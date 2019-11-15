# CheckListBox Loading/Retrieving items from a Database
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Controls
- User Interface
## Updated
- 05/20/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This article shows the basics for loading/Retrieving items from a Database into a CheckedListBox.&nbsp;</span></p>
<p><span style="font-size:small"><strong><span style="color:#ff0000">3/17/2014</span></strong> added a language extension method to locate items in a CheckedListBox when the items are populated with a string array either by Add or AddRange of the items property.
 Decided while I was at it add an example in C#. So there is a demo for both C# and VB.NET.<br>
<img id="110715" src="http://i1.code.msdn.s-msft.com/checklistbox-loadingretriev-70b0c202/image/file/110715/1/am.png" alt="" width="394" height="203"></span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">There are no special requirement other than having VS2010</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This article shows the basics for loading/Retrieving items from a Database into a CheckedListBox.&nbsp; The first thing to understand is the CheckedListBox control does not support data binding so you need to add items and set
 the checked property for each item in the CheckedListBox using methods native to the CheckedListBox for determining whether an item is checked or not to save back to your database. For loading essentially, we use a native method to set the check state of an
 item.</span></p>
<p><span style="font-size:small">&nbsp;Although this demonstration is specific to loading/retrieving items from a Database into a CheckedListBox does not mean you could not do load/ retrieving items from another source such as XML or even a delimited file.
 A database was chosen because most solutions are data centric in nature so it seems prudent to demonstrate loading and saving the check state of items in a database.</span></p>
<p><span style="font-size:small">&nbsp;One thing to consider when saving the state of rows as shown in the demonstration project is that using the close event will slow down the application termination. If this is an issue (which under normal circumstances
 should not be) then the alternate is updating the check state as the check state changes.</span></p>
<p><span style="font-size:small">&nbsp;Caveats, while working with a CheckedListBox I would suggest setting the property CheckOnClick to False which is the default as setting this property to True means that a single click on an item will toggle the current
 state. In the demonstration project there is a label which shows via the selected value changed event the current items checked state.</span></p>
<p><span style="font-size:small"><img id="76975" src="http://i1.code.msdn.s-msft.com/checklistbox-loadingretriev-70b0c202/image/file/76975/1/figure1.jpg" alt="" width="411" height="355"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>07/2013</strong>:&nbsp;The following will produce a list of checked items. Add a command button, add the code below.<br>
<br>
<strong>01/2014</strong>: Added secondary example w/o a backend database.</span><span style="font-size:small">&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;System.Text.StringBuilder&nbsp;
Dim&nbsp;CheckedList&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;Item&nbsp;In&nbsp;clbCheckedListBox.Items.Cast(Of&nbsp;<span class="js__object">String</span>)()&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(<span class="js__object">Function</span>(xItem,&nbsp;Index)&nbsp;clbCheckedListBox.GetItemChecked(Index))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;Item&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;).ToList&nbsp;
&nbsp;
If&nbsp;CheckedList.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;item&nbsp;In&nbsp;CheckedList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(sb.ToString)&nbsp;
End&nbsp;If</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>08/2013</strong> shows how to split text from the items</div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Dim&nbsp;TheList&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;Item&nbsp;In&nbsp;clbOptions.Items.Cast(Of&nbsp;<span class="js__object">String</span>)()&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(<span class="js__object">Function</span>(xItem,&nbsp;Index)&nbsp;clbOptions.GetItemChecked(Index))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;Item&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;).ToList&nbsp;
&nbsp;
If&nbsp;TheList.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Items&nbsp;=&nbsp;(From&nbsp;T&nbsp;In&nbsp;clbOptions.CheckedList&nbsp;Let&nbsp;P&nbsp;=&nbsp;T.Split(<span class="js__string">&quot;&nbsp;&quot;</span>c)&nbsp;Select&nbsp;New&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Left&nbsp;=&nbsp;P(<span class="js__num">0</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Right&nbsp;=&nbsp;P(<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;).ToList&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;item&nbsp;In&nbsp;Items&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__object">String</span>.Format(<span class="js__string">&quot;[{0}]&nbsp;[{1}]&quot;</span>,&nbsp;item.Left,&nbsp;item.Right))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;No&nbsp;checked&nbsp;items&quot;</span>)&nbsp;
End&nbsp;If</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<div class="endscriptcode"><span style="font-size:small">TheList above could be a language extension (I mixed it up above where in the second LINQ statement CheckedList is the same as the results of TheList)'</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Runtime.CompilerServices.Extension()&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;<span class="js__object">Function</span>&nbsp;CheckedList(ByVal&nbsp;sender&nbsp;As&nbsp;CheckedListBox)&nbsp;As&nbsp;List(Of&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;(From&nbsp;Item&nbsp;In&nbsp;sender.Items.Cast(Of&nbsp;<span class="js__object">String</span>)().Where(<span class="js__object">Function</span>(xItem,&nbsp;Index)&nbsp;sender.GetItemChecked(Index))&nbsp;Select&nbsp;Item).ToList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong><span style="color:#ff0000">1/2014</span></strong> addition<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Public&nbsp;Class&nbsp;frmDataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;frmDataTable_Load(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;MyBase.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dt&nbsp;As&nbsp;New&nbsp;DataTable&nbsp;With&nbsp;<span class="js__brace">{</span>.TableName&nbsp;=&nbsp;<span class="js__string">&quot;MyTable&quot;</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(New&nbsp;DataColumn&nbsp;With&nbsp;<span class="js__brace">{</span>.ColumnName&nbsp;=&nbsp;<span class="js__string">&quot;Identifier&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DataType&nbsp;=&nbsp;GetType(Int32),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AutoIncrement&nbsp;=&nbsp;True,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AutoIncrementStep&nbsp;=&nbsp;<span class="js__num">100</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AutoIncrementSeed&nbsp;=&nbsp;<span class="js__num">100</span><span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(New&nbsp;DataColumn&nbsp;With&nbsp;<span class="js__brace">{</span>.ColumnName&nbsp;=&nbsp;<span class="js__string">&quot;Name&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DataType&nbsp;=&nbsp;GetType(<span class="js__object">String</span>)<span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(New&nbsp;DataColumn&nbsp;With&nbsp;<span class="js__brace">{</span>.ColumnName&nbsp;=&nbsp;<span class="js__string">&quot;ExtraData&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DataType&nbsp;=&nbsp;GetType(<span class="js__object">String</span>)<span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>Nothing,&nbsp;<span class="js__string">&quot;One&quot;</span>,&nbsp;<span class="js__string">&quot;Extra&nbsp;1&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>Nothing,&nbsp;<span class="js__string">&quot;Two&quot;</span>,&nbsp;<span class="js__string">&quot;Extra&nbsp;2&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>Nothing,&nbsp;<span class="js__string">&quot;Three&quot;</span>,&nbsp;<span class="js__string">&quot;Extra&nbsp;3&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>Nothing,&nbsp;<span class="js__string">&quot;Four&quot;</span>,&nbsp;<span class="js__string">&quot;Extra&nbsp;4&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;<span class="js__brace">{</span>Nothing,&nbsp;<span class="js__string">&quot;Five&quot;</span>,&nbsp;<span class="js__string">&quot;Extra&nbsp;5&quot;</span><span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clbCheckedListBox.DataSource&nbsp;=&nbsp;dt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clbCheckedListBox.DisplayMember&nbsp;=&nbsp;<span class="js__string">&quot;Name&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;cmdGetChecked_Click(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;cmdGetChecked.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;clbCheckedListBox.CheckedItems.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;System.Text.StringBuilder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;drv&nbsp;As&nbsp;DataRowView&nbsp;In&nbsp;clbCheckedListBox.CheckedItems&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="js__object">String</span>.Join(<span class="js__string">&quot;,&quot;</span>,&nbsp;drv.Row.ItemArray))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(sb.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Class</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#ff0000"><strong>5/20/2014</strong></span><br>
Here are a few lanaguage exensions for obtaining checked items. CheckedItemsList returns a string array of items that are checked in a CheckedListBox which is a wrapper on top of CheckedItemsList. CheckedItems was done basically for use with String.Join.<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="js">public&nbsp;static&nbsp;string[]&nbsp;CheckedItems(<span class="js__operator">this</span>&nbsp;CheckedListBox&nbsp;sender)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;sender.CheckedItemsList().ToArray();&nbsp;
<span class="js__brace">}</span>&nbsp;
public&nbsp;static&nbsp;IEnumerable&lt;string&gt;&nbsp;CheckedItemsList(<span class="js__operator">this</span>&nbsp;CheckedListBox&nbsp;sender)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Result&nbsp;=&nbsp;from&nbsp;T&nbsp;<span class="js__operator">in</span>&nbsp;sender.Items.OfType&lt;string&gt;().Where(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(item,&nbsp;index)&nbsp;=&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;sender.GetItemChecked(index);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;T;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Result;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Example usage for CheckedItems which returns (Paul,Ringo) where each name in this case is a item and the resulting string in this case could be used for a where condition in a where SQL statement for a IN condition.<br>
<img id="114901" src="http://i1.code.msdn.s-msft.com/checklistbox-loadingretriev-70b0c202/image/file/114901/1/in.png" alt="" width="318" height="89"><br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;inValues&nbsp;=&nbsp;<span class="cs__string">&quot;(&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__keyword">string</span>.Join(<span class="cs__string">&quot;,&quot;</span>,&nbsp;checkedListBox1.CheckedItems())&nbsp;&#43;&nbsp;<span class="cs__string">&quot;)&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
</div>
</span></div>
