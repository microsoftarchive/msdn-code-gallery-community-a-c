# CSR code samples #12 (Repeater)
## License
- Apache License, Version 2.0
## Technologies
- Sharepoint Online
- SharePoint Server 2013
- SharePoint  2013
## Topics
- SharePoint
- Javascript
- Client Side Rendering
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p><span>This JSLink sample allows you to use Javascript repeater within your SharePoint List Forms and views.</span></p>
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
<p><img id="125700" src="125700-sharepoint%20form%20-%20inner%20repeater.png" alt="" width="555" height="404" style="border:1px solid black"></p>
<p>&nbsp;</p>
<p><img id="125701" src="125701-sharepoint%20form%20-%20inner%20repeater%20validation.png" alt="validation" width="625" height="406" style="border:1px solid black"></p>
<p>&nbsp;</p>
<p><img id="125702" src="125702-sharepoint%20list%20view-%20inner%20repeater.png" alt="View" width="440" height="331" style="border:1px solid black"></p>
<h2><span>Deployment steps:</span></h2>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>list </li><li>Add <strong>&nbsp;plane multiline field&nbsp;</strong>to the list and name it&nbsp;<strong>Dependents</strong>
</li><li>Edit the New and Endit <strong>List Forms and views&nbsp;</strong>pages&nbsp;
</li><li>Go to List view&nbsp;<strong>web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/HideEmptyColumn.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
 &nbsp;
<p><img id="125703" src="http://i1.code.msdn.s-msft.com/office/client-side-rendering-code-56649801/image/file/125703/1/sharepoint%20form%20-%20inner%20repeater%20jslink.png" alt="" width="290" height="547" style="border:1px solid black"></p>
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;New&nbsp;and&nbsp;Edit&nbsp;Forms&nbsp;&ndash;&nbsp;Repeater&nbsp;Input&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;repeaterFormArr&nbsp;=&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;input&nbsp;type='text'&nbsp;id='nameInput'&nbsp;placeholder='Full&nbsp;Name'&nbsp;required&nbsp;class='ms-long&nbsp;ms-spellcheck-true'&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;input&nbsp;type='number'&nbsp;id='ageInput'&nbsp;placeholder='Age'&nbsp;required&nbsp;style='padding:&nbsp;2px&nbsp;4px;'&nbsp;class='ms-long&nbsp;ms-spellcheck-true'&gt;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;input&nbsp;type='text'&nbsp;id='ssnInput'&nbsp;placeholder='SSN'&nbsp;pattern=\&quot;^\\d{3}-\\d{2}-\\d{4}$\&quot;&nbsp;title='###-##-####'&nbsp;class='ms-long&nbsp;ms-spellcheck-true'&gt;&quot;</span>,&nbsp;
];&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;ControlRenderMode;&nbsp;
<span class="js__statement">var</span>&nbsp;repeaterFormValues&nbsp;=&nbsp;[];&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;repeaterFiledContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;repeaterFiledContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;repeaterFiledContext.Templates.Fields&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Apply&nbsp;the&nbsp;new&nbsp;rendering&nbsp;for&nbsp;Age&nbsp;field&nbsp;on&nbsp;New&nbsp;and&nbsp;Edit&nbsp;forms</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Dependents&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;View&quot;</span>:&nbsp;RepeaterFiledViewTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;DisplayForm&quot;</span>:&nbsp;RepeaterFiledViewTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;NewForm&quot;</span>:&nbsp;RepeaterFiledEditFTemplate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;EditForm&quot;</span>:&nbsp;RepeaterFiledEditFTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(repeaterFiledContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RepeaterFiledViewTemplate(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ControlRenderMode&nbsp;=&nbsp;ctx.ControlMode;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ctx.CurrentItem[ctx.CurrentFieldSchema.Name]&nbsp;&amp;&amp;&nbsp;ctx.CurrentItem[ctx.CurrentFieldSchema.Name]&nbsp;!=&nbsp;<span class="js__string">'[]'</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fieldValue&nbsp;=&nbsp;ctx.CurrentItem[ctx.CurrentFieldSchema.Name].replace(<span class="js__reg_exp">/&amp;quot;/g</span>,&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>).replace(<span class="js__reg_exp">/(&lt;([^&gt;]&#43;)&gt;)/g</span>,&nbsp;<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;repeaterFormValues&nbsp;=&nbsp;JSON.parse(fieldValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;GetRenderHtmlRepeaterValues();&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RepeaterFiledEditFTemplate(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ControlRenderMode&nbsp;=&nbsp;ctx.ControlMode;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;formCtx&nbsp;=&nbsp;SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(formCtx.fieldValue)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;repeaterFormValues&nbsp;=&nbsp;JSON.parse(formCtx.fieldValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Register&nbsp;a&nbsp;callback&nbsp;just&nbsp;before&nbsp;submit.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;formCtx.registerGetValueCallback(formCtx.fieldName,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;JSON.stringify(repeaterFormValues);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;HTMLViewTemplate&nbsp;=&nbsp;<span class="js__string">&quot;&lt;form&nbsp;id='innerForm'&nbsp;onsubmit='return&nbsp;AddItem();'&gt;{Controls}&lt;div&gt;&lt;input&nbsp;type='submit'&nbsp;value='Add'&nbsp;style='margin-left:0'&gt;&lt;/div&gt;&lt;br/&gt;&lt;div&nbsp;id='divRepeaterValues'&gt;{RepeaterValues}&lt;/div&gt;&lt;br/&gt;&lt;/form&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;returnHTML&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;repeaterFormArr.length;&nbsp;&#43;&#43;index)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;returnHTML&nbsp;&#43;=&nbsp;repeaterFormArr[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;returnHTML&nbsp;=&nbsp;HTMLViewTemplate.replace(<span class="js__reg_exp">/{Controls}/g</span>,&nbsp;returnHTML);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;returnHTML&nbsp;=&nbsp;returnHTML.replace(<span class="js__reg_exp">/{RepeaterValues}/g</span>,&nbsp;GetRenderHtmlRepeaterValues());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;returnHTML;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;GetRenderHtmlRepeaterValues()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;innerindex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;HTMLItemsTemplate&nbsp;=&nbsp;<span class="js__string">&quot;&lt;table&nbsp;width='100%'&nbsp;style='border:1px&nbsp;solid&nbsp;#ababab;'&gt;{Items}&lt;/table&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;HTMLItemTemplate&nbsp;=&nbsp;<span class="js__string">&quot;&lt;tr&gt;{Item}&lt;/tr&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;HTMLValueTemplate&nbsp;=&nbsp;<span class="js__string">&quot;&lt;td&gt;{Value}&lt;/td&gt;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ControlRenderMode&nbsp;==&nbsp;SPClientTemplates.ClientControlMode.EditForm&nbsp;||&nbsp;ControlRenderMode&nbsp;==&nbsp;SPClientTemplates.ClientControlMode.NewForm)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HTMLItemTemplate&nbsp;=&nbsp;<span class="js__string">&quot;&lt;tr&gt;{Item}&lt;td&gt;&lt;a&nbsp;href='javascript:DeleteItem({Index});'&gt;Delete&lt;/a&gt;&lt;/td&gt;&lt;/tr&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;returnHTML&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tempValueHtml;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;repeaterFormValues.length;&nbsp;&#43;&#43;index)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tempValueHtml&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(innerindex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;innerindex&nbsp;&lt;&nbsp;repeaterFormValues[index].length;&nbsp;&#43;&#43;innerindex)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tempValueHtml&nbsp;&#43;=&nbsp;HTMLValueTemplate.replace(<span class="js__reg_exp">/{Value}/g</span>,&nbsp;repeaterFormValues[index][innerindex][<span class="js__string">&quot;Value&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;returnHTML&nbsp;&#43;=&nbsp;HTMLItemTemplate.replace(<span class="js__reg_exp">/{Item}/g</span>,&nbsp;tempValueHtml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;returnHTML&nbsp;=&nbsp;returnHTML.replace(<span class="js__reg_exp">/{Index}/g</span>,&nbsp;index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(repeaterFormValues.length)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;returnHTML&nbsp;=&nbsp;HTMLItemsTemplate.replace(<span class="js__reg_exp">/{Items}/g</span>,&nbsp;returnHTML);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;returnHTML;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;AddItem()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;innerForm&nbsp;=&nbsp;document.getElementById(<span class="js__string">'innerForm'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(innerForm.checkValidity())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tempRepeaterValue&nbsp;=&nbsp;[];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;innerForm.length;&nbsp;index&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(innerForm[index].type&nbsp;!=&nbsp;<span class="js__string">&quot;submit&quot;</span>&nbsp;&amp;&amp;&nbsp;innerForm[index].type&nbsp;!=&nbsp;<span class="js__string">&quot;button&quot;</span>&nbsp;&amp;&amp;&nbsp;innerForm[index].type&nbsp;!=&nbsp;<span class="js__string">&quot;reset&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tempRepeaterValue.push(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;ID&quot;</span>:&nbsp;innerForm[index].id,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Value&quot;</span>:&nbsp;innerForm[index].value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;innerForm[index].value&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;repeaterFormValues.push(tempRepeaterValue);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">&quot;divRepeaterValues&quot;</span>).innerHTML&nbsp;=&nbsp;GetRenderHtmlRepeaterValues();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;DeleteItem(index)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;repeaterFormValues.splice(index,&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">&quot;divRepeaterValues&quot;</span>).innerHTML&nbsp;=&nbsp;GetRenderHtmlRepeaterValues();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h2><strong>What you should learn if you browse this code sample (BasicRepeater.js)?</strong></h2>
<p>This is an advance sample, it will help you to learn how to utilize your javascript skills to build advanced SharePoint list forms.</p>
