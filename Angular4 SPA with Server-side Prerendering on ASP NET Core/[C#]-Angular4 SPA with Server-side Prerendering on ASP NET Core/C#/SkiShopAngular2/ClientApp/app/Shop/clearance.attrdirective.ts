import { Directive, Renderer, ElementRef, Input } from '@angular/core';

@Directive ({
    selector: '[clearance-class]'
})
export class ClearanceAttrDirective {
    nativeElement: Node; 
    constructor(private renderer: Renderer, private element: ElementRef) {
        this.nativeElement = element.nativeElement;
        
    }

    @Input('clearance-class')
    priceCurrent: number;

    @Input('price-regular')
    priceRegular: number;

    getString(price: number): string {
        return price.toLocaleString(
            'en-us', { style: 'currency', currency: 'USD' });
    }

    ngOnInit() {
        if (this.priceCurrent < this.priceRegular) {
            let del = this.renderer.createElement(this.nativeElement, 'del');
            this.renderer.setElementStyle(del, 'color', 'navy');
            this.renderer.setElementStyle(del, 'font-weight', '500');
            this.renderer.createText(del, this.getString(this.priceRegular));
            let span = this.renderer.createElement(this.nativeElement, 'span');
            this.renderer.setElementStyle(span, 'color', 'red');
            this.renderer.setElementStyle(span, 'font-weight', 'bold');
            this.renderer.createText(span, ' ' + this.getString(this.priceCurrent));
        } else {
            this.renderer.setElementStyle(this.nativeElement, 'color', 'navy');
            this.renderer.setElementStyle(this.nativeElement, 'font-weight', '500');
            this.renderer.createText(this.nativeElement,
                this.getString(this.priceCurrent));
        }
    }


}