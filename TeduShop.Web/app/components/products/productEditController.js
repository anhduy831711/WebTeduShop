(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];
    function productEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTiltle = GetSeoTiltle;

        function GetSeoTiltle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function LoadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError('Đọc Dữ Liệu Không Thành Công');
            })
        }
        function UpdateProduct() {
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' Đã Được Cập Nhật Thành Công');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập Nhật Không Thành Công');
            })
        }

        function LoadProductCategories() {
            apiService.get("api/productcategory/getallparent", null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                notificationService.displayError('Đọc Danh Sách Danh Mục Không Thành Công');
            })
        }
        LoadProductCategories();
        LoadProductDetail();
    }
})(angular.module('tedushop.product_categories'));