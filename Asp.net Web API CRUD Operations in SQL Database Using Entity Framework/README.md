# Asp.net Web API CRUD Operations in SQL Database Using Entity Framework
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- SQL Server
- ADO.NET Entity Framework
- ASP.NET
- jQuery
- Web Services
- Javascript
- HTML5
## Topics
- AJAX
- ASP.NET and ADO.NET Entity Framework
- ASP.NET MVC
- jQuery
- HTML5
- ASP.NET Web API
## Updated
- 03/20/2013
## Description

<h1>Introduction</h1>
<p><span>CRUD stands for &quot;Create, Read, Update, and Delete,&quot; which are the four basic database operations. Many HTTP services also model CRUD operations through REST or REST-like API.</span></p>
<p><span>Description</span></p>
<p><span>The student API will expose following methods.</span></p>
<table>
<tbody>
<tr>
<th>Action</th>
<th>HTTP method</th>
<th>Relative URI</th>
</tr>
<tr>
<td><span style="font-size:small">Get a list of all students</span></td>
<td><span style="font-size:small">GET</span></td>
<td><span style="font-size:small">/api/student</span></td>
</tr>
<tr>
<td><span style="font-size:small">Get a student by ID</span></td>
<td><span style="font-size:small">GET</span></td>
<td><span style="font-size:small">/api/student/<em>id</em></span></td>
</tr>
<tr>
<td><span style="font-size:small">Get a student by gender</span></td>
<td><span style="font-size:small">GET</span></td>
<td><span style="font-size:small">/api/student?gender=<em>Male</em></span></td>
</tr>
<tr>
<td><span style="font-size:small">Create a new student</span></td>
<td><span style="font-size:small">POST</span></td>
<td><span style="font-size:small">/api/student</span></td>
</tr>
<tr>
<td><span style="font-size:small">Update a student</span></td>
<td><span style="font-size:small">PUT</span></td>
<td><span style="font-size:small">/api/student/<em>id</em></span></td>
</tr>
<tr>
<td><span style="font-size:small">Delete a student</span></td>
<td><span style="font-size:small">DELETE</span></td>
<td><span style="font-size:small">/api/student/<em>id</em></span></td>
</tr>
</tbody>
</table>
<h1>Methods</h1>
<p><span>The four main HTTP methods (GET, PUT, POST, and DELTETE) can be mapped to CRUD operations as follows:</span></p>
<ul>
<li>
<p><span>GET retrieves the representation of the resource at a specified URI. GET should have no side effects on the server.</span></p>
</li><li>
<p><span>PUT updates a resource at a specified URI. PUT can also be used to create a new resource at a specified URI, if the server allows clients to specify new URIs. For this tutorial, the API will not support creation through PUT.</span></p>
</li><li>
<p><span>POST creates a new resource. The server assigns the URI for the new object and returns this URI as part of the response message.</span></p>
</li><li>
<p><span>DELETE deletes a resource at a specified URI.</span></p>
</li></ul>
<p><span>Note: The PUT method replaces the entire product entity. That is, the client is expected to send a complete representation of the updated product. If you want to support partial updates, the PATCH method is preferred. This tutorial does not implement
 PATCH.</span></p>
<h1 class="jq-clearfix">jQuery:</h1>
<p class="desc"><span><strong>Description:&nbsp;</strong>Load data from the server using a HTTP GET request.</span></p>
<p class="desc"><span>jQuery.get( url [, data] [, success(data, textStatus, jqXHR)] [, dataType]&nbsp;</span></p>
<p class="desc"><span><strong>url:&nbsp;</strong>A string containing the URL to which the request is sent.</span></p>
<p class="desc"><span><strong>data:&nbsp;</strong>A map or string that is sent to the server with the request.</span></p>
<p class="desc"><span><strong>success(data, textStatus, jqXHR):&nbsp;</strong>A callback function that is executed if the request succeeds.</span></p>
<p class="desc"><span><strong>dataType:&nbsp;</strong>The type of data expected from the server. Default: Intelligent Guess (xml, json, script, or html).</span></p>
<h3 class="desc"><span>Code Get Request Used in the Project:</span></h3>
<p class="desc">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<pre class="js">&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://localhost:60792/api/student'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">'GET'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;<span class="js__string">'json'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteResponses(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(x,&nbsp;y,&nbsp;z)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(x&nbsp;&#43;&nbsp;<span class="js__string">'\n'</span>&nbsp;&#43;&nbsp;y&nbsp;&#43;&nbsp;<span class="js__string">'\n'</span>&nbsp;&#43;&nbsp;z);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3 class="desc"><span>&nbsp; Code Post Request used in the project:</span></h3>
<p class="desc">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
<pre class="js">$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://localhost:60792/api/student/'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">'POST'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;JSON.stringify(student),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json;charset=utf-8&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">'Student&nbsp;added&nbsp;Successfully'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">'Student&nbsp;not&nbsp;Added'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
