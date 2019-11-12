# C# How to compress PDF images
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- .NET
- Class Library
- VB.Net
- Visual Studio 2013
- PDF API
## Topics
- C#
- Class Library
- Code Sample
- .NET 4
- How to
- Language Samples
- PDF API
## Updated
- 02/27/2018
## Description

<p><strong>Introduction</strong></p>
<p>In this sample, the component Spire.PDF3.9.462 is applied to the project. You need to download and install this version (or above version) of the component, and add the dll from the file into project assemblies as a reference. The code steps below can offer
 you the information of coding.</p>
<p>&nbsp;</p>
<p><strong>Method 1</strong></p>
<p>STEP1: Add using directives.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Graphics;&nbsp;
</pre>
</div>
</div>
</div>
<p>STEP2: Create an object of PdfDocument class and load the PDF from file.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">PdfDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\Input.pdf&quot;</span>);</pre>
</div>
</div>
</div>
</h1>
<p>STEP3: Disable incremental update.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">doc.FileInfo.IncrementalUpdate&nbsp;=&nbsp;<span class="cs__keyword">false</span>;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>STEP4: Traverse all pages of PDF and diagnose whether the images are contained or not. Call the TryCompressImage() method to compress the images in PDF.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">foreach</span>&nbsp;(PdfPageBase&nbsp;page&nbsp;<span class="cs__keyword">in</span>&nbsp;doc.Pages)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(page&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(page.ImagesInfo&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(PdfImageInfo&nbsp;info&nbsp;<span class="cs__keyword">in</span>&nbsp;page.ImagesInfo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page.TryCompressImage(info.Index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>STEP5: Save to file</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">doc.SaveToFile(<span class="cs__string">&quot;Output.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Method 2</strong></p>
<p>STEP1: Add using directives.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Graphics;&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>STEP2: Create an object of PdfDocument class and load the PDF from file.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">PdfDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\Input.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>STEP3: Disable incremental update.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">doc.FileInfo.IncrementalUpdate&nbsp;=&nbsp;<span class="cs__keyword">false</span>;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>STEP4: Traverse all PDF pages. Extract and traverse all images, set bp.Quality values to compress images. And replace the images with newly compressed images.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">foreach</span>&nbsp;(PdfPageBase&nbsp;page&nbsp;<span class="cs__keyword">in</span>&nbsp;doc.Pages)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Image[]&nbsp;images&nbsp;=&nbsp;page.ExtractImages();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(images&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;images.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;images.Length;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;image&nbsp;=&nbsp;images[j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfBitmap&nbsp;bp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfBitmap(image);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bp.Quality&nbsp;=&nbsp;<span class="cs__number">20</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page.ReplaceImage(j,&nbsp;bp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>STEP5: Save to file</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">doc.SaveToFile(<span class="cs__string">&quot;Output2.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Useful information</strong></p>
<p><strong>Spire.PDF for .NET</strong> is a professional PDF component applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET application.</p>
<p>Many rich features can be supported by the .NET PDF API, such as security setting (including digital signature), PDF text/attachment/image extract, PDF merge/split, metadata update, section, graph/image drawing and inserting, table creation and processing,
 and importing data etc. Besides, Spire.PDF for .NET can be applied to easily converting Text, Image and HTML to PDF with C#/VB.NET in high quality.&nbsp;</p>
<p><strong>Related links</strong></p>
<p>Website: <a href="https://www.e-iceblue.com/">https://www.e-iceblue.com/</a></p>
<p>Download: <a href="https://www.e-iceblue.com/Download/download-pdf-for-net-now.html">
https://www.e-iceblue.com/Download/download-pdf-for-net-now.html</a></p>
