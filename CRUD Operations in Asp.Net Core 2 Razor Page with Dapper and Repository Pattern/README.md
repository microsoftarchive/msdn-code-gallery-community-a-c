# CRUD Operations in Asp.Net Core 2 Razor Page with Dapper and Repository Pattern
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Repository Pattern
- Dapper
- ASP.NET Core 2.0
- Razor Pages
## Topics
- Performance
- Web Development
- ASP.NET Security
## Updated
- 01/28/2018
## Description

<h1>Introduction</h1>
<p>This article will demonstrate you about how to perform CRUD operations in&nbsp;<em>Razor Page</em>&nbsp;which introduced Asp.Net Core 2 using Dapper and Repository Pattern.</p>
<p>To complete this demonstration in a simple manner, we will follow some steps as below.</p>
<p>Step 1: Create Razor Page in Asp.Net Core 2</p>
<p>Step 2: Create Database and Table</p>
<p>Step 3: Install Dapper</p>
<p>Step 4: Create Repository Class and Interface with Required Entity</p>
<p>Step 5: Create Connection String and get it on Repository Class</p>
<p>Step 6: Create Razor Page for CRUD Operations</p>
<p>Step 7: Implement Code in Razor Pages for performing CRUD Operations</p>
<p>Now we have defined six steps to complete this practical demonstration. So, let&rsquo;s move to step by step and complete the task.</p>
<h1><span>Building the Sample</span>&nbsp;</h1>
<p><span>STEP 1: Create Razor Page in Asp.Net Core 2</span></p>
<p>To create&nbsp;<em>Asp.Net Core 2 Razor Page</em>&nbsp;project, open Visual Studio 2017 version 15.3 and above and make sure you have installed .Net Core SDK 2.0 with your system. If you don&rsquo;t have this configuration with your system, please update
 your Visual Studio and system with these configurations.</p>
<p>I hope, you have installed the lasted version of Visual Studio with&nbsp;<em>.</em><em>Net Core SDK 2.0</em>, so open Visual Studio and Go to File&nbsp;<span>Menu</span>&nbsp;&gt; choose&nbsp;<span>New</span>&nbsp;&gt; select&nbsp;<span>Project</span>. It
 will open &ldquo;New Project&rdquo; windows. From the New Project windows, you have to choose&nbsp;<span>.Net Core</span>&nbsp;from the left panel and then from the center panel choose &ldquo;Asp.Net Core Web Application&rdquo; and provide the suitable name
 like &ldquo;RazorPagesExample&rdquo; and click to OK.</p>
<p><img src="http://www.mukeshkumar.net/Upload/Images/280120180859RazorPages.png" alt="Razor Page"></p>
<p>After clicking OK button, it will pop up with a new window from where we can choose the template for Razor Page.</p>
<p><img src="http://www.mukeshkumar.net/Upload/Images/280120180900RazorPages.png" alt="Razor Page Web Application"></p>
<p>From here, you have to choose &ldquo;Web Application&rdquo; to create Razor Page application and click to OK. It will take minutes or seconds to configure your project and finally, we have the project ready for demonstration.</p>
<p><span>STEP 2: Create Database and Table</span></p>
<p>Open SSMS [SQL Server Management Studio] and create new database name called it &ldquo;TestDB&rdquo; and inside that, you have to create one table that is called &ldquo;Product&rdquo; using following SQL scripts. Now we have a database and its corresponding
 table is ready.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">--Create&nbsp;Database&nbsp;
CREATE&nbsp;DATABASE&nbsp;TestDB&nbsp;
GO&nbsp;
&nbsp;
--Use&nbsp;Created&nbsp;Database&nbsp;
USE&nbsp;TestDB&nbsp;
GO&nbsp;
&nbsp;
--Create&nbsp;Table&nbsp;<span class="js__string">&quot;Product&quot;</span>&nbsp;
CREATE&nbsp;TABLE&nbsp;Product(Id&nbsp;INT&nbsp;PRIMARY&nbsp;KEY&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>),&nbsp;Name&nbsp;VARCHAR(<span class="js__num">25</span>),&nbsp;Model&nbsp;VARCHAR(<span class="js__num">50</span>),&nbsp;Price&nbsp;INT)&nbsp;
&nbsp;
--Insert&nbsp;dummy&nbsp;reocrd&nbsp;<span class="js__operator">in</span>&nbsp;table&nbsp;
INSERT&nbsp;INTO&nbsp;Product(Name,&nbsp;Model,&nbsp;Price)&nbsp;VALUES(<span class="js__string">'Nokia&nbsp;1'</span>,&nbsp;<span class="js__string">'Nokia'</span>,&nbsp;<span class="js__num">25000</span>)&nbsp;
&nbsp;
SELECT&nbsp;*&nbsp;FROM&nbsp;Product</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><span>STEP 3: Install Dapper</span></p>
<p>In one line, Dapper is micro ORM with high performance for SQL, MySQL etc.</p>
<p>It is a simple step to install Dapper. Right click on the project and choose &ldquo;<span>Manage NuGet Packages</span>&rdquo;. It will open&nbsp;<span>NuGet Package Manager</span>&nbsp;from there you can search packages which need to be installed. So, now
 we will search &ldquo;Dapper&rdquo; and installed it. After installation, it will be shown in the&nbsp;<span>NuGet</span>&nbsp;section which lies inside the &ldquo;<span>Dependencies</span>&rdquo; as follows in the project.</p>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...</em></p>
<p><em><a href="http://www.mukeshkumar.net/articles/dotnetcore/crud-operations-in-asp-net-core-2-razor-page-with-dapper-and-repository-pattern" target="_blank">http://www.mukeshkumar.net/articles/dotnetcore/crud-operations-in-asp-net-core-2-razor-page-with-dapper-and-repository-pattern</a><br>
</em></p>
