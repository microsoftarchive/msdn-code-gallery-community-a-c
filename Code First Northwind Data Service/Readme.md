# Code First Northwind Data Service
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- ADO.NET Entity Framework
- WCF Data Services
- OData
- Entity Framework
## Topics
- ADO.NET Entity Framework
- WCF Data Services
- OData
- Code First
## Updated
- 02/23/2012
## Description

<div class="saveHistory" id="allHistory"></div>
<p>The code-first functionality in Entity Framework 4.1 enables you to create a data model by first creating a set of data classes and then exposing those classes as typed
<a href="http://msdn.microsoft.com/en-us/library/gg696460(v=VS.103).aspx" target="_blank">
DbSet</a> objects accessible from a <a href="http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=VS.103).aspx" target="_blank">
DbContext</a> object. For more information, see <a href="http://msdn.microsoft.com/en-us/library/gg696169(v=VS.103).aspx" target="_blank">
Creating and Mapping a Conceptual Model (Entity Framework 4.1)</a>.</p>
<p>Because <a href="http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=VS.103).aspx" target="_blank">
DbContext</a>&nbsp;provides access&nbsp;to the underlying <a href="http://msdn.microsoft.com/en-us/library/system.data.objects.objectcontext" target="_blank">
ObjectContext</a>, you can use <a href="http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=VS.103).aspx" target="_blank">
DbContext</a> as the data source for a data service using the Entity Framework provider. This sample defines an OData service by creating a code-first data model to access tables in an existing Northwind sample database. This data model is used as the Entity
 Framework-based provider for the data service. This sample shows how to the data service to support an Entity Framework provider based on
<a href="http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=VS.103).aspx" target="_blank">
DbContext</a> instead of the usual typed <a href="http://msdn.microsoft.com/en-us/library/system.data.objects.objectcontext" target="_blank">
ObjectContext</a>. For more information, see the post <a class="internal-link x_x_x_x_x_x_view-post" href="/b/writingdata_services/archive/2011/06/15/entity-framework-4-1-code-first-and-wcf-data-services.aspx">
Entity Framework 4.1: Code First and WCF Data Services</a>.</p>
<h2 class="section">Change History</h2>
<div class="section">
<ul>
<li>9/19/2011
<ul>
<li>Fixed a bug in the Northwind Code First model file (Northwind.cs) </li><li>Changed the DbContext to target a named connection string in the constructor </li><li>Changed the model to remove the IncludeMetadataConvention convention to prevent generation of an EdmMetadata entity set.<span style="font-family:Consolas; color:#2b91af; font-size:x-small"><span style="font-family:Consolas; color:#2b91af; font-size:x-small"><span style="font-family:Consolas; color:#2b91af; font-size:x-small">&nbsp;</span></span></span>
</li><li>Fixed up some incorrect assembly references </li><li>Added a NuGet package for the latest version of EF 4.1 </li></ul>
&nbsp; </li></ul>
</div>
<div>
<h2 class="heading"><span>Prerequisites</span></h2>
<div class="section" id="sectionSection0">
<p>Before running this sample, make sure that the following software is installed:</p>
<ul>
<li class="unordered">Visual Studio 2010 </li><li class="unordered">Entity Framework 4.1, which can be downloaded and installed from the
<a href="http://go.microsoft.com/fwlink/?LinkId=207115" target="_blank">Microsoft Download Center</a>, or from
<a href="http://nuget.org/List/Packages/EntityFramework" target="_blank">NuGet.org</a> (this project also includes the EF 4.1 NuGet package).
</li><li class="unordered">An instance of Microsoft&nbsp;SQL Server.&nbsp;This includes SQL Server Express, which is included in a default installation of Visual Studio.
</li><li class="unordered">The Northwind sample database. To download this sample database, see the download page,
<a href="http://go.microsoft.com/fwlink/?linkid=24758" target="_blank">Sample Databases for SQL Server</a>.
<blockquote>Note: if you don't have a Northwind database attached to the default SQL Server Express instance, Code First will generate a new one, but it will be initialized with no data.</blockquote>
</li></ul>
</div>
</div>
<h2 class="heading"><span>Building and Accessing the Sample Data Service</span></h2>
<p class="section">Use the following procedures to configure, build, and access the sample data service.</p>
<div class="section">
<div><span><strong>To configure the data service and build the sample</strong></span></div>
<div class="subSection">
<ol class="ordered">
<li>
<p>Unzip the sample files on the local computer.</p>
</li><li>
<p>In Visual Studio, open the CodeFirstNorthwind.sln solution file in the root directory of the sample.</p>
</li><li>
<p>In Solution Explorer, expand <strong>References</strong> and locate the entry for EntityFramework.</p>
<p>If this reference is indicated with a yellow triangle because the reference assembly cannot currently be located, remove and re-add a reference to the installed Entity Framework 4.1 assembly.</p>
</li><li>
<p>(Optional) In the Solution Explorer, open the Web.config file and change the <em>
data source</em> parameter in the <strong>NorthwindEntities</strong> connection string to the name of the SQL Server instance running the Northwind database.</p>
<p>Do this only if Northwind is running on a SQL Server instance other than the default SQL Server Express instance.</p>
</li><li>
<p>Build the sample.</p>
</li></ol>
</div>
</div>
<div class="section"><span><strong>To run the Northwind data service sample</strong></span></div>
<div class="subSection">
<ol class="ordered">
<li>
<p>(Optional) In Internet Explorer, from the <strong>Tools</strong> menu, select <strong>
Internet Options</strong>, click the <strong>Content</strong> tab, click <strong>
Settings</strong>, and clear <strong>Turn on feed viewing</strong>.</p>
<p>This makes sure that feed reading is disabled. If you do not disable this functionality, then the Web browser will treat the returned AtomPub encoded document as an XML feed instead of displaying the raw XML data.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>If your browser cannot display the feed as raw XML data, you should still be able to view the feed as the source code for the page.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</div>
</li><li>
<p>With the project loaded in Visual Studio, press F5.</p>
<p>A new browser window is opened and the root URI of the service is displayed.</p>
</li><li>
<p>In Visual Studio, press the F5 key to start debugging the application.</p>
</li><li>
<p>Open a Web browser on the local computer. In the address bar, enter the following URI:</p>
<div class="code"><span style="font-family:courier new,courier">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre>http://localhost:12345/northwind.svc</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This returns the default service document, which contains a list of entity sets that are exposed by this data service.</p>
</li><li>
<p>In the address bar of your Web browser, enter the following URI:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre><span style="font-family:courier new,courier">http://localhost:12345/northwind.svc/Customers</span></pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This returns a set of all customers in the Northwind sample database.</p>
</li><li>
<p>In the address bar of your Web browser, enter the following URI:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre><span style="font-family:courier new,courier">http://localhost:12345/northwind.svc/Customers('ALFKI')</span></pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This returns an entity instance for the specific customer, <code>ALFKI</code>.</p>
</li><li>
<p>In the address bar of your Web browser, enter the following URI:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre><span style="font-family:courier new,courier">http://localhost:12345/northwind.svc/Customers('ALFKI')/Orders</span></pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This traverses the relationship between customers and orders to return a set of all orders for the specific customer
<code>ALFKI</code>.</p>
</li><li>
<p>In the address bar of your Web browser, enter the following URI:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre><span style="font-family:courier new,courier">http://localhost:12345/northwind.svc/Customers('ALFKI')/Orders?$filter=OrderID eq 10643</span></pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This filters orders that belong to the specific customer <code>ALFKI</code> so that only a specific order is returned based on the supplied
<code>OrderID</code> value.</p>
</li></ol>
</div>
