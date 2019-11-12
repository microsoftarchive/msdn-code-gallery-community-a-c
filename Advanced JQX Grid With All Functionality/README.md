# Advanced JQX Grid With All Functionality
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- jQuery
- GridView
- HTML5
- jQuery UI
- jQWidgets
- CSS3
## Topics
- jQuery
- GridView
- HTML5
- jQWidgets
- CSS3
- jqxGrid
## Updated
- 07/04/2016
## Description

<p><span style="font-size:small">In this article we will see how we can implement or create a JQWidget&rsquo;s JQX grid in our application. It is a client side grid which is good in performance and speed. We will see the advanced properties of a JQWidget JQX
 gris in this article.</span></p>
<p><span style="font-size:small">If you are new to the term JQX Grid then please find out the articles related to JQWidget category here:&nbsp;</span><span style="font-size:x-small"><a title="JQXGrid" href="http://sibeeshpassion.com/category/products/jqwidgets/">http://sibeeshpassion.com/category/products/jqwidgets/</a></span></p>
<p><span style="font-size:small">If you need to bind the data source dynamically, please read here:<a href="http://sibeeshpassion.com/Convert-CellSet-to-HTML-table-And-From-HTML-To-Json-To-Array" target="_blank">http://sibeeshpassion.com/Convert-CellSet-to-HTML-table-And-From-HTML-To-Json-To-Array</a>.
 For the past days I have been working on JQX Grid. Now I will share that Grid with all the functionality.</span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">In my previous article, one member asked for some functionality. So I thought of sharing that info. Please note that I have not implemented all the functionalities. I have selected some important features that we may use in
 our programming life.</span></p>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">As we discussed in the previous articles, we need a web application with all the contents of JQX Widgets (<a href="http://sibeeshpassion.com/working-with-jqx-grid-with-filtering-and-sorting/" target="_blank">http://sibeeshpassion.com/working-with-jqx-grid-with-filtering-and-sorting/</a>&nbsp;).</span></p>
<p><strong><span style="font-size:small">What is JQX Grid?</span></strong></p>
<p><span style="font-size:small">jqxGrid is powerful datagrid widget built entirely with open web standards. It offers rich functionality, easy to use APIs and works across devices and browsers. jqxGrid delivers advanced data visualization features and built-in
 support for client and server-side paging, editing, sorting and filtering.</span></p>
<p><strong><span style="font-size:small">What we need?</span></strong></p>
<p><strong><span style="font-size:small"><em>Simple HTML</em></span></strong></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_579648">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=&ldquo;en&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Include the extra UI elements</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_716233">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;body&nbsp;class=&lsquo;<span class="js__statement">default</span>&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=&lsquo;jqxWidget&rsquo;&nbsp;style=&ldquo;font-size:&nbsp;13px;&nbsp;font-family:&nbsp;Verdana;&nbsp;float:&nbsp;left;&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=&ldquo;jqxgrid&rdquo;&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-top:&nbsp;20px;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;Excel&rdquo;&nbsp;id=&lsquo;excelExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;XML&rdquo;&nbsp;id=&lsquo;xmlExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-left:&nbsp;10px;&nbsp;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;CSV&rdquo;&nbsp;id=&lsquo;csvExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;TSV&rdquo;&nbsp;id=&lsquo;tsvExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-left:&nbsp;10px;&nbsp;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;HTML&rdquo;&nbsp;id=&lsquo;htmlExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;JSON&rdquo;&nbsp;id=&lsquo;jsonExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-left:&nbsp;10px;&nbsp;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Print&rdquo;&nbsp;id=&lsquo;print&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&lt;/body&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Include Reference</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_126841">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;link&nbsp;rel=&ldquo;stylesheet&rdquo;&nbsp;href=&ldquo;jqwidgets/styles/jqx.base.css&rdquo;&nbsp;type=&ldquo;text<span class="js__reg_exp">/css&rdquo;&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;scripts/jquery<span class="js__num">-1.11</span><span class="js__num">.1</span>.min.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxcore.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxdata.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxbuttons.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxscrollbar.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxlistbox.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxdropdownlist.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxmenu.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.filter.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.sort.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.selection.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxpanel.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxcheckbox.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;scripts/demos.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.pager.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.edit.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.columnsresize.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.columnsreorder.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.export.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxdata.export.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">What we add new?</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_437684">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.pager.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">This script is for adding the functionality of Paging :). You can add the functionality to the grid as</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_310920">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">pageable:&nbsp;true.&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">And if you want different stylish paging then you can set that like this:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_471163">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">pagermode:&nbsp;&lsquo;simple&rsquo;,&nbsp;
&nbsp;
&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.edit.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">This script is for adding the functionality of Editing :). You can add the functionality to the grid as</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_949303">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">editable:&nbsp;true.&nbsp;
&nbsp;
&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.columnsresize.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.columnsreorder.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">These scripts are for adding the functionality of Hierarchy columns. If we want to separate the data in the column header then you can include the following scripts.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_366861">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.export.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=&ldquo;jqwidgets/jqxdata.export.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">When you want to export your grid to any formate, please include those scripts. You can implement the same just like the following:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_281463">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(&ldquo;#excelExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;<span class="js__sl_comment">//Assign&nbsp;styles&nbsp;to&nbsp;the&nbsp;button</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#xmlExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#csvExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#tsvExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#htmlExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jsonExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#excelExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;xls&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;export&nbsp;to&nbsp;xlx</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#xmlExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;xml&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;<span class="js__sl_comment">//To&nbsp;export&nbsp;to&nbsp;XML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#csvExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;csv&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;export&nbsp;to&nbsp;csv</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#tsvExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;tsv&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;export&nbsp;to&nbsp;tsv</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#htmlExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;html&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;export&nbsp;to&nbsp;html</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jsonExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;json&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;export&nbsp;to&nbsp;JSON</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">If you want to print your grid:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_484946">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(&ldquo;#print&rdquo;).jqxButton();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#print&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;gridContent&nbsp;=&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;html&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newWindow&nbsp;=&nbsp;window.open(&rdquo;,&nbsp;&rdquo;,&nbsp;&lsquo;width=<span class="js__num">800</span>,&nbsp;height=<span class="js__num">500</span>&prime;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document&nbsp;=&nbsp;newWindow.document.open(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageContent&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;!DOCTYPE&nbsp;html&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;html&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;head&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;meta&nbsp;charset=&rdquo;utf<span class="js__num">-8</span>&Prime;&nbsp;/&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;title&gt;jQWidgets&nbsp;Grid&lt;/title&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;/head&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;body&gt;\n&rsquo;&nbsp;&#43;&nbsp;gridContent&nbsp;&#43;&nbsp;&lsquo;\n&lt;<span class="js__reg_exp">/body&gt;\n&lt;/</span>html&gt;&rsquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(pageContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newWindow.print();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now we need data to populate the grid, right? Since we are familiar with a simple header JQX Grid from the previous article, now we can go for a hierarchy column grid. So let&rsquo;s say we have XML as follows:</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_983691">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">&lt;DATA&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ProductID&gt;<span class="js__num">72</span>&lt;/ProductID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SupplierName&gt;Formaggi&nbsp;Fortini&nbsp;s.r.l.&lt;/SupplierName&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Quantity&gt;<span class="js__num">24</span>&nbsp;&ndash;&nbsp;<span class="js__num">200</span>&nbsp;g&nbsp;pkgs.&lt;/Quantity&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Freight&gt;<span class="js__num">32.3800</span>&lt;/Freight&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;OrderDate&gt;<span class="js__num">1996</span><span class="js__num">-07</span><span class="js__num">-04</span>&nbsp;<span class="js__num">00</span>:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/OrderDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;OrderAddress&gt;<span class="js__num">59</span>&nbsp;rue&nbsp;de&nbsp;l-Abbaye&lt;/OrderAddress&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Price&gt;<span class="js__num">34.8000</span>&lt;/Price&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;City&gt;Ravenna&lt;/City&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Address&gt;Viale&nbsp;Dante,&nbsp;<span class="js__num">75</span>&lt;/Address&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ProductName&gt;Mozzarella&nbsp;di&nbsp;Giovanni&lt;/ProductName&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ProductID&gt;<span class="js__num">42</span>&lt;/ProductID&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SupplierName&gt;Leka&nbsp;Trading&lt;/SupplierName&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Quantity&gt;<span class="js__num">32</span>&nbsp;&ndash;&nbsp;<span class="js__num">1</span>&nbsp;kg&nbsp;pkgs.&lt;/Quantity&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Freight&gt;<span class="js__num">32.3800</span>&lt;/Freight&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;OrderDate&gt;<span class="js__num">1996</span><span class="js__num">-07</span><span class="js__num">-04</span>&nbsp;<span class="js__num">00</span>:<span class="js__num">00</span>:<span class="js__num">00</span>&lt;/OrderDate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;OrderAddress&gt;<span class="js__num">59</span>&nbsp;rue&nbsp;de&nbsp;l-Abbaye&lt;/OrderAddress&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Price&gt;<span class="js__num">14.0000</span>&lt;/Price&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;City&gt;Singapore&lt;/City&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Address&gt;<span class="js__num">471</span>&nbsp;Serangoon&nbsp;Loop,&nbsp;Suite&nbsp;#<span class="js__num">402</span>&lt;/Address&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ProductName&gt;Singaporean&nbsp;Hokkien&nbsp;Fried&nbsp;Mee&lt;/ProductName&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&hellip;&hellip;..&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ROW&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&hellip;&hellip;..&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ROW&gt;&nbsp;
&lt;/DATA&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Please find the&nbsp;<em>orderdetailsextended.xml</em>&nbsp;from the source.</span></p>
<p><span style="font-size:small">Implementing a JQX GRid with advanced features</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_16395">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;prepare&nbsp;the&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;source&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datatype:&nbsp;&ldquo;xml&rdquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datafields:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;SupplierName&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;type:&nbsp;&lsquo;number&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;OrderDate&rsquo;,&nbsp;type:&nbsp;&lsquo;date&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;OrderAddress&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Freight&rsquo;,&nbsp;type:&nbsp;&lsquo;number&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Price&rsquo;,&nbsp;type:&nbsp;&lsquo;number&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;City&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;ProductName&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Address&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;&lsquo;orderdetailsextended.xml&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;root:&nbsp;&lsquo;DATA&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;record:&nbsp;&lsquo;ROW&rsquo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dataAdapter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;$.jqx.dataAdapter(source,&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadComplete:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;create&nbsp;jqxgrid.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;<span class="js__num">900</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source:&nbsp;dataAdapter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;autorowheight:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;altrows:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnsresize:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Supplier&nbsp;Name&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;SupplierName&rsquo;,&nbsp;width:&nbsp;<span class="js__num">110</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Name&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;ProductName&rsquo;,&nbsp;width:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">80</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Freight&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Freight&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;<span class="js__object">Date</span>&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;datafield:&nbsp;&lsquo;OrderDate&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Address&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;OrderAddress&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Price&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Price&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;c2&prime;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">70</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Address&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;Location&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Address&rsquo;,&nbsp;width:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;City&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;Location&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;City&rsquo;,&nbsp;width:&nbsp;<span class="js__num">80</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columngroups:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Product&nbsp;Details&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;ProductDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Details&rsquo;,&nbsp;parentgroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;OrderDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Location&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;Location&rsquo;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#excelExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#xmlExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#csvExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#tsvExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#htmlExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jsonExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#excelExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;xls&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#xmlExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;xml&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#csvExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;csv&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#tsvExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;tsv&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#htmlExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;html&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jsonExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;json&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#print&rdquo;).jqxButton();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#print&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;gridContent&nbsp;=&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;html&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newWindow&nbsp;=&nbsp;window.open(&rdquo;,&nbsp;&rdquo;,&nbsp;&lsquo;width=<span class="js__num">800</span>,&nbsp;height=<span class="js__num">500</span>&prime;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document&nbsp;=&nbsp;newWindow.document.open(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageContent&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;!DOCTYPE&nbsp;html&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;html&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;head&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;meta&nbsp;charset=&rdquo;utf<span class="js__num">-8</span>&Prime;&nbsp;/&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;title&gt;jQWidgets&nbsp;Grid&lt;/title&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;/head&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;body&gt;\n&rsquo;&nbsp;&#43;&nbsp;gridContent&nbsp;&#43;&nbsp;&lsquo;\n&lt;<span class="js__reg_exp">/body&gt;\n&lt;/</span>html&gt;&rsquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(pageContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newWindow.print();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">In the preceding script you can see a code part as follows:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_444842">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">columngroups:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Product&nbsp;Details&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;ProductDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Details&rsquo;,&nbsp;parentgroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;OrderDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Location&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;Location&rsquo;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">This is where the column grouping is happening. And if you want to add a column under this column you can set that as follows:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_928994">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Name&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;ProductName&rsquo;,&nbsp;width:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">You can specify this as needed and your data source.Now this is how our page looks like.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_842263">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=&ldquo;en&rdquo;&gt;&nbsp;
&lt;head&gt;&nbsp;
&lt;title&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;rel=&ldquo;stylesheet&rdquo;&nbsp;href=&ldquo;jqwidgets/styles/jqx.base.css&rdquo;&nbsp;type=&ldquo;text<span class="js__reg_exp">/css&rdquo;&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;scripts/jquery<span class="js__num">-1.11</span><span class="js__num">.1</span>.min.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxcore.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxdata.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxbuttons.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxscrollbar.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxlistbox.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxdropdownlist.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxmenu.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.filter.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.sort.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxgrid.selection.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxpanel.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;jqwidgets/jqxcheckbox.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&nbsp;src=&ldquo;scripts/demos.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;generatedata.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.pager.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.edit.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.columnsresize.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.columnsreorder.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxgrid.export.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=&ldquo;jqwidgets/jqxdata.export.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;prepare&nbsp;the&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;source&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datatype:&nbsp;&ldquo;xml&rdquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datafields:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;SupplierName&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;type:&nbsp;&lsquo;number&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;OrderDate&rsquo;,&nbsp;type:&nbsp;&lsquo;date&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;OrderAddress&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Freight&rsquo;,&nbsp;type:&nbsp;&lsquo;number&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Price&rsquo;,&nbsp;type:&nbsp;&lsquo;number&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;City&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;ProductName&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;&lsquo;Address&rsquo;,&nbsp;type:&nbsp;&lsquo;string&rsquo;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;&lsquo;orderdetailsextended.xml&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;root:&nbsp;&lsquo;DATA&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;record:&nbsp;&lsquo;ROW&rsquo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dataAdapter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;$.jqx.dataAdapter(source,&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadComplete:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;create&nbsp;jqxgrid.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;<span class="js__num">900</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source:&nbsp;dataAdapter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;autorowheight:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;altrows:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnsresize:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Supplier&nbsp;Name&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;SupplierName&rsquo;,&nbsp;width:&nbsp;<span class="js__num">110</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Name&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;ProductName&rsquo;,&nbsp;width:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">80</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Freight&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Freight&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;<span class="js__object">Date</span>&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;datafield:&nbsp;&lsquo;OrderDate&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Address&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;OrderAddress&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Price&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Price&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;c2&prime;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">70</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Address&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;Location&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Address&rsquo;,&nbsp;width:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;City&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;Location&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;City&rsquo;,&nbsp;width:&nbsp;<span class="js__num">80</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columngroups:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Product&nbsp;Details&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;ProductDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Details&rsquo;,&nbsp;parentgroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;OrderDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Location&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;Location&rsquo;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#excelExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#xmlExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#csvExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#tsvExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#htmlExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jsonExport&rdquo;).jqxButton(<span class="js__brace">{</span>&nbsp;theme:&nbsp;theme&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#excelExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;xls&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#xmlExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;xml&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#csvExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;csv&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#tsvExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;tsv&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#htmlExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;html&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jsonExport&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;json&rsquo;,&nbsp;&lsquo;jqxGrid&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#print&rdquo;).jqxButton();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&ldquo;#print&rdquo;).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;gridContent&nbsp;=&nbsp;$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&lsquo;exportdata&rsquo;,&nbsp;&lsquo;html&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newWindow&nbsp;=&nbsp;window.open(&rdquo;,&nbsp;&rdquo;,&nbsp;&lsquo;width=<span class="js__num">800</span>,&nbsp;height=<span class="js__num">500</span>&prime;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document&nbsp;=&nbsp;newWindow.document.open(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageContent&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;!DOCTYPE&nbsp;html&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;html&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;head&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;meta&nbsp;charset=&rdquo;utf<span class="js__num">-8</span>&Prime;&nbsp;/&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;title&gt;jQWidgets&nbsp;Grid&lt;/title&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;/head&gt;\n&rsquo;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lsquo;&lt;body&gt;\n&rsquo;&nbsp;&#43;&nbsp;gridContent&nbsp;&#43;&nbsp;&lsquo;\n&lt;<span class="js__reg_exp">/body&gt;\n&lt;/</span>html&gt;&rsquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(pageContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newWindow.print();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&nbsp;class=&lsquo;<span class="js__statement">default</span>&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=&lsquo;jqxWidget&rsquo;&nbsp;style=&ldquo;font-size:&nbsp;13px;&nbsp;font-family:&nbsp;Verdana;&nbsp;float:&nbsp;left;&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=&ldquo;jqxgrid&rdquo;&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-top:&nbsp;20px;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;Excel&rdquo;&nbsp;id=&lsquo;excelExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;XML&rdquo;&nbsp;id=&lsquo;xmlExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-left:&nbsp;10px;&nbsp;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;CSV&rdquo;&nbsp;id=&lsquo;csvExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;TSV&rdquo;&nbsp;id=&lsquo;tsvExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-left:&nbsp;10px;&nbsp;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;HTML&rdquo;&nbsp;id=&lsquo;htmlExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Export&nbsp;to&nbsp;JSON&rdquo;&nbsp;id=&lsquo;jsonExport&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&lsquo;margin-left:&nbsp;10px;&nbsp;float:&nbsp;left;&rsquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Print&rdquo;&nbsp;id=&lsquo;print&rsquo;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">That is all. We have successfully created a wonderful JQX Grid as in the following:</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_8991"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/advanced-jqx-grid-with-all-functionality1.jpg"><img class="size-full x_x_wp-image-8991" src="-advanced-jqx-grid-with-all-functionality1.jpg" alt="Advanced JQX Grid With All Functionality" width="650" height="528"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Advanced JQX Grid With All Functionality</span></p>
</div>
<div class="wp-caption x_x_alignnone" id="attachment_9001"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/advanced-jqx-grid-with-all-functionality2.jpg"><img class="size-full x_x_wp-image-9001" src="-advanced-jqx-grid-with-all-functionality2.jpg" alt="Advanced JQX Grid With All Functionality" width="650" height="536"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Advanced JQX Grid With All Functionality</span></p>
</div>
<div class="wp-caption x_x_alignnone" id="attachment_9011"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/advanced-jqx-grid-with-all-functionality3.jpg"><img class="size-full x_x_wp-image-9011" src="-advanced-jqx-grid-with-all-functionality3.jpg" alt="Advanced JQX Grid With All Functionality" width="650" height="530"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Advanced JQX Grid With All Functionality</span></p>
</div>
<p><span style="font-size:small">Now you may think, why are those export buttons outside? It looks different, right? Now we can work on it. In the JQX Grid there is an option called showtoolbar, by setting this to true we can have a toolbar along with the grid.
 There we can bind all of these buttons if you want. So shall we start?</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_495507">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">showtoolbar:&nbsp;true,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Add that line to your JQX grid implementation. Next we need to append the UI elements to the tool bar, right?</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_27112">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">rendertoolbar:<span class="js__operator">function</span>&nbsp;(toolbar)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;me&nbsp;=&nbsp;<span class="js__operator">this</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;container&nbsp;=&nbsp;$(&ldquo;&lt;div&nbsp;&gt;&lt;/div&gt;&rdquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;input&nbsp;=&nbsp;$(&lsquo;&lt;div&nbsp;id=&rdquo;excelExport&rdquo;&nbsp;style=&rdquo;background-color:&nbsp;#<span class="js__num">555555</span>;float:&nbsp;left;&nbsp;font-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;weight:&nbsp;bold;line-height:&nbsp;28px;&nbsp;min-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;80px;padding:&nbsp;3px&nbsp;5px&nbsp;3px&nbsp;10px;color:&nbsp;#fff;&nbsp;&ldquo;&gt;Excel&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;div&nbsp;style=&rdquo;background-color:&nbsp;#<span class="js__num">555555</span>;float:&nbsp;left;&nbsp;font-weight:&nbsp;bold;line-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;height:&nbsp;28px;&nbsp;min-width:&nbsp;80px;padding:&nbsp;3px&nbsp;5px&nbsp;3px&nbsp;10px;color:&nbsp;#fff;&nbsp;margin-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;left:&nbsp;3px;&rdquo;&nbsp;id=&rdquo;print&rdquo;&nbsp;&gt;Print&lt;<span class="js__reg_exp">/div&gt;&lt;/</span>div&gt;&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;toolbar.append(container);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;container.append(input);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Add the preceding function also.&nbsp;Now this is how your JQX Grid Implementation must be:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_515919">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(&ldquo;#jqxgrid&rdquo;).jqxGrid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;<span class="js__num">900</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source:&nbsp;dataAdapter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageable:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;autorowheight:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;altrows:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnsresize:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;showtoolbar:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rendertoolbar:&nbsp;<span class="js__operator">function</span>&nbsp;(toolbar)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;me&nbsp;=&nbsp;<span class="js__operator">this</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;container&nbsp;=&nbsp;$(&ldquo;&lt;div&nbsp;&gt;&lt;/div&gt;&rdquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;input&nbsp;=&nbsp;$(&lsquo;&lt;div&nbsp;id=&rdquo;div1&Prime;&nbsp;style=&rdquo;background-color:&nbsp;#<span class="js__num">555555</span>;float:&nbsp;left;&nbsp;font-weight:&nbsp;bold;line-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;height:&nbsp;28px;&nbsp;min-width:&nbsp;80px;padding:&nbsp;3px&nbsp;5px&nbsp;3px&nbsp;10px;color:&nbsp;#fff;&nbsp;&ldquo;&gt;Your&nbsp;First&nbsp;Div&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=&rdquo;background-color:&nbsp;#<span class="js__num">555555</span>;float:&nbsp;left;&nbsp;font-weight:&nbsp;bold;line-height:&nbsp;28px;&nbsp;min-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;80px;padding:&nbsp;3px&nbsp;5px&nbsp;3px&nbsp;10px;color:&nbsp;#fff;&nbsp;margin-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;left:&nbsp;3px;&rdquo;&nbsp;id=&rdquo;Div2&Prime;&nbsp;&gt;Your&nbsp;Second&nbsp;Div&lt;<span class="js__reg_exp">/div&gt;&lt;/</span>div&gt;&rsquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;toolbar.append(container);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;container.append(input);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Supplier&nbsp;Name&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;SupplierName&rsquo;,&nbsp;width:&nbsp;<span class="js__num">110</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Name&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;ProductName&rsquo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;width:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Quantity&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;cente&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">80</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Freight&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Freight&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;<span class="js__object">Date</span>&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;d&rsquo;,&nbsp;da&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tafield:&nbsp;&lsquo;OrderDate&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Address&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;OrderDetails&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Order&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address&rsquo;,&nbsp;width:&nbsp;<span class="js__num">100</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Price&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Price&rsquo;,&nbsp;cellsformat:&nbsp;&lsquo;c2&prime;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;cellsa&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lign:&nbsp;&lsquo;center&rsquo;,&nbsp;width:&nbsp;<span class="js__num">70</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Address&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;Location&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;Address&rsquo;,&nbsp;width&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="js__num">120</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;City&rsquo;,&nbsp;columngroup:&nbsp;&lsquo;Location&rsquo;,&nbsp;cellsalign:&nbsp;&lsquo;center&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;datafield:&nbsp;&lsquo;City&rsquo;,&nbsp;width:&nbsp;<span class="js__num">80</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columngroups:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Product&nbsp;Details&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;ProductDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Order&nbsp;Details&rsquo;,&nbsp;parentgroup:&nbsp;&lsquo;ProductDetails&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;OrderDetails&rsquo;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;text:&nbsp;&lsquo;Location&rsquo;,&nbsp;align:&nbsp;&lsquo;center&rsquo;,&nbsp;name:&nbsp;&lsquo;Location&rsquo;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now your output looks like the following:</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_9021"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/advanced-jqx-grid-with-all-functionality4.jpg"><img class="size-full x_x_wp-image-9021" src="-advanced-jqx-grid-with-all-functionality4.jpg" alt="Advanced JQX Grid With All Functionality" width="650" height="522"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Advanced JQX Grid With All Functionality</span></p>
</div>
<p><span style="font-size:small">What if you want to share this Grid with your friends? For that we have a jQuery share pluggin,<a href="http://www.jqueryscript.net/social-media/Minimal-jQuery-Plugin-For-Social-Share-Buttons-Sharer.html" target="_blank">Minimal
 jQuery Plugin For Social Share Buttons &ndash; Sharer</a>.</span></p>
<p><span style="font-size:small">Include the following files from the downloded rar from the preceding link</span></p>
<li><span style="font-size:small">jquery.sharer.css</span> </li><li><span style="font-size:small">jquery.sharer.js</span> </li><li><span style="font-size:small">sharer.png</span>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_458545"></div>
<div class="syntaxhighlighter jscript">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;link&nbsp;href=&ldquo;styles/jquery.sharer.css&rdquo;&nbsp;rel=&ldquo;stylesheet&rdquo;&nbsp;type=&ldquo;text/css&rdquo;&nbsp;/&gt;&nbsp;
&lt;script&nbsp;src=&ldquo;scripts/jquery.sharer.js&rdquo;&nbsp;type=&ldquo;text/javascript&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Include the script to your page</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_153115">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(&ldquo;.social-buttons&rdquo;).sharer();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Add a div where you can see the share buttons</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_660334">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;class=&ldquo;social-buttons&rdquo;&nbsp;style=&ldquo;position:&nbsp;relative;z-index:&nbsp;<span class="js__num">1000</span>;&rdquo;&gt;&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Well, that&rsquo;s all; you have now done everything. We can now see the page as,</span></div>
</div>
</div>
<div class="wp-caption x_x_alignnone" id="attachment_9031"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/advanced-jqx-grid-with-all-functionality5.jpg"><img class="size-full x_x_wp-image-9031" src="-advanced-jqx-grid-with-all-functionality5.jpg" alt="Advanced JQX Grid With All Functionality" width="650" height="478"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Advanced JQX Grid With All Functionality</span></p>
</div>
<p><span style="font-size:small">To set the page size add the following line to your grid settings:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_553102">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">pagesize:&nbsp;<span class="js__num">50</span>,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">To set the custom pagesize options add the following line to your grid settings:</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_320967">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">pagesizeoptions:&nbsp;[&lsquo;<span class="js__num">5</span>&prime;,&rsquo;<span class="js__num">10</span>&rsquo;,&rsquo;<span class="js__num">15</span>&rsquo;,&rsquo;<span class="js__num">20</span>&rsquo;,&rsquo;<span class="js__num">30</span>&rsquo;,&rsquo;<span class="js__num">40</span>&rsquo;,&rsquo;<span class="js__num">50</span>&rsquo;],&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">To allow resizing of the columns add the following line to your grid settings:</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_754727">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">columnsresize:&nbsp;true,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">To allow column re-ordering options add the following line to your grid settings:</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_188181">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">columnsreorder:&nbsp;true,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Be sure that you added the&nbsp;</span><em style="font-size:small">jqxgrid.columnsreorder.js</em><span style="font-size:small">&nbsp;JavaScript file.</span></div>
</div>
</div>
<p><span style="font-size:small">To allow an Excel-like filter add the following line to your grid settings:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_258036">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">filtermode:&nbsp;&lsquo;excel&rsquo;,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Then you will get a filtering option as follows:</span></div>
</div>
</div>
<div class="wp-caption x_x_alignnone" id="attachment_9041"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/advanced-jqx-grid-with-all-functionality6.jpg"><img class="size-full x_x_wp-image-9041" src="-advanced-jqx-grid-with-all-functionality6.jpg" alt="Advanced JQX Grid With All Functionality" width="650" height="407"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Advanced JQX Grid With All Functionality</span></p>
</div>
<p><span style="font-size:small">To enable the tooltip add the following line to your grid settings</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_737773">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">enabletooltips:&nbsp;true,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">To apply themes add the following line to your grid settings</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_234467">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">theme:&nbsp;&lsquo;metro&rsquo;,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Please be noted that you must include the style sheet accordingly, In this case you have to include the following</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter xml" id="highlighter_249035">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;link&nbsp;href=&ldquo;~<span class="js__reg_exp">/jqwidgets/</span>styles<span class="js__reg_exp">/jqx.metro.css&rdquo;&nbsp;rel=&ldquo;stylesheet&rdquo;&nbsp;/</span>&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">You can find so many CSS in&nbsp;</span><em style="font-size:small">jqwidgets/styles</em><span style="font-size:small">&nbsp;folder.</span></div>
</div>
</div>
<p><span style="font-size:small">To enable auto height add the following line to your grid settings</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_235444">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">autoheight:&nbsp;true,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">To show the default filter icon always add the following line to your grid settings</span></div>
</div>
</div>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_586101">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">autoshowfiltericon:&nbsp;false,&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Happy Coding.</span></div>
</div>
</div>
</li>