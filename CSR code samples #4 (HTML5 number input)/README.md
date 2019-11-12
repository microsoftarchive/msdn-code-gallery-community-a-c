# CSR code samples #4 (HTML5 number input)
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
<p>This JSLink sample will demonstrate&nbsp;how to use HTML5 input control Instead of the old HTML in SharePoint New and Edit forms.</p>
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
<h1><img id="109739" src="109739-jsfield.jslink%20list%20new%20and%20edit%20forms.png" alt="JSField.JSLink List New and Edit Forms" width="563" height="239" style="border:1px solid black"></h1>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<div></div>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>List </li><li>Add a new column to the list:&nbsp;
<ul>
<li>Name: Age </li><li>Type: Number </li></ul>
</li><li>Edit the&nbsp;<strong>Default New Form</strong> </li><li>Go to List New Form&nbsp;<strong>web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/HTML5NumberInput.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab&nbsp;<br>
<br>
<img id="109740" src="109740-list%20new%20and%20edit%20form%20(js%20link).png" alt="List New and Edit Form (JS Link)" width="643" height="299" style="border:1px solid black">
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing
</li><li>Apply the previous steps on the&nbsp;<strong>Default Edit Form</strong> </li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;List&nbsp;New&nbsp;and&nbsp;Edit&nbsp;Forms&nbsp;&ndash;&nbsp;HTML5&nbsp;Number&nbsp;Input&nbsp;Sample</span>&nbsp;
<span class="cs__com">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(function&nbsp;()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ageFiledContext&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ageFiledContext.Templates&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ageFiledContext.Templates.Fields&nbsp;=&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Age&nbsp;field&nbsp;on&nbsp;New&nbsp;and&nbsp;Edit&nbsp;forms</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Age&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;NewForm&quot;</span>:&nbsp;ageFiledTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;EditForm&quot;</span>:&nbsp;ageFiledTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(ageFiledContext);&nbsp;
&nbsp;
})();&nbsp;
&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
function&nbsp;ageFiledTemplate(ctx)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;formCtx&nbsp;=&nbsp;SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Register&nbsp;a&nbsp;callback&nbsp;just&nbsp;before&nbsp;submit.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formCtx.registerGetValueCallback(formCtx.fieldName,&nbsp;function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;document.getElementById(<span class="cs__string">'inpAge'</span>).<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Render&nbsp;Html5&nbsp;input&nbsp;(number)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&lt;input&nbsp;type='number'&nbsp;id='inpAge'&nbsp;min='18'&nbsp;max='110'&nbsp;value='&quot;</span>&nbsp;&#43;&nbsp;formCtx.fieldValue&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'/&gt;&quot;</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>What you should learn if you browse this code sample (HTML5NumberInput.js)?</strong></p>
<p>In this code sample you will learn how to use<strong>&nbsp;JSLink templates with New and Edit forms</strong>.</p>
