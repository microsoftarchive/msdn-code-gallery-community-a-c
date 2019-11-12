# Convert PDF to image in C# with NReco.PdfRenderer
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
- .NET Framework 4.5
## Topics
- Convert PDF to Image
- PDF to Tiff
- PDF to Png
- PDF rasterizer
- PDF to jpg
- Convert PDF page to Jpeg
## Updated
- 02/23/2017
## Description

<p><span style="font-size:small">PDF is a popular format for books, articles and various reports. In some cases PDF should be rendered to image from C# code, some typical situations:</span></p>
<ul>
<li><span style="font-size:small">produce preview of PDF documents in ASP.NET application</span>
</li><li><span style="font-size:small">embed PDF viewer into ASP.NET app (possibly with watermaking of PDF rendering result) or .NET desktop application without external dependencies (say, Acrobat Reader or GhostScript).</span>
</li></ul>
<p><span style="font-size:small"><a href="https://www.nrecosite.com/pdf_to_image_renderer_net.aspx">NReco.PdfRenderer</a> provides fast and inexpensive way of rendering PDF to images (png, jpg, tiff) from C# code. It provides simple API and internally uses
 poppler tools (free and open-source PDF rendering library), all necessary binaries are embedded into PdfRenderer assembly and extracted on first use.&nbsp;</span></p>
<h1><span>Render PDF to image</span></h1>
<p><span style="font-size:small">The following C# code snippet illustrates how to render PDF page to image:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;pdfToImg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NReco.PdfRenderer.PdfToImageConverter();&nbsp;
pdfToImg.GenerateImage(&nbsp;<span class="cs__string">&quot;sample.PDF&quot;</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;
&nbsp;&nbsp;ImageFormat.Jpeg,&nbsp;<span class="cs__string">&quot;Sample1.jpg&quot;</span>&nbsp;);&nbsp;
&nbsp;
Image&nbsp;firstPageImg&nbsp;=&nbsp;pdfToImg.GenerateImage(<span class="cs__string">&quot;sample.PDF&quot;</span>,&nbsp;<span class="cs__number">1</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">It is possible to change rendering DPI (affects image dimensions) by setting &quot;Dpi&quot; or &quot;ScaleTo&quot; properies (in last case DPI will be calculated automatically to match specified width / height limitation).</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<h1>PDF Viewer Sample</h1>
<p><span style="font-size:small">Sample implements simple ASP.NET PDF viewer: PDF file is located on the server side, but user can view it as images produced by PdfRenderer:</span></p>
<p><img id="169949" src="169949-pdfrenderer_demo.jpg" alt="" width="70%"></p>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<ul>
<li><span style="font-size:small"><a href="https://www.nrecosite.com/pdf_to_image_renderer_net.aspx">NReco PdfRenderer website</a> (more examples, online demo)&nbsp;</span>
</li></ul>
