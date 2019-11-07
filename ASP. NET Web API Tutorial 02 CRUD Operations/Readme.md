# ASP. NET Web API Tutorial 02: CRUD Operations
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
## Topics
- Web API
## Updated
- 09/14/2012
## Description

<p><em><a href="http://www.asp.net/web-api/overview/creating-web-apis/creating-a-web-api-that-supports-crud-operations">http://www.asp.net/web-api/overview/creating-web-apis/creating-a-web-api-that-supports-crud-operations</a></em></p>
<p>[Excerpt]</p>
<p>This tutorial shows how to support CRUD operations in an HTTP service using ASP.NET Web API.</p>
<p>CRUD stands for &quot;Create, Read, Update, and Delete,&quot; which are the four basic database operations. Many HTTP services also model CRUD operations through REST or REST-like APIs.</p>
<p>In this tutorial, you will build a very simple web API to manage a list of products. Each product will contain a name, price, and category (such as &quot;toys&quot; or &quot;hardware&quot;), plus a product ID.</p>
<p>The products web API will expose following methods.</p>
<table>
<tbody>
<tr>
<th>Action</th>
<th>HTTP method</th>
<th>Relative URI</th>
</tr>
<tr>
<td>Get a list of all products</td>
<td>GET</td>
<td>/api/products</td>
</tr>
<tr>
<td>Get a product by ID</td>
<td>GET</td>
<td>/api/products/<em>id</em></td>
</tr>
<tr>
<td>Get a product by category</td>
<td>GET</td>
<td>/api/products?category=<em>category</em></td>
</tr>
<tr>
<td>Create a new product</td>
<td>POST</td>
<td>/api/products</td>
</tr>
<tr>
<td>Update a product</td>
<td>PUT</td>
<td>/api/products/<em>id</em></td>
</tr>
<tr>
<td>Delete a product</td>
<td>DELETE</td>
<td>/api/products/<em>id</em></td>
</tr>
</tbody>
</table>
<p>Notice that some of the URIs include the product ID in path. For example, to get the product whose ID is 28, the client sends a GET request for
<a href="http://hostname/api/products/28">http://<em>hostname</em>/api/products/28</a>.</p>
<h3>Resources</h3>
<p>The products API defines URIs for two resource types:</p>
<table>
<tbody>
<tr>
<th>Resource</th>
<th>URI</th>
</tr>
<tr>
<td>The list of all the products.</td>
<td>/api/products</td>
</tr>
<tr>
<td>An individual product.</td>
<td>/api/products/<em>id</em></td>
</tr>
</tbody>
</table>
<h3>Methods</h3>
<p>The four main HTTP methods (GET, PUT, POST, and DELTETE) can be mapped to CRUD operations as follows:</p>
<ul>
<li>GET retrieves the representation of the resource at a specified URI. GET should have no side effects on the server.
</li><li>PUT updates a resource at a specified URI. PUT can also be used to create a new resource at a specified URI, if the server allows clients to specify new URIs. For this tutorial, the API will not support creation through PUT.
</li><li>POST creates a new resource. The server assigns the URI for the new object and returns this URI as part of the response message.
</li><li>DELETE deletes a resource at a specified URI. </li></ul>
<p>Note: The PUT method replaces the entire product entity. That is, the client is expected to send a complete representation of the updated product. If you want to support partial updates, the PATCH method is preferred. This tutorial does not implement PATCH.</p>
<h2>Create a New Web API Project</h2>
<p>Start by running Visual Studio 2010 and select <strong>New Project</strong> from the
<strong>Start</strong> page. Or, from the <strong>File</strong> menu, select <strong>
New</strong> and then <strong>Project</strong>.</p>
<p>In the <strong>Templates</strong> pane, select <strong>Installed Templates</strong> and expand the
<strong>Visual C#</strong> node. Under <strong>Visual C#</strong>, select <strong>
Web</strong>. In the list of project templates, select <strong>ASP.NET MVC 4 Web Application</strong>. Name the project &quot;ProductStore&quot; and click
<strong>OK</strong>.</p>
<p><img src="-webapi_crud01.png" alt=""></p>
<p>In the <strong>New ASP.NET MVC 4 Project</strong> dialog, select <strong>Web API</strong> and click
<strong>OK</strong>.</p>
<p><img src="-webapi_crud02.png" alt=""></p>
<h2>Adding a Model</h2>
<p>A <em>model</em> is an object that represents the data in your application. In ASP.NET Web API, you can use strongly typed CLR objects as models, and they will automatically be serialized to XML or JSON for the client.</p>
<p>For the ProductStore API, our data consists of products, so we'll create a new class named Product.</p>
<p>If Solution Explorer is not already visible, click the <strong>View</strong> menu and select
<strong>Solution Explorer</strong>. In Solution Explorer, right-click the <strong>
Models</strong> folder. From the context meny, select <strong>Add</strong>, then select
<strong>Class</strong>. Name the class &quot;Product&quot;.</p>
<p><img src="-webapi_crud03.png" alt=""></p>
