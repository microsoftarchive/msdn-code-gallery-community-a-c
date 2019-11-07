# C# VB.NET OCR Image to Text, Word, searchable PDF & QR Barcode Read Recognition
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- WCF
- GDI+
- Silverlight
- ASP.NET
- Win32
- .NET
- Class Library
- Windows Forms
- WPF
- Microsoft Azure
- ASP.NET MVC
- C++
- .NET Framework 4
- .NET Framework
- Windows
- Visual Basic .NET
- Office 365
- VB.Net
- .NET Framework 4.0
- SharePoint Server 2010
- Library
- Windows General
- Service Bus
- C# Language
- Windows Runtime
- ASP.NET MVC 4
- .NET Framework 4.5
- Windows 8
- .NET Framwork
- Cloud
- Visual C#
- ASP.NET Web API
- Visual C Sharp .NET
- Image process
- SharePoint Server 2013
- Windows Store app
- .NET Development
- Image Processing
- Bing OCR
- OCR
- Windows Imaging Component (WIC)
- Windows 10
- Barcode
- Barcode Recognition
- Barcode Reading
- Optical Character Recognition
- Royalty Free
## Topics
- Controls
- Graphics
- C#
- WCF
- ASP.NET
- Class Library
- User Interface
- Windows Forms
- Graphics and 3D
- WPF
- Microsoft Azure
- Data Access
- Images
- Media
- 2d graphics
- Image manipulation
- Code Sample
- Image Gallery
- Image
- .NET 4
- Imaging
- Drawing
- How to
- Numerical Computing
- Text
- Windows Forms Controls
- Graphics Functions
- BitmapImage
- Bing OCR Control
- OCR
- Read Barcode
- Barcode
- Barcode Recognition
- Optical Character Recognition
- Barcode scanner
## Updated
- 08/23/2016
## Description

<h1>Introduction</h1>
<p>This code sample shows how to do <a href="http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-api-overview.html" target="_blank">
C# VB.NET OCR and barcode recognition to&nbsp;convert images (in various formats like JPEG, PNG, TIFF, PDF, etc.) into editable document formats</a> (<a href="https://asprise.com/royalty-free-library/c%23-sharp.net-ocr-source-code-examples-demos.html#xml" target="_blank">Word,
 XML, searchable PDF, etc.</a>) and read barcodes in formats of&nbsp;<span>EAN-8, EAN-13, UPC-A, UPC-E, ISBN-10, ISBN-13, Interleaved 2 of 5, Code 39, Code 128, PDF417, and QR Code.</span></p>
<h1>Build the Sample</h1>
<p>Download and unzip the sample project. Open it with Visual Studio 2013 or higher, Tools -&gt; NuGet Package Manager -&gt; Restore, then Press F5 to run it.</p>
<p>Alternatively, install from NuGet directly:</p>
<pre><img src="-nuget-blue.png" alt=""><strong><span class="code" style="font-size:medium">&nbsp;Install-Package asprise-ocr-api</span></strong></pre>
<p><span>You can invoke the OCR demo Form by copying the following code to Program.cs (for C#):</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">...
static class Program { // Program.cs
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new asprise_ocr_api.OcrSampleForm());
    }
}</pre>
<div class="preview">
<pre class="csharp">...&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;{&nbsp;<span class="cs__com">//&nbsp;Program.cs</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[STAThread]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.EnableVisualStyles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.SetCompatibleTextRenderingDefault(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run(<span class="cs__keyword">new</span>&nbsp;asprise_ocr_api.OcrSampleForm());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><img id="158460" src="158460-csharp-ui.png" alt="" height="300">&nbsp;</div>
<div class="endscriptcode"><object width="180" height="100" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=https://code.msdn.microsoft.com/site/view/file/158459/1/AspriseOcrDemo_WindowsMedia%20-%20HD%20720i_ConstrainedVBR.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="/site/view/file/158459/1/AspriseOcrDemo_WindowsMedia%20-%20HD%20720i_ConstrainedVBR.wmv"
 /> <param name="id" value="158459" /> <param name="name" value="AspriseOcrDemo_WindowsMedia - HD 720i_ConstrainedVBR.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> &nbsp;&nbsp;<a id="x_/site/view/file/158459/1/AspriseOcrDemo_WindowsMedia%20-%20HD%20720i_ConstrainedVBR.wmv" href="https://code.msdn.microsoft.com/site/view/file/158459/1/AspriseOcrDemo_WindowsMedia%20-%20HD%20720i_ConstrainedVBR.wmv">Download
 video</a>&nbsp;| <a href="https://www.youtube.com/watch?v=v17hhJHXNiA" target="_blank">
View video on Youtube</a></div>
<h1>C# VB.NET OCR in Action</h1>
<h2><span style="font-size:20px; font-weight:bold">Jump Start</span></h2>
<p>The following code demonstrates the basic usage of Asprise <a href="http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-api-overview.html" target="_blank">
C# VB.NET OCR and Barcode Recognition</a>:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using asprise_ocr_api;

AspriseOCR.SetUp();
AspriseOCR ocr = new AspriseOCR();
ocr.StartEngine(&quot;eng&quot;, AspriseOCR.SPEED_FASTEST);

string s = ocr.Recognize(&quot;C:\path\img.jpg&quot;, -1, -1, -1, -1, -1, AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);
Console.WriteLine(&quot;OCR Result: &quot; &#43; s);
// process more images here ...

ocr.StopEngine();</pre>
<pre class="hidden">Imports asprise_ocr_api
Private ocr As AspriseOCR
AspriseOCR.SetUp()
ocr = New AspriseOCR()
ocr.StartEngine(&quot;eng&quot;, AspriseOCR.SPEED_FASTEST)

Dim s As String = ocr.Recognize(&quot;C:\img.jpg&quot;, -1, -1, -1, -1, -1, AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT)
Console.WriteLine(&quot;OCR Result: &quot; &amp; s)
' process more images here ...

ocr.StopEngine()</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;asprise_ocr_api;&nbsp;
&nbsp;
AspriseOCR.SetUp();&nbsp;
AspriseOCR&nbsp;ocr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseOCR();&nbsp;
ocr.StartEngine(<span class="cs__string">&quot;eng&quot;</span>,&nbsp;AspriseOCR.SPEED_FASTEST);&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;ocr.Recognize(<span class="cs__string">&quot;C:\path\img.jpg&quot;</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;AspriseOCR.RECOGNIZE_TYPE_ALL,&nbsp;AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);&nbsp;
Console.WriteLine(<span class="cs__string">&quot;OCR&nbsp;Result:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;s);&nbsp;
<span class="cs__com">//&nbsp;process&nbsp;more&nbsp;images&nbsp;here&nbsp;...</span>&nbsp;
&nbsp;
ocr.StopEngine();</pre>
</div>
</div>
</div>
<p>Line 3: performs one-time setup if it has not been done;</p>
<p>Lines 4 &amp; 5: Creates a new Ocr engine that recognizes English in fastest speed setting; The evaluation version is able to recognize English (eng), Spanish (spa), Portuguese (por), German (deu) and French (fra). For other languages, please contact us.
 The list of languages supported can be found&nbsp;<a class="reference internal" href="http://asprise.com/ocr/docs/html/intro-ocr-sdk-library.html#intro-langs">Languages Supported</a>.</p>
<p>Line 7: All the OCR work is done here. The Recognize method of the AspriseOCR class recognizes all the characters and barcodes from the image and output them as plain text. Other supported output formats are: XML (<code class="docutils literal"><span class="pre">AspriseOCR.OUTPUT_FORMAT_XML</span></code>),
 searchable PDF (<code class="docutils literal"><span class="pre">Ocr.OUTPUT_FORMAT_PDF</span></code>) and user editable RTF (<code class="docutils literal"><span class="pre">Ocr.OUTPUT_FORMAT_RTF</span></code>).</p>
<h2>OCR to Searchable PDF Format</h2>
<p><span>If you set the output format as OUTPUT_FORMAT_PDF, you need to specify the target PDF output file as following:</span></p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ocr.Recognize(&quot;C:\test-image.png&quot;, -1, -1, -1, -1, -1,
  Ocr.RECOGNIZE_TYPE_ALL, Ocr.OUTPUT_FORMAT_PDF,
  &quot;PROP_PDF_OUTPUT_FILE=ocr-result.pdf|PROP_PDF_OUTPUT_TEXT_VISIBLE=true&quot;);
</pre>
<div class="preview">
<pre class="csharp">ocr.Recognize(<span class="cs__string">&quot;C:\test-image.png&quot;</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;Ocr.RECOGNIZE_TYPE_ALL,&nbsp;Ocr.OUTPUT_FORMAT_PDF,&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;PROP_PDF_OUTPUT_FILE=ocr-result.pdf|PROP_PDF_OUTPUT_TEXT_VISIBLE=true&quot;</span>);&nbsp;</pre>
</div>
</div>
</div>
</div>
<p>In above code, properties are specified in a single string separated by&nbsp;<code class="docutils literal"><span class="pre">|</span></code>&nbsp;(with key and value separated by&nbsp;<code class="docutils literal"><span class="pre">=</span></code>).
 Alternatively, you may specify properties separately in pairs:</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ocr.Recognize(&quot;C:\test-image.png&quot;, -1, -1, -1, -1, -1,
  Ocr.RECOGNIZE_TYPE_ALL, Ocr.OUTPUT_FORMAT_PDF,
  AspriseOCR.PROP_PDF_OUTPUT_FILE, &quot;ocr-result.pdf&quot;,
  AspriseOCR.PROP_PDF_OUTPUT_TEXT_VISIBLE, true);
</pre>
<div class="preview">
<pre class="csharp">ocr.Recognize(<span class="cs__string">&quot;C:\test-image.png&quot;</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;Ocr.RECOGNIZE_TYPE_ALL,&nbsp;Ocr.OUTPUT_FORMAT_PDF,&nbsp;
&nbsp;&nbsp;AspriseOCR.PROP_PDF_OUTPUT_FILE,&nbsp;<span class="cs__string">&quot;ocr-result.pdf&quot;</span>,&nbsp;
&nbsp;&nbsp;AspriseOCR.PROP_PDF_OUTPUT_TEXT_VISIBLE,&nbsp;<span class="cs__keyword">true</span>);&nbsp;</pre>
</div>
</div>
</div>
</div>
<h2>Recognizes Text Only Or Barcode Only</h2>
<p>To save OCR time, you can choose to OCR text or barcode only. Text only:</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string s = ocr.Recognize(&quot;C:\path\img.jpg&quot;, -1, -1, -1, -1, -1,
   AspriseOCR.RECOGNIZE_TYPE_TEXT, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;ocr.Recognize(<span class="cs__string">&quot;C:\path\img.jpg&quot;</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;AspriseOCR.RECOGNIZE_TYPE_TEXT,&nbsp;AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><a href="http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-api-overview.html" target="_blank">Read barcode and QR codes in C# and VB.NET</a>:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string s = ocr.Recognize(&quot;C:\path\img.jpg&quot;, -1, -1, -1, -1, -1,
   AspriseOCR.RECOGNIZE_TYPE_BARCODE, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
<div class="preview">
<pre class="js">string&nbsp;s&nbsp;=&nbsp;ocr.Recognize(<span class="js__string">&quot;C:\path\img.jpg&quot;</span>,&nbsp;-<span class="js__num">1</span>,&nbsp;-<span class="js__num">1</span>,&nbsp;-<span class="js__num">1</span>,&nbsp;-<span class="js__num">1</span>,&nbsp;-<span class="js__num">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;AspriseOCR.RECOGNIZE_TYPE_BARCODE,&nbsp;AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
</div>
</div>
</div>
</div>
</div>
<h2>Perform OCR On Part Of The Image</h2>
<p>In some cases, you might not want to OCR the whole image. In that case, you can OCR on part of the image to save time:</p>
<div class="highlight-csharp">
<div class="highlight"></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string s = ocr.Recognize(&quot;C:\path\img.jpg&quot;, -1, 0, 0, 400, 200,
   AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;ocr.Recognize(<span class="cs__string">&quot;C:\path\img.jpg&quot;</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">400</span>,&nbsp;<span class="cs__number">200</span>,&nbsp;
&nbsp;&nbsp;&nbsp;AspriseOCR.RECOGNIZE_TYPE_ALL,&nbsp;AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Perform OCR On A Certain Page From The Specified TIFF File</h2>
<div class="endscriptcode"><span>A PDF or TIFF file may contain multiple pages. If you need to recognize only a certain page, you can specify the page number as following:</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string s = ocr.Recognize(&quot;C:\img1.tif&quot;, 1, -1, -1, -1, -1,
   AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;ocr.Recognize(<span class="cs__string">&quot;C:\img1.tif&quot;</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;AspriseOCR.RECOGNIZE_TYPE_ALL,&nbsp;AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Note 1 means the second page (the page number of the first page is 0). -1 means all pages.</div>
</div>
<div class="endscriptcode"></div>
<h1>More Information</h1>
<p style="font-size:15px; line-height:22px; margin-top:0px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-api-overview.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="-icon-scan-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Learn
 more about Asprise OCR and Barcode Recognition C# VB.NET API SDK</a></p>
<p style="font-size:15px; line-height:22px; margin-top:0px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-barcode-reader-sdk-samples-docs.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="-icon-book-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Access
 to Asprise C# VB.NET OCR and Barcode Reading Developer's Guide</a></p>
<p style="font-size:15px; line-height:22px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/ocr/docs/Help/html/429a5bd5-3f62-f489-ede7-025e47709dab.htm" target="_blank" style="text-decoration:none; color:#0066aa"><img src="-icon-code-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Browse
 API (MSDN style) online</a></p>
