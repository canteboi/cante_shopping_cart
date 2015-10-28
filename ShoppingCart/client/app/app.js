'use strict';

angular.module('shoppingcartapp', [
  'ngAnimate',        
  'ngCookies',        
  'ngResource',       
  'ngSanitize',       
  'ui.router',        
  'ui.bootstrap'      
])

  .config(function ($urlRouterProvider, $locationProvider) {

      $urlRouterProvider.otherwise('/');

      $urlRouterProvider.rule(function ($injector, $location) {
          var path = $location.path();
          var hasTrailingSlash = path.charAt(path.length - 1) === '/';

          if (hasTrailingSlash) {
              return path.substr(0, path.length - 1);
          }
      });

      //$locationProvider.html5Mode(true);

  })

  // if a state change starts, and there is no currently logged in user,
  // then try to establish an authenticate session first.
  .run(function ($rootScope, $state, $log) {

      //$rootScope.$on('$stateChangeSuccess', function (event, toState) {
      //    if (toState.name !== 'auth.login' && !Auth.isLoggedIn()) {
      //        $log.warn('No authenticated session cached.');
      //        $log.debug('Kicking off login workflow.');
      //        $state.go('auth.login');
      //    }
      //});
  })


  // expose global libraries to angular
  .run(function ($rootScope) {
      $rootScope._ = _;
  })

.run(function ($rootScope, $cookies) {
    $rootScope.$on('$stateChangeSuccess', function (ev, to, toParams, from) {
        $cookies.previousState = from.name;
    });
})

;