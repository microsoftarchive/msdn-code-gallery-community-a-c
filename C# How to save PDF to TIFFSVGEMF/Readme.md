# C# How to save PDF to TIFF/SVG/EMF
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- .NET
- c# control
- PDF API
## Topics
- C#
- How to
- PDF API
- .NET PDF library
- PDF to tiff/SVG/EMF
## Updated
- 02/08/2018
## Description

<p>This code sample describes how to convert PDF files into TIFF/SVG/EMF using free component in C#.</p>
<h1><strong>Tools you need</strong></h1>
<ul>
<li>Free Spire.PDF for .NET </li><li>Visual Studio </li></ul>
<h1><strong>Preparation</strong></h1>
<p><span style="font-size:small">Free Spire.PDF for .NET is applied into the project. You need to&nbsp;<a href="https://www.e-iceblue.com/Download/download-pdf-for-net-free.html"><strong>download</strong></a>&nbsp;and install the component first and then reference
 the&nbsp;<strong><em>Spire.Pdf.dll</em></strong>&nbsp;in Visual Studio. The code below illustrates the details.</span></p>
<p><span style="font-size:medium; font-weight:bold"><strong>1. PDF to TIFF</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Drawing;
using System.Drawing.Imaging;
using Spire.Pdf;

namespace SavePdfAsTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load a PDF sample from file
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;);
            //Call JoinTiffImages() method to save the PDF to Tiff and open the result
            JoinTiffImages(SaveAsImage(document), &quot;result.tiff&quot;, EncoderValue.CompressionLZW);
            System.Diagnostics.Process.Start(&quot;result.tiff&quot;);
        }
        //Define SaveAsImage() method to save the PDF document as image array
        private static Image[] SaveAsImage(PdfDocument document)
        {
            Image[] images = new Image[document.Pages.Count];
            for (int i = 0; i &lt; document.Pages.Count; i&#43;&#43;)
            {
                images[i] = document.SaveAsImage(i);
            }
            return images;
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j &lt; encoders.Length; j&#43;&#43;)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType &#43; &quot; mime type not found in ImageCodecInfo&quot;);
        }
        //Define JoinTiffImages() method to save the images from PDF pages to tiff image type, with the specified encoder and image-encoder parameters.
        public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
        {
            Encoder enc = Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)compressEncoder);
            Image pages = images[0];
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo(&quot;image/tiff&quot;);
            foreach (Image img in images)
            {
                if (frame == 0)
                {
                    pages = img;
                    pages.Save(outFile, info, ep);
                }

                else
                {
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                    pages.SaveAdd(img, ep);
                }
                if (frame == images.Length - 1)
                {
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }
                frame&#43;&#43;;
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing.Imaging;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SavePdfAsTiff&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;an&nbsp;object&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;a&nbsp;PDF&nbsp;sample&nbsp;from&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Call&nbsp;JoinTiffImages()&nbsp;method&nbsp;to&nbsp;save&nbsp;the&nbsp;PDF&nbsp;to&nbsp;Tiff&nbsp;and&nbsp;open&nbsp;the&nbsp;result</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JoinTiffImages(SaveAsImage(document),&nbsp;<span class="cs__string">&quot;result.tiff&quot;</span>,&nbsp;EncoderValue.CompressionLZW);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;result.tiff&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Define&nbsp;SaveAsImage()&nbsp;method&nbsp;to&nbsp;save&nbsp;the&nbsp;PDF&nbsp;document&nbsp;as&nbsp;image&nbsp;array</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Image[]&nbsp;SaveAsImage(PdfDocument&nbsp;document)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image[]&nbsp;images&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Image[document.Pages.Count];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;document.Pages.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;images[i]&nbsp;=&nbsp;document.SaveAsImage(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;images;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;ImageCodecInfo&nbsp;GetEncoderInfo(<span class="cs__keyword">string</span>&nbsp;mimeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageCodecInfo[]&nbsp;encoders&nbsp;=&nbsp;ImageCodecInfo.GetImageEncoders();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;encoders.Length;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(encoders[j].MimeType&nbsp;==&nbsp;mimeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;encoders[j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(mimeType&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;mime&nbsp;type&nbsp;not&nbsp;found&nbsp;in&nbsp;ImageCodecInfo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Define&nbsp;JoinTiffImages()&nbsp;method&nbsp;to&nbsp;save&nbsp;the&nbsp;images&nbsp;from&nbsp;PDF&nbsp;pages&nbsp;to&nbsp;tiff&nbsp;image&nbsp;type,&nbsp;with&nbsp;the&nbsp;specified&nbsp;encoder&nbsp;and&nbsp;image-encoder&nbsp;parameters.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;JoinTiffImages(Image[]&nbsp;images,&nbsp;<span class="cs__keyword">string</span>&nbsp;outFile,&nbsp;EncoderValue&nbsp;compressEncoder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Encoder&nbsp;enc&nbsp;=&nbsp;Encoder.SaveFlag;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EncoderParameters&nbsp;ep&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameters(<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(enc,&nbsp;(<span class="cs__keyword">long</span>)EncoderValue.MultiFrame);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">1</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(Encoder.Compression,&nbsp;(<span class="cs__keyword">long</span>)compressEncoder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;pages&nbsp;=&nbsp;images[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;frame&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageCodecInfo&nbsp;info&nbsp;=&nbsp;GetEncoderInfo(<span class="cs__string">&quot;image/tiff&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Image&nbsp;img&nbsp;<span class="cs__keyword">in</span>&nbsp;images)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(frame&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages&nbsp;=&nbsp;img;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages.Save(outFile,&nbsp;info,&nbsp;ep);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(enc,&nbsp;(<span class="cs__keyword">long</span>)EncoderValue.FrameDimensionPage);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages.SaveAdd(img,&nbsp;ep);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(frame&nbsp;==&nbsp;images.Length&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(enc,&nbsp;(<span class="cs__keyword">long</span>)EncoderValue.Flush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages.SaveAdd(ep);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frame&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong><span style="font-size:medium">2.<strong style="font-size:10px">&nbsp;PDF to SVG</strong></span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Spire.Pdf;

namespace PDFtoSVG_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the sample from file
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;);
            //Save the file to SVG
            document.SaveToFile(&quot;Result.svg&quot;, FileFormat.SVG);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;PDFtoSVG_PDF&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;an&nbsp;instance&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;sample&nbsp;from&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;the&nbsp;file&nbsp;to&nbsp;SVG</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.SaveToFile(<span class="cs__string">&quot;Result.svg&quot;</span>,&nbsp;FileFormat.SVG);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><strong>3. PDF to EMF</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Spire.Pdf;
using System;
using System.Drawing;

namespace PDFtoEMF_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load the sample
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;);
            //Call to use the SaveAsImage method to save all the PDF pages as EMF
            for (int i = 0; i &lt; doc.Pages.Count; i&#43;&#43;)
            {
                String fileName = String.Format(&quot;Sample-img-{0}.emf&quot;, i);
                using (Image image = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile, 300, 300))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Emf);
                }
            }

        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;PDFtoEMF_PDF&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;an&nbsp;object&nbsp;of&nbsp;PdfDocument&nbsp;class&nbsp;and&nbsp;load&nbsp;the&nbsp;sample</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\sample.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Call&nbsp;to&nbsp;use&nbsp;the&nbsp;SaveAsImage&nbsp;method&nbsp;to&nbsp;save&nbsp;all&nbsp;the&nbsp;PDF&nbsp;pages&nbsp;as&nbsp;EMF</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;doc.Pages.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;fileName&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;Sample-img-{0}.emf&quot;</span>,&nbsp;i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Image&nbsp;image&nbsp;=&nbsp;doc.SaveAsImage(i,&nbsp;Spire.Pdf.Graphics.PdfImageType.Metafile,&nbsp;<span class="cs__number">300</span>,&nbsp;<span class="cs__number">300</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image.Save(fileName,&nbsp;System.Drawing.Imaging.ImageFormat.Emf);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p><span style="font-size:medium"><strong>More samples about conversion</strong></span></p>
<ul>
<li>&nbsp;<a href="https://code.msdn.microsoft.com/Operate-PDF-file-in-C-585605ef#content">PDF to Image</a>
</li><li>&nbsp;<a href="https://code.msdn.microsoft.com/How-to-convert-PDF-to-XPS-9e982613">PDF to XPS</a> and
<a href="https://code.msdn.microsoft.com/Convert-XPS-to-PDF-in-C-2885c168#content">
XPS to PDF</a> </li><li>&nbsp;<a href="https://code.msdn.microsoft.com/Convert-HTML-to-PDF-with-C-b16fc75f">HTML to PDF</a> and
<a href="https://code.msdn.microsoft.com/Operate-PDF-file-in-C-af322546">PDF to HTML</a>
</li><li>&nbsp;<a href="https://code.msdn.microsoft.com/How-to-convert-PDF-to-Word-6d48fc6a">PDF to Doc</a>
</li></ul>
<ul>
</ul>
<h1>More Information</h1>
<p><strong>Spire.PDF for .NET</strong>&nbsp;is a professional PDF component applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET application.</p>
<p>Many rich features can be supported by the .NET PDF API, such as security setting (including digital signature), PDF text/attachment/image extract, PDF merge/split, metadata update, section, graph/image drawing and inserting, table creation and processing,
 and importing data etc. Besides, Spire.PDF for .NET can be applied to easily converting Text, Image and HTML to PDF with C#/VB.NET in high quality.</p>
<p><strong>Related links</strong></p>
<p>Website:&nbsp;<a href="https://www.e-iceblue.com/">https://www.e-iceblue.com/</a></p>
<p>Introduction:&nbsp;<a href="https://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html">https://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html</a></p>
<p>Download:&nbsp;<a href="https://www.e-iceblue.com/Download/download-pdf-for-net-now.html">https://www.e-iceblue.com/Download/download-pdf-for-net-now.html</a></p>
