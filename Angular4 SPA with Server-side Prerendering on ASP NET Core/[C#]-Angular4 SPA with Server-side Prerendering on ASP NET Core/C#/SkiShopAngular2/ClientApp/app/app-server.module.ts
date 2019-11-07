import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { BrowserModule } from '@angular/platform-browser'
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { AppModule } from './app.module';
import { EntryComponent } from './entry.component';

import { ServerTransferStateModule } from '../modules/transfer-state/server-transfer-state.module';
import { TransferState } from '../modules/transfer-state/transfer-state';

@NgModule({
    imports: [ ServerModule, AppModule, NoopAnimationsModule, ServerTransferStateModule,
        BrowserModule.withServerTransition({
            appId: 'skishop-angular4'
        })],
    bootstrap: [ EntryComponent ]
})
export class AppServerModule {
    constructor(private transferState: TransferState) { }

    ngOnBootstrap = () => {
        console.log('bootstrapped');
        this.transferState.inject();
    }
}