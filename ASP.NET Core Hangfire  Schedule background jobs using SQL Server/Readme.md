# ASP.NET Core Hangfire : Schedule background jobs using SQL Server
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SQL Server
- NuGet
- Hangfire
- ASP.NET Core
## Topics
- Background thread
- Background Agent
- Background tasks
- Background Workers
- Hangfire
## Updated
- 01/08/2017
## Description

<p>Scheduling and monitoring background task is challenging work. Every big application needs to implement background tasks to accomplish background works like data processing, email reminders, process SMS queue and Email queues etc. Windows service is that
 the most typical approach to meet the necessity.</p>
<p>Today, we are going to setup Hangfire and write some code to schedule an initial job in the ASP.NET Core project.</p>
<h1>Introduction</h1>
<p>Hangfire is an open source library to schedule and execute background jobs in .NET application. you'll be able to create a simple background process inside the same application pool or thread without creating separate application. Hangfire create background
 jobs in persistence storage like MS SQL server, Redis, MongoDb and others, that may prevent from loosing job on recycling IIS pool or exception prevalence.</p>
<p><br>
ASP.NET Core is now a common platform for MVC and Web API, no separate project creation needed. Let's create a new ASP.NET Core MVC project. After the project is created install Hangfire from nuget. You can install Hangfire either from Package Management Console
 or Nuget package manager.</p>
<p>Intall via nuget</p>
<p>PM&gt; Install-Package HangFire</p>
<h1><span>Configuration</span></h1>
<p><span>Open&nbsp;</span><code>Startup.cs</code><span>&nbsp;class and locate a&nbsp;</span><code>ConfigureServices</code><span>&nbsp;method to register Hangefire as a service.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void ConfigureServices(IServiceCollection services)
{
    // Add Hangfire services.
    services.AddHangfire(x =&gt; x.UseSqlServerStorage(Configuration.GetConnectionString(&quot;DefaultConnection&quot;)));
    
    // Add framework services.
    services.AddMvc();
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;Hangfire&nbsp;services.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.AddHangfire(x&nbsp;=&gt;&nbsp;x.UseSqlServerStorage(Configuration.GetConnectionString(<span class="cs__string">&quot;DefaultConnection&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;framework&nbsp;services.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Here we are registering Hangfire will SQL Server. We must provide a connection string to locate SQL server database named&nbsp;</span><code>HangFireDb</code><span>.&nbsp;</span><code>DefaultConnection</code><span>&nbsp;is
 a connection string name added to&nbsp;</span><code>appsettings.json</code><span>&nbsp;file.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">&quot;ConnectionStrings&quot;: {
    &quot;DefaultConnection&quot;: &quot;Data Source=.\\SQLEXPRESS2014;Initial Catalog=HangFireDb;Integrated Security=True;&quot;
  }</pre>
<div class="preview">
<pre class="js"><span class="js__string">&quot;ConnectionStrings&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;DefaultConnection&quot;</span>:&nbsp;<span class="js__string">&quot;Data&nbsp;Source=.\\SQLEXPRESS2014;Initial&nbsp;Catalog=HangFireDb;Integrated&nbsp;Security=True;&quot;</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Once the service is configured,&nbsp; navigate to&nbsp;</span><code>Configure</code><span>&nbsp;method to add below codes. Here,&nbsp;</span><code>app.UseHangfireDashboard()</code><span>&nbsp;will set up the dashboard&nbsp;</span><code>http://&lt;website-url&gt;/hangfire</code><span>,
 and&nbsp;</span><code>app.UseHangfireServer()</code><span>&nbsp;will register a new instance for&nbsp;</span><a href="http://api.hangfire.io/html/T_Hangfire_BackgroundJobServer.htm" target="_blank">BackgroundJobServer</a><span>.</span></div>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddConsole(Configuration.GetSection(&quot;Logging&quot;));
    loggerFactory.AddDebug();

    app.UseHangfireDashboard();
    app.UseHangfireServer();
    
    app.UseDeveloperExceptionPage();
    app.UseBrowserLink();
    
    app.UseStaticFiles();
    app.UseMvc(routes =&gt;
    {
        routes.MapRoute(
            name: &quot;default&quot;,
            template: &quot;{controller=Home}/{action=Index}/{id?}&quot;);
    });
}</pre>
<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;Configure(IApplicationBuilder&nbsp;app,&nbsp;IHostingEnvironment&nbsp;env,&nbsp;ILoggerFactory&nbsp;loggerFactory)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;loggerFactory.AddConsole(Configuration.GetSection(<span class="js__string">&quot;Logging&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;loggerFactory.AddDebug();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app.UseHangfireDashboard();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app.UseHangfireServer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app.UseDeveloperExceptionPage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app.UseBrowserLink();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app.UseStaticFiles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app.UseMvc(routes&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">&quot;default&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;template:&nbsp;<span class="js__string">&quot;{controller=Home}/{action=Index}/{id?}&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Now, Let's run the application. Hangfire dashboard is available in browser by hitting</span><code>http://&lt;website-url&gt;/hangfire</code><span>&nbsp;url.</span></div>
<div class="endscriptcode"><span><img id="165715" src="165715-implement-hangfire-aspnetcore-mvc-5.png" alt="" width="967" height="669"><br>
</span></div>
<p><span style="font-size:20px; font-weight:bold">How it works?</span></p>
<p><span>Hangfire handles different types of background jobs, and all of them are invoked in a separate execution context.</span><br>
<span>With Hangfire you can create</span></p>
<h5>Fire-and-forget</h5>
<p><span>Fire and forget jobs are executed once on an immediate basis after creation. Once you create a fire-and-forget job, it is saved to its queue (&quot;default&quot; by default, but multiple queues supported). The queue is listened by a couple of dedicated workers
 that fetch a job and perform it.&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">BackgroundJob.Enqueue(() =&gt; Console.WriteLine(&quot;Fire-and-forget Job Executed&quot;));</pre>
<div class="preview">
<pre class="csharp">BackgroundJob.Enqueue(()&nbsp;=&gt;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Fire-and-forget&nbsp;Job&nbsp;Executed&quot;</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h5>Delayed</h5>
<span>After the given delay the job will be put in its queue and invoked as a regular fire-and-forget job.&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">BackgroundJob.Schedule(() =&gt; Console.WriteLine(&quot;Delayed job executed&quot;), TimeSpan.FromMinutes(1));</pre>
<div class="preview">
<pre class="js">BackgroundJob.Schedule(()&nbsp;=&gt;&nbsp;Console.WriteLine(<span class="js__string">&quot;Delayed&nbsp;job&nbsp;executed&quot;</span>),&nbsp;TimeSpan.FromMinutes(<span class="js__num">1</span>));</pre>
</div>
</div>
</div>
<h5>Recurring</h5>
<p><span>Recurring jobs will recurrent on every defined interval.You can define interval from milliseconds to year.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">RecurringJob.AddOrUpdate(() =&gt; Console.WriteLine(&quot;Minutely Job executed&quot;), Cron.Minutely);</pre>
<div class="preview">
<pre class="js">RecurringJob.AddOrUpdate(()&nbsp;=&gt;&nbsp;Console.WriteLine(<span class="js__string">&quot;Minutely&nbsp;Job&nbsp;executed&quot;</span>),&nbsp;Cron.Minutely);</pre>
</div>
</div>
</div>
<h5>Continuations</h5>
<p><span>Continuations allow you to define complex workflows by chaining multiple background jobs together. Here second is Enqueued with the first job.&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var id = BackgroundJob.Enqueue(() =&gt; Console.WriteLine(&quot;Hello, &quot;));
BackgroundJob.ContinueWith(id, () =&gt; Console.WriteLine(&quot;world!&quot;));</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;id&nbsp;=&nbsp;BackgroundJob.Enqueue(()&nbsp;=&gt;&nbsp;Console.WriteLine(<span class="js__string">&quot;Hello,&nbsp;&quot;</span>));&nbsp;
BackgroundJob.ContinueWith(id,&nbsp;()&nbsp;=&gt;&nbsp;Console.WriteLine(<span class="js__string">&quot;world!&quot;</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>After running the application, we have interesting results in a dashboard.</span></div>
<div class="endscriptcode"><span><img id="165716" src="165716-implement-hangfire-aspnetcore-mvc-success.png" alt="" width="948" height="540"><br>
</span></div>
<p><span>That's all. You can find the detailed&nbsp;</span><a href="http://docs.hangfire.io/en/latest/" target="_blank">documentation</a><span>&nbsp;from the official&nbsp;</span><a rel="nofollow" href="http://hangfire.io/" target="_blank">Hangfire</a><span>&nbsp;website.
 You can fork the&nbsp;</span><a rel="nofollow" href="https://github.com/HangfireIO/Hangfire" target="_blank">Hangfire project</a><span>&nbsp;and make contributions on GitHub.</span></p>
<p>&nbsp;</p>
<p>For more details visit <a href="http://www.dotnetspan.com/2016/12/hangfire-with-aspnet-core-mvc-and-web-api.html">
original article</a>.&nbsp;</p>
