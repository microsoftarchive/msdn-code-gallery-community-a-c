import { NgModule } from '@angular/core';
import { BrowserModule  } from '@angular/platform-browser';

import { BackButtonComponent } from './back-button.component';
import { CommanBarComponent } from './command-bar.component';

@NgModule({
  imports: [
    BrowserModule
  ],
  providers: [

  ],
  declarations: [
    BackButtonComponent,
    CommanBarComponent
  ],
  exports: [
    BackButtonComponent,
    CommanBarComponent
  ]
})
export class OfficeUiModule { }