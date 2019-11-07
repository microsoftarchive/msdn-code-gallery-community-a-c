import { Directive, ViewContainerRef, TemplateRef, Input,
    Attribute, SimpleChanges
} from '@angular/core';

@Directive ({
    selector: '[pagenationOf]'
})
export class PagenationDirective {
    constructor(private container: ViewContainerRef,
        private template: TemplateRef<Object>) { }

    @Input('pagenationOf')
    counter: number;

    ngOnChanges(changes: SimpleChanges) {
        this.container.clear();
        for (let i = 0; i < this.counter; i++) {
            this.container.createEmbeddedView(this.template, new CounterContext(i + 1));
        }
    }
}

class CounterContext {
    constructor(public $implicit: any) { }
}
