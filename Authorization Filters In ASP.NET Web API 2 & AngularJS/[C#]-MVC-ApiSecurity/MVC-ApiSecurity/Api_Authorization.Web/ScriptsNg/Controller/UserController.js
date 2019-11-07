
AppSecurity.controller('userCtrl', ['$scope', '$http', 'crudService', '$window', '$sessionStorage',
    function ($scope, $http, crudService, $window, $sessionStorage) {

        $scope.message = 'Authorization Filters in ASP.NET Web API 2';
        
        $scope.loggedflag = false;
        $scope.loggedip = '';
        $scope.loggeduser = '';

        $scope.accountManager = {
            loggedflag: false,
            loginurl: '/Account/Login',
            loginsessionurl: '/Account/GetSession',
            logouturl: '/Account/Logout',

            //login-logout
            login: function () {
                var login = crudService.post($scope.accountManager.loginurl, $scope.userModel);
                login.then(function (response) {
                    if (response.data.UserId > 0) {
                        $sessionStorage.loggedflag = true;
                        $sessionStorage.loggeduser = response.data.UserName;
                        $sessionStorage.loggeduserrole = response.data.Role;
                        $sessionStorage.loggedip = response.data.Ip;
                        $window.location = '/Home';
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            },
            logout: function () {
                var logoutsession = crudService.get($scope.accountManager.logouturl);
                logoutsession.then(function (response) {
                    if (response) {
                        $sessionStorage.loggedflag = false;
                        $sessionStorage.loggeduser = '';
                        $window.location = '/Account';
                    }  
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        };

        $scope.loggedflag = $sessionStorage.loggedflag;
        $scope.loggeduser = $sessionStorage.loggeduser;
    }]);
