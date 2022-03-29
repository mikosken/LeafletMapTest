// Import this script to add pins to a leaflet map.
// This script assumes that jQuery, leaflet.css and leaflet.js has already been loaded,
// and that there exists an element with id="map" on the page.
var map = L.map('map', {
    center: [58.50, 14.70],
    minZoom: 2,
    zoom: 6,
})

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution:
        '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
    subdomains: ['a', 'b', 'c'],
}).addTo(map)

var myURL = jQuery('script[src$="/leaflet-manager/lm.js"]').attr('src').replace('/leaflet-manager/lm.js', '/leaflet-manager/');

var pinIcon = L.icon({
    iconUrl: myURL + 'img/edited-pin-48.png',
    iconSize: [48, 48],
    iconAnchor: [17, 40],
    popupAnchor: [0, -20],
});
map.attributionControl.addAttribution('Edited pin icon by<a href = "https://freeicons.io/profile/3024">Tinu CA</a> on <a href = "https://freeicons.io" > freeicons.io</a >')


// Loop through all map-marker elements inside map element and use their lat/long to create pins on map.
var markers = document.querySelectorAll("#map .map-marker")

for (var i = 0; i < markers.length; ++i) {
    L.marker([markers[i].getAttribute('data-latitude'), markers[i].getAttribute('data-longitude')], { icon: pinIcon })
        .bindPopup(markers[i].getAttribute('data-name'))
        .addTo(map);
}
