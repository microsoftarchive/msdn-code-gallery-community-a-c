(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;
        var $http = common.$http;
        //var $scope = common.$scope;
        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount,
            savePeople: savePeople,
            modifyuser: modifyuser,
            deletePeople:deletePeople
        };

        return service;

        function getMessageCount() { return $q.when(72); }
        function modifyuser(user,$scope)
        {
           // var $scope = $scope;
            var request = $http({
                method: "post",
                url: "/HotTowel/ModifyPeople",
                data: user
            });

            return request.then(handleSucess, handleError);
        }

        function deletePeople(user, $scope,idx) {
           // var $scope = $scope;
            var request = $http({
                method: "post",
                url: "/HotTowel/DeletePeople",
                data: user
            });

            return request.then(function (response) {
                $scope.vm.people.splice(idx, 1);
                $scope.Modifymessage = "Data deleted successfully"
            },
            function (error) {
                handleError(error);
            }
               );
        }


        function savePeople(user,$scope)
        {
                var request = $http({
                    method: "post",
                    url: "/HotTowel/SavePeople",
                    data: user
                });

              //  var nsg = request.then(handleSucess, handleError);

                return request.then(function (response) {
                    $scope.vm.people.push(response.data);
                    $scope.message = "Data saved successfully"
                    $scope.user.firstname = "";
                    $scope.user.lastname = "";
                    $scope.user.age = "";
                    $scope.user.location = "";
                },
                function (error) {
                    handleError(Error);
                }
                );
                    //handleSucess,handleError);
        }
        function handleSucess(response)
        {
            
            return response.data;
        }
        function handleError(response)
        {
            // The API response from the server should be returned in a
            // nomralized format. However, if the request was not handled by the
            // server (or what not handles properly - ex. server error), then we
            // may have to normalize it on our end, as best we can.
            if (
            !angular.isObject(response.data) ||
            !response.data.message
            ) {
                return ($q.reject("An unknown error occurred."));
            }
            // Otherwise, use expected error message.
            return ($q.reject(response.data.message));

        }

        function getPeople() {

            // Get the deferred object
            var deferred = $q.defer();
            // Initiates the AJAX call
            $http({ method: 'GET', url: '/HotTowel/GetPeopleDetails' }).success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request completes
            return deferred.promise;
            /*
            var people = [
                { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
                { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
                { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
                { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
                { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
                { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
                { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
            ];
            return $q.when(people);
            */
        }
    }
})();