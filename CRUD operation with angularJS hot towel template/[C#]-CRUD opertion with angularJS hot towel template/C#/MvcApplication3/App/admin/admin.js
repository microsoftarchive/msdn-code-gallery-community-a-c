(function () {
    'use strict';
    var controllerId = 'admin';
    angular.module('app').controller(controllerId, ['common','datacontext','$scope', admin]);

    function admin(common,datacontext,$scope) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'People';

        activate();

        $scope.update=function(user)
        {
            var message = datacontext.modifyuser(user, $scope);
            $('#userModel').modal('hide');
        }
        $scope.add=function()
        {
            var currentuser = $scope.user;
            datacontext.savePeople(currentuser, $scope);
            $('#userModel').modal('hide');
        }
        $scope.showadd=function()
        {
            $scope.user = null;
            $scope.editMode = false;
            $('#userModel').modal('show');
        }
        $scope.showedit=function(p)
        {
            $scope.user= p;
            $scope.editMode = true;
            $('#userModel').modal('show');
            
        }
        $scope.cancel=function()
        {
            $scope.user = null;
            $('#userModel').modal('hide');
        }
        $scope.delete=function(idx)
        {
            var currentuser = this.p;//.user;
            datacontext.deletePeople(currentuser, $scope, idx)
        }
        function activate() {
            var promises = [getPeople()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard 1.0'); });
        }

        function getPeople() {
            return datacontext.getPeople().then(function (data) {
                return vm.people = data;
            });
        }
    }
})();