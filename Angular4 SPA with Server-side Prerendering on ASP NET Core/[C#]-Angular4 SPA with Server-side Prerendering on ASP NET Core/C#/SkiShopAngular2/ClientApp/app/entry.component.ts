import { Component, OnInit, OnDestroy, Inject, ViewEncapsulation,
   RendererFactory2, PLATFORM_ID } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { Router, ActivatedRoute, NavigationEnd, PRIMARY_OUTLET} from '@angular/router';
import { Meta, Title, DOCUMENT, MetaDefinition } from '@angular/platform-browser';
import { isPlatformServer } from '@angular/common';
import 'rxjs/add/operator/mergeMap';

import { LinkService } from './link.service';
import { REQUEST } from '../constants';

@Component ({
    selector: 'app',
    templateUrl: 'entry.component.html', 
    encapsulation: ViewEncapsulation.None
})
export class EntryComponent implements OnInit, OnDestroy {
    private defaultTitle: string = 'Ski Shop';

    private routerSub$: Subscription;

    constructor(private router: Router, private activeRoute: ActivatedRoute,
        private title: Title, private meta: Meta, private linkService: LinkService,
        @Inject(REQUEST) private request) {
      console.log(`What's our REQUEST Object look like?`);
      console.log(`The Request object only really exists on the Server, but on the Browser we can at least see Cookies`);
      console.log(this.request);
    }

    ngOnInit() {
        this.changeOnNavigation();
    }

    ngOnDestroy() {
        this.routerSub$.unsubscribe();
    }

    private changeOnNavigation() {
      this.routerSub$ = this.router.events
        .filter(event => event instanceof NavigationEnd)
        .map(() => this.activeRoute)
        .map(route => {
          while (route.firstChild) route = route.firstChild;
          return route;
        })
        .filter(route => route.outlet === 'primary')
        .mergeMap(route => route.data)
        .subscribe((event) => {
          this.setValues(event);
        });
    }

    private setValues(event) {
        const title = event['title']
            ? `${event['title']} - ${this.defaultTitle}`
            : `${this.defaultTitle}`;
        this.title.setTitle(title);

        const meta = event['meta'] || [];
        for (let i = 0; i < meta.length; i++) {
            this.meta.updateTag(meta[i]);
        }

        const link = event['links'] || [];
        for (let i = 0; i < link.length; i++) {
            this.linkService.addTag(link[i]);
        }
    }
}