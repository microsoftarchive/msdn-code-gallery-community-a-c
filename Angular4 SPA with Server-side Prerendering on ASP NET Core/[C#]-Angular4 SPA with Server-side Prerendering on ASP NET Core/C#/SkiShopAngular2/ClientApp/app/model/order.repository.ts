import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Order } from './order.model';
import { RestDataSource } from './rest.datasource';

@Injectable()
export class OrderRepository {
    private orders: Order[] = [];

    constructor(private dataSource: RestDataSource) { }

    getOrders(): Order[] {
        return this.orders;
    }

    saveOrder(order: Order): Observable<Order> {
        return this.dataSource.saveOrder(order);
    }
}