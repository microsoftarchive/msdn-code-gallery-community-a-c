# C# Convert PDF to Image .NET PDF Converter Library
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Studio 2005 SDK
- ASP.NET
- Visual Studio 2008
- .NET
- Class Library
- Windows Forms
- Console Application
- Windows SDK
- .NET Framework
- Visual Basic .NET
- VB.Net
- Library
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- .NET Development
- Visual Studio 2015
- Visual Studio 2017
## Topics
- How to
- PDF
- .NET PDF
- C# PDF
- PDF Convert
- Convert PDF to Image
- PDF to Jpeg
- PDF to Tiff
- PDF to Png
- PDF to Gif
- PDF to Bmp
- Pdf Library
- PDF to jpg
- PDF to multi-page tiff
- Convert PDF page to Jpeg
- Convert PDF page to Tiff
- .NET PDF library
## Updated
- 03/06/2019
## Description

<h1><strong>C# How to Convert PDF to Image with Free Trial</strong><strong>&nbsp;</strong></h1>
<p class="p">How to convert <strong>PDF to JPG/JPEG/T</strong><strong>IFF</strong><strong>/PNG/BMP/GIF</strong>&nbsp;images using C#.NET using .NET PDF to Image Converter Library.</p>
<p class="p"><span style="color:#ff0000"><strong>Note:&nbsp;</strong></span><strong style="color:#ff0000">please rename the downloaded zip file if you cannot run the project.
</strong><span style="color:#000000">For example, unzip and name it as &quot;Demo&quot;. Or you can directly
<a title="CnetSDK .NET PDF to Image SDK Free Trial" href="https://storage.googleapis.com/wzukusers/user-29892693/documents/5c5955c7816803tndfSy/CnetSDK.PDFtoImage.Converter.Trial.zip" target="_blank">
download the full &amp; free trial package here</a> and test more.</span></p>
<p class="p">&nbsp;</p>
<h2 class="p"><span style="color:#333399"><strong>Requirement</strong></span><strong>&nbsp;</strong></h2>
<p class="p">CnetSDK C# .NET PDF to Image Converter SDK is compatible with .NET Framework 2.0&#43;, Visual Studio 2005&#43;, Windows XP&#43;, and x86 &amp; x64 systems.</p>
<p><br>
<strong>Please Note</strong></p>
<p>The demo provided here is for .NET Framework 4.0, x86&nbsp;and x64. Certainly, CnetSDK full free trial package contains all dll libraries for .NET Framework 2.0&nbsp;and above versions, x86 and x64. You may find and download the full trial from any of the
 following links.</p>
<p class="p">&nbsp;</p>
<h2 class="p"><span style="color:#333399"><strong>Description</strong></span></h2>
<p class="p">Are you looking for a C# PDF to image converter library for .NET applications development? CnetSDK .NET PDF to Image Converter SDK&nbsp;is a totally standalone PDF to image converter library for .NET, C#, VB.NET, ASP.NET projects. It works independently
 that does not require Adobe Acrobat or any other 3rd party PDF software or libraries installed on your system.</p>
<p class="p">You can easily integrate this C# PDF to image conversion library to your Visual Studio .NET windows and&nbsp;<a title="ASP.NET PDF to Image Conversion for Web Projects" href="http://www.cnetsdk.com/aspnet-pdf-to-image-converter"><span style="text-decoration:underline">ASP.NET
 web projects</span></a>&nbsp;by simply adding the reference to the dll library. It grants&nbsp;<a title="Tutorial C# Convert PDF to Images" href="http://www.cnetsdk.com/net-pdf-to-image-converter-csharp-sample-code"><span style="text-decoration:underline">high-quality
 C# PDF to images conversion</span></a>, including:</p>
<ul>
</ul>
<ul>
<li><a title="C# Convert PDF to JPG Image" href="http://www.cnetsdk.com/net-pdf-to-image-converter-convert-pdf-to-jpeg"><span style="text-decoration:underline">C# convert PDF to jpg/jpeg images</span></a>
</li><li>C#&nbsp;convert PDF to tiff images </li><li>C# convert PDF to png images </li><li>C# convert PDF to bmp images </li><li>C# convert PDF to gif images </li><li>C# convert PDF file to multi-page tiff image file </li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">PdfFile&nbsp;PDFtoImageConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfFile();&nbsp;
PDFtoImageConverter.LoadPdfFile(filename);&nbsp;
<span class="cs__keyword">int</span>&nbsp;Count&nbsp;=&nbsp;PDFtoImageConverter.FilePageCount;&nbsp;
PDFtoImageConverter.SetDPI&nbsp;=&nbsp;<span class="cs__number">150</span>;&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp&nbsp;=&nbsp;PDFtoImageConverter.ConvertToImage(i,&nbsp;<span class="cs__number">768</span>,&nbsp;<span class="cs__number">1024</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp.Save(<span class="cs__string">&quot;E:/CnetSDK&quot;</span>&nbsp;&#43;&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.jpeg&quot;</span>,&nbsp;ImageFormat.Jpeg);&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p class="p">The above C# sample code illustrates how to convert PDF to JPG/JPEG image with a defined output image size. Certainly, you can keep the original size of PDF document page and convert each PDF page to JPG/JPEG image.</p>
<p class="p">&nbsp;</p>
<h1><strong>More Information</strong><strong>&nbsp;</strong></h1>
<p class="p">Click to learn more.</p>
<ul>
<li><a title="CnetSDK .NET Library for PDF to Image Conversion in C#" href="http://www.cnetsdk.com/net-pdf-to-image-converter-sdk"><span style="text-decoration:underline">See CnetSDK .NET PDF to Image Converter SDK</span></a>
</li><li><a title="Provides .NET SDKs for PDF, Barcode, OCR, Excel, etc." href="http://www.cnetsdk.com/"><span style="text-decoration:underline">See more PDF products on CnetSDK website</span></a>
</li></ul>
<p>Support Email: <a title="CnetSDK Support Team" href="mailto:support@cnetsdk.com" target="_blank">
support@cnetsdk.com</a></p>
