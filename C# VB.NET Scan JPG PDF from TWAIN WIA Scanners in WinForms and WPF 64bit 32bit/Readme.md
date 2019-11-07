# C# VB.NET Scan JPG PDF from TWAIN WIA Scanners in WinForms and WPF 64bit 32bit
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- GDI+
- Silverlight
- ASP.NET
- Win32
- Windows Forms
- WPF
- .NET Framework
- Visual Basic.NET
- .NET Framework 4.0
- Library
- Windows General
- WinForms
- WIA
- Graphics Functions
- Visual C#
- Visual C Sharp .NET
- System.Drawing.Drawing2D
- Image process
- .NET Development
- Windows Desktop App Development
- Image Processing
- scanner
- scan
- Twain
- document scanning
## Topics
- Controls
- Graphics
- C#
- User Interface
- Windows Forms
- Graphics and 3D
- WPF
- Images
- Visual Basic .NET
- Image manipulation
- Image
- Imaging
- Drawing
- How to
- WIA
- Windows Forms Controls
- User Experience
- scanner
- Twain
- document scanning
## Updated
- 08/22/2016
## Description

<h1>Introduction</h1>
<p>This code sample demostrates how to <a href="http://asprise.com/c%23-vb.net-scanner-api/twain-wia-scan-pdf-library-overview.html" target="_blank">
scan documents from TWAIN WIA scanners in JPEG or PDF formats for Windows Forms and WPF applications</a>.</p>
<h1><span>Building the Sample</span></h1>
<p>Download and unzip the sample project. Open it with Visual Studio 2013 or higher. Press F5 to run it.</p>
<p>Alternatively, install from NuGet:</p>
<p><img src="-nuget-blue.png" alt=""> <span class="code" style="font-size:medium">
Install-Package asprise-scan-scanner-twain-wia-api</span></p>
<p><img src="-demo-screen-dotnet.png" alt="" width="400"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Suppose that we need to scan color US letter documents and save the result in JPEG files. The following code demonstrates how to use Asprise .NET Scanning API to achieve that:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using asprise_imaging_api;

Result result = new AspriseImaging().Scan(new Request()
    .SetTwainCap(TwainConstants.ICAP_PIXELTYPE, TwainConstants.TWPT_RGB)
    .SetTwainCap(TwainConstants.ICAP_SUPPORTEDSIZES, TwainConstants.TWSS_USLETTER)
    .SetPromptScanMore(true) // prompt to scan more pages
    .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG)
      .SetSavePath(&quot;.\\${TMS}${EXT}&quot;)), // Environment variables in path will be expanded
  &quot;select&quot;, true, true); // &quot;select&quot; prompts device selection dialog.

List&lt;string&gt; files = result == null ? null : result.GetImageFiles();
Console.WriteLine(&quot;Scanned: &quot; &#43; string.Join(&quot;, &quot;, files == null ? new string[0] : files.ToArray()));</pre>
<pre class="hidden">Imports asprise_imaging_api

Dim result As Result = New AspriseImaging().Scan(New Request()
   .SetTwainCap(TwainConstants.ICAP_PIXELTYPE, TwainConstants.TWPT_RGB)
   .SetTwainCap(TwainConstants.ICAP_SUPPORTEDSIZES, TwainConstants.TWSS_USLETTER)
   .SetPromptScanMore(True) ' prompt to scan more pages
   .AddOutputItem(New RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG)
      .SetSavePath(&quot;.\${TMS}${EXT}&quot;)), ' Environment variables in path will be expanded
  &quot;select&quot;, True, True) ' &quot;select&quot; prompts device selection dialog.

Dim files As List(Of String) = If(result Is Nothing, Nothing, result.GetImageFiles())
Console.WriteLine(&quot;Scanned: &quot; &amp; String.Join(&quot;, &quot;, If(files Is Nothing, New String(-1) {}, files.ToArray())))
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;asprise_imaging_api;&nbsp;
&nbsp;
Result&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseImaging().Scan(<span class="cs__keyword">new</span>&nbsp;Request()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.SetTwainCap(TwainConstants.ICAP_PIXELTYPE,&nbsp;TwainConstants.TWPT_RGB)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.SetTwainCap(TwainConstants.ICAP_SUPPORTEDSIZES,&nbsp;TwainConstants.TWSS_USLETTER)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.SetPromptScanMore(<span class="cs__keyword">true</span>)&nbsp;<span class="cs__com">//&nbsp;prompt&nbsp;to&nbsp;scan&nbsp;more&nbsp;pages</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.AddOutputItem(<span class="cs__keyword">new</span>&nbsp;RequestOutputItem(AspriseImaging.OUTPUT_SAVE,&nbsp;AspriseImaging.FORMAT_JPG)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SetSavePath(<span class="cs__string">&quot;.\\${TMS}${EXT}&quot;</span>)),&nbsp;<span class="cs__com">//&nbsp;Environment&nbsp;variables&nbsp;in&nbsp;path&nbsp;will&nbsp;be&nbsp;expanded</span>&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;select&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;<span class="cs__com">//&nbsp;&quot;select&quot;&nbsp;prompts&nbsp;device&nbsp;selection&nbsp;dialog.</span>&nbsp;
&nbsp;
List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;files&nbsp;=&nbsp;result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;result.GetImageFiles();&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Scanned:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__keyword">string</span>.Join(<span class="cs__string">&quot;,&nbsp;&quot;</span>,&nbsp;files&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[<span class="cs__number">0</span>]&nbsp;:&nbsp;files.ToArray()));</pre>
</div>
</div>
</div>
<p>Alternatively, Asprise C# VB.NET Scanning SDK also allows you to specify scan requests using JSON based scan DSL (please refer to&nbsp;<a class="reference internal" href="http://asprise.com/scan2/docs/html/asprise-scan-sdk-api-request.html#scan-request">Asprise
 Scanning Request DSL</a>&nbsp;for details). The code below is equivalent to the OO based code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Result result = new AspriseImaging().Scan(&quot;{&quot; &#43;
    &quot;  \&quot;twain_cap_setting\&quot; : {&quot; &#43;
    &quot;    \&quot;ICAP_PIXEXELTYPE\&quot; : \&quot;TWPT_RGB\&quot;,&quot; &#43;
    &quot;    \&quot;ICAP_SUPPORPORTEDSIZES\&quot; : \&quot;TWSS_USLESLETTER\&quot;&quot; &#43;
    &quot;  },&quot; &#43;
    &quot;  \&quot;prompt_scan_more\&quot; : true,&quot; &#43;
    &quot;  \&quot;output_settings\&quot; : [ {&quot; &#43;
    &quot;    \&quot;type\&quot; : \&quot;save\&quot;,&quot; &#43;
    &quot;    \&quot;format\&quot; : \&quot;jpg\&quot;,&quot; &#43;
    &quot;    \&quot;save_path\&quot; : \&quot;.\\\\${TMS}${EXT}\&quot;&quot; &#43;
    &quot;  } ]&quot; &#43;
    &quot;}&quot;, &quot;select&quot;, true, true);

List&lt;string&gt; files = result == null ? null : result.GetImageFiles();
Console.WriteLine(&quot;Scanned: &quot; &#43; string.Join(&quot;, &quot;, files == null ? new string[0] : files.ToArray()));</pre>
<div class="preview">
<pre class="csharp">Result&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseImaging().Scan(<span class="cs__string">&quot;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;\&quot;twain_cap_setting\&quot;&nbsp;:&nbsp;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;ICAP_PIXEXELTYPE\&quot;&nbsp;:&nbsp;\&quot;TWPT_RGB\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;ICAP_SUPPORPORTEDSIZES\&quot;&nbsp;:&nbsp;\&quot;TWSS_USLESLETTER\&quot;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;},&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;\&quot;prompt_scan_more\&quot;&nbsp;:&nbsp;true,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;\&quot;output_settings\&quot;&nbsp;:&nbsp;[&nbsp;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;type\&quot;&nbsp;:&nbsp;\&quot;save\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;format\&quot;&nbsp;:&nbsp;\&quot;jpg\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;save_path\&quot;&nbsp;:&nbsp;\&quot;.\\\\${TMS}${EXT}\&quot;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;}&nbsp;]&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;}&quot;</span>,&nbsp;<span class="cs__string">&quot;select&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;files&nbsp;=&nbsp;result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;result.GetImageFiles();&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Scanned:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__keyword">string</span>.Join(<span class="cs__string">&quot;,&nbsp;&quot;</span>,&nbsp;files&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[<span class="cs__number">0</span>]&nbsp;:&nbsp;files.ToArray()));</pre>
</div>
</div>
</div>
<h1>More Scanning Scenarios</h1>
<h2>Scan And Upload To Server<a class="headerlink" title="Permalink to this headline" href="http://asprise.com/scan2/docs/html/asprise-scan-library-csharp-vb.net-component.html#scan-and-upload-to-server"></a></h2>
<p>It&rsquo;s easy to allow the user to <a href="http://asprise.com/c%23-vb.net-scanner-api/twain-wia-scan-pdf-library-overview.html" target="_blank">
scan from TWAIN WIA scanners in JPG or PDF and upload to the server</a>. The server side script to handle the upload can be written in any programming language, ASP.NET, Java, PHP, Python, Ruby, etc. You handle the upload from Asprise Scanning SDK in the same
 way as you handle a simple HTML form upload.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
  new RequestOutputItem(AspriseImaging.OUTPUT_UPLOAD, AspriseImaging.FORMAT_JPG).SetUploadSetting( // Upload
    new UploadSetting(&quot;http://asprise.com/scan/applet/upload.php?action=dump&quot;)
      .AddPostField(&quot;title&quot;, &quot;Test scan&quot;))) // Additional data to be passed to server: post fields, headers, etc.
 &quot;select&quot;, true, true);

String response = result == null ? null : result.GetUploadResponse();
Console.WriteLine(&quot;From server: \n&quot; &#43; response);

// Alternatively, request can be specified using JSON
Result result = new AspriseImaging().Scan(&quot;{&quot; &#43;
  &quot;  \&quot;output_settings\&quot; : [ {&quot; &#43;
  &quot;    \&quot;type\&quot; : \&quot;upload\&quot;,&quot; &#43;
  &quot;    \&quot;format\&quot; : \&quot;jpg\&quot;,&quot; &#43;
  &quot;    \&quot;upload_target\&quot; : {&quot; &#43;
  &quot;      \&quot;url\&quot; : \&quot;http://asprise.com/scan/applet/upload.php?action=dump\&quot;,&quot; &#43;
  &quot;      \&quot;post_fields\&quot; : {&quot; &#43;
  &quot;        \&quot;title\&quot; : \&quot;Test scan\&quot;&quot; &#43;
  &quot;      }&quot; &#43;
  &quot;    }&quot; &#43;
  &quot;  } ]&quot; &#43;
 &quot;}&quot;, &quot;select&quot;, true, true);</pre>
<div class="preview">
<pre class="csharp">Result&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseImaging().Scan(<span class="cs__keyword">new</span>&nbsp;Request().AddOutputItem(&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;RequestOutputItem(AspriseImaging.OUTPUT_UPLOAD,&nbsp;AspriseImaging.FORMAT_JPG).SetUploadSetting(&nbsp;<span class="cs__com">//&nbsp;Upload</span><span class="cs__keyword">new</span>&nbsp;UploadSetting(<span class="cs__string">&quot;http://asprise.com/scan/applet/upload.php?action=dump&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AddPostField(<span class="cs__string">&quot;title&quot;</span>,&nbsp;<span class="cs__string">&quot;Test&nbsp;scan&quot;</span>)))&nbsp;<span class="cs__com">//&nbsp;Additional&nbsp;data&nbsp;to&nbsp;be&nbsp;passed&nbsp;to&nbsp;server:&nbsp;post&nbsp;fields,&nbsp;headers,&nbsp;etc.</span><span class="cs__string">&quot;select&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
String&nbsp;response&nbsp;=&nbsp;result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;result.GetUploadResponse();&nbsp;
Console.WriteLine(<span class="cs__string">&quot;From&nbsp;server:&nbsp;\n&quot;</span>&nbsp;&#43;&nbsp;response);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Alternatively,&nbsp;request&nbsp;can&nbsp;be&nbsp;specified&nbsp;using&nbsp;JSON</span>&nbsp;
Result&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseImaging().Scan(<span class="cs__string">&quot;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;\&quot;output_settings\&quot;&nbsp;:&nbsp;[&nbsp;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;type\&quot;&nbsp;:&nbsp;\&quot;upload\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;format\&quot;&nbsp;:&nbsp;\&quot;jpg\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;upload_target\&quot;&nbsp;:&nbsp;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;url\&quot;&nbsp;:&nbsp;\&quot;http://asprise.com/scan/applet/upload.php?action=dump\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;post_fields\&quot;&nbsp;:&nbsp;{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&quot;title\&quot;&nbsp;:&nbsp;\&quot;Test&nbsp;scan\&quot;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;}&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;}&nbsp;]&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;<span class="cs__string">&quot;}&quot;</span>,&nbsp;<span class="cs__string">&quot;select&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">true</span>);</pre>
</div>
</div>
</div>
<h2>Scan Multiple Pages As PDF</h2>
<p class="endscriptcode"><span>Scanning multiple pages as a single PDF file simplifies organization. To do so, you need to set the format type to&nbsp;</span><code class="docutils literal"><span class="pre">AspriseImaging.FORMAT_PDF</span></code><span>.
 Additionally, you may add a text line to the bottom of the first page and set EXIF tags.</span></p>
<p class="endscriptcode"><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
  new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_PDF)
    .SetPdfTextLine(&quot;Scanned on ${DATETIME} by user X&quot;) // Optional text line at the bottom of the 1st page
    .AddExifTag(&quot;DocumentName&quot;, &quot;Scan to PDF by Asprise&quot;) // Optional PDF doc properties (metadata)
    .SetSavePath(&quot;.\\${TMS}${EXT}&quot;)
  ).SetPromptScanMore(true) // whether to prompt user to scan more pages
 , &quot;select&quot;, true, true);

string pdfFile = result == null ? null : result.GetPdfFile();
Console.WriteLine(&quot;Documents scanned as PDF: &quot; &#43; pdfFile);

// Alternatively, request can be specified using the following JSON:
{
  &quot;output_settings&quot; : [ {
    &quot;type&quot; : &quot;save&quot;,
    &quot;format&quot; : &quot;pdf&quot;,
    &quot;pdf_text_line&quot; : &quot;Scanned on ${DATETIME} by user X&quot;,
    &quot;pdf_owner_password&quot; : &quot;&quot;,
    &quot;pdf_user_password&quot; : &quot;&quot;,
    &quot;exif&quot; : {
      &quot;DocumentName&quot; : &quot;Scan to PDF by Asprise&quot;    },
    &quot;save_path&quot; : &quot;.\\${TMS}${EXT}&quot;  } ],
  &quot;prompt_scan_more&quot; : true
}</pre>
<div class="preview">
<pre class="csharp">Result&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseImaging().Scan(<span class="cs__keyword">new</span>&nbsp;Request().AddOutputItem(&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;RequestOutputItem(AspriseImaging.OUTPUT_SAVE,&nbsp;AspriseImaging.FORMAT_PDF)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.SetPdfTextLine(<span class="cs__string">&quot;Scanned&nbsp;on&nbsp;${DATETIME}&nbsp;by&nbsp;user&nbsp;X&quot;</span>)&nbsp;<span class="cs__com">//&nbsp;Optional&nbsp;text&nbsp;line&nbsp;at&nbsp;the&nbsp;bottom&nbsp;of&nbsp;the&nbsp;1st&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.AddExifTag(<span class="cs__string">&quot;DocumentName&quot;</span>,&nbsp;<span class="cs__string">&quot;Scan&nbsp;to&nbsp;PDF&nbsp;by&nbsp;Asprise&quot;</span>)&nbsp;<span class="cs__com">//&nbsp;Optional&nbsp;PDF&nbsp;doc&nbsp;properties&nbsp;(metadata)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.SetSavePath(<span class="cs__string">&quot;.\\${TMS}${EXT}&quot;</span>)&nbsp;
&nbsp;&nbsp;).SetPromptScanMore(<span class="cs__keyword">true</span>)&nbsp;<span class="cs__com">//&nbsp;whether&nbsp;to&nbsp;prompt&nbsp;user&nbsp;to&nbsp;scan&nbsp;more&nbsp;pages</span>&nbsp;
&nbsp;,&nbsp;<span class="cs__string">&quot;select&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;pdfFile&nbsp;=&nbsp;result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;result.GetPdfFile();&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Documents&nbsp;scanned&nbsp;as&nbsp;PDF:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;pdfFile);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Alternatively,&nbsp;request&nbsp;can&nbsp;be&nbsp;specified&nbsp;using&nbsp;the&nbsp;following&nbsp;JSON:</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;output_settings&quot;</span>&nbsp;:&nbsp;[&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;type&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;save&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;format&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;pdf&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;pdf_text_line&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;Scanned&nbsp;on&nbsp;${DATETIME}&nbsp;by&nbsp;user&nbsp;X&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;pdf_owner_password&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;pdf_user_password&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;exif&quot;</span>&nbsp;:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;DocumentName&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;Scan&nbsp;to&nbsp;PDF&nbsp;by&nbsp;Asprise&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;save_path&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;.\\${TMS}${EXT}&quot;</span>&nbsp;&nbsp;}&nbsp;],&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;prompt_scan_more&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">true</span>&nbsp;
}</pre>
</div>
</div>
</div>
<h2>ADF With Optional Blank Page Detection<a class="headerlink" title="Permalink to this headline" href="http://asprise.com/scan2/docs/html/asprise-scan-library-csharp-vb.net-component.html#adf-with-optional-blank-page-detection"></a></h2>
<p class="endscriptcode"><a href="http://asprise.com/c%23-vb.net-scanner-api/twain-wia-document-scan-library-sdk-samples-docs.html" target="_blank">Automatic Document Feeder (ADF)</a> allows bulk scanning of multiple pages in a single session. Optionally,
 you may choose to automatically discard blank page.</p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Result result = new AspriseImaging().Scan(new Request()
  .SetTwainCap(TwainConstants.CAP_FEEDERENABLED, true) // select feeder instead of flatbed
  .SetTwainCap(TwainConstants.CAP_AUTOFEED, true)
  .SetTwainCap(TwainConstants.CAP_DUPLEXENABLED, true)
  .SetDiscardBlankPages(true)
  .SetBlankPageThreshold(0.02m) // Discard pages with ink coverage &lt; 2%
  .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_PDF).SetSavePath(&quot;.\\${TMS}${EXT}&quot;)),
 &quot;select&quot;, true, true);

string pdfFile = result == null ? null : result.GetPdfFile();
Console.WriteLine(&quot;Documents scanned as PDF: &quot; &#43; pdfFile);

// Alternatively, request can be specified using the following JSON:
{
    &quot;twain_cap_setting&quot; : {
      &quot;CAP_FEEDERENABLED&quot; : true,
      &quot;CAP_AUTOFEED&quot; : true,
      &quot;CAP_DUPLEXENABLED&quot; : true
    },
    &quot;discard_blank_pages&quot; : true,
     // pages with ink coverage below the threshold will be discarded
    &quot;blank_page_threshold&quot; : &quot;0.02&quot;, // default value is 0.02
    &quot;output_settings&quot; : [ {
      &quot;type&quot; : &quot;save&quot;,
      &quot;format&quot; : &quot;pdf&quot;,
      &quot;save_path&quot; : &quot;.\\${TMS}${EXT}&quot;    } ]
 }</pre>
<div class="preview">
<pre class="csharp">Result&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AspriseImaging().Scan(<span class="cs__keyword">new</span>&nbsp;Request()&nbsp;
&nbsp;&nbsp;.SetTwainCap(TwainConstants.CAP_FEEDERENABLED,&nbsp;<span class="cs__keyword">true</span>)&nbsp;<span class="cs__com">//&nbsp;select&nbsp;feeder&nbsp;instead&nbsp;of&nbsp;flatbed</span>&nbsp;
&nbsp;&nbsp;.SetTwainCap(TwainConstants.CAP_AUTOFEED,&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;.SetTwainCap(TwainConstants.CAP_DUPLEXENABLED,&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;.SetDiscardBlankPages(<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;.SetBlankPageThreshold(<span class="cs__number">0</span>.02m)&nbsp;<span class="cs__com">//&nbsp;Discard&nbsp;pages&nbsp;with&nbsp;ink&nbsp;coverage&nbsp;&lt;&nbsp;2%</span>&nbsp;
&nbsp;&nbsp;.AddOutputItem(<span class="cs__keyword">new</span>&nbsp;RequestOutputItem(AspriseImaging.OUTPUT_SAVE,&nbsp;AspriseImaging.FORMAT_PDF).SetSavePath(<span class="cs__string">&quot;.\\${TMS}${EXT}&quot;</span>)),&nbsp;
&nbsp;<span class="cs__string">&quot;select&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;pdfFile&nbsp;=&nbsp;result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;result.GetPdfFile();&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Documents&nbsp;scanned&nbsp;as&nbsp;PDF:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;pdfFile);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Alternatively,&nbsp;request&nbsp;can&nbsp;be&nbsp;specified&nbsp;using&nbsp;the&nbsp;following&nbsp;JSON:</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;twain_cap_setting&quot;</span>&nbsp;:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;CAP_FEEDERENABLED&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;CAP_AUTOFEED&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;CAP_DUPLEXENABLED&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;discard_blank_pages&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;pages&nbsp;with&nbsp;ink&nbsp;coverage&nbsp;below&nbsp;the&nbsp;threshold&nbsp;will&nbsp;be&nbsp;discarded</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;blank_page_threshold&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;0.02&quot;</span>,&nbsp;<span class="cs__com">//&nbsp;default&nbsp;value&nbsp;is&nbsp;0.02</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;output_settings&quot;</span>&nbsp;:&nbsp;[&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;type&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;save&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;format&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;pdf&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;save_path&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;.\\${TMS}${EXT}&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;]&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h1>More Information</h1>
<p style="font-size:15px; line-height:22px; margin-top:0px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/c%23-vb.net-scanner-api/twain-wia-scan-pdf-library-overview.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="-icon-scan-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Learn
 more about Asprise Scan C# VB.NET SDK for TWAIN WIA Scanners</a></p>
<p style="font-size:15px; line-height:22px; margin-top:0px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/c%23-vb.net-scanner-api/twain-wia-document-scan-library-sdk-samples-docs.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="-icon-book-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Access
 to Asprise Scan C# VB.NET Developer's Guide</a></p>
<p style="font-size:15px; line-height:22px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/scan2/docs/Help/index.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="-icon-code-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Browse API
 (MSDN style) online</a></p>
