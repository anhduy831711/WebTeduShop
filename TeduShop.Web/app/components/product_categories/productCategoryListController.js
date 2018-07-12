(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategory = getListProductCategory;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.deleteMulti = deleteMulti;
        $scope.seleteAll = seleteAll;
        $scope.isAll = false;
        function seleteAll()
        {
            if ($scope.isAll ===false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            }
            else
            {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }
        function deleteMulti()
        {
            var listId =[];

            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })

            var config = {
                params: {
                    checkedProductCategories: JSON.stringify(listId)
                }
            }

            apiService.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess("Xóa Thành Công");
                search();
            }, function (error) {
                notificationService.displayError("Xóa Không Thành Công");
            })
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter('filter')(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $("#btnDelete").removeAttr('disabled');
            }
            else {
                $("#btnDelete").attr('disabled', 'disabled');
            }
        }, true);

        function deleteProductCategory(id)
        {

            $ngBootbox.confirm('Bạn Có Muốn Xóa Hay Không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                console.log(config);
                apiService.del('api/productcategory/delete', config, function (result) {
                    notificationService.displaySuccess("Xóa Thành Công");
                    search();
                }, function (error) {
                    notificationService.displayError("Xóa Không Thành Công");
                })
            })
        }

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
                    pageSize :1
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0)
                {
                    notificationService.displayWarning("Không Tìm Thấy Bảng Ghi Nào.")
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