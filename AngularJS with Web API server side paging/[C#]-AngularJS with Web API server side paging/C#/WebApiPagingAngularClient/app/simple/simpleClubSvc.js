(function () {
    'use strict';

    angular
        .module('app')
        .factory('simpleClubSvc', simpleClubSvc);

    simpleClubSvc.$inject = ['$q', 'clubClientSvc'];

    function simpleClubSvc($q, clubClientSvc) {
        var initialOptions ={
            size: 4,            
            orderBy: "name"
        }, service = {
            load: load,
            clear: clear,
            clubs: [],
            paging: {
                options: angular.copy(initialOptions),
                info: {
                    totalItems: 0,
                    totalPages: 1,
                    currentPage: 0,
                    sortableProperties: [
                    "name",
                    "city"
                    ]
                }
            }
        };

        service.paging.info.moreAvailable = function () {
            return service.paging.info.currentPage < service.paging.info.totalPages;
        }

        return service;

        function load() {
            service.paging.info.currentPage += 1;

            var queryArgs = {
                pageSize: service.paging.options.size,
                pageNumber: service.paging.info.currentPage,
                orderBy: service.paging.options.orderBy
            };

            return clubClientSvc.query(queryArgs).$promise.then(
                function (result) {                    
                    result.clubs.forEach(function (club) {                         
                        service.clubs.push(club);
                    });

                    service.paging.info.totalPages = result.totalPages;
                    service.paging.info.totalItems = result.totalCount;

                    return result.$promise;
                }, function (result) {
                    service.paging.info.currentPage -= 1;
                    return $q.reject(result);
                });
        }
        
        function clear() {
            service.clubs.length = 0;
            service.paging.info.totalItems = 0;
            service.paging.info.currentPage = 0;
            service.paging.info.totalPages = 1;
        }
    }
})();