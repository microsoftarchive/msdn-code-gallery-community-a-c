(function() {
    'use strict';
    angular.module('main').directive("loadingIndicator", function() {
        return {
            restrict : "A",
            link : function(scope, element, attrs) {
                scope.$on("loading-started", function(e) {
                    element.css("display", "block");
                });

                scope.$on("loading-complete", function(e) {
                    element.css("display", "none");
                });
            }
        };
    });
})();