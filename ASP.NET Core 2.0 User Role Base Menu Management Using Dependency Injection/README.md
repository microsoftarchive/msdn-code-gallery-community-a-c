# ASP.NET Core 2.0 User Role Base Menu Management Using Dependency Injection
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Identity
- ASP.NET Core
- ASP.NET Core 2.0
## Topics
- ASP.NET Identity
- ASP.NET Core 2.0
## Updated
- 04/03/2018
## Description

<h1>Introduction</h1>
<p><img id="197549" src="197549-aspdynamicmenu.gif" alt="" width="565" height="303"></p>
<p>Before we start this article kindly read our previous article,</p>
<ul>
<li><a href="https://code.msdn.microsoft.com/Getting-Started-With-e98e08b9" target="_blank">Getting Started With ASP.NET Core 2.0 Identity And Role Management</a>&nbsp;
</li></ul>
<p>In our previous article we have discussed in detail about how to use ASP.NET Core Identity in MVC Application for creating user roles and displaying the menu depending on user roles.</p>
<p>In this article we will see in detail how to display role-based dynamic menu after a user logs in. For this we will create a Menu Master table and insert a few records to display the menu and link the URL to the menu based on the logged in user's role.</p>
<p>Here we will see how to:</p>
<ul>
<li>Create default admin and manager users. </li><li>Create MenuMaster table and insert a few sample records for Admin and Manager roles to display menus.
</li><li>Redirect unauthenticated users to the login page.&nbsp; </li><li>Display menu dynamically based on logged in user. </li></ul>
<h1><span>Building the Sample</span></h1>
<h1><strong>Prerequisites<br>
</strong></h1>
<p>Make sure you have installed all the prerequisites in your computer. If not, then download and install all, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2017 from this&nbsp;<a href="https://www.visualstudio.com/" target="_blank">link</a>
</li><li>SQL Server 2014 or above </li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h1><strong>Step 1: Create a Database</strong></h1>
<p>This is in continuation of our previous article as we have told that, we will be using a Common Database for both ASP.NET Identity tables and for our own new tables</p>
<p>In our previous article we have explained about creating User Role, here for Role base Menu management we need to make a relationship table between ASP.NET Roles table and our menu table.</p>
<p>Let us see in detail about how to create our new Menu Table which has relationship with ASP.NET Identity AspNetRoles table.</p>
<p>Here we can see Field used for&nbsp;MenuMaster,</p>
<p><img id="197550" src="197550-0.png" alt="" width="445" height="648"></p>
<p>Firstly, we will create a Database and set the connection string in&nbsp;<strong>appsettings.json</strong>&nbsp;file for DefaultConnection with our new database connection. We will be using this database for ASP.NET Core Identity table creation.</p>
<p>Create Database: Run the following script to create our database MenuMaster table and sample Menu insert rows script.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;MASTER&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">1</span>)&nbsp;Check&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;<span class="js__operator">new</span>&nbsp;DB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.databases&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'AttendanceDB'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;DATABASE&nbsp;AttendanceDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;DATABASE&nbsp;AttendanceDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
USE&nbsp;AttendanceDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(&nbsp;SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.tables&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'MenuMaster'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;TABLE&nbsp;MenuMaster&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;MenuMaster&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MenuIdentity&nbsp;int&nbsp;identity(<span class="js__num">1</span>,<span class="js__num">1</span>),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MenuID&nbsp;VARCHAR(<span class="js__num">30</span>)&nbsp;&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MenuName&nbsp;VARCHAR(<span class="js__num">30</span>)&nbsp;&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;Parent_MenuID&nbsp;&nbsp;VARCHAR(<span class="js__num">30</span>)&nbsp;&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;User_Roll&nbsp;[varchar](<span class="js__num">256</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MenuFileName&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MenuURL&nbsp;VARCHAR(<span class="js__num">500</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;USE_YN&nbsp;Char(<span class="js__num">1</span>)&nbsp;DEFAULT&nbsp;<span class="js__string">'Y'</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;CreatedDate&nbsp;datetime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
CONSTRAINT&nbsp;[PK_MenuMaster]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;[MenuIdentity]&nbsp;ASC&nbsp;&nbsp;&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;[MenuID]&nbsp;ASC,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;[MenuName]&nbsp;ASC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
select&nbsp;*&nbsp;from&nbsp;MenuMaster&nbsp;&nbsp;&nbsp;
--&nbsp;Insert&nbsp;Admin&nbsp;User&nbsp;Details&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'AUSER'</span>,<span class="js__string">'ADMIN&nbsp;Dashboard'</span>,<span class="js__string">'*'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'ADMINC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;
&nbsp;Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'AAbout'</span>,<span class="js__string">'About&nbsp;Admin'</span>,<span class="js__string">'*'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'ADMINAC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'LStock'</span>,<span class="js__string">'Live&nbsp;Stock'</span>,<span class="js__string">'AUSER'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'StockC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'Profile'</span>,<span class="js__string">'User&nbsp;Details'</span>,<span class="js__string">'AUSER'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'MemberC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'MUSER'</span>,<span class="js__string">'Manager&nbsp;Dashboard'</span>,<span class="js__string">'*'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'ManagerC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;
&nbsp;Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'MAbout'</span>,<span class="js__string">'About&nbsp;Manager'</span>,<span class="js__string">'*'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'ManagerAC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'Accounts'</span>,<span class="js__string">'Account&nbsp;Details'</span>,<span class="js__string">'MUSER'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'AccountC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'Inventory'</span>,<span class="js__string">'Inventory&nbsp;Details'</span>,<span class="js__string">'MUSER'</span>,<span class="js__string">'ADMIN'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'InventoryC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;
&nbsp;
--&nbsp;Insert&nbsp;Manager&nbsp;User&nbsp;Details&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'MUSER'</span>,<span class="js__string">'Manager&nbsp;Dashboard'</span>,<span class="js__string">'*'</span>,<span class="js__string">'Manager'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'ManagerC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;
&nbsp;Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'MAbout'</span>,<span class="js__string">'About&nbsp;Manager'</span>,<span class="js__string">'*'</span>,<span class="js__string">'Manager'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'ManagerAC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'Accounts'</span>,<span class="js__string">'Account&nbsp;Details'</span>,<span class="js__string">'MUSER'</span>,<span class="js__string">'Manager'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'AccountC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;MenuMaster(MenuID&nbsp;,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Values(<span class="js__string">'Inventory'</span>,<span class="js__string">'Inventory&nbsp;Details'</span>,<span class="js__string">'MUSER'</span>,<span class="js__string">'Manager'</span>,<span class="js__string">'INDEX'</span>,<span class="js__string">'InventoryC'</span>,<span class="js__string">'Y'</span>,getDate())&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;
select&nbsp;*&nbsp;from&nbsp;MenuMaster&nbsp;&nbsp;
&nbsp;
select&nbsp;*&nbsp;from&nbsp;AspnetUserRoles&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Here we can see the format we are using in our Menu Master table to insert our records for display menu based on user role.</p>
<p>MenuID = 'AUSER' (We will give unique menu ID)</p>
<p>MenuName = 'ADMIN Dashboard' (We will give menu display text),</p>
<p>Parent_MenuID = '*&rsquo; (If this is main menu then we will give here as &ldquo;*&rdquo; else we will give the MenuID of previous records to display this record to show as submenu)</p>
<p>User_Roll = 'ADMIN' (Here we will give the User Role, if same menu need to be used for multiple roles based users like Admin, Manager, Accountant and etc. then we will insert the same menu details with different user roles. In our sample we have added the
 same menu details as 'Manager Dashboard' for both Admin and Manager User as both can view the menu and page.)</p>
<p>,MenuFileName = 'INDEX' (Here we give our View name to be displayed when the menu is clicked)</p>
<p>MenuURL = 'ADMINC' (Here we give our Controller name to be displayed when the menu is clicked)</p>
<p>USE_YN = 'Y' (This is optional field as we can use this as to display menu or not)</p>
<p>CreatedDate = getDate() &nbsp;(This also optional as to input the Crete date)&nbsp;</p>
<p>In this demo application we have already all the needed controllers and view to be displayed when user click on menu</p>
<h1>Step 2: <strong>Create your ASP.NET Core&nbsp; </strong></h1>
<p><strong>&nbsp;</strong>After installing our Visual Studio 2017 click Start, then Programs and select&nbsp;<strong>Visual Studio 2017</strong>&nbsp;- Click&nbsp;<strong>Visual Studio 2017</strong>. Click New, then Project, select Web and then select&nbsp;<strong>ASP.NET
 Core Web Application</strong>. Enter your project name and click&nbsp;</p>
<p><img id="197551" src="197551-1.png" alt="" width="414" height="271"></p>
<p>Select Web Application(Model-View-Controller) and click on the Change Authentication</p>
<p>&nbsp;</p>
<p><img id="197552" src="197552-2.png" alt="" width="487" height="314"></p>
<p>Select Individual User Accounts and click ok to create your project.</p>
<p><img id="197553" src="197553-3.png" alt="" width="462" height="318"></p>
<h2><strong>Updating appsettings.json</strong>&nbsp;</h2>
<p>In <strong>appsettings.json</strong>&nbsp; file we can find the&nbsp;DefaultConnection&nbsp;Connection string.Here in connection string change your SQL Server Name, UID and PWD to create and store all user details in one database.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js"><span class="js__string">&quot;ConnectionStrings&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;DefaultConnection&quot;</span>:&nbsp;<span class="js__string">&quot;Server=&nbsp;YOURSERVERNAME;Database=InventoryDB;user&nbsp;id=&nbsp;YOURSQLUSERID;password=YOURSQLPASSWORD;Trusted_Connection=True;MultipleActiveResultSets=true&quot;</span><span class="js__brace">}</span>,&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><strong>Step 3: Add Identity Service in Startup.cs file</strong></h1>
<p>By default, in your ASP.NET Core application the Identity Service will be added in Startup.cs File /ConfigureServices method. You can also additionally add the password strength while user the register and also set the default login page/logout page and
 also AccessDenaiedPath by using the fallowing code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">services.AddIdentity&lt;ApplicationUser,&nbsp;IdentityRole&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AddEntityFrameworkStores&lt;ApplicationDbContext&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AddDefaultTokenProviders();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Password&nbsp;Strength&nbsp;Setting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.Configure&lt;IdentityOptions&gt;(options&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Password&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireDigit&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequiredLength&nbsp;=&nbsp;<span class="js__num">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireNonAlphanumeric&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireUppercase&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireLowercase&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequiredUniqueChars&nbsp;=&nbsp;<span class="js__num">6</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Lockout&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Lockout.DefaultLockoutTimeSpan&nbsp;=&nbsp;TimeSpan.FromMinutes(<span class="js__num">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Lockout.MaxFailedAccessAttempts&nbsp;=&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Lockout.AllowedForNewUsers&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;User&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.User.RequireUniqueEmail&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Seting&nbsp;the&nbsp;Account&nbsp;Login&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.ConfigureApplicationCookie(options&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Cookie&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Cookie.HttpOnly&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.ExpireTimeSpan&nbsp;=&nbsp;TimeSpan.FromMinutes(<span class="js__num">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.LoginPath&nbsp;=&nbsp;<span class="js__string">&quot;/Account/Login&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;If&nbsp;the&nbsp;LoginPath&nbsp;is&nbsp;not&nbsp;set&nbsp;here,&nbsp;ASP.NET&nbsp;Core&nbsp;will&nbsp;default&nbsp;to&nbsp;/Account/Login</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.LogoutPath&nbsp;=&nbsp;<span class="js__string">&quot;/Account/Logout&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;If&nbsp;the&nbsp;LogoutPath&nbsp;is&nbsp;not&nbsp;set&nbsp;here,&nbsp;ASP.NET&nbsp;Core&nbsp;will&nbsp;default&nbsp;to&nbsp;/Account/Logout</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.AccessDeniedPath&nbsp;=&nbsp;<span class="js__string">&quot;/Account/AccessDenied&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;If&nbsp;the&nbsp;AccessDeniedPath&nbsp;is&nbsp;not&nbsp;set&nbsp;here,&nbsp;ASP.NET&nbsp;Core&nbsp;will&nbsp;default&nbsp;to&nbsp;/Account/AccessDenied</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.SlidingExpiration&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><strong>Step 4: Register and Create Users</strong></h1>
<p>Now our Asp.NET Core web application is ready for user to register in our website and also user can login to our system after registration. We will be doing the Authorization by adding role to user in next steps. Build and run your application to register
 your first default Admin user.</p>
<p><img id="197554" src="197554-4.png" alt="" width="553" height="197"></p>
<p>Here we will be registering two users as one for Admin and another user for Manager. We will be using this users for adding roles. We will create 2 users as
<a href="mailto:syedshanumcain@gmail.com">syedshanumcain@gmail.com</a> and <a href="mailto:afraz@gmail.com">
afraz@gmail.com</a> . Note: You can create users as per your need and change the user details in startup code for adding roles to users.</p>
<p><img id="197555" src="197555-5.png" alt="" width="564" height="317"></p>
<h2><strong>Refresh the Database:</strong></h2>
<p>When we refresh our database, we can see all the Identity tables has been created.</p>
<p><img id="197556" src="197556-6.png" alt="" width="228" height="259"></p>
<h1><strong>Step 5: Create Role and assign User for Role</strong></h1>
<p>We use the below method to create a new Role&rsquo;s as &ldquo;Admin&rdquo; and &ldquo;Manager&rdquo; , we will assign the recently registered users as &ldquo;Admin&rdquo; &nbsp;and&nbsp; &ldquo;Manager&rdquo; to our website. Open Startup.cs file and add
 this method in your Startup.cs file.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;async&nbsp;Task&nbsp;CreateUserRoles(IServiceProvider&nbsp;serviceProvider)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;RoleManager&nbsp;=&nbsp;serviceProvider.GetRequiredService&lt;RoleManager&lt;IdentityRole&gt;&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;UserManager&nbsp;=&nbsp;serviceProvider.GetRequiredService&lt;UserManager&lt;ApplicationUser&gt;&gt;();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IdentityResult&nbsp;roleResult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Adding&nbsp;Addmin&nbsp;Role&nbsp;&nbsp;</span><span class="js__statement">var</span>&nbsp;roleCheck&nbsp;=&nbsp;await&nbsp;RoleManager.RoleExistsAsync(<span class="js__string">&quot;Admin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!roleCheck)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//create&nbsp;the&nbsp;roles&nbsp;and&nbsp;seed&nbsp;them&nbsp;to&nbsp;the&nbsp;database&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleResult&nbsp;=&nbsp;await&nbsp;RoleManager.CreateAsync(<span class="js__operator">new</span>&nbsp;IdentityRole(<span class="js__string">&quot;Admin&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleCheck&nbsp;=&nbsp;await&nbsp;RoleManager.RoleExistsAsync(<span class="js__string">&quot;Manager&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!roleCheck)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//create&nbsp;the&nbsp;roles&nbsp;and&nbsp;seed&nbsp;them&nbsp;to&nbsp;the&nbsp;database&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleResult&nbsp;=&nbsp;await&nbsp;RoleManager.CreateAsync(<span class="js__operator">new</span>&nbsp;IdentityRole(<span class="js__string">&quot;Manager&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//Assign&nbsp;Admin&nbsp;role&nbsp;to&nbsp;the&nbsp;main&nbsp;User&nbsp;here&nbsp;we&nbsp;have&nbsp;given&nbsp;our&nbsp;newly&nbsp;loregistered&nbsp;login&nbsp;id&nbsp;for&nbsp;Admin&nbsp;management&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ApplicationUser&nbsp;user&nbsp;=&nbsp;await&nbsp;UserManager.FindByEmailAsync(<span class="js__string">&quot;syedshanumcain@gmail.com&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;User&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ApplicationUser();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;UserManager.AddToRoleAsync(user,&nbsp;<span class="js__string">&quot;Admin&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;=&nbsp;await&nbsp;UserManager.FindByEmailAsync(<span class="js__string">&quot;Afraz@gmail.com&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;UserManager.AddToRoleAsync(user,&nbsp;<span class="js__string">&quot;Manager&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>From Startup.cs file we can find the Configure method. Call our CreateUserRoles method from this Configure method. When we build and run our application we can see new Role as &ldquo;Admin&rdquo; and &ldquo;Manager&rdquo; will be created in ASPNetRole table.&nbsp;&nbsp;</p>
<h1><strong>Step 6: Create Admin/Manager Page and Set Authorization</strong></h1>
<p>Now we have a Admin/Manager user for our ASP.NET Core web application as a next step lets create Controllers and views to display based on user login, In our previous example we have already seen on how to set Authorization for roles in each page, Using
 that we will be creating all our need Controllers and Views.IN the attached sample demo application you can found all the controllers and views which we have created and create your own as per your need.&nbsp;&nbsp;</p>
<h1><strong>&nbsp;Step 7: Working with Dependency Injection&nbsp;</strong></h1>
<h2><strong>Creating Model Class</strong></h2>
<p>First, we will start with creating a class in our Model folder. We give the class name as MenuMaster as same as our table name in our Database. In MenuMaster class, we need to create properties same like our Table fields like below.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;MenuMaster&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;MenuIdentity&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;MenuID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;MenuName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Parent_MenuID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;User_Roll&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;MenuFileName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;MenuURL&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;USE_YN&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DateTime&nbsp;CreatedDate&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>Creating Interface Class</strong></h2>
<p>Now, it&rsquo;s time for us to create an interface with method named GetMenuMaster() , GetMenuMaster(String UserRole) and we will be implementing this interface in our Service to get all the Menu details from the table and also another method to get menu
 by user role. For creating the Interface, add a new class to your model folder and name the class as &ldquo;IMenuMasterService&rdquo;.</p>
<p>We will change the class to an interface as we are going to create an interface to implement in our service. &nbsp;&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IMenuMasterService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;MenuMaster&gt;&nbsp;GetMenuMaster();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;MenuMaster&gt;&nbsp;GetMenuMaster(<span class="js__object">String</span>&nbsp;UserRole);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>Creating Service:</strong></h2>
<p>Now, let&rsquo;s add a new class Services folder and name the class as &ldquo;MenuMasterService&rdquo;. In this class, we will be implementing our interface IMenuMasterService. We know that if we implement the interface, then we should declare the interface
 method in our class. In this service, we use the interface method and we return the list with Menu details and also return the Menu details by user role. We will be directly Injecting this on our View page.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;MenuMasterService:IMenuMasterService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;readonly&nbsp;ApplicationDbContext&nbsp;_dbContext;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MenuMasterService(ApplicationDbContext&nbsp;dbContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbContext&nbsp;=&nbsp;dbContext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;MenuMaster&gt;&nbsp;GetMenuMaster()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;_dbContext.MenuMaster.AsEnumerable();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;MenuMaster&gt;&nbsp;GetMenuMaster(string&nbsp;UserRole)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;_dbContext.MenuMaster.Where(m&nbsp;=&gt;&nbsp;m.User_Roll&nbsp;==&nbsp;UserRole).ToList();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>Register the Service</strong></h2>
<p>We need to register our created service to the container. Open the Startup.cs from your project to add the service to the container.</p>
<p>In the Startup.cs class, find the method named as ConfigureServices and add your service &ldquo;MenuMasterService&rdquo; like below.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">services.AddTransient&lt;MenuMasterService,&nbsp;MenuMasterService&gt;();</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;<strong style="font-size:1.5em">Inject the Service in the _Layout.cshtml page</strong></h2>
<div class="endscriptcode">&nbsp;Now, it&rsquo;s much simpler and easier as we can directly Inject the service in our View page and bind all the result to our view page. For injecting the Service in our View, here we will be using our existing _Layout.cshtml
 page. Since we are going to display the menu in top of our website an use in all our pages,here we have used the _Layout.cshtml page to bind the menu results as menu based on user logged in.</div>
<p>&nbsp;</p>
<p>Here first we check the user is Authenticated to our website then if the user is logged in then we get the role details of the logged in user and bind the menu based on the user roles. Here we are binding 2 level of menu as Main Menu and Submenu. In our
 table result we check for all the Parenut_MenuID=&rdquo; *&rdquo; as we will be displaying the main menu with the parent_MenuID as &ldquo;*&rdquo; and in next inner loop we display the submenu appropriate to the main menu.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;class=<span class="js__string">&quot;navbar-collapse&nbsp;collapse&quot;</span>&gt;&nbsp;
&nbsp;&lt;ul&nbsp;class=<span class="js__string">&quot;nav&nbsp;navbar-nav&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;li&gt;&lt;a&nbsp;asp-area=<span class="js__string">&quot;&quot;</span>&nbsp;asp-controller=<span class="js__string">&quot;Home&quot;</span>&nbsp;asp-action=<span class="js__string">&quot;Index&quot;</span>&gt;Home&lt;<span class="js__reg_exp">/a&gt;&lt;/</span>li&gt;&nbsp;
&nbsp;@<span class="js__statement">if</span>&nbsp;(User.Identity.IsAuthenticated)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;UserRoles&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(@User.IsInRole(<span class="js__string">&quot;Admin&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserRoles&nbsp;=&nbsp;<span class="js__string">&quot;Admin&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserRoles&nbsp;=&nbsp;<span class="js__string">&quot;Manager&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__statement">if</span>&nbsp;(menus.GetMenuMaster(@UserRoles).Any())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__statement">if</span>&nbsp;(menus.GetMenuMaster(@UserRoles).Any())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(<span class="js__statement">var</span>&nbsp;menuNames&nbsp;<span class="js__operator">in</span>&nbsp;menus.GetMenuMaster(@UserRoles).Where(n&nbsp;=&gt;&nbsp;n.Parent_MenuID&nbsp;==&nbsp;<span class="js__string">&quot;*&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a&nbsp;asp-area=<span class="js__string">&quot;&quot;</span>&nbsp;asp-controller=@menuNames.MenuURL&nbsp;asp-action=@menuNames.MenuFileName&gt;@menuNames.MenuName&lt;/a&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&nbsp;class=<span class="js__string">&quot;sub-menu&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(<span class="js__statement">var</span>&nbsp;subMenu&nbsp;<span class="js__operator">in</span>&nbsp;menus.GetMenuMaster(@UserRoles).Where(n&nbsp;=&gt;&nbsp;n.Parent_MenuID&nbsp;==&nbsp;@menuNames.MenuID))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a&nbsp;asp-area=<span class="js__string">&quot;&quot;</span>&nbsp;asp-controller=@subMenu.MenuURL&nbsp;asp-action=@subMenu.MenuFileName&gt;@subMenu.MenuName&lt;/a&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="197557" src="197557-animation_1.gif" alt="" width="656" height="343"></div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ASPNETCORERoleManagement -&nbsp; 2018-04-03&nbsp;</em> </li></ul>
<h1>More Information</h1>
<p>Firstly, create a sample AttendanceDB Database in your SQL Server and run the script to create MenuMaster table and insert sample records. In the appsettings.json&nbsp; file change the DefaultConnection connection string with your SQL Server Connections.
 In Startup.cs file add all the code as we discussed in this article. This is simple demo application and we have fixed with Admin and Manager roles, you can change as per your requirement and also the CSS design for menu and sub menu is not good for Mobile
 compatibility you can add your own bootstrap design to implement your menu style. Hope you all like this article and soon we will see in another article with more live examples.</p>
