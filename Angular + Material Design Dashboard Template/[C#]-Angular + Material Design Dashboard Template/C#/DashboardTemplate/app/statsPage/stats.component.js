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
var app_service_1 = require("../mainPage/app.service");
var c3 = require("c3");
var d3 = require("d3");
var StatsComponent = (function () {
    function StatsComponent(appService) {
        this.appService = appService;
    }
    StatsComponent.prototype.onResize = function (event) {
        this.resizeCharts();
    };
    StatsComponent.prototype.resizeCharts = function () {
        var elemWidth = this.chartContainer.nativeElement.clientWidth;
        var elemHeight = this.chartContainer.nativeElement.clientHeight;
        if (this.birthRateChart == undefined) {
            return;
        }
        this.birthRateChart.resize({ width: elemWidth - 50 });
        this.internetusersChart.resize({ width: elemWidth - 50 });
        this.gdpChart.resize({ width: elemWidth - 50 });
        this.hdiChart.resize({ width: elemWidth - 50 });
    };
    StatsComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        this.birthRateChart = c3.generate({
            bindto: document.getElementById('chartBirthrate'),
            data: {
                x: 'x',
                columns: []
            },
            axis: {
                x: {
                    type: 'category'
                },
                y: {
                    tick: {
                        format: d3.format('.2f')
                    }
                }
            }
        });
        this.internetusersChart = c3.generate({
            bindto: document.getElementById('chartInternetusers'),
            data: {
                x: 'x',
                columns: []
            },
            axis: {
                x: {
                    type: 'category'
                },
                y: {
                    tick: {
                        format: d3.format('.2f')
                    }
                }
            }
        });
        this.gdpChart = c3.generate({
            bindto: document.getElementById('chartGDP'),
            data: {
                x: 'x',
                columns: []
            },
            axis: {
                x: {
                    type: 'category'
                },
                y: {
                    tick: {
                        format: d3.format('.2f')
                    }
                }
            }
        });
        this.hdiChart = c3.generate({
            bindto: document.getElementById('chartHDI'),
            data: {
                x: 'x',
                columns: []
            },
            axis: {
                x: {
                    type: 'category'
                },
                y: {
                    tick: {
                        format: d3.format('.2f')
                    }
                }
            }
        });
        this.appService.getEmittedValue().subscribe(function (data) {
            _this.birthRateChart.load({
                columns: data.birth_rate
            });
            _this.internetusersChart.load({
                columns: data.internetusers
            });
            _this.gdpChart.load({
                columns: data.gdp_capita
            });
            _this.hdiChart.load({
                columns: data.hdi
            });
        });
        // renders the charts width, after initialy generating them
        // not the best method, but a simple workaround
        setTimeout(function () {
            _this.resizeCharts();
        }, 0);
    };
    return StatsComponent;
}());
__decorate([
    core_1.ViewChild('chartContainer'),
    __metadata("design:type", Object)
], StatsComponent.prototype, "chartContainer", void 0);
__decorate([
    core_1.HostListener('window:resize', ['$event']),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Object]),
    __metadata("design:returntype", void 0)
], StatsComponent.prototype, "onResize", null);
StatsComponent = __decorate([
    core_1.Component({
        selector: 'stats-root',
        templateUrl: 'stats.component.html',
        styleUrls: ['stats.component.css'],
        moduleId: module.id
    }),
    __metadata("design:paramtypes", [app_service_1.AppService])
], StatsComponent);
exports.StatsComponent = StatsComponent;
;
//# sourceMappingURL=stats.component.js.map