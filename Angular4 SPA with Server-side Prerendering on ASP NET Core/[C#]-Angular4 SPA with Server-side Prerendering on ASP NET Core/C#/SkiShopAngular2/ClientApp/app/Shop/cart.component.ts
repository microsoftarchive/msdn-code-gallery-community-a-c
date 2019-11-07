import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Cart } from '../model/cart.model';
import { RestDataSource } from '../model/rest.datasource';

@Component({
    templateUrl: 'cart.component.html'
})
export class CartComponent {
    constructor(public cart: Cart, private router: Router,
        private dataSource: RestDataSource) { }

    names: string[];

    checkout() {
        let skus = [];
        this.cart.lines.forEach(l => {
            skus.push(l.skuNo);
        });
        this.dataSource.checkQuantities(skus).subscribe(data => {
            let items = data;
            this.names = [];
            items.forEach(i => {
                if (i.quantity < this.cart.lines.find(l => l.skuNo === i.skuNo).quantity) {
                    let skis = this.cart.lines.find(l => l.skuNo === i.skuNo);
                    this.names.push(`${skis.skis} ${skis.size}`);
                }
            });
            if (this.names.length > 0) {
                return;
            } else {
                this.router.navigateByUrl('/checkout');
            }
        });
    }


}