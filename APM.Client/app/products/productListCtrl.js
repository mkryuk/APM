(function() {
    "use strict";
    angular.module("productManagement")
    .controller("ProductListCtrl", ["productResource", ProductListCtrl]);

    function ProductListCtrl(productResource) {

        var vm = this;
        vm.products = [];
        vm.searchCriteria = "FFS";

        productResource.query({
            $filter: "contains(ProductCode, 'FS') and Price ge 10 and Price le 200",
            $orderby: "Price desc"}, function (data) {
            vm.products = data;
        });
    }
}());