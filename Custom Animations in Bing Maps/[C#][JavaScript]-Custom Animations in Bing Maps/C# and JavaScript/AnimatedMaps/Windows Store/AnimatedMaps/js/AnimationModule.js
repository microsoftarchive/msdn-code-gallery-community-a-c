/***************************************************************
* Animation Module
*
* Author: Ricky Brundritt
* Website: http://rbrundritt.wordpress.com
* Date: July 5th, 2014
* 
* This module contains a number of class for performing animations on Bing Maps. 
*
* Module Name: AnimationModule
* Namespace: Bing.Maps.Animations
*
* Simple Pushpin Animations:
* --------------------------
*
* Drop - Drops a pushpin from a height above the map and places it on a location.
* Bounce - Drops a pushpin from a height above the map and bounces it to rest on a location.
*
* Path Animaiton Class:
* ---------------------
*
* Takes a set off coordinates and loops through them over a period of time. 
* A callback is used on each timer tick so that you can update the UI.
*
* Base Animation Class:
*----------------------
*
* A base class for creating animations that support play, pause and start.
*
****************************************************************/

window.Bing = window.Bing || {};
window.Bing.Maps = window.Bing.Maps || {};
window.Bing.Maps.Animations = new function () {
    var _delay = 30,
        EARTH_RADIUS_KM = 6378.1;

    this.Pushpin = {
        Drop:  function (pin, height, duration) {
            /// <summary>A simple animation that drops a pin from a height above it's destinated location onto the map.</summary>
            /// <param name="pin" type="Microsoft.Maps.Pushpin">The pushpin to perform the animation on.</param>
            /// <param name="height" type="Number">The height above the destinated location to drop the pushpin from. Default is 150 pixels.</param>
            /// <param name="duration" type="Number">Length of time in ms that the animation should run for. Default is 150 ms.</param>

            height = (height && height > 0) ? height : 150;
            duration = (duration && duration > 0) ? duration : 150;

            var anchor = pin.getAnchor();
            var from = anchor.y + height;

            pin.setOptions({ anchor: new Microsoft.Maps.Point(anchor.x, anchor.y + height) });

            simpleAnimation(linear,
                function (delta) {
                    var y = from - height * delta;
                    pin.setOptions({ anchor: new Microsoft.Maps.Point(anchor.x, y) });
                },
                duration
            );
        },

        Bounce: function (pin, height, duration) {
            /// <summary>A simple animation that drops a pin from a height above it's destinated location onto the map and bounce's it to rest.</summary>
            /// <param name="pin" type="Microsoft.Maps.Pushpin">The pushpin to perform the animation on.</param>
            /// <param name="height" type="Number">The height above the destinated location to drop the pushpin from. Default is 150 pixels.</param>
            /// <param name="duration" type="Number">Length of time in ms that the animation should run for. Default is 1000 ms.</param>

            height = (height && height > 0) ? height : 150;
            duration = (duration && duration > 0) ? duration : 1000;

            var anchor = pin.getAnchor();
            var from = anchor.y + height;

            pin.setOptions({ anchor: new Microsoft.Maps.Point(anchor.x, anchor.y + height) });

            simpleAnimation(bounce,
                function (delta) {
                    var y = from - height * delta;
                    pin.setOptions({ anchor: new Microsoft.Maps.Point(anchor.x, y) });
                },
                duration
            );
        }
    };

    this.PathAnimation = function (path, intervalCallback, isGeodesic, duration) {
        /// <summary>This class extends from the BaseAnimation class and cycles through a set of coordinates over a period of time, calculating mid-point coordinates along the way.</summary>
        /// <param name="path" type="Microsoft.MApsLocation[]">An array of locations to cycle through.</param>
        /// <param name="intervalCallback" type="Function">A function that is called when a frame is to be rendered. This callback function recieves four values; current cordinate, index on path and frame index.</param>
        /// <param name="isGeodesic" type="Boolean">Indicates if the path should follow the curve of the earth.</param>
        /// <param name="duration" type="Number">Length of time in ms that the animation should run for. Default is 1000 ms.</param>

        var _totalDistance = 0, 
            _intervalLocs = [path[0]],
            _intervalIdx = [0],
            _frameCount = Math.ceil(duration / _delay), idx;

        var progress, dlat, dlon;

        if (isGeodesic) {
            //Calcualte the total distance along the path in KM's.
            for (var i = 0; i < path.length - 1; i++) {
                _totalDistance += haversineDistance(path[i], path[i + 1]);
            }
        }else{
            //Calcualte the total distance along the path in degrees.
            for (var i = 0; i < path.length - 1; i++) {
                dlat = (path[i + 1].latitude - path[i].latitude);
                dlon = (path[i + 1].longitude - path[i].longitude);

                _totalDistance += Math.sqrt(dlat*dlat + dlon*dlon);
            }
        }

        //Pre-calculate step points for smoother rendering.
        for (var f = 0; f < _frameCount; f++) {
            progress = (f * _delay) / duration;

            var travel = progress * _totalDistance;
            var alpha;
            var dist = 0;
            var dx = travel;

            for (var i = 0; i < path.length - 1; i++) {

                if(isGeodesic){
                    dist += haversineDistance(path[i], path[i + 1]);
                }else {
                    dlat = (path[i + 1].latitude - path[i].latitude);
                    dlon = (path[i + 1].longitude - path[i].longitude);
                    alpha = Math.atan2(dlat * Math.PI / 180, dlon * Math.PI / 180);
                    dist += Math.sqrt(dlat * dlat + dlon * dlon);
                }

                if (dist >= travel) {
                    idx = i;
                    break;
                }

                dx = travel - dist;
            }

            if (dx != 0 && idx < path.length - 1) {
                if (isGeodesic) {
                    var bearing = calculateBearing(path[idx], path[idx + 1]);
                    _intervalLocs.push(calculateCoord(path[idx], bearing, dx));
                }else{
                    dlat = dx * Math.sin(alpha);
                    dlon = dx * Math.cos(alpha);

                    _intervalLocs.push(new Microsoft.Maps.Location(path[idx].latitude + dlat, path[idx].longitude + dlon));
                }

                _intervalIdx.push(idx);
            }
        }

        //Ensure the last location is the last coordinate in the path.
        _intervalLocs.push(path[path.length - 1]);
        _intervalIdx.push(path.length - 1);

        return new Bing.Maps.Animations.BaseAnimation(
            function (progress, frameIdx) {

                if (intervalCallback) {
                    intervalCallback(_intervalLocs[frameIdx], _intervalIdx[frameIdx], frameIdx);
                }
            }, duration);
    };

    this.BaseAnimation = function (renderFrameCallback, duration) {
        /// <summary>A base class that can be used to create animations that support play, pause and stop.</summary>
        /// <param name="renderFrameCallback" type="Function">A function that is called when a frame is to be rendered. This function recieves two values; progress and frameIdx.</param>
        /// <param name="duration" type="Number">Length of time in ms that the animation should run for. Default is 1000 ms.</param>

        var _timerId,
            frameIdx = 0,
            _isPaused = false;

        //Varify value 
        duration = (duration && duration > 0) ? duration : 1000;

        this.play = function () {
            if (renderFrameCallback) {
                if (_timerId) {
                    _isPaused = false;
                } else {
                    _timerId = setInterval(function () {
                        if (!_isPaused) {                            
                            var progress = (frameIdx * _delay) / duration;

                            renderFrameCallback(progress, frameIdx);

                            if (progress >= 1) {
                                reset();
                            }

                            frameIdx++;
                        }
                    });
                }
            }
        };

        this.pause = function () {
            _isPaused = true;
        };

        this.stop = function () {
            reset();
        };

        function reset() {
            if (_timerId != null) {
                clearInterval(_timerId);
            }

            frameIdx = 0;
            _isPaused = false;
        }
    };

    /**** Helper methods - Simple Animations *****/

    function simpleAnimation(delta, step, duration) {
        /// <summary>A method for running simple animations over a period of time.</summary>
        /// <param name="delta" type="Function">A function that calculates the progress offset.</param>
        /// <param name="step" type="Function">A function that is called when a frame is to be rendered.</param>
        /// <param name="duration" type="Number">Length of time in ms that the animation should run for. Default is 150 ms.</param>
        
        var _timerId,
            _frame = 0;

        duration = (duration && duration > 0) ? duration : 150;

        _timerId = setInterval(function () {
            var progress = (_frame * _delay) / duration;

            if (progress > 1) {
                progress = 1;
            }

            step(delta(progress));

            if (progress == 1) {
                clearInterval(_timerId);
            }

            _frame++;
        }, _delay);
    }

    function linear(progress) {
        /// <summary>A method used for offseting an animation progress linearly.</summary>
        /// <param name="progress" type="Number">The animation progress to offset.</param>

        return progress;
    }

    function bounce(progress) {
        /// <summary>A method used for offseting an animation progress using a bounce sequence.</summary>
        /// <param name="progress" type="Number">The animation progress to offset.</param>

        return 1 - Math.abs(Math.cos(progress * 2.5 * Math.PI)) / Math.exp(3 * progress);
    }

    /**** Helper methods - Spatial *****/

    function degToRad(x) {
        return x * Math.PI / 180;
    }

    function radToDeg(x) {
        return x * 180 / Math.PI;
    }

    function haversineDistance(origin, dest) {
        /// <summary>Calculates the distance between two locations in KM's.</summary>
        /// <param name="origin" type="Microsoft.Maps.Location">Initial location.</param>
        /// <param name="dest" type="Microsoft.Maps.Location">Second location.</param>

        var lat1 = degToRad(origin.latitude),
            lon1 = degToRad(origin.longitude),
            lat2 = degToRad(dest.latitude),
            lon2 = degToRad(dest.longitude);

        var dLat = lat2 - lat1,
        dLon = lon2 - lon1,
        cordLength = Math.pow(Math.sin(dLat / 2), 2) + Math.cos(lat1) * Math.cos(lat2) * Math.pow(Math.sin(dLon / 2), 2),
        centralAngle = 2 * Math.atan2(Math.sqrt(cordLength), Math.sqrt(1 - cordLength));

        return EARTH_RADIUS_KM * centralAngle;
    }

    function calculateBearing(origin, dest) {
        /// <summary>Calculates the bearing between two loacations.</summary>
        /// <param name="origin" type="Microsoft.Maps.Location">Initial location.</param>
        /// <param name="dest" type="Microsoft.Maps.Location">Second location.</param>

        var lat1 = degToRad(origin.latitude);
        var lon1 = origin.longitude;
        var lat2 = degToRad(dest.latitude);
        var lon2 = dest.longitude;
        var dLon = degToRad(lon2 - lon1);
        var y = Math.sin(dLon) * Math.cos(lat2);
        var x = Math.cos(lat1) * Math.sin(lat2) - Math.sin(lat1) * Math.cos(lat2) * Math.cos(dLon);
        return (radToDeg(Math.atan2(y, x)) + 360) % 360;
    }

    function calculateCoord(origin, brng, arcLength) {
        /// <summary>Calculates a destination coordinate given a starting location, bearing, and distance in KM's.</summary>
        /// <param name="origin" type="Microsoft.Maps.Location">Initial location.</param>
        /// <param name="brng" type="Number">Bearing pointing towards new location.</param>
        /// <param name="arcLength" type="Number">A distance in KM's.</param>

        var lat1 = degToRad(origin.latitude),
        lon1 = degToRad(origin.longitude),
        centralAngle = arcLength / EARTH_RADIUS_KM;

        var lat2 = Math.asin(Math.sin(lat1) * Math.cos(centralAngle) + Math.cos(lat1) * Math.sin(centralAngle) * Math.cos(degToRad(brng)));
        var lon2 = lon1 + Math.atan2(Math.sin(degToRad(brng)) * Math.sin(centralAngle) * Math.cos(lat1), Math.cos(centralAngle) - Math.sin(lat1) * Math.sin(lat2));

        return new Microsoft.Maps.Location(radToDeg(lat2), radToDeg(lon2));
    }
};

// Call the Module Loaded method
Microsoft.Maps.moduleLoaded('AnimationModule');