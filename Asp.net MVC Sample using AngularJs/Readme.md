# Asp.net MVC Sample using AngularJs
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- ASP.NET MVC 5
- AngularJS
## Topics
- ASP.NET Web API
## Updated
- 07/27/2014
## Description

<h1>
<p class="endscriptcode">Introduction</p>
</h1>
<p><em>Have tried to build small demo application to bring in together both world of MVC &#43; angularjs. The demo is simple customer tabular record with feature such as search, add, update, delete,validation. Most of them are handled using angularjs whereas server
 side operations are been handled by mvc web api. More or less angularjs plays a vital role as compared to what asp.net mvc offer. In and all these combination is well suited to develop need website. This is basic implementation where it gives very clear understanding
 of how angular methods and intrinsic functions are tight with UI elements. It is very modular in nature such as controller, factory, directives and UI function events such as click, show, hide, disabled , repeat and so on.</em></p>
<h1><span>Architecture</span></h1>
<ul>
<li><span>Used MVC Web Api.</span> </li><li><span>Angular Js - Factory, Controller and UI</span> </li><li><span>Angular Js List of operation and UI feature.</span> </li><li><span>data-ng-app=&quot;app&quot; id=&quot;ng-app&quot;</span> </li><li><span>data-ng-controller=&quot;CustomersController&quot; </span></li><li><span>data-ng-show=&quot;loading&quot;<br>
data-ng-click=&quot;toggleAdd()&quot;<br>
data-ng-hide=&quot;addMode&quot;</span> </li><li><span>data-ng-disabled=&quot;!addCustomer.$valid&quot;</span> </li><li><span>data-ng-repeat=&quot;customer in customers | filter:search&quot;<br>
</span></li></ul>
<p><span style="font-size:20px; font-weight:bold">AngularJS</span></p>
<p><em>We have registered <strong>app</strong> module in view of MVC page.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var app = angular.module('app', []);
var url = 'api/Customers/';
app.factory('customerFactory', function ($http) {
    return {
        getCustomer: function () {
            return $http.get(url);
        },
        addCustomer: function (customer) {
            return $http.post(url, customer);
        },
        deleteCustomer: function (customer) {
            return $http.delete(url &#43; customer.CustomerID);
        },
        updateCustomer: function (customer) {
            return $http.put(url &#43; customer.Id, customer);
        }
    };
});
</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">'app'</span>,&nbsp;[]);&nbsp;
<span class="js__statement">var</span>&nbsp;url&nbsp;=&nbsp;<span class="js__string">'api/Customers/'</span>;&nbsp;
app.factory(<span class="js__string">'customerFactory'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($http)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getCustomer:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http.get(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addCustomer:&nbsp;<span class="js__operator">function</span>&nbsp;(customer)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http.post(url,&nbsp;customer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;deleteCustomer:&nbsp;<span class="js__operator">function</span>&nbsp;(customer)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http.<span class="js__operator">delete</span>(url&nbsp;&#43;&nbsp;customer.CustomerID);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;updateCustomer:&nbsp;<span class="js__operator">function</span>&nbsp;(customer)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http.put(url&nbsp;&#43;&nbsp;customer.Id,&nbsp;customer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<h1><em>Output:</em></h1>
<p><em>To run -</em></p>
<p><em><a href="http://localhost/customer">http://localhost/customer</a></em></p>
<p><em><br>
</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:25px; width:1px; height:1px; overflow:hidden">
</div>
