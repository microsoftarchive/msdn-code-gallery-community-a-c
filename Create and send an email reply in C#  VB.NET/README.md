# Create and send an email reply in C# / VB.NET
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- .NET Framework
- VB.Net
## Topics
- C#
- Send Email
- VB.Net
- Reply Email
## Updated
- 09/02/2016
## Description

<p>Here you can download the latest version of the demo .NET application, with C# and VB.NET source code:<br>
<a href="http://www.gemboxsoftware.com/Email/Articles/EmailReply.zip">Download EmailReply.zip</a></p>
<h2>Introduction</h2>
<p>Some time ago I needed a <strong>solution for sending email replies using C#</strong>. An internet search didn&rsquo;t return any usable examples, so I needed to investigate it on my own. I wrote this article in the hope that it would be useful for someone
 trying to <strong>create and send an email message reply programmatically in a .NET application</strong>. It was mainly to save you the trouble of going through RFC documents and understanding the email message format (MIME).</p>
<h2 id="EmailReplyStandard">Email reply standard</h2>
<p>The <a href="https://en.wikipedia.org/wiki/MIME">MIME</a>&nbsp;standard extends the original ASCII text-only email format to support character sets other than ASCII, non-text attachments and multipart message bodies. Although the standard is very old, it
 is still in use and most of today&rsquo;s email messages are still sent and received in this format.</p>
<p>The format is specified in a few RFC documents, but since each of them has been updated, it took me a while to find the info on writing reply messages.
<a href="https://tools.ietf.org/html/rfc2822#section-3.6.4">RFC 2822</a> defines <em>
&ldquo;identification fields&rdquo;</em>, better known as headers, which need to be defined in an email message reply. For an email message to qualify as a reply, it needs to contain the headers
<em>&ldquo;In-Reply-To&rdquo;</em> and <em>&ldquo;References&rdquo;</em>.</p>
<p>The standard also states that you should prefix the email message subject with &ldquo;Re:&rdquo; (from Latin &ldquo;res&rdquo; meaning &ldquo;in the matter of&rdquo;), although it is not mandatory.</p>
<h2>What about the email message body?</h2>
<p>It came as a surprise to me that the email message reply examples in <a href="https://tools.ietf.org/html/rfc2822#appendix-A.2">
RFC 2822</a> <em>don&rsquo;t include the original email message body</em>, especially since all of the email replies in my inbox do. It&rsquo;s because most of the commonly used email clients have this option enabled by default, but it can be disabled.</p>
<p>Although there is no standard defining the format for quoting in a plain text message, the '&gt;' sign is the most commonly used quote prefix char. Basically, you prefix every line of the original message text with a '&gt;' sign. You can read more about
 it <a href="https://en.wikipedia.org/wiki/Posting_style">here</a>. For HTML message bodies, there is no standard at all. Not even a convention. You are free to include the original text any way you see fit. Most of the email clients use the
<code>&lt;blockquote&gt;</code> tag, but some use the <code>&lt;div&gt;</code> tag with custom styling.</p>
<p><img id="159164" src="159164-message.png" alt="" width="673" height="504"></p>
<p style="text-align:center"><em>Screenshot of an email message reply</em></p>
<h2>C# / VB.NET code</h2>
<p>Now that we have some knowledge of the subject, we can take a look at the code.</p>
<pre class="csharp"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span><span>Visual Basic</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><span class="hidden">vb</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Download&nbsp;unread&nbsp;messages&nbsp;from&nbsp;the&nbsp;server</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&nbsp;messages&nbsp;=&nbsp;GetMessages();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(messages&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(messages.Count().ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;new&nbsp;message(s).&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;message&nbsp;replies</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&nbsp;replies&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(MailMessage&nbsp;msg&nbsp;<span class="cs__keyword">in</span>&nbsp;messages)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;replies.Add(CreateReply(msg));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Send&nbsp;replies</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendReplies(replies);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;No&nbsp;new&nbsp;messages.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Press&nbsp;any&nbsp;key&nbsp;to&nbsp;exit...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
}</pre>
</div>
</div>
</div>
</pre>
<p>Method <code>Main</code> first checks if there are any new unseen email messages on the server. If
<code>GetMessages</code> returns a not-null enumeration of email messages, the result is enumerated and a reply message is created for each item, using the
<code>CreateReply</code> method. Since the original email messages won&rsquo;t be needed any more, they are disposed of after creating the replies. At the end, the replies are passed to the
<code>SendReplies</code> method which will send them using <code>System.Net.SmtpClient</code>. Since this is a console application, progress info is displayed on the console window.</p>
<h3>Reading emails with an IMAP client</h3>
<p>There are two standard email protocols that can be used for fetching email messages, POP and IMAP. Unfortunately, the .NET framework doesn&rsquo;t provide support for either of them. It supports only SMTP, which can be used only for sending email messages.
 The following code uses <a href="https://github.com/smiley22/S22.Imap">S22.Imap</a>, a third party IMAP client for downloading messages from the server.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEnumerable&nbsp;GetMessages()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(ImapClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ImapClient(imapHost,&nbsp;<span class="cs__number">993</span>,&nbsp;<span class="cs__keyword">true</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Connected&nbsp;to&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imapHost&nbsp;&#43;&nbsp;<span class="cs__string">'.'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Login</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.Login(imapUser,&nbsp;imapPassword,&nbsp;AuthMethod.Auto);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Authenticated.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;a&nbsp;collection&nbsp;of&nbsp;all&nbsp;unseen&nbsp;messages&nbsp;in&nbsp;the&nbsp;INBOX&nbsp;folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.DefaultMailbox&nbsp;=&nbsp;<span class="cs__string">&quot;INBOX&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&nbsp;uids&nbsp;=&nbsp;client.Search(SearchCondition.Unseen());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(uids.Count()&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;client.GetMessages(uids);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>S22.Imap makes retrieving new messages a trivial task. First, you need to initialize a new
<code>ImapClient</code>, which connects to the server. The next step is authentication, which is executed by calling the
<code>Login</code> method with the mailbox username, password and authentication method as parameters. Use
<code>AuthMethod.Auto</code> because it will select the best authentication method that the server supports.</p>
<p>The next step is to set <em>&ldquo;INBOX&rdquo; as a default mailbox</em> and query the server for all unseen messages. The method returns an enumeration of message IDs. If that enumeration is not empty, the
<code>GetMessages</code> method is called, which will return an enumeration of <code>
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Mail.MailMessage.aspx" target="_blank" title="Auto generated link to System.Net.Mail.MailMessage">System.Net.Mail.MailMessage</a></code> instances for the provided message IDs.</p>
<h3>Creating a reply message</h3>
<p>After all the unseen messages have been downloaded, replies are created by calling the
<code>CreateReply</code> method in a loop, as you can see in the following code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Create&nbsp;message&nbsp;replies</span>&nbsp;
List&nbsp;replies&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List();&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(MailMessage&nbsp;msg&nbsp;<span class="cs__keyword">in</span>&nbsp;messages)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;replies.Add(CreateReply(msg));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;msg.Dispose();&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">The <code>CreateReply</code> method first creates a new mail message with the sender and receiver addresses swapped.</p>
<p class="endscriptcode">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">MailMessage&nbsp;reply&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage(<span class="cs__keyword">new</span>&nbsp;MailAddress(imapUser,&nbsp;<span class="cs__string">&quot;Sender&quot;</span>),&nbsp;source.From);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><code>source.To</code> cannot be used as a <em>from</em> parameter since it is a collection of email addresses instead of a single address and it might contain multiple addresses, so you could end up with the wrong one. In the example
 code, I have used a username defined for IMAP server authentication. Be sure to specify the full email address of the user as a username, when using your credentials, or it won&rsquo;t work as expected.</div>
<p>&nbsp;</p>
<p>The first thing you need to do with a reply message is to add the required headers. As explained in the
<a href="#EmailReplyStandard">Email reply standard</a> section, these are <em>&quot;In-Reply-To&quot;</em> and
<em>&quot;References&quot;</em>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;id&nbsp;=&nbsp;source.Headers[<span class="cs__string">&quot;Message-ID&quot;</span>];&nbsp;
reply.Headers.Add(<span class="cs__string">&quot;In-Reply-To&quot;</span>,&nbsp;id);&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;references&nbsp;=&nbsp;source.Headers[<span class="cs__string">&quot;References&quot;</span>];&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(references))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;references&nbsp;&#43;=&nbsp;<span class="cs__string">'&nbsp;'</span>;&nbsp;
&nbsp;
reply.Headers.Add(<span class="cs__string">&quot;References&quot;</span>,&nbsp;references&nbsp;&#43;&nbsp;id);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Although <em>&quot;Message-ID&quot;</em> header is not mandatory, most messages will contain it, especially those from major providers like Gmail, Yahoo, Outlook, etc. For that reason, the
<code>id</code> variable is not checked.</div>
<p>&nbsp;</p>
<p>Next, if not already prefixed, prefix the reply subject with &quot;Re:&quot;.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Add&nbsp;subject</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(!source.Subject.StartsWith(<span class="cs__string">&quot;Re:&quot;</span>,&nbsp;StringComparison.OrdinalIgnoreCase))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;reply.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Re:&nbsp;&quot;</span>;&nbsp;
&nbsp;
reply.Subject&nbsp;&#43;=&nbsp;source.Subject;</pre>
</div>
</div>
</div>
<p class="endscriptcode">&nbsp;Finally, the reply body is composed, depending on the source message body type.</p>
<p class="endscriptcode">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">StringBuilder&nbsp;body&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
<span class="cs__keyword">if</span>&nbsp;(source.IsBodyHtml)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;p&gt;Thank&nbsp;you&nbsp;for&nbsp;your&nbsp;email!&lt;/p&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;p&gt;We&nbsp;are&nbsp;currently&nbsp;out&nbsp;of&nbsp;the&nbsp;office,&nbsp;but&nbsp;we&nbsp;will&nbsp;respond&nbsp;as&nbsp;soon&nbsp;as&nbsp;possible.&lt;/p&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;p&gt;Best&nbsp;regards,&lt;br/&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(senderName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;/p&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;br/&gt;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;div&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(source.Date().HasValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.AppendFormat(<span class="cs__string">&quot;On&nbsp;{0},&quot;</span>,&nbsp;source.Date().Value.ToString(CultureInfo.InvariantCulture));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(source.From.DisplayName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.Append(source.From.DisplayName&nbsp;&#43;&nbsp;<span class="cs__string">'&nbsp;'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendFormat(<span class="cs__string">&quot;&lt;&lt;a&nbsp;href=\&quot;mailto:{0}\&quot;&gt;{0}&lt;/a&gt;&gt;&nbsp;wrote:&lt;br/&gt;&quot;</span>,&nbsp;source.From.Address);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(source.Body))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;blockqoute&nbsp;style=\&quot;margin:&nbsp;0&nbsp;0&nbsp;0&nbsp;5px;border-left:2px&nbsp;blue&nbsp;solid;padding-left:5px\&quot;&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.Append(source.Body);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;/blockquote&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&lt;/div&gt;&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine(<span class="cs__string">&quot;Thank&nbsp;you&nbsp;for&nbsp;your&nbsp;email!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine(<span class="cs__string">&quot;We&nbsp;are&nbsp;currently&nbsp;out&nbsp;of&nbsp;the&nbsp;office,&nbsp;but&nbsp;we&nbsp;will&nbsp;respond&nbsp;as&nbsp;soon&nbsp;as&nbsp;possible.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine(<span class="cs__string">&quot;Best&nbsp;regards,&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine(senderName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(source.Date().HasValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.AppendFormat(<span class="cs__string">&quot;On&nbsp;{0},&nbsp;&quot;</span>,&nbsp;source.Date().Value.ToString(CultureInfo.InvariantCulture));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.Append(source.From);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine(<span class="cs__string">&quot;&nbsp;wrote:&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(source.Body))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.AppendLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body.Append(<span class="cs__string">&quot;&gt;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;source.Body.Replace(<span class="cs__string">&quot;\r\n&quot;</span>,&nbsp;<span class="cs__string">&quot;\r\n&gt;&nbsp;&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
&nbsp;
reply.Body&nbsp;=&nbsp;body.ToString();&nbsp;
reply.IsBodyHtml&nbsp;=&nbsp;source.IsBodyHtml;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>I have used very simple text for the reply body, but you can see that the <code>
&lt;blockqoute&gt;</code> tag is used for the HTML body and the '&gt;' prefix for the plain text body.</p>
<h3>Sending emails with an SMTP client</h3>
<p>Newly created message replies are sent using the standard .NET <code>SmtpClient</code>. The process is quite straightforward as you can see in the code below:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(SmtpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SmtpClient(smtpHost,&nbsp;<span class="cs__number">587</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;SMTP&nbsp;client&nbsp;properties</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;client.EnableSsl&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;client.UseDefaultCredentials&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;client.Credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NetworkCredential(smtpUser,&nbsp;smtpPassword);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;client.DeliveryFormat&nbsp;=&nbsp;SmtpDeliveryFormat.International;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Send</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;retry&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(MailMessage&nbsp;msg&nbsp;<span class="cs__keyword">in</span>&nbsp;replies)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.Send(msg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retry&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!retry)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Failed&nbsp;to&nbsp;send&nbsp;reply&nbsp;to&nbsp;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg.To.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">'.'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Exception:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retry&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;All&nbsp;replies&nbsp;successfully&nbsp;sent.&quot;</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>To prevent the application from crashing on single message errors, all exceptions are ignored. Still, there might be an error with the SMTP server or credentials that will cause every message to fail, so for that reason, I have used a very simple and primitive
 retry pattern. Basically, it uses a bool variable to break the sending loop when there are two exceptions in a row.</p>
<p><img id="159165" src="159165-screenshot.png" alt="" width="461" height="191" style="display:block; margin-left:auto; margin-right:auto"></p>
<p style="text-align:center"><em>Screenshot of the EmailReply application&rsquo;s console window</em></p>
<h2>Alternatives</h2>
<p>Since the .NET Framework doesn&rsquo;t provide any means for downloading email messages from the server, the code presented in this article uses the
<a href="https://github.com/smiley22/S22.Imap">S22.Imap</a> component for that task. As the name suggests, the library communicates with the server using the IMAP protocol. Another very commonly used protocol is POP, and there are even more components for it
 on the internet since POP is a much older and simpler protocol. <a href="http://hpop.sourceforge.net/">
OpenPop</a> is the most popular, but <a href="https://github.com/smiley22/S22.Pop3">
S22.Pop3</a> is a good choice as well since it uses the <code><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Mail.MailMessage.aspx" target="_blank" title="Auto generated link to System.Net.Mail.MailMessage">System.Net.Mail.MailMessage</a></code> class instead of the custom message class used by OpenPop. Another alternative is to use all-in-one components, like
<a href="http://www.gemboxsoftware.com/Email/Overview">GemBox.Email</a>, which have IMAP, POP and custom SMTP clients with extended possibilities.</p>
<h2>Gmail security</h2>
<p>Being one of the most used email providers, Google&rsquo;s Gmail service has a very high security standards. By default, POP, IMAP and common authentication mechanisms are disabled. To be able to use your Gmail account in the demo application supplied with
 this article, you need to do the following:</p>
<h3>Enable POP or IMAP access for your account</h3>
<ol>
<li>
<p>Log in to your Gmail account and select 'Settings' from the right side menu.</p>
<img id="159166" src="159166-gmail_1.png" alt="" width="265" height="379">
</li><li>
<p>Select the 'Forwarding and POP/IMAP' tab and enable POP or IMAP, depending on which protocol you are going to use.</p>
<img id="159168" src="159168-gmail_2.png" alt="" width="782" height="400">
</li></ol>
<h3>Allow access for less secure applications</h3>
<ol>
<li>
<p>Click on you account icon in the top right corner and select 'My Account'.</p>
<img id="159169" src="159169-gmail_3.png" alt="" width="329" height="256">
</li><li>
<p>Click on 'Sign-in &amp; security' and, at the bottom of the page, set 'Allow less secure apps:' to ON.</p>
<img id="159170" src="159170-gmail_5.png" alt="" width="642" height="260">
</li></ol>
<h2>Conclusion</h2>
<p>The aim of this article was to show that creating an email message reply is quite simple. All you need to do is add headers:
<em>&quot;In-Reply-To&quot;</em> and <em>&quot;References&quot;</em>. Everything else is optional. I hope this article and the attached console application will help you with your future .NET email applications.</p>
