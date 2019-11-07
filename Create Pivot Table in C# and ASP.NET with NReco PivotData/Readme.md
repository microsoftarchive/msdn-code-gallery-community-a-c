# Create Pivot Table in C# and ASP.NET with NReco PivotData
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ASP.NET
- ASP.NET MVC
- ASP.NET Web Forms
- SQLite
- ASP.NET Core
- ASP.NET Core MVC
## Topics
- Reports
- PivotTable
- Business Intelligence
- Reporting
- aggregating data
- PivotChart
- pivot
- Grouping Controls
## Updated
- 02/23/2017
## Description

<p><span style="font-size:small">Pivot tables (crosstabs) are good for visualization of aggregated data; unlike usual data grids that just display tabular datasets,
<a href="https://www.nrecosite.com/pivotdata/cube-basics.aspx" target="_blank">pivot table columns and rows are calculated dynamically</a> by grouping of input data and table values are results of aggregation function: sum, average, count etc.</span></p>
<p><span style="font-size:small">Usually users have to export a dataset from their business applications and build pivot tables by themselves with Excel, or use expensive heavy-weight reporting solutions based on OLAP servers. This example provides an alternative
 to get highly customizable built-in business intelligence and reporting functionality embedded directly into ASP.NET application.<br>
</span></p>
<h1>Pivot Table Sample</h1>
<p><span style="font-size:small">This example uses well-known '<a href="https://northwinddatabase.codeplex.com/" target="_blank">northwind</a>' database (<span style="font-size:small">SQLite</span>) as data source for the pivot table.
<a href="https://www.nrecosite.com/pivot_data_library_net.aspx" target="_blank">NReco PivotData SDK</a> (NReco.PivotData.dll, NReco.PivotData.Extensions.dll) is used for calculation of in-memory data cube by 'Order Details' table, rendering pivot table to HTML
 and preparation of JSON pivot data for Google Charts. Also simple drop-down based filter is added to illustrate how report output may be customized by end-user:</span></p>
<p><span style="font-size:small"><img id="168168" src="168168-2017-01-16_1505.png" alt="" width="100%"></span></p>
<p><span style="font-size:small">Online demo: <a href="http://pivottable.nrecosite.com/ToolkitPivot/Index" target="_blank">
http://pivottable.nrecosite.com/ToolkitPivot/Index</a></span></p>
<h2>Calculate data cube</h2>
<p><span style="font-size:small">The following code illustrates how to build <a href="https://www.nrecosite.com/pivotdata/cube-basics.aspx" target="_blank">
in-memory data cube</a> by ADO.NET data reader: &nbsp; </span><em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> // lets assume this is initalized command with select query
SQLiteCommand selectCmd; 

var dbCmdSource = new DbCommandSource(selectCmd);
// lets define derived fields for 'OrderDate' to get separate 'Year' and 'Month'
var derivedValSource = new DerivedValueSource(dbCmdSource);
derivedValSource.Register(&quot;Order Year&quot;, new DatePartValue(&quot;OrderDate&quot;).YearHandler );
derivedValSource.Register(&quot;Order Month&quot;, new DatePartValue(&quot;OrderDate&quot;).MonthNumberHandler );

var pvtData = new PivotData(new[]{&quot;Country&quot;,&quot;Order Year&quot;,&quot;Order Month&quot;},
		// lets define 2 measures: count and sum of UnitPrice
		new CompositeAggregatorFactory( 
			new CountAggregatorFactory(),
			new SumAggregatorFactory(&quot;UnitPrice&quot;)
		) );
pvtData.ProcessData(derivedValSource);</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//&nbsp;lets&nbsp;assume&nbsp;this&nbsp;is&nbsp;initalized&nbsp;command&nbsp;with&nbsp;select&nbsp;query</span>&nbsp;
SQLiteCommand&nbsp;selectCmd;&nbsp;&nbsp;
&nbsp;
var&nbsp;dbCmdSource&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DbCommandSource(selectCmd);&nbsp;
<span class="cs__com">//&nbsp;lets&nbsp;define&nbsp;derived&nbsp;fields&nbsp;for&nbsp;'OrderDate'&nbsp;to&nbsp;get&nbsp;separate&nbsp;'Year'&nbsp;and&nbsp;'Month'</span>&nbsp;
var&nbsp;derivedValSource&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DerivedValueSource(dbCmdSource);&nbsp;
derivedValSource.Register(<span class="cs__string">&quot;Order&nbsp;Year&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;DatePartValue(<span class="cs__string">&quot;OrderDate&quot;</span>).YearHandler&nbsp;);&nbsp;
derivedValSource.Register(<span class="cs__string">&quot;Order&nbsp;Month&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;DatePartValue(<span class="cs__string">&quot;OrderDate&quot;</span>).MonthNumberHandler&nbsp;);&nbsp;
&nbsp;
var&nbsp;pvtData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PivotData(<span class="cs__keyword">new</span>[]{<span class="cs__string">&quot;Country&quot;</span>,<span class="cs__string">&quot;Order&nbsp;Year&quot;</span>,<span class="cs__string">&quot;Order&nbsp;Month&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;lets&nbsp;define&nbsp;2&nbsp;measures:&nbsp;count&nbsp;and&nbsp;sum&nbsp;of&nbsp;UnitPrice</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;CompositeAggregatorFactory(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;CountAggregatorFactory(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;SumAggregatorFactory(<span class="cs__string">&quot;UnitPrice&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;);&nbsp;
pvtData.ProcessData(derivedValSource);</pre>
</div>
</div>
</div>
<p><span style="font-size:small">DerivedValueSource used to define additional input data columns on-the-fly; in this case 'Order Year' and 'Order Month' are calculated from 'OrderDate' column. As alternative these values maybe calculated in SQL.</span></p>
<h2>Create Pivot Table</h2>
<p><span style="font-size:small">Once we have a data cube it is possible to build pivot table data model with help of PivotTable class:</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var filteredPvtData = new SliceQuery(pvtData).Where(&quot;Order Year&quot;, year).Execute();

// render pivot table HTML
var pvtTbl = new PivotTable(
	new[] {&quot;Country&quot;},  // rows
	new[] {&quot;Order Year&quot;, &quot;Order Month&quot;},  // cols
	filteredPvtData
);
// sort by row total
pvtTbl.SortRowKeys(null, 
	1, // lets order by measure #1 (sum of unit price) 
	System.ComponentModel.ListSortDirection.Descending);</pre>
<div class="preview">
<pre class="csharp">var&nbsp;filteredPvtData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SliceQuery(pvtData).Where(<span class="cs__string">&quot;Order&nbsp;Year&quot;</span>,&nbsp;year).Execute();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;render&nbsp;pivot&nbsp;table&nbsp;HTML</span>&nbsp;
var&nbsp;pvtTbl&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PivotTable(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>[]&nbsp;{<span class="cs__string">&quot;Country&quot;</span>},&nbsp;&nbsp;<span class="cs__com">//&nbsp;rows</span><span class="cs__keyword">new</span>[]&nbsp;{<span class="cs__string">&quot;Order&nbsp;Year&quot;</span>,&nbsp;<span class="cs__string">&quot;Order&nbsp;Month&quot;</span>},&nbsp;&nbsp;<span class="cs__com">//&nbsp;cols</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;filteredPvtData&nbsp;
);&nbsp;
<span class="cs__com">//&nbsp;sort&nbsp;by&nbsp;row&nbsp;total</span>&nbsp;
pvtTbl.SortRowKeys(<span class="cs__keyword">null</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__com">//&nbsp;lets&nbsp;order&nbsp;by&nbsp;measure&nbsp;#1&nbsp;(sum&nbsp;of&nbsp;unit&nbsp;price)&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;System.ComponentModel.ListSortDirection.Descending);</pre>
</div>
</div>
</div>
<p class="endscriptcode"><span style="font-size:small">SliceQuery class is used for OLAP operations like filtering, slicing etc. For more details see documentation on
<a href="https://www.nrecosite.com/pivotdata/query-cube.aspx" target="_blank">querying and filtering the data cube</a>.</span></p>
<p>&nbsp;</p>
<h2 class="endscriptcode">Render Pivot Table to HTML</h2>
<p><span style="font-size:small">The following code snippet renders PivotTable model to HTML table:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var strHtmlWr = new StringWriter();
var pvtHtmlWr = new PivotTableHtmlWriter(strHtmlWr);
pvtHtmlWr.TableClass = &quot;table table-bordered table-condensed pvtTable&quot;;
pvtHtmlWr.Write(pvtTbl);
var htmlContent = strHtmlWr.ToString();</pre>
<div class="preview">
<pre class="csharp">var&nbsp;strHtmlWr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringWriter();&nbsp;
var&nbsp;pvtHtmlWr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PivotTableHtmlWriter(strHtmlWr);&nbsp;
pvtHtmlWr.TableClass&nbsp;=&nbsp;<span class="cs__string">&quot;table&nbsp;table-bordered&nbsp;table-condensed&nbsp;pvtTable&quot;</span>;&nbsp;
pvtHtmlWr.Write(pvtTbl);&nbsp;
var&nbsp;htmlContent&nbsp;=&nbsp;strHtmlWr.ToString();</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">PivotData Toolkit provides a set of writers for exporting pivot table to other formats like CSV, Excel, JSON (PDF export may be obtained from HTML with
<a href="https://www.nrecosite.com/pdf_generator_net.aspx" target="_blank">PdfGenerator</a> component).</span></div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:small"><strong>NReco.PivotData.Examples.PivotTableMvc</strong> (MVC5 example)</span>
<ul>
<li><span style="font-size:small"><strong>PivotController.cs</strong>: GetDataCube method creates in-memory data cube, PivotTable method creates pivot table data model, and exports it to HTML / JSON with PivotData Toolkit writers.</span>
</li><li><span style="font-size:small"><strong>PivotTable.cshtml</strong>: renders pivot table HTML &#43; javascript code that renders pie chart with GoogleCharts.<br>
</span></li></ul>
</li><li><span style="font-size:small"><strong>NReco.PivotData.Examples.PivotTableWebForms</strong> (WebForms example)</span>
<ul>
<li><span style="font-size:small">functionality is identical to MVC version, all code is concentrated in
<strong>PivotTableControl.ascx.cs</strong> .</span> </li></ul>
</li></ul>
<p><span style="font-size:small">Note that PivotData Toolkit has netstandard builds that may be used with MVC Core applications.</span></p>
<h1>More Information</h1>
<ul>
<li><span style="font-size:small"><a href="https://www.nrecosite.com/pivot_data_library_net.aspx">NReco PivotData Toolkit
</a>page (more examples may be downloaded here)<em>&nbsp;</em></span> </li><li><span style="font-size:small"><a href="http://pivottable.nrecosite.com/">Pivot table builder online demo</a></span>
</li><li><span style="font-size:small"><a href="https://www.nrecosite.com/pivotdata/cube-basics.aspx">Getting started and How-tos</a></span>
</li></ul>
