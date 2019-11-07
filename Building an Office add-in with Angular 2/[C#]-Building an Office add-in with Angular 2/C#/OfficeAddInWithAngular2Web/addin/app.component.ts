import { Component, OnInit, Input } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'addin',
    templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit {
    title: string = 'Angular 2 Excel Add-in';

    constructor() {

    }

    ngOnInit() {
    }
}
