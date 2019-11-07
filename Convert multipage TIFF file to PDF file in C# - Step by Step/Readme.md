# Convert multipage TIFF file to PDF file in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Win32
- Windows Forms
- Microsoft Azure
- .NET Framework
- .NET Framework 4.0
- Graphics Functions
## Topics
- Controls
- Graphics
- C#
- ASP.NET
- User Interface
- Graphics and 3D
- Microsoft Azure
- Image
- How to
- BitmapImage
## Updated
- 02/04/2016
## Description

<h1>Introduction</h1>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em>This is a C# example to convert multiTIFF file to PDF via a free C# PDF library.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em>If you are searching for a solution to convert multipages Tiff images into PDF-format in C#, stop the searching - you're in the right place! The PDF Vison .Net is only the one library designed for this purpose.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em>Only the .Net platform and nothing else, 32 and 64-bit support, Full Trust level, converting of all types of Images, works under Windows, Mac, Linux and a lot of other nuances</em><em>.</em></p>
<h1>Main Functions</h1>
<p><img id="148214" src="148214-screen.png" alt="" width="800" height="513"></p>
<h1>How to do it:</h1>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em>So, here we'll show you in details how to convert a multi Tiff images to PDF in C#.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the tiff file: multipages.tiff (please see in att. file) and we need to create an PDF document.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em>Type the application name and location, for example &quot;multi tiff to pdf&quot; and &quot;c:\samples&quot;.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.PdfVison.dll&quot;</em><em>.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to convert our&nbsp;</em><em style="font-size:13.008px">multipages.tiff&nbsp;</em><em>image into&nbsp;</em><em style="font-size:13.008px">multipages.</em><em>pdf.</em></p>
<p style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px">
<em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><em style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px"><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the PDF Visoin.Net library we've created an PDF file.</em><em>&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {

            //Convert multipage TIFF file to PDF file
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();
            // You may download the latest version of SDK here:   
            // www.sautinsoft.com/products/convert-html-pdf-and-tiff-pdf-asp.net/download.php 

            //specify converting options
            v.PageStyle.PageSize.Auto();
             
            string tiffPath = Path.GetFullPath(@&quot;d:\Tempos\multipages.tiff&quot;);
            string pdfPath = Path.ChangeExtension(tiffPath, &quot;.pdf&quot;);

            //Convert image file to pdf
            int ret = v.ConvertImageFileToPDFFile(tiffPath, pdfPath);

            if (ret == 0)
            {
                //Show produced PDF in Acrobat Reader
                System.Diagnostics.Process.Start(pdfPath);
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Test&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Convert&nbsp;multipage&nbsp;TIFF&nbsp;file&nbsp;to&nbsp;PDF&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.PdfVision&nbsp;v&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.PdfVision();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;www.sautinsoft.com/products/convert-html-pdf-and-tiff-pdf-asp.net/download.php&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//specify&nbsp;converting&nbsp;options</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v.PageStyle.PageSize.Auto();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;tiffPath&nbsp;=&nbsp;Path.GetFullPath(@<span class="cs__string">&quot;d:\Tempos\multipages.tiff&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pdfPath&nbsp;=&nbsp;Path.ChangeExtension(tiffPath,&nbsp;<span class="cs__string">&quot;.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Convert&nbsp;image&nbsp;file&nbsp;to&nbsp;pdf</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;ret&nbsp;=&nbsp;v.ConvertImageFileToPDFFile(tiffPath,&nbsp;pdfPath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ret&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Show&nbsp;produced&nbsp;PDF&nbsp;in&nbsp;Acrobat&nbsp;Reader</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(pdfPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1 style="color:#3a3e43; font-family:'Segoe UI',Verdana,Arial; font-size:1.4em; margin:0px">
Source Code Files</h1>
<h1>
<div style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px; font-weight:normal">
<em>Related Links:</em></div>
<div style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px; font-weight:normal">
<em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/" style="color:#960bb4; text-decoration:none">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/convert-html-pdf-and-tiff-pdf-asp.net/html-to-pdf-jpeg-tiff-gif-to-pdf-asp.net.php" style="color:#960bb4; text-decoration:none">PDF Vision .NET</a><br>
Download:&nbsp;<a href="http://sautinsoft.com/thankyou.php?download=5" style="color:#960bb4; text-decoration:none">PDF Vision .NET</a><br>
</em></div>
</h1>
<h2 class="H2Text" style="color:#3a3e43; font-family:'Segoe UI',Verdana,Arial; font-size:1.2em">
Requrements and Technical Information</h2>
<h1>
<p class="CommonText" style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13.008px; font-weight:normal">
<em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that PDF Vision.Net is entirely written in managed C#, which makes it absolutely standalone and
 an independent library</em></p>
</h1>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
<h2 class="projectSummary" style="border:0px; font-weight:normal; font-family:'Segoe UI Semibold','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; margin:4px 0px 11px; outline:0px; padding:0px; clear:both; color:#2a2a2a; line-height:1.4; font-size:1.1em; word-wrap:break-word">
This is a C# example to convert Jpeg file to PDF via a free C# PDF library.If you are searching for a solution to convert Jpeg images into PDF-format in C#, stop the searching - you're in the right place!</h2>
</div>
