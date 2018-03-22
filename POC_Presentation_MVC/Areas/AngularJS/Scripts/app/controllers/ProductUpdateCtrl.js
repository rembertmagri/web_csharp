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
            if (result.data.Valid) {
                $location.path('/');
            } else {
                var errormsg = "";
                var keys = Object.keys(result.data.Errors);
                for (var i = 0; i < keys.length; i++) {
                    errormsg = errormsg + ' ' + result.data.Errors[keys[i]][0].ErrorMessage;
                }
                alert(errormsg);
            }
            console.log(result);
        });
    };
});