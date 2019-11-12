import { Component, Input, Inject } from '@angular/core';
import { Http,Response, Headers, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';


@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    // to get the Student Details
    public Inventory: InventoryMaster[] = [];
    // to hide and Show Insert/Edit 
    AddTable: Boolean = false;
    // To stored Student Informations for insert/Update and Delete
    public sInventoryID : number = 0;
    public sItemName = "";
    public sStockQty : number  = 0;
    public sReorderQty : number = 0;
    public sPriorityStatus: boolean = false;

    //For display Edit and Delete Images
    public imgchk = require("./Images/chk.png");
    public imgunChk =  require("./Images/unchk.png");
    public bseUrl: string = "";
    
    public schkName: string = "";
    myName: string; 
    constructor(public http: Http, @Inject('BASE_URL')  baseUrl: string) {
        this.myName = "Shanu";
        this.AddTable = false;
        this.bseUrl = baseUrl; 
        this.getData();
    }


    //to get all the Inventory data from Web API
    getData() {

        this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory').subscribe(result => {
            this.Inventory = result.json();
        }, error => console.error(error)); 
         
    }

    // to show form for add new Student Information
    AddInventory() { 
        this.AddTable = true;
        // To stored Student Informations for insert/Update and Delete
        this.sInventoryID = 0;
        this.sItemName = "";
        this.sStockQty = 50;
        this.sReorderQty = 50;
        this.sPriorityStatus = false;
    }

    // to show form for edit Inventory Information
    editInventoryDetails(inventoryIDs : number, itemNames : string, stockQtys : number, reorderQtys : number , priorityStatus : number) { 
        this.AddTable = true;
        this.sInventoryID = inventoryIDs;
        this.sItemName = itemNames;
        this.sStockQty = stockQtys;
        this.sReorderQty = reorderQtys;
        if (priorityStatus == 0)
        {
            this.sPriorityStatus = false;
        }
        else {
            this.sPriorityStatus = true;
        }
       
    }

    // If the InventoryId is 0 then insert the Inventory infromation using post and if the Inventory id is greater than 0 then edit using put mehod
    addInventoryDetails(inventoryIDs: number, itemNames: string, stockQtys: number, reorderQtys: number, priorityStatus: boolean) {
        var pStatus: number = 0;
        
        this.schkName = priorityStatus.toString();
        if (this.schkName == "true") {
            pStatus = 1;
        }
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        if (inventoryIDs == 0) {
            this.http.post(this.bseUrl + 'api/InventoryMasterAPI/', JSON.stringify({ InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus }),
                { headers: headers }).subscribe(
                response => {
                    this.getData();

                }, error => {
                }
                ); 
            
        }
        else {
            this.http.put(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, JSON.stringify({ InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus }), { headers: headers })
                .subscribe(response => {
                    this.getData();

                }, error => {
                }
                ); 
           
        }
        this.AddTable = false;
        //
        //
        //this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory').subscribe(result => {
        //    this.Inventory = result.json();
        //}, error => console.error(error)); 
    }

    //to Delete the selected Inventory detail from database.
    deleteinventoryDetails(inventoryIDs: number) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        this.http.delete(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, { headers: headers }).subscribe(response => {
            this.getData();

        }, error => {
        }
        ); 

        //this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory').subscribe(result => {
        //    this.Inventory = result.json();
        //}, error => console.error(error)); 
    }

    closeEdits() {
        this.AddTable = false;
        // To stored Student Informations for insert/Update and Delete
        this.sInventoryID = 0;
        this.sItemName = "";
        this.sStockQty = 50;
        this.sReorderQty = 50;
        this.sPriorityStatus = false;
    }
}

export interface InventoryMaster {
    inventoryID: number;
    itemName: string;
    stockQty: number;
    reorderQty: number;
    priorityStatus: number;
} 
