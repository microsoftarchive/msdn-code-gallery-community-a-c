export class StyleDetail {
    constructor(
        public styleNo: string,
        public styleName: string,
        public gender: string,
        public priceCurrent: number,
        public priceRegular: number, 
        public categoryName: string, 
        public brandName: string,
        public imageBig: string,
        public skuNos: string[],
        public sizes: string[],
        public quantities: number[]
    ) { }
}