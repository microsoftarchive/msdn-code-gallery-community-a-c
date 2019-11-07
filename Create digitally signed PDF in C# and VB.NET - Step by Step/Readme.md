# Create digitally signed PDF in C# and VB.NET - Step by Step
## Requires
- 
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- .NET
- Windows Forms
- WPF
- .NET Framework
- .NET Framework 4.0
- Visual C#
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- How to
- PDF
- PDF file
- Portable Document Format (pdf)
- Export to Pdf
- PDF API
- Converting DOCX/DOC/HTML/RTF to PDF/XPS/Image
- C# PDF
- PDF rasterizer
## Updated
- 05/22/2018
## Description

<h1>Introduction</h1>
<p>Digital signatures can be used for many types of documents where traditional pen-and-ink signatures were used in the past. However, the mere existence of a digital signature is not adequate assurance that a document is what it appears to be. Moreover, government
 and enterprise settings often need to impose additional constraints on their signature workflows, such as restricting user choices and document behavior during and after signing.</p>
<p>The following example shows how to create a digitally signed PDF document.<br>
<br>
Certificate file:&nbsp;SautinSoft.pfx.&nbsp;<br>
Signature file:&nbsp;Signature.png.</p>
<h1><span>Building the Sample</span></h1>
<p><em><span>First of all, you need to point an existing document (*.docx, *.rtf, *.pdf, *.html, *.txt, etc) which you want to sign by digital signature:</span></em></p>
<p><em>&nbsp;</em></p>
<p><em></em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Path to a loadable document.
string loadPath = @&quot;..\..\..\..\..\..\Testing Files\digitalsignature.docx&quot;;</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Path&nbsp;to&nbsp;a&nbsp;loadable&nbsp;document.</span>&nbsp;
string&nbsp;loadPath&nbsp;=&nbsp;@<span class="js__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\digitalsignature.docx&quot;</span>;</pre>
</div>
</div>
</em></div>
<p><em></p>
<div class="endscriptcode">&nbsp;<span>If you want, you may to add in your document a picture, symbolizes a handwritten signature.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Signature line added with MS Word -&gt; Insert tab -&gt; Signature Line button by default has description 'Microsoft Office Signature Line...'.
var signatureLine = document.GetChildElements(true).OfType().FirstOrDefault();
// This picture symbolizes a handwritten signature
var signature = new Picture(document, @&quot;..\..\..\..\..\..\Testing Files\signature.png&quot;);</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Signature&nbsp;line&nbsp;added&nbsp;with&nbsp;MS&nbsp;Word&nbsp;-&gt;&nbsp;Insert&nbsp;tab&nbsp;-&gt;&nbsp;Signature&nbsp;Line&nbsp;button&nbsp;by&nbsp;default&nbsp;has&nbsp;description&nbsp;'Microsoft&nbsp;Office&nbsp;Signature&nbsp;Line...'.</span>&nbsp;
<span class="js__statement">var</span>&nbsp;signatureLine&nbsp;=&nbsp;document.GetChildElements(true).OfType().FirstOrDefault();&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;picture&nbsp;symbolizes&nbsp;a&nbsp;handwritten&nbsp;signature</span>&nbsp;
<span class="js__statement">var</span>&nbsp;signature&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Picture(document,&nbsp;@<span class="js__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\signature.png&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Signature in this document will be 4.5 cm right of TopCenter position of signature line and 4.5 cm below of TopLeft position of signature line</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">signature.Layout = Layout.Floating(
new HorizontalPosition(4.5, LengthUnit.Centimeter, HorizontalPositionAnchor.Page),
new VerticalPosition(-4.5, LengthUnit.Centimeter, VerticalPositionAnchor.Page),
signature.Layout.Size);</pre>
<div class="preview">
<pre class="js">signature.Layout&nbsp;=&nbsp;Layout.Floating(&nbsp;
<span class="js__operator">new</span>&nbsp;HorizontalPosition(<span class="js__num">4.5</span>,&nbsp;LengthUnit.Centimeter,&nbsp;HorizontalPositionAnchor.Page),&nbsp;
<span class="js__operator">new</span>&nbsp;VerticalPosition(-<span class="js__num">4.5</span>,&nbsp;LengthUnit.Centimeter,&nbsp;VerticalPositionAnchor.Page),&nbsp;
signature.Layout.Size);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>And the last step is to point of a certificate (*.pfx) and its characteristics: Password of the certificate, Contact Info, etc.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Path to the certificate (*.pfx).
CertificatePath = @&quot;..\..\..\..\..\..\Testing Files\SautinSoft.pfx&quot;,
// Password of the certificate.
CertificatePassword = &quot;123456789&quot;,
// Additional information about the certificate.
Location = &quot;World Wide Web&quot;,
Reason = &quot;Document.Net by SautiSoft&quot;,
ContactInfo = &quot;info@sautinsoft.com&quot;,
// Placeholder where signature should be visualized.
SignatureLine = signatureLine,
// Visual representation of digital signature.
Signature = signature</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Path&nbsp;to&nbsp;the&nbsp;certificate&nbsp;(*.pfx).</span>&nbsp;
CertificatePath&nbsp;=&nbsp;@<span class="js__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\SautinSoft.pfx&quot;</span>,&nbsp;
<span class="js__sl_comment">//&nbsp;Password&nbsp;of&nbsp;the&nbsp;certificate.</span>&nbsp;
CertificatePassword&nbsp;=&nbsp;<span class="js__string">&quot;123456789&quot;</span>,&nbsp;
<span class="js__sl_comment">//&nbsp;Additional&nbsp;information&nbsp;about&nbsp;the&nbsp;certificate.</span>&nbsp;
Location&nbsp;=&nbsp;<span class="js__string">&quot;World&nbsp;Wide&nbsp;Web&quot;</span>,&nbsp;
Reason&nbsp;=&nbsp;<span class="js__string">&quot;Document.Net&nbsp;by&nbsp;SautiSoft&quot;</span>,&nbsp;
ContactInfo&nbsp;=&nbsp;<span class="js__string">&quot;info@sautinsoft.com&quot;</span>,&nbsp;
<span class="js__sl_comment">//&nbsp;Placeholder&nbsp;where&nbsp;signature&nbsp;should&nbsp;be&nbsp;visualized.</span>&nbsp;
SignatureLine&nbsp;=&nbsp;signatureLine,&nbsp;
<span class="js__sl_comment">//&nbsp;Visual&nbsp;representation&nbsp;of&nbsp;digital&nbsp;signature.</span>&nbsp;
Signature&nbsp;=&nbsp;signature</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>As the result, you will get the digitally&nbsp;</span><a href="http://localhost/data/files/digitalsignature.pdf">signed PDF</a><span>&nbsp;document.</span></div>
<div class="endscriptcode"><img id="185821" src="185821-screensignature.png" alt="" width="600" height="569"></div>
</div>
</div>
</div>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using SautinSoft.Document.Tables;
namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            DigitalSignature();
        }
        ///
        /// Load an existing document (*.docx, *.rtf, *.pdf, *.html, *.txt, *.pdf) and save it in a PDF document with the digital signature.
        ///
        public static void DigitalSignature()
        {
            // Path to a loadable document.
            string loadPath = @&quot;..\..\..\..\..\..\Testing Files\digitalsignature.docx&quot;;

            //DocumentCore.Serial = &quot;put your serial here&quot;;
            DocumentCore document = DocumentCore.Load(loadPath);

            // Signature line added with MS Word -&gt; Insert tab -&gt; Signature Line button by default has description 'Microsoft Office Signature Line...'.
            var signatureLine = document.GetChildElements(true).OfType().FirstOrDefault();
            // This picture symbolizes a handwritten signature
            var signature = new Picture(document, @&quot;..\..\..\..\..\..\Testing Files\signature.png&quot;);

            // Signature in this document will be 4.5 cm right of TopLeft position of signature line
            // and 4.5 cm below of TopLeft position of signature line.
             signature.Layout = Layout.Floating(
                new HorizontalPosition(4.5, LengthUnit.Centimeter, HorizontalPositionAnchor.Page),
                new VerticalPosition(-4.5, LengthUnit.Centimeter, VerticalPositionAnchor.Page),
                signature.Layout.Size);

            //signature.Layout = Layout.Inline(signature.Layout.Size);
            var options = new PdfSaveOptions()
            {
                DigitalSignature =
                {
                    // Path to the certificate (*.pfx).
                    CertificatePath = @&quot;..\..\..\..\..\..\Testing Files\SautinSoft.pfx&quot;,
                    // Password of the certificate.
                    CertificatePassword = &quot;123456789&quot;,
                    // Additional information about the certificate.
                    Location = &quot;World Wide Web&quot;,
                    Reason = &quot;Document.Net by SautiSoft&quot;,
                    ContactInfo = &quot;info@sautinsoft.com&quot;,
                    // Placeholder where signature should be visualized.
                    SignatureLine = signatureLine,
                    // Visual representation of digital signature.
                    Signature = signature
                }
            };

            string savePath = Path.ChangeExtension(loadPath, &quot;.pdf&quot;);
            document.Save(savePath, options);

            // Open file - digitalsignature.pdf.
            System.Diagnostics.Process.Start(savePath);
        }

    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document.Tables;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Sample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DigitalSignature();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Load&nbsp;an&nbsp;existing&nbsp;document&nbsp;(*.docx,&nbsp;*.rtf,&nbsp;*.pdf,&nbsp;*.html,&nbsp;*.txt,&nbsp;*.pdf)&nbsp;and&nbsp;save&nbsp;it&nbsp;in&nbsp;a&nbsp;PDF&nbsp;document&nbsp;with&nbsp;the&nbsp;digital&nbsp;signature.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DigitalSignature()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Path&nbsp;to&nbsp;a&nbsp;loadable&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;loadPath&nbsp;=&nbsp;@<span class="cs__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\digitalsignature.docx&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//DocumentCore.Serial&nbsp;=&nbsp;&quot;put&nbsp;your&nbsp;serial&nbsp;here&quot;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;document&nbsp;=&nbsp;DocumentCore.Load(loadPath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Signature&nbsp;line&nbsp;added&nbsp;with&nbsp;MS&nbsp;Word&nbsp;-&gt;&nbsp;Insert&nbsp;tab&nbsp;-&gt;&nbsp;Signature&nbsp;Line&nbsp;button&nbsp;by&nbsp;default&nbsp;has&nbsp;description&nbsp;'Microsoft&nbsp;Office&nbsp;Signature&nbsp;Line...'.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;signatureLine&nbsp;=&nbsp;document.GetChildElements(<span class="cs__keyword">true</span>).OfType().FirstOrDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;picture&nbsp;symbolizes&nbsp;a&nbsp;handwritten&nbsp;signature</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;signature&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Picture(document,&nbsp;@<span class="cs__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\signature.png&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Signature&nbsp;in&nbsp;this&nbsp;document&nbsp;will&nbsp;be&nbsp;4.5&nbsp;cm&nbsp;right&nbsp;of&nbsp;TopLeft&nbsp;position&nbsp;of&nbsp;signature&nbsp;line</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;and&nbsp;4.5&nbsp;cm&nbsp;below&nbsp;of&nbsp;TopLeft&nbsp;position&nbsp;of&nbsp;signature&nbsp;line.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signature.Layout&nbsp;=&nbsp;Layout.Floating(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;HorizontalPosition(<span class="cs__number">4.5</span>,&nbsp;LengthUnit.Centimeter,&nbsp;HorizontalPositionAnchor.Page),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;VerticalPosition(-<span class="cs__number">4.5</span>,&nbsp;LengthUnit.Centimeter,&nbsp;VerticalPositionAnchor.Page),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signature.Layout.Size);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//signature.Layout&nbsp;=&nbsp;Layout.Inline(signature.Layout.Size);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfSaveOptions()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DigitalSignature&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Path&nbsp;to&nbsp;the&nbsp;certificate&nbsp;(*.pfx).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CertificatePath&nbsp;=&nbsp;@<span class="cs__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\SautinSoft.pfx&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Password&nbsp;of&nbsp;the&nbsp;certificate.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CertificatePassword&nbsp;=&nbsp;<span class="cs__string">&quot;123456789&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Additional&nbsp;information&nbsp;about&nbsp;the&nbsp;certificate.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location&nbsp;=&nbsp;<span class="cs__string">&quot;World&nbsp;Wide&nbsp;Web&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Reason&nbsp;=&nbsp;<span class="cs__string">&quot;Document.Net&nbsp;by&nbsp;SautiSoft&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactInfo&nbsp;=&nbsp;<span class="cs__string">&quot;info@sautinsoft.com&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Placeholder&nbsp;where&nbsp;signature&nbsp;should&nbsp;be&nbsp;visualized.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SignatureLine&nbsp;=&nbsp;signatureLine,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Visual&nbsp;representation&nbsp;of&nbsp;digital&nbsp;signature.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Signature&nbsp;=&nbsp;signature&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;savePath&nbsp;=&nbsp;Path.ChangeExtension(loadPath,&nbsp;<span class="cs__string">&quot;.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.Save(savePath,&nbsp;options);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;file&nbsp;-&nbsp;digitalsignature.pdf.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(savePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><em>Related Links:</em></p>
<div><em>Install from Nuget: PM&gt; Install-Package sautinsoft.document.</em></div>
<div><em><span>&nbsp;</span><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/document/index.php">Document.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/products/docx-document/download.php">Document.Net</a></em><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><span>&nbsp;Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used.</span><br>
<br>
<span>Note that &laquo;Document .Net&raquo; is entirely written in managed C#, which makes it absolutely standalone and an independent library. Of course, No dependency on Microsoft Word.</span></p>
