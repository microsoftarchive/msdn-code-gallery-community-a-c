# Converting between JsonObject and forms-urlencoded data
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC 4
- ASP.NET Web API
## Topics
- jQuery
- Web API
## Updated
- 03/04/2012
## Description

<div><em>This sample was introduced in the blog post from <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/03/05/writing-formurlencoded-data-with-asp-net-web-apis.aspx">
http://blogs.msdn.com/b/carlosfigueira/archive/2012/03/05/writing-formurlencoded-data-with-asp-net-web-apis.aspx</a>.</em></div>
<div>The <a href="http://msdn.microsoft.com/en-us/library/system.net.http.formatting.formurlencodedmediatypeformatter(v=vs.108).aspx">
FormUrlEncodedMediaTypeFormatter</a> class shipped with the ASP.NET Web APIs beta is one of the default formatters in the Web APIs and can be used to support incoming data from the
<a href="http://www.w3.org/TR/html401/interact/forms.html#h-17.13.4.1">application/x-www-form-urlencoded</a> media type. This is the default format used for HTML form submission, and it has always been supported in ASP.NET MVC (but not in WCF, which was a constant
 feature request). This is also the default format used by <a href="http://jquery.com/">
jQuery</a> when submitting objects, which makes supporting this format even more important, given the almost ubiquity of that library.</div>
<div>So ASP.NET Web APIs continues with the tradition of ASP.NET MVC and provides a formatter which supports consuming forms data natively. It also supports the complex objects format which is used by jQuery, in which the objects are &ldquo;flattened&rdquo;
 and all values are sent as key-value pairs as forms data. For example, this JavaScript object</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">'John'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;age:&nbsp;<span class="js__num">33</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;luckyNumbers:&nbsp;[<span class="js__num">3</span>,&nbsp;<span class="js__num">7</span>],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;children:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'Jack'</span>,&nbsp;age:&nbsp;<span class="js__num">6</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">'Jane'</span>,&nbsp;age:&nbsp;<span class="js__num">4</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:2cc04b91-3913-4b7c-ae8b-04b9821e9a87" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<div>when sent as the body of a POST request (or other requests with a body) is encoded as follows (line breaks added for clarity)</div>
<blockquote>
<div><span style="font-family:Courier New">name=John&amp;age=33&amp;luckyNumbers[]=3&amp;luckyNumbers[]=7&amp;
<br>
&nbsp;&nbsp;&nbsp; children[0][name]=Jack&amp;children[0][age]=6&amp; <br>
&nbsp;&nbsp;&nbsp; children[1][name]=Jane&amp;children[1][age]=4</span></div>
</blockquote>
<div>The <a href="http://msdn.microsoft.com/en-us/library/system.net.http.formatting.formurlencodedmediatypeformatter(v=vs.108).aspx">
FormUrlEncodedMediaTypeFormatter</a>, however, can only <em>read</em> form-urlencoded data; it cannot produce them, because the main scenario for which this formatter was created was to consume such data. There was one request for writing data on this format
 (for an API which needs to invoke an existing service which doesn&rsquo;t support JSON input, and supports only forms data instead), so this post will show a simple media type formatter which can both read
<em>and write</em> forms encoded data.</div>
<div>A small warning before going on: I haven&rsquo;t been able to find any formal specification for the format used by jQuery when encoding complex types, so this is what I was able to find out from passing many different object types and observing what their
 wire representation was. In other words, <a href="http://www.codinghorror.com/blog/2007/03/the-works-on-my-machine-certification-program.html">
it works on my machine</a>. If you know of any formal specification of that format, please let me know.</div>
<div>The existing form encoded formatter already does all the reading part, so we can inherit from the type and only override the writing methods. Below is the virtual methods of the class, nothing new here &ndash; we only support
<a href="http://msdn.microsoft.com/en-us/library/system.json.jsonobject(v=vs.108).aspx">
JsonObject</a> (which provides a good abstraction for JavaScript complex types), but supporting other types (such as JSON.NET&rsquo;s
<a href="http://james.newtonking.com/projects/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm">
JObject</a>) should be trivial. When writing the type, start a new factory which first flattens the object in a list of key/value pairs, then writes them to the stream separated by &lsquo;&amp;&rsquo;.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;ReadWriteFormUrlEncodedMediaTypeFormatter&nbsp;:&nbsp;FormUrlEncodedMediaTypeFormatter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Encoding&nbsp;encoding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UTF8Encoding(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;CanWriteType(Type&nbsp;type)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.CanWriteType(type)&nbsp;||&nbsp;type&nbsp;==&nbsp;<span class="cs__keyword">typeof</span>(JsonObject);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnWriteToStreamAsync(Type&nbsp;type,&nbsp;<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Stream&nbsp;stream,&nbsp;HttpContentHeaders&nbsp;contentHeaders,&nbsp;FormatterContext&nbsp;formatterContext,&nbsp;TransportContext&nbsp;transportContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(type&nbsp;==&nbsp;<span class="cs__keyword">typeof</span>(JsonObject))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Task.Factory.StartNew(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;pairs&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Flatten(pairs,&nbsp;<span class="cs__keyword">value</span>&nbsp;<span class="cs__keyword">as</span>&nbsp;JsonObject);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;bytes&nbsp;=&nbsp;encoding.GetBytes(<span class="cs__keyword">string</span>.Join(<span class="cs__string">&quot;&amp;&quot;</span>,&nbsp;pairs));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stream.Write(bytes,&nbsp;<span class="cs__number">0</span>,&nbsp;bytes.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnWriteToStreamAsync(type,&nbsp;<span class="cs__keyword">value</span>,&nbsp;stream,&nbsp;contentHeaders,&nbsp;formatterContext,&nbsp;transportContext);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:a8d42c41-c8d1-4b92-a3d5-36b0351656d1" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<div>Flattening the object means that for each of the object&rsquo;s keys, we&rsquo;ll push them to a stack and start flattening their values. At the end of the operation, the stack should be empty (otherwise some error happened), so we check that for debugging
 sake.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Flatten(List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;pairs,&nbsp;JsonObject&nbsp;input)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">object</span>&gt;&nbsp;stack&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">object</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;key&nbsp;<span class="cs__keyword">in</span>&nbsp;input.Keys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stack.Add(key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Flatten(pairs,&nbsp;input[key],&nbsp;stack);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stack.RemoveAt(stack.Count&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(stack.Count&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Something&nbsp;went&nbsp;wrong&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:67cf54ca-1274-47ab-b325-5178fb2df4b2" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<div>The main logic of this formatter happens in the recursive Flatten method. Here we check all the possible types of objects which can be written out. jQuery doesn&rsquo;t write out any null values, so we&rsquo;re doing the same here. For arrays and objects,
 the method pushes the key into the stack and calls itself recursively for the value. Finally, for &ldquo;primitive&rdquo; values (numbers, strings, Boolean), we create the key by traversing the stack, separating them with square brackets. One thing which I
 noticed is that for arrays, the last element doesn&rsquo;t have the index in the serialized format, as shown in the &ldquo;luckyNumbers&rdquo; member in the example above, so this code also accounts for that.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Flatten(List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;pairs,&nbsp;JsonValue&nbsp;input,&nbsp;List&lt;<span class="cs__keyword">object</span>&gt;&nbsp;indices)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(input&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;<span class="cs__com">//&nbsp;null&nbsp;values&nbsp;aren't&nbsp;serialized</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(input.JsonType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;JsonType.Array:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;input.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indices.Add(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Flatten(pairs,&nbsp;input[i],&nbsp;indices);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indices.RemoveAt(indices.Count&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;JsonType.Object:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;kvp&nbsp;<span class="cs__keyword">in</span>&nbsp;input)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indices.Add(kvp.Key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Flatten(pairs,&nbsp;kvp.Value,&nbsp;indices);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indices.RemoveAt(indices.Count&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;input.ReadAs&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;name&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;indices.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;index&nbsp;=&nbsp;indices[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name.Append(<span class="cs__string">'['</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;&lt;&nbsp;indices.Count&nbsp;-&nbsp;<span class="cs__number">1</span>&nbsp;||&nbsp;index&nbsp;<span class="cs__keyword">is</span>&nbsp;<span class="cs__keyword">string</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;last&nbsp;array&nbsp;index&nbsp;not&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name.Append(index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name.Append(<span class="cs__string">']'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pairs.Add(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}={1}&quot;</span>,&nbsp;Uri.EscapeDataString(name.ToString()),&nbsp;Uri.EscapeDataString(<span class="cs__keyword">value</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:fbf4eafe-31e4-4daf-a78b-dddf31db5393" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<div>That&rsquo;s it. In the project from code gallery I&rsquo;ll include a test project which shows some examples of the conversions this formatter can do.</div>
</div>
</div>
</div>
</div>
