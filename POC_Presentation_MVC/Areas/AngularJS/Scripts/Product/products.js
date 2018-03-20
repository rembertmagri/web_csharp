var pocAngularApp = angular.module('pocAngular', ['ngRoute']).run(function ($rootScope) {
    $rootScope.UTIL = {

        toJsDate: function (str) {
            if (!str) return null;
            str = str.replace('/Date(', '').replace(')/', '');
            return new Date(parseInt(str));
        },

        otherFunction: function (x) {
            return 0;
        }

    };
});

pocAngularApp.config(function ($routeProvider) {
    $routeProvider.
      when('/', {
          templateUrl: '/AngularJS/Product/Table',
          controller: 'ProductListCtrl'
      }).
      when('/Create', {
          templateUrl: '/AngularJS/Product/Create',
          controller: 'ProductCreateCtrl'
      }).
      when('/Read/:productId', {
          templateUrl: '/AngularJS/Product/Read',
          controller: 'ProductFindCtrl'
      }).
      when('/Update/:productId', {
          templateUrl: '/AngularJS/Product/Update',
          controller: 'ProductUpdateCtrl'
      }).
      when('/Delete/:productId', {
          templateUrl: '/AngularJS/Product/Delete',
          controller: 'ProductFindCtrl'
      }).
      when('/Del/:productId', {
          templateUrl: '/AngularJS/Product/Table',
          controller: 'ProductDelCtrl'
      }).
      otherwise({
          redirectTo: '/'
      });
});

pocAngularApp.factory('productsService', function ($http) {
    return {
        list: function (callback) {
            $http.get('/AngularJS/Product/List').then(callback);
        },
        find: function (id, callback) {
            $http({
                method: 'GET',
                url: '/AngularJS/Product/Find',
                params: { id: id }
            }).then(callback);
        },
        del: function (id, callback) {
            $http({
                method: 'POST',
                url: '/AngularJS/Product/Delete',
                data: { id: id }
            }).then(callback);
        },
        create: function (product, callback) {
            $http({
                method: 'POST',
                url: '/AngularJS/Product/Create',
                data: { product: product }
            }).then(callback);
        },
        update: function (product, callback) {
            $http({
                method: 'POST',
                url: '/AngularJS/Product/Update',
                data: { product: product }
            }).then(callback);
        }
    };
});

pocAngularApp.controller('ProductListCtrl', function ($scope, productsService) {
    console.log('ProductListCtrl');
    productsService.list(function (result) {
        $scope.products = result.data;
        console.log(result);
    });

    $scope.sortField = 'Id';
    $scope.reverse = false;
});

pocAngularApp.controller('ProductCreateCtrl', function ($scope, $location, productsService) {
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

pocAngularApp.controller('ProductFindCtrl', function ($scope, $routeParams, productsService) {
    console.log('ProductFindCtrl');
    productsService.find($routeParams.productId, function (result) {
        $scope.product = result.data;
        console.log(result);
    });
});

pocAngularApp.controller('ProductUpdateCtrl', function ($scope, $routeParams, $location, productsService) {
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

pocAngularApp.controller('ProductDelCtrl', function ($scope, $routeParams, $location, productsService) {
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