# ASP.NET Core 2.0 - Apply bootstrap template
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- Bootstrap
- ASP:NET
- ASP.NET Core 2.0
## Topics
- C#
- ASP.NET
- Bootstrap
- ASP.NET Core 2.0
## Updated
- 01/14/2018
## Description

<h1><span style="font-size:medium">Introduction</span></h1>
<p><span>This article walks you through the steps for creating an ASP.NET Core 2.0 Web Application using Bootstrap as the template for layout.</span></p>
<p>&nbsp;</p>
<h1><a name="STEP1_Creating_the_ASP_NET_Core_Project_in_VS_2017"></a><span><a name="STEP1_Creating_the_ASP_NET_Core_Project_in_VS_2017"></a><strong><a name="STEP1_Creating_the_ASP_NET_Core_Project_in_VS_2017"></a><a name="STEP1_Creating_the_ASP_NET_Core_Project_in_VS_2017"></a><span style="font-size:medium">STEP1
 - Creating the ASP .NET Core Project in VS 2017</span></strong></span></h1>
<p lang="en-US"><span>Open VS 2017 and on the File menu click New Project. Then select the Visual C # -&gt; Web template and check ASP .NET Core Web Application (.NET Core).</span></p>
<p lang="en-US">&nbsp;</p>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8561.Image1.png"><img src=":-8561.image1.png" alt=" "></a></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US">Then enter the name AspNetCoreDemo and click OK.</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US">In the next window, choose the ASP .NET Core 2.0 version and mark the Web Application (Model-View-Controller) template without authentication and click the OK button:</p>
<p lang="en-US">&nbsp;</p>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6786.Image2.png"><img src=":-6786.image2.png" alt=" "></a><br>
<br>
</p>
<h1><span><a name="STEP_2_Upgrade_version_if_necessary"></a><span style="font-size:medium">STEP2 - Upgrade version if necessary</span></span></h1>
<p lang="en-US"><span>You can verify the version of bootstrap in</span><span>&nbsp;two ways.</span></p>
<p>First one, accessing the files on wwwroot\lib\bootstrap\dist\css folder. If open for example the file Bootstrap.css, we can check that the version of bootstrap is the 3.3.7</p>
<p>&nbsp;</p>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0636.Image3.png"><img src=":-0636.image3.png" alt=" "></a></p>
<p>&nbsp;</p>
<p>Another way to verify the bootstrap version is to check the installed Bower package.</p>
<p>Just select the bower.json file on the project and check the version.</p>
<p>&nbsp;</p>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1273.Image4.png"><img src=":-1273.image4.png" alt=" "></a></p>
<h1><span style="font-size:medium">STEP3 - Change Layout</span></h1>
<p><a name="STEP_3_Change_Layout"></a><span style="font-size:small">The default bootstrap&nbsp;template&nbsp;used in&nbsp;Visual Studio 2017&nbsp;is&nbsp;Jumbotron.&nbsp;Jumpotron&rsquo;s original source code is available&nbsp;<a href="http://getbootstrap.com/getting-started/#download" target="_blank">here&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a>&nbsp;in
 the bootstrap website.</span>&nbsp;</p>
<p><span lang="pt">On this sample, we will change this template to a free bootstrap template Creative that could be download here:&nbsp;</span><a href="https://startbootstrap.com/template-overviews/creative/" target="_blank"><span lang="en-US">https://startbootstrap.com/template-overviews/creative/</span>&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span lang="pt">.</span></p>
<p>&nbsp;</p>
<p>To make that change we need to:</p>
<ul>
<li><span>Add the stylesheet&nbsp;</span><span>creative.css</span><span>&nbsp;to the&nbsp;</span><span>CSS&nbsp;</span><span>folder</span>
</li><li><span>Add the stylesheet&nbsp;</span><span>creative.js&nbsp;</span><span>to the&nbsp;</span><span>JS&nbsp;</span><span>folder</span>
</li><li><span>Add the image</span><span>&nbsp;folder from template downloaded</span> </li><li><span>Add the css folder from template downloaded</span> </li><li><span>Add the vendor folder from template downloaded</span> </li></ul>
<p>&nbsp;<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/4113.Image5.png"><img src=":-4113.image5.png" alt=" "></a></p>
<p>&nbsp;</p>
<ul>
<li><span>Now,&nbsp;open the layout file&nbsp;</span><span>_Layout.cshtml</span><span>&nbsp;in the&nbsp;</span><span>Shared</span><span>&nbsp;folder under&nbsp;</span><span>Views</span><span>&nbsp;Folder</span>
</li></ul>
<p>&nbsp;</p>
<p>Copy the content from index.html to layout.cshtml according to your layout</p>
<p>&nbsp;</p>
<p>This is the sample created with the solution:</p>
<p>&nbsp;<br>
<span><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1145.Image6.png"><img src=":-1145.image6.png" alt=" "></a>&nbsp;</span></p>
<p lang="en-US">&nbsp;</p>
<p>This is the sample after our changes:</p>
<p>&nbsp;</p>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1537.Image7.png"><img src=":-1537.image7.png" alt=" "></a></p>
