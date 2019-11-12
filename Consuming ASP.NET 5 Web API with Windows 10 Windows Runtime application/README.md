# Consuming ASP.NET 5 Web API with Windows 10 Windows Runtime application
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- ASP.NET
- Windows Runtime
- Windows Store app
- ASP.NET MVC 5
- ASP.NET Web API 2
- Windows 10
## Topics
- ASP.NET Web API
- Windows Store app
## Updated
- 08/14/2015
## Description

<h1>Introduction</h1>
<p><em>This sample project explains how to create an ASP.NET 5 Web API and to consume it in Windows 10 native application using Windows Runtime APIs.&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This project was built and tested in Visual Studio 2015 Community (or any edition that you can use). The project works as expected and establishes a connection between the Web API and the client application.&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>ASP.NET 5 is the new version of ASP.NET and maintaining the Web API is a lot easier in ASP.NET 5. I have provided a sample for you to learn how easy and simple it is to create a Web API and use it in ASP.NET 5. On a side note, Windows 10 has released
 and many would be looking forward for articles and sources for Windows 10 samples. In my sample I have used
<strong>Windows.Web.Http</strong> namespace's <strong>HttpClient</strong> (to provide full Windows Runtime feel).&nbsp;</em></p>
<p><em>The Web API's code is a simple single controller for the API. We use the routes to work with the code at
<strong>/api/controller</strong> and let the users get responses.Below is the code for that controller.&nbsp;</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.Mvc;&nbsp;
<span class="cs__keyword">using</span>&nbsp;APIWin10CRUDExample.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;APIWin10CRUDExample.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/[controller]&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UserController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET:&nbsp;api/user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;User&gt;&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Model.GetAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET&nbsp;api/user/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet(<span class="cs__string">&quot;{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;User&nbsp;Get(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Model.GetUser(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;POST&nbsp;api/user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Post([FromForm]<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;JsonConvert.DeserializeObject&lt;User&gt;(<span class="cs__keyword">value</span>);&nbsp;<span class="cs__com">//&nbsp;Convert&nbsp;JSON&nbsp;to&nbsp;Users</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model.CreateUser(user);&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;new&nbsp;User</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;PUT&nbsp;api/user/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPut(<span class="cs__string">&quot;{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Put([FromForm]<span class="cs__keyword">int</span>&nbsp;id,&nbsp;[FromForm]<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;JsonConvert.DeserializeObject&lt;User&gt;(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model.UpdateUser(id,&nbsp;user);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;DELETE&nbsp;api/user/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpDelete(<span class="cs__string">&quot;{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model.DeleteUser(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;You should consider downloading the package for more details and to test the application by building it! :-)</div>
<br>
</em>
<p></p>
<p><em>The code for the client is as simple as,&nbsp;</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Other&nbsp;namespaces&nbsp;for&nbsp;the&nbsp;project</span>&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.Web.Http;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;In&nbsp;the&nbsp;source&nbsp;code</span>&nbsp;
<span class="cs__keyword">using</span>&nbsp;(var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient())&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Send&nbsp;the&nbsp;requests&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;client.GetAsync();&nbsp;//&nbsp;GET&nbsp;HTTP&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;**/</span>&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
This way you can send other types of requests also. They would require different parameters based on how your API requests them.&nbsp;</em>
<p></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Client is the package that contains the libraries and other tools required to run the client application. It is a Windows 10 Windows Runtime application.&nbsp;</em>
</li><li><em><em>Inside the package is the Web API. The package name is <strong>APICRUDSample</strong>. Unzip it and run it before running the client.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>This package and a full explanation is already hosted on many websites. You should consider reading them. I have also provided an article on
<a href="http://www.c-sharpcorner.com/UploadFile/201fc1/consuming-Asp-Net-5-web-api-with-crud-functions-in-windows-1/">
C# Corner</a>, consider reading it to learn more.</em></p>
