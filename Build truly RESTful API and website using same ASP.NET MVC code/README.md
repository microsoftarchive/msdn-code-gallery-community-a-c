# Build truly RESTful API and website using same ASP.NET MVC code
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC
## Topics
- ASP.NET
- ASP.NET MVC
## Updated
- 07/29/2011
## Description

<h2>Introduction</h2>
<p>A truly RESTful API means you have unique URLs to uniquely represent entities and collections, and there is no verb/action on the URL. You cannot have URL like&nbsp;<code>/Customers/Create&nbsp;</code>or&nbsp;<code>/Customers/John/Update</code>,<code>/Customers/John/Delete</code>&nbsp;where
 the action is part of the URL that represents the entity. An URL can only represent the state of an entity, like&nbsp;<code>/Customers/John</code>&nbsp;represents the state of John, a customer, and allow GET, POST, PUT, DELETE on that very URL to perform CRUD
 operations. Same goes for a collection where&nbsp;<code>/Customers</code>returns list of customers and a POST to that URL adds new customer(s). Usually we create separate controllers to deal with API part of the website but I will show you how you can create
 both RESTful website and API using the same controller code working over the exact same URL that a browser can use to browse through the website and a client application can perform CRUD operations on the entities.</p>
<p>I have tried Scott Gu&rsquo;s examples on creating RESTful routes, this&nbsp;<a href="http://msdn.microsoft.com/en-us/magazine/dd943053.aspx">MSDN Magazine article</a>, Phil Haack&rsquo;s&nbsp;<a href="http://haacked.com/archive/2009/08/17/rest-for-mvc.aspx">REST
 SDK for ASP.NET MVC</a>, and various other examples. But they have all made the same classic mistake - the action is part of the URL. You have to have URLs like&nbsp;<code>http://localhost:8082/MovieApp/Home/Edit/5?format=Xml</code>&nbsp;to edit a certain
 entity and define the format eg xml, that you need to support. They aren&rsquo;t truly RESTful since the URL does not uniquely represent the state of an entity. The action is part of the URL. When you put the action on the URL, then it is straightforward to
 do it using ASP.NET MVC. Only when you take the action out of the URL and you have to support CRUD over the same URL, using three different formats &ndash; html, xml and json, it becomes tricky and you need some custom filters to do the job. It&rsquo;s not
 very tricky though, you just need to keep in mind your controller actions are serving multiple formats and design your website in a certain way that makes it API friendly. You make the website URLs look like API URL.</p>
<p>The example code has a library of&nbsp;<code>ActionFilterAttribute</code>&nbsp;and&nbsp;<code>ValurProvider</code>&nbsp;that make it possible to serve and accept html, json and xml over the same URL. A regular browser gets html output, an AJAX call expecting
 json gets json response and an XmlHttp call gets xml response.</p>
<p>You might ask why not use WCF REST SDK? The idea is to reuse the same logic to retrieve models and emit html, json, xml all from the same code so that we do not have to duplicate logic in the website and then in the API. If we use WCF REST SDK, you have
 to create a WCF API layer that replicates the model handling logic in the controllers.</p>
<p>The example shown here offers the following RESTful URLs:</p>
<ul>
<li>/Customers &ndash; returns a list of customers. A POST to this URL adds a new customer.
</li><li>/Customers/C0001 &ndash; returns details of the customer having id C001. Update and Delete supported on the same URL.
</li><li>/Customers/C0001/Orders &ndash; returns the orders of the specified customer. Post to this adds new order to the customer.
</li><li>/Customers/C0001/Orders/O0001 &ndash; returns a specific order and allows update and delete on the same URL.
</li></ul>
<p>All these URLs support GET, POST, PUT, DELETE. Users can browse to these URLs and get html page rendered. Client apps can make AJAX calls to these URLs to perform CRUD on these. Thus making a truly RESTful API and website.</p>
<p><img src="25703-customers.png" alt="" width="500" height="624"></p>
<p>They also support verbs over POST in case you don&rsquo;t have PUT, DELETE allowed on your webserver or through firewalls. They are usually disabled by default in most webservers and firewalls due to security common practices. In that case you can use POST
 and pass the verb as query string. For ex,&nbsp;<code>/Customers/C0001?verb=Delete</code>&nbsp;to delete the customer. This does not break the RESTfulness since the URL&nbsp;<code>/Customers/C0001</code>&nbsp;is still uniquely identifying the entity. You are
 passing additional context on the URL. Query strings are also used to do filtering, sorting operations on REST URLs. For ex,&nbsp;<code>/Customers?filter=John&amp;sort=Location&amp;limit=100</code>&nbsp;tells the server to return a filtered, sorted, and paged
 collection of customers.</p>
<h2>Registering routes for truly RESTful URLs</h2>
<p>For each level of entity in the hierarchical entity model, you need to register a route that serves both the collection of an entity and the individual entity. For ex, first level if Customer and then second level is Orders. So, you need to register the
 routes in this way:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterRoutes(RouteCollection&nbsp;routes)&nbsp;
{&nbsp;
&nbsp;&nbsp;routes.IgnoreRoute(<span class="cs__string">&quot;{resource}.axd/{*pathInfo}&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SingleCustomer&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Customers/{customerId}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;controller&nbsp;=&nbsp;<span class="cs__string">&quot;Customers&quot;</span>,&nbsp;action&nbsp;=&nbsp;<span class="cs__string">&quot;SingleCustomer&quot;</span>&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;CustomerOrders&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Customers/{customerId}/Orders/{orderId}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;controller&nbsp;=&nbsp;<span class="cs__string">&quot;Customers&quot;</span>,&nbsp;action&nbsp;=&nbsp;<span class="cs__string">&quot;SingleCustomerOrders&quot;</span>,&nbsp;orderId&nbsp;=&nbsp;UrlParameter.Optional&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Default&quot;</span>,&nbsp;<span class="cs__com">//&nbsp;Route&nbsp;name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;{controller}/{action}/{id}&quot;</span>,&nbsp;<span class="cs__com">//&nbsp;URL&nbsp;with&nbsp;parameters</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;controller&nbsp;=&nbsp;<span class="cs__string">&quot;Home&quot;</span>,&nbsp;action&nbsp;=&nbsp;<span class="cs__string">&quot;Index&quot;</span>,&nbsp;id&nbsp;=&nbsp;UrlParameter.Optional&nbsp;}&nbsp;<span class="cs__com">//&nbsp;Parameter&nbsp;defaults</span>&nbsp;
&nbsp;&nbsp;);&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>The default map takes care of hits to&nbsp;<code>/Customers</code>. It calls&nbsp;<code>Index()</code>&nbsp;action on&nbsp;<code>CustomersController</code>. Index action renders the collection of customers. Hits to individual customers like&nbsp;<code>/Customers/C0001</code>&nbsp;is
 handled by the<code>SingleCustomer</code>&nbsp;route. Hits to a customer&rsquo;s orders&nbsp;<code>/Customers/C001/Orders</code>&nbsp;and to individual orders eg<code>/Customers/C001/Orders/O0001</code>&nbsp;are both handled by the second route&nbsp;<code>CustomerOrders</code>.</p>
<h2>Rendering JSON and XML output from actions</h2>
<p>In order to emit JSON and XML from actions, you need to use some custom&nbsp;<code>ActionFilter</code>. ASP.NET MVC comes with&nbsp;<code>JsonResult</code>, but it uses the deprecated&nbsp;<code>JavascriptSerializer</code>. So, I have made one using .NET
 3.5&rsquo;s<code>DataContractJsonSerializer</code>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;JsonResult2&nbsp;:&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult2()&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult2(<span class="cs__keyword">object</span>&nbsp;data)&nbsp;{&nbsp;<span class="cs__keyword">this</span>.Data&nbsp;=&nbsp;data;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ContentType&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Encoding&nbsp;ContentEncoding&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Data&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ExecuteResult(ControllerContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;context&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseBase&nbsp;response&nbsp;=&nbsp;context.HttpContext.Response;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(<span class="cs__keyword">this</span>.ContentType))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.ContentType&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ContentType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/json&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.ContentEncoding&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.ContentEncoding&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ContentEncoding;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContractJsonSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractJsonSerializer(<span class="cs__keyword">this</span>.Data.GetType());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.WriteObject(response.OutputStream,&nbsp;<span class="cs__keyword">this</span>.Data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>In the same way I have created&nbsp;<code>XmlResult</code>&nbsp;that I found from from&nbsp;<a href="http://www.hackersbasement.com/csharp/post/2009/06/07/XmlResult-for-ASPNet-MVC.aspx">here</a>&nbsp;and have made some modifications to support Generic types:</p>
<pre id="pre2" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Source:&nbsp;http://www.hackersbasement.com/csharp/post/2009/06/07/XmlResult-for-ASPNet-MVC.aspx</span>&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;XmlResult&nbsp;:&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;XmlResult()&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;XmlResult(<span class="cs__keyword">object</span>&nbsp;data)&nbsp;{&nbsp;<span class="cs__keyword">this</span>.Data&nbsp;=&nbsp;data;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ContentType&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Encoding&nbsp;ContentEncoding&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Data&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ExecuteResult(ControllerContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;context&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseBase&nbsp;response&nbsp;=&nbsp;context.HttpContext.Response;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(<span class="cs__keyword">this</span>.ContentType))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.ContentType&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ContentType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;text/xml&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.ContentEncoding&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.ContentEncoding&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ContentEncoding;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.Data&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.Data&nbsp;<span class="cs__keyword">is</span>&nbsp;XmlNode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Write(((XmlNode)<span class="cs__keyword">this</span>.Data).OuterXml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.Data&nbsp;<span class="cs__keyword">is</span>&nbsp;XNode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Write(((XNode)<span class="cs__keyword">this</span>.Data).ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;dataType&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Data.GetType();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;OMAR:&nbsp;For&nbsp;generic&nbsp;types,&nbsp;use&nbsp;DataContractSerializer&nbsp;because&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;XMLSerializer&nbsp;cannot&nbsp;serialize&nbsp;generic&nbsp;interface&nbsp;lists&nbsp;or&nbsp;types.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dataType.IsGenericType&nbsp;||&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType.GetCustomAttributes(<span class="cs__keyword">typeof</span>(DataContractAttribute),&nbsp;<span class="cs__keyword">true</span>).FirstOrDefault()&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;dSer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractSerializer(dataType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dSer.WriteObject(response.OutputStream,&nbsp;<span class="cs__keyword">this</span>.Data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xSer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlSerializer(dataType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xSer.Serialize(response.OutputStream,&nbsp;<span class="cs__keyword">this</span>.Data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<br></span></pre>
<pre id="pre2" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal">Now that we have the&nbsp;<code>JsonResult2</code>&nbsp;and&nbsp;<code>XmlResult</code>, we need to create the&nbsp;<code>ActionFilter</code>&nbsp;attributes that will intercept the response and use the right Result class to render the result.</span></pre>
<p>First we have the&nbsp;<code>EnableJsonAttribute</code>&nbsp;that emits JSON:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EnableJsonAttribute&nbsp;:&nbsp;ActionFilterAttribute&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;_jsonTypes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;application/json&quot;</span>,&nbsp;<span class="cs__string">&quot;text/json&quot;</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuted(ActionExecutedContext&nbsp;filterContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">typeof</span>(RedirectToRouteResult).IsInstanceOfType(filterContext.Result))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;acceptTypes&nbsp;=&nbsp;filterContext.HttpContext.Request.AcceptTypes&nbsp;??&nbsp;<span class="cs__keyword">new</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;text/html&quot;</span>&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;filterContext.Controller.ViewData.Model;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;contentEncoding&nbsp;=&nbsp;filterContext.HttpContext.Request.ContentEncoding&nbsp;??&nbsp;Encoding.UTF8;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_jsonTypes.Any(type&nbsp;=&gt;&nbsp;acceptTypes.Contains(type)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.Result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JsonResult2()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data&nbsp;=&nbsp;model,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentEncoding&nbsp;=&nbsp;contentEncoding,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;filterContext.HttpContext.Request.ContentType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Then we have the&nbsp;<code>EnableXmlAttribute</code>&nbsp;that emits XML:</p>
<div class="pre-action-link" id="premain4">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EnableXmlAttribute&nbsp;:&nbsp;ActionFilterAttribute&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;_xmlTypes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;application/xml&quot;</span>,&nbsp;<span class="cs__string">&quot;text/xml&quot;</span>&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuted(ActionExecutedContext&nbsp;filterContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">typeof</span>(RedirectToRouteResult).IsInstanceOfType(filterContext.Result))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;acceptTypes&nbsp;=&nbsp;filterContext.HttpContext.Request.AcceptTypes&nbsp;??&nbsp;<span class="cs__keyword">new</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;text/html&quot;</span>&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;filterContext.Controller.ViewData.Model;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;contentEncoding&nbsp;=&nbsp;filterContext.HttpContext.Request.ContentEncoding&nbsp;??&nbsp;Encoding.UTF8;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_xmlTypes.Any(type&nbsp;=&gt;&nbsp;acceptTypes.Contains(type)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.Result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlResult()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data&nbsp;=&nbsp;model,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentEncoding&nbsp;=&nbsp;contentEncoding,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;filterContext.HttpContext.Request.ContentType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</div>
<pre id="pre4" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal">Both of these filters have same logic. They look at the requested content type. If they find the right content type, then do their job.</span></pre>
<p>All you need to do is put these attributes on the Actions and they do their magic:</p>
<pre id="pre5" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
<div class="preview">
<pre class="csharp">[EnableJson,&nbsp;EnableXml]&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index(<span class="cs__keyword">string</span>&nbsp;verb)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(GetModel().Customers);&nbsp;
}</pre>
</div>
</div>
</div>
<br></span></pre>
<p>These filter work for GET, POST, PUT, DELETE and for single entities and collections.</p>
<h2>Accepting JSON and XML serialized objects as request</h2>
<p>ASP.NET MVC 2 out of the box does not support JSON or XML serialized objects in request. You need to use the<a href="http://haacked.com/archive/2010/04/15/sending-json-to-an-asp-net-mvc-action-method-argument.aspx">ASP.NET MVC 2 Futures library</a>&nbsp;to
 allow JSON serialized objects to be sent as request. Futures has a<code>JsonValueProvider</code>&nbsp;that can accept JSON post and convert it to object. But there&rsquo;s no&nbsp;<code>ValueProvider</code>&nbsp;for XML in the futures library. There&rsquo;s
 one available&nbsp;<a href="http://www.nogginbox.co.uk/blog/xml-to-asp.net-mvc-action-method">here</a>&nbsp;that I have used.</p>
<p>In order to enable JSON and XML in request</p>
<div class="pre-action-link" id="premain6">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_Start()&nbsp;
{&nbsp;
&nbsp;&nbsp;AreaRegistration.RegisterAllAreas();&nbsp;
&nbsp;
&nbsp;&nbsp;RegisterRoutes(RouteTable.Routes);&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;Source:&nbsp;http://haacked.com/archive/2010/04/15/sending-json-to-an-asp-net-mvc-action-method-argument.aspx</span>&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;must&nbsp;be&nbsp;added&nbsp;to&nbsp;accept&nbsp;JSON&nbsp;as&nbsp;request</span>&nbsp;
&nbsp;&nbsp;ValueProviderFactories.Factories.Add(<span class="cs__keyword">new</span>&nbsp;JsonValueProviderFactory());&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;must&nbsp;be&nbsp;added&nbsp;to&nbsp;accept&nbsp;XML&nbsp;as&nbsp;request</span>&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;Source:&nbsp;http://www.nogginbox.co.uk/blog/xml-to-asp.net-mvc-action-method</span>&nbsp;
&nbsp;&nbsp;ValueProviderFactories.Factories.Add(<span class="cs__keyword">new</span>&nbsp;XmlValueProviderFactory());&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
</div>
<pre id="pre6" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal">When both of these Value Providers are used, ASP.NET MVC can accept JSON and XML serialized objects as request and automatically deserialize them. Most importantly,&nbsp;<code>ModelState.IsValid</code>&nbsp;works. If you just use an<code>ActionFilter</code>&nbsp;to intercept request and do the deserialization there, which is what most have tried, it does not validate the model. The model validation happens before the&nbsp;<code>ActionFilter</code>&nbsp;is hit. The only way so far to make model validation work is to use the value providers.</span></pre>
<pre id="pre6" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal"><br></span></pre>
<pre id="pre6" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal">You can find a detail walkthrough of this project here:</span></pre>
<pre id="pre6" class="brush: x_x_csharp" lang="cs"><span style="white-space:normal"><a href="http://omaralzabir.com/build-truly-restful-api-and-website-using-same-asp-net-mvc-code/">http://omaralzabir.com/build-truly-restful-api-and-website-using-same-asp-net-mvc-code/</a><br></span></pre>
