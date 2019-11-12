# Convert xls to xlsx or xlsx to xls in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- WPF
## Topics
- Excel
- xls to xlsx
- Excel file conversion
- XLSX to XLS
- XLS to XLSX in C#
- XLSX to XLS in C#
## Updated
- 08/11/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Since Microsoft has released its 2007 office pack, compatibility matters between old versions&rsquo; files and 2007 programs has been reported. That is why Convert XLS to XLSX has been developed, to ensure you that your old
 files can still be used.This sample focuses on delivering a solution to convert Excel files in a folder from XLS to XLSX or from XLSX to XLS via a .NET Excel component - Spire.XLS.</span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">Description</span></strong></p>
<p><br>
<span style="font-size:small">Under the help of Spire.XLS, the conversion between XLS,XLSX can be as easy as ABC.<a href="http://www.e-iceblue.com/Download/download-excel-for-net-now.html">Download Spire.XLS for .NET</a> and install it on your system. The Spire.XLS
 installation is clean, professional and wrapped up in a MSI installer. Then, adds Spire.XLS.dll as reference in the downloaded Bin folder thought the below path: &quot;..\Spire.XLS\Bin\NET4.0\ Spire.XLS.dll&quot;.Then let's check the code.</span></p>
<p><br>
<strong><span style="font-size:small">Code snippet for convert XLS to XLSX:</span></strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;load&nbsp;source&nbsp;xls&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(@<span class="cs__string">&quot;..\..\source.xls&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;to&nbsp;xlsx&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.SaveToFile(@<span class="cs__string">&quot;..\..\temp1.xlsx&quot;</span>,&nbsp;ExcelVersion.Version2010);</pre>
</div>
</div>
</div>
<p><strong><span style="font-size:small">Convert XLSX to XLS:</span></strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;load&nbsp;source&nbsp;xlsx&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook2&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook2.LoadFromFile(@<span class="js__string">&quot;..\..\temp1.xlsx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;convert&nbsp;to&nbsp;xls&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook2.SaveToFile(@<span class="js__string">&quot;..\..\temp2.xls&quot;</span>,&nbsp;ExcelVersion.Version97to2003);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><span style="font-size:small">Spire.XLS for .NET is a standalone Excel .NET managed assembly and does not depend on Microsoft Office Excel. Spire.XLS for .NET offers support both for the old Excel 97-2003 format (.xls) and for the new Excel 2007,Excel 2010
 and Excel 2013 (.xlsx, .xlsb, .xlsm), along with Open Office(.ods) format. It features fast and reliably compared to developing your own spreadsheet manipulation solution or using Microsoft Automation.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Main Functions</strong></span></p>
<ul>
<li><span style="font-size:small">Powerful &amp; High Quality Excel File Conversion</span>
</li><li><span style="font-size:small">Create Excel Report from Comprehensive Workbook Designer</span>
</li><li><span style="font-size:small">Freely operate Worksheet</span> </li><li><span style="font-size:small">Easily Manipulate cells &amp; Excel Calculation Engine at run time</span>
</li><li><span style="font-size:small">Handle Chart, Data and other Elements</span> </li></ul>
<p><strong><span style="font-size:small">Related links</span></strong></p>
<p><span style="font-size:small">Website: <a href="http://www.e-iceblue.com/">http://www.e-iceblue.com/</a></span></p>
<p><span style="font-size:small">Product Home: <a href="http://www.e-iceblue.com/Introduce/free-xls-component.html">
Free Spire.XLS for .NET</a></span></p>
<p><span style="font-size:small">Download: <a href="http://www.e-iceblue.com/Download/download-excel-for-net-now.html">
Free Spire.XLS Download</a><br>
</span></p>
<p><span style="font-size:small">Live Demo: <a href="http://www.e-iceblue.com/Knowledgebase/Spire.XLS/Demos.html">
Spire.XLS Demos</a><br>
</span></p>
<p><span style="font-size:small">Forum: <a href="http://www.e-iceblue.com/forum/spire-xls-f4.html">
Free Spire.XLS Forum</a></span></p>
