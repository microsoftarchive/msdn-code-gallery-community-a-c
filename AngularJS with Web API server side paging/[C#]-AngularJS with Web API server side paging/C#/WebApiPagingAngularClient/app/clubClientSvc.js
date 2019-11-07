(function () {
    'use strict';

    angular
        .module('app')
        .factory('clubClientSvc', function ($resource) {
            return $resource("api/clubs/:id",
                { id: "@id" },
                {                  
                    'query': {
                        method: 'GET',
                        url:'/api/clubs/:pageSize/:pageNumber/:orderBy',
                        params: { pageSize: '@pageSize', pageNumber: '@pageNumber', orderBy: '@orderBy' }
                    } 
            });
        });
})();
