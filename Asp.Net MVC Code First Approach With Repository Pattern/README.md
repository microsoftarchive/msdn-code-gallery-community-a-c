# Asp.Net MVC Code First Approach With Repository Pattern
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Repository Pattern
- ASP.NET MVC 4
- Entity Framework Code First
## Topics
- crud operations in mvc4
## Updated
- 08/08/2016
## Description

<h1>Introduction</h1>
<p><em><span>There are three approaches in Entity Framework to work with database and these are Database First, Model First and Code First. I always prefer to work with Code First approach.</span><br>
<br>
<strong>Code First Approach</strong><br>
<br>
<span>It is a part of Entity Framework which uses&nbsp;</span><strong>POCO [Plan Old CLR Object]</strong><span>. Basically it removes to write or doing some extra effort to write data access code. In the code first, firstly we create our model entity. It is
 our domain model. We only need to define our entity classes and rest of the task is done by Entity Framework.</span><br>
<br>
<strong>Repository Pattern<br>
</strong><br>
<span>It is used to create an abstraction layer between data access logic and business logic in the application. It has the responsibility to communicate with data access layer and get data and transfer it to business logic layer.</span></em></p>
<p>&nbsp;</p>
<h1>Build Sample</h1>
<p>&nbsp;</p>
<p><em><span><strong>Create an ASP.NET MVC Project<br>
</strong><br>
<span>Open Visual Studio 2015, Click on&nbsp;</span><strong>File</strong><span>, choose&nbsp;</span><strong>New</strong><span>&nbsp;and then choose Project. It will open a&nbsp;</span><strong>New Project</strong><span>&nbsp;Dialog. Inside the&nbsp;</span><strong>Installed
 Template</strong><span>, choose&nbsp;</span><strong>Visual C#</strong><span>&nbsp;and then choose&nbsp;</span><strong>Web.&nbsp;</strong><span>After that select&nbsp;</span><strong>ASP.NET Web Application</strong><span>&nbsp;and provide the proper name and
 click&nbsp;</span><strong>OK</strong><span>.<br>
<br>
<span>It will open a new dialog where you can choose different types of project. Choose MVC as the project and click on OK.</span><br>
<br>
<strong>Adding Model</strong><br>
<br>
<span>To add a new model, right click on&nbsp;</span><strong>Model folder</strong><span>&nbsp;and choose&nbsp;</span><strong>Add</strong><span>&nbsp;and then select&nbsp;</span><strong>class</strong><span>. It will open a add new class dialog where you need
 to pass the model class name &ldquo;</span><strong>Emloyee.cs</strong><span>&rdquo; and click on&nbsp;</span><strong>OK</strong><span>.</span></span></span></em></p>
<p><em><span><span><span>&nbsp;</span></span></span></em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>

<div class="preview">
<pre class="js">namespace&nbsp;EmployeeManagement.Models&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Id&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Name&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Email&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Age&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Address&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information on X, see &nbsp;my blog on Csharpcorner.</em></p>
<p><em><a title="Code First Approach with Repository Pattern In Asp.Net MVC" href="http://www.c-sharpcorner.com/UploadFile/8a67c0/Asp-Net-mvc-code-first-approach-with-repository-pattern/" target="_blank">http://www.c-sharpcorner.com/UploadFile/8a67c0/Asp-Net-mvc-code-first-approach-with-repository-pattern/</a><br>
</em></p>
