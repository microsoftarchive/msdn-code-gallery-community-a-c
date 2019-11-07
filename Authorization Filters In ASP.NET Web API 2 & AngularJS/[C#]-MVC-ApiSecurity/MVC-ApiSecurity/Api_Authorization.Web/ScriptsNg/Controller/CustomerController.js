
AppSecurity.controller('customerCtrl', ['$scope', '$http', 'crudService',
    function ($scope, $http, crudService) {
        $scope.modalmessage = 'New Customer';
        $scope.custId = 0;
        $scope.customerManager = {
            pagesize: 100,
            pagenumber: 0,
            apiUrlget: '/api/Customer/GetCustomers',
            apiUrlpost: '/api/Customer/SaveCustomer',
            apiUrlput: '/api/Customer/UpdateCustomer',
            apiUrldelete: '/api/Customer/DeleteCustomer',
            methodtype: null,

            //Http Get Customer 
            _get: function () {
                $scope.customers = [];
                $scope.customerManager.methodtype = 'get';
                var headerToken = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.customerManager.methodtype) };

                //Service call
                var url = $scope.customerManager.apiUrlget + '/' + $scope.customerManager.pagenumber + '/' + $scope.customerManager.pagesize;
                var cust = crudService.get(url, headerToken);
                cust.then(function (response) {
                    $scope.authresult = 'Customer records(' + response.data.customer.length + ') : HTTP-' + response.status;
                    $scope.resultStyle = { "color": "green" };
                    $scope.customers = response.data.customer;
                },
                function (error) {
                    switch (error.status) {
                        case 401:
                            $scope.authresult = 'Limited access on retrive data(Unauthorized) : HTTP-' + error.status;
                            $scope.resultStyle = { "color": "red" };
                            break;
                        default:
                            $scope.authresult = error;
                    }
                });
            },

            //Http Get Customer 
            _getbyId: function (dataModel) {
                $scope.customerManager.methodtype = 'put';
                $scope.custId = dataModel.CustomerID;
                $scope.modalmessage = dataModel.CustomerName;
                $scope.customerName = dataModel.CustomerName;
                $scope.customerTel = dataModel.Tel;
            },

            //Http Post Customer 
            _save: function () {
                $scope.customerManager.methodtype = 'post';
                var headerToken = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.customerManager.methodtype) };
                var model = {
                    CustomerName: $scope.customerName,
                    Tel: $scope.customerTel
                };

                //Service call
                var url = $scope.customerManager.apiUrlpost;
                var cust = crudService.post(url, model, headerToken);
                cust.then(function (response) {
                    alert();
                    if (response.data.message === 1) {
                        $scope.modalresult = 'Customer saved: HTTP-' + response.status;
                        $scope.resultStyle = { "color": "green" };
                        $scope.customers = response.data.customer;
                        $scope.customerManager._get();
                        $scope.customerManager._clear();
                        $('#customerModal').modal('hide');
                    }
                },
                function (error) {
                    switch (error.status) {
                        case 401:
                            $scope.authresult = 'Limited access on save data(Unauthorized) : HTTP-' + error.status;
                            $scope.resultStyle = { "color": "red" };
                            $('#customerModal').modal('hide');
                            break;
                        default:
                            $scope.authresult = error;
                    }
                });
            },

            //Http Put Customer 
            _update: function () {
                if ($scope.custId > 0) {
                    var headerToken = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.customerManager.methodtype) };
                    var model = {
                        CustomerID: $scope.custId,
                        CustomerName: $scope.customerName,
                        Gender: $scope.ddlGender,
                        Tel: $scope.customerTel
                    };

                    //Service call
                    var url = $scope.customerManager.apiUrlput;
                    var cust = crudService.put(url, model, headerToken);
                    cust.then(function (response) {
                        if (response.data.message === 1) {
                            $scope.modalresult = 'Customer updated: HTTP-' + response.status;
                            $scope.resultStyle = { "color": "green" };
                            $scope.customers = response.data.customer;
                            $scope.customerManager._get();
                            $scope.customerManager._clear();
                            $('#customerModal').modal('hide');
                        }
                    },
                    function (error) {
                        switch (error.status) {
                            case 401:
                                $scope.authresult = 'Limited access on update data(Unauthorized) : HTTP-' + error.status;
                                $scope.resultStyle = { "color": "red" };
                                $('#customerModal').modal('hide');
                                break;
                            default:
                                $scope.authresult = error;
                        }
                    });
                }
            },

            //Http Delete Customer 
            _delete: function (dataModel) {
                $scope.customerManager.methodtype = 'delete';
                var IsConf = confirm('You are about to delete ' + dataModel.CustomerName + '. Are you sure?');
                if (IsConf) {
                    var headerToken = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.customerManager.methodtype) };

                    //Service call
                    var url = $scope.customerManager.apiUrldelete + '/' + dataModel.CustomerID;
                    var cust = crudService.delete(url, headerToken);
                    cust.then(function (response) {
                        if (response.data.message === 1) {
                            $scope.modalresult = 'Customer deleted:' + dataModel.CustomerName + ' HTTP-' + response.status;
                            $scope.resultStyle = { "color": "green" };
                            $scope.customers = response.data.customer;
                            $scope.customerManager._get();
                        }
                    },
                    function (error) {
                        switch (error.status) {
                            case 401:
                                $scope.authresult = 'Limited access on delete data(Unauthorized) : HTTP-' + error.status;
                                $scope.resultStyle = { "color": "red" };
                                break;
                            default:
                                $scope.authresult = error;
                        }
                    });
                }
            },

            //Reset Form
            _clear: function () {
                $scope.modalmessage = 'New Customer';
                $scope.custId = 0;
                $scope.customerName = '';
                $scope.customerTel = '';
            },
        };
    }]);