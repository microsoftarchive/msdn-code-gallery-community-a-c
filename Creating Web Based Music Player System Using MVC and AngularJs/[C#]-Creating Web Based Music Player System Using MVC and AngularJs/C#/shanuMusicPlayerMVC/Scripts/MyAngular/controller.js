// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   
var app;
(function () {
    app = angular.module("AngularJs_Module", ['ngAnimate']);
})();


app.controller("AngularJs_Controller", function ($scope, $timeout, $rootScope, $window, $http , FileUploadService) {
    $scope.date = new Date();
    $scope.MyName = "shanu";
    // For Album Details
    $scope.AlbumIdentitys = 0;
    $scope.UImage = "";
    $scope.AlbumName = "";

    // For Music Details
    $scope.musicID = 0;
    $scope.SingerName = "";
    $scope.AlbumNameS = "RedAlbum";
    $scope.MusicFileName = "";
    $scope.Description = "";

    //For Visible design

    $scope.showMusicsAdd = false;
    $scope.showAlbum = true;
    $scope.showMusics = false;
    $scope.showEditMusics = false;

    // This method is to get all the kids Learn Details to display for CRUD. 
    selectAlbumDetails($scope.AlbumName);

    function selectAlbumDetails(AlbumName) {
        $http.get('/api/MusicAPI/getAlbums/', { params: { AlbumName: AlbumName } }).success(function (data) {
            $scope.AlbumData = data;
          
            if ($scope.AlbumData.length > 0) {
            }
        })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
   });

        $http.get('/api/MusicAPI/getMusicSelectALL/', { params: { AlbumName: AlbumName } }).success(function (data) {
            $scope.MusicData = data;

            if ($scope.AlbumData.length > 0) {
            }
        })
  .error(function () {
      $scope.error = "An Error has occured while loading posts!";
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


    //clear all the control values after insert and edit.
    function cleardetails() {
        $scope.AlbumIdentitys = "0";
        $scope.UImage = "";
        $scope.AlbumName = "";

        $scope.AlbumName = "";

        $scope.IsFormSubmitted = false;

        // For Music Details
        $scope.musicID = 0;
        $scope.SingerName = "";
        $scope.AlbumNameS = "";
        $scope.MusicFileName = "";
        $scope.Description = "";
        $scope.showEditMusics = false;


        $scope.Message = "";
        $scope.FileInvalidMessage = "";
        $scope.SelectedFileForUpload = null;
        $scope.FileDescription_TR = "";
        $scope.IsFormSubmitted = false;
        $scope.IsFileValid = false;
        $scope.IsFormValid = false;
        isValid = false;
    }


    // --------------------  Album CRUD Management and Image Upload

    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

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
        //    alert($scope.Imagename);
        $scope.SelectedFileForUpload = file[0];

    }

    //Save Album File
    $scope.saveAlbum = function () {
        $scope.IsFormSubmitted = true;

        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);

        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload).then(function (d) {

                $http.get('/api/MusicAPI/insertAlbum/', { params: { AlbumName: $scope.AlbumName, ImageName: $scope.Imagename } }).success(function (data) {
                    $scope.menuInserted = data;
                    alert($scope.menuInserted);
                    cleardetails();
                    selectAlbumDetails('');
                })
         .error(function () {
             $scope.error = "An Error has occured while loading posts!";
         });

            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }

    };


    // ********   Music CRUD Management and MP3 File Upload

        
    //Form Validation
    $scope.$watch("f2.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
    // ------------------------------------------------------------------------------------


    //File Validation
    $scope.ChechMusicFileValid = function (file) {
        var isValid = false;
        if ($scope.selectmp3FileforUpload != null) {
            $scope.FileInvalidMessage = "";
            isValid = true;
        }
        else {
            $scope.FileInvalidMessage = "Music File required!";
        }
        $scope.IsFileValid = isValid;
    };

    //to upload Music File

    //File Select event 
    $scope.selectmp3FileforUpload = function (file) {        
        var files = file[0];       
        $scope.MusicFileName = files.name;
        //    alert($scope.Imagename);
        $scope.selectmp3FileforUpload = file[0];

    }


    //Save Music  File
    $scope.saveMusicDetails = function () {
        
        $scope.IsFormSubmitted = true;

        $scope.Message = "";
         

        $scope.ChechMusicFileValid($scope.selectmp3FileforUpload);
        

        if ($scope.IsFormValid && $scope.IsFileValid) {
          
            FileUploadService.UploadFile($scope.selectmp3FileforUpload).then(function (d) {
               
                //if the Music ID=0 means its new Music insert here i will call the Web api insert method
                if ($scope.musicID == 0) {

                    $http.get('/api/MusicAPI/insertMusic/', { params: { SingerName: $scope.SingerName, AlbumName: $scope.AlbumNameS, MusicFileName: $scope.MusicFileName, Description: $scope.Description } }).success(function (data) {

                        $scope.menuInserted = data;
                        alert($scope.menuInserted);


                        cleardetails();
                        selectAlbumDetails('');
                    })
             .error(function () {
                 $scope.error = "An Error has occured while loading posts!";
             });
                }


                else {  // to update to the Music details
                    $http.get('/api/MusicAPI/updateMusic/', { params: { musicID: $scope.musicID, SingerName: $scope.SingerName, AlbumName: $scope.AlbumNameS, MusicFileName: $scope.MusicFileName, Description: $scope.Description } }).success(function (data) {
                        $scope.menuUpdated = data;
                        alert($scope.menuUpdated);

                        cleardetails();
                        selectAlbumDetails('');
                    })
            .error(function () {
                $scope.error = "An Error has occured while loading posts!";
            });
                }

            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }

    };

    //Edit MusicEdit  Details
    $scope.MusicEdit = function KidsEdit(musicID, SingerName, AlbumName, MusicFileName, Description) {
        cleardetails();
        $scope.showEditMusics = true;
        alert(musicID);
        $scope.musicID = musicID;
        $scope.SingerName = SingerName;
        $scope.AlbumNameS = AlbumName;
        $scope.MusicFileName = MusicFileName;
        $scope.Description = Description;
    }

    //Delete MusicDelete Detail
    $scope.MusicDelete = function KidsDelete(musicIDs) {
        cleardetails();
        $scope.showEditMusics = true;
        $scope.musicID = musicIDs;
        var delConfirm = confirm("Are you sure you want to delete the Kids Lear Detail ?");
        if (delConfirm == true) {

            $http.get('/api/MusicAPI/deleteMusic/', { params: { musicID: $scope.musicID } }).success(function (data) {
                alert("Music Detail Deleted Successfully!!");
                cleardetails();
                selectAlbumDetails('');
            })
      .error(function () {
          $scope.error = "An Error has occured while loading posts!";
      });

        }
    }


   
    //----------------------------------------------------------------------------------------

    

})


.factory('FileUploadService', function ($http, $q) {
  
    var fac = {};
    fac.UploadFile = function (file) {
        var formData = new FormData();
        formData.append("file", file);
      
        var defer = $q.defer();
     
        $http.post("/MusicPlayer/UploadFile", formData,
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