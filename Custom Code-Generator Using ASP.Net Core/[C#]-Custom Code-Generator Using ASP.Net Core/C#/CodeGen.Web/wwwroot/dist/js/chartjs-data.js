/*Chartjs Init*/

$( document ).ready(function() {
    "use strict";
	
	if( $('#chart_1').length > 0 ){
		var ctx1 = document.getElementById("chart_1").getContext("2d");
		var data1 = {
			labels: ["January", "February", "March", "April", "May", "June", "July"],
			datasets: [
			{
				label: "fir",
				backgroundColor: "rgba(220,70,102,0.4)",
				borderColor: "rgba(220,70,102,0.4)",
				pointBorderColor: "rgb(220,70,102)",
				pointHighlightStroke: "rgba(220,70,102,1)",
				data: [0, 59, 80, 58, 20, 55, 40]
			},
			{
				label: "sec",
				backgroundColor: "rgba(70,148,8,0.4)",
				borderColor: "rgba(70,148,8,0.4)",
				pointBorderColor: "rgb(70,148,8)",
				pointBackgroundColor: "rgba(70,148,8,0.4)",
				data: [28, 48, 40, 19, 86, 27, 90],
			}
			
		]
		};
		
		var areaChart = new Chart(ctx1, {
			type:"line",
			data:data1,
			
			options: {
				tooltips: {
					mode:"label"
				},
				elements:{
					point: {
						hitRadius:90
					}
				},
				
				scales: {
					yAxes: [{
						stacked: true,
						gridLines: {
							color: "#878787",
						},
						ticks: {
							fontFamily: "Roboto",
							fontColor:"#878787"
						}
					}],
					xAxes: [{
						stacked: true,
						gridLines: {
							color: "#878787",
						},
						ticks: {
							fontFamily: "Roboto",
							fontColor:"#878787"
						}
					}]
				},
				animation: {
					duration:	3000
				},
				responsive: true,
				legend: {
					display: false,
				},
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				}
				
			}
		});
	}
    
	if( $('#chart_2').length > 0 ){
		var ctx2 = document.getElementById("chart_2").getContext("2d");
		var data2 = {
			labels: ["January", "February", "March", "April", "May", "June", "July"],
			datasets: [
				{
					label: "My First dataset",
					backgroundColor: "rgba(220,70,102,.8)",
					borderColor: "rgba(220,70,102,.8)",
					data: [10, 30, 80, 61, 26, 75, 40]
				},
				{
					label: "My Second dataset",
					backgroundColor: "rgba(70,148,8,.8)",
					borderColor: "rgba(70,148,8,.8)",
					data: [28, 48, 40, 19, 86, 27, 90]
				}
			]
		};
		
		var hBar = new Chart(ctx2, {
			type:"horizontalBar",
			data:data2,
			
			options: {
				tooltips: {
					mode:"label"
				},
				scales: {
					yAxes: [{
						stacked: true,
						gridLines: {
							color: "#878787",
						},
						ticks: {
							fontFamily: "Roboto",
							fontColor:"#878787"
						}
					}],
					xAxes: [{
						stacked: true,
						gridLines: {
							color: "#878787",
						},
						ticks: {
							fontFamily: "Roboto",
							fontColor:"#878787"
						}
					}],
					
				},
				elements:{
					point: {
						hitRadius:40
					}
				},
				animation: {
					duration:	3000
				},
				responsive: true,
				legend: {
					display: false,
				},
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				}
				
			}
		});
	}

	if( $('#chart_3').length > 0 ){
		var ctx3 = document.getElementById("chart_3").getContext("2d");
		var data3 = {
			labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
			datasets: [
				{
					label: "My First dataset",
					backgroundColor: "rgba(70,148,8,0.8)",
					borderColor: "rgba(70,148,8,0.8)",
					pointBackgroundColor: "rgba(70,148,8,1)",
					pointBorderColor: "#fff",
					pointHoverBackgroundColor: "#fff",
					pointHoverBorderColor: "rgba(70,148,8,1)",
					data: [65, 59, 90, 81, 56, 55, 40]
				},
				{
					label: "My Second dataset",
					backgroundColor: "rgba(234,108,65,0.8)",
					borderColor: "rgba(234,108,65,0.8)",
					pointBackgroundColor: "rgba(234,108,65,1)",
					pointBorderColor: "#fff",
					pointHoverBackgroundColor: "#fff",
					pointHoverBorderColor: "rgba(234,108,65,1)",
					data: [28, 48, 40, 19, 96, 27, 100]
				}
			]
		};
		var radarChart = new Chart(ctx3, {
			type: "radar",
			data: data3,
			options: {
					scale: {
						ticks: {
							beginAtZero: true,
							fontFamily: "Roboto",
							
						},
						gridLines: {
							color: "#878787",
						},
						pointLabels:{
							fontFamily: "Roboto",
							fontColor:"#878787"
						},
					},
					
					animation: {
						duration:	3000
					},
					responsive: true,
					legend: {
							labels: {
							fontFamily: "Roboto",
							fontColor:"#878787"
							}
						},
						elements: {
							arc: {
								borderWidth: 0
							}
						},
						tooltip: {
						backgroundColor:'rgba(33,33,33,1)',
						cornerRadius:0,
						footerFontFamily:"'Roboto'"
					}
			}
		});
	}

	if( $('#chart_4').length > 0 ){
		var ctx4 = document.getElementById("chart_4").getContext("2d");
		var data4 = {
			datasets: [{
				data: [
					11,
					16,
					7,
					3,
					14
				],
				backgroundColor: [
					"rgba(234,108,65,.8)",
					"rgba(220,70,102,.8)",
					"rgba(23,126,193,.8)",
					"rgba(70,148,8,.8)",
					"rgba(230,154,42,.8)"
				],
				label: 'My dataset' // for legend
			}],
			labels: [
				"lab 1",
				"lab 2",
				"lab 3",
				"lab 4",
				"lab 5"
			]
		};
		var polarChart = new Chart(ctx4, {
			type: "polarArea",
			data: data4,
			options: {
				elements: {
					arc: {
						borderColor: "#fff",
						borderWidth: 0
					}
				},
				scale: {
					ticks: {
						beginAtZero: true,
						fontFamily: "Roboto",
						
					},
					gridLines: {
						color: "#878787",
					}
				},
				animation: {
					duration:	3000
				},
				responsive: true,
				legend: {
					labels: {
					fontFamily: "Roboto",
					fontColor:"#878787"
					}
				},
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				}
			}
		});
	}

	if( $('#chart_5').length > 0 ){
		var ctx5 = document.getElementById("chart_5").getContext("2d");
		var data5 = {
			datasets: [
				{
					label: 'First Dataset',
					data: [
						{
							x: 80,
							y: 60,
							r: 10
						},
						{
							x: 40,
							y: 40,
							r: 10
						},
						{
							x: 30,
							y: 40,
							r: 20
						},
						{
							x: 20,
							y: 10,
							r: 10
						},
						{
							x: 50,
							y: 30,
							r: 10
						}
					],
					backgroundColor:"rgba(234,108,65,.8)",
					hoverBackgroundColor: "rgba(234,108,65,.8)",
				},
				{
					label: 'Second Dataset',
					data: [
						{
							x: 40,
							y: 30,
							r: 10
						},
						{
							x: 25,
							y: 20,
							r: 10
						},
						{
							x: 35,
							y: 30,
							r: 10
						}
					],
					backgroundColor:"rgba(220,70,102,.8)",
					hoverBackgroundColor: "rgba(220,70,102,.8)",
				}]
		};
		
		var bubbleChart = new Chart(ctx5,{
			type:"bubble",
			data:data5,
			options: {
				elements: {
					points: {
						borderWidth: 1,
						borderColor: 'rgb(33, 33, 33)'
					}
				},
				scales: {
					xAxes: [
					{
						ticks: {
							min: -10,
							max: 100,
							fontFamily: "Roboto",
							fontColor:"#878787"
						},
						gridLines: {
							color: "#878787",
						}
					}],
					yAxes: [
					{
						ticks: {
							fontFamily: "Roboto",
							fontColor:"#878787"
						},
						gridLines: {
							color: "#878787",
						}
					}]
				},
				animation: {
					duration:	3000
				},
				responsive: true,
				legend: {
					labels: {
					fontFamily: "Roboto",
					fontColor:"#878787"
					}
				},
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				}
			}
		});
	}

	if( $('#chart_6').length > 0 ){
		var ctx6 = document.getElementById("chart_6").getContext("2d");
		var data6 = {
			 labels: [
			"lab 1",
			"lab 2",
			"lab 3"
		],
		datasets: [
			{
				data: [300, 50, 100],
				backgroundColor: [
					"rgba(234,101,162,.8)",
					"rgba(220,70,102,.8)",
					"rgba(70,148,8,.8)"
				],
				hoverBackgroundColor: [
					"rgba(234,101,162,.8)",
					"rgba(220,70,102,.8)",
					"rgba(70,148,8,.8)"
				]
			}]
		};
		
		var pieChart  = new Chart(ctx6,{
			type: 'pie',
			data: data6,
			options: {
				animation: {
					duration:	3000
				},
				responsive: true,
				legend: {
					labels: {
					fontFamily: "Roboto",
					fontColor:"#878787"
					}
				},
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				},
				elements: {
					arc: {
						borderWidth: 0
					}
				}
			}
		});
	}

	if( $('#chart_7').length > 0 ){
		var ctx7 = document.getElementById("chart_7").getContext("2d");
		var data7 = {
			 labels: [
			"lab 1",
			"lab 2",
			"lab 3"
		],
		datasets: [
			{
				data: [300, 50, 100],
				backgroundColor: [
					"rgba(220,70,102,.8)",
					"rgba(230,154,42,.8)",
					"rgba(70,148,8,.8)"
				],
				hoverBackgroundColor: [
					"rgba(220,70,102,.8)",
					"rgba(230,154,42,.8)",
					"rgba(70,148,8,.8)"
				]
			}]
		};
		
		var doughnutChart = new Chart(ctx7, {
			type: 'doughnut',
			data: data7,
			options: {
				animation: {
					duration:	3000
				},
				responsive: true,
				legend: {
					labels: {
					fontFamily: "Roboto",
					fontColor:"#878787"
					}
				},
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				},
				elements: {
					arc: {
						borderWidth: 0
					}
				}
			}
		});
	}	
});