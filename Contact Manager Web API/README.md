# Contact Manager Web API
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Windows Phone
- Windows 8
## Topics
- ASP.NET Web API
## Updated
- 08/16/2012
## Description

<h1>Introduction</h1>
<p>ASP.NET Web API is a framework for building and consuming HTTP services that can reach a broad range of clients including browsers, phones and tablets. This application consists of a contact manager web API that is used by an ASP.NET MVC application and
 a Windows Phone application to display and manage a list of contacts.</p>
<h1>Requirements</h1>
<ul>
<li>Visual Studio 2010 SP1, Visual Web Developer 2010 SP1 or Visual Studio 2012 </li><li><a href="http://www.asp.net/mvc/mvc4">ASP.NET MVC 4</a>&nbsp;
<ul>
<li>Already included with Visual Studio 2012 </li></ul>
</li><li><a href="http://www.microsoft.com/en-us/download/details.aspx?id=1038">IIS 7.5 Express</a>
</li><li>SQL Server LocalDB&nbsp;(<a href="http://www.microsoft.com/en-us/download/details.aspx?id=29062">SqlLocalDB.MSI</a>)
<ul>
<li>Included with Visual Studio 2012 </li></ul>
</li><li>Update 4.0.2 for Microsoft .NET Framework 4 &ndash; Design-time Update for Visual Studio 2010 SP1 (<a href="http://www.microsoft.com/en-us/download/details.aspx?id=27759">KB2544525</a>)
<ul>
<li>Required to use LocalDB with Visual Studio 2010 SP1 </li></ul>
</li><li><a href="http://www.microsoft.com/en-us/download/details.aspx?displaylang=en&id=8279">Windows Phone SDK 7.1</a>
<ul>
<li>Required to run the ContactManager.Phone project </li><li>NOTE: The Windows Phone SDK is not currently supported with Visual Studio 2012 or on Windows 8
</li></ul>
</li><li>Windows 8
<ul>
<li>Required along with Visual Studio 2012 to run the ContactManager.WindowsStore project
</li></ul>
</li></ul>
<p>This sample uses the <a href="http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages">
NuGet package restore</a> feature to install the required set of NuGet packages when the sample is first built. Make sure you have network access to the public NuGet feed on
<a href="http://www.nuget.org">www.nuget.org</a> before building this sample the first time.</p>
<h1>Description</h1>
<p>When you run the application a list of contacts is displayed in the browser along with a form for adding new contacts. You can also remove contacts and view an image of each contact.</p>
<p><img id="63514" src="http://i1.code.msdn.s-msft.com/contact-manager-web-api-0e8e373d/image/file/63514/1/contact%20manager.png" alt="" width="600" height="488"></p>
<p>The web application includes a link to documentation for the contact manager web API. Click on the API link to view a list of the available HTTP endpoints and the allowed HTTP methods. You can also view a description of the supported parameters and sample
 request and response message payloads.</p>
<p><img id="63513" src="http://i1.code.msdn.s-msft.com/contact-manager-web-api-0e8e373d/image/file/63513/1/contact%20manager%20help%20page.png" alt="" width="598" height="594"></p>
<p>Running the application also brings up a Windows Phone application in the Windows Phone emulator. NOTE: The Windows Phone app is currently not supported when using Visual Studio 2012 or Windows 8. The Windows Phone application displays the list of contacts
 and you can click on a contact to see an image for that contact. To refresh the list of contacts as new contacts are added simply click the back key and reload the application</p>
<p><img id="59500" src="http://i1.code.msdn.s-msft.com/contact-manager-web-api-0e8e373d/image/file/59500/1/phone.png" alt="" width="229" height="415"></p>
<p>When running on Windows 8 with Visual Studio 2012 you can also run&nbsp;a Windows&nbsp;8 app to access the Contact Manager data.</p>
<p><img id="63515" src="http://i1.code.msdn.s-msft.com/contact-manager-web-api-0e8e373d/image/file/63515/1/contact%20manager%20win8%20app.png" alt="" width="277" height="463"></p>
<p>The Windows 8 app uses the new HttpClient in .NET 4.5 along with the ASP.NET Web API Client libraries to retrieve and deserialize&nbsp;the contact data.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
client.BaseAddress&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;http://localhost:8081/&quot;</span>);&nbsp;
HttpResponseMessage&nbsp;response&nbsp;=&nbsp;await&nbsp;client.GetAsync(<span class="cs__string">&quot;api/contacts&quot;</span>);&nbsp;
Contact[]&nbsp;contacts&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsAsync&lt;Contact[]&gt;();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>The contact manage web API is implemented by the <em>ContactsController</em>. The
<em>ContactsController</em> handles GET request for the list of contacts and also POST requests for adding new contacts. It also supports PUT and DELETE requests for updating contacts and removing contacts.</p>
<p>The <em>ContactsController</em> is implemented using an <em>IContactRepository</em> to store and retrieve the contacts. The
<em>IContactRepository</em> is injected into the controller's constructor using the
<a href="http://www.ninject.org">Ninject</a> IoC container.</p>
<p>Self links for each returned <em>Contact</em> instance are provided by the <em>
[ContactSelfLinkFilter]</em> filter, which runs for every request to the <em>ContactsController</em>. The self links are generated using the
<em>UrlHelper</em>.</p>
<p>The ASP.NET MVC application uses <a href="http://www.jquery.com">jQuery</a> to retrieve the list of contacts from the web API as JSON and then binds the contact data to the UI using
<a href="http://www.knockoutjs.com">knockout.js</a>.</p>
<p>Because ASP.NET Web API supports HTTP content negotiation the contact data can also be retrieved as XML.</p>
<p><img id="59501" src="http://i1.code.msdn.s-msft.com/contact-manager-web-api-0e8e373d/image/file/59501/1/contacts%20as%20xml.png" alt="" width="612" height="495"></p>
<p>The client can specify the desired media type by either using the HTTP Accept header or using a custom URI path extension. The URI path extension support is provided by adding
<em>UriPathExtensionMappings</em> to each of the configured set of formatters and by adding routes to allow for the extensions.</p>
<p>In addition to the built-in support for JSON and XML in ASP.NET Web API the sample adds a custom MediaTypeFormatter so that the contact data can be retrieved in the vCard electronic business card format.</p>
<p>You can also use the OData query syntax to&nbsp;query over the&nbsp;list of contacts. For example, you can use the $top operator to request just the first two contacts.</p>
<p><img id="59502" src="http://i1.code.msdn.s-msft.com/contact-manager-web-api-0e8e373d/image/file/59502/1/odata.png" alt="" width="618" height="362"></p>
<p>Support for the OData query syntax is enabled by returning an instance of <em>
IQueryable</em> from an action and attributing the action with the <em>[Queryable]</em> filter.</p>
<h1>More Information</h1>
<div><a href="http://www.asp.net/web-api">ASP.NET Web API home page</a></div>
