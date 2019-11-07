(function () {
    'use strict';
    var angularControllers = angular.module('angularControllers', []);

    angularControllers.controller('ListCtrl', ['$scope', '$http', '$location', '$route',
      function ($scope, $http, $location, $route) {
          $http.get('data/data.json').success(function (data) {
              $scope.data = data;
          });

          $scope.orderProp = 'model';

          $scope.go = function (route) {
              // $scope.$apply(function () { $location.path(route); });
              $location.path(route);
          }

      }]);

    angularControllers.controller('DetailCtrl', ['$scope', '$routeParams', '$http',
      function ($scope, $routeParams, $http) {
          $http.get('data/' + $routeParams.itemId + '.json').success(function (data) {
              $scope.item = data;
          });
      }]);
})();