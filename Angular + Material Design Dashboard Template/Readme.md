# Angular + Material Design Dashboard Template
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- d3
- TypeScript
- Angular 5
- Angular Material
- INQStats
- c3
## Topics
- data visualization
- web application
- Web App
- dashboard
- Sample App
## Updated
- 01/30/2018
## Description

<h1>Introduction</h1>
<p>This is an Angular 5 (TypeScript) &#43; Material Design responsive dashboard using d3.js/c3.js wrapped in a Visual Studio solution. Additionally, it demonstrates the usage of
<a href="http://inqstats.inqubu.com/" target="_blank">INQStats</a>, an open API to retrieve demographic data from all countries of the world.</p>
<p><img id="187509" src="187509-screen.gif" alt="" width="500"></p>
<h1><span>Getting Started</span></h1>
<h2>1) Prerequisites</h2>
<p>Make sure you have the latest version of Visual Studio installed, you can download the latest version for free
<a href="https://www.visualstudio.com/downloads/" target="_blank">here</a>.&nbsp;Choose at least the ASP.NET and the NodeJS workload when you install VS.</p>
<p>Also, if you haven't done it yet, go to the <a href="https://nodejs.org/en/download/" target="_blank" rel="nofollow">
node.js download page</a> and download &amp; install node.</p>
<h2>2) Set up application<strong>&nbsp;</strong><em>&nbsp;</em></h2>
<p>Download the application.&nbsp;Open a console/terminal and switch to the DashboardTemplate directory (this is the directory where app, bin, package.json, etc. is located). Type</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>
<pre class="hidden">npm install</pre>
<div class="preview">
<pre class="windowsshell">npm&nbsp;install</pre>
</div>
</div>
</div>
<p>to install the necessary node packages. This may take a while.</p>
<h2>3) Get INQStats key and add it to the project</h2>
<p>INQStats is used to retrieve demographic data. Go to the <a href="http://blog.inqubu.com/inqstats-open-api-published-to-get-demographic-data" target="_blank" rel="nofollow">
INQStats API page</a>, enter your name, eMail and a short description and press send - you'll receive an API key. Doubleclick on DashboardTemplate.sln to open the solution. Navigate to app/mainPage/app.service.ts and find the line<strong>
</strong><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">apiKey: string = &quot;&lt;ADD YOUR INQSTATS KEY HERE&gt;&quot;;</pre>
<div class="preview">
<pre class="js">apiKey:&nbsp;string&nbsp;=&nbsp;<span class="js__string">&quot;&lt;ADD&nbsp;YOUR&nbsp;INQSTATS&nbsp;KEY&nbsp;HERE&gt;&quot;</span>;<br></pre>
</div>
</div>
</div>
<p>Paste your INQStats API key here. In Visual Studio, press F5 to start a local webserver, you should now see the application running in a browser.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>&nbsp;</p>
<h1><span>Troubleshooting</span></h1>
<p>If the app gets stuck at the &quot;Loading app&quot; screen, open the browser console (F12) and check for errors. If you see a &quot;ZoneAwareError&quot; saying that d3/index.js cannot be found, delete your browser cache and try again.</p>
<p>If you see the template with empty charts, make sure your INQStats key is set and valid.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p><span><br>
</span></p>
<ul>
</ul>
