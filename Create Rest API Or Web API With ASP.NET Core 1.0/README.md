# Create Rest API Or Web API With ASP.NET Core 1.0
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET
- ASP.NET Web API
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
- ASP.NET Core 1.0.1
## Topics
- C#
- ASP.NET
- ASP.NET MVC
- ASP.NET Web API
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
## Updated
- 01/29/2017
## Description

<h1>Introduction</h1>
<p><br>
<span style="font-size:16px">There are several articles on Google for creating Rest API or Web API with ASP.NET Core 1.0. In this article, We will explain how to create Rest API or Web API with ASP.NET Core 1.0, starting from scratch.<br>
</span><br>
<span style="font-size:16px">Before reading this article, you must read the articles given below for ASP.NET Core knowledge.</span></p>
<ul>
<li><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank"><span style="font-size:16px">ASP.NET CORE 1.0: Getting Started</span></a>
</li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a></span>
</li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core
 1.0: Middleware And Static files (Part 1)</a></span> </li><li><span style="font-size:16px"><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware
 And Staticfiles In ASP.NET Core 1.0 - Part Two</a></span> </li></ul>
<p>&nbsp;</p>
<p><strong><span style="font-size:2em">Start from Scratch</span></strong></p>
<div><br>
<span style="font-size:16px">We choose &quot;Empty&quot; template in &quot;ASP.NET Core Templates&quot; Category. I think someone may have a doubt like -- without selecting a &quot;Web API&quot;, why do we choose &quot;Empty&quot; template in &quot;ASP.NET Core Templates&quot; Category ? Because the &quot;Web API&quot;
 templates automatically generate a few libraries related to REST API creation. So, we don&rsquo;t know what is happening in the background. That&rsquo;s why we choose &quot;Empty&quot; template.<br>
</span><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/3833.empty_2D00_asp_2D00_net_2D00_core_2D00_1_2D00_0.jpg"><img src=":-3833.empty_2d00_asp_2d00_net_2d00_core_2d00_1_2d00_0.jpg" alt="" style="border-width:0px; border-style:solid"></a></div>
<h1>References Required</h1>
<div><br>
<span style="font-size:16px">We need the following references for accessing Static files, libraries for Routing, and Rest API, accessing MVC design pattern, etc.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.StaticFiles&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.1.0&quot;</code><code style="color:#000000">,</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Routing&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc.Core&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc.ViewFeatures&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code></span></div>
</div>
</div>
<h1>Project.json</h1>
<div><br>
<span style="font-size:16px">The following JSON file will show the full reference structure of our Web API application.</span>&nbsp;<br>
<br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;dependencies&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.NETCore.App&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;version&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;type&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;platform&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Diagnostics&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.IISIntegration&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.Kestrel&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.Extensions.Logging.Console&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.StaticFiles&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.1.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Routing&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc.Core&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc.ViewFeatures&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;tools&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.IISIntegration.Tools&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0-preview2-final&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;frameworks&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;netcoreapp1.0&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;imports&quot;</code><code style="color:#000000">: [&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:blue">&quot;dotnet5.6&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:blue">&quot;portable-net45&#43;win8&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:#000000">]&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;buildOptions&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;emitEntryPoint&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;preserveCompilationContext&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;runtimeOptions&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;configProperties&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;System.GC.Server&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code>&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;publishOptions&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;include&quot;</code><code style="color:#000000">: [&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;wwwroot&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;web.config&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;scripts&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;postpublish&quot;</code><code style="color:#000000">: [
</code><code style="color:blue">&quot;dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%&quot;</code>
<code style="color:#000000">]&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>Project Structure</h1>
<div><br>
<span style="font-size:16px">This is the project structure of our Rest API application.</span><br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1373.project-structure-asp.net-core-1.0.JPG"><img src=":-1373.project-structure-asp.net-core-1.0.jpg" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h1>LibraryDetails.cs</h1>
<div><br>
<span style="font-size:16px">We have created the following class for property details in our Rest API application.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">namespace</code>
<code style="color:#000000">DotNetCoreExtentions&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
LibraryDetails&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">int</code> <code style="color:#000000">
Id { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
Author { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
BookName { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
Category { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:33px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>API Controller</h1>
<div><br>
<span style="font-size:16px">We have to create one folder named &nbsp;&quot;Controllers&quot;. Right click on the &quot;Controllers&quot; folder and go to the following steps to create an API class
<em>&quot;Add &ndash; &gt; New item.. -&gt; Web API Controller Class&quot;</em>.<br>
</span><br>
<span style="font-size:16px">We have created an API Class named as &quot;LibraryAPI&quot;.<br>
</span></div>
<h1>LibraryAPI.cs</h1>
<div><br>
<span style="font-size:16px">The following code contains the CRUD operation of REST API application.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Mvc;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Routing;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#008200">// For more information on enabling Web API for empty projects, visit
<a href="http://go.microsoft.com/fwlink/?LinkID=397860%20">http://go.microsoft.com/fwlink/?LinkID=397860&nbsp;</a>;
</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">namespace</code>
<code style="color:#000000">DotNetCoreExtentions&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">[Route(</code><code style="color:blue">&quot;api/[controller]&quot;</code><code style="color:#000000">)]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
LibraryAPI : Controller&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">LibraryDetails[] LibraryDetails =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
LibraryDetails[]&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">LibraryDetails { Id=1, BookName=</code><code style="color:blue">&quot;Programming C# for Beginners&quot;</code><code style="color:#000000">, Author=</code><code style="color:blue">&quot;Mahesh Chand&quot;</code><code style="color:#000000">, Category=</code><code style="color:blue">&quot;C#&quot;</code>
<code style="color:#000000">},&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">LibraryDetails { Id=2, BookName=</code><code style="color:blue">&quot;Setting Up SharePoint 2016 Multi-Server Farm In Azure&quot;</code><code style="color:#000000">, Author=</code><code style="color:blue">&quot;Priyaranjan K S&quot;</code><code style="color:#000000">,
 Category=</code><code style="color:blue">&quot;SharePoint&quot;</code> <code style="color:#000000">
},&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">LibraryDetails { Id=3, BookName=</code><code style="color:blue">&quot;SQL Queries For Beginners&quot;</code><code style="color:#000000">, Author=</code><code style="color:blue">&quot;Syed Shanu&quot;</code><code style="color:#000000">, Category=</code><code style="color:blue">&quot;Sql&quot;</code>
<code style="color:#000000">},&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">LibraryDetails { Id=4, BookName=</code><code style="color:blue">&quot;OOPs Principle and Theory&quot;</code><code style="color:#000000">, Author=</code><code style="color:blue">&quot;Syed Shanu&quot;</code><code style="color:#000000">, Category=</code><code style="color:blue">&quot;Basic
 Concepts&quot;</code> <code style="color:#000000">},&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">LibraryDetails { Id=5, BookName=</code><code style="color:blue">&quot;ASP.NET GridView Control Pocket Guide&quot;</code><code style="color:#000000">, Author=</code><code style="color:blue">&quot;Vincent Maverick Durano&quot;</code><code style="color:#000000">,
 Category=</code><code style="color:blue">&quot;Asp.Net&quot;</code> <code style="color:#000000">
}&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">};&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:33px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// GET: api/values&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">[HttpGet]&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IEnumerable&lt;LibraryDetails&gt; GetAllBooks()&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">LibraryDetails;&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// GET api/values/5&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">[HttpGet(</code><code style="color:blue">&quot;{id}&quot;</code><code style="color:#000000">)]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IActionResult Get(</code><code style="color:#006699; font-weight:bold">int</code>
<code style="color:#000000">id)&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var books = LibraryDetails.FirstOrDefault((p) =&gt; p.Id ==
 id);&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var item = books;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(item == </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">NotFound();&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ObjectResult(item);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:33px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// POST api/values&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">[HttpPost]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Post([FromBody]</code><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">value)&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// PUT api/values/5&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">[HttpPut(</code><code style="color:blue">&quot;{id}&quot;</code><code style="color:#000000">)]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Put(</code><code style="color:#006699; font-weight:bold">int</code> <code style="color:#000000">
id, [FromBody]</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
value)&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// DELETE api/values/5&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">[HttpDelete(</code><code style="color:blue">&quot;{id}&quot;</code><code style="color:#000000">)]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Delete(</code><code style="color:#006699; font-weight:bold">int</code> <code style="color:#000000">
id)&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h2>[Route(&quot;api/[controller]&quot;)]</h2>
<div><br>
<span style="font-size:16px">The route will assign a single route path for accessing specific API Controller CRUD operations. Instead of &quot;[controller]&quot;, we can mention our controller name as &quot;LibraryAPI&quot; in client side or server side code. If searching for
 any information from API, we can pass id like this -&quot;api/LibraryAPI/id&quot;.<br>
</span></div>
<h2>Accessing JSON data into Library API</h2>
<div><br>
<span style="font-size:16px">At client-side, we are going to access JSON data from Library API with the help of JavaScript.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#008200">//api url&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">var</code>
<code style="color:#000000">uri = </code><code style="color:blue">'api/LibraryAPI'</code><code style="color:#000000">;</code><code style="color:#008200">//[Route(&quot;api/[controller]&quot;)] instead of [controller] we can mention our API classname.&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">$(document).ready(</code><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">() {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#008200">// Send an AJAX request&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">$.getJSON(uri)&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">.done(</code><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">(data) {&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#008200">// On success,
 'data' contains a list of products.&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">$.each(data,
</code><code style="color:#006699; font-weight:bold">function</code> <code style="color:#000000">
(key, item) {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:72px!important"><code style="color:#008200">//
 Add a list item for the product.&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:72px!important"><code style="color:#000000">$('&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;li&gt;</code><code style="color:blue">', { text: ItemDetails(item) }).appendTo($('</code><code style="color:gray">#books')).before(&quot;&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&quot;);&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:72px!important"><code style="color:#000000">$(</code><code style="color:blue">&quot;li&quot;</code><code style="color:#000000">).addClass(</code><code style="color:blue">&quot;list-group-item
 list-group-item-info&quot;</code><code style="color:#000000">);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">});&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">});&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">});&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">ItemDetails(item) {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:blue">'BookId : [ '</code> <code style="color:#000000">&#43; item.id &#43;
</code><code style="color:blue">' ] -- Author Name : [ '</code> <code style="color:#000000">
&#43; item.author &#43; </code><code style="color:blue">' ] -- Book Name : [ '</code> <code style="color:#000000">
&#43; item.bookName &#43; </code><code style="color:blue">' ] -- Category : [ '</code> <code style="color:#000000">
&#43; item.category &#43; </code><code style="color:blue">' ]'</code><code style="color:#000000">;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">find() {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">var</code>
<code style="color:#000000">id = $(</code><code style="color:blue">'#bookId'</code><code style="color:#000000">).val();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(id == </code><code style="color:blue">''</code><code style="color:#000000">) id = 0;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">$.getJSON(uri &#43;
</code><code style="color:blue">'/'</code> <code style="color:#000000">&#43; id)&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">.done(</code><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">(data) {&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">$(</code><code style="color:blue">'#library'</code><code style="color:#000000">).text(ItemDetails(data));&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">$(</code><code style="color:blue">&quot;p&quot;</code><code style="color:#000000">).addClass(</code><code style="color:blue">&quot;list-group-item
 list-group-item-info&quot;</code><code style="color:#000000">);&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">})&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">.fail(</code><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">(jqXHR, textStatus, err) {&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">$(</code><code style="color:blue">'#library'</code><code style="color:#000000">).text(</code><code style="color:blue">'Error:
 '</code> <code style="color:#000000">&#43; err);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">});&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}</code></span></span></div>
</div>
</div>
<h1>Startup.cs</h1>
<div><br>
<span style="font-size:16px">In the following code, we mention the &quot;AddMvc()&quot; in configuration service method. It will help to access the MVC related information at runtime.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Builder;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Hosting;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.DependencyInjection;&nbsp; </code>
</span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.Logging;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">namespace</code>
<code style="color:#000000">DotNetCoreExtentions&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
Startup&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// This method gets called by the runtime. Use this method to add services to the container.&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// For more information on how to configure your application, visit
<a href="http://go.microsoft.com/fwlink/?LinkID=398940%20">http://go.microsoft.com/fwlink/?LinkID=398940&nbsp;</a>;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
ConfigureServices(IServiceCollection services)&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">services.AddMvc();&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// This method gets called by the runtime. Use this method to configure the HTTP request
 pipeline.&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">loggerFactory.AddConsole();&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(env.IsDevelopment())&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">app.UseDeveloperExceptionPage();&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">app.UseFileServer();&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">app.UseMvc();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>Output 1</h1>
<div><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0640.image001.jpg"><img src=":-0640.image001.jpg" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h2>JSON Output 1</h2>
<div><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0118.json_2D00_output_2D00_1.jpg"><img src=":-0118.json_2d00_output_2d00_1.jpg" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h1>Output 2</h1>
<div><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1537.out2.jpg"><img src=":-1537.out2.jpg" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h2>JSON Output 2</h2>
<div><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/5050.json_2D00_output_2D00_2.jpg"><img src=":-5050.json_2d00_output_2d00_2.jpg" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h1>Reference</h1>
<div>
<ul>
<li><span style="font-size:16px"><a title="Microsoft Docs" href="https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api" target="_blank">Microsoft Docs</a></span>
</li><li><span style="font-size:16px">You can read this article in&nbsp;<a title="RajeeshMenoth Blog" href="https://rajeeshmenoth.wordpress.com/2017/01/27/how-to-create-rest-api-or-web-api-with-asp-net-core-1-0/" target="_blank">RajeeshMenoth Blog</a></span>
</li><li><span style="font-size:16px"><a title="Web API 2 Docs" href="https://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api" target="_blank">Web API 2 Docs</a></span>
</li></ul>
<h1>See Also</h1>
<br>
<span style="font-size:16px">It's recommended to read more articles related to ASP.NET Core.<br>
<ul>
<li><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank"><span style="font-size:16px">ASP.NET CORE 1.0: Getting Started</span></a>
</li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a></span>
</li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core
 1.0: Middleware And Static files (Part 1)</a></span> </li><li><span style="font-size:16px"><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware
 And Staticfiles In ASP.NET Core 1.0 - Part Two</a></span> </li><li><a title="ASP.NET Core 1.0 Configuration: Aurelia Single Page Applications" href="https://social.technet.microsoft.com/wiki/contents/articles/36792.asp-net-core-1-0-configuration-aurelia-single-page-applications.aspx" target="_blank">ASP.NET Core 1.0 Configuration:
 Aurelia Single Page Applications</a> </li><li><a title="ASP.NET Core 1.0: Create An Aurelia Single Page Application" href="https://social.technet.microsoft.com/wiki/contents/articles/36799.asp-net-core-1-0-create-an-aurelia-single-page-application.aspx" target="_blank">ASP.NET Core 1.0: Create An Aurelia
 Single Page Application</a> </li></ul>
</span>
<h1>
<p>Conclusion</p>
</h1>
<div><span style="font-size:16px">Thus, we learned how to create Rest API or Web API with ASP.NET Core 1.0 when starting from scratch. We hope you liked this article. Please share your valuable suggestions and feedback.</span></div>
</div>
