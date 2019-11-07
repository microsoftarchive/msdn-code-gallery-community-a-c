/*Sparkline Init*/
  
$(document).ready(function() {
   "use strict";
   
   var sparklineLogin = function() { 
		if( $('#sparkline_1').length > 0 ){
			$("#sparkline_1").sparkline([2,4,4,6,8,5,6,4,8,6,6,2 ], {
				type: 'line',
				width: '100%',
				height: '50',
				resize: true,
				lineColor: '#177ec1',
				fillColor: '#177ec1',
				maxSpotColor: '#177ec1',
				highlightLineColor: 'rgba(0, 0, 0, 0.2)',
				highlightSpotColor: '#177ec1'
			});
		}	
        if( $('#sparkline_2').length > 0 ){
			$("#sparkline_2").sparkline([0,2,8,6,8,5,6,4,8,6,6,2 ], {
				type: 'bar',
				width: '100%',
				height: '50',
				barWidth: '5',
				resize: true,
				barSpacing: '5',
				barColor: '#e69a2a',
				highlightSpotColor: '#e69a2a'
			});
		}	
		if( $('#sparkline_3').length > 0 ){
			$("#sparkline_3").sparkline([20,4,4], {
				type: 'pie',
				width: '50',
				height: '50',
				resize: true,
				sliceColors: ['#177ec1', '#dc4666', '#ea6c41']
			});
		}
		if( $('#sparkline_4').length > 0 ){
			$("#sparkline_4").sparkline([5,6,2,8,9,4,7,10,5,4,2], {
			type: 'bar',
			height: '200',
			width: '100%',
			barWidth: 10,
			barSpacing: 5,
			barColor: '#dc4666',
			resize: true,
			});
		}	
		
		if( $('#sparkline_5').length > 0 ){
			$('#sparkline_5').sparkline([5, 6, 2, 9, 4, 7, 5, 8, 5,4], {
				type: 'bar',
				height: '200',
				width: '100%',
				barWidth: '10',
				resize: true,
				barSpacing: '5',
				barColor: '#ea6c41'
			});
			$('#sparkline_5').sparkline([5, 6, 2, 9, 4, 7, 10, 12,4,7,10], {
				type: 'line',
				height: '200',
				width: '100%',
				lineColor: '#ea6c41',
				fillColor: 'transparent',
				composite: true,
				highlightLineColor: 'rgba(0,0,0,.1)',
				highlightSpotColor: 'rgba(0,0,0,.2)'
			});
		}
		
		if( $('#sparkline_6').length > 0 ){
			$("#sparkline_6").sparkline([0, 23, 43, 35, 44, 45, 56, 37, 40, 45, 56, 7, 10], {
				type: 'line',
				width: '100%',
				height: '200',
				lineColor: '#dc4666',
				fillColor: 'transparent',
				spotColor: '#fff',
				minSpotColor: undefined,
				maxSpotColor: undefined,
				resize: true,
				highlightSpotColor: undefined,
				highlightLineColor: undefined
			});
		}
		if( $('#sparkline_7').length > 0 ){
			$('#sparkline_7').sparkline([15, 23, 55, 35, 54, 45, 66, 47, 30], {
				type: 'line',
				width: '100%',
				height: '200',
				chartRangeMax: 50,
				resize: true,
				lineColor: 'rgba(220,70,102, 0.6)',
				fillColor: 'rgba(220,70,102, 0.6)',
				highlightLineColor: 'rgba(0,0,0,0)',
				highlightSpotColor: 'rgba(0,0,0,0)',
			});
			$('#sparkline_7').sparkline([0, 13, 10, 14, 15, 10, 18, 20, 0], {
				type: 'line',
				width: '100%',
				height: '200',
				chartRangeMax: 40,
				lineColor: 'rgba(23,126,193, 0.6)',
				fillColor: 'rgba(23,126,193, 0.6)',
				composite: true,
				resize: true,
				highlightLineColor: 'rgba(0,0,0,0)',
				highlightSpotColor: 'rgba(0,0,0,0)',
			});
			if( $('#sparkline_8').length > 0 ){
				$("#sparkline_8").sparkline([20,10,4], {
					type: 'pie',
					width: '200',
					height: '200',
					resize: true,
					sliceColors: ['#dc4666', '#ea6c41','#177ec1']
				});
			}
		}	
   }
    var sparkResize;
 
        $(window).resize(function(e) {
            clearTimeout(sparkResize);
            sparkResize = setTimeout(sparklineLogin, 200);
        });
        sparklineLogin();

});