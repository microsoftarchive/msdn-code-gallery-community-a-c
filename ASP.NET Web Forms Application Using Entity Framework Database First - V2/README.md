# ASP.NET Web Forms Application Using Entity Framework Database First - V2
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
- ASP.NET
- ASP.NET and ADO.NET Entity Framework
- ASP.NET Web Forms
- ASP.NET Code Sample Downloads
## Topics
- ASP.NET
- ASP.NET and ADO.NET Entity Framework
- Data Access
- ORM
- ASP.NET Code Sample Downloads
## Updated
- 01/18/2012
## Description

<h1>Introduction</h1>
<p>A Visual Studio project which shows how to use the Entity Framework in an ASP.NET Web Forms web application project, using the Database First workflow and the ObjectDataSource control and EntityDataSourceControl. The code illustrates the following topics:</p>
<ul>
<li>Performing basic CRUD operations. </li><li>Filtering, ordering, and grouping data. </li><li>Working with related data. </li><li>Handling concurrency. </li><li>Creating compiled LINQ&nbsp;queries. </li><li>Implementing pre-generating views. </li><li>Implementing table-per-hierarchy inheritance. </li><li>Using stored procedures. </li><li>Using Dynamic Data functionality. </li><li>Implementing the repository pattern. </li><li>Understanding lazy loading, eager loading, and explicit loading. </li><li>Using the NoTracking merge option. </li></ul>
<p>For tutorials that show you how to create the project, see&nbsp;<a href="http://www.asp.net/entity-framework/tutorials#Continuing">Continuing with the Entity Framework</a>.</p>
<h1>Getting Started</h1>
<p>To build and run this sample, you must have Visual Studio 2010 installed. Unzip the CSContosoUniversity.zip or VBContosoUniversity.zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the ContosoUniversity.sln
 solution.</p>
<h1>Running the Sample</h1>
<p>To run the sample, hit F5 or choose the Debug | Start Debugging menu command. You will see the home page which includes a menu bar.</p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-web-forms-6c7197aa/image/file/19095/1/contosouniversityhomepage.png" alt="" width="564" height="143"></p>
<p>From this page you can select any of the tabs to perform various actions such as display a list of students, add new students, display a list of courses, and so forth.</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-web-forms-6c7197aa/image/file/19097/1/addstudents.png" alt="" width="258" height="177"></p>
<p><img src="http://i4.code.msdn.microsoft.com/aspnet-web-forms-6c7197aa/image/file/19096/1/studentlist.png" alt="" width="310" height="111"></p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-web-forms-6c7197aa/image/file/19098/1/departmentsconcurrency.png" alt="" width="631" height="252"></p>
<h1>Source Code Overview</h1>
<p>The <em>ContosoUniversity</em> folder includes the following folders and files</p>
<ul>
<li><em>Account</em> folder - Unchanged from what the project template creates. Note that this project does not implement membership functionality.
</li><li><em>App_Data</em> folder - Holds the SQL Server Express database file. </li><li><em>BLL</em> folder - The business logic layer. Holds the repository and the business logic class used by the ObjectDataSource.
</li><li><em>DAL</em> folder - The data access layer.&nbsp; Holds the .edmx file and a partial class with data annotations for the Student entity.
</li><li><em>Properties</em> or <em>MyProject</em> folder - Unchanged from what the project template creates.
</li><li><em>Scripts</em> folder - Unchanged from what the project template creates. </li><li><em>Styles</em> folder - Holds the CSS file, which contains minor changes from what the project template creates.
</li><li>Web page files </li><li><em>Global.asax</em> file - Unchanged from what the project template creates.
</li><li><em>Site.master</em> - Master page file. Specifies the layout of all site pages.
</li><li>Web.config file - Contains the connection string to the database. </li></ul>
