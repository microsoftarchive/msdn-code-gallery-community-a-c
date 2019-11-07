//var myModule = angular.module('employeeModule', []);
//myModule.controller('employeeController', ['$scope', function ($scope) {
//    $scope.users =
//        [
//          { Name: 'Raj Kumar', Designation: 'Project Manager', Location: 'Noida India' },
//          { Name: 'John Smith', Designation: 'Database Administrator', Location: 'Florida USA' },
//          { Name: 'Monika Malhotra', Designation: 'Search Engine', Location: 'Banglora India' },
//          { Name: 'Versha Pandey', Designation: 'Senior Software Engineer', Location: 'Mumbai India' },
//          { Name: 'Steve ', Designation: 'Project Manager', Location: 'Brisbane Australia' },
//          { Name: 'Pooja Sharma', Designation: 'Tester', Location: 'Delhi India' },
//          { Name: 'Reena Tyagi', Designation: 'Fresher', Location: 'Delhi India' }

//        ];
//    $scope.addUsers = function () {
//        $scope.users.push({ Name: $scope.inputData.Name, Designation: $scope.inputData.Designation, Location: $scope.inputData.Location });
//    };
//    $scope.removeUser = function (userToRemove) {
//        var index = this.users.indexOf(userToRemove);
//        this.users.splice(index, 1);
//    };

//    $scope.clearUser = function (user) {
//        user.Name = '';
//        user.Designation = '';
//        user.Location = '';
//    };

//    $scope.clearInput = function () {
//        $scope.inputData.Name = '';
//        $scope.inputData.Designation = '';
//        $scope.inputData.Location = '';
//    };

//    $scope.editUser = function (id) {
//        for (i in $scope.users) {
//            if ($scope.users[i].id == id) {
//                $scope.newUser = angular.copy($scope.users[i]);
//            }
//        }
//    }
//}]);



function friendController($scope, $http) {  
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data
    $http.get('/api/Friend/').success(function (data) {        
        $scope.friends = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.friend.editMode = !this.friend.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit
    $scope.save = function () {
        alert("Edit");
        $scope.loading = true;
        var frien = this.friend;
        alert(emp);
        $http.put('/api/Friend/', frien).success(function (data) {
            alert("Saved Successfully!!");
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Friend! " + data;
            $scope.loading = false;

        });
    };

    //Used to add a new record
    $scope.add = function () {        
        $scope.loading = true;
        $http.post('/api/Friend/', this.newfriend).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.friends.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Friend! " + data;
            $scope.loading = false;

        });
    };

    //Used to edit a record
    $scope.deletefriend = function () {       
        $scope.loading = true;
        var friendid = this.friend.FriendId;
        $http.delete('/api/Friend/' + friendid).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.friends, function (i) {
                if ($scope.friends[i].FriendId === friendid) {
                    $scope.friends.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Friend! " + data;
            $scope.loading = false;

        });
    };

}