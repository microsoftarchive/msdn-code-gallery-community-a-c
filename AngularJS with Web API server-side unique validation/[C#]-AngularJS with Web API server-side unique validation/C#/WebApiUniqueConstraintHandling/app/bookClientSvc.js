(function () {
    'use strict';

    angular
        .module('app')
        .factory('bookClientSvc', function ($resource) {
            return $resource("api/books/:id",
                { id: "@id" },
                {
                    'titleAvailable': { method: 'POST', url: 'api/books/titleAvailable', params: { title: '@title' } }
                });
        });
})();
