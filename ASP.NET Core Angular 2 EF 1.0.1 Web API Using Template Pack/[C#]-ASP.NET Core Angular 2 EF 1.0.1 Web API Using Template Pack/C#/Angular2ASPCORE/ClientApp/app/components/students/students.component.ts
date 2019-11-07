import { Component } from '@angular/core';
import { Http } from "@angular/http";



@Component({
    selector: 'students',
    template: require('./students.component.html')
})

export class studentsComponent {
    public student: StudentMasters[] = [];

    myName: string;
    constructor(http: Http) {
        this.myName = "Shanu";
        http.get('/api/StudentMastersAPI/Student').subscribe(result => {
            this.student = result.json();
        });
    }

}

export interface StudentMasters {
    stdID: number;
    stdName: string;
    email: string;
    phone: string;
    address: string;
}
