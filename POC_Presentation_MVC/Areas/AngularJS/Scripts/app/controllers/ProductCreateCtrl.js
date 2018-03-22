angular.module('pocAngular').controller('ProductCreateCtrl', function ($scope, $location, productsService) {
    console.log('ProductCreateCtrl');
    $scope.submit = function () {
        console.log($scope.product);
        productsService.create($scope.product, function (result) {
            if ("Ok" == result.data) {
                $location.path('/');
            } else {
                //TODO: error
            }
            console.log(result);
        });
    };
});