/// <reference path="../../typings/globals/office-js/index.d.ts" />

import { Injectable } from '@angular/core';

import { IOfficeResult  } from './ioffice-result';

@Injectable()
export class ExcelService {
    private workbook: Office.Document = Office.context.document;
    //private bindingName: string = 'addinBinding';
    private bindingName: string = 'addinBinding';
    private namedItemName: string = "'Sheet1'!A1";
    private binding: Office.MatrixBinding;

    constructor() { }

    bindToWorkBook(): Promise<IOfficeResult> {
        return new Promise((resolve, reject) => {
            this.workbook.bindings.addFromNamedItemAsync(this.namedItemName, Office.BindingType.Matrix, { id: this.bindingName },
                (addBindingResult: Office.AsyncResult) => {
                    if (addBindingResult.status === Office.AsyncResultStatus.Failed) {
                        reject({
                            error: 'Unable to bind to workbook. Error: ' + addBindingResult.error.message
                        });
                    } else {
                        this.binding = addBindingResult.value;
                        resolve({
                            success: 'Created binding ' + this.bindingName + ' on ' + this.namedItemName
                        });
                    }
                });
        });
    }

    setSampleText(text: string): Promise<IOfficeResult> {
        return new Promise((resolve, reject) => {
            if (this.binding) {
                this.binding.setDataAsync([[text]], (result: Office.AsyncResult) => {
                    if (result.status === Office.AsyncResultStatus.Failed) {
                        reject({ error: 'Failed to update value. Error: ' + result.error.message });
                    } else {
                        resolve({
                            success: 'Updated value of ' + this.namedItemName + ' to be ' + text
                        });
                    }
                });
            } else {
                reject({
                    error: 'binding has not been created. bindToWorkBook must be called first'
                });
            }
        });
    }

}