# CSR code samples #8 (Read-only SP Controls)
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Sharepoint Online
- SharePoint Server 2013
## Topics
- SharePoint
- SharePoint List
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p>Sometimes we need to allwo user to edit list item but without touch some item fields, this will enhance the form user experience (if no need to modify&nbsp;these filed),&nbsp;<span>This JSLink sample will demonstrate&nbsp;how to use and utilize ready sharepoint
 javascript libraries to make form fileds uneditable.&nbsp;</span></p>
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
<p><img id="110725" src="110725-jslink-readonly.png" alt="JS-Link ReadOnly" width="554" height="574" style="border:1px solid black"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<div></div>
<ol>
<li>Create a&nbsp;<strong>Task&nbsp;</strong>List </li><li>Edit the&nbsp;<strong>Edit Form page</strong> </li><li>Go to List Edit Form&nbsp;<strong>web-part properties</strong>&nbsp;and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/ReadOnlySPControls.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab
</li><li><strong>&nbsp;</strong>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing
</li><li>Apply the previous steps on the&nbsp;<strong>Edit Form</strong> </li></ol>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List add and edit &ndash; ReadOnly SP Controls Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var readonlyFiledContext = {};
    readonlyFiledContext.Templates = {};
    readonlyFiledContext.Templates.Fields = {
        // Apply the new rendering for Age field on Edit forms
        &quot;Title&quot;: {
            &quot;EditForm&quot;: readonlyFieldTemplate
        },
        &quot;AssignedTo&quot;: {
            &quot;EditForm&quot;: readonlyFieldTemplate
        },
        &quot;Priority&quot;: {
            &quot;EditForm&quot;: readonlyFieldTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(readonlyFiledContext);

})();

// This function provides the rendering logic
function readonlyFieldTemplate(ctx) {

    //Reuse ready sharepoint javascript libraries
    switch (ctx.CurrentFieldSchema.FieldType) {
        case &quot;Text&quot;:
        case &quot;Number&quot;:
        case &quot;Integer&quot;:
        case &quot;Currency&quot;:
        case &quot;Choice&quot;:
        case &quot;Computed&quot;:
            return SPField_FormDisplay_Default(ctx);

        case &quot;MultiChoice&quot;:
            prepareMultiChoiceFieldValue(ctx);
            return SPField_FormDisplay_Default(ctx);

        case &quot;Boolean&quot;:
            return SPField_FormDisplay_DefaultNoEncode(ctx);

        case &quot;Note&quot;:
            prepareNoteFieldValue(ctx);
            return SPFieldNote_Display(ctx);

        case &quot;File&quot;:
            return SPFieldFile_Display(ctx);

        case &quot;Lookup&quot;:
        case &quot;LookupMulti&quot;:
                return SPFieldLookup_Display(ctx);           

        case &quot;URL&quot;:
            return RenderFieldValueDefault(ctx);

        case &quot;User&quot;:
            prepareUserFieldValue(ctx);
            return SPFieldUser_Display(ctx);

        case &quot;UserMulti&quot;:
            prepareUserFieldValue(ctx);
            return SPFieldUserMulti_Display(ctx);

        case &quot;DateTime&quot;:
            return SPFieldDateTime_Display(ctx);

        case &quot;Attachments&quot;:
            return SPFieldAttachments_Default(ctx);

        case &quot;TaxonomyFieldType&quot;:
            //Re-use ready sharepoint inside sp.ui.taxonomy.js javascript libraries
            return SP.UI.Taxonomy.TaxonomyFieldTemplate.renderDisplayControl(ctx);
    }
}

//User control need specific formatted value to render content correctly
function prepareUserFieldValue(ctx) {
    var item = ctx['CurrentItem'];
    var userField = item[ctx.CurrentFieldSchema.Name];
    var fieldValue = &quot;&quot;;

    for (var i = 0; i &lt; userField.length; i&#43;&#43;) {
        fieldValue &#43;= userField[i].EntityData.SPUserID &#43; SPClientTemplates.Utility.UserLookupDelimitString &#43; userField[i].DisplayText;

        if ((i &#43; 1) != userField.length) {
            fieldValue &#43;= SPClientTemplates.Utility.UserLookupDelimitString
        }
    }

    ctx[&quot;CurrentFieldValue&quot;] = fieldValue;
}

//Choice control need specific formatted value to render content correctly
function prepareMultiChoiceFieldValue(ctx) {

    if (ctx[&quot;CurrentFieldValue&quot;]) {
        var fieldValue = ctx[&quot;CurrentFieldValue&quot;];

        var find = ';#';
        var regExpObj = new RegExp(find, 'g');

        fieldValue = fieldValue.replace(regExpObj, '; ');
        fieldValue = fieldValue.replace(/^; /g, '');
        fieldValue = fieldValue.replace(/; $/g, '');

        ctx[&quot;CurrentFieldValue&quot;] = fieldValue;
    }
}

//Note control need specific formatted value to render content correctly
function prepareNoteFieldValue(ctx) {

    if (ctx[&quot;CurrentFieldValue&quot;]) {
        var fieldValue = ctx[&quot;CurrentFieldValue&quot;];
        fieldValue = &quot;&lt;div&gt;&quot; &#43; fieldValue.replace(/\n/g, '&lt;br /&gt;'); &#43; &quot;&lt;/div&gt;&quot;;

        ctx[&quot;CurrentFieldValue&quot;] = fieldValue;
    }
}</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;add&nbsp;and&nbsp;edit&nbsp;&ndash;&nbsp;ReadOnly&nbsp;SP&nbsp;Controls&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;readonlyFiledContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;readonlyFiledContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;readonlyFiledContext.Templates.Fields&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Age&nbsp;field&nbsp;on&nbsp;Edit&nbsp;forms</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Title&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;EditForm&quot;</span>:&nbsp;readonlyFieldTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;AssignedTo&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;EditForm&quot;</span>:&nbsp;readonlyFieldTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Priority&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;EditForm&quot;</span>:&nbsp;readonlyFieldTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(readonlyFiledContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;readonlyFieldTemplate(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Reuse&nbsp;ready&nbsp;sharepoint&nbsp;javascript&nbsp;libraries</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">switch</span>&nbsp;(ctx.CurrentFieldSchema.FieldType)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Text&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Number&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Integer&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Currency&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Choice&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Computed&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPField_FormDisplay_Default(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;MultiChoice&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prepareMultiChoiceFieldValue(ctx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPField_FormDisplay_Default(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Boolean&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPField_FormDisplay_DefaultNoEncode(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Note&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prepareNoteFieldValue(ctx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldNote_Display(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;File&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldFile_Display(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Lookup&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;LookupMulti&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldLookup_Display(ctx);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;URL&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;RenderFieldValueDefault(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;User&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prepareUserFieldValue(ctx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldUser_Display(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;UserMulti&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prepareUserFieldValue(ctx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldUserMulti_Display(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;DateTime&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldDateTime_Display(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Attachments&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SPFieldAttachments_Default(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;TaxonomyFieldType&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Re-use&nbsp;ready&nbsp;sharepoint&nbsp;inside&nbsp;sp.ui.taxonomy.js&nbsp;javascript&nbsp;libraries</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SP.UI.Taxonomy.TaxonomyFieldTemplate.renderDisplayControl(ctx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//User&nbsp;control&nbsp;need&nbsp;specific&nbsp;formatted&nbsp;value&nbsp;to&nbsp;render&nbsp;content&nbsp;correctly</span>&nbsp;
<span class="js__operator">function</span>&nbsp;prepareUserFieldValue(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item&nbsp;=&nbsp;ctx[<span class="js__string">'CurrentItem'</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;userField&nbsp;=&nbsp;item[ctx.CurrentFieldSchema.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fieldValue&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;userField.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fieldValue&nbsp;&#43;=&nbsp;userField[i].EntityData.SPUserID&nbsp;&#43;&nbsp;SPClientTemplates.Utility.UserLookupDelimitString&nbsp;&#43;&nbsp;userField[i].DisplayText;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;((i&nbsp;&#43;&nbsp;<span class="js__num">1</span>)&nbsp;!=&nbsp;userField.length)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fieldValue&nbsp;&#43;=&nbsp;SPClientTemplates.Utility.UserLookupDelimitString&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>]&nbsp;=&nbsp;fieldValue;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//Choice&nbsp;control&nbsp;need&nbsp;specific&nbsp;formatted&nbsp;value&nbsp;to&nbsp;render&nbsp;content&nbsp;correctly</span>&nbsp;
<span class="js__operator">function</span>&nbsp;prepareMultiChoiceFieldValue(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>])&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fieldValue&nbsp;=&nbsp;ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;find&nbsp;=&nbsp;<span class="js__string">';#'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;regExpObj&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">RegExp</span>(find,&nbsp;<span class="js__string">'g'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fieldValue&nbsp;=&nbsp;fieldValue.replace(regExpObj,&nbsp;<span class="js__string">';&nbsp;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fieldValue&nbsp;=&nbsp;fieldValue.replace(<span class="js__reg_exp">/^;&nbsp;/g</span>,&nbsp;<span class="js__string">''</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fieldValue&nbsp;=&nbsp;fieldValue.replace(<span class="js__reg_exp">/;&nbsp;$/g</span>,&nbsp;<span class="js__string">''</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>]&nbsp;=&nbsp;fieldValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//Note&nbsp;control&nbsp;need&nbsp;specific&nbsp;formatted&nbsp;value&nbsp;to&nbsp;render&nbsp;content&nbsp;correctly</span>&nbsp;
<span class="js__operator">function</span>&nbsp;prepareNoteFieldValue(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>])&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fieldValue&nbsp;=&nbsp;ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fieldValue&nbsp;=&nbsp;<span class="js__string">&quot;&lt;div&gt;&quot;</span>&nbsp;&#43;&nbsp;fieldValue.replace(<span class="js__reg_exp">/\n/g</span>,&nbsp;<span class="js__string">'&lt;br&nbsp;/&gt;'</span>);&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx[<span class="js__string">&quot;CurrentFieldValue&quot;</span>]&nbsp;=&nbsp;fieldValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<h2>What you should learn if you browse this code sample (ReadOnlySPControls.js)?</h2>
</div>
<div class="endscriptcode">
<p>This JSLink sample will show how to use and&nbsp;<strong>utilize ready sharepoint javascript libraries</strong>&nbsp;to make form fileds uneditable.&nbsp;</p>
</div>
