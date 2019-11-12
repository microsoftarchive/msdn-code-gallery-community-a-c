import { OpaqueToken } from '@angular/core';

export class SelectedCategory {
    constructor(public category: string) { }
}

export const SELECTED_CATEGORY = new OpaqueToken('selected_category');