'use strict';

angular.module('shoppingcartapp')
  .controller('CheckoutCtrl', function ($scope, PaymentMethods) {
      $scope.paymentMethods = {};
      $scope.paymentMethods = _.clone(PaymentMethods, true);

});