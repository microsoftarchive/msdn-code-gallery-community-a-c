# Claims Aware Web Application
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
- 01/10/2015
## Description

<h1><span style="color:#ff0000">NOTE: This sample is outdated. The technology, methods, and/or user interface instructions used in this sample are still supported, but have been succeeded by newer features. &nbsp;The scenario addressed by this sample is accomplished
 using the latest technology in&nbsp;<a href="https://github.com/AzureADSamples/WebApp-OpenIDConnect-DotNet" target="_blank">WebApp-OpenIDConnect-DotNet</a>.</span></h1>
<div></div>
<h1>Overview</h1>
<p class="MsoNormal">This sample will show you how claims have been integrated into the .NET framework. You will learn how to enable a web application to use WIF. You will see how they are useful from within existing properties and functions, and how you
 can take the next step to using them directly using the ClaimsPrincipal class in System.Security.Claims. You also will also learn how to work with the local STS that is part of the Identity and Access tool for Visual Studio 2012.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">You must have the <a href="http://go.microsoft.com/fwlink/?LinkID=245849">
Identity and Access Tool for Visual Studio 2012</a> installed. You can find this via the Extension Manager or download it directly from Visual Studio Gallery.</p>
<h1>How To Run</h1>
<p class="MsoNormal">To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5. When you do you will see the name of an authenticated user displayed in the header and in the body of the page. You will
 also see an email address displayed and a table of claim values for the authenticated user.</p>
<h1>Details</h1>
<p class="MsoNormal">This sample has already been configured to use WIF via the Identity and Access tool which added the required sections to the web.config. Take a look at the configuration tab in the tool by choosing Identity and Access option from the
 project context menu, or look at the <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/system.identitymodel.aspx" target="_blank" title="Auto generated link to system.identitymodel">system.identitymodel</a> and <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/system.identitymodel.services.aspx" target="_blank" title="Auto generated link to system.identitymodel.services">system.identitymodel.services</a> sections in the web.config.</p>
<p class="MsoNormal">In the body of the page the name is displayed using the Page.User.Identity.Name property. In the header the name is displayed using the LoginName control. The value itself is from a claim that the Windows Identity Foundation processed
 from a security token and integrated into the current user principal. Other claims can also be sent in a security token. These claims can be accessed directly, for example the email address displayed in the body is another claim in the security token. That
 is accessed in the code behind of default.aspx page by creating a ClaimsPrincipal from the current user. You can see all of the claims returned in the security token below in the GridView where we have used the ClaimsPrincipal as the data source in the code
 behind.</p>
<p class="MsoNormal">So where is the user in this sample from? Where are they being authenticated? This sample is configured to use the Local STS that is part of the Identity and Access Tool for Visual Studio 2012. The Local STS is an Identity Provider for
 testing purposes so you can build your application without needing to configure or connect to an Identity Provider. As this is used only for testing it does not actually authenticate a user. It simply issues a security token with the claims it is configured
 with whenever an application asks. You can configure the Local STS from the Identity and Access context menu to add other claims, set a different port of an alternate token type.</p>
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
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245849">Identity and Access Tool for Visual Studio 2012</a><a name="_GoBack"></a></p>
