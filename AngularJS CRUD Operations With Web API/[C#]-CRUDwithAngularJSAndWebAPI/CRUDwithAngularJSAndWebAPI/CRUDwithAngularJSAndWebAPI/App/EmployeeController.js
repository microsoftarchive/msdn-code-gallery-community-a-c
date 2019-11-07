app.controller("EmployeeController", ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
    $scope.ListOfEmployee;
    $scope.Status;

    $scope.Close = function () {
        $location.path('/EmployeeList');
    }    

    //Get all employee and bind with html table
    $http.get("api/employee/GetAllEmployee").success(function (data) {
        $scope.ListOfEmployee = data;

    })
    .error(function (data) {
        $scope.Status = "data not found";
    });

    //Add new employee
    $scope.Add = function () {
        var employeeData = {
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Address: $scope.Address,
            Salary: $scope.Salary,
            DOB: $scope.DOB,
           // DepartmentID: $scope.DepartmentID
        };
        debugger;
        $http.post("api/employee/AddEmployee", employeeData).success(function (data) {
            $location.path('/EmployeeList');
        }).error(function (data) {
            console.log(data);
            $scope.error = "Something wrong when adding new employee " + data.ExceptionMessage;
        });
    }

    //Fill the employee records for update

    if ($routeParams.empId) {
        $scope.Id = $routeParams.empId;

        $http.get('api/employee/GetEmployee/' + $scope.Id).success(function (data) {
            $scope.FirstName = data.FirstName;
            $scope.LastName = data.LastName;
            $scope.Address = data.Address;
            $scope.Salary = data.Salary;
            $scope.DOB = data.DOB
            //$scope.DepartmentID = data.DepartmentID
        });

    }

    //Update the employee records
    $scope.Update = function () {
        debugger;
        var employeeData = {
            EmployeeID: $scope.Id,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Address: $scope.Address,
            Salary: $scope.Salary,
            DOB: $scope.DOB
            //DepartmentID: $scope.DepartmentID
        };
        if ($scope.Id > 0) {
            
            $http.put("api/employee/UpdateEmployee", employeeData).success(function (data) {
                $location.path('/EmployeeList');
            }).error(function (data) {
                console.log(data);
                $scope.error = "Something wrong when adding updating employee " + data.ExceptionMessage;
            });
        }
    }


    //Delete the selected employee from the list
    $scope.Delete = function () {
        if ($scope.Id > 0) {
            
            $http.delete("api/employee/DeleteEmployee/" + $scope.Id).success(function (data) {
                $location.path('/EmployeeList');
            }).error(function (data) {
                console.log(data);
                $scope.error = "Something wrong when adding Deleting employee " + data.ExceptionMessage;
            });
        }

    }
}]);