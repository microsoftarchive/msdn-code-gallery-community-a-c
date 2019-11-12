var map, currentAnimation;

var path = [
    new Microsoft.Maps.Location(42.8, 12.49),   //Italy
    new Microsoft.Maps.Location(51.5, 0),       //London
    new Microsoft.Maps.Location(40.8, -73.8),   //New York
    new Microsoft.Maps.Location(47.6, -122.3)   //Seattle
];

function GetMap() {
    map = new Microsoft.Maps.Map(document.getElementById("myMap"), {
        credentials: "YOUR_BING_MAPS_KEY"
    });

    //Load the Animation Module
    Microsoft.Maps.loadModule("AnimationModule");
}

function ClearMap() {
    map.entities.clear();

    if (currentAnimation != null) {
        currentAnimation.stop();
        currentAnimation = null;
    }
}

function ScalingPin() {
    ClearMap();

    var pin = new Microsoft.Maps.Pushpin(map.getCenter(), { typeName: 'scaleStyle' });
    map.entities.push(pin);
}

function DropPin() {
    ClearMap();

    var pin = new Microsoft.Maps.Pushpin(map.getCenter());
    map.entities.push(pin);

    Bing.Maps.Animations.PushpinAnimations.Drop(pin);
}

function BouncePin() {
    ClearMap();

    var pin = new Microsoft.Maps.Pushpin(map.getCenter());
    map.entities.push(pin);

    Bing.Maps.Animations.PushpinAnimations.Bounce(pin);
}

function Bounce4Pins() {
    ClearMap();

    var idx = 0;

    for (var i = 0; i < path.length; i++) {
        setTimeout(function () {
            var pin = new Microsoft.Maps.Pushpin(path[idx]);
            map.entities.push(pin);

            Bing.Maps.Animations.PushpinAnimations.Bounce(pin);
            idx++;
        }, i * 500);
    }
}

function MovePinOnPath(isGeodesic) {
    ClearMap();

    var pin = new Microsoft.Maps.Pushpin(path[0]);
    map.entities.push(pin);

    currentAnimation = new Bing.Maps.Animations.PathAnimation(path, function (coord) {
        pin.setLocation(coord);
    }, isGeodesic, 40000);

    currentAnimation.play();
}

function MoveMapOnPath(isGeodesic) {
    ClearMap();

    //Change zooms levels as map reaches points along path.
    var zooms = [5, 4, 6, 5];

    map.setView({ center: path[0], zoom: zooms[0] });

    currentAnimation = new Bing.Maps.Animations.PathAnimation(path, function (coord, idx) {
        map.setView({ center: coord, zoom: zooms[idx] });
    }, isGeodesic, 100000);

    currentAnimation.play();
}

function DrawPath(isGeodesic) {
    ClearMap();

    var line;

    currentAnimation = new Bing.Maps.Animations.PathAnimation(path, function (coord, idx, frameIdx) {
        if (frameIdx == 1) {
            //Create the line the line after the first frame so that we have two points to work with.
            line = new Microsoft.Maps.Polyline([path[0], coord]);
            map.entities.push(line);
        }
        else if (frameIdx > 1) {
            var points = line.getLocations();
            points.push(coord);
            line.setLocations(points);
        }
    }, isGeodesic, 40000);

    currentAnimation.play();
}

//Initialization logic for loading the map control
(function () {
    function initialize() {
        Microsoft.Maps.loadModule('Microsoft.Maps.Map', { callback: GetMap });
    }

    document.addEventListener("DOMContentLoaded", initialize, false);
})();