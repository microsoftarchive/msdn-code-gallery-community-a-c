# Best Practices for ASP.NET MVC Application
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- WCF
- themes
- Entity Framework
- ASP.NET MVC 3
- Razor
- Theme
- Code First
- Windows Communication Foundation
- Plugin
- Publisher/Subscriber
- Inversion of Control / Dependency Injection
- Plugin framework
- autofac
- DDD
- multi themes
- ioc
- Dependency Injection
- Inversion of Control
- Domain Driven Design
- EF code first
- SOA
- Service Oriented Architecture
- DCI
- Data Context Interaction
- autofac integrated with wcf
- automapper
- DotNetOpenAuth
- DotNetOpenAuth2
## Topics
- Software Architecture
- Web Architecture
- Service Architecture
## Updated
- 05/18/2012
## Description

<h1>Introduction</h1>
<p><em>By many years, I always tried to implemented the best sulotion for .NET, specific on C#. Some of my concerns are how we can manage good data access technical, how we can make the plugin framework for easilly maintain and work on big team, how we have
 multi-thems, multi-languages in one site. And now I am really happy, because I can introduce it in this example code.</em></p>
<h2 class="endscriptcode"><span><strong><span>Project Status:</span></strong></span>&nbsp;<span style="color:#ff0000">I<strong>n progress</strong></span></h2>
<h2 class="endscriptcode"><span style="color:#000000"><strong>History:</strong></span></h2>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<ul>
<li><span style="color:#ff0000"><strong><span style="text-decoration:underline">Version 0.5 (18-05-2012):</span></strong>&nbsp;finished integration for Twitter &amp; Google login. Improved for login model. Refactoring all actions related to authentication to
 DCI patterns</span> </li><li><strong><em><span><strong><em><em><strong><em><strong>Version 0.4 (09-05-2012):</strong></em>&nbsp;</strong></em></em></strong></span>Add login with social network accounts using DotNetOpenAuth version 2. Improve DCI architecture on this example.<em>&nbsp;</em><strong><em><strong><strong><strong>&nbsp;</strong></strong><em><strong><em><em><strong><br>
</strong></em></em></strong></em></strong></em></strong></em></strong></li><li><strong><em><span><strong><em><strong>Version 0.3 (29-04-2012)</strong></em>:</strong></span></em></strong>&nbsp;separated code into service, try to build Domain Event, Pub-sub architecture, and DCI as well.<strong><em><span><strong><br>
</strong></span></em></strong></li><li><strong><em><span><strong><em>Version 0.2 (20-04-2012)</em></strong>:&nbsp;</span></em></strong>add new customized controller, customized razor view engine. I am going to integrating multi-themes on razor, but it is still on processing.<strong><em><br>
</em></strong></li><li><strong><em><span>Version 0.1 (18-04-2012)</span></em></strong>: Plugin framework, data access layer using Entity Framework, Ioc container using Autofac
</li></ul>
</div>
<h1><span>Building the Sample</span></h1>
<ul>
<li><em><a href="http://en.wikipedia.org/wiki/Data_access_layer">Data Access Layer</a> (EF with best practices)</em>
</li><li><em><a href="http://en.wikipedia.org/wiki/Plug-in_(computing)">Plugin Framework</a> (based on compiled View)</em>
</li><li><em><a href="http://en.wikipedia.org/wiki/Service-oriented_architecture">SOA</a> (Service Oriented Architecture) using Microsoft WCF 4.0</em>
</li><li><em><a href="http://en.wikipedia.org/wiki/Data,_context_and_interaction">DCI</a> (Data Context Interaction)</em>
</li></ul>
<p><span style="text-decoration:underline">.NET components:</span></p>
<ul>
<li><a href="http://en.wikipedia.org/wiki/ADO.NET_Entity_Framework">ADO.NET Entity Framework
</a></li><li><a href="http://www.google.co.uk/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&ved=0CC0QFjAA&url=http%3A%2F%2Fcode.google.com%2Fp%2Fautofac%2F&ei=3rOdT_XrIYm28QPm7tCSDw&usg=AFQjCNETrL3vD8kKlGSMzDTR5y4kbRx76A&sig2=y4x12QQaB4MghHkSNzFbDQ">Autofac</a> for IoC container
</li><li><a href="http://www.google.co.uk/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&ved=0CDYQFjAA&url=http%3A%2F%2Fwww.asp.net%2Fmvc&ei=C7SdT7_XCsaF8gP185ScDw&usg=AFQjCNEjMxN1d69mJvnErcLHq7mcOPAACQ&sig2=pqyz79KYuwDR3baLuR5C5g">ASP.NET MVC 3.0
</a></li><li><a href="http://www.google.co.uk/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&ved=0CD4QFjAA&url=http%3A%2F%2Fmsdn.microsoft.com%2Fen-us%2Fnetframework%2Faa663324&ei=I7SdT-rwGpSr8APUwMyMDw&usg=AFQjCNFYs5AagDZiU_2HYVz3HSCB4jPHgg&sig2=yuwNw0DfYSmDeVc_xUBMyQ">Microsoft
 WCF</a> 4.0 </li><li><a href="http://automapper.org/">AutoMapper</a> </li><li><a href="http://www.dotnetopenauth.net/oauth/dotnetopenauth-4-0-released/">DotNetOpenAuth version 2</a>
</li></ul>
<p><span style="text-decoration:underline">Architecture:</span> <a href="http://en.wikipedia.org/wiki/Domain-driven_design">
Domain Driven Design</a> on design Domain, <a href="http://en.wikipedia.org/wiki/Service-oriented_architecture">
Service Oriented Architecture</a> (SOA)</p>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p><span style="text-decoration:underline"><em><strong><span style="font-size:medium">Solution structure:</span></strong></em></span></p>
<p><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/56968/1/btlsolution.png" alt="" width="301" height="618"></p>
<p><span style="text-decoration:underline"><strong><span style="font-size:medium">Guidance for install service:</span></strong></span></p>
<p>You have to host AppServiceIISHost to IIS as below</p>
<p><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/56967/1/iishost.png" alt="" width="317" height="471"></p>
<p>&nbsp;</p>
<p>As you see, I host AppSecurity as a service on IIS, and host web application into IIS as well.</p>
<p><span style="text-decoration:underline"><em><strong><span style="font-size:medium">Testing service using wcftestclient tool:</span></strong></em></span></p>
<p><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/56969/1/wcftestclient.png" alt="" width="1151" height="341"></p>
<p><span style="text-decoration:underline"><em><strong><span style="font-size:medium">Data Connection String:</span></strong></em></span></p>
<p>You have to change database connection string inside web.config in AppSecurityService point to your database server. I give you an example for this as below</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">&lt;connectionStrings&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add&nbsp;name=<span class="js__string">&quot;DefaultConnection&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;providerName=<span class="js__string">&quot;System.Data.SqlClient&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connectionString=&quot;Server=.\SQLEXPRESS;Database=AdvertisementDB;Integrated&nbsp;Security=false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Persist&nbsp;Security&nbsp;Info=False;User&nbsp;ID=sa;Password=<span class="js__num">123456</span>;Connect&nbsp;Timeout=<span class="js__num">120</span>;MultipleActiveResultSets=True;&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;/connectionStrings&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="text-decoration:underline"><em><strong><span style="font-size:medium">Login with Social network account:</span></strong></em></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">I have updated new features for this sample project. It is login with Social network account using DotNetOpenAuth version 2. As you know, this feature make user is very happy to using your web, because they can use any social account
 (such as facebook, twitter, google, yahoo, linked, windows live,...) to login to your web.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">I have a little demo for this feature as below</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Login page:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/57283/1/loginpage_0.png" alt="" width="922" height="447"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Login page with popup:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/57284/1/loginpage_1.png" alt="" width="608" height="576"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Sign up new user:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/57285/1/loginpage_2.png" alt="" width="617" height="684"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">In the case, you click on facebook icon at login page, it will redirect you to facebook for login like picture as below</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="http://i1.code.msdn.s-msft.com/net-best-practice-samples-4e9b92a4/image/file/57286/1/loginpage_3.png" alt="" width="1007" height="576"></div>
<div class="endscriptcode">After you sign up in facebook page, it will redirect you to Home page.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
