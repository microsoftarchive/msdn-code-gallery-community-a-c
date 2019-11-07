# ASP.NET Core MVC:  Authentication and Role Based  Authorisation  with Identity
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET
- ASP.NET Identity
- ASP.NET Core
- ASP.NET Core MVC
- ASP.NET Core 1.1
## Topics
- Authentication
- ASP.NET Identity
- Role-based Authorisation
- ASP.NET Core Identity
## Updated
- 01/16/2017
## Description

<h1>Introduction</h1>
<p>A Visual Studio 2015 project which shows how to implement authentication and role based authorization with ASP.NET identity in the ASP.NET Core MVC application.</p>
<p>The code illustrates the following topics:</p>
<ol>
<li>Listings, create, update and delete application roles. </li><li>Listings, create, update and delete application users. </li><li>Assign and update an application role to the application user. </li><li>Login and Logout functionality. </li><li>Role-based authorization. </li><li>Access denied implemented for unauthorized users. </li><li>Remember me for the authenticate user. </li><li>Show username of the authenticated user. </li><li>Custom application user and role classes. </li></ol>
<h1>Getting Started</h1>
<p>To build and run this sample as-is, you must have Visual Studio 2015 installed. In most cases you can run the application by following these steps:</p>
<ol>
<li>Download and extract the .zip file. </li><li>Open the solution file in Visual Studio. </li><li>Change connection string in the appsettings.json file of the web application.
</li><li>Run the following command for migration and create database.
<ul>
<li>Tools &ndash;&gt; NuGet Package Manager &ndash;&gt; Package Manager Console </li><li>PM&gt; Add-Migration MyFirstMigration </li><li>PM&gt; Update-Database </li></ul>
</li><li>Run the application. </li></ol>
<h1>Running the Sample</h1>
<p>To run the sample, hit F5 or choose the Debug | Start Debugging menu command. You will see the role list screen. From this screen you have role listing screen as shown in below figure. There are also top menu for the &lsquo;Role&rsquo; when clicks on that
 then same screen opens.</p>
<p><img id="168089" src="168089-1.png" alt="" width="476" height="316"></p>
<div>Figure 1: Role listing</div>
<p>Now click on &ldquo;Add Role&rdquo; button to add new application role in the application as per following screen.</p>
<p><img id="168090" src="168090-2.png" alt="" width="726" height="317"></p>
<div>Figure 2: Add Application Role</div>
<p>As per figure 1, Delete button uses to delete individual application role as per following figure.</p>
<p><img id="168091" src="168091-4.png" alt="" width="477" height="369"></p>
<div>Figure 3: Delete Application Role</div>
<p>Now clicks on User menu on the top and shows the application users listing as shown in below figure.</p>
<p><img id="168092" src="168092-5.png" alt="" width="426" height="271"></p>
<div>Figure 4: Application User Listing</div>
<p>Now click on &ldquo;Add User&rdquo; button to add new application user in the application as per following screen.</p>
<p><img id="168093" src="168093-6.png" alt="" width="734" height="482"></p>
<div>Figure 5: Add Application User</div>
<p>As per figure 4, Edit button uses to edit individual application user as per following figure.</p>
<p><img id="168094" src="168094-7.png" alt="" width="727" height="320"></p>
<div>Figure 6: Edit Application User</div>
<p>As per figure 4, Delete button uses to delete individual application role as per following figure.</p>
<p><img id="168095" src="168095-8.png" alt="" width="426" height="326"></p>
<div>Figure 7: Delete Application User</div>
<p>Now click on Log In menu button on top the right corner and login with following screen.</p>
<p><img id="168096" src="168096-9.png" alt="" width="460" height="340"></p>
<div>Figure 8: User Login Screen</div>
<p>Clicks on &lsquo;Log In&rsquo; button as role based show following screen.The authenticate user must have 'User' role to access this screen.</p>
<p><img id="168097" src="168097-10.png" alt="" width="749" height="167"></p>
<div>Figure 9: Welcome Screen After Authorisation</div>
<p>If authenticate user is not authorised then shown following screen.</p>
<p><img id="168098" src="168098-11.png" alt="" width="450" height="205"></p>
<div>Figure 10: UnAuthorised Screen</div>
<h1>Source Code Overview</h1>
<p>Most of folders play same role as in MVC application but there are following more folder and files.</p>
<ol>
<li>wwwroot: It holds static js and css files. </li><li>appsettings.json:It holds database connection string. </li><li>Migrations: It holds database migration files. </li><li>ApplicationUser: Custom identity User Class. </li><li>ApplicationRole: Custome Identity Role Class. </li></ol>
