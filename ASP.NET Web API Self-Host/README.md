# ASP.NET Web API Self-Host
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
## Topics
- ASP.NET Web API hosting
## Updated
- 08/15/2012
## Description

<p>ASP.NET Web API is a framework for building HTTP services that can reach a broad range of clients including browsers, phones and tablets. ASP.NET Web API ships with ASP.NET MVC 4 and is part of the Microsoft web platform. However, this does not mean that
 you are limited to hosting your web APIs in IIS! ASP.NET Web API gives you the flexiblity to host your web APIs anywhere you would like, including self-hosting in your own process.</p>
<p>Note: This sample uses the <a href="http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages">
NuGet package restore</a> feature to install the required set of NuGet packages when the sample is first built. Make sure you have network access to the public NuGet feed on
<a href="http://www.nuget.org/">www.nuget.org</a> before building this sample the first time.</p>
<p>To self-host a web API you first need to setup your server configuration. At a minimum you need to specify the base address for your HTTP server and configure routes for your web APIs. Note that you configure your routes just like you would using ASP.NET
 Routing, except the routes need to be added to the route collection on your config instance</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Set&nbsp;up&nbsp;server&nbsp;configuration</span>&nbsp;
HttpSelfHostConfiguration&nbsp;config&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpSelfHostConfiguration(_baseAddress);&nbsp;
&nbsp;
config.Routes.MapHttpRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="cs__string">&quot;DefaultApi&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;routeTemplate:&nbsp;<span class="cs__string">&quot;api/{controller}/{id}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;defaults:&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id&nbsp;=&nbsp;RouteParameter.Optional&nbsp;}&nbsp;
);</pre>
</div>
</div>
</div>
<p><span>Implement your web API just like you would if it was web hosted by deriving from ApiController and adding your actions. Here we add a simple HelloController&nbsp;with a Get action that returns a simple string:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HelloController&nbsp;:&nbsp;ApiController&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Hello,&nbsp;world!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div><span>Create a self-host server with this configuration and open the server to start listening for requests. You will need to run the sample as an administrator to be able to open the server:</span><span>&nbsp;</span><span>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Create&nbsp;server</span>&nbsp;
server&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpSelfHostServer(config);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Start&nbsp;listening</span>&nbsp;
server.OpenAsync().Wait();&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Listening&nbsp;on&nbsp;&quot;</span>&nbsp;&#43;&nbsp;_baseAddress);</pre>
</div>
</div>
</div>
<div>&nbsp;Lastly, create an HttpClien and send a GET request to the web API to retrieve the string:</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Call&nbsp;the&nbsp;web&nbsp;API&nbsp;and&nbsp;display&nbsp;the&nbsp;result</span>&nbsp;
HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
client.GetStringAsync(_address).ContinueWith(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;getTask&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(getTask.IsCanceled)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Request&nbsp;was&nbsp;canceled&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(getTask.IsFaulted)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Request&nbsp;failed:&nbsp;{0}&quot;</span>,&nbsp;getTask.Exception);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Client&nbsp;received:&nbsp;{0}&quot;</span>,&nbsp;getTask.Result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});</pre>
</div>
</div>
</div>
</div>
<p>When you run the application you should see the result displayed:</p>
<p><img id="63522" src="63522-self%20host%20web%20api.png" alt="" width="514" height="262">&nbsp;</p>
<h1>More Information</h1>
<div><a href="http://www.asp.net/web-api">ASP.NET Web API home page</a></div>
<div><a href="http://www.asp.net/web-api/overview/hosting-aspnet-web-api/self-host-a-web-api">Tutorial: Self-host a Web API</a></div>
<div></div>
