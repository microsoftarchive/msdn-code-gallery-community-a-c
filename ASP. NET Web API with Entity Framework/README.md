# ASP. NET Web API with Entity Framework
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Entity Framework
- ASP.NET Web API
- knockout.js
## Topics
- ASP.NET Web API
## Updated
- 09/26/2012
## Description

<p>This sample contains the completed project for the tutorial <a href="http://www.asp.net/web-api/overview/creating-web-apis/using-web-api-with-entity-framework/using-web-api-with-entity-framework,-part-1">
Using Web API with Entity Framework</a>&nbsp;on the <a href="http://asp.net/web-api">
asp.net/web-api</a>&nbsp;site.</p>
<p>Excerpt:</p>
<p>This tutorial shows how to use ASP.NET Web API with ADO.NET Entity Framework, using code-first development.</p>
<p>Entity Framework is an object/relational mapping framework. It maps the domain objects in your code to entities in a relational database. For the most part, you do not have to worry about the database layer, because Entity Framework takes care of it for
 you. Your code manipulates the objects, and changes are persisted to a database.</p>
<h2>About the Tutorial</h2>
<p>In this tutorial, you will create a simple store application. There are two main parts to the application. Normal users can view products and create orders:</p>
<p><img src="http://aspnet13.orcsweb.com/media/3663418/webapi_ef01.png" alt=""></p>
<p>Administrators can create, delete, or edit products:</p>
<p><img src="http://aspnet13.orcsweb.com/media/3663424/webapi_ef02.png" alt=""></p>
<h2>Skills You&rsquo;ll Learn</h2>
<p>Here&rsquo;s what you&rsquo;ll learn:</p>
<ul>
<li>How to use Entity Framework with ASP.NET Web API. </li><li>How to use knockout.js to create a dynamic client UI. </li><li>How to use forms authentication with Web API to authenticate users. </li></ul>
<p>Although this tutorial is self-contained, you might want to read the following tutorials first:</p>
<ul>
<li><a>Your First ASP.NET Web API</a> </li><li><a href="http://www.asp.net/web-api/overview/creating-web-apis/creating-a-web-api-that-supports-crud-operations">Creating a Web API that Supports CRUD Operations
</a></li></ul>
<p>Some knowledge of <a href="http://www.asp.net/mvc/tutorials/mvc-4">ASP.NET MVC</a> is also helpful.</p>
<h2>Overview</h2>
<p>At a high level, here is the architecture of the application:</p>
<ul>
<li>ASP.NET MVC generates the HTML pages for the client. </li><li>ASP.NET Web API exposes CRUD operations on the data (products and orders). </li><li>Entity Framework translates the C# models used by Web API into database entities.
</li></ul>
<p><img src="http://aspnet13.orcsweb.com/media/3663430/webapi_ef03.png" alt=""></p>
<p>The following diagram shows how the domain objects are represented at various layers of the application: The database layer, the object model, and finally the wire format, which is used to transmit data to the client via HTTP.</p>
<p><img src="http://aspnet13.orcsweb.com/media/3663436/webapi_ef04.png" alt=""></p>
