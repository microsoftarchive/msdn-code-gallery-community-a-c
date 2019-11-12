import { Component } from '@angular/core';

import { StyleMulti } from '../model/styleMulti.model';
import { StyleMultiRepository } from '../model/styleMulti.repository';

@Component({
    selector: 'shop',
    templateUrl: 'shop.component.html'
})
export class ShopComponent {
    constructor(private repository: StyleMultiRepository) { }

    get stylesPopolar(): StyleMulti[] {
        return this.repository.getStylesPopular();
    }

    get stylesClearance(): StyleMulti[] {
        return this.repository.getStylesClearance();
    }
}