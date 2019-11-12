
app.controller('StudentCtrl', ['$scope', 'CrudService',
    function ($scope, CrudService) {

        // Base Url 
        var baseUrl = '/api/Student/';
        $scope.btnText = "Save";
        $scope.studentID = 0;
        $scope.SaveUpdate = function () {
            var student = {
                FirstName: $scope.firstName,
                LastName: $scope.lasttName,
                Email: $scope.email,
                Address: $scope.adress,
                StudentID: $scope.studentID
            }
            if ($scope.btnText == "Save") {
                var apiRoute = baseUrl + 'SaveStudent/';
                var saveStudent = CrudService.post(apiRoute, student);
                saveStudent.then(function (response) {
                    if (response.data != "") {
                        alert("Data Save Successfully");
                        $scope.GetStudents();
                        $scope.Clear();

                    } else {
                        alert("Some error");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else
            {
                var apiRoute = baseUrl + 'UpdateStudent/';
                var UpdateStudent = CrudService.put(apiRoute, student);
                UpdateStudent.then(function (response) {
                    if (response.data != "") {
                        alert("Data Update Successfully");
                        $scope.GetStudents();
                        $scope.Clear();

                    } else {
                        alert("Some error");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }


        $scope.GetStudents = function () {
            var apiRoute = baseUrl + 'GetStudents/';
            var student = CrudService.getAll(apiRoute);
            student.then(function (response) {
                debugger
                $scope.studnets = response.data;

            },
            function (error) {
                console.log("Error: " + error);
            });


        }
        $scope.GetStudents();
        
        $scope.GetStudentByID = function (dataModel)
        {
            debugger
            var apiRoute = baseUrl + 'GetStudentByID';
            var student = CrudService.getbyID(apiRoute, dataModel.StudentID);
            student.then(function (response) {
                $scope.studentID = response.data.StudentID;
                $scope.firstName = response.data.FirstName;
                $scope.lasttName = response.data.LastName;
                $scope.email = response.data.Email;
                $scope.adress = response.data.Address;
                $scope.btnText = "Update";
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.DeleteStudent = function (dataModel)
        {
            debugger
            var apiRoute = baseUrl + 'DeleteStudent/' + dataModel.StudentID;
            var deleteStudent = CrudService.delete(apiRoute);
            deleteStudent.then(function (response) {
                if (response.data != "") {
                    alert("Data Delete Successfully");
                    $scope.GetStudents();
                    $scope.Clear();

                } else {
                    alert("Some error");
                }

            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.Clear = function () {
            $scope.studentID = 0;
            $scope.firstName = "";
            $scope.lasttName = "";
            $scope.email = "";
            $scope.adress = "";
            $scope.btnText = "Save";
        }

    }]);