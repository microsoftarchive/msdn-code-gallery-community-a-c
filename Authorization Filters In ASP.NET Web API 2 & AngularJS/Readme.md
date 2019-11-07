# Authorization Filters In ASP.NET Web API 2 & AngularJS
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET
- AngularJS
## Topics
- ASP.NET MVC
- ASP.NET Security
- ASP.NET Web API
## Updated
- 10/20/2016
## Description

<p><span>In this article, we are going to explore a security issue which will help us to prevent unauthorized access of a Web API using custom authorization filter.</span></p>
<p>It is important to restrict unauthorized access to particular operations/actions of an application. I did an experiment while&nbsp;I was working on a project that needed to restrict an unauthorized person from performing Crud operations. The authorization
 is based on the user role.<br>
<br>
OK, Let's get started. Here are the steps; I hope you will enjoy it.<br>
<strong><br>
Contents</strong></p>
<ul>
<li>SQL Database<br>
<br>
<ul>
<li>Create a new Database </li><li>Run the DB-script<br>
<br>
</li></ul>
</li><li>ASP.NET MVC Application(Web Api)<br>
<br>
<ul>
<li>MVC, WebAPI Project </li><li>Install AngularJS </li><li>Authentication &amp; </li><li>Authorization </li></ul>
</li></ul>
<p><strong>Create New Database</strong></p>
<p><strong>&nbsp;</strong> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE DATABASE [ApiSecurity] ON PRIMARY   
( NAME = N'ApiSecurity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ApiSecurity.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )  

LOG ON   
( NAME = N'ApiSecurity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ApiSecurity_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)  
GO  </pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">ApiSecurity</span>]&nbsp;<span class="sql__keyword">ON</span>&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;<span class="sql__keyword">NAME</span>&nbsp;=&nbsp;<span class="sql__id">N</span><span class="sql__string">'ApiSecurity',&nbsp;FILENAME&nbsp;=&nbsp;N'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ApiSecurity.mdf'</span>&nbsp;,&nbsp;<span class="sql__id">SIZE</span>&nbsp;=&nbsp;<span class="sql__id">3072KB</span>&nbsp;,&nbsp;<span class="sql__id">MAXSIZE</span>&nbsp;=&nbsp;<span class="sql__id">UNLIMITED</span>,&nbsp;<span class="sql__id">FILEGROWTH</span>&nbsp;=&nbsp;<span class="sql__id">1024KB</span>&nbsp;)&nbsp;&nbsp;&nbsp;
&nbsp;
<span class="sql__id">LOG</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;<span class="sql__keyword">NAME</span>&nbsp;=&nbsp;<span class="sql__id">N</span><span class="sql__string">'ApiSecurity_log',&nbsp;FILENAME&nbsp;=&nbsp;N'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ApiSecurity_log.ldf'</span>&nbsp;,&nbsp;<span class="sql__id">SIZE</span>&nbsp;=&nbsp;<span class="sql__id">1024KB</span>&nbsp;,&nbsp;<span class="sql__id">MAXSIZE</span>&nbsp;=&nbsp;<span class="sql__id">2048GB</span>&nbsp;,&nbsp;<span class="sql__id">FILEGROWTH</span>&nbsp;=&nbsp;<span class="sql__number">10</span>%)&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><span>After creating the database, let's download&nbsp;and run the script. Let's create a new MVC Application</span><br>
<br>
<strong>MVC Application<br>
<br>
</strong><span>Install&nbsp;AngularJS for client side scripting from NuGet package installer.</span><br>
<br>
<span>First, we need to login for the authentication check</span><br>
<br>
<strong>Authentication &amp; Authorization</strong><span>&nbsp;</span></p>
<ul>
<em>&nbsp;</em>
<li>Authentication : Identity of the user. </li><li>Authorization : Allowed to perform an action.<br>
<img src="-image002.png" alt="login">
</li></ul>
<p>After successful login(Authentication), we can access the get customer link to show all the customers, only if we have the read permission in the database, given below:<br>
<img src="-image003.jpg" alt="database">.<br>
In our database table, we have to restrict the access (CanRead to &quot;False&quot;) of Administrator to view the customer list.<br>
<br>
<img src="-image004.png" alt="table"><br>
<br>
The result will show a 401 response message while fetching the data from the database, where the logged in user role is an administrator.<br>
<br>
<img src="-image005.jpg" alt="administrator"><br>
<br>
</p>
<div class="dp-highlighter"></div>
<p><span>I hope this helped.&nbsp;</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span><span><br>
</span></span></p>
