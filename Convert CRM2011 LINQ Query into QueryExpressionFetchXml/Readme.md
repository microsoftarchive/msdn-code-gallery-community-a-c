# Convert CRM2011 LINQ Query into QueryExpression/FetchXml
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Dynamics CRM
- Microsoft Dynamics CRM 2011
## Topics
- LINQ
## Updated
- 01/05/2012
## Description

<h1>Introduction</h1>
<p>With the introduction of Linq within the Dynamics CRM 2011 sdk, I've more or less stopped using QueryExpressions and FetchXml in server side code. This makes it increasingly painful when I've got to convert my queries to fetchXml or QueryExpressions for
 use in Javascript or Silverlight code. This sample shows how you can convert those linq queries into a QueryExpression or FetchXml by way of a command line utility.</p>
<p>This is a useful tool for debugging your linq queries as well to check that they are going to execute as you expect - however I would highly recommend LinqPad for a more indepth debuger/learning tool (www.linqpad.net).</p>
<p>This sample also demonstrates how to compile a Linq query from a text string - although this is something that shouldn't be done to get round the lack of dynamic query support in Linq - please see :&nbsp;<a href="http://code.msdn.microsoft.com/Dynamically-construct-a-e34c2593">http://code.msdn.microsoft.com/Dynamically-construct-a-e34c2593</a>&nbsp;for
 an example of how to do this.</p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample is built using VS2010 and runs as a Console application.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The main challenge was how to find the Query Expression from a linq query. This is solved by accessing a private method named 'GetQueryExpression'.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">QueryExpression query = (QueryExpression)linq.Provider.GetType().InvokeMember(&quot;GetQueryExpression&quot;, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, linq.Provider, arguments);</pre>
<div class="preview">
<pre class="csharp">QueryExpression&nbsp;query&nbsp;=&nbsp;(QueryExpression)linq.Provider.GetType().InvokeMember(<span class="cs__string">&quot;GetQueryExpression&quot;</span>,&nbsp;BindingFlags.InvokeMethod&nbsp;|&nbsp;BindingFlags.Public&nbsp;|&nbsp;BindingFlags.NonPublic&nbsp;|&nbsp;BindingFlags.Instance,&nbsp;<span class="cs__keyword">null</span>,&nbsp;linq.Provider,&nbsp;arguments);</pre>
</div>
</div>
</div>
<p>When you run the sample, you are prompted first to enter the details of your CRM server, and then you can enter a linq query. The Context must be named ctx - so a query would look like:</p>
<p>&gt;from c in ctx.CreateQuery&lt;Contact&gt;()</p>
<p>&gt;select c</p>
<p>To convert your query, simply press enter with a blank line.</p>
<p>The query is output to the console as well as saved as a text file for future reference.</p>
<ul>
</ul>
