# BindingSource Filter with Starts, contains, ends with and case sensitive options
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Data Binding
- SQL Server
- DataTable
- Filter expression
- BindingSource
- dataview
## Topics
- Windows Forms
- Data filter
- BindingSource filtering
## Updated
- 03/10/2018
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample focuses on filtering a BindingSource component where it&rsquo;s data source is a DataTable rather than filtering from the Filter property of a BindingSource. The reason is that many developers writing window
 form applications use a BindingSource in tangent with a TableAdapter or simply using a DataSet or DataTable and need case or case insensitive capabilities for filter where the BindingSource component filter does not have the ability to filter with case insensitive
 casing.</span></p>
<p><span style="font-size:small">To provide this I created a language extension library which has extensions for a BindingSource with a DataSource set to a DataTable. There are methods focus on LIKE conditions for starts-with, ends-with and contains with one
 for a general equal, all provide an option for casing.</span></p>
<p><span style="font-size:small">There is a language extensions library and a class project to load a Customers table where the class project would be for a production project yet only has enough functionality to load all of the data so we can use a unit test
 (also included) to test the extension methods against live data.</span></p>
<p><span style="font-size:small">Many developers will create extension methods or functions in a class or write the functions in the form they will use the methods. I will not knock this but highly advocate using a class project to store the methods and optionally
 use extension methods as I have to allow for method based programming an allow these methods to be used in other applications.</span></p>
<p><span style="font-size:small">There is no project with a user interface on purpose. First off many developers will more likely than not code directly in the form and when things go wrong have no clue how to fix the issues. If you start with a unit test project
 and have small test to test all scenarios that a user might enter into say Textbox controls to filter then there is less of a chance for issues in your actual project.</span></p>
<p><span style="font-size:small">The unit test supplied goes through most common filtering, I kept things simple, no complex/compound filtering as we can in that case end up with a great deal of different filters. I will leave that up to you.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">How were the unit test written? I selected a generic table that could be in any application. Then in SQL-Server Management Studio ran SQL SELECT statements with case sensitive and case insensitive queries. Here is an example
 of one of the queries where I indicate that the query should be case sensitive.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">SELECT  CustomerIdentifier ,
        CompanyName ,
        ContactName ,
        ContactTitle ,
        City ,
        PostalCode ,
        Country
FROM    Customers
WHERE   ContactTitle LIKE '%Manager'
        OR ContactTitle LIKE 'sales%' COLLATE Latin1_General_CS_AS;</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">SELECT</span>&nbsp;&nbsp;<span class="sql__id">CustomerIdentifier</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CompanyName</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">ContactName</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">ContactTitle</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">City</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">PostalCode</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Country</span>&nbsp;
<span class="sql__keyword">FROM</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>&nbsp;
<span class="sql__keyword">WHERE</span>&nbsp;&nbsp;&nbsp;<span class="sql__id">ContactTitle</span>&nbsp;<span class="sql__keyword">LIKE</span>&nbsp;<span class="sql__string">'%Manager'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">OR</span>&nbsp;<span class="sql__id">ContactTitle</span>&nbsp;<span class="sql__keyword">LIKE</span>&nbsp;<span class="sql__string">'sales%'</span>&nbsp;<span class="sql__keyword">COLLATE</span>&nbsp;<span class="sql__id">Latin1_General_CS_AS</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Then write a unit test against the above query then followed that up with another test without&nbsp;COLLATE Latin1_General_CS_AS.&nbsp; Here are two test used for the above.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestMethod]
public void FreeForm_CaseSensitive_OnBoth_Conditions()
{
    var bsContact = new BindingSource();
    var ops = new DataOperations();
    bsContact.DataSource = ops.GetAll();
    bsContact.RowFilterFreeForm(&quot;ContactTitle LIKE '%Manager' OR ContactTitle LIKE 'Sales%'&quot;, true);
    Assert.IsTrue(bsContact.Count == 62, &quot;Expected 62 records&quot;);
}
/// &lt;summary&gt;
/// Deviation from above, note in the above test we had Sales case sensitive, here we kept case sensitive
/// but asked for sales which does not match what is in the table.
/// &lt;/summary&gt;
[TestMethod]
public void FreeForm_CaseSensitive_OnBoth_Conditions_LastField_NotExact()
{
    var bsContact = new BindingSource();
    var ops = new DataOperations();
    bsContact.DataSource = ops.GetAll();
    bsContact.RowFilterFreeForm(&quot;ContactTitle LIKE '%Manager' OR ContactTitle LIKE 'sales%'&quot;, true);
    Assert.IsTrue(bsContact.Count == 33, &quot;Expected 33 records&quot;);
}</pre>
<div class="preview">
<pre class="js">[TestMethod]&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;FreeForm_CaseSensitive_OnBoth_Conditions()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;bsContact&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ops&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bsContact.DataSource&nbsp;=&nbsp;ops.GetAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bsContact.RowFilterFreeForm(<span class="js__string">&quot;ContactTitle&nbsp;LIKE&nbsp;'%Manager'&nbsp;OR&nbsp;ContactTitle&nbsp;LIKE&nbsp;'Sales%'&quot;</span>,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(bsContact.Count&nbsp;==&nbsp;<span class="js__num">62</span>,&nbsp;<span class="js__string">&quot;Expected&nbsp;62&nbsp;records&quot;</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Deviation&nbsp;from&nbsp;above,&nbsp;note&nbsp;in&nbsp;the&nbsp;above&nbsp;test&nbsp;we&nbsp;had&nbsp;Sales&nbsp;case&nbsp;sensitive,&nbsp;here&nbsp;we&nbsp;kept&nbsp;case&nbsp;sensitive</span>&nbsp;
<span class="js__sl_comment">///&nbsp;but&nbsp;asked&nbsp;for&nbsp;sales&nbsp;which&nbsp;does&nbsp;not&nbsp;match&nbsp;what&nbsp;is&nbsp;in&nbsp;the&nbsp;table.</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
[TestMethod]&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;FreeForm_CaseSensitive_OnBoth_Conditions_LastField_NotExact()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;bsContact&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ops&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bsContact.DataSource&nbsp;=&nbsp;ops.GetAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bsContact.RowFilterFreeForm(<span class="js__string">&quot;ContactTitle&nbsp;LIKE&nbsp;'%Manager'&nbsp;OR&nbsp;ContactTitle&nbsp;LIKE&nbsp;'sales%'&quot;</span>,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(bsContact.Count&nbsp;==&nbsp;<span class="js__num">33</span>,&nbsp;<span class="js__string">&quot;Expected&nbsp;33&nbsp;records&quot;</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Here we have the extensions and test in the Visual Studio solution</div>
<div class="endscriptcode"><img id="180542" src="180542-1.jpg" alt="" width="473" height="613"></div>
</span></div>
<h1 class="endscriptcode">To run the code</h1>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">You will need to have SQL-Server installed and create the database using the supplied script located in Operations project.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode"><span style="font-size:small; color:#ff0000">UPDATE</span></h1>
<div class="endscriptcode"><span style="font-size:small">Added an overloaded version of RowFilter using an enum</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public enum FilterCondition 
{
    StartsWith,
    Contains,
    EndsWith
}</pre>
<div class="preview">
<pre class="js">public&nbsp;enum&nbsp;FilterCondition&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StartsWith,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Contains,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EndsWith&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The extension.</span>&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Provides filter for starts-with, contains or ends-with
/// &lt;/summary&gt;
/// &lt;param name=&quot;pSender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;pField&quot;&gt;Field to apply filter on&lt;/param&gt;
/// &lt;param name=&quot;pValue&quot;&gt;Value for filter&lt;/param&gt;
/// &lt;param name=&quot;pCondition&quot;&gt;Type of filter&lt;/param&gt;
/// &lt;param name=&quot;pCaseSensitive&quot;&gt;Filter should be case or case in-sensitive&lt;/param&gt;
public static void RowFilter(this BindingSource pSender, string pField, string pValue, 
    FilterCondition pCondition, bool pCaseSensitive = false)
{
    switch (pCondition)
    {
        case FilterCondition.StartsWith:
            pSender.RowFilterStartsWith(pField, pValue, pCaseSensitive);
            break;
        case FilterCondition.Contains:
            pSender.RowFilterContains(pField, pValue, pCaseSensitive);
            break;
        case FilterCondition.EndsWith:
            pSender.RowFilterEndsWith(pField, pValue, pCaseSensitive);
            break;
        default:
            break;
    }
}</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Provides&nbsp;filter&nbsp;for&nbsp;starts-with,&nbsp;contains&nbsp;or&nbsp;ends-with</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pSender&quot;&gt;&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pField&quot;&gt;Field&nbsp;to&nbsp;apply&nbsp;filter&nbsp;on&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pValue&quot;&gt;Value&nbsp;for&nbsp;filter&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pCondition&quot;&gt;Type&nbsp;of&nbsp;filter&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pCaseSensitive&quot;&gt;Filter&nbsp;should&nbsp;be&nbsp;case&nbsp;or&nbsp;case&nbsp;in-sensitive&lt;/param&gt;</span>&nbsp;
public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;RowFilter(<span class="js__operator">this</span>&nbsp;BindingSource&nbsp;pSender,&nbsp;string&nbsp;pField,&nbsp;string&nbsp;pValue,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FilterCondition&nbsp;pCondition,&nbsp;bool&nbsp;pCaseSensitive&nbsp;=&nbsp;false)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">switch</span>&nbsp;(pCondition)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;FilterCondition.StartsWith:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pSender.RowFilterStartsWith(pField,&nbsp;pValue,&nbsp;pCaseSensitive);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;FilterCondition.Contains:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pSender.RowFilterContains(pField,&nbsp;pValue,&nbsp;pCaseSensitive);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;FilterCondition.EndsWith:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pSender.RowFilterEndsWith(pField,&nbsp;pValue,&nbsp;pCaseSensitive);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span style="font-size:small">One of the test.</span></div>
</div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestMethod]
public void ContactTitleEndsWith_CaseSensitive_OverLoad_Good()
{
    var bsContact = new BindingSource();
    var ops = new DataOperations();
    bsContact.DataSource = ops.GetAll();
    bsContact.RowFilter(&quot;ContactTitle&quot;, &quot;Manager&quot;, Extensions.FilterCondition.EndsWith, true);
    Assert.IsTrue(bsContact.Count == 33, &quot;Expected 33 records&quot;);
}</pre>
<div class="preview">
<pre class="csharp">[TestMethod]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ContactTitleEndsWith_CaseSensitive_OverLoad_Good()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bsContact&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ops&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bsContact.DataSource&nbsp;=&nbsp;ops.GetAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bsContact.RowFilter(<span class="cs__string">&quot;ContactTitle&quot;</span>,&nbsp;<span class="cs__string">&quot;Manager&quot;</span>,&nbsp;Extensions.FilterCondition.EndsWith,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(bsContact.Count&nbsp;==&nbsp;<span class="cs__number">33</span>,&nbsp;<span class="cs__string">&quot;Expected&nbsp;33&nbsp;records&quot;</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<div class="endscriptcode"><span style="font-size:small">EDIT: Source code has been</span></div>
<div class="endscriptcode">
<ul>
<li><span style="font-size:x-small">Updated to Visual Studio 2017</span> </li><li><span style="font-size:x-small">Added new extensions for filtering</span> </li><li><span style="font-size:x-small">Added a extension method to escape apostrophes in filter values</span>
</li></ul>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
