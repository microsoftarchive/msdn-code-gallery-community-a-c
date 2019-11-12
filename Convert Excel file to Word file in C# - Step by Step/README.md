# Convert Excel file to Word file in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Win32
- Windows Forms
- Microsoft Azure
- .NET Framework
- .NET Framework 4.0
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- Microsoft Azure
- How to
## Updated
- 02/29/2016
## Description

<h1>Introduction</h1>
<p><em>How to write a function to convert Excel (XLS/XLSX) to DOCX in C# for 15 minutes?</em></p>
<p><span>Imagine, that in 15 minutes after reading this text you will be able to provide API for your application to convert Excel tables into Word (DOCX) using C# or VB.Net.</span></p>
<p>During the conversion process you may: select custom sheets and area of cells for conversion, specify page properties, add page numbers.</p>
<p><em><br>
</em></p>
<h1>Main Functions</h1>
<p><img id="149065" src="149065-exceltodocx.png" alt="" width="686" height="338"></p>
<h1>How to do it:</h1>
<p><em>So, here we'll show you in details how to convert any Excel files in Word documents using C#.</em></p>
<p><em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the Excel file: test.xls (please see in att. file) and we need to create &nbsp;a Word document from&nbsp;test.docx</em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;xls to docx&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.ExceltoPDF.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to convert our test.xls into test.docx</em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the Excel to PDF.Net library we've created a Word document.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Sample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Convert&nbsp;Excel&nbsp;file&nbsp;to&nbsp;DOCX&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExcelToPdf&nbsp;x&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ExcelToPdf();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;www.sautinsoft.com/convert-excel-xls-to-pdf/free-download-spreadsheet-xls-excel-to-pdf-component.php</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;DOCX&nbsp;as&nbsp;output&nbsp;format.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x.OutputFormat&nbsp;=&nbsp;SautinSoft.ExcelToPdf.eOutputFormat.Docx;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;excelFile&nbsp;=&nbsp;Path.GetFullPath(@<span class="cs__string">&quot;d:\Download\test.xls&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;docxFile&nbsp;=&nbsp;Path.ChangeExtension(excelFile,&nbsp;<span class="cs__string">&quot;.docx&quot;</span>);&nbsp;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x.ConvertFile(excelFile,&nbsp;docxFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(docxFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><img id="149066" src="149066-scr.png" alt=""></h1>
<h1>Source Code Files</h1>
<div><em>Related Links:</em></div>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home: <a href="http://sautinsoft.com/convert-excel-xls-to-pdf/spreadsheet-xls-excel-to-pdf-export-component-asp.net.php">
Excel to PDF.Net</a><br>
Download:&nbsp;<a href="http://sautinsoft.com/thankyou.php?download=exceltopdf_net.zip">Excel to PDF.Net</a><br>
</em></div>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that Excel to PDF.Net is entirely written in managed C#, which makes it
 absolutely standalone and an independent library</em></p>
