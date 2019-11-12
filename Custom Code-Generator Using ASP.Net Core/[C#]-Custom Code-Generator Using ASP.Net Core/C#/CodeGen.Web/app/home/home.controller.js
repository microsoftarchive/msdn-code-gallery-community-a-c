
templatingApp.controller('HomeController', ['$scope', '$http', function ($scope, $http) {

    $scope.dbId = 0; $scope.dbname = null;
    $scope.collist = []; $scope.isCheckAll = 0;


    $("#checkAll").click(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
        var elm = $('#checkboxes input:checked[name="coList[]"]').map(function () { return $(this).val(); }).get();
        var totalelm = elm.length;
        if (totalelm > 0) {
            for (var i = 1; i <= totalelm; i++) {
                var el = document.getElementById('chkc_' + i);
                angular.element(el).triggerHandler('click');
            };
        }
        else {
            $scope.collist = [];
        };
    });

    GetAllDb();
    function GetAllDb() {
        $http({
            method: 'GET',
            url: '/api/Codegen/GetDatabaseList'
        }).then(function successCallback(response) {
            $scope.dblist = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    };

    $scope.getAllTable = function (itm) {
        $scope.dbId = itm.databaseId; $scope.dbname = itm.databaseName;
        $scope.dbModel = {
            DatabaseId: itm.databaseId,
            DatabaseName: itm.databaseName
        };

        $http({
            method: 'POST',
            url: '/api/Codegen/GetDatabaseTableList',
            data: $scope.dbModel
        }).then(function successCallback(response) {
            $scope.tblist = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    };

    $scope.getAllTableColumn = function (itm) {
        $scope.dbModel = {
            DatabaseId: $scope.dbId,
            DatabaseName: $scope.dbname,
            TableId: itm.tableId,
            TableName: itm.tableName
        };

        $http({
            method: 'POST',
            url: '/api/Codegen/GetDatabaseTableColumnList',
            data: $scope.dbModel
        }).then(function successCallback(response) {
            $scope.colist = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    };

    $scope.getColumn = function (itm, status) {
        if (status) {
            var result = checkValue(itm.columnId, $scope.collist);
            if (result == 'Not exist') {
                $scope.collist.push({
                    ColumnId: itm.columnId,
                    ColumnName: itm.columnName,
                    DataType: itm.dataType,
                    MaxLength: itm.maxLength,
                    IsNullable: itm.isNullable,
                    TableSchema: itm.tableSchema,
                    Tablename: itm.tablename
                });
            }
        }
        else {
            var index = $scope.collist.indexOf(itm.ColumnId);
            if (index > -1)
                $scope.collist.splice(index, 1);
        }
    };

    $scope.generate = function () {
        $('.nav-tabs a[href="#views"]').tab('show');

        var rowGen = [];
        var elementIDSql = 'genCodeSql';
        var elementIDVm = 'genCodeVm';
        var elementIDVu = 'genCodeVu';
        var elementIDNg = 'genCodeAngular';
        var elementIDApi = 'genCodeAPI';

        if ($scope.collist.length > 0) {
            var models = "[" + JSON.stringify($scope.collist) + "]";

            $http({
                method: 'POST',
                url: '/api/Codegen/GenerateCode',
                data: models,
                dataType: "json",
                contentType: 'application/json; charset=utf-8'
            }).then(function (response) {

                $('#genCodeSql').text(''); $('#genCodeVm').text(''); $('#genCodeVu').text(''); $('#genCodeAngular').text(''); $('#genCodeAPI').text('');
                rowGen = response.data.spCollection;

                if (rowGen.length > 0) {
                    for (var i = 0; i < rowGen.length; i++) {
                        //SP
                        if (i == 0)
                            document.getElementById(elementIDSql).innerHTML += "--+++++++++ SET SP +++++++ \r\n" + rowGen[i] + "\r\n";
                        else if (i == 1)
                            document.getElementById(elementIDSql).innerHTML += "--+++++++++ GET SP +++++++++ \r\n" + rowGen[i] + "\r\n";
                        else if (i == 2)
                            document.getElementById(elementIDSql).innerHTML += "--+++++++++ PUT SP +++++++++ \r\n" + rowGen[i] + "\r\n";
                        else if (i == 3)
                            document.getElementById(elementIDSql).innerHTML += "--+++++++++ DELETE SP +++++++++ \r\n" + rowGen[i] + "\r\n";
                        //VM
                        else if (i == 4)
                            document.getElementById(elementIDVm).innerHTML += "// +++++++++ MODEL PROPERTIES +++++++++ \r\n" + rowGen[i] + "\r\n";
                        //VIEW
                        else if (i == 5)
                            document.getElementById(elementIDVu).innerHTML += "<!-- +++++++++ HTML FORM +++++++++ --> \r\n" + rowGen[i] + "\r\n";
                        //ANGULAR
                        else if (i == 6)
                            document.getElementById(elementIDNg).innerHTML += "// +++++++++ AngularJS Controller +++++++++ \r\n" + rowGen[i] + "\r\n";
                        //API
                        else if (i == 7)
                            document.getElementById(elementIDApi).innerHTML += "// +++++++++ API Controller +++++++++ \r\n" + rowGen[i] + "\r\n";
                        else
                            document.getElementById(elementIDSql).innerHTML += " Error !!";
                    };
                };
            }, function (error) {
                console.log(error);
            });
        }
        else {
            rowGen = []; $('#genCodeSql').text(''); $('#genCodeVm').text('');
            console.log("Please Choose a Column!!");
        };
    };
    $scope.reset = function () {
        $scope.collist = []; rowGen = [];
        $('#genCodeSql').text(''); $('#genCodeVm').text('');
    };

    var checkValue = function (value, arr) {
        var status = 'Not exist';
        for (var i = 0; i < arr.length; i++) {
            var columnId = arr[i].columnId;
            if (columnId == value) {
                status = 'Exist';
                break;
            }
        }
        return status;
    };

    var postMultipleModel = function (apiRoute, methodMode, model) {
        var models = "[" + JSON.stringify(model) + "]";
        var request = $http({
            method: methodMode,
            url: apiRoute,
            data: models,
            async: false,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
        });

        return request;
    };
}]);
