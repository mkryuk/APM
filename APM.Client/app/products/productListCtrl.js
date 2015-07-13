(function() {
    "use strict";
    angular.module("productManagement")
    .controller("ProductListCtrl", ["productResource", ProductListCtrl]);

    function ProductListCtrl(productResource) {

        var vm = this;
        vm.products = [];
        productResource.query(function (data) {
            vm.products = data;
        });
    }
}());