(function() {
    'use strict';

    angular
        .module('app')
        .directive('bookSort', bookSort);

    bookSort.$inject = ['bookService'];
    
    function bookSort(bookService) {
        var directive = {        
            restrict: 'E',
            replace: true,
            templateUrl: 'app/books/bookSort.html',
            scope: {
                orderByOptions: '=',
                orderBy: '='
            }
        };

        return directive;
    }

})();