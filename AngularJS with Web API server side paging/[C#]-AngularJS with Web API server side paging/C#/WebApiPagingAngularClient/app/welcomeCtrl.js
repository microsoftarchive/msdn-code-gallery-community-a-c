(function () {
    'use strict';

    angular
        .module('app')
        .controller('welcomeCtrl', welcomeCtrl);

    welcomeCtrl.$inject = ['$scope']; 

    function welcomeCtrl($scope) {

        activate();

        function activate() { }
    }
})();
