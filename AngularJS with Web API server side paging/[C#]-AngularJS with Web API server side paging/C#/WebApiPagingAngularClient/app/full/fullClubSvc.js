(function () {
    'use strict';

    angular
        .module('app')
        .factory('fullClubSvc', fullClubSvc);

    fullClubSvc.$inject = ['$q', 'clubClientSvc'];

    function fullClubSvc($q, clubClientSvc) {
        var initialOptions = {
            size: 4,
            orderBy: "name"
        },
        service = {
            initialize: initialize,
            navigate: navigate,
            clear: clear,
            pages: [],
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

        return service;

        function initialize() {
            var queryArgs = {
                pageSize: service.paging.options.size,
                pageNumber: service.paging.info.currentPage
            };

            service.paging.info.currentPage = 1;

            return clubClientSvc.query(queryArgs).$promise.then(
                function (result) {
                    var newPage = {
                        number: pageNumber,
                        clubs: []
                    };
                    result.clubs.forEach(function (club) {
                        newPage.clubs.push(club);
                    });

                    service.pages.push(newPage);
                    service.paging.info.currentPage = 1;
                    service.paging.info.totalPages = result.totalPages;

                    return result.$promise;
                }, function (result) {
                    return $q.reject(result);
                });
        }

        function navigate(pageNumber) {
            var dfd = $q.defer();

            if (pageNumber > service.paging.info.totalPages) {               
                return dfd.reject({ error: "page number out of range" });
            }

            if (service.pages[pageNumber]) {
                service.paging.info.currentPage = pageNumber;
                dfd.resolve();
            } else {
                return load(pageNumber);
            }

            return dfd.promise;
        }

        function load(pageNumber) {
            var queryArgs = {
                pageSize: service.paging.options.size,
                pageNumber: pageNumber,
                orderBy: service.paging.options.orderBy
            };

            return clubClientSvc.query(queryArgs).$promise.then(
                function (result) {
                    var newPage = {
                        number: service.paging.info.pageNumber,
                        clubs: []
                    };
                    result.clubs.forEach(function (club) {
                        newPage.clubs.push(club);
                    });

                    service.pages[pageNumber] = newPage;
                    service.paging.info.currentPage = pageNumber;
                    service.paging.info.totalPages = result.totalPages;
                    service.paging.info.totalItems = result.totalItems;

                    return result.$promise;
                }, function (result) {
                    return $q.reject(result);
                });
        }

        function clear() {
            service.pages.length = 0;
            service.paging.info.totalItems = 0;
            service.paging.info.currentPage = 0;
            service.paging.info.totalPages = 1;
        }
    }
})();