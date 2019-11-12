/// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   
/// <reference path="Modules.js" />   
/// <reference path="Services.js" />   

app.controller("AngularJs_WCFController", function ($scope, $timeout, $rootScope, $window, AngularJs_WCFService, FileUploadService) {
    $scope.date = new Date();
 //  To set and get the Item Details values
    var firstbool = true;  
    $scope.Imagename = "";
    $scope.Item_ID = "0";
    $scope.Item_Name = "";
    $scope.Description = "";
    $scope.Item_Price = "0";
    $scope.txtAddedBy = "";

   


    // This is publich method which will be called initially and load all the item Details. 
    GetItemDetails();
    //To Get All Records   
    function GetItemDetails() {


        var promiseGet = AngularJs_WCFService.GetItemDetails();
        promiseGet.then(function (pl) {
            $scope.getItemDetailsDisp = pl.data
        },
             function (errorPl) {
             });
    }

    //Declarationa and Function for Image Upload and Save Data
    //--------------------------------------------
    // Variables
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
        $scope.FileDescription_TR = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });


    // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
    // ------------------------------------------------------------------------------------
    //File Validation
    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (800 * 800)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Only JPEG/PNG/Gif Image can be upload )";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {

        var files = file[0];
        $scope.Imagename = files.name;
        alert($scope.Imagename);
        $scope.SelectedFileForUpload = file[0];
       
    }
    //----------------------------------------------------------------------------------------
  
    //Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
     
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload).then(function (d) {             

                var ItmDetails = {
                    Item_ID:$scope.Item_ID,
                    Item_Name: $scope.Item_Name,
                    Description: $scope.Description,
                    Item_Price: $scope.Item_Price,
                    Image_Name: $scope.Imagename,
                    AddedBy: $scope.txtAddedBy
                };
             
                var promisePost = AngularJs_WCFService.post(ItmDetails);
                promisePost.then(function (pl) {
                    alert(p1.data.Item_Name);
                    GetItemDetails();
                }, function (err) {
                   // alert("Data Insert Error " + err.Message);
                });
                alert(d.Message + " Item Saved!");
                $scope.IsFormSubmitted = false;
                ClearForm();
               
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }

    };
    //Clear form 
    function ClearForm() {
        $scope.Imagename = "";
        $scope.Item_ID = "0";
        $scope.Item_Name = "";
        $scope.Description = "";
        $scope.Item_Price = "0";
        $scope.txtAddedBy = "";

        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;
    }

})
.factory('FileUploadService', function ($http, $q) {

    var fac = {};
    fac.UploadFile = function (file) {
        var formData = new FormData();
        formData.append("file", file);
     
        var defer = $q.defer();
        $http.post("/shanuShopping/UploadFile", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });

        return defer.promise;

    }
    return fac;

    //---------------------------------------------
    //End of Image Upload and Insert record

   

});