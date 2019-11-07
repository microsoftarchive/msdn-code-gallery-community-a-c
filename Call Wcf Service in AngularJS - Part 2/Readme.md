# Call Wcf Service in AngularJS - Part 2
## Requires
- 
## License
- MIT
## Technologies
- WCF
- jQuery
- Javascript
- AngularJS
## Topics
- Call WCF Service in AngularJs
## Updated
- 01/26/2016
## Description

<h1><span style="outline:none 0px"><span style="outline:none 0px">I have used the following Languages in this article:</span></span></h1>
<ul>
<li style="outline:none 0px"><span style="font-size:small">AngularJS</span> </li></ul>
<ul>
<li><span style="font-size:small">Wcf Service</span> </li></ul>
<ul>
<li style="outline:none 0px"><span style="font-size:small">jQuery</span> </li></ul>
<h3><span><span style="font-size:small">Here's the link for the previous part of this series :
<span><a title="Call WCF Service Using jQuery - Part 1" href="https://code.msdn.microsoft.com/Call-WCF-Service-Using-5cb8ea71" target="_blank"><span style="color:#0000ff">How to call WCF Service Using jQuery - Part 1</span></a><span style="color:#0000ff"> .</span></span></span></span></h3>
<h1><span><span><span style="text-align:justify; outline:none 0px; background-color:#ffffff">This image contains my solution explorer.</span></span></span></h1>
<p><em><img id="147787" src="147787-demo.jpg" alt="" width="445" height="279"></em></p>
<p>&nbsp;</p>
<div></div>
<div><span style="font-size:small"><strong>AngularDemo.html file</strong></span></div>
<ul>
<li><span style="font-size:small">The <strong>ng-app </strong>is an application name in AngularJs which is unique in project.</span>
</li></ul>
<ul>
<li><span style="font-size:small">The <strong>ng-app</strong> directive defines an AngularJS application.</span>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; ng-app=&quot;AngularApp&quot;&gt;  </pre>
<div class="preview">
<pre class="js">&lt;html&nbsp;xmlns=<span class="js__string">&quot;http://www.w3.org/1999/xhtml&quot;</span>&nbsp;<span style="background-color:#ffff00">ng-app</span>=<span class="js__string">&quot;AngularApp&quot;</span>&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div><span style="font-size:small"><strong>App.js file&nbsp;</strong>&nbsp;</span></div>
<div><span style="font-size:small">
<ul>
<li><span style="font-size:small">The module is a container for the different parts of an application.</span>
</li></ul>
<ul>
<li><span style="font-size:small">The module is a container for the application controllers.</span>
</li></ul>
<ul>
<li><span style="font-size:small">Controllers always belong to a module.</span> </li></ul>
</span></div>
<p><span style="font-size:small">&nbsp;Here we can integrate angular project name in app.js.</span></p>
<p><span style="font-size:small"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var app = angular.module('AngularApp', []);   </pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;app&nbsp;=&nbsp;angular.<span style="background-color:#ffff00">module</span>(<span class="js__string">'AngularApp'</span>,&nbsp;[]);&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><strong>AngularDemo.html file</strong></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>ng-controller&nbsp;</strong>&nbsp;is a specific controller for my project which I define in my body tag.
</span></li></ul>
<p>&nbsp;</p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;body ng-controller=&quot;AngularController&quot;&gt;</pre>
<div class="preview">
<pre class="js">&lt;body&nbsp;<span style="background-color:#ffff00">ng-controller</span>=<span class="js__string">&quot;AngularController&quot;</span>&gt;</pre>
</div>
</div>
</em></div>
<p><em></em></p>
<div><span style="font-size:small"><strong>Controller.js</strong>&nbsp;</span></div>
<ul>
<li><span style="font-size:small">&nbsp;Here &nbsp;I used controller as an intermediate between service.js and app.js.</span><br>
<br>
</li><li><span style="font-size:small">&nbsp;The following GET method is used for getting all the records from service.</span>
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">    app.controller('AngularController', ['$scope', '$http', 'AngularService', function ($scope, $http, AngularService) {    
        
        $scope.formdata = {};    
        
        //load data    
        AngularService.get().success(function (response) {    
            $scope.Products = JSON.parse(response.d);    
        });  </pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;app.controller(<span class="js__string">'AngularController'</span>,&nbsp;[<span class="js__string">'$scope'</span>,&nbsp;<span class="js__string">'$http'</span>,&nbsp;<span class="js__string">'AngularService'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;$http,&nbsp;AngularService)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.formdata&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//load&nbsp;data&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AngularService.get().success(<span class="js__operator">function</span>&nbsp;(response)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Products&nbsp;=&nbsp;JSON.parse(response.d);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div><span style="font-size:small"><strong>Service.js</strong>&nbsp;</span></div>
<ul>
<li><span style="font-size:small">&nbsp;Below i declared get service for fetching records from service.</span><br>
<br>
</li><li><span style="font-size:small">&nbsp;WCF Service URL is taken from my previous
<a href="https://code.msdn.microsoft.com/Call-WCF-Service-Using-5cb8ea71" target="_blank">
article</a>.</span><br>
<br>
</li><li><span style="font-size:small">&nbsp;So you can download my service from there and used here.</span><span>&nbsp;</span>
</li></ul>
<ul>
<br>
</ul>
<ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">app.factory('AngularService', ['$http', function ($http) {    
    return {    
        //load data service    
        get: function () {    
            return $http({    
                method: 'POST',    
                headers: {    
                    'Content-Type': 'application/json; charset=utf-8'    
                },    
                url: 'http://kunalpatel.tk/ProductService.svc/LoadAllProductDetail',    
                data: {}    
            });    
        }    
  };    
}]); </pre>
<div class="preview">
<pre class="js">app.factory(<span class="js__string">'AngularService'</span>,&nbsp;[<span class="js__string">'$http'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($http)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//load&nbsp;data&nbsp;service&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http(<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;method:&nbsp;<span class="js__string">'POST'</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'Content-Type'</span>:&nbsp;<span class="js__string">'application/json;&nbsp;charset=utf-8'</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://kunalpatel.tk/ProductService.svc/LoadAllProductDetail'</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>]);&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</ul>
<div><span style="font-size:small"><strong>&nbsp;<strong>AngularDemo.html file</strong></strong></span></div>
<ul>
<li><span style="font-size:small"><strong>&nbsp;</strong><strong>ng-repeat </strong>
is a working like for, foreach loop in angular</span> </li></ul>
<ul>
<li><span style="font-size:small">&nbsp;<strong>ng-click </strong>is like onclick event in javascript.</span>
</li></ul>
<ul>
<li><span style="font-size:small">&nbsp;<strong>{{ &nbsp;}} &nbsp;</strong>&nbsp;is a syntax for displaying data.</span>
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;table class='table table-bordered'&gt;  
    &lt;tbody&gt;  
        &lt;tr&gt;  
            &lt;th&gt;Name&lt;/th&gt;  
            &lt;th&gt;Description&lt;/th&gt;  
            &lt;th colspan=&quot;2&quot;&gt;Action&lt;/th&gt;  
        &lt;/tr&gt;  
        &lt;tr ng-repeat=&quot;Product in Products&quot;&gt;  
            &lt;td&gt;{{ Product.ProductName}}&lt;/td&gt;  
            &lt;td&gt;{{ Product.ProductDescription}}&lt;/td&gt;  
            &lt;td&gt;&lt;span&gt;&lt;a href=&quot;javascript:void(0);&quot; ng-click=&quot;edit(Product);&quot;&gt;    
                       &lt;img width=&quot;16&quot; height=&quot;16&quot; alt=&quot;Close&quot; src=&quot;Image/Edit.jpg&quot; /&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;  
            &lt;td&gt;&lt;span&gt;&lt;a href=&quot;javascript:void(0);&quot; ng-click=&quot;delete(Product.Id);&quot;&gt;    
                       &lt;img width=&quot;16&quot; height=&quot;16&quot; alt=&quot;Close&quot; src=&quot;Image/close.png&quot; /&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;  
        &lt;/tr&gt;  
    &lt;/tbody&gt;  
&lt;/table&gt; </pre>
<div class="preview">
<pre class="js">&lt;table&nbsp;class=<span class="js__string">'table&nbsp;table-bordered'</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tbody&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Name&lt;/th&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Description&lt;/th&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&nbsp;colspan=<span class="js__string">&quot;2&quot;</span>&gt;Action&lt;/th&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;<span style="background-color:#ffff00">ng-repeat</span>=<span class="js__string">&quot;Product&nbsp;in&nbsp;Products&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;Product.ProductName<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;Product.ProductDescription<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;span&gt;&lt;a&nbsp;href=<span class="js__string">&quot;javascript:void(0);&quot;</span>&nbsp;ng-click=<span class="js__string">&quot;edit(Product);&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;width=<span class="js__string">&quot;16&quot;</span>&nbsp;height=<span class="js__string">&quot;16&quot;</span>&nbsp;alt=<span class="js__string">&quot;Close&quot;</span>&nbsp;src=<span class="js__string">&quot;Image/Edit.jpg&quot;</span>&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>a&gt;&lt;<span class="js__reg_exp">/span&gt;&lt;/</span>td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;span&gt;&lt;a&nbsp;href=<span class="js__string">&quot;javascript:void(0);&quot;</span>&nbsp;ng-click=<span class="js__string">&quot;delete(Product.Id);&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;width=<span class="js__string">&quot;16&quot;</span>&nbsp;height=<span class="js__string">&quot;16&quot;</span>&nbsp;alt=<span class="js__string">&quot;Close&quot;</span>&nbsp;src=<span class="js__string">&quot;Image/close.png&quot;</span>&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>a&gt;&lt;<span class="js__reg_exp">/span&gt;&lt;/</span>td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;&nbsp;&nbsp;
&lt;/table&gt;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span style="font-size:medium">Download Source Code&nbsp;</span> :&nbsp; <span style="font-size:small">
<a id="147792" href="/site/view/file/147792/1/Call_WcfService_AngularJs.rar">Call_WcfService_AngularJs.rar</a></span></h1>
<h1><span style="font-size:medium">Test Output Here</span> : <span style="font-size:small">
<a title="Call Wcf Service in Angularjs" href="http://kunalpatel.tk/AngularDemo.html" target="_blank">http://kunalpatel.tk</a></span></h1>
<h1>Output Image :</h1>
<p><img id="147793" src="147793-output.jpg" alt="" width="600" height="350"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
