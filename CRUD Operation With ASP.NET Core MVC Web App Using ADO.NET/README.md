# CRUD Operation With ASP.NET Core MVC Web App Using ADO.NET
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- .NET Framework
- ASP.NET Core CRUD
## Topics
- ASP.NET Core CRUD
## Updated
- 01/29/2018
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In this article, I am going to explain how to create an MVC web application in ASP.NET Core 2.0 using ADO.NET. We will be creating a sample Employee Record Management System and performing CRUD operations on it.</span></p>
<p><span style="font-size:small">We will be using Visual Studio 2017 (Version 15.3.5 or above) and SQL Server.</span></p>
<h1>Prerequisites</h1>
<ul>
<li>
<p><span style="font-size:small">Install .NET Core 2.0.0 or above SDK from&nbsp;<a href="https://www.microsoft.com/net/core#windowscmd" target="_blank">here</a>&nbsp;</span></p>
</li><li>
<p><span style="font-size:small">Install Visual Studio 2017 Community Edition (Version 15.3.5 or above) from&nbsp;</span><a href="https://www.visualstudio.com/downloads/" target="_blank" style="font-size:small">here</a></p>
</li></ul>
<div>
<p><span style="font-size:small">Now, we are ready to proceed with the creation of our MVC web application.</span></p>
</div>
<h1>Creating Table and Stored Procedures</h1>
<p><span style="font-size:small">We will be using a DB table to store all the records of employees.</span></p>
<p><span style="font-size:small">Open SQL Server and use the following script to create&nbsp;<em>tblEmployee&nbsp;</em>table.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">Create</span>&nbsp;<span class="sql__keyword">table</span>&nbsp;<span class="sql__id">tblEmployee</span>(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">EmployeeId</span>&nbsp;<span class="sql__keyword">int</span>&nbsp;<span class="sql__id">IDENTITY</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">Name</span>&nbsp;<span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">City</span>&nbsp;<span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Department</span>&nbsp;<span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Gender</span>&nbsp;<span class="sql__keyword">varchar</span>(<span class="sql__number">6</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Now, we will create stored procedures to add, delete, update, and get employee data.</span></p>
<h2><span style="font-size:small">To insert an Employee Record</span></h2>
<div></div>
<div><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">Create&nbsp;procedure&nbsp;spAddEmployee&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Name&nbsp;VARCHAR(<span class="js__num">20</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@City&nbsp;VARCHAR(<span class="js__num">20</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Department&nbsp;VARCHAR(<span class="js__num">20</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Gender&nbsp;VARCHAR(<span class="js__num">6</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
as&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Begin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Insert&nbsp;into&nbsp;tblEmployee&nbsp;(Name,City,Department,&nbsp;Gender)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values&nbsp;(@Name,@City,@Department,&nbsp;@Gender)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
End</pre>
</div>
</div>
</div>
</strong>
<h2 class="endscriptcode"><span style="font-size:small">To update an Employee Record</span></h2>
<strong></strong></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">Create</span>&nbsp;<span class="sql__keyword">procedure</span>&nbsp;<span class="sql__id">spUpdateEmployee</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">EmpId</span>&nbsp;<span class="sql__keyword">INTEGER</span>&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Name</span>&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">20</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">City</span>&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">20</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Department</span>&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">20</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Gender</span>&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">6</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">as</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">begin</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">Update</span>&nbsp;<span class="sql__id">tblEmployee</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">set</span>&nbsp;<span class="sql__keyword">Name</span>=<span class="sql__keyword">@</span><span class="sql__variable">Name</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">City</span>=<span class="sql__keyword">@</span><span class="sql__variable">City</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Department</span>=<span class="sql__keyword">@</span><span class="sql__variable">Department</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Gender</span>=<span class="sql__keyword">@</span><span class="sql__variable">Gender</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">where</span>&nbsp;<span class="sql__id">EmployeeId</span>=<span class="sql__keyword">@</span><span class="sql__variable">EmpId</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">End</span></pre>
</div>
</div>
</div>
<h2 class="endscriptcode"><span style="font-size:small">&nbsp;To delete an Employee Record</span><strong><strong style="font-size:1.5em"><strong>&nbsp;</strong></strong></strong></h2>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong><strong style="font-size:1.5em"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">Create</span>&nbsp;<span class="sql__keyword">procedure</span>&nbsp;<span class="sql__id">spDeleteEmployee</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">EmpId</span>&nbsp;<span class="sql__keyword">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">as</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">begin</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__keyword">Delete</span>&nbsp;<span class="sql__keyword">from</span>&nbsp;<span class="sql__id">tblEmployee</span>&nbsp;<span class="sql__keyword">where</span>&nbsp;<span class="sql__id">EmployeeId</span>=<span class="sql__keyword">@</span><span class="sql__variable">EmpId</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">End</span></pre>
</div>
</div>
</div>
</strong></strong></strong></div>
<div></div>
<div><strong></strong>
<h2 class="endscriptcode"><span style="font-size:small">&nbsp;To view all Employee Records</span></h2>
<strong>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">Create&nbsp;procedure&nbsp;spGetAllEmployees&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
as&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Begin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;from&nbsp;tblEmployee&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
End&nbsp;</pre>
</div>
</div>
</div>
</div>
</strong>
<div class="endscriptcode">
<p><span style="font-size:small">Now, our Database part has been completed. So, we will proceed to create the MVC application using Visual Studio.</span></p>
</div>
<div class="endscriptcode">
<h1>Create MVC Web Application</h1>
</div>
<div class="endscriptcode">
<p><span style="font-size:small">Open Visual Studio and select File &gt;&gt; New &gt;&gt; Project.</span></p>
</div>
</div>
<p><img id="181416" src="181416-project1.png" alt="" width="647" height="422"></p>
<p><span style="font-size:small">After selecting the project, a &quot;New Project&quot; dialog will open. Select .NET Core inside Visual C# menu from the left panel.</span></p>
<p><span style="font-size:small">Then, select &ldquo;ASP.NET Core Web Application&rdquo; from available project types. Put the name of the project as&nbsp;<em>MVCDemoApp&nbsp;</em>and press OK. Refer to this image.</span></p>
<p><span><img id="181417" src="181417-project2.png" alt="" width="650" height="397"><br>
</span></p>
<p><span style="font-size:small">After clicking on OK, a new dialog will open asking to select the project template. You can observe two drop-down menus at the top left of the template window. Select &ldquo;.NET Core&rdquo; and &ldquo;ASP.NET Core 2.0&rdquo;
 from these dropdowns. Then, select &ldquo;Web application(Model-View-Controller)&rdquo; template and press OK.</span></p>
<p><span><img id="181418" src="181418-project3.png" alt=""></span></p>
<p><span style="font-size:small">Now our project will open. You can observe that we have Models, Views and Controllers folders already created. We will be adding our files to these folders only.</span></p>
<p><span><img id="181419" src="181419-solutionexplorer.png" alt="" width="261" height="270"></span></p>
<h1>Adding the Controller to the Application</h1>
<div>
<p><span style="font-size:small">Right click on Controllers folder and select Add &gt;&gt; New Item</span></p>
</div>
<p><img id="181420" src="181420-createcontroller.png" alt="" width="650" height="378"></p>
<p><span style="font-size:small">An &ldquo;Add New Item&rdquo; dialog box will open. Select Web from the left panel, then select &ldquo;MVC Controller Class&rdquo; from templates panel, and put the name as&nbsp;</span><em style="font-size:small">EmployeeController.cs</em><span style="font-size:small">.
 Press OK.</span></p>
<p><img id="181421" src="181421-createcontroller_2.png" alt="" width="650" height="397"></p>
<p><span style="font-size:small">Now our EmployeeController has been created. We will put all our business logic in this controller.</span></p>
<h1>Adding the Model to the Application</h1>
<p><span style="font-size:small">Right click on Models folder and select Add &gt;&gt; Class. Name your class Employee.cs. This class will contain our Employee model properties.</span><br>
<span style="font-size:small">Add one more class file to Models folder. Name it as EmployeeDataAccessLayer.cs . This class will contain our Database related operations.</span><br>
<span style="font-size:small">Now, the Models folder has the following structure.</span></p>
<div></div>
<p><img id="181423" src="181423-solutionexplorermodel.png" alt="" width="274" height="325"></p>
<p><span style="font-size:small">Open&nbsp;<em>Employee.cs</em>&nbsp;and put the following code in it. Since we are adding the required validators to the fields of Employee class, so we need to use <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> at the top.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCDemoApp.Models&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Gender&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Department&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;City&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Open&nbsp;</span><em style="font-size:small">EmployeeDataAccessLayer.cs&nbsp;</em><span style="font-size:small">and put the following code to handle database operations. Make sure to put your connection
 string.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCDemoApp.Models&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;EmployeeDataAccessLayer&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;connectionString&nbsp;=&nbsp;<span class="cs__string">&quot;Put&nbsp;Your&nbsp;Connection&nbsp;string&nbsp;here&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;View&nbsp;all&nbsp;employees&nbsp;details&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Employee&gt;&nbsp;GetAllEmployees()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Employee&gt;&nbsp;lstemployee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Employee&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectionString))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;spGetAllEmployees&quot;</span>,&nbsp;con);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;CommandType.StoredProcedure;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataReader&nbsp;rdr&nbsp;=&nbsp;cmd.ExecuteReader();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(rdr.Read())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;employee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Employee();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.ID&nbsp;=&nbsp;Convert.ToInt32(rdr[<span class="cs__string">&quot;EmployeeID&quot;</span>]);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.Name&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;Name&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.Gender&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;Gender&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.Department&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;Department&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.City&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;City&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstemployee.Add(employee);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Close();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lstemployee;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Add&nbsp;new&nbsp;employee&nbsp;record&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;AddEmployee(Employee&nbsp;employee)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectionString))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;spAddEmployee&quot;</span>,&nbsp;con);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;CommandType.StoredProcedure;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@Name&quot;</span>,&nbsp;employee.Name);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@Gender&quot;</span>,&nbsp;employee.Gender);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@Department&quot;</span>,&nbsp;employee.Department);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@City&quot;</span>,&nbsp;employee.City);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Close();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Update&nbsp;the&nbsp;records&nbsp;of&nbsp;a&nbsp;particluar&nbsp;employee&nbsp;&nbsp;</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;UpdateEmployee(Employee&nbsp;employee)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectionString))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;spUpdateEmployee&quot;</span>,&nbsp;con);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;CommandType.StoredProcedure;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@EmpId&quot;</span>,&nbsp;employee.ID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@Name&quot;</span>,&nbsp;employee.Name);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@Gender&quot;</span>,&nbsp;employee.Gender);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@Department&quot;</span>,&nbsp;employee.Department);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@City&quot;</span>,&nbsp;employee.City);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Close();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;details&nbsp;of&nbsp;a&nbsp;particular&nbsp;employee&nbsp;&nbsp;</span><span class="cs__keyword">public</span>&nbsp;Employee&nbsp;GetEmployeeData(<span class="cs__keyword">int</span>?&nbsp;id)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;employee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Employee();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectionString))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;sqlQuery&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;tblEmployee&nbsp;WHERE&nbsp;EmployeeID=&nbsp;&quot;</span>&nbsp;&#43;&nbsp;id;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(sqlQuery,&nbsp;con);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataReader&nbsp;rdr&nbsp;=&nbsp;cmd.ExecuteReader();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(rdr.Read())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.ID&nbsp;=&nbsp;Convert.ToInt32(rdr[<span class="cs__string">&quot;EmployeeID&quot;</span>]);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.Name&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;Name&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.Gender&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;Gender&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.Department&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;Department&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employee.City&nbsp;=&nbsp;rdr[<span class="cs__string">&quot;City&quot;</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;employee;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Delete&nbsp;the&nbsp;record&nbsp;on&nbsp;a&nbsp;particular&nbsp;employee&nbsp;&nbsp;</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;DeleteEmployee(<span class="cs__keyword">int</span>?&nbsp;id)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectionString))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;spDeleteEmployee&quot;</span>,&nbsp;con);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;CommandType.StoredProcedure;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@EmpId&quot;</span>,&nbsp;id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Close();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Now, we will proceed to create our Views.</span></p>
<h1>Adding Views to the Application</h1>
<p><span style="font-size:small">To add views for our controller class, we need to create a folder inside&nbsp;<em>Views&nbsp;</em>folder with the same name as our controller and then add our views to that folder.</span></p>
<p><span style="font-size:small">Right-click on the&nbsp;<em>Views&nbsp;</em>folder, and then Add &gt;&gt; New Folder and name the folder as&nbsp;<em>Employee</em>.</span></p>
<p><img id="181425" src="181425-addviewfolder.png" alt=""></p>
<p><span style="font-size:small">Now Right click on the&nbsp;</span><em style="font-size:small">Views/Employee</em><span style="font-size:small">&nbsp;folder, and then select Add &gt;&gt; New Item.</span></p>
<p><img id="181426" src="181426-addview.png" alt="" width="650" height="394"></p>
<p><span style="font-size:small">An &ldquo;Add New Item&rdquo; dialog box will open. Select Web from the left panel, then select &ldquo;MVC View Page&rdquo; from templates panel, and put the name as</span><em style="font-size:small">&nbsp;Index.cshtml</em><span style="font-size:small">.
 Press OK.</span></p>
<p><img id="181428" src="181428-addview1.png" alt="" width="650" height="396"></p>
<div><span style="font-size:small">Thus we have created our first view. Similarly add 4 more views in&nbsp;<em>Views/Employee</em>&nbsp;folder,&nbsp;<em>Create.cshtml, Delete.cshtml, Details.cshtml,&nbsp;</em>and&nbsp;<em>Edit.cshtml.</em></span></div>
<div>
<div>
<p><span style="font-size:small">Now, our&nbsp;<em>Views&nbsp;</em>folder will look like this</span></p>
</div>
</div>
<p><img id="181429" src="181429-solutionexplorerview.png" alt="" width="248" height="454"></p>
<p><span style="font-size:small">Since our Views has been created, we will put codes in View and Controller for performing CRUD operations.</span></p>
<h2>Create View</h2>
<p><span style="font-size:small">This view will be used to Add new employee data to the database</span></p>
<div>
<p><span style="font-size:small">Open&nbsp;<em>Create.cshtml&nbsp;</em>and put following code into it.</span></p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;MVCDemoApp.Models.Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[&quot;Title&quot;]&nbsp;=&nbsp;&quot;Create&quot;;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Create<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;h4</span><span class="html__tag_start">&gt;</span>Employees<span class="html__tag_end">&lt;/h4&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;hr</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-4&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Create&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">asp-validation-summary</span>=<span class="html__attr_value">&quot;ModelOnly&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;select</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;option</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;&quot;</span><span class="html__tag_start">&gt;-</span>-&nbsp;Select&nbsp;Gender&nbsp;--<span class="html__tag_end">&lt;/option&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;option</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Male&quot;</span><span class="html__tag_start">&gt;</span>Male<span class="html__tag_end">&lt;/option&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;option</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Female&quot;</span><span class="html__tag_start">&gt;</span>Female<span class="html__tag_end">&lt;/option&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/select&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Department&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Department&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;Department&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;City&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;City&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;City&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Create&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-default&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Index&quot;</span><span class="html__tag_start">&gt;</span>Back&nbsp;to&nbsp;List<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
@section&nbsp;Scripts&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@{await&nbsp;Html.RenderPartialAsync(&quot;_ValidationScriptsPartial&quot;);}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To handle database operations, we will create an object of&nbsp;<em>EmployeeDataAccessLayer&nbsp;</em>class inside the&nbsp;<em>EmployeeController&nbsp;</em>class.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EmployeeController&nbsp;:&nbsp;Controller&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EmployeeDataAccessLayer&nbsp;objemployee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EmployeeDataAccessLayer();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET:&nbsp;/&lt;controller&gt;/&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Index()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To handle the business logic of create, open&nbsp;<em>EmployeeController.cs&nbsp;</em>and put following code into it.</span></div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[HttpGet]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Create()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[HttpPost]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
[ValidateAntiForgeryToken]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Create([Bind]&nbsp;Employee&nbsp;employee)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objemployee.AddEmployee(employee);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(employee);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The [Bind] attribute is used with parameter &ldquo;employee&rdquo; to protect against over-posting.To know more about over-posting visit&nbsp;</span><a href="https://docs.microsoft.com/en-gb/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#overpost" target="_blank" style="font-size:small">here</a><span style="font-size:small">&nbsp;</span></p>
<h2>Index View</h2>
<p><span style="font-size:small">This view will be displaying all the employee records present in the database.&nbsp;Additionally, we will also be providing action methods Edit, Details and Delete on each record.</span></p>
<p><span style="font-size:small">Open&nbsp;<em>Index.cshtml</em>&nbsp;and put following code in it</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;IEnumerable<span class="html__tag_start">&lt;MVCDemoApp</span>.Models.Employee<span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[&quot;Title&quot;]&nbsp;=&nbsp;&quot;Index&quot;;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Index<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Create&quot;</span><span class="html__tag_start">&gt;</span>Create&nbsp;New<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;table</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;table&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;thead</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Gender)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Department)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.City)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/th&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/thead&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tbody</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(var&nbsp;item&nbsp;in&nbsp;Model)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(modelItem&nbsp;=&gt;&nbsp;item.Name)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(modelItem&nbsp;=&gt;&nbsp;item.Gender)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(modelItem&nbsp;=&gt;&nbsp;item.Department)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(modelItem&nbsp;=&gt;&nbsp;item.City)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Edit&quot;</span>&nbsp;<span class="html__attr_name">asp-route-id</span>=<span class="html__attr_value">&quot;@item.ID&quot;</span><span class="html__tag_start">&gt;</span>Edit<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;|&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Details&quot;</span>&nbsp;<span class="html__attr_name">asp-route-id</span>=<span class="html__attr_value">&quot;@item.ID&quot;</span><span class="html__tag_start">&gt;</span>Details<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;|&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Delete&quot;</span>&nbsp;<span class="html__attr_name">asp-route-id</span>=<span class="html__attr_value">&quot;@item.ID&quot;</span><span class="html__tag_start">&gt;</span>Delete<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tbody&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To handle the business logic of Index view, open&nbsp;<em>EmployeeController.cs&nbsp;</em>and add following code in Index method.</span></div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Index()&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Employee&gt;&nbsp;lstEmployee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Employee&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lstEmployee&nbsp;=&nbsp;objemployee.GetAllEmployees().ToList();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(lstEmployee);&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<h2>Edit View</h2>
<p><span style="font-size:small">This view will enable us to edit an existing employee data.</span></p>
<p><span style="font-size:small">Open&nbsp;<em>Edit.cshtml&nbsp;</em>and put following code into it.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;MVCDemoApp.Models.Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[&quot;Title&quot;]&nbsp;=&nbsp;&quot;Edit&quot;;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Edit<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;h4</span><span class="html__tag_start">&gt;</span>Employees<span class="html__tag_end">&lt;/h4&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;hr</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-4&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Edit&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">asp-validation-summary</span>=<span class="html__attr_value">&quot;ModelOnly&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;hidden&quot;</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;ID&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;select</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;option</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;&quot;</span><span class="html__tag_start">&gt;-</span>-&nbsp;Select&nbsp;Gender&nbsp;--<span class="html__tag_end">&lt;/option&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;option</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Male&quot;</span><span class="html__tag_start">&gt;</span>Male<span class="html__tag_end">&lt;/option&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;option</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Female&quot;</span><span class="html__tag_start">&gt;</span>Female<span class="html__tag_end">&lt;/option&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/select&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Department&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Department&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;Department&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;City&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;City&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">asp-validation-for</span>=<span class="html__attr_value">&quot;City&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Save&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-default&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Index&quot;</span><span class="html__tag_start">&gt;</span>Back&nbsp;to&nbsp;List<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
@section&nbsp;Scripts&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@{await&nbsp;Html.RenderPartialAsync(&quot;_ValidationScriptsPartial&quot;);}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To handle the business logic of Edit view, open&nbsp;</span><em style="font-size:small">EmployeeController.cs&nbsp;</em><span style="font-size:small">and add following code to it.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[HttpGet]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Edit(<span class="cs__keyword">int</span>?&nbsp;id)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;employee&nbsp;=&nbsp;objemployee.GetEmployeeData(id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(employee&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(employee);&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[HttpPost]&nbsp;&nbsp;&nbsp;
[ValidateAntiForgeryToken]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Edit(<span class="cs__keyword">int</span>&nbsp;id,&nbsp;[Bind]Employee&nbsp;employee)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;!=&nbsp;employee.ID)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objemployee.UpdateEmployee(employee);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(employee);&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">As you can observe that we have two Edit action methods, one for HttpGet and another for HttpPost.The HttpGet Edit action method will fetch the employee data and populates the fields of edit view. Once the user clicks on Save
 button after editing the record, a Post request will be generated which is handled by HttpPost Edit action method.</span></p>
<h2>Details View</h2>
<div>
<p><span style="font-size:small">This view will display the details of a particular employee.</span></p>
</div>
<div><span style="font-size:small">Open&nbsp;<em>Details.cshtml&nbsp;</em>and put following code into it.</span></div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;MVCDemoApp.Models.Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[&quot;Title&quot;]&nbsp;=&nbsp;&quot;Details&quot;;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Details<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h4</span><span class="html__tag_start">&gt;</span>Employees<span class="html__tag_end">&lt;/h4&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;hr</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dl</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dl-horizontal&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dt</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dt&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dd</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dd&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dt</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Gender)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dt&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dd</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.Gender)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dd&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dt</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Department)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dt&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dd</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.Department)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dd&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dt</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.City)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dt&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;dd</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.City)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dd&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/dl&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Edit&quot;</span>&nbsp;<span class="html__attr_name">asp-route-id</span>=<span class="html__attr_value">&quot;@Model.ID&quot;</span><span class="html__tag_start">&gt;</span>Edit<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;|&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">asp-action</span>=<span class="html__attr_value">&quot;Index&quot;</span><span class="html__tag_start">&gt;</span>Back&nbsp;to&nbsp;List<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To handle the business logic of Details view,open&nbsp;</span><em style="font-size:small">EmployeeController.cs&nbsp;</em><span style="font-size:small">and add following code to it.</span></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[HttpGet]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Details(<span class="cs__keyword">int</span>?&nbsp;id)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;employee&nbsp;=&nbsp;objemployee.GetEmployeeData(id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(employee&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(employee);&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Delete View</h2>
<p><span style="font-size:small">This view will help us to remove employee data .</span></p>
<p><span style="font-size:small">Open&nbsp;<em>Delete.cshtml&nbsp;</em>and put following code into it.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">@model&nbsp;MVCDemoApp.Models.Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="js__string">&quot;Title&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;Delete&quot;</span>;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&lt;h2&gt;Delete&lt;/h2&gt;&nbsp;&nbsp;&nbsp;
&lt;h3&gt;Are&nbsp;you&nbsp;sure&nbsp;you&nbsp;want&nbsp;to&nbsp;<span class="js__operator">delete</span>&nbsp;<span class="js__operator">this</span>?&lt;/h3&gt;&nbsp;&nbsp;&nbsp;
&lt;div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h4&gt;Employees&lt;/h4&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;hr&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;dl&nbsp;class=<span class="js__string">&quot;dl-horizontal&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Gender)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.Gender)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Department)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.Department)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.City)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dt&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(model&nbsp;=&gt;&nbsp;model.City)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dd&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dl&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;form&nbsp;asp-action=<span class="js__string">&quot;Delete&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;hidden&quot;</span>&nbsp;asp-<span class="js__statement">for</span>=<span class="js__string">&quot;ID&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;value=<span class="js__string">&quot;Delete&quot;</span>&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-default&quot;</span>&nbsp;/&gt;&nbsp;|&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a&nbsp;asp-action=<span class="js__string">&quot;Index&quot;</span>&gt;Back&nbsp;to&nbsp;List&lt;/a&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/form&gt;&nbsp;&nbsp;&nbsp;
&lt;/div&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To handle the business logic of Delete view, open&nbsp;</span><em style="font-size:small">EmployeeController.cs&nbsp;</em><span style="font-size:small">and add following code to it.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[HttpGet]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Delete(<span class="cs__keyword">int</span>?&nbsp;id)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;employee&nbsp;=&nbsp;objemployee.GetEmployeeData(id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(employee&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(employee);&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[HttpPost,&nbsp;ActionName(<span class="cs__string">&quot;Delete&quot;</span>)]&nbsp;&nbsp;&nbsp;
[ValidateAntiForgeryToken]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;DeleteConfirmed(<span class="cs__keyword">int</span>?&nbsp;id)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;objemployee.DeleteEmployee(id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">To complete Delete operation we need two Delete methods accepting same parameter (Employee Id). But two methods with same name and method signature will create a compile time error and if we rename the Delete method then routing
 won't be able to find it as asp.net maps URL segments to action methods by name. So, to resolve this issue we put ActionName(&quot;Delete&quot;) attribute to the DeleteConfirmed method. That attribute performs mapping for the routing system so that a URL that includes
 /Delete/ for a POST request will find the DeleteConfirmed method.</span></p>
<p><span style="font-size:small">When we click on Delete link on the Index page, it will send a Get request and return a View of the employee using HttpGet Delete method. When we click on Delete button on this view, it will send a Post request to delete the
 record which is handled by the HttpPost DeleteConfirmed method. Performing a delete operation in response to a Get request (or for that matter, performing an edit operation, create operation, or any other operation that changes data) opens up a security hole.
 Hence, we have two separate methods.</span></p>
<div><span style="font-size:small">And that&rsquo;s it. We have created our first ASP.NET Core MVC web application. Before launching the application, we will configure route URLs.&nbsp;Open&nbsp;<em>Startup.cs</em>&nbsp;file to set the format for routing.Scroll
 down to app.UseMvc method, where you can set the route url. </span>
<p><span style="font-size:small">Make sure that your route url is set like this</span></p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">app.UseMvc(routes&nbsp;=&gt;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;routes.MapRoute(&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="cs__string">&quot;default&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;template:&nbsp;<span class="cs__string">&quot;{controller=Home}/{action=Index}/{id?}&quot;</span>);&nbsp;&nbsp;&nbsp;
});&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">This url pattern sets HomeController as default controller and Index method as default action method, whereas Id parameter is optional. Default and optional route parameters need not be present in the
 URL path for a match. If we do not append any controller name in the URL then it will take HomeController as default controller and Index method of HomeController as default action method. Similarly, if we append only Controller name in the URL, it will navigate
 to Index action method of that controller.</span>
<p><span style="font-size:small">Now press F5 to launch the application and navigate to Employee controller by appending&nbsp;<em>/Employee</em>in the URL.</span></p>
<p><span style="font-size:small">You can see the page as shown below.</span></p>
<p><img id="181431" src="181431-index1.png" alt="" width="650" height="189"></p>
</div>
<p>&nbsp;</p>
<p><span style="font-size:small">Click on&nbsp;<em>CreateNew</em>&nbsp;to navigate to&nbsp;<em>Create&nbsp;</em>view. Add a new Employee record as shown in the image below.</span></p>
<p><span><img id="181432" src="181432-create1.png" alt="" width="394" height="553"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">If we miss the data in any field while creating employee record, we will get a required field validation error message.</span></p>
<p><span><img id="181433" src="181433-createvalidation.png" alt="" width="416" height="567"></span></p>
<p><span style="font-size:small">After inserting the data in all the fields, click on &quot;Create&quot; button. The new employee record will be created and you will be redirected to the Index view, displaying records of all the employees. Here, we can also see action
 methods Edit, Details, and Delete.</span></p>
<p><span><img id="181434" src="181434-index2.png" alt="" width="650" height="203"><br>
</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">If we want to edit an existing employee record, then click Edit action link. It will open Edit View as below where we can change the employee data.</span></p>
<p><img id="181435" src="181435-edit1.png" alt="" width="396" height="548"></p>
<p><span style="font-size:small">Here we have changed the Department of employee Swati from Finance to HR.Click on &quot;Save&quot; to return to the Index view to see the updated changes as highlighted in the image below.</span></p>
<p><img id="181436" src="181436-index3.png" alt="" width="650" height="188"></p>
<p><span style="font-size:small">If we miss any fields while editing employee records, then Edit view will also throw required field validation error message</span></p>
<p><img id="181437" src="181437-editvalidation.png" alt="" width="397" height="567"></p>
<p><span style="font-size:small">If you want to see the details of any Employee, then click on Details action link, which will open the Details view, as shown in the image below.</span></p>
<p><img id="181438" src="181438-details.png" alt="" width="311" height="305"></p>
<p><span style="font-size:small">Click on &quot;Back to List&quot; to go back to Index view. Now, we will perform Delete operation on an employee named Venkat. Click on Delete action link which will open Delete view asking for a confirmation to delete.</span></p>
<p><img id="181439" src="181439-delete1.png" alt="" width="422" height="384"></p>
<p><span style="font-size:small">Once we click on Delete button, it will send HttpPost request to delete employee record and we will be redirected to the Index view. Here, we can see that the employee with name Venkat has been removed from our record.</span></p>
<p><img id="181440" src="181440-index4.png" alt="" width="650" height="174"></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><em>MVCDemoApp.zip- </em>code&nbsp;attached for better understanding. Feel free to download and play with it.</span>
</li></ul>
