import { Injectable } from '@angular/core';

import { Cart } from './cart.model';

@Injectable()
export class Order {
    public orderId: number;
    public name: string;
    public street: string;
    public city: string;
    public province: string;
    public postcode: string;
    public email: string;
    public orderItems = this.cart.lines;
    public totalValue: number;

    constructor(public cart: Cart) { }

    clear() {
        this.orderId = null;
        this.name = this.street, this.city = null;
        this.province = this.postcode = this.email = null;
        this.cart.clearCart();
    }
}