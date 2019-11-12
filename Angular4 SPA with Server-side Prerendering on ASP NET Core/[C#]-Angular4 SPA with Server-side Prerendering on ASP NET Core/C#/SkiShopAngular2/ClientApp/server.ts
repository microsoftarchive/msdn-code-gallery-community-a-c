//import 'es6-shim';
//import 'es6-promise';
import 'zone.js/dist/zone-node';
import 'zone.js';
import 'reflect-metadata';
import './polyfill';

import { enableProdMode } from '@angular/core';
import { createServerRenderer } from 'aspnet-prerendering';

import { AppServerModule } from './app/app-server.module';
import { ngAspnetCoreEngine, IEngineOptions, createTransferScript,} from './temporary-aspnetcore-engine';

enableProdMode();

export default createServerRenderer((params:BootFuncParams) => {
    const setOptions: IEngineOptions = {
        appSelector: '<app></app>',
        ngModule: AppServerModule,
        request: params,
        providers: []
    }

    return ngAspnetCoreEngine(setOptions).then(response => {
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object',
            fromDotnet: params.data.thisCameFromDotNET
        });

        return ({
            html: response.html,
            globals: response.globals
        });
    });
})
