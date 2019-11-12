(function () {
    'use strict';
    angular
        .module('WidgetsApp')
        .controller('WidgetsController', function ($scope, factory) {
            var res = factory.getData();
            var options;
            if (res != undefined) {
                res.then(function (d) {
                    var data = JSON.parse(d.data);
                    var categories = [];
                    for (var i = 0; i < data.length; i++) {
                        categories.push(data[i].name)
                    }
                    options = new Highcharts.chart('widgetPie', {
                        credits: {
                            enabled: false
                        },
                        chart: {
                            type: 'pie',
                            renderTo: ''
                        },
                        title: {
                            text: 'Product VS Quantity - Pie Chart'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: false,
                                    format: '<b>{point.name}</b>: {point.y:,.0f}'
                                }
                            }
                        },
                        series: [{
                            name:'Quantity',
                            data: data
                        }]
                    });
                    options = new Highcharts.chart('widgetColumn', {
                        credits: {
                            enabled: false
                        },
                        chart: {
                            type: 'column',
                            renderTo: ''
                        },
                        title: {
                            text: 'Product VS Quantity - Column Chart'
                        },
                        series: [{
                            name: 'Quantity',
                            data: data
                        }]
                    });
                    options = new Highcharts.chart('widgetBar', {
                        credits: {
                            enabled: false
                        },
                        chart: {
                            type: 'bar',
                            renderTo: ''
                        },
                        title: {
                            text: 'Product VS Quantity - Bar Chart'
                        },
                        series: [{
                            name: 'Quantity',
                            data: data
                        }]
                    });
                    options = new Highcharts.chart('widgetLine', {
                        credits: {
                            enabled: false
                        },
                        chart: {
                            type: 'line',
                            renderTo: ''
                        },
                        title: {
                            text: 'Product VS Quantity - Line Chart'
                        },
                        series: [{
                            name: 'Quantity',
                            data: data
                        }]
                    });
                    options = new Highcharts.chart('widgetspline', {
                        credits: {
                            enabled: false
                        },
                        chart: {
                            type: 'spline',
                            renderTo: ''
                        },
                        title: {
                            text: 'Product VS Quantity - Spline Chart'
                        },
                        series: [{
                            name: 'Quantity',
                            data: data
                        }]
                    });
                    options = new Highcharts.chart('widgetScatter', {
                        credits: {
                            enabled: false
                        },
                        chart: {
                            type: 'scatter',
                            renderTo: ''
                        },
                        title: {
                            text: 'Product VS Quantity - Scatter Chart'
                        },
                        series: [{
                            name: 'Quantity',
                            data: data
                        }]
                    });
                }, function (error) {
                    console.log('Oops! Something went wrong while fetching the data.');
                });
            }
        });
})();
