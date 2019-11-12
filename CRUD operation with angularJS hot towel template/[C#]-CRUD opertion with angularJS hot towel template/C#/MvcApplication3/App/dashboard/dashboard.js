(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext','$scope', dashboard]);

    function dashboard(common, datacontext, $scope) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Add User',
            description: 'Hot Towel Angular is a SPA template for Angular developers.'
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.title = 'Dashboard';
        $scope.edituser=function()
        {
          //  var currentuser = $scope.user;
            this.p.editMode = true;
            //$scope.user.editMode = true;
        }
        $scope.cancel = function () {
            //  var currentuser = $scope.user;
            this.p.editMode = false;

            if ($scope.user != null) {
                $scope.user.firstname = "";
                $scope.user.lastname = "";
                $scope.user.age = "";
                $scope.user.location = "";
            }
        }
        $scope.delete= function(idx)
        {
            var currentuser = this.p;//.user;
            datacontext.deletePeople(currentuser,$scope,idx)
        }
        $scope.save=function()
        {
            var currentuser = $scope.user;
            var message =datacontext.savePeople(currentuser,$scope);
           // vm.people.push(currentuser);
        }
        $scope.modifyuser = function()
        {
            var message = datacontext.modifyuser(this.p,$scope);
            this.p.editMode = false;
            $scope.Modifymessage = "Data modified successfully"
        }
        activate();

        function activate() {
            var promises = [getMessageCount(), getPeople()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getMessageCount() {
            return datacontext.getMessageCount().then(function (data) {
                return vm.messageCount = data;
            });
        }

        function getPeople() {
            return datacontext.getPeople().then(function (data) {
                return vm.people = data;
            });
        }
    }
})();