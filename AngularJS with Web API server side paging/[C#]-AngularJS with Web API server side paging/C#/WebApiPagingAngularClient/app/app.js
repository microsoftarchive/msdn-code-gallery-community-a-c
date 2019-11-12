(function () {
    'use strict';

    var app = angular.module('app', ['ngResource','ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {        

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'welcomeCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.when('/simplePaging', {
            templateUrl: 'app/simple/simple.html',
            controller: 'simpleCtrl',
            caseInsensitiveMatch: true            
        });
        $routeProvider.when('/fullPaging', {
            templateUrl: 'app/full/full.html',
            controller: 'fullCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);

    app.run([function () {        
    }]);
})();