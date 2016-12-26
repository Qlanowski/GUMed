(function () {
    "use strict";

    angular.module("logout", [])
    .directive("logout", logout); //zapisywane est w html jako wait-cursor

    function logout() {
        return {
            restrict: "E", // musi byc <logout> a nie moze byc <div wait-cursor>
            templateUrl: "/views/logout.html"
        };
    }

})();