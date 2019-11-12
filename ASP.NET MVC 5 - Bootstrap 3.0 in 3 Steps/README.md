# ASP.NET MVC 5 - Bootstrap 3.0 in 3 Steps
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET MVC
- Bootstrap
- ASP.NET MVC 5
## Topics
- C#
- ASP.NET MVC
- Bootstrap
## Updated
- 05/31/2014
## Description

<p lang="en-US"><strong>Introduction</strong></p>
<p><span>This article walks you through the steps for creating a ASP.NET MVC&nbsp; 5 Web Application using Bootstrap as template for layout.</span></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 1 - Create ASP.NET Web Application</strong></p>
<p>&nbsp;</p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2013 and create a new project of type ASP.NET Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called MVCBootstrap.</span>
</li></ul>
<p><img id="115861" src="115861-1.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p><img id="115862" src="115862-2.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p><strong>STEP 2 - Upgrade version if necessary</strong></p>
<p lang="en-US">You can verify the version of bootstrap on two ways.</p>
<p>First one, accessing the files on Content or Scripts folder. If open for example the file Bootstrap.css, we can check that the version of bootstrap is the 3.0.0</p>
<p><img id="115863" src="115863-3.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>Another way to verify the bootstrap version is to check the installed NuGet package.</p>
<ul type="disc">
<li><span>Right click the solution and select&nbsp;</span><span>Manage NuGet packages for solution.</span><span>. option.</span>
</li><li><span>In the Manage NuGet screen, select&nbsp;</span><span>Installed Packages</span><span>&nbsp;section.
</span></li><li><span>Then select the&nbsp;</span><span>bootstrap</span><span>&nbsp;package in the center pane to see the version details.
</span></li></ul>
<p>As you see the version is 3.0.0</p>
<p><img id="115864" src="115864-4.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p><strong>STEP 3 - Change Layout</strong></p>
<p>The default bootstrap&nbsp;template&nbsp;used in&nbsp;Visual Studio 2013&nbsp;is&nbsp;Jumbotron.&nbsp;Jumpotron&rsquo;s original source code is available&nbsp;<a href="http://getbootstrap.com/getting-started/#download">here</a>&nbsp;in bootstrap website.</p>
<p>On this sample we will chabge this template to the Justified-Nav one. So for that do the next steps:</p>
<ul type="disc">
<li><span>Add the style sheet&nbsp;</span><span>justified-nav.css</span><span>&nbsp;to the&nbsp;</span><span>Content</span><span>&nbsp;folder</span>
</li></ul>
<p><img id="115865" src="115865-5.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul type="disc">
<li><span>Open the&nbsp;</span><span>BundleConfig.cs</span><span>&nbsp;file under the&nbsp;</span><span>App_Start</span><span>&nbsp;folder.</span>
</li><li><span>Add the&nbsp;</span><span>justified-nav.css</span><span>&nbsp;to the &ldquo;</span><span>~/Content/css</span><span>&rdquo; style bundle.</span>
</li></ul>
<p><img id="115866" src="115866-6.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul type="disc">
<li><span>Now,&nbsp;open the layout file&nbsp;</span><span>_Layout.cshtml</span><span>&nbsp;in the&nbsp;</span><span>Shared</span><span>&nbsp;folder under&nbsp;</span><span>Views</span><span>&nbsp;Folder</span>
</li><li><span>Remove the section within the&nbsp;</span><span>div</span><span>&nbsp;tag with&nbsp;</span><span>class=&rdquo;navbar navbar-inverse navbar-fixed-top</span>
</li></ul>
<p><img id="115867" src="115867-7.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul type="disc">
<li><span>Open the&nbsp;</span><span>Index.cshtml</span><span>&nbsp;file in the&nbsp;</span><span>Home</span><span>&nbsp;folder under&nbsp;</span><span>Views</span>
</li><li><span>Change the class </span><span>col-md-4</span><span> to</span><span> col-lg-4</span>
</li><li><span>Now the sample is&nbsp;</span><span>ready</span><span>.</span> </li></ul>
<p>&nbsp;</p>
<p>This is the sample created with solution:</p>
<p><img id="115868" src="115868-9.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>This is the sample after our changes:</p>
<p><img id="115870" src="115870-10.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p><img id="115871" src="115871-11.png" alt="" width="400" height="400" style="display:block"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
