# AAL - Windows Store app to REST service - Authentication
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- Windows Azure Access Control Service
- windows azure active directory
- windows azure authentication library
- Windows RT
- Windows Store app
## Topics
- Authentication
- claims-based authentication
- Identity
## Updated
- 01/10/2015
## Description

<h1><span style="font-size:xx-large; color:#ff0000">NOTE: This sample is outdated. The technology, methods, and/or user interface instructions used in this sample are still supported, but have been succeeded by newer features. &nbsp;The scenario addressed by
 this sample is accomplished using the latest technology in&nbsp;</span><a title="NativeClient-WindowsStore" href="https://github.com/AzureADSamples/NativeClient-WindowsStore" target="_blank" style="font-size:xx-large">NativeClient-WindowsStore</a><span style="color:#ff0000; font-size:xx-large">.</span></h1>
<p><strong>Overview</strong><span style="color:black">&nbsp;</span></p>
<p><span style="color:black">This sample demonstrates how to use the Windows Azure Authentication Library (AAL) for Windows Store Beta to add user authentication capabilities to a Windows Store application. Furthermore, it demonstrates how to authenticate calls
 to a Web API REST service by leveraging the JSON Web Token Handler for Microsoft .Net Framework 4.5 (JWT handler).</span></p>
<p class="MsoNormal"><span style="color:black">&nbsp;</span></p>
<p class="MsoNormal"><span style="color:black">AAL is a Windows Runtime Component offering a simple programming model for Windows Azure Active Directory (AAD) in Windows Store applications. Its main purpose is to help developers easily obtain access tokens
 from Windows Azure Active Directory, to be used for requesting access to protected resources such as REST services.</span></p>
<p class="MsoNormal"><span style="color:black">&nbsp;</span></p>
<p class="MsoNormal"><span style="color:black">The JSON Web Token Handler for Microsoft .Net Framework (JWT handler) is a library built on .NET 4.5 which adds the JSON Web token format as a first-class citizen in the .NET programming model. The JWT handler
 can be used both within the WIF pipeline, to secure existing Web sites and services with JWT tokens in addition to the formats supported out of the box (such as SAML1.1 and SAML2). The JWT handler can also be used standalone, with no direct dependencies on
 WIF configuration.&nbsp;</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong>&nbsp;</p>
<p class="MsoNormal"><strong><span>Prerequisites</span></strong><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Windows 8 OS</span></p>
<p class="MsoNormal"><span>Visual Studio 2012</span></p>
<p class="MsoNormal"><span>A working internet connection</span></p>
<p class="MsoNormal"><span>Your own tenant in Windows Azure AD</span></p>
<p class="MsoNormal"><span>Windows 8 developer license</span></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong>&nbsp;</p>
<p class="MsoNormal"><strong><span>Running the Sample</span></strong></p>
<p class="MsoNormal"><span>The sample solution includes two projects:</span></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong>&nbsp;</p>
<p class="MsoNormal"><strong><span>TodoListService</span></strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>This is a .Net 4.5 MVC4 WebAPI&nbsp;project which stores user&rsquo;s todo list items. The APIs exposed by this application use the Json Web Token Security Token Handler to ensure only authorized users or clients can access the
 service.</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong>&nbsp;</p>
<p class="MsoNormal"><strong><span>TodoListClient</span></strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>This is a C#-XAML based Windows Store application which consumes the APIs exposed by the TodoListService for adding and retrieving user&rsquo;s todo items. This also uses
</span><span>Windows Azure Authentication Library (AAL) for Windows Store Beta that allows a user to
</span>authorize access to TodoListService.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">In summary, TodoListClient is a client application that requests an access to a resource i.e. TodoListService using
<span>Windows Azure Authentication Library (AAL) for Windows Store Beta.</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong>&nbsp;</p>
<p class="MsoNormal"><strong><span>Details</span></strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Before running this sample, you will need to register application objects and permission objects in your Windows Azure AD tenant, for the client application (TodoListClient) as well as the resource service (TodoListService). Also,
 you will need to make few code changes in TodoListClient and TodoListService projects, which are explained later in the document.</span></p>
<p class="MsoNormal"><span><span>&nbsp;</span></span></p>
<p class="MsoNormal"><span><span>If you don&rsquo;t have your own Windows Azure AD tenant at this point, please see &ldquo;Create a New Directory Tenant and Add a User&rdquo; section in
</span></span><a href="http://go.microsoft.com/fwlink/?LinkId=296708"><span><span>Windows Store app walk through</span></span></a><span><span>. You can follow those instructions to set up a new tenant that can be used in this sample.</span></span><span><strong>&nbsp;</strong></span></p>
<p class="MsoNormal"><span><strong>&nbsp;</strong></span>&nbsp;</p>
<p class="MsoNormal"><span><strong>Registering Todo Client and Service with Windows Azure AD</strong></span><strong>&nbsp;</strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>This can be done by using the Windows Azure Management Portal, or by calling directly the Directory Graph API. To use the Windows Azure Management Portal, complete the following steps:</span></p>
<ol>
<li>In a web browser, go to <a href="https://manage.windowsazure.com/">https://manage.windowsazure.com</a>.<br>
<br>
</li><li>In the Windows Azure Management Portal, click on the <strong>Active Directory</strong> icon on the left menu, and then click on your organization&rsquo;s name.
<br>
<br>
</li><li>From the Quick Start menu, click on the <strong>Applications</strong> tab.<br>
<br>
</li><li>On the command bar, click <strong>Add</strong>.<br>
<br>
</li><li>On the first page of the wizard, enter a user friendly name for your web API in the
<strong>Name</strong> field. This name will enable it to be easily identified when looking at registered client applications in your Windows Azure AD directory, so in our case, name it
<em>ToDo List Web API</em>. The <strong>Web Application and/or Web API</strong> option under
<strong>Type</strong> should already be selected, so click the arrow to proceed.<br>
<br>
</li><li>On the next page, enter in the information for the web API&rsquo;s <strong>App URL</strong> and
<strong>App ID URI</strong>. The <strong>App URL</strong> is the address for the web API, and the
<strong>App ID URI</strong> is the logical identifier for the app. In our case, both of these values are the same, so set them to
<em><a href="http://localhost:40316/">http://localhost:40316/</a></em>, and then click the next arrow.<br>
<br>
</li><li>On the next page, select the directory access type that your web API needs. In our case, we are not accessing the Graph API, so you should select
<strong>Single Sign-On</strong>, and then click the checkmark button to finish.<br>
<br>
After you have added your web API, you will need to register your client application. The following steps will show you how to complete this process.<br>
<br>
</li><li>In the Windows Azure Management Portal, go back to the <strong>Applications</strong> tab of your organization&rsquo;s directory.<br>
<br>
</li><li>On the command bar, click <strong>Add</strong>.<br>
<br>
</li><li>On the first page of the wizard, enter a user friendly name for your client application, such as
<em>ToDo List Client</em> and then select the <strong>Native Client Application</strong> option under
<strong>Type</strong>. Click the arrow to proceed.<br>
<br>
</li><li>On the next page, enter the <strong>Redirect URI</strong> for your client application. This is the location where Windows Azure AD will redirect in response to an OAuth 2.0 request. This sample has been configured to use the following value:
<em>ms-app://s-1-15-2-797486421-3941894044-1170908958-3713153935-3493960503-1947744077-2411385664/</em>
<p>After you've entered the value, click the checkmark button.</p>
</li></ol>
<p>Your client application has now been added to Windows Azure AD. The following steps will show you how to configure the client application&rsquo;s access to the web API.</p>
<ol>
<div class="MsoNormal"></div>
<li>The client application&rsquo;s Quick Start page should be displayed. Click <strong>
Configure</strong> on the top menu, and the application configuration page will appear.
</li><li>On the <strong>web apis</strong> section of the configuration page, expand the drop-down menu for
<strong>Configure Web API Access for this Native Client Application</strong>, and then click the
<strong>ToDo List Web API</strong> you previously added. </li><li>After selecting the service, click <strong>Save</strong> on the command bar.&nbsp;&nbsp;
</li></ol>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><strong><span>Configuring sample with real values in the code</span></strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Open the TodoListApp solution file using Visual Studio 2012 and see both the projects listed in Solution Explorer window. Currently this sample makes use of placeholders defined for the fields: domainName, clientID, resourceAppIDUri,
 resourceBaseAddress and audience. These placeholders are represented as &ldquo;[ text ]&rdquo; in the code. You will need to replace them with the real values for those fields.</span></p>
<p class="MsoNormal"><span>Let&rsquo;s start from the client application.</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong>&nbsp;</p>
<p class="MsoNormal"><strong><span>Open the MainPage.xaml.cs file of the TodoListClient project.</span></strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Here, you will find the placeholders for domainName, clientID, resourceAppIDUri and resourceBaseAddress.
</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>Domain name</span></strong><span> (also referred as Tenant name) is used to form an authority endpoint which is required by the
<em>AuthenticationContext</em> constructor.</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>Client ID</span></strong><span> is a unique identifier for your TodoListClient application which is registered in Windows Azure AD for your tenant.
</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>Resource App ID URI</span></strong><span> is
</span>the identifier that will be used by <span>TodoListClient </span>application to identify the target service resource, when requesting authorization for the service from Windows Azure AD.<strong>&nbsp;</strong></p>
<p class="MsoNormal"><strong>&nbsp;</strong></p>
<p class="MsoNormal"><strong>Resource Base Address</strong> is the base address at which TodoListService can be reached.</p>
<p class="MsoNormal"><em>AcquireTokenAsync</em> method gets a security token from the tenant authority, which is issued for TodoListService. The result of this call is stored in the
<em>AuthenticationResult</em> object. The <em>Status</em> property on the <em>AuthenticationResult
</em>object indicates the outcome of the token acquisition operation. On successful authentication,
<em>AccessToken</em> field on the <em>AuthenticationResult </em>object contains the access token received from the authority.<strong>&nbsp;</strong></p>
<p class="MsoListParagraph" style="margin-left:.5in; text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Replace the text</span>
<span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">
[Your domain name. Example: contoso.onmicrosoft.com]</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">with your Windows Azure AD tenant name or domain name in following line of code</span><span>.</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">const</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> domainName =
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">&quot;[Your domain name. Example: contoso.onmicrosoft.com]&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;</span></p>
<p class="MsoListParagraph" style="margin-left:.5in; text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Replace the text</span><span>
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">[Your client id. Example: de119d9a-c0b9-4ac0-b794-ca82e9d7dcd4]
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">with</span><span>
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Client ID that you received in step #4 above, in following line of code.</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">const</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> clientID =
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">&quot;[Your client id. Example: de119d9a-c0b9-4ac0-b794-ca82e9d7dcd4]&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;</span></p>
<p class="MsoListParagraph" style="margin-left:.5in; text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Replace the text</span>
<span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">
[Your service application Uri. Example: http://localhost:40316/]</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">with the URL of the TodoListService application in following line of code. Currently, TodoListService project is configured to have
</span><a href="http://localhost:40316/"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">http://localhost:40316/</span></a><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> as its URL</span><span>.</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">const</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> resourceAppIDUri =
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">&quot;[Your service application Uri. Example:
</span><a href="http://localhost:40316/"><span style="font-size:9.5pt; font-family:Consolas; background:white">http://localhost:40316/</span></a><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">]&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;</span></p>
<p class="MsoListParagraph" style="margin-left:.5in; text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Replace the text</span><span>
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">[The base address at which your service can be reached. Example:
</span><a href="http://localhost:40316/"><span style="font-size:9.5pt; font-family:Consolas; background:white">http://localhost:40316/</span></a><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">]</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">with the base address of the TodoListService application in following line of code. For this sample, the base address is
</span><a href="http://localhost:40316/"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">http://localhost:40316/</span></a><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">.
</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:blue; background:white">const</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:black; background:white"> resourceBaseAddress =
</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:#a31515; background:white">&quot;[The base address at which your service can be reached. Example:
</span><a href="http://localhost:40316/"><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; background:white">http://localhost:40316/</span></a><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:#a31515; background:white">]&quot;</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:black; background:white">;</span></p>
<p class="MsoNormal"><span>Also, you will see in the code that resourceBaseAddress is used to construct the endpoint for web API as:</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:black; background:white">resourceBaseAddress &#43;
</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:#a31515; background:white">&quot;/api/todolist&quot;</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>Now let&rsquo;s take a look at the resource service.</span><strong><span>&nbsp;</span></strong></p>
<p class="MsoNormal"><strong><span>Open the Global.asax.cs file of the TodoListService project.</span></strong><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Here, you will find the placeholders for domainName and audience.</span></p>
<p class="MsoNormal"><strong><span>Audience</span></strong><span> is the </span>
<span>intended target for the token returned by </span><em>AcquireTokenAsync </em>
method<em>.</em><span> In this case it is the application URL of </span><span>TodoListService.</span><strong>&nbsp;</strong></p>
<p class="MsoListParagraph" style="margin-left:.5in; text-indent:-.25in"><span style="font-size:11.0pt; font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Replace the text</span><span>
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">[Your domain name. Example: contoso.onmicrosoft.com]</span>
<span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">with your Windows Azure AD tenant name or domain name in following line of code.</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">const</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> domainName =
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">&quot;[Your domain name. Example: contoso.onmicrosoft.com]&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;</span></p>
<p class="MsoListParagraph" style="margin-left:.5in; text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Replace the text</span>
<span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">
[Your service application Uri. Example: http://localhost:40316/]</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">with the URL of the TodoListService application in following line of code.</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">const</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> audience =
</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515; background:white">&quot;[Your service application Uri. Example: http://localhost:40316/]&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span style="color:black">Another interesting thing to notice in
</span><strong><span>Global.asax.cs </span></strong><span style="color:black">file is the
<em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">TokenValidationHandler class,</span></em> an implementation of DelegatingHandler.
<em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">TokenValidationHandler&lsquo;s
</span></em>purpose is<em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> </span>
</em>to process request messages before they reach the application code and enforce authentication requirements. The method
<em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">TryRetrieveToken</span></em> inspects incoming http requests to verify if the authorization header contains an OAuth2 header with a bearer token. If a bearer token is not found, the request is not authorized.
 If the header contains a bearer token, it is validated through the <em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">JWT handler</span></em>. A
<em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">TokenValidationParameters </span>
</em>object is created to set the expected properties, issuer, audience and signing token, on the token. The information like issuer, token signing certificates is retrieved by reading the federation metadata of the tenant. This is done in
<em>GetTenantInformation</em> method. The method <em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">JWT handler.ValidateToken</span></em> is then called to validate the token and, upon successful validation, a new
<em><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">ClaimsPrincipal</span></em> instance is added as the principal of the current thread.</span><span>&nbsp;</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>Once, all the above steps are performed, you are ready to run the sample. Currently this sample solution is configured to have multiple startup projects. Hence when you hit F5 button, both TodoListClient and TodoListService projects
 will run. To verify this setting, right click the TodoListApp solution in Solution Explorer window, select &ldquo;Properties&rdquo; option. Expand &ldquo;Common Properties&rdquo; and select &ldquo;Startup Project&rdquo; in the left pane, select &ldquo;Multiple
 startup projects&rdquo; option at right, select the &ldquo;Start&rdquo; action from the drop down for TodoListClient and TodoListService. Click &ldquo;Ok&rdquo;.</span><span>&nbsp;</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>When TodoListClient application is launched for the first time, there is no authentication token cached in it. Hence,
</span><em>AcquireTokenAsync</em> method<span> pops up </span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh750287.aspx"><span>Web Authentication Broker</span></a><span> control displaying the Azure AD sign in page in it. You need to enter
 your tenant credentials here.</span>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>After successful authentication, AAL caches both Access token and the Refresh token. The application shows a page to add the Todo items. Type your todo item in the text box and tap the Add Todo button.
</span>AAL is called again, but this time a cached token is returned and it is used to invoke
<span>a web API on the TodoListService to add your new item. Similarly, a web API on the TodoListService is invoked to retrieve the existing todo items. Thus, the application will display all the todo items that are added by you.</span>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>You can close the TodoListClient application by pressing the Alt&#43;F4 key or just switching to another application. Now launch the TodoListClient application again. It will directly navigate you to the main page of the application.
</span>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>You can clear the AAL cache by tapping the Remove Account link on the main page. Now if you choose to add a Todo item, AAL will display the Azure AD sign in page again.</span>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>You can find more detailed information about </span>
<span style="color:black">Windows Azure Authentication Library (AAL) for Windows Store Beta and this sample in
</span><a href="http://go.microsoft.com/fwlink/?LinkId=296708"><span>Windows Store app walk through</span></a><span style="color:black">.</span></p>
