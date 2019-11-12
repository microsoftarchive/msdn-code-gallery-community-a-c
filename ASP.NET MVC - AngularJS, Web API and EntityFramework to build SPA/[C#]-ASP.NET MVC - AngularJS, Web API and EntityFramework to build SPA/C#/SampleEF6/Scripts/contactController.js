/// <reference path="angular.js" />
function contactController($scope, $http, $q) {
    $scope.contacts = [];
    $scope.contact = {};

    init();

    function init() {
        getContacts();
    }

    function getContacts() {
        var deferred = $q.defer();
        $http.get('/api/Contact').success(function (results) {
            $scope.contacts = results;
            deferred.resolve(results);
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed getting contacts');
        });

        return deferred.promise;
    };

    function getContact(id) {
        var deferred = $q.defer();
        $http.get('/api/Contact/' + id).success(function (results) {
            $scope.contact = results;
            deferred.resolve(results);
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed getting contact');
        });

        return deferred.promise;
    };

    function save(contact) {
        var deferred = $q.defer();
        $http.post('/api/Contact/' + contact).success(function (results) {
            $scope.contact = results;
            deferred.resolve(results);
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed saving contact');
        });

        return deferred.promise;
    };

    function edit(contact) {
        var deferred = $q.defer();
        $http.put('/api/Contact/' + contact).success(function (results) {
            $scope.contact = results;
            deferred.resolve(results);
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed editing contact');
        });

        return deferred.promise;
    };

    function remove(id) {
        var deferred = $q.defer();
        $http.delete('/api/Contact/' + id).success(function (results) {
            deferred.resolve(results);
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed deleteing contact');
        });

        return deferred.promise;
    };

    $scope.edit = function (id) {
        var deferred = $q.defer();

        if (id) {
            $scope.title = 'Edit Contact';
            $scope.saveButtonText = 'Update';
            getContact(id);
            $("#modalEdit").modal();
        }
        else {
            $scope.title = 'Add Contact';
            $scope.saveButtonText = 'Save';
            $scope.contact = {};
            $("#modalEdit").modal();
        }
    }

    $scope.delete = function (id) {
        remove(id).then(processSuccess, processError);
        getContacts();
    }

    $scope.save = function () {
        if ($scope.editForm.$valid) {
            if (!$scope.contact.id) {
                save($scope.contact).then(processSuccess, processError);

            }
            else {
                edit($scope.contact).then(processSuccess, processError);
            }

            getContacts();
        }
    }

    function processSuccess() {
        $scope.editForm.$dirty = false;
        toastr.success('Save with success');

        $timeout(function () {
            $route.reload();
        }, 1000);
    }

    function processError(error) {
        toastr.error(error);
    }









}
