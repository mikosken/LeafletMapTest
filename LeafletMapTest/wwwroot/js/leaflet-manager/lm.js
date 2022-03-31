// Import this script to add pins to a leaflet map.
// This script assumes that jQuery, leaflet.css and leaflet.js has already been loaded,
// and that there exists an element with id="map" on the page.
//
// To automatically zoom to fit markers, if they exist, set the attribute data-zoommarkerbounds.
// zoomMarkerBounds overrides any center lat/long and default zoom level if markers exist.
// <div id="map" data-zoommarkerbounds="true"></div>
//
// To set initial map center, set the attributes data-centerlat & data-centerlong.
// <div id="map" data-centerlat="0" data-centerlong="179">
//
//
// This script really needs to be cleaned up...


// Map element & settings.
var mapElement = document.querySelector("#map");

var [centerLat, centerLong] = settingLatLong();
var defaultZoom = settingZoomLevel();
var zoomToFitMarkers = settingZoomToFitMarkers();

// Containing folder of this script.
var myURL = jQuery('script[src$="/leaflet-manager/lm.js"]').attr('src').replace('/leaflet-manager/lm.js', '/leaflet-manager/');


var map = L.map('map', {
    center: [centerLat, centerLong],
    minZoom: 2,
    zoom: defaultZoom,
})

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution:
        '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
    subdomains: ['a', 'b', 'c'],
}).addTo(map)


var pinIcon = L.icon({
    iconUrl: myURL + 'img/edited-pin-48.png',
    iconSize: [48, 48],
    iconAnchor: [17, 40],
    popupAnchor: [0, -20],
});
map.attributionControl.addAttribution('Edited pin icon by<a href = "https://freeicons.io/profile/3024">Tinu CA</a> on <a href = "https://freeicons.io" > freeicons.io</a >');

// Loop through all map-marker elements inside map element and use their lat/long to create pins on map.
var markers = document.querySelectorAll("#map .map-marker");

let markerGroup = [];

for (var i = 0; i < markers.length; ++i) {
    var dataTitle = markers[i].getAttribute('data-popuptitle');
    var dataText = markers[i].getAttribute('data-popuptext');

    var popupString = '';
    // Check that data is set. (Not null or empty string.)
    if (dataTitle) {
        popupString += '<b>' + dataTitle + '</b><br>';
    }
    if (dataText) {
        popupString += dataText;
    }

    var m = L.marker([markers[i].getAttribute('data-latitude').replace(',', '.'), markers[i].getAttribute('data-longitude').replace(',', '.')], { icon: pinIcon })
        .bindPopup(popupString)
        .addTo(map);
    markerGroup.push(m);
}

if (zoomToFitMarkers && markerGroup.length > 0) {
    // Zoom to bounds of all markers.
    var group = new L.featureGroup(markerGroup);
    map.fitBounds(group.getBounds());
}

///////////////////////////////////////////////////
// Helper functions.
//
function settingLatLong() {
    // Default center.
    var centerLat = 0;
    var centerLong = 0;
    if (mapElement.hasAttribute('data-centerlat') && mapElement.hasAttribute('data-centerlong')) {
        var dataCenterLat = mapElement.getAttribute('data-centerlat');
        var dataCenterLong = mapElement.getAttribute('data-centerlong');
        if (!isNaN(Number(dataCenterLat)) || !isNaN(Number(dataCenterLong))) {
            centerLat = Number(dataCenterLat);
            centerLong = Number(dataCenterLong);
        }
    }
    return [centerLat, centerLong];
}

function settingZoomLevel() {
    // Default zoom level.
    var defaultZoom = 2;
    if (mapElement.hasAttribute('data-zoomlevel')) {
        var dataZoomLevel = mapElement.getAttribute('data-zoomlevel');
        if (!isNaN(Number(dataZoomLevel))) {
            defaultZoom = Number(dataZoomLevel);
        }
    }
    return defaultZoom;
}

function settingZoomToFitMarkers() {
    // Zoom to fit markers.
    var zoomToFitMarkers = false;
    if (mapElement.hasAttribute('data-zoomtofitmarkers')) {
        var dataZoomToFitMarkers = mapElement.getAttribute('data-zoomtofitmarkers');
        if (dataZoomToFitMarkers.toLowerCase() == 'true') {
            zoomToFitMarkers = true;
        }
    }
    return zoomToFitMarkers;
}