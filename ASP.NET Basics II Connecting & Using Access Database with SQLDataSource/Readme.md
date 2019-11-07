# ASP.NET Basics II: Connecting & Using Access Database with SQLDataSource
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Data Binding
- ASP.NET
- Data Access
- OLEDB
- MS Access
## Topics
- Data Binding
- ASP.NET
- Data Access
- OLE DB
- OLEDB
- Databases
- Microsoft Access
- MS Access
## Updated
- 03/30/2018
## Description

<h1 style="text-align:justify">Introduction</h1>
<p style="text-align:justify"><span style="font-size:small"><strong>This is Part II for Basic ASP.NET Series.
</strong><strong><br>
<br>
</strong></span></p>
<p style="text-align:justify"><span style="font-size:small"><em>The Sample demonstrates how to connect &amp; use an access database in webforms. It demonstrates how to use<strong> SQLDataSource &amp; GridView
</strong>controls &amp; also how to <strong>insert</strong>, <strong>delete </strong>
&amp; <strong>update </strong>access database using <strong>OleDbConnection </strong>
&amp; <strong>OleDbCommand.</strong></em></span></p>
<h1 style="text-align:justify"><span>Building the Sample</span></h1>
<p style="text-align:justify"><em><span style="font-size:small"><em><em>Sample can simply be tested with Visual Studio IISExpress. The CSS Style applied to controls is very basic but responsive. Sample should display correctly on screens with Resolution 1024
 x 768. Maximizing web browser can resolve any display conflicts.</em></em></span></em></p>
<p style="text-align:justify"><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><span style="font-size:medium"><strong>Develope Code Step by Step as:
</strong></span></p>
<p style="text-align:justify"><strong>[Note: Only Important Partial Code is given here. Complete code provided in zip is required to run web application]</strong></p>
<ul style="text-align:justify">
<li><strong><span style="font-size:small">Create Access Database File through Access [File Format Used: Access 2002-2003] &amp; include it into App_Data Folder.</span></strong>
</li></ul>
<p style="padding-left:60px; text-align:justify"><span style="font-size:small"><img id="196808" src="196808-screen2.0.png" alt="" width="206" height="89"><br>
</span></p>
<ul style="text-align:justify">
<li><strong><span style="font-size:small">Insert SQLDataSource Control &amp; Configure DataSource &amp; Check ConnectionString in Web.Config.</span></strong>
</li></ul>
<p style="padding-left:60px; text-align:justify"><span style="font-size:small"><img id="196809" src="196809-screen2.01.png" alt="" width="456" height="374"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;connectionStrings&gt;
    &lt;add name=&quot;ConnectionString&quot; connectionString=&quot;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database1.mdb;Persist Security Info=True&quot;
     providerName=&quot;System.Data.OleDb&quot; /&gt;
&lt;/connectionStrings&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;ConnectionString&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;Provider=Microsoft.Jet.OLEDB.4.0;Data&nbsp;Source=|DataDirectory|\Database1.mdb;Persist&nbsp;Security&nbsp;Info=True&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.OleDb&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small"><strong>Insert GridView Control &amp; Choose DataSource as created SQLDataSource.</strong></span>
</li></ul>
<p style="text-align:justify"><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;asp:GridView ID=&quot;GridView1&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;False&quot; Width=&quot;50%&quot; DataKeyNames=&quot;ID&quot; DataSourceID=&quot;SqlDataSource1&quot; AllowSorting=&quot;True&quot;&gt;
        &lt;Columns&gt;
            &lt;asp:BoundField DataField=&quot;ID&quot; HeaderText=&quot;ID&quot; ReadOnly=&quot;True&quot; SortExpression=&quot;ID&quot; InsertVisible=&quot;False&quot; /&gt;
            &lt;asp:BoundField DataField=&quot;Emp_Name&quot; HeaderText=&quot;Emp_Name&quot; SortExpression=&quot;Emp_Name&quot; /&gt;
            &lt;asp:BoundField DataField=&quot;Emp_Dept&quot; HeaderText=&quot;Emp_Dept&quot; SortExpression=&quot;Emp_Dept&quot; /&gt;
            &lt;asp:BoundField DataField=&quot;Emp_Contact&quot; HeaderText=&quot;Emp_Contact&quot; SortExpression=&quot;Emp_Contact&quot; /&gt;
        &lt;/Columns&gt;
&lt;/asp:GridView&gt;</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;asp</span>:GridView&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;GridView1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">AutoGenerateColumns</span>=<span class="html__attr_value">&quot;False&quot;</span>&nbsp;<span class="html__attr_name">Width</span>=<span class="html__attr_value">&quot;50%&quot;</span>&nbsp;<span class="html__attr_name">DataKeyNames</span>=<span class="html__attr_value">&quot;ID&quot;</span>&nbsp;<span class="html__attr_name">DataSourceID</span>=<span class="html__attr_value">&quot;SqlDataSource1&quot;</span>&nbsp;<span class="html__attr_name">AllowSorting</span>=<span class="html__attr_value">&quot;True&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;Columns</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;ID&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;ID&quot;</span>&nbsp;<span class="html__attr_name">ReadOnly</span>=<span class="html__attr_value">&quot;True&quot;</span>&nbsp;<span class="html__attr_name">SortExpression</span>=<span class="html__attr_value">&quot;ID&quot;</span>&nbsp;<span class="html__attr_name">InsertVisible</span>=<span class="html__attr_value">&quot;False&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Emp_Name&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Emp_Name&quot;</span>&nbsp;<span class="html__attr_name">SortExpression</span>=<span class="html__attr_value">&quot;Emp_Name&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Emp_Dept&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Emp_Dept&quot;</span>&nbsp;<span class="html__attr_name">SortExpression</span>=<span class="html__attr_value">&quot;Emp_Dept&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:BoundField&nbsp;<span class="html__attr_name">DataField</span>=<span class="html__attr_value">&quot;Emp_Contact&quot;</span>&nbsp;<span class="html__attr_name">HeaderText</span>=<span class="html__attr_value">&quot;Emp_Contact&quot;</span>&nbsp;<span class="html__attr_name">SortExpression</span>=<span class="html__attr_value">&quot;Emp_Contact&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/Columns&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/asp:GridView&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul style="text-align:justify">
<li><span style="font-size:small"><strong>Handle Connected Database with <span style="font-size:small">
<em><strong>OleDbConnection &amp; <span style="font-size:small"><em><strong>OleDbCommand
</strong></em></span></strong></em><strong><span style="font-size:small"><strong>in VB.NET CodeFile.</strong></span></strong></span></strong></span>
</li></ul>
<blockquote>
<ul>
<li><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Create OleDbConnection &amp; Intialize at form load.</strong></span></span></span>
</li></ul>
<span style="font-size:small"><span style="font-size:small"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden"> Private Shared con As OleDbConnection
 Private Shared cmd As OleDbCommand


.....



    Private Sub CustomPages_DBSQL_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(ConfigurationManager.ConnectionStrings(&quot;ConnectionString&quot;).ConnectionString)
    End Sub</pre>
<div class="preview">
<pre class="vb">&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;con&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;OleDbConnection&nbsp;
&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;OleDbCommand&nbsp;
&nbsp;
&nbsp;
.....&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CustomPages_DBSQL_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection(ConfigurationManager.ConnectionStrings(<span class="visualBasic__string">&quot;ConnectionString&quot;</span>).ConnectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span></span></span>
<ul>
<li><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Create general function that accepts query &amp; return type as parameters &amp; returns First Selection or No. of rows affected based on
<em>ExecuteScalar or ExecuteNonQuery, respectively.</em></strong></span></span></span>
</li></ul>
<span style="font-size:small"><span style="font-size:small"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Private Function getQueryResult(query As String, Optional ByVal j As Short = 0) As String
        con.Open()
        Dim data As String = &quot;&quot;
        cmd = New OleDbCommand(query, con)
        If j = 1 Then
            data = cmd.ExecuteScalar()
        Else
            data = cmd.ExecuteNonQuery()
        End If
        con.Close()
        GridView1.DataBind()
        Return data
    End Function</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getQueryResult(query&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Optional</span>&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;j&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;data&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand(query,&nbsp;con)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;j&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;cmd.ExecuteScalar()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;cmd.ExecuteNonQuery()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridView1.DataBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;data&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span></span></span>
<ul>
<li><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Handle INSERT
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">getQueryResult(String.Format(&quot;insert into AccessEmp values({0},'{1}','{2}',{3});&quot;, i &#43; 1, TxtName.Text, DropDownDeptIns.SelectedItem.Text, Emp_Contact))
</pre>
<div class="preview">
<pre class="vb">getQueryResult(<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;insert&nbsp;into&nbsp;AccessEmp&nbsp;values({0},'{1}','{2}',{3});&quot;</span>,&nbsp;i&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;TxtName.Text,&nbsp;DropDownDeptIns.SelectedItem.Text,&nbsp;Emp_Contact))&nbsp;
</pre>
</div>
</div>
</div>
</strong></span></span></span></li></ul>
</blockquote>
<p><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>&nbsp;</strong></span></span></span></p>
<div class="endscriptcode"><strong>&nbsp;<img id="196811" src="196811-screen2.1.png" alt="" width="587" height="330" style="display:block; margin-left:auto; margin-right:auto"></strong></div>
<p>&nbsp;</p>
<blockquote><br>
<ul>
<li><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Handle DELETE
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">        Dim i = DropDownDelID.SelectedIndex
        Dim j = getQueryResult(&quot;select max(id) from AccessEmp;&quot;, 1)
        getQueryResult(String.Format(&quot;delete from AccessEmp where id={0}&quot;, i &#43; 1))</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;=&nbsp;DropDownDelID.SelectedIndex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;j&nbsp;=&nbsp;getQueryResult(<span class="visualBasic__string">&quot;select&nbsp;max(id)&nbsp;from&nbsp;AccessEmp;&quot;</span>,&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getQueryResult(<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;delete&nbsp;from&nbsp;AccessEmp&nbsp;where&nbsp;id={0}&quot;</span>,&nbsp;i&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>))</pre>
</div>
</div>
</div>
</strong></span></span></span></li></ul>
</blockquote>
<p><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>&nbsp;</strong></span></span></span></p>
<div class="endscriptcode" style="text-align:center"><strong><img id="196812" src="196812-screen2.2.png" alt="" width="589" height="329">&nbsp;</strong></div>
<p>&nbsp;</p>
<blockquote><br>
<ul>
<li><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Handle UPDATE
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden"> Dim i = DropDownUpID.SelectedIndex
 getQueryResult(String.Format(&quot;update AccessEmp set Emp_Name='{1}',Emp_Dept='{2}',Emp_Contact={3} where id={0}&quot;, i &#43; 1, TxtUpName.Text, DropDownDeptUp.SelectedValue, TxtUpContact.Text))</pre>
<div class="preview">
<pre class="vb">&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;=&nbsp;DropDownUpID.SelectedIndex&nbsp;
&nbsp;getQueryResult(<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;update&nbsp;AccessEmp&nbsp;set&nbsp;Emp_Name='{1}',Emp_Dept='{2}',Emp_Contact={3}&nbsp;where&nbsp;id={0}&quot;</span>,&nbsp;i&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;TxtUpName.Text,&nbsp;DropDownDeptUp.SelectedValue,&nbsp;TxtUpContact.Text))</pre>
</div>
</div>
</div>
</strong></span></span></span></li></ul>
</blockquote>
<p><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>&nbsp;</strong></span></span></span></p>
<div class="endscriptcode"><strong><img id="196813" src="196813-screen2.3.png" alt="" width="620" height="347">&nbsp;<img id="196814" src="196814-screen2.4.png" alt="" width="613" height="344"></strong></div>
<p><strong>&nbsp;</strong></p>
<p>&nbsp;</p>
<h1 style="text-align:justify">More Information</h1>
<p style="text-align:justify"><em><em>For more information on various controls use Microsoft Documentation.</em></em></p>
