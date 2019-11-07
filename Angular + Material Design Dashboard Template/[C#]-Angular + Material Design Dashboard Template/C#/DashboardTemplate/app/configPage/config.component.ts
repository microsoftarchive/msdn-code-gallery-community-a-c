import { Component } from '@angular/core';

@Component({
    selector: 'config-root',
    templateUrl: 'config.component.html',
    styleUrls: ['config.component.css'],
    moduleId: module.id
})
export class ConfigComponent {
    siteInfo = "Use this page to define settings";
};