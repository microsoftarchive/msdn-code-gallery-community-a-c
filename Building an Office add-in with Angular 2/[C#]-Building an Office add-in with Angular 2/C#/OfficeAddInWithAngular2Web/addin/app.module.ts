import { NgModule }       from '@angular/core';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent }   from './app.component';

import { OfficeUiModule } from './office-ui/office-ui.module';
import { DemoModule } from './demo/demo.module';

@NgModule({
    imports: [
        BrowserModule,
        RouterModule,
        OfficeUiModule,
        DemoModule
        ],
    declarations: [
        AppComponent
        ],
    bootstrap: [
        AppComponent
        ]
})
export class AppModule { }