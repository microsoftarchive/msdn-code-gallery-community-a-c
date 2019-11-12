# Configure Angular4 with TypeScript on a WebApplication with VS 2017
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET
- ASP.NET MVC 5
- TypeScript
- Angular 4
## Topics
- ASP.NET
- ASP.NET MVC
- TypeScript
- Angular 4
## Updated
- 04/16/2017
## Description

<p lang="en-US">This article will show how to configure Angular 4 and TypeScript in a ASP.Net MVC web application</p>
<p lang="en-US"><strong>STEP 1 - Make sure you have installed the prerequisites</strong></p>
<p lang="en-US">Without these requisites, application will not run.</p>
<ul type="disc">
<li><span lang="pt">Visual Studio 2017</span> </li><li><span lang="pt">TypeScript 2.0 for Visual Studio 2017</span> </li></ul>
<p lang="en-US"><strong>STEP 2 - Create ASP.NET MVC Web Application</strong></p>
<p lang="en-US"><span lang="pt">Go to Visual Studio</span><span lang="en-US">&rsquo;</span><span lang="pt">s&nbsp;</span><span lang="en-US">File New Project</span><span lang="en-US">&nbsp;menu, expand the&nbsp;</span><span lang="en-US">Web</span><span lang="en-US">&nbsp;category,
 and pick&nbsp;</span><span lang="en-US">ASP.NET Web Application like on the image below</span></p>
<p lang="en-US"><img id="172232" src="172232-angular4_1.png" alt="" width="600" height="400"></p>
<p>Select the template MVC:</p>
<p><img id="172233" src="172233-angular4_2.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 3 - Configure Angular 4</strong></p>
<p lang="en-US">We need now to prepare our frontend to run Angular 4</p>
<ul type="disc">
<li lang="en-US">Create tsconfig.json which is the TypeScript compiler configuration file.&nbsp;
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;compilerOptions&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;target&quot;</span>:&nbsp;<span class="js__string">&quot;es5&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;module&quot;</span>:&nbsp;<span class="js__string">&quot;commonjs&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;moduleResolution&quot;</span>:&nbsp;<span class="js__string">&quot;node&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;sourceMap&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;emitDecoratorMetadata&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;experimentalDecorators&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lib&quot;</span>:&nbsp;[&nbsp;<span class="js__string">&quot;es2015&quot;</span>,&nbsp;<span class="js__string">&quot;dom&quot;</span>&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;noImplicitAny&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;suppressImplicitAnyIndexErrors&quot;</span>:&nbsp;true&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<ul type="disc">
<li lang="en-US">Add package.json file to your project folder with the below code:
</li></ul>
<p><span>The&nbsp;</span><em>most</em><span>&nbsp;important things in your package.json are the name and version fields. Those are actually required, and your package won't install without them. The name and version together form an identifier that is assumed
 to be completely unique. Changes to the package should come along with changes to the version.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span><span class="js__string">&quot;name&quot;</span>:&nbsp;<span class="js__string">&quot;angular-quickstart&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;version&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;description&quot;</span>:&nbsp;<span class="js__string">&quot;QuickStart&nbsp;package.json&nbsp;from&nbsp;the&nbsp;documentation&nbsp;for&nbsp;visual&nbsp;studio&nbsp;2017&nbsp;&amp;&nbsp;WebApi&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;scripts&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;start&quot;</span>:&nbsp;<span class="js__string">&quot;tsc&nbsp;&amp;&amp;&nbsp;concurrently&nbsp;\&quot;tsc&nbsp;-w\&quot;&nbsp;\&quot;lite-server\&quot;&nbsp;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lint&quot;</span>:&nbsp;<span class="js__string">&quot;tslint&nbsp;./app/**/*.ts&nbsp;-t&nbsp;verbose&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lite&quot;</span>:&nbsp;<span class="js__string">&quot;lite-server&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;pree2e&quot;</span>:&nbsp;<span class="js__string">&quot;webdriver-manager&nbsp;update&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;test&quot;</span>:&nbsp;<span class="js__string">&quot;tsc&nbsp;&amp;&amp;&nbsp;concurrently&nbsp;\&quot;tsc&nbsp;-w\&quot;&nbsp;\&quot;karma&nbsp;start&nbsp;karma.conf.js\&quot;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;test-once&quot;</span>:&nbsp;<span class="js__string">&quot;tsc&nbsp;&amp;&amp;&nbsp;karma&nbsp;start&nbsp;karma.conf.js&nbsp;--single-run&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;tsc&quot;</span>:&nbsp;<span class="js__string">&quot;tsc&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;tsc:w&quot;</span>:&nbsp;<span class="js__string">&quot;tsc&nbsp;-w&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;keywords&quot;</span>:&nbsp;[],&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;author&quot;</span>:&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;license&quot;</span>:&nbsp;<span class="js__string">&quot;MIT&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;dependencies&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;@angular/common&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/compiler&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/core&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/forms&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/http&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/platform-browser&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/platform-browser-dynamic&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@angular/router&quot;</span>:&nbsp;<span class="js__string">&quot;4.0.2&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;angular-in-memory-web-api&quot;</span>:&nbsp;<span class="js__string">&quot;~0.2.4&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;systemjs&quot;</span>:&nbsp;<span class="js__string">&quot;0.19.40&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;core-js&quot;</span>:&nbsp;<span class="js__string">&quot;^2.4.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;rxjs&quot;</span>:&nbsp;<span class="js__string">&quot;5.0.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;zone.js&quot;</span>:&nbsp;<span class="js__string">&quot;^0.7.4&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;devDependencies&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;concurrently&quot;</span>:&nbsp;<span class="js__string">&quot;^3.2.0&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lite-server&quot;</span>:&nbsp;<span class="js__string">&quot;^2.2.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;typescript&quot;</span>:&nbsp;<span class="js__string">&quot;~2.0.10&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;canonical-path&quot;</span>:&nbsp;<span class="js__string">&quot;0.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;tslint&quot;</span>:&nbsp;<span class="js__string">&quot;^3.15.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lodash&quot;</span>:&nbsp;<span class="js__string">&quot;^4.16.4&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;jasmine-core&quot;</span>:&nbsp;<span class="js__string">&quot;~2.4.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;karma&quot;</span>:&nbsp;<span class="js__string">&quot;^1.3.0&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;karma-chrome-launcher&quot;</span>:&nbsp;<span class="js__string">&quot;^2.0.0&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;karma-cli&quot;</span>:&nbsp;<span class="js__string">&quot;^1.0.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;karma-jasmine&quot;</span>:&nbsp;<span class="js__string">&quot;^1.0.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;karma-jasmine-html-reporter&quot;</span>:&nbsp;<span class="js__string">&quot;^0.2.2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;protractor&quot;</span>:&nbsp;<span class="js__string">&quot;~4.0.14&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;rimraf&quot;</span>:&nbsp;<span class="js__string">&quot;^2.5.4&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@types/node&quot;</span>:&nbsp;<span class="js__string">&quot;^6.0.46&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@types/jasmine&quot;</span>:&nbsp;<span class="js__string">&quot;2.5.36&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;repository&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<ul>
<li>Create a sub-folder app on the root folder. On this folder we need to create our typescript files:&nbsp;
<ul>
<li>main.ts </li><li>app.module.ts </li><li>app.component.ts </li><li>app.component.html </li></ul>
</li></ul>
<ul>
<li>Create your index.html file like showing below: </li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__doctype">&lt;!DOCTYPE&nbsp;html&gt;</span>&nbsp;
<span class="html__tag_start">&lt;html</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span><span class="html__tag_start">&gt;</span>document.write('<span class="html__tag_start">&lt;base</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;'&nbsp;&#43;&nbsp;document.location&nbsp;&#43;&nbsp;'&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>');<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span>Angular4&nbsp;Routing<span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;base</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">charset</span>=<span class="html__attr_value">&quot;UTF-8&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;viewport&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;width=device-width,&nbsp;initial-scale=1&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;base</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;styles.css&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;load&nbsp;bootstrap&nbsp;3&nbsp;styles&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;Polyfill(s)&nbsp;for&nbsp;older&nbsp;browsers&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;node_modules/core-js/client/shim.min.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;node_modules/zone.js/dist/zone.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;node_modules/systemjs/dist/system.src.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;systemjs.config.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.import('app/main.js').catch(function&nbsp;(err)&nbsp;{&nbsp;console.error(err);&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;my</span>-app<span class="html__tag_start">&gt;</span>Loading&nbsp;App&lt;/my-app&gt;&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Angular will launch the app in the browser with our component and places it in a specific location on index.html.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 5 - Run application</strong></p>
<p lang="en-US"><img id="172239" src="172239-angular4_5.png" alt="" width="546" height="187"></p>
<p lang="en-US">&nbsp;</p>
<p><strong>Resources</strong></p>
<p lang="en-US">Angular4:&nbsp;<a href="https://angular.io/">https://angular.io/</a></p>
<p lang="en-US">My personal blog:&nbsp;<a href="http://joaoeduardosousa.wordpress.com/">http://joaoeduardosousa.wordpress.com/&nbsp;</a></p>
