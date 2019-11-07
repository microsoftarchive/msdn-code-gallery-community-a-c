# CSR code samples #3 (Confidential Documents)
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Sharepoint Online
- SharePoint Server 2013
- SharePoint 2013
## Topics
- SharePoint
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p>This JSLink sample will show how to add an icon beside confidential documents name. This icon is added to the document name based on the Confidential field&nbsp;(Yes/No) value.</p>
<p><strong>Note:</strong>&nbsp;This sample is part from&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series of samples to learn you how to work with CSR templates</a>.</p>
<p>&nbsp;</p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" title="SharePoint 2013 Client Side Rendering: List Views" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2>Screenshot</h2>
<p><img id="109735" src="109735-list%20view%20%e2%80%93%20client%20side%20rendering.png" alt="List view – Client side rendering" width="596" height="339" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<div></div>
<ol>
<li>Create a&nbsp;<strong>Documents Library</strong> </li><li>Add a new&nbsp;<strong>column&nbsp;</strong>to the library:&nbsp;<br>
<ul>
<li>Name: Confidential </li><li>Type: Yes/No </li></ul>
</li><li>Edit the&nbsp;<strong>Default List View (All Documents)</strong>&nbsp;page </li><li>Go to List view&nbsp;<strong>web-part properties</strong>&nbsp;and add the JSLink file (~sitecollection/Style%20Library/JSLink-Samples/ConfidentialDocuments.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List view &ndash; Confidential Documents Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var linkFilenameFiledContext = {};
    linkFilenameFiledContext.Templates = {};
    linkFilenameFiledContext.Templates.Fields = {
        // Apply the new rendering for LinkFilename field on list view
        &quot;LinkFilename&quot;: { &quot;View&quot;: linkFilenameFiledTemplate }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(linkFilenameFiledContext);

})();

// This function provides the rendering logic
function linkFilenameFiledTemplate(ctx) {

    var confidential = ctx.CurrentItem[&quot;Confidential&quot;];
    var title = ctx.CurrentItem[&quot;FileLeafRef&quot;];

    // This Regex expression use to delete extension (.docx, .pdf ...) form the file name
    title = title.replace(/\.[^/.]&#43;$/, &quot;&quot;)

    // Check confidential field value
    if (confidential &amp;&amp; confidential.toLowerCase() == 'yes') {
        
        // Render HTML that contains the file name and the confidential icon
        return title &#43; &quot;&amp;nbsp;&lt;img src='/Style%20Library/JSLink-Samples/imgs/Confidential.png' alt='Confidential Document' title='Confidential Document'/&gt;&quot;;
    }
    else
    {
        return title;
    }
}
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;view&nbsp;&ndash;&nbsp;Confidential&nbsp;Documents&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;linkFilenameFiledContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;linkFilenameFiledContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;linkFilenameFiledContext.Templates.Fields&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;LinkFilename&nbsp;field&nbsp;on&nbsp;list&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;LinkFilename&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;View&quot;</span>:&nbsp;linkFilenameFiledTemplate&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(linkFilenameFiledContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;linkFilenameFiledTemplate(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;confidential&nbsp;=&nbsp;ctx.CurrentItem[<span class="js__string">&quot;Confidential&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;title&nbsp;=&nbsp;ctx.CurrentItem[<span class="js__string">&quot;FileLeafRef&quot;</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;Regex&nbsp;expression&nbsp;use&nbsp;to&nbsp;delete&nbsp;extension&nbsp;(.docx,&nbsp;.pdf&nbsp;...)&nbsp;form&nbsp;the&nbsp;file&nbsp;name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;title&nbsp;=&nbsp;title.replace(<span class="js__reg_exp">/\.[^/</span>.]&#43;$/,&nbsp;<span class="js__string">&quot;&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Check&nbsp;confidential&nbsp;field&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(confidential&nbsp;&amp;&amp;&nbsp;confidential.toLowerCase()&nbsp;==&nbsp;<span class="js__string">'yes'</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Render&nbsp;HTML&nbsp;that&nbsp;contains&nbsp;the&nbsp;file&nbsp;name&nbsp;and&nbsp;the&nbsp;confidential&nbsp;icon</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;title&nbsp;&#43;&nbsp;<span class="js__string">&quot;&amp;nbsp;&lt;img&nbsp;src='/Style%20Library/JSLink-Samples/imgs/Confidential.png'&nbsp;alt='Confidential&nbsp;Document'&nbsp;title='Confidential&nbsp;Document'/&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;title;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2>What you should learn if you browse this code sample (ConfidentialDocuments.js)?</h2>
<p>If you browse this code sample, it&rsquo;s like previous sample, you will learn the basic steps to work with JS Link templates. And the code shows you&nbsp;<strong>how to use well-known technologies</strong>, such as HTML and JavaScript&nbsp;to easily customize
 SharePoint list views.</p>
