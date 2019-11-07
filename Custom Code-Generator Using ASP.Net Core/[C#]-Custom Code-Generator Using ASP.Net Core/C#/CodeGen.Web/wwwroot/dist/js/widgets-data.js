/*Widgets Init*/
 
"use strict"; 

/*****Ready function start*****/
$(document).ready(function(){
	if( $('#support_table').length > 0 ) {
		$('#support_table').DataTable({
		 "bFilter": false,
		 "bLengthChange": false,
		 "bPaginate": false,
		 "bInfo": false,
		});
	}
	if( $('#chart_6').length > 0 ){
		var ctx6 = document.getElementById("chart_6").getContext("2d");
		var data6 = {
			 labels: [
			"organic",
			"Referral",
			"Other"
		],
		datasets: [
			{
				data: [200,50,250],
				backgroundColor: [
					"#177ec1",
					"#469408",
					"#e69a2a",
				],
				hoverBackgroundColor: [
					"#177ec1",
					"#469408",
					"#e69a2a",
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
				maintainAspectRatio:false,
				legend: {
					display:false
				},
				elements: {
					arc: {
							borderWidth: 0
						}
				},
				tooltips: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				}
			}
		});
	}
	if( $('#pie_chart_4').length > 0 ){
		$('#pie_chart_4').easyPieChart({
			barColor : '#469408',
			lineWidth: 20,
			animate: 3000,
			size:	165,
			lineCap: 'square',
			trackColor: 'rgba(33,33,33,0.1)',
			scaleColor: false,
			onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent));
			}
		});
	}
	if( $('#chart_7').length > 0 ){
		var ctx7 = document.getElementById("chart_7").getContext("2d");
		var data7 = {
			 labels: [
			"lab 1",
			"lab 2",
			"lab 3",
			"lab 4",
			"lab 5"
		],
		datasets: [
			{
				data: [30,70,300, 50, 100],
				backgroundColor: [
					"rgba(220,70,102,1)",
					"rgba(23,126,193,1)",
					"rgba(70,148,8,1)",
					"rgba(234,108,65,1)",
					"rgba(230,154,42,1)"
				],
				hoverBackgroundColor: [
					"rgba(220,70,102,1)",
					"rgba(23,126,193,1)",
					"rgba(70,148,8,1)",
					"rgba(234,108,65,1)",
					"rgba(230,154,42,1)"
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
				elements: {
					arc: {
						borderWidth: 0
					}
				},
				responsive: true,
				maintainAspectRatio:false,
				percentageInnerCutout: 50,
				legend: {
					display:false
				},
				tooltips: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Roboto'"
				},
				cutoutPercentage: 70,
				segmentShowStroke: false
			}
		});
	}	
	
	if( $('.instagram-lite').length > 0 ){
		/*instagram*/
		$.fn.spectragram.accessData = {
				accessToken: '3434068161.50cce2b.797965f78a3e4269839dd8e3b4ae65a4',
				clientID: '50cce2bc21ad40a7939d71ed89f63a14'
			};
		$('.instagram-lite').spectragram('getUserFeed', {
			query: 'themenerds', //this gets adrianengine's photo feed
			size: 'max',
			max: 4});
	}	
});
/*****Ready function end*****/


var sparklineLogin = function() { 
	if( $('#sparkline_1').length > 0 ){
		$("#sparkline_1").sparkline([2,4,4,6,8,5,6,4,8,6,6,2 ], {
			type: 'line',
			width: '100%',
			height: '35',
			lineColor: '#177ec1',
			fillColor: 'rgba(23,126,193,.2)',
			maxSpotColor: '#177ec1',
			highlightLineColor: 'rgba(0, 0, 0, 0.2)',
			highlightSpotColor: '#177ec1'
		});
	}	
	if( $('#sparkline_2').length > 0 ){
		$("#sparkline_2").sparkline([0,2,8,6,8], {
			type: 'line',
			width: '100%',
			height: '35',
			lineColor: '#177ec1',
			fillColor: 'rgba(23,126,193,.2)',
			maxSpotColor: '#177ec1',
			highlightLineColor: 'rgba(0, 0, 0, 0.2)',
			highlightSpotColor: '#177ec1'
		});
	}	
	if( $('#sparkline_3').length > 0 ){
		$("#sparkline_3").sparkline([0, 23, 43, 35, 44, 45, 56, 37, 40, 45, 56, 7, 10], {
			type: 'line',
			width: '100%',
			height: '35',
			lineColor: '#177ec1',
			fillColor: 'rgba(23,126,193,.2)',
			maxSpotColor: '#177ec1',
			highlightLineColor: 'rgba(0, 0, 0, 0.2)',
			highlightSpotColor: '#177ec1'
		});
	}
	if( $('#sparkline_4').length > 0 ){
		$("#sparkline_4").sparkline([2,4,4,6,8,5,6,4,8,6,6,2 ], {
			type: 'line',
			width: '100%',
			height: '45',
			lineColor: '#e69a2a',
			fillColor: '#e69a2a',
			maxSpotColor: '#e69a2a',
			highlightLineColor: 'rgba(0, 0, 0, 0.2)',
			highlightSpotColor: '#e69a2a'
		});
	}	
	if( $('#sparkline_5').length > 0 ){
		$("#sparkline_5").sparkline([0,2,8,6,8], {
			type: 'bar',
			width: '100%',
			height: '45',
			barWidth: '10',
			resize: true,
			barSpacing: '10',
			barColor: '#469408',
			highlightSpotColor: '#469408'
		});
	}	
	if( $('#sparkline_6').length > 0 ){
		$("#sparkline_6").sparkline([2,4,4,6,8,5,6,4,8,6,6,2 ], {
			type: 'line',
			width: '100%',
			height: '45',
			lineColor: '#e69a2a',
			fillColor: '#e69a2a',
			maxSpotColor: '#e69a2a',
			highlightLineColor: 'rgba(0, 0, 0, 0.2)',
			highlightSpotColor: '#e69a2a'
		});
	}	
	
}
var sparkResize;
	$(window).resize(function(e) {
		clearTimeout(sparkResize);
		sparkResize = setTimeout(sparklineLogin, 200);
	});
sparklineLogin();

	