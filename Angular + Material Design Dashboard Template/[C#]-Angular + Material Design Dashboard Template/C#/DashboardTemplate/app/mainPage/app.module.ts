import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from "@angular/flex-layout";
import { HttpModule } from '@angular/http';
import { CommonModule } from "@angular/common";

import { AppComponent } from './app.component';
import { AppService } from './app.service';

import { ConfigComponent } from '../configPage/config.component';
import { StatsComponent } from '../statsPage/stats.component';

import { MatButtonModule, MatCardModule, MatToolbarModule, MatSidenavModule, MatListModule, MatIconModule, MatTabsModule } from '@angular/material';

@NgModule({
    imports: [
        BrowserAnimationsModule,
        FlexLayoutModule,
        HttpModule,
        CommonModule,
        MatButtonModule,
        MatToolbarModule,
        MatIconModule,
        MatCardModule,
        MatTabsModule,
        MatSidenavModule,
        MatListModule
    ],
    providers: [ AppService ],
    declarations: [
        AppComponent,
        ConfigComponent,
        StatsComponent
    ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }
