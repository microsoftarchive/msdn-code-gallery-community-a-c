"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var animations_1 = require("@angular/platform-browser/animations");
var flex_layout_1 = require("@angular/flex-layout");
var http_1 = require("@angular/http");
var common_1 = require("@angular/common");
var app_component_1 = require("./app.component");
var app_service_1 = require("./app.service");
var config_component_1 = require("../configPage/config.component");
var stats_component_1 = require("../statsPage/stats.component");
var material_1 = require("@angular/material");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            animations_1.BrowserAnimationsModule,
            flex_layout_1.FlexLayoutModule,
            http_1.HttpModule,
            common_1.CommonModule,
            material_1.MatButtonModule,
            material_1.MatToolbarModule,
            material_1.MatIconModule,
            material_1.MatCardModule,
            material_1.MatTabsModule,
            material_1.MatSidenavModule,
            material_1.MatListModule
        ],
        providers: [app_service_1.AppService],
        declarations: [
            app_component_1.AppComponent,
            config_component_1.ConfigComponent,
            stats_component_1.StatsComponent
        ],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map