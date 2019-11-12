# ASP.NET Core 1.0 - How to configure Angular2 with TypeScript
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET Core
- Angular2
## Topics
- C#
- ASP.NET Core
- Angular2
## Updated
- 04/18/2017
## Description

<p lang="en-US">This article will show how to configure Angular 2 and TypeScript in a ASP.Net Core based API</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 1 - Make sure you have installed the prerequisites</strong></p>
<p lang="en-US">Without these requisites, application will not run.</p>
<ul type="disc">
<li><a href="https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs"><span lang="pt">Visual Studio 2015 Update 3</span></a><span lang="pt">. Note that Update 2 is not enough. You need Update 3, because it fixes some issues with NPM, plus it&rsquo;s
 a prerequisite for TypeScript 2.0.</span> </li><li><a href="https://blogs.msdn.microsoft.com/dotnet/2016/09/13/announcing-september-2016-updates-for-net-core-1-0/"><span lang="pt">.NET Core 1.0.1</span></a>
</li><li><a href="https://blogs.msdn.microsoft.com/typescript/2016/09/22/announcing-typescript-2-0/"><span lang="pt">TypeScript 2.0 for Visual Studio 2015</span></a><span lang="pt">. If Visual Studio keeps complaining&nbsp;</span><span lang="en-US">Cannot find name
 'require'</span><span lang="pt">, it</span><span lang="en-US">&rsquo;</span><span lang="pt">s because you forgot to install this.</span>
</li><li><a href="https://nodejs.org/"><span lang="pt">Node.js version 4 or later</span></a>
</li></ul>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 2 - Create ASP.NET Core Web Application</strong></p>
<p lang="en-US"><span lang="pt">Go to Visual Studio</span><span lang="en-US">&rsquo;</span><span lang="pt">s&nbsp;</span><span lang="en-US">File New Project</span><span lang="en-US">&nbsp;menu, expand the&nbsp;</span><span lang="en-US">Web</span><span lang="en-US">&nbsp;category,
 and pick&nbsp;</span><span lang="en-US">ASP.NET Core Web Application like on the image below</span></p>
<p lang="en-US"><img id="163766" src="163766-1.png" alt="" width="600" height="400"></p>
<p>Select the template Web API:</p>
<p>&nbsp;</p>
<p><img id="163767" src="163767-2.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p><strong>STEP 3 - Prepare Web Application to run Angular 2</strong></p>
<p lang="en-US">At this point, we have our backend part ready. Let&rsquo;s setup the frontend.</p>
<p><span lang="en-US">A Web API project can't serve static files like JavaScripts, CSS styles, images, or even HTML files. Therefore we need to add a reference to</span><span lang="pt">&nbsp;</span><span lang="en-US">Microsoft.AspNetCore.StaticFiles&nbsp;in
 the</span><span lang="pt">&nbsp;</span><span lang="en-US">project.json:</span></p>
<ul>
<li>&quot;Microsoft.AspNetCore.StaticFiles&quot;: &quot;1.0.0 &quot;, </li></ul>
<p lang="en-US">And in the startup.cs, we need to add the following line, just before the call of UseMvc().</p>
<ul>
<li>app.UseStaticFiles(); </li></ul>
<p lang="en-US">&nbsp;</p>
<p><span lang="en-US">Another important thing we need to do in the</span><span lang="pt">&nbsp;</span><span lang="en-US">startup.cs</span><span lang="pt">&nbsp;</span><span lang="en-US">is to support the Routing of Angular 2. If the Browser calls a URL that
 doesn't exist</span><span lang="pt">&nbsp;</span><span lang="en-US">on the server, it could be an Angular route. Especially if the URL doesn't contain a file extension.</span></p>
<p><span lang="en-US">Just before we call</span><span lang="pt">&nbsp;</span><span lang="en-US">UseStaticFiles() insert the following code:</span></p>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">app.Use(async&nbsp;(context,&nbsp;next)&nbsp;=&gt;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;next();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context.Response.StatusCode&nbsp;==&nbsp;<span class="cs__number">404</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;!Path.HasExtension(context.Request.Path.Value))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Request.Path&nbsp;=&nbsp;<span class="cs__string">&quot;/index.html&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;next();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
});&nbsp;
&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>STEP 4 - Configure Angular 2</strong></div>
<p>&nbsp;</p>
<p lang="en-US">Now we prepared the ASP.NET Core application to start to follow the angular.io tutorial.</p>
<ul type="disc">
<li lang="en-US"><span>You need to create tsconfig.json which is the TypeScript compiler configuration file. It guides the compiler to generate JavaScript files.</span>
</li></ul>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">{&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;compilerOptions&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;target&quot;</span>:&nbsp;<span class="cs__string">&quot;es5&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;module&quot;</span>:&nbsp;<span class="cs__string">&quot;system&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;moduleResolution&quot;</span>:&nbsp;<span class="cs__string">&quot;node&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;sourceMap&quot;</span>:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;emitDecoratorMetadata&quot;</span>:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;experimentalDecorators&quot;</span>:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;removeComments&quot;</span>:&nbsp;<span class="cs__keyword">false</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;noImplicitAny&quot;</span>:&nbsp;<span class="cs__keyword">false</span>&nbsp;
&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;exclude&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;node_modules&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;typings/main&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;typings/main.d.ts&quot;</span>&nbsp;
&nbsp;&nbsp;]&nbsp;
&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<ul>
<li>&nbsp;Create a typings.json file in your project folder angular2-demo as shown below:
</li></ul>
</div>
<p>&nbsp;</p>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">{&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;globalDependencies&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;core-js&quot;</span>:&nbsp;<span class="cs__string">&quot;registry:dt/core-js#0.0.0&#43;20160602141332&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;jasmine&quot;</span>:&nbsp;<span class="cs__string">&quot;registry:dt/jasmine#2.2.0&#43;20160621224255&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;node&quot;</span>:&nbsp;<span class="cs__string">&quot;registry:dt/node#6.0.0&#43;20160621231320&quot;</span>&nbsp;
&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<ul type="disc">
<li lang="en-US"><span>Add package.json file to your project folder with the below code:</span>
</li></ul>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">package.json&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;name&quot;</span>:&nbsp;<span class="cs__string">&quot;angular2-demo&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;version&quot;</span>:&nbsp;<span class="cs__string">&quot;1.0.0&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;scripts&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;start&quot;</span>:&nbsp;<span class="cs__string">&quot;concurrent&nbsp;\&quot;npm&nbsp;run&nbsp;tsc:w\&quot;&nbsp;\&quot;npm&nbsp;run&nbsp;lite\&quot;&nbsp;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;tsc&quot;</span>:&nbsp;<span class="cs__string">&quot;tsc&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;tsc:w&quot;</span>:&nbsp;<span class="cs__string">&quot;tsc&nbsp;-w&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;lite&quot;</span>:&nbsp;<span class="cs__string">&quot;lite-server&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;typings&quot;</span>:&nbsp;<span class="cs__string">&quot;typings&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;postinstall&quot;</span>:&nbsp;<span class="cs__string">&quot;typings&nbsp;install&quot;</span>&nbsp;
&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;license&quot;</span>:&nbsp;<span class="cs__string">&quot;ISC&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;dependencies&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;angular2&quot;</span>:&nbsp;<span class="cs__string">&quot;2.0.0-beta.7&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;systemjs&quot;</span>:&nbsp;<span class="cs__string">&quot;0.19.22&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;es6-promise&quot;</span>:&nbsp;<span class="cs__string">&quot;^3.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;es6-shim&quot;</span>:&nbsp;<span class="cs__string">&quot;^0.33.3&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;reflect-metadata&quot;</span>:&nbsp;<span class="cs__string">&quot;0.1.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;rxjs&quot;</span>:&nbsp;<span class="cs__string">&quot;5.0.0-beta.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;zone.js&quot;</span>:&nbsp;<span class="cs__string">&quot;0.5.15&quot;</span>&nbsp;
&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;<span class="cs__string">&quot;devDependencies&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;concurrently&quot;</span>:&nbsp;<span class="cs__string">&quot;^2.0.0&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;lite-server&quot;</span>:&nbsp;<span class="cs__string">&quot;^2.1.0&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;typescript&quot;</span>:&nbsp;<span class="cs__string">&quot;^1.7.5&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;typings&quot;</span>:<span class="cs__string">&quot;^0.6.8&quot;</span>&nbsp;
&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The package.json will contain the packages that our apps require. These packages are installed and maintained with npm (Node Package Manager). To install packages, run the below npm command in command prompt.</div>
<p>&nbsp;</p>
<p lang="en-US">Create a sub-folder called app/ inside your wwwroot project folder to the place Angular app components.</p>
<p lang="en-US">The files which you create need to be saved with .ts extension. Create a file called environment_app.component.ts in your app/ folder with the below code:</p>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">environment_app.component.ts&nbsp;
&nbsp;
import&nbsp;{Component,&nbsp;View}&nbsp;from&nbsp;<span class="cs__string">&quot;angular2/core&quot;</span>;&nbsp;
&nbsp;
@Component({&nbsp;
&nbsp;&nbsp;&nbsp;selector:&nbsp;<span class="cs__string">'my-app'</span>&nbsp;
})&nbsp;
&nbsp;
@View({&nbsp;
&nbsp;&nbsp;template:&nbsp;<span class="cs__string">'&lt;h2&gt;My&nbsp;First&nbsp;Angular&nbsp;2&nbsp;App&lt;/h2&gt;'</span>&nbsp;
})&nbsp;
&nbsp;
export&nbsp;<span class="cs__keyword">class</span>&nbsp;AppComponent&nbsp;{&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Next, create environment_main.ts file with the below code:</div>
<p>&nbsp;</p>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">import&nbsp;{bootstrap}&nbsp;from&nbsp;<span class="cs__string">&quot;angular2/platform/browser&quot;</span>&nbsp;
import&nbsp;{AppComponent}&nbsp;from&nbsp;<span class="cs__string">&quot;./environment_app.component&quot;</span>&nbsp;
&nbsp;
bootstrap(AppComponent);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The environment_main.ts file tells Angular to load the component.</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<ul type="disc">
<li lang="en-US"><span>Now create a index.html in your project folder angular2demo/ with the below code:</span>
</li></ul>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Hello&nbsp;World&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://cdnjs.cloudflare.com/ajax/libs/es6-shim/0.33.3/es6-shim.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://cdnjs.cloudflare.com/ajax/libs/systemjs/0.19.20/system-polyfills.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://code.angularjs.org/2.0.0-beta.6/angular2-polyfills.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://code.angularjs.org/tools/system.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://code.angularjs.org/tools/typescript.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://code.angularjs.org/2.0.0-beta.6/Rx.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;https://code.angularjs.org/2.0.0-beta.6/angular2.dev.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.config({&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;transpiler:&nbsp;<span class="cs__string">'typescript'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;typescriptOptions:&nbsp;{&nbsp;emitDecoratorMetadata:&nbsp;<span class="cs__keyword">true</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;packages:&nbsp;{<span class="cs__string">'app'</span>:&nbsp;{defaultExtension:&nbsp;<span class="cs__string">'ts'</span>}}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.import(<span class="cs__string">'/app/environment_main'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.then(<span class="cs__keyword">null</span>,&nbsp;console.error.bind(console));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;my-app&gt;Loading...&lt;/my-app&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p lang="en-US">Angular will launch the app in the browser with our component and places it in a specific location on index.html.</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong><span lang="en-US">STEP 5 - Run application</span></strong></p>
<p lang="en-US"><img id="163768" src="163768-3.png" alt="" width="600" height="400"></p>
<p><strong>Resources</strong></p>
<p lang="en-US">Angular2: <a href="http://www.angular2.com/">http://www.angular2.com/</a></p>
<p lang="en-US"><span>My personal blog:</span><span>&nbsp;</span><a href="http://joaoeduardosousa.wordpress.com/"><span>http://joaoeduardosousa.wordpress.com/&nbsp;</span></a></p>
