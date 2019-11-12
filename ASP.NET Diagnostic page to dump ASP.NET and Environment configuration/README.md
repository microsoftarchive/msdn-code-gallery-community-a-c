# ASP.NET Diagnostic page to dump ASP.NET and Environment configuration
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
## Topics
- ASP.NET
## Updated
- 07/21/2011
## Description

<h1>Introduction</h1>
<p><span style="font-family:arial,helvetica,sans-serif; font-size:small">Sometimes you need to quickly see if your ASP.NET site is running on the correct server, from correct code location, using correct .NET runtime, on a correct OS and hardware environment.
 Especially if you are running on a shared hosting and you do not have access to the server configuration, dumping Environment variables gives you valuable information about the server processor and you can find out whether the hosting company is putting you
 on a cheap server. Here&rsquo;s a handy ASPX page that you can just copy on any website and it dumps the Environment settings and common ASP.NET settings to help diagnose various problems.</span></p>
<p><span style="font-family:arial,helvetica,sans-serif; font-size:small"><img src="25320-asp.net%20diagnostic%20page.png" alt="" width="499" height="797"></span></p>
<p><span style="font-family:arial,helvetica,sans-serif; font-size:small">&nbsp;</span></p>
<h1><span style="font-family:arial,helvetica,sans-serif; font-size:small; font-weight:normal">It dumps all the Enviornment variables. I have only shown a few on the screenshot. Then it dumps some useful Request properties. Then it has the ASP.NET tracing output
 which gives very useful content.</span></h1>
<p><span style="font-family:arial,helvetica,sans-serif; font-size:small">The code of the page is very simple:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__attr_name">AutoEventWireup</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">Trace</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">TraceMode</span>=<span class="html__attr_value">&quot;SortByCategory&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span>ASP.NET&nbsp;Diagnostic&nbsp;Page<span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Environment&nbsp;Variables<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;pre</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&lt;%&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;variables&nbsp;=&nbsp;Environment.GetEnvironmentVariables();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(DictionaryEntry&nbsp;entry&nbsp;in&nbsp;variables)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(&quot;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span>&quot;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(entry.Key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(&quot;<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span>&quot;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(entry.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(&quot;<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span>&quot;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/pre&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Misc<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;pre</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;Response.Filter&nbsp;=&nbsp;&lt;%=&nbsp;Request.Filter.ToString()&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Request.ApplicationPath&nbsp;=&nbsp;&lt;%=&nbsp;Request.ApplicationPath&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Request.PhysicalApplicationPath&nbsp;=&nbsp;&lt;%=&nbsp;Request.PhysicalApplicationPath&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Request.PhysicalPath&nbsp;=&nbsp;&lt;%=&nbsp;Request.PhysicalPath&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Request.UrlReferrer&nbsp;=&nbsp;&lt;%=&nbsp;Request.UrlReferrer&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Request.UserLanguages&nbsp;=&nbsp;&lt;%=&nbsp;string.Join(&quot;,&quot;,&nbsp;(Request.UserLanguages&nbsp;??&nbsp;new&nbsp;string[0]))&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/pre&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-family:arial,helvetica,sans-serif; font-size:small">That&rsquo;s all in the Dump.aspx. Just drop this page on a website and you are ready to go.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<h1>How to use this page</h1>
<p>You can use this to test many things:</p>
<p>&nbsp;</p>
<ul>
<li>Dump the cookies browser is sending to your website and see if the cookies are correct. Sometimes you get bad cookie injected in browser by some code and it causes your code to fail. Using this page, you can test that.
</li><li>See if server has right .NET framework installed.&nbsp; </li><li>Verify if the site is running from correct webserver by looking at the machine name.
</li><li>Test if load balancer is working. Deploy this page on all your webservers. Then keep refreshing the page. You should see different machine name being dumped on different page loads. &nbsp;&nbsp;
</li><li>Check what is in Session and see if there's something incorrect stored in session that might be causing your application to fail. See if Session being created at all or not.&nbsp;&nbsp;
</li><li>Test if you are getting right Request Headers.&nbsp;&nbsp; </li><li>Set this page as some form's POST page and make a post to this page to see what is getting post.&nbsp;
</li></ul>
These are just some of the ways you can make use of this page to test your webserver, application code, form posts, AJAX calls and so on.&nbsp;</div>
<div class="endscriptcode"><span style="font-family:arial,helvetica,sans-serif; font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:medium"><strong><span style="font-family:arial,helvetica,sans-serif">I will keep updating the Dump.aspx with more stuff as I encounter. Keep an eye on it.</span></strong></span></div>
