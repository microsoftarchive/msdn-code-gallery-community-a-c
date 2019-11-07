import { NgModule } from '@angular/core';

import { RestDataSource } from './rest.datasource';
import { StyleMultiRepository } from './styleMulti.repository';
import { Cart } from './cart.model';
import { Order } from './order.model';
import { OrderRepository } from './order.repository';
import { OrderSummaryRepository } from './orderSummary.repository';

@NgModule ({
    providers: [RestDataSource, StyleMultiRepository, Cart, Order,
        OrderRepository, OrderSummaryRepository]  
})
export class ModelModule { }