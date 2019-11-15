# Add a text watermark on PDF in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- WPF
- c# control
## Topics
- Add watermark on PDF
- Text watermark on PDF
- create watermark on PDF in C#
## Updated
- 10/14/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This sample shows how to add text watermark on every PDF pages in a document using free Spire.PDF with C#.</span><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small">This solution is based on a .NET PDF component - free Spire.PDF, download the package and unzip it, you&rsquo;ll get dll file and sample demo at the same time. Create or
 open a .NET class application in Visual Studio 2005 or above versions, add Spire.Pdf.dll as a reference to your .NET project assemblies, set &ldquo;Target framework&rdquo; to &ldquo;.NET Framework 4&rdquo;, then you&rsquo;re able to create text watermark on
 PDF using this sample code.</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><strong>Tools We Need:</strong><br>
</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small">- Free Spire.PDF (This dll is available in the package attached.)<br>
- Visual Studio</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:small"><strong>Detailed Steps:</strong></span></span></span><span style="font-size:20px"><span style="font-size:small"><span style="font-size:small">
</span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:small">STEP 1. Create an instance of Spire.PDF.Document and Load the file base on a specified file path.</span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;PdfDocument&nbsp;doc&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;doc.LoadFromFile(@<span class="js__string">&quot;..\..\Sample1.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<p style="text-align:justify"><span style="font-size:small">STEP 2. Add a text watermark on all PDF pages and format the text.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;foreach&nbsp;(PdfPageBase&nbsp;page&nbsp;<span class="js__operator">in</span>&nbsp;doc.Pages)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfTilingBrush&nbsp;brush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfTilingBrush(<span class="js__operator">new</span>&nbsp;SizeF(page.Canvas.ClientSize.Width&nbsp;/&nbsp;<span class="js__num">2</span>,&nbsp;page.Canvas.ClientSize.Height&nbsp;/&nbsp;<span class="js__num">3</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.SetTransparency(<span class="js__num">0</span>.3f);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.Save();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.TranslateTransform(brush.Size.Width&nbsp;/&nbsp;<span class="js__num">2</span>,&nbsp;brush.Size.Height&nbsp;/&nbsp;<span class="js__num">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.RotateTransform(-<span class="js__num">45</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.DrawString(<span class="js__string">&quot;MSDN&nbsp;Samples&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;PdfFont(PdfFontFamily.Helvetica,&nbsp;<span class="js__num">24</span>),&nbsp;PdfBrushes.Violet,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;PdfStringFormat(PdfTextAlignment.Center));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.Restore();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush.Graphics.SetTransparency(<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page.Canvas.DrawRectangle(brush,&nbsp;<span class="js__operator">new</span>&nbsp;RectangleF(<span class="js__operator">new</span>&nbsp;PointF(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>),&nbsp;page.Canvas.ClientSize));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p style="text-align:justify"><span style="font-size:small">STEP 3. Save the file.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">doc.SaveToFile(<span class="js__string">&quot;TextWaterMark.pdf&quot;</span>);&nbsp;</pre>
</div>
</div>
</div>
<p style="text-align:justify"><span style="font-size:small"><strong>Output:</strong></span></p>
<p style="text-align:justify"><span style="font-size:small"><strong><img id="127011" src="https://i1.code.msdn.s-msft.com/add-a-text-watermark-on-e56799cf/image/file/127011/1/2.png" alt="" width="569" height="292"></strong></span></p>
<h1>More Information</h1>
<p style="text-align:justify"><span style="font-size:10pt"><span>Spire.PDF is a PDF component which contains an incredible wealth of features to create, read, edit and manipulate PDF documents on .NET, Silverlight and WPF Platform. As an independent PDF library,
 it does not need users to install Adobe Acrobat or any other third party libraries. Spire.PDF for .NET is completely written in C#, but also supports VB.NET, Windows Forms and ASP.NET Applications.</span></span></p>
<p style="text-align:justify"><span style="font-size:small"><strong>Related Links:</strong></span></p>
<p><span style="font-size:10pt">Website: </span><a href="http://www.e-iceblue.com"><span style="font-size:10pt">www.e-iceblue.com</span></a></p>
<p><span style="font-size:10pt">Free Trial: <a title="Download Spire.PDF for .NET" href="http://www.e-iceblue.com/Download/download-pdf-for-net-now.html" target="_self">
Download Spire.PDF for .NET</a></span><a title="Download Spire.PDF for .NET" href="http://www.e-iceblue.com/Download/download-pdf-for-net-now.html" target="_self"><span style="font-size:12pt">&nbsp;</span></a></p>
<p><span style="font-size:10pt">Forum: </span><span style="font-size:10pt"><a href="http://www.e-iceblue.com/forum/spire-pdf-f7.html"><span style="font-size:10pt">Spire.PDF for .NET Forum</span></a></span></p>
<p><span style="font-size:10pt"><span style="font-size:10pt">Demos: <a title="Spire.PDF Demos" href="http://www.e-iceblue.com/Knowledgebase/Spire.PDF/Demos.html" target="_self">
Spire.PDF Demos</a></span></span></p>
