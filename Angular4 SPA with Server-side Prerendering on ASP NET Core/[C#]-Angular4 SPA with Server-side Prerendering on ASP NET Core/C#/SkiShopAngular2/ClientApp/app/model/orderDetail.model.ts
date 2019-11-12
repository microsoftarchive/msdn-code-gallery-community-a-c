export class OrderDetail {
    constructor(
        public skis: string,
        public size: string,
        public price: number,
        public quantity: number,
        public subTotal: number
    ) { }
}