// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   


var app;


(function () {
    app = angular.module("RESTClientModule", ['ngAnimate']);
})();


app.controller("AngularJs_Controller", function ($scope, $timeout, $rootScope, $window, $http) {
    $scope.date = new Date();
    $scope.MyName = "shanu";
    $scope.sMenuID = "";
    $scope.sMenuName = "";
   


    $scope.showMenuAdd = true;
    $scope.addEditMenu = false;
    $scope.MenuList = true;
    $scope.showItem = true;
    $scope.userRoleName = $("#txtuserRoleName").val();
    //This variable will be used for Insert/Edit/Delete menu details.  menuID, menuName, parentMenuID, UserRole, menuFileName, MenuURL, UseYN
    $scope.MenuIdentitys = 0;
    $scope.menuIDs = "";
    $scope.menuNames = "";
    $scope.parentMenuIDs = "";
    $scope.selectedUserRole = "";
    $scope.menuFileNames = "";
    $scope.MenuURLs = "";
    $scope.UseYNs = true;
    $scope.searchRoleName = "";
  

   

    // This method is to get all the UserRole and bind to dropdownbox selection for creating menu by User Role. 
    selectuerRoleDetails($scope.searchRoleName);
    // This method is to get all the UserRole and bind to dropdownbox selection for creating menu by User Role. 
    function selectuerRoleDetails(UserRole) {      
        $http.get('/api/MenuAPI/getUserRoleDetails/', { params: { UserRole: UserRole } }).success(function (data) {
         
            $scope.userRoleData = data;
        })
  .error(function () {
      $scope.error = "An Error has occured while loading posts!";
  });
    }


    //This method is used to search and display the Menu Details for display,Edit and Delete
    selectMenuDetails($scope.sMenuID, $scope.sMenuName);

    function selectMenuDetails(menuID, menuName) {
     
        $http.get('/api/MenuAPI/getMenuCRUDSelect/', { params: { menuID: menuID, menuName: menuName } }).success(function (data) {
            $scope.MenuData = data;
            $scope.showMenuAdd = true;
            $scope.addEditMenu = false;
            $scope.MenuList = true;
            $scope.showItem = true;

            if ($scope.MenuData.length > 0) {
            }
        })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
   });

        //Here we call all the created menu details to bind in select list for creating sub menu
        $http.get('/api/MenuAPI/getMenuCRUDSelect/', { params: { menuID: "", menuName: "" } }).success(function (data) {
            $scope.MenuDataSelect = data;         

          
        })
  .error(function () {
      $scope.error = "An Error has occured while loading posts!";
  });
        
       
    }


    //Search
    $scope.searchMenuDetails = function () {

        selectMenuDetails($scope.sMenuID, $scope.sMenuName);
    }

    //Edit Menu Details
    $scope.menuEdit = function menuEdit(MenuIdentity, menuID, menuName, parentMenuID, UserRole, menuFileName, MenuURL, UseYN) {
        cleardetails();
        $scope.MenuIdentitys = MenuIdentity;
        $scope.menuIDs = menuID;
        $scope.menuNames = menuName;
        $scope.parentMenuIDs = parentMenuID;
        $scope.selectedUserRole = UserRole;
        $scope.menuFileNames = menuFileName;
        $scope.MenuURLs = MenuURL;     
        if (UseYN == "Y")
        {
            $scope.UseYNs = true;
        }
        else
        {
            $scope.UseYNs = false;
        }
       

        $scope.showMenuAdd = true;
        $scope.addEditMenu = true;
        $scope.MenuList = true;
        $scope.showItem = true;
    }

    //Delete Menu Detail
    $scope.MenuDelete = function MenuDelete(MenuIdentity, menuName) {
        cleardetails();
        $scope.MenuIdentitys = MenuIdentity;
        var delConfirm = confirm("Are you sure you want to delete the Student " + menuName + " ?");
        if (delConfirm == true) {

            $http.get('/api/MenuAPI/deleteMenu/', { params: { MenuIdentity: $scope.MenuIdentitys } }).success(function (data) {
                alert("Menu Deleted Successfully!!");
                cleardetails();
                selectMenuDetails('', '');
            })
      .error(function () {
          $scope.error = "An Error has occured while loading posts!";
      });

        }
    }

    // New Menu Add Details
    $scope.showMenuAddDetails = function () {
        cleardetails();
        $scope.showMenuAdd = true;
        $scope.addEditMenu = true;
        $scope.MenuList = true;
        $scope.showItem = true;

    }

    //clear all the control values after insert and edit.
    function cleardetails() {
        $scope.MenuIdentitys = 0;
        $scope.menuIDs = "";
        $scope.menuNames = "";
        $scope.parentMenuIDs = "";
        $scope.selectedUserRole = "";
        $scope.menuFileNames = "";
        $scope.MenuURLs = "";
        $scope.UseYNs = true;
        $scope.IsFormSubmitted = false;
    }

    //Form Validation
    $scope.Message = "";
    $scope.IsFormSubmitted = false;

    $scope.IsFormValid = false;


    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;

    });

    //Save Menu
    $scope.saveDetails = function () {
        if ($scope.selectedUserRole == "")
        {
            alert("Select User Role");
            return;
        }
      
        if ($scope.parentMenuIDs == "") {
            alert("Select parent ID");
            return;
        }

        $scope.IsFormSubmitted = true;
        if ($scope.IsFormValid) {
          
            if ($scope.UseYNs == true)
            {
                $scope.UseYNsN = "Y";
            }
            else
            {
                $scope.UseYNsN = "N";
            }
           

            //if the MenuIdentity ID=0 means its new Menu insert here i will call the Web api insert method
            if ($scope.MenuIdentitys == 0) {

                $http.get('/api/MenuAPI/insertMenu/', { params: { menuID: $scope.menuIDs, menuName: $scope.menuNames, parentMenuID: $scope.parentMenuIDs, UserRole: $scope.selectedUserRole, menuFileName: $scope.menuFileNames, MenuURL: $scope.MenuURLs, UseYN: $scope.UseYNsN } }).success(function (data) {

                    $scope.menuInserted = data;
                    alert($scope.menuInserted);


                    cleardetails();
                    selectMenuDetails('', '');
                    selectMenubyUserRoleDetails($scope.userRoleName);
                })
         .error(function () {
             $scope.error = "An Error has occured while loading posts!";
         });
            }
          

            else {  // to update to the Menu details
                $http.get('/api/MenuAPI/updateMenu/', { params: { MenuIdentity: $scope.MenuIdentitys, menuID: $scope.menuIDs, menuName: $scope.menuNames, parentMenuID: $scope.parentMenuIDs, UserRole: $scope.selectedUserRole, menuFileName: $scope.menuFileNames, MenuURL: $scope.MenuURLs, UseYN: $scope.UseYNsN } }).success(function (data) {
                    $scope.menuUpdated = data;
                    alert($scope.menuUpdated);

                    cleardetails();
                    selectMenuDetails('', '');
                    selectMenubyUserRoleDetails($scope.userRoleName);
                })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
            }

        }
        else {
            $scope.Message = "All the fields are required.";
        }

        $scope.IsFormSubmitted = false;
    }




    //********** ---------------- for Disoplay Menu by User Role -------------   ***************
    // This method is to get all the menu details of logged in users .Bind this result for creating Menu
    selectMenubyUserRoleDetails($scope.userRoleName);
    // This method is to get all the menu details of logged in users .Bind this result for creating Menu
    function selectMenubyUserRoleDetails(UserRole) {
       // alert($scope.userRoleName);
        $http.get('/api/MenuAPI/getMenubyUserRole/', { params: { UserRole: $scope.userRoleName } }).success(function (data) {
            $scope.generateMenuData = data;
        })
 .error(function () {
     $scope.error = "An Error has occured while loading posts!";
 });

    }



    $scope.showDetails = false;
    $scope.showSubDetails = false;
    $scope.subChildIDS = "";
    $scope.Imagename = "R1.png";
    $scope.showsubMenu = function (showMenus, ids) {

        if (showMenus == 1) {
            $scope.subChildIDS = ids;

            $scope.showSubDetails = true;
        }
        else if (showMenus == 0) {
            $scope.showSubDetails = false;
        }
        else {

            $scope.showSubDetails = true;
        }
    }

    //********** ---------------- End Disoplay Menu -------------   ***************

});