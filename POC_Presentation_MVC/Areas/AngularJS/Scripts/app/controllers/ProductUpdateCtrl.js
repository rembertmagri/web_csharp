angular.module('pocAngular').controller('ProductUpdateCtrl', function ($scope, $routeParams, $location, productsService) {
    console.log('ProductUpdateCtrl');
    productsService.find($routeParams.productId, function (result) {
        $scope.product = result.data;
        console.log(result);
    });
    $scope.submit = function () {
        $scope.product.CreationDate = new Date();
        console.log($scope.product);
        productsService.update($scope.product, function (result) {
            if ("Ok" == result.data) {
                $location.path('/');
            } else {
                //TODO: error
            }
            console.log(result);
        });
    };
});