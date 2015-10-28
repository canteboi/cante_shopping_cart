'use strict';

angular.module('shoppingcartapp')
  .controller('DashboardCtrl', function ($scope, $filter, Products) {

      $scope.products = {};
      $scope.products = _.clone(Products, true);

});