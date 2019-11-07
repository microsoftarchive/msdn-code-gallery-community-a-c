/// <reference path="../angular.js" /> 
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   
/// <reference path="../angular-file-upload.js" />   
/// <reference path="../angular-file-upload.min.js" />   
var app;
var shoppingCartList = [{ Item_IDs: '', Item_Names: '', Item_Prices: '', Image_Names: '', Descriptions: '', ItemCount: 0 }];

(function () {
    app = angular.module("RESTClientModule", []);
})();