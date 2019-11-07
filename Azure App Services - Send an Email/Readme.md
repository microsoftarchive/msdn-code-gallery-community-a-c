# Azure App Services - Send an Email
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Azure
- Windows Azure Web Sites
## Topics
- C#
- Azure
- Windows Azure Web Sites
## Updated
- 01/25/2016
## Description

<h1>Introduction</h1>
<p><em>There are numerous ways to send emails from an Azure App Server (Web App) for example using SendGrid from the market place or sending an email using your O365 SMTP server.&nbsp;</em></p>
<p><em>A point to consider when sending emails from an App Service is that if you send spam or to many emails, then the IP address of your App will be blacklisted and it will shutdown your App.&nbsp; So do not use an Azure Web App to send spam or bulk emails.</em></p>
<p><em>See More Information for 2 articles I wrote about sending emails from Azure App Services.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Unzip the code and open the solution.&nbsp; There are 3 places where you need to modify the code to make it work for you.&nbsp;
</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em></p>
<ol>
<li>Replace existing content with&nbsp;your email address and name on line 14. </li><li>Replace existing content with a 'from' email address and name on line 15. </li><li>Replace existing content with your O365 user id and password on line 22.&nbsp; You might consider placing these in a configuration file and accessing them via code instead of hard coding them.
</li></ol>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Use the System.Net.Mail namespace to run&nbsp;access and send emails from your&nbsp;Azure App&nbsp;Service.&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MailMessage msg = new MailMessage();
msg.To.Add(new MailAddress(&quot;TO&quot;, &quot;Benjamin&quot;));
msg.From = new MailAddress(&quot;From&quot;, &quot;You&quot;);
msg.Subject = &quot;Azure Web App Email&quot;;
msg.Body = &quot;Test message from a Web App&quot;;
msg.IsBodyHtml = true;
SmtpClient client = new SmtpClient();
client.UseDefaultCredentials = false;
client.Credentials = new System.Net.NetworkCredential(&quot;UID&quot;, &quot;PASS&quot;);
client.Port = 587;
client.Host = &quot;smtp.office365.com&quot;;</pre>
<div class="preview">
<pre class="csharp">MailMessage&nbsp;msg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage();&nbsp;
msg.To.Add(<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;TO&quot;</span>,&nbsp;<span class="cs__string">&quot;Benjamin&quot;</span>));&nbsp;
msg.From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;From&quot;</span>,&nbsp;<span class="cs__string">&quot;You&quot;</span>);&nbsp;
msg.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Azure&nbsp;Web&nbsp;App&nbsp;Email&quot;</span>;&nbsp;
msg.Body&nbsp;=&nbsp;<span class="cs__string">&quot;Test&nbsp;message&nbsp;from&nbsp;a&nbsp;Web&nbsp;App&quot;</span>;&nbsp;
msg.IsBodyHtml&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
SmtpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SmtpClient();&nbsp;
client.UseDefaultCredentials&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
client.Credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Net.NetworkCredential(<span class="cs__string">&quot;UID&quot;</span>,&nbsp;<span class="cs__string">&quot;PASS&quot;</span>);&nbsp;
client.Port&nbsp;=&nbsp;<span class="cs__number">587</span>;&nbsp;
client.Host&nbsp;=&nbsp;<span class="cs__string">&quot;smtp.office365.com&quot;</span>;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>default.aspx -&nbsp;contains a label to display if the email was sent ok or not.</em>
</li><li><em><em>default.aspx.cs - contains the source to send an email from an Azure App Service.</em></em>
</li><li><em>web.config - contains the default ASP.NET web site configurations for 4.6</em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on sending emails see these posts:</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em></p>
<ul>
<li>Sending emails using Send Grid from an Azure Web App -&gt; <a href="http://blogs.msdn.com/b/benjaminperkins/archive/2015/02/02/sending-an-email-from-azure-websites-using-sendgrid.aspx">
http://blogs.msdn.com/b/benjaminperkins/archive/2015/02/02/sending-an-email-from-azure-websites-using-sendgrid.aspx</a>
</li><li>Sending emails using O365 SMTP Exchange Online -&gt; <a href="http://blogs.msdn.com/b/waws/archive/2015/10/09/sending-email-from-an-azure-web-app-using-an-O365-smtp-server.aspx">
http://blogs.msdn.com/b/waws/archive/2015/10/09/sending-email-from-an-azure-web-app-using-an-O365-smtp-server.aspx</a>
</li></ul>
</em>
<p></p>
