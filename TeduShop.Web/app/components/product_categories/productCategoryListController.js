(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategory = getListProductCategory;
        $scope.keyword = '';
        
        $scope.search = search;
        function search()
        {
            getListProductCategory();
        }
        function getListProductCategory(page)
        {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize :2
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0)
                {
                    notificationService.displayWarning("Không Tìm Thấy Bảng Ghi Nào.")
                }
                else
                {
                    notificationService.displaySuccess("Tìm Thấy Tổng Cộng " + result.data.TotalCount + " Bảng Ghi");
                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load List Product Category Fail');
            });
        }

        $scope.getListProductCategory();
    }
})(angular.module('tedushop.product_categories'));