angular.module('pocAngular').controller('ProductDelCtrl', function ($scope, $routeParams, $location, productsService) {
    console.log('ProductDelCtrl');
    productsService.del($routeParams.productId, function (result) {
        if ("Ok" == result.data) {
            $location.path('/');
        } else {
            //TODO: error
        }
        console.log(result);
    });
});