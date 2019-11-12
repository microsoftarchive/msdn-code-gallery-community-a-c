// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   
var app;
(function () {
    app = angular.module("AngularJsHome_Module", ['ngAnimate']);
})();


app.controller("AngularJsHome_Controller", function ($scope, $timeout, $rootScope, $window, $http) {
    $scope.date = new Date();
    $scope.MyName = "shanu";
    // For Album Details
    $scope.AlbumIdentitys = 0;
    $scope.AlbumImage = "RedAlbum.jpg";
    $scope.AlbumName = "RedAlbu";

    // For Music Details
    $scope.musicID = 0;
    $scope.SingerName = "";
    $scope.AlbumNameS = "RedAlbum";
    $scope.MusicFileName = "";
    $scope.Description = "";

    // Play Songs
    $scope.selectedSongIndex = 0;
    $scope.songsCount = 0;
    $scope.CurrentSong = "Alarm06NOK.wav";
    $scope.selectedSongstoPlay = "/uploads/Alarm06NOK.wav";
    //For Visible design
 
    $scope.showAlbum = true;
    $scope.showMusics = false;
    $scope.showButton = false;
    $scope.showSounds = false;
  
    // This method is to get all the kids Learn Details to display for CRUD. 
    selectAlbumDetails('');

    function selectAlbumDetails(AlbumName) {
        $http.get('/api/MusicAPI/getAlbums/', { params: { AlbumName: AlbumName } }).success(function (data) {
            $scope.AlbumData = data;

            if ($scope.AlbumData.length > 0) {
            }
        })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
   });

      
    }

    // New Album
    $scope.showAlbumDetails = function () {
        $scope.showAlbum = true;
        $scope.showMusics = false;
        $scope.showButton = false;
    }

    var audio = document.getElementById("audioPlay");
    //Show Music   Details
    $scope.showMusicAlbum = function showMusicAlbum(AlbumNames, ImageName) {

        $scope.AlbumName = AlbumNames;
        $scope.AlbumImage = ImageName;
         
        // Get the Music Play list by Albums
        $http.get('/api/MusicAPI/getMusicSelectALL/', { params: { AlbumName: $scope.AlbumName } }).success(function (data) {
            $scope.MusicData = data;
           
            if ($scope.MusicData.length > 0) {
                $scope.showAlbum = false;
                $scope.showMusics = true;
                $scope.showButton = true;
                $scope.songsCount=$scope.MusicData.length;
                $scope.selectedSongIndex = 0;
                $scope.CurrentSong = $scope.MusicData[$scope.selectedSongIndex].MusicFileName;
                $scope.playMusic($scope.selectedSongIndex, $scope.CurrentSong);
            }
            else
            {
                alert("No Songs has been added in this Album")
                $scope.songsCount = 0;
                $scope.selectedSongIndex = 0;
            }
           
        })
.error(function () {
    $scope.error = "An Error has occured while loading posts!";
});
    }


    //Previous Song Play
    $scope.previousSong = function ()
    {
        if($scope.selectedSongIndex>0)
        {
            $scope.selectedSongIndex = $scope.selectedSongIndex - 1;
        }
        else
        {
            $scope.selectedSongIndex = 0;
        }

        $scope.CurrentSong = $scope.MusicData[$scope.selectedSongIndex].MusicFileName;
        $scope.playMusic($scope.selectedSongIndex, $scope.CurrentSong);
    }


    //next Song Play
    $scope.nextSong = function () {
        if ($scope.selectedSongIndex < $scope.songsCount) {
            $scope.selectedSongIndex = $scope.selectedSongIndex + 1;
        }
        else {
            $scope.selectedSongIndex = 0;
        }

        $scope.CurrentSong = $scope.MusicData[$scope.selectedSongIndex].MusicFileName;
        $scope.playMusic($scope.selectedSongIndex, $scope.CurrentSong);
    }



    //Play Songs
    $scope.playMusic = function (indexnumber, musicFileName) {
        $scope.selectedSongIndex = indexnumber;
        $scope.CurrentSong = musicFileName;
    $scope.selectedSongstoPlay = "/uploads/" + musicFileName;     
  
        audio.load();
        audio.play();

        audio.addEventListener('ended', function () {
            if ($scope.selectedSongIndex < $scope.songsCount) {
                $scope.selectedSongIndex = $scope.selectedSongIndex + 1;
            }
            else {
                $scope.selectedSongIndex = 0;
            }

            $scope.CurrentSong = $scope.MusicData[$scope.selectedSongIndex].MusicFileName;
            $scope.selectedSongstoPlay = "/uploads/" + musicFileName;

            audio.load();
            audio.play();
           
        });
    }


    //play Current Songs
    $scope.playCurrent = function () {      
        audio.play();
    }

     


    //Pause Songs
    $scope.pauseMusic = function () {
        audio.pause();
    }

});