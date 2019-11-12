# Autodiscover Checker 2.2
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- EWS
- Microsoft Exchange Server 2007
- Microsoft Exchange Server 2010
- Autodiscovery
- autodiscover
## Topics
- autodiscover
- Coding
- Exchange Managed API
- SCP Lookup
- POX Autodiscover
## Updated
- 06/21/2013
## Description

<h1>Introduction</h1>
<p><em>This sample uses the Exchange Managed API&nbsp;2.0&nbsp;and custom code to do several forms of&nbsp;autodiscover against Exchange. It handles callbacks for doing redirection and certificates.&nbsp; Logging is provided for referrels, redirection, certificates
 and network activity. This code will work for both on-premise and hosted Exchange servers such as Exchange Online/Office 365.&nbsp;&nbsp;</em><em>&nbsp; There&nbsp;is&nbsp;example contained&nbsp;written in raw C# code
</em><em>that shows how you might do the POX, SCP look-up and SOAP Autodiscover processes.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You will need to use Visual Studio 2010 to build the project.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span>This unsupported sample provides help by demonstrating how to properly call the<br>
Exchange AutoDiscovery web service. Executing the built application can be used<br>
for gathering information on what is accessed during the AutoDiscover process<br>
and also be used for troubleshooting. If you use the code or executable, you<br>
are responsible for its usage and will need to take ownership of the code - you<br>
should also only use this in a test lab and not production. </span></em></p>
<p><span>This is sample code and there are no implied warranties or guarantees as to its<br>
behavior. If you use this app or its code, you need to take 100% responsibility<br>
for its code and its usage. It&rsquo;s considered to be unsupported sample code which<br>
demonstrates the concept of doing AutoDiscovery with the Exchange Managed API and<br>
should only be used in a lab environment.</span></p>
<p>&nbsp;</p>
<p>For external AutoDiscovery and connectivity checker, be sure to look at the Remote Connectivity Analyzer.</p>
<p>Remote Connectivity Analyzer</p>
<p>&nbsp;&nbsp;&nbsp; <a href="https://www.testexchangeconnectivity.com/">https://www.testexchangeconnectivity.com/</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.Security.RemoteCertificateValidationCallback&nbsp;oCallback&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(service.RedirectionUrlValidationCallback&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;a&nbsp;prior&nbsp;one&nbsp;was&nbsp;set,&nbsp;save&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oCallback&nbsp;=&nbsp;ServicePointManager.ServerCertificateValidationCallback;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Save&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServicePointManager.ServerCertificateValidationCallback&nbsp;=&nbsp;oAutodiscoveryCallbackHelper.CertificateValidationCallBack;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;service.RedirectionUrlValidationCallback&nbsp;=&nbsp;oAutodiscoveryCallbackHelper.RedirectionUrlValidationCallbackAllowAnything;&nbsp;
&nbsp;
...&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oResponse&nbsp;=&nbsp;service.GetUserSettings(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sUserSmtpAddress,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserSettingName.ActiveDirectoryServer,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserSettingName.AlternateMailboxes,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserSettingName.CasVersion,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserSettingName.ExternalEwsUrl,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserSettingName.InternalEwsUrl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
