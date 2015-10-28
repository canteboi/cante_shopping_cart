'use strict';

angular.module('shoppingcartapp')
  .config(function ($stateProvider) {

      $stateProvider
        .state('checkout', {
            url: '/checkout',
            templateUrl: 'client/app/checkout/checkout.html',
            controller: 'CheckoutCtrl',
            resolve: {
                RawPaymentMethods: function (SelectionService, $stateParams) {
                    return SelectionService.request.GetPaymentMethods().$promise;
                },
                PaymentMethods: function (RawPaymentMethods) {
                    return RawPaymentMethods.$promise.then(function (records) {

                        var chain = _.chain(records)
                          .map(function (record) {

                              return record;
                          });

                        return chain.value();
                    });
                }
            }
        });

  });