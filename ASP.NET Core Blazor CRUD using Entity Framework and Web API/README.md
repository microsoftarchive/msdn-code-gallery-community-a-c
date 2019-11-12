# ASP.NET Core Blazor CRUD using Entity Framework and Web API
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Core
- Blazor
- ASP.NET Core Blazor
## Topics
- ASP.NET Core
- Blazor
- ASP.NET Core Blazor
## Updated
- 06/10/2018
## Description

<p>Introduction</p>
<p><a title="ASP.NET Core Blazor CRUD using Entity Framework and Web API" href="https://www.youtube.com/watch?v=QgyRxzNN6B0" target="_blank"><img id="200064" src="200064-capture.png" alt="" width="485" height="283"><br>
</a></p>
<p>In this article we will see on how to create a simple CRUD application for ASP.NET Core Blazor using Entity Framework and Web API. Blazor is a new framework introduced by Microsoft.I love to work with Blazor as this make our SPA full stack application development
 in more simple way and yes now we can use only one Language as C#. Before Blazor we are been using ASP.NET Core with the combination of Angular or ReactJs, now with the help of Blazor support we can create our own SPA application directly with C# Code.If you
 start your SPA application development using Blazor surely you will love it and it was that much simple and fun to work with Blazor.&nbsp;&nbsp;</p>
<p>In this article, we will see the on creating CRUD web Application using ASP.NET Core Blazor</p>
<ul>
<li>C: (Create): Insert new Student Details into the database using ASP.NET Core, Blazor, EF and Web API.
</li><li>R: (Read): Select Student Details from the database using ASP.NET Core, Blazor, EF and Web API.
</li><li>U: (Update): Update Student Details to the database using ASP.NET Core, Blazor, EF and Web API
</li><li>D: (Delete): Delete Student Details from the database using ASP.NET Core, Blazor, EF and Web API.
</li></ul>
<p><img id="200065" src="200065-1.gif" alt="" width="600" height="400"></p>
<p>We will be using Web API and EF to perform our CRUD operations. Web API has the following four methods as Get/Post/Put and Delete, where</p>
<ul>
<li>Get is to request for the data. (Select) </li><li>Post is to create a data. (Insert) </li><li>Put is to update the data. (Update) </li><li>Delete is to delete data. (Delete) </li></ul>
<h1><span>Building the Sample</span></h1>
<h1><strong>Prerequisites</strong></h1>
<p><span>Make sure, you have installed all the prerequisites in your computer. If not, then download and install all, one by one. Note that since Blazor is the new framework and we must have installed preview of Visual Studio 2017 (15.7) or above.</span></p>
<ul>
<li>Install the&nbsp;<a href="https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview2" target="_blank">.NET Core 2.1 Preview 2 SDK</a>. (You can find the all versions from this
<a href="https://www.microsoft.com/net/download/all" target="_blank">link</a>&nbsp;
</li></ul>
<ul>
<li>Install the latest preview of&nbsp;<a href="https://www.visualstudio.com/vs/preview/" target="_blank">Visual Studio 2017 (15.7)</a>.&nbsp;
</li></ul>
<ul>
<li>Install the&nbsp;<a href="https://marketplace.visualstudio.com/items?itemName=aspnet.blazor" target="_blank">ASP.NET Core Blazor Language Services</a>&nbsp;for Blazor Extentions.
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>Code part</strong></p>
<p><strong>Step 1 -&nbsp;Create a database and a table</strong></p>
<p>We will be using our SQL Server database for our WEB API and EF. First, we create a database named StudentsDB and a table as StudentMaster. Here is the SQL script to create a database table and sample record insert query in our table. Run the query given
 below in your local SQL Server to create a database and a table to be used in our project.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;MASTER&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">1</span>)&nbsp;Check&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;<span class="js__operator">new</span>&nbsp;DB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.databases&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'StudentsDB'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;DATABASE&nbsp;StudentsDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;DATABASE&nbsp;StudentsDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
USE&nbsp;StudentsDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__sl_comment">////////////&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(&nbsp;SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.tables&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'StudentMasters'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;TABLE&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[StudentMasters](&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StdID]&nbsp;INT&nbsp;IDENTITY&nbsp;PRIMARY&nbsp;KEY,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StdName]&nbsp;[varchar](<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Email]&nbsp;&nbsp;[varchar](<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Phone]&nbsp;&nbsp;[varchar](<span class="js__num">20</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Address]&nbsp;&nbsp;[varchar](<span class="js__num">200</span>)&nbsp;NOT&nbsp;NULL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;insert&nbsp;sample&nbsp;data&nbsp;to&nbsp;Student&nbsp;Master&nbsp;table&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[StudentMasters]&nbsp;&nbsp;&nbsp;([StdName],[Email],[Phone],[Address])&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;(<span class="js__string">'Shanu'</span>,<span class="js__string">'syedshanumcain@gmail.com'</span>,<span class="js__string">'01030550007'</span>,<span class="js__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[StudentMasters]&nbsp;&nbsp;&nbsp;([StdName],[Email],[Phone],[Address])&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;(<span class="js__string">'Afraz'</span>,<span class="js__string">'Afraz@afrazmail.com'</span>,<span class="js__string">'01030550006'</span>,<span class="js__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[StudentMasters]&nbsp;&nbsp;&nbsp;([StdName],[Email],[Phone],[Address])&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;(<span class="js__string">'Afreen'</span>,<span class="js__string">'Afreen@afreenmail.com'</span>,<span class="js__string">'01030550005'</span>,<span class="js__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;*&nbsp;from&nbsp;[StudentMasters]&nbsp;&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Step 2 -&nbsp;Create ASP.NET Core Blazor Application</strong></p>
<p>After installing all the prerequisites listed above and ASP.NET Core Blazor Language Services, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2017 &gt;&gt; Visual Studio 2017 on your desktop. Click New &gt;&gt; Project. Select Web &gt;&gt; ASP.NET
 Core Angular Web Application. Enter your project name and click OK.</p>
<p><img id="200066" src="200066-3.png" alt="" width="458" height="251"></p>
<p>Select Blazor (ASP.NET Core hosted) and click ok</p>
<p><img id="200067" src="200067-4.png" alt="" width="479" height="266"></p>
<p>After creating ASP.NET Core Blazor Application, wait for few seconds. You will see below structure in solution explorer.</p>
<p><img id="200068" src="200068-4_0.png" alt="" width="254" height="412"></p>
<h1><strong>What is new in ASP.NET Core Blazor solution?</strong></h1>
<p>When we create our new ASP.NET Core Blazor application we can see as there will be 3 projects will be automatically created in the solution Explorer.</p>
<h2><strong>Client Project</strong></h2>
<p>The first project created as the Client project and it will be as our Solutionname.Client and here we can see as our Solutionname as &ldquo;BlazorASPCORE&rdquo;. As the project named as client and this project will be mainly focused for all the client-side
 view. Here we will be adding all our page view to be display in the client side in browser.</p>
<p><img id="200069" src="200069-5.png" alt="" width="249" height="327"></p>
<p>We can see as few of sample page has been already added here and we can also see a shared folder same like our MVC application where will be having the Sharedfolder and Layout page for the Master page.Here in Blazor we have the MainLayout which will be work
 like the Master page and NavMenu for the left side menu display.</p>
<h2><strong>Server Project</strong></h2>
<p>As the name indicating this project will be used as a Server project. This project is mainly used to create all our Controllers and WEB API Controllers to perform all business logic and perform CRUD operation using WEB API&rsquo;s. In our demo application
 we will be adding a Web API in this Server project and all the WEB API in our Client application. This Server project will be work like get/set the data from Database and from our Client project we bind or send the result to this server to perform the CRUD
 operation in database.</p>
<p><img id="200070" src="200070-6.png" alt="" width="280" height="148"></p>
<h2><strong>Shared Project</strong></h2>
<p>As the name indicating this project work like a shred project. This project works as a Model for our Server project and for the Client project. The Model declared in this Shared project will be used in both the Server and in the Client project. We also install
 all the packages needed for our project here, for example to use the Entity Framework we install all the packages in this Shared project.</p>
<p><img id="200071" src="200071-6.png" alt="" width="280" height="148"></p>
<p><strong>Run to test the application</strong></p>
<p>When we run the application, we can see that the left side has navigation and the right side contains the data. We can see as the default sample pages and menus will be displayed in our Blazor web site. We can use the pages or remove it and start with our
 own page.</p>
<p><img id="200072" src="200072-8.png" alt="" width="1202" height="564"></p>
<p>Now let&rsquo;s see how to add new page perform the CRUD operation for maintain student details.</p>
<p><strong>Using Entity Framework</strong></p>
<p>To use the Entity Framework in our Blazor application we need to install the below packages</p>
<p><strong>Install the Packages</strong></p>
<p>Go to Tools and then select -&gt; NuGet Package Manager -&gt; Package Manager Console.</p>
<p><img id="200074" src="200074-9.png" alt="" width="595" height="394"></p>
<p>You can see the Console at the bottom of the VS 2017 IDE and in right side of the combobox on the console select the Default project as your shared project&rdquo; Select Shared&rdquo;</p>
<p><img id="200075" src="200075-10.png" alt="" width="1264" height="232"></p>
<p>1)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;You can see the PM&gt; and copy and paste the below line to install the Database Provider package. This package is used to set the database provider as SQL Servder</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Install-Package&nbsp;Microsoft.EntityFrameworkCore.SqlServer</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="200079" src="200079-11.png" alt="" width="1198" height="166"></div>
<p>&nbsp;</p>
<p>We can see as the package is installed in our Shared folder</p>
<p>Install the Entity Framework</p>
<p>2)&nbsp; &nbsp; &nbsp;You can see the PM&gt; and copy and paste the below line to install the EF package.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Install-Package&nbsp;Microsoft.EntityFrameworkCore.Tools</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="200080" src="200080-12.png" alt="" width="1247" height="177"></div>
<p>&nbsp;</p>
<p>To Create DB Context and set the DB Connection string</p>
<p>&nbsp; &nbsp;3) You can see the PM&gt; and copy and paste the below line set the Connection string and create DB Context. This is important part as we give our SQL Server name, Database Name and SQL server UID and SQL Server Password to connect to our database
 for performing the CRUD operation. We also give our SQL Table name to create the Model class in our Shared project.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Scaffold-DbContext&nbsp;<span class="js__string">&quot;Server=&nbsp;YourSqlServerName;Database=StudentsDB;user&nbsp;id=&nbsp;YourSqlUID;password=&nbsp;YourSqlPassword;Trusted_Connection=True;MultipleActiveResultSets=true&quot;</span>&nbsp;Microsoft.EntityFrameworkCore.SqlServer&nbsp;-OutputDir&nbsp;Models&nbsp;-Tables&nbsp;StudentMasters</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="200081" src="200081-13.png" alt="" width="802" height="100"></div>
<p>Press enter create connection string, Model Class and Database Context.</p>
<p><img id="200082" src="200082-14.png" alt="" width="381" height="192"></p>
<p>We can see StudentMasters Model class and StudentsDBContext class has been created in our Shared project. We will be using this Model and DBContext in our Server project to create our Web API to perform the CRUD operations.&nbsp;
<strong>&nbsp;</strong></p>
<p><strong>Creating Web API for CRUD operation</strong></p>
<p>To create our WEB API Controller, right click Controllers folder. Click Add New Controller.</p>
<p><img id="200083" src="200083-15.png" alt="" width="564" height="178"></p>
<p><span>Here we will be using Scaffold method to create our WEB API .We select API Controller with actions, using Entity Framework.</span></p>
<p><span><img id="200084" src="200084-16.png" alt="" width="854" height="447"></span></p>
<p><span>Select our Model and DatabaseContext from the Shared project.</span></p>
<p><span><img id="200085" src="200085-17.png" alt="" width="586" height="219"></span></p>
<p><span>Select our StudentMasters Model from the Shared Project for performing the CRUD operation.</span></p>
<p><span><img id="200086" src="200086-18.png" alt="" width="590" height="374"></span></p>
<p><span>Select the Data Context Class as our StudentsDBContext from the Shared project. Our Controller name will be automatically added if you need you can change it and click the ADD.</span></p>
<p><span><img id="200087" src="200087-19.png" alt="" width="592" height="215"></span></p>
<p><span>Our WEB API with Get/Post/Put and Delete method for performing the CRUD operation will be automatically created and we no need to write any code in Web API now as we have used the Scaffold method for all the actions and methods add with code.</span></p>
<p>To test Get Method, we can run our project and copy the GET method API path. Here, we can see our API path to get api/StudentMasters/
<br>
<br>
Run the program and paste API path to test our output.<strong>&nbsp;</strong></p>
<p><img id="200088" src="200088-21.png" alt="" width="744" height="141"></p>
<p>Now we will bind all this WEB API Json result in out View page from our Client project</p>
<p><strong>Working with Client Project</strong></p>
<p>First, we need to add the new Razor view page</p>
<p><strong>Add Razor View</strong></p>
<p>To add the Razor view page right click the Pages folder from the Client project. Click on Add &gt;&gt; New Item</p>
<p><img id="200089" src="200089-22.png" alt="" width="862" height="239"></p>
<p>Select Razor View &gt;&gt; Enter your page name,Here we have given the name as Students.chtml</p>
<p><img id="200090" src="200090-23.png" alt="" width="780" height="443"></p>
<p>In Razor view Page we have 3 parts of code as first is the Import part where we import all the references and models for using in the view, HTML design and data bind part and finally we have the function part to call all the web API to bind in our HTML page
 and also to perform client-side business logic to be displayed in View page.</p>
<p><strong>Import part</strong></p>
<p>First, we import all the needed support files and references in our Razor View page.Here we have first imported our Model class to be used in our view and also imported HTTPClient for calling the Web API to perform the CRUD operations.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">@using&nbsp;BLAZORASPCORE.Shared&nbsp;
@using&nbsp;BLAZORASPCORE.Shared.Models&nbsp;
@page&nbsp;<span class="js__string">&quot;/Students&quot;</span>&nbsp;
@using&nbsp;Microsoft.AspNetCore.Blazor.Browser.Interop&nbsp;
@inject&nbsp;HttpClient&nbsp;Http&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>HTML design and data Bind part</strong></p>
<p>Next, we design our Student details page to display the student details from the database and created a form to Insert and update the Student details we also have Delete button to delete the student records from the database.</p>
<p>For binding in Blazor we use the bind=&quot;@stds.StdId&quot; and to call the method using
<strong>onclick</strong>=&quot;@AddNewStudent&quot;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;h1&gt;&nbsp;ASP.NET&nbsp;Core&nbsp;BLAZOR&nbsp;CRUD&nbsp;demo&nbsp;<span class="js__statement">for</span>&nbsp;Studetns&lt;/h1&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;table&nbsp;width=<span class="js__string">&quot;100%&quot;</span>&nbsp;style=<span class="js__string">&quot;background:#05163D;color:honeydew&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;20&quot;</span>&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;&nbsp;Add&nbsp;New&nbsp;Student&nbsp;Details&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;right&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;@AddNewStudent&quot;</span>&gt;Add&nbsp;New&nbsp;Student&lt;/button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;10&quot;</span>&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;colspan=<span class="js__string">&quot;2&quot;</span>&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&lt;/table&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;form&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;class=<span class="js__string">&quot;form-group&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;control-label&quot;</span>&gt;Student&nbsp;ID&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;class=<span class="js__string">&quot;form-control&quot;</span>&nbsp;bind=<span class="js__string">&quot;@stds.StdId&quot;</span>&nbsp;readonly&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;20&quot;</span>&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;control-label&quot;</span>&gt;Student&nbsp;Name&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;class=<span class="js__string">&quot;form-control&quot;</span>&nbsp;bind=<span class="js__string">&quot;@stds.StdName&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Email&quot;</span>&nbsp;class=<span class="js__string">&quot;control-label&quot;</span>&gt;Email&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;class=<span class="js__string">&quot;form-control&quot;</span>&nbsp;bind=<span class="js__string">&quot;@stds.Email&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;20&quot;</span>&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;control-label&quot;</span>&gt;Phone&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;class=<span class="js__string">&quot;form-control&quot;</span>&nbsp;bind=<span class="js__string">&quot;@stds.Phone&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;control-label&quot;</span>&gt;Address&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;class=<span class="js__string">&quot;form-control&quot;</span>&nbsp;bind=<span class="js__string">&quot;@stds.Address&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;20&quot;</span>&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-success&quot;</span>&nbsp;onclick=<span class="js__string">&quot;@(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;AddStudent())&quot;</span>&nbsp;style=<span class="js__string">&quot;width:220px;&quot;</span>&gt;Save&lt;/button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&lt;/form&gt;&nbsp;
&nbsp;
&lt;table&nbsp;width=<span class="js__string">&quot;100%&quot;</span>&nbsp;style=<span class="js__string">&quot;background:#0A2464;color:honeydew&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;20&quot;</span>&gt;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Student&nbsp;Details&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;colspan=<span class="js__string">&quot;2&quot;</span>&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&lt;/table&gt;&nbsp;
&nbsp;
@<span class="js__statement">if</span>&nbsp;(student&nbsp;==&nbsp;null)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&lt;em&gt;Loading...&lt;<span class="js__reg_exp">/em&gt;&lt;/</span>p&gt;&nbsp;
<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;class=<span class="js__string">&quot;table&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Student&nbsp;ID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Student&nbsp;Name&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Email&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Phone&lt;/th&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Address&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tbody&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(<span class="js__statement">var</span>&nbsp;std&nbsp;<span class="js__operator">in</span>&nbsp;student)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@std.StdId&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@std.StdName&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@std.Email&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@std.Phone&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@std.Address&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;button&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-primary&quot;</span>&nbsp;onclick=<span class="js__string">&quot;@(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;EditStudent(@std.StdId))&quot;</span>&nbsp;style=<span class="js__string">&quot;width:110px;&quot;</span>&gt;Edit&lt;<span class="js__reg_exp">/button&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;button&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-danger&quot;</span>&nbsp;onclick=<span class="js__string">&quot;@(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;DeleteStudent(@std.StdId))&quot;</span>&gt;Delete&lt;<span class="js__reg_exp">/button&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Function Part</strong></p>
<p>function part to call all the web API to bind in our HTML page and also to perform client-side business logic to be displayed in View page.In this Function we create a separate function for Add, Edit and Delete the student details and call the Web API Get,Post,Put
 and Delete method to perform the CRUD operations and in HTML we call all the function and bind the results.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">@functions&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StudentMasters[]&nbsp;student;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StudentMasters&nbsp;stds&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ids&nbsp;=&nbsp;<span class="js__string">&quot;0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;showAddrow&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;async&nbsp;Task&nbsp;OnInitAsync()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;student&nbsp;=&nbsp;await&nbsp;Http.GetJsonAsync&lt;StudentMasters[]&gt;(<span class="js__string">&quot;/api/StudentMasters/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;AddNewStudent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stds&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;New&nbsp;Student&nbsp;Details&nbsp;Method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;async&nbsp;Task&nbsp;AddStudent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(stds.StdId&nbsp;==&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Http.SendJsonAsync(HttpMethod.Post,&nbsp;<span class="js__string">&quot;/api/StudentMasters/&quot;</span>,&nbsp;stds);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Http.SendJsonAsync(HttpMethod.Put,&nbsp;<span class="js__string">&quot;/api/StudentMasters/&quot;</span>&nbsp;&#43;&nbsp;stds.StdId,&nbsp;stds);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stds&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentMasters();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;student&nbsp;=&nbsp;await&nbsp;Http.GetJsonAsync&lt;StudentMasters[]&gt;(<span class="js__string">&quot;/api/StudentMasters/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Edit&nbsp;Method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;async&nbsp;Task&nbsp;EditStudent(int&nbsp;studentID)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ids&nbsp;=&nbsp;studentID.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stds&nbsp;=&nbsp;await&nbsp;Http.GetJsonAsync&lt;StudentMasters&gt;(<span class="js__string">&quot;/api/StudentMasters/&quot;</span>&nbsp;&#43;&nbsp;Convert.ToInt32(studentID));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Delte&nbsp;Method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;async&nbsp;Task&nbsp;DeleteStudent(int&nbsp;studentID)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ids&nbsp;=&nbsp;studentID.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Http.DeleteAsync(<span class="js__string">&quot;/api/StudentMasters/&quot;</span>&nbsp;&#43;&nbsp;Convert.ToInt32(studentID));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;await&nbsp;Http.DeleteAsync(&quot;/api/StudentMasters/Delete/&quot;&nbsp;&#43;&nbsp;Convert.ToInt32(studentID));</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;student&nbsp;=&nbsp;await&nbsp;Http.GetJsonAsync&lt;StudentMasters[]&gt;(<span class="js__string">&quot;/api/StudentMasters/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>BLAZORASPCORE.zip - 2018-05-18 </li></ul>
<h1>More Information</h1>
<p>Note as when creating the DBContext and setting the connection string, don&rsquo;t forget to add your SQL connection string. Hope you all like this article and in next article we will see more examples to work with Blazors and its really very cool and awesome
 to work with Blazor.<strong>&nbsp;</strong></p>
