# Convert Excel to HTML with Formatting in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- WPF
## Topics
- Controls
- C#
- XLS to HTML
- Convert Excel with image to HTML
- Excel reference
## Updated
- 08/21/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">If you created a pretty Excel table and now want to publish it online as a web page, the simplest way is to export it to an old good HTML file. This sample is aimed to deliver a C# solution to convert Excel to HTML with its
 original layout.</span></p>
<p style="text-align:justify"><span style="font-size:small">This solution is based on a .NET Excel component which is available on CodePlex (<a href="http://spreadsheet.codeplex.com/">http://spreadsheet.codeplex.com/</a>), download the package and unzip it,
 you&rsquo;ll get .dll file and sample demo &amp; code at the same time. Create or open a .NET class application in Visual Studio 2005 or above versions, add Spire.XLS.dll as a reference to your .NET project assemblies, set &ldquo;Target framework&rdquo; to
 &ldquo;.NET Framework 4&rdquo;, then you&rsquo;re able to convert Excel file to HTML page with sample code below.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace ExceltoHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            //load Excel file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@&quot;Book1.xlsx&quot;);

            //convert Excel to HTML
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToHtml(&quot;sample.html&quot;);

            //Preview HTML
            System.Diagnostics.Process.Start(&quot;sample.html&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ExceltoHTML&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//load&nbsp;Excel&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(@<span class="cs__string">&quot;Book1.xlsx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//convert&nbsp;Excel&nbsp;to&nbsp;HTML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;sheet&nbsp;=&nbsp;workbook.Worksheets[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToHtml(<span class="cs__string">&quot;sample.html&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Preview&nbsp;HTML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;sample.html&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small"><strong>Screenshot of Output</strong></span></p>
<p><span style="font-size:small"><strong><img id="124146" src="124146-embed_image_2.png" alt="" width="578" height="403"></strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Note:</strong></span></p>
<p><span style="font-size:small">While using this method to generate HTML page from Excel, a supporting folder will be generated to hold the images that are embedded in the Excel table. If you don&rsquo;t want such a supporting folder due to any reason, you
 can embed the images into HTML code when converting Excel to HTML using following code:</span></p>
<p><span style="font-size:small"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace ExceltoHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            // create Workbook instance and load file
            Workbook book = new Workbook();
            book.LoadFromFile(&quot;Book1.xlsx&quot;);

           // embed image into html when converting
            HTMLOptions options = new HTMLOptions();
            options.ImageEmbedded = true; 

            // save the sheet to html
            book.Worksheets[0].SaveToHtml(&quot;sample.html&quot;, options);
            System.Diagnostics.Process.Start(&quot;sample.html&quot;); 

         
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ExceltoHTML&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;Workbook&nbsp;instance&nbsp;and&nbsp;load&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;book&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;book.LoadFromFile(<span class="cs__string">&quot;Book1.xlsx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;embed&nbsp;image&nbsp;into&nbsp;html&nbsp;when&nbsp;converting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HTMLOptions&nbsp;options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HTMLOptions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.ImageEmbedded&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;save&nbsp;the&nbsp;sheet&nbsp;to&nbsp;html</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;book.Worksheets[<span class="cs__number">0</span>].SaveToHtml(<span class="cs__string">&quot;sample.html&quot;</span>,&nbsp;options);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;sample.html&quot;</span>);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</span>
<p></p>
<p><span style="font-size:small">After running the code, you&rsquo;ll find images have been embedded into HTML code.</span></p>
<p><span style="font-size:small"><img id="124147" src="124147-11.png" alt=""><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<h1>More Information</h1>
<p><span style="font-size:small">Spire.XLS for .NET is a standalone Excel .NET managed assembly and does not depend on Microsoft Office Excel. Spire.XLS for .NET offers support both for the old Excel 97-2003 format (.xls) and for the new Excel 2007,Excel 2010
 and Excel 2013 (.xlsx, .xlsb, .xlsm), along with Open Office(.ods) format. It features fast and reliably compared to developing your own spreadsheet manipulation solution or using Microsoft Automation.</span></p>
<p><strong><span style="font-size:small">Related links</span></strong><em>&nbsp;</em></p>
<p><span style="font-size:small">Website: <a href="http://www.e-iceblue.com">www.e-iceblue.com</a></span><br>
<span style="font-size:small">Product Home: <a href="http://www.e-iceblue.com/Introduce/free-xls-component.html">
Free Spire.XLS for .NET</a></span><br>
<span style="font-size:small">Download: <a href="http://www.e-iceblue.com/Download/download-excel-for-net-now.html">
Spire.XLS for. NET</a></span><br>
<span style="font-size:small">Forum: <a href="http://www.e-iceblue.com/forum/viewforum.php?f=4">
Spire.XLS forum</a></span></p>
