/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop', ['tedushop.products', 'tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/HomeView.html",
            controller: "HomeController"
        })

        $urlRouterProvider.otherwise('/admin');
    }
})();