import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { APP_BASE_HREF } from '@angular/common';

import { ORIGIN_URL, REQUEST } from '../constants';
import { AppModule } from './app.module';
import { EntryComponent } from './entry.component';
import { BrowserTransferStateModule } from '../modules/transfer-state/browser-transfer-state.module';

export function getOriginUrl() {
  return window.location.origin;
}

export function getRequest() {
  return { cookie: document.cookie };
}

@NgModule({
    imports: [AppModule, BrowserAnimationsModule, BrowserTransferStateModule,
       BrowserModule.withServerTransition({ appId: 'skishop-angular4' })
  ],
    providers: [
      {
        provide: ORIGIN_URL,
        useFactory: (getOriginUrl)
      }, {
        provide: REQUEST,
        useFactory: (getRequest)
      }], 
    bootstrap: [EntryComponent]
})
export class AppClientModule { }
