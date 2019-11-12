/***************************************************************
* D3 Overlay Module
*
* Author: Ricky Brundritt
* Website: http://rbrundritt.wordpress.com
* Date: Jan 22nd, 2015
* 
*
***************************************************************/

var D3OverlayManager = function (map) {

    var _d3Projection = null,
        _center,
        _zoom,
        _mapWidth,
        _mapHeight,
        _mapDiv,
        _d3Container,
        _layers = [],
        _idCnt = 0,
        _worldWidth = 512,
        _prevX = null;

    function _init() {
        _mapDiv = map.getRootElement();

        if (_mapDiv.childNodes.length >= 3 && _mapDiv.childNodes[2].childNodes.length >= 2) {
            _d3Container = document.createElement('div');
            _d3Container.style.position = 'absolute';
            _d3Container.style.top = '0px';
            _d3Container.style.left = '0px';
            _mapDiv.childNodes[2].childNodes[1].appendChild(_d3Container);

            _center = map.getCenter();
            _zoom = map.getZoom();
            _mapWidth = map.getWidth();
            _mapHeight = map.getHeight();

            _d3Projection = d3.geo.path().projection(_mapProjection);

            Microsoft.Maps.Events.addHandler(map, 'viewchange', function () {
                var z = map.getZoom();

                if (z != _zoom) {
                    _d3Container.style.display = 'none';
                } else {
                    _d3Container.style.display = '';

                    var cPixel = map.tryLocationToPixel(_center, Microsoft.Maps.PixelReference.viewport);
                    _d3Container.style.top = cPixel.y + 'px';
                    _d3Container.style.left = cPixel.x + 'px';
                }
            });

            Microsoft.Maps.Events.addHandler(map, 'viewchangeend', function () {
                _d3Container.style.display = '';

                _d3Container.style.top = '0px';
                _d3Container.style.left = '0px';

                _worldWidth = Math.pow(2, map.getZoom()) * 256;
                _prevX = { x: 0, y: 0 };

                if (_mapHeight != map.getHeight() || _mapWidth != map.getWidth()) {
                    //Map was resized. Resize layers.
                    _mapWidth = map.getWidth();
                    _mapHeight = map.getHeight();
                }

                for (var i = 0; i < _layers.length; i++) {
                    if (_layers[i].svg) {
                        //Enusre layers are the same size as the map.
                        _layers[i].svg.attr("width", _mapWidth);
                        _layers[i].svg.attr("height", _mapHeight);
                        _layers[i].svg[0][0].style.left = -_mapWidth / 2 + 'px';
                        _layers[i].svg[0][0].style.top = -_mapHeight / 2 + 'px';

                        //Update data to align with projection
                        _layers[i].svg.selectAll('path').attr("d", _d3Projection);
                    }
                }

                _center = map.getCenter();
                _zoom = map.getZoom();
            });
        } else {
            //Map not fully loaded yet, try again in 100ms
            setTimeout(_init, 100);
        }
    }

    function _mapProjection(coordinates) {
        var loc = new Microsoft.Maps.Location(coordinates[1], coordinates[0]);
        var pixel = map.tryLocationToPixel(loc, Microsoft.Maps.PixelReference.control);

        //Workaround to ensure polygons are rendered properly when more than one world is visible.
        if (_prevX != null) {
            // Check for a gigantic jump to prevent wrapping around the world
            var dist = pixel.x - _prevX;
            if (Math.abs(dist) > (_worldWidth * 0.9)) {
                if (dist > 0) { pixel.x -= _worldWidth } else { pixel.x += _worldWidth }
            }
        }
        _prevX = pixel.x;

        return [pixel.x, pixel.y];
    }

    /*******************
    * Public functions
    ********************/

    this.addLayer = function (options) {

        //options = {
        //    loaded: function (svg, projection) { },    //Callback that is fired when the layer has been loaded.
        //    viewChanged: function (svg, projection) { }    //Callback that is fired when the view needs updating
        //}

        var _id = _idCnt++,
            layerInfo = {
                id: _idCnt,
                options: options
            };

        function _initLayer() {
            if (_d3Container) {
                layerInfo.svg = d3.select(_d3Container).append('svg')
                            .attr('width', _mapWidth)
                            .attr('height', _mapHeight);

                layerInfo.svg[0][0].style.position = 'relative';
                layerInfo.svg[0][0].style.left = -_mapWidth / 2 + 'px';
                layerInfo.svg[0][0].style.top = -_mapHeight / 2 + 'px';

                if (options && options.loaded) {
                    options.loaded(layerInfo.svg, _d3Projection);
                }
            } else {
                //Map not fully loaded yet, try again in 100ms
                setTimeout(_initLayer, 100);
            }
        }

        _initLayer();

        _layers.push(layerInfo);

        return layerInfo;
    };

    this.removeLayer = function (layer) {
        for (var i = 0; i < _layers.length; i++) {
            if (_layers[i].id == layer.id) {
                _d3Container.removeChild(layer.svg);
                _layer.splice(i, 1);
                break;
            }
        }
    };

    _init();
};

// Call the Module Loaded method
Microsoft.Maps.moduleLoaded('D3OverlayModule');
