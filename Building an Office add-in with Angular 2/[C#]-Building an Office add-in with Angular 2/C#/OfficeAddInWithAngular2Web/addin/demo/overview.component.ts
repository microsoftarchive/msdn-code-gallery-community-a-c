import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    templateUrl: 'overview.component.html',
    styleUrls: ['overview.component.css']
})

export class OverviewComponent {
    title: string = "Overview";
    description: string = 'This is a sample Excel add-in made with Angular 2 and Office UI Fabric. Click the link to see how to interact with the workbook.';

    details: Object[] = [
        {
            route: '/office',
            title: 'OfficeJS integration'
        }
    ];

    constructor() {
    }
}