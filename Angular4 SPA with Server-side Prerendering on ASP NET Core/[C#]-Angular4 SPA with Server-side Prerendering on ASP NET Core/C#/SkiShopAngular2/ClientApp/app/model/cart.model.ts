import { Injectable } from '@angular/core';
import { LocalStorage } from 'ngx-webstorage';

@Injectable()
export class Cart {
    @LocalStorage()
    public lines: CartLine[];

    countItem(lines: CartLine[]): number {
        let count = 0;
        lines.forEach(l => {
            count += l.quantity;
        });
        return count;
    }

    countPrice(lines: CartLine[]): number {
        let total = 0;
        lines.forEach(l => {
            total += l.price * l.quantity;
        });
        return total;
    }

    public itemCount: number = typeof this.lines != 'undefined' && this.lines != null && this.lines.length > 0
        ? this.countItem(this.lines)
        : 0;
    public cartPrice: number = typeof this.lines != 'undefined' && this.lines != null && this.lines.length > 0
        ? this.countPrice(this.lines)
        : 0;

    addLine(skuNo: string,
        brand: string,
        name: string,
        gender: string,
        price: number,
        size: string,
        quantity: number) {

        let line: CartLine;
        if (typeof this.lines != 'undefined' && this.lines != null && this.lines.length > 0) {
            line = this.lines.find(l => l.skuNo === skuNo);
        } else {
            this.lines = [];
        }
        if (typeof line != 'undefined' && line != null) {
            line.quantity += quantity;
            this.lines = this.lines;
        } else {
            this.lines.push(new CartLine(skuNo,
                `${brand} ${name} - ${gender}`,
                size,
                price,
                quantity));
            this.lines = this.lines;
        }
        this.recalculate();
    }

    updateQuantity(skuNo: string, quantity: number) {
        let line = this.lines.find(l => l.skuNo === skuNo);
        if (typeof line != 'undefined' && line != null) {
            line.quantity = Number(quantity);
            this.lines = this.lines;
        }
        this.recalculate();
    }

    removeLine(skuNo: string) {
        let index = this.lines.findIndex(l => l.skuNo === skuNo);
        this.lines.splice(index, 1);
        this.lines = this.lines;
        this.recalculate();
    }

    clearCart() {
        this.lines = [];
        this.lines = this.lines;
        this.itemCount = 0;
        this.cartPrice = 0;
    }

    private recalculate() {
        this.itemCount = 0;
        this.cartPrice = 0;
        this.lines.forEach(l => {
            l.subTotal = l.price * l.quantity;
            this.itemCount += l.quantity;
            this.cartPrice += l.price * l.quantity;
        });
    }


}

export class CartLine {
    constructor(
        public skuNo: string,
        public skis: string,
        public size: string, 
        public price: number,
        public quantity: number
    ) { }

    public subTotal = this.lineTotal;

    get lineTotal(): number {
        return this.price * this.quantity;
    }
}