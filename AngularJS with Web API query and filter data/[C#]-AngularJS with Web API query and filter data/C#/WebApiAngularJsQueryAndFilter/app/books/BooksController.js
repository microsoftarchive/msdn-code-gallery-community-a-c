(function () {
    'use strict';

    angular
        .module('app')
        .controller('BooksController', BooksController);

    BooksController.$inject = ['$scope', '$route', '$routeParams', 'bookService']; 

    /* to keep this project lightweight a dialog service has not been used and errors are show using alert. 
    This is not recommended in a real world application*/

    function BooksController($scope, $route, $routeParams, bookService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'BooksController';        
        vm.books = [];            
        vm.filterBy = filterBy;
        vm.status = {
            loaded: false,
            busy: false,
            message: ''
        };
        vm.search = search;               

        activate();
        
        function activate() {
            //get the filter values and the order by values to chooose from
            bookService.setupQuery({
                filters: ['classifications','publishers']
            })
            .then(function (result) {
                vm.options = result.options;                                
                vm.query = result.query;
                vm.query.orderBy = "title"; //set an initial order by value

                //watch the query and on any changes update the route params
                $scope.$watch("vm.query",
                function (newQuery, oldQuery) {
                    if (newQuery !== oldQuery) {
                        //if the are any unselectable filters (author in this demo) which have been used and are still on the query then remove them for the next query
                        cleanMiscFilters(newQuery, oldQuery);
                        $route.updateParams(vm.query);
                        search();
                    }
                },
                true);

                if (Object.keys($routeParams).length > 0) {
                    bookService.queryFromParams(vm.query, $routeParams);
                    search();
                } else {                    
                    /*in a real world scenario with paging implemented you may well want to load the first page of all results here
                    if no query is supplied */
                }
            },function (result) {
                alert("Web API has thrown the exception below. Please fix this error, rebuild and reload the project. Error: " + result.data);
            })
            .finally(function () {
                vm.status.loaded = true;
            });
        }

        function cleanMiscFilters(newQuery, oldQuery) {
            vm.options.allFilterTypes.forEach(function (filterType) {
                if (!vm.options.selectableFilters[filterType] && newQuery[filterType].length > 0 && angular.equals(newQuery[filterType], oldQuery[filterType])) {
                    newQuery[filterType].length = 0;
                }
            });            
        }

        //called when clicking on link in the results (author name for example). Clear out the existing query and add the new filter
        function filterBy(filterType, filterValue) {
            angular.forEach(vm.query,function (value, key) {
                if (filterType === key) {
                    vm.query[key].length = 0;
                    vm.query[key].push(String(filterValue));            
                }                    
                else if(angular.isArray(value)){
                    vm.query[key].length = 0;
                } else if(key !== "orderBy") {
                    vm.query[key] = "";
                }
            });
        }
    
        function search() {
            vm.status.busy = true;
            vm.books.length = 0;
            return bookService.search(vm.query)
                                    .then(function (results) {
                                        vm.books = results.books;
                                        return results;
                                    },function (result) {
                                        alert("Web API has thrown the exception below. Please fix this error, rebuild and reload the project. Error: " + result.data);
                                    })
                                    .finally(function () {
                                        vm.status.busy = false;
                                    });
        }
    }
})();
