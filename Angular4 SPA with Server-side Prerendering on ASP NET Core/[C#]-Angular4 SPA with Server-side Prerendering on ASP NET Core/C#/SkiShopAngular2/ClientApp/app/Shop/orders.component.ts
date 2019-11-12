import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { OrderSummaryRepository } from '../model/orderSummary.repository';
import { RestDataSource } from '../model/rest.datasource';
import { OrderSummary } from '../model/orderSummary.model';
import { OrderDetail } from '../model/orderDetail.model';

@Component({
    templateUrl: 'orders.component.html'
})
export class OrdersComponent {
    constructor(private repository: OrderSummaryRepository,
        private dataSource: RestDataSource,
        private activeRoute: ActivatedRoute) { }

    selectedOrderId: number = -1;
    totalValue: number = 0;
    orderDetail: OrderDetail[];
    orders: OrderSummary[] = [];

    getOrders() {
        return this.dataSource.getOrders().subscribe(data => {
            this.orders = data;
        });
    }

    ngOnInit() {
        this.activeRoute.params.subscribe(params => {
            this.selectedOrderId = Number(params['orderId']);
            this.totalValue = Number(params['totalValue']);
            this.dataSource.getOrderDetail(this.selectedOrderId).subscribe(data => {
                this.orderDetail = data;
            });
            this.getOrders();
        });
    }
}