using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Data.SQLite;

using NReco.PivotData;
using NReco.PivotData.Input;
using NReco.PivotData.Input.Value;
using NReco.PivotData.Output;

namespace NReco.PivotData.Examples.PivotTableWebForms.Templates {

	public partial class PivotTableControl : System.Web.UI.UserControl {

		protected DropDownList filterYear;

		PivotData PvtData;

		protected string PivotTableHtml;
		protected string PivotChartJson;

		protected void Page_Load(object sender, EventArgs e) {
			PvtData = GetDataCube();

			if (!IsPostBack) {
				// bind years filter items
				var yearKeys = PvtData.GetDimensionKeys(new[]{"Order Year"})[0];
				filterYear.DataSource = yearKeys.Select( y => new ListItem( y.ToString(), y.ToString()) ).ToArray();
				filterYear.DataBind();
			}

		}

		protected void filterYear_SelectedIndexChanged(object sender, EventArgs e) {
		}

		protected override void OnPreRender(EventArgs e) {
			CreatePivotTable();			
			base.OnPreRender(e);
		}

		void CreatePivotTable() {
			// in this example filter is applied to in-memory data cube
			// for large datasets it may be applied on database level (with SQL WHERE expression)
			var filteredPvtData = new SliceQuery(PvtData).Where("Order Year", Convert.ToInt32(filterYear.SelectedValue) ).Execute();

			// render pivot table HTML
			var pvtTbl = new PivotTable(
				new[] {"Country"},  // rows
				new[] {"Order Year", "Order Month"},  // cols
				filteredPvtData
			);
			// sort by row total
			pvtTbl.SortRowKeys(null, 
				1, // lets order by measure #1 (sum of unit price) 
				System.ComponentModel.ListSortDirection.Descending);

			var strHtmlWr = new StringWriter();
			var pvtHtmlWr = new PivotTableHtmlWriter(strHtmlWr);
			pvtHtmlWr.TableClass = "table table-bordered table-condensed pvtTable";
			pvtHtmlWr.Write(pvtTbl);
			PivotTableHtml = strHtmlWr.ToString();

			// prepare data for pie chart (total sum by country)
			var pvtDataForChart = new SliceQuery(filteredPvtData).Dimension("Country").Measure(1).Execute();
			var chartPvtTbl = new PivotTable(new[]{"Country"},null,pvtDataForChart);
			// sort by row total
			chartPvtTbl.SortRowKeys(null, System.ComponentModel.ListSortDirection.Descending);
			var strJsonWr = new StringWriter();
			var jsonWr = new PivotTableJsonWriter(strJsonWr);
			jsonWr.Write(chartPvtTbl);
			PivotChartJson = strJsonWr.ToString();
		}

		PivotData GetDataCube() {

			// SQLite database file
			var sqliteDbFile = Path.Combine( Server.MapPath("~/") , "../db/northwind.db");
			
			var sqliteConn = new SQLiteConnection("Data Source="+sqliteDbFile);
			var selectCmd = sqliteConn.CreateCommand();
			selectCmd.CommandText = @"
				select o.OrderID, c.CompanyName, c.ContactName, o.OrderDate, p.ProductName, od.UnitPrice, od.Quantity, c.Country
				from [Order Details] od
				LEFT JOIN [Orders] o ON (od.OrderId=o.OrderId)
				LEFT JOIN [Products] p ON (od.ProductId=p.ProductId)
				LEFT JOIN [Customers] c ON (c.CustomerID=o.CustomerID)
			";

			// this example uses data reader as input and aggregates data with .NET
			// it is possible to aggregate data on database level with GROUP BY 
			// (see "ToolkitDbSource" example from PivotData Toolkit Trial package ( https://www.nrecosite.com/pivot_data_library_net.aspx ) 
			var dbCmdSource = new DbCommandSource(selectCmd);

			// lets define derived fields for 'OrderDate' to get separate 'Year' and 'Month'
 			var derivedValSource = new DerivedValueSource(dbCmdSource);
			derivedValSource.Register("Order Year", new DatePartValue("OrderDate").YearHandler );
			derivedValSource.Register("Order Month", new DatePartValue("OrderDate").MonthNumberHandler );

			// configuration of the serialized cube
			var pvtData = new PivotData(new[]{"Country","Order Year","Order Month"},
					// lets define 2 measures: count and sum of UnitPrice
					new CompositeAggregatorFactory( 
						new CountAggregatorFactory(),
						new SumAggregatorFactory("UnitPrice")
					) );
			pvtData.ProcessData(derivedValSource);
			return pvtData;
		}

	}
}