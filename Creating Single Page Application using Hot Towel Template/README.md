# Creating Single Page Application using Hot Towel Template
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- ASP.NET
- ViewModel pattern (MVVM)
- HTML5
- ASP.NET MVC 4
- ASP.NET Web API
- .NET 4.5
## Topics
- Single Page Application (SPA)
## Updated
- 02/21/2014
## Description

<h1>&nbsp;&nbsp;</h1>
<h1>Introduction</h1>
<p><strong>Single-Page Applications (SPAs)</strong> are Rich, Responsive Web apps that load a single HTML page and dynamically update that page as the user interacts with the app.</p>
<p>This code sample gives the demo application for creating Single Page Application using<strong> Hot Towel SPA Template</strong> (<strong>Knockout, Durandal, Breeze</strong>).&nbsp;<em><br>
</em></p>
<p><em><img id="109152" src="109152-6.png" alt="" width="722" height="392"><br>
<br>
</em>This application will be useful for understanding the basics of Single Page Application in some extend. If you follow and create the application your own, it will give great experience on SPA.&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Please take a look into the Durandal, Knockout and Breeze basics for more understands the below steps.</p>
<p><strong><a href="http://durandaljs.com/" target="_blank">Durandal</a>&nbsp;</strong><br>
<br>
Durandal is small JavaScript framework designed to make building Single Page Applications (SPAs) simple and elegant. &nbsp;<br>
<strong><a href="http://knockoutjs.com/index.html" target="_blank">Knockout</a></strong></p>
<p>Knockout is a JavaScript library that helps you to create rich, responsive display and editor user interfaces with a clean underlying data model.&nbsp;</p>
<p><strong><a href="http://www.breezejs.com/home" target="_blank">Breeze</a>&nbsp;</strong></p>
<p>Breeze is a JavaScript library that helps you manage data in rich client applications. It store &amp; retrieve the data in database, execute queries etc.&nbsp;</p>
<p><br>
<strong><a href="http://www.asp.net/single-page-application/overview/templates/hottowel-template" target="_blank">Hot Towel Template</a>&nbsp;</strong></p>
<p>Hot Towel creates a great starting point for building a Single Page Application (SPA) with ASP.NET. It provides a modular structure for your code, view navigation, data binding, rich data management and simple but elegant styling. &nbsp;</p>
<p><strong><a href="http://www.odata.org/" target="_blank">Open Data Protocol</a>&nbsp;</strong></p>
<p>The purpose of the <strong>Open Data protocol (OData) </strong>is to provide a REST-based protocol for CRUD-style operations (Create, Read, Update and Delete) against resources exposed as data services.&nbsp;</p>
<p><strong>Pre-requisites &nbsp; &nbsp;</strong></p>
<p>To run this sample in development machine, machine should have <strong>Visual Studio 2012</strong> or higher and MVC 4 with
<strong>&nbsp;Hot Towel Template</strong>. If reader has some basic knowledge on <strong>
MVVM pattern</strong> it helps to understand better Hot Towel SPA.&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This code sample describes step by step creation of My Contact project using MVC 4 - Hot Towel Single Page Application Template.</p>
<p>I am explaining the step by step creation of My Contact project using MVC 4 Hot Towel SPA and I have written inline comment in the source code for better understanding the code. In this web page I am concentrating on steps for creating this application.&nbsp;</p>
<p><br>
<span style="text-decoration:underline"><strong>Step 1: Create My Contacts project using MVC 4 -&gt; Hot Towel SPA.</strong></span></p>
<p><em><strong><img id="109154" src="109154-first.png" alt="" width="722" height="354"></strong></em></p>
<p><em><strong><img id="109155" src="109155-2.png" alt="" width="722" height="618"><br>
</strong></em></p>
<p><span style="text-decoration:underline"><strong>Step 2: Create database &amp; table.</strong></span></p>
<p>Create database under App_Data folder, please see the below image for database creation. &nbsp;</p>
<p><em>App_Data -&gt; Add -&gt; New Items -&gt; SQL Server Compact 4.0 Local Database. &nbsp;</em></p>
<p>It can be any database, but corresponding connection string has to mention in the web.config file.&nbsp;I am taking SQL Server Compact 4.0 Local Database.&nbsp;</p>
<p><img id="109156" src="109156-3.png" alt="" width="722" height="398"></p>
<p>Double click the <strong>MyContact.sdf </strong>file and create table with column Id, Name, Mobile, Email, see the below image.</p>
<p><img id="109157" src="109157-4.png" alt="" width="722" height="454"></p>
<p>Add the connection string information into<strong> web.config</strong> file. &nbsp;&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;MyContactDB&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;Data&nbsp;Source=|DataDirectory|MyContact.sdf&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.SqlServerCe.4.0&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="text-decoration:underline"><strong>Step 3: Create Model and DataContext Classes</strong></span></div>
<div class="endscriptcode"><br>
Contact model class, Contact.cs and datacontext class MyContactDbcontext.cs under Models folder.&nbsp;</div>
<div class="endscriptcode"><br>
<strong>Contact.cs&nbsp;</strong></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;Contact&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Id&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required,&nbsp;MaxLength(<span class="js__num">100</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Name&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[RegularExpression(@<span class="js__string">&quot;\(?\d{3}\)?-?&nbsp;*\d{3}-?&nbsp;*-?\d{4}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="js__string">&quot;Invalid&nbsp;mobile&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Mobile&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[RegularExpression(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__string">&quot;^\w&#43;[\w-\.]*\@\w&#43;((-\w&#43;)|(\w*))\.[a-z]{2,3}$&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="js__string">&quot;Invalid&nbsp;email&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Email&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>MyContactDbContext.cs&nbsp;</strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;MyContactDBContext&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//WebConfig-Connection&nbsp;string&nbsp;name&nbsp;has&nbsp;to&nbsp;mention&nbsp;here&nbsp;for&nbsp;connecting&nbsp;the&nbsp;database.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MyContactDBContext()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;base(nameOrConnectionString:&nbsp;<span class="js__string">&quot;MyContactDB&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;OnModelCreating(DbModelBuilder&nbsp;modelBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelBuilder.Conventions.Remove&lt;PluralizingTableNameConvention&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Database.SetInitializer&lt;MyContactDBContext&gt;(null);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DbSet&lt;Contact&gt;&nbsp;Contacts&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="text-decoration:underline"><strong>Step 4: Web API class for Breeze framework contact with database. BreezeController.cs (ApiController) under Controller folder.</strong></span></div>
<div class="endscriptcode"><strong><br>
</strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="109160" src="109160-7.png" alt="" width="722" height="454"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong>BreezeController.cs&nbsp;</strong></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;[BreezeController]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;BreezeController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;readonly&nbsp;EFContextProvider&lt;MyContactDBContext&gt;&nbsp;_contextProvider&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;EFContextProvider&lt;MyContactDBContext&gt;();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Metadata()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//assemblyref://System.Web.Http.OData</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//OData&nbsp;reference&nbsp;has&nbsp;to&nbsp;add&nbsp;for&nbsp;Breeze&nbsp;connection&nbsp;with&nbsp;database&nbsp;for&nbsp;getting&nbsp;metadata.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;reference&nbsp;will&nbsp;not&nbsp;come&nbsp;with&nbsp;this&nbsp;template&nbsp;-&nbsp;it&nbsp;can&nbsp;be&nbsp;download&nbsp;from&nbsp;online,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//also&nbsp;this&nbsp;code&nbsp;sample&nbsp;package&nbsp;is&nbsp;having&nbsp;this&nbsp;assembly&nbsp;dll.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_contextProvider.Metadata();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IQueryable&lt;Contact&gt;&nbsp;Contacts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_contextProvider.Context.Contacts;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;SaveResult&nbsp;SaveChanges(JObject&nbsp;saveBundle)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_contextProvider.SaveChanges(saveBundle);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.web.Http.OData.aspx" target="_blank" title="Auto generated link to System.web.Http.OData">System.web.Http.OData</a> </strong>- reference has to add for getting Metadata using Breeze.</div>
<div class="endscriptcode">&nbsp;<br>
Until now we created database and web API for breeze communicate with database. Before going into next session, please take a look into the Durandal, Knockout and Breeze basics.&nbsp;</div>
<div class="endscriptcode">&nbsp; &nbsp;</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">Client Side Code&nbsp;</h1>
<div class="endscriptcode"></div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
<div class="endscriptcode">Hot Towel SPA client side code constructed using MVVM pattern, client html/java script file will act Model, View &amp; ViewModel classes. Let us see client side code in the below section.</div>
<div class="endscriptcode"><br>
All client side code comes under App folder in the My Contact project. It has three folders.</div>
<div class="endscriptcode">&nbsp;<br>
<strong>services (model) </strong>-&gt; contains java script files for model, datacontext, log and Breeze.partial-entities.</div>
<div class="endscriptcode"><br>
<strong>viewmodels</strong> -&gt; contains java script files it act as viewmodel classes for html view files</div>
<div class="endscriptcode"><br>
<strong>view&nbsp;</strong>-&gt; contains html files mostly view (UI) files.</div>
<div class="endscriptcode">&nbsp;<br>
From here I am start mentioning the file name, it has to copy from the downloaded source code. Source code has inline comment whenever if necessary.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
</div>
<div class="endscriptcode"><br>
<span style="text-decoration:underline"><strong>Step 5: Bootstrapper and Configuration files</strong></span></div>
<div class="endscriptcode"><br>
main.js files works like bootstrapper and config.js (it has to create or copy from source code) contain configuration information like remoteServicName.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
<span style="text-decoration:underline"><strong>Step 6: Create file in services folder (copy files from source code) - MODEL</strong></span></div>
<div class="endscriptcode"><br>
<strong>model.js </strong>file helps to sync up table column using Breeze Metadata file.&nbsp;</div>
<div class="endscriptcode"><br>
<strong>breeze.partial-entities.js</strong> into App-&gt;services folder, some reason template is not creating this file or I was missing something on this. But this is the way to work around. &nbsp;</div>
<div class="endscriptcode"><br>
<strong>datacontext.js </strong>file is getting data, add/updating using Breeze API controller, Breeze framework will take care all the service calls.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
<span style="text-decoration:underline"><strong>Step 7: Create html files under view folder (copy files from source code) - VIEW</strong></span></div>
<div class="endscriptcode"><br>
<strong>contacts.html</strong> -&gt; list all available contacts extracted from the database, knockout framework helps for data-binding from viewmodel to view.&nbsp;</div>
<div class="endscriptcode"><br>
Similarly <strong>contactadd.html &amp; contactedit.html</strong> are used for add and edit respectively.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><br>
<span style="text-decoration:underline"><strong>Step 8: Create java script files under viewmodel folder &nbsp;(copy files from source code) - VIEWMODEL</strong></span></div>
<div class="endscriptcode"><br>
Usually viewmodel file contains properties, methods and command which can be invoke by the view.&nbsp;</div>
<div class="endscriptcode"><br>
Note: naming convention of both view &amp; viewmodel should be same, and then durandal understands view &amp; its corresponding viewmodel files.</div>
<div class="endscriptcode"><br>
<strong>contacts.js</strong> -&gt; contacts properties contains list of contacts and some other properties/command for searching by name.</div>
<div class="endscriptcode"><br>
contactadd.js/contactedit.js - doing add/edit properties and commands. For understanding purpose add/edit files are created two separate views, also it helps to navigate independently each other.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
<span style="text-decoration:underline"><strong>Step 9: Updating routes for navigating Contacts, Contact Add views&nbsp;</strong></span></div>
<div class="endscriptcode"><br>
<strong>shell.js</strong> (App-&gt;viewmodels), below code has to update for display Contacts, Add item in the menu list.</div>
</div>
<p><img id="109161" src="109161-5.png" alt="" width="722" height="417"></p>
<p>&nbsp;</p>
<p><span style="text-decoration:underline"><strong>Step 10: Build &amp; Run&nbsp;</strong></span></p>
<p>Once done all the above steps, add the required namespaces in all .cs files and Build &amp; Run the application. It will redirect to contacts list page. Click 'Add' menu, then add some contact information and click 'Save'. Then you can able to see the newly
 added record in contacts view.&nbsp;</p>
<h1>Conclusion</h1>
<p>I hope this article helps to understands MVC 4 Hot Towel SPA and able to create your own My Contact project. Please let me your valuable comments, suggestions and quires on this article. Thanks to John Papa for Hot Towel template.&nbsp;</p>
<p>You can use Fiddler Web Debugger tool for analyzing OData request from Breeze framework.</p>
<h1>References</h1>
<ol>
<li><a href="http://www.johnpapa.net/spa/" target="_blank">http://www.johnpapa.net/spa/</a>
</li><li><a href="http://msdn.microsoft.com/en-us/magazine/dn463786.aspx" target="_blank">http://msdn.microsoft.com/en-us/magazine/dn463786.aspx</a>
</li><li><a href="http://www.asp.net/single-page-application/overview/templates/hottowel-template" target="_blank">http://www.asp.net/single-page-application/overview/templates/hottowel-template</a>
</li><li><a href="http://durandaljs.com/" target="_blank">http://durandaljs.com/</a> </li><li><a href="http://knockoutjs.com/index.html" target="_blank">http://knockoutjs.com/index.html</a>
</li><li><a href="http://www.breezejs.com/home" target="_blank">http://www.breezejs.com/home</a>
</li><li><a href="http://www.telerik.com/fiddler" target="_blank">http://www.telerik.com/fiddler</a>
</li><li><a href="http://www.odata.org/" target="_blank">http://www.odata.org/</a> </li></ol>
