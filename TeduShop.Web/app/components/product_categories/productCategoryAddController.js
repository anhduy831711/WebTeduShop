﻿(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$scope', 'apiService','notificationService','$state'];
    function productCategoryAddController($scope, apiService, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.AddProductCategory = AddProductCategory;
        $scope.regularName = /^\w{3,10}$/;
        function AddProductCategory()
        {
            apiService.post('api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' Đã Được Thêm Mới');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Thêm Mới Không Thành Công');
            })
        }

        function LoadParentCategories() {
            apiService.get("api/productcategory/getallparent", null, function (result) {
                $scope.parentcategories = result.data;
            }, function () {
                cosole.log('Cannot get list parents');
            })
        }
        LoadParentCategories();
    }
})(angular.module('tedushop.product_categories'));