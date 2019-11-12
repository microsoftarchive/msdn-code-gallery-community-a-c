# Creating an Excel Workbook with VB.NET and ASP.NET
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Excel
- VB.Net
## Topics
- Office
- Generate Excel Workbook
- Microsoft Office
## Updated
- 10/03/2011
## Description

<h1>Introduction</h1>
<p>This sample shows how to create an XLSX file from a database query using VB.NET and ASP.NET. It uses the helper library EPPlus (<a href="http://epplus.codeplex.com/">http://epplus.codeplex.com/</a>) . Reference DLLs are included in the sample</p>
<h1><span>Building the Sample</span></h1>
<p>You will need to change the value for the connection string variable &quot;<em>con</em>&quot;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'TODO:&nbsp;INSERT&nbsp;CONNECTION&nbsp;STRING</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;conString&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;INSERT&nbsp;CONNECTION&nbsp;STRING&nbsp;HERE&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Additionally this solution file contains 2 database projects which create the sample database. If this database is not created please check the solution targets or creater the database yourself.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">Additionally there is an SQL file which contains sample data for the database in the file GenerateCountryData.sql. This will insert a lot of sample data into the country database.</div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The web project contrains a sample page which has only one button on the page. Clicking this button generates the XLSX file in memory and then sends it to the browser to be downloaded.</p>
<p>The GenerateXLSXFile method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;GenerateXLSXFile(tbl&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;excelPackage&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ExcelPackage&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;excelWorksheet&nbsp;=&nbsp;excelPackage.Workbook.Worksheets.Add(<span class="visualBasic__string">&quot;DemoPage&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelWorksheet.Cells(<span class="visualBasic__string">&quot;A1&quot;</span>).LoadFromDataTable(tbl,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.ContentType&nbsp;=&nbsp;<span class="visualBasic__string">&quot;application/vnd.openxmlformats-officedocument.spreadsheetml.sheet&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.AddHeader(<span class="visualBasic__string">&quot;content-disposition&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;attachment;&nbsp;&nbsp;filename=ExcelDemo.xlsx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;stream&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;MemoryStream&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;MemoryStream(excelPackage.GetAsByteArray())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.OutputStream.Write(stream.ToArray(),&nbsp;<span class="visualBasic__number">0</span>,&nbsp;stream.ToArray().Length)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Flush()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Close()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The method takes a DataTable object (and this can be changed to suit your own needs). It creates a new Excel workbook and worksheet and inserts the data in the cells beginning at A1.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">It then forces the download by settings the Content Type and Response headers.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Generating the datatable</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CreateDataTable()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dataTable&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataTable(<span class="visualBasic__string">&quot;DT&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'TODO:&nbsp;INSERT&nbsp;CONNECTION&nbsp;STRING</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;conString&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;INSERT&nbsp;CONNECTION&nbsp;STRING&nbsp;HERE&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;con&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlConnection(conString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sql&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;country;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCommand(sql,&nbsp;con)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;adaptor&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlDataAdapter&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;adaptor.SelectCommand&nbsp;=&nbsp;cmd&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;adaptor.Fill(dataTable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Close()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dataTable&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;More Information</h1>
<div class="endscriptcode"></div>
<div class="endscriptcode">For more information please see EPPlus on Codeplex <a href="http://epplus.codeplex.com/">
http://epplus.codeplex.com/</a></div>
</div>
