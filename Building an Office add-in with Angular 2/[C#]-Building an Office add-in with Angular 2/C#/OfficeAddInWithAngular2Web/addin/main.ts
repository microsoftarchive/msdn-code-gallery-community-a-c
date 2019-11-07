/// <reference path="../typings/globals/office-js/index.d.ts" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule }              from './app.module';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

import {enableProdMode} from '@angular/core';

enableProdMode();

//use this to run in browser for dev
//platformBrowserDynamic().bootstrapModule(AppModule);

//bootstrap with Office.js for in Office
  Office.initialize = () => {
      console.log("Office init: bootstrapping Angular2");
      platformBrowserDynamic().bootstrapModule(AppModule);
  }