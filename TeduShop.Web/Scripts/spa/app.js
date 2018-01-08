/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module('MyModule', []);

myApp.controller("StudentController", StudentController);
myApp.controller("TeacherController", TeacherController);
myApp.controller("SchoolController", SchoolController);

function StudentController($scope)
{
    //$scope.message = "My Message by student";
}

function TeacherController($scope) {
    //$scope.message = "My Message by teacher";
}

function SchoolController($scope) {
    $scope.message = "My Message by School";
}