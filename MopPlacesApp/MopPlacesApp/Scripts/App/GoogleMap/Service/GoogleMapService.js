(function () {

    var mopPlaceMod = angular.module("mopPlacesModule");

    mopPlaceMod.service("MapPlacesService", ["$http", function ($http) {

        var service = this;

        service.myLocations = [];

        var myCenter = new google.maps.LatLng(43.8585, 18.4200);
        var myplaces = [];
        var count = 0;
        var markers = [];
        var geocoder = new google.maps.Geocoder;


        function initialize() {

            var mapProp = {
                center: myCenter,
                zoom: 19,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            service.map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
            google.maps.event.addListener(service.map, 'click', function (event) {

                //max selected locations is 1
                var infowindow = new google.maps.InfoWindow();
                if (count < 1) {
                    geocodeLatLng(event.latLng, infowindow);
                    var GoogleApi = {
                        Long: event.latLng.lng(),
                        Lati: event.latLng.lat()
                    };
                    myplaces[count] = GoogleApi;

                }
                count++;
            });
        }

        // geocoding tranlating Lon and Lat into Adress and adding marker
        function geocodeLatLng(location, infowindow) {

            geocoder.geocode({ 'location': location }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        var marker = new google.maps.Marker({
                            position: location,
                            map: self.map
                        });
                        markers.push(marker);
                        infowindow.setContent(results[1].formatted_address);
                        infowindow.open(self.map, marker);
                    }
                }
            });
        }

        // function for coordinates save
        function saveCoord() {


            console.log(myplaces);


            if (myplaces.length > 0) {
                var place = {
                    Name: self.name,
                    Category: self.category,
                    Description: self.description,
                    Long: myplaces[0].Long,
                    Lati: myplaces[0].Lati
                }



                data = JSON.stringify(place);

                $http.post(url = "api/googlemaps", data
                 ).then(function (response) {
                     console.log("SPASENO");
                     myplaces = []
                     isDisabled();

                 }, function (error) {
                     console.log("ERORCINA");
                     console.log(error);
                     myplaces = []
                 });
            }
            else {
                console.log("fula");
            }
        }

        function isDisabled() {
            self.isDisabled = true;
        }

        //delete marker
        function clear() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
            myplaces = [];
            count = 0;
        }














        service.showPanels == "1";

        service.showFirstPanel = showFirstPanel;
        service.showSecondPanel = showSecondPanel;

        function showFirstPanel() {

            service.showPanel = '1';
        };

        function showSecondPanel() {

            service.showPanel = '2';
        };

    }]);

})();