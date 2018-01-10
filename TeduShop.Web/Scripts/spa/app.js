/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module('MyModule', []);

myApp.controller("StudentController", StudentController);
myApp.service('Validation', Validation);

StudentController.$inject = ['$scope', 'Validation'];

function StudentController($scope, Validation)
{
    $scope.CheckNumber = function () {
        $scope.mesage = Validation.CheckNumber($scope.num);
    }
}

function Validation($window)
{
    return {
        CheckNumber: CheckNumber
    }
    function CheckNumber(input)
    {
        if(input%2==0)
        {
            return "this is even";
        }
        else
        {
            return "this is odd";
        }
    }
}