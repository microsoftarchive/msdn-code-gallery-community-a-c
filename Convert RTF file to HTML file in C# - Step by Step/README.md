# Convert RTF file to HTML file in C# - Step by Step
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
- Microsoft Azure
- .NET Framework 4.0
- HTML5
- Visual C#
## Topics
- Controls
- C#
- ASP.NET
- Azure
- Windows Forms
- Microsoft Azure
- Web Services
- HTML5
- .NET 4
- How to
## Updated
- 01/27/2016
## Description

<h1>Introduction</h1>
<p><em>This is a demonstration sample for converting RTF files to HTML files with SautinSoft.RTFtoHTML Free library. The sample shows how<em><em>to provide API for your application to convert RTF document into HTML page, using C# or VB.Net.</em></em></em></p>
<p><em>Now you can operate with RtfToHTML class which provides you by various methods and properties to convert RTF as MemoryStream, String, Files and so forth.</em></p>
<h1>Main Functions</h1>
<p><img id="147799" src="147799-rtftohtml.png" alt="" width="624" height="305"></p>
<h1>How to do it:</h1>
<p><em>So, here we'll show you in details how to convert any RTF files in HTML documents using C#.</em></p>
<p><em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the RTF file: test.rtf (please see in att. file) and we need to create &nbsp;a HTML document from test.rtf</em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;rtf to html&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.RtfToHTML.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to convert our test.rtf into test.html</em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the RTFtoHTML.Net library we've created a HTML document.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SampleConvert&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;sample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.RtfToHtml&nbsp;r&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.RtfToHtml();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;AppPath=<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Environment.CurrentDirectory.aspx" target="_blank" title="Auto generated link to System.Environment.CurrentDirectory">System.Environment.CurrentDirectory</a>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//specify&nbsp;some&nbsp;options</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.OutputFormat&nbsp;=&nbsp;SautinSoft.RtfToHtml.eOutputFormat.HTML_5;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Encoding&nbsp;=&nbsp;SautinSoft.RtfToHtml.eEncoding.UTF_8;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;rtfFile&nbsp;=&nbsp;Path.GetFullPath(@<span class="cs__string">&quot;D:\test.rtf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;htmlFile&nbsp;=&nbsp;Path.Combine(AppPath,<span class="cs__string">&quot;test.html&quot;</span>);&nbsp;<span class="cs__com">//the&nbsp;result&nbsp;will&nbsp;be&nbsp;located&nbsp;in&nbsp;the&nbsp;same&nbsp;folder&nbsp;as&nbsp;binary</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;r.ConvertFile(rtfFile,htmlFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Console.WriteLine.aspx" target="_blank" title="Auto generated link to System.Console.WriteLine">System.Console.WriteLine</a>(<span class="cs__string">&quot;Converted&nbsp;successfully!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(htmlFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Console.WriteLine.aspx" target="_blank" title="Auto generated link to System.Console.WriteLine">System.Console.WriteLine</a>(<span class="cs__string">&quot;Conversion&nbsp;failed!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1>Source Code Files</h1>
<p>&nbsp;<em>Related Links:</em></p>
<div><em><br>
Website:&nbsp;<a href="http://sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/convert-rtf-to-html/rtf-to-html-component-asp.net.php">RTF to HTML.Net</a><br>
Download:&nbsp;<a href="http://sautinsoft.com/convert-rtf-to-html/download.php"><em>RTF to HTML.Net</em></a><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that RTFtoHTML.Net is entirely written in managed C#, which makes it absolutely
 standalone and an independent library</em></p>
