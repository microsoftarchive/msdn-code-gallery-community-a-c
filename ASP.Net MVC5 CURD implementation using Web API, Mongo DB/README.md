# ASP.Net MVC5 CURD implementation using Web API, Mongo DB
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ASP.NET MVC 4
- MongoDB
- ASP.NET Web API 2
## Topics
- Architecture and Design
- Generic C# resuable code
- ASP.NET Web API
- Jquery Ajax
- ASP.NET MVC 5
- .net mongo db crud opration
## Updated
- 04/25/2015
## Description

<h1><span style="font-size:medium">Web API CURD Operation</span></h1>
<p><span style="font-size:small"><span style="white-space:pre">&nbsp;</span>A Visual Studio 2013/2015 project shows how to use the Mongo DB in Web Api, and ASP.Net MVC 5 web application.</span><br>
<br>
<span style="font-size:small"><span style="white-space:pre">&nbsp;</span>This project makes it easy to communicate Mongo DB using C-Sharp Driver.</span><br>
<span style="font-size:small">Main goal of an application to achieve CURD(Create, Update, Retrieve, Delete) operation.</span><br>
<br>
<span style="font-size:small"><strong>Requirement</strong></span><br>
<span style="font-size:small"><span style="white-space:pre">&nbsp;</span>Visual Studio 2015 or Visual Studio 2013, Mongo DB, Fiddler.</span><br>
<br>
<span style="font-size:small"><strong>Technologies</strong></span><br>
<span style="font-size:small"><span style="white-space:pre">&nbsp;</span>ASP.Net MVC 5, Web Api, Mongo DB, C#.&nbsp;</span><br>
<br>
<span style="font-size:small"><strong>Roadmap</strong></span><br>
<span style="font-size:small">Mongo DB communication, Web Api design, ASP.Net MVC 5, Ajax implementation.</span></p>
<h2><span style="font-size:small">Introduction:</span></h2>
<p><span style="font-size:small">This project shows how simple Employee management system works(CURD) using Mongo DB, using ASP.Net Web api, MVC5.</span><br>
<br>
<span style="font-size:small">Following section we gonna discuss</span></p>
<ol>
<li><span style="font-size:small">Architecture</span> </li><li><span style="font-size:small">Mongo DB server interaction</span>
<ol>
<li><span style="font-size:small">Download and install Mongo DB server</span> </li><li><span style="font-size:small">Start Mongo DB server</span> </li><li><span style="font-size:small">Mongo DB client editor</span> </li><li><span style="font-size:small">Create database, and table for Employee management</span>
</li></ol>
</li><li><span style="font-size:small">Web api creation</span> </li><li><span style="font-size:small">Client application</span>
<ol>
<li><span style="font-size:small">MVC application</span> </li></ol>
</li><li><span style="font-size:small">Demo screen</span> </li><li><span style="font-size:small">Source Code Overview</span> </li></ol>
<h1><span style="font-size:small">1. Architecture</span></h1>
<p><span style="font-size:small">Some high level design for communication.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<h1><span style="font-size:small"><img id="136524" src="136524-newcurdapi.png" alt="" width="977" height="547"></span></h1>
<p>&nbsp;</p>
<p><span style="font-size:small">* Different client can communicate to ASP.Net web api, just request and response method(json)</span><br>
<span style="font-size:small">* Once Web api got requested data, then communicate to back-end(Mongo DB), try to update against collection(table) based on request type(Create, Delete,Update).</span><br>
<span style="font-size:small">* Pass response to respective client</span><br>
<span style="font-size:small">* client receive the response in XML or JSON formatted date, then populate into native UI screen.</span><br>
<br>
<span style="font-size:small">Different client has different methodology&nbsp;to consume REST based service, like C#, Java, Jquery, etc. here am used c# code for the same.</span></p>
<p>&nbsp;</p>
<h1><span style="font-size:small">2. Mongo DB server interaction</span></h1>
<p><span style="font-size:small"><strong>1. Download and install Mongo DB server</strong></span><br>
<span style="font-size:small"><a href="http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/">http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/</a></span><br>
<span style="font-size:small"><strong>2. Start Mongo DB server&nbsp;</strong></span><br>
<span style="font-size:small">Once installation been completed, we gonna start MongoDB server.</span><br>
<span style="font-size:small"><em>steps</em>:</span></p>
<blockquote><span style="font-size:small">C:\&gt; cd &quot;Program Files&quot;</span></blockquote>
<blockquote><span style="font-size:small">C:\Program Files&gt; cd &quot;MongoDB 2.6 Standard&quot;</span></blockquote>
<blockquote><span style="font-size:small">C:\Program Files\MongoDB 2.6 Standard&gt; cd bin</span></blockquote>
<blockquote><span style="font-size:small">C:\Program Files\MongoDB 2.6 Standard\bin&gt; Mongod.exe</span></blockquote>
<blockquote><span style="font-size:small"><img id="136526" src="136526-mongo3.png" alt="" width="643" height="330"></span></blockquote>
<blockquote><span style="font-size:small"><strong>server initiated successfully.</strong></span><br>
</blockquote>
<blockquote><br>
</blockquote>
<blockquote><span style="font-size:small"><strong>3. Mongo DB client editor</strong></span><br>
<span style="font-size:small">Connect MongoDB server using Robomongo editer or we gonna use command prompt for do the same.</span><br>
<span style="font-size:small">To download RoboMongo editor :&nbsp;<a href="http://robomongo.org/">http://robomongo.org/</a></span><br>
<span style="font-size:small"><strong>&nbsp;</strong></span></blockquote>
<blockquote><span style="font-size:small"><strong>4. Create database</strong></span><br>
</blockquote>
<blockquote>
<blockquote><span style="font-size:small">Create Collection like below</span></blockquote>
<blockquote>
<blockquote><span style="font-size:small">db.createCollection(&quot;EmployeeDetails&quot;);</span></blockquote>
</blockquote>
<blockquote>
<blockquote><span style="font-size:small">db.createCollection(&quot;Department&quot;);</span></blockquote>
<blockquote><br>
</blockquote>
</blockquote>
</blockquote>
<blockquote><span style="font-size:small"><img id="136529" src="136529-mongorobo1.png" alt="" width="931" height="341"></span></blockquote>
<blockquote>
<h1><span style="font-size:small">3. Web Api creation</span></h1>
<span style="font-size:small">Following methods has been using in Web api to achieve CURD operation.</span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp</span>

<div class="preview">
<pre class="csharp"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IList&lt;IEmployee&gt;&nbsp;Get(){&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEmployee&nbsp;Get(<span class="cs__keyword">int</span>&nbsp;id){&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Post(Employee&nbsp;<span class="cs__keyword">value</span>)&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Put(<span class="cs__keyword">int</span>&nbsp;id,&nbsp;Employee&nbsp;<span class="cs__keyword">value</span>)&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;{&nbsp;}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small"><img id="136532" src="136532-employee.png" alt="" width="206" height="290">&nbsp;</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<h1><span style="font-size:small">4. Client application</span></h1>
<span style="font-size:small">Here i would used ASP.net MVC5 web application for consuming Web Api service.</span></div>
</blockquote>
<blockquote>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp</span>

<div class="preview">
<pre class="csharp"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;CreateNewEmployee(Employee&nbsp;postedEmployee)&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;UpdateEmployee(Employee&nbsp;postedEmployee,&nbsp;<span class="cs__keyword">int</span>&nbsp;employeeId)&nbsp;{&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;DeleteEmployee(<span class="cs__keyword">int</span>&nbsp;empId){&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;GetAllEmployeeList()&nbsp;{&nbsp;}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span style="font-size:small">5. Demo screen</span></h1>
</blockquote>
<blockquote><span style="font-size:small"><strong>Initial screen</strong></span></blockquote>
<blockquote><span style="font-size:small"><strong><img id="136533" src="136533-demoscreen1.png" alt="" width="1354" height="329"><br>
</strong></span></blockquote>
<blockquote><span style="font-size:small"><strong><strong>Add New Employee</strong></strong></span></blockquote>
<blockquote><span style="font-size:small"><strong><strong><img id="136534" src="136534-demoscreen2.png" alt="" width="592" height="640"></strong></strong></span></blockquote>
<blockquote><br>
</blockquote>
<blockquote><span style="font-size:small"><strong><strong><strong>Update Employee</strong></strong></strong></span></blockquote>
<blockquote><span style="font-size:small"><strong><strong><strong><img id="136535" src="136535-demoscreen5.png" alt="" width="603" height="644"></strong></strong></strong></span></blockquote>
<blockquote><br>
</blockquote>
<blockquote><span style="font-size:small"><strong><strong><strong><strong>Delete Employee</strong></strong></strong></strong></span></blockquote>
<blockquote><span style="font-size:small"><strong><strong><strong><strong><img id="136537" src="136537-demoscreen4.png" alt="" width="595" height="170"></strong></strong></strong></strong></span></blockquote>
<blockquote><br>
</blockquote>
<blockquote><span style="font-size:small"><strong><strong><strong><strong><strong>Employee List screen</strong></strong></strong></strong></strong></span></blockquote>
<blockquote><br>
</blockquote>
<blockquote><span style="font-size:small"><strong><strong><strong><strong><strong><img id="136538" src="136538-demoscreen3.png" alt="" width="1287" height="253"></strong></strong></strong></strong></strong></span></blockquote>
<blockquote><br>
</blockquote>
<blockquote><span style="font-size:x-small"><strong><strong><strong><strong><strong>
<h1><span style="font-size:medium">6. Source Code Overview</span></h1>
</strong></strong></strong></strong></strong></span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><strong>Business</strong>
</span></blockquote>
<blockquote>
<p><span style="font-size:small"><span style="color:#000000"><span style="white-space:pre"><em>EmployeeManagement.Core(Lib)</em> :
</span></span><span style="white-space:pre">This project has explain how to connect Web Api service.
</span></span></p>
</blockquote>
<blockquote>
<p><span style="white-space:pre; font-size:small"><span style="color:#000000"><em>EmployeeManagement.Service(Web Api)
</em>:</span> This is Web Api project, it supposed to expose All HTTP service method's.</span></p>
</blockquote>
<blockquote><span style="font-size:small"><strong><span style="white-space:pre">DataAccess</span></strong></span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><em>EmployeeManagement.Data(Lib) :
</em>This project has to implemented Mongo Db interaction, like insert, update, delete, retrieve through C# driver.</span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><strong>Infrastructure</strong>
</span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><em>EmployeeManagement.SharedLibraries(Lib)</em> : This project used for common libraries class, it used for data communication.</span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><strong>Presentation</strong></span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><strong>&nbsp;</strong></span><em style="font-size:small; white-space:pre">EmployeeManagement.Web(Web)
</em><span style="font-size:small; white-space:pre">: This is ASP.Net MVC 5 project, it used for client presentation like add new record, update, delete.</span></blockquote>
<blockquote><strong><span style="font-size:medium; white-space:pre">Execution Process</span></strong></blockquote>
<blockquote><strong><span style="white-space:pre">Build all projects one by one.</span></strong></blockquote>
<blockquote><span style="font-size:small">1. Need to update current Mongo DB server path, like in Data Access project used MONGO_SERVER appSetting,&nbsp;please update the EmployeeManagement.Service and EmployeeManagement.Data(Optional).</span></blockquote>
<blockquote><img id="136824" src="https://i1.code.msdn.s-msft.com/aspnet-mvc5-curd-b4a57435/image/file/136824/1/mongoserverconfig.png" alt="" width="502" height="67"><br>
</blockquote>
<blockquote><span style="font-size:x-small"><span style="font-size:small">2. Once EmployeeManagement.Service build successfully, publish the content into local server(IIS or Windows server).</span></span></blockquote>
<blockquote><span style="font-size:small"><span>&nbsp;</span><span style="white-space:pre">3. Configure EmployeeManagement API endpoint into EmployeeManagement.Web and EmployeeManagement.Core(optional).</span></span></blockquote>
<blockquote><span style="white-space:pre; font-size:small"><img id="136825" src="https://i1.code.msdn.s-msft.com/aspnet-mvc5-curd-b4a57435/image/file/136825/1/employeemgmgtapiurl.png" alt="" width="666" height="125"><br>
</span></blockquote>
<blockquote><span style="white-space:pre"><br>
</span></blockquote>
