'use strict';

angular.module('shoppingcartapp')
  .controller('CartCtrl', function ($scope, $filter, CartItems) {

      $scope.cartitems = {};
      $scope.cartitems = _.clone(CartItems, true);

});