import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { Observer } from 'rxjs/Observer';
import { SessionStorage} from 'ngx-webstorage';

import { StyleMultiCategory } from '../model/styleMultiCategory.model';
import { RestDataSource } from '../model/rest.datasource';
import { SelectedCategory, SELECTED_CATEGORY } from './selectedCategory.model';

@Component({
    selector: 'styleByCategory',
    templateUrl: 'stylesByCategory.component.html'
})
export class StylesByCategoryComponent {
    constructor(private dataSource: RestDataSource, private router: Router,
        @Inject(SELECTED_CATEGORY) private observer: Observer<SelectedCategory>,
        private activeRoute: ActivatedRoute ) { }

    @SessionStorage()
    public stylesByCategory: CategoryStyles[];

    newItem: CategoryStyles = { category: null, styles: [] };
    selectedCategory: string = null;
    styles: StyleMultiCategory[] = [];
    stylesOrigin: StyleMultiCategory[] = [];
    stylesFiltered: StyleMultiCategory[] = [];
    sort: string;
    genders: string[];
    idealFors: string[];
    activeGenders: boolean[] = [];
    activeIdealFors: boolean[] = [];
    rightAfterRouteChange: boolean;

    public itemsPerPage: number = 6;
    public selectedPage: number = 1; 

    getStylesByCategory(category: string) {
        if (this.stylesByCategory != null &&
            typeof this.stylesByCategory.find(s=>s.category === category) != 'undefined') {
            this.stylesOrigin = this.stylesByCategory.find(s => s.category === category).styles;
            this.styles = this.stylesOrigin.slice();
            this.stylesFiltered = this.stylesOrigin.slice();

            this.activeGenders = [];
            this.genders = this.activeRoute.snapshot.queryParams['gender'] || [];
            if (this.genders.length > 0) {
                this.allGenders.forEach((g, index) => {
                    this.activeGenders[index] = this.genders.indexOf(g) > -1;
                });
            }

            this.activeIdealFors = [];
            this.idealFors = this.activeRoute.snapshot.queryParams['idealFor'] || [];
            if (this.idealFors.length > 0) {
                this.allIdealFors.forEach((i, index) => {
                    this.activeIdealFors[index] = this.idealFors.indexOf(i) > -1;
                });
            }

            this.rightAfterRouteChange = true;
        } else {
            this.dataSource.getStylesByCategory(category)
                .subscribe(data => {
                    this.newItem.category = category;
                    this.newItem.styles = data;
                    if (this.stylesByCategory == null) {
                        this.stylesByCategory = [];
                    }
                    if (this.stylesByCategory.indexOf(this.newItem) < 0) {
                        this.stylesByCategory.push(this.newItem);
                        this.stylesByCategory = this.stylesByCategory;
                    }
                    
                    this.stylesOrigin = data;
                    this.styles = this.stylesOrigin.slice();
                    this.stylesFiltered = this.stylesOrigin.slice();

                    this.activeGenders = [];
                    this.genders = this.activeRoute.snapshot.queryParams['gender'] || [];
                    if (this.genders.length > 0) {
                        this.allGenders.forEach((g, index) => {
                            this.activeGenders[index] = this.genders.indexOf(g) > -1;
                        });
                    }

                    this.activeIdealFors = [];
                    this.idealFors = this.activeRoute.snapshot.queryParams['idealFor'] || [];
                    if (this.idealFors.length > 0) {
                        this.allIdealFors.forEach((i, index) => {
                            this.activeIdealFors[index] = this.idealFors.indexOf(i) > -1;
                        });
                    }
                    this.rightAfterRouteChange = true;
                });
        }
    }

    ngOnInit() {
        this.activeRoute.params.subscribe(params => {
            this.selectedCategory = params['category'];
            this.observer.next(new SelectedCategory(this.selectedCategory));
            
            this.selectedPage = params['selectedPage'];
            this.sort = params['sort'];

            this.stylesOrigin = [];
            this.getStylesByCategory(this.selectedCategory);
        });

        this.activeRoute.queryParams.subscribe(params => {
            this.genders = params['gender'] || [];
            this.idealFors = params['idealFor'] || [];

            this.activeGenders = [];
            if (this.genders.length > 0) {
                this.allGenders.forEach((g, index) => {
                    this.activeGenders[index] = this.genders.indexOf(g) > -1;
                });
            } 

            this.activeIdealFors = [];
            if (this.idealFors.length > 0) {
                this.allIdealFors.forEach((i, index) => {
                    this.activeIdealFors[index] = this.idealFors.indexOf(i) > -1;
                });
            }

            this.rightAfterRouteChange = true;
        });
    }

    ngOnDestroy() {
        this.observer.next(new SelectedCategory(null));
    }

    get stylesPerPage(): StyleMultiCategory[] {
        if (this.rightAfterRouteChange) {
            this.rightAfterRouteChange = false;
            let styles = this.filterGender(this.styles, this.genders);
            styles = this.filterIdealFor(styles, this.idealFors);
            this.stylesFiltered = styles;
        }
        this.sortStyles(this.stylesFiltered, this.sort);
        let pageIndex = (this.selectedPage - 1) * this.itemsPerPage;
        return this.stylesFiltered.slice(pageIndex, pageIndex + this.itemsPerPage);
    }

    sortStyles(styles: StyleMultiCategory[], sort: string): StyleMultiCategory[] {
        switch(sort) {
            case 'none':
                styles = this.stylesOrigin.slice();
                break;
            case 'from low to high':
                styles.sort((a, b) => {
                    return a.priceCurrent - b.priceCurrent;
                });
                break;
            case 'from high to low':
                styles.sort((a, b) => {
                    return b.priceCurrent - a.priceCurrent;
                });
                break;
        }
        return styles;
    }

    go() {
        this.selectedPage = 1;

        let styles = this.filterGender(this.styles, this.genders);
        styles = this.filterIdealFor(styles, this.idealFors);
        this.stylesFiltered = styles;

        this.changeRouter();
    }

    changeSort(sort: string) {
        this.sort = sort;
        this.selectedPage = 1;
        this.changeRouter();
    }

    get allGenders() {
        let scorer = {
            "Men's": 0, "Women's": 1, "Unisex": 2,
            "Kids' - Children": 3, "Kids' - Children to Youths": 4,
            "Kids' - Youths": 5
        }
        return this.styles.map(s => s.gender)
            .filter((c, index, array) => array.indexOf(c) === index)
            .sort((a, b) => {
                return scorer[a] - scorer[b];
            });
    }

    get allIdealFors() {
        let idealFors = [];
        this.styles.forEach(s => {
            s.idealFors.forEach(i => {
                idealFors.push(i);
            });
        });
        return idealFors.filter((i, index, array) => array.indexOf(i) === index)
            .sort();
    }

    filterGender(styles: StyleMultiCategory[], genderFilter: string[]):
        StyleMultiCategory[] {
        if (genderFilter.length) {
            return styles.filter((s) => genderFilter.indexOf(s.gender) > -1);
        } else {
            return styles;
        }
    }

    filterIdealFor(styles: StyleMultiCategory[], idealFilter: string[]):
        StyleMultiCategory[] {
        if (idealFilter.length) {
            return styles.filter((s) => s.idealFors
                .some(i => idealFilter.indexOf(i) > -1));
        } else {
            return styles;
        }
    }

    pickGender() {
        this.genders = [];
        this.activeGenders.forEach((g, index) => {
            if (g) {
                this.genders.push(this.allGenders[index]);
            }
        });
    }

    pickIdealFor() {
        this.idealFors = [];
        this.activeIdealFors.forEach((i, index) => {
            if (i) {
                this.idealFors.push(this.allIdealFors[index]);
            }
        });
    }

    countGender(gender: string): number {
        return this.filterIdealFor(this.styles, this.idealFors)
            .filter(s => s.gender === gender).length;
    }
 
    countIdealFor(idealFor: string): number {
        return this.filterGender(this.styles, this.genders)
            .filter(s => s.idealFors.indexOf(idealFor) > -1).length;
    }

    changePage(newPage: number) {
        this.selectedPage = newPage;
        this.changeRouter();
    }

    highlight(active: boolean): string {
        return active ? 'bg-primary text-white' : '';
    }

    highlightFilter(item: boolean): string {
        return item ? 'btn btn-primary' : '';
    }

    get pageCount(): number {
        return Math.ceil(this.stylesFiltered.length / this.itemsPerPage);
    }

    private changeRouter() {
        this.router.navigate(['/category', this.selectedCategory,
                this.selectedPage, this.sort
            ],
            { queryParams: { gender: this.genders, idealFor: this.idealFors } });
    }

}

export class CategoryStyles {
    constructor(
        public category: string,
        public styles: StyleMultiCategory[]
    ) { }
    
}