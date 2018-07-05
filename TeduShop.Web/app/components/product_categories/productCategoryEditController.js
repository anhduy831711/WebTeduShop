(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];
    function productCategoryEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTiltle = GetSeoTiltle;

        function GetSeoTiltle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function LoadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError('Đọc Dữ Liệu Không Thành Công');
            })
        }
        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' Đã Được Cập Nhật Thành Công');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Cập Nhật Không Thành Công');
            })
        }

        function LoadParentCategories() {
            apiService.get("api/productcategory/getallparent", null, function (result) {
                $scope.parentcategories = result.data;
            }, function () {
                cosole.log('Cannot get list parents');
            })
        }
        LoadProductCategoryDetail();
        LoadParentCategories();
    }
})(angular.module('tedushop.product_categories'));