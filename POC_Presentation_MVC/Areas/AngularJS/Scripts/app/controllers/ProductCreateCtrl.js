angular.module('pocAngular').controller('ProductCreateCtrl', function ($scope, $location, productsService) {
    console.log('ProductCreateCtrl');
    $scope.submit = function () {
        console.log($scope.product);
        productsService.create($scope.product, function (result) {
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