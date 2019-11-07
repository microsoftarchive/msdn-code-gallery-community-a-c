import { NgModule } from '@angular/core';
import { BrowserModule  } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';

import { demoRouting } from './demo.routing';

import { OverviewComponent } from './overview.component';
import { OfficeInteractionComponent } from './office-interaction.component';

import { OfficeModule } from '../office/office.module';
import { OfficeUiModule } from '../office-ui/office-ui.module';
import { ExcelService } from '../office/excel.service';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    demoRouting,
    OfficeModule,
    OfficeUiModule
  ],
  providers: [
    ExcelService
  ],
  declarations: [
    OverviewComponent, OfficeInteractionComponent
  ],
  exports: [
    OverviewComponent, OfficeInteractionComponent
  ]
})
export class DemoModule { }