# CORS support in ASP.NET Web APIs - RC version
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET MVC 4
- ASP.NET Web API
## Topics
- HTTP
- Web API
- Cross-Domain
## Updated
- 07/01/2012
## Description

<div><em>To run the sample, set&nbsp;all projects in the solution as startup projects, then F5. You'll need to use a browser with CORS support and browse to the Mashup project root.</em></div>
<div>A few months back I had <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/20/implementing-cors-support-in-asp-net-web-apis.aspx">
posted</a> some <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/21/implementing-cors-support-in-asp-net-web-apis-take-2.aspx">
code</a> to enable support for CORS (Cross-Origin Resource Sharing) in the ASP.NET Web API. At that point, that product was in its Beta version, and with the Release Candidate (RC) released last month, some of the API changes made the code stop working (and
 in the per-action example, it even stopped building). With many comments asking for an updated version which builds, here they are.</div>
<div>The <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/20/implementing-cors-support-in-asp-net-web-apis.aspx">
first version</a> (a global message handler, which enabled CORS for all controllers / actions in the application), actually didn&rsquo;t need any update at all. Actually, the message handler didn&rsquo;t need any updates, but the actions in the values controller
 which take the string as a parameter need a <a href="http://msdn.microsoft.com/en-us/library/system.web.http.frombodyattribute(v=vs.108).aspx">
[FromBody]</a> decoration due to the model binding changes between the Beta and the RC version. In RC, parameters of simple types (such as string) by default come from the URI (either in the route or in the query string), and the application passed the parameter
 via the request body.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ValuesController&nbsp;:&nbsp;ApiController&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;allValues&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;{&nbsp;<span class="cs__string">&quot;value1&quot;</span>,&nbsp;<span class="cs__string">&quot;value2&quot;</span>&nbsp;};&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET&nbsp;/api/values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;allValues;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET&nbsp;/api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Get(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;&lt;&nbsp;allValues.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;allValues[id];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(<span class="cs__keyword">this</span>.Request.CreateResponse(HttpStatusCode.NotFound));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;POST&nbsp;/api/values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;HttpResponseMessage&nbsp;Post([FromBody]<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allValues.Add(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.Request.CreateResponse&lt;<span class="cs__keyword">int</span>&gt;(HttpStatusCode.Created,&nbsp;allValues.Count&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;PUT&nbsp;/api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Put(<span class="cs__keyword">int</span>&nbsp;id,&nbsp;[FromBody]&nbsp;<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;&lt;&nbsp;allValues.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allValues[id]&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(<span class="cs__keyword">this</span>.Request.CreateResponse(HttpStatusCode.NotFound));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;DELETE&nbsp;/api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;&lt;&nbsp;allValues.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allValues.RemoveAt(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(<span class="cs__keyword">this</span>.Request.CreateResponse(HttpStatusCode.NotFound));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:d2070fd6-a875-425c-b716-6a9fea3202b6" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>The <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/21/implementing-cors-support-in-asp-net-web-apis-take-2.aspx">
second version</a> &ndash; CORS support on a per-action basis &ndash; had some changes. That version was implemented using two components: one filter attribute, and one action selector (to define the action that would respond to preflight requests). The code
 for the filter was almost the same, with the exception that the property of the <a href="http://msdn.microsoft.com/en-us/library/system.web.http.filters.httpactionexecutedcontext(v=vs.108)">
HttpActionExecutedContext</a> in the action filter which stored the response changed from Result to
<a href="http://msdn.microsoft.com/en-us/library/system.web.http.filters.httpactionexecutedcontext.response(v=vs.108)">
Response</a>:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuted(HttpActionExecutedContext&nbsp;actionExecutedContext)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(actionExecutedContext.Request.Headers.Contains(Origin))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;originHeader&nbsp;=&nbsp;actionExecutedContext.Request.Headers.GetValues(Origin).FirstOrDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(originHeader))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin,&nbsp;originHeader);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:13489c3a-3cbc-420c-b9c5-76bc95ae4785" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>The code for the action selector itself was actually unchanged, but the nested type to implement the new action descriptor had quite a lot of changes, mostly related to the OM changes in the
<a href="http://msdn.microsoft.com/en-us/library/system.web.http.controllers.httpactiondescriptor(v=vs.108)">
HttpActionDescriptor</a> class (related to return types). Besides trivial changes (e.g., from ReadOnlyCollection&lt;T&gt; to Collection&lt;T&gt;), there were two larger changes:</div>
<ul>
<li>The Execute method is now asynchronous (and also named <a href="http://msdn.microsoft.com/en-us/library/hh995180(v=vs.108)">
ExecuteAsync</a>). Since we don&rsquo;t need to execute any asynchronous operation (we already know the operation result at that point), we&rsquo;re now using a
<a href="http://msdn.microsoft.com/en-us/library/dd449174.aspx">TaskCompletionSource&lt;TResult&gt;</a> as explained by Brad Wilson in his
<a href="http://bradwilson.typepad.com/blog/2012/04/tpl-and-servers-pt2.html">series about TPL and Servers</a>.
</li><li>The class also defines a new property, <a href="http://msdn.microsoft.com/en-us/library/system.web.http.controllers.httpactiondescriptor.actionbinding(v=vs.108)">
ActionBinding</a>, which defines the binding from the request to the parameters. Unlike the other operations in the class which we can simply delegate to the original descriptor, we can&rsquo;t do that for the preflight action, since it&rsquo;s possible that
 the actions take some additional parameter (which is the case in the values controller used in the example). In this case, we simply create a new instance of
<a href="http://msdn.microsoft.com/en-us/library/system.web.http.controllers.httpactionbinding(v=vs.108)">
HttpActionBinding</a> which doesn&rsquo;t take any parameters to return to the Web API runtime.
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:f88edd0c-b968-4053-a146-4760535982a1" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</li></ul>
&nbsp;
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;PreflightActionDescriptor&nbsp;:&nbsp;HttpActionDescriptor&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HttpActionDescriptor&nbsp;originalAction;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;accessControlRequestMethod;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;HttpActionBinding&nbsp;actionBinding;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;PreflightActionDescriptor(HttpActionDescriptor&nbsp;originalAction,&nbsp;<span class="cs__keyword">string</span>&nbsp;accessControlRequestMethod)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.originalAction&nbsp;=&nbsp;originalAction;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.accessControlRequestMethod&nbsp;=&nbsp;accessControlRequestMethod;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.actionBinding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpActionBinding(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpParameterBinding[<span class="cs__number">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ActionName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.originalAction.ActionName;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&lt;<span class="cs__keyword">object</span>&gt;&nbsp;ExecuteAsync(HttpControllerContext&nbsp;controllerContext,&nbsp;IDictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">object</span>&gt;&nbsp;arguments)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessage(HttpStatusCode.OK);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;No&nbsp;need&nbsp;to&nbsp;add&nbsp;the&nbsp;Origin;&nbsp;this&nbsp;will&nbsp;be&nbsp;added&nbsp;by&nbsp;the&nbsp;action&nbsp;filter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Add(AccessControlAllowMethods,&nbsp;<span class="cs__keyword">this</span>.accessControlRequestMethod);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;requestedHeaders&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Join(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;,&nbsp;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;controllerContext.Request.Headers.GetValues(AccessControlRequestHeaders));&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(requestedHeaders))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Add(AccessControlAllowHeaders,&nbsp;requestedHeaders);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tcs&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TaskCompletionSource&lt;<span class="cs__keyword">object</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tcs.SetResult(response);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;tcs.Task;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Collection&lt;HttpParameterDescriptor&gt;&nbsp;GetParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.originalAction.GetParameters();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Type&nbsp;ReturnType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">typeof</span>(HttpResponseMessage);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Collection&lt;FilterInfo&gt;&nbsp;GetFilterPipeline()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.originalAction.GetFilterPipeline();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Collection&lt;IFilter&gt;&nbsp;GetFilters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.originalAction.GetFilters();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Collection&lt;T&gt;&nbsp;GetCustomAttributes&lt;T&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.originalAction.GetCustomAttributes&lt;T&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;HttpActionBinding&nbsp;ActionBinding&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.actionBinding;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;<span class="cs__keyword">this</span>.actionBinding&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>And that&rsquo;s basically it. The code in the gallery will contain both projects (global CORS &#43; per-action CORS), along with a simple project which can be tested (in CORS-enabled browsers, such as Chrome, IE10&#43; and FF3.5&#43;) for both services.</div>
