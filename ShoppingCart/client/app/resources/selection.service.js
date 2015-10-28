'use strict';

angular.module('shoppingcartapp')
    .factory('SelectionService', function ($resource) {

        return {
            'request': $resource('', {
                
            },
            {
                GetOrderStatus : {
                    url: 'api/orderstatus',
                    method: 'GET',
                    isArray : true
                },
                GetPaymentMethods : {
                    url: 'api/paymentmethods',
                    method: 'GET',
                    isArray : true
                }
            })
        }
    });