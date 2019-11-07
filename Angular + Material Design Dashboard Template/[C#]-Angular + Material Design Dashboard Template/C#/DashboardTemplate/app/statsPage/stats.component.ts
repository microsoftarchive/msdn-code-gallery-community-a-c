import { Component, ViewChild, HostListener } from '@angular/core';
import { AppService } from '../mainPage/app.service';
import * as c3 from 'c3';
import * as d3 from 'd3';

@Component({
    selector: 'stats-root',
    templateUrl: 'stats.component.html',
    styleUrls: ['stats.component.css'],
    moduleId: module.id
})
export class StatsComponent {

    constructor(private appService: AppService) { }
    birthRateChart: any;
    internetusersChart: any;
    gdpChart: any;
    hdiChart: any;

    @ViewChild('chartContainer') chartContainer: any

    @HostListener('window:resize', ['$event'])
    onResize(event) {
        this.resizeCharts();
    }


    resizeCharts() {

        var elemWidth = this.chartContainer.nativeElement.clientWidth;
        var elemHeight = this.chartContainer.nativeElement.clientHeight;

        if (this.birthRateChart == undefined) {
            return;
        }

        this.birthRateChart.resize({ width: elemWidth - 50 })
        this.internetusersChart.resize({ width: elemWidth - 50 })
        this.gdpChart.resize({ width: elemWidth - 50 })
        this.hdiChart.resize({ width: elemWidth - 50 })


    }


    ngAfterViewInit() {

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

        this.appService.getEmittedValue().subscribe(
        (data) => {

            this.birthRateChart.load({
                columns: data.birth_rate
            });

            this.internetusersChart.load({
                columns: data.internetusers
            });

            this.gdpChart.load({
                columns: data.gdp_capita
            });

            this.hdiChart.load({
                columns: data.hdi
            });

        });

        // renders the charts width, after initialy generating them
        // not the best method, but a simple workaround
        setTimeout(() => {
            this.resizeCharts();
        }, 0);


    }


};