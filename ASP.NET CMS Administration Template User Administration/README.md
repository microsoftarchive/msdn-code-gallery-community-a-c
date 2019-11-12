# ASP.NET CMS: Administration Template User Administration
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- AJAX
- SQL
- SQL Server
- ASP.NET
- XML
- Microsoft Azure
- XAML
- Windows Phone 7
- SQL Azure
- .NET Framework
- Javascript
- Visual Basic .NET
- ASP.NET Web Forms
- Visual Basic.NET
- VB.Net
- Windows General
- Windows Phone
- C# Language
- HTML
- Async
- HTML5
- Windows 8
- ASP.NET Web API
- Visual Studio 2012
- Windows Phone 7.5
- .NET 4.5
- Windows RT
- Windows Phone 8
## Topics
- Controls
- C#
- Data Binding
- AJAX
- Asynchronous Programming
- Security
- Authentication
- ASP.NET
- User Interface
- Architecture and Design
- Microsoft Azure
- Data Access
- XAML
- threading
- customization
- UI Layout
- Javascript
- Visual Basic .NET
- Rapid Application Development
- Parallel Programming
- UAC
- Getting Started
- HTML
- Async
- HTML5
- .NET 4
- How to
- UI Design
- Membership
- HTTP
- C# Language Features
- ASP.NET Web API
- User Experience
- Role Based Access Control
- sites and content
## Updated
- 12/06/2013
## Description

<h1>Introduction</h1>
<p><em>The next stage in adding functionality to the user administration section of our ASP.NET Administration template is to allow ourselves to create new users and assign them the roles that we created in the previous article. We will also of course allow
 End Users (EUs) to register themselves and automatically assign them the minimum authenticated role we have.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This code has been written on Windows Server 2008 RC2, and developed using Microsoft Visual Studio 2012 It should work perfectly well on any computer running Windows XP and higher.</em></p>
<p><em>You will need to add your own connection strings to the solution; found in the Web Config file.</em></p>
<p><em>The application will NOT build. This is deliberate - there is a small error concerning the creation of the user. It is your task in this example to work out what the error is and where the information is that will let you fix the error. You will also
 want to create your messages for successfully creating the user as well as failing to create the user.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>I am not going to go into great depths about user management, authorisation and authentication - there are complete books on the subject. At the end of this article there are links to some excellent resources that you should read if you wish to turn this
 tutorial work into a production ready solution.</p>
<p>Ok, so we know now how to create roles and you will have added the logic for updating and deleting roles. Now we need to create the Users who we will assign roles to. In this tutorial we are of course only interested in the back-end administration aspects
 of user management and not the user's self-registration process - I will leave that to you; although I will show you how to assign a role to their registration proceedure.</p>
<p>The natural reason for an administrator to want to add user's manually is so that they can assign special priviledges to an individual or for creating test users for themselves with each individual role assigned.</p>
<p><span style="color:#ff0000">Remember to rate these articles please. Without the ratings I can not tell if I am giving too much or not enough information!</span></p>
<p><span style="font-size:20px; font-weight:bold">Procedure</span></p>
<ol>
<li>You should already have your connection string set-up from previous articles. If you use the download available from this article you will need to re-set the connection string again in web.config
</li><li>In your solution explorer add a new item, web form using admin.master file. Save it as ManageUsers.aspx
</li><li>Get rid of any unnecessary content holders in the new file - so that the admin.master content is shown
</li></ol>
<p>The basic setup following the proceedure we designed in the Roles tutorial produces this:</p>
<p><img id="60444" src="60444-screenhunter_02%20jul.%2002%2013.24.gif" alt="" width="890" height="117"></p>
<p>You will notice the ApplicationId's are different. This is from previous work I have done. You need to be aware that you need to filter your users by ApplicationId before displaying them, to End Users, although it is ok for the Super Administrator - if and
 only if - the Super Administrator is the same for all applications using this database.</p>
<p>So the first thing we need to do is filter the users according to our current application id, which means we need to know what our application id is. Our aspnetdb contains an Application table where we can look up the ApplicationId using the application
 name which you set in your web config.... correct? If you did not do that, then do it now; If this application is to work on a web farm it needs to have a fixed Application Name and not an ASP.NET auto-generated one.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;applicationID&nbsp;from&nbsp;Applications&nbsp;table.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Guid&nbsp;getApplicationID()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;appName&nbsp;=&nbsp;<span class="cs__string">&quot;cmsCCSLABS&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guid&nbsp;aID&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Guid();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Connect&nbsp;to&nbsp;Database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(SqlDataSource1.ConnectionString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;SELECT&nbsp;(ApplicationId)&nbsp;FROM&nbsp;aspnet_Applications&nbsp;WHERE&nbsp;ApplicationName='&quot;</span>&nbsp;&#43;&nbsp;appName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;';&quot;</span>,&nbsp;conn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;aID&nbsp;=&nbsp;(Guid)command.ExecuteScalar();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;exx&nbsp;=&nbsp;ex.Message;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;aID;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The above method gets the ApplicationId from aspnet_Applications table. You will have to check to see if your table is called the same. I have hard coded my appName = although we should have this in our settings, or extract
 it from our web.config. This gives us the ApplicationId from our ApplicationName - now we can limit the usernames to our running application.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">So, with what we have done so far - now, we still have to add the functionality to Add, Delete and Update Members. Then, we will need to add members to roles. So we have quite a lot to do yet. However, in this tutorial we are simply
 going to produce the functionality to add, delete and update. In the next sub-tutorial on User Administration we will combine what we have done so that the membership system and the roles system work in unison.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Adding, Deleting, and Updating, are the basics of all user administration; although additional considerations are often required such as suspended accounts, or frozen accounts because of investigations due to litigation. These additional
 considerations could be placed in the membership database however, it is probably better to create a new table which holds additional information such as profiles and statuses, messages and notes etc.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Once we have added the labels, textboxes and link buttons for adding, updating and deleting we simply double click each button to create the event and move to the code behind method so we can implement the required functionality.</div>
<div class="endscriptcode"></div>
<p>Roles were created using Roles.Add, Users, are created using Membership.CreateUser, and requires a minimum of Username and Password. That is all I have implemented for you; I am sure you can work the rest out for yourself. I will also leave you to work out
 how to update and delete the users.</p>
<p>If you like my samples then please nominate me for an MVP. <a href="http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx">
http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx</a>. Leave me a message if you nominated me!</p>
<h1>More Information</h1>
<p>Team View Service, Azure Services and Azure SQL</p>
<ol>
<li><a href="https://tfspreview.com/en-us/learn/start/connect-to-vs/" target="_blank">https://tfspreview.com/en-us/learn/start/connect-to-vs/</a>
</li><li><a href="http://blogs.msdn.com/b/bharry/archive/2012/06/07/announcing-continuous-deployment-to-azure-with-team-foundation-service.aspx" target="_blank">http://blogs.msdn.com/b/bharry/archive/2012/06/07/announcing-continuous-deployment-to-azure-with-team-foundation-service.aspx</a>
</li></ol>
<p>Authentication and Authorisation</p>
<ol>
<li><a href="http://www.4guysfromrolla.com/articles/121405-1.aspx">http://www.4guysfromrolla.com/articles/121405-1.aspx</a>
</li><li><a href="http://weblogs.asp.net/scottgu/archive/2006/04/22/Always-set-the-_2200_applicationName_2200_-property-when-configuring-ASP.NET-2.0-Membership-and-other-Providers.aspx">http://weblogs.asp.net/scottgu/archive/2006/04/22/Always-set-the-_2200_applicationName_2200_-property-when-configuring-ASP.NET-2.0-Membership-and-other-Providers.aspx</a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/t32yf0a9.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/t32yf0a9.aspx</a>
</li></ol>
<p>&nbsp;</p>
<ul>
<li><em>I will add additional tutorials on this subject adding more advanced features to the original template until we end up with a full CMS written with your needs in mind. Past, Current and Future topics:
<br>
</em></li><li><a href="http://code.msdn.microsoft.com/Advanced-ASPNET-Administrat-f980b166" target="_blank">Introduction</a>
</li><li><a href="http://code.msdn.microsoft.com/ASPNET-CMS-Administration-482dcaf9" target="_blank">Customization I: The basics</a><em><br>
</em><a href="http://code.msdn.microsoft.com/ASPNET-CMS-Administration-31863627" target="_blank">Customization 2: Advanced</a>
</li><li><a href="http://code.msdn.microsoft.com/ASPNET-CMS-Administration-1f03ceef" target="_blank">Adding User Administration</a>
<ul>
<li><a href="http://code.msdn.microsoft.com/ASPNET-CMS-Administration-681f425b" target="_blank">User Administration</a>
</li><li><a href="http://code.msdn.microsoft.com/ASPNET-CMS-Administration-1f03ceef" target="_blank">Roles Administration</a>
</li><li><a href="http://code.msdn.microsoft.com/ASPNET-From-Scratch-CMS-6d16b251" target="_blank">Adding Users With Roles</a>
</li></ul>
</li><li><a href="http://code.msdn.microsoft.com/ASPNET-From-Scratch-CMS-11758972" target="_blank">Adding Database Administration</a>
</li><li><a href="http://code.msdn.microsoft.com/ASPNET-From-Scratch-CMS-d8da2918" target="_blank">Adding Content Administration</a>
<ul>
<li><a href="http://code.msdn.microsoft.com/ASPNET-From-Scratch-CMS-4cc3a1ab" target="_blank">Frontend Template customization
</a></li></ul>
</li><li>Adding Site Administration </li><li>... and anything you think you need here </li></ul>
<p>However, I will not add these tutorials if no one is interested in this, so if you are interested then rate this article please.</p>
