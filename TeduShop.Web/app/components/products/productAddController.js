(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];
    function productAddController($scope, apiService, notificationService, $state, commonService) {
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
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.GetSeoTiltle = GetSeoTiltle;

        function GetSeoTiltle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('api/product/create', $scope.product, function (result) {
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

        $scope.moreImages = [];
        $scope.ChooseMoreImage = function ()
        {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
                //console.log(fileUrl);
            }
            finder.popup();
        }
        LoadProductCategories();
    }
})(angular.module('tedushop.products'));