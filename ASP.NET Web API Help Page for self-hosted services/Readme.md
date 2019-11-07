# ASP.NET Web API Help Page for self-hosted services
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET Web API
## Topics
- documentation
- ASP.NET Web API
- Web API
## Updated
- 12/20/2012
## Description

<p>This sample shows how to get the <a href="http://blogs.msdn.com/b/yaohuang1/archive/2012/08/15/introducing-the-asp-net-web-api-help-page-preview.aspx">
ASP.NET Web API Help Page</a>&nbsp;working on self-hosted services. Even though <a href="http://blogs.msdn.com/b/yaohuang1/archive/2012/08/15/introducing-the-asp-net-web-api-help-page-preview.aspx">
ASP.NET Web API Help Page</a> is implemented using ASP.NET MVC, which won&rsquo;t work on self-hosted services, most of the code in the package however can be reused to support the generation of Help Page on self host. See this
<a href="http://blogs.msdn.com/b/yaohuang1/archive/2012/12/20/making-asp-net-web-api-help-page-work-on-self-hosted-services.aspx">
blog</a> for more&nbsp;information.</p>
<h1>Web Api Help Page Self Host Sample</h1>
<p>The sample contains two projects: WebApiHelpPageSelfHost.csproj and SampleWebApiSelfHost.csproj. To run the sample, make sure you Enable NuGet Package Restore. (Inside VS, go to Tools -&gt; Options... -&gt; Package Manager -&gt; check &quot;Allow NuGet to download
 missing packages during build&quot; option)</p>
<h3>WebApiHelpPageSelfHost.csproj</h3>
<p>This project contains the source code for the Help Page. All the files come from the
<a href="https://nuget.org/packages/Microsoft.AspNet.WebApi.HelpPage/0.3.0-rc">ASP.NET Web API Help Page package</a>, except for the HelpControllerBase.cs and the files under the View.&nbsp;</p>
<h3>SampleWebApiSelfHost.csproj</h3>
<p>This project contains a self-hosted Web API service with the help page enabled. It references the WebApiHelpPageSelfHost.csproj. You can simply build and run this project to see the self-hosted Help Page in action.</p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/1768.image_5F00_297E1740.png"><img title="image" src="-0285.image_5f00_thumb_5f00_343b6e95.png" border="0" alt="image" width="554" height="281" style="border:0px currentColor; padding-top:0px; padding-right:0px; padding-left:0px; display:inline"></a></p>
<p>Open a browser and go to http://localhost:8080/help to see the following pages.</p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/6165.image_5F00_7405551A.png"><img title="image" src="-8712.image_5f00_thumb_5f00_7ab85e9d.png" border="0" alt="image" width="554" height="398" style="border:0px currentColor; padding-top:0px; padding-right:0px; padding-left:0px; display:inline"></a></p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/3441.image_5F00_680364E6.png"><img title="image" src="-5582.image_5f00_thumb_5f00_405ce8bc.png" border="0" alt="image" width="554" height="398" style="border:0px currentColor; padding-top:0px; padding-right:0px; padding-left:0px; display:inline"></a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
