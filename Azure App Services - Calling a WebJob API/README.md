# Azure App Services - Calling a WebJob API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Azure
## Topics
- C#
- Azure
## Updated
- 02/01/2016
## Description

<h1>Introduction</h1>
<p><em>Although you can execute a triggered WebJob from the Azure Console, from PowerShell and from the Server Manager in Visual Studio, you can also do it from C# code by calling the WebJob API discussed here:&nbsp;
<a href="http://github.com/projectkudu/kudu/wiki/WebJobs-API">http://github.com/projectkudu/kudu/wiki/WebJobs-API</a>
</em></p>
<p><em>You may want to trigger a WebJob when a user performs a specific action on your web site or when a specific programmable event happens.&nbsp; Using the WebJob API, this is possible.</em></p>
<p><em>Visit the link to the blog in the More Information section.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Executing the WebJob API requires authentication, specificlly Basic Authentication.&nbsp; The credentials you use are the publishing profile credentials for the App Service running your WebJob.&nbsp; See the blog in the More Information section where
 I explain how to get them.&nbsp; Update the userName and userPassword in the C# code with the credentials contained in the downloaded publishing profile.</em></p>
<p><em>Change the webJobName to the name of your WebJob.</em></p>
<p><em>Change the URL to the KUDU/SCM&nbsp;web address of your App Service hosting the WebJob.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This example allows you to call a WebJob hosted on Azure using a API.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//App&nbsp;Service&nbsp;Publish&nbsp;Profile&nbsp;Credentials</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;userName&nbsp;=&nbsp;<span class="cs__string">&quot;userName&quot;</span>;&nbsp;<span class="cs__com">//userName</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;userPassword&nbsp;=&nbsp;<span class="cs__string">&quot;userPWD&quot;</span>;&nbsp;<span class="cs__com">//userPWD</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//change&nbsp;webJobName&nbsp;to&nbsp;your&nbsp;WebJob&nbsp;name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;webJobName&nbsp;=&nbsp;<span class="cs__string">&quot;WEBJOBNAME&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;unEncodedString&nbsp;=&nbsp;String.Format($<span class="cs__string">&quot;{userName}:{userPassword}&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;encodedString&nbsp;=&nbsp;Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(unEncodedString));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Change&nbsp;this&nbsp;URL&nbsp;to&nbsp;your&nbsp;WebApp&nbsp;hosting&nbsp;the&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;URL&nbsp;=&nbsp;<span class="cs__string">&quot;https://?.scm.azurewebsites.net/api/triggeredwebjobs/&quot;</span>&nbsp;&#43;&nbsp;webJobName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/run&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.WebRequest&nbsp;request&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.WebRequest.Create.aspx" target="_blank" title="Auto generated link to System.Net.WebRequest.Create">System.Net.WebRequest.Create</a>(URL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentLength&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers[<span class="cs__string">&quot;Authorization&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Basic&nbsp;&quot;</span>&nbsp;&#43;&nbsp;encodedString;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.WebResponse&nbsp;response&nbsp;=&nbsp;request.GetResponse();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.IO.Stream&nbsp;dataStream&nbsp;=&nbsp;response.GetResponseStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.IO.StreamReader&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.StreamReader.aspx" target="_blank" title="Auto generated link to System.IO.StreamReader">System.IO.StreamReader</a>(dataStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;responseFromServer&nbsp;=&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;OK&quot;</span>);&nbsp;&nbsp;<span class="cs__com">//no&nbsp;response</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReadLine();&nbsp;
&nbsp;}&nbsp;
&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(ex.Message.ToString());&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Program.cs - contains all the code for the entire solution.</em> </li></ul>
<h1>More Information</h1>
<p><em>Here is a blog that discusses how I used this code.&nbsp; <a href="http://blogs.msdn.com/b/benjaminperkins/archive/2016/02/01/using-the-azure-webjob-api.aspx">
http://blogs.msdn.com/b/benjaminperkins/archive/2016/02/01/using-the-azure-webjob-api.aspx</a> additionally, here is an interesting blog that discusses how to troubleshoot a slow or hung WebJob, JIC you ever run into that situation.&nbsp;
<a href="http://blogs.msdn.com/b/waws/archive/2016/02/01/troubleshooting-a-hung-or-long-running-webjob.aspx">
http://blogs.msdn.com/b/waws/archive/2016/02/01/troubleshooting-a-hung-or-long-running-webjob.aspx</a>
</em></p>
