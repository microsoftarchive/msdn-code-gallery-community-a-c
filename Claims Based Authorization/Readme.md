# Claims Based Authorization
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
- 10/22/2012
## Description

<h1>Overview</h1>
<p class="MsoNormal">This sample will show you how to use the Claims Authorization Module provided by WIF for enabling claims based authorization. You will see how to create a class for use with the Claims Authorization Manager to specify policy in config
 for controlling access to pages in an ASP.NET Web Application.</p>
<p class="MsoNormal">In addition this sample shows the basics of how claims have been integrated into the .NET framework. You will learn how a web application is enabled to use WIF. You will see how they are useful from within existing properties and functions,
 and how you can take the next step to using them directly using the ClaimsPrincipal class in System.Security.Claims. You also will also learn how to work with the local STS that is part of the Identity and Access tool for Visual Studio 2012.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">You must have the <a href="http://go.microsoft.com/fwlink/?LinkID=245849">
Identity and Access Tool for Visual Studio 2012</a> installed. You can find this via the Extension Manager or download it directly from Visual Studio Gallery.</p>
<h1>How To Run</h1>
<p class="MsoNormal">To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5. This page allows anonymous access; the other pages in this web application require authentication and specific claim types
 for access. By default this application is configured to use the Local STS that will issue claims to you as soon as authentication in the application is required. By default you should be able to access the Developers page. You should not initially be able
 to access the Administrators page; if you try you will get a 401 unauthorized error. You can see the claims associated with your user here.</p>
<h1>Claims Authorization Details</h1>
<p class="MsoNormal">Access to the pages is controlled via web.config settings for specific claim values using an implementation of the ClaimsAuthorizationManager classthat is part of WIF. You can change the claims issued to you via the Identity and Access
 extension or directly in the Local STS config. For this project there are commented claim values for you to uncomment to allow access to the Administrators page.</p>
<p class="MsoNormal">The Claims Authorization Module is enabled in the web.config. One enabled you can then specify the policies and class to process the claims authorization decisions in system.identityModel\identityConfiguration\claimsAuthorizationManager.
 There you can see that the type has been set to ClaimsAuthorizationLibrary.MyClaimsAuthorizationManager that is defined in the ClaimsAuthorizationLibrary project in the solution. The specific policies of which claims are required for access to a page are specified
 within the policy sub-element.</p>
<h1>Claims Usage Details</h1>
<p class="MsoNormal">This sample has already been configured to use WIF via the Identity and Access tool which added the required sections to the web.config. Take a look at t<a name="_GoBack"></a>he configuration tab in the tool by choosing Identity and
 Access option from the project context menu, or look at the system.identitymodel and system.identitymodel.services sections in the web.config.</p>
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
