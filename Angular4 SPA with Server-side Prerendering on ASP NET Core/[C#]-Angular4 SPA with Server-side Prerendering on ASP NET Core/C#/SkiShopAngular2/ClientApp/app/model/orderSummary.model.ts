export class OrderSummary {
    constructor(
        public orderId: number,
        public name: string,
        public city: string, 
        public totalValue: number,
        public data: string
    ) { }
}