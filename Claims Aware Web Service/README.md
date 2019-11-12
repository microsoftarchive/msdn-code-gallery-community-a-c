# Claims Aware Web Service
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
 using the latest technology in&nbsp;<a href="https://github.com/AzureADSamples/WebApp-WebAPI-OpenIDConnect-DotNet" target="_blank">WebApp-WebAPI-OpenIDConnect-UserIdentity-DotNet</a>.</span></h1>
<div></div>
<h1>Overview</h1>
<p class="MsoNormal">This sample will show you how claims have been integrated into the .NET framework. You will learn how a WCF web service is enabled to use WIF. You will see how to use claims using the ClaimsPrincipal class in <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Security.Claims.aspx" target="_blank" title="Auto generated link to System.Security.Claims">System.Security.Claims</a> and
 to configure your service to enable WIF. You also will also learn how to work with the local STS that is part of the Identity and Access tool for Visual Studio 2012.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">You must have the <a href="http://go.microsoft.com/fwlink/?LinkID=245849">
Identity and Access Tool for Visual Studio 2012</a> installed. You can find this via the Extension Manager or download it directly from Visual Studio Gallery.</p>
<h1>How To Run</h1>
<p class="MsoNormal">To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5. When you do you will see a web page pop up with a directory listing for the WCF service and a command line window. You
 may also see a tray notification that the Local STS has started. The command line window is waiting for ENTER to be pressed. When it is you will see an echo from the WCF service of &quot;Hello World&quot; followed by the claims sent to authenticate the client. Pressing
 any key will close the command window, closing the browser will exit debug mode.</p>
<p class="MsoNormal">Please note: if when you hit F5 you notice that VS starts only one project, please stop the debugger, right click on the solution in Solution Explorer, and choose &quot;Set StartUp Projects...&quot;. In the dialog select &quot;Multiple Startup Projects&quot;,
 and assign the action &quot;Start&quot; to both &quot;Client&quot; and ClaimsAwareWebService&quot;. Hit OK, then prss F5 again.</p>
<h1>Details</h1>
<p class="MsoNormal">This sample has already been configured to use WIF via the Identity and Access tool which added the required sections to the web.config of the WCF service. Take a look at the configuration tab in the tool by choosing Identity and Access
 option from the project context menu, or look at the <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/system.identitymodel.aspx" target="_blank" title="Auto generated link to system.identitymodel">system.identitymodel</a> and <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/system.identitymodel.services.aspx" target="_blank" title="Auto generated link to system.identitymodel.services">system.identitymodel.services</a> sections in the web.config. Note that a test certificate has been added for use in application development as well. You should not add this cert to
 your trusted store; instead for development we disable certificate validation as you can see in the service behaviors.</p>
<p class="MsoNormal">Note that the identity and access tooling does not configure your client application. The client was configured via adding a normal service reference. Note the app.config has the same certificate reference and certificate validation has
 been disabled in the endpoint behaviors. In the WsFederation binding you can see the configuration that enables use of the Local STS.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">So where is the user in this sample from? Where are they being authenticated? This sample is configured to use the Local STS that is part of the Identity and Access Tool for Visual Studio 2012. The Local STS is an Identity Provider for
 testing purposes so you can build your application without needing to configure or connect to an Identity Provider. As this is used only for testing it does not actually authenticate a user. It simply issues a security token with the claims it is configured
 with whenever an application asks. You can configure the Local STS from the Identity and Access context menu to add other claims, set a different port or an alternate token type.</p>
<h1>Troubleshooting</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I get an error that a certificate cannot be found.</p>
<p class="MsoListParagraphCxSpMiddle">The Identity and Access tool installs a certificate in your personal store for testing purposes with WCF the first time it is run on a WCF project. Choose Identity and Access option from the project context menu and select
 OK and the certificate will be installed. This only needs to be done once. <a name="_GoBack">
</a></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I get an error from the Local STS when I hit F5</p>
<p class="MsoListParagraphCxSpMiddle">You need to run VS in admin mode to use the Local STS as it needs to be able to open ports to function.</p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I get a stack trace in the client when I hit F5</p>
<p class="MsoListParagraphCxSpLast">You may have been too quick. Make sure you see the Local STS running in the tray before pressing enter. If you get this error restart the app.</p>
<h1>Security Considerations</h1>
<p class="MsoNormal">For illustrative purposes this sample application shows all the properties of claims (i.e. claim types and claim values), which are issued by a security token service (STS). In production code, security implications of echoing the properties
 of claims should be carefully considered. For example, some of the security considerations are: (i) accepting only claim types that are expected by the applications; (ii) sanitizing the claim properties before using them; and (iii) filtering out claims that
 may contain sensitive personal information. DO NOT use this sample code &lsquo;as is&rsquo; in production code.</p>
<h1>References</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245850">Windows Identity Foundation .NET 4.5 Reference documentation</a></p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245849">Identity and Access Tool for Visual Studio 2012</a></p>
