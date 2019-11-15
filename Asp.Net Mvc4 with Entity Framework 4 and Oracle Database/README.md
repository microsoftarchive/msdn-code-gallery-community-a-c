# Asp.Net Mvc4 with Entity Framework 4 and Oracle Database
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
- ASP.NET MVC 4
- ADO.NET Entity Framework with Oracle
- ASP.NET MVC 4 with Entity Framework
## Topics
- ASP.NET and ADO.NET Entity Framework
- ASP.NET MVC
- ASP.NET MVC 4
- ADO.NET Entity Framework with Oracle
- Stored Procedure Entity Framework Oracle DB
- Stored Procedure Entity Framework
## Updated
- 10/29/2014
## Description

<h1>Introduction</h1>
<p><em>The solution in this article helps to understand and implement below points.</em></p>
<ul>
<li><em>&nbsp;&nbsp;&nbsp;&nbsp; How to use Entity Framework with Oracle database.</em>
</li><li><em>&nbsp;&nbsp;&nbsp;&nbsp; Integration of Entity Framework with Asp.Net MVC 4.</em>
</li></ul>
<p><em>I wanted to keep this article simple to understand, so only above features are covered. I have a plan of working on many other solutions end to end for Asp.Net MVC 4.</em></p>
<p><em>&nbsp;</em>&nbsp;<em>Prerequisite to develop the sample</em></p>
<ul>
<li><em>&nbsp;&nbsp;&nbsp;Visual Studio 2010.</em> </li><li><em>&nbsp;&nbsp;&nbsp;Visual Studio 2010 sp1.</em> </li><li><em>&nbsp;&nbsp;&nbsp;Asp.Net MVC 4.</em> </li><li><em>&nbsp;&nbsp; Entity Framework 4.</em> </li><li><em>&nbsp;&nbsp; Oracle Database Server.</em> </li><li><em>&nbsp;&nbsp; ODAC(Oracle Data Access Component).</em> </li></ul>
<p><em>&nbsp;&nbsp;<span style="text-decoration:underline"><strong>&nbsp;Note</strong></span>: Install Oracle Data Access Component(ODAC) 11.2.0.3&nbsp;or later from the OTN. The ODAC download includes&nbsp;Oracle Developer Tools fro Visual Studio and ODP.Net
 taht will be used in this lab.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Please follow the below steps to build the application end to end.</em></p>
<h3><span style="text-decoration:underline"><strong>Step 1:Create MVC Project</strong></span></h3>
<p><em>Open the Visual Studio 2010 IDE AND CREATE Asp.Net MVC 4 application. As shown in the below screens.</em></p>
<p><strong>File-&gt;New-&gt;Project</strong></p>
<p><strong>&nbsp;</strong></p>
<p><em>&nbsp;</em>&nbsp;<img id="127303" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127303/1/screen1.png" alt="" width="959" height="415"></p>
<p><strong>Visual C# -&gt;Web-&gt;Asp.Net MVC 4 Web Application</strong></p>
<p><strong>&nbsp;</strong>&nbsp;<strong>&nbsp;</strong>&nbsp;<img id="127304" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127304/1/screen2.png" alt="" width="957" height="660"></p>
<p><strong>&nbsp;</strong></p>
<p><strong><img id="125499" src="125499-project_3.png" alt=""></strong></p>
<p><strong>&nbsp;</strong><strong>Project Solution Structure</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong><img id="127305" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127305/1/screen4.png" alt="">&nbsp;</strong></p>
<h3><span style="text-decoration:underline"><strong>Step 2: Create DAL Project </strong>
</span></h3>
<p><em>Below points are to be considered for DAL project.</em></p>
<ul>
<li><em>The DAL project is a simple class libraray.</em> </li><li><em>In DAL project we are going to add the entity framework(.edmx) file.</em>
</li></ul>
<p><strong>A) Steps to add class library in the solution.</strong></p>
<p><strong>Right Click Solution &quot;MVC4WithEF4AndOracleDB.Dal&quot;</strong></p>
<p><strong>Click &quot;Ok&quot;</strong></p>
<p><strong>Right Click &quot;Class1.cs&quot; and delete it.</strong></p>
<p><strong><img id="125501" src="125501-project_5.png" alt="" width="955" height="660">&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>Project Solution Structure</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;<img id="127306" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127306/1/screen5.png" alt="" width="415" height="656"></strong></p>
<p><strong>&nbsp;B) Steps to add Entity Framework support in the DAL Layer</strong></p>
<ol>
<li>Right click on DAL project &quot;MVCWithEF4AndOracleDB.Dal&quot; </li><li>Click Add </li><li>Click &quot;Add New Item&quot; </li><li>In Add New Item Dialog box select &quot;ADO.Net Entity Data Model&quot; </li><li>Name it as &quot;OracleDataModel.edmx&quot; </li><li>Click Add </li></ol>
<p><strong>&nbsp;This will start Entity Data Model Wizard.</strong></p>
<p><strong>&nbsp;</strong>&nbsp;</p>
<p><strong>&nbsp;<img id="127291" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127291/1/oracledatamodel.png" alt="" width="956" height="660"></strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>Choose &quot;Generate from Database&quot;,Click Next </strong></p>
<p><strong>&nbsp;</strong>&nbsp;</p>
<p><strong><img id="127292" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127292/1/entitydatamodelwizard1.png" alt="" width="537" height="485"></strong></p>
<p><strong>&nbsp;</strong>&nbsp;</p>
<p><strong>In Choose your data connecction window ,Click &quot;New Connection&quot;</strong></p>
<p><strong><img id="127293" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127293/1/entitydatamodelwizard2.png" alt=""></strong></p>
<p><strong>In Choose Data Source Window select &quot;Oracle Database&quot;.</strong></p>
<p><strong>Select Data Provider as &quot;ODP.Net , Managed Driver&quot;.</strong></p>
<p><strong>Click Continue</strong></p>
<p><strong>This will open &quot;Connection Properties&quot; window as below</strong></p>
<p><strong>&nbsp;</strong>&nbsp;</p>
<p><strong><img id="127295" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127295/1/entitydatamodelwizard3.png" alt="" width="553" height="618"></strong></p>
<p><strong>&nbsp;</strong>&nbsp;</p>
<p><strong>In Connection Propperties window enter below details</strong></p>
<ul>
<li>User Name </li><li>Password </li><li>Select Data Source Name from Drop Down </li><li>Click test Connection </li><li>This will pop up &quot;Test Connection Succeded&quot; window. </li><li>Click &quot;OK&quot; </li></ul>
<p><strong>Name your Entity object(In my case it is &quot;OracleEntities&quot;</strong></p>
<p><strong>&nbsp;</strong>&nbsp;</p>
<p><strong><img id="127296" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127296/1/entitydatamodelwizard4.png" alt="" width="536" height="486"></strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;Clicking &quot;Next&quot; will pop up &quot;Choose Your Database Objects&quot; window.</strong></p>
<p><strong><img id="127297" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127297/1/entitydatamodelwizard5.png" alt=""></strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>In &quot;Choose your database Objects&quot; window , select the obhects you want to use in your application.</strong></p>
<p><strong>As in this sample, I am going to demonstrate the use of Stored Procedure with Entity Framework.I am select the procedure&nbsp; &quot;GETDBUSERBYUSERID&quot; .</strong></p>
<p><strong><a></a>Enter the name of model &quot;OracleModel&quot;. </strong>&nbsp;</p>
<p><strong>Click &quot;Finish&quot;.</strong></p>
<p><strong>With all above steps we have successfully included the ADO.Net Entity Framework (.edmx) file in the DAL layer.</strong></p>
<p><span style="text-decoration:underline"><strong>GETDBUSERBYUSERID stored procedure</strong></span></p>
<p><span style="text-decoration:underline">&nbsp;</span>CREATE OR REPLACE PROCEDURE &#65279;GETDBUSERBYUSERID(</p>
<p>p_userid in test_user.USER_ID%TYPE,</p>
<p>UserDetails OUT SYS_REFCURSOR )</p>
<p>IS</p>
<p>BEGIN</p>
<p>OPEN UserDetails FOR</p>
<p>SELECT User_Name,Age FROM Test_User Where User_ID=p_userid;</p>
<p>&nbsp;END GETDBUSERBYUSERID;</p>
<p><strong>&nbsp;</strong>&nbsp;The stored procedure takes user id as input and returns the&nbsp;REFCURSOR with details of the user.</p>
<p><strong>&nbsp;C) Changes to&nbsp;OracleDataModel.edmx file&nbsp;</strong></p>
<ul>
<li>In solution explorer double click the OracleDataModel.edmx file. </li><li>Right click on the file and <a></a>select &quot;Model Browser&quot;. <span style="text-decoration:underline">
</span></li></ul>
<p><span style="text-decoration:underline"><strong>Create Complex Class</strong></span></p>
<p>Under OracleModel</p>
<p>Right click on folder &quot;Complex&nbsp;Types&quot; =&gt; Create Complex Types.Name the class as
<strong>UserDetails</strong>.</p>
<p>Right click on the class&nbsp;<strong>UserDetails </strong>=&gt;<strong>Click ADD =&gt;&nbsp;&nbsp;Scalar Property =&gt;String</strong>.Name the property as
<strong>UserName.</strong></p>
<p>Right click on the class <strong>UserDetails =&gt;Click ADD=&gt;Scalar Property=&gt;Int64</strong>.Name the property as
<strong>Age.</strong></p>
<p><span style="text-decoration:underline"><strong>Function import for stored Procedure</strong></span></p>
<ul>
<li>In &quot;Model Browser&quot; navigate to <strong>OracleModel.Store=&gt;Stored Procedures
</strong>and double click on stores procedure &quot;<strong>GETDBUSERBYUSERID</strong>&quot;
</li><li>This will open&nbsp;&quot;Add function import&quot; window. </li></ul>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;Steps in Add Function Import</strong></p>
<ul>
<li>Function Import Name :GetDBUserByUserId </li><li>Select the stored procedure &quot;GETDBUSERBYUSERID&quot; </li><li>Select the complex and select Complex class &quot;UserDetails&quot; created in step &quot;Create Complex Class&quot;
</li></ul>
<p><strong>After performing steps in this section ,we will see the model browser updated as per the screen below.</strong></p>
<p><strong>&nbsp;</strong></p>
<p><img id="127301" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127301/1/entitydatamodelwizard6.png" alt="" width="584" height="664">&nbsp;</p>
<p>&nbsp;</p>
<h3><span style="text-decoration:underline">Step 3 :Using the Dal in the GUI Project
</span></h3>
<p><span style="text-decoration:underline"><strong>A. Updates in Web.config file.</strong></span></p>
<ul>
<li>Open the Web.config file from the GUI Project . </li><li>Open the App.config from the DAL project. </li><li>Copy the connection string from App.config to web.config under the connectionStrings section.
</li><li>In Web.config add the section <strong>&lt;oracle.manageddataaccess.client&gt;</strong> as below.
</li></ul>
<p>&lt;oracle.manageddataaccessclient&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; &lt;version number=&quot;*&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;implicitRefCursor&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;storedProcedure schema=&quot;YourSchemaName&quot; name=&quot;GETDBUSERBYUSERID&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;refCursor name=&quot;UserDetails&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;bindInfo mode=&quot;Output&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/refCursor&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/storedProcedure&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/implicitRefCursor&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/version&gt;</p>
<p>&lt;/oracle.manageddataaccessclient&gt;</p>
<p><span style="text-decoration:underline"><strong>B. Use the entity framework in the GUI Project.&nbsp;</strong></span></p>
<p>Double click on the HomeController.cs calss under controllers folder.</p>
<p>In index action add the below code.</p>
<p>Public ActionResult Index()</p>
<p>{</p>
<p>OracleEntities entities= new OracleEntities();</p>
<p>var output= entities.GETDBUSERBYUSERID(11);</p>
<p>return View();</p>
<p>}</p>
<p>&nbsp;</p>
<p><strong>Place the break point on the line return View(); to see the results returned.I have checked the result in the Output window as below.</strong></p>
<p><img id="127302" src="https://i1.code.msdn.s-msft.com/aspnet-mvc4-with-entity-bf84ecbe/image/file/127302/1/entitydatamodelwizard7.png" alt="" width="1892" height="486"></p>
<p>&nbsp;</p>
<h3><span style="text-decoration:underline"><strong>&nbsp;&nbsp;Happy Coding.....</strong></span></h3>
