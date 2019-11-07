# ADAL - Server to Server Authentication
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
## Topics
- Authentication
## Updated
- 12/29/2014
## Description

<h1><span style="color:#ff0000; font-size:xx-large">NOTE: This sample is outdated. The technology, methods, and/or user interface instructions used in this sample are still supported, but have been succeeded by newer features. &nbsp;The scenario addressed by
 this sample is accomplished using the latest technology in&nbsp;<a href="https://github.com/AzureADSamples/Daemon-DotNet" target="_blank" style="font-size:xx-large">Daemon-DotNet</a> and
<a href="https://github.com/AzureADSamples/Daemon-CertificateCredential-DotNet" target="_blank" style="font-size:xx-large">
Daemon-CertificateCredential-DotNet</a>.</span></h1>
<h1>Overview</h1>
<p><span style="font-size:small">This sample demonstrates how to use the <strong>
Active Directory Authentication Library (ADAL) package</strong> to secure service calls from a server side process or a device (for ex. A sensor)&nbsp; to an MVC4 Web API REST service. The caller processes is simulated in the sample solution by a console application.
 The below free body diagram captures the scenario we are implementing at a high level:</span></p>
<p><br>
<img id="95985" src="95985-capture.png" alt="" width="642" height="336"></p>
<p><span style="font-size:small">Furthermore, it demonstrates how to authenticate calls to a Web API REST service by leveraging
</span><span style="font-size:small">the <strong>JSON Web Token Handler for Microsoft .Net Framework 4.5 (JWT handler).</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">ADAL is a library, built on .Net 4.0, offering a simple programming model for Windows Azure Active Directory (WAAD) and Windows Server Active Directory Federation Services for Windows Server 2012 R2 in client applications. Its
 main purpose is to help developers easily obtain access tokens from Windows Azure Active Directory (WAAD) and Windows Server Active Directory Federation Services for Windows Server 2012 R2, which can then be used for requesting access to protected resources
 such as REST services.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">The JSON Web Token Handler for Microsoft .Net Framework (JWT handler) is a library built on .NET 4.5 which adds the JSON Web token format as a first-class citizen in the .NET programming model. The JWT handler can be used both
 within the WIF pipeline, to secure existing Web sites and services with JWT tokens in addition to the formats supported out of the box (such as SAML1.1 and SAML2). The JWT handler can also be used standalone, with no direct dependencies on WIF configuration.</span></p>
<p>&nbsp;</p>
<h2><strong>Prerequisites</strong></h2>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">Visual Studio 2012 </span></li><li><span style="font-size:small">Windows Azure Subscription </span></li><li><span style="font-size:small">Azure AD tenant&nbsp;&nbsp; </span></li><li><span style="font-size:small">Windows Azure AD Module for Windows PowerShell (<a href="http://technet.microsoft.com/en-us/library/jj151815.aspx">More<br>
information on setting up PowerShell to use with Windows Azure AD</a>) </span></li><li><span style="font-size:small"><a href="http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c">NuGet package Manager</a>
</span></li><li><span style="font-size:small">A working internet connection </span></li></ul>
<p>&nbsp;</p>
<h2><strong>Running the Sample</strong></h2>
<p>&nbsp;</p>
<p><span style="font-size:small">The sample solution includes three projects:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>TelemetryServiceWebAPI</strong></span><br>
<br>
<span style="font-size:small">A .Net 4.5 MVC4 WebAPI&nbsp;project, implementing a simple REST WebAPI</span><br>
<span style="font-size:small">simulating a service which gathers Telemetry data. </span>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Note</strong><em>: SSL is mandatory before putting an application following this sample guidance into production.</em></span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>TelemetryServiceMonitor</strong></span><br>
<br>
<span style="font-size:small">A .Net 4.5 console project simulating a long running server process which consumes the API exposed by
<strong>TelemetryServiceWebAPI</strong>.&nbsp; <strong>TelemetryServiceMonitor </strong>
polls <strong>TelemetryServiceWebAPI</strong> every 20 seconds to get device data from all other
<strong>TelemetryServiceClients</strong> writing to the <strong>TelemetryServiceWebAPI</strong>. The results of every call are displayed as messages in the console.
</span></li><li><span style="font-size:small"><strong>TelemetryServiceClient</strong></span><br>
<span style="font-size:small">A .Net 4.5 console project simulating a long running client process which consumes the API exposed by
<strong>TelemetryServiceWebAPI</strong>.&nbsp; <strong>TelemetryServiceClient </strong>
writes Device data {Name, Memory, TimeStamp} to the <strong>TelemetryServiceWebAPI
</strong>every 10 seconds. The data written at every call is also displayed in the</span><br>
<span style="font-size:small">console along with the URI of the new resource created on the
<strong>TelemetryServiceWebAPI</strong>. </span></li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small">Before running this </span><span style="font-size:small">sample, you will need to create an Azure Active Directory tenant and register
</span><span style="font-size:small">the client and Services in the sample with Azure AD and update the sample with</span><br>
<span style="font-size:small">your tenant information.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;</span><span style="font-size:small"> you don&rsquo;t have your own Windows Azure AD tenant, please follow the &ldquo;<strong>Working<br>
with Your Windows Azure AD Directory Tenant</strong>&rdquo; section in <a href="http://msdn.microsoft.com/en-us/library/dn151790.aspx">
Adding Sign-On to Your Web Application Using Windows Azure AD</a> to create one. As you don&rsquo;t need a user for</span><br>
<span style="font-size:small">this sample you will need to follow steps 1-3 of this section.
</span></p>
<p>&nbsp;</p>
<h3><span style="font-size:small">2.&nbsp;&nbsp;&nbsp; Register </span><span style="font-size:small">a New Application on your Azure AD tenant for&nbsp; T<strong>elemetryServiceWebAPI</strong></span></h3>
<p>&nbsp;</p>
<ol>
<li><span style="font-size:small">Go </span><span style="font-size:small">to the <strong>
Active Directory</strong> tab in the Windows Azure Management Portal. Click the</span><br>
<span style="font-size:small"><strong>APPLICATIONS</strong> header in the top area
</span><span style="font-size:small">of the screen. </span></li><li><span style="font-size:small">This area is dedicated to listing </span><span style="font-size:small">all the applications that are registered in your directory tenant. We say that
</span><span style="font-size:small">an application is &ldquo;registered&rdquo; in a tenant when:
</span></li></ol>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">The application has an entry in the </span><span style="font-size:small">directory, which describes its main coordinates: name, associated endpoints,
</span><span style="font-size:small">and so on. More details later. </span></li><li><span style="font-size:small">The application itself has been </span><span style="font-size:small">granted permission to perform some operation on the current directory tenant:</span><span style="font-size:small"> the operations range from requesting a
 sign-on token to the ability to query </span><span style="font-size:small">the directory. Once again, more details later.
</span></li></ul>
<h3><br>
<strong>Important&nbsp; </strong></h3>
<p><span style="font-size:small">No application can take advantage&nbsp;</span><span style="font-size:small">of Windows Azure AD without having been registered: this is both for security&nbsp;</span><span style="font-size:small">reasons (only apps that the
 administrator approves of should be allowed) and&nbsp;</span><span style="font-size:small">practical considerations (interaction with Windows Azure AD entails use of</span><br>
<span style="font-size:small">&nbsp;specific open protocols, which in turn require the knowledge of key&nbsp;</span><span style="font-size:small">parameters describing the app).</span></p>
<p>&nbsp;</p>
<p style="padding-left:30px"><span style="font-size:small">3. Clicking the <strong>
Add</strong> button on </span><span style="font-size:small">the Windows Azure Management Portal command bar at the bottom of the screen.
</span><br>
<br>
<span style="font-size:small">4. The process of registering one app through the </span>
<span style="font-size:small">Windows Azure Management Portal is structured as a classic wizard, in which
</span><span style="font-size:small">subsequent screens break down the gathering of the required information
</span><span style="font-size:small">according to your choices.</span></p>
<p><br>
<br>
</p>
<p style="padding-left:30px"><span style="font-size:small"><span style="font-family:Times New Roman">&nbsp;</span></span></p>
<p class="MsoNormal" style="margin:0in 0in 8pt; line-height:normal"><span style="font-size:small"><span style="line-height:107%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">&nbsp;<img id="95989" src="95989-s2s2.png" alt="" width="594" height="436">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></p>
<p class="MsoNormal" style="margin:0in 0in 8pt; line-height:normal"><span style="font-size:small"><span style="line-height:107%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">&nbsp;</span></span>&nbsp;</p>
<p><br>
<span style="font-size:small">The options offered are straightforward:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>Name</strong>: the text entered here is used as human-readable moniker to refer to the app whenever a user -- be it an</span><br>
<span style="font-size:small">administrator managing the registered apps list or a customer deciding to grant directory access to the app &ndash; needs to do something about it. There is more info about this in the
<a href="http://msdn.microsoft.com/en-us/library/dn151789.aspx">Developing Multi-Tenant Web Applications with Windows Azure AD</a> paper.
</span></li><li><span style="font-size:small"><strong>Type</strong>: This set of radio buttons allows you to specify what kind of app you are trying to build. For the</span><br>
<span style="font-size:small">purposes of this Sample, in which our goal is to create a WEB API, the proper choice is
<strong>&ldquo;WEB<br>
APPLICATION AND/OR WEB API&rdquo;</strong>.</span> </li></ul>
<p>&nbsp;</p>
<ol>
</ol>
<p style="padding-left:30px"><span style="font-size:small">5. Once you have entered the application&rsquo;s name and chosen the
<strong>&ldquo;WEB APPLICATION AND/OR WEB API&rdquo;</strong></span><br>
<span style="font-size:small">access type, click on the arrow on the lower right corner to move to the next</span><br>
<span style="font-size:small">screen.</span></p>
<ol>
</ol>
<p style="padding-left:30px"><span style="font-size:small">6. In this screen the Windows Azure Management Portal gathers important coordinates
</span><span style="font-size:small">which the service needs to drive the sign-in protocol flow.
</span></p>
<p>&nbsp;</p>
<p><br>
<img id="95991" src="95991-s2s3.png" alt="" width="668" height="460"></p>
<p><br>
<br>
</p>
<p><span style="font-size:small">Here there&rsquo;s what you need to enter:</span></p>
<ul>
<li><span style="font-size:small"><strong>APP URL</strong>: Since we are building a web API service
</span><span style="font-size:small">which does not have a sign-in flow we don&rsquo;t really need to provide Windows
</span><span style="font-size:small">Azure AD the physical address where your API is hosted. However since this is a
</span><span style="font-size:small">required field in the portal we can enter a dummy value here. For web
</span><span style="font-size:small">applications this parameter needs to represents the
<em>address</em> of your web application. Windows </span><span style="font-size:small">Azure AD needs to know your application&rsquo;s address so that, after a user
</span><span style="font-size:small">successfully authenticated on Windows Azure AD&rsquo;s pages, it can redirect the
</span><span style="font-size:small">flow back to your application. </span></li><li><span style="font-size:small"><strong>APP ID URI</strong>: this parameter represents the
<em>identifier</em> of your web </span><span style="font-size:small">application. Windows Azure AD uses this value at sign-on time, to determine
</span><span style="font-size:small">that the authentication request is meant to enable a user to access this
</span><span style="font-size:small">particular application - among all the ones registered - so that the correct
</span><span style="font-size:small">settings can be applied, click on the arrow on the lower right corner to move
</span><span style="font-size:small">to the next screen.</span> </li></ul>
<table border="0" cellpadding="0">
<tbody>
<tr>
<td>
<p><span style="font-size:small"><strong>Note<br>
</strong></span></p>
</td>
</tr>
<tr>
<td>
<p><span style="font-size:small">The <strong>APP&nbsp;ID URI</strong> must be unique within the directory tenant. A good&nbsp;</span><span style="font-size:small">&nbsp; default value for it is the
<strong>APP&nbsp; URL</strong> value itself, however with that strategy the uniqueness&nbsp;</span><span style="font-size:small">&nbsp; constraint is not always easy to respect: developing the app on local hosting&nbsp;</span><span style="font-size:small">environments
 such as IIS Express and the Windows Azure Fabric Emulator tend&nbsp;</span><span style="font-size:small">to produce a restricted range of addresses that will be reused by multiple&nbsp;</span><span style="font-size:small">developers or even multiple projects
 from the same developer. One possible&nbsp;</span><span style="font-size:small">&nbsp;strategy is to append something to the
<strong>APP&nbsp;&nbsp; URI</strong> value as a differentiator.</span></p>
<p><span style="font-size:small">Also note. The <strong>APP ID URI</strong> is a URI, and as such it&nbsp;</span><span style="font-size:small">does not have to correspond to any network addressable endpoint.</span></p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<ol>
</ol>
<p style="padding-left:30px"><span style="font-size:small">7. The </span><span style="font-size:small">options offered allow you to set access your app needs to Azure AD:</span></p>
<ol>
<img id="95992" src="95992-s2s4.png" alt="" width="608" height="454"></ol>
<p class="MsoNormal" style="margin:0in 0in 8pt; line-height:normal"><span style="font-size:small"><span style="line-height:107%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></p>
<p><br>
<br>
</p>
<ul>
<li><span style="font-size:small"><strong>Access type</strong>: Since this is a Web API and we
</span><span style="font-size:small">don&rsquo;t need directory access the proper choice is
<strong>Single sign-on</strong>. Once </span><span style="font-size:small">you have selected Single Sign-on you can click on the checkbox button on the
</span><span style="font-size:small">lower right corner. Note: The Web API be are building does not support sign-on but
</span><span style="font-size:small">selecting this option registers the API with the minimum access requirements we
</span><span style="font-size:small">need.</span> </li></ul>
<p><br>
<span style="font-size:small">3.&nbsp;&nbsp;Follow the </span><span style="font-size:small">steps in 2. Above to
<strong>&ldquo;Register a New Application&rdquo; </strong>for the two client applications</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>-TelemetryServiceClient</strong></span></p>
<p><span style="font-size:small"><strong>-TelemetryServiceMonitor</strong></span></p>
<p><br>
<span style="font-size:small"><strong>Note</strong>:</span></p>
<p><span style="font-size:small">- Even though this </span><span style="font-size:small">sample uses console applications to describe the client applications we would
</span><span style="font-size:small">still choose the <strong>&ldquo;WEB APPLICATION AND/OR WEB API&rdquo; option, as the OAuth grant type (&ldquo;Client Credential Grant&rdquo;) that the console application uses applies to any service to service interaction.
 Since the Clients here contain the client secret (as described below) it is expected that the client would be running in a secure environment like:</strong><strong>&nbsp;</strong></span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>Background job (Cron job) on a server</strong><strong>&nbsp;</strong></span>
</li><li><span style="font-size:small"><strong>&nbsp;<br>
</strong><strong>Service to service calls made by a Web<br>
Application to say Graph API where the Web Application is a confidential client<br>
</strong><strong>&nbsp;</strong></span> </li><li><span style="font-size:small"><strong>Set of embedded devices (For e.g. Sensors) where the<br>
client secret is stored in a secure storage on the device itself and cannot be<br>
retrieved\misused by the end user.</strong></span> </li></ul>
<p><br>
<span style="font-size:small">- We are leveraging the </span><span style="font-size:small">portal to set up our service 2 service client application. You may notice that
</span><span style="font-size:small">the flow is not optimal of such a client, our purpose of following the above</span><br>
<span style="font-size:small">steps is to use the Windows Azure management portal to create the</span><br>
<span style="font-size:small">ServicePrincipal for the application in the directory instance. Some of the below</span><br>
<span style="font-size:small">points are also worth mentioning:</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small">- </span><span style="font-size:small">Since in this sample the client applications are console applications the &ldquo;<strong>APP<br>
ID URL</strong>&rdquo; is not really relevant and you can fill in a dummy value.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">-Similarly </span><span style="font-size:small">the
<strong>&ldquo;WEB APPLICATION AND/OR WEB API&rdquo; and &ldquo;Single-Sign On&rdquo; are not applicable to the client apps we are setting up for Service to Service but are needed none the less to keep the wizard in the portal happy.
</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong><span style="text-decoration:underline">Updating the tenant information in the sample:</span></strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Start Visual Studio </span><span style="font-size:small">2012, open the solution</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Updating TelemetryServiceClient</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">1. Open the <strong>App.config </strong></span><span style="font-size:small">file of the
<strong>TelemetryServiceClient</strong> project and update the placeholders </span>
<span style="font-size:small">for <strong>Tenant</strong>, <strong>ClientID</strong>,
<strong>ClientSecret</strong>, <strong>Resource</strong>, <strong>ResourceUrl</strong> keys with the values
</span><span style="font-size:small">mentioned below.&nbsp;&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">a. Copy your Windows </span><span style="font-size:small">Azure AD tenant endpoint and fill in the &ldquo;value&rdquo; associated with the
<strong>Tenant </strong></span><span style="font-size:small">&ldquo;key&rdquo;.&nbsp; E.g. https://login.windows.net/yourdomain.onmicrosoft.com</span></p>
<p><br>
<span style="font-size:small">b. <strong>Goto</strong> the <strong>TelemetryServiceClient
</strong></span><span style="font-size:small">app on your tenant. You should be on a screen similar to the one you saw at the
</span><span style="font-size:small">end of registering the client application. Select
<strong>CONFIGURE</strong> at the top </span><span style="font-size:small">of the screen. Scroll all the way down and you&rsquo;ll see a
<strong>CLIENT ID </strong>field<strong>. </strong>Copy the CLIENT ID and fill in the &ldquo;value&rdquo; associated with the
<strong>ClientID</strong></span><br>
<span style="font-size:small">&ldquo;key&rdquo;.</span></p>
<p><br>
<span style="font-size:small">c.&nbsp;Below <strong>CLIENT ID </strong>you should see a keys section.
<strong>Select</strong> the duration drop down to</span><br>
<span style="font-size:small">create a new key with the specified duration. When you
<strong>SAVE</strong> the change </span><span style="font-size:small">you will be given the option to copy the key to clipboard by clicking a button
</span><span style="font-size:small">right next to the key. Fill in the &ldquo;value&rdquo; associated with the
<strong>ClientSecret </strong></span><span style="font-size:small">&ldquo;Key&rdquo; with the clipboard contents.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">d.&nbsp;Copy the <strong>App Id Uri</strong> of the service that you entered in step2 above and fill in the</span><br>
<span style="font-size:small">&ldquo;value&rdquo; associated with the <strong>Resource
</strong>key.</span></p>
<p><br>
<span style="font-size:small">e.&nbsp;<strong>ResourceUrl </strong>key.</span><br>
<span style="font-size:small">This should be the physical address where your service is hosted</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Updating TelemetryServiceMonitor</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">1.&nbsp;Open <strong>App.config </strong></span><span style="font-size:small">of the
<strong>TelemetryServiceMonitor</strong> project and update the placeholders for <strong>
Tenant</strong>, </span><span style="font-size:small"><strong>ClientID</strong>, <strong>
ClientSecret</strong>, <strong>Resource, </strong><strong>ResourceUrl</strong> keys following the exact steps (a-e, except c as there
</span><span style="font-size:small">is no client secret being used by the TelemetryServiceMonitor) described
</span><span style="font-size:small">above.&nbsp;&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Since the <strong>TelemetryServiceMonitor</strong> uses an X.509
</span><span style="font-size:small">certificate instead of a client secret we would additionally need to update
<strong>CertificatePath</strong> and <strong>CertificatePassword</strong> keys with the
</span><span style="font-size:small">respective values for the certificate you intend to use. If you are planning to</span><br>
<span style="font-size:small">reuse the certificate provided in this sample you can specify the path to the
</span><span style="font-size:small">.pfx file the password for which is &ldquo;password&rdquo;.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">You can create your own self-signed </span><span style="font-size:small">certificate using
<strong>makecert</strong>.<strong>exe</strong> and <strong>PvkPfx</strong>.<strong>exe
</strong>as shown </span><span style="font-size:small">below<strong>:</strong></span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>makecert.exe</strong> -r -pe -n</span><br>
<span style="font-size:small">&quot;CN=TelemetryServiceMonitor&quot; -ss My -sr CurrentUser -e 08/04/2015 -sv</span><br>
<span style="font-size:small">c:\TelemetryServiceMonitor.pvk c:\TelemetryServiceMonitor.cer</span>
</li></ul>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>Pvk2Pfx</strong> /pvk c:\TelemetryService</span><span style="font-size:small">Monitor.pvk /pi &quot;password&quot; /spc c:\TelemetryServiceMonitor.cer</span><br>
<span style="font-size:small">/pfx c:\Telemetry</span><span style="font-size:small">ServiceMonitor.pfx</span>
</li></ul>
<p><br>
<br>
</p>
<p><span style="font-size:small">In order to use the </span><span style="font-size:small">Auth client credential grant with client assertion (which essentially replaces
</span><span style="font-size:small">he secret with a jwt signed by an X.509 certificate) you require your App</span><span style="font-size:small">cation configured on Windows Azure Active Directory to be able to verify th</span><span style="font-size:small">e
 client assertion (signed jwt that the client sends over). To do so you </span><span style="font-size:small">would need to provision the application object on your directory using Windows
</span><span style="font-size:small">Azure AD PowerShell with the X.509 certificate you intend to use. To set up
</span><span style="font-size:small">PowerShell on your machine follow the instructions
<a href="http://technet.microsoft.com/en-us/library/jj151815.aspx">here</a>. Once you have PowerShell set connect to your
</span><span style="font-size:small">tenant using the below commands:</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> connect-msolservice -credential $msolcred</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Once connected run the </span><span style="font-size:small">below to get all the service principal information on your tenant</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> Get-MsolServicePrincipal</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">You will see the list of </span><span style="font-size:small">all Service Principals registered on you tenant. Locate the service principals
</span><span style="font-size:small">associated with the <strong>TelemetryServiceMonitor,
</strong>you can do this by looking</span><br>
<span style="font-size:small">for the App ID URI you earlier specified for the monitor, once you have located</span><br>
<span style="font-size:small">the Service Principal details you will find among other tenant properties the AppPrincipalID.
</span><span style="font-size:small">Copy the AppPrincipalID and use the below steps to provision the X.509</span><br>
<span style="font-size:small">certificate on it.</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> $cer = New-Object</span><br>
<span style="font-size:small">System.Security.Cryptography.X509Certificates.X509Certificate</span></p>
<p><br>
<br>
</p>
<p>&nbsp;<span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> $cer.Import(&quot;<em>Path to Certificate (.cer) file</em>&quot;)</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> $binCert = $cer.GetRawCertData()</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> $credValue =</span><br>
<span style="font-size:small">[System.Convert]::ToBase64String($binCert);</span></p>
<p><br>
<br>
<br>
</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> New-MsolServicePrincipalCredential</span><br>
<span style="font-size:small">-AppPrincipalId &quot;Application Principal ID from above&quot; -Type</span><br>
<span style="font-size:small">asymmetric -Value $credValue -StartDate $cer.GetEffectiveDateString() -EndDate</span><br>
<span style="font-size:small">$cer.GetExpirationDateString() -Usage verify</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small">You can check if the </span><span style="font-size:small">certificate was provisioned successfully using the</span><br>
<span style="font-size:small">Get-MsolServicePrincipalCredential command</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>PS C:\windows\system32&gt;</strong> Get-MsolServicePrincipalCredential</span><br>
<span style="font-size:small">&ndash;ServicePrincipalName &ldquo;App ID URI<strong>&rdquo;</strong></span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>Updating TelemetryServiceWebAPI</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">1.&nbsp;&nbsp;Open the <strong>global</strong>.<strong>asax</strong>.<strong>cs
</strong></span><span style="font-size:small">file under <strong>TelemetryServiceWebAPI</strong> project.</span></p>
<p><br>
<span style="font-size:small">-Update the <strong>audience </strong></span><span style="font-size:small">with the service App ID URI, created in step 2 above while registering the
<strong>TelemetryServiceWebAPI</strong></span><br>
<span style="font-size:small">application on your tenant</span></p>
<p><span style="font-size:small">-Update the <strong>domainName </strong></span><span style="font-size:small">to your tenant/domain name</span></p>
<p>2<span style="font-size:small">.&nbsp;Open the <strong>web.config</strong> file under
<strong>TelemetryServiceWebAPI </strong>and<strong> </strong>replace the</span><br>
<span style="font-size:small">&ldquo;values&rdquo; associated with the <strong>ClientObjectID1</strong> and
<strong>MonitorObjectID </strong></span><span style="font-size:small">keys with the Object ID values for the
<strong>TelemetryServiceClient</strong> and <strong>TelemetryServiceMonitor<br>
</strong>projects respectively. &nbsp;To retrieve the Object Identifier values </span>
<span style="font-size:small">associated with your client applications follow the instructions below:</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">In order to configure </span><span style="font-size:small">the sample using the Object ID you first need to retrieve the value of the
</span><span style="font-size:small">Object ID. You can do this by running the Windows Azure AD PowerShell. To set</span><br>
<span style="font-size:small">up PowerShell on your machine follow the instructions
<a href="http://technet.microsoft.com/en-us/library/jj151815.aspx">here</a>. Once you have PowerShell set connect to your
</span><span style="font-size:small">tenant using the below commands:</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">PS</span><br>
<span style="font-size:small">C:\windows\system32&gt; connect-msolservice -credential $msolcred</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Once connected run the </span><span style="font-size:small">below to get all the service principal information on your tenant</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">PS C:\windows\system32&gt;</span> <span style="font-size:small">
Get-MsolServicePrincipal</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">You will see the list of </span><span style="font-size:small">all Service Principals registered on you tenant. Locate the service principals
</span><span style="font-size:small">associated with the <strong>TelemetryServiceClient</strong> and
<strong>TelemetryServiceMonitor,<br>
</strong>you can do this by looking for the App ID URI you earlier specified for </span>
<span style="font-size:small">these, once you have located the Service Principal details you will find among
</span><span style="font-size:small">other tenant properties the ObjectID. You can now use these to reconfigure your
</span><span style="font-size:small">sample.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">To run this sample, hit</span><br>
<span style="font-size:small">F5. The solution is configured to start the <strong>
TelemetryServiceWebAPI</strong></span><br>
<span style="font-size:small">project.</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small">In order to see the </span><span style="font-size:small">scenario in action, right click the
<strong>TelemetryServiceClient</strong> project, Goto </span><span style="font-size:small"><strong>Debug</strong> and select &ldquo;<strong>Start new instance</strong>&rdquo;. The application will
</span><span style="font-size:small">request a security token from Windows Azure AD and present it to the
</span><span style="font-size:small">TelemetryServiceWebAPI in order to POST device data to the service.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">To see that the data was </span><span style="font-size:small">actually posted we can use the
<strong>TelemetryServiceMonitor</strong>&nbsp; project, right </span><span style="font-size:small">click the
<strong>TelemetryServiceMonitor</strong> project, goto <strong>Debug</strong> and select</span><br>
<span style="font-size:small">&ldquo;<strong>Start new instance</strong>&rdquo;. The application will request a security token from
</span><span style="font-size:small">Windows Azure AD and present it to the <strong>
TelemetryServiceWebAPI</strong> in order </span><span style="font-size:small">to GET device data written to the service.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Details&nbsp;</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Let&rsquo;s take a quick look </span><span style="font-size:small">at the structure of the solution. For more detailed information, please refer
</span><span style="font-size:small">to the comments in the code.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small"><strong>TelemetryServiceClient</strong> and <strong>
TelemetryServiceMonitor</strong> are .Net 4.5 </span><span style="font-size:small">projects using AAL.&nbsp;
<strong>TelemetryServiceWebAPI</strong> is a .Net 4.5 project </span><span style="font-size:small">using the JWT handler to validate the JWT token received from the
</span><span style="font-size:small">TelemetryServiceClient and TelemetryServiceMonitor. AAL is provided in the
</span><span style="font-size:small">&ldquo;Windows Azure Authentication Library Beta&rdquo; NuGet package and
<em>JWTSecurityTokenHandler </em></span><span style="font-size:small">in the &ldquo;JSON Web Token Handler for Microsoft .Net Framework 4.5&rdquo; NuGet package.
</span><span style="font-size:small">Notice the assemblies &ldquo;<strong>Microsoft.WindowsAzure.ActiveDirectory.Authentication</strong>&rdquo;&nbsp;
</span><span style="font-size:small">and &ldquo;<strong>System.IdentityModel.Tokens.JWT</strong>&rdquo; under the references node in the
</span><span style="font-size:small">Solution Explorer in Visual Studio for these projects respectively.</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify"><span style="font-size:small">Let&rsquo;s start from the
</span><span style="font-size:small">requesting side of the solution. Open the <strong>
TelemetryServiceMonitor</strong></span><br>
<span style="font-size:small">project and look at the <strong>app.config</strong>. Here you will see some values that
</span><span style="font-size:small">are used later by ADAL:</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify"><span style="font-size:small">1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small"><em>Tenant</em></span><br>
<br>
<span style="font-size:small">This value represents the full URL identifying the Windows Azure Active</span><br>
<span style="font-size:small">Directory tenant that contains all the settings describing the scenario.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small"><em>Resource</em></span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">This is an identifier
</span><span style="font-size:small">within the tenant for the service we are accessing. When working with a
</span><span style="font-size:small">directory tenant this value is specified in the form of
</span><span style="font-size:small">an App ID URI.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">ClientID</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">The unique identifier
</span><span style="font-size:small">for your app.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CertificatePath</span><br>
<span style="font-size:small">and CertificatePassword: These values reference the path and password of the</span><br>
<span style="font-size:small">certificate the application uses to sign the jwt token it sends to your</span><br>
<span style="font-size:small">directory tenant. The application corresponding to the TelemetryServiceMonitor</span><br>
<span style="font-size:small">on your directory needs to have the corresponding public key (.cer) configured</span><br>
<span style="font-size:small">in order to verify the incoming jwt signature.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">6. ResourceUrl</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">This is the physical </span><span style="font-size:small">address for the service we are accessing, for instance once you host your
</span><span style="font-size:small">service to a production environment your physical address will change from</span><br>
<span style="font-size:small">http://localhost:XXX/ to https://XYZ.cloudapp.net/</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">The <strong>TelemetryServiceClient
</strong></span><span style="font-size:small">project&rsquo;s <strong>app.config </strong>
has similar values as described above. The </span><span style="font-size:small">CertificatePath and CertificatePassword are however replaced with just the</span><br>
<span style="font-size:small">client secret:</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small"><em>ClientSecret</em></span><br>
<br>
<span style="font-size:small">The ServicePrincipal credentials assigned to TelemetryServiceClient&rsquo;s ServicePrincipal.</span><br>
<span style="font-size:small">TelemetryServiceClient uses it to identify itself with Windows Azure AD in
</span><span style="font-size:small">order to obtain a token.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">Moving on to the service
</span><span style="font-size:small">side: open the <strong>TelemetryServiceWebAPI</strong> project and examine and examine
<strong>Global.asax.cs</strong>. </span><span style="font-size:small">The most interesting class here is
<em>TokenValidationHandler, </em>an </span><span style="font-size:small">implementation of DelegatingHandler.&nbsp;
<em>TokenValidationHandler&lsquo;s </em>purpose </span><span style="font-size:small">is<em>
</em>to process request messages before they reach the application code </span><span style="font-size:small">and enforce authentication requirements. The method
<em>TryRetrieveToken </em></span><span style="font-size:small">inspects incoming http requests to verify if the authorization header contains
</span><span style="font-size:small">an OAuth2 header with a bearer token. If a bearer token is not found, the
</span><span style="font-size:small">request is not authorized and an unauthorized status code is sent back to the
</span><span style="font-size:small">Client. If the header contains a bearer token, it is validated through the
<em>JWT handler</em>. A <em>TokenValidationParameters </em>object is created to set the
</span><span style="font-size:small">expected properties, issuer, audience and signing token, on the token. The
</span><span style="font-size:small">method <em>JWT handler.ValidateToken()</em> is then called to validate the token
</span><span style="font-size:small">and, upon successful validation, a new <em>ClaimsPrincipal</em> instance is set
</span><span style="font-size:small">as the Principal of the current thread and as the Current user in HttpContext.</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify">&nbsp;<span style="font-size:small"><strong>TelemetryServiceWebAPI</strong> additionally enforces access control by
</span><span style="font-size:small">ensuring that only specific clients are allowed to perform a POST and others a
</span><span style="font-size:small">GET. In order to enforce this access control the Service relies on checking the
</span><span style="font-size:small">Object ID claim </span><span style="font-size:small">(&ldquo;http://schemas.microsoft.com/identity/claims/objectidentifier&rdquo;) of incoming
</span><span style="font-size:small">request in the claim and restricts actions in the DevicesController.cs class.
</span><span style="font-size:small">The expected Object ID of the <strong>TelemetryServiceMonitor</strong> and
<strong>TelemetryServiceClient </strong></span><span style="font-size:small">can be set in the
<strong>web.config</strong> of the <strong>TelemetryServiceWebAPI</strong>.</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify"><span style="font-size:small"><strong>Deploying the Telemetry Service to Windows Azure</strong></span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">The sample solution is d</span><span style="font-size:small">signed to run from your local machine; you can explore the scenario without
</span><span style="font-size:small">being required to have a Windows Azure subscription, and in fact you can choose
</span><span style="font-size:small">to use ADAL to connect to Windows Azure Active Directory regardless of where</span><br>
<span style="font-size:small">you will run your services. <strong>Note:</strong> Once you are getting ready to deploy
</span><span style="font-size:small">to a production environment you <strong>must</strong> use SSL to secure you service.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">That said, here are</span><span style="font-size:small">detailed instructions you can follow if you want to deploy the
<strong>TelemetryServiceWebAPI </strong></span><span style="font-size:small">o Windows Azure.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">&nbsp;The steps below
</span><span style="font-size:small">assume that you are using the October 2012 release of the Windows Azure SDK.
</span><span style="font-size:small">lso note that to debug you will need to run VS in administrator mode.</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify"><span style="font-size:small">1.&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">In the Solution Explorer, right click on the
<strong>TelemetryServiceWebAPI </strong></span><span style="font-size:small">project and choose
<em>Add Windows Azure Cloud Service Project</em>.&nbsp; This </span><span style="font-size:small">will create a new project called
<strong>TelemetryServiceWebAPI.Azure</strong>.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">2.&nbsp;</span><span style="font-size:small">To publish select
<em>Publish</em> on the <strong>TelemetryServiceWebAPI.Azure </strong></span><span style="font-size:small">project. Select the Cloud Service where you would like to deploy to and choose
<em>Publish</em>.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">Make sure that the
<strong>TelemetryServiceWebAPI </strong>project references the 64 bit</span><br>
<span style="font-size:small">version of AAL.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">4.&nbsp;&nbsp;&nbsp;O</span><span style="font-size:small">nce published open
<strong>app.config</strong> in the <strong>TelmetryServiceMonitor</strong> and <strong>
TelemetryServiceClient </strong>project and change the <em>ResourceUrl</em> value to your URL of the</span><br>
<span style="font-size:small">published service.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">Once the deployment has taken place you can start an instance of the
<strong>TelemetryServiceMonitor</strong></span><br>
<span style="font-size:small">followed by the <strong>TelemetryServiceClient</strong> as described earlier.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small"><strong>Security Considerations</strong></span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">1.&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">The JWT Tokens issued by Windows Azure AD are not encrypted and hence must be</span><br>
<span style="font-size:small">sent to the Service on a secure channel like https in order to prevent</span><br>
<span style="font-size:small">information disclosure, spoofing and other security attacks.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">2.&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">The exceptions thrown by the JWT handler could contain sensitive information</span><br>
<span style="font-size:small">and it is up to the applications using it to make sure that this sensitive</span><br>
<span style="font-size:small">information is not sent to the Client.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span style="font-size:small">3.&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">JWT handler could be configured to do audience verification. The security</span><br>
<span style="font-size:small">implications of turning off these checks should be understood.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">4.&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:small">JWT handler does not log the token but applications logging the tokens should</span><br>
<span style="font-size:small">be careful about information disclosure.&nbsp;</span></p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><br>
<br>
</p>
<p style="text-align:justify">&nbsp;</p>
<p class="MsoNormal" style="margin:0in 0in 8pt; text-align:justify; line-height:normal">
<span style="font-size:small"><span style="line-height:107%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
