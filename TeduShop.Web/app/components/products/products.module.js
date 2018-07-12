﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop.products', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            parent:'base',
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('products_add', {
            url: "/products_add",
            parent: 'base',
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        }).state('edit_product', {
            url: "/edit_product/{id}",
            parent: 'base',
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController"
        });
    }
})();