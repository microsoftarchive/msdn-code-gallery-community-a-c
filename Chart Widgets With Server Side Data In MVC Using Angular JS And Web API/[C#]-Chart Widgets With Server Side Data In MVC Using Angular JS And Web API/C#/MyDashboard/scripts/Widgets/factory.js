(function () {
    'use strict';
    angular
        .module('WidgetsApp')
        .service('factory', function ($http) {
            this.getData = function () {
                var url = 'Api/Widget';
                return $http({
                    type: 'get',
                    url: url
                });
            }
        });
})();