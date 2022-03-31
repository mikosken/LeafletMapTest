# Leaflet Map Test

A test in adding a leaflet map to an ASP.NET / dotNet Core web app.
This web app uses an internal Sqlite memory database that is seeded with dummy
data on each startup.

The supporting script leaflet-manager/lm.js created for this project is capable of
reading data-* attributes as settings from the html map element, as well as create
map markers from data-* in sub-elements.


## Interesting files & useage

In case you wish to see the most important files for using leaflet or wish
to extend functionality, you can start by looking here:

* LeafletMapTest\wwwroot\js\leaflet-manager\
	* lm.js - Contains support functionality for setting up the map and reading settings from html data-attributes.
	* img\ - Contains marker images.
* LeafletMapTest\Views\MapItems\
	* Index.cshtml & Details.cshtml - Uses leaflet together with lm.js to display data from database.

To use leaflet in the manner I have here, add leaflet js & css between head
tags:
```<head>
    <link rel="stylesheet" href="~/lib/leaflet/leaflet.css" />
    <script src="~/lib/leaflet/leaflet.js"></script>
</head>
```
and add jQuery and leaflet-manager/lm.js at end of the body tag:
```    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/js/leaflet-manager/lm.js"~></script>
</body>
```

Finally you can add a map element to the page and specify markers directly as
child elements.
Note that map element must have id="map" and markers must have
class="map-marker". Note that you should hide the marker element in html to
prevent it from interfering with the rest of the page, it is only used as a
data carrier.
```<div class="map-marker" ... style="display:none">
```

Example:
```    <div id="map" data-zoomtofitmarkers="true" data-zoomlevel="6" data-centerlat="58.52" data-centerlong="14.72" style="height: 440px; border: 1px solid #AAA;">
        <div class="map-marker" data-popuptitle="Järntorget" data-popuptext="Gothenburg" data-latitude="57.699871" data-longitude="11.952903" style="display:none"></div>
        <div class="map-marker" data-popuptitle="Gothenburg central station" data-popuptext="Gothenburg" data-latitude="57.709284" data-longitude="11.972801" style="display:none"></div>
    </div>
```

data-* attributes for map element currently implemented in /leaflet-manager/lm.js:
* data-zoomtofitmarkers - true/false, default false. If there are markers on the map,zoom to fit. Overrides zoomlevel and lat/long setting.
* data-zoomlevel - Number, default 2. Default zoom level when loading the map.
* data-centerlat & data-centerlong - Number, default [0, 0]. Sets default view center on map.

data* attributes for marker elements currently implemented in /leaflet-manager/lm.js:
* data-popuptitle - Sets title in the popup when clicking on a marker.
* data-popuptext - Sets text/description in the popup when clicking on a marker.
* data-latitude & data-longitude - Sets position of marker on map.


## Getting Started

To compile or continue development try this:

Install **git** and **Visual Studio 2022**, then open a git console:

```cd .\suitable\project\folder
git clone <address_to_this_repo>
```

Open ...\suitable\project\folder\LeafletMapTest\LeafletMapTest.sln in Visual Studio.
To build and run click the Run-button for the project.


## References

Inspiration, code snippets, etc.
* [Leafletjs](https://leafletjs.com/)
* [Creating An Interactive Map With Leaflet and OpenStreetMap](https://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/)
* [OpenStreetMap](https://www.openstreetmap.org/about)