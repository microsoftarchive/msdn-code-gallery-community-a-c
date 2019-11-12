# Advanced Search using JQuery DataTables in ASP.NET MVC
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
- Javascript
- Entity Framework
- ASP.NET MVC 5
- JQuery DataTables
## Topics
- C#
- ASP.NET MVC
- ASP.NET MVC 5
- JQuery DataTables
- Advanced Search
## Updated
- 06/20/2017
## Description

<h1>Introduction</h1>
<p><em><em>This sample demonstrates How to Implement <strong>Advanced Search</strong> Functionality in an existing
<strong>Grid </strong>using <strong>JQuery DataTables</strong> in <strong>ASP.NET MVC 5</strong></em></em></p>
<h1>Database Script</h1>
<p>you can download the datbase script from <a href="https://www.codeproject.com/KB/aspnet/1170086/Sql_Script.zip">
this link location</a>.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><em><em>There is file named&nbsp;<strong>dbscript.txt,</strong>&nbsp;you would need to create database with reqired tables and some data in the tables using the script which can be found in the solution, and after that you will need to modify the connection
 string of the database in the&nbsp;<strong>web.config</strong>&nbsp;which will be used by
<strong>Entity Framework</strong> to query records :</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;add&nbsp;name=<span class="cs__string">&quot;DefaultConnection&quot;</span>&nbsp;connectionString=<span class="cs__string">&quot;Data&nbsp;Source=(localdb)\MSSQLLocalDB;Initial&nbsp;Catalog=TrialAssignment-Joseph;Integrated&nbsp;Security=True;MultipleActiveResultSets=true&quot;</span>&nbsp;providerName=<span class="cs__string">&quot;System.Data.SqlClient&quot;</span>&nbsp;/&gt;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</em></em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>At the end of this post we will have a working grid with server side advanced search, pagination, filtering and sorting and after implementing all of this, our application will look like:</span></p>
<p><span><img id="170179" src="170179-image_1.png" alt="" width="1434" height="797"><br>
</span></p>
<p><span>In<strong> Solution Explorer</strong>, Expand the&nbsp;</span><em>Views</em><span>&nbsp;folder, then again expand the&nbsp;</span><strong><em>Asset</em></strong><span>&nbsp;folder and open the&nbsp;</span><strong><em>Index.cshtml</em></strong><span>&nbsp;file,
 we will add the HTML for the Advanced Search button that will appear above the grid. Add the following HTML in the view:</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;button</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-default&nbsp;btn-md&quot;</span><span class="html__attr_name">data-toggle</span>=<span class="html__attr_value">&quot;modal&quot;</span><span class="html__attr_name">data-target</span>=<span class="html__attr_value">&quot;#advancedSearchModal&quot;</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;advancedsearch-button&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;span</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;glyphicon&nbsp;glyphicon-search&quot;</span><span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Advanced&nbsp;Search&nbsp;
<span class="html__tag_end">&lt;/button&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>If you note, we have some new attributes in the button code, you don't need to worry that those are for bootstrap modal, as clicking the button will open a Modal dialog, and user would be able to select the search criteria
 and search for results. The&nbsp;</span><strong><code>data-toggle=&quot;modal&quot;</code></strong><span>&nbsp;attribute dictates that this button will toggle a Modal Dialog and&nbsp;</span><strong><code>data-target=&quot;#advancedSearchModal&quot;</code></strong><span>&nbsp;specifies
 the HTML element of the page which would be displayed as Modal Dialog.</span><br>
<span>After adding the above HTML code in the&nbsp;</span><strong><em>Index.cshtml</em></strong><span>, the view will have the following code in it:</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-12&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel&nbsp;panel-primary&nbsp;list-panel&quot;</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;list-panel&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel-heading&nbsp;list-panel-heading&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;h1</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel-title&nbsp;list-panel-title&quot;</span><span class="html__tag_start">&gt;</span>Assets<span class="html__tag_end">&lt;/h1&gt;</span><span class="html__tag_start">&lt;button</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-default&nbsp;btn-md&quot;</span><span class="html__attr_name">data-toggle</span>=<span class="html__attr_value">&quot;modal&quot;</span><span class="html__attr_name">data-target</span>=<span class="html__attr_value">&quot;#advancedSearchModal&quot;</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;advancedsearch-button&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;span</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;glyphicon&nbsp;glyphicon-search&quot;</span><span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Advanced&nbsp;Search&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/button&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel-body&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;table</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;assets-data-table&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;table&nbsp;table-striped&nbsp;table-bordered&quot;</span><span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;width:100%;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_end">&lt;/table&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
@section&nbsp;Scripts&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;script</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="js__statement">var</span>&nbsp;assetListVM;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;assetListVM&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt:&nbsp;null,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;init:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt&nbsp;=&nbsp;$(<span class="js__string">'#assets-data-table'</span>).DataTable(<span class="js__brace">{</span><span class="js__string">&quot;serverSide&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;processing&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;ajax&quot;</span>:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;url&quot;</span>:&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;@Url.Action(&quot;</span>Get<span class="js__string">&quot;,&quot;</span>Asset<span class="js__string">&quot;)&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;columns&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Bar&nbsp;Code&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;BarCode&quot;</span>,&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Manufacturer&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;Manufacturer&quot;</span>,&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Model&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;ModelNumber&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Building&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;Building&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Room&nbsp;No&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;RoomNo&quot;</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Quantity&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;Quantity&quot;</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lengthMenu&quot;</span>:&nbsp;[[<span class="js__num">10</span>,&nbsp;<span class="js__num">25</span>,&nbsp;<span class="js__num">50</span>,&nbsp;<span class="js__num">100</span>],&nbsp;[<span class="js__num">10</span>,&nbsp;<span class="js__num">25</span>,&nbsp;<span class="js__num">50</span>,&nbsp;<span class="js__num">100</span>]],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;initialize&nbsp;the&nbsp;datatables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;assetListVM.init();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>We will also need to create a&nbsp;</span><code>ViewModel</code><span>&nbsp;class which will be used for posting the search criteria to server side which will be controller action for performing the search. Let's add the&nbsp;</span><code>ViewModel</code><span>&nbsp;then.
 Following is the code for the&nbsp;</span><strong><code>AdvancedSearchViewModel</code>&nbsp;</strong><span>class:</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;GridExampleMVC.Models&nbsp;
{&nbsp;
&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;AdvancedSearchViewModel&nbsp;
&nbsp;{&nbsp;
&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Facility-Site&quot;</span>)]&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;Guid&nbsp;FacilitySite&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Main-Location&nbsp;(Building)&quot;</span>)]&nbsp;
&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Building&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Manufacturer&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Status&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;SelectList&nbsp;FacilitySiteList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;SelectList&nbsp;BuildingList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;SelectList&nbsp;ManufacturerList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;SelectList&nbsp;StatusList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<div class="endscriptcode"><span>Navigate to&nbsp;</span><strong><em>Controllers</em></strong><span>&nbsp;folder and expand it, and open the&nbsp;</span><strong><em>AssetController.cs</em></strong><span>&nbsp;file, we will add a new get action that will be
 used to populate the&nbsp;</span><strong><code>AdvancedSeachViewModel</code>&nbsp;</strong><span>and we will be setting the&nbsp;</span><code>SelectList</code><span>&nbsp;properties with data from their respective data sources for populating the Dropdown List
 controls on the advanced search modal popup:</span></div>
<div class="endscriptcode"><span><span><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[HttpGet]&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;AdvancedSearch()&nbsp;
{&nbsp;
&nbsp;var&nbsp;advancedSearchViewModel&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AdvancedSearchViewModel();&nbsp;
&nbsp;
&nbsp;advancedSearchViewModel.FacilitySiteList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectList(DbContext.FacilitySites&nbsp;
&nbsp;.Where(facilitySite&nbsp;=&gt;&nbsp;facilitySite.IsActive&nbsp;&amp;&amp;&nbsp;!facilitySite.IsDeleted)&nbsp;
&nbsp;.Select(x&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;x.FacilitySiteID,&nbsp;x.FacilityName&nbsp;}),&nbsp;
&nbsp;<span class="cs__string">&quot;FacilitySiteID&quot;</span>,&nbsp;
&nbsp;<span class="cs__string">&quot;FacilityName&quot;</span>);&nbsp;
&nbsp;
&nbsp;advancedSearchViewModel.BuildingList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectList(DbContext.Assets&nbsp;
&nbsp;.GroupBy(x&nbsp;=&gt;&nbsp;x.Building)&nbsp;
&nbsp;.Where(x&nbsp;=&gt;&nbsp;x.Key&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;!x.Key.Equals(<span class="cs__keyword">string</span>.Empty))&nbsp;
&nbsp;.Select(x&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;Building&nbsp;=&nbsp;x.Key&nbsp;}),&nbsp;
&nbsp;<span class="cs__string">&quot;Building&quot;</span>,&nbsp;
&nbsp;<span class="cs__string">&quot;Building&quot;</span>);&nbsp;
&nbsp;
&nbsp;advancedSearchViewModel.ManufacturerList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectList(DbContext.Assets&nbsp;
&nbsp;.GroupBy(x&nbsp;=&gt;&nbsp;x.Manufacturer)&nbsp;
&nbsp;.Where(x&nbsp;=&gt;&nbsp;x.Key&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;!x.Key.Equals(<span class="cs__keyword">string</span>.Empty))&nbsp;
&nbsp;.Select(x&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;Manufacturer&nbsp;=&nbsp;x.Key&nbsp;}),&nbsp;
&nbsp;<span class="cs__string">&quot;Manufacturer&quot;</span>,&nbsp;
&nbsp;<span class="cs__string">&quot;Manufacturer&quot;</span>);&nbsp;
&nbsp;
&nbsp;advancedSearchViewModel.StatusList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectList(<span class="cs__keyword">new</span>&nbsp;List&lt;SelectListItem&gt;&nbsp;
&nbsp;{&nbsp;
&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectListItem&nbsp;{&nbsp;Text=<span class="cs__string">&quot;Issued&quot;</span>,Value=<span class="cs__keyword">bool</span>.TrueString},&nbsp;
&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectListItem&nbsp;{&nbsp;Text=<span class="cs__string">&quot;Not&nbsp;Issued&quot;</span>,Value&nbsp;=&nbsp;<span class="cs__keyword">bool</span>.FalseString}&nbsp;
&nbsp;},&nbsp;
&nbsp;<span class="cs__string">&quot;Value&quot;</span>,&nbsp;
&nbsp;<span class="cs__string">&quot;Text&quot;</span>&nbsp;
&nbsp;);&nbsp;
&nbsp;
&nbsp;<span class="cs__keyword">return</span>&nbsp;View(<span class="cs__string">&quot;_AdvancedSearchPartial&quot;</span>,&nbsp;advancedSearchViewModel);&nbsp;
}</pre>
</div>
</div>
</div>
</span></span></span></div>
</span></div>
<p>&nbsp;</p>
<p>Our&nbsp;<code>AdvancedSearch</code>&nbsp;post action will be almost the same implementation wise as was the implementation of Search action for Server Side Sort, Filter and Paging one, but there will be a small change in action signatures for&nbsp;<code>AdvancedSearch</code>,
 it will now take 2 parameters which is quite obvious, one for maintaining the&nbsp;<code>DataTables</code>state which was already there before as well and the new one will be the instance of&nbsp;<code>AdvancedSearchViewModel</code><strong>&nbsp;</strong>class
 which will have the state of controls of Advanced Search Modal popup.</p>
<p>We need to update the&nbsp;<code>SearchAssets<strong>&nbsp;</strong>private</code>&nbsp;method which we created in the previous post about Grid View Server Side Processing, add the advanced searching database logic in this method, so this method will not
 take another parameter which is we know instance of&nbsp;<code>AdvancedSearchViewModel</code>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;IQueryable&lt;Asset&gt;&nbsp;SearchAssets(IDataTablesRequest&nbsp;requestModel,&nbsp;&nbsp;
AdvancedSearchViewModel&nbsp;searchViewModel,&nbsp;IQueryable&lt;Asset&gt;&nbsp;query)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Apply&nbsp;filters</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(requestModel.Search.Value&nbsp;!=&nbsp;<span class="cs__keyword">string</span>.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;requestModel.Search.Value.Trim();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(p&nbsp;=&gt;&nbsp;p.Barcode.Contains(<span class="cs__keyword">value</span>)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Manufacturer.Contains(<span class="cs__keyword">value</span>)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.ModelNumber.Contains(<span class="cs__keyword">value</span>)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Building.Contains(<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*****&nbsp;Advanced&nbsp;Search&nbsp;Starts&nbsp;******/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(searchViewModel.FacilitySite&nbsp;!=&nbsp;Guid.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(x&nbsp;=&gt;&nbsp;x.FacilitySiteID&nbsp;==&nbsp;searchViewModel.FacilitySite);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(searchViewModel.Building&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(x&nbsp;=&gt;&nbsp;x.Building&nbsp;==&nbsp;searchViewModel.Building);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(searchViewModel.Manufacturer&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(x&nbsp;=&gt;&nbsp;x.Manufacturer&nbsp;==&nbsp;searchViewModel.Manufacturer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(searchViewModel.Status&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;Issued&nbsp;=&nbsp;<span class="cs__keyword">bool</span>.Parse(searchViewModel.Status);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(x&nbsp;=&gt;&nbsp;x.Issued&nbsp;==&nbsp;Issued);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*****&nbsp;Advanced&nbsp;Search&nbsp;Ends&nbsp;******/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;filteredCount&nbsp;=&nbsp;query.Count();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Sort</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sortedColumns&nbsp;=&nbsp;requestModel.Columns.GetSortedColumns();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;orderByString&nbsp;=&nbsp;String.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;column&nbsp;<span class="cs__keyword">in</span>&nbsp;sortedColumns)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;orderByString&nbsp;&#43;=&nbsp;orderByString&nbsp;!=&nbsp;String.Empty&nbsp;?&nbsp;<span class="cs__string">&quot;,&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;orderByString&nbsp;&#43;=&nbsp;(column.Data)&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(column.SortDirection&nbsp;==&nbsp;Column.OrderDirection.Ascendant&nbsp;?&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;asc&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;&nbsp;desc&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.OrderBy(orderByString&nbsp;==&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>.Empty&nbsp;?&nbsp;<span class="cs__string">&quot;BarCode&nbsp;asc&quot;</span>&nbsp;:&nbsp;orderByString);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;query;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Now update the action as well which is called for handles the grid server side processing to accept the advanced search parameter as well and pass them to the&nbsp;<code>SearchAssets</code>&nbsp;method for more granular filtering,
 here is the updated code of the action:</div>
<p>&nbsp;</p>
<p><span>&nbsp;</span></p>
<div class="endscriptcode"><span>
<div class="endscriptcode"><span><span><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Get([ModelBinder(<span class="cs__keyword">typeof</span>(DataTablesBinder))]&nbsp;&nbsp;
IDataTablesRequest&nbsp;requestModel,&nbsp;AdvancedSearchViewModel&nbsp;searchViewModel)&nbsp;
&nbsp;{&nbsp;
&nbsp;IQueryable&lt;Asset&gt;&nbsp;query&nbsp;=&nbsp;DbContext.Assets;&nbsp;
&nbsp;var&nbsp;totalCount&nbsp;=&nbsp;query.Count();&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//&nbsp;searching&nbsp;and&nbsp;sorting</span>&nbsp;
&nbsp;query&nbsp;=&nbsp;SearchAssets(requestModel,&nbsp;searchViewModel,query);&nbsp;
&nbsp;var&nbsp;filteredCount&nbsp;=&nbsp;query.Count();&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//&nbsp;Paging</span>&nbsp;
&nbsp;query&nbsp;=&nbsp;query.Skip(requestModel.Start).Take(requestModel.Length);&nbsp;
&nbsp;&nbsp;
&nbsp;var&nbsp;data&nbsp;=&nbsp;query.Select(asset&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;
&nbsp;{&nbsp;
&nbsp;AssetID&nbsp;=&nbsp;asset.AssetID,&nbsp;
&nbsp;BarCode&nbsp;=&nbsp;asset.Barcode,&nbsp;
&nbsp;Manufacturer&nbsp;=&nbsp;asset.Manufacturer,&nbsp;
&nbsp;ModelNumber&nbsp;=&nbsp;asset.ModelNumber,&nbsp;
&nbsp;Building&nbsp;=&nbsp;asset.Building,&nbsp;
&nbsp;RoomNo&nbsp;=&nbsp;asset.RoomNo,&nbsp;
&nbsp;Quantity&nbsp;=&nbsp;asset.Quantity&nbsp;
&nbsp;}).ToList();&nbsp;
&nbsp;
&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(<span class="cs__keyword">new</span>&nbsp;DataTablesResponse&nbsp;
&nbsp;(requestModel.Draw,&nbsp;data,&nbsp;filteredCount,&nbsp;totalCount),&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
}</pre>
</div>
</div>
</div>
</span></span></span></div>
</span></div>
<p>&nbsp;</p>
<p>Create a new Partial View named &nbsp;<em>_AdvancedSearchPartial.cshtml</em>,&nbsp;open the file&nbsp;<em>_AdvancedSearchPartial.cshtml</em>&nbsp;and add the HTML in the partial view that will be displayed as modal popup when the user will click the Advanced
 Search button that we created in the&nbsp;<em>Index.cshtml</em>&nbsp;view, following the code of the advanced search partial view:</p>
<p><span>&nbsp;</span></p>
<div class="endscriptcode"><span>
<div class="endscriptcode"><span><span><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;TA_UM.ViewModels.AdvancedSearchViewModel&nbsp;
@{&nbsp;
&nbsp;Layout&nbsp;=&nbsp;null;&nbsp;
}&nbsp;
&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal&nbsp;fade&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;advancedSearchModal&quot;</span>&nbsp;&nbsp;
<span class="html__attr_name">tabindex</span>=<span class="html__attr_value">&quot;-1&quot;</span>&nbsp;<span class="html__attr_name">role</span>=<span class="html__attr_value">&quot;dialog&quot;</span>&nbsp;&nbsp;
<span class="html__attr_name">aria-labelledby</span>=<span class="html__attr_value">&quot;myModalLabel&quot;</span>&nbsp;&nbsp;
<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">data-backdrop</span>=<span class="html__attr_value">&quot;static&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal-dialog&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal-content&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal-header&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;h4</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal-title&quot;</span><span class="html__tag_start">&gt;</span>Advanced&nbsp;Search<span class="html__tag_end">&lt;/h4&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;@using&nbsp;(Html.BeginForm(&quot;Get&quot;,&nbsp;&quot;Asset&quot;,&nbsp;&nbsp;
&nbsp;FormMethod.Get,&nbsp;new&nbsp;{&nbsp;id&nbsp;=&nbsp;&quot;frmAdvancedSearch&quot;,&nbsp;&nbsp;
&nbsp;@class&nbsp;=&nbsp;&quot;form-horizontal&quot;,&nbsp;role&nbsp;=&nbsp;&quot;form&quot;&nbsp;}))&nbsp;
&nbsp;{&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal-body&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-horizontal&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;hr</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.FacilitySite,&nbsp;&nbsp;
&nbsp;htmlAttributes:&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;control-label&nbsp;col-md-3&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-8&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dropdown&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.DropDownListFor(model&nbsp;=&gt;&nbsp;model.FacilitySite,&nbsp;&nbsp;
&nbsp;Model.FacilitySiteList,&nbsp;&quot;Any&quot;,&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;form-control&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Building,&nbsp;&nbsp;
&nbsp;htmlAttributes:&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;control-label&nbsp;col-md-3&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-8&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dropdown&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.DropDownListFor(model&nbsp;=&gt;&nbsp;model.Building,&nbsp;&nbsp;
&nbsp;Model.BuildingList,&nbsp;&quot;Any&quot;,&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;form-control&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Manufacturer,&nbsp;&nbsp;
&nbsp;htmlAttributes:&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;control-label&nbsp;col-md-3&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-8&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dropdown&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.DropDownListFor(model&nbsp;=&gt;&nbsp;model.Manufacturer,&nbsp;&nbsp;
&nbsp;Model.ManufacturerList,&nbsp;&quot;Any&quot;,&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;form-control&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Status,&nbsp;&nbsp;
&nbsp;htmlAttributes:&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;control-label&nbsp;col-md-3&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-8&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dropdown&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;@Html.DropDownListFor(model&nbsp;=&gt;&nbsp;model.Status,&nbsp;&nbsp;
&nbsp;Model.StatusList,&nbsp;&quot;Both&quot;,&nbsp;new&nbsp;{&nbsp;@class&nbsp;=&nbsp;&quot;form-control&quot;&nbsp;})&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;modal-footer&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;btnPerformAdvancedSearch&quot;</span>&nbsp;&nbsp;
&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-default&nbsp;btn-success&quot;</span>&nbsp;&nbsp;
&nbsp;<span class="html__attr_name">data-dismiss</span>=<span class="html__attr_value">&quot;modal&quot;</span><span class="html__tag_start">&gt;</span>Search<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;btnCancel&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span>&nbsp;&nbsp;
&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-default&quot;</span>&nbsp;<span class="html__attr_name">data-dismiss</span>=<span class="html__attr_value">&quot;modal&quot;</span><span class="html__tag_start">&gt;</span>Cancel<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;}&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Finally, open the&nbsp;</span><strong><em>Index.cshtml</em></strong><span>&nbsp;located in&nbsp;</span><strong>Views &gt;&gt; Asset</strong><span>&nbsp;and call the&nbsp;</span><code>AdvancedSearch</code><span>&nbsp;get
 action before the&nbsp;</span><strong><code>&lt;span style=&quot;background-color: yellow&quot;&gt;@section Scripts&lt;/span&gt;</code></strong><span>&nbsp;start for adding the Advanced Search Modal popup HTML in the browser which will be displayed when button is triggered,
 another thing to note is that we have not specified anywhere about how the dropdown selected values will be posted with&nbsp;</span><code>DataTables</code><span>&nbsp;server side processing in the same action, though we have added the parameter in action but
 we haven't changed anything specific to that in View, we will have to update the jquery datatables initialization code for that, and specify the values for posting to the&nbsp;</span><code>AdvancedSearchViewModel</code><strong>&nbsp;</strong><span>using data
 property for which we would have to define the property, so add the following code just after the line where we are specifying URL for datatable which is&nbsp;</span><strong><span>&quot;url&quot;</span>:&nbsp;<span>&quot;</span><span>@</span>Url.Action(<span>&quot;Get&quot;,&quot;Asset&quot;</span>)<span>&quot;</span></strong><span>,
 and after adding that final Index view, the code should be:</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;data.FacilitySite&nbsp;=&nbsp;$(<span class="js__string">&quot;#FacilitySite&quot;</span>).val();&nbsp;
&nbsp;data.Building&nbsp;=&nbsp;$(<span class="js__string">&quot;#Building&quot;</span>).val();&nbsp;
&nbsp;data.Manufacturer&nbsp;=&nbsp;$(<span class="js__string">&quot;#Manufacturer&quot;</span>).val();&nbsp;
&nbsp;data.Status&nbsp;=&nbsp;$(<span class="js__string">&quot;#Status&quot;</span>).val();&nbsp;
&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Now build the project, and run it in browser to see the working server side Advanced Search using JQuery datatables and with server side filtering, paging, and sorting as well in action.</span></div>
<br>
</span></div>
<br>
</span></span></span></div>
<br>
</span></div>
