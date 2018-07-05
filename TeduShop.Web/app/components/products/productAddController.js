(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];
    function productAddController($scope, apiService, notificationService, $state) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.AddProduct = AddProduct;
        $scope.regularName = /^\w{3,10}$/;
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        };

        $scope.ChooseImage = function()
        {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl)
            {
                $scope.product.Image = fileUrl;
                console.log(fileUrl);
            }
            finder.popup();
        }

        function AddProduct() {
            apiService.post('api/productcategory/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' Đã Được Thêm Mới');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Thêm Mới Không Thành Công');
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
    }
})(angular.module('tedushop.products'));