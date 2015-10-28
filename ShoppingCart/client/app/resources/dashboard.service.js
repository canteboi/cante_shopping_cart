'use strict';

angular.module('shoppingcartapp')
    .factory('DashboardService', function ($resource) {

        return {
            'request': $resource('api/products', {

            })
        }
    });