import 'zone.js/dist/zone-node';
import './polyfill';
import 'reflect-metadata';
import 'zone.js';
import { enableProdMode } from '@angular/core';
import { createServerRenderer, RenderResult } from 'aspnet-prerendering';
import { INITIAL_CONFIG } from '@angular/platform-server';
import { APP_BASE_HREF } from '@angular/common';

import { ORIGIN_URL } from './constants';
// Grab the (Node) server-specific NgModule
import { AppServerModuleNgFactory } from './ngfactory/app/app-server.module.ngfactory';
// Temporary * the engine will be on npm soon (`@universal/ng-aspnetcore-engine`)
import {
    ngAspnetCoreEngine, IEngineOptions,
    createTransferScript
    } from './temporary-aspnetcore-engine';

enableProdMode();

export default createServerRenderer(params => {

    // Platform-server provider configuration
    const setupOptions: IEngineOptions = {
        appSelector: '<app></app>',
        ngModule: AppServerModuleNgFactory,
        request: params,
        providers: [
            // Optional - Any other Server providers you want to pass (remember you'll have to provide them for the Browser as well)
        ]
    };

    return ngAspnetCoreEngine(setupOptions).then(response => {
        //Apply your transferData to response.globals
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object'
        });

        return ({
            html: response.html,
            globals: response.globals
        });
    });
});

/* -------- THIS FILE IS TEMPORARY and will be gone when @ngtools/webpack can handle dual files (w server) ---------- */
