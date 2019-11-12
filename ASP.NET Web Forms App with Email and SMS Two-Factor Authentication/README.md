# ASP.NET Web Forms App with Email and SMS Two-Factor Authentication
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web Forms
- ASP.NET 4.5
- Visual Studio Express 2013 for Web
- Twilio
- Send Grid
## Topics
- ASP.NET Authentication
- ASP.NET Two-Factor Authentication
## Updated
- 10/17/2014
## Description

<h2>Introduction</h2>
<p>This download has been created to accompany the following tutorials:</p>
<ul>
<li><a href="http://www.asp.net/web-forms/overview/security/create-a-secure-aspnet-web-forms-app-with-user-registration,-email-confirmation-and-password-reset">Create a secure ASP.NET Web Forms app with user registration, email confirmation and password reset</a>
</li><li><a href="http://www.asp.net/web-forms/overview/security/create-an-aspnet-web-forms-app-with-sms-two-factor-authentication">Create an ASP.NET Web Forms app with SMS Two-Factor Authentication</a>
</li></ul>
<p>The first of the above two tutorials shows you how to build an ASP.NET Web Forms authentication app with user registration, email confirmation and password reset using the ASP.NET Identity membership system. The second tutorial shows you how to build an
 ASP.NET Web Forms app with Two-Factor Authentication. This code sample was created by following the steps provided in each tutorial. When you have completed both of the above two tutorials, you will have an app that provides the same functionality that is
 provided by this sample app.</p>
<h2>Running the Sample</h2>
<p>Before you can run this sample, you must create the following:</p>
<ul>
<li>A Send Grid account </li><li>A Twilio account </li></ul>
<p>Specific values from each of these accounts are used to successfully call the APIs related to these two accounts.</p>
<table border="0">
<tbody>
<tr>
<td>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml">&nbsp;&nbsp;<span class="xml__tag_start">&lt;appSettings</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;SendGrid&nbsp;Credentials--&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;emailServiceUserName&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;[EmailServiceAccountUserName]&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;emailServicePassword&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;[EmailServiceAccountPassword]&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;Twilio&nbsp;Credentials--&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;SMSSID&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;[SMSServiceAccountSID]&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;SMSAuthToken&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;[SMSServiceAuthorizationToken]&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;SMSPhoneNumber&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;&#43;[SMSPhoneNumber]&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/appSettings&gt;</span>&nbsp;
&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</td>
</tr>
</tbody>
</table>
<h2>Application Scenarios and Tasks</h2>
<p>The scenarios and tasks presented in the tutorials related to this ASP.NET Web Forms sample app include:</p>
<ul>
<li>Installing and enabling SendGrid and Twilio </li><li>Emailing confirmation before logging-in </li><li>Password recovery and reset </li><li>Resending an email confirmation link </li><li>Setting up SMS and two-factor authentication </li><li>Enabling two-factor authentication for registered users </li></ul>
