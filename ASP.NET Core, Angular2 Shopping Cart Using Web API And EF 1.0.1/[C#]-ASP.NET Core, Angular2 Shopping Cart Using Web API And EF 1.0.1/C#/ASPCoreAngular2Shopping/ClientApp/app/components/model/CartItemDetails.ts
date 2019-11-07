export class CartItemDetails {
    constructor(
        public CItem_ID: number,
        public CItem_Name: string,
        public CImage_Name: string,
        public CDescription: string,
        public CAddedBy: string,
        public CItem_Price: number,
        public CQty: number,
        public CTotalPrice: number
    ) { }
}  