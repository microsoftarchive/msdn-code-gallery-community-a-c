(function () {
    'use strict';

    angular
        .module('app')
        .controller('WelcomeController', WelcomeController);

    function WelcomeController() {
        /* jshint validthis:true */
        var vm = this;

        vm.title = 'Querying and filtering AngularJS <> WebAPI <> Entity Framework';
        vm.description = "How to.. modern interface, filter and query. click on the books tab to see the demo. F12 and step through the code to get a better understanding of what's going on.";
    }
})();
