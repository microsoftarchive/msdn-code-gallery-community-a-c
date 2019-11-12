# Create a Signature Pad Using AngularJs
## License
- Apache License, Version 2.0
## Technologies
- Bootstrap
- HTML5/JavaScript
- AngularJS
## Topics
- Signatures
## Updated
- 02/19/2016
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Today I am going to introduce you to using signature pad with AngularJS and WCF service. In this article I am going to show you how to bind signature pad using WCF services.</span></p>
<p><span style="font-size:small"><strong>I used the following in this article:</strong></span></p>
<ol>
<li><span style="font-size:small">Use canvas controm from html5 for drawing signature on signature pad.</span>
</li><li><span style="font-size:small">I used angularjs and wcf rest service for store and retrive signature from database and how to display on screen your signature.</span>
</li></ol>
<p>&nbsp;</p>
<p><span style="font-size:medium"><strong>Step 1: SQL Script for signature pad</strong></span></p>
<ol>
<li><span style="font-size:medium"><span style="font-size:small">This is my sql script which i have used in this article.</span><strong><br>
</strong></span></li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>SQL</span></strong></div>
<div class="pluginLinkHolder"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></div>
<strong><span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span><span class="sql__keyword">TABLE</span>[<span class="sql__id">dbo</span>].[<span class="sql__id">mstSign</span>]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">SignId</span>][<span class="sql__id">UNIQUEIDENTIFIER</span>]&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">cName</span>][<span class="sql__keyword">VARCHAR</span>](<span class="sql__number">150</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">cSigndata</span>][<span class="sql__keyword">VARCHAR</span>](<span class="sql__id">MAX</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">dtDateTime</span>][<span class="sql__keyword">DATETIME</span>]&nbsp;<span class="sql__value">NULL</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;&nbsp;&nbsp;
</pre>
</div>
</strong></div>
</div>
<p><span style="font-size:medium"><strong>Step 2: Wcf Service</strong></span></p>
<ol>
<li><span style="font-size:small">I used my hosted service here.</span> </li><li><span style="font-size:small">So, you can get the latest service from my previous article</span><span style="font-size:small">
<a href="https://code.msdn.microsoft.com/Call-WCF-Service-Using-5cb8ea71" target="_blank">
Call WCF Service Using jQuery - Part 1</a></span> </li><li><span style="font-size:small">I updated my service code there, and also you can see WCF configuration using Windows activation service from web.config.
</span></li></ol>
<p>&nbsp;</p>
<p><span style="font-size:medium"><strong>Step 3: Html5 Canvas code</strong></span></p>
<ol>
<li><span style="font-size:small">I used <span style="background-color:#ccffff">signature_pad.js</span> for displaying signature pattern on screen.</span>
</li><li><span style="font-size:small">This JavaScript file is attached in source code.</span>
</li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;name&quot;</span><span class="html__tag_start">&gt;</span>Enter&nbsp;Your&nbsp;Signature<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;canvas</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">'signatureCanvas'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'300'</span>&nbsp;<span class="html__attr_name">height</span>=<span class="html__attr_value">'150'</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">'border:&nbsp;1px&nbsp;solid&nbsp;black;'</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/canvas&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<h4><span style="font-size:small">JavaScript code for displaying signature</span></h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">'signatureCanvas'</span>);&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;signaturePad&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SignaturePad(canvas);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:medium">&nbsp;<strong>Step 4: Save Canvas using service</strong></span></div>
<h4><span style="font-size:small">My Controller:</span></h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;for&nbsp;signature&nbsp;image&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;sigImg&nbsp;=&nbsp;signaturePad.toDataURL().replace(<span class="js__string">'data:image/png;base64,'</span>,&nbsp;<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;name&nbsp;=&nbsp;$scope.sign.name;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;xml&nbsp;=&nbsp;JSON.stringify&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'name'</span>:&nbsp;name,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'imageData'</span>:&nbsp;sigImg&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;call&nbsp;add&nbsp;service&nbsp;for&nbsp;save&nbsp;signature&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signService.Add(name,&nbsp;sigImg).success(<span class="js__operator">function</span>(response)&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h4><span style="font-size:small">My Service:</span></h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">Add:&nbsp;<span class="js__operator">function</span>(name,&nbsp;imagedata)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;method:&nbsp;<span class="js__string">'POST'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'Content-Type'</span>:&nbsp;<span class="js__string">'application/json;&nbsp;charset=utf-8'</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://kunalpatel.tk/ProductService.svc/AddNewSignature'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;name,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageData:&nbsp;imagedata&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<h4><span style="font-size:small"><strong><span style="font-size:medium">Step 5: Load signature on screen</span><br>
</strong></span><br>
<span style="font-size:small">My Html:</span></h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span>&nbsp;<span class="html__attr_name">ng-repeat</span>=<span class="html__attr_value">&quot;sign&nbsp;in&nbsp;Signatures&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;b</span><span class="html__tag_start">&gt;{</span>{&nbsp;sign.cName&nbsp;}}<span class="html__tag_end">&lt;/b&gt;</span><span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;zoom_img&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;http://www.kunalpatel.tk/Images&nbsp;/Signature/{{&nbsp;sign.cSigndata&nbsp;}}&quot;</span>&nbsp;<span class="html__attr_name">height</span>=<span class="html__attr_value">&quot;50&quot;</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;100&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h4><span style="font-size:small">My Controller</span></h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;signService.get().success(<span class="js__operator">function</span>(response)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Signatures&nbsp;=&nbsp;JSON.parse(response.d);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h4><span style="font-size:small">My Service</span></h4>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;get:&nbsp;<span class="js__operator">function</span>()&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;$http&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;method:&nbsp;<span class="js__string">'POST'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">'Content-Type'</span>:&nbsp;<span class="js__string">'application/json;&nbsp;charset=utf-8'</span><span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://kunalpatel.tk/ProductService.svc/LoadAllSignature'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span><span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h4><span style="font-size:medium"><strong>Step 5 : Final Output</strong></span></h4>
<div>
<div>
<h1><span style="font-size:medium">Download Source Code</span> : <a id="148714" href="/site/view/file/148714/1/SignaturePad.rar">
SignaturePad.rar</a></h1>
<span style="font-size:small">&nbsp;</span>
<h1><span style="font-size:medium">Test Output Here</span> : <span style="font-size:small">
<a title="Click here for test signature pad" href="http://www.kunalpatel.tk/signature.html" target="_blank"><span style="font-size:medium">Click Here for test signature pad</span></a><br>
</span></h1>
<span style="font-size:small">&nbsp;</span>
<h1>Output Image</h1>
</div>
</div>
<p><em>&nbsp;<img id="148715" src="148715-videorecord.gif" alt="" width="502" height="216"></em></p>
