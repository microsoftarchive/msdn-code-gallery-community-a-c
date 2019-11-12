import './polyfill';
import 'reflect-metadata';
import 'zone.js/dist/zone';
//import 'angular2-universal-polyfills/browser'; change for angular4
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppClientModule } from './app/app-client.module';
import 'bootstrap';
const rootElemTagName = 'app'; // Update this if you change your root component selector

// Enable either Hot Module Reloading or production mode
if (module['hot']) {
    module['hot'].accept();
    module['hot'].dispose(() => {
        // Before restarting the app, we create a new root element and dispose the old one
        const oldRootElem = document.querySelector(rootElemTagName);
        const newRootElem = document.createElement(rootElemTagName);
        oldRootElem.parentNode.insertBefore(newRootElem, oldRootElem);
        modulePromise.then(appModule=>appModule.destroy());
    });
} else {
    enableProdMode();
}

// Boot the application, either now or when the DOM content is loaded
const modulePromise = platformBrowserDynamic().bootstrapModule(AppClientModule);

