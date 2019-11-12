# ASP.NET N Tier WCF sample application implementation on separate machines.
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- WCF
- SQL Server
- ASP.NET
- Visual Studio 2010
## Topics
- Architecture and Design
- Distributed Applications
## Updated
- 10/03/2011
## Description

<h1>Introduction</h1>
<p>This Sample cover the below requirements</p>
<p><em>We have three separate <strong>Web Server</strong>, <strong>Application server</strong> and
<strong>DB Server</strong>. looking for true 3-Tier WEB Server : ASP.NET Web Pages ( .aspx) ( Presentation Tier) :APP Server: WCF ( Business/ Data Access tier) :DB Server(SQL Server) : Sample DB table.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Visual Studio 2010</em></p>
<p><em>C#</em></p>
<p><em>WCF</em></p>
<p><em>SQL Server</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>You can divide the Sample into 3 layers</em></p>
<ol>
<li><em>Presentation layer (Aspx pages,user controls , master pages , them,...)</em>
</li><li><em>Business layer (WCF Service, Business Code , Data Access layer ,...)</em>
</li><li><em>Database layer (DataBase ,Tables , Stored procedures)&nbsp;</em> </li></ol>
<p>For example, the business rules now go on a separate machine and you use WCF Service to talk from the client application to the business rule tier.</p>
<p><em>Note:</em></p>
<p><em>You can enhance the attached project by adding the following:</em></p>
<ol>
<li><em>Exception handling layer</em> </li><li><em>Cache layer</em> </li><li><em>Proxy project. for example </em>if you have 3 client application and you connect directly to WCF Service so any modification in WCF you have to go to each client project and update the WCF service but if you add WCF to proxy project and client projects
 consume this service through proxy project and any modification in WCF ; you only have to update the proxy project and then upload this Dll to client projects.
</li></ol>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file TierProject.zip - C# code</em> </li></ul>
