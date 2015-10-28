'use strict';

angular.module('shoppingcartapp')
    .factory('CartService', function ($resource) {

        return {
            'request': $resource('api/cartitems/2', {

            })
        }
    });