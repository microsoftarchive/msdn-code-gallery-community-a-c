(function() {
    'use strict';

    angular
        .module('app')
        .directive('topNav', topNav);

    topNav.$inject = [];
    
    function topNav () {        
        var directive = {
            restrict: 'E',
            replace: true,
            templateUrl: 'app/topNav.html'
        };
        return directive;
    }

})();