
app.service('CRUDService', function ($http) {
    //**********----Get Record----***************
    this.getProducts = function (apiRoute) {
        return $http.get(apiRoute);
    }
});