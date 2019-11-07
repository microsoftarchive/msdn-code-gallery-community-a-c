(function() {
    'use strict';

    angular
        .module('app')
        .directive('bookSearch', bookSearch);

    bookSearch.$inject = ['bookService'];
    
    function bookSearch(bookService) {
        var directive = {
            link: link,
            restrict: 'E',
            replace: true,
            scope: {
                search: '&',
                searchText: '='
            },
            templateUrl: 'app/books/bookSearch.html'         
        };
        return directive;

        function link(scope, element, attrs) {
            scope.internalSearchText = "";

            scope.searchClicked = function () {
                if (scope.internalSearchText) {
                    scope.searchText = scope.internalSearchText;
                } else {
                    scope.searchText = null;
                }
                
                scope.search();
            }

            scope.$watch('searchText',
                function (newTxt, oldTxt) {
                    if (newTxt && newTxt !== oldTxt) {
                        scope.internalSearchText = newTxt;
                    }
                },
                true);
        }
    }

})();