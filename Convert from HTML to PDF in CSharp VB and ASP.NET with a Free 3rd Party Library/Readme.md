# Convert from HTML to PDF in CSharp VB and ASP.NET with a Free 3rd Party Library
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET Framework
- VB.Net
## Topics
- HTML to PDF
- Html To Pdf Conversion
- Pdf Library
- Html to Pdf Azure
## Updated
- 05/10/2019
## Description

<p>Converting from html to pdf is not an easy task. There are some tools that can do that, but most of them cost thousands of dollars.</p>
<p>Select.Pdf offers a Community Edition (FREE) of the powerful <a title="Html To Pdf Converter for .NET" href="http://selectpdf.com/html-to-pdf-converter/">
Html To Pdf Converter for .NET</a> that can be found in the full featured pdf library Select.Pdf for .NET. The free html to pdf converter offers most of the features the professional sdk offers, the most notable limitation is that it can only generate pdf documents
 up to 5 pages long.</p>
<p>The <a title="Free Html To Pdf for .NET" href="http://selectpdf.com/community-edition/">
community edition</a> contains ready to use samples, coded in C# and VB.NET for Windows Forms and ASP.NET. Select.Pdf Html To Pdf Converter for .NET works on any Windows OS and on Windows Azure.</p>
<p>SelectPdf Html To Pdf Converter provides versions for .NET Framework and .NET Core 2.0 and above (through .NET Standard 2.0). SelectPdf only works on Windows. SelectPdf works on Azure cloud, including Azure Web Apps (Basic plan or above) with some limitations.</p>
<h1>Html to Pdf Converter For .NET - Community Edition Features</h1>
<ul>
<li>Generate pdf documents up to 5 pages </li><li>Convert any web page to pdf </li><li>Convert any raw html string to pdf </li><li>Set pdf page settings (page size, page orientation, page margins) </li><li>Resize content during conversion to fit the pdf page </li><li>Set pdf document properties </li><li>Set pdf viewer preferences </li><li>Set pdf security (passwords, permissions) </li><li>Set conversion delay and web page navigation timeout </li><li>Custom headers and footers </li><li>Support for html in headers and footers </li><li>Automatic and manual page breaks </li><li>Repeat html table headers on each page </li><li>Support for @media types screen and print </li><li>Support for internal and external links </li><li>Generate bookmarks automatically based on html elements </li><li>Support for HTTP headers </li><li>Support for HTTP cookies </li><li>Support for web pages that require authentication </li><li>Support for proxy servers </li><li>Enable/disable javascript </li><li>Modify color space </li><li>Multithreading support </li><li>HTML5/CSS3 support </li><li>Web fonts support </li></ul>
<h1><span>Building the Sample</span></h1>
<p>The sample project attached presents most of the SelectPdf Html To Pdf Converter Features. A reference to the Select.Pdf Html To Pdf for .NET was a added as a NuGet Package. Alternatively, the free product can be downloaded from&nbsp;<a title="Free Html To Pdf Converter" href="http://selectpdf.com/community-edition/">http://selectpdf.com/community-edition/</a>.</p>
<p>SelectPdf Free Html To Pdf Converter is very easy to use. Below is a small sample code. A lot more can be found in the sample project attached.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// instantiate the html to pdf converter
HtmlToPdf converter = new HtmlToPdf();

// convert the url to pdf
PdfDocument doc = converter.ConvertUrl(url);

// save pdf document
doc.Save(file);

// close pdf document
doc.Close();</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;instantiate&nbsp;the&nbsp;html&nbsp;to&nbsp;pdf&nbsp;converter</span>&nbsp;
HtmlToPdf&nbsp;converter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdf();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;convert&nbsp;the&nbsp;url&nbsp;to&nbsp;pdf</span>&nbsp;
PdfDocument&nbsp;doc&nbsp;=&nbsp;converter.ConvertUrl(url);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;save&nbsp;pdf&nbsp;document</span>&nbsp;
doc.Save(file);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;close&nbsp;pdf&nbsp;document</span>&nbsp;
doc.Close();</pre>
</div>
</div>
</div>
<p><span style="font-size:small">ASP.NET MVC Sample available here:&nbsp;<a href="https://code.msdn.microsoft.com/Free-Html-To-Pdf-Converter-04e4438e">https://code.msdn.microsoft.com/Free-Html-To-Pdf-Converter-04e4438e</a></span></p>
<p><span style="font-size:small">ASP.NET Core MVC Sample available here:&nbsp;<a href="https://code.msdn.microsoft.com/Convert-from-HTML-to-PDF-d63582e8">https://code.msdn.microsoft.com/Convert-from-HTML-to-PDF-d63582e8</a></span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<h1>IMPORTANT</h1>
<p>This Community Edition of SelectPdf IS NOT THE FREE TRIAL for SelectPdf Commercial Library. This is a FREE product with
<strong>limited functionality</strong>. If you want to try the full featured SelectPdf Library, download a free trial version from here:
<a title="Html To Pdf Converter" href="http://selectpdf.com/pdf-library-for-net/" target="_blank">
http://selectpdf.com/pdf-library-for-net/</a></p>
<p>The following features are not part of the free community edition. To use any of these features you need the full
<strong>commercial</strong> <a title="SelectPdf Library for .NET" href="http://selectpdf.com/pdf-library-for-net/" target="_blank">
SelectPdf Library for .NET</a>:</p>
<p>- Create PDF documents with more than 5 pages.<br>
- Convert only a certain section of the page, specified by the html element ID.<br>
- Manually start the conversion to PDF from javascript.<br>
- Specify a JS startup script that will run before the conversion.<br>
- Hide parts of the web page during the html to pdf conversion.<br>
- Load and modify existing PDF documents.<br>
- Add additional HTML, text, images to PDF (using PdfHtmlElement, PdfTextElement, PdfImageElement objects).<br>
- Get web elements location in PDF.<br>
- Specify the open action of the PDF document (jump to page, run script).<br>
- Custom headers and footers on specific PDF pages.<br>
- Form fields filling.<br>
- PDF portfolios management.<br>
- Resize/scale content of existing PDF documents.<br>
- Extract text from PDF (PDF to Text converter).<br>
- Search for text in PDF.<br>
- Convert PDF pages to images (PDF to Image converter).</p>
