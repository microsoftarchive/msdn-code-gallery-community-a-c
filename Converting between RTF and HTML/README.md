# Converting between RTF and HTML
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Rich Text
- XAML and HTML conversions
- RTF and HTML Conversions
## Updated
- 07/26/2012
## Description

<p>Have you ever had the desire to convert some RTF text into HTML or take HTML and generate a RTF document? Probably not. But if you did, then you are in luck! I recently had the need to do this conversion and after some searching found out a way to do it
 by enhancing a sample distributed in the MSDN library called: <a href="http://msdn.microsoft.com/en-us/library/aa972129.aspx">
XAML to HTML Conversion Demo</a>.</p>
<p>That sample has code which converts HTML to and from a XAML Flow Document. But this doesn&rsquo;t make things easier until you realize that there is a way to convert RTF to XAML and XAML to RTF&nbsp;easily. The key is to use
<a title="http://msdn.microsoft.com/en-us/library/system.windows.controls.richtextbox.aspx" href="http://msdn.microsoft.com/en-us/library/system.windows.controls.richtextbox.aspx">
System.Windows.Controls.RichTextBox</a> which can load RTF/XAML from a stream and save it as XAML/RTF.</p>
<p><strong>RTF to XAML</strong>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ConvertRtfToXaml(<span class="cs__keyword">string</span>&nbsp;rtfText)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;richTextBox&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RichTextBox();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">string</span>.IsNullOrEmpty(rtfText))&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;textRange&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TextRange(richTextBox.Document.ContentStart,&nbsp;richTextBox.Document.ContentEnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;rtfMemoryStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;rtfStreamWriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamWriter(rtfMemoryStream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtfStreamWriter.Write(rtfText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtfStreamWriter.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtfMemoryStream.Seek(<span class="cs__number">0</span>,&nbsp;SeekOrigin.Begin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textRange.Load(rtfMemoryStream,&nbsp;DataFormats.Rtf);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;rtfMemoryStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textRange&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TextRange(richTextBox.Document.ContentStart,&nbsp;richTextBox.Document.ContentEnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textRange.Save(rtfMemoryStream,&nbsp;DataFormats.Xaml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtfMemoryStream.Seek(<span class="cs__number">0</span>,&nbsp;SeekOrigin.Begin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;rtfStreamReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(rtfMemoryStream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;rtfStreamReader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><strong>XAML to RTF</strong>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;static&nbsp;string&nbsp;ConvertXamlToRtf(string&nbsp;xamlText)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;richTextBox&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;RichTextBox();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(string.IsNullOrEmpty(xamlText))&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;textRange&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;TextRange(richTextBox.Document.ContentStart,&nbsp;richTextBox.Document.ContentEnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;xamlMemoryStream&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;xamlStreamWriter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StreamWriter(xamlMemoryStream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xamlStreamWriter.Write(xamlText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xamlStreamWriter.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xamlMemoryStream.Seek(<span class="js__num">0</span>,&nbsp;SeekOrigin.Begin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textRange.Load(xamlMemoryStream,&nbsp;DataFormats.Xaml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;rtfMemoryStream&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textRange&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;TextRange(richTextBox.Document.ContentStart,&nbsp;richTextBox.Document.ContentEnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textRange.Save(rtfMemoryStream,&nbsp;DataFormats.Rtf);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtfMemoryStream.Seek(<span class="js__num">0</span>,&nbsp;SeekOrigin.Begin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;rtfStreamReader&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StreamReader(rtfMemoryStream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;rtfStreamReader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><strong>&nbsp;</strong>With this code we have all we need to convert RTF to HTML and HTML to RTF. I modified the MSDN library sample to add this RTF/XAML to XAML/RTF conversion and then I either run that XAML through HTML converter which results in the HTML
 text or I run the HTML through the XAML converter and generate XAML text. I added an interface for these conversion utilities and converted the sample into a library so that I would be able to use it from other projects. Here is the interface:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IMarkupConverter&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ConvertXamlToHtml(string&nbsp;xamlText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ConvertHtmlToXaml(string&nbsp;htmlText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ConvertRtfToHtml(string&nbsp;rtfText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ConvertHtmlToRtf(string&nbsp;htmlText);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;class&nbsp;MarkupConverter&nbsp;:&nbsp;IMarkupConverter&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ConvertXamlToHtml(string&nbsp;xamlText)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;HtmlFromXamlConverter.ConvertXamlToHtml(xamlText,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ConvertHtmlToXaml(string&nbsp;htmlText)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;HtmlToXamlConverter.ConvertHtmlToXaml(htmlText,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ConvertRtfToHtml(string&nbsp;rtfText)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;RtfToHtmlConverter.ConvertRtfToHtml(rtfText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ConvertHtmlToRtf(string&nbsp;htmlText)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;HtmlToRtfConverter.ConvertHtmlToRtf(htmlText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>With this I am now able to convert from RTF to HTML and from HTML to RTF. However, there is one catch &ndash; the conversion uses the RichTextBox WPF control which requires a single threaded apartment (STA). Therefore in order to run your code that calls
 the ConvertRtfToHtml or ConvertHtmlToRtf functions,&nbsp;they must also be running in a STA. If you can&rsquo;t have your program run in a STA (for example: when running an ASP .NET website)&nbsp;then you must create a new STA thread to run the conversion.
 Like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">MarkupConverter&nbsp;markupConverter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MarkupConverter();&nbsp;
&nbsp;&nbsp;
private&nbsp;string&nbsp;ConvertRtfToHtml(string&nbsp;rtfText)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;thread&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Thread(ConvertRtfInSTAThread);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;threadData&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ConvertRtfThreadData&nbsp;<span class="js__brace">{</span>&nbsp;RtfText&nbsp;=&nbsp;rtfText&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;thread.SetApartmentState(ApartmentState.STA);&nbsp;
&nbsp;&nbsp;&nbsp;thread.Start(threadData);&nbsp;
&nbsp;&nbsp;&nbsp;thread.Join();&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;threadData.HtmlText;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
private&nbsp;<span class="js__operator">void</span>&nbsp;ConvertRtfInSTAThread(object&nbsp;rtf)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;threadData&nbsp;=&nbsp;rtf&nbsp;as&nbsp;ConvertRtfThreadData;&nbsp;
&nbsp;&nbsp;&nbsp;threadData.HtmlText&nbsp;=&nbsp;markupConverter.ConvertRtfToHtml(threadData.RtfText);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
private&nbsp;class&nbsp;ConvertRtfThreadData&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;RtfText&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;HtmlText&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;That is all there is too it! Hopefully, this will come in handy for anyone needing to perform this conversion.</p>
<p>&nbsp;</p>
<p><span style="font-size:large">Read more from <a href="http://matthewmanela.com/">
Matthew Manela</a>&nbsp;at his <a href="http://matthewmanela.com/">blog</a>...</span></p>
