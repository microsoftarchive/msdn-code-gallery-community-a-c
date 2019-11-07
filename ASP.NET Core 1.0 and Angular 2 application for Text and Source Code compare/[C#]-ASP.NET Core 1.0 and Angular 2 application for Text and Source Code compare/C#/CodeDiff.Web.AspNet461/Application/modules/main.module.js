(function() {
    'use strict';
    angular.module('main', ['ngSanitize']);

    angular.module('main').config(function($httpProvider) {

        $httpProvider.interceptors.push(function($q, $rootScope) {
            return {
                'request': function(config) {
                    $rootScope.$broadcast('loading-started');
                    return config || $q.when(config);
                },
                'response': function(response) {
                    $rootScope.$broadcast('loading-complete');
                    return response || $q.when(response);
                }
            };
        });
    });
})();