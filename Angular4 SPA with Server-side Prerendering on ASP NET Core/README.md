# Angular4 SPA with Server-side Prerendering on ASP NET Core
## Requires
- Visual Studio 2017
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Core
- EF Core Code First
- Angular4
## Topics
- Single Page Application (SPA)
- Angular4
## Updated
- 07/31/2017
## Description

<h1>Introduction</h1>
<p>This Angular4 Single Page Application is upgraded from&nbsp;<a title="Angular2 SPA Using EF Core on ASP NET Core" href="https://code.msdn.microsoft.com/Angular2-SPA-with-EF-Core-4f4eccf1">https://code.msdn.microsoft.com/Angular2-SPA-with-EF-Core-4f4eccf1</a>.
 Here are some new features : server prerendering with SEO, AOT build, production build and new homepage. &nbsp;&nbsp;</p>
<p>The SPA builds&nbsp;</p>
<ol>
<li>A product navigation system that customers can use to browse skis by &nbsp;category, price, gender, ideal- for, and page
</li><li>A shopping cart where customers can add and remove skis </li><li>A checkout where customers can fill in their shipping details and place their orders
</li><li>An order list where customers can review their orders. </li></ol>
<p>In this sample, we use</p>
<ol>
<li>Webpack to bundle client-side resources (HMR for development) </li><li>Angular4 as front-end platform </li><li>TypeSript as front-end codes (awesome-typescript-loader for JIT compilation, ngtools/webpack for AOT compilation)
</li><li>Bootstrap4 for styling and layout </li><li>ASP.NET Core as server-side platform </li><li>EF Core to create database, seed data, and access data at the back-end &nbsp;
</li><li>server prerendering for better initial load and SEO </li></ol>
<p>Notice: IIS settings in the web.config for angular routing system cannot work with Hot Module Replacement. Change its name from web2.config to web.config when production needed.</p>
<p>&nbsp;</p>
<h1>Prerequirements:</h1>
<ol>
<li>Visual Studio 2017 </li><li>ASP.Net Core 1.1.0 and up </li><li>EF Core </li><li>Node.js </li><li>Angular4 and other additional modules </li></ol>
<p>&nbsp;</p>
<h1>Running the Sample</h1>
<p>It will take a while for VS2017 to automatically install all the npm and .NET dependencies when you first open tbe app. &nbsp;</p>
<p>Step 1: Make JIT/AOT build</p>
<p>TOOLS -&gt; Node.js Tools -&gt; Node.js Interactive Window</p>
<p>.npm rebuild node-sass</p>
<p>&nbsp;</p>
<p><img id="173504" src="173504-nodesass_2.jpg" alt="" width="620" height="334"></p>
<p>&nbsp;</p>
<p>For JIT:&nbsp;</p>
<p>.npm run build:dev</p>
<p><img id="173505" src="173505-devbuild_2.jpg" alt="" width="620" height="334"></p>
<p>&nbsp;</p>
<p>For AOT:&nbsp;</p>
<p>.npm run build:aot</p>
<p><img id="173506" src="173506-aotbuild_2.jpg" alt="" width="620" height="335"></p>
<p>&nbsp;</p>
<p>To initially load the home page image properly, please check if the image name in the folder ClientApp/dist is the same as the one in the folder wwwroot/ClientApp/dist. If it's not, copy the image from the first folder to the second one.&nbsp;</p>
<p>&nbsp;</p>
<p>Step 2: <span>Create the database using NuGet Package Manager Console&nbsp;</span></p>
<p><img id="173507" src="173507-1_pm_2.jpg" alt="" width="616" height="390">&nbsp;</p>
<h1><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/angular4-spa-with-server-4964df03/image/file/173510/1/skishopangular2_2.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="https://i1.code.msdn.s-msft.com/angular4-spa-with-server-4964df03/image/file/173510/1/skishopangular2_2.wmv"
 /> <param name="id" value="173510" /> <param name="name" value="SkiShopAngular2_2.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="https://i1.code.msdn.s-msft.com/angular4-spa-with-server-4964df03/image/file/173510/1/skishopangular2_2.wmv" href="https://i1.code.msdn.s-msft.com/angular4-spa-with-server-4964df03/image/file/173510/1/skishopangular2_2.wmv">Download video</a></h1>
<p>Or go to</p>
<p><a href="https://www.youtube.com/watch?v=hfR-ymvgVvY" target="_blank">https://www.youtube.com/watch?v=hfR-ymvgVvY</a></p>
<p>&nbsp;</p>
<p><img id="173511" src="173511-1.gif" alt="" width="605" height="378"></p>
<p>&nbsp;</p>
<p><img id="173512" src="173512-2.gif" alt=""></p>
<p>&nbsp;</p>
<p><img id="173513" src="173513-3.gif" alt="" width="605" height="378"></p>
<p>&nbsp;</p>
<p><img id="173514" src="173514-4.gif" alt="" width="605" height="378"></p>
<p>&nbsp;</p>
<p><img id="173515" src="173515-5.gif" alt="" width="605" height="378"></p>
<p>&nbsp;</p>
<p><img id="174577" src="174577-homepage_2.jpg" alt="" width="632" height="399"></p>
<h1>Sample Codes</h1>
<p>clearance.attrdirective.ts</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;Directive,&nbsp;Renderer,&nbsp;ElementRef,&nbsp;Input&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;
&nbsp;
@Directive&nbsp;(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selector:&nbsp;<span class="js__string">'[clearance-class]'</span>&nbsp;
<span class="js__brace">}</span>)&nbsp;
export&nbsp;class&nbsp;ClearanceAttrDirective&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;nativeElement:&nbsp;Node;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;constructor(private&nbsp;renderer:&nbsp;Renderer,&nbsp;private&nbsp;element:&nbsp;ElementRef)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.nativeElement&nbsp;=&nbsp;element.nativeElement;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Input(<span class="js__string">'clearance-class'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;priceCurrent:&nbsp;number;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Input(<span class="js__string">'price-regular'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;priceRegular:&nbsp;number;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;getString(price:&nbsp;number):&nbsp;string&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;price.toLocaleString(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'en-us'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;style:&nbsp;<span class="js__string">'currency'</span>,&nbsp;currency:&nbsp;<span class="js__string">'USD'</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ngOnInit()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__operator">this</span>.priceCurrent&nbsp;&lt;&nbsp;<span class="js__operator">this</span>.priceRegular)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;del&nbsp;=&nbsp;<span class="js__operator">this</span>.renderer.createElement(<span class="js__operator">this</span>.nativeElement,&nbsp;<span class="js__string">'del'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.setElementStyle(del,&nbsp;<span class="js__string">'color'</span>,&nbsp;<span class="js__string">'navy'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.setElementStyle(del,&nbsp;<span class="js__string">'font-weight'</span>,&nbsp;<span class="js__string">'500'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.createText(del,&nbsp;<span class="js__operator">this</span>.getString(<span class="js__operator">this</span>.priceRegular));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;span&nbsp;=&nbsp;<span class="js__operator">this</span>.renderer.createElement(<span class="js__operator">this</span>.nativeElement,&nbsp;<span class="js__string">'span'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.setElementStyle(span,&nbsp;<span class="js__string">'color'</span>,&nbsp;<span class="js__string">'red'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.setElementStyle(span,&nbsp;<span class="js__string">'font-weight'</span>,&nbsp;<span class="js__string">'bold'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.createText(span,&nbsp;<span class="js__string">'&nbsp;'</span>&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.getString(<span class="js__operator">this</span>.priceCurrent));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.setElementStyle(<span class="js__operator">this</span>.nativeElement,&nbsp;<span class="js__string">'color'</span>,&nbsp;<span class="js__string">'navy'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.setElementStyle(<span class="js__operator">this</span>.nativeElement,&nbsp;<span class="js__string">'font-weight'</span>,&nbsp;<span class="js__string">'500'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.renderer.createText(<span class="js__operator">this</span>.nativeElement,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.getString(<span class="js__operator">this</span>.priceCurrent));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p>For more information on Angular 4 server prerendering on ASP NET Core, please go check:</p>
<p><a title="aspnetcore-angular2-universal by Mark Pieszak" href="https://github.com/MarkPieszak/aspnetcore-angular2-universal" target="_blank">https://github.com/MarkPieszak/aspnetcore-angular2-universal&nbsp;</a></p>
<p><a href="https://github.com/angular/universal/tree/master/modules/ng-aspnetcore-engine" target="_blank">https://github.com/angular/universal/tree/master/modules/ng-aspnetcore-engine</a></p>
