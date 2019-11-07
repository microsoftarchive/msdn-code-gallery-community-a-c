# ASP.NET Core 2.0 -Dependency Injection
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- ASP.NET
- ASP.NET Core 2.0
## Topics
- C#
- ASP.NET
- ASP.NET Core 2.0
## Updated
- 01/12/2018
## Description

<p class="post-name">In this article, I'll show you the new feature introduced in ASP .NET Core that allows you to inject dependencies directly into a View using the dependency injection container.</p>
<p class="post-content x_user-defined-markup"><br>
ASP .NET Core has introduced a feature called view injection that allows you to inject dependencies into a view using the inject keyword.<br>
<br>
Previously, to retrieve data from a View, we needed to pass it from the Controller using the Controller properties, such as ViewBag, ViewData, or Model properties.<br>
<br>
In ASP.NET Core MVC, this task became very simple using the Inject directive that allows you to inject the dependencies directly into the View and retrieve the data.<br>
<br>
Let's see this working in practice!</p>
<p class="post-content x_user-defined-markup">&nbsp;</p>
<p class="post-content x_user-defined-markup">&nbsp;</p>
<h1><span><span style="font-size:small"><strong>STEP1 - Creating the ASP .NET Core Project in VS 2017</strong></span><br>
</span></h1>
<p>Open VS 2017 and on the File menu click New Project. Then select the Visual C # -&gt; Web template and check ASP .NET Core Web Application (.NET Core).&nbsp;<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/2260.Image1.png"><img src=":-2260.image1.png" alt=" "></a><br>
<br>
Then enter the name AspNetCoreDemo and click OK.<br>
<br>
In the next window, choose the ASP .NET Core 2.0 version and mark the Web Application (Model-View-Controller) template without authentication and click the OK button:<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0451.Image2.png"><img src=":-0451.image2.png" alt=" "></a><br>
<br>
<strong>&nbsp;</strong></p>
<h1><strong><span style="font-size:small">STEP2 - Creating a new service in the application</span></strong></h1>
<strong></strong>Let's define a very simple service just for testing in our application.<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/3250.Image3.png"><img src=":-3250.image3.png" alt=" "></a><br>
<br>
Create the Services folder in the project (Project -&gt; New Folder), and then add the CountriesService.cs file to this folder containing the following code:<br>
<br>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1 style="display:inline!important"><span style="font-size:small">STEP 3 - Injecting the service into View</span></h1>
<div class="reCodeBlock">
<div><strong>&nbsp;</strong></div>
</div>
<p class="post-content x_user-defined-markup">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Collections.Generic;
namespace AspNetCoreDemo.Services
{
    public class CountriesService
    {
        public List&lt;string&gt; GetCountries()
        {
            return new List&lt;string&gt;() { &quot;Portugal&quot;, &quot;Spain&quot;, &quot;France&quot; };
        }
    }
}
</pre>
<div class="preview">
<pre class="js">using&nbsp;System.Collections.Generic;&nbsp;
namespace&nbsp;AspNetCoreDemo.Services&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CountriesService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;List&lt;string&gt;&nbsp;GetCountries()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;()&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;Portugal&quot;</span>,&nbsp;<span class="js__string">&quot;Spain&quot;</span>,&nbsp;<span class="js__string">&quot;France&quot;</span>&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;We will now have how we can inject the service created in the project view using the @inject directive.</div>
<p><br>
Think of the @Inject directive as a property being added in your View and populating the property using dependency injection.<br>
<br>
The basic syntax used is: @inject &lt;service&gt; &lt;name&gt;<br>
<br>
At where :<br>
1. @ inject - is the directive used to inject dependencies;<br>
2. &lt;service&gt; - is the class of service.<br>
3. &lt;name&gt; - is the service injection name through which we can access the service's methods.<br>
<br>
Let's open the Index.cshtml file from the /Views/Home folder and include the code below in this file</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@inject AspNetCoreDemo.Services.CountriesService Countries
@foreach (var countryName in Countries.GetCountries())
        {
            &lt;ul&gt;
                &lt;li&gt;@countryName&lt;/li&gt;
            &lt;/ul&gt;
        }</pre>
<div class="preview">
<pre class="js">@inject&nbsp;AspNetCoreDemo.Services.CountriesService&nbsp;Countries&nbsp;
@foreach&nbsp;(<span class="js__statement">var</span>&nbsp;countryName&nbsp;<span class="js__operator">in</span>&nbsp;Countries.GetCountries())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;@countryName&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong style="font-size:small">STEP4 - Registering the service in the Startup.cs file</strong></div>
<p>&nbsp;</p>
<p><br>
Open the Startup.cs file and add the code below to this file that registers the service created for dependency injection in the ConfigureServices method.<br>
<br>
</p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient&lt;CountriesService&gt;();
        }</pre>
<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddTransient&lt;CountriesService&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong style="font-size:small">STEP5 - Result</strong></div>
</div>
</div>
<p>Executing the project, we will obtain the following result:<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0451.Image4.png"><img src=":-0451.image4.png" alt=" "></a></p>
<p>&nbsp;</p>
