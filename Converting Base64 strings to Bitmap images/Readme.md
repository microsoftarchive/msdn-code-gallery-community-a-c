# Converting Base64 strings to Bitmap images
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- WCF
- GDI+
- ASP.NET
- Windows Forms
- Web Services
- .NET Framework
- ASP.NET Web Forms
- ASMX web services
- HTML
- HTML5
- website
- Graphics Functions
- ASP.NET 4.5
- asp.net 4.0
- .NET 4.5
## Topics
- C#
- WCF
- GDI+
- WCF Data Services
- Web Services
- HTTP Download
- WebBrowser
- HttpWebRequest
- HTML
- Data Import
- HTML5
- Generic C# resuable code
- web service
- Base64 Encoding
- WebService
- Load Image
- Extension methods
## Updated
- 03/01/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify">This article details how to decode or convert Base64 encoded strings back into
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> images by means of extending the string class.</p>
<p style="text-align:justify"><strong>Note:</strong> This article is an update that builds upon the article:
<a href="http://code.msdn.microsoft.com/Encoding-Bitmaps-to-Base64-603248e3" target="_blank">
Encoding Bitmaps to Base64 Strings</a></p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify">There are&nbsp;no special requirements or instructions for building the sample source code.</p>
<h1><span style="font-size:20px; font-weight:bold">Description - Images as Base64 strings</span></h1>
<p style="text-align:justify">From <a href="http://en.wikipedia.org/wiki/Base64">
Wikipedia</a>:</p>
<blockquote>
<p><strong>Base64</strong> is a group of similar encoding schemes that represent <a href="http://en.wikipedia.org/wiki/Binary_data">
binary data</a> in an ASCII string format by translating it into a <a href="http://en.wikipedia.org/wiki/Radix">
radix</a>-64 representation. The Base64 term originates from a specific <a href="http://en.wikipedia.org/wiki/MIME#Content-Transfer-Encoding">
MIME content transfer encoding</a>.</p>
<p>Base64 encoding schemes are commonly used when there is a need to encode binary data that need to be stored and transferred over media that are designed to deal with textual data. This is to ensure that the data remain intact without modification during
 transport. Base64 is commonly used in a number of applications including <a href="http://en.wikipedia.org/wiki/Email">
email</a> via <a href="http://en.wikipedia.org/wiki/MIME">MIME</a>, and storing complex data in
<a href="http://en.wikipedia.org/wiki/XML">XML</a>.</p>
</blockquote>
<p style="text-align:justify">From the definition quoted above the need for base64 encoding becomes more clear. From
<a href="http://msdn.microsoft.com/en-us/library/dhx0d524.aspx">MSDN documentation</a>:</p>
<blockquote>
<p>The base-64 digits in ascending order from zero are the uppercase characters &quot;A&quot; to &quot;Z&quot;, the lowercase characters &quot;a&quot; to &quot;z&quot;, the numerals &quot;0&quot; to &quot;9&quot;, and the symbols &quot;&#43;&quot; and &quot;/&quot;. The valueless character, &quot;=&quot;, is used for trailing padding.</p>
</blockquote>
<p style="text-align:justify">Base64 encoding allows developers to expose binary data without potentially encountering conflicts in regards to the transfer medium. Base64 encoded binary data serves ideally when performing data transfer operations using platforms
 such as html, xml, email.</p>
<p style="text-align:justify">A common implementation of Base64 encoding can be found when transferring image data. This article details how to convert/decode a Base64 string back into a
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx">Bitmap</a> image.</p>
<h1>Base64 String to Bitmap decoding implemented as an extension method</h1>
<p style="text-align:justify">The code snippet listed below details the <strong><em>Base64StringToBitmap</em></strong> extension method targeting the String class.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap Base64StringToBitmap(this string base64String)
{
    Bitmap bmpReturn = null;

    byte[] byteBuffer = Convert.FromBase64String(base64String);
    MemoryStream memoryStream = new MemoryStream(byteBuffer);

    memoryStream.Position = 0;

    bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

    memoryStream.Close();
    memoryStream = null;
    byteBuffer = null;

    return bmpReturn;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;Base64StringToBitmap(<span class="cs__keyword">this</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;base64String)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmpReturn&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;byteBuffer&nbsp;=&nbsp;Convert.FromBase64String(base64String);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;memoryStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream(byteBuffer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream.Position&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmpReturn&nbsp;=&nbsp;(Bitmap)Bitmap.FromStream(memoryStream);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;byteBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;bmpReturn;&nbsp;
}</pre>
</div>
</div>
</div>
<p style="text-align:justify"><span>The Base64 string parameter is first converted to a byte array by invoking the
<a title="Convert.FromBase64String" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.convert.frombase64string.aspx" target="_blank">
Convert.FromBase64String</a> method. Next we create a <a title="MemoryStream" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.io.memorystream.aspx" target="_blank">
MemoryStream</a> against the resulting byte array, which serves as a parameter to the
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> class&rsquo; <a title="FromStream" rel="tag" href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms536294(v=vs.85).aspx" target="_blank">
FromStream</a> static method.</span></p>
<h1><span>The implementation</span></h1>
<p style="text-align:justify"><span>The <strong><em>Base64StringToBitmap</em></strong> extension method is implemented in a console based application. The sample source creates a
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> instance from the file system, which is then converted to a Base64 string. This article details how to convert Bitmaps to Base64 encoded strings:
<a href="http://code.msdn.microsoft.com/Encoding-Bitmaps-to-Base64-603248e3" target="_blank">
Encoding Bitmaps to Base64 Strings</a>, of which this article is a follow up article. Next the newly created Base64 string is converted back to a
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> image by invoking the <strong><em>Base64StringToBitmap</em></strong> extension method. In order to test if the Base64 string was decoded successfully the
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> image is saved to disk and displayed in the default installed application associated with png images.</span></p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
{
    StreamReader streamReader = new StreamReader(&quot;NavForward.png&quot;);
    Bitmap bmp = new Bitmap(streamReader.BaseStream);
    streamReader.Close();

    string base64ImageString = bmp.ToBase64String(ImageFormat.Png);

    Console.WriteLine(base64ImageString);

    Bitmap bmpFromString = base64ImageString.Base64StringToBitmap();
    bmpFromString.Save(&quot;FromBase64String.png&quot;, ImageFormat.Png);

    Process.Start(&quot;FromBase64String.png&quot;);

    Console.ReadKey();
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;streamReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(<span class="cs__string">&quot;NavForward.png&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(streamReader.BaseStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;streamReader.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64ImageString&nbsp;=&nbsp;bmp.ToBase64String(ImageFormat.Png);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(base64ImageString);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmpFromString&nbsp;=&nbsp;base64ImageString.Base64StringToBitmap();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmpFromString.Save(<span class="cs__string">&quot;FromBase64String.png&quot;</span>,&nbsp;ImageFormat.Png);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Process.Start(<span class="cs__string">&quot;FromBase64String.png&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ExtBitmap.cs - Contains the definition of Base64StringToBitmap extension method</em>
</li><li><em><em>Program.cs - Console based test application</em></em> </li></ul>
<h1>More Information</h1>
<div>
<p class="paragraphStyle">This article is based on an article originally posted on my
<a href="http://softwarebydefault.com">blog</a>:&nbsp;<a href="http://softwarebydefault.com/2013/03/01/base64-strings-bitmap/">http://softwarebydefault.com/2013/03/01/base64-strings-bitmap/</a> If you have any questions/comments please feel free to make use
 of the Q&amp;A section on this page, also please remember to rate this article.</p>
<strong>Dewald Esterhuizen</strong></div>
