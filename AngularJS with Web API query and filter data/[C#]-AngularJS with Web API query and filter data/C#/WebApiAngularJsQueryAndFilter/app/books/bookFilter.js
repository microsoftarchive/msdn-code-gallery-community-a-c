(function() {
    'use strict';

    angular
        .module('app')
        .directive('bookFilter', bookFilter);

    bookFilter.$inject = [];
    
    function bookFilter(bookService) {
        var directive = {
            link: link,
            restrict: 'E',
            replace: true,
            scope: {
                availableFilters: '=',
                query: '='
            },
            templateUrl: 'app/books/bookFilter.html'            
        };
        return directive;

        function link(scope, element, attrs) {            
            scope.setSelected = setSelected;
            
            function setSelected(filterType, filterValue) {
                //if value is already selected remove it, otherwise add it
                //must convert id to string as it will always be a string in $routeparams
                var id = filterValue.id.toString();
                
                if (scope.query[filterType] && scope.query[filterType].indexOf(id) >= 0) {
                    if (Array.isArray(scope.query[filterType])) {
                        scope.query[filterType].splice(scope.query[filterType].indexOf(id), 1);
                    } else {
                        scope.query[filterType] = [];
                    }
                } else {                    
                    if (!scope.query[filterType]) {
                        scope.query[filterType] = [];
                    }

                    scope.query[filterType].push(id);
                }                
            }
        }
    }
})();