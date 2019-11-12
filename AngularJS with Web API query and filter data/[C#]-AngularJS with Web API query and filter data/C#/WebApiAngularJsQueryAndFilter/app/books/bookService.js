(function () {
    'use strict';

    angular
        .module('app')
        .service('bookService', bookService);

    bookService.$inject = ['bookResource'];

    function bookService(bookResource) {
        var service = {
            setupQuery: setupQuery,            
            search: search,
            queryFromParams: queryFromParams
        };

        return service;
        
        function setupQuery(selectableFilters) {                        
            return bookResource
                        .queryOptions(selectableFilters)
                        .$promise;
        }

        //populate the query with any route params making sure check if the property is an array or single value
        function queryFromParams(query, routeParams) {
            for (var property in query) {
                if (routeParams[property]) {
                    if (Array.isArray(query[property])) {
                        if (Array.isArray(routeParams[property])) {
                            query[property] = routeParams[property];
                        } else {
                            query[property].push(routeParams[property]);
                        }
                    } else {
                        query[property] = routeParams[property];
                    }
                }
            }
        }

        function search(query) {            
            return bookResource
                .search(query)
                        .$promise;
        }
    }
})();