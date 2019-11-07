# ASP.NET MVC Facebook Birthday App sample code
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
## Topics
- C#
- Security
## Updated
- 09/30/2014
## Description

<h1>Introduction</h1>
<p>Please follow the&nbsp;<a href="http://www.asp.net/mvc/tutorials/mvc-4/aspnet-mvc-facebook-birthday-app">ASP.NET MVC Facebook Birthday App</a> tutorial, which is updated and contains customer comments.</p>
<h1><span>Building the Sample</span></h1>
<p><em>Please read&nbsp;the&nbsp;<a href="http://www.asp.net/mvc/tutorials/mvc-4/aspnet-mvc-facebook-birthday-app">ASP.NET MVC Facebook Birthday App</a>&nbsp;tutorial</em></p>
<p>Over the past several months Facebook made changes to their application development APIs that were incompatible with the MVC Facebook support.</p>
<p>We have been working on updates while the Facebook API kept evolving, and on 4/30/2014 Facebook announced a&nbsp;<a href="https://developers.facebook.com/blog/post/2014/04/30/f8/">two-year stability guarantee</a>. This was a fantastic announcement because
 this ensured a similar stability for ASP.NET MVC developers developing Facebook applications. We've fixed the Facebook package and renamed it to<strong>Microsoft.AspNet.Facebook</strong>. This package is now available on NuGet.</p>
<p><a href="https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&status=Closed&type=All&priority=All&release=All&assignedTo=All&component=Facebook&sortField=LastUpdatedDate&sortDirection=Descending&page=0&reasonClosed=All">Here</a>&nbsp;are the
 issues that we&rsquo;ve fixed.</p>
<p>&nbsp;</p>
<p>If you&rsquo;re new to the world of Facebook application development on MVC you can check out a Birthday application&nbsp;<a href="http://www.asp.net/mvc/tutorials/mvc-4/aspnet-mvc-facebook-birthday-app">here</a>. Keep in mind this tutorial will be gradually
 updated so it may not be entirely accurate.</p>
<h3>The important new stuff</h3>
<p>The original Microsoft.AspNet.Mvc.Facebook package and corresponding API&rsquo;s at the time had no concept of optional or default permissions. This created friction with some of the updated prompt dialogs that Facebook released. To address this we&rsquo;ve
 made the Facebook&rsquo;s authorize filter more flexible by providing permission prompt hooks to control login dialog flow.</p>
<p><em>FacebookAuthorizeFIlter</em>&nbsp;now exposes&nbsp;<em>OnPermissionPrompt</em>&nbsp;and an&nbsp;<em>OnDeniedPermissionPrompt</em>&nbsp;hooks.<strong>&nbsp;</strong>So what do these hooks do? Let&rsquo;s go over each in detail.</p>
<p>&nbsp;</p>
<h3>OnPermissionPrompt</h3>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
