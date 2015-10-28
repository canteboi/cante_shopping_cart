'use strict';

angular.module('shoppingcartapp')
  .config(function ($stateProvider) {

      $stateProvider
        .state('dashboard', {
            url: '/',
            templateUrl: 'client/app/dashboard/dashboard.html',
            //teplateUrl: '<span>Hello World</span>',
            controller: 'DashboardCtrl',
            resolve: {

                RawProducts: function (DashboardService, $stateParams) {
                    return DashboardService.request.query().$promise;
                },
                Products: function (RawProducts) {
                    return RawProducts.$promise.then(function (records) {
                        var chain = _.chain(records)
                          .map(function (record) {

                              //reserved for future manipulations
                              return record;
                          });

                        return chain.value();
                        //return records;
                    });
                }
            }
        });

  });