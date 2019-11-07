# Convert from HTML to PDF in ASP.NET Core with a Free 3rd Party Library
## Requires
- Visual Studio 2017
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Microsoft Azure
- .NET Framework
- .NET Core
- ASP.NET Core
- ASP.NET Core MVC
- ASP.NET Core 2.0
- .NET Core 2.0
## Topics
- HTML to PDF
- Html To Pdf Conversion
- Pdf Library
- Html to Pdf for .NET Core
- PDF Library for .NET Core
- Html to Pdf Azure
## Updated
- 05/10/2019
## Description

<p>Converting from html to pdf is not an easy task. There are some tools that can do that, but most of them cost thousands of dollars.</p>
<p>SelectPdf offers a Community Edition (FREE) of the powerful <a title="Html To Pdf Converter for .NET Core" href="https://selectpdf.com/html-to-pdf-converter/">
Html To Pdf Converter for .NET Core</a>&nbsp;that can be found in the full featured pdf library SelectPdf for .NET Core. The free html to pdf converter offers most of the features the professional sdk offers, the most notable limitation is that it can only
 generate pdf documents up to 5 pages long.</p>
<p>The <a title="Free Html To Pdf for .NET" href="http://selectpdf.com/community-edition/">
community edition</a> contains ready to use samples, coded in C# and VB.NET for ASP.NET, MVC and ASP.NET Core 2.0. SelectPdf Html To Pdf Converter for .NET works on any Windows OS and on Windows Azure.</p>
<p><span>SelectPdf Html To Pdf Converter provides versions for .NET Framework and .NET Core 2.0 and above (through .NET Standard 2.0). SelectPdf only works on Windows. SelectPdf works on Azure cloud, including Azure Web Apps (Basic plan or above) with some
 limitations.</span></p>
<h1>Html to Pdf Converter For .NET Core - Community Edition Features</h1>
<ul>
<li>Generate pdf documents up to 5 pages </li><li>Convert any web page to pdf </li><li>Convert any raw html string to pdf </li><li>Set pdf page settings (page size, page orientation, page margins) </li><li>Resize content during conversion to fit the pdf page </li><li>Set pdf document properties </li><li>Set pdf viewer preferences </li><li>Set pdf security (passwords, permissions) </li><li>Set conversion delay and web page navigation timeout </li><li>Custom headers and footers </li><li>Support for html in headers and footers </li><li>Automatic and manual page breaks </li><li>Repeat html table headers on each page </li><li>Support for @media types screen and print </li><li>Support for internal and external links </li><li>Generate bookmarks automatically based on html elements </li><li>Support for HTTP headers </li><li>Support for HTTP cookies </li><li>Support for web pages that require authentication </li><li>Support for proxy servers </li><li>Enable/disable javascript </li><li>Modify color space </li><li>Multithreading support </li><li>HTML5/CSS3 support </li><li>Web fonts support </li></ul>
<h1><span>Building the Sample</span></h1>
<p>The sample project attached presents most of the SelectPdf Html To Pdf Converter Features. A reference to the SelectPdf Html To Pdf for .NET Core was a added as a NuGet Package. Alternatively, the free product can be downloaded from&nbsp;<a title="Free Html To Pdf Converter" href="http://selectpdf.com/community-edition/">http://selectpdf.com/community-edition/</a>.</p>
<p>SelectPdf Free Html To Pdf Converter is very easy to use. Below is a small sample code. A lot more can be found in the sample project attached.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public IActionResult OnPost()
{
    // instantiate a html to pdf converter object
    HtmlToPdf converter = new HtmlToPdf();

    // create a new pdf document converting an url
    PdfDocument doc = converter.ConvertUrl(TxtUrl);

    // save pdf document
    byte[] pdf = doc.Save();

    // close pdf document
    doc.Close();

    // return resulted pdf document
    FileResult fileResult = new FileContentResult(pdf, &quot;application/pdf&quot;);
    fileResult.FileDownloadName = &quot;Document.pdf&quot;;
    return fileResult;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;OnPost()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;instantiate&nbsp;a&nbsp;html&nbsp;to&nbsp;pdf&nbsp;converter&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HtmlToPdf&nbsp;converter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdf();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;a&nbsp;new&nbsp;pdf&nbsp;document&nbsp;converting&nbsp;an&nbsp;url</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;doc&nbsp;=&nbsp;converter.ConvertUrl(TxtUrl);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;save&nbsp;pdf&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;pdf&nbsp;=&nbsp;doc.Save();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;close&nbsp;pdf&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;doc.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;return&nbsp;resulted&nbsp;pdf&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FileResult&nbsp;fileResult&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileContentResult(pdf,&nbsp;<span class="cs__string">&quot;application/pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fileResult.FileDownloadName&nbsp;=&nbsp;<span class="cs__string">&quot;Document.pdf&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;fileResult;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small">ASP.NET Sample available here:&nbsp;<a href="https://code.msdn.microsoft.com/Convert-from-HTML-to-PDF-09ce2a1d">https://code.msdn.microsoft.com/Convert-from-HTML-to-PDF-09ce2a1d</a></span></p>
<p><span style="font-size:small">ASP.NET MVC Sample available here:&nbsp;<a href="https://code.msdn.microsoft.com/Free-Html-To-Pdf-Converter-04e4438e">https://code.msdn.microsoft.com/Free-Html-To-Pdf-Converter-04e4438e</a></span></p>
<p><span style="font-size:small"><br>
</span></p>
<h1>IMPORTANT</h1>
<p>This Community Edition of SelectPdf IS NOT THE FREE TRIAL for SelectPdf Commercial Library. This is a FREE product with
<strong>limited functionality</strong>. If you want to try the full featured SelectPdf Library, download a free trial version from here:
<a title="Html To Pdf Converter for .NET Core" href="https://selectpdf.com/pdf-library-for-net/" target="_blank">
https://selectpdf.com/pdf-library-for-net/</a></p>
<p>The following features are not part of the free community edition. To use any of these features you need the full
<strong>commercial</strong> <a title="SelectPdf Library for .NET Core" href="https://selectpdf.com/pdf-library-for-net/" target="_blank">
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
