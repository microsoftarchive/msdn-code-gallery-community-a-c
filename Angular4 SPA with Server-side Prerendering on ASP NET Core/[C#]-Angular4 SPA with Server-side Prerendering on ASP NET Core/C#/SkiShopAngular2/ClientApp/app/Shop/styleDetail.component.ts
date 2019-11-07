import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observer } from 'rxjs/Observer';
import { Router } from '@angular/router';

import { Cart } from '../model/cart.model';
import { StyleDetail } from '../model/styleDetail.model';
import { RestDataSource } from '../model/rest.datasource';
import { SelectedCategory, SELECTED_CATEGORY } from './selectedCategory.model';

@Component({
    selector: 'style-detail',
    templateUrl: 'styleDetail.component.html'
})
export class StyleDetailComponent {
    constructor(private dataSource: RestDataSource,
        private cart: Cart,
        @Inject(SELECTED_CATEGORY) private observer: Observer<SelectedCategory>,
        private activeRoute: ActivatedRoute, private router: Router) { }

    styleDetail: StyleDetail = null;
    category: string= null;
    styleNo: string = null;
    sizes: string[] = null;
    pickedItem: IPickedItem = { size: 'pick a size', quantity: 1 };
    sizesSoldOut: string[] = [];
    ifTooMuch: boolean = false;
    ifInteger: boolean = false;

    get style(): StyleDetail {
        return this.styleDetail;
    }

    sortSizes(sizes: string[]): string[] {
        if (isNaN(Number(sizes[0][0]))) {
            let scorer = {
                'X-Small': 0, 'Small': 1, 'Medium': 2,
                'Large': 3, 'X-Large': 4
            };
            let finalSizes = sizes.sort((a, b) => {
                return scorer[a] - scorer[b];
            });
            return finalSizes;
        } else {
            let mySizes = [];
            sizes.forEach(s => {
                mySizes.push(Number(s.split('cm').slice(0, 1)));
            });
            mySizes = mySizes.sort();
            let finalSizes = [];
            mySizes.forEach(s => {
                finalSizes.push(String(s) + 'cm');
            });
            return finalSizes;
        }
    }

    ngOnInit() {
        this.category = this.activeRoute.snapshot.params["category"];
        this.observer.next(new SelectedCategory(this.category));
        this.styleNo = this.activeRoute.snapshot.params["styleNo"];
        this.dataSource.getStyleDetail(this.styleNo).subscribe(data => {
            this.styleDetail = data;
            this.sizes = this.styleDetail.sizes.slice();
            this.sizes = this.sortSizes(this.sizes);
            let indexes = [];
            this.styleDetail.quantities.forEach((q, index) => {
                if (q === 0) {
                    this.sizesSoldOut.push(this.styleDetail.sizes[index]) ;
                }
            });
        });
    }

    ngOnDestroy() {
        this.observer.next(new SelectedCategory(null));
    }

    getClasses(size: string, sizes: string[], quantities: number[]): string {
        let index = sizes.findIndex(s => s === size);
        let quantity = quantities[index];
        if (quantity > 0) {
            return this.pickedItem.size === size ? 'btn btn-info' : 'btn btn-primary';
        } else {
            return 'btn disabled';
        }

    }

    addToCart(style: StyleDetail, size: string, quantity: number) {
        if (size === 'pick a size' || size === 'None') {
            this.pickedItem.size = 'None';
            return;
        }

        let indexSoldOut = this.sizesSoldOut.findIndex(s => s === size);
        if (indexSoldOut > -1) {
            this.pickedItem.size = 'None';
            return;
        }

        if (!Number.isInteger(quantity)) {
            this.ifInteger = true;
            return;
        } else {
            this.ifInteger = false;
        }

        let index = style.sizes.findIndex(s => s === size);
        let inStock = style.quantities[index];
        if (quantity > inStock) {
            this.ifTooMuch = true;
            return;
        } else {
            this.ifTooMuch = false;
        }

        let skuNo = style.skuNos[index];
        let brand = style.brandName;
        let name = style.styleName;
        let gender = style.gender;
        let price = style.priceCurrent;

        this.cart.addLine(skuNo, brand, name, gender, price, size, quantity);
        this.router.navigateByUrl('/cart');
    }

}

interface IPickedItem {
    size: string;
    quantity: number;
}

