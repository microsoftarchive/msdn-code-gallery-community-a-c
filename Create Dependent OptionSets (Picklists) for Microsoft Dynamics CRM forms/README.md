# Create Dependent OptionSets (Picklists) for Microsoft Dynamics CRM forms
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Javascript
- Microsoft Dynamics CRM 2016
## Topics
- Form Scripting
## Updated
- 06/24/2018
## Description

<p>It is a common requirement that the values in one option set field need to be filtered by a value chosen in another option set field. This topic describes one approach to achieve this requirement with a re-usable JScript library, form events, and a JavaScript
 web resource containing configuration data as JSON.</p>
<p>To observe and verify the functionality of this sample you can install the DependentOptionSetsSample_2_0_0_0_target_CRM_8.0_managed.zip managed solution included with the Visual Studio solution containing the sample code</p>
<p>This is the same sample available in the MSDN Library:&nbsp;<a title="Sample: Create dependent OptionSets (picklists)" href="http://msdn.microsoft.com/library/gg594433.aspx" target="_blank">Sample: Create dependent OptionSets (picklists)</a></p>
<h1>Goals for this Solution</h1>
<p>This solution is intended to meet the following requirements:</p>
<ul>
<li>It provides a generic, re-usable JScript library that can be used for any pair of option set fields.
</li></ul>
<ul class="unordered">
<li>
<p>It allows for a chain of dependent option set fields. Because the options of each dependent option set field are filtered based on the value of another field, additional option set field options can be filtered by the option chosen in the first dependent
 option set field. This allows for the possibility of a set of hierarchically dependent option set fields.</p>
</li></ul>
<ul class="unordered">
<li>
<p>The filtering of dependent options is set as JSON in a JavaScript web resource. This allows for changing the option mappings without changing the code. Editing JSON data in a JavaScript web resource is easier for a non-developer to configure options with
 less opportunity to break the code.</p>
</li></ul>
<ul>
<li>The solution supports multiple languages. The filtering is based solely on the data value of the options rather than any text in the options.
</li><li>Filtering works for any number of instances of an attribute control on the form.
</li></ul>
<h1>Example</h1>
<p>This section describes one application of this approach and the procedure to apply the sample library.</p>
<p>The <strong>Ticket</strong> (sample_ticket) entity form has three option set fields and options that allow for categorization of products. The following table shows the desired filtering of options set options.</p>
<table>
<tbody>
<tr>
<th><strong>Category<br>
</strong><code>(sample_category)</code> </th>
<th><strong>Sub Category<br>
</strong><code>(sample_subcategory)</code> </th>
<th><strong>Type<br>
</strong><code>(sample_type)</code> </th>
</tr>
<tr>
<td rowspan="11">
<p><strong>Value:</strong>727000000 <strong>Label:</strong> Software</p>
</td>
<td rowspan="4">
<p><strong>Value:</strong>727000000 <strong>Label:</strong> Personal Productivity</p>
</td>
<td>
<p><strong>Value:</strong>727000000 <strong>Label:</strong> Word Processor</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000001 <strong>Label:</strong> Spreadsheet</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000002 <strong>Label:</strong> Internet Browser</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000003 <strong>Label:</strong> E-mail</p>
</td>
</tr>
<tr>
<td rowspan="3">
<p><strong>Value:</strong>727000001 <strong>Label:</strong> Business Applications</p>
</td>
<td>
<p><strong>Value:</strong>727000004 <strong>Label:</strong> Customer Relationship Management</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000005 <strong>Label:</strong> Enterprise Resource Management</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000006 <strong>Label:</strong> Human Resource Management</p>
</td>
</tr>
<tr>
<td rowspan="4">
<p><strong>Value:</strong>727000002 <strong>Label:</strong> Operating Systems</p>
</td>
<td>
<p><strong>Value:</strong>727000007 <strong>Label:</strong> Windows 10</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000008 <strong>Label:</strong> Windows 8</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000009 <strong>Label:</strong> Windows Server 2016</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000010 <strong>Label:</strong> Windows Server 2012</p>
</td>
</tr>
<tr>
<td rowspan="19">
<p><strong>Value:</strong>727000001 <strong>Label:</strong> Hardware</p>
</td>
<td rowspan="4">
<p><strong>Value:</strong>727000003 <strong>Label:</strong> Desktop Computer</p>
</td>
<td>
<p><strong>Value:</strong>727000011 <strong>Label:</strong> Workstation x1000</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000012 <strong>Label:</strong> Workstation x2000</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000013 <strong>Label:</strong> Workstation x3000</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000014 <strong>Label:</strong> Workstation x4000</p>
</td>
</tr>
<tr>
<td rowspan="4">
<p><strong>Value:</strong>727000004 <strong>Label:</strong> Laptop Computer</p>
</td>
<td>
<p><strong>Value:</strong>727000015 <strong>Label:</strong> Laptop 1000 series</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000016 <strong>Label:</strong> Laptop 2000 series</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000017 <strong>Label:</strong> Laptop 3000 series</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000018 <strong>Label:</strong> Laptop 4000 series</p>
</td>
</tr>
<tr>
<td rowspan="4">
<p><strong>Value:</strong>727000005 <strong>Label:</strong> Monitor</p>
</td>
<td>
<p><strong>Value:</strong>727000019 <strong>Label:</strong> CRT</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000020 <strong>Label:</strong> LCD</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000021 <strong>Label:</strong> LED</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000022 <strong>Label:</strong> Projector</p>
</td>
</tr>
<tr>
<td rowspan="4">
<p><strong>Value:</strong>727000006 <strong>Label:</strong> Printer</p>
</td>
<td>
<p><strong>Value:</strong>727000023 <strong>Label:&nbsp;</strong>Inkjet</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000024 <strong>Label:</strong> Laser</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000025 <strong>Label:</strong> LED</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000026 <strong>Label:</strong> Solid-ink</p>
</td>
</tr>
<tr>
<td rowspan="3">
<p><strong>Value:</strong>727000007 <strong>Label:</strong> Telephone</p>
</td>
<td>
<p><strong>Value:</strong>727000027 <strong>Label:</strong> Landline</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000028 <strong>Label:</strong> Mobile</p>
</td>
</tr>
<tr>
<td>
<p><strong>Value:</strong>727000029 <strong>Label:</strong> Smart Phone</p>
</td>
</tr>
</tbody>
</table>
<h2>To Enable Filtering</h2>
<ol>
<li>
<p>Convert the desired filtering of options into the following JSON document and upload it as an JavaScript web resource titled
<strong>sample_TicketDependentOptionSetConfig.js</strong>.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">[&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;parent&quot;</span>:&nbsp;<span class="js__string">&quot;sample_category&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;child&quot;</span>:&nbsp;<span class="js__string">&quot;sample_subcategory&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;options&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000000&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000000&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000001&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000002&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000001&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000003&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000004&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000005&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000006&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000007&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;parent&quot;</span>:&nbsp;<span class="js__string">&quot;sample_subcategory&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;child&quot;</span>:&nbsp;<span class="js__string">&quot;sample_type&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;options&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000000&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000000&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000001&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000002&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000003&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000001&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000004&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000005&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000006&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000002&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000007&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000008&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000009&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000010&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000003&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000011&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000012&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000013&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000014&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000004&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000015&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000016&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000017&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000018&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000005&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000019&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000020&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000021&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000022&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000006&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000023&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000024&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000025&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000026&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000007&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000027&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000028&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;727000029&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
]</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>
<p>Create a JavaScript web resource named <strong>sample_SDK.DependentOptionSetSample.js</strong> using the following code.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//If&nbsp;the&nbsp;SDK&nbsp;namespace&nbsp;object&nbsp;is&nbsp;not&nbsp;defined,&nbsp;create&nbsp;it.</span>&nbsp;
<span class="js__statement">if</span>&nbsp;(<span class="js__operator">typeof</span>&nbsp;(SDK)&nbsp;==&nbsp;<span class="js__string">&quot;undefined&quot;</span>)&nbsp;
<span class="js__brace">{</span>&nbsp;SDK&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Create&nbsp;Namespace&nbsp;container&nbsp;for&nbsp;functions&nbsp;in&nbsp;this&nbsp;library;</span>&nbsp;
SDK.DependentOptionSet&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
SDK.DependentOptionSet.config&nbsp;=&nbsp;null;&nbsp;
&nbsp;
<span class="js__ml_comment">/**&nbsp;
&nbsp;*&nbsp;@function&nbsp;SDK.DependentOptionSet.init&nbsp;
&nbsp;*&nbsp;@param&nbsp;{string}&nbsp;webResourceName&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;JavaScript&nbsp;web&nbsp;resource&nbsp;containing&nbsp;the&nbsp;JSON&nbsp;definition&nbsp;&nbsp;
&nbsp;*&nbsp;of&nbsp;option&nbsp;dependencies&nbsp;
&nbsp;*/</span>&nbsp;
SDK.DependentOptionSet.init&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(webResourceName)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(SDK.DependentOptionSet.config&nbsp;==&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Retrieve&nbsp;the&nbsp;JavaScript&nbsp;Web&nbsp;Resource&nbsp;specified&nbsp;by&nbsp;the&nbsp;parameter&nbsp;passed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;clientURL&nbsp;=&nbsp;Xrm.Page.context.getClientUrl();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pathToWR&nbsp;=&nbsp;clientURL&nbsp;&#43;&nbsp;<span class="js__string">&quot;/WebResources/&quot;</span>&nbsp;&#43;&nbsp;webResourceName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;xhr&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XMLHttpRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xhr.open(<span class="js__string">&quot;GET&quot;</span>,&nbsp;pathToWR,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xhr.onreadystatechange&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__operator">this</span>.readyState&nbsp;==&nbsp;<span class="js__num">4</span>&nbsp;<span class="js__ml_comment">/*&nbsp;complete&nbsp;*/</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.onreadystatechange&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__operator">this</span>.status&nbsp;==&nbsp;<span class="js__num">200</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDK.DependentOptionSet.config&nbsp;=&nbsp;JSON.parse(<span class="js__operator">this</span>.response);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDK.DependentOptionSet.completeInitialization();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__error">Error</span>(<span class="js__string">&quot;Failed&nbsp;to&nbsp;load&nbsp;configuration&nbsp;data&nbsp;for&nbsp;dependent&nbsp;option&nbsp;sets.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xhr.send();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDK.DependentOptionSet.completeInitialization();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>;&nbsp;
&nbsp;
<span class="js__ml_comment">/**&nbsp;
&nbsp;*&nbsp;@function&nbsp;SDK.DependentOptionSet.completeInitialization&nbsp;
&nbsp;*&nbsp;Initializes&nbsp;the&nbsp;dependent&nbsp;option&nbsp;set&nbsp;options&nbsp;when&nbsp;the&nbsp;form&nbsp;loads&nbsp;
&nbsp;*/</span>&nbsp;
SDK.DependentOptionSet.completeInitialization&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//If&nbsp;the&nbsp;parent&nbsp;field&nbsp;is&nbsp;null,&nbsp;make&nbsp;sure&nbsp;the&nbsp;child&nbsp;field&nbsp;is&nbsp;null&nbsp;and&nbsp;disabled</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Otherwise,&nbsp;call&nbsp;fireOnChange&nbsp;to&nbsp;filter&nbsp;the&nbsp;child&nbsp;options</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;SDK.DependentOptionSet.config.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;parentAttribute&nbsp;=&nbsp;Xrm.Page.getAttribute(SDK.DependentOptionSet.config[i].parent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;parentFieldValue&nbsp;=&nbsp;parentAttribute.getValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(parentFieldValue&nbsp;==&nbsp;null&nbsp;||&nbsp;parentFieldValue&nbsp;==&nbsp;-<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;childAttribute&nbsp;=&nbsp;Xrm.Page.getAttribute(SDK.DependentOptionSet.config[i].child);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childAttribute.setValue(null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childAttribute.controls.forEach(<span class="js__operator">function</span>&nbsp;(c)&nbsp;<span class="js__brace">{</span>&nbsp;c.setDisabled(true);&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parentAttribute.fireOnChange();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__ml_comment">/**&nbsp;
&nbsp;*&nbsp;@function&nbsp;SDK.DependentOptionSet.filterDependentField&nbsp;
&nbsp;*&nbsp;Locates&nbsp;the&nbsp;correct&nbsp;set&nbsp;of&nbsp;configurations&nbsp;
&nbsp;*&nbsp;@param&nbsp;{string}&nbsp;parentFieldParam&nbsp;The&nbsp;name&nbsp;of&nbsp;the&nbsp;parent&nbsp;field&nbsp;
&nbsp;*&nbsp;@param&nbsp;{string}&nbsp;childFieldParam&nbsp;The&nbsp;name&nbsp;of&nbsp;the&nbsp;dependent&nbsp;field&nbsp;
&nbsp;*/</span>&nbsp;
SDK.DependentOptionSet.filterDependentField&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(parentFieldParam,&nbsp;childFieldParam)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Looping&nbsp;through&nbsp;the&nbsp;array&nbsp;of&nbsp;all&nbsp;the&nbsp;possible&nbsp;dependency&nbsp;configurations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;SDK.DependentOptionSet.config.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dependentOptionSet&nbsp;=&nbsp;SDK.DependentOptionSet.config[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;Match&nbsp;the&nbsp;parameters&nbsp;to&nbsp;the&nbsp;correct&nbsp;dependent&nbsp;optionset&nbsp;mapping*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;((dependentOptionSet.parent&nbsp;==&nbsp;parentFieldParam)&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(dependentOptionSet.child&nbsp;==&nbsp;childFieldParam))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
<span class="js__ml_comment">/*&nbsp;
*&nbsp;Using&nbsp;setTimeout&nbsp;to&nbsp;allow&nbsp;a&nbsp;little&nbsp;time&nbsp;between&nbsp;calling&nbsp;this&nbsp;potentially&nbsp;recursive&nbsp;function.&nbsp;
*&nbsp;Without&nbsp;including&nbsp;some&nbsp;time&nbsp;between&nbsp;calls,&nbsp;the&nbsp;value&nbsp;at&nbsp;the&nbsp;end&nbsp;of&nbsp;the&nbsp;chain&nbsp;of&nbsp;dependencies&nbsp;&nbsp;
*&nbsp;was&nbsp;being&nbsp;set&nbsp;to&nbsp;null&nbsp;on&nbsp;form&nbsp;load.&nbsp;
*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;setTimeout(SDK.DependentOptionSet.filterOptions,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">100</span>,&nbsp;parentFieldParam,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childFieldParam,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dependentOptionSet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>;&nbsp;
&nbsp;
<span class="js__ml_comment">/**&nbsp;
&nbsp;*&nbsp;@function&nbsp;SDK.DependentOptionSet.filterOptions&nbsp;
&nbsp;*&nbsp;Filters&nbsp;options&nbsp;available&nbsp;in&nbsp;dependent&nbsp;fields&nbsp;when&nbsp;the&nbsp;parent&nbsp;field&nbsp;changes&nbsp;
&nbsp;*&nbsp;@param&nbsp;{string}&nbsp;parentFieldParam&nbsp;The&nbsp;name&nbsp;of&nbsp;the&nbsp;parent&nbsp;field&nbsp;
&nbsp;*&nbsp;@param&nbsp;{string}&nbsp;childFieldParam&nbsp;The&nbsp;name&nbsp;of&nbsp;the&nbsp;dependent&nbsp;field&nbsp;
&nbsp;*&nbsp;@param&nbsp;{object}&nbsp;dependentOptionSet&nbsp;The&nbsp;configuration&nbsp;data&nbsp;for&nbsp;the&nbsp;dependent&nbsp;options&nbsp;
&nbsp;*/</span>&nbsp;
SDK.DependentOptionSet.filterOptions&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(parentFieldParam,&nbsp;childFieldParam,&nbsp;dependentOptionSet)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;Get&nbsp;references&nbsp;to&nbsp;the&nbsp;related&nbsp;fields*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;parentField&nbsp;=&nbsp;Xrm.Page.getAttribute(parentFieldParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;parentFieldValue&nbsp;=&nbsp;parentField.getValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;childField&nbsp;=&nbsp;Xrm.Page.getAttribute(childFieldParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;Capture&nbsp;the&nbsp;current&nbsp;value&nbsp;of&nbsp;the&nbsp;child&nbsp;field*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;currentChildFieldValue&nbsp;=&nbsp;childField.getValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*&nbsp;If&nbsp;the&nbsp;parent&nbsp;field&nbsp;is&nbsp;null,&nbsp;set&nbsp;the&nbsp;Child&nbsp;field&nbsp;to&nbsp;null&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Interactive&nbsp;Service&nbsp;Hub,&nbsp;CRM&nbsp;for&nbsp;Tablets&nbsp;&amp;&nbsp;CRM&nbsp;for&nbsp;phones&nbsp;can&nbsp;return&nbsp;-1&nbsp;when&nbsp;no&nbsp;option&nbsp;selected</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(parentFieldValue&nbsp;==&nbsp;null&nbsp;||&nbsp;parentFieldValue&nbsp;==&nbsp;-<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childField.setValue(null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childField.fireOnChange();&nbsp;<span class="js__sl_comment">//filter&nbsp;any&nbsp;dependent&nbsp;optionsets</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Any&nbsp;attribute&nbsp;may&nbsp;have&nbsp;any&nbsp;number&nbsp;of&nbsp;controls</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;So&nbsp;disable&nbsp;each&nbsp;instance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childField.controls.forEach(<span class="js__operator">function</span>&nbsp;(c)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.setDisabled(true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Nothing&nbsp;more&nbsp;to&nbsp;do&nbsp;when&nbsp;parent&nbsp;attribute&nbsp;is&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;valid&nbsp;child&nbsp;options&nbsp;defined&nbsp;by&nbsp;the&nbsp;configuration</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;validOptionValues&nbsp;=&nbsp;dependentOptionSet.options[parentFieldValue.toString()];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//When&nbsp;the&nbsp;parent&nbsp;field&nbsp;has&nbsp;a&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Any&nbsp;attribute&nbsp;may&nbsp;have&nbsp;more&nbsp;than&nbsp;one&nbsp;control&nbsp;in&nbsp;the&nbsp;form,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;So&nbsp;iterate&nbsp;over&nbsp;each&nbsp;one</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;childField.controls.forEach(<span class="js__operator">function</span>&nbsp;(c)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.setDisabled(false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.clearOptions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;attribute&nbsp;contains&nbsp;the&nbsp;valid&nbsp;options</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;childFieldAttribute&nbsp;=&nbsp;c.getAttribute();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;attribute&nbsp;options&nbsp;for&nbsp;the&nbsp;Interactive&nbsp;Service&nbsp;Hub,&nbsp;CRM&nbsp;for&nbsp;Tablets&nbsp;&amp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;CRM&nbsp;for&nbsp;phones&nbsp;clients&nbsp;do&nbsp;not&nbsp;include&nbsp;a&nbsp;definition&nbsp;for&nbsp;an&nbsp;unselected&nbsp;option.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;will&nbsp;add&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Xrm.Page.context.client.getClient()&nbsp;==&nbsp;<span class="js__string">&quot;Mobile&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.addOption(<span class="js__brace">{</span>&nbsp;text:&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;value:&nbsp;-<span class="js__num">1</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;each&nbsp;option&nbsp;value,&nbsp;get&nbsp;the&nbsp;definition&nbsp;from&nbsp;the&nbsp;attribute&nbsp;and&nbsp;add&nbsp;it&nbsp;to&nbsp;the&nbsp;control.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validOptionValues.forEach(<span class="js__operator">function</span>&nbsp;(optionValue)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Get&nbsp;the&nbsp;option&nbsp;defnition&nbsp;from&nbsp;the&nbsp;attribute</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;option&nbsp;=&nbsp;childFieldAttribute.getOption(<span class="js__function">parseInt</span>(optionValue));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Add&nbsp;the&nbsp;option&nbsp;to&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.addOption(option);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;the&nbsp;value&nbsp;back&nbsp;to&nbsp;the&nbsp;current&nbsp;value&nbsp;if&nbsp;it&nbsp;is&nbsp;a&nbsp;valid&nbsp;value.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(currentChildFieldValue&nbsp;!=&nbsp;null&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validOptionValues.indexOf(currentChildFieldValue.toString())&nbsp;&gt;&nbsp;-<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childField.setValue(currentChildFieldValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Otherwise&nbsp;set&nbsp;it&nbsp;to&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childField.setValue(null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;childField.fireOnChange();&nbsp;<span class="js__sl_comment">//filter&nbsp;any&nbsp;other&nbsp;dependent&nbsp;optionsets</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>
<p>Add the <strong>sample_SDK.DependentOptionSetSample.js</strong> Script web resource to the JScript libraries available for the form.</p>
</li><li>
<p>In the <strong>Onload</strong> event for the form, configure the event handler to call the<strong> SDK.DependentOptionSet.init
</strong>function and pass in the name of the XML web resource as a parameter. Use the field on the
<strong>Handler Properties</strong> dialog box to enter: <span style="font-family:'Courier New'">
&quot;sample_TicketDependentOptionSetConfig.js&quot;</span> into the field <strong>Comma separated list of parameters that will be passed to the function</strong>.</p>
</li><li>
<p>In the <strong>OnChange</strong> event for the <strong>Category</strong> field, set the
<strong>Function</strong> to <strong>SDK.DependentOptionSet.filterDependentField</strong>.</p>
<p>In the <strong>Comma separated list of parameters that will be passed to the function</strong> text box enter:
<span style="font-family:'Courier New'">&quot;sample_category&quot;, &quot;sample_subcategory&quot;</span>.</p>
</li><li>
<p>In the <strong>OnChange</strong> event for the <strong>Sub Category</strong> field, set the
<strong>Function</strong> to <strong>SDK.DependentOptionSet.filterDependentField</strong>.</p>
<p>In the <strong>Comma separated list of parameters that will be passed to the function</strong> text box enter:
<span style="font-family:'Courier New'">&quot;sample_subcategory &quot;, &quot;sample_type&quot;</span>.</p>
</li><li>
<p>Save and publish all customizations.</p>
</li></ol>
<p>When you open the <strong>Ticket</strong> entity form you will find that the <strong>
Sub Category</strong> and <strong>Type</strong> options are filtered depending on the values chosen for their respective option sets.</p>
