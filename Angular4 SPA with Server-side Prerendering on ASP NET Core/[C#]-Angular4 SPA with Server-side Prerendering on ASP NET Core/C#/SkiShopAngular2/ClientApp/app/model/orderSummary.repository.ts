import { Injectable } from '@angular/core';

import { OrderSummary } from './orderSummary.model';
import { RestDataSource } from './rest.datasource';

@Injectable()
export class OrderSummaryRepository {
    constructor(private dataSource: RestDataSource) {
        this.dataSource.getOrders().subscribe(data => {
            this.orders = data;
        });
    }

    orders: OrderSummary[] = [];

    getOrders(): OrderSummary[] {
        return this.orders;
    }
}