# ASP.NET Core 1.0 and AngularJS - Setup AngularJS
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET
- AngularJS
## Topics
- C#
- ASP.NET
- AngularJS
## Updated
- 06/29/2016
## Description

<div>
<div>
<div>
<p lang="en-US"><strong>Introduction</strong></p>
<p lang="en-US">This demo shows you how to setup Angular on a ASP.NET 5 web application</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 1 - Create ASP.NET 5 Web Application</strong></p>
<p lang="en-US">&nbsp;</p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2015 and create a new project of type ASP.NET 5 Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called Demo.</span> </li></ul>
<p><img id="154275" src="154275-1.png" alt="" width="600" height="400"></p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p><img id="154276" src="154276-2.png" alt="" width="600" height="400"></p>
<p>After selection of our template, your first web application using ASP.NET 5 is created.</p>
<p>&nbsp;</p>
<p><strong>STEP 2 - Configure Angular</strong></p>
<p lang="en-US">To start using AngularJS in your ASP.NET application, you must either install it as part of your project, or reference it from a content delivery network (CDN).</p>
<p lang="en-US"><span lang="pt">You can add AngularJS using the built-in</span><span lang="en-US">&nbsp;</span><a href="https://docs.asp.net/en/latest/client-side/bower.html#bower-index"><span lang="en-US">Bower</span></a><span lang="en-US">&nbsp;support. Select
 Bower folder and choose Manage Bower Package has in the image below.</span></p>
<p lang="en-US"><img id="154280" src="154280-4.png" alt="" width="600" height="300"></p>
<p>Then select Angular and install it on solution.</p>
<p lang="en-US"><img id="154281" src="154281-5.png" alt="" width="600" height="300"></p>
<p>After installation, Angular should appear on lib and Bower Dependencies folder.</p>
<p lang="en-US"><img id="154282" src="154282-6.png" alt="" width="347" height="498"></p>
<p>To finish this setup, we need to reference the angular script on our master page (on this case on _layout.cshtml).</p>
<p lang="en-US">On the body tag just add ng-app directive to indicate that the page is in AngularJS.</p>
<p lang="en-US">Then just to test, I create on the Index.html an expression {{10 &#43; 10}}, that in angular indicate to sum the two operators.</p>
<p lang="en-US">The result is on the image below</p>
<p lang="en-US"><img id="154284" src="154284-7.png" alt="" width="600" height="300"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>References:</strong></p>
<p><a href="https://docs.asp.net/en/latest/client-side/using-gulp.html">https://docs.asp.net/en/latest/client-side/using-gulp.html</a></p>
<p lang="en-US">&nbsp;</p>
</div>
</div>
</div>
