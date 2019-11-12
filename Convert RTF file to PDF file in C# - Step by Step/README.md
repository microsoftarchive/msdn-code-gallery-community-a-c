# Convert RTF file to PDF file in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- .NET
- Windows Forms
- WPF
- Microsoft Azure
- .NET Framework
- VB.Net
- .NET Framework 4.0
- C# Language
- ASP.NET MVC 4
- Visual C#
- ASP.NET Web API
- SharePoint Server 2013
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- Windows Forms
- WPF
- Microsoft Azure
- ASP.NET MVC
- custom controls
- Visual Basic .NET
- Office Automation
- How to
- WCF Service
## Updated
- 01/20/2016
## Description

<h1>Introduction</h1>
<p>This is a C # example to convert RTF files into PDF under .Net without using MS Office Automation via a free C# PDF library. Only the .Net platform and nothing else.</p>
<p><span>With the help of &quot;PDF Metamorphosis .Net&quot;, any .Net application can easily transform RTF documents to PDF format. For example, to convert a RTF to PDF in C# you will only need to add a reference to the PdfMetamorphosis.dll and type a few lines of code.</span></p>
<h1><span>Main Functions</span></h1>
<p><em><img id="147571" src="147571-rtftopdf.png" alt=""></em></p>
<h1>How to do it:</h1>
<p><em>So, here we'll show you in details how to convert any RTF files in PDF documents using C#.</em></p>
<p><em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the RTF file: test.rtf (please see in att. file) and we need to create &nbsp;a PDF document from&nbsp;test.rtf</em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;rtf to pdf&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.PdfMetamorphosis.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to convert our test.rtf into test.pdf</em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the PDF Metmorphosis.Net library we've created a PDF document.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.aspx" target="_blank" title="Auto generated link to System.Collections">System.Collections</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Test&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.PdfMetamorphosis&nbsp;p&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.PdfMetamorphosis();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;www.sautinsoft.com/products/pdf-metamorphosis/download.php</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;rtfPath&nbsp;=&nbsp;@<span class="cs__string">&quot;d:\test.rtf&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pdfPath&nbsp;=&nbsp;Path.ChangeExtension(rtfPath,&nbsp;<span class="cs__string">&quot;.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;p.RtfToPdfConvertFile(rtfPath,&nbsp;pdfPath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Console.WriteLine.aspx" target="_blank" title="Auto generated link to System.Console.WriteLine">System.Console.WriteLine</a>(<span class="cs__string">&quot;An&nbsp;error&nbsp;occured&nbsp;during&nbsp;converting&nbsp;RTF&nbsp;to&nbsp;PDF!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(pdfPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>Source Code Files</h1>
<div><em>Related Links:</em></div>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/pdf-metamorphosis/index.php">PDF Metamorphosis .NET</a><br>
Download:&nbsp;<a href="http://sautinsoft.com/products/pdf-metamorphosis/download.php">PDF Metamorphosis .NET</a><br>
</em></div>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that PDF Metmoarphosis.Net is entirely written in managed C#, which makes
 it absolutely standalone and an independent library</em></p>
