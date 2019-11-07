# Applying Conditional Formatting in Excel file on Runtime using Aspose.Cells
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET
## Topics
- Conditional Formatting
## Updated
- 05/20/2014
## Description

<h1>Introduction</h1>
<div>In this sample application we have implemented some conditional formatting styles to give an idea to the users that how easy it is to implement the conditional formatting using
<a href="http://goo.gl/8RNgpA" target="_blank">Aspose.Cells for .NET</a>.&nbsp;</div>
<h1><span style="font-size:20px; font-weight:bold">&nbsp;</span></h1>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<div><em>&nbsp;</em></div>
<div><em>Microsoft Excel provides an advanced feature know as Conditional formatting that allows the users to apply formats to a cell or a range of cells and formatting changes depending on the value of the cell or&nbsp; formula. For example, you can have a
 cell appear with red background only when the value of the cell is greater than 100. Conditional formatting feature provides a range of options to the users e.g. it lets users to apply cell shading, borders, colored icons, arrows, flags and font formatting
 which help in data presentation in a very sophisticated way.<br>
</em></div>
<div>
<div><em>Aspose.Cells fully supports the conditional formatting feature and users can implement it with simple code at runtime. You can add shaded data bars to graphically enhance the underlying numbers by embedding a simple bar chart in the cells or use icon
 sets to adds small icons, such as arrows and traffic lights to the cells to enhance the presentation of your data in an excel file.</em></div>
</div>
<div><em>&nbsp;</em>&nbsp;</div>
<div><em>This sample application generates an XLSX file with different conditional formatting features. Following is a screenshot of the output you will get after executing the sample application.<br>
</em></div>
<p><img id="114981" src="114981-conditional_formatting.png" alt="" width="820" height="437"></p>
<p>&nbsp;</p>
<p>Following method creates a new file using Workbook object and calls different methods to add different types of conditional formatting to the worksheet.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//Instantiate a workbook object
Workbook book = new Workbook();

//Create a worksheet object and get the first worksheet
Worksheet sheet1 = book.Worksheets[0];

//Set the first worksheet to _sheet object
_sheet = sheet1;

//Call different custom methods
//These methods exhibits different conditional formatting types with their custom
//formattings attributes for MS Excel 2007 .xlsx file format
AddDefaultIconSet();
AddIconSet1();
AddIconSet2();
AddDefaultColorScale();
AddDataBar1();
AddDataBar2();
AddTimePeriod_1();
AddTimePeriod_2();

//AutoFit M Column in the worksheet
_sheet.AutoFitColumn(12);

//Specify the output file path
string output = @&quot;c:\data\Testoutput.xlsx&quot;;

//Save the excel file
book.Save(output, SaveFormat.Xlsx);
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//Instantiate&nbsp;a&nbsp;workbook&nbsp;object</span>&nbsp;
Workbook&nbsp;book&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;
<span class="cs__com">//Create&nbsp;a&nbsp;worksheet&nbsp;object&nbsp;and&nbsp;get&nbsp;the&nbsp;first&nbsp;worksheet</span>&nbsp;
Worksheet&nbsp;sheet1&nbsp;=&nbsp;book.Worksheets[<span class="cs__number">0</span>];&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;first&nbsp;worksheet&nbsp;to&nbsp;_sheet&nbsp;object</span>&nbsp;
_sheet&nbsp;=&nbsp;sheet1;&nbsp;
&nbsp;
<span class="cs__com">//Call&nbsp;different&nbsp;custom&nbsp;methods</span>&nbsp;
<span class="cs__com">//These&nbsp;methods&nbsp;exhibits&nbsp;different&nbsp;conditional&nbsp;formatting&nbsp;types&nbsp;with&nbsp;their&nbsp;custom</span>&nbsp;
<span class="cs__com">//formattings&nbsp;attributes&nbsp;for&nbsp;MS&nbsp;Excel&nbsp;2007&nbsp;.xlsx&nbsp;file&nbsp;format</span>&nbsp;
AddDefaultIconSet();&nbsp;
AddIconSet1();&nbsp;
AddIconSet2();&nbsp;
AddDefaultColorScale();&nbsp;
AddDataBar1();&nbsp;
AddDataBar2();&nbsp;
AddTimePeriod_1();&nbsp;
AddTimePeriod_2();&nbsp;
&nbsp;
<span class="cs__com">//AutoFit&nbsp;M&nbsp;Column&nbsp;in&nbsp;the&nbsp;worksheet</span>&nbsp;
_sheet.AutoFitColumn(<span class="cs__number">12</span>);&nbsp;
&nbsp;
<span class="cs__com">//Specify&nbsp;the&nbsp;output&nbsp;file&nbsp;path</span>&nbsp;
<span class="cs__keyword">string</span>&nbsp;output&nbsp;=&nbsp;@<span class="cs__string">&quot;c:\data\Testoutput.xlsx&quot;</span>;&nbsp;
&nbsp;
<span class="cs__com">//Save&nbsp;the&nbsp;excel&nbsp;file</span>&nbsp;
book.Save(output,&nbsp;SaveFormat.Xlsx);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">As you can see in the above code, I am calling different methods to apply the conditional formatting, I will explain them one by one for your understanding.</div>
<div class="endscriptcode">Following method implements the IconSet conditional formatting type. This conditional formatting will be set to the range of cells &quot;A1:C2&quot;.</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void AddDefaultIconSet()
{
    FormatConditionCollection conds = GetFormatCondition(&quot;A1:C2&quot;, Color.Yellow);
    int idx = conds.AddCondition(FormatConditionType.IconSet);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddDefaultIconSet()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FormatConditionCollection&nbsp;conds&nbsp;=&nbsp;GetFormatCondition(<span class="cs__string">&quot;A1:C2&quot;</span>,&nbsp;Color.Yellow);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;idx&nbsp;=&nbsp;conds.AddCondition(FormatConditionType.IconSet);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Following are the helping methods used to create the conditional formatting ranges filling up the data in the ranges.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> //This method adds formatted conditions.
 private FormatConditionCollection GetFormatCondition(string cellAreaName, Color color)
 {
     //Adds an empty conditional formattings
     int index = _sheet.ConditionalFormattings.Add();
     //Get the formatted conditions
     FormatConditionCollection formatConditions = _sheet.ConditionalFormattings[index];
     //Get the cell area calling the custom GetCellAreaByName method
     CellArea area = GetCellAreaByName(cellAreaName);
     //Add the formatted conditions cell area.
     formatConditions.AddArea(area);
     //Call the custom FillCell method
     FillCell(cellAreaName, color);
     //Return the formatted conditions
     return formatConditions;
 }

 //This method specifies the cell shading color for the conditional formattings cellarea range.
 private void FillCell(string cellAreaName, Color color)
 {
     CellArea area = GetCellAreaByName(cellAreaName);
     int k = 0;
     for (int i = area.StartColumn; i &lt;= area.EndColumn; i&#43;&#43;)
     {
         for (int j = area.StartRow; j &lt;= area.EndRow; j&#43;&#43;)
         {
             Cell c = _sheet.Cells[j, i];
             if (!color.IsEmpty)
             {
                 Style s = c.GetStyle();
                 s.ForegroundColor = color;
                 s.Pattern = BackgroundType.Solid;
                 c.SetStyle(s);
             }
             //Set some random values to the cells in the cellarea range
             int value = j &#43; i &#43; k;
             c.PutValue(value);
             k&#43;&#43;;
         }
     }

 }

 //This method specifies the CellArea range (start row, start col, end row, end col etc.)
 //for the conditional formatting
 internal static CellArea GetCellAreaByName(string s)
 {
     CellArea area = new CellArea();
     string[] strCellRange = s.Replace(&quot;$&quot;, &quot;&quot;).Split(':');
     int column;
     CellsHelper.CellNameToIndex(strCellRange[0], out area.StartRow, out column);
     area.StartColumn = column;
     if (strCellRange.Length == 1)
     {
         area.EndRow = area.StartRow;
         area.EndColumn = area.StartColumn;
     }
     else
     {
         CellsHelper.CellNameToIndex(strCellRange[1], out area.EndRow, out column);
         area.EndColumn = column;
     }
     return area;
 }

</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//This&nbsp;method&nbsp;adds&nbsp;formatted&nbsp;conditions.</span>&nbsp;
&nbsp;<span class="cs__keyword">private</span>&nbsp;FormatConditionCollection&nbsp;GetFormatCondition(<span class="cs__keyword">string</span>&nbsp;cellAreaName,&nbsp;Color&nbsp;color)&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Adds&nbsp;an&nbsp;empty&nbsp;conditional&nbsp;formattings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;_sheet.ConditionalFormattings.Add();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;formatted&nbsp;conditions</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormatConditionCollection&nbsp;formatConditions&nbsp;=&nbsp;_sheet.ConditionalFormattings[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;cell&nbsp;area&nbsp;calling&nbsp;the&nbsp;custom&nbsp;GetCellAreaByName&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CellArea&nbsp;area&nbsp;=&nbsp;GetCellAreaByName(cellAreaName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;the&nbsp;formatted&nbsp;conditions&nbsp;cell&nbsp;area.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;formatConditions.AddArea(area);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Call&nbsp;the&nbsp;custom&nbsp;FillCell&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FillCell(cellAreaName,&nbsp;color);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Return&nbsp;the&nbsp;formatted&nbsp;conditions</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;formatConditions;&nbsp;
&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//This&nbsp;method&nbsp;specifies&nbsp;the&nbsp;cell&nbsp;shading&nbsp;color&nbsp;for&nbsp;the&nbsp;conditional&nbsp;formattings&nbsp;cellarea&nbsp;range.</span>&nbsp;
&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;FillCell(<span class="cs__keyword">string</span>&nbsp;cellAreaName,&nbsp;Color&nbsp;color)&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CellArea&nbsp;area&nbsp;=&nbsp;GetCellAreaByName(cellAreaName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;area.StartColumn;&nbsp;i&nbsp;&lt;=&nbsp;area.EndColumn;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;area.StartRow;&nbsp;j&nbsp;&lt;=&nbsp;area.EndRow;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cell&nbsp;c&nbsp;=&nbsp;_sheet.Cells[j,&nbsp;i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!color.IsEmpty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;s&nbsp;=&nbsp;c.GetStyle();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s.ForegroundColor&nbsp;=&nbsp;color;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s.Pattern&nbsp;=&nbsp;BackgroundType.Solid;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetStyle(s);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;some&nbsp;random&nbsp;values&nbsp;to&nbsp;the&nbsp;cells&nbsp;in&nbsp;the&nbsp;cellarea&nbsp;range</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;j&nbsp;&#43;&nbsp;i&nbsp;&#43;&nbsp;k;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.PutValue(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;k&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//This&nbsp;method&nbsp;specifies&nbsp;the&nbsp;CellArea&nbsp;range&nbsp;(start&nbsp;row,&nbsp;start&nbsp;col,&nbsp;end&nbsp;row,&nbsp;end&nbsp;col&nbsp;etc.)</span>&nbsp;
&nbsp;<span class="cs__com">//for&nbsp;the&nbsp;conditional&nbsp;formatting</span>&nbsp;
&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;CellArea&nbsp;GetCellAreaByName(<span class="cs__keyword">string</span>&nbsp;s)&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CellArea&nbsp;area&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CellArea();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;strCellRange&nbsp;=&nbsp;s.Replace(<span class="cs__string">&quot;$&quot;</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>).Split(<span class="cs__string">':'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;column;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CellsHelper.CellNameToIndex(strCellRange[<span class="cs__number">0</span>],&nbsp;<span class="cs__keyword">out</span>&nbsp;area.StartRow,&nbsp;<span class="cs__keyword">out</span>&nbsp;column);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;area.StartColumn&nbsp;=&nbsp;column;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(strCellRange.Length&nbsp;==&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;area.EndRow&nbsp;=&nbsp;area.StartRow;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;area.EndColumn&nbsp;=&nbsp;area.StartColumn;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CellsHelper.CellNameToIndex(strCellRange[<span class="cs__number">1</span>],&nbsp;<span class="cs__keyword">out</span>&nbsp;area.EndRow,&nbsp;<span class="cs__keyword">out</span>&nbsp;column);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;area.EndColumn&nbsp;=&nbsp;column;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;area;&nbsp;
&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Below are the two methods used to set the IconSet conditional formatting for with arrows colored attributes in range of cell &quot;M1:O2&quot; and &quot;M3:O4&quot; respectively.</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//This method implements the IconSet conditional formatting type with 3 Arrows Colored attribute.
private void AddIconSet1()
        {
            FormatConditionCollection conds = GetFormatCondition(&quot;M1:O2&quot;, Color.AliceBlue);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows3;
            Cell c = _sheet.Cells[&quot;M1&quot;];
            c.PutValue(&quot;Arrows3&quot;);
        }
        
//This method implements the IconSet conditional formatting type with 4 Arrows Colored attribute.
private void AddIconSet2()
        {
            FormatConditionCollection conds = GetFormatCondition(&quot;M3:O4&quot;, Color.AntiqueWhite);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows4;
            Cell c = _sheet.Cells[&quot;M3&quot;];
            c.PutValue(&quot;Arrows4&quot;);
        }       
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//This&nbsp;method&nbsp;implements&nbsp;the&nbsp;IconSet&nbsp;conditional&nbsp;formatting&nbsp;type&nbsp;with&nbsp;3&nbsp;Arrows&nbsp;Colored&nbsp;attribute.</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddIconSet1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormatConditionCollection&nbsp;conds&nbsp;=&nbsp;GetFormatCondition(<span class="cs__string">&quot;M1:O2&quot;</span>,&nbsp;Color.AliceBlue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;idx&nbsp;=&nbsp;conds.AddCondition(FormatConditionType.IconSet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormatCondition&nbsp;cond&nbsp;=&nbsp;conds[idx];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cond.IconSet.Type&nbsp;=&nbsp;IconSetType.Arrows3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cell&nbsp;c&nbsp;=&nbsp;_sheet.Cells[<span class="cs__string">&quot;M1&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.PutValue(<span class="cs__string">&quot;Arrows3&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__com">//This&nbsp;method&nbsp;implements&nbsp;the&nbsp;IconSet&nbsp;conditional&nbsp;formatting&nbsp;type&nbsp;with&nbsp;4&nbsp;Arrows&nbsp;Colored&nbsp;attribute.</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddIconSet2()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormatConditionCollection&nbsp;conds&nbsp;=&nbsp;GetFormatCondition(<span class="cs__string">&quot;M3:O4&quot;</span>,&nbsp;Color.AntiqueWhite);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;idx&nbsp;=&nbsp;conds.AddCondition(FormatConditionType.IconSet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormatCondition&nbsp;cond&nbsp;=&nbsp;conds[idx];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cond.IconSet.Type&nbsp;=&nbsp;IconSetType.Arrows4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cell&nbsp;c&nbsp;=&nbsp;_sheet.Cells[<span class="cs__string">&quot;M3&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.PutValue(<span class="cs__string">&quot;Arrows4&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The above sample codes gives you an idea of how to implement the conditional formatting using Aspose.Cells for .NET. You can download the sample application and check the complete code to test the&nbsp;conditional formatting feature.
 You can modify the&nbsp;sample application and use it as per your requirement.&nbsp;&nbsp;You can also download our
<a href="http://goo.gl/n3VBn2" target="_blank">Examples Dashboard</a> to test different features of Aspose.Cells for .NET.</div>
</div>
