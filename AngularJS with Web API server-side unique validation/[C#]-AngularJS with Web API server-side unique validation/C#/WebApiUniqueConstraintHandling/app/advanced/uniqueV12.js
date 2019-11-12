(function () {
    'use strict';

    angular
        .module('app')
        .directive('uniqueV12', uniqueV12);

    uniqueV12.$inject = ['$parse'];

    function uniqueV12($parse) {

        var directive = {
            restrict: 'A',
            require: 'ngModel',
            link: link
        };

        return directive;

        function link(scope, element, attrs, ctrl) {
            var fn = $parse(attrs["uniqueV12"]),
                checkUnique = function () {
                    return fn(scope, { modelValue: ctrl.$modelValue, viewValue: ctrl.$viewValue });
                };

            ctrl.$viewChangeListeners.push(function () {
                checkUnique().then(
                    function () {
                        ctrl.$setValidity('unique', true);
                    },
                    function () {
                        ctrl.$setValidity('unique', false);
                    });
            });
        }
    }

})();