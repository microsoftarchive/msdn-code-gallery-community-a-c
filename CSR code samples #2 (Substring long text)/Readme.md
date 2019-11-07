# CSR code samples #2 (Substring long text)
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Sharepoint Online
- SharePoint Server 2013
- SharePoint Foundation 2013
## Topics
- SharePoint
- SharePoint List
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p><span>This JSLink sample will show you&nbsp;</span><span>how to make the announcements body text shorter and display the whole announcements body text as a tooltip.</span></p>
<p><strong>Note:</strong>&nbsp;This sample is part from&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series of samples to learn you how to work with CSR templates</a>.</p>
<p><span><br>
</span></p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" title="SharePoint 2013 Client Side Rendering: List Views" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2><span>Screenshot</span></h2>
<p><img id="109733" src="109733-sharepoint%20list%20view%20-%20substring%20long%20string%20csr.png" alt="Client Side Rendering - tooltip" width="774" height="303" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2><span>Deployment steps:<br>
</span></h2>
<ol>
<li>Create an&nbsp;<strong>Announcements&nbsp;</strong>list </li><li>Create a new view that display the&nbsp;<strong>Body&nbsp;</strong>field. </li><li>Edit the&nbsp;<strong>List View</strong>&nbsp;page </li><li>Go to List view&nbsp;<strong>web-part properties</strong>&nbsp;and add the JSLink file (~sitecollection/Style%20Library/JSLink-Samples/SubstringLongText.js) to&nbsp;<strong>JS link property&nbsp;</strong>under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.
</li></ol>
<h2><span><br>
</span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List View - Substring Long String Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var bodyFiledContext = {};
    bodyFiledContext.Templates = {};
    bodyFiledContext.Templates.Fields = {
        // Apply the new rendering for Body field on list view
        &quot;Body&quot;: { &quot;View&quot;: bodyFiledTemplate }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(bodyFiledContext);

})();

// This function provides the rendering logic
function bodyFiledTemplate(ctx) {

    var bodyValue = ctx.CurrentItem[ctx.CurrentFieldSchema.Name];

    //This regex expression use to delete html tags from the Body field
    var regex = /(&lt;([^&gt;]&#43;)&gt;)/ig;

    bodyValue = bodyValue.replace(regex, &quot;&quot;);

    var newBodyValue = bodyValue;

    if (bodyValue &amp;&amp; bodyValue.length &gt;= 100)
    {
        newBodyValue = bodyValue.substring(0, 100) &#43; &quot; ...&quot;;
    }

    return &quot;&lt;span title='&quot; &#43; bodyValue &#43; &quot;'&gt;&quot; &#43; newBodyValue &#43; &quot;&lt;/span&gt;&quot;;
       
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;List&nbsp;View&nbsp;-&nbsp;Substring&nbsp;Long&nbsp;String&nbsp;Sample</span>&nbsp;
<span class="cs__com">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(function&nbsp;()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bodyFiledContext&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bodyFiledContext.Templates&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bodyFiledContext.Templates.Fields&nbsp;=&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Body&nbsp;field&nbsp;on&nbsp;list&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Body&quot;</span>:&nbsp;{&nbsp;<span class="cs__string">&quot;View&quot;</span>:&nbsp;bodyFiledTemplate&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(bodyFiledContext);&nbsp;
&nbsp;
})();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
function&nbsp;bodyFiledTemplate(ctx)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bodyValue&nbsp;=&nbsp;ctx.CurrentItem[ctx.CurrentFieldSchema.Name];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;regex&nbsp;expression&nbsp;use&nbsp;to&nbsp;delete&nbsp;html&nbsp;tags&nbsp;from&nbsp;the&nbsp;Body&nbsp;field</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;regex&nbsp;=&nbsp;/(&lt;([^&gt;]&#43;)&gt;)/ig;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bodyValue&nbsp;=&nbsp;bodyValue.replace(regex,&nbsp;<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;newBodyValue&nbsp;=&nbsp;bodyValue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(bodyValue&nbsp;&amp;&amp;&nbsp;bodyValue.length&nbsp;&gt;=&nbsp;<span class="cs__number">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newBodyValue&nbsp;=&nbsp;bodyValue.substring(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">100</span>)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;...&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;title='&quot;</span>&nbsp;&#43;&nbsp;bodyValue&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&gt;&quot;</span>&nbsp;&#43;&nbsp;newBodyValue&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/span&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h2>What you should learn if you browse this code sample (SubstringLongText.js)?</h2>
<p>If you browse this code sample, it&rsquo;s like previous sample, you will learn the basic steps to work with JS Link templates. And the code shows you&nbsp;<strong>how to use well-known technologies</strong>, such as HTML and JavaScript&nbsp;to easily customize
 SharePoint list views.</p>
