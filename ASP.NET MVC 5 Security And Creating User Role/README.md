# ASP.NET MVC 5 Security And Creating User Role
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- MVC
- ASP.NET MVC 5
- ASP.NET Identity
## Topics
- ASP.NET MVC
- MVC
- ASP.NET Identity
## Updated
- 06/19/2019
## Description

<h1>Introduction</h1>
<p><img id="147301" src="147301-1.gif" alt="" width="550" height="320"></p>
<p><span>In this article we will see how to use ASP.NET Identity in MVC Application for creating user roles and displaying the menu depending on user roles.</span></p>
<p><span>Here we will see how to:</span>&nbsp;</p>
<ul>
<li><span>Create default admin role and other roles</span><span>.</span> </li><li><span>Create default admin users</span><span>.</span> </li><li><span>Add Username for new User Registration</span><span>.</span> </li><li><span>Select User Role during User Registration</span><span>.</span> </li><li><span>Change Login Email with User Name</span><span>.</span> </li><li><span>Display Role Creation Menu only for Admin User</span><span>.</span> </li><li><span>Display message for normal user</span><span>.</span> </li><li><span>Redirect Unauthenticated users to default home page</span><span>.</span>&nbsp;
</li></ul>
<h2><strong><span>Authentication and Authorization<br>
</span></strong><span><br>
<strong>Authentication</strong></span></h2>
<p><span>Check for the Valid User. Here the question is how to check whether a user is valid or not. When a user comes to a Web ssite for the first time he will register for that Web site. All his information, like user name, password, email, and so on will
 be stored in the Web site database. When a user enters his userID and password, the information will be checked with the database. If the user has entered the same userID and Password as in the database then he or she is a valid user and will be redirected
 to the Web site home page. If the user enters a UserID and/or Password that does not match the database then the login page will give a message, something like &ldquo;Enter valid Name or Password&rdquo;. The entire process of checking whether the user is valid
 or not for accessing the Web site is called Authentication.</span><img id="147302" src="147302-1.png" alt="" width="550" height="212"></p>
<p><strong><span>Authorization<br>
</span></strong><span><br>
Once the user is authenticated he needs to be redirected to the appropriate page by his role. For example, when an Admin is logged in, then he is to be redirected to the Admin Page. If an Accountant is logged in, then he is to be redirected to his Accounts
 page. If an End User is logged in, then he is to be redirected to his page.</span><img id="147303" src="147303-2.png" alt="" width="654" height="242"></p>
<h1><span>Building the Sample</span></h1>
<p><strong>Prerequisites</strong></p>
<p><strong>Visual Studio 2015:</strong><span>&nbsp;You can download it from&nbsp;</span><span><a href="https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx">here</a></span><span>.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>Create your Web Application in Visual Studio 2015<br>
</strong><br>
<span>After installing our Visual Studio 2015 click Start, then Programs and select&nbsp;</span><strong>Visual Studio 2015</strong><span>&nbsp;- Click</span><strong>Visual Studio 2015</strong><span>. Click New, then Project, select Web and then select&nbsp;</span><strong>ASP.NET
 Web Application</strong><span>. Enter your project name and click OK.</span></p>
<p><span><img id="147304" src="147304-3.png" alt="" width="556" height="322"></span></p>
<p><span>Select MVC and click OK.</span></p>
<p><img id="147305" src="147305-4.png" alt="" width="557" height="325"></p>
<h2><strong><span>Create a Database</span></strong></h2>
<p>Firstly, we will create a Database and set the connection string in&nbsp;<strong>web.config</strong>&nbsp;file for DefaultConnection with our new database connection. We will be using this database for ASP.NET Identity table creation and also our sample
 attendance Web project. Instead of using two databases as one for default ASP.NET user database and another for our Attendance DB, here we will be using one common database for both user details and for our sample web project demo.</p>
<div><span>Create Database: Run the following and create database script to create our sample test database.</span>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Create&nbsp;date&nbsp;:&nbsp;2016-01-17&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Description&nbsp;:&nbsp;To&nbsp;Create&nbsp;Database&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;=============================================&nbsp;&nbsp;</span>&nbsp;
--<span class="sql__id">Script</span><span class="sql__keyword">to</span><span class="sql__keyword">create</span><span class="sql__id">DB</span>,<span class="sql__keyword">Table</span><span class="sql__keyword">and</span><span class="sql__id">sample</span><span class="sql__keyword">Insert</span><span class="sql__keyword">data</span><span class="sql__keyword">USE</span><span class="sql__keyword">MASTER</span>;&nbsp;&nbsp;&nbsp;
<span class="sql__com">--&nbsp;1)&nbsp;Check&nbsp;for&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;new&nbsp;DB&nbsp;&nbsp;</span><span class="sql__keyword">IF</span><span class="sql__keyword">EXISTS</span>&nbsp;(<span class="sql__keyword">SELECT</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span><span class="sql__id">sys</span>.<span class="sql__keyword">databases</span><span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'AttendanceDB'</span>&nbsp;)&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">BEGIN</span><span class="sql__keyword">ALTER</span><span class="sql__keyword">DATABASE</span><span class="sql__id">AttendanceDB</span><span class="sql__keyword">SET</span><span class="sql__id">SINGLE_USER</span><span class="sql__keyword">WITH</span><span class="sql__keyword">ROLLBACK</span><span class="sql__id">IMMEDIATE</span><span class="sql__keyword">DROP</span><span class="sql__keyword">DATABASE</span><span class="sql__id">AttendanceDB</span>&nbsp;;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">END</span><span class="sql__keyword">CREATE</span><span class="sql__keyword">DATABASE</span><span class="sql__id">AttendanceDB</span><span class="sql__id">GO</span><span class="sql__keyword">USE</span><span class="sql__id">AttendanceDB</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Web.Config</strong>
<div><span><br>
In web.config file we can find the&nbsp;</span><span>DefaultConnection</span><span>&nbsp;</span><span>Connection string. By default ASP.NET MVC will use this connection string to create all ASP.NET Identity related tables like AspNetUsers, etc. For our application
 we also need to use database for other page activities instead of using two different databases, one for User details and one for our own functionality. Here I will be using one database where all ASP.NET Identity tables will be created and also we can create
 our own tables for other page uses.</span></div>
<div><span>Here in connection string change your SQL Server Name, UID and PWD to create and store all user details in one database.</span><span>&nbsp;</span></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">&lt;connectionStrings&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add&nbsp;name=<span class="js__string">&quot;DefaultConnection&quot;</span>&nbsp;connectionString=<span class="js__string">&quot;data&nbsp;source=YOURSERVERNAME;initial&nbsp;catalog=AttendanceDB;user&nbsp;id=UID;password=PWD;Integrated&nbsp;Security=True&quot;</span>&nbsp;providerName=<span class="js__string">&quot;System.Data.SqlClient&quot;</span>&nbsp;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&lt;/connectionStrings&gt;&nbsp;</pre>
</div>
</div>
</div>
<p><strong style="font-size:1.5em">Create default Role and Admin User</strong></p>
<p><span>Firstly, create default user role like &ldquo;Admin&rdquo;,&rdquo;Manager&rdquo;, etc and also we will create a default admin user. We will be creating all default roles and user in &ldquo;Startup.cs&rdquo;</span></p>
<p><img id="147306" src="147306-5.png" alt="" width="308" height="338"></p>
<p><span>OWIN (OPEN WEB Interface for .NET) defines a standard interface between .NET and WEB Server and each OWIN application has a&nbsp;</span><strong>Startup Class</strong><span>&nbsp;where we can specify components.</span></p>
<p><strong>Reference</strong></p>
<div>
<ul>
<li><a href="http://www.asp.net/aspnet/overview/owin-and-katana" target="_blank">OWIN and Katana</a>
</li></ul>
</div>
<p><span>In &ldquo;Startup.cs&rdquo; file we can find the&nbsp;</span><span>Configuration</span><span>&nbsp;method. From this method we will be calling our<span><strong>createRolesandUsers()</strong>&nbsp;method to create a default user role and user.&nbsp;</span>We
 will check for Roles already created or not. If Roles, like Admin, is not created, then we will create a new Role as &ldquo;Admin&rdquo; and we will create a default user and set the user role as Admin. We will be using this user as super user where the user
 can create new roles from our MVC application.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigureAuth(app);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;createRolesandUsers();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;this&nbsp;method&nbsp;we&nbsp;will&nbsp;create&nbsp;default&nbsp;User&nbsp;roles&nbsp;and&nbsp;Admin&nbsp;user&nbsp;for&nbsp;login&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;createRolesandUsers()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ApplicationDbContext&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationDbContext();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;roleManager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RoleManager&lt;IdentityRole&gt;(<span class="cs__keyword">new</span>&nbsp;RoleStore&lt;IdentityRole&gt;(context));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;UserManager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UserManager&lt;ApplicationUser&gt;(<span class="cs__keyword">new</span>&nbsp;UserStore&lt;ApplicationUser&gt;(context));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;Startup&nbsp;iam&nbsp;creating&nbsp;first&nbsp;Admin&nbsp;Role&nbsp;and&nbsp;creating&nbsp;a&nbsp;default&nbsp;Admin&nbsp;User&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!roleManager.RoleExists(<span class="cs__string">&quot;Admin&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;first&nbsp;we&nbsp;create&nbsp;Admin&nbsp;rool&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;role&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.AspNet.Identity.EntityFramework.IdentityRole.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.Identity.EntityFramework.IdentityRole">Microsoft.AspNet.Identity.EntityFramework.IdentityRole</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;role.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Admin&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleManager.Create(role);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Here&nbsp;we&nbsp;create&nbsp;a&nbsp;Admin&nbsp;super&nbsp;user&nbsp;who&nbsp;will&nbsp;maintain&nbsp;the&nbsp;website&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationUser();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user.UserName&nbsp;=&nbsp;<span class="cs__string">&quot;shanu&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user.Email&nbsp;=&nbsp;<span class="cs__string">&quot;syedshanumcain@gmail.com&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;userPWD&nbsp;=&nbsp;<span class="cs__string">&quot;A@Z200711&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;chkUser&nbsp;=&nbsp;UserManager.Create(user,&nbsp;userPWD);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;default&nbsp;User&nbsp;to&nbsp;Role&nbsp;Admin&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(chkUser.Succeeded)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result1&nbsp;=&nbsp;UserManager.AddToRole(user.Id,&nbsp;<span class="cs__string">&quot;Admin&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;creating&nbsp;Creating&nbsp;Manager&nbsp;role&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!roleManager.RoleExists(<span class="cs__string">&quot;Manager&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;role&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.AspNet.Identity.EntityFramework.IdentityRole.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.Identity.EntityFramework.IdentityRole">Microsoft.AspNet.Identity.EntityFramework.IdentityRole</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;role.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Manager&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleManager.Create(role);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;creating&nbsp;Creating&nbsp;Employee&nbsp;role&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!roleManager.RoleExists(<span class="cs__string">&quot;Employee&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;role&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.AspNet.Identity.EntityFramework.IdentityRole.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.Identity.EntityFramework.IdentityRole">Microsoft.AspNet.Identity.EntityFramework.IdentityRole</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;role.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Employee&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleManager.Create(role);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>When we run our application we can see new default ASP.NET user related tables will be created in our&nbsp;</span><strong>AttendanceDB</strong><span>&nbsp;Database. Here we can see in the following image as all ASP.NET
 user related tables will be automatically created when we run our application and also all our default user roles will be inserted in AspNetRoles table and default admin user will be created in AspNetUsers table.</span></div>
<div class="endscriptcode"><span><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span><img id="147308" src="147308-7.png" alt="" width="600" height="220"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong><span>Customize User Registration</span></strong><strong><span>&nbsp;with adding username and Role</span></strong></div>
<div class="endscriptcode"><span><br>
</span></div>
<p><img id="147307" src="147307-2.gif" alt="" width="550" height="400"></p>
<p>By default for user registration in ASP.NET MVC 5 we can use Email and passoword. Here, we will customize the default user registration with adding a username and a ComboBox to display the user roles. User can enter their username and select there user role
 during registration.</p>
<p><strong>View Part:&nbsp;</strong><span>Firstly, add a TextBox for username and ComboBox for displaying User Role in Register.cshtml,</span></p>
<p><img id="147309" src="147309-6.png" alt="" width="323" height="265"></p>
<p><span>Double click the&nbsp;</span><strong>Register.cshtml</strong><span>&nbsp;and change the html code like the following to add textbox and combobox with caption. Here we can see first we add a textbox and Combobox .We bind the combobox with (SelectList)
 ViewBag.Name.&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="csharp">@model&nbsp;shanuMVCUserRoles.Models.RegisterViewModel&nbsp;&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="cs__string">&quot;Register&quot;</span>;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&lt;h2&gt;@ViewBag.Title.&lt;/h2&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@<span class="cs__keyword">using</span>&nbsp;(Html.BeginForm(<span class="cs__string">&quot;Register&quot;</span>,&nbsp;<span class="cs__string">&quot;Account&quot;</span>,&nbsp;FormMethod.Post,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-horizontal&quot;</span>,&nbsp;role&nbsp;=&nbsp;<span class="cs__string">&quot;form&quot;</span>&nbsp;}))&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.AntiForgeryToken()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h4&gt;Create&nbsp;a&nbsp;<span class="cs__keyword">new</span>&nbsp;account.&lt;/h4&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;hr&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationSummary(<span class="cs__string">&quot;&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;text-danger&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.Email,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.TextBoxFor(m&nbsp;=&gt;&nbsp;m.Email,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-control&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.UserName,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.TextBoxFor(m&nbsp;=&gt;&nbsp;m.UserName,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-control&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.Password,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.PasswordFor(m&nbsp;=&gt;&nbsp;m.Password,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-control&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.ConfirmPassword,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.PasswordFor(m&nbsp;=&gt;&nbsp;m.ConfirmPassword,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-control&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.Label(<span class="cs__string">&quot;user&nbsp;Role&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@*@Html.DropDownList(<span class="cs__string">&quot;Name&quot;</span>)*@&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DropDownList(<span class="cs__string">&quot;UserRoles&quot;</span>,&nbsp;(SelectList)ViewBag.Name,&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-offset-2&nbsp;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="cs__string">&quot;submit&quot;</span>&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;btn&nbsp;btn-default&quot;</span>&nbsp;<span class="cs__keyword">value</span>=<span class="cs__string">&quot;Register&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@section&nbsp;Scripts&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Scripts.Render(<span class="cs__string">&quot;~/bundles/jqueryval&quot;</span>)&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Model Part<br>
</span></strong><br>
<span>Next in&nbsp;</span><strong>AccountViewModel.cs</strong><span>&nbsp;check for the RegisterViewModel and add the UserRoles and UserName properties with required for validation.</span></div>
<p><img id="147310" src="147310-8.png" alt="" width="1234" height="539"></p>
<p><span>Double click the&nbsp;</span><strong>AccountViewModel.cs</strong><span>&nbsp;file from Models folder, find the RegisterViewModel class, add UserName and UserRoles properties as in the following.&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;RegisterViewModel&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;UserRoles&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;UserRoles&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[EmailAddress]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Email&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Email&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;UserName&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;UserName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StringLength(<span class="js__num">100</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="js__string">&quot;The&nbsp;{0}&nbsp;must&nbsp;be&nbsp;at&nbsp;least&nbsp;{2}&nbsp;characters&nbsp;long.&quot;</span>,&nbsp;MinimumLength&nbsp;=&nbsp;<span class="js__num">6</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataType(DataType.Password)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Password&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Password&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataType(DataType.Password)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Confirm&nbsp;password&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Compare(<span class="js__string">&quot;Password&quot;</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="js__string">&quot;The&nbsp;password&nbsp;and&nbsp;confirmation&nbsp;password&nbsp;do&nbsp;not&nbsp;match.&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ConfirmPassword&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Controller Part</span></strong><br>
<br>
<span>Next in</span><strong>&nbsp;AccountController.cs f</strong><span>irst we get all the role names to be bound in ComboBox except Admin role and in register button click we will add the functionality to insert username and set user selected role in ASP.NET
 identity database.</span></div>
<p><img id="147311" src="147311-9.png" alt="" width="312" height="208"></p>
<p>Firstly, create an object for our ApplicationDBContext. Here, ApplicationDBContext is a class which is used to perform all ASP.NET Identity database functions like create user, roles, etc.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">ApplicationDbContext&nbsp;context;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;AccountController()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationDbContext();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Register ActionResult method:&nbsp;</strong></div>
<p><span>Using the&nbsp;</span><strong>ApplicationDBConterxt&nbsp;</strong><span>object we will get all the roles from database. For user registration we will not display the Admin roles. User can select rest of any role type during registration.&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;GET:&nbsp;/Account/Register&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Register()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Name&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectList(context.Roles.Where(u&nbsp;=&gt;&nbsp;!u.Name.Contains(<span class="cs__string">&quot;Admin&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToList(),&nbsp;<span class="cs__string">&quot;Name&quot;</span>,&nbsp;<span class="cs__string">&quot;Name&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Register User<br>
</span></strong><span><br>
By default the user email will be stored as username in AspNetUsers table. Here we will change to store the user entered name. After user was created successfully we will set the user selected role for the user.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;POST:&nbsp;/Account/Register&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ValidateAntiForgeryToken]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;ActionResult&gt;&nbsp;Register(RegisterViewModel&nbsp;model)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationUser&nbsp;{&nbsp;UserName&nbsp;=&nbsp;model.UserName,&nbsp;Email&nbsp;=&nbsp;model.Email&nbsp;};&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;await&nbsp;UserManager.CreateAsync(user,&nbsp;model.Password);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result.Succeeded)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;SignInManager.SignInAsync(user,&nbsp;isPersistent:&nbsp;<span class="cs__keyword">false</span>,&nbsp;rememberBrowser:&nbsp;<span class="cs__keyword">false</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;how&nbsp;to&nbsp;enable&nbsp;account&nbsp;confirmation&nbsp;and&nbsp;password&nbsp;reset&nbsp;please&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=320771&nbsp;&nbsp;</span><span class="cs__com">//&nbsp;Send&nbsp;an&nbsp;email&nbsp;with&nbsp;this&nbsp;link&nbsp;&nbsp;</span><span class="cs__com">//&nbsp;string&nbsp;code&nbsp;=&nbsp;await&nbsp;UserManager.GenerateEmailConfirmationTokenAsync(user.Id);&nbsp;&nbsp;</span><span class="cs__com">//&nbsp;var&nbsp;callbackUrl&nbsp;=&nbsp;Url.Action(&quot;ConfirmEmail&quot;,&nbsp;&quot;Account&quot;,&nbsp;new&nbsp;{&nbsp;userId&nbsp;=&nbsp;user.Id,&nbsp;code&nbsp;=&nbsp;code&nbsp;},&nbsp;protocol:&nbsp;Request.Url.Scheme);&nbsp;&nbsp;</span><span class="cs__com">//&nbsp;await&nbsp;UserManager.SendEmailAsync(user.Id,&nbsp;&quot;Confirm&nbsp;your&nbsp;account&quot;,&nbsp;&quot;Please&nbsp;confirm&nbsp;your&nbsp;account&nbsp;by&nbsp;clicking&nbsp;&lt;a&nbsp;href=\&quot;&quot;&nbsp;&#43;&nbsp;callbackUrl&nbsp;&#43;&nbsp;&quot;\&quot;&gt;here&lt;/a&gt;&quot;);&nbsp;&nbsp;</span><span class="cs__com">//Assign&nbsp;Role&nbsp;to&nbsp;user&nbsp;Here&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;<span class="cs__keyword">this</span>.UserManager.AddToRoleAsync(user.Id,&nbsp;model.UserRoles);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Ends&nbsp;Here&nbsp;&nbsp;&nbsp;</span><span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>,&nbsp;<span class="cs__string">&quot;Users&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Name&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectList(context.Roles.Where(u&nbsp;=&gt;&nbsp;!u.Name.Contains(<span class="cs__string">&quot;Admin&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToList(),&nbsp;<span class="cs__string">&quot;Name&quot;</span>,&nbsp;<span class="cs__string">&quot;Name&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddErrors(result);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;we&nbsp;got&nbsp;this&nbsp;far,&nbsp;something&nbsp;failed,&nbsp;redisplay&nbsp;form&nbsp;&nbsp;</span><span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><strong style="font-size:1.5em">Customize User&nbsp;</strong><strong style="font-size:1.5em">login</strong></p>
<p><span>In the same way as user registration we will customize user login to change email as username to enter. By default in ASP.NET MVC 5 for login user needs to enter Email and password. Here we will customize for user by entering username and password.
 In this demo we are not using any other Facebook, Gmail or Twitter login so we will be using UserName instead of Email.</span></p>
<p><strong>View Part<br>
</strong><br>
Here we will change the email with UserName in&nbsp;<strong>Login.cshtml</strong>. We can find the&nbsp;<strong>Login.cshtml</strong>&nbsp;file from the folder inside&nbsp;<strong>Views/Account/Login.cshtml.</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">@<span class="cs__keyword">using</span>&nbsp;shanuMVCUserRoles.Models&nbsp;&nbsp;&nbsp;
@model&nbsp;LoginViewModel&nbsp;&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="cs__string">&quot;Log&nbsp;in&quot;</span>;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&lt;h2&gt;@ViewBag.Title&lt;/h2&gt;&nbsp;&nbsp;&nbsp;
&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;row&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-8&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;section&nbsp;id=<span class="cs__string">&quot;loginForm&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="cs__keyword">using</span>&nbsp;(Html.BeginForm(<span class="cs__string">&quot;Login&quot;</span>,&nbsp;<span class="cs__string">&quot;Account&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;ReturnUrl&nbsp;=&nbsp;ViewBag.ReturnUrl&nbsp;},&nbsp;FormMethod.Post,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-horizontal&quot;</span>,&nbsp;role&nbsp;=&nbsp;<span class="cs__string">&quot;form&quot;</span>&nbsp;}))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.AntiForgeryToken()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h4&gt;Use&nbsp;a&nbsp;local&nbsp;account&nbsp;to&nbsp;log&nbsp;<span class="cs__keyword">in</span>.&lt;/h4&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;hr&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationSummary(<span class="cs__keyword">true</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;text-danger&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.UserName,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.TextBoxFor(m&nbsp;=&gt;&nbsp;m.UserName,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-control&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(m&nbsp;=&gt;&nbsp;m.UserName,&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;text-danger&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.Password,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;col-md-2&nbsp;control-label&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.PasswordFor(m&nbsp;=&gt;&nbsp;m.Password,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;form-control&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(m&nbsp;=&gt;&nbsp;m.Password,&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;text-danger&quot;</span>&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-offset-2&nbsp;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;checkbox&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.CheckBoxFor(m&nbsp;=&gt;&nbsp;m.RememberMe)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(m&nbsp;=&gt;&nbsp;m.RememberMe)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;form-group&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-offset-2&nbsp;col-md-10&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="cs__string">&quot;submit&quot;</span>&nbsp;<span class="cs__keyword">value</span>=<span class="cs__string">&quot;Log&nbsp;in&quot;</span>&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;btn&nbsp;btn-default&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(<span class="cs__string">&quot;Register&nbsp;as&nbsp;a&nbsp;new&nbsp;user&quot;</span>,&nbsp;<span class="cs__string">&quot;Register&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@*&nbsp;Enable&nbsp;<span class="cs__keyword">this</span>&nbsp;once&nbsp;you&nbsp;have&nbsp;account&nbsp;confirmation&nbsp;enabled&nbsp;<span class="cs__keyword">for</span>&nbsp;password&nbsp;reset&nbsp;functionality&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(<span class="cs__string">&quot;Forgot&nbsp;your&nbsp;password?&quot;</span>,&nbsp;<span class="cs__string">&quot;ForgotPassword&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;*@&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/section&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;col-md-4&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;section&nbsp;id=<span class="cs__string">&quot;socialLoginForm&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.Partial(<span class="cs__string">&quot;_ExternalLoginsListPartial&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;ExternalLoginListViewModel&nbsp;{&nbsp;ReturnUrl&nbsp;=&nbsp;ViewBag.ReturnUrl&nbsp;})&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/section&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@section&nbsp;Scripts&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Scripts.Render(<span class="cs__string">&quot;~/bundles/jqueryval&quot;</span>)&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Model Part</strong>
<div>&nbsp;</div>
<div><span>Same as Registration in AccountViewModel we need to find the loginViewModel to change the Email with UserName,</span></div>
<div><span><br>
</span></div>
</div>
<p><img id="147313" src="147313-10.png" alt="" width="553" height="271"></p>
<p>&nbsp;</p>
<p>Here in the following code we can see that we have changed the Email property to UserName. &nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;LoginViewModel&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;UserName&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;UserName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataType(DataType.Password)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Password&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Password&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Remember&nbsp;me?&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">bool</span>&nbsp;RememberMe&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong><span>Controller Part:<br>
</span></strong><span><br>
In login button click we need to change the email with username to check from database for user Authentication. Here in the following code we can see as we changed the email with username after successful login we will be redirect to the user page. Next we
 will see how to create a user page and display the text and menu by user role.</span><span>&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;POST:&nbsp;/Account/Login&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ValidateAntiForgeryToken]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;ActionResult&gt;&nbsp;Login(LoginViewModel&nbsp;model,&nbsp;string&nbsp;returnUrl)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;View(model);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;This&nbsp;doesn't&nbsp;count&nbsp;login&nbsp;failures&nbsp;towards&nbsp;account&nbsp;lockout&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;To&nbsp;enable&nbsp;password&nbsp;failures&nbsp;to&nbsp;trigger&nbsp;account&nbsp;lockout,&nbsp;change&nbsp;to&nbsp;shouldLockout:&nbsp;true&nbsp;&nbsp;</span><span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;await&nbsp;SignInManager.PasswordSignInAsync(model.UserName,&nbsp;model.Password,&nbsp;model.RememberMe,&nbsp;shouldLockout:&nbsp;false);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">switch</span>&nbsp;(result)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">case</span>&nbsp;SignInStatus.Success:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;RedirectToLocal(returnUrl);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;SignInStatus.LockedOut:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(<span class="js__string">&quot;Lockout&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;SignInStatus.RequiresVerification:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;RedirectToAction(<span class="js__string">&quot;SendCode&quot;</span>,&nbsp;<span class="js__operator">new</span><span class="js__brace">{</span>&nbsp;ReturnUrl&nbsp;=&nbsp;returnUrl,&nbsp;RememberMe&nbsp;=&nbsp;model.RememberMe&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;SignInStatus.Failure:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">default</span>:&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ModelState.AddModelError(<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;Invalid&nbsp;login&nbsp;attempt.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(model);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;GET:&nbsp;/Account/VerifyCode&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;ActionResult&gt;&nbsp;VerifyCode(string&nbsp;provider,&nbsp;string&nbsp;returnUrl,&nbsp;bool&nbsp;rememberMe)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Require&nbsp;that&nbsp;the&nbsp;user&nbsp;has&nbsp;already&nbsp;logged&nbsp;in&nbsp;via&nbsp;username/password&nbsp;or&nbsp;external&nbsp;login&nbsp;&nbsp;</span><span class="js__statement">if</span>&nbsp;(!await&nbsp;SignInManager.HasBeenVerifiedAsync())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;View(<span class="js__string">&quot;Error&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">return</span>&nbsp;View(<span class="js__operator">new</span>&nbsp;VerifyCodeViewModel&nbsp;<span class="js__brace">{</span>&nbsp;Provider&nbsp;=&nbsp;provider,&nbsp;ReturnUrl&nbsp;=&nbsp;returnUrl,&nbsp;RememberMe&nbsp;=&nbsp;rememberMe&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong style="font-size:1.5em">Authenticated and Authorized User page</strong></p>
<p><span>Here we create a new page for displaying message of Authenticated and Authorized user by their role.</span></p>
<p><span>If the logged in user role is Admin, then we will display the welcome message for Admin and display the menu forcreating new roles.</span></p>
<p><span>If the logged in users roles are Manager, Employee, Accounts, etc. then we will display a welcome message for them.</span></p>
<p>Firstly, create a new Empty Controller named &ldquo;<strong>userscontroller.cs</strong>&rdquo;. In this controller first we add the [Authorize] at the top of controller for checking the valid users.</p>
<p><span>Creating our View: Right click on index ActionResult and create a view .</span></p>
<p>In view we check for the ViewBag.<span>displayMenu</span>&nbsp;value. If the value is &ldquo;<strong>Yes</strong>&quot;, then we display the Admin welcome message and a link for creating new Menu. If the&nbsp;<strong>ViewBag.</strong><span><strong>displayMenu</strong>&nbsp;is
 &ldquo;<strong>No,&nbsp;</strong>then display other users name with welcome message.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&quot;Index&quot;;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
@if&nbsp;(ViewBag.displayMenu&nbsp;==&nbsp;&quot;Yes&quot;)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h1</span><span class="html__tag_start">&gt;</span>Welcome&nbsp;Admin.&nbsp;Now&nbsp;you&nbsp;can&nbsp;create&nbsp;user&nbsp;Role.<span class="html__tag_end">&lt;/h1&gt;</span><span class="html__tag_start">&lt;h3</span><span class="html__tag_start">&gt;&nbsp;</span><span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;@</span>Html.ActionLink(&quot;Manage&nbsp;Role&quot;,&nbsp;&quot;Index&quot;,&nbsp;&quot;Role&quot;)<span class="html__tag_end">&lt;/li&gt;</span><span class="html__tag_end">&lt;/h3&gt;</span>&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
else&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;Welcome&nbsp;<span class="html__tag_start">&lt;strong</span><span class="html__tag_start">&gt;@</span>ViewBag.Name<span class="html__tag_end">&lt;/strong&gt;</span>&nbsp;:)&nbsp;.We&nbsp;will&nbsp;add&nbsp;user&nbsp;module&nbsp;soon&nbsp;<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><strong>Controller part</strong></p>
<p><span>In controller we will check the user is logged in to the system or not. If the user did not log in, then</span></p>
<p>Display the message as &ldquo;<strong>Not Logged In</strong>&rdquo; and if the user is authenticated, then we check the logged in users role. If the users role is &ldquo;Admin&quot;, then we set&nbsp;<strong>ViewBag.displayMenu = &quot;Yes&quot;</strong>, else we set<strong>ViewBag.displayMenu
 = &quot;No&quot;</strong>.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(User.Identity.IsAuthenticated)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;User.Identity;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Name&nbsp;=&nbsp;user.Name;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.displayMenu&nbsp;=&nbsp;<span class="cs__string">&quot;No&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isAdminUser())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.displayMenu&nbsp;=&nbsp;<span class="cs__string">&quot;Yes&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Not&nbsp;Logged&nbsp;IN&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>For checking the user is logged in we create method and return the Boolean value to our main Index method.</span><span>&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;Boolean&nbsp;isAdminUser()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(User.Identity.IsAuthenticated)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;User.Identity;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ApplicationDbContext&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationDbContext();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;UserManager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UserManager&lt;ApplicationUser&gt;(<span class="cs__keyword">new</span>&nbsp;UserStore&lt;ApplicationUser&gt;(context));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;s&nbsp;=&nbsp;UserManager.GetRoles(user.GetUserId());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(s[<span class="cs__number">0</span>].ToString()&nbsp;==&nbsp;<span class="cs__string">&quot;Admin&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><strong style="font-size:1.5em">Admin users can create Roles</strong></p>
<p>We already saw that if the Admin user is logged in then we will display the link for creating new users. For admin login we have already created a default user with UserName as &quot;<strong>shanu</strong>&quot; and password as &quot;<strong>A@Z200711</strong>&quot;,</p>
<p><span><img id="147301" src="147301-1.gif" alt="" width="550" height="320"><br>
</span></p>
<p><span>For creating user role by admin first we will add a new empty controller and named it RoleController.cs,</span></p>
<p><span>In this controller we check that the user role is Admin. If the logged in user role is Admin, then we will get all the role names using&nbsp;</span><span>ApplicationDbContext</span>&nbsp;<span>object.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(User.Identity.IsAuthenticated)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!isAdminUser())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Roles&nbsp;=&nbsp;context.Roles.ToList();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(Roles);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>In view we bind all the user roles inside html table.</span><span>&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;IEnumerable<span class="html__tag_start">&lt;Microsoft</span>.AspNet.Identity.EntityFramework.IdentityRole<span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
@{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&quot;Add&nbsp;Role&quot;;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;table</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;&nbsp;background-color:#FFFFFF;&nbsp;border:&nbsp;dashed&nbsp;3px&nbsp;#6D7B8D;&nbsp;padding:&nbsp;5px;width:&nbsp;99%;table-layout:fixed;&quot;</span>&nbsp;<span class="html__attr_name">cellpadding</span>=<span class="html__attr_value">&quot;6&quot;</span>&nbsp;<span class="html__attr_name">cellspacing</span>=<span class="html__attr_value">&quot;6&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;height:&nbsp;30px;&nbsp;background-color:#336699&nbsp;;&nbsp;color:#FFFFFF&nbsp;;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;center&quot;</span>&nbsp;<span class="html__attr_name">colspan</span>=<span class="html__attr_value">&quot;2&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;&nbsp;</span>Create&nbsp;User&nbsp;Roles<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;tbrole&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;width:100%;&nbsp;border:dotted&nbsp;1px;&nbsp;background-color:gainsboro;&nbsp;padding-left:10px;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(var&nbsp;item&nbsp;in&nbsp;Model)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;width:100%;&nbsp;border:dotted&nbsp;1px;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@item.Name&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;right&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;color:#FFFFFF;padding-right:10;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h3</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;@Html.ActionLink(&quot;Click&nbsp;to&nbsp;Create&nbsp;New&nbsp;Role&quot;,&nbsp;&quot;Create&quot;,&nbsp;&quot;Role&quot;)&nbsp;<span class="html__tag_end">&lt;/h3&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<h1 class="scriptcode"><span style="font-size:2em">Source Code Files</span></h1>
<ul>
<li><em><em><span>shanuMVCUserRoles.zip</span>.</em></em> </li></ul>
<h1>More Information</h1>
<p><span>Firstly, create a sample AttendanceDB Database in your SQL Server. In the Web.Config file change the DefaultConnection connection string with your SQL Server Connections. In Startup.cs file I have created default Admin user with UserName &quot;</span><strong>shanu</strong><span>&quot;
 and password &quot;</span><strong>A@Z200711.&quot;&nbsp;</strong><span>This UserName and password will be used to login as Admin user. You can change this user name and password as you like. For security reason after log in as Admin you can change the Admin user password
 as you like,</span></p>
<p><em><img id="147316" src="147316-3.gif" alt="" width="550" height="300"><br>
</em></p>
