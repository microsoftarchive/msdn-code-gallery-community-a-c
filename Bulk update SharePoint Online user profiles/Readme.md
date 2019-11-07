# Bulk update SharePoint Online user profiles
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Web Services
- Office 365
- Sharepoint Online
- Claims Authentication
## Topics
- Bulk Update
- User Profiles
## Updated
- 01/06/2014
## Description

<p>This sample code show how user profiles in SharePoint Online can be updated via the legacy SOAP web service. It also provides information how the authentication procedure works in SharePoint Online. Through the limitation to the user profile REST API this
 is the only way to update.</p>
<p>In Office 365 the authentication is a bit different and an authentication cookie needs to be passed.</p>
<p>The longer explanation how to authentication against Office 365 work can be found in the MSDN article
<a href="http://msdn.microsoft.com/en-us/library/hh147177(v=office.14).aspx">Remote Authentication in SharePoint Online Using Claims-Based Authentication</a>. Another great source of information is the blog post &ldquo;<a href="http://www.wictorwilen.se/post/How-to-do-active-authentication-to-Office-365-and-SharePoint-Online.aspx">How
 to do active authentication to Office 365 and SharePoint Online</a>&rdquo; by Wictor Wil&eacute;n. In this article Wictor provides a helper object that make the authentication process easy. His solution is mainly targeted on SharePoint 2010 in Office 365 but
 this still works in the recent version of SharePoint Online.</p>
<p><em>The Authentication against SharePoint Online Web Services is much simpler now and is also covered in this sample. The new introduced authentication object
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.sharepointonlinecredentials.aspx">
SharePointOnlineCredentials.</a>&nbsp;</em></p>
<p>&nbsp;</p>
<p><em>The followin code provides the basic steps to do this.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Pass the username and password to SharePointOnlineCredentials constructor
// Password needs to be passed as a System.Security.SecureString
SharePointOnlineCredentials onlineCred = new SharePointOnlineCredentials(_username, mySecurePassword);

// Get the authentication cookie by passing the url of the web service
string authCookie = onlineCred.GetAuthenticationCookie(_adminUrl);

// Create a CookieContainer to authenticate against the web service
CookieContainer authContainer = new CookieContainer();

// Put the authenticationCookie string in the container
authContainer.SetCookies(_adminUrl, _authCookie);

// Setting up the user profile web service
UserProfileWS.UserProfileService upService = new UserProfileWS.UserProfileService();

// assign the correct url to the web service
upService.Url = _adminUrl.AbsoluteUri;

// Assign previously created auth container to web service
upService.CookieContainer = authContainer;
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Pass&nbsp;the&nbsp;username&nbsp;and&nbsp;password&nbsp;to&nbsp;SharePointOnlineCredentials&nbsp;constructor</span>&nbsp;
<span class="cs__com">//&nbsp;Password&nbsp;needs&nbsp;to&nbsp;be&nbsp;passed&nbsp;as&nbsp;a&nbsp;System.Security.SecureString</span>&nbsp;
SharePointOnlineCredentials&nbsp;onlineCred&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharePointOnlineCredentials(_username,&nbsp;mySecurePassword);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;authentication&nbsp;cookie&nbsp;by&nbsp;passing&nbsp;the&nbsp;url&nbsp;of&nbsp;the&nbsp;web&nbsp;service</span>&nbsp;
<span class="cs__keyword">string</span>&nbsp;authCookie&nbsp;=&nbsp;onlineCred.GetAuthenticationCookie(_adminUrl);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;CookieContainer&nbsp;to&nbsp;authenticate&nbsp;against&nbsp;the&nbsp;web&nbsp;service</span>&nbsp;
CookieContainer&nbsp;authContainer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CookieContainer();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Put&nbsp;the&nbsp;authenticationCookie&nbsp;string&nbsp;in&nbsp;the&nbsp;container</span>&nbsp;
authContainer.SetCookies(_adminUrl,&nbsp;_authCookie);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Setting&nbsp;up&nbsp;the&nbsp;user&nbsp;profile&nbsp;web&nbsp;service</span>&nbsp;
UserProfileWS.UserProfileService&nbsp;upService&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UserProfileWS.UserProfileService();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;assign&nbsp;the&nbsp;correct&nbsp;url&nbsp;to&nbsp;the&nbsp;web&nbsp;service</span>&nbsp;
upService.Url&nbsp;=&nbsp;_adminUrl.AbsoluteUri;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Assign&nbsp;previously&nbsp;created&nbsp;auth&nbsp;container&nbsp;to&nbsp;web&nbsp;service</span>&nbsp;
upService.CookieContainer&nbsp;=&nbsp;authContainer;&nbsp;</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>How it works</h1>
<p>The data will be imported from a tab separated text file. The following amage shows the update working.</p>
<p><img id="106529" src="106529-command-line-import.jpg" alt="" width="676" height="343"></p>
<h1>More Information</h1>
<p><em>I wrote a blog post that covers all the parts in this solution. This can be found under the title &quot;<a href="http://www.n8d.at/blog/bulk-update-sharepoint-user-profiles-in-office-365/">Bulk update SharePoint User Profiles in Office 365</a>&quot;&nbsp;</em></p>
