// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
// PARTICULAR PURPOSE. 
// 
// Copyright (c) Microsoft Corporation. All rights reserved 

// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    var app = WinJS.Application;

    // This function responds to all application activations.
    app.onactivated = function (eventObject) {
        if (eventObject.detail.kind === Windows.ApplicationModel.Activation.ActivationKind.launch) {
            
            WinJS.UI.processAll();
        }
    };

    app.start();

    // set view api to show Birdseye view
    function setView() 
    {
        resetMapDiv();
        map.setView({ center: new Microsoft.Maps.Location(47.6215, -122.349329), mapTypeId: Microsoft.Maps.MapTypeId.auto, zoom: 18 });
    }
    // set view api to pan map
    function pan(x, y) 
    {
        resetMapDiv();
        var mapCenter = map.getCenter();
        var pos = map.tryPixelToLocation(new Microsoft.Maps.Point(map.getWidth() / 2 + x, map.getHeight() / 2 - (y - 1)), Microsoft.Maps.PixelReference.control);
        mapCenter.latitude += pos.latitude - mapCenter.latitude;
        mapCenter.longitude += pos.longitude - mapCenter.longitude;
        map.setView({ center: mapCenter });
    }
    // api to add pin on map
    function addPushpin() 
    {
        resetMapDiv();
        var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), null);
        map.entities.push(pushpin);
    }
    // api to add custom pin on map
    function addCustomPushpin()
    {
        resetMapDiv();
        var html = '<div style="overflow: hidden; "><img src="http://www.bingmapsportal.com/Content/poi_custom.png" alt="pin"></div>';
        var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), { htmlContent: html });
        map.entities.push(pushpin);
    }
    // api to add polygon on map
    function addPolygon() 
    {
        resetMapDiv();
        var center = map.getCenter();
        addCircle(center.latitude, center.longitude);
    }
    // add circle on map
    function addCircle(latitude, longitude) 
    {
        resetMapDiv();
        var radius;
        var zoom = map.getZoom();
        // calculate radius in KMs based on zoom level so that circle is displayed in current bounds
        switch (Math.floor(zoom / 4)) {
            case 0:
                radius = 500;
                break;
            case 1:
                radius = 100;
                break;
            case 2:
                radius = 50;
                break;
            case 3:
                radius = 5;
                break;
            default:
                radius = 0.1;
                break;

        }

        var R = 6371; // earth's mean radius in km
        var lat = (latitude * Math.PI) / 180;
        var lon = (longitude * Math.PI) / 180;
        var d = parseFloat(radius) / R; 
        var circle= new Array();
        for (var x = 0; x <= 360; x++) {
            var r = x * Math.PI / 180; //rad
            var cirLat = Math.asin(Math.sin(lat) * Math.cos(d) + Math.cos(lat) * Math.sin(d) * Math.cos(r));
            var cirLong = ((lon + Math.atan2(Math.sin(r) * Math.sin(d) * Math.cos(lat), Math.cos(d) - Math.sin(lat) * Math.sin(cirLat))) * 180) / Math.PI;
            cirLat = (cirLat * 180) / Math.PI;
            circle.push(new Microsoft.Maps.Location(cirLat, cirLong));
        }
        var polygoncolor = new Microsoft.Maps.Color(Math.round(255 * Math.random()), Math.round(255 * Math.random()), Math.round(255 * Math.random()), Math.round(255 * Math.random()));
        var polygon = new Microsoft.Maps.Polygon(circle, { fillColor: polygoncolor, strokeColor: polygoncolor });
        // Add the polygon to the map
        map.entities.push(polygon);
    }
    // api to add infobox on map
   function addInfobox() 
   {
        resetMapDiv();
        var infobox = new Microsoft.Maps.Infobox(map.getCenter(), {
            height: 100, title: 'Infobox Title', description: 'Description comes here', titleClickHandler: function () { }, actions: [{ label: 'Action1', eventHandler: function () { } }, { label: 'Action2', eventHandler: function () { } }]
        });
        map.entities.push(infobox);
    }
    // api to add tilelayer on map
    function addtilelayer() 
    {
        resetMapDiv();
        var options = { uriConstructor: 'http://www.microsoft.com/maps/isdk/ajax/layers/lidar/{quadkey}.png', width: 256, height: 256 };
        var tileSource = new Microsoft.Maps.TileSource(options);
        var tilelayer = new Microsoft.Maps.TileLayer({ mercator: tileSource });
        map.entities.push(tilelayer);
        //center map to show tile layer
        map.setView({ center: new Microsoft.Maps.Location(48.03, -122.42), zoom: 11 });
    }

    // api to add tilelayer on map
    function addtraffic() 
    {
        resetMapDiv();
        Microsoft.Maps.loadModule('Microsoft.Maps.Traffic', { callback: trafficModuleLoaded });
    }

    function trafficModuleLoaded() 
    {
        //set center 
        map.setView({ center: new Microsoft.Maps.Location(40.71, -74.00), zoom: 8 });
        var trafficManager = new Microsoft.Maps.Traffic.TrafficManager(map);
        // show all traffic data
        trafficManager.show();
    }
    // api to add tilelayer on map
    function addBingThemeMap() 
    {
        resetMapDiv();
        Microsoft.Maps.loadModule('Microsoft.Maps.Themes.BingTheme', {
            callback: function () {
                var id = 'Your Bing Maps Key';
                map = new Microsoft.Maps.Map(document.getElementById('mapdiv'),
                {
                    credentials: id,
                    center: new Microsoft.Maps.Location(47.60, -122.33),
                    zoom: 10,
                    theme: new Microsoft.Maps.Themes.BingTheme()
                });
                var pin1 = new Microsoft.Maps.Pushpin(map.getCenter(), null);
                map.entities.push(pin1);
                map.entities.push(new Microsoft.Maps.Infobox(map.getCenter(), { title: 'Seattle', description: 'description here', pushpin: pin1 }));
                var pin2 = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(47.45, -122.33), null);
                map.entities.push(pin2);
                map.entities.push(new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(47.45, -122.33), { title: 'Tacoma', description: 'description here', pushpin: pin2 }));
            }
        });
    }
    
    function addComplexShapes() 
    {
        resetMapDiv();
        Microsoft.Maps.loadModule('Microsoft.Maps.AdvancedShapes', {
            callback: function () {

                var polygon = new Microsoft.Maps.Polygon([
                        [new Microsoft.Maps.Location(47.604, -121.940),
                            new Microsoft.Maps.Location(47.604, -121.540),
                            new Microsoft.Maps.Location(47.834, -121.540),
                            new Microsoft.Maps.Location(47.834, -121.940),
                            new Microsoft.Maps.Location(47.604, -121.940)],
                        [new Microsoft.Maps.Location(47.704, -121.740),
                            new Microsoft.Maps.Location(47.704, -121.640),
                            new Microsoft.Maps.Location(47.804, -121.640),
                            new Microsoft.Maps.Location(47.804, -121.740),
                            new Microsoft.Maps.Location(47.704, -121.740)],
                        [new Microsoft.Maps.Location(47.744, -121.700),
                            new Microsoft.Maps.Location(47.744, -121.680),
                            new Microsoft.Maps.Location(47.764, -121.680),
                            new Microsoft.Maps.Location(47.764, -121.700),
                            new Microsoft.Maps.Location(47.744, -121.700)]]);
                map.entities.push(polygon);
                map.setView({ zoom: 11, center: new Microsoft.Maps.Location(47.704, -121.740) });
            }
        });
    }
    // api to load custom module
    function customModule() 
    {
        resetMapDiv();
        Microsoft.Maps.loadModule('clusterModule', { callback: customModuleLoaded });
        map.setView({ zoom: 1, center: new Microsoft.Maps.Location(0, 0), mapTypeId: Microsoft.Maps.MapTypeId.road });
    }
   
    // custom module callback
    function customModuleLoaded() 
    {
        map.entities.clear();
       
        testDataGenerator.generateData(100, dataCallback);
    }
    // api to load venue map module on map
    function addVM() 
    {
        resetMapDiv();
        Microsoft.Maps.loadModule('Microsoft.Maps.VenueMaps', { callback: vmCallback });
    }
    // venue map module callback
    function vmCallback() 
    {
        var venueMapFactory = new Microsoft.Maps.VenueMaps.VenueMapFactory(map);
        venueMapFactory.create({
                                    venueMapId: 'hcl-timessquare',
                                    success: success,
                                    error: err
                              });
    }
    // error callback for venue map
    function err(errorCode, args) 
    {
        var message = 'Error while loading venue map. Errorcode : ' + errorCode;
        var md = new Windows.UI.Popups.MessageDialog(message);
        md.showAsync();
    }

    // success callback from venue map callback
    function success(venueMap, args) 
    {
        venueMap.show();
        map.setView(venueMap.bestMapView);
    }

    var searchManager = null;
    var currInfobox = null;
    // callback function to create searchManager once search module is loaded
    function createSearchManager()
    {
        if (!searchManager)
        {
            map.addComponent('searchManager', new Microsoft.Maps.Search.SearchManager(map));
            searchManager = map.getComponent('searchManager');
        }
    }

    // business search api request
    function search()
    {
        resetMapDiv();
        if (searchManager)
        {
            searchRequest();
        }
        else
        {
            Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: searchRequest });
        }
    }

    // business search api
    function searchRequest()
    {
        createSearchManager();
        var what = 'pizza';
        var userData = { name: 'Maps Test User', id: 'XYZ' };
        var where = 'boston, ma';
        var query = '';
        var request =
            {
                what: what,
                where: where,
                query: query,
                count: 10,
                startIndex: 0,
                bounds: map.getBounds(),
                callback: search_onSearchSuccess,
                errorCallback: search_onSearchFailure,
                userData: userData
            };
        searchManager.search(request);
    }

    // business search api success callback
    function search_onSearchSuccess(result, userData)
    {
        map.entities.clear();
        var searchResults = result && result.searchResults;
        if (searchResults)
        {
            for (var i = 0; i < searchResults.length; i++)
            {
                search_createMapPin(searchResults[i]);
            }

            if (result.searchRegion && result.searchRegion.mapBounds)
            {
                map.setView({ bounds: result.searchRegion.mapBounds.locationRect });
            }
        }
    }
    // business search api failure callback
    function search_onSearchFailure(result, userData)
    {
        var md = new Windows.UI.Popups.MessageDialog("Search failed");
        md.showAsync();
    }

    // business search api display search results
    function search_createMapPin(result)
    {
        if (result)
        {
            var pin = new Microsoft.Maps.Pushpin(result.location, null);
            Microsoft.Maps.Events.addHandler(pin, 'click', function () { search_showInfoBox(result) });
            map.entities.push(pin);
        }
    }

    // business search api infobox
    function search_showInfoBox(result)
    {
        if (currInfobox)
        {
            currInfobox.setOptions({ visible: true });
            map.entities.remove(currInfobox);
        }
        currInfobox = new Microsoft.Maps.Infobox(
            result.location,
            {
                title: result.name,
                description: [result.address, result.city, result.state, result.country, result.phone].join(" "),
                showPointer: true,
                titleAction: null,
                titleClickHandler: null
            });

        currInfobox.setOptions({ visible: true });
        map.entities.push(currInfobox);
    }

    // reverse geocode api request
    function reverseGeocode()
    {
        resetMapDiv();
        if (searchManager)
        {
            reverseGeocodeRequest();
        }

        else
        {
            Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: reverseGeocodeRequest });
        }
    }

    // reverse geocode api
    function reverseGeocodeRequest()
    {
        createSearchManager();
        var userData = { name: 'Maps Test User', id: 'XYZ' };
        var request =
		{
		    location: map.getCenter(),
		    callback: onReverseGeocodeSuccess,
		    errorCallback: onReverseGeocodeFailed,
		    userData: userData
		};
        searchManager.reverseGeocode(request);
    }

    // reverse geocode api request success callback
    function onReverseGeocodeSuccess(result, userData)
    {
        if (result)
        {
            map.entities.clear();
            var pushpin = new Microsoft.Maps.Pushpin(result.location, null);
            map.setView({ center: result.location, zoom: 10 });
            map.entities.push(pushpin);
        }
    }

    // reverse geocode api request failure callback
    function onReverseGeocodeFailed(result, userData)
    {
        var md = new Windows.UI.Popups.MessageDialog("Reverse Geocode failed");
        md.showAsync();
    }

    // geocode api request
    function geocode()
    {
        resetMapDiv();
        if (searchManager)
        {
            geocodeRequest();
        }
        else
        {
            Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: geocodeRequest });
        }
    }

    // geocode api request
    function geocodeRequest()
    {
        createSearchManager();
        var where = 'Denver, CO';
        var userData = { name: 'Maps Test User', id: 'XYZ' };
        var request =
		{
		    where: where,
		    count: 2,
		    bounds: map.getBounds(),
		    callback: onGeocodeSuccess,
		    errorCallback: onGeocodeFailed,
		    userData: userData
		};
        searchManager.geocode(request);
    }

    // geocode api request success callback
    function onGeocodeSuccess(result, userData)
    {
        if (result)
        {
            map.entities.clear();
            var MM = Microsoft.Maps;
            var topResult = result.results && result.results[0];
            if (topResult)
            {
                var pushpin = new MM.Pushpin(topResult.location, null);
                map.setView({ center: topResult.location, zoom: 10 });
                map.entities.push(pushpin);
            }
        }
    }

    // geocode api request failure callback
    function onGeocodeFailed(result, userData)
    {
        var md = new Windows.UI.Popups.MessageDialog("Geocode failed");
        md.showAsync();
    }

    // api to use Rest direction service
    function getDirections() 
    {
        map.getCredentials( function(credentials) 
        {
            var start= 'Boston, MA'; var end= 'New York, NY'; 
            var routeRequest = 'http://dev.virtualearth.net/REST/v1/Routes?wp.0=' + start + '&wp.1=' + end + '&routePathOutput=Points&output=json&key=' + credentials;
            WinJS.xhr({ url: routeRequest }).then(routeCallback);
        });
    }
    // route callback
    function routeCallback(result)    {           result = JSON.parse(result.responseText);
          if (result && result.resourceSets && result.resourceSets.length > 0 && result.resourceSets[0].resources && result.resourceSets[0].resources.length > 0 && result.resourceSets[0].resources[0].routeLegs.length > 0)           {              // instruction list can be displayed using below code              var resultsListItem = null;              var resultsList = document.createElement("ol");
              for (var i = 0; i < result.resourceSets[0].resources[0].routeLegs[0].itineraryItems.length; ++i)              {                  resultsListItem = document.createElement("li");                  resultsList.appendChild(resultsListItem);                  var resultStr = result.resourceSets[0].resources[0].routeLegs[0].itineraryItems[i].instruction.text;                  resultsListItem.innerHTML = resultStr;              }              var bbox = result.resourceSets[0].resources[0].bbox;               var viewBoundaries = Microsoft.Maps.LocationRect.fromLocations(new Microsoft.Maps.Location(bbox[0], bbox[1]), new Microsoft.Maps.Location(bbox[2], bbox[3]));              map.setView({ bounds: viewBoundaries});               var routeline = result.resourceSets[0].resources[0].routePath.line;               var routepoints = new Array();               for (var i = 0; i < routeline.coordinates.length; i++)               {                   routepoints[i]=new Microsoft.Maps.Location(routeline.coordinates[i][0], routeline.coordinates[i][1]);              }               var routeshape = new Microsoft.Maps.Polyline(routepoints, {strokeColor:new Microsoft.Maps.Color(200,0,0,200)});               var startPushpinOptions = { icon: '/images/start.png', anchor: new Microsoft.Maps.Point(3, 28) };               var startPin= new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(routeline.coordinates[0][0], routeline.coordinates[0][1]), startPushpinOptions);               var endPushpinOptions = { icon: '/images/end.png', anchor: new Microsoft.Maps.Point(3, 28)};               var endPin= new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(routeline.coordinates[routeline.coordinates.length-1][0], routeline.coordinates[routeline.coordinates.length-1][1]), endPushpinOptions);               map.entities.push(startPin);               map.entities.push(endPin);               map.entities.push(routeshape);         }   }   
    // api to use Rest direction service
    function getDD() {
        Microsoft.Maps.loadModule('Microsoft.Maps.Directions', { callback: createDrivingDirections });
    }
      
    function createDrivingDirections()
    {
        document.getElementById("directionsItinerary").style.display = "block";
        document.getElementById("mapdiv").style.width = "75%";
        var directionsManager;
        directionsManager = new Microsoft.Maps.Directions.DirectionsManager(map);
        // Set Route Mode to driving 
        directionsManager.setRequestOptions({ routeMode: Microsoft.Maps.Directions.RouteMode.driving });
        var seattleWaypoint = new Microsoft.Maps.Directions.Waypoint({ address: 'Seattle, WA' });
        directionsManager.addWaypoint(seattleWaypoint);
        var tacomaWaypoint = new Microsoft.Maps.Directions.Waypoint({ address: 'Tacoma, WA', location: new Microsoft.Maps.Location(47.255134, -122.441650) });
        directionsManager.addWaypoint(tacomaWaypoint);
        // Set the element in which the itinerary will be rendered
        directionsManager.setRenderOptions({ itineraryContainer: document.getElementById('directionsItinerary') });
  //      alert('Calculating directions...');
        directionsManager.calculateDirections();
    }

    // clear map entities
    function clearMap() 
    {
        resetMapDiv(); 
        map.entities.clear();
    }
    // close app
    function close() 
    {
        window.close();
    }

    function initialize()
    {
        // allow culture & homeRegion in call back function
        Microsoft.Maps.loadModule('Microsoft.Maps.Map', { callback: initMap, homeRegion: 'US', culture: 'en-us' });
        document.getElementById("directions").addEventListener("click", getDD, false);
        document.getElementById("setView").addEventListener("click", setView, false);
        document.getElementById("panRight").addEventListener("click", function () { pan(16, 0) }, false);
        document.getElementById("pushpin").addEventListener("click", addPushpin, false);
        document.getElementById("customPushpin").addEventListener("click", addCustomPushpin, false);
        document.getElementById("polygon").addEventListener("click", addPolygon, false);
        document.getElementById("clear").addEventListener("click", clearMap, false);
        document.getElementById("close").addEventListener("click", close, false);
        document.getElementById("infobox").addEventListener("click", addInfobox, false);
        document.getElementById("vm").addEventListener("click", addVM, false);
        document.getElementById("cm").addEventListener("click", customModule, false);
        document.getElementById("restDirections").addEventListener("click", getDirections, false);
        document.getElementById("tilelayer").addEventListener("click", addtilelayer, false);
        document.getElementById("traffic").addEventListener("click", addtraffic, false);
        document.getElementById("bingTheme").addEventListener("click", addBingThemeMap, false);
        document.getElementById("complexShapes").addEventListener("click", addComplexShapes, false);
        document.getElementById("geocode").addEventListener("click", geocode, false);
        document.getElementById("revGeocode").addEventListener("click", reverseGeocode, false);
        document.getElementById("search").addEventListener("click", search, false);
    }
    document.addEventListener("DOMContentLoaded", initialize, false);

})();

var map;
function initMap() 
{
    try 
    {
        var mapOptions =
        {
            // Add your Bing Maps key here
            credentials: 'Your Bing Maps Key',
            center: new Microsoft.Maps.Location(40.71, -74.00),
            mapTypeId: Microsoft.Maps.MapTypeId.road,
            zoom: 8
        };
        map = new Microsoft.Maps.Map(document.getElementById("mapdiv"), mapOptions);
    }
    catch (e) 
    {
        var md = new Windows.UI.Popups.MessageDialog(e.message);
        md.showAsync();
    }
}

// help functions

function resetMapDiv()
{
    if (document.getElementById("directionsItinerary").style.display == "block")
    {
        document.getElementById("directionsItinerary").style.display = "none";
        document.getElementById("mapdiv").style.width = "100%";
    }
}
function displayInfo(e) 
{
    if (e.targetType == "pushpin") 
    {
        showInfobox(e.target);
    }
}
function showInfobox(shape) 
{
    for (var i = map.entities.getLength() - 1; i >= 0; i--) 
    {
        var pushpin = map.entities.get(i);        if (pushpin.toString() == '[Infobox]') 
        {
            map.entities.removeAt(i);
        };
    }
    var infoboxOptions = {  width: 170,                             height: 80,                             showCloseButton: true,                             zIndex: 10,                             offset: new Microsoft.Maps.Point(10, 0),                             showPointer: true,                             title: shape.title,                             description: shape.description                          };    var defInfobox = new Microsoft.Maps.Infobox(shape.getLocation(), infoboxOptions);    map.entities.push(defInfobox);
}

function createClusteredpin(cluster, latlong) 
{
    var pin = new Microsoft.Maps.Pushpin(latlong, {
                                                    icon: '/images/clusteredpin.png',
                                                    anchor: new Microsoft.Maps.Point(8, 8)
                                                  });
    pin.title = 'Cluster pin';
    pin.description = 'Number of pins : ' + cluster.length;
    Microsoft.Maps.Events.addHandler(pin, 'click', displayInfo);
    return pin;
}
    
function createPin(data) 
{
    var pin = new Microsoft.Maps.Pushpin(data._LatLong, {
                                                        icon: '/images/nonclusteredpin.png',
                                                        anchor: new Microsoft.Maps.Point(8, 8)
                                                        });
    pin.title = 'Single pin';
    pin.description = 'GridKey: ' + data.GridKey;
    Microsoft.Maps.Events.addHandler(pin, 'click', displayInfo);
    return pin;
}
function dataCallback(response) 
{
    if (response != null) 
    {
       var greenLayer = new ClusteredEntityCollection(map, 
                                                        {
                                                            singlePinCallback: createPin,
                                                            clusteredPinCallback: createClusteredpin
                                                        });
        //This method is part of dynamically downloaded clustering Module V7ClientSideClustering.js.
       greenLayer.SetData(response);
    }
}

var testDataGenerator = new function () {    /*    * Example data model that may be returned from a custom web service.    */    var ExampleDataModel = function (name, latitude, longitude)     {        this.Name = name;        this.Latitude = latitude;        this.Longitude = longitude;    };
    /*    * This function generates a bunch of random random data with     * coordinate information and returns it to a callback function     * similar to what happens when calling a web service.    */    this.generateData = function (numPoints, callback)     {        var data = [], randomLatitude, randomLongitude;        for (var i = 0; i < numPoints; i++)        {            randomLatitude = Math.random() * 181 - 90;            randomLongitude = Math.random() * 361 - 180;            data.push(new ExampleDataModel("Point: " + i, randomLatitude, randomLongitude));        }        if (callback)         {            callback(data);        }    };};