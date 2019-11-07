(function () {
    'use strict';

    angular
        .module('app')
        .controller('welcome', welcome);
        
    function welcome() {
        var vm = this;
        
        activate();

        function activate() { }
    }
})();
