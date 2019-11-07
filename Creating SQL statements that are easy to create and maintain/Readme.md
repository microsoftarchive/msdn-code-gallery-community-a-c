# Creating SQL statements that are easy to create and maintain
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL
- Win32
- ADO.NET
- Windows Forms
- .NET Framework 4.0
## Topics
- Data Binding
- LINQ to XML
- Data Access
- How to
- Query Execution
## Updated
- 02/15/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This article shows several methods to write better SQL statements that are easy to create and maintain. Historically many developers will do just the opposite, create SQL statements that are, time consuming to create using concatenated
 strings that are difficult to maintain and some are easy to breakdown security wise and compromise data. Along with this a brief look at how to avoid string concatenation for database connection strings.</span></p>
<p><span style="font-size:small">See also </span></p>
<p><span style="font-size:small"><a href="http://code.msdn.microsoft.com/Reveal-parameter-values-28725e53">Reveal named parameters</a></span></p>
<p><span style="font-size:small"><a href="http://code.msdn.microsoft.com/Extending-My-Namespace-27fc6075">Extending MyNamespace project My_SQL</a></span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">There are no special requirements for building the project other than using Visual Studio 2010</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">In the first method, you create your SQL (start with a simple select statement) statement in your SQL editor i.e. using MS-Access, in the query builder, or for SQL Server in SQL Server Management Studio. In your project select
 Solution Explorer, right click on the project folder and create a new folder named SQL. Now right click on the new folder and add a new text file (with a .sql extension instead of .txt), name it something meaningful for the SQL statement created prior. Copy
 your SQL statement into the new code module, notice that the IDE applies syntax highlighting to the standard SQL. Back to Solution Explorer, select the new file, and select properties followed by setting Build Action to
<a href="http://msdn.microsoft.com/en-us/library/ht9h2dk8.aspx">Embedded Resource</a>. From the sample project add MyDatabase.vb to your project which is needed for a My Namespace addition My.SQL.GetSQL as shown in figure 1 where we pass the name of the .sql
 file created prior.&nbsp;That is the simple example while there are examples in the project that show how to work with a where clause with single and multiple conditions.
</span></p>
<p><strong><span style="font-size:small">Figure 1</span></strong></p>
<p>&nbsp;</p>
<div><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Figure1()
    Dim SelectStatement As String = My.SQL.GetSQL(&quot;MyStatement.sql&quot;)
    Using cn As New OleDbConnection With {.ConnectionString = &quot;Your connection string&quot;}
        Using cmd As New OleDbCommand With {.Connection = cn, .CommandText = SelectStatement}
            Dim dt As New DataTable
            cn.Open()
            dt.Load(cmd.ExecuteReader)
        End Using
    End Using
End Sub</pre>
<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;Figure1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;SelectStatement&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;My.SQL.GetSQL(<span class="js__string">&quot;MyStatement.sql&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cn&nbsp;As&nbsp;New&nbsp;OleDbConnection&nbsp;With&nbsp;<span class="js__brace">{</span>.ConnectionString&nbsp;=&nbsp;<span class="js__string">&quot;Your&nbsp;connection&nbsp;string&quot;</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cmd&nbsp;As&nbsp;New&nbsp;OleDbCommand&nbsp;With&nbsp;<span class="js__brace">{</span>.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;SelectStatement<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dt&nbsp;As&nbsp;New&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Load(cmd.ExecuteReader)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Another method (see figure 2) uses
<a title="MSDN How to create XML Literals" href="http://msdn.microsoft.com/en-us/library/bb384692.aspx" target="_blank">
XML literals</a> and <a title="MSDN documenation on embedded expressions" href="http://msdn.microsoft.com/en-us/library/bb384752.aspx" target="_blank">
embedded expressions</a>. Referring to figure 2, the outer nodes SQL are not included in the string returned, only the SQL statement. I should point out that the indents and spaces are included although I have not seen any major database squawk over this. In
 the included project there are examples of using embedded expressions as shown in figure 3.</span></div>
</span></div>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;<strong>Figure 2</strong></span></p>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Figure2()
    Dim SelectStatement =
    &lt;SQL&gt;
    SELECT 
        Identifier, 
        CompanyName, 
        ContactName, 
        ContactPhone
    FROM 
        Customers
    &lt;/SQL&gt;.Value

    Using cn As New OleDbConnection With
        {.ConnectionString = &quot;Your connection string&quot;}
        Using cmd As New OleDbCommand With
            {.Connection = cn, .CommandText = SelectStatement}
            Dim dt As New DataTable
            cn.Open()
            dt.Load(cmd.ExecuteReader)
        End Using
    End Using

End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Figure2()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;SelectStatement&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SQL&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactPhone&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/SQL&gt;.Value&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{.ConnectionString&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Your&nbsp;connection&nbsp;string&quot;</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;SelectStatement}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Load(cmd.ExecuteReader)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<p>C# version of the above</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string SelectStatement = 
@&quot;
    SELECT 
        Identifier, 
        CompanyName, 
        ContactName, 
        ContactPhone 
    FROM 
        Customers&quot;;
using (OleDbConnection cn = new OleDbConnection { ConnectionString = &quot;Your connection string&quot; })
{
    using (OleDbCommand cmd = new OleDbCommand { Connection = cn, CommandText = SelectStatement })
    {
        DataTable dt = new DataTable();
        cn.Open();
        dt.Load(cmd.ExecuteReader());
    }
}</pre>
<div class="preview">
<pre class="js">string&nbsp;SelectStatement&nbsp;=&nbsp;&nbsp;
@&quot;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactPhone&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customers&quot;;&nbsp;
using&nbsp;(OleDbConnection&nbsp;cn&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;OleDbConnection&nbsp;<span class="js__brace">{</span>&nbsp;ConnectionString&nbsp;=&nbsp;<span class="js__string">&quot;Your&nbsp;connection&nbsp;string&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(OleDbCommand&nbsp;cmd&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;OleDbCommand&nbsp;<span class="js__brace">{</span>&nbsp;Connection&nbsp;=&nbsp;cn,&nbsp;CommandText&nbsp;=&nbsp;SelectStatement&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dt&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Load(cmd.ExecuteReader());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<div class="endscriptcode">&nbsp;<strong>Figure 3</strong>.</div>
<span style="font-size:small"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private CurrentID As Integer = 10
Private Sub Figure3()
    Dim SelectStatement =
    &lt;SQL&gt;
    SELECT 
        Identifier, 
        CompanyName, 
        ContactName, 
        ContactPhone
    FROM 
        Customers
    WHERE Identifier = &lt;%= CurrentID %&gt;
    &lt;/SQL&gt;.Value

    Using cn As New OleDbConnection With
        {.ConnectionString = &quot;Your connection string&quot;}
        Using cmd As New OleDbCommand With
            {.Connection = cn, .CommandText = SelectStatement}
            Dim dt As New DataTable
            cn.Open()
            dt.Load(cmd.ExecuteReader)
        End Using
    End Using

End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;CurrentID&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">10</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Figure3()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;SelectStatement&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SQL&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactPhone&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WHERE&nbsp;Identifier&nbsp;=&nbsp;&lt;%=&nbsp;CurrentID&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/SQL&gt;.Value&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{.ConnectionString&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Your&nbsp;connection&nbsp;string&quot;</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;SelectStatement}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Load(cmd.ExecuteReader)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><strong>Output from Figure 2</strong></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>&nbsp;</strong></span></span></span></span>&nbsp;</div>
<span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">SQL</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">        SELECT 
            Identifier, 
            CompanyName, 
            ContactName, 
            ContactPhone
        FROM 
            Customers
        WHERE Identifier = 10</pre>
<div class="preview">
<pre class="mysql">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Identifier</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CompanyName</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">ContactName</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">ContactPhone</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">FROM</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">WHERE</span>&nbsp;<span class="sql__id">Identifier</span>&nbsp;=&nbsp;<span class="sql__number">10</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"></span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"></span></span></span></span></span></span></span></span></span></span></span></span></div>
</strong>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"></span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"></span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Figure
 4</strong>.</span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Figure4()
    Using cn As New OleDbConnection With
        {
            .ConnectionString = &quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb&quot;
        }
        Using cmd As New OleDbCommand With {.Connection = cn}
            Dim P1 As New OleDbParameter With
                {
                    .OleDbType = OleDbType.Integer,
                    .ParameterName = &quot;@SomeField&quot;
                }
            Dim P2 As New OleDbParameter With
                {
                    .OleDbType = OleDbType.LongVarChar,
                    .ParameterName = &quot;@AnotherField&quot;
                }

            P1.Value = ComboBox5.Text
            P2.Value = ComboBox6.Text

            cmd.CommandText = My.SQL.GetSQL(&quot;MainSelect3.sql&quot;)
            cmd.Parameters.AddRange(New OleDbParameter() {P1, P2})

            cn.Open()
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
        End Using
    End Using
End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Figure4()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ConnectionString&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Provider=Microsoft.ACE.OLEDB.12.0;Data&nbsp;Source=Database1.accdb&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.Connection&nbsp;=&nbsp;cn}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;P1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.OleDbType&nbsp;=&nbsp;OleDbType.<span class="visualBasic__keyword">Integer</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ParameterName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;@SomeField&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;P2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.OleDbType&nbsp;=&nbsp;OleDbType.LongVarChar,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ParameterName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;@AnotherField&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;P1.Value&nbsp;=&nbsp;ComboBox5.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;P2.Value&nbsp;=&nbsp;ComboBox6.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;My.SQL.GetSQL(<span class="visualBasic__string">&quot;MainSelect3.sql&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddRange(<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter()&nbsp;{P1,&nbsp;P2})&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Load(cmd.ExecuteReader)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Okay they are the basics for writing better SQL statements. In the project I demonstrate not only a single condition on a where clause but dynamic multiple conditions. These basics can be applied to other types of SQL statements
 such as insert, update and remove.</div>
<div class="endscriptcode">&nbsp;</div>
</span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>Important</strong>:
</span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small">There&#65279;
 is code that are in specific file type as they need to be. For instance <a title="MSDN documentation" href="http://msdn.microsoft.com/en-us/library/bb384936.aspx" target="_blank">
language extension methods</a> as shown below. If you have never used them before they are either functions or procedures that can still be called as a function or procedure or as a method to the first parameter, in the example below we can use it against a
 String only.</span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    &lt;System.Diagnostics.DebuggerStepThrough()&gt; _
    &lt;Runtime.CompilerServices.Extension()&gt; _
    Function TrimQueryText(ByVal value As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(value.TrimStart, &quot; {2,}&quot;, &quot; &quot;)
    End Function</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Diagnostics.DebuggerStepThrough()&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Runtime.CompilerServices.Extension()&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Function</span>&nbsp;TrimQueryText(ByVal&nbsp;value&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;System.Text.RegularExpressions.Regex.Replace(value.TrimStart,&nbsp;<span class="js__string">&quot;&nbsp;{2,}&quot;</span>,&nbsp;<span class="js__string">&quot;&nbsp;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</span></span></span></span></span></span></span></span></span></span></span></span></div>
<div class="endscriptcode">
<div>If the field Identifier were a string (in figure 2), we would need to wrap the embedded expression within apostrophes to indicate we are dealing with a string.</div>
</div>
<div class="endscriptcode"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><span style="font-size:small"><strong>&nbsp;</strong></span></span></span></span></span></span></span></span></span></span></span></span>&nbsp;</div>
</span></span></span></span></span></span></span></span></span></span></span></div>
<p><span style="font-size:small">One last idea came to mind was avoiding string concatenation in regards to creating database connection strings as they are easy prey to typos as are SQL statements.<br>
There is a &lsquo;Live&rsquo; button on the main form, this will open a new form. In the form load event a connection string is constructed using
<a title="MSDN documentation" href="http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbconnectionstringbuilder.aspx" target="_blank">
OleDbConnectionStringBuilder</a> which once seen is easy to duplicate.<br>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim Builder As New OleDbConnectionStringBuilder With
    {
        .Provider = &quot;Microsoft.Jet.OLEDB.4.0&quot;,
        .DataSource = IO.Path.Combine(Application.StartupPath, &quot;Database1.mdb&quot;)
    }</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;Builder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnectionStringBuilder&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Provider&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Microsoft.Jet.OLEDB.4.0&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DataSource&nbsp;=&nbsp;IO.Path.Combine(Application.StartupPath,&nbsp;<span class="visualBasic__string">&quot;Database1.mdb&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">After the data is retrieved using a OleDbConnection, OleDbCommand the data is loaded into a DataTable which is then set as the DataSource for a BindingSource. The BindingSource is assigned to the DataSource
 of the DataGridView and is set as the BindingSource for the BindingNavigator. The BindingNavigator allows the user to traverse rows via buttons or identifier. Also the BindingSource is used to locate and position to a specific row using one of the row&rsquo;s
 identifiers and allow the current row to stay current after the user sorts the DataGridView by clicking a DataGridView column header.&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small">Hopefully I have given some decent methods to avoid using string concatenation for both adding SQL statements and connection strings to your code.</span></div>
<p>&nbsp;</p>
