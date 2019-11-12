(function () {
    'use strict';

    //hook up to the Web API actions https://docs.angularjs.org/api/ngResource/service/$resource
    angular
        .module('app')
        .factory('bookResource', function ($resource) {
            return $resource("api/books/:id",
                { id: "@id" },
                {
                    'queryOptions': { method: 'POST', url: 'api/books/queryOptions' },
                    'search': { method: 'POST', url: 'api/books/search' }
                });
        });
})();
