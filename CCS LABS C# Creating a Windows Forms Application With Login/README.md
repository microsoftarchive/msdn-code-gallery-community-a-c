# CCS LABS C#: Creating a Windows Forms Application With Login
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- SQL Server
- .NET
- Windows Forms
- Visual Studio 2010
- .NET Framework 4
- .NET Framework
- Visual Basic .NET
- VB.Net
- Windows General
- C# Language
- WinForms
- SQL Server Compact
- .NET 4.5
## Topics
- C#
- SQL
- Security
- SQL Server
- Authentication
- User Interface
- Windows Forms
- Architecture and Design
- Data Access
- Web Services
- input
- Visual Basic .NET
- Code Sample
- UAC
- Getting Started
- .NET 4
- How to
- UI Design
- forms-based authentication
- general
- C# Language Features
- User Experience
- data and storage
## Updated
- 12/17/2013
## Description

<h1>Description</h1>
<p>It is often necessary to only permit authenticated users to use our applications. There is no predefined method of doing this within Windows Forms, unlike Web Forms and ASP.NET. In this tutorial I have written the bare bones of a login system that uses a
 local database - you will want to change that to a database that you control.</p>
<h1>Building And Running</h1>
<p>The application was written in C# .Net 4, in Visual Studio 2010. It was created on Windows Server 2008 R2. So should work on any Windows based machine from Vista up - with the correct .Net application installed. As it does not require UAC - it should also
 run on Windows XP.</p>
<h1>The Database</h1>
<p>The database is simple, it has a unique ID for each user added to the table, a column for the username and a column for the password. And that is all there is too it.</p>
<h1>How it Works</h1>
<p>The main application calls the login form as soon as it starts. The login form validates the users name and password against the database using a custom sql query which returns the userID of the person with those matching username and password combination.</p>
<p>If the user wishes to register they simply click a link - which allows them to register using their username, password and a repeat of the password to make sure they have not mistyped. The login form hides the password but this registration form does not
 - you can change that by adding the password character you wish to use in the textbox's properties window.</p>
<p>If the user registers or logs in successfully the windows are closed and the main application is informed the user has authenticated. The main application is also given the user's username; which could be used for logging purposes. If, however, authentication
 fails the application is closed.</p>
<h1>Future Considerations</h1>
<ol>
<li>
<div>You could add roles to the database allowing users within a role to do certain actions where others can not.</div>
</li><li>
<div>You should encrypt the user password at the very least.</div>
</li><li>
<div>You should use a database that you have control over and not one local to the usersof the application.</div>
</li><li>
<div>You should have a timeout if the user does not use their machine for a few minutes - the user should be logged out automatically, with any sensitive data hidden from prying eyes.</div>
</li></ol>
<p>Do not forget to rate this contribution please.</p>
<p>If you like my samples then please nominate me for an MVP. <a href="http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx">
http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx</a>. Leave me a message if you nominated me!</p>
<h1>Update:</h1>
<p>The code had some logical errors in it which have now been fixed.</p>
<p>Updated to Visual Studio 2012 - you can use <a href="http://www.codeproject.com/Articles/70569/Microsoft-Visual-Studio-Solution-File-Version-Chan" target="_blank">
this </a>to change the version to previous Visual Studio version.</p>
