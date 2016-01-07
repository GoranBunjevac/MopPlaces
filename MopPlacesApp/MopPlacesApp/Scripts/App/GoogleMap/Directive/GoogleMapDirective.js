(function () {

    var mopPlaceMod = angular.module("mopPlacesModule");

    mopPlaceMod.directive("mopPlacesDirective", function () {

        return {
            templateUrl: "/Scripts/App/GoogleMap/Template/GoogleMapTemplate.html",
            controller: "MapController as mapController"
        }
    })

})();