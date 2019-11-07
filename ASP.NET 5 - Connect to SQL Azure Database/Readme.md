# ASP.NET 5 - Connect to SQL Azure Database
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL
- ASP.NET
- Azure
- Microsoft Azure
- ASP.NET MVC
- SQL Azure
- Microsoft Azure SQL Database
- ASP.NET5
## Topics
- C#
- SQL
- ASP.NET
- Azure
- Microsoft Azure
- ASP.NET MVC
- SQL Azure
- Microsoft Azure SQL Database
- ASP.NET5
## Updated
- 01/03/2016
## Description

<div>
<div>
<div>
<div>
<p lang="en-US"><strong>Introduction</strong></p>
<p lang="en-US">Using MVC, Entity Framework, ASP.NET5 Scaffolding, and Azure SQLServer you can create a web application that stores your information on an SQL Azure database. This demo shows you how to create a web application with MVC and Entity Framework
 7, that communicate with a SQL Azure database.</p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 1 - Create Azure Account</strong></p>
<p lang="en-US">You need to get a Windows Azure account. Everyone can open a Windows Azure account for free.</p>
<p lang="en-US">Check the link below for more information.</p>
<p lang="en-US"><a href="http://www.windowsazure.com/en-us/pricing/free-trial/">http://www.windowsazure.com/en-us/pricing/free-trial/
</a></p>
<p><img id="146758" src="146758-1.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 2 - Create SQL Database on Windows Azure</strong></p>
<p lang="en-US">After get access to an Azure Account, we need to create a SQL Database to store your data.</p>
<p lang="en-US">So for that we need to select the option New on the left bottom of our web page and then select the option Data &#43; Storage -&gt; SQL Database-&gt; Set the name and provide the configurations you need.</p>
<p lang="en-US">On this case our SQL Database will have the name &quot;SQLDemoAzure&quot;.</p>
<p><img id="146759" src="146759-2.png" alt="" width="600" height="400"></p>
<p lang="en-US">After created the SQL Database, we need to get the connection string that will be used on Web Aplication to access the Azure SQL Database.</p>
<p>For that, select the databse created and on the main window, on the right side, we have an option called &quot;Show Connection String&quot;.</p>
<p>When we select that option, a new tabwill appear, like the following image, with the connection string formatted to different providers.</p>
<p><img id="146760" src="146760-3.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 3 - Create ASP.NET 5 Web Application</strong></p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2015 and create a new project of type ASP.NET 5 Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called Demo.</span> </li></ul>
<p><img id="146203" src="146203-1.png" alt="" width="600" height="400">&nbsp;</p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p>&nbsp;</p>
<p><img id="146204" src="146204-2.png" alt="" width="600" height="400"></p>
<p>After selection of our template, your first web application using ASP.NET 5 is created.</p>
<p>&nbsp;<img id="146206" src="146206-3.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 4 - Create Data Model</strong></p>
<p lang="en-US">After we have our web application created, we need to ceate our data model.</p>
<p>For that, select the option Add New Item on solution and choose the option Class. Create the class like the one on the image above.&nbsp;</p>
<p><img id="146208" src="146208-4.png" alt="" width="600" height="400">&nbsp;</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 5 - Scaffolding</strong></p>
<p>&nbsp;</p>
<p><span lang="pt">This could be made </span><span lang="en-US">easily</span><span lang="pt"> using the Scaffolding functionality.</span></p>
<p>On the solution on the top of controller folder, select the option Add New Scaffold Item.</p>
<p>On the new screen, select the option MVC6 Controller with views using entity framework.</p>
<p><img id="146209" src="146209-5.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p>Select the name of the controller, class model and data context class.</p>
<p><img id="146210" src="146210-6.png" alt="" width="600" height="400">&nbsp;</p>
<p>The new controllers and views associated, was created with sucess.</p>
<p><img id="146211" src="146211-7.png" alt="" width="600" height="400">&nbsp;</p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 6 - Change Connection String</strong></p>
<p lang="en-US">For that just copy your database connection string, as explain on step1 and past into appsettings.json file.</p>
<p lang="en-US"><img id="146761" src="146761-10.png" alt="" width="600" height="400"></p>
<p lang="en-US"><span>&nbsp;</span></p>
<p lang="en-US"><strong>STEP 7 - Change Menu Layout</strong></p>
<p lang="en-US">To test the two tables, we can add two new entries on the web application menu.</p>
<p><img id="146213" src="146213-8.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p><strong>STEP 8 - Run Application</strong></p>
<p>Press now the F5 button, to run the web application.</p>
<p>The new entities appear on the menu.</p>
<p><img id="146216" src="146216-9.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p>Press the option car to see our entiity in action</p>
<p><img id="146762" src="146762-13.png" alt="" width="600" height="400"></p>
<p>Checking the database, you can see the table corresponding to the entity created and the data inserted.</p>
<p>&nbsp;<img id="146763" src="146763-14.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</div>
</div>
</div>
</div>
