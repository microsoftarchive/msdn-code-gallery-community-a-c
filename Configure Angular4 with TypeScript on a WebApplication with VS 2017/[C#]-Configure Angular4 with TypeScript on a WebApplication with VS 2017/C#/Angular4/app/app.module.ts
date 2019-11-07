import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';

import { Root1Component } from './root1/root1.component';
import { Root2Component } from './root2/root2.component';

const appRoutes: Routes = [
    { path: 'root1', component: Root1Component },
    { path: 'root2', component: Root2Component }
];


@NgModule({
    imports:
    [
        BrowserModule,
        RouterModule.forRoot(appRoutes)
    ],
    declarations: [
        AppComponent,
        Root1Component,
        Root2Component
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
