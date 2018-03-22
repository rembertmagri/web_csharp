angular.module('pocAngular').controller('ProductListCtrl', function ($scope, productsService) {
    console.log('ProductListCtrl');
    productsService.list(function (result) {
        $scope.products = result.data;
        console.log(result);
    });

    $scope.sortField = 'Id';
    $scope.reverse = false;
});