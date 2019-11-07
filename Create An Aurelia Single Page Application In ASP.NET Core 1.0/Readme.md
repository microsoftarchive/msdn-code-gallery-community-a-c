# Create An Aurelia Single Page Application In ASP.NET Core 1.0
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET
- Javascript
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
- ASP.NET Core 1.0.1
- Aurelia
## Topics
- C#
- ASP.NET
- Javascript
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
- ASP.NET Core 1.0.1
- Aurelia
## Updated
- 01/17/2017
## Description

<h1>Introduction</h1>
<p><br>
<span style="font-size:16px">In our previous article, we studied&nbsp;<a title="ASP.NET Core 1.0 Configuration: Aurelia Single Page Applications" href="https://social.technet.microsoft.com/wiki/contents/articles/36792.asp-net-core-1-0-configuration-aurelia-single-page-applications.aspx" target="_blank">ASP.NET
 Core 1.0 Configuration: Aurelia Single Page Applications</a>.&nbsp;Now, we are going to create Aurelia single page Applications in ASP.NET Core 1.0.</span></p>
<h1>Aurelia</h1>
<p><span style="font-size:16px">Aurelia is a JavaScript client framework for mobile, desktop, Web and we can create a single page applications using th Aurelia framework.<br>
</span></p>
<h1>Configuring Aurelia in ASP.NET Core 1.0</h1>
<p><br>
<span style="font-size:16px">In our previous article, we mentioned a detailed description about&nbsp;<a title="ASP.NET Core 1.0 Configuration: Aurelia Single Page Applications" href="https://social.technet.microsoft.com/wiki/contents/articles/36792.asp-net-core-1-0-configuration-aurelia-single-page-applications.aspx" target="_blank">ASP.NET
 Core 1.0 Configuration: Aurelia Single Page Applications</a>.&nbsp;Thus, we only noticed the important steps of Aurelia configuration in ASP.NET Core 1.0. Install jspm and Aurelia framework through the command.</span></p>
<ul>
<li><span style="font-size:16px">Download and install :&nbsp;<a title="Node.js" href="https://nodejs.org/en/" target="_blank">Node.js</a></span>
</li><li><span style="font-size:16px">Download and install :&nbsp;<a title="Git - Downloads" href="https://git-scm.com/downloads" target="_blank">Git - Downloads</a></span>
</li><li><span style="font-size:16px">Install jspm [ Command : <em>&quot;npm install -g jspm&quot;</em> ].</span>
</li><li><span style="font-size:16px">jspm Initialization [ Command : <em>&quot;jspm init&quot;</em> ].<br>
</span></li><li><span style="font-size:16px">Install Aurelia framework in ASP.NET Core 1.0 [ Command :
<em>&quot;jspm install aurelia-framework&quot;</em> ].<br>
</span></li><li><span style="font-size:16px">Install Aurelia bootstrapper in ASP.NET Core 1.0 [ Command :
<em>&quot;jspm install aurelia-bootstrapper&quot;</em> ].<br>
</span></li></ul>
<div>
<h1>Project Structure</h1>
<span style="font-size:16px">Click <em>&quot;show all files icon&quot;</em> in Solution Explorer. You can see the jspm_packages reference and config.js inside the wwwroot.<br>
</span><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/2352.Project_2D00_Structure.png"><img src=":-2352.project_2d00_structure.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h1>Aurelia Reference in index.html page</h1>
<div><br>
<span style="font-size:16px">We are going to add Aurelia references in <em>&quot;index.html&quot;</em> page because in ASP.NET Core 1.0, we run index.html file as a start page in default. Don't worry. We can mention other pages also but we need to do some customization
 in the code.<br>
</span></div>
<h1>Index.html</h1>
<div><br>
<span style="font-size:16px">The code given below contains the reference of &quot;jspm_packages/system.js&quot; &amp; &quot;config.js&quot;. The body tag contains the &quot;aurelia-app&quot; or an entry point of Aurelia app and it automatically detects the app.js file in our root folder
 (what we mention baseURL on jspm installation) or wwwroot. The &quot;System.import(&quot;Aurelia-Bootstrapper&quot;)&quot; will help to import Aurelia-Bootstrapper references in the body.</span>&nbsp;<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/7723.Index_2D00_Page.png"><img src=":-7723.index_2d00_page.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h1>config.js</h1>
<div><span style="font-size:16px">JSON file contains all the details about Aurelia configuration.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">System.config({</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">baseURL:
</code><code style="color:blue">&quot;/&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">defaultJSExtensions:
</code><code style="color:#006699; font-weight:bold">true</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">transpiler:
</code><code style="color:blue">&quot;babel&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">babelOptions: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;optional&quot;</code><code style="color:#000000">: [</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;runtime&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;optimisation.modules.system&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">]</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">paths: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:*&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;jspm_packages/github/*&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:*&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;jspm_packages/npm/*&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">map: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;aurelia-bootstrapper&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-bootstrapper@2.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;aurelia-framework&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-framework@1.0.8&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;aurelia-pal-browser&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal-browser@1.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;babel&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:babel-core@5.8.38&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;babel-runtime&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:babel-runtime@5.8.38&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;core-js&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:core-js@1.2.7&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:jspm/nodelibs-assert@0.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;assert&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:assert@1.4.1&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:jspm/nodelibs-buffer@0.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;buffer&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:buffer@3.6.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:jspm/nodelibs-path@0.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;path-browserify&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:path-browserify@0.0.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:process@0.11.9&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:jspm/nodelibs-util@0.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;util&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:util@0.10.3&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;github:jspm/nodelibs-vm@0.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;vm-browserify&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:vm-browserify@0.0.4&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:assert@1.4.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;assert&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-assert@0.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;buffer&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-buffer@0.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;util&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:util@0.10.3&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-binding@1.1.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-task-queue&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-task-queue@1.1.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-bootstrapper@2.0.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-event-aggregator&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-event-aggregator@1.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-framework&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-framework@1.0.8&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-history&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-history@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-history-browser&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-history-browser@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-loader-default&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-loader-default@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging-console&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging-console@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal-browser&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal-browser@1.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-polyfills&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-polyfills@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-router&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-router@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating-binding&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating-binding@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating-resources&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating-resources@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating-router&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating-router@1.0.1&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-dependency-injection@1.3.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-event-aggregator@1.0.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-framework@1.0.8&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-binding&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-binding@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-dependency-injection&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-dependency-injection@1.3.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-loader&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-loader@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-task-queue&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-task-queue@1.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating@1.2.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-history-browser@1.0.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-history&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-history@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-loader-default@1.0.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-loader&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-loader@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-loader@1.0.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-logging-console@1.0.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-pal-browser@1.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-polyfills@1.1.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-route-recognizer@1.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-router@1.1.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-dependency-injection&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-dependency-injection@1.3.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-event-aggregator&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-event-aggregator@1.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-history&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-history@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-route-recognizer&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-route-recognizer@1.1.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-task-queue@1.1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-templating-binding@1.2.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-binding&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-binding@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating@1.2.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-templating-resources@1.2.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-binding&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-binding@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-dependency-injection&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-dependency-injection@1.3.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-loader&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-loader@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-task-queue&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-task-queue@1.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-templating-router@1.0.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-binding&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-binding@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-dependency-injection&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-dependency-injection@1.3.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-router&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-router@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-templating&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-templating@1.2.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:aurelia-templating@1.2.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-binding&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-binding@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-dependency-injection&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-dependency-injection@1.3.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-loader&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-loader@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-logging&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-logging@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-metadata&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-metadata@1.0.3&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal@1.2.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-path@1.1.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-task-queue&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-task-queue@1.1.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:babel-runtime@5.8.38&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:buffer@3.6.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;base64-js&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:base64-js@0.0.8&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;child_process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-child_process@0.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;fs&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-fs@0.1.2&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;ieee754&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:ieee754@1.1.8&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;isarray&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:isarray@1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:core-js@1.2.7&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;fs&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-fs@0.1.2&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;path&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-path@0.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;systemjs-json&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:systemjs/plugin-json@0.1.2&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:inherits@2.0.1&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;util&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-util@0.1.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:path-browserify@0.0.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:process@0.11.9&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;assert&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-assert@0.1.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;fs&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-fs@0.1.2&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;vm&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-vm@0.1.0&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:util@0.10.3&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;inherits&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:inherits@2.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;process&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;github:jspm/nodelibs-process@0.1.2&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;npm:vm-browserify@0.0.4&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;indexof&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:indexof@0.0.1&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">});</code></span></div>
</div>
</div>
<h1>package.json</h1>
<div>&nbsp;<br>
<span style="font-size:16px">JSON file contains all the dependencies of Aurelia.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;jspm&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;directories&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;baseURL&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;wwwroot&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;dependencies&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-bootstrapper&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-bootstrapper@^2.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-framework&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-framework@^1.0.8&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;aurelia-pal-browser&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:aurelia-pal-browser@^1.1.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;devDependencies&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;babel&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:babel-core@^5.8.24&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;babel-runtime&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:babel-runtime@^5.8.24&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;core-js&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;npm:core-js@^1.1.4&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>app.js</h1>
<div><br>
<span style="font-size:16px">We have created one more staticfile or app.js inside the wwwroot or Webroot. The file given below contains the syntax as &quot;export&quot;. It will help to export the entire class details to correspondence app.html as Controller and View
 name relation in ASP.NET MVC.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">export class App</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">constructor()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">this</code><code style="color:#000000">.Message =
</code><code style="color:blue">&quot;Aurelia in Asp.Net Core 1.0 !!&quot;</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>app.html</h1>
<div><br>
Now, we are going to create one more HTML file inside the wwwroot or Webroot. Here, we will bind the app.js methods,functions etc. inside the curly bracket
<em><strong>&quot;${}&quot;</strong></em>.<br>
<br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">template</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;${Message}&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">template</code><code style="color:#000000">&gt;</code></span></div>
</div>
<br>
<h1>Project.json</h1>
<span style="font-size:16px">When we want to call Staticfiles in ASP.NET Core 1.0, we need to add Staticfiles dependency in project.json.<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;dependencies&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.NETCore.App&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;version&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;type&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;platform&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Diagnostics&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.IISIntegration&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.Kestrel&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.Extensions.Logging.Console&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.StaticFiles&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.1.0&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;tools&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.IISIntegration.Tools&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0-preview2-final&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;frameworks&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;netcoreapp1.0&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;imports&quot;</code><code style="color:#000000">: [</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:blue">&quot;dotnet5.6&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:blue">&quot;portable-net45&#43;win8&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:#000000">]</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;buildOptions&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;emitEntryPoint&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;preserveCompilationContext&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;runtimeOptions&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;configProperties&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;System.GC.Server&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;publishOptions&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;include&quot;</code><code style="color:#000000">: [</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;wwwroot&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;web.config&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">]</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;scripts&quot;</code><code style="color:#000000">: {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;postpublish&quot;</code><code style="color:#000000">: [
</code><code style="color:blue">&quot;dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%&quot;</code>
<code style="color:#000000">]</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>Configuration in Startup.cs Class</h1>
<div><br>
<span style="font-size:16px">The code given below in <strong>UseFileServer()</strong> will help to call staticfiles in ASP.NET Core 1.0.&nbsp;<br>
</span><br>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">System;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">System.Collections.Generic;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">System.Linq;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">System.Threading.Tasks;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Builder;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Hosting;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Http;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.DependencyInjection;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.Extensions.Logging;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">namespace</code>
<code style="color:#000000">AureliaHelloWorld</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
Startup</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// This method gets called by the runtime. Use this method to add services to the container.</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// For more information on how to configure your application, visit
<a href="http://go.microsoft.com/fwlink/?LinkID=398940">http://go.microsoft.com/fwlink/?LinkID=398940</a></code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
ConfigureServices(IServiceCollection services)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#008200">// This method gets called by the runtime. Use this method to configure the HTTP request
 pipeline.</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">loggerFactory.AddConsole();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(env.IsDevelopment())</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">app.UseDeveloperExceptionPage();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">app.UseFileServer();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;</code><span style="margin-left:3px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">app.Run(async (context) =&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">await context.Response.WriteAsync(</code><code style="color:blue">&quot;Hello
 World!&quot;</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">});</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</div>
<h1>Possible Error</h1>
<div><br>
<span style="font-size:16px">I think possibly we will get the given error below.<br>
</span><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8156.Aurelia-_2D00_-Error.png"><img src=":-8156.aurelia-_2d00_-error.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<span style="font-size:16px">Therefore, we need to install aurelia-pal Browser in our project.<br>
</span><br>
<strong><span style="font-size:16px">Command<br>
</span></strong><br>
<em><span style="font-size:16px">&quot;jspm install npm:aurelia-pal-browser&quot;<br>
</span></em></div>
<h1>Output</h1>
<div><span style="font-size:16px">Finally, we got it.<br>
</span><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0116.aurelia_2D00_output.png"><img src=":-0116.aurelia_2d00_output.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</div>
<h1>References</h1>
<div>
<ul>
<li><span style="font-size:16px"><a title="Aurelia -Docs" href="http://aurelia.io/hub.html#/doc/persona/developer" target="_blank">Aurelia - Docs</a></span>
</li><li><span style="font-size:16px"><a title="jspm Docs" href="http://jspm.io/" target="_blank">jspm - Docs</a></span>
</li><li><span style="font-size:16px">You can read this article in&nbsp;<a title="RajeeshMenoth Blog" href="https://rajeeshmenoth.wordpress.com/2017/01/14/create-an-aurelia-single-page-applications-in-asp-net-core-1-0/" target="_blank">RajeeshMenoth Blog</a></span>
</li></ul>
<h1>Conclusion</h1>
<div><span style="font-size:16px">We learned how to create an Aurelia single page application in ASP.NET Core 1.0 and I hope you liked this article. Please share your valuable suggestions and feedback.</span></div>
</div>
