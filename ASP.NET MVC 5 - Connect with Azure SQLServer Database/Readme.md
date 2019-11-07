# ASP.NET MVC 5 - Connect with Azure SQLServer Database
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Microsoft Azure
- ASP.NET MVC
- SQL Azure
- ASP.NET MVC 5
- MVC5
## Topics
- C#
- Microsoft Azure
- ASP.NET MVC
- SQL Azure
## Updated
- 04/23/2014
## Description

<p lang="en-US"><span style="font-size:small"><strong>Introduction</strong></span></p>
<p lang="en-US">Using MVC, Entity Framework, ASP.NET Scaffolding, and Azure SQLServer you can create a web application that stores your information on an SQL Azure database. This demo shows you how to create a web application with MVC and Entity Framework 6,
 that communicate with a SQL Azure database.</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 1 - Create Azure Account</strong></span></p>
<p lang="en-US">You need to get a Windows Azure account. Everyone can open a Windows Azure account for free.</p>
<p lang="en-US">Check the link below for more information.</p>
<p lang="en-US"><a href="http://www.windowsazure.com/en-us/pricing/free-trial/">http://www.windowsazure.com/en-us/pricing/free-trial/
</a></p>
<p>&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 2 - Create SQL Database on Windows Azure</strong></span></p>
<p lang="en-US">After get access to an Azure Account, we need to create a SQL Database to store your data.</p>
<p lang="en-US">So for that we need to select the option New on the left bottom of our web page and then select the option Data Services -&gt; SQL Database-&gt; Quick Create and give a name to your SQL Database and provide credentials.</p>
<p lang="en-US">On this case our SQL Database will have the name &quot;MVCDemo&quot;.</p>
<p><img id="113355" src="113355-1.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p lang="en-US"><img id="113356" src="113356-2.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p lang="en-US">After created the SQL Database, we need to get the connection string that will be used on Web Aplication to access the Azure SQL Database.</p>
<p>For that, select the databse cretaed and on the main window, on the right side, we have an option called &quot;Show Connection String&quot;.</p>
<p>When we select that option, a new window will appear, like the following image, with the connection string formatted to different providers.</p>
<p><img id="113357" src="113357-3.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 3 - Create ASP.NET Web Application</span></strong></p>
<p lang="en-US">I will be using Visual Studio 2013 as my development environment. Our first step will be to create an ASP.NET Web Application.</p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2013 and create a new project of type ASP.NET Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called MVCDemoAzureSQLServer.</span>
</li></ul>
<p><span style="white-space:pre"><img id="113358" src="113358-4.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">
</span>&nbsp;&nbsp;</p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p><img id="113359" src="113359-5.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>STEP 4 - Create Data Model</strong></span></p>
<p lang="en-US">After we have our web application created, we need to ceate our data model.</p>
<p>For that, select the option Add New Item on solution and choose the option ADO.NET Entity Data Model.</p>
<p>On this sample, we call it DataModel.edmx.</p>
<p><img id="113360" src="113360-6.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p>After we select this component, a configuration wizard will appear.</p>
<p>On the first screen, we need to choose model contents. Two options will be available:</p>
<ol type="1">
<li><span>Generate from database </span></li><li><span>Empty Model</span> </li></ol>
<p><img id="113361" src="113361-7.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p><span>By selecting&nbsp;</span><span>Generate from database</span><span>, you can generate an .edmx file from an existing database. In the next steps, the Entity Data Model Wizard will guide you through selecting a data source, database, and database objects
 to include in the conceptual model.</span></p>
<p><span>By selecting&nbsp;</span><span>Empty model</span><span>, you can add an .edmx file that contains empty conceptual model, storage model, and mapping sections to your project. Select this option if you plan to use the Entity Designer to build your conceptual
 model and later generate a database that supports the model. </span></p>
<p><span>On this sample, we select the first one.</span></p>
<p><img id="113362" src="113362-8.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p>On the next screen, we need to select the Data Connection.</p>
<p>Select the option New Connection and paste the information existent on STEP2 to ADO.NET provider.</p>
<p>The database will be filled with the name of our Azure SQL Database.</p>
<p>On this moment we have our empty .edmx file created with the correct connection string to our Azure SQL Database.</p>
<p>So, lets add some entities to our model.</p>
<p>On the DataModel.edmx diagram select the option Add New -&gt; Entity</p>
<p><img id="113363" src="113363-9.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p>Create two entities like the existent on the next image.</p>
<p><img id="113364" src="113364-10.png" alt="" width="498" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p>Select the option Generate Dabase from Model.</p>
<p>This option, will generate a SQL script. Execute the script in your sql database.</p>
<p><img id="113365" src="113365-11.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p>Right now, we have our Azure SQL Database created, and our web application with the connection to it.</p>
<p>Lets create our web application controllers and views.</p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 5 - Scaffolding</span></strong></p>
<p><span lang="pt">This could be made </span><span lang="en-US">easily</span><span lang="pt"> using the Scaffolding functionality.</span></p>
<p>On the solution, select the option Add New Scaffolded Item like on the image below.</p>
<p><img id="113366" src="113366-12.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p>On the new screen, select the option MVC5 Controller with views using entity framework.</p>
<p><img id="113367" src="113367-13.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p>Select the name of the controller, class model and data context class.</p>
<p><img id="113368" src="113368-14.png" alt="" width="600" height="425" style="display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p>Do the same to the other entity (Model)</p>
<p>The two new controllers and views associated, were created with sucess.</p>
<p><img id="113369" src="113369-15.png" alt="" width="287" height="526" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 6 - Change Menu Layout</span></strong></p>
<p lang="en-US">To test the two tables, we can add two new entries on the web application menu.</p>
<p><img id="113370" src="113370-16.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 7 - Run Application</span></strong></p>
<p>Press now the F5 button, to run the web application.</p>
<p>The new entities appear on the menu.</p>
<p><img id="113371" src="113371-17.png" alt="" width="600" height="400" style="vertical-align:middle; display:block; margin-left:auto; margin-right:auto">Select the first one and add, new brands.</p>
<p><img id="113372" src="113372-18.png" alt="" width="600" height="400" style="vertical-align:middle"></p>
<p>Select the second one, and check that the brands created, appear on the create view, to associate model to a existent car.</p>
<p><img id="113374" src="113374-19.png" alt="" width="570" height="440" style="display:block; margin-left:auto; margin-right:auto"></p>
