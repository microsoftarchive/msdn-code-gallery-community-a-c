(function () {

    //angular module
    var myApp = angular.module('myApp', ['angularTreeview']);

    //controller
    myApp.controller('myController', function ($scope, $http) {
        fetch();
        function fetch() {
            $http({
                method: 'GET',
                url: '/api/Roles'
            }).then(function successCallback(response) {
                console.log(response.data.objRole);
                $scope.roleList = response.data.objRole;
            }, function errorCallback(response) {
                console.log(response);
            });
        }
    });

})();

