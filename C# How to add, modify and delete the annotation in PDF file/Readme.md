# C# How to add, modify and delete the annotation in PDF file
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- .NET
- Class Library
- c# control
- PDF API
## Topics
- C#
- Class Library
- PDF
- .Net Programming
- PDF annotation
## Updated
- 02/08/2018
## Description

<h1>Introduction</h1>
<p>An annotation conveys additional and significant information to the readers, it provides us a choice to edit and enrich the document freely. This sample project will show you how to deal with the annotations with the help of component Free Spire.PDF for
 .NET in C#.</p>
<p><strong>The tools you need</strong>: Free Spire.PDF for .NET</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Visual Studio 2013</p>
<p><strong>Preparation:</strong> Download and install the component from the <a href="https://www.e-iceblue.com/Download/download-pdf-for-net-free.html">
official website</a>, and add the Spire.PDF.dll into the program assemblies as a reference. You can get the details from the full code below.</p>
<p>The full code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Spire.Pdf;
using Spire.Pdf.General.Find;
using System.Drawing;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;

namespace Annotation_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;);

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Call the FindText() method to  find the text  where you need to add annotation      
      PdfTextFind[] results = page.FindText(&quot;IPCC&quot;).Finds;

            //Specify the location of annotation
            float x = results[0].Position.X - doc.PageSettings.Margins.Top;
            float y = results[0].Position.Y - doc.PageSettings.Margins.Left &#43; results[0].Size.Height - 23;

            //Create the pop-up annotation
            RectangleF rect = new RectangleF(x, y, 15, 0);
            PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rect);

            //Add the text into the annotation and set the icon and color
            popupAnnotation.Text = &quot;IPCC,This is a scientific and intergovernmental body under the auspices of the United Nations.&quot;;
            popupAnnotation.Icon = PdfPopupIcon.Help;
            popupAnnotation.Color = Color.SandyBrown;

            //Add the annotation to the PDF file
            page.AnnotationsWidget.Add(popupAnnotation);

            //Save the file and view
            doc.SaveToFile(&quot;Annotation.pdf&quot;);
            System.Diagnostics.Process.Start(&quot;Annotation.pdf&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.General.Find;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Annotations;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Graphics;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Annotation_PDF&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;an&nbsp;instance&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;first&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfPageBase&nbsp;page&nbsp;=&nbsp;doc.Pages[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Call&nbsp;the&nbsp;FindText()&nbsp;method&nbsp;to&nbsp;&nbsp;find&nbsp;the&nbsp;text&nbsp;&nbsp;where&nbsp;you&nbsp;need&nbsp;to&nbsp;add&nbsp;annotation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfTextFind[]&nbsp;results&nbsp;=&nbsp;page.FindText(<span class="cs__string">&quot;IPCC&quot;</span>).Finds;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Specify&nbsp;the&nbsp;location&nbsp;of&nbsp;annotation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;x&nbsp;=&nbsp;results[<span class="cs__number">0</span>].Position.X&nbsp;-&nbsp;doc.PageSettings.Margins.Top;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;y&nbsp;=&nbsp;results[<span class="cs__number">0</span>].Position.Y&nbsp;-&nbsp;doc.PageSettings.Margins.Left&nbsp;&#43;&nbsp;results[<span class="cs__number">0</span>].Size.Height&nbsp;-&nbsp;<span class="cs__number">23</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;the&nbsp;pop-up&nbsp;annotation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RectangleF&nbsp;rect&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RectangleF(x,&nbsp;y,&nbsp;<span class="cs__number">15</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfPopupAnnotation&nbsp;popupAnnotation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfPopupAnnotation(rect);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;the&nbsp;text&nbsp;into&nbsp;the&nbsp;annotation&nbsp;and&nbsp;set&nbsp;the&nbsp;icon&nbsp;and&nbsp;color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;popupAnnotation.Text&nbsp;=&nbsp;<span class="cs__string">&quot;IPCC,This&nbsp;is&nbsp;a&nbsp;scientific&nbsp;and&nbsp;intergovernmental&nbsp;body&nbsp;under&nbsp;the&nbsp;auspices&nbsp;of&nbsp;the&nbsp;United&nbsp;Nations.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;popupAnnotation.Icon&nbsp;=&nbsp;PdfPopupIcon.Help;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;popupAnnotation.Color&nbsp;=&nbsp;Color.SandyBrown;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;the&nbsp;annotation&nbsp;to&nbsp;the&nbsp;PDF&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page.AnnotationsWidget.Add(popupAnnotation);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;the&nbsp;file&nbsp;and&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.SaveToFile(<span class="cs__string">&quot;Annotation.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;Annotation.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>Run the program and you will get the result like below:</p>
<p><strong>Screenshot:</strong></p>
<h1><img id="184489" src="184489-12.png" alt="" width="780" height="497"></h1>
<p>&nbsp;</p>
<p><strong>2. How to modify the existing annotation?</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace ModifyAnnotation_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the file
            PdfDocument pdf = new PdfDocument(@&quot;C:\Users\Administrator\Desktop\Annotation.pdf&quot;);

            //Get the first annotation in the first page
            PdfAnnotation annotation = pdf.Pages[0].AnnotationsWidget[0];

            //Add the modified text and set the formatting
            annotation.Text = &quot; Dedicate to the task of providing the world with an objective, scientific view of climate change and its political and economic impacts.&quot;;
            annotation.Border = new PdfAnnotationBorder(1f);
            annotation.Color = new PdfRGBColor(Color.LightGreen);
            annotation.Flags = PdfAnnotationFlags.Locked;

            //Save the file and view
            pdf.SaveToFile(&quot;result.pdf&quot;);
            System.Diagnostics.Process.Start(&quot;result.pdf&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Annotations;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Graphics;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ModifyAnnotation_PDF&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;an&nbsp;instance&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;pdf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\Annotation.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;first&nbsp;annotation&nbsp;in&nbsp;the&nbsp;first&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfAnnotation&nbsp;annotation&nbsp;=&nbsp;pdf.Pages[<span class="cs__number">0</span>].AnnotationsWidget[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;the&nbsp;modified&nbsp;text&nbsp;and&nbsp;set&nbsp;the&nbsp;formatting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;annotation.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&nbsp;Dedicate&nbsp;to&nbsp;the&nbsp;task&nbsp;of&nbsp;providing&nbsp;the&nbsp;world&nbsp;with&nbsp;an&nbsp;objective,&nbsp;scientific&nbsp;view&nbsp;of&nbsp;climate&nbsp;change&nbsp;and&nbsp;its&nbsp;political&nbsp;and&nbsp;economic&nbsp;impacts.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;annotation.Border&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfAnnotationBorder(1f);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;annotation.Color&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfRGBColor(Color.LightGreen);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;annotation.Flags&nbsp;=&nbsp;PdfAnnotationFlags.Locked;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;the&nbsp;file&nbsp;and&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdf.SaveToFile(<span class="cs__string">&quot;result.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;result.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Screenshot:</strong></p>
<p><img id="184491" src="184491-13.png" alt="" width="754" height="484"></p>
<p>&nbsp;</p>
<p><strong>3. How to delete the annotation?</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Spire.Pdf;

namespace DeleteAnnotation_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load the PDF 
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@&quot;C:\Users\Administrator\Desktop\Annotation.pdf&quot;);

            //Get the first annotation in the first page and remove it
            document.Pages[0].AnnotationsWidget.RemoveAt(0);

            //Save the file and view
            document.SaveToFile(&quot;output.pdf&quot;);
            System.Diagnostics.Process.Start(&quot;output.pdf&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DeleteAnnotation_PDF&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;an&nbsp;object&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;PDF&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\Annotation.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;first&nbsp;annotation&nbsp;in&nbsp;the&nbsp;first&nbsp;page&nbsp;and&nbsp;remove&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.Pages[<span class="cs__number">0</span>].AnnotationsWidget.RemoveAt(<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;the&nbsp;file&nbsp;and&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.SaveToFile(<span class="cs__string">&quot;output.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;output.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p>Run the program and the annotation has been removed.</p>
<p><strong>Useful information</strong></p>
<p><strong>Spire.PDF for .NET</strong> is a professional PDF component applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET application.</p>
<p>Many rich features can be supported by the .NET PDF API, such as security setting (including digital signature), PDF text/attachment/image extract, PDF merge/split, metadata update, section, graph/image drawing and inserting, table creation and processing,
 and importing data etc. Besides, Spire.PDF for .NET can be applied to easily converting Text, Image and HTML to PDF with C#/VB.NET in high quality.</p>
<p><strong>Related links</strong></p>
<p>Website: <a href="https://www.e-iceblue.com/">https://www.e-iceblue.com/</a></p>
<p>Forum:<a href="https://www.e-iceblue.com/forum/spire-pdf-f7.html">&nbsp;https://www.e-iceblue.com/forum/spire-pdf-f7.html</a></p>
