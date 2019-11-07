(function () {
    'use strict';

    var app = angular.module('app', ['ngResource','ngRoute','ngMessages']);

    app.config(['$routeProvider', function ($routeProvider) {        

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'welcomeCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.when('/simple', {
            templateUrl: 'app/simple/simple.html',
            controller: 'simpleCtrl',
            caseInsensitiveMatch: true            
        });
        $routeProvider.when('/advanced', {
            templateUrl: 'app/advanced/advanced.html',
            controller: 'advancedCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);

    app.run([function () {        
    }]);
})();