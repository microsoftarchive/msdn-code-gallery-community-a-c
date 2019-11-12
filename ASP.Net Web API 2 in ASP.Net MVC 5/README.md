# ASP.Net Web API 2 in ASP.Net MVC 5
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET Web API
- ASP.NET MVC 5
## Topics
- ASP.NET Web API
- MVC5
## Updated
- 01/12/2016
## Description

<h1 style="text-align:justify">Introduction</h1>
<p style="text-align:justify"><span>Today, we'll learn how to access the <span style="background-color:#888888">
Web API 2 in the ASP.NET MVC 5 application</span>.&nbsp;</span></p>
<h1 style="text-align:justify"><span>Building the Sample</span></h1>
<p style="text-align:justify">To create this application, there are the following prerequisites:</p>
<ul style="text-align:justify">
<li>Visual Studio 2013 or higher. </li><li>ASP.NET MVC 5 </li></ul>
<p style="text-align:justify"><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify">If you are building apps or websites today, the chances are you&rsquo;ll have heard of REST and .net Web API, but you may not be sure what these things are, whether you should use them or how to get started. If this sounds familiar,
 then this article for you.<span style="font-size:20px; font-weight:bold"><br>
</span></p>
<p style="text-align:justify"><span>ASP.NET Web API is a framework for building web APIs on top of the .NET Framework.&nbsp;</span>This article described how to create the Web API and access that Web API in the ASP.NET MVC 5. We'll show the CRUD operations
 in further articles. Thanks for reading.&nbsp;&nbsp;</p>
<p style="text-align:justify"><span>A&nbsp;</span><em>model</em><span>&nbsp;is an object that represents the data in your application ASP.NET Web API can automatically serialize your model to JSON, XML, or some other format, and then write the serialized data
 into the body of the HTTP response message. As long as a client can read the serialization format, it can deserialize the object. Most clients can parse either XML or JSON. Moreover, the client can indicate which format it wants by setting the Accept header
 in the HTTP request message.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StudentRepository&nbsp;:&nbsp;IStudentRepository&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;List&lt;Student&gt;&nbsp;items&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Student&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;next&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StudentRepository()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddStudent(<span class="cs__keyword">new</span>&nbsp;Student&nbsp;{&nbsp;ID&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Chourouk&quot;</span>,&nbsp;City&nbsp;=&nbsp;<span class="cs__string">&quot;Hammamet&quot;</span>,&nbsp;Course&nbsp;=&nbsp;<span class="cs__string">&quot;Software&nbsp;engineering&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddStudent(<span class="cs__keyword">new</span>&nbsp;Student&nbsp;{&nbsp;ID&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Khaled&quot;</span>,&nbsp;City&nbsp;=&nbsp;<span class="cs__string">&quot;Gabes&quot;</span>,&nbsp;Course&nbsp;=&nbsp;<span class="cs__string">&quot;Mobile&nbsp;development&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddStudent(<span class="cs__keyword">new</span>&nbsp;Student&nbsp;{&nbsp;ID&nbsp;=&nbsp;<span class="cs__number">3</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sirine&quot;</span>,&nbsp;City&nbsp;=&nbsp;<span class="cs__string">&quot;Nabeul&quot;</span>,&nbsp;Course&nbsp;=&nbsp;<span class="cs__string">&quot;Medecine&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddStudent(<span class="cs__keyword">new</span>&nbsp;Student&nbsp;{&nbsp;ID&nbsp;=&nbsp;<span class="cs__number">4</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Israa&quot;</span>,&nbsp;City&nbsp;=&nbsp;<span class="cs__string">&quot;Rades&quot;</span>,&nbsp;Course&nbsp;=&nbsp;<span class="cs__string">&quot;Design&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Student&gt;&nbsp;GetAllStudents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;items;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Student&nbsp;AddStudent(Student&nbsp;student)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(items&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;student&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;student.ID&nbsp;=&nbsp;next&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Add(student);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;student;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="csharp">@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="cs__string">&quot;Data&quot;</span>;&nbsp;
}&nbsp;
&nbsp;
&lt;script&nbsp;src=<span class="cs__string">&quot;~/Scripts/jquery-1.10.2.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax({&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="cs__string">&quot;http://localhost:10689/api/students&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="cs__string">&quot;Get&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;function&nbsp;(data)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;data.length;&nbsp;i&#43;&#43;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">&quot;&lt;tr&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;&nbsp;data[i].Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/td&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;data[i].Course&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/td&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;data[i].City&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/td&gt;&lt;/tr&gt;&quot;</span>).appendTo(<span class="cs__string">&quot;#students&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;function&nbsp;(msg)&nbsp;{&nbsp;alert(msg);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&lt;/script&gt;&nbsp;
&nbsp;
&lt;h2&gt;Index&lt;/h2&gt;&nbsp;
&nbsp;
&lt;div&nbsp;id=<span class="cs__string">&quot;body&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;section&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;content-wrapper&nbsp;main-content&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;id=<span class="cs__string">&quot;students&quot;</span>&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;table&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;@Html.DisplayName(<span class="cs__string">&quot;Name&quot;</span>)&lt;/th&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;@Html.DisplayName(<span class="cs__string">&quot;Course&quot;</span>)&lt;/th&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;@Html.DisplayName(<span class="cs__string">&quot;City&quot;</span>)&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/section&gt;&nbsp;
&lt;/div&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
</h1>
<ul>
</ul>
<p><span>Please check the path on the browser when you are accessing your controller.</span></p>
<p><span><img id="147238" src="147238-webapi.png" alt="" width="1231" height="398"><br>
</span></p>
<h1>More Information</h1>
<p><em>For more information , you can contact me through my website :&nbsp;<a href="http://www.hjaiejchourouk.com/">hjaiejchourouk.com/</a></em></p>
