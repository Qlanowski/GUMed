(function () {

    "use strict";
    //Creating the module
    angular.module("app-patients", ["waitCursor","logout", "ngRoute"])
    .config(function ($routeProvider) {

        $routeProvider.when("/", {
            controller: "patientsController",
            controllerAs: "vm",
            templateUrl: "/views/patientsView.html"
        });


        $routeProvider.otherwise({ redirectTo: "/" });


    });

})();