# ASP.NET Web API - with NUnit test project
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
- HttpClient
- NUnit
## Topics
- Unit Testing
- ASP.NET Web API
## Updated
- 04/08/2013
## Description

<h1>Introduction</h1>
<p>ASP.NET Web API is a light weight framework for building and consuming Http services that can reach variety of clients that is browsers, phones and tables. Web API is flexible such a way service can be self hosted or deployed in another applicatio as requried.</p>
<p>The objective of this simple is to provide insight into testing Web API application using NUnit. Note that Controller testing i.e., DAL (Data access layer) is separated from actual Http service testing.</p>
<p>&nbsp;</p>
<h1>Requirements</h1>
<ul>
<li>Visual Studio 2010 SP1, Visual Web Developer 2010 SP1 or Visual Studio 2012 </li><li><a href="http://www.asp.net/mvc/mvc4">ASP.NET MVC 4</a>&nbsp;
<ul>
<li>Already included with Visual Studio 2012 </li></ul>
</li><li><a href="http://www.microsoft.com/en-us/download/details.aspx?id=1038">IIS 7.5 Express</a>
</li><li><a href="http://automapper.org/" target="_blank">Automapper </a>for object to object mapping
</li><li><a href="http://unity.codeplex.com/" target="_blank">Microsoft's Unity </a>for implementing Inversion of controller (DI)
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The solution contains two projects.</p>
<p><strong>ContactManager </strong>web application is a ASP.NET Web API application, which retrieves entity and returns
<strong>DTO </strong>to the client. In Web API controller class repository(Interface) from data layer&nbsp; is injected, Unity container is used for DI. After retrieving data from data layer, it is mapped to an instance of DTO (which is in model folder) and
 returned to the client. <strong>Automapper </strong>is used for Object to object mapping.</p>
<p>Note that <strong>Data Access Layer </strong>(DAL) is implemented in Model folder of the ASP.NET Web API project for demo sake. It is a standard practice to have DAL is separate class library project where N-Tier practice is followed.</p>
<p><strong>ContactsNUitTests </strong>project contains test cases for ContactsController using NUnit and service HTTP response specific cases.</p>
<p>When you run the application and navigate to uri <strong>http://&lt;portnumber&gt;/api/contacts/get
</strong>a list of contact is displayed in Json format. Uri <strong><a href="http://%3cportnumber%3e/api/contacts/get/1">http://&lt;portnumber&gt;/api/contacts/get/1</a>
</strong>displays contact with id 1.</p>
<p>When the unit tests are run from the Visual Studio &gt; Tools menu or as a separate instance all tests should pass based on your service port number update in Web.config.</p>
<p>&nbsp;</p>
<p><img id="79562" src="79562-contact_json.jpg" alt="" width="343" height="281"></p>
<p>&nbsp;</p>
<p>When the NUnit is added through Visual Studio Add In manager, choosing the Tools menu in Visual studio and running the tests will show the out put as shown below.</p>
<p><img id="75577" src="75577-nunitconsole.gif" alt="" width="1548" height="320"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;HttpClient&nbsp;client;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;HttpResponseMessage&nbsp;response;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[SetUp]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetUP()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.BaseAddress&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(ConfigurationManager.AppSettings[<span class="cs__string">&quot;serviceBaseUri&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;client.GetAsync(<span class="cs__string">&quot;contacts/get&quot;</span>).Result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>ContactManager\ContactManager\Controllers\ContactsController.cs </li><li>ContactManager\ContactsNUnitTests\Controllers\ContactsControllerTests.cs </li><li>ContactManager\ContactsNUnitTests\ServiceHttpResponse\HttpResponseTests.cs </li></ul>
<h1>More Information</h1>
<p><span style="font-size:small"><em>Microsoft's Unity framework is utilised for DI (IoC)</em></span></p>
