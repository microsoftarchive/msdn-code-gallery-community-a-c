# ASP.NET 5 - Create Web Application Step by Step
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Code First
- MVC
- MVC 6
- ASP.NET 5
- vNext
- EF
- EF 7
## Topics
- C#
- Code First
- MVC
- MVC 6
- ASP.NET 5
- vNext
- EF
- EF 7
## Updated
- 12/17/2015
## Description

<div>
<div>
<p lang="en-US"><strong>Introduction</strong></p>
<p lang="en-US">Using MVC, Entity Framework, ASP.NET Scaffolding you can create a web application that stores your information. This demo shows you how to create a ASP.NET 5 web application with MVC and Entity Framework 7.</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong>STEP 1 - Create ASP.NET 5 Web Application</strong></p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2015 and create a new project of type ASP.NET 5 Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called Demo.</span> </li></ul>
<p><img id="146203" src="146203-1.png" alt="" width="600" height="400"></p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option MVC.</span> </li></ul>
<p><img id="146204" src="146204-2.png" alt="" width="600" height="400"></p>
<p>After selection of our template, your first web application using ASP.NET 5 is created.</p>
<p><img id="146206" src="146206-3.png" alt="" width="600" height="400">&nbsp;</p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 2 - Create Data Model</strong></p>
<p lang="en-US">After we have our web application created, we need to ceate our data model.</p>
<p>For that, select the option Add New Item on solution and choose the option Class. Create the class like the one on the image above.</p>
<p><img id="146208" src="146208-4.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 3 - Scaffolding</strong></p>
<p><span lang="pt">This could be made </span><span lang="en-US">easily</span><span lang="pt"> using the Scaffolding functionality.</span></p>
<p>On the solution on the top of controller folder, select the option Add New Scaffold Item.</p>
<p>&nbsp;</p>
<p>On the new screen, select the option MVC6 Controller with views using entity framework.</p>
<p><img id="146209" src="146209-5.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p>Select the name of the controller, class model and data context class.</p>
<p><img id="146210" src="146210-6.png" alt="" width="600" height="400">&nbsp;</p>
<p>The new controllers and views associated, was created with sucess.</p>
<p><img id="146211" src="146211-7.png" alt="" width="600" height="400">&nbsp;</p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 4 - Change Menu Layout</strong></p>
<p lang="en-US">To test the two tables, we can add two new entries on the web application menu.</p>
<p><img id="146213" src="146213-8.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong>STEP 5 - Run Application</strong></p>
<p>Press now the F5 button, to run the web application.</p>
<p>The new entities appear on the menu.</p>
<p><img id="146216" src="146216-9.png" alt="" width="600" height="400">&nbsp;</p>
<p>Press the option car to see our entiity in action</p>
<p>An message error will appear sayng that the entity doesn't exists on internal database and that we need to create it using some commands on package manager console.</p>
<p><img id="146218" src="146218-10.png" alt="" width="600" height="290">&nbsp;</p>
<p>Execute the commands like on the image above na try again</p>
<p><img id="146219" src="146219-11.png" alt="" width="600" height="400"></p>
<p>An thats it! Now its working</p>
<p><img id="146220" src="146220-12.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
</div>
</div>
