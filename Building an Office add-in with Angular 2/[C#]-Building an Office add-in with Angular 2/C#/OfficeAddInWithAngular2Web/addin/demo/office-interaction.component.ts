import { Component, OnInit } from '@angular/core';

import {ExcelService } from '../office/excel.service';
import { IOfficeResult } from '../office/ioffice-result';

@Component({
    moduleId: module.id,
    templateUrl: 'office-interaction.component.html',
    styleUrls: ['office-interaction.component.css']
})
export class OfficeInteractionComponent implements OnInit {
    title: string = "Office interaction";
    description: string = "Type in the text you want to insert into cell A1 ('Sheet1'!A1) below.";
    feedback: string = '';

    isBusy: boolean;
    userInput: string;

    constructor(private excelService: ExcelService) { }

    ngOnInit() {
        this.isBusy = true;
        this.feedback = 'binding to workbook';

        this.excelService
            .bindToWorkBook()
            .then((result: IOfficeResult) => {
                this.onResult(result);
            }, (result: IOfficeResult) => {
                this.onResult(result);
            });
    }

    submit() {
        this.isBusy = true;

        this.excelService
            .setSampleText(this.userInput)
            .then((result: IOfficeResult) => {
                this.onResult(result);
            }, (result: IOfficeResult) => {
                this.onResult(result);
            });
    }

    onResult(result: IOfficeResult): void {
        this.feedback = result.error || result.success;
        this.isBusy = false;
    }
}