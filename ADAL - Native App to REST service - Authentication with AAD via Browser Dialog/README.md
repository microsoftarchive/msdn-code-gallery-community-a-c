# ADAL - Native App to REST service - Authentication with AAD via Browser Dialog
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- Windows Azure Access Control Service
- windows azure active directory
- windows azure authentication library
## Topics
- Authentication
- claims-based authentication
- Identity
## Updated
- 01/10/2015
## Description

<h1><span style="font-size:xx-large; color:#ff0000">NOTE: This sample is outdated. The technology, methods, and/or user interface instructions used in this sample are still supported, but have been succeeded by newer features. &nbsp;The scenario addressed by
 this sample is accomplished using the latest technology in&nbsp;<a href="https://github.com/azureadsamples/nativeclient-dotnet" target="_blank">NativeClient-DotNet</a>.</span></h1>
<h1 style="text-align:justify">Authentication via Browser Dialog - Readme</h1>
<h2>Overview</h2>
<p style="text-align:justify"><span style="font-size:small">This sample demonstrates how to use the Active Directory Authentication Library (ADAL)</span></p>
<p style="text-align:justify"><span style="font-size:small">package to add user authentication capabilities to a WPF client. Furthermore,</span><br>
<span style="font-size:small">it demonstrates how to authenticate calls to a Web API REST service by</span><br>
<span style="font-size:small">leveraging the JSON Web Token Handler for Microsoft .Net Framework 4.5 (JWT</span><br>
<span style="font-size:small">handler).</span></p>
<p style="text-align:justify"><span style="font-size:small">ADAL is a library, built on .Net 4.0, offering a simple programming model for Windows</span><br>
<span style="font-size:small">Azure Active Directory (AAD) in client applications. Its main purpose is to</span><br>
<span style="font-size:small">help developers easily obtain access tokens from Windows Azure Active</span><br>
<span style="font-size:small">Directory, to be used for requesting access to protected resources such as REST</span><br>
<span style="font-size:small">services.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">The JSON Web Token Handler for Microsoft .Net Framework (JWT handler) is a library built on</span><br>
<span style="font-size:small">.NET 4.5 which adds the JSON Web token format as a first-class citizen in the</span><br>
<span style="font-size:small">.NET programming model. The JWT handler can be used both within the WIF</span><br>
<span style="font-size:small">pipeline, to secure existing Web sites and services with JWT tokens in addition</span><br>
<span style="font-size:small">to the formats supported out of the box (such as SAML1.1 and SAML2). The JWT</span><br>
<span style="font-size:small">handler can also be used standalone, with no direct dependencies on WIF</span><br>
<span style="font-size:small">configuration.</span></p>
<p style="text-align:justify">&nbsp;</p>
<h2 style="text-align:justify">Prerequisites</h2>
<p style="text-align:justify">&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small">Visual Studio 2012.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></li><li><span style="font-size:small">A working internet connection.</span> </li><li><span style="font-size:small">Windows Azure subscription.</span> </li><li><span style="font-size:small">Windows Azure Active Directory tenant.</span> </li><li><span style="font-size:small"><a href="http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c">NuGet package Manager.</a></span>
</li></ul>
<p style="text-align:justify"><br>
<strong><span style="font-size:small">Running the Sample</span></strong></p>
<p style="text-align:justify"><br>
<span style="font-size:small">Before running this sample, you will need to create an Azure Active Directory tenant and register the client and service in the sample with Azure AD and update the sample with your tenant information.</span></p>
<p style="text-align:justify">&nbsp;</p>
<ol style="text-align:justify">
<li><span style="font-size:small">If you don&rsquo;t have your own Windows Azure AD tenant, please follow the
<a href="http://msdn.microsoft.com/en-us/library/windowsazure/79e09d59-08b9-446a-8ead-209134a4326d#BKMK_Working">
&ldquo;Create<br>
a New Directory Tenant and Add a User&rdquo;</a> section in Windows Store app walk</span><br>
<span style="font-size:small">through to create one.</span> </li></ol>
<ul style="text-align:justify">
&nbsp;
<li style="text-align:left"><span style="font-size:small">Copy the domain name (in https://login.windows.net/&lt;domainName&gt;.onmicrosoft.com</span><br>
<span style="font-size:small">format) into <strong>authority </strong>in</span><br>
<span style="font-size:small">global.asax.cs file in TodoListService.</span> </li></ul>
<p>&nbsp;</p>
<ol style="text-align:justify">
</ol>
<p style="text-align:justify"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2. Register the client and service applications in AAD and update the sample</span></p>
<p>&nbsp;</p>
<ul>
<li>&nbsp;
<ul>
<li><span style="font-size:small">Click Add at the bottom of the page</span> </li><li><span style="font-size:small">Enter &ldquo;TodoListService&rdquo; as the name</span><br>
<span style="font-size:small">and choose web application or web api option.</span>
</li><li><span style="font-size:small">Enter <a href="https://localhost:44300/">https://localhost:44300/</a> as the App URL and &ldquo;<a href="http://localhost/TodoListService">http://localhost/TodoListService</a>&rdquo; as the App ID URI and click next.
</span></li><li><span style="font-size:small">Choose Single Sign on as this sample doesn&rsquo;t need to read or write graph data.</span>
</li><li><span style="font-size:small">You should see this page when done</span> </li></ul>
</li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small">NOTE: </span><span style="font-size:small">There is no way to delete the applications once they are created through the
</span><span style="font-size:small">portal at this time</span>
<blockquote>
<li><span style="font-size:small">Sign</span><br>
<span style="font-size:small">in to <a href="https://manage.windowsazure.com">https://manage.windowsazure.com</a>.</span>
</li><li><span style="font-size:small">Click</span><br>
<span style="font-size:small">on Active Directory in the left hand pane.</span> </li><li><span style="font-size:small">Click your directory.</span> </li><li><span style="font-size:small">Click on Applications.</span> </li><li><span style="font-size:small"><em>Add Service application</em>. </span></li></blockquote>
</li></ul>
<p style="text-align:justify"><img id="95973" src="95973-aad1.png" alt="" width="698" height="745"></p>
<p style="text-align:justify">Figure 1</p>
<p style="text-align:justify">&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small"><em>Add<br>
Client Application</em>. </span>
<ul>
<li><span style="font-size:small">Go back to Applications and click Add</span><br>
<span style="font-size:small">at the bottom of the page.</span> </li><li><span style="font-size:small">Enter &ldquo;TodoListClient&rdquo; as the name and</span><br>
<span style="font-size:small">choose &ldquo;Native Client Application&rdquo;.</span>
</li><li><span style="font-size:small">Click next and enter <a href="http://TodoListClient">
http://TodoListClient</a> as the Redirect Uri. Click the check</span><br>
<span style="font-size:small">mark.</span> </li><li><span style="font-size:small">Click on &ldquo;Configure access to web APIs&rdquo;</span><br>
<span style="font-size:small">and then click &ldquo;Configure it now&rdquo;.</span>
</li><li><span style="font-size:small">Choose TodoListService that we created</span><br>
<span style="font-size:small">above in the drop down &ldquo;Configure web API access for this native client</span><br>
<span style="font-size:small">application&rdquo; and click Save.</span> </li><li><span style="font-size:small">Copy Client ID to clientId &nbsp;and Redirect URI to redirectUri in</span><br>
<span style="font-size:small">MainWindow.xaml.cs</span> </li></ul>
</li></ul>
<p style="text-align:justify"><br>
<span style="font-size:small"><img id="95974" src="95974-aad2.png" alt="" width="730" height="777"></span><br>
<br>
<span style="font-size:small">Figure 2</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">3. The sample is configured to run the
</span><span style="font-size:small">TodoListService in IIS Express on https. In order to get the sample working,
</span><span style="font-size:small">please copy the localhost certificate with friendly name = &ldquo;IIS Express
</span><span style="font-size:small">Development Certificate&rdquo; from Local Computer -&gt; My store to Trusted Root
</span><span style="font-size:small">store, otherwise the calls to TodoListService made by ADAL (during 401
</span><span style="font-size:small">discovery) and TodoListClient fail with the reason that the https certificate</span><br>
<span style="font-size:small">is invalid.</span></p>
<ul style="text-align:justify">
<li><span style="font-size:small">To do </span><span style="font-size:small">this, run mmc.exe.&nbsp; Go to File -&gt;
</span><span style="font-size:small">Add/Remove snap-in, choose certificates and click Add. Choose &ldquo;Computer account&rdquo;,
</span><span style="font-size:small">click &ldquo;Finish&rdquo; and then click &ldquo;OK&rdquo;.
</span></li><li><span style="font-size:small">Now </span><span style="font-size:small">go to Personal -&gt; Certificates and look for &ldquo;localhost&rdquo; certificate issued</span><br>
<span style="font-size:small">by &ldquo;localhost&rdquo; and friendly name = &ldquo;IIS Express Development Certificate&rdquo;.</span><br>
<span style="font-size:small">Export this certificate without the private key and then import into &ldquo;Trusted</span><br>
<span style="font-size:small">Root Certificate Authorities&rdquo;.</span> </li></ul>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">To run this </span><span style="font-size:small">sample, hit F5. The solution is configured to start multiple projects and will</span><br>
<span style="font-size:small">take care to put all the right parts in motion.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">You will get a </span><span style="font-size:small">401 exception on the call to uthenticationParameters.CreateFromResourceUrl()
</span><span style="font-size:small">which is expected since the client is doing 401 discovery by making a call to
</span><span style="font-size:small">the TodoListService without an access token. Press F5 to continue.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">In order to see </span>
<span style="font-size:small">the scenario in action, enter a value in the textbox and click the &ldquo;Add item&rdquo;</span><br>
<span style="font-size:small">button in the TodoListManager UI. Given that calling the corresponding service
</span><span style="font-size:small">requires presenting a security token, the application will prompt you with a
</span><span style="font-size:small">sign in page. Sign in as a user of your AAD domain.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">Now that we have </span>
<span style="font-size:small">a token, you will see that subsequent calls to the service will no longer</span><br>
<span style="font-size:small">trigger an authentication prompt as the token is cached, unless the cache is
</span><span style="font-size:small">cleared by clicking the Clear Cache button. The sample is configured with a
</span><span style="font-size:small">custom cache, CredManCache.cs under TodoListClient. The CredManCache uses
<a href="http://msdn.microsoft.com/en-us/library/aa923650.aspx">credential manager</a> to store the AuthenticationResult
</span><span style="font-size:small">objects that contain access token, refresh token, user id etc.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">To clear the </span><span style="font-size:small">token cache, click the Clear Cache button which also clears the items in the</span><br>
<span style="font-size:small">Todo items list. When you add an item again, you will be prompted with a sign
</span><span style="font-size:small">in page.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">When you want to </span><span style="font-size:small">stop debugging, hit the Stop button in Visual Studio.</span></p>
<h2 style="text-align:justify"><br>
<span style="font-size:small">Details</span></h2>
<p style="text-align:justify"><br>
<span style="font-size:small">Let&rsquo;s take a </span><span style="font-size:small">quick look at the structure of the solution. If you want more detailed</span><br>
<span style="font-size:small">information, please refer to the comments in the code.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small"><strong>TodoListService:</strong></span></p>
<p style="text-align:justify"><span style="font-size:small">A .Net 4.5 MVC4 </span>
<span style="font-size:small">WebAPI&nbsp;project implementing a simple REST fa&ccedil;ade on top of a collection of
</span><span style="font-size:small">todo items. It utilizes the functionality in the JWT handler package.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small"><strong>TodoListClient:</strong></span><br>
<br>
<span style="font-size:small">A .Net 4.0 WPF project implementing a simple client which consumes the API
</span><span style="font-size:small">exposed by TodoListService. TodoListClient can be used for adding new todo
</span><span style="font-size:small">items and display the ones assigned to the signed in user. It utilizes the
</span><span style="font-size:small">functionality in the ADAL package to display the Browser dialog for
</span><span style="font-size:small">authenticating and getting a JWT token from AAD/ADFS.<strong>&nbsp;</strong></span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">ADAL is provided </span><span style="font-size:small">in the &ldquo;Azure Directory Authentication Library&rdquo; NuGet package and
<em>JWTSecurityTokenHandler</em> in the &ldquo;JSON Web </span><span style="font-size:small">Token Handler for Microsoft .Net Framework 4.5&rdquo; NuGet package. Notice the
</span><span style="font-size:small">assemblies &ldquo;<strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.IdentityModel.Clients.ActiveDirectory.aspx" target="_blank" title="Auto generated link to Microsoft.IdentityModel.Clients.ActiveDirectory">Microsoft.IdentityModel.Clients.ActiveDirectory</a></strong>&rdquo;
</span><span style="font-size:small">and &ldquo;<strong>Microsoft.IdentityModel.Clients.ActiveDirectory.WindowsForms&rdquo;
</strong>under the references node in the Solution Explorer in Visual Studio for </span>
<span style="font-size:small">TodoListClient project and &ldquo;<strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IdentityModel.Tokens.aspx" target="_blank" title="Auto generated link to System.IdentityModel.Tokens">System.IdentityModel.Tokens</a></strong>&rdquo;
</span><span style="font-size:small">in the TodoListService project.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">Let&rsquo;s start from </span><span style="font-size:small">the client side of the solution. Open the
<strong>TodoListClient</strong> project and</span><br>
<span style="font-size:small">look at the <strong>MainWindow.xaml.cs</strong></span></p>
<p style="text-align:justify">&nbsp;</p>
<ol style="text-align:justify">
<li><span style="font-size:small">authority</span><br>
<span style="font-size:small">refers to the AAD tenant in https://login.windows.net/&lt;tenant_name_or_ID&gt;
</span><span style="font-size:small">format, for example, &ldquo;https://login.windows.net/treyresearch.onmicrosoft.com. It could be set to
</span><span style="font-size:small">https://login.windows.net/common to defer figuring out the domain till users
</span><span style="font-size:small">sign in.&nbsp; Here it is set to string.Empty,
</span><span style="font-size:small">as the client is going to get the value from the TodoListService.</span>
</li><li><span style="font-size:small">clientId</span><br>
<span style="font-size:small">is a unique identifier for the TodoListClient application which is registered</span><br>
<span style="font-size:small">in AAD for your tenant (see Figure 2).&nbsp; </span>
</li><li><span style="font-size:small">redirectUri</span><br>
<span style="font-size:small">is a URI of the client App registered in AAD (see Figure 2).
</span></li><li><span style="font-size:small">resourceAppIDUri</span><br>
<span style="font-size:small">is the identifier that will be used by TodoListClient application to identify
</span><span style="font-size:small">the target service resource &nbsp;when </span>
<span style="font-size:small">requesting authorization for the service from Windows Azure AD (see Figure 1).&nbsp; The value of resourceAppIdUri is also going
</span><span style="font-size:small">to be obtained from the TodoListService in addition to authority.</span>
</li></ol>
<p style="text-align:justify"><br>
<span style="font-size:small">You will also see that we have setup some application-level members,
</span><span style="font-size:small"><em>AuthenticationContext</em> , a &ldquo;proxy&rdquo; for your tenant. On initialization the
</span><span style="font-size:small"><em>AuthenticationContext</em> is set to the authority specified in the authority
</span><span style="font-size:small">variable and the custom cache, CredManCache.</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify"><span style="font-size:small">In the MainWindow() you will see that the client calls
</span><span style="font-size:small">AuthenticationParameters.CreateFromResourceUrl() to do a 401 discovery and get
</span><span style="font-size:small">the values of authority and resourceAppIdUri.</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify"><span style="font-size:small">When the Add item button is clicked the
<em>GetAuthorizationHeader</em>() method is called, which calls AcquireToken() method in ADAL.Net to get
</span><span style="font-size:small">an AuthenticationResult containing an access token and then returns a http
</span><span style="font-size:small">authorization header with the access token obtained from ADAL.</span></p>
<p style="text-align:justify">&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small">AcquireToken() checks the cache to see </span><span style="font-size:small">if there is a valid access token for the given authority, resource and client.
</span><span style="font-size:small">If there is a valid access token, it is returned. Otherwise, ADAL checks if
</span><span style="font-size:small">there is a valid refresh token, if yes, the refresh token would be sent to AAD
</span><span style="font-size:small">to get an access token. If neither of the above is possible, then a browser
</span><span style="font-size:small">dialog is presented to the user to enter credentials.
</span></li><li><span style="font-size:small">Upon successful authentication <em>AcquireToken
</em></span><span style="font-size:small">returns an <em>AuthenticationResult</em> which</span><br>
<span style="font-size:small">is saved in the cache for use in the subsequent calls.
</span></li></ul>
<p style="text-align:justify"><br>
<span style="font-size:small">You can see how </span><span style="font-size:small">the JWT token is utilized in the
<em>GetResponseFromService() </em>method. Here the accessToken is put </span><span style="font-size:small">in the Authorization header of the HTTP Request sent to the TodoListService.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">Finally on the </span><span style="font-size:small">Client side, take a look at CredManCache.cs. You will see that CredManCache is
</span><span style="font-size:small">a dictionary of TokenCacheKey and string pair. TokenCacheKey contains fields
</span><span style="font-size:small">like authority, clientId, resource etc. &nbsp;CredManCache encodes the TokenCacheKey into a
</span><span style="font-size:small">string to store in CredMan and decodes the key back to TokenCacheKey while
</span><span style="font-size:small">reading the entries. CacheHelper.cs has the logic to encode and decode the keys
</span><span style="font-size:small">of type TokenCacheKey. The values in the dictionary are string representation
</span><span style="font-size:small">of AuthenticationResult.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">Since the cache </span>
<span style="font-size:small">is a dictionary, you can run Linq queries on it, for example, to find all the</span><br>
<span style="font-size:small">tokens obtained from a specific authority or find all the tokens of a specific
</span><span style="font-size:small">user etc.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">Moving on to the </span>
<span style="font-size:small">service side: open the <strong>TodoListService</strong> project and examine
<strong>Global.asax.cs</strong>. </span><span style="font-size:small">The most interesting class here is
<em>TokenValidationHandler, </em>an </span><span style="font-size:small">implementation of DelegatingHandler.&nbsp;
<em>TokenValidationHandler&lsquo;s </em>purpose </span><span style="font-size:small">is<em>
</em>to process request messages before they reach the application code </span><span style="font-size:small">and enforce authentication requirements. The method
<em>TryRetrieveToken </em></span><span style="font-size:small">inspects incoming http requests to verify if the authorization header contains
</span><span style="font-size:small">an OAuth2 header with a bearer token. If a bearer token is not found, the
</span><span style="font-size:small">request is not authorized and an unauthorized status code along with the</span><br>
<span style="font-size:small">authorization url and resource Id &nbsp;is </span><span style="font-size:small">sent back to the Client. &nbsp;If the header
</span><span style="font-size:small">contains a bearer token, it is validated through the
<em>JWT handler</em>. A <em>TokenValidationParameters </em>object is created to set the expected
</span><span style="font-size:small">properties, issuer, audience and signing token, on the token. The method
<em>ValidateToken() </em></span><span style="font-size:small">is then called to validate the token and, upon successful validation, a new
<em>ClaimsPrincipal </em></span><span style="font-size:small">instance is set as the Principal of the current thread and as the Current user
</span><span style="font-size:small">in HttpContext.</span></p>
<h2 style="text-align:justify"><br>
<span style="font-size:small">Deploying the TodoListService to Windows Azure</span></h2>
<p style="text-align:justify"><br>
<span style="font-size:small">The sample </span><span style="font-size:small">solution is designed to run from your local machine; you can explore the
</span><span style="font-size:small">scenario without having a Windows Azure subscription, and in fact you can
</span><span style="font-size:small">choose to use ADAL to connect to Windows Azure Active Directory regardless of
</span><span style="font-size:small">where you will run your services.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">That said, here </span><span style="font-size:small">are detailed instructions you can follow if you want to deploy the
<strong>TodoListService </strong></span><span style="font-size:small">to Windows Azure.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">The steps </span><span style="font-size:small">below assume that you are using the April 2013 release of the Windows Azure</span><br>
<span style="font-size:small">SDK. Also note that to debug you will need to run VS in administrator mode.</span></p>
<p style="text-align:justify">&nbsp;</p>
<ol style="text-align:justify">
<li><span style="font-size:small">In the Solution Explorer, right click</span><br>
<span style="font-size:small">on the <strong>TodoListService</strong> project and choose
<em>Add Windows Azure Cloud<br>
Service Project</em>. &nbsp;This will create a new project called <strong>TodoListService.Azure</strong>.</span>
</li><li><span style="font-size:small">Make sure that multiple startup</span><br>
<span style="font-size:small">projects are still enabled. The following should be marked as startup projects</span><br>
<span style="font-size:small">now:</span> </li></ol>
<p style="text-align:justify">&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small">TodoListClient</span> </li><li><span style="font-size:small">TodoListService.Azure</span> </li></ul>
<p style="text-align:justify; padding-left:30px"><span style="font-size:small">&nbsp;</span></p>
<p style="text-align:justify; padding-left:30px"><span style="font-size:small">3. To test on the local simulation
</span><span style="font-size:small">environment: open <strong>MainWindow.xaml.cs</strong> in&nbsp;&nbsp; the<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TodoListClient
</strong></span><span style="font-size:small">project and change the <em>resourceBaseAddress
</em>value to <a href="http://127.0.0.1:81/">http://127.0.0.1:81/</a>. You will also have to relax the
</span><span style="font-size:small">validation on resourceAppIdUri, which would not work now. So, move the &ldquo;resourceAppIdUri = parameters.Resource;&rdquo; statement out of the if block and comment out the if and else statement in MainWindow().</span></p>
<ol style="text-align:justify">
</ol>
<p style="padding-left:30px"><span style="font-size:small">4.To publish select <em>
Publish</em> on </span><span style="font-size:small">the <strong>TodoListService.Azure</strong> project. Select the Cloud Service where you
</span><span style="font-size:small">would like to deploy to and choose <em>Publish.</em></span></p>
<ol style="text-align:justify">
<span style="font-size:small">1. Once published open <strong>MainWindow.xaml.cs </strong>
</span><span style="font-size:small">in the <strong>TodoListClient</strong> project and change the
<em>resourceBaseAddress </em></span><span style="font-size:small">value to the URL of the published service.</span>
<blockquote>
<p>&nbsp;</p>
</blockquote>
</ol>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2. Once the deployment took place: before
</span><span style="font-size:small">launching the debugger, change your&nbsp;&nbsp; startup projects settings so only the
</span><span style="font-size:small">following projects are enabled:</span></p>
<p style="text-align:justify">&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small">TodoListClient</span> </li></ul>
<h2 style="text-align:justify"><br>
<span style="font-size:small">Security Considerations</span></h2>
<p style="text-align:justify">&nbsp;</p>
<ol style="text-align:justify">
<li><span style="font-size:small">When a custom token cache is plugged</span><br>
<span style="font-size:small">into ADAL, make sure that the entries in the cache are encrypted so that they</span><br>
<span style="font-size:small">are secure. </span></li><li><span style="font-size:small">Note that the browser dialog that is</span><br>
<span style="font-size:small">used for the authentication flow in ADAL does not have an address bar.
</span></li><li><span style="font-size:small">The JWT Tokens issued by AAD are bearer</span><br>
<span style="font-size:small">tokens and may not be encrypted and hence must be sent to the service on a</span><br>
<span style="font-size:small">secure channel like https in order to prevent information disclosure, spoofing</span><br>
<span style="font-size:small">and other security attacks. </span></li><li><span style="font-size:small">The exceptions thrown by the JWT handler</span><br>
<span style="font-size:small">could contain sensitive information and it is up to the applications using it</span><br>
<span style="font-size:small">to make sure that this sensitive information is not sent to the Client.</span>
</li><li><span style="font-size:small">JWT handler could be configured to</span><br>
<span style="font-size:small">skip audience verification and Issuer verification. The security implications</span><br>
<span style="font-size:small">of turning off these checks should be understood.</span>
</li><li><span style="font-size:small">The</span><br>
<span style="font-size:small">JWT tokens issued by AAD are credentials (alike to passwords) and include</span><br>
<span style="font-size:small">information about users which may be considered sensitive information.&nbsp; The JWT token handler does not log tokens.&nbsp; Applications that log tokens should protect</span><br>
<span style="font-size:small">the log data appropriately to prevent information disclosure, spoofing, and</span><br>
<span style="font-size:small">other security attacks.</span> </li></ol>
