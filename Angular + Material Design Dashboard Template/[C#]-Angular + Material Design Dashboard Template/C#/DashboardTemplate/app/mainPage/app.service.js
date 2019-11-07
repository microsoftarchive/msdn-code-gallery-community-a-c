"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
var AppService = (function () {
    function AppService(http) {
        this.http = http;
        this.fire = new core_1.EventEmitter();
        this.fire2 = new core_1.EventEmitter();
        this.apiKey = "7d39fbc067d21a0f";
    }
    AppService.prototype.getINQStatsData = function (data, region) {
        console.log('http://inqstatsapi.inqubu.com?api_key=' + this.apiKey + '&countries=' + region + '&data=' + data + '&lang=en');
        return this.http.get('http://inqstatsapi.inqubu.com?api_key=' + this.apiKey + '&countries=' + region + '&data=' + data + '&lang=en')
            .map(function (res) {
            var body = res.json();
            return body;
        });
    };
    AppService.prototype.updateView = function (data) {
        this.fire.emit(data);
    };
    AppService.prototype.getUpdatedView = function () {
        return this.fire2;
    };
    AppService.prototype.resizeView = function () {
        this.fire2.emit();
    };
    AppService.prototype.getEmittedValue = function () {
        return this.fire;
    };
    return AppService;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], AppService.prototype, "fire", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], AppService.prototype, "fire2", void 0);
AppService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], AppService);
exports.AppService = AppService;
//# sourceMappingURL=app.service.js.map