/// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   
/// <reference path="Modules.js" />   
/// <reference path="Services.js" />   

app.controller("AngularJs_ShoppingFController", function ($scope, $http, $timeout, $rootScope, $window, AngularJs_WCFService) {
    $scope.date = new Date();
    //  To set and get the Item Details values
    var firstbool = true;
    $scope.Imagename = "";
    $scope.Item_ID = "";
    $scope.Item_Name = "";
    $scope.Description = "";
    $scope.Item_Price = "0";
    $scope.txtAddedBy = "";

    // Item List Arrays.This arrays will be used to Add and Remove Items to the Cart.
    $scope.items = [];
    //to display the Table for Shopping cart Page.
    $scope.showItem = false;
    $scope.showDetails = false;
    $scope.showCartDetails = false;

    //This variable will be used to Increment the item Quantity by every click.
    var ItemCountExist = 0;
    //This variable will be used to calculate and display the Cat Total Price,Total Qty and GrandTotal result in Cart
    $scope.totalPrice = 0;
    $scope.totalQty = 0;
    $scope.GrandtotalPrice = 0;
  
    // This is publich method which will be called initially and load all the item Details.
    GetItemDetails();
    //To Get All Records   
    function GetItemDetails() {

        $scope.showItem = false;
        $scope.showDetails = true;
        $scope.showCartDetails = false;

        var promiseGet = AngularJs_WCFService.GetItemDetails();
        promiseGet.then(function (pl) {
            $scope.getItemDetailsDisp = pl.data
        },
             function (errorPl) {
             });
    }

   
    //This method used to get all the details when user clicks on Image Inside the Grid and display the details to add items to the Cart
    $scope.showImage = function (imageNm, ItemID, ItemName, ItemPrize, ItemDescription) {
      
        $scope.Imagename = imageNm;
        $scope.Item_ID = ItemID;
        $scope.Item_Name = ItemName;
        $scope.Description = ItemDescription;
        $scope.Item_Price = ItemPrize;
        $scope.showItem = true;
        $scope.showDetails = true;
        $scope.showCartDetails = false;

        ItemCountExist = 0;
    }

    //This method will hide the detail table Row and display the Cart Items
   
    $scope.showMyCart = function () {
        if ($scope.items.length > 0)
        {
            alert("You have added " +$scope.items.length + " Items in Your Cart !");
            $scope.showItem = false;
            $scope.showDetails = false;
            $scope.showCartDetails = true; 
        }
        else {
            alert("Ther is no Items In your Cart.Add Items to view your Cart Details !")
        }
    }
    //This method will hide the detail table Row and display the Cart Items
    $scope.showCart = function () {     
        //alert(shoppingCartList.length);
        $scope.showItem = true;
        $scope.showDetails = false;
        $scope.showCartDetails = true;
        addItemstoCart();      
    }
  
   // This method is to calculate the TotalPrice,TotalQty and Grand Total price
    function getItemTotalresult() {
        $scope.totalPrice = 0;
        $scope.totalQty = 0;
        $scope.GrandtotalPrice = 0;

        for (count = 0; count < $scope.items.length; count++) {
         
            $scope.totalPrice += parseInt($scope.items[count].Item_Prices );
            $scope.totalQty += ($scope.items[count].ItemCounts);
           

            $scope.GrandtotalPrice += ($scope.items[count].Item_Prices * $scope.items[count].ItemCounts);
        }
       
      
    }
    
   //This method will add the Items to the cart and if the Item already exist then the Qty will be incremnet by 1.
    function addItemstoCart() {
       
        if ($scope.items.length > 0)
            {
            for (count = 0; count < $scope.items.length; count++) {
              
                if ($scope.items[count].Item_Names == $scope.Item_Name) {

                    ItemCountExist = $scope.items[count].ItemCounts + 1;
                    $scope.items[count].ItemCounts = ItemCountExist;
                } 
            }        }
        if (ItemCountExist <= 0)
        {
            ItemCountExist = 1;
            var ItmDetails = {
                Item_IDs: $scope.Item_ID,
                Item_Names: $scope.Item_Name,
                Descriptions: $scope.Description,
                Item_Prices: $scope.Item_Price,
                Image_Names: $scope.Imagename,
                ItemCounts: ItemCountExist
            };
            $scope.items.push(ItmDetails);
            $scope.item = {};

        }
        getItemTotalresult();

      
    }

    //This method is to remove the Item from the cart.Each Item inside the Cart can be removed.
    $scope.removeFromCart = function (index) {
        $scope.items.splice(index, 1);
    }

    //This Method is to hide the Chopping cart details and Show the Item Details to add more items to the cart.
    $scope.showItemDetails = function () {      
        $scope.showItem = false;
        $scope.showDetails = true;
        $scope.showCartDetails = false;

    }

});