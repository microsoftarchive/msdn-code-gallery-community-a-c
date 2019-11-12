import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

import { Order } from '../model/order.model';
import { OrderRepository } from '../model/order.repository';

@Component({
    templateUrl: 'checkout.component.html',
    styleUrls: ['checkout.component.css']
})
export class CheckoutComponent {
    constructor(public order: Order, public repository: OrderRepository) { }

    orderSent: boolean = false;
    submitted: boolean = false;

    submitOrder(form: NgForm) {
        this.submitted = true;
        if (form.valid) {
            this.order.totalValue = this.order.cart.cartPrice;
            this.order.orderItems.forEach(oi => {
                oi.subTotal = oi.price * oi.quantity;
            });
            this.repository.saveOrder(this.order).subscribe(order => {
                this.order.clear();
                this.orderSent = true;
                this.submitted = false;
            });
        }
    }
}