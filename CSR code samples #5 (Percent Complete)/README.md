# CSR code samples #5 (Percent Complete)
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
<p>This JSLink sample will show how to add rendering logic for the Task list Percent Complete field, this code will change the file render to be displayed as a progress bar in&nbsp;<strong>View&nbsp;</strong>and&nbsp;<strong>Display&nbsp;</strong>forms, and
 as a scroll input in the&nbsp;<strong>New&nbsp;</strong>and&nbsp;<strong>Edit&nbsp;</strong>forms.</p>
<p><strong>Note:</strong>&nbsp;This sample is part from&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series of samples to learn you how to work with CSR templates</a>.</p>
<p>&nbsp;</p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" title="Using the JSLink property to change the way your field or views are rendered in SharePoint 2013 - See more at: http://zimmergren.net/technical/sp-2013-using-the-spfield-jslink-property-to-change-the-way-your-field-is-rendered-in-sharepoint-2013#sthash.g1A4qJvM.dpuf" href="http://zimmergren.net/technical/sp-2013-using-the-spfield-jslink-property-to-change-the-way-your-field-is-rendered-in-sharepoint-2013" target="_blank">article&nbsp;</a>by
 Tobias Zimmergren.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2>Screenshots</h2>
<p><img id="109741" src="109741-1.png" alt="Tasks List CSR " width="541" height="329" style="border:1px solid black"></p>
<p><img id="109742" src="109742-2.png" alt="Tasks List (JS Link)" width="508" height="332" style="border:1px solid black"></p>
<p><img id="109743" src="109743-3.png" alt="Tasks List Form (Client Side rendering)" width="587" height="387" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<div></div>
<ol>
<li>Create a&nbsp;<strong>Task&nbsp;</strong>List<strong>&nbsp;</strong> </li><li>Create a new View and add&nbsp;<strong>% Complete</strong>&nbsp;field&nbsp;to the view
</li><li>Edit the&nbsp;<strong>Default List View (All Documents)</strong>&nbsp;page </li><li>Go to List View<strong>&nbsp;web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/PercentComplete.js) to&nbsp;<strong>JS link property&nbsp;</strong>under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing
</li><li><strong>&nbsp;</strong>Apply the previous steps on the other forms&nbsp;<strong>Display</strong>,&nbsp;<strong>New&nbsp;</strong>and&nbsp;<strong>Edit</strong>.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;List&nbsp;view,&nbsp;display,&nbsp;add&nbsp;and&nbsp;edit&nbsp;&ndash;&nbsp;Percent&nbsp;Complete&nbsp;Sample</span>&nbsp;
<span class="cs__com">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(function&nbsp;()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;percentCompleteFiledContext&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;percentCompleteFiledContext.Templates&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;percentCompleteFiledContext.Templates.Fields&nbsp;=&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;PercentComplete&nbsp;field&nbsp;on&nbsp;List&nbsp;View,&nbsp;Display,&nbsp;New&nbsp;and&nbsp;Edit&nbsp;forms</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;PercentComplete&quot;</span>:&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;View&quot;</span>:&nbsp;percentCompleteViewFiledTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;DisplayForm&quot;</span>:&nbsp;percentCompleteViewFiledTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;NewForm&quot;</span>:&nbsp;percentCompleteEditFiledTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;EditForm&quot;</span>:&nbsp;percentCompleteEditFiledTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(percentCompleteFiledContext);&nbsp;
&nbsp;
})();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic&nbsp;for&nbsp;View&nbsp;and&nbsp;Display&nbsp;form</span>&nbsp;
function&nbsp;percentCompleteViewFiledTemplate(ctx)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;percentComplete&nbsp;=&nbsp;ctx.CurrentItem[ctx.CurrentFieldSchema.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;&quot;&lt;div&nbsp;style=<span class="cs__string">'background-color:&nbsp;#e5e5e5;&nbsp;width:&nbsp;100px;&nbsp;&nbsp;display:inline-block;'</span>&gt;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;style=<span class="cs__string">'width:&nbsp;&quot;&nbsp;&#43;&nbsp;percentComplete.replace(/\s&#43;/g,&nbsp;'</span><span class="cs__string">')&nbsp;&#43;&nbsp;&quot;;&nbsp;background-color:&nbsp;#0094ff;'</span>&gt;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;nbsp;&lt;/div&gt;&lt;/div&gt;&amp;nbsp;&quot;&nbsp;&#43;&nbsp;percentComplete;&nbsp;
&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic&nbsp;for&nbsp;New&nbsp;and&nbsp;Edit&nbsp;forms</span>&nbsp;
function&nbsp;percentCompleteEditFiledTemplate(ctx)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;formCtx&nbsp;=&nbsp;SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Register&nbsp;a&nbsp;callback&nbsp;just&nbsp;before&nbsp;submit.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formCtx.registerGetValueCallback(formCtx.fieldName,&nbsp;function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;document.getElementById(<span class="cs__string">'inpPercentComplete'</span>).<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;&quot;&lt;input&nbsp;type=<span class="cs__string">'range'</span>&nbsp;id=<span class="cs__string">'inpPercentComplete'</span>&nbsp;name=<span class="cs__string">'inpPercentComplete'</span>&nbsp;min=<span class="cs__string">'0'</span>&nbsp;max=<span class="cs__string">'100'</span>&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oninput=<span class="cs__string">'outPercentComplete.value=inpPercentComplete.value'</span>&nbsp;<span class="cs__keyword">value</span>=<span class="cs__string">'&quot;&nbsp;&#43;&nbsp;formCtx.fieldValue&nbsp;&#43;&nbsp;&quot;'</span>&nbsp;/&gt;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;output&nbsp;name=<span class="cs__string">'outPercentComplete'</span>&nbsp;<span class="cs__keyword">for</span>=<span class="cs__string">'inpPercentComplete'</span>&nbsp;&gt;<span class="cs__string">&quot;&nbsp;&#43;&nbsp;formCtx.fieldValue&nbsp;&#43;&nbsp;&quot;</span>&lt;/output&gt;%&quot;;&nbsp;
&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>What you should learn if you browse this code sample (PercentComplete.js)?</strong></p>
<p>In this code sample you will learn how to use the same JSLink templates with all types of forms View, Display, New and Edit.</p>
