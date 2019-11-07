import { Component, OnChanges, Input,
    Output, EventEmitter } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'command-bar',
    templateUrl: 'command-bar.component.html',
    styleUrls:['command-bar.component.css']
})

export class CommanBarComponent {
    @Input() title: string;
}