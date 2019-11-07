# ASP.NET Core 1.0 - Change Bootstrap layout in 3 Steps
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET
- Bootstrap
- ASP.NET Core
## Topics
- C#
- Bootstrap
- ASP.NET Core
- ASP:NET
## Updated
- 01/09/2017
## Description

<p lang="en-US"><strong>Introduction</strong></p>
<p><span>This article walks you through the steps for creating a ASP.NET Core Web Application using Bootstrap as template for layout and change it to a new one.</span></p>
<p><strong>STEP 1 - Create ASP.NET Web Application</strong></p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2015 and create a new project of type ASP.NET Core Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called ASPNETCoreBootstrap.</span>
</li></ul>
<p>&nbsp;&nbsp;<img id="166823" src="166823-1.png" alt="" width="600" height="400"></p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option web Application.</span> </li></ul>
<p><img id="166824" src="166824-2.png" alt="" width="600" height="400">&nbsp;</p>
<p><strong>STEP 2 - Upgrade version if necessary</strong></p>
<p lang="en-US">You can verify the version of bootstrap on two ways.</p>
<p>First one, accessing the files on lib\bootstrap\dist\css folder. If open for example the file Bootstrap.css, we can check that the version of bootstrap is the 3.3.6</p>
<p>&nbsp;</p>
<p>Another way to verify the bootstrap version is to check the installed Bower package.</p>
<ul type="disc">
<li><span>Right click the solution and select&nbsp;</span><span>Manage Bower packages for solution.</span><span>. option.</span>
</li><li><span>In the Manage Bower screen, select&nbsp;</span><span>Installed Packages</span><span>&nbsp;section.
</span></li><li><span>Then select the&nbsp;</span><span>bootstrap</span><span>&nbsp;package in the center pane to see the version details.
</span></li></ul>
<p>As you see the version is 3.3.6</p>
<p><img id="166828" src="166828-4.png" alt="" width="600" height="400">&nbsp;</p>
<p lang="en-US"><strong>STEP 3 - Change Layout</strong></p>
<p>The default bootstrap&nbsp;template&nbsp;used in&nbsp;Visual Studio 2015&nbsp;is&nbsp;Jumbotron.&nbsp;Jumpotron&rsquo;s original source code is available&nbsp;<a href="http://getbootstrap.com/getting-started/#download">here</a>&nbsp;in bootstrap website.</p>
<p><span lang="pt">On this sample we will change this template to a free bootstrap template Creative that could be download here:
</span><a href="https://startbootstrap.com/template-overviews/creative/"><span lang="en-US">https://startbootstrap.com/template-overviews/creative/</span></a><span lang="pt">.</span></p>
<p>To made tha t change we need to:</p>
<ul type="disc">
<li><span>Add the style sheet&nbsp;</span><span>creative.css</span><span>&nbsp;to the&nbsp;</span><span>CSS
</span><span>folder</span> </li><li><span>Add the style sheet&nbsp;</span><span>creative.js </span><span>to the&nbsp;</span><span>JS
</span><span>folder</span> </li><li><span>Add the </span><span>img</span><span> folder from template downloaded</span>
</li></ul>
<p><img id="166829" src="166829-5.png" alt="" width="339" height="583"></p>
<p>Now,&nbsp;open the layout file&nbsp;_Layout.cshtml&nbsp;in the&nbsp;Shared&nbsp;folder under&nbsp;Views&nbsp;Folder and copy the content from index.html to layout.cshtml according to your layout</p>
<p>This is the sample created with solution:</p>
<p><img id="166830" src="166830-6.png" alt="" width="600" height="400">&nbsp;</p>
<p>This is the sample after our changes:</p>
<p><img id="166831" src="166831-7.png" alt="" width="600" height="400"></p>
