# Convert HTML to PDF in C#/VB.NET and ASP.NET/MVC
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
## Topics
- Conversions
- HTML to PDF
- Html To Pdf Conversion
- HTML to Image
- HTML to SVG
- HTML to MHTML
- URL to PDF
- SVG to PDF
- MHTML to PDF
## Updated
- 11/14/2018
## Description

<h1>Introduction</h1>
<p>Syncfusion Essential PDF supports <a class="preview" title="HTML to PDF .NET" href="https://www.syncfusion.com/pdf-framework/net/html-to-pdf" target="_blank">
HTML to PDF in .NET</a> by using the advanced WebKit rendering engine. This converter can easily be integrated into any application of .NET platform such as WinForms, WPF, MVC and Azure Cloud Service to convert URLs, HTML string, SVG, MHTML to PDF.</p>
<h1><span>Building the Sample</span></h1>
<p>The sample showcased here covers most of the important features of HTML to PDF conversion. To deploy the sample, you need to install WebKit HTML converter which is available in the below link.</p>
<p><br>
WebKit HTML Converter:<em> <span style="color:#0000ff"><a title="https://www.syncfusion.com/downloads/latest-version" href="https://www.syncfusion.com/downloads/latest-version">https://www.syncfusion.com/downloads/latest-version</a></span></em></p>
<p><em><br>
</em>After the installation, the <em>WebKitPath </em>property of an instance of <span style="color:#3366ff">
WebKitConverterSettings </span>class should be assigned to the QtBinaries directory in the installed location. By default, this will be the installed location.</p>
<p><em><br>
<span style="color:#808080">$Systemdrive\Program Files (x86)\Syncfusion\WebKitHTMLConverter\xx.x.x.xx\QtBinaries</span></em></p>
<p><em><br>
</em>Alternatively, you can place the QtBinaries folder in the application bin folder which need no reference in the code behind.</p>
<p><br>
Products that come under Community license and the eligibility of the Community license can be checked from:
<em><a title="https://www.syncfusion.com/products/communitylicense" href="https://www.syncfusion.com/products/communitylicense"><span style="color:#0000ff">https://www.syncfusion.com/products/communitylicense</span></a><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Essential PDF easily converts HTML to PDF. The converter is very reliable and provides full support for HTML tags, CSS and JavaScript and also for advanced HTML5 features like CSS3, Canvas, SVG, and Web Fonts.</p>
<p><br>
Our Essential PDF WebKit rendering is accurate, and the result preserves all the graphics, images, texts, fonts, and layout of the original HTML document/web page.</p>
<p><br>
It does not require external dependencies like browsers, printer drivers, and viewers.</p>
<p><br>
Documentation is also available at:<em>&nbsp; <a title="https://help.syncfusion.com/file-formats/pdf/working-with-document-conversions#conversion-using-webkit-rendering" href="https://help.syncfusion.com/file-formats/pdf/converting-html-to-pdf#conversion-using-webkit-rendering">
<span style="color:#0000ff">https://help.syncfusion.com/file-formats/pdf/converting-html-to-pdf#conversion-using-webkit-rendering</span></a><br>
</em></p>
<h2><em>Sample output:</em></h2>
<p><img id="158271" src="158271-test.png" alt="" width="616" height="409"></p>
<p>&nbsp;</p>
<h2>HTML to PDF features</h2>
<p style="padding-left:30px">&bull;&nbsp;&nbsp;&nbsp; Converts any webpage to PDF.<br>
&bull;&nbsp;&nbsp;&nbsp; Converts any raw HTML string to PDF.<br>
&bull;&nbsp;&nbsp;&nbsp; Prevents text and image split across pages.<br>
&bull;&nbsp;&nbsp;&nbsp; Converts HTML form to fillable PDF form.<br>
&bull;&nbsp;&nbsp;&nbsp; Works both in 32-bit and 64-bit environments.<br>
&bull;&nbsp;&nbsp;&nbsp; Automatically creates Table of Contents.<br>
&bull;&nbsp;&nbsp;&nbsp; Automatically creates bookmark hierarchy.<br>
&bull;&nbsp;&nbsp;&nbsp; Converts only a part of the web page to PDF.<br>
&bull;&nbsp;&nbsp;&nbsp; Supports header and footer.<br>
&bull;&nbsp;&nbsp;&nbsp; Repeats HTML table header and footer in PDF.<br>
&bull;&nbsp;&nbsp;&nbsp; Supports HTML5, CSS3, SVG, and Web fonts.<br>
&bull;&nbsp;&nbsp;&nbsp; Converts any HTML to MHTML.<br>
&bull;&nbsp;&nbsp;&nbsp; Converts any HTML to SVG.<br>
&bull;&nbsp;&nbsp;&nbsp; Converts any HTML to image.<br>
&bull;&nbsp;&nbsp;&nbsp; Supports accessing HTML page using both HTTP POST and GET methods.<br>
&bull;&nbsp;&nbsp;&nbsp; Supports HTTP cookies.<br>
&bull;&nbsp;&nbsp;&nbsp; Supports cookies-based form authentication.<br>
&bull;&nbsp;&nbsp;&nbsp; Thread safe.<br>
&bull;&nbsp;&nbsp;&nbsp; Supports internal and external hyperlinks.<br>
&bull;&nbsp;&nbsp;&nbsp; Sets document properties, page settings, security, viewer preferences, etc.<br>
&bull;&nbsp;&nbsp;&nbsp; Protects PDF document with password and permission.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__com">//Initialize&nbsp;HTML&nbsp;converter</span>&nbsp;
HtmlToPdfConverter&nbsp;htmlConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdfConverter(HtmlRenderingEngine.WebKit);&nbsp;
&nbsp;
<span class="cs__com">//WebKit&nbsp;converter&nbsp;settings</span>&nbsp;
WebKitConverterSettings&nbsp;webKitSettings&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebKitConverterSettings();&nbsp;
&nbsp;
<span class="cs__com">//Assign&nbsp;the&nbsp;WebKit&nbsp;binaries&nbsp;path</span>&nbsp;
<span class="cs__com">//webKitSettings.WebKitPath&nbsp;=&nbsp;@&quot;../../../../QtBinaries&quot;;</span>&nbsp;
&nbsp;
<span class="cs__com">//Assing&nbsp;WebKit&nbsp;settings&nbsp;to&nbsp;converter&nbsp;settings</span>&nbsp;
htmlConverter.ConverterSettings&nbsp;=&nbsp;webKitSettings;&nbsp;
&nbsp;
<span class="cs__com">//Convert&nbsp;url&nbsp;to&nbsp;PDF&nbsp;document.</span>&nbsp;
PdfDocument&nbsp;document&nbsp;=&nbsp;htmlConverter.Convert(<span class="cs__string">&quot;www.google.com&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Save&nbsp;and&nbsp;close&nbsp;the&nbsp;document.</span>&nbsp;
document.Save(<span class="cs__string">&quot;Sample.pdf&quot;</span>);&nbsp;
document.Close(<span class="cs__keyword">true</span>);&nbsp;
</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p>For more information, please refer our UG documentation<em><br>
<a title="https://help.syncfusion.com/file-formats/pdf/working-with-document-conversions#conversion-using-webkit-rendering" href="https://help.syncfusion.com/file-formats/pdf/converting-html-to-pdf#conversion-using-webkit-rendering">https://help.syncfusion.com/file-formats/pdf/converting-html-to-pdf#conversion-using-webkit-rendering</a><br>
</em></p>
