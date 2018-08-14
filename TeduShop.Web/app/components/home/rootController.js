(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$scope', '$state','authData','loginService','authenticationService']
    function rootController($scope, $state, authData, loginService, authenticationService) {
        $scope.logout = function () {
            $state.go('login');
            console.log('abc');
        }
        $scope.authentication = authData.authenticationData;
        //authenticationService.validateRequest();
    }
})(angular.module('tedushop'));