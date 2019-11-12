# ASP.NET MVC HangFire - Execute Jobs in Background using SQLServer
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- MVC
- ASP.NET MVC 5
- Hangfire
## Topics
- C#
- ASP.NET
- MVC
- Hangfire
## Updated
- 09/14/2015
## Description

<p><strong><span style="font-size:small">Introduction</span></strong></p>
<p>This article walks you through configuration of HangFire.</p>
<p>&quot;An easy way to perform fire-and-forget, delayed and recurring tasks inside ASP.NET applications&quot; -
<a href="http://hangfire.io/">http://hangfire.io/</a></p>
<p>We can easily configure different types of jobs (recurring, schedule or fire and forget)</p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">STEP 1 - Create ASP.NET Web Application</span></strong></p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2015 and create a new project of type ASP.NET Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called HangFire.</span>
</li></ul>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><img id="142546" src="142546-1.png" alt="" width="600" height="400"></p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p lang="en-US">&nbsp;</p>
<p><img id="142549" src="142549-1.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 2 - Install Nuget</span></strong></p>
<p>&nbsp;</p>
<p>In order to use HangFire we need to install a Nuget package.</p>
<p>We can install using the Package Manager Console</p>
<ul type="disc">
<li><span>PM&gt; Install-Package HangFire -Version 1.4.6</span> </li></ul>
<p>Or using the Visual Studio Nuget Management</p>
<p>&nbsp;</p>
<p><img id="142550" src="142550-3.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 3 - Configure Startup class</span></strong></p>
<p>&nbsp;</p>
<p>Need to provide connection string to our database.~</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;Hangfire;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.aspx" target="_blank" title="Auto generated link to Microsoft.Owin">Microsoft.Owin</a>;&nbsp;
using&nbsp;Owin;&nbsp;
using&nbsp;System;&nbsp;
&nbsp;
[assembly:&nbsp;OwinStartupAttribute(<span class="js__operator">typeof</span>(HangFire.Startup))]&nbsp;
namespace&nbsp;HangFire&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigureAuth(app);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalConfiguration.Configuration&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.UseSqlServerStorage(<span class="js__string">&quot;connectionString&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundJob.Enqueue(()&nbsp;=&gt;&nbsp;Console.WriteLine(<span class="js__string">&quot;Fire-and-forget!&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseHangfireDashboard();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseHangfireServer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 4 - Run</span></strong></p>
<p lang="en-US">Run application using the address of it follow by /hangfire, like on the image below.</p>
<p>&nbsp;</p>
<p><img id="142551" src="142551-4.png" alt="" width="600" height="400"></p>
<p>When we run this address for the first time, new table will be created on our database.</p>
<p><img id="142552" src="142552-5.png" alt="" width="229" height="200"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">Resources</span></strong></p>
<p lang="en-US">Some good resources about Signal could be found here:</p>
<ul type="disc">
<li lang="en-US"><span>My personal blog:&nbsp;</span><a href="http://joaoeduardosousa.wordpress.com/"><span>http://joaoeduardosousa.wordpress.com/
</span></a></li></ul>
<ul type="disc">
<li><a href="http://hangfire.io/"><span>http://hangfire.io/</span></a> </li></ul>
