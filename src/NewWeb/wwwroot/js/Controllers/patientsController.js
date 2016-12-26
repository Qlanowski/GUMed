(function () {

    "use strict";
    //Getting the existing module
    angular.module("app-patients")
        .controller("patientsController", patientsController);
    function patientsController($scope) {
        $scope.name = "Karol Ulanowski";
    };
})();