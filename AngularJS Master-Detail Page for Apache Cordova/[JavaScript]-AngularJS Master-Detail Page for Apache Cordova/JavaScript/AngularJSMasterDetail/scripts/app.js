(function () {
    'use strict';
    var angularApp = angular.module('angularApp', [
      'ngRoute',
      'angularControllers'
    ]);

    // Fix for platform-specific URL prefixing.
    angularApp.config([
        '$compileProvider',
        function ($compileProvider) {
            $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|file|ghttps?|ms-appx|x-wmapp0):/);
            // Use $compileProvider.urlSanitizationWhitelist(...) for Angular 1.2
            $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|ftp|file|ms-appx|x-wmapp0):|data:image\//);
        }
    ]);


    angularApp.config(['$routeProvider',
      function ($routeProvider) {
          $routeProvider.
            when('/data/:itemId', {
                templateUrl: 'partials/details.html',
                controller: 'DetailCtrl'
            }).
            otherwise({
                redirectTo: '/data'
            });
      }]);
})();