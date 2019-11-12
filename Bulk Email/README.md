# Bulk Email
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- SQL Server
- ASP.NET
## Topics
- Send Email
## Updated
- 06/04/2012
## Description

<h1>Send Bulk Email to multiple users</h1>
<p>Simple C# Web Application used to send Bulk Email to multiple recipients. This example is built with C# and WebForms in ASP.Net 4.0, and uses Ajax Control Toolkit. You are free to use this application and extend it further.</p>
<h1><span>Building the Sample</span></h1>
<p>To build and run this sample, you must have Visual Studio 2010 installed. Unzip the BulkEmail.zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the BulkEmail.sln solution. Before running the application
 you have to create the database. Use Database.sql file to create the database for this project.</p>
<p>This project uses SQL Server to read the contacts from the database. It includes autocomplete so users can choose one or multiple recipients to send emails to. It also includes HTMLEditor to format your message for better dispaly.</p>
<p>You can extend this application to add multiple threads for sending emails. To be able to send emails, you have to provide you credentials for your gmail account. You are free to edit this project to use one or more email services.</p>
<p>All the required assemblies are included in the project for easier implementation.</p>
<p><em>Screenshot of the Web Application:</em></p>
<p><em><img id="59324" src="59324-bulkemail.png" alt=""></em></p>
<p>&nbsp;</p>
<h1><strong>Code Snipet</strong></h1>
<p>AutoComplete.cs</p>
<p><em></em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Services.aspx" target="_blank" title="Auto generated link to System.Web.Services">System.Web.Services</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Configuration.aspx" target="_blank" title="Auto generated link to System.Configuration">System.Configuration</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a>;&nbsp;
&nbsp;
[WebService(Namespace&nbsp;=&nbsp;<span class="js__string">&quot;http://tempuri.org/&quot;</span>)]&nbsp;
[WebServiceBinding(ConformsTo&nbsp;=&nbsp;WsiProfiles.BasicProfile1_1)]&nbsp;
[System.Web.Script.Services.ScriptService]&nbsp;
public&nbsp;class&nbsp;AutoComplete&nbsp;:&nbsp;WebService&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;AutoComplete()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string[]&nbsp;GetCompletionList(string&nbsp;prefixText,&nbsp;int&nbsp;count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;string&gt;&nbsp;recipients&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;ds&nbsp;=&nbsp;GetContacts();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(DataRow&nbsp;row&nbsp;<span class="js__operator">in</span>&nbsp;ds.Tables[<span class="js__num">0</span>].Rows)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recipients.Add(row[<span class="js__string">&quot;EmailAddress&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;(from&nbsp;r&nbsp;<span class="js__operator">in</span>&nbsp;recipients&nbsp;where&nbsp;r.StartsWith(prefixText,&nbsp;StringComparison.CurrentCultureIgnoreCase)&nbsp;select&nbsp;r).Take(count).ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;DataSet&nbsp;GetContacts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;cs&nbsp;=&nbsp;ConfigurationManager.ConnectionStrings[<span class="js__string">&quot;BulkSMS&quot;</span>].ConnectionString;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlConnection(cs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataAdapter&nbsp;myDataAdapter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlDataAdapter(<span class="js__string">&quot;GetRecipients&quot;</span>,&nbsp;con);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;myDataSet&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataSet(<span class="js__string">&quot;Recipients&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myDataAdapter.Fill(myDataSet,&nbsp;<span class="js__string">&quot;Recipients&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;myDataSet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</em></div>
