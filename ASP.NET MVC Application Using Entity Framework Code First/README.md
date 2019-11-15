# ASP.NET MVC Application Using Entity Framework Code First
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
- ASP.NET
- ASP.NET MVC
- Entity Framework
## Topics
- Asynchronous Programming
- Entity Framework
- Concurrency
- Code First
- Inheritance
- Lazy Loading
- ASP.NET Code Sample Downloads
- Data Annotation
- Code First Migrations
- Eager Loading
- Connection Resiliency
## Updated
- 02/11/2017
## Description

<p><strong>Note:</strong>&nbsp;A newer version is available. See the&nbsp;<a href="https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-mvc/intro/samples/cu-final">VS 2015, ASP.NET Core, and EF Core sample app</a>.</p>
<h1>Introduction</h1>
<p>A Visual Studio 2013 project which shows how to use the Entity Framework 6 in an ASP.NET&nbsp;MVC 5 web application project, using the Code First development approach.</p>
<p>The previous version that uses EF 5 and MVC 4 in a Visual Studio 2012 project is
<a href="http://archive.msdn.microsoft.com/aspnetmvcsamples/Release/ProjectReleases.aspx?ReleaseId=6024">
available to download</a>.</p>
<p>The code illustrates the following topics:</p>
<ul>
<li>Creating a data model using data annotations attributes, and fluent API for database mapping.
</li><li>Performing basic CRUD operations. </li><li>Filtering, ordering, and grouping data. </li><li>Working with related data. </li><li>Implementing connection resiliency </li><li>Using command interception </li><li>Writing async code </li><li>Handling concurrency. </li><li>Implementing table-per-hierarchy inheritance. </li><li>Performing raw SQL queries. </li><li>Performing no-tracking queries. </li><li>Working with proxy classes. </li><li>Disabling automatic detection of changes. </li><li>Disabling validation when saving changes. </li></ul>
<p>A tutorial series describes how to build the sample application from scratch. There is an
<a href="http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application">
EF 6 MVC 5 VS 2013 tutorial series</a> and an <a href="http://www.asp.net/mvc/tutorials/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application">
EF 5 MVC 4 VS 2012 tutorial series</a>.</p>
<h1>Getting Started</h1>
<p>To build and run this sample as-is, you must have Visual Studio 2013 or Visual Studio 2013 Express for Web installed. If you have Visual Studio 2015, change the connection string in the Web.config file so that the SQL Server instance name is MSSQLLocalDB
 instead of v11.0.</p>
<p>In most cases you can run the application by following these steps:</p>
<ol>
<li>Download and extract the .zip file. </li><li>Open the solution file in Visual Studio. </li><li>Build the solution, which automatically installs the missing NuGet packages. </li><li>Open the Package Manager Console, and run the update-database command to create the database.
</li><li>Run the application. </li></ol>
<p>If you have any problems with those instructions, follow these longer instructions.</p>
<ol>
<li>Download the .zip file. </li><li>In File Explorer, right-click the&nbsp;.zip file and click Properties, then in the Properties window click Unblock.
</li><li>Unzip the file. </li><li>Double-click the .sln file to launch Visual Studio. </li><li>From the Tools menu, click Library Package Manager, then Package Manager Console.
</li><li>In the Package Manager Console (PMC), click Restore. </li><li>Exit Visual Studio. </li><li>Restart Visual Studio, opening the solution file you closed in the previous step.
</li><li>In the Package Manager Console (PMC), enter the Update-Database command. (If you get the following error:<br>
&quot;<em>The term 'Update-Database' is not recognized as the name of a cmdlet, function, script file, or operable program</em>&quot;, exit and restart Visual Studio.)
</li><li>Each migration will run, then the seed method will run. You can now&nbsp;run the application.
</li></ol>
<h1>Running the Sample</h1>
<p>To run the sample, hit F5 or choose the Debug | Start Debugging menu command. You will see the home page which includes a menu bar. (In a narrow browser window you'll have to click the symbol at the top right of the page in order to see the menu.)</p>
<p>From this page you can select any of the tabs to perform various actions such as display a list of students, add new students, display a list of instructors, and so forth.</p>
<p><img src="http://i1.code.msdn.s-msft.com/aspnet-mvc-application-b01a9fe8/image/file/109835/1/studentpagingsearch.png" id="109835" alt="" width="606" height="623"></p>
<p>&nbsp;</p>
<p><img src="http://i1.code.msdn.s-msft.com/aspnet-mvc-application-b01a9fe8/image/file/109836/1/instructoreditwithcourses.png" id="109836" alt="" width="604" height="750"></p>
<h1>Source Code Overview</h1>
<p>The <em>ContosoUniversity</em> folder includes the following folders and files</p>
<ul>
<li><em>App_Data</em> folder - Holds the SQL Server&nbsp;Compact database file. </li><li><em>Content</em> - Holds CSS files. </li><li>Controllers - Holds controller classes. </li><li><em>DAL</em> folder - The data access layer.&nbsp; Holds the context, initializer, repository, and unit of work classes.
</li><li><em>Logging</em> folder - Holds code that does logging. </li><li><em>Migrations</em> folder - Holds EF Code First migrations code, including the Seed method.
</li><li><em>Models</em> folder - Holds model classes. </li><li><em>Properties</em> or <em>MyProject</em> folder - Project properties. </li><li><em>Scripts</em> folder - Script files. </li><li><em>ViewModels</em> folder -&nbsp;Holds view model classes.&nbsp; </li><li><em>Views</em>&nbsp;folder - Holds view classes. </li><li>Visual Studio project file (.csproj or .vbproj). </li><li><em>packages.config</em> - Specifies NuGet packages included in the project. </li><li><em>Global.asax</em> file - Includes database initializer code. </li><li>Web.config file -&nbsp;Includes the connection string to the database. </li></ul>
