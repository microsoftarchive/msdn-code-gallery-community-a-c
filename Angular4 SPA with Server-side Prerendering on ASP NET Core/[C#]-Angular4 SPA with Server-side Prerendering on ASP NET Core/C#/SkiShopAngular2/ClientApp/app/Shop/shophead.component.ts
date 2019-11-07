import { Component, Inject} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';

import { StyleMultiRepository } from '../model/styleMulti.repository';
import { SelectedCategory, SELECTED_CATEGORY } from './selectedCategory.model';
import { Cart } from '../model/cart.model';

@Component({
    selector: 'shophead',
    templateUrl: 'shophead.component.html'
})
export class ShopHeadComponent {
    constructor(private repository: StyleMultiRepository, private cart: Cart,
        @Inject(SELECTED_CATEGORY) private categoryEvents: Observable<SelectedCategory>,
        @Inject(SELECTED_CATEGORY) private observer: Observer<SelectedCategory>) {
        categoryEvents.subscribe((update) => {
            this.selectedCategory = update.category;
        });
    }

    selectedCategory: string = null;

    get categories(): string[] {
        return this.repository.getCategories();
    }

    getClasses(category: string): string {
        return `nav-item ${category === this.selectedCategory ? 'bg-info' : ''}`;
    }

    changeCategory(category?: string) {
        this.observer.next(new SelectedCategory(category));
    }
}

