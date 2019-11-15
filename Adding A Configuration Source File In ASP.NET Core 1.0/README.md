# Adding A Configuration Source File In ASP.NET Core 1.0
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- JSON
- ASP.NET
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
- ASP.NET Core 1.0.1
## Topics
- C#
- JSON
- ASP.NET
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
- ASP.NET Core 1.0.1
## Updated
- 02/10/2017
## Description

<h1>Introduction</h1>
<p><br>
<span style="font-size:16px">In this article, I will explain how to add a configuration source in ASP.NET Core 1.0. This is the simplest way to access the JSON file information in ASP.NET Core 1.0.<br>
</span><br>
<span style="font-size:16px">Before reading this article, you must read the articles given below for ASP.NET Core knowledge.</span></p>
<ul>
<li><span style="font-size:16px"><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank">ASP.NET CORE 1.0: Getting Started</a><br>
</span></li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a><br>
</span></li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core
 1.0: Middleware And Static files (Part 1)</a><br>
</span></li><li><span style="font-size:16px"><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware
 And Staticfiles In ASP.NET Core 1.0 - Part Two</a></span> </li></ul>
<h1>Package required</h1>
<div><br>
<span style="font-size:16px">We need to add the following JSON package in package.json file. This package will help to access the information in ASP.NET Core 1.0.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:blue">&quot;Microsoft.Extensions.Configuration.Json&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code></span></div>
</div>
</div>
<h1>Creating a json file</h1>
<div><br>
<span style="font-size:16px">We are creating a configuration JSON file in our application.<br>
</span><br>
<span style="font-size:16px"><em>Right click -&gt; Add -&gt; New Item.. -&gt; Click &quot;Code&quot; inside the Installed Category -&gt; Select json file.&nbsp;<br>
</em></span><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1033.ConfigPage.jpg"><img src="https://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/1033.ConfigPage.jpg" alt="" style="border-width:0px; border-style:solid"></a><br>
<span style="font-size:10px">Picture Source By :&nbsp;https://rajeeshmenoth.wordpress.com/<br>
</span></div>
<h1>appsettings.json</h1>
<div><br>
<span style="font-size:16px">We have added one sample message inside the JSON file.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;Message&quot;</code><code style="color:#000000">: {
</code><code style="color:blue">&quot;WelcomeMessage&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;Configure Source In ASP.NET Core 1.0 !!&quot;</code> <code style="color:#000000">
},&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;Microsoft&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Platform&quot;</code><code style="color:#000000">: [
</code><code style="color:blue">&quot;My&quot;</code><code style="color:#000000">, </code><code style="color:blue">&quot;New&quot;</code><code style="color:#000000">,
</code><code style="color:blue">&quot;Article !! &quot;</code> <code style="color:#000000">
]&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>JSON configuration</h1>
<div><br>
<span style="font-size:16px">In the following code, we used <em>&quot;AddJsonFile(&quot;json file name&quot;)&quot;</em> extension method. We can access the JSON file in our application through this extension &quot;AddJsonFile(&quot;appsettings.json&quot;)&quot;.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Builder;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Hosting;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Http;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.Configuration;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.DependencyInjection;&nbsp; </code>
</span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.Logging;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">namespace</code>
<code style="color:#000000">ConfiguringSource&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
Startup&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">Startup(IHostingEnvironment env)&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var ConfigBuilder =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ConfigurationBuilder().SetBasePath(env.ContentRootPath)&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:174px!important"><code style="color:#000000">.AddJsonFile(</code><code style="color:blue">&quot;appsettings.json&quot;</code><code style="color:#000000">);&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">Configuration = ConfigBuilder.Build();&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// This method gets called by the runtime. Use this method to add services to the container.&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// For more information on how to configure your application, visit
<a href="http://go.microsoft.com/fwlink/?LinkID=398940%20">http://go.microsoft.com/fwlink/?LinkID=398940&nbsp;</a>;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IConfiguration Configuration { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
ConfigureServices(IServiceCollection services)&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// This method gets called by the runtime. Use this method to configure the HTTP request
 pipeline.&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">loggerFactory.AddConsole();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(env.IsDevelopment())&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">app.UseDeveloperExceptionPage();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">app.Run(async (context) =&gt;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">var Message = Configuration[</code><code style="color:blue">&quot;Message:WelcomeMessage&quot;</code><code style="color:#000000">];&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">var Details = Configuration.GetSection(</code><code style="color:blue">&quot;Microsoft:Platform&quot;</code><code style="color:#000000">).GetChildren().Select(x
 =&gt; x.Value);</code><code style="color:#008200">//array of value&nbsp; </code>
</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">await context.Response.WriteAsync(</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">.Join(</code><code style="color:blue">&quot;
 &quot;</code><code style="color:#000000">, Details) &#43; Message);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:57px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">});&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>IConfiguration Interface</h1>
<div><br>
<span style="font-size:16px">IConfiguration Interface represents a set of key/value application configuration properties.<br>
</span></div>
<h1>Possible Error !!</h1>
<div><br>
We have added all packages and libraries but we are getting the &quot;File Not Found&quot; Exception. This is not a big deal! We can resolve this Internal Server Error in two ways.<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6763.Possible_2D00_Error.png"><img src="https://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/6763.Possible_2D00_Error.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
<h2>Fixing Error 1 :</h2>
<br>
<span style="font-size:16px">We need to specify the exact path of &quot;appsettings.json&quot; file. The following code includes &quot;IHostingEnvironment&quot; to find the path of the JSON file or any other file inside the application.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">Startup(IHostingEnvironment env)&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">var builder =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ConfigurationBuilder()&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">.SetBasePath(env.ContentRootPath)&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">.AddJsonFile(</code><code style="color:blue">&quot;appsettings.json&quot;</code><code style="color:#000000">);&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">Configuration = builder.Build();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h2>Fixing Error 2 :</h2>
<div><br>
<span style="font-size:16px">This is a common answer. We can directly put &quot;Directory.GetCurrentDirectory()&quot; to find the path of the file.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">Startup()&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">var builder =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ConfigurationBuilder()&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">.SetBasePath(Directory.GetCurrentDirectory())&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">.AddJsonFile(</code><code style="color:blue">&quot;appsettings.json&quot;</code><code style="color:#000000">);&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">Configuration = builder.Build();&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>project.json</h1>
<div><br>
<span style="font-size:16px">The final structure of project.json file in our application is given below.<br>
</span><br>
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
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.Extensions.Configuration.Json&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code>&nbsp;</span></span></div>
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
<h1>Array</h1>
<div><br>
<span style="font-size:16px">The following code will read the array of value in JSON file.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">app.Run(async (context) =&gt;&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">var Message = Configuration[</code><code style="color:blue">&quot;Message:WelcomeMessage&quot;</code><code style="color:#000000">];&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">var Details = Configuration.GetSection(</code><code style="color:blue">&quot;Microsoft:Platform&quot;</code><code style="color:#000000">).GetChildren().Select(x
 =&gt; x.Value);</code><code style="color:#008200">//array of value&nbsp; </code>
</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">await context.Response.WriteAsync(</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">.Join(</code><code style="color:blue">&quot;
 &quot;</code><code style="color:#000000">, Details) &#43; Message);&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:57px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">});</code></span></span></div>
</div>
</div>
<h1>Output</h1>
<div><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/2656.DotnetCore_2D00_Output.jpg"><img src="https://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/2656.DotnetCore_2D00_Output.jpg" alt="" style="border-width:0px; border-style:solid"></a></div>
<h1>Conclusion</h1>
<div><span style="font-size:16px"><br>
We learned about adding a configuration source in ASP.NET Core 1.0 and I hope you liked this article. Please share your valuable suggestions and feedback.<br>
</span></div>
<h1>Reference</h1>
<div>
<ul>
<li><span style="font-size:16px"><a title="Microsoft Docs" href="https://docs.microsoft.com/en-us/aspnet/core/getting-started" target="_blank">Microsoft Docs</a><br>
</span></li><li><span style="font-size:16px">You can read this article in&nbsp;<a title="RajeeshMenoth Blog" href="https://rajeeshmenoth.wordpress.com/2017/02/08/adding-a-configuration-source-file-in-asp-net-core-1-0/" target="_blank">RajeeshMenoth Blog</a></span>
</li></ul>
<h1>Downloads</h1>
<div><br>
<span style="font-size:16px">You can download other ASP.NET Core 1.0 source code from the MSDN Code, using the links, mentioned below.</span><br>
<ul>
<li><span style="font-size:16px"><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part One" href="https://code.msdn.microsoft.com/Middleware-And-Staticfiles-36a78e4a" target="_blank">Middleware And Staticfiles In ASP.NET Core 1.0 - Part One</a><br>
</span></li><li><span style="font-size:16px"><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://code.msdn.microsoft.com/Middleware-And-Staticfiles-4be1c8d0" target="_blank">Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two</a><br>
</span></li><li><span style="font-size:16px"><a title="Create An Aurelia Single Page Application In ASP.NET Core 1.0" href="https://code.msdn.microsoft.com/Create-An-Aurelia-Single-dbffe00f" target="_blank">Create An Aurelia Single Page Application In ASP.NET Core 1.0</a><br>
</span></li><li><span style="font-size:16px"><a title="Create Rest API Or Web API With ASP.NET Core 1.0" href="https://code.msdn.microsoft.com/Create-Rest-API-Or-Web-API-16cc5392" target="_blank">Create Rest API Or Web API With ASP.NET Core 1.0</a></span>
</li></ul>
<h1>See Also</h1>
<div><br>
<span style="font-size:16px">It's recommended to read more articles related to ASP.NET Core.</span><br>
<ul>
<li><span style="font-size:16px"><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank">ASP.NET CORE 1.0: Getting Started</a><br>
</span></li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a><br>
</span></li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core
 1.0: Middleware And Static files (Part 1)</a><br>
</span></li><li><span style="font-size:16px"><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware
 And Staticfiles In ASP.NET Core 1.0 - Part Two</a><br>
</span></li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0 Configuration: Aurelia Single Page Applications" href="https://social.technet.microsoft.com/wiki/contents/articles/36792.asp-net-core-1-0-configuration-aurelia-single-page-applications.aspx" target="_blank">ASP.NET
 Core 1.0 Configuration: Aurelia Single Page Applications</a><br>
</span></li><li><span style="font-size:16px"><a title="ASP.NET Core 1.0: Create An Aurelia Single Page Application" href="https://social.technet.microsoft.com/wiki/contents/articles/36799.asp-net-core-1-0-create-an-aurelia-single-page-application.aspx" target="_blank">ASP.NET
 Core 1.0: Create An Aurelia Single Page Application</a><br>
</span></li><li><a title="Create Rest API Or Web API With ASP.NET Core 1.0" href="https://social.technet.microsoft.com/wiki/contents/articles/36887.create-rest-api-or-web-api-with-asp-net-core-1-0.aspx" target="_blank"><span style="font-size:16px">Create Rest API Or Web
 API With ASP.NET Core 1.0</span></a> </li></ul>
</div>
</div>
</div>
