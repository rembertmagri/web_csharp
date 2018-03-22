angular.module('pocAngular').factory('productsService', function ($http) {
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