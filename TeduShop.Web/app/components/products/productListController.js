(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProduct = deleteProduct;
        $scope.deleteMulti = deleteMulti;
        $scope.seleteAll = seleteAll;
        $scope.isAll = false;
        function seleteAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }
        function deleteMulti() {
            var listId = [];

            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })

            var config = {
                params: {
                    checkedProducts: JSON.stringify(listId)
                }
            }

            apiService.del('api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess("Xóa Thành Công");
                search();
            }, function (error) {
                notificationService.displayError("Xóa Không Thành Công");
            })
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter('filter')(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $("#btnDelete").removeAttr('disabled');
            }
            else {
                $("#btnDelete").attr('disabled', 'disabled');
            }
        }, true);

        function deleteProduct(id) {

            $ngBootbox.confirm('Bạn Có Muốn Xóa Hay Không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                console.log(config);
                apiService.del('api/product/delete', config, function (result) {
                    notificationService.displaySuccess("Xóa Thành Công");
                    search();
                }, function (error) {
                    notificationService.displayError("Xóa Không Thành Công");
                })
            })
        }

        function search() {
            getListProduct();
        }
        function getListProduct(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không Tìm Thấy Bảng Ghi Nào.")
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load List Product Category Fail');
            });
        }

        $scope.search();
    }
})(angular.module('tedushop.products'));
