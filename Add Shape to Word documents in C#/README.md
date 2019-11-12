# Add Shape to Word documents in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Visual C#.NET
## Topics
- Add Shape to Word documents in C#
## Updated
- 12/10/2015
## Description

<h2>Introduction</h2>
<p>This sample shows how to add shape to word documents in C# via a .NET word library-Spire.Doc. Through the code, you'll get clear information about adding shape to word documents in C#.&nbsp;</p>
<p>Spire.Doc for .NET&nbsp;is a professional Word .NET library which enables developers to&nbsp;create, read, write, convert and&nbsp;print Word document files&nbsp;on any .NET( C#, VB.NET, ASP.NET) platform. Using Spire.Doc, you also can add shape to your
 word document in C#.</p>
<p><span>Below is the code snippet:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Document&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Section&nbsp;sec&nbsp;=&nbsp;doc.AddSection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Paragraph&nbsp;para1&nbsp;=&nbsp;sec.AddParagraph();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShapeObject&nbsp;shape1&nbsp;=&nbsp;para1.AppendShape(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;ShapeType.Donut);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShapeObject&nbsp;shape2&nbsp;=&nbsp;para1.AppendShape(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;ShapeType.Cube);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shape2.Left&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShapeObject&nbsp;Shape3&nbsp;=&nbsp;para1.AppendShape(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;ShapeType.Diamond);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shape3.Left&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShapeObject&nbsp;shape4&nbsp;=&nbsp;para1.AppendShape(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;ShapeType.SmileyFace);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shape4.Top&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShapeObject&nbsp;shape5&nbsp;=&nbsp;para1.AppendShape(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;ShapeType.Moon);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shape5.Top&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shape5.Left&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShapeObject&nbsp;Shape6&nbsp;=&nbsp;para1.AppendShape(<span class="cs__number">30</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;ShapeType.LeftArrow);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shape6.Top&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shape6.Left&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.SaveToFile(<span class="cs__string">&quot;AddShape.docx&quot;</span>,&nbsp;FileFormat.Docx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="cs__string">&quot;AddShape.docx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode" style="display:inline!important"><em style="font-size:10px">As an independent Word .NET component, Spire.Doc for .NET doesn't need Microsoft Word to be installed on the machine.</em></div>
<p>Using Spire.Doc, developers can&nbsp;export word documents to other formats like PDF,&nbsp;XML,&nbsp;RTF,&nbsp;TXT,&nbsp;XPS,&nbsp;EPUB,&nbsp;EMF,&nbsp;and HTML. Other functions like&nbsp;<span>Mail merge, security, format (font, paragraph and page settings),
 objects (text, image, hyperlink, comment, table, bookmark, header/footer, footnote/endnote etc. are supported as well.</span></p>
<p>Spire.Doc supports Microsoft Word 97-2003,&nbsp;Microsoft Word&nbsp;2007,&nbsp;Microsoft Word&nbsp;2010,&nbsp;Microsoft Word&nbsp;2013,&nbsp;and C #, VB.NET, ASP.NET and ASP.NET MVC. In addition,&nbsp;Spire.Doc (version 5.5.184) starts to support WordML
 and WordXML.</p>
<p><strong><em>How to Download and Install Spire.Doc</em></strong></p>
<p>Download&nbsp;<a href="http://www.e-iceblue.com/Download/download-word-for-net-now.html">Spire.Doc
</a>(version 5.5.184 for this sample)&nbsp;here and&nbsp;install it to the specified path on your system.&nbsp;There are several folders, which save dlls for different .NET Framework versions under Bin directory. After creating a project, right click project
 name &rarr; Add Reference &rarr; Browse &rarr; Spire.Doc folder &rarr; Bin,&nbsp;choose the corresponding dll according to the Framework used by your project,&nbsp;and then add it to your project as reference.</p>
<p>Welcome to download Spire.Doc to have a free trial.</p>
<p><strong>Related Links:</strong></p>
<p>Website:&nbsp;<a href="http://www.e-iceblue.com/">http://www.e-iceblue.com/</a></p>
<p>Product Home:&nbsp;<a href="http://www.e-iceblue.com/Introduce/word-for-net-introduce.html">http://www.e-iceblue.com/Introduce/word-for-net-introduce.html</a></p>
<p>Download:&nbsp;<a href="http://www.e-iceblue.com/Download/download-word-for-net-now.html">http://www.e-iceblue.com/Download/download-word-for-net-now.html</a></p>
<p>Forum:&nbsp;<a href="http://www.e-iceblue.com/forum/">http://www.e-iceblue.com/forum/</a></p>
