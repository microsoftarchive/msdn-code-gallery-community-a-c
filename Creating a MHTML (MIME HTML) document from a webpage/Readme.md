# Creating a MHTML (MIME HTML) document from a webpage
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- MHTML
- CDO
- MIME
## Topics
- Document Conversion
## Updated
- 06/23/2011
## Description

<p>I recently had to generate a MHTML (MIME HTML) document from a webpage in .NET. Searching for existing solutions, I found some articles around CDO and IE/Browser object automation but did not find a definite guide. So here is a sample of two different approaches
 for creating a MHTML document from a webpage.</p>
<p>&nbsp;<img src="23826-mhtml%20maker.png" alt="" width="663" height="285"></p>
<h2></h2>
<h2>CDO Approach</h2>
<p>The main advantage of using CDO is that it has a built-in method for creating a MHTML document.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Message message = new MessageClass {MimeFormatted = true};
message.CreateMHTMLBody(url, CdoMHTMLFlags.cdoSuppressNone, &quot;&quot;, &quot;&quot;);</pre>
<div class="preview">
<pre id="codePreview" class="csharp">Message&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageClass&nbsp;{MimeFormatted&nbsp;=&nbsp;<span class="cs__keyword">true</span>};&nbsp;
message.CreateMHTMLBody(url,&nbsp;CdoMHTMLFlags.cdoSuppressNone,&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>CDO will automatically embed images and external css files. If you have to embed other external resources, you will have to do some coding. Here is an example for embedding javascript:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var scriptPart = message.BodyPart.AddBodyPart();
scriptPart.ContentMediaType = &quot;text/javascript&quot;;
scriptPart.Charset = &quot;iso-8859-1&quot;;
scriptPart.ContentTransferEncoding = &quot;quoted-printable&quot;;
scriptPart.Fields[&quot;urn:schemas:mailheader:content-id&quot;].Value = id;
scriptPart.Fields[&quot;urn:schemas:mailheader:content-disposition&quot;].Value = &quot;inline&quot;;
scriptPart.Fields.Update();

var stream = scriptPart.GetDecodedContentStream();
var scriptStream = (IStream)stream;
var scriptContent = _webRequestHelper.GetContent(absoluteScriptUrl);
scriptStream.Write(scriptContent.Content, scriptContent.Content.Length, IntPtr.Zero);
stream.Flush();
stream.Close();

message.HTMLBody = message.HTMLBody.Replace(scriptUrl, &quot;cid:&quot; &#43; id);</pre>
<div class="preview">
<pre id="codePreview" class="csharp">var&nbsp;scriptPart&nbsp;=&nbsp;message.BodyPart.AddBodyPart();&nbsp;
scriptPart.ContentMediaType&nbsp;=&nbsp;<span class="cs__string">&quot;text/javascript&quot;</span>;&nbsp;
scriptPart.Charset&nbsp;=&nbsp;<span class="cs__string">&quot;iso-8859-1&quot;</span>;&nbsp;
scriptPart.ContentTransferEncoding&nbsp;=&nbsp;<span class="cs__string">&quot;quoted-printable&quot;</span>;&nbsp;
scriptPart.Fields[<span class="cs__string">&quot;urn:schemas:mailheader:content-id&quot;</span>].Value&nbsp;=&nbsp;id;&nbsp;
scriptPart.Fields[<span class="cs__string">&quot;urn:schemas:mailheader:content-disposition&quot;</span>].Value&nbsp;=&nbsp;<span class="cs__string">&quot;inline&quot;</span>;&nbsp;
scriptPart.Fields.Update();&nbsp;
&nbsp;
var&nbsp;stream&nbsp;=&nbsp;scriptPart.GetDecodedContentStream();&nbsp;
var&nbsp;scriptStream&nbsp;=&nbsp;(IStream)stream;&nbsp;
var&nbsp;scriptContent&nbsp;=&nbsp;_webRequestHelper.GetContent(absoluteScriptUrl);&nbsp;
scriptStream.Write(scriptContent.Content,&nbsp;scriptContent.Content.Length,&nbsp;IntPtr.Zero);&nbsp;
stream.Flush();&nbsp;
stream.Close();&nbsp;
&nbsp;
message.HTMLBody&nbsp;=&nbsp;message.HTMLBody.Replace(scriptUrl,&nbsp;<span class="cs__string">&quot;cid:&quot;</span>&nbsp;&#43;&nbsp;id);</pre>
</div>
</div>
</div>
<p></p>
<p>The main disadvantages of using CDO are:</p>
<ul>
<li>COM Interop! </li><li>Does not work in 64 bit systems (x64) </li><li>Requires STA (Single Threaded Apartment), so if you use this in an ASP.NET application, you will have to do some threading tricks.
</li></ul>
<p>&nbsp;</p>
<h2>System.Net.Mail</h2>
<p>You can also create a MHTML document using MailMessage in System.Net.Mail. There is little more work involved but you do not have to deal with COM Interop or 32bit limitation.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var message = new MailMessage { From = new MailAddress(&quot;a@a.com&quot;) };
var view = AlternateView.CreateAlternateViewFromString(htmlString.ToString(), new ContentType(&quot;text/html&quot;));
view.TransferEncoding = TransferEncoding.SevenBit;
message.AlternateViews.Add(view);</pre>
<div class="preview">
<pre id="codePreview" class="csharp">var&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage&nbsp;{&nbsp;From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;a@a.com&quot;</span>)&nbsp;};&nbsp;
var&nbsp;view&nbsp;=&nbsp;AlternateView.CreateAlternateViewFromString(htmlString.ToString(),&nbsp;<span class="cs__keyword">new</span>&nbsp;ContentType(<span class="cs__string">&quot;text/html&quot;</span>));&nbsp;
view.TransferEncoding&nbsp;=&nbsp;TransferEncoding.SevenBit;&nbsp;
message.AlternateViews.Add(view);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>You will have to do all the work of detecting external resources, downloading them and then adding them as MimeParts. Here is an example on how to do that:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var id = Guid.NewGuid().ToString();

var result = _webRequestHelper.GetContent(absoluteUrl);

var ms = new MemoryStream(result.Content);
var lr = new LinkedResource(ms, new ContentType(result.ContentType)) {ContentId = id, TransferEncoding = TransferEncoding.Base64};
resources.Add(lr);

htmlString.Replace(url, &quot;cid:&quot; &#43; id);
</pre>
<div class="preview">
<pre id="codePreview" class="js"><span class="js__statement">var</span>&nbsp;id&nbsp;=&nbsp;Guid.NewGuid().ToString();&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;_webRequestHelper.GetContent(absoluteUrl);&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;ms&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MemoryStream(result.Content);&nbsp;
<span class="js__statement">var</span>&nbsp;lr&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;LinkedResource(ms,&nbsp;<span class="js__operator">new</span>&nbsp;ContentType(result.ContentType))&nbsp;<span class="js__brace">{</span>ContentId&nbsp;=&nbsp;id,&nbsp;TransferEncoding&nbsp;=&nbsp;TransferEncoding.Base64<span class="js__brace">}</span>;&nbsp;
resources.Add(lr);&nbsp;
&nbsp;
htmlString.Replace(url,&nbsp;<span class="js__string">&quot;cid:&quot;</span>&nbsp;&#43;&nbsp;id);&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>One little caveat of this approach is that there isn&rsquo;t an easy way to get to the MHTML document content unless you intend to send it in an email. So I had to write a small extension method using reflection to pull it out as a byte array.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var sendMethod = typeof(MailMessage).GetMethod(&quot;Send&quot;, BindingFlags.Instance | BindingFlags.NonPublic);

sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { GetMailWriter(ms), false }, null);

private static object GetMailWriter(MemoryStream ms)
{
    var assembly = typeof(MailMessage).Assembly;
    var mailWriterType = assembly.GetType(&quot;System.Net.Mail.MailWriter&quot;);
    var mailWriterConstructorInfo = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);

    return mailWriterConstructorInfo.Invoke(new object[] { ms });
}</pre>
<div class="preview">
<pre id="codePreview" class="js"><span class="js__statement">var</span>&nbsp;sendMethod&nbsp;=&nbsp;<span class="js__operator">typeof</span>(MailMessage).GetMethod(<span class="js__string">&quot;Send&quot;</span>,&nbsp;BindingFlags.Instance&nbsp;|&nbsp;BindingFlags.NonPublic);&nbsp;
&nbsp;
sendMethod.Invoke(message,&nbsp;BindingFlags.Instance&nbsp;|&nbsp;BindingFlags.NonPublic,&nbsp;null,&nbsp;<span class="js__operator">new</span>[]&nbsp;<span class="js__brace">{</span>&nbsp;GetMailWriter(ms),&nbsp;false&nbsp;<span class="js__brace">}</span>,&nbsp;null);&nbsp;
&nbsp;
private&nbsp;static&nbsp;object&nbsp;GetMailWriter(MemoryStream&nbsp;ms)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;assembly&nbsp;=&nbsp;<span class="js__operator">typeof</span>(MailMessage).Assembly;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;mailWriterType&nbsp;=&nbsp;assembly.GetType(<span class="js__string">&quot;System.Net.Mail.MailWriter&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;mailWriterConstructorInfo&nbsp;=&nbsp;mailWriterType.GetConstructor(BindingFlags.Instance&nbsp;|&nbsp;BindingFlags.NonPublic,&nbsp;null,&nbsp;<span class="js__operator">new</span>[]&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__operator">typeof</span>(Stream)&nbsp;<span class="js__brace">}</span>,&nbsp;null);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;mailWriterConstructorInfo.Invoke(<span class="js__operator">new</span>&nbsp;object[]&nbsp;<span class="js__brace">{</span>&nbsp;ms&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>This sample does not include code for handling css background images and iframes but it shouldn&rsquo;t be too hard to modify the sample to handle those.</p>
