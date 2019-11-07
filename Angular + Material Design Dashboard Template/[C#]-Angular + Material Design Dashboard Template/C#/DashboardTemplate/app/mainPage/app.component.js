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
var app_service_1 = require("./app.service");
var material_1 = require("@angular/material");
var AppComponent = (function () {
    function AppComponent(appService) {
        this.appService = appService;
        this.selectedRegion = "afr";
        this.regions = [
            { name: "Africa", id: "afr" },
            { name: "America", id: "ame" },
            { name: "Asia", id: "asi" },
            { name: "Europe", id: "eur" },
            { name: "Oceania", id: "oce" },
        ];
    }
    AppComponent.prototype.onResize = function (event) {
        if (event.target.innerWidth < 600) {
            this.sidenav.mode = "over";
            this.sidenav.close();
        }
        else {
            this.sidenav.mode = "side";
            this.sidenav.open();
        }
    };
    AppComponent.prototype.loadRegionStats = function (id, regionname) {
        var _this = this;
        this.selectedRegion = id;
        this.appService.getINQStatsData("internetusers_percent,birth_rate,gdp_capita,hdi", regionname).subscribe(function (data) {
            _this.prepareData(data);
        });
    };
    AppComponent.prototype.prepareData = function (countries) {
        // This is highly INQStats depended code. You can remove it for your own data processing.
        // There's highly repetitive code here but focus is on the components and styling anyway.
        function byYear(a, b) {
            if (a.year < b.year)
                return -1;
            if (a.year > b.year)
                return 1;
            return 0;
        }
        var birth_rate_sum = [];
        var internetusers_sum = [];
        var gdp_capita_sum = [];
        var hdi_sum = [];
        countries.forEach(function (country) {
            country.birth_rate.forEach(function (birth) {
                var addFlag = true;
                // If the year already exists, addFlag = false, if the year doesnt exist in the list, a new object is pushed to the list
                // The values for all countries in a region are totalized
                birth_rate_sum.forEach(function (element) {
                    if (element.year == birth.year) {
                        if (element.count == undefined) {
                            // 2 because the first element was already added to the list below, new length is therefore 2
                            element.count = 2;
                        }
                        else {
                            element.count += 1;
                        }
                        element.data = parseFloat(element.data) + parseFloat(birth.data);
                        addFlag = false;
                    }
                });
                if (addFlag) {
                    birth_rate_sum.push(birth);
                }
            });
            country.internetusers_percent.forEach(function (internet) {
                var addFlag = true;
                internetusers_sum.forEach(function (element) {
                    if (element.year == internet.year) {
                        if (element.count == undefined) {
                            element.count = 2;
                        }
                        else {
                            element.count += 1;
                        }
                        element.data = parseFloat(element.data) + parseFloat(internet.data);
                        addFlag = false;
                    }
                });
                if (addFlag) {
                    internetusers_sum.push(internet);
                }
            });
            country.gdp_capita.forEach(function (gdp) {
                var addFlag = true;
                gdp_capita_sum.forEach(function (element) {
                    if (element.year == gdp.year) {
                        if (element.count == undefined) {
                            element.count = 2;
                        }
                        else {
                            element.count += 1;
                        }
                        element.data = parseFloat(element.data) + parseFloat(gdp.data);
                        addFlag = false;
                    }
                });
                if (addFlag) {
                    gdp_capita_sum.push(gdp);
                }
            });
            country.hdi.forEach(function (hdi) {
                var addFlag = true;
                hdi_sum.forEach(function (element) {
                    if (element.year == hdi.year) {
                        if (element.count == undefined) {
                            element.count = 2;
                        }
                        else {
                            element.count += 1;
                        }
                        element.data = parseFloat(element.data) + parseFloat(hdi.data);
                        addFlag = false;
                    }
                });
                if (addFlag) {
                    hdi_sum.push(hdi);
                }
            });
            return;
        });
        // Divide the sum for each datapoint by the number of elements per year to get the average
        birth_rate_sum.forEach(function (element) {
            element.year = parseInt(element.year);
            element.average = Math.round(element.data / element.count * 100) / 100;
        });
        birth_rate_sum.sort(byYear);
        internetusers_sum.forEach(function (element) {
            element.year = parseInt(element.year);
            element.average = Math.round(element.data / element.count * 100) / 100;
        });
        internetusers_sum.sort(byYear);
        gdp_capita_sum.forEach(function (element) {
            element.year = parseInt(element.year);
            element.average = Math.round(element.data / element.count * 100) / 100;
        });
        gdp_capita_sum.sort(byYear);
        hdi_sum.forEach(function (element) {
            element.year = parseInt(element.year);
            element.average = Math.round(element.data / element.count * 100) / 100;
        });
        hdi_sum.sort(byYear);
        // --------------------------------------------------------------
        var birthArray = [];
        var birthX = ['x'];
        var birthY = ['Average birth rate'];
        var internetArray = [];
        var internetX = ['x'];
        var internetY = ['Average Internet users in %'];
        var gdpArray = [];
        var gdpX = ['x'];
        var gdpY = ['Average gross domestic product per capita'];
        var hdiArray = [];
        var hdiX = ['x'];
        var hdiY = ['Average human development index'];
        birth_rate_sum.forEach(function (element) {
            birthX.push(element.year);
            birthY.push(element.average);
        });
        birthArray.push(birthX, birthY);
        internetusers_sum.forEach(function (element) {
            internetX.push(element.year);
            internetY.push(element.average);
        });
        internetArray.push(internetX, internetY);
        gdp_capita_sum.forEach(function (element) {
            gdpX.push(element.year);
            gdpY.push(element.average);
        });
        gdpArray.push(gdpX, gdpY);
        hdi_sum.forEach(function (element) {
            hdiX.push(element.year);
            hdiY.push(element.average);
        });
        hdiArray.push(hdiX, hdiY);
        var dataContainer = {
            birth_rate: birthArray,
            internetusers: internetArray,
            gdp_capita: gdpArray,
            hdi: hdiArray
        };
        console.log(dataContainer);
        this.appService.updateView(dataContainer);
    };
    AppComponent.prototype.ngAfterViewInit = function () {
        this.loadRegionStats("afr", "africa");
    };
    return AppComponent;
}());
__decorate([
    core_1.ViewChild('sidenav'),
    __metadata("design:type", material_1.MatSidenav)
], AppComponent.prototype, "sidenav", void 0);
__decorate([
    core_1.HostListener('window:resize', ['$event']),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Object]),
    __metadata("design:returntype", void 0)
], AppComponent.prototype, "onResize", null);
AppComponent = __decorate([
    core_1.Component({
        selector: 'app-root',
        templateUrl: 'app.component.html',
        styleUrls: ['app.component.css'],
        moduleId: module.id
    }),
    __metadata("design:paramtypes", [app_service_1.AppService])
], AppComponent);
exports.AppComponent = AppComponent;
;
//# sourceMappingURL=app.component.js.map