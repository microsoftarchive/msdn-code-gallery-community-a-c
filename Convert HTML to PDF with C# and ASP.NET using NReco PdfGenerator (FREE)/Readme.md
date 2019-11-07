# Convert HTML to PDF with C# and ASP.NET using NReco PdfGenerator (FREE)
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ASP.NET
- ASP.NET MVC
- .NET Framework
- ASP.NET Web Forms
- ASP.NET Core
- ASP.NET Core MVC
## Topics
- Data Export
- Export to Pdf
- HTML to PDF
- C# PDF
- Html To Pdf Conversion
- C# wkhtmltopdf
## Updated
- 04/06/2017
## Description

<h1>Why convert HTML to PDF in C#</h1>
<p><span style="font-size:small">Export to PDF is a common feature in business applications but usage of low level PDF libraries (like iTextSharp or PdfSharp) requires a lot of boilerplate C# code. Applying visual design for PDF exports is very complicated
 with this approach.&nbsp;</span></p>
<p><span style="font-size:small">Fortunately better alternative exists: export content may be prepared as web page (HTML document) and then converted to PDF. Most reliable converters are based on browser engine (WebKit) that renders web page (including execution
 of js code) like a real web browser.</span></p>
<p><span style="font-size:small">One of the most popular HTML-to-PDF convertsion tool is
<a href="http://wkhtmltopdf.org/" target="_blank">wkhtmltopdf</a>. In this example we use
<a href="https://www.nrecosite.com/pdf_generator_net.aspx">NReco PdfGenerator</a>&nbsp;.NET wrapper that embeds wkhtmltopdf and provides simple API to execute it.<br>
</span></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">PdfGenerator usage<br>
</span></p>
<p><span style="font-size:small">Install <a href="https://www.nuget.org/packages/NReco.PdfGenerator/" target="_blank">
NReco.PdfGenerator nuget package</a>: &quot;install-package NReco.PdfGenerator&quot;</span></p>
<p><span style="font-size:small">The following code snippet illustrates PdfGenerator API usage:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using NReco.PdfGenerator;

....

var htmlToPdf = new HtmlToPdfConverter();

var pdfBytesFromUrl = htmlToPdf.GeneratePdfFromFile(webPageUrl, null);
var pdfBytesFromHtmlString = htmlToPdf.GeneratePdf(htmlContent, null);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;NReco.PdfGenerator;&nbsp;
&nbsp;
....&nbsp;
&nbsp;
var&nbsp;htmlToPdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdfConverter();&nbsp;
&nbsp;
var&nbsp;pdfBytesFromUrl&nbsp;=&nbsp;htmlToPdf.GeneratePdfFromFile(webPageUrl,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
var&nbsp;pdfBytesFromHtmlString&nbsp;=&nbsp;htmlToPdf.GeneratePdf(htmlContent,&nbsp;<span class="cs__keyword">null</span>);</pre>
</div>
</div>
</div>
<p><span style="font-size:small">That's all! Wkhtmltopdf is automatically extracted on first use (by default it is extracted to app bin folder, but location may be changed with &quot;PdfToolPath&quot; property).</span></p>
<p><span style="font-size:small">PdfGenerator has special build (<a href="https://www.nuget.org/packages/NReco.PdfGenerator.LT">NReco.PdfGenerator.LT</a>) that can be used from .NET Core projects, more details can be found on&nbsp;<a href="https://www.nrecosite.com/pdf_generator_net.aspx">PdfGenerator
 website</a>.<br>
</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">Examples package includes 2 projects:</span><em>&nbsp;</em></p>
<ul>
<li><span style="font-size:small">NReco.PdfGenerator.Examples.DemoMvc - ASP.NET MVC example</span>
</li><li><span style="font-size:small">NReco.PdfGenerator.Examples.DemoWebForms - ASP.NET WebForms example</span>
</li></ul>
<p><span style="font-size:small">Functionality in these projects is the same; it is possible to specify HTML template within textarea or specify web page URL for PDF generation.</span></p>
