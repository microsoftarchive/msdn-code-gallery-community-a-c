# Convert XML to JSON In Angular JS
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- JSON
- XML
- HTML5
- AngularJS
## Topics
- XML
- Visual Studio
- HTML5
- XML to JSON
- AngularJS
## Updated
- 07/05/2016
## Description

<p><span style="font-size:small">In this post we will see how we can convert an XML file to&nbsp;<a href="http://sibeeshpassion.com/category/json/" target="_blank">JSON&nbsp;</a>in Angular JS. As you all know Angular JS is a JavaScript framework for developing
 applications. So basically Angular JS expects the response in the form of JSON. Hence it is recommended to return the data in JSON format before you start to work on the data. Here in this post we will load a local XML file using Angular JS $http service,
 and we will convert the same XML file to JSON. If you are new to Angular JS, please read here:&nbsp;<a href="http://sibeeshpassion.com/category/angularjs/" target="_blank">Angular JS</a>. I hope you will like this article.</span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">I have already posted an article related to $http service in Angular JS, you can see here:&nbsp;<a href="http://sibeeshpassion.com/learning-angularjs-http/" target="_blank">$http Service In Angular JS<br>
</a></span></p>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">Create an html page first.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_323252">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Convert&nbsp;XML&nbsp;to&nbsp;JSON&nbsp;In&nbsp;Angular&nbsp;JS&nbsp;-&nbsp;SibeeshPassion&nbsp;&lt;/title&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now add the needed reference as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_576129">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=<span class="js__string">&quot;jquery-2.1.3.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;angular.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;xml2json.js&quot;</span>&gt;&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<blockquote>
<p><span style="font-size:small">Have you noticed that I have added xml2json.js file? This is the file which is doing the conversion part. You can always download the file from&nbsp;<a href="https://code.google.com/p/x2js/" target="_blank">https://code.google.com/p/x2js/</a></span></p>
</blockquote>
<p><span style="font-size:small">Now create a controller and app directive as follows.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_354779">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;ng-app=<span class="js__string">&quot;httpApp&quot;</span>&nbsp;ng-controller=<span class="js__string">&quot;httpController&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Next thing we need to do is adding the service. You can add the $http service as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_281349">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">'httpApp'</span>,&nbsp;[]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.controller(<span class="js__string">'httpController'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;$http)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">&quot;Sitemap.xml&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;transformResponse:&nbsp;<span class="js__operator">function</span>&nbsp;(cnv)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;x2js&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;X2JS();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;aftCnv&nbsp;=&nbsp;x2js.xml_str2json(cnv);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;aftCnv;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.success(<span class="js__operator">function</span>&nbsp;(response)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(response);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Here httpApp is our app and httpController is our controller. And we are transforming our response using the function transformResponse.</span></p>
<p><span style="font-size:small">Transforming Request and Response</span></p>
<p><span style="font-size:small">In Angular JS, requests can be transformed using a function called transformRequest and if it is a response we can transform by function transformResponse. These functions returns the transformed values.</span></p>
<p><span style="font-size:small">Here in our example we are using the transformResponse function as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_128603">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">transformResponse:&nbsp;<span class="js__operator">function</span>&nbsp;(cnv)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;x2js&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;X2JS();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;aftCnv&nbsp;=&nbsp;x2js.xml_str2json(cnv);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;aftCnv;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">The x2js.xml_str2json(cnv) will return the json object and we return aftCnv from the function transformResponse. Sounds good? Once we are done everything, we are just write the JSON object in the browser console, so that we
 can see the object.</span></p>
<p><strong><span style="font-size:small">Output</span></strong></p>
<div class="wp-caption x_alignnone" id="attachment_10904"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/11/Convert_XML_to_JSON_In_Angular_JS-e1446550586662.png"><img class="size-full x_wp-image-10904" src="-convert_xml_to_json_in_angular_js-e1446550586662.png" alt="Convert XML To JSON In Angular JS" width="650" height="379"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Convert XML To JSON In Angular JS</span></p>
</div>
<p><span style="font-size:small">That&rsquo;s all we have done everything. Happy coding!.</span></p>
<h1></h1>
