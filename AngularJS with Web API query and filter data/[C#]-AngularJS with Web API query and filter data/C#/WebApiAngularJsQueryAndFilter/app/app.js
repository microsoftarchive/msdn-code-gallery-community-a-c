(function () {
    'use strict';

    var app = angular.module('app', ['ngResource','ngRoute','ngMessages']);

    app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
        $locationProvider.html5Mode(true)

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'WelcomeController',
            controllerAs: 'vm',
            caseInsensitiveMatch: true

        });
        $routeProvider.when('/books', {
            templateUrl: 'app/books/books.html',
            controller: 'BooksController',
            controllerAs: 'vm',
            caseInsensitiveMatch: true,
            reloadOnSearch: false //don't reload when the url query is changed https://docs.angularjs.org/api/ngRoute/provider/$routeProvider
        });        
        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);

    app.run(['$route', function ($route) {
    }]);
})();