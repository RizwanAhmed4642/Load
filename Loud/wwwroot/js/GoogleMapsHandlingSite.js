// Include the markers for goole clusterer pins file
var script = document.createElement('script');
script.src = 'https://cdn.rawgit.com/googlemaps/js-marker-clusterer/gh-pages/src/markerclusterer.js';
document.head.appendChild(script);


var areaPolygon;
var areaPolygons = [];
var allLocations = [];
//var areasdata = data.areasdata;
var areasdata = {};
var geocoder;
var map;
var markers = [];
var bounds = new google.maps.LatLngBounds();
var delay = 0;

function wait(millis) {
    var date = new Date();
    var curDate = null;

    do { curDate = new Date(); }
    while (curDate - date < millis);
}

//function initialize() {

//    geocoder = new google.maps.Geocoder();
//    var latlng = new google.maps.LatLng(-25.2744, 133.7751);
//    var myOptions = {

//        center: latlng,
//        zoom: 3,
//        mapTypeId: google.maps.MapTypeId.ROADMAP
//    }
//    map = new google.maps.Map(document.getElementById("map"), myOptions);
//    map.setZoom(3);
//}

function initialize(focusCountry = "Australia") {

    var geocoder = new google.maps.Geocoder();
    if (focusCountry == "")
        focusCountry = "Australia";

    geocoder.geocode({ 'address': focusCountry }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {

            var myOptions = {
                center: results[0].geometry.location,
                zoom: 16,//Map Zooming with Clustering @Usman
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById("map"), myOptions);

        } else {
            console.log("Geocode was not successful for the following reason: " + status);
        }
    });
}


//Execute our 'initialize' function once the page has loaded
//google.maps.event.addDomListener(window, 'load', initialize);



function loadAreas(map) {

    //console.log(areasdata);
    for (var i = 0; i < areasdata.length; i++) {


        var areaid = areasdata[i].ID;
        var lat1 = areasdata[i].StartLat;
        var lng1 = areasdata[i].StartLng;
        var lat2 = areasdata[i].EndLat;
        var lng2 = areasdata[i].EndLng;
        var colour = areasdata[i].Colour;

        var areaCoords = [
            new google.maps.LatLng(lat1, lng1),
            new google.maps.LatLng(lat1, lng2),
            new google.maps.LatLng(lat2, lng2),
            new google.maps.LatLng(lat2, lng1),
            new google.maps.LatLng(lat1, lng1)
        ];

        // polygons that don't have colour
        var opacity;
        if (colour === "")
        {
            opacity = 0.0;
        }
        else
        {
            opacity = 0.25;
        }
        areaPolygon = new google.maps.Polygon({
            paths: areaCoords,
            clickable: false,
            strokeColor: '#0000ff',
            strokeOpacity: 1.0,
            strokeWeight: 0.5,
            fillColor: colour,
            fillOpacity: opacity,
            id: areaid
        });

        areaPolygon.setMap(map);
        areaPolygons.push(areaPolygon);
    }
}


function recreateGeocodesOnMap(id, nm, lat, lng, venueName, type, showArr, focusCountry = "Australia") {

    geocoder = new google.maps.Geocoder(); 

    geocoder.geocode({ 'address': focusCountry }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            var myOptions = {
                zoom: 16,
                center: results[0].geometry.location,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                position: results[0].geometry.location,
                clickable: true,
                icon: "https://www.google.com/intl/en_us/mapfiles/ms/micons/blue-dot.png",
                title: focusCountry
            };

            map = new google.maps.Map(document.getElementById("map"), myOptions);

            geocoder = new google.maps.Geocoder();
            //Add pins with array
            if (showArr == true)
                addMakersWithArray();
            else
                showlatlong(id, nm, nm, lat, lng, venueName, type);

        } else {
            console.log('Geocode was not successful for the following reason: ' + status);
        }
    });

}

function createGeocodeWithAddress(geocoder, map, address) {
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === 'OK') {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location,
                title: "Marker",
            });

            const infowindow = new google.maps.InfoWindow({
                content: address,
            });

            marker.addListener("click", () => {
                infowindow.open({
                    anchor: marker,
                    map,
                    shouldFocus: false,
                });
            });

        } else {
            console.log('Geocode was not successful for the following reason: ' + status);
        }
    });
}

function makeMarkerWithAddress(address) {

    var geocoder = new google.maps.Geocoder();
    var result = ["", ""];
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            result[0] = results[0].geometry.location.lat();
            result[1] = results[0].geometry.location.lng();
        } else {
            result[0] = "Unable to find address: " + status;
        }
        showlatlong("null", address, address, result[0], result[1], "null", "null");
    });
}

function showlatlong(id, address, desc, lat, lng, venueName, type) {

    desc = `<br><div class='text-dark h6'>${desc}</div><br><a  href='/${venueName.replace(/\s/g, "")}/Edit${venueName.replace(/\s/g, "")}/${id}' target='_blank' class='btn btn-sm btn-primary'>Show Details</a> <a  href='/Task/Create?sVenueID=${id}&sVenueType=${venueName}' target='_blank' class='btn btn-sm btn-success'>Add Task</a>`;
    var mIcon = "";
    if (venueName.toUpperCase() == "Church".toUpperCase()) {

        mIcon = "/Media/icons/Church.png";
    }
    else if (venueName.toUpperCase() == "High School".toUpperCase() && type.toUpperCase() == "Public".toUpperCase()) {
        mIcon = "/Media/icons/High-School-1.png";
        
    }
    else if (venueName.toUpperCase() == "High School".toUpperCase() && type.toUpperCase() == "Private".toUpperCase()) {
        mIcon = "/Media/icons/Private-High-School-1.png";
    }
    else if (venueName.toUpperCase() == "Primary School".toUpperCase() && type.toUpperCase() == "Public".toUpperCase()) {
        mIcon = "/Media/icons/Primary-School-1.png";
    }
    else if (venueName.toUpperCase() == "Primary School".toUpperCase() && type.toUpperCase() == "Private".toUpperCase()) {
        mIcon = "/Media/icons/Private-Primary-School-1.png";
    }
    else if (venueName.toUpperCase() == "High School".toUpperCase() && type.toUpperCase() == "Catholic".toUpperCase()) {
        mIcon = "/Media/icons/High-Catholic-1.png";

    }
    else if (venueName.toUpperCase() == "Primary School".toUpperCase() && type.toUpperCase() == "Catholic".toUpperCase()) {
        mIcon = "/Media/icons/Primary-Catholic-1.png";
    }
    else {
        mIcon = "https://www.google.com/intl/en_us/mapfiles/ms/micons/blue-dot.png";
    }
     
    if (geocoder) {
        var myCenter = new google.maps.LatLng(lat, lng);
        var marker = new google.maps.Marker({
            map: map,
            position: myCenter,
            clickable: true,
            icon: mIcon,
            title: address
        });
        marker.setMap(map);
        markers.push(marker);
        markers[markers.length] = marker;
        var infoWindow = new google.maps.InfoWindow({
            content: desc
        });
        bounds.extend(marker.position)
        map.fitBounds(bounds);

        google.maps.event.addListener(marker, "click", function () {
            infoWindow.open(map, marker);
        });
        wait(delay);
    }
}
// Deletes all markers in the array by removing references to them.
function deleteMarkers() {
    clearMarkers();
    markers = [];
}
// Sets the map on all markers in the array.
function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}
// Removes the markers from the map, but keeps them in the array.
function clearMarkers() {
    setAllMap(null);
}

function addMakersWithArray() {

    loadAreas(map);



    // Define the locations
    var locations = [];

    var bounds = new google.maps.LatLngBounds();
    for (var i = 0; i < allLocations.length; i++) {
        var venueName = allLocations[i].venueName;
        var type = allLocations[i].type;
        var desc = `<br><div class='text-dark h6'>${venueName} <br>${allLocations[i].nm}</div><br><a  href='/${venueName.replace(/\s/g, "")}/Edit${venueName.replace(/\s/g, "")}/${allLocations[i].id}' target='_blank' class='btn btn-sm btn-primary'>Show Details</a> <a  href='/Task/Create?sVenueID=${allLocations[i].id}&sVenueType=${venueName}' target='_blank' class='btn btn-sm btn-success'>Add Task</a>`;
        var mIcon = "";
        if (venueName.toUpperCase() == "Church".toUpperCase()) {
            mIcon = "/Media/icons/Church.png";
        }
        else if (venueName.toUpperCase() == "High School".toUpperCase() && type.toUpperCase() == "Public".toUpperCase()) {
            mIcon = "/Media/icons/High-School-1.png";
        }
        else if (venueName.toUpperCase() == "High School".toUpperCase() && type.toUpperCase() == "Private".toUpperCase()) {
            mIcon = "/Media/icons/Private-High-School-1.png";
        }
        else if (venueName.toUpperCase() == "Primary School".toUpperCase() && type.toUpperCase() == "Public".toUpperCase()) {
            mIcon = "/Media/icons/Primary-School-1.png";
        }
        else if (venueName.toUpperCase() == "Primary School".toUpperCase() && type.toUpperCase() == "Private".toUpperCase()) {
            mIcon = "/Media/icons/Private-Primary-School-1.png";
        }
        else if (venueName.toUpperCase() == "High School".toUpperCase() && type.toUpperCase() == "Catholic".toUpperCase()) {
            mIcon = "/Media/icons/High-Catholic-1.png";
        }
        else if (venueName.toUpperCase() == "Primary School".toUpperCase() && type.toUpperCase() == "Catholic".toUpperCase()) {
            mIcon = "/Media/icons/Primary-Catholic-1.png";
        }
        else {
            mIcon = "https://www.google.com/intl/en_us/mapfiles/ms/micons/blue-dot.png";
        }
        var latLng = new google.maps.LatLng(allLocations[i].lat, allLocations[i].lng);

        // markers based on the locations
        var marker = new google.maps.Marker({
            position: latLng,
            map: map,
            clickable: true,
            icon: mIcon,
            title: allLocations[i].address
        });
        markers.push(marker);
        bounds.extend(latLng);

        google.maps.event.addListener(marker, "click", (function (marker, desc) {
            return function () {
                var infoWindow = new google.maps.InfoWindow({
                    content: desc
                });
                infoWindow.open(map, marker);
            };
        })(marker, desc));

    } 

    // Use the marker clusterer library to cluster the markers
    var markerCluster = new MarkerClusterer(map, markers, {
        imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m',
        maxZoom: 16 //Map Zooming with Clustering @Usman
    });
    map.fitBounds(bounds);

    //console.log(allLocations);
    //for (var i = 0; i < allLocations.length; i++) {

    //    var id = allLocations[i].id;
    //    var nm = allLocations[i].nm;
    //    var lat = allLocations[i].lat;
    //    var lng = allLocations[i].lng;
    //    var venueName = allLocations[i].venueName;
    //    var type = allLocations[i].type;
    //    //adding pins
    //    showlatlong(id, nm, nm, lat, lng, venueName, type);
    //}
}

async function getLatLngAndPlusCode(address) {
    return new Promise((resolve, reject) => {
        let geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {

                //console.log(results);
                let latitude = results[0].geometry.location.lat();
                let longitude = results[0].geometry.location.lng();
                let formatted_address = results[0].formatted_address;
                let plus_code = results[0].plus_code.compound_code;
                let obj = { 'latitude': latitude, 'longitude': longitude, 'formatted_address': formatted_address, 'plus_code': plus_code };
                resolve(obj);
            } else {
                reject(new Error("Geocode was not successful for the following reason: " + status));
            }
        });
    });
}
