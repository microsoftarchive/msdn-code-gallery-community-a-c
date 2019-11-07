# CSR code samples #9 (Hide Controls)
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
- SharePoint client object model (CSOM)
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p>This JSLink sample will show how to hide a list field form list forms. also you will learn how to use
<strong>OnPostRender </strong>functionality<strong>.</strong></p>
<p>&nbsp;</p>
<p><strong>Note:</strong>&nbsp;This sample is part&nbsp;of a&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series samples to learn you how to work with CSR templates</a>.</p>
<p>&nbsp;</p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2>Screenshot</h2>
<p><img id="111110" src="111110-sharepoint%20csr%20hidden%20field.png" alt="" width="750" height="422" style="border:1px solid black"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<div></div>
<ol>
<li>Create a&nbsp;<strong>Task&nbsp;</strong>List </li><li>Edit the&nbsp;<strong>Edit Form page</strong> </li><li>Go to List Edit Form&nbsp;<strong>web-part properties</strong>&nbsp;and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/HiddenField.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab
</li><li><strong>&nbsp;</strong>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing
</li><li>Apply the previous steps on the&nbsp;<strong>Edit Form</strong> </li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List New and Edit Forms &ndash; Hidden Field Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // jQuery library is required in this sample
    // Fallback to loading jQuery from a CDN path if the local is unavailable
    (window.jQuery || document.write('&lt;script src=&quot;//ajax.aspnetcdn.com/ajax/jquery/jquery-1.10.0.min.js&quot;&gt;&lt;\/script&gt;'));

    // Create object that have the context information about the field that we want to change it's output render 
    var hiddenFiledContext = {};
    hiddenFiledContext.Templates = {}; 
    hiddenFiledContext.Templates.OnPostRender = hiddenFiledOnPreRender;
    hiddenFiledContext.Templates.Fields = {
        // Apply the new rendering for Age field on New and Edit forms
        &quot;Predecessors&quot;: {
            &quot;NewForm&quot;: hiddenFiledTemplate,
            &quot;EditForm&quot;: hiddenFiledTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(hiddenFiledContext);

})();


// This function provides the rendering logic
function hiddenFiledTemplate() {
    return &quot;&lt;span class='csrHiddenField'&gt;&lt;/span&gt;&quot;;
}

// This function provides the rendering logic
function hiddenFiledOnPreRender(ctx) {
    jQuery(&quot;.csrHiddenField&quot;).closest(&quot;tr&quot;).hide();
}


</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;New&nbsp;and&nbsp;Edit&nbsp;Forms&nbsp;&ndash;&nbsp;Hidden&nbsp;Field&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;jQuery&nbsp;library&nbsp;is&nbsp;required&nbsp;in&nbsp;this&nbsp;sample</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Fallback&nbsp;to&nbsp;loading&nbsp;jQuery&nbsp;from&nbsp;a&nbsp;CDN&nbsp;path&nbsp;if&nbsp;the&nbsp;local&nbsp;is&nbsp;unavailable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(window.jQuery&nbsp;||&nbsp;document.write(<span class="js__string">'&lt;script&nbsp;src=&quot;//ajax.aspnetcdn.com/ajax/jquery/jquery-1.10.0.min.js&quot;&gt;&lt;\/script&gt;'</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;hiddenFiledContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hiddenFiledContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hiddenFiledContext.Templates.OnPostRender&nbsp;=&nbsp;hiddenFiledOnPreRender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hiddenFiledContext.Templates.Fields&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Age&nbsp;field&nbsp;on&nbsp;New&nbsp;and&nbsp;Edit&nbsp;forms</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Predecessors&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;NewForm&quot;</span>:&nbsp;hiddenFiledTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;EditForm&quot;</span>:&nbsp;hiddenFiledTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(hiddenFiledContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;hiddenFiledTemplate()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">&quot;&lt;span&nbsp;class='csrHiddenField'&gt;&lt;/span&gt;&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;hiddenFiledOnPreRender(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">&quot;.csrHiddenField&quot;</span>).closest(<span class="js__string">&quot;tr&quot;</span>).hide();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h2>What you should learn if you browse this code sample (HiddenField.js)?</h2>
<p>If you browse this code sample,&nbsp;you will learn how to use&nbsp;<strong>OnPostRender
</strong>template&nbsp;functionality<strong>.</strong></p>
