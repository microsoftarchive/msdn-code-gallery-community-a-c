(function() {
    'use strict';

    angular
        .module('app')
        .directive('bookSearchStatus', bookSearchStatus);

    bookSearchStatus.$inject = [];
    
    function bookSearchStatus(bookService) {        
        var directive = {
            restrict: 'E',
            replace: true,
            scope: {
                filters: '=',
                books: '=',
                searchStatus: '='
            },
            templateUrl: 'app/books/bookSearchStatus.html'
        };
        return directive;
    }

})();