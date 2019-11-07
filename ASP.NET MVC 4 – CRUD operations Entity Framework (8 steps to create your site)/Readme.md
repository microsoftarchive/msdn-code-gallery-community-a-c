# ASP.NET MVC 4 – CRUD operations Entity Framework (8 steps to create your site)
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ADO.NET Entity Framework
- ASP.NET
- .NET Framework
- ASP.NET MVC 4
- Entity Framework 5
## Topics
- Controls
- C#
- Data Binding
- ADO.NET Entity Framework
- User Interface
- Data Access
- ASP.NET MVC
- Entity Framework
## Updated
- 02/01/2014
## Description

<p><span style="font-size:medium"><strong>MVC4 &ndash; Entity Framework</strong></span><br>
<br>
<span style="font-size:medium"><strong>8 Steps to create your site</strong></span></p>
<div><br>
Jo&atilde;o Sousa</div>
<p>&nbsp;</p>
<h1>STEP1</h1>
<p>Create a new project of type ASP.NET MVC 4 Web Application&nbsp;&nbsp;</p>
<p><img id="96426" src="96426-picture1.png" alt="" width="942" height="562"></p>
<p>Choose the option Internet Application</p>
<p><img id="96427" src="96427-picture2.png" alt="" width="675" height="590"></p>
<p><br>
After project creation, it look like this:</p>
<p>&nbsp;<img id="96429" src="96429-picture3.png" alt="" width="1117" height="621"></p>
<p><br>
<br>
</p>
<h1>STEP2</h1>
<p>Add new items of type ADO.NET Entity Data Model to the solution.</p>
<p>Name it to Model.edmx</p>
<p>&nbsp;<img id="96430" src="96430-picture4.png" alt="" width="950" height="566"></p>
<p><br>
<br>
</p>
<h1>STEP3</h1>
<p>Open the Model.edmx, with double click on the top of the file and create the data structure.</p>
<p><img id="96432" src="96432-picture5.png" alt="" width="640" height="441"></p>
<p>&nbsp;</p>
<p>On this sample, we have two entities (Clients and Contacts).</p>
<p>After save this model, two new classes will be generated (Clients.cs and Contacts.cs)</p>
<p>&nbsp;</p>
<p><strong>Clients:</strong></p>
<p>&nbsp;<img id="96433" src="96433-picture6.png" alt="" width="807" height="482"></p>
<p><strong>Contacts:</strong></p>
<p><img id="96434" src="96434-picture7.png" alt="" width="683" height="379"></p>
<p>&nbsp;</p>
<h1>STEP4</h1>
<p>On the package manager console, execute the follow command.</p>
<p><strong>Install-package mvcscaffolding</strong></p>
<p><a href="http://www.nuget.org/packages/MVCScaffolding/">http://www.nuget.org/packages/MVCScaffolding/</a><strong>&nbsp;</strong></p>
<p><br>
<img id="96435" src="96435-picture8.png" alt="" width="1300" height="313"></p>
<h1>STEP5</h1>
<p>Now we can scaffold a controller and a set of Create, Read, Update and Delete (CRUD) views. In the Package Management console run the following command.</p>
<p><strong>Scaffold controller ClientsController &ndash;force &ndash;DBContextType &ldquo;ModelContainer&rdquo;</strong></p>
<p><strong>Scaffold controller ContactsController &ndash;force &ndash;DBContextType &ldquo;ModelContainer&rdquo;</strong></p>
<p>This will generate a set of views, a controller and an Entity Framework database context.</p>
<p><img id="96436" src="96436-picture9.png" alt="" width="1303" height="381"></p>
<p>&nbsp;</p>
<p>On the next image, you can see the files created by the command executed.</p>
<p>The repositories, controllers and views.</p>
<p><img id="96437" src="96437-picture10.png" alt="" width="416" height="593"><br>
<br>
</p>
<h1>STEP6</h1>
<p>Comment the line //throw new UnintentionalCodeFirstException()</p>
<p>&nbsp;<img id="96438" src="96438-picture11.png" alt="" width="838" height="499"></p>
<p><br>
<br>
</p>
<h1>STEP7</h1>
<p>Create two new entries on the application menu.</p>
<p>One to call the Clients entities and other to call Contacts entities. This could be made on the /Views/Shared/_Layout.cshmtl.</p>
<p>&nbsp;</p>
<p><img id="96439" src="96439-picture12.png" alt="" width="1169" height="432"><br>
<br>
</p>
<h1>STEP8</h1>
<p>Run the application.</p>
<p>Verify that two new entries exists on menu and that you can Create/Edit/Delete both entities created.</p>
<p><br>
&nbsp;<img id="96440" src="96440-picture13.png" alt="" width="1024" height="473"></p>
<p><img id="96441" src="96441-picture14.png" alt="" width="1011" height="371"></p>
<p><br>
<br>
</p>
