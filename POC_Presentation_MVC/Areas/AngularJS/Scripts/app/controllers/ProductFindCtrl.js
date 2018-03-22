angular.module('pocAngular').controller('ProductFindCtrl', function ($scope, $routeParams, productsService) {
    console.log('ProductFindCtrl');
    productsService.find($routeParams.productId, function (result) {
        $scope.product = result.data;
        console.log(result);
    });
});