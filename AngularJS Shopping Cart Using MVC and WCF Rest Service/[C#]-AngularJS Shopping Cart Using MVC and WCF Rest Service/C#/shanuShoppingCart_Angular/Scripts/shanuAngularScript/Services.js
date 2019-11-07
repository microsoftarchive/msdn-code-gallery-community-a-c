/// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   
/// <reference path="Modules.js" />   

app.service("AngularJs_WCFService", function ($http) {
    //Get Order Master Records  
    this.GetItemDetails = function () {
        return $http.get("http://localhost:4191/Service1.svc/GetItemDetails/");
    };


    //To Save the Item Details with Image Name to the Database    
  
    this.post = function (ItemDetails) {
        var request = $http({
            method: "post",
            url: "http://localhost:4191/Service1.svc/addItemMaster",
            data: ItemDetails
        });
    
   
      return request;   
   }   

    
});
