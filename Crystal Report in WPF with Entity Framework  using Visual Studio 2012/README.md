# Crystal Report in WPF with Entity Framework  using Visual Studio 2012
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- ADO.NET Entity Framework
- WPF
- SQL Server 2008 R2 Express Edition 64 bit
- Crystal Report
## Topics
- Crystal Report in WPF
- Crystal Report in Visual Studio 2012
- Crystal Report using .net framework 4.5
- Crystal report using datasource
- Crystal Report using Entity Framework
## Updated
- 03/18/2014
## Description

<h1>Introduction</h1>
<p>WPF Crystal Reports using Entity Framework and DataSet</p>
<p><em>Visual Studio 2012 For Desktop Application does not support directly by SAP Crystal Report.
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Download the Supported Version for Visual Studio or .NET framework.</em></p>
<p><em>The Current Version of crystal reports supports .net framework 4.0.<br>
</em></p>
<p><em><a title="http://scn.sap.com/docs/DOC-7824" href="http://scn.sap.com/docs/DOC-7824">Download Here</a><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This article describes how to create Crystal Reports in WPF using Entity Framework in visual studio 2012.
<br>
</em></p>
<p>Follow the Steps.</p>
<p>1) Create New WPF Project.</p>
<p>2) Create Two New Folder Data and Report</p>
<p>If Crystal Report Viewer is not found in your Toolbox.</p>
<p>then follow the steps.</p>
<p>i) Right Click on Toolbox.</p>
<p>ii) Create Report Tab.</p>
<p>iii) Right Click in Report Tab select Choose Items.</p>
<p>iv) In WPF Component Tab choose Crystal Report Viewer for WPF</p>
<p>&nbsp;</p>
<p><img id="110797" src="110797-1.jpg" alt="" width="627" height="50"></p>
<p>&nbsp;</p>
<p>3) Create Entity Data Model in Data Folder.</p>
<p><img id="110798" src="110798-2.jpg" alt="" width="640" height="390"></p>
<p><img id="110799" src="110799-3.jpg" alt="" width="538" height="480"><img id="110800" src="110800-4.jpg" alt=""><img id="110804" src="110804-5.jpg" alt="" width="544" height="480"></p>
<p><strong>4) Create DataSet in Data Folder.</strong></p>
<p><img id="110824" src="110824-6.jpg" alt="" width="640" height="390"></p>
<p><img id="110825" src="110825-7.jpg" alt="" width="498" height="112"></p>
<p><strong>5) Add Tables in Dataset.</strong></p>
<p><img id="110826" src="110826-8.jpg" alt=""></p>
<p><strong>6) Create Crystal Report in SAP Crystal Report.</strong></p>
<p><strong>7) Create Blank Report</strong></p>
<p><strong>8) In DataBase Expert Select ADO.NET (XML)</strong></p>
<p><strong><img id="110827" src="110827-9.jpg" alt="" width="503" height="447"><br>
</strong></p>
<p><strong>9) Select the Dataset from Data folder from your current project.</strong></p>
<p><strong><img id="110828" src="110828-10.jpg" alt=""><br>
</strong></p>
<p><img id="110829" src="110829-11.jpg" alt="" width="500" height="477"></p>
<p>10) Select the Tables from DataSet.</p>
<p><img id="110830" src="110830-12.jpg" alt="" width="503" height="453"></p>
<p>Design Report as per your requirement.</p>
<p><img id="110831" src="110831-13.jpg" alt=""></p>
<p>11) Create New Window in Report Folder.</p>
<p>12) Drag and Drop Crystal Report Viewer from Toolbox.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">Viewer</span>=<span class="xaml__attr_value">&quot;clr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;CrystalReport_Example.Report.Report&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Report&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;550&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;1024&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Viewer</span>:CrystalReportsViewer&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;CrystalReportViewer1&quot;</span>&nbsp;<span class="xaml__attr_name">Loaded</span>=<span class="xaml__attr_value">&quot;CrystalReportViewer1_Loaded&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Include Name Space in your Report.cs file.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;CrystalReport_Example.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;CrystalDecisions.CrystalReports.Engine;&nbsp;
<span class="cs__keyword">using</span>&nbsp;CrystalDecisions.ReportSource;</pre>
</div>
</div>
</div>
Add Reference CrystalReports.Engine in your project.</div>
<p><img id="110832" src="110832-14.jpg" alt=""></p>
<p>&nbsp;</p>
<p>13) Write the following Code in App.config File.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;startup</span>&nbsp;<span class="xaml__attr_name">useLegacyV2RuntimeActivationPolicy</span>=<span class="xaml__attr_value">&quot;true&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;supportedRuntime</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;v4.0&quot;</span>&nbsp;<span class="xaml__attr_name">sku</span>=<span class="xaml__attr_value">&quot;.NETFramework,Version=v4.0&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/startup&gt;</span></pre>
</div>
</div>
</div>
<p><span>&nbsp;</span></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
