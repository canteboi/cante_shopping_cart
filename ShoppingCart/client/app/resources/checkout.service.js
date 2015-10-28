'use strict';

angular.module('shoppingcartapp')
    .factory('CheckoutService', function ($resource) {

        return {
            'request': $resource('api/orders/2', {

            })
        }
    });