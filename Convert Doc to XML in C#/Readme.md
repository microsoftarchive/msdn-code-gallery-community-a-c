# Convert Doc to XML in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- WPF
- c# control
- Word API
## Topics
- Doc/Docx to XML
- Convert Doc to XML
## Updated
- 11/17/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In some cases, developers have the requirement to convert Doc/Docx to XML. This sample gives a C# solution provided by Spire.Doc for this issue.</span><em>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><strong>Tools we need:</strong><br>
</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small">- Spire.Doc dll (<span style="font-size:20px"><span style="font-size:small">This dll is available in the package attached.</span></span>)<br>
- Visual Studio</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><strong>Prepare the environment</strong></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small">This solution is based on a .NET Word component -
 Spire.Doc, download the package and unzip it, you&rsquo;ll get dll file and sample demo at the same time. Create or open a .NET class application in Visual Studio 2005 or above versions, add Spire.Doc.dll as a reference to your .NET project assemblies, set
 &ldquo;Target framework&rdquo; to &ldquo;.NET Framework 4&rdquo;.</span></span></span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><strong>Namespaces to be used</strong></span></span></span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small">using Spire.Doc;<br>
using Spire.Doc.Documents;</span></span></span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><strong>Code snippet</strong><br>
</span></span></span></span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
        {
            //Create word document
            Document document = new Document();
            document.LoadFromFile(&quot;Sample.doc&quot;);

            //Save doc file.
            document.SaveToFile(&quot;Sample.xml&quot;, FileFormat.Xml);

            //Launching the MS Word file.
            WordDocViewer(&quot;Sample.xml&quot;);
        }
        static void WordDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;word&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Document&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.LoadFromFile(<span class="cs__string">&quot;Sample.doc&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;doc&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.SaveToFile(<span class="cs__string">&quot;Sample.xml&quot;</span>,&nbsp;FileFormat.Xml);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Launching&nbsp;the&nbsp;MS&nbsp;Word&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WordDocViewer(<span class="cs__string">&quot;Sample.xml&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;WordDocViewer(<span class="cs__keyword">string</span>&nbsp;fileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(fileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><strong><span style="font-size:small">Sample Word file for test</span></strong></p>
<p><strong><span style="font-size:small"><img id="129783" src="129783-3.png" alt=""></span></strong></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">Result</span></strong></p>
<p><strong><span style="font-size:small"><img id="129780" src="129780-2.png" alt="" width="679" height="362"><br>
</span></strong></p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p style="text-align:justify"><span style="font-size:small"><strong>Spire.Doc for .NET
</strong>is a professional Word .NET library specially designed for developers to create, read, write, convert and print Word document files from any .NET( C#, VB.NET, ASP.NET) platform with fast and high quality performance. By using Spire.Doc for .NET, users
 can save Word Doc/Docx to stream, save as web response and convert Word Doc/Docx to XML, RTF, EMF, TXT, XPS, EPUB, HTML and vice versa. Spire.Doc for .NET also supports to convert Word Doc/Docx to PDF and HTML to image.</span></p>
<p><strong><span style="font-size:small">Related Links</span></strong></p>
<p><span style="font-size:small">Website:&nbsp;<a href="http://www.e-iceblue.com">http://www.e-iceblue.com</a>&nbsp;</span></p>
<p><span style="font-size:small">Forum: <a href="http://www.e-iceblue.com/forum/spire-doc-f6.html">
Spire.Doc Forum</a></span></p>
<p style="text-align:justify"><span style="font-size:small"><br>
</span></p>
