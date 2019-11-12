# C# How to add, modify and delete bookmark in PDF
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- .NET
- Class Library
- PDF API
## Topics
- C#
- .Net Programming
- c# control
- bookmark in PDF
## Updated
- 02/08/2018
## Description

<h1><span style="color:#008000">Introduction</span></h1>
<p>The bookmark function in the files provides a good convenience to us to locate the special paragraph. We can freely edit the bookmark in the document according to our needs. This sample is aimed to show you how to add、modify and delete the bookmark in PDF
 document with component Free Spire.PDF for .NET in C#. You should download and install the component first and add the Spire.PDF.dll file to the project as a reference and add the using directives as well. The further detail has been given below.</p>
<p><strong>Tools we need</strong></p>
<ul>
<li>Free Spire.PDF for .NET </li><li>Visual Studio </li></ul>
<p><span style="color:#008000; font-size:medium"><strong>1.How to add bookmark</strong><strong>？</strong></span></p>
<p><span style="color:#008000; font-size:small"><strong>&nbsp; &nbsp; 1.1 Create a new document and add bookmark</strong></span></p>
<p><strong>Step 1</strong>: Add name space as blow</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Bookmarks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.General;&nbsp;
</pre>
</div>
</div>
</div>
<ul>
</ul>
<p><strong>Step 2: </strong>Main code snippets</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Create&nbsp;an&nbsp;object&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;add&nbsp;page&nbsp;to&nbsp;the&nbsp;document</span>&nbsp;
PdfDocument&nbsp;pdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
PdfPageBase&nbsp;page&nbsp;=&nbsp;pdf.Pages.Add();&nbsp;
&nbsp;
<span class="cs__com">//Add&nbsp;bookmark&nbsp;to&nbsp;the&nbsp;appointed&nbsp;location&nbsp;in&nbsp;the&nbsp;page</span>&nbsp;
PdfBookmark&nbsp;bookmark&nbsp;=&nbsp;pdf.Bookmarks.Add(<span class="cs__string">&quot;Introduction:&quot;</span>);&nbsp;
bookmark.Destination&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDestination(page);&nbsp;
bookmark.Destination.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointF(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;bookmark&nbsp;font&nbsp;style&nbsp;and&nbsp;color</span>&nbsp;
bookmark.DisplayStyle&nbsp;=&nbsp;PdfTextStyle.Bold;&nbsp;
bookmark.Color&nbsp;=&nbsp;Color.SeaGreen;&nbsp;
&nbsp;
<span class="cs__com">//Add&nbsp;childbookmark&nbsp;to&nbsp;the&nbsp;appointed&nbsp;location&nbsp;in&nbsp;the&nbsp;page</span>&nbsp;
PdfBookmark&nbsp;childBookmark&nbsp;=&nbsp;bookmark.Insert(<span class="cs__number">0</span>,&nbsp;<span class="cs__string">&quot;PREFACE&quot;</span>);&nbsp;
childBookmark.Destination&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDestination(page);&nbsp;
childBookmark.Destination.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointF(<span class="cs__number">400</span>,&nbsp;<span class="cs__number">300</span>);&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;childbookmark&nbsp;font&nbsp;style&nbsp;and&nbsp;color</span>&nbsp;
childBookmark.DisplayStyle&nbsp;=&nbsp;PdfTextStyle.Regular;&nbsp;
childBookmark.Color&nbsp;=&nbsp;Color.Black;&nbsp;
&nbsp;
<span class="cs__com">//Save&nbsp;to&nbsp;file&nbsp;and&nbsp;open&nbsp;the&nbsp;document</span>&nbsp;
pdf.SaveToFile(<span class="cs__string">&quot;Bookmark.pdf&quot;</span>);&nbsp;
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="cs__string">&quot;Bookmark.pdf&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<p>Run the program and generate the document.</p>
<p><strong>Screenshot:</strong></p>
<p><img id="185012" src="185012-11.png" alt="" width="296" height="274"></p>
<p>&nbsp;</p>
<p><span style="color:#008000; font-size:small"><strong>1.2 Add bookmark to the existing document</strong></span></p>
<p><strong>&nbsp;Step 1:</strong> Add name space as blow</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Bookmarks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.General;&nbsp;</pre>
</div>
</div>
</div>
<p><strong>Step 2: </strong>Main code snippets</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Initialize&nbsp;an&nbsp;instance&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;PDF&nbsp;file</span>&nbsp;
PdfDocument&nbsp;pdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
pdf.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;</span>);&nbsp;
<span class="cs__com">//Traverse&nbsp;all&nbsp;pages</span><span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;pdf.Pages.Count;&nbsp;i&#43;&#43;)&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__com">//Add&nbsp;bookmark&nbsp;to&nbsp;the&nbsp;appointed&nbsp;location&nbsp;in&nbsp;the&nbsp;page</span>&nbsp;
PdfBookmark&nbsp;bookmark&nbsp;=&nbsp;pdf.Bookmarks.Add(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Chaper{0}&quot;</span>,&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__number">1</span>));&nbsp;
bookmark.Destination&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDestination(pdf.Pages[i]);&nbsp;
bookmark.Destination.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointF(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;bookmark&nbsp;font&nbsp;style&nbsp;and&nbsp;color</span>&nbsp;
bookmark.DisplayStyle&nbsp;=&nbsp;PdfTextStyle.Bold;&nbsp;
bookmark.Color&nbsp;=&nbsp;Color.Black;&nbsp;
}&nbsp;
<span class="cs__com">//Save&nbsp;to&nbsp;file&nbsp;and&nbsp;open&nbsp;the&nbsp;document</span>&nbsp;
pdf.SaveToFile(<span class="cs__string">&quot;Bookmark1.pdf&quot;</span>);&nbsp;
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="cs__string">&quot;Bookmark1.pdf&quot;</span>);&nbsp;</pre>
</div>
</div>
</div>
<p>Run the program and generate the document</p>
<p><strong>Screenshot:</strong></p>
<p><img id="185015" src="185015-12.png" alt="" width="1197" height="250"></p>
<p><span style="color:#008000; font-size:medium"><strong>2. How to modify the bookmark in PDF?</strong></span></p>
<p><strong>Step1: </strong>Add name space as blow</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Bookmarks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.General;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;</pre>
</div>
</div>
</div>
<p><strong>Step2:</strong> Main code snippets</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Initialize&nbsp;an&nbsp;instance&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;PDF&nbsp;file</span>&nbsp;
PdfDocument&nbsp;pdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
pdf.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\Bookmark.pdf&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//Get&nbsp;the&nbsp;first&nbsp;bookmark&nbsp;</span>&nbsp;
PdfBookmarkCollection&nbsp;bookmarks&nbsp;=&nbsp;pdf.Bookmarks;&nbsp;
PdfBookmark&nbsp;childbookmark&nbsp;=&nbsp;bookmarks[<span class="cs__number">0</span>];&nbsp;
&nbsp;
<span class="cs__com">//Modify&nbsp;the&nbsp;bookmark&nbsp;font&nbsp;and&nbsp;color&nbsp;in&nbsp;the&nbsp;appointed&nbsp;bookmark&nbsp;of&nbsp;the&nbsp;page</span>&nbsp;
childbookmark.Destination&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDestination(pdf.Pages[<span class="cs__number">1</span>]);&nbsp;
childbookmark.DisplayStyle&nbsp;=&nbsp;PdfTextStyle.Bold;&nbsp;
childbookmark.Color&nbsp;=&nbsp;Color.Brown;&nbsp;
<span class="cs__com">//Modify&nbsp;the&nbsp;title&nbsp;of&nbsp;bookmark</span>&nbsp;
childbookmark.Title&nbsp;=&nbsp;<span class="cs__string">&quot;CHAPER&nbsp;Ⅰ&quot;</span>;&nbsp;
&nbsp;
<span class="cs__com">//Save&nbsp;to&nbsp;file&nbsp;and&nbsp;open&nbsp;the&nbsp;document</span>&nbsp;
pdf.SaveToFile(<span class="cs__string">&quot;ModifyBookmark.pdf&quot;</span>);&nbsp;
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="cs__string">&quot;ModifyBookmark.pdf&quot;</span>);&nbsp;</pre>
</div>
</div>
</div>
<p><strong>Screenshot:</strong></p>
<p><img id="185016" src="185016-13.png" alt="" width="273" height="314"></p>
<p><span style="color:#008000; font-size:medium"><strong>3. How to delete the bookmarks in PDF?</strong></span></p>
<p><strong>Full code:</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Bookmarks;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RemoveBookmark_PDF&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;an&nbsp;instance&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;PDF&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;pdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdf.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\Bookmark1.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;all&nbsp;bookmarks&nbsp;and&nbsp;remove&nbsp;the&nbsp;first&nbsp;one</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfBookmarkCollection&nbsp;bookmarks&nbsp;=&nbsp;pdf.Bookmarks;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bookmarks.RemoveAt(<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;to&nbsp;file&nbsp;and&nbsp;open&nbsp;the&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdf.SaveToFile(<span class="cs__string">&quot;DemoveBookmark.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="cs__string">&quot;DemoveBookmark.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p>Run the program and the bookmarks in the PDF has been removed.</p>
<p>&nbsp;</p>
<h1><span style="color:#008000">More Information</span></h1>
<p><strong>Spire.PDF for .NET</strong> is a professional PDF component applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET application.</p>
<p>Many rich features can be supported by the .NET PDF API, such as security setting (including digital signature), PDF text/attachment/image extract, PDF merge/split, metadata update, section, graph/image drawing and inserting, table creation and processing,
 and importing data etc. Besides, Spire.PDF for .NET can be applied to easily converting Text, Image and HTML to PDF with C#/VB.NET in high quality.</p>
<p><span style="color:#000000; font-size:small"><strong>Related links</strong></span></p>
<p>Website: <a href="https://www.e-iceblue.com/">https://www.e-iceblue.com/</a></p>
<p>Download: <a href="https://www.e-iceblue.com/Download/download-pdf-for-net-free.html">
https://www.e-iceblue.com/Download/download-pdf-for-net-free.html</a></p>
