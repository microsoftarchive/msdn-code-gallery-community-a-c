import {
    Component, Input, trigger,
    state,
    style,
    transition,
    animate,
    keyframes } from '@angular/core';
import { Http, Response,  Headers, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';


@Component({
    selector: 'students' 
   ,
     
    animations: [

        trigger('buttonReSize', [
            state('inactive', style({
                transform: 'scale(1)',
                backgroundColor: '#f83500'
            })),
            state('active', style({
                transform: 'scale(1.4)',
                backgroundColor: '#0094ff'
            })),
            transition('inactive => active', animate('100ms ease-in')),
            transition('active => inactive', animate('100ms ease-out'))
        ]),

        trigger('moveBottom', [

            transition('void => *', [
                animate(900, keyframes([
                    style({ opacity: 0, transform: 'translateY(-200px)', offset: 0 }),
                    style({ opacity: 1, transform: 'translateY(25px)', offset: .75 }),
                    style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),
                    
                ]))
            ])

        ]),
        trigger('moveTop', [

            transition('void => *', [
                animate(900, keyframes([
                    style({ opacity: 0, transform: 'translateY(+400px)', offset: 0 }),
                    style({ opacity: 1, transform: 'translateY(25px)', offset: .75 }),
                    style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),

                ]))
            ])

        ]),
       
        trigger('moveRight', [

            transition('void => *', [
                animate(900, keyframes([
                    style({ opacity: 0, transform: 'translateX(-400px)', offset: 0 }),
                    style({ opacity: 1, transform: 'translateX(25px)', offset: .75 }),
                    style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),

                ]))
            ])

        ]),
        trigger('movelLeft', [

            transition('void => *', [
                animate(900, keyframes([
                    style({ opacity: 0, transform: 'translateX(+400px)', offset: 0 }),
                    style({ opacity: 1, transform: 'translateX(25px)', offset: .75 }),
                    style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),

                ]))
            ])

        ]),
        trigger('fadeIn', [
            transition('* => *', [
                animate('1s', keyframes([
                    style({ opacity: 0, transform: 'translateX(0)', offset: 0 }),
                    style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),
                ]))
            ])
        ]),

       
    ],
    template: require('./students.component.html')
})

export class studentsComponent {
      // to get the Student Details
    public student: StudentMasters[] = []; 
    // to hide and Show Insert/Edit 
    AddstudetnsTable: Boolean = false;
    // To stored Student Informations for insert/Update and Delete
    public StdIDs = "0";
    public StdNames  = "";
    public Emails = "";
    public Phones = "";
    public Addresss= "";

    //For display Edit and Delete Images
    public imgEdit = require("./Images/edit.gif");
    public imgDelete = require("./Images/delete.gif");

    myName: string;
    //for animation status 
    animStatus: string = 'inactive';
    constructor(public http: Http) {
        this.myName = "Shanu";
        this.AddstudetnsTable = false;
        this.getData();
    }

    //for Animation to toggle Active and Inactive
    animButton() {
        this.animStatus = (this.animStatus === 'inactive' ? 'active' : 'inactive');
    }

    //to get all the Student data from Web API
    getData()
    {
        this.http.get('/api/StudentMastersAPI/Student').subscribe(result => {
            this.student = result.json();
        });
    }


    // to show form for add new Student Information
    AddStudent() {
        this.animButton();
        this.AddstudetnsTable = true; 
    this.StdIDs = "0";
    this.StdNames = "";
    this.Emails = "";
    this.Phones = "";
    this.Addresss = "";
    }

    // to show form for edit Student Information
    editStudentsDetails(StdID, StdName, Email, Phone, Address) {
        this.animButton();
        this.AddstudetnsTable = true;
        this.StdIDs = StdID;
        this.StdNames = StdName;
        this.Emails = Email;
        this.Phones = Phone;
        this.Addresss = Address;
    }

    // If the studentid is 0 then insert the student infromation using post and if the student id is more than 0 then edit using put mehod
    addStudentsDetails(StdID, StdName, Email, Phone, Address) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        if (StdID == 0)
        {
            this.http.post('api/StudentMastersAPI', JSON.stringify({ StdID: StdID, StdName: StdName, Email: Email, Phone: Phone, Address: Address }), { headers: headers }).subscribe();
            alert("Student Detail Inserted");
        }
        else
        {
            this.http.put('api/StudentMastersAPI/' + StdID, JSON.stringify({ StdID: StdID, StdName: StdName, Email: Email, Phone: Phone, Address: Address }), { headers: headers }).subscribe();
            alert("Student Detail Updated");
        }     
        this.AddstudetnsTable = false; 
        this.getData();         
    }

    //to Delete the selected student detail from database.
    deleteStudentsDetails(StdID) {         
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');       
        this.http.delete('api/StudentMastersAPI/' + StdID, { headers: headers }).subscribe();
            alert("Student Detail Deleted");
            this.getData();        
    }

    closeEdits()
    {
        this.AddstudetnsTable = false;
        this.StdIDs = "0";
        this.StdNames = "";
        this.Emails = "";
        this.Phones = "";
        this.Addresss = "";
    }
}
export interface StudentMasters {
    stdID: number;
    stdName: string;
    email: string;
    phone: string;
    address: string;
} 