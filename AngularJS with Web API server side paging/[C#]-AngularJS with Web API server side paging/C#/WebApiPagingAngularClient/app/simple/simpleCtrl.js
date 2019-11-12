(function () {
    'use strict';

    angular
        .module('app')
        .controller('simpleCtrl', simpleCtrl);

    simpleCtrl.$inject = ['$scope', 'simpleClubSvc'];

    function simpleCtrl($scope, simpleClubSvc) {
        $scope.title = 'simple paging';
        $scope.description = 'Using paging to populate a single list of clubs.';

        $scope.clubs = simpleClubSvc.clubs;
        $scope.loadClubs = loadClubs;

        $scope.clear = simpleClubSvc.clear;
        
        $scope.options = simpleClubSvc.paging.options;
        $scope.info = simpleClubSvc.paging.info;

        $scope.status = {
            type: "info",
            message: "ready",
            busy: false
        };        
        
        activate();

        function activate() {
            //if this is the first activation of the controller load the first page
            if (simpleClubSvc.paging.info.currentPage === 0) {
                simpleClubSvc.load();
            }
        }

        function loadClubs() {
            $scope.status.busy = true;
            $scope.status.message = "loading records";

            simpleClubSvc.load()
                            .then(function (result) {
                                $scope.status.message = "ready";
                            }, function (result) {
                                $scope.status.message = "something went wrong: " + (result.error || result.statusText);
                            })
                            ['finally'](function () {
                                $scope.status.busy = false;
                            });
        }

        function optionsChanged() {
            simpleClubSvc.clear();            
        }
    }
})();
