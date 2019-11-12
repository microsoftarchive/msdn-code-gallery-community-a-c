# ASP.NET MVC Application with Custom Bootstrap layout - VS 2015, 2013, 2012
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
- Bootstrap
- CSS
- HTML5/JavaScript
## Topics
- C#
- ASP.NET MVC
- Bootstrap
- HTML5/JavaScript
## Updated
- 01/18/2017
## Description

<h1>Background</h1>
<p style="text-align:justify"><span style="font-size:small">Bootstrap is the most popular HTML, CSS, and JS framework for developing responsive, mobile first projects on the web. It provides a default a layout, fonts and JavaScript widgets like accordion /
 carousel and many more. You can either take the default boostrap.css to implement bootstrap in your web application or you can use custom bootstrap themes available for free or purchase premium themes. In this article I will show how you can easily change
 the default ASP.NET MVC layout and apply custom bootstrap theme / layout to your MVC web application.</span></p>
<p style="text-align:justify"><span style="font-size:small">This article is developers having experience working on ASP.NET MVC web application and has knowledge on bootstrap, CSS, HTML, JavaScript and JQuery.</span></p>
<h1 style="text-align:justify">Introduction</h1>
<p style="text-align:justify"><span style="font-size:small">In this article I will show how to create an ASP.NET MVC web application with a custom bootstrap theme / layout. For this demo I am using Visual Studio 2012, ASP.NET MVC 4, a custom bootstrap theme
 (<strong><em>bootstrap business casual</em></strong>).</span>&nbsp;</p>
<h1 style="text-align:justify"><span>Getting Started</span></h1>
<p style="text-align:justify"><span style="font-size:small">This tutorial is can be used for
<strong><em>VS 2012 and VS 2013 and VS 2015. &nbsp;</em></strong>For VS 2015 &ndash; there is a slight difference, the default ASP.NET MVC web application project comes with bootstrap installed (see Fig.1) and the ASP.NET MVC template is the bootstrap template
 &ndash; <strong><em>jumbotron </em></strong>(see Fig.2).You need to first uninstall current / default bootstrap version and jQuery package using NuGet package manager and then follow below steps to implement custom bootstrap theme.</span></p>
<p style="text-align:justify"><img id="159753" src="159753-fig%201.png" alt="" width="353" height="500"></p>
<p style="text-align:justify"><img id="159754" src="159754-fig%202.png" alt="" width="700" height="500"></p>
<p style="text-align:justify"><span style="font-size:small">For creating an ASP.NET MVC web application with custom bootstrap theme:</span></p>
<p style="text-align:justify"><span style="font-size:small">Step I &ndash; Download the bootstrap theme you intend to implement in you ASP.NET MVC application and keep it ready. (You may need to extract the files from zip folder in to a separate folder). For
 this demo I am using a custom bootstrap theme - <strong><em>Business casual</em></strong>, I have downloaded the theme from following website
<a href="https://startbootstrap.com/template-overviews/business-casual/">https://startbootstrap.com/template-overviews/business-casual/</a> .</span></p>
<p style="text-align:justify"><span style="font-size:small">Step II &ndash; Create an ASP.NET MVC web application, follow the steps mentioned below.
</span></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Open VS 2012 / VS 2013 / VS 2015 and create new project select web &ndash; ASP.NET MVC 4 web application.</span>
</li><li style="text-align:justify"><span style="font-size:small">Enter project name &ndash;&ldquo;<strong>ASPNETMVC_BootstrapCustomThemeDemo</strong>&rdquo;. Click ok</span>
</li><li style="text-align:justify"><span style="font-size:small">Select &lsquo;<strong>Internet template&rsquo; (VS 2012 / VS 2013)</strong> and click ok. Select &lsquo;<strong>MVC&rsquo;</strong> for
<strong>VS 2015</strong></span> </li><li style="text-align:justify"><span style="font-size:small">The custom bootstrap I am about to implement has a
<em>Blog menu</em> and a <em>Blog.html page</em>, so I have created a <em>Blog.cshtml</em> view and an
<em>Action</em> for the same in <em>HomeController</em>, also added the blog menu in
<em>_layout.cshtml</em>. ( see Fig.3)</span> </li><li style="text-align:justify"><span style="font-size:small">After the project is created, just press F5 to run the application and in the web browser you would find the default ASP.NET MVC application template displayed. (see Fig.3)</span>
</li></ul>
<p><img id="159755" src="159755-fig%203.png" alt="" width="700" height="500"></p>
<p style="text-align:justify"><span style="font-size:small">Step III- To implement the Custom Bootstrap them in your ASP.NET MVC Web application.</span></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">As we are going to implement the bootstrap CSS frame work we do not need this
<em>Site.css</em>, so the first thing you need to do is open the Site.css file and delete all the content from this file (See Fig.4), then save the file and close it. We would need this file to override the bootstrap CCS elements.</span>
</li></ul>
<p><img id="159757" src="159757-fig%204.png" alt="" width="700" height="400"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next open the Custom theme folder
<em>(startbootstrap-business-casual-gh-pages<strong>)</strong></em>, you would see few files and folders &ndash; you need to copy the
<em>CSS, fonts<strong> </strong></em>and<strong><em> </em></strong><em>img folder</em> to the MVC application
<em>Content</em> folder ( See Fig.5)</span> </li></ul>
<p><img id="159758" src="159758-fig%205.png" alt="" width="700" height="457"></p>
<p>&nbsp;</p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next open the <em>js</em> folder inside the Custom theme folder copy all the
<em>JavaScript</em> files from this folder to the MVC application <em>Scripts</em> folder ( see Fig 6)</span>
</li></ul>
<p><img id="159759" src="159759-fig%206.png" alt="" width="700" height="372"></p>
<p>&nbsp;</p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next got to <em>Visual Studio</em> and on the top of Solution explorer bar, Click on &ldquo;<em>Show All files<strong>&rdquo;</strong></em> option to view the files and folders we copied to the project
 folders ( see Fig. 7)</span> </li></ul>
<p><img id="159760" src="159760-fig%207.png" alt="" width="349" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next, to make files and folders part of the project - Right click on each of them and &nbsp;select option &ldquo;<em>Include in Project</em>&rdquo; (see Fig.8)&nbsp;</span>
</li></ul>
<p><img id="159761" src="159761-fig%208.png" alt="" width="500" height="400"></p>
<p style="text-align:justify"><span style="font-size:small">Step IV- To configure the ASP.NET MVC web application with the custom bootstrap theme:</span></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">In the Solution Explorer, Open the
<em>BundleConfig.cs</em> file under <em>App_Start</em> folder, and add the following to the
<em>bundle</em><em>configs</em> (see Fig. 9)</span> </li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">bundles.Add(new&nbsp;ScriptBundle(&quot;~/bundles/jquery&quot;).Include(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;~/Scripts/jquery.js&quot;));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bundles.Add(new&nbsp;ScriptBundle(&quot;~/bundles/bootstrap&quot;).Include(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;~/Scripts/bootstrap.js&quot;));&nbsp;
&nbsp;
bundles.Add(new&nbsp;StyleBundle(&quot;~/Content/css&quot;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Include(&quot;~/Content/site.css&quot;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Include(&quot;~/Content/bootstrap.css&quot;));&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><img id="159763" src="159763-fig%209.png" alt="" width="700" height="500"></p>
<p>&nbsp;</p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next open the index.html file from custom theme folder and update the _layout.cshtml view of the MVC application.
<em>Note: <span style="text-decoration:underline">Almost all custom themes are designed with a generic layout, so much of the elements / components are repeated in each page, as a developer for MVC we need to separate out the code that is repeated and would
 go in layout page and the code that would go in the index page.</span></em></span>
</li><li style="text-align:justify"><span style="font-size:small">Copy the head section from the index.html page to the _layout.cshtml and make the changes ( see Fig. 10)</span>
</li></ul>
<p><img id="159764" src="159764-fig%2010.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next Replace the Header tag section inside body tag in _layout.cshtml with the nav tag from index.html (see below). Also make the following changes to the relative path of the images and add the @html.ActionLink()
 for each of the views, also do the highlighted changes (see Fig. 11)</span> </li></ul>
<p><img id="159765" src="159765-fig%2011.png" alt="" width="700" height="500"></p>
<ul>
<li><span style="font-size:small">Next scroll down and replace the footer Section inside the body tag in _layout.cshtml with footer tag from index.html (see Fig. 12) and save the changes.</span>
</li></ul>
<p><img id="159766" src="159766-fig%2012.png" alt="" width="700" height="450"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next setting up the Index.cshtml view &ndash; for this copy only the container section below nav-bar and paste it into Index.cshtml (see Fig. 13). Note: we would not copy the nav-bar the footer section
 as it is already present in our _layout.cshtml. Also make sure you reference the _layout.cshtml at the top (see below), as it contains the nav-bar and footer details</span>
</li></ul>
<p><img id="159767" src="159767-fig%2013.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">As the Index.cshtml is having Carousel, we need to add the jquery.js and bootstrap.js and also the jquery script for Carousel (see Fig. 14) at the bottom of the index.cshtml view</span>
</li></ul>
<p><img id="159768" src="159768-fig%2014.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next setting up the About.cshtml view &ndash; for this open the about.html file, copy only the container section below nav-bar and paste it into About.cshtml (see Fig. 15). Note: we would not copy
 the nav-bar the footer section as it is already present in our _layout.cshtml. Also make sure you reference the _layout.cshtml at the top (see below), as it contains the nav-bar and footer details</span>
</li></ul>
<p><img id="159769" src="159769-fig%2015.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Next setting up the Contact.cshtml view &ndash; for this open the contact.html file, copy only the container section below nav-bar and paste it into Contact.cshtml (see Fig. 16). Note: we would not
 copy the nav-bar the footer section as that is already present in our _layout.cshtml. Also make sure you reference the _layout.cshtml at the top (see below), as it contains the nav-bar and footer details</span>
</li></ul>
<p><img id="159770" src="159770-fig%2016.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Finally setting up the Blog.cshtml view &ndash; for this open the blog.html file, copy only the container section below nav-bar and paste it into Blog.cshtml (see Fig. 17). Note: we would not copy
 the nav-bar the footer section as that is already present in our _layout.cshtml. Also make sure you reference the _layout.cshtml at the top (see below), as it contains the nav-bar and footer details</span>
</li></ul>
<p><img id="159772" src="159772-fig%2017.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Close all the .html files and Save all your work.&nbsp; Now , just press F5 to run the application and in the web browser there you go, you will see the ASP.NET MVC application displayed with the
 custom bootstrap template we implemented ( see Fig. 18)</span> </li></ul>
<p><img id="159774" src="159774-fig%2018.png" alt="" width="700" height="500"></p>
<ul>
<li style="text-align:justify"><span style="font-size:small">Few points to note: </span>
<ul>
<li><span style="font-size:small">_layout.cshtml would contain the common elements &ndash; lie the header (logo), Menu and footer- in case of dynamic components make sure to reference the jquery.js and boostrap.js file at the bottom of the page and if required
 some jQuery script. </span></li><li><span style="font-size:small">Make sure you are reference the image and the CSS links properly.</span>
</li></ul>
</li></ul>
<p style="text-align:justify"><span style="font-size:small">This completes the steps required for creating an ASP.NET MVC web application with a custom bootstrap theme.&nbsp;</span></p>
<p style="text-align:justify"><span style="font-size:small">Request you to Please rate and add comments..</span></p>
<p style="text-align:justify"><span style="font-size:small">Thanks,</span></p>
<p style="text-align:justify"><span style="font-size:small">Hussain Patel</span></p>
