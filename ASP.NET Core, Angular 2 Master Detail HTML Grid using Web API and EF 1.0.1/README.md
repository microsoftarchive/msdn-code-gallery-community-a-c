# ASP.NET Core, Angular 2 Master Detail HTML Grid using Web API and EF 1.0.1
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET Web API
- ASP.NET Core
- Angular2
- ASP.NET Core 1.0.1
- Entity Framework 1.0.1
## Topics
- ASP.NET Web API
- ASP.NET Core
- Angular2
- ASP.NET Core 1.0.1
- Entity Framework 1.0.1
## Updated
- 01/23/2017
## Description

<h1>Introduction</h1>
<p><img id="166578" src="166578-1.gif" alt="" width="564" height="380"></p>
<p>In this article let&rsquo;s see how to create our own ASP.NET Core, Angular 2 Master Detail HTML grid using Template pack, Entity Framework 1.0.1 and Web API.</p>
<p>Note: Kindly read our previous article which deeply explains about Getting Started with ASP.NET Core Template Pack&nbsp;</p>
<ul>
<li><a href="https://code.msdn.microsoft.com/ASPNET-Core-Template-Pack-71bcde34?redir=0" target="_blank">ASP.NET Core Template Pack</a>
</li><li><a href="https://code.msdn.microsoft.com/ASPNET-Core-Angular-2-EF-8fbfae0c?redir=0" target="_blank">ASP.NET Core Angular 2 EF 1.0.1 Web API Using Template Pack</a>
</li></ul>
<p>In this article let&rsquo;s see</p>
<p>&nbsp;</p>
<ul>
<li>&nbsp;Creating sample Database and Student Master and Detail Table in SQL Server to display in our web application.
</li><li>&nbsp;How to create ASP.NET Core Angular 2 Starter Application (.NET Core) using Template pack
</li><li>&nbsp;Creating EF, DBContext Class and Model Class. </li><li>&nbsp;Creating WEB API </li><li>Creating our First Component TypeScript file to get WEB API JSON result using Http Module.
</li><li>&nbsp;Creating our first Component HTML file to bind data to Master and Detail HTML Grid
</li></ul>
<p>&nbsp;</p>
<p>This article will explain in detail about how to create a Master /Detail Table and bind the Master related details in inner HTML table to show the output as Master/Detail Grid. Here in this article we have used the Student Master and Student Detail relation
 to show the Master/Detail grid. In Student Master, we store student ID, Name, Email, Phone and Address. In Student Details, we store the student&rsquo;s exam final result for displaying Student Major, studying Year with Term and Grade details.</p>
<p>Here in the below image we can see when the user clicked on the Student ID &ldquo;2&rdquo; then we can see next the details grid was being displayed to show student results in detail by Major, Year, Term and Grade.</p>
<p>Here we display the student details by each student Id.<span style="white-space:pre">
</span></p>
<p><span style="white-space:pre"><img id="166579" src="166579-19.png" alt="" width="464" height="296"><br>
</span></p>
<h1><span>Building the Sample</span></h1>
<h1><strong>Prerequisites</strong></h1>
<p>Make sure you have installed all the prerequisites in your computer. If not, then download and install all of them, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2015 with Update 3 from this&nbsp;<a href="https://www.visualstudio.com/downloads/" target="_blank">link</a>.
</li><li>If you have Visual Studio 2015 and have not yet updated with update 3, download and install the Visual Studio 2015 Update 3 from this&nbsp;<a href="https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs" target="_blank">link</a>.
</li><li><a href="https://www.microsoft.com/net/core#windowsvs2015" target="_blank">Download</a>&nbsp;and install .NET Core 1.0.1
</li><li><a href="https://blogs.msdn.microsoft.com/typescript/2016/09/22/announcing-typescript-2-0/" target="_blank"></a><a href="https://blogs.msdn.microsoft.com/typescript/2016/09/22/announcing-typescript-2-0/" target="_blank">Download</a>&nbsp;and install TypeScript
 2.0 </li><li>Download and install Node.js v4.0 or above. I have installed V6.9.1 (<a href="https://nodejs.org/en/" target="_blank">Download link</a>).
</li><li>Download and install Download ASP.NET Core Template Pack visz file from this&nbsp;<a href="https://marketplace.visualstudio.com/items?itemName=MadsKristensen.ASPNETCoreTemplatePack" target="_blank">link</a>.
</li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h1><strong>Step 1 Create a Database and Table</strong></h1>
<p>We will create a Student Master and Student Detail table to be used for the Master and Detail Grid data binding.</p>
<p>The following is the script to create a database, table and sample insert query.</p>
<p>Run this script in your SQL Server. I have used SQL Server 2014.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;MASTER&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;
--<span class="js__num">1</span>)&nbsp;Check&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;Database&nbsp;Exists.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;<span class="js__operator">new</span>&nbsp;DB&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS(SELECT[name]&nbsp;FROM&nbsp;sys.databases&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'StudentsDB'</span>)&nbsp;&nbsp;&nbsp;
DROP&nbsp;DATABASE&nbsp;StudentsDB&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;
--CREATEDATABASEStudentsDB&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;
USE&nbsp;StudentsDB&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;
--<span class="js__num">1</span>)&nbsp;<span class="js__sl_comment">////////////&nbsp;StudentMasters&nbsp;&nbsp;</span>&nbsp;
IF&nbsp;EXISTS(SELECT[name]&nbsp;FROM&nbsp;sys.tables&nbsp;WHERE[name]&nbsp;=&nbsp;<span class="js__string">'StudentMasters'</span>)&nbsp;&nbsp;&nbsp;
DROP&nbsp;TABLE&nbsp;StudentMasters&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;
CREATE&nbsp;TABLE[dbo].[StudentMasters](&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StdID]&nbsp;INT&nbsp;IDENTITY&nbsp;PRIMARY&nbsp;KEY,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StdName][varchar](<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Email][varchar](<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Phone][varchar](<span class="js__num">20</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Address][varchar](<span class="js__num">200</span>)&nbsp;NOT&nbsp;NULL&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--insert&nbsp;sample&nbsp;data&nbsp;to&nbsp;Student&nbsp;Master&nbsp;table&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentMasters]([StdName],&nbsp;[Email],&nbsp;[Phone],&nbsp;[Address])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__string">'Shanu'</span>,&nbsp;<span class="js__string">'syedshanumcain@gmail.com'</span>,&nbsp;<span class="js__string">'01030550007'</span>,&nbsp;<span class="js__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentMasters]([StdName],&nbsp;[Email],&nbsp;[Phone],&nbsp;[Address])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__string">'Afraz'</span>,&nbsp;<span class="js__string">'Afraz@afrazmail.com'</span>,&nbsp;<span class="js__string">'01030550006'</span>,&nbsp;<span class="js__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentMasters]([StdName],&nbsp;[Email],&nbsp;[Phone],&nbsp;[Address])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__string">'Afreen'</span>,&nbsp;<span class="js__string">'Afreen@afreenmail.com'</span>,&nbsp;<span class="js__string">'01030550005'</span>,&nbsp;<span class="js__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
select&nbsp;*&nbsp;from[StudentMasters]&nbsp;&nbsp;&nbsp;
&nbsp;
IF&nbsp;EXISTS(SELECT[name]&nbsp;FROM&nbsp;sys.tables&nbsp;WHERE[name]&nbsp;=&nbsp;<span class="js__string">'StudentDetails'</span>)&nbsp;&nbsp;&nbsp;
DROP&nbsp;TABLE&nbsp;StudentDetails&nbsp;&nbsp;&nbsp;
GO&nbsp;
CREATE&nbsp;TABLE[dbo].[StudentDetails](&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StdDtlID]&nbsp;INT&nbsp;IDENTITY&nbsp;PRIMARY&nbsp;KEY,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StdID]&nbsp;INT&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Major][varchar](<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Year][varchar](<span class="js__num">30</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Term][varchar](<span class="js__num">30</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Grade][varchar](<span class="js__num">10</span>)&nbsp;NOT&nbsp;NULL&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;&nbsp;&nbsp;
&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">1</span>,<span class="js__string">'Computer&nbsp;Science'</span>,<span class="js__string">'First&nbsp;Year'</span>,<span class="js__string">'First&nbsp;Term'</span>,<span class="js__string">'A'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">1</span>,<span class="js__string">'Computer&nbsp;Science'</span>,<span class="js__string">'First&nbsp;Year'</span>,<span class="js__string">'Second&nbsp;Term'</span>,<span class="js__string">'B'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">1</span>,<span class="js__string">'Computer&nbsp;Science'</span>,<span class="js__string">'Second&nbsp;Year'</span>,<span class="js__string">'First&nbsp;Term'</span>,<span class="js__string">'C'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">2</span>,<span class="js__string">'Computer&nbsp;Engineer'</span>,<span class="js__string">'Third&nbsp;Year'</span>,<span class="js__string">'First&nbsp;Term'</span>,<span class="js__string">'A'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">2</span>,<span class="js__string">'Computer&nbsp;Engineer'</span>,<span class="js__string">'Third&nbsp;Year'</span>,<span class="js__string">'Second&nbsp;Term'</span>,<span class="js__string">'A'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">3</span>,<span class="js__string">'English'</span>,<span class="js__string">'First&nbsp;Year'</span>,<span class="js__string">'First&nbsp;Term'</span>,<span class="js__string">'C'</span>)&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO[StudentDetails]([StdID],&nbsp;[Major],&nbsp;[Year],&nbsp;[Term],[Grade])&nbsp;&nbsp;&nbsp;
VALUES(<span class="js__num">13</span>,<span class="js__string">'Economics'</span>,<span class="js__string">'First&nbsp;Year'</span>,<span class="js__string">'First&nbsp;Term'</span>,<span class="js__string">'A'</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
select&nbsp;*&nbsp;from&nbsp;StudentDetails&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1 class="endscriptcode"><strong>Step 2 Create ASP.NET Core Angular 2 application</strong>&nbsp;</h1>
<div class="endscriptcode">After installing all the prerequisites listed above and ASP.NET Core Template, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2015 &gt;&gt; Visual Studio 2015, on your desktop. Click New &gt;&gt; Project. Select Web &gt;&gt;
 ASP.NET Core Angular 2 Starter. Enter your project name and click OK.</div>
<p><img id="166580" src="166580-1.png" alt="" width="501" height="252"></p>
<p>After creating ASP.NET Core Angular 2 application, wait for a few seconds. You will see that all the dependencies are automatically restoring.</p>
<p><img id="166581" src="166581-1_0.png" alt="" width="241" height="324"></p>
<p>We will be using all this in our project to create, build and run our Angular 2 with ASP.NET Core Template Pack, WEB API and EF 1.0.1<strong>
</strong></p>
<h1><strong>Step 3 Creating Entity Framework</strong></h1>
<p><strong>Add Entity Framework Packages</strong></p>
<p>To add our Entity Framework Packages in our ASP.NET Core application .Open the Project.JSON File and in dependencies add the below line to.</p>
<p>Note : Here we have used EF version 1.0.1.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js"><span class="js__string">&quot;Microsoft.EntityFrameworkCore.SqlServer&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Microsoft.EntityFrameworkCore.Tools&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0-preview2-final&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><img id="166582" src="166582-2.png" alt="" width="417" height="330"></div>
<p>&nbsp;</p>
<p>When we save the project,.json file we can see the Reference was been Restoring.</p>
<p><img id="166583" src="166583-2_0.png" alt="" width="208" height="49"></p>
<p>After few second we can see Entity framework package has been restored and all reference has been added.&nbsp;</p>
<p><img id="166584" src="166584-3.png" alt="" width="270" height="303"></p>
<h2><strong>Adding Connection String</strong></h2>
<p><strong>&nbsp;</strong>To add the connection string with our SQL connection open the &ldquo;appsettings.json&rdquo; file .Yes this is the JSON file and this file looks like the below image by default.</p>
<p><img id="166585" src="166585-4.png" alt="" width="305" height="181"></p>
<p>In this appsettings.json file add our connection string&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__string">&quot;ConnectionStrings&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;DefaultConnection&quot;</span>:&nbsp;<span class="js__string">&quot;Server=YOURDBSERVER;Database=StudentsDB;user&nbsp;id=SQLID;password=SQLPWD;Trusted_Connection=True;MultipleActiveResultSets=true;&quot;</span><span class="js__brace">}</span>,&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Note change the SQL connection string as per your local connection.</p>
<p><img id="166586" src="166586-5.png" alt="" width="560" height="161"></p>
<p>Next step is we create a folder named &ldquo;Data&rdquo; to create our model and DBContext class</p>
<p><img id="166587" src="166587-6_0.png" alt="" width="186" height="151"></p>
<h2><strong>&nbsp;Model Class for Student Master&nbsp;</strong></h2>
<p>We can create a model by adding a new class file in our Data Folder. Right Click Data folder and click Add&gt;Click Class. Enter the class name as StudentMasters and click Add.</p>
<p><img id="166588" src="166588-6.png" alt="" width="509" height="251"></p>
<p>Now in this class we first create property variable, add studentMaster. We will be using this in our WEB API controller.&nbsp;<strong>&nbsp;</strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;&nbsp;
&nbsp;
namespace&nbsp;Angular2ASPCORE.Data&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentMasters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;StdID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Name&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;StdName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Email&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Email&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Phone&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Phone&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Address&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>Model Class for Student Detail&nbsp;</strong></h2>
<p><span lang="EN-US">We can create a model by adding a new class file in our Data Folder. Right Click Data folder and click Add&gt;Click Class. Enter the class name as StudentDetails and click Add</span></p>
<p><img id="166590" src="166590-7.png" alt="" width="432" height="223"></p>
<p>Now in this class we first create property variable, add StudentDetails . We will be using this in our WEB API controller.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;StudentDetails&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;StdDtlID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;StudentID&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;StdID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Major&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Major&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Year&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Year&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Term&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Term&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Grade&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2 class="endscriptcode">&nbsp;<strong>Creating Database Context</strong></h2>
<p>DBContext is Entity Framework Class for establishing connection to database</p>
<p>We can create a DBContext class by adding a new class file in our Data Folder. Right Click Data folder and click Add&gt;Click Class. Enter the class name as StudentContext and click Add.</p>
<p><span style="white-space:pre"><img id="166591" src="166591-8.png" alt="" width="495" height="216">
</span></p>
<p>In this class we inherit DbContext and created Dbset for our studentMasters and StudentDetails table.<strong>&nbsp;</strong></p>
<p><span style="white-space:pre">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
using&nbsp;Microsoft.EntityFrameworkCore;&nbsp;
&nbsp;
namespace&nbsp;Angular2ASPCORE.Data&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;studentContext&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;studentContext(DbContextOptions&lt;studentContext&gt;&nbsp;options)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;base(options)&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;studentContext()&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DbSet&lt;StudentMasters&gt;&nbsp;StudentMasters&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DbSet&lt;StudentDetails&gt;&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2 class="endscriptcode"><span>&nbsp;</span><strong>Startup.CS</strong></h2>
<p>&nbsp;</p>
<p>Now we need to add our database connection string and provider as SQL SERVER.To add this we add the below code in Startup.cs file under
<strong>ConfigureServices</strong> method.<strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Add&nbsp;Entity&nbsp;framework&nbsp;.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddDbContext&lt;studentContext&gt;(options&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.UseSqlServer(Configuration.GetConnectionString(<span class="js__string">&quot;DefaultConnection&quot;</span>)));&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode"><strong style="font-size:2em">Step 4 Creating Web API</strong></h1>
<p>To create our WEB API Controller, right click Controllers folder. Click Add and click New Item.</p>
<p><span style="white-space:pre"><img id="166592" src="166592-9.png" alt="" width="405" height="226">
</span></p>
<p>Click ASP.NET in right side &gt; Click Web API Controller Class. Enter the name as &ldquo;StudentMastersAPI.cs&rdquo; and click Add.</p>
<p><img id="166593" src="166593-10.png" alt="" width="421" height="260"></p>
<p>In this we are using only Get method to get all the students result from database and bind the final result using Angular2 to html file.</p>
<p>Here in this web API we get both Student Master , Student Details and Student Details load by condition student ID.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[Produces(<span class="js__string">&quot;application/json&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;api/StudentMastersAPI&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;StudentMastersAPI&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;readonly&nbsp;studentContext&nbsp;_context;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;StudentMastersAPI(studentContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context&nbsp;=&nbsp;context;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/values</span>&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;Student&nbsp;Master</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;Student&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentMasters&gt;&nbsp;GetStudentMasters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_context.StudentMasters;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/values</span>&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;Student&nbsp;Detail</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;Details&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentDetails&gt;&nbsp;GetStudentDetails()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_context.StudentDetails;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;Student&nbsp;Detail&nbsp;with&nbsp;studentid&nbsp;to&nbsp;load&nbsp;by&nbsp;student&nbsp;ID</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET&nbsp;api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;Details/{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;StudentDetails&gt;&nbsp;GetStudentDetails(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_context.StudentDetails.Where(i&nbsp;=&gt;&nbsp;i.StdID&nbsp;==&nbsp;id).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;To test it we can run our project and copy the get method api path here we can see our API path for get is api/StudentMastersAPI/Student</div>
<p><br>
Run the program and paste the above API path to test our output.</p>
<p>&nbsp;</p>
<p><img id="166594" src="166594-11.png" alt="" width="456" height="121"></p>
<p>To get the Student Details by Student ID. Here we can see all the Student Details for Student ID=1 has been loaded.</p>
<p>api/StudentMastersAPI/Details/1</p>
<p><img id="166595" src="166595-12.png" alt="" width="444" height="116"></p>
<h1><strong>Working with Angular2</strong></h1>
<p>We create all Angular2 related App, Module, Services, Component and html template under ClientApp/App folder.</p>
<p>We create &ldquo;students&rdquo; folder under app folder to create our typescript and html file for displaying Student details.</p>
<p><img id="166596" src="166596-13.png" alt="" width="202" height="209"></p>
<h1><strong>Step 5 Creating Component TypeScript</strong></h1>
<p>Right Click on students folder and click on add new Item. Select Client-side from left side and select TypeScript File and name the file as &ldquo;students.component.ts&rdquo; and click Add.</p>
<p><span style="white-space:pre"><img id="166597" src="166597-14.png" alt="" width="499" height="240">
</span></p>
<p>In students.component.ts file we have three parts first is the,</p>
<ol>
<li>import part </li><li>Next is component part </li><li>Next we have the class for writing our business logics. </li></ol>
<p>&nbsp;First we import angular files to be used in our component here we import http for using http client in our Angular2 component.&nbsp;</p>
<p>In component we have selector and template. Selector is to give a name for this app and in our html file we use this selector name to display in our html page.<br>
<br>
In template we give our output html file name. here we will create on html file as &ldquo;students.component.html&rdquo;.<strong><br>
</strong><br>
Export Class is the main class where we do all our business logic and variable declaration to be used in our component template. In this class we get the API method result and bind the result to the student array. &nbsp;</p>
<p>Here we get first all the Student Master data from web API to bind in our html page. We have created one more function named &ldquo;getStudentsDetails&rdquo; to this function we pass the Student ID to load only the selected Student ID related data from Student
 Detail tables. We call this function from button click of each Student Master.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;Component&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;Http&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">&quot;@angular/http&quot;</span>;&nbsp;
&nbsp;
@Component(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selector:&nbsp;<span class="js__string">'students'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;template:&nbsp;require(<span class="js__string">'./students.component.html'</span>)&nbsp;
<span class="js__brace">}</span>)&nbsp;
&nbsp;
export&nbsp;class&nbsp;studentsComponent&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;student:&nbsp;StudentMasters[]&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;studentdetails:&nbsp;StudentDetails[]&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;myName:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;activeRow:&nbsp;string&nbsp;=&nbsp;<span class="js__string">&quot;0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;constructor(public&nbsp;http:&nbsp;Http)&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.myName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.getStudentMasterData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;getStudentMasterData()&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.http.get(<span class="js__string">'/api/StudentMastersAPI/Student'</span>).subscribe(result&nbsp;=&gt;&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.student&nbsp;=&nbsp;result.json();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;getStudentsDetails(StudID)&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.http.get(<span class="js__string">'/api/StudentMastersAPI/Details/'</span>&nbsp;&#43;&nbsp;StudID).subscribe(result&nbsp;=&gt;&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.studentdetails&nbsp;=&nbsp;result.json();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.activeRow&nbsp;=&nbsp;StudID;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">////&nbsp;For&nbsp;Student&nbsp;Master</span>&nbsp;
export&nbsp;interface&nbsp;StudentMasters&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;stdID:&nbsp;number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;stdName:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;email:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;phone:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;address:&nbsp;string;&nbsp;
<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;For&nbsp;Student&nbsp;Details</span>&nbsp;
export&nbsp;interface&nbsp;StudentDetails&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StdDtlID:&nbsp;number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;stdID:&nbsp;number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Major:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Year:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Term:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Grade:&nbsp;string;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><strong>Step 6 Creating Component HTML File</strong></h1>
<p>Right Click on students folder and click on add new Item. Select Client-side from left side and select html File and name the file as &ldquo;students.component.html&rdquo; and click Add.</p>
<p><img id="166598" src="166598-15.png" alt="" width="425" height="208"></p>
<p>Write the below html code to bind the result in our html page.</p>
<p>Here we have first created HTML Table for loading the Student Master data with Detail Button.</p>
<p>In the Detail Button click we load the Student Details for selected Student and bind the result according to the table row.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;h1&gt;Angular&nbsp;<span class="js__num">2</span><span class="js__statement">with</span>&nbsp;ASP.NET&nbsp;Core&nbsp;Template&nbsp;Pack,&nbsp;WEB&nbsp;API&nbsp;and&nbsp;EF&nbsp;<span class="js__num">1.0</span><span class="js__num">.1</span>&nbsp;&lt;/h1&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;h2&gt;My&nbsp;Name&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myName<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/h2&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;h1&gt;Students&nbsp;Details&nbsp;:&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;
&lt;p&nbsp;*ngIf=<span class="js__string">&quot;!student&quot;</span>&gt;&lt;em&gt;Loading&nbsp;Student&nbsp;Details&nbsp;please&nbsp;Wait&nbsp;!&nbsp;...&lt;<span class="js__reg_exp">/em&gt;&lt;/</span>p&gt;&nbsp;
&lt;!--&lt;pre&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;studentdetails&nbsp;|&nbsp;json&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/pre&gt;--&gt;&nbsp;
&lt;table&nbsp;class=<span class="js__string">'table'</span>&nbsp;style=<span class="js__string">&quot;background-color:#FFFFFF;&nbsp;border:2px&nbsp;#6D7B8D;&nbsp;padding:5px;width:99%;table-layout:fixed;&quot;</span>&nbsp;cellpadding=<span class="js__string">&quot;2&quot;</span>&nbsp;cellspacing=<span class="js__string">&quot;2&quot;</span>&nbsp;*ngIf=<span class="js__string">&quot;student&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;style=<span class="js__string">&quot;height:&nbsp;30px;&nbsp;background-color:#336699&nbsp;;&nbsp;color:#FFFFFF&nbsp;;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;&nbsp;width=<span class="js__string">&quot;80&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;80&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Student&nbsp;ID&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Student&nbsp;Name&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Email&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;120&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Phone&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;340&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Address&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tbody&nbsp;*ngFor=<span class="js__string">&quot;let&nbsp;StudentMasters&nbsp;&nbsp;of&nbsp;student&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;(click)=getStudentsDetails(StudentMasters.stdID)&nbsp;style=&quot;background-color:#<span class="js__num">334668</span>;color:#FFFFFF;font-size:large;width:80px;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;border-color:#a2aabe;border-style:dashed;border-width:2px;&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Detail&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/button&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.stdID<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;left&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.stdName<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;left&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.email<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.phone<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;left&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.address<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;*ngIf=<span class="js__string">&quot;activeRow==StudentMasters.stdID&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;colspan=<span class="js__string">&quot;6&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;class=<span class="js__string">'table'</span>&nbsp;style=<span class="js__string">&quot;background-color:#ECF3F4;&nbsp;border:2px&nbsp;#6D7B8D;&nbsp;padding:5px;width:99%;table-layout:fixed;&quot;</span>&nbsp;cellpadding=<span class="js__string">&quot;2&quot;</span>&nbsp;cellspacing=<span class="js__string">&quot;2&quot;</span>&nbsp;*ngIf=<span class="js__string">&quot;studentdetails&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;style=<span class="js__string">&quot;height:&nbsp;30px;&nbsp;background-color:#659EC7&nbsp;;&nbsp;color:#FFFFFF&nbsp;;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;100&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&lt;Strong&gt;Student&nbsp;Detail&nbsp;--&gt;&lt;<span class="js__reg_exp">/Strong&gt;&nbsp;&nbsp;&nbsp;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Major&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Year&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;120&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Term&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;340&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Grade&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tbody&nbsp;*ngFor=<span class="js__string">&quot;let&nbsp;stddetails&nbsp;&nbsp;of&nbsp;studentdetails&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;100&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>stddetails.major<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>stddetails.year<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;120&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>stddetails.term<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;340&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>stddetails.grade<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;
&lt;/table&gt;&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1 class="endscriptcode"><strong>Step 7 Adding Navigation menu</strong></h1>
<p>We can add our newly created student details menu in existing menu.</p>
<p>TO add our new navigation menu open the &ldquo;navmenu.component.html&rdquo; under navmenu menu.write the below code to add our navigation menu link for students.Here we have removed the existing Count and Fetch menu.<strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;li&nbsp;[routerLinkActive]=<span class="js__string">&quot;['link-active']&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a&nbsp;[routerLink]=<span class="js__string">&quot;['/students']&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">'glyphicon&nbsp;glyphicon-th-list'</span>&gt;&lt;/span&gt;&nbsp;Students&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/a&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/li&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h1><strong>Step 8 App Module</strong></h1>
<p>App Module is the root for all files and we can find the app.module.ts under ClientApp\app, and import our students component</p>
<p>App Module is root for all file and we can find the app.module.ts under ClientApp\ app</p>
<p>Import our students component</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;NgModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;RouterModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/router'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;UniversalModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'angular2-universal'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;AppComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/app/app.component'</span>&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;NavMenuComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/navmenu/navmenu.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;HomeComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/home/home.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;FetchDataComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/fetchdata/fetchdata.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;CounterComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/counter/counter.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;studentsComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/students/students.component'</span>;&nbsp;
&nbsp;
@NgModule(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bootstrap:&nbsp;[&nbsp;AppComponent&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;declarations:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavMenuComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CounterComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FetchDataComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HomeComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentsComponent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imports:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UniversalModule,&nbsp;<span class="js__sl_comment">//&nbsp;Must&nbsp;be&nbsp;first&nbsp;import.&nbsp;This&nbsp;automatically&nbsp;imports&nbsp;BrowserModule,&nbsp;HttpModule,&nbsp;and&nbsp;JsonpModule&nbsp;too.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RouterModule.forRoot([&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">''</span>,&nbsp;redirectTo:&nbsp;<span class="js__string">'home'</span>,&nbsp;pathMatch:&nbsp;<span class="js__string">'full'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'home'</span>,&nbsp;component:&nbsp;HomeComponent&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'counter'</span>,&nbsp;component:&nbsp;CounterComponent&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'fetch-data'</span>,&nbsp;component:&nbsp;FetchDataComponent&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'students'</span>,&nbsp;component:&nbsp;studentsComponent&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'**'</span>,&nbsp;redirectTo:&nbsp;<span class="js__string">'home'</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
<span class="js__brace">}</span>)&nbsp;
export&nbsp;class&nbsp;AppModule&nbsp;<span class="js__brace">{</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h1><strong>Step 9 Build and run the Application</strong></h1>
<p>Build and run the application and you can see our Students Master/Detail page will be loaded with all Student Master and Detail information&rsquo;s.</p>
<img id="166600" src="166600-18.png" alt="" width="482" height="241"></div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>Angular2AspCoreMasterDetail.zip</span> </li></ul>
<h1>More Information</h1>
<p>First create the Database and Table in your SQL Server. You can run the SQL Script from this article to create StudentsDB database and StudentMasters and StudentDetails Table and also don&rsquo;t forget to change the Connection string from &ldquo;appsettings.json&rdquo;.<strong>&nbsp;</strong></p>
