import { Injectable } from '@angular/core';
import { StyleMulti } from './styleMulti.model';
import { RestDataSource } from './rest.datasource';

@Injectable()
export class  StyleMultiRepository {
    private styles: StyleMulti[] = [];
    private stylesPopular: StyleMulti[] = [];
    private stylesClearance: StyleMulti[] = [];
    private categories: string[] = [];
    private errorS:string = '';
    private errorC: string = '';

    constructor(private dataSource: RestDataSource) {
        dataSource.getAllStyles().subscribe(data => {
            this.styles = data;
        }, error => {
            this.errorS = error;
            });

        dataSource.getPopularClearance().subscribe(data => {
            let styles = data;
            this.stylesPopular = styles.slice(0, 3);
            this.stylesClearance = styles.slice(3);
        }, error => {
            this.errorS = error;
        });

        dataSource.getCategories().subscribe(data => {
            this.categories = data;
        }, error => {
            this.errorC = error;
        });
    }

    getStyles(category: string = null): StyleMulti[] {
        return this.styles.filter(s => category === null || category === s.categoryName);
    }

    getStylesPopular(): StyleMulti[] {
        return this.stylesPopular;
    }

    getStylesClearance(): StyleMulti[] {
        return this.stylesClearance;
    }

    getStyle(styleNo: string): StyleMulti {
        return this.styles.find(s => s.styleNo === styleNo);
    }

    getCategories(): string[] {
      return this.categories;
    }
}