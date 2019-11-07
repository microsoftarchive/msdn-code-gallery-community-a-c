# Claims Aware MVC Application
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Identity Foundation
- ASP.NET MVC 4
## Topics
- claims-based authentication
## Updated
- 01/10/2015
## Description

<h1><span style="color:#ff0000">NOTE: This sample is outdated. The technology, methods, and/or user interface instructions used in this sample are still supported, but have been succeeded by newer features. &nbsp;The scenario addressed by this sample is accomplished
 using the latest technology in&nbsp;<a href="https://github.com/AzureADSamples/WebApp-OpenIDConnect-DotNet" target="_blank">WebApp-OpenIDConnect-DotNet</a>.</span></h1>
<div></div>
<h1>Overview</h1>
<p class="MsoNormal">This sample will show you how claims have been integrated into the .NET framework. You will learn how to enable an MVC application to use WIF to protect a specific page (as opposed to the entire site) allowing you to retain control of
 your login experience.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">You must have the <a href="http://go.microsoft.com/fwlink/?LinkID=245849">
Identity and Access Tool for Visual Studio 2012</a> installed. You can find this via the Extension Manager or download it directly from Visual Studio Gallery.</p>
<h1>How To Run</h1>
<p class="MsoNormal">To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5. When you do you will see a page with a link to go to a protected Admin page. Note that in the header it says &quot;Anonymous&quot;
 as you are not authenticated yet. Selecting the Admin link will redirect you to the login page to authenticate. There you have a Log In button that will send a request to the Local STS which will authenticate you by issuing a security token. You will be redirected
 back to the Admin page you were trying to access after this occurs where you will see claim values from the security token displayed; name, last name and email address. These claims were mapped into properties of the account model.</p>
<h1>Details</h1>
<p class="MsoNormal">This sample has already been configured to use WIF via the required sections to the web.config. Take a look at the system.identitymodel and system.identitymodel.services sections in the web.config. Note that since we are only requiring
 authentication for a specific page authentication is set to allow, not deny, anonymous users in the web.config.</p>
<p class="MsoNormal">The Admin controller has the action for the Index decorated with [Authorize] which requires you to be authenticated before you can view it. This redirects you prior to logging in to the Login page.</p>
<p class="MsoNormal">The Login view prepares a form that triggers the Login controller SignIn action. There we call the WSFederationAuthenticationModule.SignIn method that WIF provides in System.IdentityModel.Services. This sends a WSFederation protocol message
 to the Local STS to perform authentication (a bit more on that below). When this is completed we are returned to the Login page as the protocol redirection sees that as the origin of the request. To complete the redirection we capture the return URL in Application_EndRequest
 of the Global.asax to redirect back to the originally requested Admin page.</p>
<p class="MsoNormal">The Admin controller now checks that the user is authenticated and creates a ClaimsPrincipal from the current user to populate the UserModel with. The Admin view then displays these values. Notice that the user name is now displayed in
 the header on the Admin and Home page when you navigate back there. This is displayed from the User.Identity.Name property from the name claim that WIF processed and integrated into the current user principal.</p>
<p class="MsoNormal">So where is the user in this sample from? Where are they being authenticated? This sample is configured to use the Local STS that is part of the Identity and Access tool for Visual Studio 2012. The Local STS is an Identity Provider for
 testing purposes so you can build your application without needing to configure or connect to an Identity Provider. As this is used only for testing it does not actually authenticate a user. It simply issues a security token with the claims it is configured
 with whenever an application asks. You can configure the Local STS from the Identity and Access context menu to add other claims, set a different port or an alternate token type.</p>
<h1>Troubleshooting</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I get an error from the Local STS when I hit F5</p>
<p class="MsoListParagraphCxSpMiddle">You need to run VS in admin mode to use the Local STS as it needs to be able to open ports to function.</p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I have to login to see any page, not just the admin page.</p>
<p class="MsoListParagraphCxSpLast">Check that the authorization section in web.config is set to allow users, not deny users.</p>
<h1>Security Considerations</h1>
<p class="MsoNormal">For illustrative purposes this sample application shows all the properties of claims (i.e. claim types and claim values), which are issued by a security token service (STS). In production code, security implications of echoing the properties
 of claims should be carefully considered. For example, some of the security considerations are: (i) accepting only claim types that are expected by the applications; (ii) sanitizing the claim properties before using them; and (iii) filtering out claims that
 may contain sensitive personal information. DO NOT use this sample code &lsquo;as is&rsquo; in production code.</p>
<h1>References</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245850">Windows Identity Foundation .NET 4.5 Reference documentation</a></p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245849">Identity and Access Tool for Visual Studio 2012</a><a name="_GoBack"></a></p>
