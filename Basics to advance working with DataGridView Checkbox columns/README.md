# Basics to advance working with DataGridView Checkbox columns
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Visual Basic .NET
- VB.Net
- WinForms
## Topics
- DataGridView
- DataGridViewCheckBox column
## Updated
- 08/09/2016
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">The main focus of this article is to demonstrate working with checkbox columns in DataGridView controls ranging from simple to complex where complex is seen this way only when one does not understand &quot;how to&quot; get a business
 requirement done. What I will use as a data source for all projects is a DataTable and access Boolean values seen as DataGridViewCheckBox columns/cells, more on this shortly.</span></p>
<p><span style="font-size:small"><span style="color:#339966"><strong>1/7/2016</strong></span>, added new C# project for demostrating summing.</span></p>
<p><span style="background-color:#ffffff"><strong><span style="font-size:small">12/29/2015</span></strong></span><span style="font-size:small">, added a new C# project</span></p>
<p><strong style="font-size:small"><span style="color:#ff0000">2/2014</span></strong><span style="font-size:small">, began including C# projects (at the current time only one) but more to follow.</span></p>
<p><span style="font-size:small"><strong>8/2016</strong>, <a href="https://1drv.ms/u/s!AtGAgKKpqdWjh2bj5Jm5GP8KwXII">
added a C# project</a> on Microsoft OneDrive that shows how to sum all checked rows via a decimal cell and handled null values.</span></p>
<p><span style="font-size:small"><img id="157987" src="157987-52.jpg" alt="" width="376" height="269"><br>
</span></p>
<p><span style="font-size:small"><br>
Screen shot of one of the project done in C and VB<br>
<img id="109051" src="109051-vc.png" alt="" width="646" height="265"></span></p>
<p><span style="font-size:small">There are several reasons for using a checkbox in a DataGridView from marking a row of data to process (perhaps export data in a selective manner or delete rows) or to keep track of roles or rights i.e. is the user an administrator,
 do they have rights to do specific operations in your application etc.</span></p>
<p><span style="font-size:small">Let me get something out of the way now rather than later, when you are not bound to a data source and are allowing users to add new rows we can get into trouble (code is from project NoDataSource in the attached solution) when
 not testing for conditions such as, is the row newly added and is there data to collection. Button1 is failed to throw an exception if the second column is empty but not Button2</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js"><span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;demonstrates&nbsp;issue&nbsp;when&nbsp;allow&nbsp;user&nbsp;to&nbsp;add&nbsp;rows&nbsp;is&nbsp;not&nbsp;accounted&nbsp;
<span class="js__string">''</span>'&nbsp;<span class="js__statement">for</span>&nbsp;<span class="js__operator">in</span>&nbsp;code&nbsp;as&nbsp;<span class="js__operator">in</span>&nbsp;Button1&nbsp;click&nbsp;event&nbsp;<span class="js__statement">while</span>&nbsp;Button2&nbsp;click&nbsp;event&nbsp;
<span class="js__string">''</span>'&nbsp;uses&nbsp;assertion&nbsp;<span class="js__statement">for</span>&nbsp;<span class="js__operator">new</span>&nbsp;rows&nbsp;and&nbsp;blank&nbsp;data&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">new</span>&nbsp;rows.&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;remarks&gt;&lt;/remarks&gt;&nbsp;
Public&nbsp;Class&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;Form1_Load(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;MyBase.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>False,&nbsp;<span class="js__string">&quot;A1&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>True,&nbsp;<span class="js__string">&quot;B1&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>False,&nbsp;<span class="js__string">&quot;C1&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Doom&nbsp;to&nbsp;<span class="js__statement">throw</span>&nbsp;an&nbsp;exception&nbsp;on&nbsp;newly&nbsp;added&nbsp;rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;sender&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;e&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;remarks&gt;&lt;/remarks&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;Button1_Click(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;CheckedRows&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;Rows&nbsp;In&nbsp;DataGridView1.Rows.Cast(Of&nbsp;DataGridViewRow)()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;CBool(Rows.Cells(<span class="js__string">&quot;ProcessColumn&quot;</span>).Value)&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;).ToList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;CheckedRows.Count&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Nothing&nbsp;checked&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;System.Text.StringBuilder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;row&nbsp;As&nbsp;DataGridViewRow&nbsp;In&nbsp;CheckedRows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(row.Cells(<span class="js__string">&quot;ActionColumn&quot;</span>).Value.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(sb.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Unlike&nbsp;the&nbsp;above&nbsp;<span class="js__operator">this</span>&nbsp;code&nbsp;checks&nbsp;<span class="js__statement">for</span>&nbsp;problems&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;sender&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;e&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;remarks&gt;&lt;/remarks&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;Button2_Click(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;Button2.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;CheckedRows&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;Rows&nbsp;In&nbsp;DataGridView1.Rows.Cast(Of&nbsp;DataGridViewRow)()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;Not&nbsp;Rows.IsNewRow&nbsp;AndAlso&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Not&nbsp;<span class="js__object">String</span>.IsNullOrWhiteSpace(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CStr(Rows.Cells(<span class="js__string">&quot;ActionColumn&quot;</span>).Value))&nbsp;AndAlso&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CBool(Rows.Cells(<span class="js__string">&quot;ProcessColumn&quot;</span>).Value)&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;).ToList&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;CheckedRows.Count&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Nothing&nbsp;checked&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;System.Text.StringBuilder&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;row&nbsp;As&nbsp;DataGridViewRow&nbsp;In&nbsp;CheckedRows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="js__string">&quot;'&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row.Cells(<span class="js__string">&quot;ActionColumn&quot;</span>).Value.ToString&nbsp;&amp;&nbsp;<span class="js__string">&quot;'&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(sb.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Class&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">.</span></div>
<p><span style="font-size:small">&nbsp;I mentioned using a DataTable, this allows you to show some information in the DataGridView while keeping other fields such as an identity field pointing back to a database table. If you loaded a DataGridView from a database
 table and hide the identity data we do not have access to this data in the DataGridView while using a DataTable we have access to the data. This is demonstrate in the project CheckedSimple_Mocked where hard coded data is placed into a DataGridView, two buttons,
 one showing how to get checked row data via the data while another button via the DataGridView.</span></p>
<p><span style="font-size:small">Note: In all project code there are&nbsp;comments where I thought it would assist in learning important things when working with checkbox columns.</span></p>
<p><span style="font-size:small"><strong>Project CheckedSimple_Mocked</strong> loads hard coded data from a DataTable then adds a column named process. Think of this as marrying data loaded from a database table with a Boolean column used to allow a user to
 check off rows they want to do something with. In the Checked 1 button shows how to get data through the data source while Checked 2 from a DataGridView. Unlike Checked 1, Checked 2 is limited to visible columns in the DataGridView. Now you might ask why I
 have the field Identifier showing? I would like you to try the code as is then hide the Identifier column and try to get it via the column not the data, might want to add a try/catch :-) This is because you can only access visible data.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><img id="95499" src="95499-am_1.jpg" alt="" width="431" height="315"><em>&nbsp;&nbsp;</em></p>
<p><span style="font-size:small"><strong>Project CheckedSimple_MS_Access </strong>
we obtain data from MS-Access and work with filtering data in a DataGridView in tangent with checkbox logic. What can make this interesting is the filtering in that a user checks off rows then does a filter that does not include current checked rows, to them
 indeed this can be confusing. Options range from telling them something like &quot;the checked rows are still checked&quot; and show them or do not mix filtering with the checked logic. There are two child forms so you get more than one demo in this project.</span></p>
<p><span style="font-size:small"><strong>Project CheckOneRow</strong> shows how to allow only one row checked. Example, there are five rows, check row 1 now check say row 3, row 3 is not checked and row 1 un-checked. Check row 5, now row 5 is checked but none
 of the other rows. This is all done at the DataTable level and not the DataGridView level for mouse operations. Sadly we must resort to using the KeyUp event for users who like to toggle a selection with the spacebar as the space bar action circumvents a trigger
 to the DataTable event ColumnChanged and will throw a tissy (an exception) so study the logic in the DataGridView key up event. Also take note of CurrentCellDirtyStateChanged event of the DataGridView to ensure we get current values w/o the need to leave the
 current row in the DataGridview</span></p>
<p><span style="font-size:small">Suppose you need to show multiple checkbox columns or more?
</span></p>
<p><span style="font-size:small"><strong>Project DualCheckBox_DataGridView</strong> and
<strong>project TripleCheckBox_DataGridView</strong> show how to allow only one checked cell per row.</span></p>
<p><span style="font-size:small"><img id="95501" src="95501-am_t.jpg" alt="" width="373" height="326"></span></p>
<p><span style="font-size:small"><strong>Project DynamicUpdateCheckBoxColumn</strong> comes closer to working with the DataGridView cell data than other projects in the solution. Here I wanted to show mixing it up with CheckBox, text and dates with only two
 columns</span></p>
<p><img id="95500" src="95500-am_2.jpg" alt="" width="470" height="408"></p>
<p><span style="font-size:small">Hopefully the projects included have been done clearly to allow you to learn how to work with CheckBox columns in DataGridView controls. Please take your time and explore as I have only touched the surface of what is in the
 source code.</span>&nbsp;</p>
