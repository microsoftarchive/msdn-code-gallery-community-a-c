# Claims Aware Web Farm
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Windows Identity Foundation
## Topics
- claims-based authentication
## Updated
- 01/29/2013
## Description

<h1>Overview</h1>
<p class="MsoNormal">This sample contains settings in the web.config that enable it to run in a web farm environment with a shared session cache, the implementation of which is also part of this sample. This sample also shows the basics of how claims have
 been integrated into the .NET framework. You will learn how a web application is enabled to use WIF. You will see how they are useful from within existing properties and functions, and how you can take t<a name="_GoBack"></a>he next step to using them directly
 using the ClaimsPrincipal class in System.Security.Claims. You also will also learn how to work with the local STS that is part of the Identity and Access tool for Visual Studio 2012.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">You must have the <a href="http://go.microsoft.com/fwlink/?LinkID=245849">
Identity and Access Tool for Visual Studio 2012</a> installed. You can find this via the Extension Manager or download it directly from Visual Studio Gallery.</p>
<h1>How To Run</h1>
<p class="MsoNormal"><span>&nbsp;</span>To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5. When you do you will see the name of an authenticated user displayed in the header and in the body
 of the page. You will also see an email address displayed and a table of claim values for the authenticated user. You will also see the machine name the sample is running on displayed prominently. This will help validate your configuration when deployed behind
 a network load balancer in a web farm. Running locally this value is not expected to change.</p>
<p class="MsoNormal">Please note: if when you hit F5 you notice that VS starts only one project, please stop the debugger, right click on the solution in Solution Explorer, and choose &quot;Set StartUp Projects...&quot;. In the dialog select &quot;Multiple Startup Projects&quot;,
 and assign the action &quot;Start&quot; to both &quot;WebApplication&quot; and &quot;WcfSessionSecurityTokenCacheService&quot;. Hit OK, then prss F5 again.</p>
<h1>Web Farm Details</h1>
<p class="MsoNormal"><span>&nbsp;</span>This sample consists of a solution with three projects.</p>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>CacheLibrary, contains an interface and proxy to the WCF service implemented in the WcfSessionSecurityTokenCacheService that is used in the WebApplication project.</p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>WcfSessionSecurityTokenCacheServic, implements a WCF service that exposes a SessionSecurityTokenCache interface that can be accessed by multiple relying parties. The WIF default, in-memory MruSessionSecurityTokenCache is used as the internal
 cache. Alternatively, this can be implemented as a durable cache backed by a database which would withstand recycles.</p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>WebApplication, a web application that has been configured to use machine key sessions for security tokens (see system.identityModel\identityconfiguration\securitytokenhandlers) and the shared session cache implemented by the CacheLibrary
 project (see system.identityModel\identityconfiguration\sessionSecurityTokenCache).</p>
<p class="MsoNormal">This sample has already been configured to use WIF via the Identity and Access tool which added the required sections to the web.config. Take a look at the configuration tab in the tool by choosing Identity and Access option from the
 project context menu, or look at the system.identitymodel and system.identitymodel.services sections in the web.config.</p>
<p class="MsoNormal">This application has been validated in a web farm environment; the instructions for how to do so are beyond the scope of this sample and would depend heavily on your deployment environment. Note that to deploy in a web farm environment
 you will need an identity provider other than the Local STS as it is not suitable for such a topology.</p>
<h1>Claims Usage Details</h1>
<p class="MsoNormal">In the body of the page the name is displayed using the Page.User.Identity.Name property. In the header the name is displayed using the LoginName control. The value itself is from a claim that the Windows Identity Foundation processed
 from a security token and integrated into the current user principal. Other claims can also be sent in a security token. These claims can be accessed directly, for example the email address displayed in the body is another claim in the security token. That
 is accessed in the code behind of default.aspx page by creating a ClaimsPrincipal from the current user. You can see all of the claims returned in the security token below in the GridView where we have used the ClaimsPrincipal as the data source in the code
 behind.</p>
<p class="MsoNormal">So where is the user in this sample from? Where are they being authenticated? This sample is configured to use the Local STS that is part of the Identity and Access Tool for Visual Studio 2012. The Local STS is an Identity Provider for
 testing purposes so you can build your application without needing to configure or connect to an Identity Provider. As this is used only for testing it does not actually authenticate a user. It simply issues a security token with the claims it is configured
 with whenever an application asks. You can configure the Local STS from the Identity and Access context menu to add other claims, set a different port or an alternate token type.</p>
<h1>Troubleshooting</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I get an error from the Local STS when I hit F5</p>
<p class="MsoListParagraphCxSpLast">You need to run VS in admin mode to use the Local STS as it needs to be able to open ports to function.</p>
<h1>Security Considerations</h1>
<p class="MsoNormal">For illustrative purposes this sample application shows all the properties of claims (i.e. claim types and claim values), which are issued by a security token service (STS). In production code, security implications of echoing the properties
 of claims should be carefully considered. For example, some of the security considerations are: (i) accepting only claim types that are expected by the applications; (ii) sanitizing the claim properties before using them; and (iii) filtering out claims that
 may contain sensitive personal information. DO NOT use this sample code &lsquo;as is&rsquo; in production code.</p>
<h1>References</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245850">Windows Identity Foundation .NET 4.5 Reference documentation</a></p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245849">Identity and Access Tool for Visual Studio 2012</a></p>
<p class="MsoNormal">&nbsp;</p>
