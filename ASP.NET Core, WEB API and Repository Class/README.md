# ASP.NET Core, WEB API and Repository Class
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Repository Pattern
- ASP.NET Web API
- ASP.NET Core
- ASP.NET Core 1.0.1
## Topics
- Repository Pattern
- ASP.NET Web API
- ASP.NET Core
## Updated
- 12/04/2016
## Description

<h1>Introduction</h1>
<div id="pastingspan1">This will be the series of article. In this series, we will see one by one in detail about</div>
<div id="pastingspan1">
<ol>
<li>Introduction to ASP.NET Core, WEB API and Repository Class </li><li>ASP.NET Core, WEB API and Repository Class display using MVC View </li><li>ASP.NET Core CRUD using WEB API and Repository Class </li><li>ASP.NET Core CRUD with Database using WEB API and Repository Class </li></ol>
</div>
<div id="pastingspan1">In this article, we will see in detail about how to create ASP.NET Core with Repository pattern in the WEB API.</div>
<div id="pastingspan1">This will be the series of article in the first series will see how to create a simple ASP.NET Core application and creating our first WEB API with Repository Class and view our JSON output in our browser.,&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div id="pastingspan1">
<p><strong>WEB API</strong></p>
<p><span>Web API is a simple and easy way to build HTTP Services for Browsers and Mobiles. It has the following four methods as Get/Post/Put and Delete where.</span></p>
<ul type="disc">
<li><span>Get is used to request for the data. (Select)</span> </li><li><span>Post is used to create a data. (Insert)</span> </li><li><span>Put is used to update the data.</span> </li><li><span>Delete used is to delete the data.</span> </li></ul>
</div>
<div id="pastingspan1"></div>
<div>&nbsp;Reference&nbsp;<a href="https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api" target="_blank">Link</a>
<p><strong><span>Repository Class</span></strong></p>
<p><span>Repository Patten allows us to create a new layer for our business logics and Database operations. We can user repository to store our data.to know more about repository check this&nbsp;<a href="https://msdn.microsoft.com/en-us/library/ff649690.aspx?f=255&MSPPError=-2147217396" target="_blank">link&nbsp;</a></span></p>
<p><strong><span>Prerequisites</span></strong></p>
<ul type="disc">
<li><em><span>Visual Studio 2015:</span></em><span>&nbsp;You can download it from&nbsp;<a href="https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx" target="_blank"><span>here</span></a>.</span>
</li><li><em><span>.NET Core 1.0.1:&nbsp;</span></em><span>download&nbsp;<a href="https://www.microsoft.com/net" target="_blank"><span>link</span></a>,<a href="https://www.microsoft.com/net/core#windows" target="_blank"><span>link2</span></a>.</span>
</li></ul>
</div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong><span>Step 1: Create our ASP.NET Core 1.0.1 Web Application.</span></strong><strong><span><br>
<br>
</span></strong><span>After installing both Visual Studio 2015 and ASP.NET Core 1.0.1. Click Start, then Programs and select Visual Studio 2015 - Click Visual Studio 2015. Click New, then Project, select Web and select ASP.NET Core Web Application. Enter your
 Project Name and click OK.</span></p>
<p><img id="163515" src="163515-1.png" alt="" width="567" height="282"></p>
<p><span>Next select WEB API. Click OK.</span></p>
<p><img id="163516" src="163516-2.png" alt="" width="560" height="319"></p>
<p><strong>Step 2: Creating Modules</strong></p>
<p><span>To create our module class first, we create one folder in side our solution project.</span></p>
<p><span>Right click our solution &gt; Click Add &gt; Click New Folder</span></p>
<p><img id="163517" src="163517-3.png" alt="" width="560" height="256"></p>
<p><span>Name the folder as&nbsp;</span><span>Models.</span></p>
<p><img id="163518" src="163518-3_1.png" alt="" width="180" height="133"></p>
<p><span>&nbsp;</span><strong>Creating Model Class</strong></p>
<p><span>Right Click the Model Folder, add new class and name it as&nbsp;<strong>&ldquo;StudentMasters.cs&rdquo;</strong></span></p>
<div>In this class, we declare our property variables.&nbsp;</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ASPNETCOREWEBAPI.Models&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;StdName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Phone&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Address&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Step 3: Repository Class</strong></p>
<p><strong>Creating Repository Class</strong></p>
<p><span>Here we create a Repository class to inject in to our Controllers. To create a Repository class,</span></p>
<p>Right click on Models Folder and click Add Class.</p>
<p>Name the class as&nbsp;<span>IStudentRepository .</span></p>
<p><span>Here we can see that I have given the class name starting with I as this class we will be using as Interface and here we will declare only our methods to be used in our StudentRepository class.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IStudentRepository&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetAll();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;Add(StudentMasters&nbsp;info);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><span>In this interface, we have added only Get and Add method. In our next article, we will see in details for CRUD operations.</span></p>
<p><span>Creating a class to implement the interface.</span></p>
<p><span>Now we create one more class inside Models folder as &ldquo;</span><span>StudentRepository&rdquo;</span><strong><span>&nbsp;we will</span></strong></p>
<p><span>In this class we create method to get all the student information and to add student Information&rsquo;s.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Concurrent.aspx" target="_blank" title="Auto generated link to System.Collections.Concurrent">System.Collections.Concurrent</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
namespace&nbsp;ASPNETCOREWEBAPI.Models&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentRepository:&nbsp;IStudentRepository&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;ConcurrentDictionary&lt;string,&nbsp;StudentMasters&gt;&nbsp;stdMaster&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ConcurrentDictionary&lt;string,&nbsp;StudentMasters&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;StudentRepository()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821039120700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;syedshanumcain@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Seoul,Korea&quot;</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetAll()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;stdMaster.Values;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Add(StudentMasters&nbsp;studentInfo)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stdMaster[studentInfo.StdName]&nbsp;=&nbsp;studentInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Adding Repository Class in Configure Services:</strong></p>
<p><span>To Inject our repository in Controllers we need to register the repository class with Dependency Injection Container.</span></p>
<p><span>To understand what is Dependency Injection(DI) check this&nbsp;<a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection" target="_blank">link&nbsp;</a></span></p>
<p><span>Open the Stratup.cs file from our solution project</span></p>
<p><img id="163519" src="163519-3_2.png" alt="" width="209" height="308"></p>
<p><span>First we add the using to import our Models folder&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;ASPNETCOREWEBAPI.Models;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Next we register our own services like the code below.</span><span>&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">services.AddSingleton&lt;IStudentRepository,&nbsp;StudentRepository&gt;();&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>&nbsp;</span><span>like this</span><span>&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;add&nbsp;services&nbsp;to&nbsp;the&nbsp;container.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;framework&nbsp;services.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddSingleton&lt;IStudentRepository,&nbsp;StudentRepository&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Here is complete Startup.cs class</span></div>
<div class="endscriptcode"><span><br>
</span></div>
<p><img id="163520" src="163520-3_3.png" alt="" width="560" height="347"></p>
<p>&nbsp;</p>
<p><span>&nbsp;</span><strong>Step 4:Creating Controllers</strong></p>
<p><span>Right Click the Controllers Folder &gt; Click Add &gt; Click New Item.</span></p>
<p><img id="163521" src="163521-4.png" alt="" width="509" height="180"></p>
<p><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">Select ASP.NET from left side&gt; Select Web API Controller Class.</span></p>
<p><img id="163522" src="163522-5.png" alt="" width="560" height="351"></p>
<p><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">Give your controller name as &ldquo;StudentController.cs&rdquo;</span></p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<span style="outline:0px">By default, our Controller class will be like this</span>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;ASPNETCOREWEBAPI.Controllers&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/values&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;string&gt;&nbsp;Get()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;string[]&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;value1&quot;</span>,&nbsp;<span class="js__string">&quot;value2&quot;</span>&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET&nbsp;api/values/5&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet(<span class="js__string">&quot;{id}&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Get(int&nbsp;id)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">&quot;value&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;POST&nbsp;api/values&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Post([FromBody]string&nbsp;value)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;PUT&nbsp;api/values/5&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPut(<span class="js__string">&quot;{id}&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Put(int&nbsp;id,&nbsp;[FromBody]string&nbsp;value)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;DELETE&nbsp;api/values/5&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpDelete(<span class="js__string">&quot;{id}&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Delete(int&nbsp;id)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">Remove all the default method inside our controller and change like to add our code.&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;ASPNETCOREWEBAPI.Controllers&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">First we add the using in our controller class&nbsp;</span>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;ASPNETCOREWEBAPI.Models;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="outline:0px; color:#333333; font-family:Consolas; font-size:9.5pt">Next we will create object for our Models.</span><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[Route(<span class="js__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">Adding Sample Information</span></strong></div>
<p><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></p>
<p>&nbsp;</p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<strong style="outline:0px">&nbsp;</strong></p>
<p><span style="outline:0px; color:#333333; font-size:9.5pt; font-family:Consolas">Next we add few sample student information to be get from our WEB API method.</span><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[Route(<span class="js__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;StudentController()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//To&nbsp;bind&nbsp;initial&nbsp;Student&nbsp;Information&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;InitializeData()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;StudentMasters&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;studentInfo1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821039120700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;syedshanumcain@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Seoul,Korea&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;studentInfo2&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Afraz&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821000000700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;afraz@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Madurai,India&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;studentInfo3&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Afreen&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821012340700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;afreen@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Chennai,India&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo1);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo2);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo3);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">WEB API Get Method</span></strong></div>
<p><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></p>
<p>&nbsp;</p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<span style="outline:0px; font-size:9.5pt; font-family:Consolas">Using this get method we return all the student information as JSON result.</span>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[Route(<span class="js__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;StudentController()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;will&nbsp;return&nbsp;all&nbsp;Student&nbsp;Information&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetAll()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_stdInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="outline:0px; color:#333333; font-family:Consolas; font-size:9.5pt">Here is the complete code for our controller class with both Adding sample data and using WEB API Get method.</span><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
using&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;&nbsp;&nbsp;
using&nbsp;ASPNETCOREWEBAPI.Models;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;ASPNETCOREWEBAPI.Controllers&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;api/[controller]&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;StudentController()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;will&nbsp;return&nbsp;all&nbsp;Student&nbsp;Information&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetAll()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_stdInfo;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//To&nbsp;bind&nbsp;initial&nbsp;Student&nbsp;Information&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;InitializeData()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;StudentMasters&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;studentInfo1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821039120700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;syedshanumcain@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Seoul,Korea&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;studentInfo2&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Afraz&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821000000700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;afraz@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Madurai,India&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;studentInfo3&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="js__string">&quot;Afreen&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;&#43;821012340700&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;afreen@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="js__string">&quot;Chennai,India&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo1);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo2);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo3);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">Step 5: Run the application</span></strong></div>
<p><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></p>
<p>&nbsp;</p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<span style="outline:0px; font-size:9.5pt; font-family:Consolas">To see the result runt the application .</span></p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<span style="outline:0px; font-size:9.5pt; font-family:Consolas">When we run the application by default we can see the values controller result as values</span></p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<span style="outline:0px; font-size:9.5pt; font-family:Consolas">http://localhost:64764/api/values</span></p>
<p><img id="163523" src="163523-7_1.png" alt="" width="327" height="101"></p>
<p><span style="outline:0px; color:#333333; font-family:Consolas; font-size:9.5pt">Change the Values with our newly created controller name as student &ldquo;</span><span style="font-family:Consolas"><span style="outline-color:initial; outline-style:initial; font-size:9.5pt">http://localhost:64764/api/student</span></span><span style="outline:0px; color:#333333; font-family:Consolas; font-size:9.5pt">&ldquo;.</span><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">&nbsp;</span></p>
<p style="outline:0px; color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<span style="outline:0px; font-size:9.5pt; font-family:Consolas">Here now we can see all our added student information has been displayed as JSON result.</span></p>
<p><img id="163524" src="163524-7.png" alt="" width="625" height="139"></p>
<div class="scriptcode"><span style="font-size:2em">Source Code Files</span></div>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><span style="color:#333333; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">This will be series of article in this first series we have seen in details about our first ASP.NET Core, WEB API and Repository Class for Get method. In next series, we will
 see how to bind this result in our MVC View.</span></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:4021px; width:1px; height:1px; overflow:hidden">
</div>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:4021px; width:1px; height:1px; overflow:hidden">
<div class="page" style="outline:0px; max-width:1024px; margin:0px auto; color:#8d8d8d; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<div class="main responsive_marginTop" style="outline:0px; width:1024px; float:left; margin-top:15px; min-height:430px; z-index:0; height:auto!important">
<div class="leftCntr" style="outline:0px; width:676px; float:left">
<div class="PaddingLeft5" id="div2" style="outline:0px; color:#333333; float:left; width:676px; line-height:21px">
<div style="outline:0px">&nbsp;<img src="-5.png" alt="" width="560" height="377" style="outline:0px; max-width:100%"></div>
<div style="outline:0px">&nbsp;Give your controller name as &ldquo;StudentController.cs&rdquo;
<p style="outline:0px"><span style="outline:0px">By default, our Controller class will be like this</span>&nbsp;</p>
</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;System;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">namespace</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ASPNETCOREWEBAPI.Controllers&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;api/[controller]&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">class</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;GET:&nbsp;api/values</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;IEnumerable&lt;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">string</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&gt;&nbsp;Get()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">return</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">string</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">[]&nbsp;{&nbsp;</span><span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;value1&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;</span><span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;value2&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;};&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;GET&nbsp;api/values/5</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet(<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;{id}&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">string</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Get(</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">int</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;id)&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">return</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;value&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;POST&nbsp;api/values</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">void</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Post([FromBody]</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">string</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;value)&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;PUT&nbsp;api/values/5</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPut(<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;{id}&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">void</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Put(</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">int</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;id,&nbsp;[FromBody]</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">string</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;value)&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;DELETE&nbsp;api/values/5</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpDelete(<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;{id}&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">void</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Delete(</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">int</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;id)&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;Remove all the default method inside our controller and change like to add our code.&nbsp;</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;System;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">namespace</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ASPNETCOREWEBAPI.Controllers&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;api/[controller]&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">class</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;First we add the using in our controller class&nbsp;</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ASPNETCOREWEBAPI.Models;&nbsp;&nbsp;</span></span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;<span style="outline:0px; font-family:Consolas; font-size:9.5pt">Next we will create object for our Models.</span>&nbsp;</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">[Route(</span><span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;api/[controller]&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">class</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">private</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;<strong style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">Adding Sample Information</span></strong>
<p style="outline:0px"><strong style="outline:0px">&nbsp;</strong></p>
<span style="outline:0px; font-size:9.5pt; font-family:Consolas">Next we add few sample student information to be get from our WEB API method.</span>&nbsp;</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">[Route(</span><span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;api/[controller]&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">class</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">private</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeData();&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//To&nbsp;bind&nbsp;initial&nbsp;Student&nbsp;Information</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">private</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">void</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;InitializeData()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;List&lt;StudentMasters&gt;();&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;studentInfo1&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentMasters&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Shanu&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&#43;821039120700&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;syedshanumcain@gmail.com&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Seoul,Korea&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;studentInfo2&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentMasters&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Afraz&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&#43;821000000700&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;afraz@gmail.com&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Madurai,India&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;studentInfo3&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentMasters&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Afreen&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&#43;821012340700&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;afreen@gmail.com&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Chennai,India&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo1);&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo2);&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo3);&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;<strong style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">WEB API Get Method</span></strong>
<p style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">Using this get method we return all the student information as JSON result.</span>&nbsp;</p>
</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">[Route(</span><span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;api/[controller]&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">class</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">private</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeData();&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//This&nbsp;will&nbsp;return&nbsp;all&nbsp;Student&nbsp;Information</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetAll()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">return</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;_stdInfo;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;<span style="outline:0px; font-family:Consolas; font-size:9.5pt">Here is the complete code for our controller class with both Adding sample data and using WEB API Get method.</span>&nbsp;</div>
<div style="outline:0px">
<div class="dp-highlighter" style="outline:0px; font-family:Consolas,&quot;Courier New&quot;,Courier,mono,serif; font-size:12px; background-color:#e7e5dc; width:669.234px; overflow:auto; padding-top:1px; margin:18px 0px!important">
<div class="bar" style="outline:0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:0px; padding:0px; border:none; list-style-position:initial; background-color:#ffffff; color:#5c5c5c; margin:0px 1px 1px 45px!important">
<li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;System;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">using</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ASPNETCOREWEBAPI.Models;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">namespace</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ASPNETCOREWEBAPI.Controllers&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;api/[controller]&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">class</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController&nbsp;:&nbsp;Controller&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">private</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;List&lt;StudentMasters&gt;&nbsp;_stdInfo;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentController()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeData();&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//This&nbsp;will&nbsp;return&nbsp;all&nbsp;Student&nbsp;Information</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">public</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetAll()&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">return</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;_stdInfo;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="comment" style="outline:0px; margin:0px; padding:0px; border:none; color:#008200; background-color:inherit">//To&nbsp;bind&nbsp;initial&nbsp;Student&nbsp;Information</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">private</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">void</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;InitializeData()&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;List&lt;StudentMasters&gt;();&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;studentInfo1&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentMasters&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Shanu&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&#43;821039120700&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;syedshanumcain@gmail.com&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Seoul,Korea&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;studentInfo2&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentMasters&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Afraz&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&#43;821000000700&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;afraz@gmail.com&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Madurai,India&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;studentInfo3&nbsp;=&nbsp;<span class="keyword" style="outline:0px; margin:0px; padding:0px; border:none; color:#006699; background-color:inherit; font-weight:bold">new</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;StudentMasters&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StdName&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Afreen&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&#43;821012340700&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;afreen@gmail.com&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;&nbsp;</span></span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&nbsp;=&nbsp;<span class="string" style="outline:0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;Chennai,India&quot;</span><span style="outline:0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo1);&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo2);&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stdInfo.Add(studentInfo3);&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:0px; border-top:none; border-right:none; border-bottom:none; border-left:3px solid #6ce26c; list-style-type:decimal-leading-zero; background-color:#f8f8f8; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; list-style-position:outside!important">
<span style="outline:0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:0px">&nbsp;<strong style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">Step 5: Run the application</span></strong>
<p style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">To see the result runt the application .</span></p>
<p style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">When we run the application by default we can see the values controller result as values</span></p>
<p style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">http://localhost:64764/api/values</span></p>
</div>
<div style="outline:0px">&nbsp;<img src="-7_1.png" alt="" style="outline:0px; max-width:100%"></div>
<div style="outline:0px">&nbsp;<span style="outline:0px; font-family:Consolas; font-size:9.5pt">Change the Values with our newly created controller name as student &ldquo;</span><a href="http://localhost:64764/api/student" target="_blank" style="outline:0px; text-decoration:none; font-family:Consolas; font-size:9.5pt">http://localhost:64764/api/student</a><span style="outline:0px; font-family:Consolas; font-size:9.5pt">&nbsp;&ldquo;.</span>
<p style="outline:0px"><span style="outline:0px; font-size:9.5pt; font-family:Consolas">Here now we can see all our added student information has been displayed as JSON result.</span></p>
</div>
<div style="outline:0px">&nbsp;<img src="-7.png" alt="" width="560" height="124" style="outline:0px; max-width:100%"></div>
<div style="outline:0px">&nbsp;</div>
<div style="outline:0px">&nbsp;<strong style="outline:0px">Conclusion:</strong></div>
<div style="outline:0px">This will be series of article in this first series we have seen in details about our first ASP.NET Core, WEB API and Repository Class for Get method. In next series, we will see how to bind this result in our MVC View.</div>
<div style="outline:0px"></div>
<p style="outline:0px">&nbsp;</p>
</div>
<div id="ArticleExtentionContainer" style="outline:0px">
<div class="clear" style="outline:0px; clear:both"></div>
</div>
<div class="clear" style="outline:0px; clear:both"></div>
<div class="linkAdContainer bottom" id="LinkAdContainerBottom" style="outline:0px">
<div class="LinkAd" id="LinkAd_Container" style="outline:0px; float:left; margin-top:10px; width:310.953px; padding:0px; line-height:20px; clear:right; margin-bottom:5px">
<a id="linkAd" class="linkAd LinkNormalBlue" href="http://www.c-sharpcorner.com/AdRedirector.aspx?AdId=92&target=http://www.e-iceblue.com/Introduce/free-products.html?aff_id=100" target="_blank" style="outline:0px; text-decoration:none; color:#0066cc">Download
 100% FREE Spire Office APIs</a></div>
</div>
<div class="relatedArticle tag-box" id="ctl00_divTagsBox" style="outline:0px; border:0px; padding:15px 0px 5px; overflow:hidden; width:676px; float:left">
<a class="HeaderTagCloud" href="http://www.c-sharpcorner.com/topics/web-api" style="outline:0px; text-decoration:none; border:0px; color:#ffffff; background:#0ab7ff; zoom:1; padding:0px 8px; margin:0px 4px 4px 0px; display:inline-block; line-height:2.2">WEB
 API</a>&nbsp;<a class="HeaderTagCloud" href="http://www.c-sharpcorner.com/topics/asp-net-core" style="outline:0px; text-decoration:none; border:0px; color:#ffffff; background:#0ab7ff; zoom:1; padding:0px 8px; margin:0px 4px 4px 0px; display:inline-block; line-height:2.2">ASP.NET
 Core</a></div>
<div class="clear" style="outline:0px; clear:both"></div>
<div id="AboutAuthorBox" style="outline:0px">
<div class="auther_bio" style="outline:0px; border-top:1px dashed #dee2e7; overflow:hidden; padding:18px 0px; width:676px">
<a id="ctl00_AuthorImageAnchor" class="image" href="http://www.c-sharpcorner.com/members/syed-shanu" style="outline:0px; text-decoration:none; display:block; float:left; margin-right:20px; overflow:hidden"><img id="ctl00_AuthorImage" src="-asmabegam20160707040512.jpg.ashx?width=100&height=100" alt="Syed Shanu" style="outline:0px; height:100px; width:100px"></a>
<div class="autherDetail" style="outline:0px; overflow:hidden"><a id="ctl00_AuthorName" class="userName" href="http://www.c-sharpcorner.com/members/syed-shanu" style="outline:0px; text-decoration:none; color:#ff6600; font-family:BebasNeueRegular; font-size:26px; padding:0px; margin-right:4px">Syed
 Shanu</a>&nbsp;<img id="TopAuthorImage" class="top-author" title="Top 100" src="-top_100.png" alt="" style="outline:0px; display:inline-block; vertical-align:bottom">
<p id="ctl00_Description" class="description" style="outline:0px; color:#525252; font-size:14px; line-height:22px; margin:6px 0px 10px">
Microsoft MVP | CSharp Corner MVP | Code Project MVP | Author | Blogger and always happy to Share what he knows to others.For any queries you can contact him to his facebook id.</p>
<div class="description" id="ctl00_PersonalBlogContainer" style="outline:0px; color:#525252; font-size:14px; line-height:22px; margin:6px 0px 10px">
<a id="ctl00_PersonalBlog" class="LinkNormalBlue personalProfileLink" href="http://shanucsharp.blogspot.kr/" target="_blank" style="outline:0px; text-decoration:none; color:#0066cc; padding-left:23px; line-height:18px; min-height:21px; display:inline-block; word-break:break-all">http://shanucsharp.blogspot.kr/</a></div>
<ul class="social" style="outline:0px; margin:0px; padding:0px; right:0px; top:12px">
<li class="github" style="outline:0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_GitHubProfileUrl" class="notSet" title="Not Available" target="_blank" style="outline:0px; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">GitHub</a>
</li><li class="twitter" style="outline:0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_TwitterFollow" title="Follow Syed on Twitter" href="https://twitter.com/intent/follow?screen_name=syedshanu3" target="_blank" style="outline:0px; text-decoration:none; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">Follow</a>
</li><li class="facebook" style="outline:0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_FacebookProfileUrl" title="Follow Syed on Facebook" href="https://www.facebook.com/syed.shanu.9" target="_blank" style="outline:0px; text-decoration:none; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">Facebook</a>
</li><li class="linkedIn" style="outline:0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_LinkedInProfileUrl" title="Follow Syed on LinkedIn" href="https://www.linkedin.com/hp/?dnr=azIOr7uy4Ybsrsnw5AbOoeVw41LDYjLvvtm" target="_blank" style="outline:0px; text-decoration:none; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">LinkedIn</a>
</li></ul>
</div>
<div class="clear" style="outline:0px; clear:both"></div>
<div class="autherIcons" style="outline:0px; margin:13px 0px 0px; overflow:hidden; width:676px">
<ul style="outline:0px; display:table-row; list-style:none outside none; margin:0px; overflow:hidden; padding:0px; text-align:center">
<li id="LiAuthorRank" class="li_1" title="Overall Rank" style="outline:0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:1px 16px 0px 55px">
<a href="http://www.c-sharpcorner.com/top-members" style="outline:0px; text-decoration:none"><span class="rank" style="outline:0px; display:block; height:46px; left:11px; top:0px; width:42px">&nbsp;</span><span id="ctl00_Rank" class="count" style="outline:0px; color:#616161; display:block; font-size:24px; font-family:proximanova-bold">60</span><span class="text" style="outline:0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Rank</span></a>
</li><li class="li_2" title="Total Views" style="outline:0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:0px 16px 0px 66px">
<a href="http://www.c-sharpcorner.com/members/syed-shanu/top-articles" style="outline:0px; text-decoration:none"><span class="reader" style="outline:0px; display:block; height:48px; left:11px; top:0px; width:50px">&nbsp;</span><span id="ctl00_Readers" class="count" style="outline:0px; color:#616161; display:block; font-size:24px; font-family:proximanova-bold">1.4m</span><span class="text" style="outline:0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Read</span></a>
</li><li id="ctl00_listMedal" class="li_4" title="Platinum Member" style="outline:0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:15px 16px 0px 48px">
<span id="ctl00_Medal" class="medal Platinum" style="outline:0px; display:block; height:55px; left:11px; top:0px; width:31px">&nbsp;</span><span id="ctl00_MedalText" class="count x_x_x_x_x_x_x_x_Platinum" style="outline:0px; color:#818181; display:block; font-size:24px; font-family:proximanova-regular; margin-top:-15px">Platinum</span><span class="text" style="outline:0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Member</span>
</li><li id="ctl00_CSharpMVP" class="li_3" title="User is a C# Corner MVP" style="outline:0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:0px 16px 0px 77px">
<a href="http://www.c-sharpcorner.com/Members/mvps/" style="outline:0px; text-decoration:none"><span class="csharpmvp" style="outline:0px; display:block; height:50px; left:11px; top:0px; width:60px">&nbsp;</span><span id="ctl00_MVP" class="count" style="outline:0px; color:#616161; display:block; font-size:24px; font-family:proximanova-bold">2</span><span class="text" style="outline:0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Times</span></a>
</li><li id="ctl00_MicrosoftMVP" class="li_5" title="User is a Microsoft MVP" style="outline:0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:0px 16px 0px 55px">
<a id="ImageMsMVP" target="_blank" style="outline:0px"><span class="microsoftmvp" style="outline:0px; display:block; float:left; height:57px; left:11px; margin:0px 10px 0px 0px; top:0px; width:38px">&nbsp;</span><span id="ctl00_MSMVP" class="count" style="outline:0px; color:#616161; display:block; font-size:24px; font-family:proximanova-bold">1</span><span class="text" style="outline:0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Time</span></a>
</li></ul>
</div>
</div>
<div class="clear" style="outline:0px; clear:both"></div>
</div>
<div class="clear" style="outline:0px; clear:both"></div>
<div class="clear" style="outline:0px; clear:both"></div>
<div class="clear" style="outline:0px; clear:both"></div>
</div>
<div class="rightCntr" style="outline:0px; width:336px; float:right; padding-bottom:10px">
<div id="PremiumSponsorTextAdBox" style="outline:0px">
<div id="ctl00_SponsorWithImage" style="outline:0px"></div>
</div>
<div id="NewsArticleAdBox" style="outline:0px">
<div class="clear x_x_x_x_x_x_x_x_newsArticleAd" style="outline:0px; clear:both">
</div>
<div style="outline:0px; width:336px; margin:10px 0px"><a id="ctl00_AdRotatorArticle" href="http://www.c-sharpcorner.com/AdRedirector.aspx?BannerId=744&target=https://www.syncfusion.com/sales/unlimitedlicense?utm_medium=mindcrackerfflNov16" target="_blank" style="outline:0px; text-decoration:none"></a></div>
</div>
<div class="rightBox" style="outline:0px; float:left; padding:0px 0px 5px; width:336px">
<h2 class="headerControls" style="outline:0px; margin:0px; padding:0px; height:30px; line-height:30px; font-size:20px; font-family:BebasNeueRegular; color:#727272; font-weight:normal; text-transform:uppercase; clear:both">
TRENDING UP<a id="ctl00_RightBar_ArticleDetailRightBar1_TrendingUp2_RssEnabledImageButton" class="headerRss" href="http://www.c-sharpcorner.com/RSS/TopArticles.aspx" target="_blank" style="outline:0px; text-decoration:none; margin-top:3px; width:16px; height:20px; display:block; text-indent:-9999px; float:right"></a></h2>
<ul class="trendingBox" style="outline:0px; overflow:hidden; list-style:none; margin:10px 5px 5px; padding:0px">
<li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">01</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/tips-for-writing-clean-and-best-code-in-c-sharp/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Tips
 For Writing Clean And Concise Code In C#</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">02</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/asp-net-mvc-hotel-booking-system-using-angularjs/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">ASP.NET
 MVC Hotel Booking System Using AngularJS</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">03</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/programming-language-for-2017/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Programming
 Language For 2017</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">04</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/why-developers-should-focus-on-communication/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Why
 Developers Should Focus On Communication</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">05</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">CRUD
 Operations In ASP.NET Core Using Entity Framework Core Code First</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">06</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/creating-web-api-with-repository-pattern-and-dependency-injection/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Creating
 Web API With Repository Pattern And Dependency Injection</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">07</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/steps-to-create-custom-master-page-in-sharepoint-2013-using-design-manager/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Steps
 To Create Custom Master Page In SharePoint 2013 Using Design Manager</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">08</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/web-scraping-in-c-sharp/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Web Scraping In C#</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">09</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/steps-to-create-custom-display-templates-in-sharepoint-2013/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Steps
 To Create Custom Display Templates In SharePoint 2013</a></div>
</li><li style="outline:0px; overflow:hidden; display:block; border-bottom:1px solid #f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<span class="numbers" style="outline:0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">10</span>
<div class="trendingDetail" style="outline:0px; width:260px; float:left"><a href="http://www.c-sharpcorner.com/article/how-to-scroll-and-view-millions-of-records/" style="outline:0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">How
 To Scroll And View Millions Of Records</a></div>
</li></ul>
<a class="viewAllLink" href="http://www.c-sharpcorner.com/top-articles" style="outline:0px; text-decoration:none; margin:0px 10px 10px 0px; padding:0px 22px 1px 0px; color:#3366cc; float:right">View All<em style="outline:0px; right:0px; top:1px; width:21px; height:21px">&nbsp;</em></a></div>
<div style="outline:0px; padding-bottom:10px"></div>
<div class="fb_reset" id="fb-root" style="outline:0px; background:none; border:0px; border-spacing:0px; color:#000000; direction:ltr; font-family:&quot;lucida grande&quot;,tahoma,verdana,arial,sans-serif; font-size:11px; line-height:1; margin:0px; overflow:visible; padding:0px; visibility:visible; word-spacing:normal">
<div style="outline:0px; overflow:hidden; top:-10000px; height:0px; width:0px">
<div style="outline:0px"></div>
</div>
<div style="outline:0px; overflow:hidden; top:-10000px; height:0px; width:0px">
<div style="outline:0px"></div>
</div>
</div>
<div class="fb-like-box x_x_x_x_x_x_x_x_fb_iframe_widget" style="outline:0px; display:inline-block; padding-bottom:10px; border:0px none">
<span style="outline:0px; display:inline-block; text-align:justify; vertical-align:bottom; width:336px; height:214px">&nbsp;</span></div>
<div id="NewArticleAdMiddle" style="outline:0px">
<div class="clear" style="outline:0px; clear:both"></div>
<div style="outline:0px; width:336px; margin-bottom:10px"><a id="ctl00_AdRotatorArticle" href="http://www.c-sharpcorner.com/AdRedirector.aspx?BannerId=744&target=https://www.syncfusion.com/sales/unlimitedlicense?utm_medium=mindcrackerfflNov16" target="_blank" style="outline:0px; text-decoration:none"></a></div>
</div>
<div class="clear" style="outline:0px; clear:both"></div>
</div>
</div>
</div>
<div class="footer" style="outline:0px; width:1903px; height:auto; float:left; margin-top:10px; left:0px; bottom:0px; color:#8d8d8d; font-family:&quot;Open Sans&quot;,sans-serif; font-size:15px">
<div class="menuStripGray" style="outline:0px; width:1903px; height:auto; background-color:#b5b5b5; padding:5px 0px; float:left">
<div class="page" style="outline:0px; max-width:1024px; margin:0px auto">
<ul style="outline:0px; float:left; margin:0px; padding:0px">
<li class="first" style="outline:0px; display:block; float:left; background:0px center; color:#ff6600">
<a href="http://www.c-sharpcorner.com/members/mvps/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 0px; font-size:12px; color:#000000">MVPs</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/most-viewed-articles" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">MOST VIEWED</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/members/legend/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">LEGENDS</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/articles/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">NOW</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/prizes/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">PRIZES</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/reviews/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">REVIEWS</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/survey/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">SURVEY</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/certification/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">CERTIFICATIONS</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/downloads/" style="outline:0px; text-decoration:none; display:block; padding:4px 10px 4px 15px; font-size:12px; color:#000000">DOWNLOADS</a>
</li></ul>
<div class="rightlink" style="outline:0px; float:right"><a href="http://www.cbeyond.net/" target="_blank" style="outline:0px; text-decoration:none; font-size:14px; color:#982929; margin-top:3px; display:block"><span class="hosted" style="outline:0px; color:#000000">Hosted
 By&nbsp;</span>CBeyond Cloud Services</a></div>
</div>
</div>
<div class="menuStripBlue" style="outline:0px; background:#0086dc; float:left; height:34px; width:1903px; z-index:99">
<div class="page" style="outline:0px; max-width:1024px; margin:0px auto">
<div class="menu" style="outline:0px">
<ul style="outline:0px; list-style:none; margin:0px; padding:0px">
<li class="first" style="outline:0px; display:block; float:left; background:0px center">
<a href="http://www.c-sharpcorner.com/resources/aboutus.aspx" style="outline:0px; text-decoration:none; color:#ffffff; display:block; padding:8px 10px 0px 0px; height:27px; float:left; text-transform:uppercase">ABOUT US</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/faq" style="outline:0px; text-decoration:none; color:#ffffff; display:block; padding:8px 10px 0px 11px; height:27px; float:left; text-transform:uppercase">FAQ</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/media/contactus.aspx" style="outline:0px; text-decoration:none; color:#ffffff; display:block; padding:8px 10px 0px 11px; height:27px; float:left; text-transform:uppercase">MEDIA
 KIT</a> </li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/members/" style="outline:0px; text-decoration:none; color:#ffffff; display:block; padding:8px 10px 0px 11px; height:27px; float:left; text-transform:uppercase">MEMBERS</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/beginners/" style="outline:0px; text-decoration:none; color:#ffffff; display:block; padding:8px 10px 0px 11px; height:27px; float:left; text-transform:uppercase">STUDENTS</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/resources/" style="outline:0px; text-decoration:none; color:#ffffff; display:block; padding:8px 10px 0px 11px; height:27px; float:left; text-transform:uppercase">LINKS</a>
</li></ul>
</div>
</div>
</div>
<div class="footerBottom" style="outline:0px; background-color:#000000; float:left; padding:10px 0px; width:1903px">
<div class="page" style="outline:0px; max-width:1024px; margin:0px auto">
<ul style="outline:0px; float:left; margin:0px; padding:0px">
<li class="first" style="outline:0px; display:block; float:left; background:0px center; color:#ff6600">
<a href="http://www.c-sharpcorner.com/contactus.aspx" style="outline:0px; text-decoration:none; color:gray; display:block; padding:8px 7px 0px 0px; font-size:12px">CONTACT US</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/privacypolicy.aspx" style="outline:0px; text-decoration:none; color:gray; display:block; padding:8px 7px 0px 10px; font-size:12px">PRIVACY POLICY</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/termsconditions.aspx" style="outline:0px; text-decoration:none; color:gray; display:block; padding:8px 7px 0px 10px; font-size:12px">TERMS &amp; CONDITIONS</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/sitemap/" style="outline:0px; text-decoration:none; color:gray; display:block; padding:8px 7px 0px 10px; font-size:12px">SITEMAP</a>
</li><li style="outline:0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/report-bugs" style="outline:0px; text-decoration:none; color:gray; display:block; padding:8px 7px 0px 10px; font-size:12px">REPORT A BUG</a>
</li></ul>
<div class="social_link" style="outline:0px; float:right; padding-bottom:6px">
<ul style="outline:0px; float:right; margin:0px; padding:0px 0px 6px">
<li style="outline:0px; display:block; float:left; background:0px center"><a class="facebook" href="http://www.facebook.com/pages/C-Corner/194086953935286" target="_blank" style="outline:0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">facebook</a>
</li><li style="outline:0px; display:block; float:left; background:0px center"><a class="twitter" href="http://twitter.com/csharpcorner" target="_blank" style="outline:0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">twitter</a>
</li><li style="outline:0px; display:block; float:left; background:0px center"><a class="google" href="https://plus.google.com/u/0/114221266846457741050/posts" target="_blank" style="outline:0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">google</a>
</li><li style="outline:0px; display:block; float:left; background:0px center"><a class="media" href="http://www.youtube.com/user/CsharpCorner1/" target="_blank" style="outline:0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">media</a>
</li></ul>
<p class="copyright" style="outline:0px; clear:both">&copy;2016 C# Corner. All contents are copyright of their authors.</p>
</div>
</div>
</div>
</div>
</div>
