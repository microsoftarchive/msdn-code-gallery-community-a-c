# CSR code samples #7 (Email Regex Validator)
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Sharepoint Online
- SharePoint Server 2013
- SharePoint 2013
## Topics
- SharePoint
- SharePoint List
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p>This JSLink sample will show how to add Regex validation to input fields&nbsp;inside New and Edit forms.</p>
<p>&nbsp;</p>
<p><strong>Note:</strong>&nbsp;<span>This sample is part</span><span>&nbsp;of a&nbsp;</span><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series samples to learn you how to work with CSR templates</a>.</p>
<p>&nbsp;</p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" title="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2>Screenshot</h2>
<p><img id="109748" src="109748-client%20side%20rendering%20-regex%20validator.png" alt="Client side rendering -Regex Validator" width="572" height="273" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<div></div>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>List </li><li>Add a new column to the list:&nbsp;
<ul>
<li>Name: Email </li><li>Type: Single line of text </li></ul>
</li><li>Edit the&nbsp;<strong>Add Form page</strong> </li><li>Go to List Add Form&nbsp;<strong>web-part properties</strong>&nbsp;and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/RegexValidator.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab
</li><li><strong>&nbsp;</strong>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing
</li><li>Apply the previous steps on the&nbsp;<strong>Edit Form</strong> </li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;List&nbsp;add&nbsp;and&nbsp;edit&nbsp;&ndash;&nbsp;Email&nbsp;Regex&nbsp;Validator&nbsp;Sample</span>&nbsp;
<span class="cs__com">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(function&nbsp;()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;emailFiledContext&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;emailFiledContext.Templates&nbsp;=&nbsp;{};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;emailFiledContext.Templates.Fields&nbsp;=&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Email&nbsp;field&nbsp;on&nbsp;New&nbsp;and&nbsp;Edit&nbsp;Forms</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Email&quot;</span>:&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;NewForm&quot;</span>:&nbsp;emailFiledTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;EditForm&quot;</span>:&nbsp;&nbsp;emailFiledTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(emailFiledContext);&nbsp;
&nbsp;
})();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
function&nbsp;emailFiledTemplate(ctx)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;formCtx&nbsp;=&nbsp;SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Register&nbsp;a&nbsp;callback&nbsp;just&nbsp;before&nbsp;submit.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formCtx.registerGetValueCallback(formCtx.fieldName,&nbsp;function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;document.getElementById(<span class="cs__string">'inpEmail'</span>).<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;container&nbsp;for&nbsp;various&nbsp;validations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;validators&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SPClientForms.ClientValidation.ValidatorSet();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;validators.RegisterValidator(<span class="cs__keyword">new</span>&nbsp;emailValidator());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Validation&nbsp;failure&nbsp;handler.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formCtx.registerValidationErrorCallback(formCtx.fieldName,&nbsp;emailOnError);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formCtx.registerClientValidator(formCtx.fieldName,&nbsp;validators);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;dir='none'&gt;&lt;input&nbsp;type='text'&nbsp;value='&quot;</span>&nbsp;&#43;&nbsp;formCtx.fieldValue&nbsp;&#43;&nbsp;&quot;<span class="cs__string">'&nbsp;&nbsp;maxlength='</span><span class="cs__number">255</span><span class="cs__string">'&nbsp;id='</span>inpEmail<span class="cs__string">'&nbsp;class='</span>ms-<span class="cs__keyword">long</span>'&gt;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&gt;&lt;span&nbsp;id=<span class="cs__string">'spnError'</span>&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">'ms-formvalidation&nbsp;ms-csrformvalidation'</span>&gt;&lt;/span&gt;&lt;/span&gt;&quot;;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Custom&nbsp;validation&nbsp;object&nbsp;to&nbsp;validate&nbsp;email&nbsp;format</span>&nbsp;
emailValidator&nbsp;=&nbsp;function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;emailValidator.prototype.Validate&nbsp;=&nbsp;function&nbsp;(<span class="cs__keyword">value</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;isError&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;errorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Email&nbsp;format&nbsp;Regex&nbsp;expression</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;emailRejex&nbsp;=&nbsp;/\S&#43;@\S&#43;\.\S&#43;/;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!emailRejex.test(<span class="cs__keyword">value</span>)&nbsp;&amp;&amp;&nbsp;<span class="cs__keyword">value</span>.trim())&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isError&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;errorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Invalid&nbsp;email&nbsp;address&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Send&nbsp;error&nbsp;message&nbsp;to&nbsp;error&nbsp;callback&nbsp;function&nbsp;(emailOnError)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;SPClientForms.ClientValidation.ValidationResult(isError,&nbsp;errorMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
};&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;error&nbsp;message&nbsp;to&nbsp;spnError&nbsp;element&nbsp;under&nbsp;the&nbsp;input&nbsp;field&nbsp;element</span>&nbsp;
function&nbsp;emailOnError(error)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="cs__string">&quot;spnError&quot;</span>).innerHTML&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;span&nbsp;role='alert'&gt;&quot;</span>&nbsp;&#43;&nbsp;error.errorMessage&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/span&gt;&quot;</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>What you should learn if you browse this code sample (RegexValidator.js)?</strong></p>
<p>With this code sample you will learn how to work with&nbsp;<strong>SPClientForms.ClientValidation</strong>&nbsp;object and how to register a new client Validator to field&rsquo;s inputs.</p>
