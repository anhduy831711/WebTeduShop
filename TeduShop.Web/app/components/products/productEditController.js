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
        $scope.moreImages = [];
        function GetSeoTiltle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function LoadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            }, function (error) {
                notificationService.displayError('Đọc Dữ Liệu Không Thành Công');
            })
        }
        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
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

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
                //console.log(fileUrl);
            }
            finder.popup();
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        LoadProductCategories();
        LoadProductDetail();
    }
})(angular.module('tedushop.product_categories'));