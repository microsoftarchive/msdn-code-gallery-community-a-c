# CSR code samples #11 (Fully customized forms with CSRListForm)
## Requires
- 
## License
- MS-LPL
## Technologies
- Sharepoint Online
- SharePoint Foundation 2013
- SharePoint 2013
## Topics
- SharePoint
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p><span>This Client side rendering code sample will help you to work with <strong>
CSRListForm&nbsp;</strong>and build your sharepoint list forms form scratch and use any form layout and design that you want.&nbsp;</span></p>
<p><strong>Note:</strong>&nbsp;This sample is part from&nbsp;<a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">series of samples to learn you how to work with CSR templates</a>.</p>
<p><span><br>
</span></p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Andrei Markeev.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage: document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2><span style="font-size:20px; font-weight:bold"><span>Screenshot (Two Columns form)</span></span></h2>
<p><img id="135180" src="135180-csrlistform.png" alt="" width="761" height="212" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2><span>Deployment steps:</span></h2>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>list </li><li>Add some columns to the list, for my exampe I use the following:
<ol>
<li>Name:&nbsp;Date, Type: date and time </li><li>Name:&nbsp;Category, Type:&nbsp;<span>Choice&nbsp;</span> </li><li><span>Name:&nbsp;Active, Type:&nbsp;Yes/No</span> </li></ol>
</li><li>Uplaod the&nbsp;FullyCustomizedForm.js file to the document library </li><li>Edit <strong>List Form&nbsp;</strong>page&nbsp; </li><li>Go to List view&nbsp;<strong>web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/FullyCustomizedForm.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
 &nbsp;&nbsp; </li><li>CHange&nbsp;<strong>Form Template Name</strong> to CSRListForm </li></ol>
<p style="padding-left:30px"><img id="135182" src="135182-csrlistform2.png" alt="" width="294" height="290"></p>
<p style="padding-left:30px">7. &nbsp;Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List Forms &ndash; User CSRListForm Server Tempalte
// Muawiyah Shannak , @MuShannak 
 
(function () { 
 
    // Create object that have the context information about the field that we want to change it's output render  
    var formTemplate = {};
    formTemplate.Templates = {};
    formTemplate.Templates.View = viewTemplate;
 
    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(formTemplate);
 
})(); 
 
// This function provides the rendering logic for the Custom Form
function viewTemplate(ctx) {
    
    var formTable = &quot;&quot;.concat(&quot;&lt;table width='100%' cellpadding='5'&gt;&quot;,
                                    &quot;&lt;tr&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;Title&lt;/div&gt;&lt;/td&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;{{TitleCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;Date&lt;/div&gt;&lt;/td&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;{{DateCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;,
                                    &quot;&lt;/tr&gt;&quot;,
                                    &quot;&lt;tr&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;Category&lt;/div&gt;&lt;/td&gt;&quot;,
                                            &quot;&lt;td&gt;&lt;div&gt;{{CategoryCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;Active&lt;/div&gt;&lt;/td&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;div&gt;{{ActiveCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;,
                                    &quot;&lt;/tr&gt;&quot;,
                                    &quot;&lt;tr&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;/td&gt;&quot;,
                                        &quot;&lt;td&gt;&lt;input type='button' value='Save' onclick=\&quot;SPClientForms.ClientFormManager.SubmitClientForm('{{FormId}}')\&quot; style='margin-left:0' &gt;&lt;/td&gt;&quot;,
                                    &quot;&lt;/tr&gt;&quot;,
                              &quot;&lt;/table&gt;&quot;);

    
    //Replace the tokens with the default sharepoint controls
    formTable = formTable.replace(&quot;{{TitleCtrl}}&quot;, getSPFieldRender(ctx, &quot;Title&quot;));
    formTable = formTable.replace(&quot;{{DateCtrl}}&quot;, getSPFieldRender(ctx, &quot;Date&quot;));
    formTable = formTable.replace(&quot;{{CategoryCtrl}}&quot;, getSPFieldRender(ctx, &quot;Category&quot;));
    formTable = formTable.replace(&quot;{{ActiveCtrl}}&quot;, getSPFieldRender(ctx, &quot;Active&quot;));
    formTable = formTable.replace(&quot;{{FormId}}&quot;, ctx.FormUniqueId);

    return formTable;
}

//This function code set the required properties and call the OOTB (default) function that use to render Sharepoint Fields 
function getSPFieldRender(ctx, fieldName)
{
    var fieldContext = ctx;

    //Get the filed Schema
    var result = ctx.ListSchema.Field.filter(function( obj ) {
        return obj.Name == fieldName;
    });

    //Set the field Schema  &amp; default value
    fieldContext.CurrentFieldSchema = result[0];
    fieldContext.CurrentFieldValue = ctx.ListData.Items[0][fieldName];

    //Call  OOTB field render function 
    return ctx.Templates.Fields[fieldName](fieldContext);
}
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;Forms&nbsp;&ndash;&nbsp;User&nbsp;CSRListForm&nbsp;Server&nbsp;Tempalte</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak&nbsp;</span>&nbsp;
&nbsp;&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;formTemplate&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTemplate.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTemplate.Templates.View&nbsp;=&nbsp;viewTemplate;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(formTemplate);&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>)();&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic&nbsp;for&nbsp;the&nbsp;Custom&nbsp;Form</span>&nbsp;
<span class="js__operator">function</span>&nbsp;viewTemplate(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;formTable&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>.concat(<span class="js__string">&quot;&lt;table&nbsp;width='100%'&nbsp;cellpadding='5'&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;tr&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;Title&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;{{TitleCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;Date&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;{{DateCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/tr&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;tr&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;Category&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;{{CategoryCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;Active&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;div&gt;{{ActiveCtrl}}&lt;/div&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/tr&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;tr&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;td&gt;&lt;input&nbsp;type='button'&nbsp;value='Save'&nbsp;onclick=\&quot;SPClientForms.ClientFormManager.SubmitClientForm('{{FormId}}')\&quot;&nbsp;style='margin-left:0'&nbsp;&gt;&lt;/td&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/tr&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/table&gt;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Replace&nbsp;the&nbsp;tokens&nbsp;with&nbsp;the&nbsp;default&nbsp;sharepoint&nbsp;controls</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTable&nbsp;=&nbsp;formTable.replace(<span class="js__string">&quot;{{TitleCtrl}}&quot;</span>,&nbsp;getSPFieldRender(ctx,&nbsp;<span class="js__string">&quot;Title&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTable&nbsp;=&nbsp;formTable.replace(<span class="js__string">&quot;{{DateCtrl}}&quot;</span>,&nbsp;getSPFieldRender(ctx,&nbsp;<span class="js__string">&quot;Date&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTable&nbsp;=&nbsp;formTable.replace(<span class="js__string">&quot;{{CategoryCtrl}}&quot;</span>,&nbsp;getSPFieldRender(ctx,&nbsp;<span class="js__string">&quot;Category&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTable&nbsp;=&nbsp;formTable.replace(<span class="js__string">&quot;{{ActiveCtrl}}&quot;</span>,&nbsp;getSPFieldRender(ctx,&nbsp;<span class="js__string">&quot;Active&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formTable&nbsp;=&nbsp;formTable.replace(<span class="js__string">&quot;{{FormId}}&quot;</span>,&nbsp;ctx.FormUniqueId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;formTable;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//This&nbsp;function&nbsp;code&nbsp;set&nbsp;the&nbsp;required&nbsp;properties&nbsp;and&nbsp;call&nbsp;the&nbsp;OOTB&nbsp;(default)&nbsp;function&nbsp;that&nbsp;use&nbsp;to&nbsp;render&nbsp;Sharepoint&nbsp;Fields&nbsp;</span>&nbsp;
<span class="js__operator">function</span>&nbsp;getSPFieldRender(ctx,&nbsp;fieldName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fieldContext&nbsp;=&nbsp;ctx;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Get&nbsp;the&nbsp;filed&nbsp;Schema</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;ctx.ListSchema.Field.filter(<span class="js__operator">function</span>(&nbsp;obj&nbsp;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;obj.Name&nbsp;==&nbsp;fieldName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;the&nbsp;field&nbsp;Schema&nbsp;&nbsp;&amp;&nbsp;default&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fieldContext.CurrentFieldSchema&nbsp;=&nbsp;result[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fieldContext.CurrentFieldValue&nbsp;=&nbsp;ctx.ListData.Items[<span class="js__num">0</span>][fieldName];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Call&nbsp;&nbsp;OOTB&nbsp;field&nbsp;render&nbsp;function&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;ctx.Templates.Fields[fieldName](fieldContext);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2><strong>What you should learn if you browse this code sample (FullyCustomizedForm.js)?</strong></h2>
<p>This is an advance sample, it will help you to learn how to create Fully customized forms and how to use&nbsp;<strong>CSRListForm template.</strong></p>
