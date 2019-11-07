<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PivotTableControl.ascx.cs" Inherits="NReco.PivotData.Examples.PivotTableWebForms.Templates.PivotTableControl" %>

	<h1>
		Pivot table &amp; chart created with PivotData library
	</h1>

	<hr />
	<div class="form-inline">
		<div class="form-group">
			<label for="orderYearFilter">Order Year:</label>
			<asp:DropDownList runat="server" ID="filterYear" CssClass="form-control" 
				AutoPostBack="true" OnSelectedIndexChanged="filterYear_SelectedIndexChanged"></asp:DropDownList>
		</div>

		<script type="text/javascript">
			$(function () {
				$('#orderYearFilter').change(function () {
					var year = $(this).val();
					location.href = '@Url.Action("Index","Pivot")?filterYear=' + year;
				});
			});
		</script>
	</div>

	<div class="row">
		<div class="col-md-7">
			<h3>Simple Pivot Table</h3>

			<div style="overflow-y:auto;">
				<%=PivotTableHtml %>
			</div>
			<br/>
		</div>
		<div class="col-md-5">

			<div id="pvtChart" style="width: 100%; height:400px;"></div>
		
			<div class="well text-center">
				See also: <a href="http://pivottable.nrecosite.com/">ASP.NET Pivot Table Builder (online demo)</a>
			</div>

			<script type="text/javascript">
				$(function () {
					var pvtTblData = <%=PivotChartJson %>;

					google.charts.load('current', {packages: ['corechart']});
					google.charts.setOnLoadCallback(drawVisualization);
					window.googleChartsLoaded = false;
					function drawVisualization() {
						window.googleChartsLoaded = true;

						// prepare data for pie chart
						var dataArr = [
							[ pvtTblData.Rows[0], pvtTblData.MeasureLabels[0] ]
						];
						for (var i=0; i<pvtTblData.RowKeys.length; i++) {
							// label, value
							dataArr.push([ pvtTblData.RowKeys[i][0], pvtTblData.RowTotals[i] ]);
						}

						var data1 = google.visualization.arrayToDataTable(dataArr);
						var options = {
							title: 'Raised Count by Category'
						};
						var pvtChart = new google.visualization.PieChart(document.getElementById('pvtChart'));
						pvtChart.draw(data1, {});

					};
					if (window.googleChartsLoaded)
						drawVisualization();

				});
			</script>

		</div>
	</div>
