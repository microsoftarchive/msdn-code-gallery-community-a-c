# CinemaPlex - ASP.net core (MVC) Cinema Application for booking Movies etc.
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- AJAX
- SQL Server
- Microsoft Azure
- ASP.NET MVC
- jQuery
- Javascript
- Entity Framework
- HTML5
- ASP.NET Web API
- HTML5/JavaScript
- ASP.NET Core
## Topics
- C#
- Microsoft Azure
- ASP.NET MVC
- jQuery
- Javascript
- shopping cart
- HTML5
- web application
- ASP.NET Web API
- HTML5/JavaScript
- e-commerce
- ASP.NET Core
## Updated
- 09/13/2017
## Description

<h1>CinemaPlex</h1>
<p>ASP.net Core Cinema Application for Booking Movies and providing a general Cinema Website.</p>
<h1>Download</h1>
<p>All the source code can be found uploaded in a zip file here or:<br>
<br>
</p>
<h3><a class="title" title="CinemaPlex - GitHub Repository" href="https://github.com/jaeko44/CinemaPlex" target="_blank">https://github.com/jaeko44/CinemaPlex</a></h3>
<h1>Launching CinemaPlex</h1>
<h4>Use Visual Studio 2015 on Microsoft, either community or enterprise edition and then run the app using F5.</h4>
<h4>Or use another IDE and deploy the application manually using CLI (<a href="https://docs.microsoft.com/en-us/aspnet/core/publishing/linuxproduction?tabs=aspnetcore2x" target="_blank">Host NGINX on Linux</a>).</h4>
<p>~/wwwroot/js/site.js -&gt; Change Line 3 to your google API Key for Youtube.</p>
<p>~/Views/Cinemas/Details.cshtml -&gt; Change Line 78 to your google API Key for Google Maps.</p>
<p>~/web.config -&gt; Change connectionStrings (Line 14/15) with your SQL Connection String.</p>
<p>~/appsettings.json -&gt; Modify Lines 3 with your SQL Connection String.</p>
<p>~/Data/ApplicationDbContext.cs -&gt; Modify Lines 45-50 with your SQL Connection String.</p>
<p>~/Startup.cs -&gt; Modify Lines 88/89 With Facebook AppId &amp; AppSecret.</p>
<p>Run the cinemaplex-db-script.sql file on your DB and run your application from Visual Studio.</p>
<p>Make sure the application can connect to the Database with Entity Framework.</p>
<p>&nbsp;</p>
<h1>Front-End Demo</h1>
<h2><a id="user-content-homepage" class="anchor" href="https://github.com/jaeko44/CinemaPlex#homepage"></a>Homepage:</h2>
<p><a href="https://camo.githubusercontent.com/e80cda2806e54528a1e3b3e748ed865cd96e30f0/68747470733a2f2f692e696d6775722e636f6d2f556b50584344742e706e67" target="_blank"><img src="https://camo.githubusercontent.com/e80cda2806e54528a1e3b3e748ed865cd96e30f0/68747470733a2f2f692e696d6775722e636f6d2f556b50584344742e706e67" alt="Quick Booking"></a></p>
<h2>Movies:</h2>
<p><a href="https://camo.githubusercontent.com/ea1ed85322b9806447860fe75d1ab0309fef9e81/68747470733a2f2f692e696d6775722e636f6d2f326137523247332e706e67" target="_blank"><img src="https://camo.githubusercontent.com/ea1ed85322b9806447860fe75d1ab0309fef9e81/68747470733a2f2f692e696d6775722e636f6d2f326137523247332e706e67" alt="All Movies"></a><a href="https://camo.githubusercontent.com/a2471a3d3a758ff96ca4bea17de173d6e404edd5/68747470733a2f2f692e696d6775722e636f6d2f344f734247794e2e706e67" target="_blank"><img src="https://camo.githubusercontent.com/a2471a3d3a758ff96ca4bea17de173d6e404edd5/68747470733a2f2f692e696d6775722e636f6d2f344f734247794e2e706e67" alt="Details"></a></p>
<h2><a id="user-content-session" class="anchor" href="https://github.com/jaeko44/CinemaPlex#session"></a>Session:</h2>
<p><a href="https://camo.githubusercontent.com/88214b15f7ed7b9f29c212920953e5c8588f19d9/68747470733a2f2f692e696d6775722e636f6d2f4c324230566f5a2e706e67" target="_blank"><img src="https://camo.githubusercontent.com/88214b15f7ed7b9f29c212920953e5c8588f19d9/68747470733a2f2f692e696d6775722e636f6d2f4c324230566f5a2e706e67" alt="Session"></a></p>
<h2><a id="user-content-cart" class="anchor" href="https://github.com/jaeko44/CinemaPlex#cart"></a>Cart</h2>
<p><a href="https://camo.githubusercontent.com/ee226b61dcdd2d5f427e8f87f6ae0b585902564a/68747470733a2f2f692e696d6775722e636f6d2f5a6361415137622e706e67" target="_blank"><img src="https://camo.githubusercontent.com/ee226b61dcdd2d5f427e8f87f6ae0b585902564a/68747470733a2f2f692e696d6775722e636f6d2f5a6361415137622e706e67" alt="Cart"></a><a href="https://camo.githubusercontent.com/c34f597031a3529cc8fd7063344f9f2c406d808b/68747470733a2f2f692e696d6775722e636f6d2f4f6c36665472752e706e67" target="_blank"><img src="https://camo.githubusercontent.com/c34f597031a3529cc8fd7063344f9f2c406d808b/68747470733a2f2f692e696d6775722e636f6d2f4f6c36665472752e706e67" alt="Book Seats"></a></p>
<h2><a id="user-content-cinemas" class="anchor" href="https://github.com/jaeko44/CinemaPlex#cinemas"></a>Cinemas:</h2>
<p><a href="https://camo.githubusercontent.com/3354ce7afd5b9101ba973ff6e0da958dab1b388e/68747470733a2f2f692e696d6775722e636f6d2f457169627643732e706e67" target="_blank"><img src="https://camo.githubusercontent.com/3354ce7afd5b9101ba973ff6e0da958dab1b388e/68747470733a2f2f692e696d6775722e636f6d2f457169627643732e706e67" alt="Cinemas"></a>![Cinema
 Details])(<a href="https://i.imgur.com/F5Cya0g.png">https://i.imgur.com/F5Cya0g.png</a>)</p>
<h2><a id="user-content-login" class="anchor" href="https://github.com/jaeko44/CinemaPlex#login"></a>Login:</h2>
<p><a href="https://camo.githubusercontent.com/c1e3e8a2000249e282146204b0756de46175bf31/68747470733a2f2f692e696d6775722e636f6d2f6b7177656635312e706e67" target="_blank"><img src="https://camo.githubusercontent.com/c1e3e8a2000249e282146204b0756de46175bf31/68747470733a2f2f692e696d6775722e636f6d2f6b7177656635312e706e67" alt="Login One-Click"></a></p>
<p>&nbsp;</p>
<h1><a id="user-content-api-demo" class="anchor" href="https://github.com/jaeko44/CinemaPlex#api-demo"></a>API Demo</h1>
<pre><code><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>JavaScript</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">js</span>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;$.getJSON(<span class="js__string">&quot;/api/sessions/location/&quot;</span>&nbsp;&#43;&nbsp;cinemaId,&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(result,&nbsp;<span class="js__operator">function</span>&nbsp;(index,&nbsp;value)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.getJSON(<span class="js__string">&quot;/api/movies/&quot;</span>&nbsp;&#43;&nbsp;value.movieID,&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;movies.append($(<span class="js__string">&quot;&lt;option/&gt;&quot;</span>).val(value.sessionID).text(data.title));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</code></pre>
<p>In the above JavaScript code we are using the /api/session/location/1-&gt;5 in order to retrieve all the Movie Sessions Listed inside each location.</p>
<p>We then do a for each loop with Jquery and get the respective value of Movies title values as well as their Session ID's and append them to our View.</p>
<h1>More Information</h1>
<p><em>For more information regarding this project see GitHub link:&nbsp;https://github.com/jaeko44/CinemaPlex<br>
<br>
</em></p>
<h1>Platform as a Service for CinemaPlex (Autolaunch ASP.net C#)</h1>
<p><span style="font-size:large"><a title="Open Cloud Platform hosting paas openstack applications" href="https://virtengine.com/products/opensource.html" target="_blank">(Open Source) One Click Launch C# &amp; other Applications/Languages</a></span></p>
<p>&nbsp;</p>
<h1>Want to build your own Private or Public Cloud (Open Source)?</h1>
<h5>A Cloud can be utilized within an organization (Users/Staff/Partners/Customers) in order to launch Virtual Machines (with various Operating Systems, like Windows, and plenty of Linux Distros) as well as Applications (RoR, NodeJS, Python, C/C&#43;&#43;, C#, or plenty
 of oneclick pre-existing apps like Blogs, Ecommerce, Control Panels, and much more)&nbsp;</h5>
<p>Private Cloud (For use within an Internal Organization, Staff/Partners/Authorized Access) -</p>
<p><a href="https://virtengine.com/products/opensource.html">Open Source Cloud Management Platform - PaaS/IaaS</a></p>
<p>&nbsp;</p>
<p>Public Cloud (Integrates with WHMCS for billing, allowing users to add credits and launch VM's according to the plans they have purchased or the credit that exists in their account) -</p>
<p><a title="Open Cloud Platform hosting paas openstack applications" href="https://virtengine.com/index.html" target="_blank">Cloud Management Platform for Hosting Providers</a></p>
<p><span style="font-size:large"><br>
</span></p>
