# Claims Aware Forms Authentication
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- .NET Framework
- Windows Identity Foundation
## Topics
- Security
- claims-based authentication
## Updated
- 10/22/2012
## Description

<h1>Overview</h1>
<p class="MsoNormal">This sample will show you how claims have been integrated into the .NET framework. You will see that claims can be accessed using just forms authentication, without separate identity providers, federation or security tokens demonstrating
 consistency of the model across authentication technologies. You will see how they are consistently exposed across existing properties and functions, and how you can take the next step to using them directly using the ClaimsPrincipal class in System.Security.Claims.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">None.</p>
<h1>How To Run</h1>
<p class="MsoNormal">To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5.
<br>
When you do,<a name="_GoBack"></a> you will see a basic ASP.NET web app based on the forms authentication template. From there you can register a user and navigate to a page that will show you claims from the user authenticated with forms authentication.</p>
<h1>Details</h1>
<p class="MsoNormal">In the body of the claims page the name displayed is accessed in the code behind of claims.aspx page by creating a ClaimsPrincipal from the current user rather than using the Page.User.Identity.Name property. In the header the name is
 displayed using the LoginName control. You can see all of the claims returned using forms authentication in the GridView where we have used the ClaimsPrincipal as the data source in the code behind.</p>
<p class="MsoNormal">When registering a new user they are also assigned the role of &quot;developer&quot; that allows them access to the developer page. If that role is not present the user will get an unauthorized page instead.</p>
<h1>Security Considerations</h1>
<p class="MsoNormal">For illustrative purposes this sample application shows all the parameters of claims (i.e. claim types and claim values), which are issued by a security token service (STS). In production code, security implications of echoing the properties
 of claims should be carefully considered. For example, some of the security considerations are: (i) accepting only claim types that are expected by the applications; (ii) sanitizing the claim parameters before using them; and (iii) filtering out claims that
 may contain sensitive personal information. DO NOT use this sample code &lsquo;as is&rsquo; in production code.</p>
<p class="MsoNormal">For illustrative purposes this sample application set the password length to 1. Don't do that.</p>
<h1>References</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245850">Windows Identity Foundation .NET 4.5 Reference documentation</a></p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245849">Identity and Access Tool for Visual Studio 2012</a></p>
