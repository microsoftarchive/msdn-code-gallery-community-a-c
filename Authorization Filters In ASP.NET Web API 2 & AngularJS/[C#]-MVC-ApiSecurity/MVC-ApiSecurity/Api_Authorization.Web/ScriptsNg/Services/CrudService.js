
AppSecurity.service('crudService', function ($http) {
    //**********----Get All Record----***************

    this.get = function (apiRoute, headerToken) {
        var request = $http({
            method: "get",
            url: apiRoute,
            headers: headerToken
        });
        return request;
    }

    //**********----Get Single Record----***************
    this.getByID = function (apiRoute, headerToken) {
        var request = $http({
            method: "get",
            url: apiRoute,
            headers: headerToken
        });
        return request;
    }

    //**********----Create New Record----***************
    this.post = function (apiRoute, model, headerToken) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: model,
            headers: headerToken
        });
        return request;
    }

    //**********----Update the Record----***************
    this.put = function (apiRoute, model, headerToken) {
        var request = $http({
            method: "put",
            url: apiRoute,
            data: model,
            headers: headerToken
        });
        return request;
    }

    //**********----Delete the Record----***************
    this.delete = function (apiRoute, headerToken) {
        var request = $http({
            method: "delete",
            url: apiRoute,
            headers: headerToken
        });
        return request;
    }
});