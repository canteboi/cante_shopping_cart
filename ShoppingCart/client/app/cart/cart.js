'use strict';

angular.module('shoppingcartapp')
  .config(function ($stateProvider) {

      $stateProvider
        .state('cart', {
            url: '/cart',
            templateUrl: 'client/app/cart/cart.html',
            controller: 'CartCtrl',
            resolve: {

                RawCartItems: function (CartService, $stateParams) {
                    return CartService.request.query().$promise;
                },
                CartItems: function (RawCartItems) {
                    return RawCartItems.$promise.then(function (records) {

                        var chain = _.chain(records)
                          .map(function (record) {

                              record.total = (parseFloat(record.quanity)) * (parseFloat(record.product.unitprice));
                              return record;
                          });

                        return chain.value();
                    });
                }
            }
        });

  });