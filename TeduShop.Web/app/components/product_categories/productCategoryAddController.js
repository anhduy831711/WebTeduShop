(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];
    function productCategoryAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.AddProductCategory = AddProductCategory;
        $scope.regularName = /^\w{3,10}$/;

        $scope.GetSeoTiltle = GetSeoTiltle;

        function GetSeoTiltle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
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