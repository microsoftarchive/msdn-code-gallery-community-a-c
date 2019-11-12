/*Dashboard2 Init*/
"use strict"; 

/*****Ready function start*****/
$(document).ready(function(){
	if($('#chart_1').length > 0) {
		// Area Chart
		var data=[{
            period: '01',
            iphone: 180,
        }, {
            period: '02',
            iphone: 105,
        },
         {
            period: '03',
            iphone: 250,
        },
		 {
            period: '04',
            iphone: 160,
        },
		 {
            period: '05',
            iphone: 130,
        },
		{
            period: '06',
            iphone: 155,
        },
		{
            period: '07',
            iphone: 150,
        },
		{
            period: '08',
            iphone: 110,
        },
		{
            period: '09',
            iphone: 170,
        },
		{
            period: '10',
            iphone: 150,
        },
		{
            period: '11',
            iphone: 150,
        },
		{
            period: '12',
            iphone: 150,
        },
		{
            period: '13',
            iphone: 150,
        },
		{
            period: '14',
            iphone: 150,
        },
		{
            period: '15',
            iphone: 160,
        },
		{
            period: '16',
            iphone: 180,
        }, {
            period: '17',
            iphone: 105,
        },
         {
            period: '18',
            iphone: 250,
        },
		 {
            period: '19',
            iphone: 160,
        },
		 {
            period: '20',
            iphone: 130,
        },
		{
            period: '21',
            iphone: 155,
        },
		{
            period: '22',
            iphone: 150,
        },
		{
            period: '23',
            iphone: 110,
        },
		{
            period: '24',
            iphone: 170,
        },
		{
            period: '25',
            iphone: 150,
        },
		{
            period: '26',
            iphone: 150,
        },
		{
            period: '27',
            iphone: 150,
        },
		{
            period: '28',
            iphone: 150,
        },
		{
            period: '29',
            iphone: 150,
        },
		{
            period: '30',
            iphone: 160,
        }];
		var areaChart = Morris.Area({
				element: 'chart_1',
				data: data,
				xkey: 'period',
				ykeys: ['iphone'],
				labels: ['iPhone'],
				pointSize: 3,
				lineWidth: 2,
				pointStrokeColors:['#e69a2a'],
				pointFillColors:['#ffffff'],
				behaveLikeLine: true,
				gridLineColor: 'rgba(33,33,33,0.1)',
				smooth: false,
				hideHover: 'auto',
				lineColors: ['#e69a2a'],
				resize: true,
				gridTextColor:'#878787',
				gridTextFamily:"Roboto",
				parseTime: false,
				fillOpacity:0.2
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
	
	if( $('#chart_8').length > 0 ){
		var ctx7 = document.getElementById("chart_8").getContext("2d");
		var data7 = {
			 labels: [
			"lab 1",
			"lab 2",
			"lab 3",
			"lab 4"
		],
		datasets: [
			{
				data: [80,40,20, 50],
				backgroundColor: [
					"rgba(220,70,102,1)",
					"rgba(23,126,193,1)",
					"rgba(234,108,65,1)",
					"rgba(230,154,42,1)"
				],
				hoverBackgroundColor: [
					"rgba(220,70,102,1)",
					"rgba(70,148,8,1)",
					"rgba(234,108,65,1)",
					"rgba(230,154,42,1)"
				]
			}]
		};
		
		var pieChart  = new Chart(ctx7,{
			type: 'pie',
			data: data7,
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
	
	if( $('#datable_1').length > 0 )
		$('#datable_1').DataTable({
			"bFilter": false,
			"bLengthChange": false,
			"bPaginate": false,
			"bInfo": false,
			
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
		if( $('#sparkline_6').length > 0 ){
			$("#sparkline_6").sparkline([0, 23, 43, 35, 44, 45, 56, 37, 40, 45, 56, 7, 10], {
				type: 'line',
				width: '100%',
				height: '50',
				lineColor: 'rgb(234,108,65)',
				fillColor: 'transparent',
				spotColor: '#fff',
				minSpotColor: undefined,
				maxSpotColor: undefined,
				highlightSpotColor: undefined,
				highlightLineColor: undefined
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