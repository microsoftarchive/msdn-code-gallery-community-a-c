(function () { // jscs:ignore validateLineBreaks
    'use strict';
    angular.module('main').factory('sourceControlService', ['$http', sourceControlService]);

    function sourceControlService($http) {
        return {
            compare: function(codeForCompare) {
                return $http.post('/api/VersionControl/CompareSource', codeForCompare);
            }
        }
    }
})();