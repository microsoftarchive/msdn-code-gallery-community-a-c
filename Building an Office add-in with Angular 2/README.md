# Building an Office add-in with Angular 2
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Office 365
- TypeScript
- Office Add-in
- Angular 2
- Office UI Fabric
## Topics
- Microsoft Office Add-ins
- Office 365
- apps for Office
## Updated
- 09/19/2016
## Description

<h2>Introduction</h2>
<p>This is a sample project showing how to get started building Office <a href="http://dev.office.com/getting-started/addins" target="_blank">
add-ins</a> with Angular 2 and Office UI Fabric.The sample add-in is a task pane add-in for Excel.</p>
<p><img id="159916" src="https://i1.code.msdn.s-msft.com/building-an-office-add-in-a9d506cd/image/file/159916/1/officeaddin1.png" alt=""></p>
<h3>Latest</h3>
<p>This sample has been updated to Angular2 release. If you need earlier versions you can find them
<a href="https://github.com/Useful-Software-Solutions-Ltd/office-addin-with-angular2/tree/18e48af2fc59de50aae94aeb4c029d7ccbae28a8" target="_blank">
here</a>.</p>
<h2>Requirements</h2>
<h3>Tools:</h3>
<ul>
<li><a href="https://nodejs.org/en/" target="_blank">Node.js</a> </li><li><a href="https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs" target="_blank">Visual Studio 2015 Community update 3</a>
</li><li><a href="https://www.visualstudio.com/en-us/features/office-tools-vs.aspx" target="_blank">Office Developer Tools</a>
</li><li><a href="https://www.microsoft.com/en-us/download/details.aspx?id=48593" target="_blank">TypeScript for Visual Studio 2015 latest version</a>
</li></ul>
<h3>NPM Packages:</h3>
<ul>
<li><a href="https://www.typescriptlang.org/#download-links" target="_blank">TypeScript</a>
</li><li><a href="https://github.com/typings/typings" target="_blank">Typings</a> </li></ul>
<div>These need to be installed globally. The setup script will do this (see the installation section).</div>
<h3>Also recommended are:</h3>
<ul>
<li><a href="https://www.visualstudio.com/en-us/features/node-js-vs.aspx" target="_blank">Node.js Tools for Visual Studio 2015</a>
</li><li><a href="https://visualstudiogallery.msdn.microsoft.com/8f2f2cbc-4da5-43ba-9de2-c9d08ade4941" target="_blank">NPM Task Runner</a>
</li><li><a href="https://visualstudiogallery.msdn.microsoft.com/4e84e2cf-2d6b-472a-b1e2-b84932511379" target="_blank">Open Command Line</a>
</li></ul>
<p>Visual Studio is required to be able to debug the add-in any of the Office desktop applications.
<br>
That said you can run this sample using the <strong>lite-server</strong> and use you preferred IDE to work with it.<br>
You can then still use Office Online for in browser debugging (see below).</p>
<h2>Installation</h2>
<p>Download or clone the repo to its own folder. Open a command prompt under the <strong>
./OfficeAddInWithAngular2Web</strong>&nbsp;directory and run the command:</p>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Bash/shell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">bash</span>

<div class="preview">
<pre class="bash">npm&nbsp;run&nbsp;setup</pre>
</div>
</div>
</div>
<div class="endscriptcode">This will install all the required NPM package and typings. If you are using Visual Studio now open the solution and build it.</div>
</div>
<div class="endscriptcode"></div>
<h3 class="endscriptcode">SSL issues</h3>
<p>Office add-ins require HTTPS and browser errors when the localhost certificate is not trusted. Make sure that the certificate being used by
<strong>IIS Express</strong>&nbsp;or <strong>lite-server </strong>is trusted. See
<a href="https://blogs.msdn.microsoft.com/robert_mcmurray/2013/11/15/how-to-trust-the-iis-express-self-signed-certificate/" target="_blank">
this post</a> for more information.</p>
<h2>Running the add-in</h2>
<h3>In Excel Online</h3>
<div>Either run start the <strong>OfficeAddInWithAngular2Web</strong> project&nbsp;in VS or from the
<strong>OfficeAddInWithAngular2Web</strong> directory&nbsp;run</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Bash/shell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">bash</span>

<div class="preview">
<pre class="bash">npm&nbsp;start<br></pre>
</div>
</div>
</div>
</div>
<p>Open up a new workbook in Excel Online. Click on the <strong>INSERT</strong> tab and then
<strong>Office Add-ins</strong>. On the Office Add-ins dialog click <strong>Upload my Add-In</strong> and select
<strong>OfficeAddInWithAngular2.xml</strong> which can be found under <br>
<strong>./OfficeAddInWithAngular2/OfficeAddInWithAngular2Manifest</strong>. The add-in will now be available on the
<strong>HOME</strong> tab and you can&nbsp;<strong>F12</strong> to debug the addin in browser.</p>
<h3>In Excel desktop</h3>
<div></div>
<div>In Visual Studio 2015 build the project and run it Visual Studio will load the add-in in Excel and allow you to debug in the IDE.</div>
<div>
<h2>Resources</h2>
<div></div>
<div></div>
<div>This sample is more of a reference project for people who are already familiar with Office add-ins, Angular 2 and TypeScript than a tutorial so if you need to get up to speed with anything here are some good resources.</div>
</div>
<div></div>
<ul>
<li><a href="https://angular.io/docs/ts/latest/quickstart.html" target="_blank">Angular 2</a>
</li><li><a href="https://www.typescriptlang.org/docs/tutorial.html" target="_blank">TypeScript</a>
</li><li><a href="http://dev.office.com/fabric/get-started" target="_blank">Office UI Fabric</a>
</li><li><a href="https://dev.office.com/getting-started/addins" target="_blank">Office Add-ins</a><strong>&nbsp;</strong><em>&nbsp;</em><strong>&nbsp;</strong><em>&nbsp;</em>
</li></ul>
<div></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode"></div>
