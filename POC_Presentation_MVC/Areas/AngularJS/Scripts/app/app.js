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