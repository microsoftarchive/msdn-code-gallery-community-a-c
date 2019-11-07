(function () {
    'use strict';
    angular
        .module('MyApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache'])
        .controller('AutoCompleteCtrl', AutoCompleteCtrl);
    function AutoCompleteCtrl($http, $timeout, $q, $log) {
        var self = this;
        self.simulateQuery = true;
        self.products = loadAllProducts($http);
        self.querySearch = querySearch;
        function querySearch(query) {
            var results = query ? self.products.filter(createFilterFor(query)) : self.products, deferred;
            if (self.simulateQuery) {
                deferred = $q.defer();
                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        }
        function loadAllProducts($http) {
            var allProducts = [];
            var url = '';
            var result = [];
            url = 'api/products';
            $http({
                method: 'GET',
                url: url,
            }).then(function successCallback(response) {
                allProducts = response.data;
                angular.forEach(allProducts, function (product, key) {
                    result.push(
                        {
                            value: product.Name.toLowerCase(),
                            display: product.Name
                        });
                });
            }, function errorCallback(response) {
                console.log('Oops! Something went wrong while fetching the data. Status Code: ' + response.status + ' Status statusText: ' + response.statusText);
            });
            return result;
        }
        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(product) {
                return (product.value.indexOf(lowercaseQuery) === 0);
            };

        }
    }
})();