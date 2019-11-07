# ASP.NET - Connect to MySQL Azure Database
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- ASP.NET
- Entity Framework
- MySQL
## Topics
- C#
- ASP.NET
- Entity Framework
- MySQL
## Updated
- 10/03/2017
## Description

<p lang="en-US"><strong>Introduction</strong></p>
<p lang="en-US">Using MVC, Entity Framework, ASP.NET Scaffolding, and Azure MySQL you can create a web application that stores your information on an MongoDB Azure database. This demo shows you how to create a web application with MVC and Entity Framework 7,
 that communicate with a MySQL Azure database.</p>
<p>&nbsp;</p>
<p><strong>STEP 1 - Create Azure Account</strong></p>
<p lang="en-US">You need to get a Windows Azure account. Everyone can open a Windows Azure account for free.</p>
<p lang="en-US">Check the link below for more information.</p>
<p lang="en-US"><a href="http://www.windowsazure.com/en-us/pricing/free-trial/"><span>http://www.windowsazure.com/en-us/pricing/free-trial/</span></a></p>
<p lang="en-US"><span><br>
</span></p>
<p lang="en-US"><strong>STEP 2 - Create MySQL Database on Windows Azure</strong></p>
<p lang="en-US">After get access to an Azure Account, we need to create a MySQL Database to store your data.</p>
<p lang="en-US">So for that we need to select the option New on the left bottom of our web page and then select the option Data &#43; Storage -&gt; MySQL Database-&gt; Set the name and provide the configurations you need.</p>
<p lang="en-US"><img id="180287" src="180287-mysql_1.png" alt="" width="339" height="602">After created the Database, we need to get the connection string that will be used on Web Aplication to access the Azure Database.</p>
<p>For that, select the database created and on the main window, on the right side, we have an option called &quot;Show Connection String&quot;.</p>
<p>When we select that option, a new tabwill appear, like the following image, with the connection string formatted to different providers.</p>
<p><img id="180288" src="180288-mysql_2.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p><strong>STEP 3 - Create ASP.NET Web Application</strong></p>
<p><span lang="pt">Go to Visual Studio</span><span lang="en-US">&rsquo;</span><span lang="pt">s&nbsp;</span><span lang="en-US">File New Project&nbsp;menu, expand the&nbsp;Web&nbsp;category, and pick&nbsp;ASP.NET Web Application like on the image below</span></p>
<p><img id="180289" src="180289-mysql_3.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p><img id="180290" src="180290-mysql_4.png" alt="" width="600" height="400"></p>
<p>After selection of our template, your first web application using ASP.NET is created.</p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 4 - Create Data Model</strong></p>
<p lang="en-US">After we have our web application created, we need to ceate our data model.</p>
<p>For that, select the option Add New Item on solution and choose the option Class. Create the class like the one on the image above.&nbsp;</p>
<p lang="en-US"><img id="180291" src="180291-mysql_5.png" alt="" width="600" height="400"></p>
<p>We need to validate that EntityFramework anf MySQL.Data.Entity are installed like we saw on the image below</p>
<p lang="en-US"><img id="180292" src="180292-mysql_6.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p><strong>STEP 5 - Scaffolding</strong></p>
<p><span lang="pt">This could be made&nbsp;</span><span lang="en-US">easily</span><span lang="pt">&nbsp;using the Scaffolding functionality.</span></p>
<p>On the solution on the top of controller folder, select the option Add New Scaffold Item.</p>
<p>On the new screen, select the option MVC6 Controller with views using entity framework.</p>
<p><img id="180293" src="180293-mysql_7.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p>Select the name of the controller, class model and data context class.</p>
<p><img id="180294" src="180294-mysql_8.png" alt="" width="300" height="200"></p>
<p>The new controllers and views associated, was created with sucess.</p>
<p lang="en-US"><img id="180295" src="180295-mysql_9.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 6 - Change Connection String</strong></p>
<p lang="en-US"><img id="180296" src="180296-mysql_10.png" alt="" width="649" height="66"><img id="180297" src="180297-mysql_11.png" alt="" width="1222" height="213"></p>
<p lang="en-US"><strong>STEP 7 - Change Menu Layout</strong></p>
<p lang="en-US">To test the new entity created, we can add one new entries on the web application menu.</p>
<p><img id="180298" src="180298-mysql_12.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p><strong>STEP 8 - Run Application</strong></p>
<p>Press now the F5 button, to run the web application.</p>
<p>The new entities appear on the menu.</p>
<p><img id="180299" src="180299-mysql_13.png" alt="" width="600" height="400"></p>
<p>Press the option car to see our entity in action</p>
<p><img id="180300" src="180300-mysql_14.png" alt="" width="600" height="400"></p>
