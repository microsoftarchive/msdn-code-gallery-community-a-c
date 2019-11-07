# Consume Web API2 using MVC
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC 4
- RestSharp
## Topics
- ASP.NET MVC 4
## Updated
- 10/12/2016
## Description

<h1>Introduction</h1>
<p><em>In this code sample I try to demostrate&nbsp;<span>how to consume ASP.NET WEB API hosted on another server (as a REST services only) using ASP.NET MVC4 (as a client) with RESTSHARP.</span></em></p>
<h1><span>Building the Sample</span></h1>
<p><em>To&nbsp;</em>play with the source code, one should have:</p>
<ul>
<li>Visual Studio 2013 express or later </li><li>ASP.NET MVC4 or later </li><li>ASP.NET WEB API2 or later </li><li>Basic knowledge of RestFul Services </li><li>Basic knowledge of ASP.NET WEB API </li><li>Basic knowledge of ASP.NET MVC4 or later </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span>In most scenarios, we develop an application of ASP.NET MVC4 using ASP.NET WEB API. But as a RESTFul service like ASP.NET WEB API, we meant to use by different clients. In this article, we will see how to consume simple ASP.NET WEB API using ASP.NET
 MVC4 (as a client) with RestSharp (simple Rest and HTTP client for .NET).</span></em></p>
<p>&nbsp;</p>
<p><em><span><span>As we are going to use RestSharp to call our ASP.NET WEB API URIs, so, first of all, let's discuss&nbsp;</span><code>&quot;RestSharp&quot;</code><span>. This is nothing but a Simple REST and HTTP API Client for .NET. It provides us with a simple way
 by which we can just initialize a&nbsp;</span><code>RestClient</code><span>, pass a&nbsp;</span><code>Request</code><span>, define a&nbsp;</span><code>Method (GET, POST, PUT, DELETE)</code><span>&nbsp;and get a</span><code>response</code><span>.</span></span></em></p>
<p>&nbsp;</p>
<p><em><span><span><img id="146489" src="146489-0%5b1%5d.png" alt="" width="1352" height="667"><br>
</span></span></em></p>
<p>&nbsp;</p>
<ul>
</ul>
<h1>Compile and run project</h1>
<p>Steps to build this project are very simple:</p>
<ol>
<li>Download source code </li><li>Extract the folder </li><li>Open Solution using preferred (check pre-requisite) Visual Studio version </li><li>Now, just build (ctrl&#43;B) the solution </li><li>You may get few build errors due to missing NugetPackage
<ul>
<li>Check output windows to know what packages are missing </li><li>Restore missing Nuget packages or you can re-install the packages </li><li>Rebuild solution again </li></ul>
</li><li>Now, you would be able to run the project. </li></ol>
<h1>More Information</h1>
<p><em>This sample code is showing how to consume Web API2, you must be required an actual Web API2 project, to download the same refer this code sample:&nbsp;</em><span style="font-size:small"><a href="https://code.msdn.microsoft.com/CRUD-operation-ASPNet-Web-62760966" target="_blank">CRUD
 operation ASP.Net Web API2</a></span></p>
