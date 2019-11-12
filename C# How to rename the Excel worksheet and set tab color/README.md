# C# How to rename the Excel worksheet and set tab color
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- .NET
- Windows Forms
- .NET Framework 4.0
- Visual Studio 2013
- Programming Languages
- Excel API
- 3rd class library
## Topics
- Controls
- C#
- Excel
- .NET
- Code Sample
- How to
- rename worksheet
## Updated
- 02/27/2018
## Description

<p><strong>Introduction</strong></p>
<p>In this operation, you should download and install the component Free Spire.XLS for .NET first, and then add the dll file as a reference into the project assemblies. These code would show you how it works.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Xls;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RenameWorksheet_Excel&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;Workbook&nbsp;class&nbsp;and&nbsp;load&nbsp;an&nbsp;instance&nbsp;from&nbsp;files</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\sampletest1.xlsx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;sheet1,sheet2&nbsp;and&nbsp;sheet3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;worksheet&nbsp;=&nbsp;workbook.Worksheets[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;worksheet1&nbsp;=&nbsp;workbook.Worksheets[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;worksheet2&nbsp;=&nbsp;workbook.Worksheets[<span class="cs__number">2</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Rename&nbsp;the&nbsp;sheets</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Rename&nbsp;sheet1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet1.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Rename&nbsp;sheet2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet2.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Rename&nbsp;sheet3&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;tab&nbsp;color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.TabColor&nbsp;=&nbsp;Color.DarkGreen;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet1.TabColor&nbsp;=&nbsp;Color.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet2.TabColor&nbsp;=&nbsp;Color.Blue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;the&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.SaveToFile(<span class="cs__string">&quot;Rename.xlsx&quot;</span>,&nbsp;ExcelVersion.Version2010);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(workbook.FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>Before</h1>
<p><img id="181318" src="181318-1.png" alt="" width="495" height="73"></p>
<ul>
</ul>
<h1>After</h1>
<p><img id="181319" src="181319-2.png" alt="" width="674" height="60"></p>
<p><strong>More about Spire.XLS for .NET</strong></p>
<p><strong>Supports</strong></p>
<p>&nbsp;</p>
<ul>
<li>Create and Edit Excel </li><li>&nbsp;Find and Replace Data </li><li>Print excel files </li><li>Import/Export data from a DataTable, DataView, Array, DataGrid etc. </li><li>Save Excel to file/Stream or as web response </li><li>Create charts </li><li>Read and write hyperlinks </li><li>Create auto filters </li><li>Implement Data Sorting </li><li>Implement Data Validations </li><li>Merge/Unmerge Cells and files </li><li>Group/UnGroup Rows and Columns </li><li>Insert/Delete or Hide Rows, Columns and Sheets </li><li>Calculate Complex Excel Formula </li><li>Freeze/Unfreeze Panes </li><li>Insert Hyperlinks to link data </li><li>Protect/Unprotect Worksheets </li><li>Create Pivot Tables </li><li>Encrypt/Decrypt Files </li><li>Load/Save Excel VBA </li><li>Merge data into Excel with MarkerDesigner </li></ul>
<p><strong>&nbsp;</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Related links</strong></p>
<p>Website: <a href="https://www.e-iceblue.com/">https://www.e-iceblue.com/</a></p>
<p>Product introduction:<a href="https://www.e-iceblue.com/Introduce/free-xls-component.html">https://www.e-iceblue.com/Introduce/free-xls-component.html</a></p>
<p>Download address: <a href="https://www.e-iceblue.com/Download/download-excel-for-net-free.html">
https://www.e-iceblue.com/Download/download-excel-for-net-free.html</a></p>
<p>Forum: <a href="https://www.e-iceblue.com/forum/spire-xls-f4.html">https://www.e-iceblue.com/forum/spire-xls-f4.html</a></p>
