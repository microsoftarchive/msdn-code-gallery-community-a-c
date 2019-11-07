# CSR code samples #10 (Hide Empty Column)
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Sharepoint Online
- SharePoint Server 2013
- SharePoint 2013
## Topics
- Javascript
- Client Side Rendering
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p><span>This JSLink sample allows you to Hide the empty list view columns.</span></p>
<p><strong>Note:</strong>&nbsp;This sample is part from&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series of samples to learn you how to work with CSR templates</a>.</p>
<p><span><br>
</span></p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2><span style="font-size:20px; font-weight:bold"><span>Screenshot</span></span></h2>
<p><img id="125689" src="125689-hide%20empty%20column%20-%20sharepoint%20client%20side%20rendering.png" alt="JS-Link" width="712" height="622" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2><span>Deployment steps:</span></h2>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>list </li><li>Add <strong>Link </strong>column to the list </li><li>Create new view that contains the&nbsp;<strong><strong>Link&nbsp;</strong></strong>field
</li><li>Edit the&nbsp;<strong>List View</strong>&nbsp;page&nbsp; </li><li>Go to List view&nbsp;<strong>web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/HideEmptyColumn.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
 &nbsp;
<p><img id="125690" src="125690-hide%20empty%20column.png" alt="" width="234" height="434" style="border:1px solid black"></p>
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List View &ndash; Hide Empty Column Sample
// Muawiyah Shannak , @MuShannak


(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var linkFiledContext = {};
    linkFiledContext.Templates = {};
   
    // Add OnPostRender event handler to hide the column if empty
    linkFiledContext.OnPostRender = linkOnPostRender;

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(linkFiledContext);

})();


function linkOnPostRender(ctx)
{
    var linkCloumnIsEmpty = 1;

    for (i = 0; i &lt; ctx.ListData.Row.length; i&#43;&#43;) {
        if (ctx.ListData.Row[i][&quot;Link&quot;])
        {
            linkCloumnIsEmpty = 0;
            break;
        }
    }

    //Hide &quot;Link&quot; column if it is empty
    if (linkCloumnIsEmpty) {
        var cell = $(&quot;div [name='Link']&quot;).closest('th');
        var cellIndex = cell[0].cellIndex &#43; 1;

        $('td:nth-child(' &#43; cellIndex &#43; ')').hide();
        $('th:nth-child(' &#43; cellIndex &#43; ')').hide();
    }

}</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;View&nbsp;&ndash;&nbsp;Hide&nbsp;Empty&nbsp;Column&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;linkFiledContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;linkFiledContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;OnPostRender&nbsp;event&nbsp;handler&nbsp;to&nbsp;hide&nbsp;the&nbsp;column&nbsp;if&nbsp;empty</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;linkFiledContext.OnPostRender&nbsp;=&nbsp;linkOnPostRender;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(linkFiledContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;linkOnPostRender(ctx)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;linkCloumnIsEmpty&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;ctx.ListData.Row.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ctx.ListData.Row[i][<span class="js__string">&quot;Link&quot;</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;linkCloumnIsEmpty&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Hide&nbsp;&quot;Link&quot;&nbsp;column&nbsp;if&nbsp;it&nbsp;is&nbsp;empty</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(linkCloumnIsEmpty)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cell&nbsp;=&nbsp;$(<span class="js__string">&quot;div&nbsp;[name='Link']&quot;</span>).closest(<span class="js__string">'th'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cellIndex&nbsp;=&nbsp;cell[<span class="js__num">0</span>].cellIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'td:nth-child('</span>&nbsp;&#43;&nbsp;cellIndex&nbsp;&#43;&nbsp;<span class="js__string">')'</span>).hide();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'th:nth-child('</span>&nbsp;&#43;&nbsp;cellIndex&nbsp;&#43;&nbsp;<span class="js__string">')'</span>).hide();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2><strong>What you should learn if you browse this code sample (HideEmptyColumn.js)?</strong></h2>
<p>If you look at&nbsp;this code sample, you will see how to create the&nbsp;<strong>CSR Context</strong>&nbsp;object, and how to access all reternd list data, then you can use the JQuery to change the view html.</p>
