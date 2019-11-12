$(function () {
    // URL to the data source that powers the locator.
    var dataSourceUrl = 'https://spatial.virtualearth.net/REST/v1/data/515d38d4d4e348d9a61c615f59704174/CoffeeShops/CoffeeShop';

    // A setting for specifying the distance units displayed. Possible values are 'km' and 'mi'.
    var distanceUnits = 'km';

    // Load the map.
    var map = new Microsoft.Maps.Map(document.getElementById('myMap'), {
        credentials: 'YOUR_BING_MAPS_KEY',
        zoom: 2
    });

    // Create a layer to load pushpins to.
    var dataLayer = new Microsoft.Maps.EntityCollection();
    map.entities.push(dataLayer);

    // Add a layer for the infobox.
    var infoboxLayer = new Microsoft.Maps.EntityCollection();
    map.entities.push(infoboxLayer);

    // Create a global infobox control.
    var infobox = new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(0, 0), {
        visible: false,
        offset: new Microsoft.Maps.Point(0, 20),
        height: 170,
        width: 230
    });
    infoboxLayer.push(infobox);

    // Create a session key from the map to use with data source service requests.
    var sessionKey;
    map.getCredentials(function (c) {
        sessionKey = c;
    });

    // Load the Search Module for Bing Maps for doing geocoding.
    var searchManager;
    Microsoft.Maps.loadModule('Microsoft.Maps.Search', {
        callback: function () {
            searchManager = new Microsoft.Maps.Search.SearchManager(map);
        }
    });

    // Resize the height of the results panel based on the available space.
    $(window).resize(function () {
        $('.resultsPanel').height($(window).height() - $('.searchBar').height() - 100);
        $('.mapPanel').height($(window).height() - 100);
        $('.sidePanel').height($(window).height() - 100);
    });
    $(window).resize();    

    // Add a click event to the search button.
    $('#searchBtn').click(function () {
        clearMap();

        // Create a request to geocode the users search.
        var geocodeRequest = {
            where: $('#searchBox').val(),
            count:1, 
            callback: function (r) {
                if(r && r.results && 
                    r.results.length > 0 && 
                    r.results[0].location) {
                    findNearbyLocations(r.results[0].location);
                }else{
                    showErrorMsg('Unable to geocode query');
                }
            },
            errorCallback:function(){
                showErrorMsg('Unable to geocode query');
            }};

        // Geocode the users search.
        searchManager.geocode(geocodeRequest);
    });

    // Add a key press event to the search box that triggers the search when the user presses Enter key.
    $('#searchBox').keypress(function (e) {
        if (e.which == 13) {
            $('#searchBtn').click();
        }
    });
    
    // A simple function for displaying error messages in the app.
    function showErrorMsg(msg) {
        $('.resultsPanel').html('<span class="errorMsg">' + msg + '</span>');
    }

    // A simple function for clearing the map and results panel.
    function clearMap() {
        dataLayer.clear();
        infobox.setOptions({ visible: false });
        $('.resultsPanel').html('');
    }

    // A function that searches for nearby locations against the data source.
    function findNearbyLocations(location) {
        // Create the URL request to do a nearby search against the data source.
        // Have it search within a radius of 20KM and return the top 10 results.
        var request = dataSourceUrl + '?spatialFilter=nearby(' + location.latitude +
            ',' + location.longitude + ',20)&$format=json&$top=10&key=' + sessionKey;

        $.ajax({
            url: request,
            dataType: 'jsonp',
            jsonp: 'jsonp',
            success: function (data) {
                var results = data.d.results;

                if (results.length > 0) {
                    // Create an array to store the coordinates of all the location results.
                    var locs = [];

                    // Create an array to store the HTML used to generate the list of results.
                    // By using an array to concatenate strings is much more efficient than using +.
                    var listItems = [];

                    //Loop through results and add to map
                    for (var i = 0; i < results.length; i++) {
                        var loc = new Microsoft.Maps.Location(results[i].Latitude, results[i].Longitude);

                        // Create pushpin
                        var pin = new Microsoft.Maps.Pushpin(loc, {
                            icon: 'images/red_pin.png',
                            text: (i + 1) + ''
                        });

                        // Store the location result info as a property of the pushpin so we can use it later.
                        pin.Metadata = results[i];

                        // Add a click event to the pushpin to display an infobox.
                        Microsoft.Maps.Events.addHandler(pin, 'click', function (e) {
                            displayInfobox(e.target);
                        });

                        // Add the pushpin to the map.
                        dataLayer.push(pin);

                        // Add the location coordinate to the array of locations
                        locs.push(loc);

                        // Create the HTML for a single list item for the result.                        
                        listItems.push('<table class="listItem"><tr><td rowspan="3"><span>', (i + 1), '.</span></td>');

                        // Store the result ID as a property of the name. This will allow us to relate the list item to the pushpin on the map.
                        listItems.push('<td><a class="title" href="javascript:void(0);" rel="', results[i].ID, '">', results[i].Name, '</a></td>');
                        listItems.push('<td>', haversineDistance(location, loc), ' ', distanceUnits, '</td></tr>');

                        listItems.push('<tr><td colspan="2" class="listItem-address">', results[i].AddressLine, '<br/>', results[i].Locality, ', ');
                        listItems.push(results[i].AdminDistrict, '<br/>', results[i].PostalCode, '</td></tr>');

                        listItems.push('<tr><td colspan="2"><a target="_blank" href="http://bing.com/maps/default.aspx?rtp=~pos.', results[i].Latitude, '_', results[i].Longitude, '_', encodeURIComponent(results[i].Name), '">Directions</a></td></tr>');

                        listItems.push('</table>');
                    }

                    // Use the array of locations from the results to set the map view to show all locations.
                    if (locs.length > 1) {
                        map.setView({ bounds: Microsoft.Maps.LocationRect.fromLocations(locs), padding: 80 });
                    } else {
                        map.setView({ center: locs[0], zoom: 15 });
                    }

                    // Add the list items to the results panel.
                    $('.resultsPanel').html(listItems.join(''));

                    // Add a click event to the title of each list item.
                    $('.title').click(function () {
                        // Get the ID of the selected location
                        var id = $(this).attr('rel');

                        //Loop through all the pins in the data layer and find the pushpin for the location.
                        var pin;
                        for (var i = 0; i < dataLayer.getLength() ; i++) {
                            pin = dataLayer.get(i);

                            if (pin.Metadata.ID != id) {
                                pin = null;
                            } else {
                                break;
                            }
                        }

                        // If a pin is found with a matching ID, then center the map on it and show it's infobox.
                        if (pin) {
                            // Offset the centering to account for the infobox.
                            map.setView({ center: pin.getLocation(), centerOffset: new Microsoft.Maps.Point(-70, 150), zoom: 17 });
                            displayInfobox(pin);
                        }
                    });
                }
            },
            error: function (e) {
                showErrorMsg(e.statusText);
            }
        });
    }

    // Takes a pushpin and generates the content for the infobox from the Metadata and displays the infobox.
    function displayInfobox(pin) {
        infobox.setLocation(pin.getLocation());

        var desc = ['<table>'];

        desc.push('<tr><td colspan="2">', pin.Metadata.AddressLine, '<br/>', pin.Metadata.Locality, ', ');
        desc.push(pin.Metadata.AdminDistrict, '<br/>', pin.Metadata.PostalCode, '</td></tr>');

        desc.push('<tr><td><b>Hours:</b></td><td>', formatTime(pin.Metadata.Open), ' - ', formatTime(pin.Metadata.Close), '</td></tr>');
        desc.push('<tr><td><b>Store Type:</b></td><td>', pin.Metadata.StoreType, '</td></tr>');
        desc.push('<tr><td><b>Has Wifi:</b></td><td>', (pin.Metadata.IsWiFiHotSpot) ? 'Yes' : 'No', '</td></tr>');
        desc.push('<tr><td colspan="2"><a target="_blank" href="http://bing.com/maps/default.aspx?rtp=~pos.', pin.Metadata.Latitude, '_', pin.Metadata.Longitude, '_', encodeURIComponent(pin.Metadata.Name), '">Directions</a></td></tr>');

        desc.push('</table>');

        infobox.setOptions({ visible: true, title: pin.Metadata.Name, description: desc.join('') });
    }

    // Formats a time in 1000 hours to hh:mm AM/PM format
    function formatTime(val) {
        var minutes = val % 100;
        var hours = Math.round(val / 100);

        if (minutes == 0) {
            minutes = '00';
        }

        if (hours > 12) {
            return (hours - 12) + ':' + minutes + 'PM';
        } else {
            return hours + ':' + minutes + 'AM';
        }
    }

    // Calculates the shortest distance between two locations on the curvature of the earth.
    function haversineDistance(loc1, loc2) {
        var degToRad = Math.PI / 180,
            lat1 = loc1.latitude * degToRad,
            lon1 = loc1.longitude * degToRad,
            lat2 = loc2.latitude * degToRad,
            lon2 = loc2.longitude * degToRad;

        var dLat = lat2 - lat1,
        dLon = lon2 - lon1,
        cordLength = Math.pow(Math.sin(dLat / 2), 2) + Math.cos(lat1) * Math.cos(lat2) * Math.pow(Math.sin(dLon / 2), 2),
        centralAngle = 2 * Math.atan2(Math.sqrt(cordLength), Math.sqrt(1 - cordLength));

        var earthRadius = (distanceUnits == 'km') ? 6378.1 : 3963.1676;
        var distance = earthRadius * centralAngle;

        // Round off distance to 2 decimal place
        return Math.round(distance * 100) / 100;
    }
});