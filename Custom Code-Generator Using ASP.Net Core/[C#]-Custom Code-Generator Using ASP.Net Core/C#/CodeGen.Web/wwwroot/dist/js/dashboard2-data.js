/*Dashboard2 Init*/
"use strict"; 

/*****Ready function start*****/
$(document).ready(function(){
	if( $('#pie_chart_4').length > 0 ){
		$('#pie_chart_4').easyPieChart({
			barColor : '#469408',
			lineWidth: 20,
			animate: 3000,
			size:	165,
			lineCap: 'square',
			trackColor: '#878787',
			scaleColor: false,
			onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent));
			}
		});
	}
	
	
	if( $('#ct_chart_5').length > 0 ){
		new Chartist.Bar('#ct_chart_5', {
		  labels: ['First quarter', 'Second quarter', 'Third quarter', 'Fourth quarter'],
		  series: [
			[600, 400, 800, 700],
			[400, 300, 700, 600],
			[800, 300, 100, 630]
		  ]
		}, {
		  axisX: {
			offset: 20
		  },
		  axisY: {
			offset: 20,
		}
		});
	}
	
	if( $('#ct_chart_7').length > 0 ){
		new Chartist.Bar('#ct_chart_7', {
		  labels: ['14-19', '19-24', '24-29', '29-34'],
		  series: [
			[80, 120, 140, 130],
			[40, 60, 70, 70]
		  ]
		}, {
		  stackBars: true,
		  axisY: {
			 offset: 20
		  }
		}).on('draw', function(data) {
		  if(data.type === 'bar') {
			data.element.attr({
			  style: 'stroke-width: 30px'
			});
		  }
		});
	}
	
	if($('#morris_area_chart').length > 0)
		// Area Chart
		Morris.Area({
			element: 'morris_area_chart',
			data: [{
				period: '2010 Q1',
				iphone: 2666,
				ipad: null,
				itouch: 2647
			}, {
				period: '2010 Q2',
				iphone: 2778,
				ipad: 2294,
				itouch: 2441
			}, {
				period: '2010 Q3',	
				iphone: 4912,
				ipad: 1969,
				itouch: 2501
			}, {
				period: '2010 Q4',
				iphone: 3767,
				ipad: 3597,
				itouch: 5689
			}, {
				period: '2011 Q1',
				iphone: 6810,
				ipad: 1914,
				itouch: 2293
			}, {
				period: '2011 Q2',
				iphone: 5670,
				ipad: 4293,
				itouch: 1881
			}, {
				period: '2011 Q3',
				iphone: 4820,
				ipad: 3795,
				itouch: 1588
			}, {
				period: '2011 Q4',
				iphone: 15073,
				ipad: 5967,
				itouch: 5175
			}, {
				period: '2012 Q1',
				iphone: 10687,
				ipad: 4460,
				itouch: 2028
			}, {
				period: '2012 Q2',
				iphone: 8432,
				ipad: 5713,
				itouch: 1791
			}],
			xkey: 'period',
			ykeys: ['iphone', 'ipad', 'itouch'],
			labels: ['iPhone', 'iPad', 'iPod Touch'],
			pointSize: 0,
			pointStrokeColors:['#177ec1', '#dc4666', '#e69a2a'],
			behaveLikeLine: true,
			gridLineColor: '#878787',
			lineWidth: 0,
			smooth: true,
			hideHover: 'auto',
			lineColors: ['#177ec1', '#dc4666', '#e69a2a'],
			resize: true,
			gridTextColor:'#878787',
			gridTextFamily:"Roboto",
		});
	
	if( $('#chart_3').length > 0 ){
		var ctx3 = document.getElementById("chart_3").getContext("2d");
		var data3 = {
			labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
			datasets: [
				{
					label: "My First dataset",
					backgroundColor: "rgba(220,70,102,0.8)",
					borderColor: "rgba(220,70,102,0.8)",
					pointBackgroundColor: "rgba(220,70,102,1)",
					pointBorderColor: "#fff",
					pointHoverBackgroundColor: "#fff",
					pointHoverBorderColor: "rgba(220,70,102,1)",
					data: [65, 59, 90, 81, 56, 55, 40]
				},
				{
					label: "My Second dataset",
					backgroundColor: "rgba(230,154,42,0.8)",
					borderColor: "rgba(230,154,42,0.8)",
					pointBackgroundColor: "rgba(230,154,42,1)",
					pointBorderColor: "#fff",
					pointHoverBackgroundColor: "#fff",
					pointHoverBorderColor: "rgba(230,154,42,1)",
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
					maintainAspectRatio:false,
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

	if( $('#datable_1').length > 0 )
		$('#datable_1').DataTable({
			"aLengthMenu": [[4, 8, 12, -1], [4, 8, 12, "All"]],
			"iDisplayLength": 4
			
		});
});
/*****Ready function end*****/

/*****Load function start*****/
$(window).load(function(){
	window.setTimeout(function(){
		$.toast({
			heading: 'Welcome to Doodle',
			text: 'Use the predefined ones, or specify a custom position object.',
			position: 'top-right',
			loaderBg:'#e69a2a',
			icon: 'success',
			hideAfter: 3500, 
			stack: 6
		});
	}, 3000);
});
/*****Load function* end*****/

/*****Sparkline function start*****/
var sparklineLogin = function() { 
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
}
	var sparkResize;
/*****Sparkline function end*****/

$(window).resize(function(e) {
	clearTimeout(sparkResize);
	sparkResize = setTimeout(sparklineLogin, 200);
});
sparklineLogin();