(function () {
    'use strict';

    angular
        .module('app')
        .directive('unique', unique);

    unique.$inject = [];

    function unique() {
        var directive = {
            require: 'ngModel',
            link: link,
            restrict: 'A',
            scope: {
                unique: '&'
            }
        };

        return directive;

        function link(scope, element, attrs, ngModel) {            
              var wrappedValidator = function (mv, vv) {
                    ngModel.$setValidity('checking', false);

                    return scope.unique({ title: mv || vv })
                                        .finally(function () {
                                            ngModel.$setValidity('checking', true);
                                        });
                };

                ngModel.$asyncValidators.unique = wrappedValidator;            
        }
    }
})();