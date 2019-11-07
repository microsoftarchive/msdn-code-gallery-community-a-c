import { Component } from '@angular/core';
import { Http } from "@angular/http";



@Component({
    selector: 'students',
    template: require('./students.component.html')
})

export class studentsComponent {
    public student: StudentMasters[] = [];
    public studentdetails: StudentDetails[] = [];
    myName: string;
    activeRow: string = "0";
    constructor(public http: Http) {
        this.myName = "Shanu";
        this.getStudentMasterData();
    }

    getStudentMasterData() {

        this.http.get('/api/StudentMastersAPI/Student').subscribe(result => {
            this.student = result.json();
        });
    }

    getStudentsDetails(StudID) {
        this.http.get('/api/StudentMastersAPI/Details/' + StudID).subscribe(result => {
            this.studentdetails = result.json();
        });
        this.activeRow = StudID; 
    }
}

//// For Student Master
export interface StudentMasters {
    stdID: number;
    stdName: string;
    email: string;
    phone: string;
    address: string;
}
// For Student Details
export interface StudentDetails {
    StdDtlID: number;
    stdID: number;
    Major: string;
    Year: string;
    Term: string;
    Grade: string;
}