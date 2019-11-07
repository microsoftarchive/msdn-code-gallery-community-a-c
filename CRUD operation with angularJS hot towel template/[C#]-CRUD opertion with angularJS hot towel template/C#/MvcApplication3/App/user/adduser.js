(function () {
    'use strict';
    var controllerId = 'addusercontroller';
    angular
        .module('app')
        .controller(controllerId, ['common', 'datacontext','$scope', adduser]);

    //adduser.$inject = ['$location']; 

    function adduser(common, datacontext,$scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'adduser';
      //  vm.save = save;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        activate();
        $scope.save = function () {
            var currentuser = $scope.user;
            datacontext.savePeople(currentuser);
            $scope.message = 'User saved';
        }
        //save(common,datacontext)
        function activate() {
            //var promises = [save()];
          //  vm.save = save;
            common.activateController([], controllerId)
                .then(function () { log('Add User'); });
        }

        function save() {

            datacontext.save(vm.user);
        }
    }
   
})();
