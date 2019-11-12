(function () {
    'use strict';

    var app = angular.module('app', ['ngResource','ngRoute','app.photo']);

    app.config(['$routeProvider', function ($routeProvider) {        

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'welcome',
            controllerAs: 'vm',
            caseInsensitiveMatch: true
        });
        $routeProvider.when('/photos', {
            templateUrl: 'app/photo/photos.html',
            controller: 'photos',
            controllerAs: 'vm',
            caseInsensitiveMatch: true            
        });
        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);


    // Handle routing errors and success events
    app.run([function () {        
    }]);
})();