# C#.NET Convert Word/Excel/Html/Rtf to PDF in Winforms and ASP.NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Office
- Visual Studio 2008
- .NET
- Class Library
- Windows Forms
- WPF
- Visual Studio 2010
- .NET Framework 4
- .NET Framework
- VB.Net
- .NET Framework 4.0
- Office 2010
- Visual Studio 2012
- Visual Studio 2013
- .NET 4.5
- Visual Studio 2015
## Topics
- How to
- Document Conversion
- HTML to PDF
- excel to pdf
- Convert Word to PDF
- RTF to PDF
## Updated
- 11/05/2018
## Description

<h1><strong>How to Convert Word, Excel, Html, Rtf document to PDF in C#/VB.NET&nbsp;</strong></h1>
<p>iDiTect.Converter .NET <span>library is a mature and effective document converting utility. Using this PDF converting control, .NET developers can quickly convert Word/Excel/Html/Rtf file to PDF document using Visual C# code.&nbsp;</span></p>
<p><span>The most outstanding feature of this PDF converting toolkit is its industry-leading converting accuracy. The PDF file, converted by iDiTect.Converter toolkit, preserves the structure &amp; layout of target Word/Excel/Html/Rtf document, keeps the elements
 (like images, tables and chats) of original file and maintains the original text style (including font, size, color, links and boldness).</span></p>
<p>Please Note: the sample can be run in .NET framework 4.0&#43;, x86 and x64. You can&nbsp;<strong>download the free full trial .NET Convert Word/Excel/Html/Rtf to PDF SDK</strong>&nbsp;<a href="https://www.iditect.com/download/iDiTect.Converter.Trial.zip">here</a>.</p>
<h2><strong>Support Document Format</strong></h2>
<ul>
<li><a href="https://www.iditect.com/tutorial/docx-to-pdf/">Convert Word (.docx) to PDF in C#</a>,&nbsp;convert multi-page Word&nbsp;document to multi-page PDF file
</li><li><a href="https://www.iditect.com/tutorial/xlsx-to-pdf/">Convert Excel (.xlsx) to PDF in C#</a>, convert active worksheet, whole workbook or selected ranges to PDF file
</li><li><a href="https://www.iditect.com/tutorial/html-to-pdf/">Convert Html to PDF in C#</a>, convert entire html file or part html elements to PDF file, external css and images supported
</li><li><a href="https://www.iditect.com/tutorial/rtf-to-pdf/">Convert Rtf to PDF in C#</a>
</li></ul>
<h2><strong>C# Code Example</strong></h2>
<p><span>This is a C# programming example for converting Word (.docx) to PDF file.</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">DocxToPdfConverter&nbsp;converter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocxToPdfConverter();&nbsp;
&nbsp;
converter.Load(File.ReadAllBytes(<span class="cs__string">&quot;sample.docx&quot;</span>));&nbsp;
&nbsp;
File.WriteAllBytes(<span class="cs__string">&quot;convert.pdf&quot;</span>,&nbsp;converter.SaveAsBytes());</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="endscriptcode"><span>Following is C#.NET demo code for Excel (.xlsx) to PDF conversion.</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">XlsxToPdfConverter&nbsp;converter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XlsxToPdfConverter();&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;(Stream&nbsp;stream&nbsp;=&nbsp;File.OpenRead(<span class="cs__string">&quot;sample.xlsx&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;converter.Load(stream);&nbsp;
}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
converter.ContentPart&nbsp;=&nbsp;PdfContentPart.FromActiveSheet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;(var&nbsp;stream&nbsp;=&nbsp;File.OpenWrite(<span class="cs__string">&quot;convert.pdf&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;converter.Save(stream);&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<div class="endscriptcode"><span>This is a C# programming example for converting HTML to PDF.</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">HtmlToPdfConverter&nbsp;converter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdfConverter();&nbsp;
&nbsp;
converter.DefaultStyleSheet&nbsp;=&nbsp;<span class="cs__string">&quot;.para{font-size:&nbsp;24px;&nbsp;color:&nbsp;#FF0000;}&quot;</span>;&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;htmlContent&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;p&nbsp;class=\&quot;para\&quot;&gt;Content&nbsp;with&nbsp;special&nbsp;style.&lt;/p&gt;&lt;p&gt;Content&nbsp;without&nbsp;style&lt;/p&gt;&quot;</span>;&nbsp;
converter.Load(htmlContent);&nbsp;
&nbsp;
File.WriteAllBytes(<span class="cs__string">&quot;convert.pdf&quot;</span>,&nbsp;converter.SaveAsBytes());</pre>
</div>
</div>
</div>
</span></div>
<div class="endscriptcode">&nbsp;</div>
<h3><strong>Related Links</strong></h3>
<ul>
<li>iDiTect website provides&nbsp;Professional .NET SDK for editing PDF, Word, Excel&nbsp;<a href="https://www.iditect.com/">https://www.iditect.com</a>
</li><li>iDiTect.Converter .NET SDK allows C#/VB.NET developers to convert PDF, Word, Excel, Image, Html, Csv, Rtf and Text&nbsp;<a href="https://www.iditect.com/product/converter/">https://www.iditect.com/product/converter/</a>
</li></ul>
<p><em>Support Email:&nbsp;</em><a href="mailto:support@iditect.com"><em>support@iditect.com</em></a></p>
