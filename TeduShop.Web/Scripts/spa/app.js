/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module('MyModule', []);

myApp.controller("MyController", MyController);

MyController.$inject = ['$scope'];

function MyController($scope)
{
    $scope.message = "My Message";
}