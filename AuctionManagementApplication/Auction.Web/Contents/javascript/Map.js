function drawMap() {


    //var ll = 23.79804617762948;
    //var lg = 90.44958227960831;
    //var uiu1 = new google.maps.LatLng(ll, lg);

    map = new google.maps.Map(document.getElementById('mapArea'), {
        center: [23.79804617762948, 90.44958227960831],
        zoom: 15,
        mapTypeId: 'hybrid'
    });

    add();

}

function add() {
    var select = document.getElementById("productImg").value;
    var name = document.getElementById("productName").value;
    var Lat = document.getElementById("productLat").value;
    var Lng = document.getElementById("productLng").value;

    
    var mk = new google.maps.Marker({
        position: [Lat, Lng],
        map: map,
        //icon: image
    });

    var contentString = '<img src="' + select + '" height="50" width="75" />' + '<h4>' + name + '</h4>';
    var infowindow = new google.maps.InfoWindow({
        content: contentString,
        maxWidth: 200,
        maxWidth: 400
    });
    infowindow.open(map, mk);

}