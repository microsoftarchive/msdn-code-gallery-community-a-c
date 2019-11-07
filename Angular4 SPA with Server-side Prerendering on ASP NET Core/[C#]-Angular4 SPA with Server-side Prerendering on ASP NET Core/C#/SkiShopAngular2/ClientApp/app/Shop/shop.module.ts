import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Subject } from 'rxjs/Subject';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

import { ModelModule } from '../model/model.module';

import { ShopComponent } from './shop.component';
import { ShopHeadComponent } from './shophead.component';
import { StylesByCategoryComponent } from './stylesByCategory.component';
import { CartSummaryComponent } from './cartSummary.component';
import { StyleDetailComponent } from './styleDetail.component';
import { CartComponent } from './cart.component';
import { CheckoutComponent } from './checkout.component';
import { OrdersComponent } from './orders.component';
import { ClearanceAttrDirective } from './clearance.attrdirective';
import { PagenationDirective } from './pagenation.directive';
import { OrderIdPipe } from './orderId.pipe';

import { SelectedCategory, SELECTED_CATEGORY } from './selectedCategory.model';


export function getSubject(): Subject<SelectedCategory> {
    return new Subject<SelectedCategory>();
}

@NgModule({
    imports: [CommonModule, RouterModule, FormsModule, ModelModule,
        ButtonsModule.forRoot()],
    declarations: [ShopComponent, ShopHeadComponent, StylesByCategoryComponent,
        StyleDetailComponent, CartComponent, CheckoutComponent, OrdersComponent,
        CartSummaryComponent, ClearanceAttrDirective, PagenationDirective,
        OrderIdPipe],
    exports: [ShopComponent, ShopHeadComponent, StylesByCategoryComponent,
        StyleDetailComponent, CartComponent, CheckoutComponent, OrdersComponent,
        ClearanceAttrDirective, PagenationDirective, OrderIdPipe],
    providers: [{ provide: SELECTED_CATEGORY, useFactory: getSubject}]
})
export class ShopModule { }