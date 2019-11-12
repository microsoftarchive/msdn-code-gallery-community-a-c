window.onresize = resize;

var map = null;
var mapHeight = 0;
var bmKey = "YOUR_BING_MAPS_KEY";
var d3MapTools = null;
var schdstLayer = null;
var schdst = null;
var l1 = 0;

(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);

        map = new Microsoft.Maps.Map(document.getElementById('divMap'), {
            credentials: bmKey,
            mapTypeId: Microsoft.Maps.MapTypeId.road,
            center: new Microsoft.Maps.Location(47.490860, -121.835747),
            zoom: 9,
            showDashboard: true,
            enableClickableLogo: false,
            enableSearchLogo: false
        });

        //Register and load the D3 Overlay Module
        Microsoft.Maps.registerModule("D3OverlayModule", "scripts/D3OverlayManager.js");
        Microsoft.Maps.loadModule("D3OverlayModule", {
            callback: resize
        });
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };
})();

function resize() {
    var mapDiv = document.getElementById("divMap");
    var windowHeight = $(window).height();
    mapHeight = windowHeight - 50;
    mapDiv.style.height = mapHeight + "px";
}

function toggleDS1() {
    if (l1 == 0) {
        l1 = 1;
        loadSchDst();
    }
    else {
        l1 = 0;
        d3MapTools.removeLayer(schdstLayer);
    }
}

function loadSchDst() {
    d3MapTools = new D3OverlayManager(map);
    schdstLayer = d3MapTools.addLayer({
        loaded: function (svg, projection) {
            //Add the school districts to the svg layer.
            d3.json('data/schdst_area_3.js', function (error, topology) {
                var topoData = topojson.feature(topology, topology.objects.schdst_area).features;

                schdst = svg.selectAll('path')
                    .data(topoData)
                  .enter().append('path')
                    .attr('class', 'schdst')
                    .attr('d', projection)
                .on('click', function (feature) {
                    alert('You clicked on school-district: ' + feature.properties.Name);
                });
            });
        }
    });
}
