import { NgModule, Inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule, Http } from '@angular/http';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
//import { BrowserModule } from '@angular/platform-browser'; change for server rendering
//import { UniversalModule } from 'angular2-universal'; change for angular4
import { Ng2Webstorage } from 'ngx-webstorage';

import { routing } from './app.routing';
import { EntryComponent } from './entry.component';

import { ShopModule } from './Shop/shop.module';
import { LinkService } from './link.service';
import { TransferHttpModule } from '../modules/transfer-http/transfer-http.module';

@NgModule({
    imports: [CommonModule,
        HttpModule, JsonpModule, FormsModule, ReactiveFormsModule,
        routing, Ng2Webstorage,
        ShopModule,
        TransferHttpModule
       ],
    declarations: [EntryComponent],
    providers: [ LinkService ],
    bootstrap: [ EntryComponent ]
})

export class AppModule { } 


