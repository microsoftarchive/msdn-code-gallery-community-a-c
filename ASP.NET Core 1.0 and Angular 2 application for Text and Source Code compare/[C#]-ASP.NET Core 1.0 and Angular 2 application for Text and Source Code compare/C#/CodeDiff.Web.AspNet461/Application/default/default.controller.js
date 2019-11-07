(function () {
    'use strict';
    angular.module('main').controller('defaultController', homeController);

    homeController.$inject = ['sourceControlService'];

    function homeController(sourceControlService) {
        var vm = this;

        vm.codeForCompare = {version1: '', version2: ''};
        vm.textDiffHtmlVisualizationResult = {version1DiffHtml: '', version2DiffHtml: ''};
        vm.compare = compare;

        function compare() {
            sourceControlService.compare(vm.codeForCompare).then(function(data){
                vm.textDiffHtmlVisualizationResult.version1DiffHtml = data.data.version1DiffHtml;
                vm.textDiffHtmlVisualizationResult.version2DiffHtml = data.data.version2DiffHtml;
                //alert('Completed!');
            });
        }
    }
})();