# CSR code samples #1 (Task Priority color)
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Sharepoint Online
- SharePoint Server 2013
- SharePoint Foundation 2013
- SharePoint 2013
## Topics
- SharePoint
- SharePoint List
- SharePoint client object model (CSOM)
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p><span>This JSLink sample allows you to change the priority field&nbsp;text color based on the&nbsp;task priority level (</span><span style="color:#ff0000">High</span><span>,&nbsp;</span><span style="color:#ff6600">Normal&nbsp;</span><span>and&nbsp;</span><span style="color:#ffcc00">Low</span><span>).</span></p>
<p>&nbsp;</p>
<p><strong>Note:</strong>&nbsp;This sample is part from&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series of samples to learn you how to work with CSR templates</a>.</p>
<p><span><br>
</span></p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2><span style="font-size:20px; font-weight:bold"><span>Screenshot</span></span></h2>
<p><img id="109731" src="109731-js%20link%20(list%20view%20%e2%80%93%20tasks%20list%20priority%20color).png" alt="JS-Link" width="520" height="350" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2><span>Deployment steps:</span></h2>
<ol>
<li>Create a&nbsp;<strong>Tasks&nbsp;</strong>list </li><li>Create new view that contains the&nbsp;<strong>Priority&nbsp;</strong>field </li><li>Edit the&nbsp;<strong>List View</strong>&nbsp;page&nbsp; </li><li>Go to List view&nbsp;<strong>web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/PriorityColor.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
 &nbsp;
<p><img id="109732" src="109732-list%20view%20web-part%20properties%20js%20link.png" alt="JS Link WebPart" width="276" height="454" style="border:1px solid black"></p>
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List View &ndash; Priority Color Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var priorityFiledContext = {};
    priorityFiledContext.Templates = {};
    priorityFiledContext.Templates.Fields = {
        // Apply the new rendering for Priority field on List View
        &quot;Priority&quot;: { &quot;View&quot;: priorityFiledTemplate }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(priorityFiledContext);

})();

// This function provides the rendering logic for list view
function priorityFiledTemplate(ctx) {

    var priority = ctx.CurrentItem[ctx.CurrentFieldSchema.Name];

    // Return html element with appropriate color based on priority value
    switch (priority) {
        case &quot;(1) High&quot;:
            return &quot;&lt;span style='color :#f00'&gt;&quot; &#43; priority &#43; &quot;&lt;/span&gt;&quot;;
            break;
        case &quot;(2) Normal&quot;:
            return &quot;&lt;span style='color :#ff6a00'&gt;&quot; &#43; priority &#43; &quot;&lt;/span&gt;&quot;;
            break;
        case &quot;(3) Low&quot;:
            return &quot;&lt;span style='color :#cab023'&gt;&quot; &#43; priority &#43; &quot;&lt;/span&gt;&quot;;
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;List&nbsp;View&nbsp;&ndash;&nbsp;Priority&nbsp;Color&nbsp;Sample</span>&nbsp;
<span class="cs__com">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(function&nbsp;()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;priorityFiledContext&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;priorityFiledContext.Templates&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;priorityFiledContext.Templates.Fields&nbsp;=&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Priority&nbsp;field&nbsp;on&nbsp;List&nbsp;View</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Priority&quot;</span>:&nbsp;{&nbsp;<span class="cs__string">&quot;View&quot;</span>:&nbsp;priorityFiledTemplate&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(priorityFiledContext);&nbsp;
&nbsp;
})();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic&nbsp;for&nbsp;list&nbsp;view</span>&nbsp;
function&nbsp;priorityFiledTemplate(ctx)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;priority&nbsp;=&nbsp;ctx.CurrentItem[ctx.CurrentFieldSchema.Name];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Return&nbsp;html&nbsp;element&nbsp;with&nbsp;appropriate&nbsp;color&nbsp;based&nbsp;on&nbsp;priority&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(priority)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;(1)&nbsp;High&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;style='color&nbsp;:#f00'&gt;&quot;</span>&nbsp;&#43;&nbsp;priority&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/span&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;(2)&nbsp;Normal&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;style='color&nbsp;:#ff6a00'&gt;&quot;</span>&nbsp;&#43;&nbsp;priority&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/span&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;(3)&nbsp;Low&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;style='color&nbsp;:#cab023'&gt;&quot;</span>&nbsp;&#43;&nbsp;priority&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/span&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h2><strong>What you should learn if you browse this code sample (PriorityColor.js)?</strong></h2>
<p>If you look at&nbsp;this code sample, you will see how to create the&nbsp;<strong>Field Context</strong>&nbsp;object, and select the field&nbsp;that you want to change its output render. Then the code show you how the&nbsp;<strong>priorityFiledTemplate&nbsp;</strong>function
 catches the context then returns&nbsp;the output render html.</p>
