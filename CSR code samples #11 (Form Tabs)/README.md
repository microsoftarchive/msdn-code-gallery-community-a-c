# CSR code samples #11 (Form Tabs)
## License
- Apache License, Version 2.0
## Technologies
- Sharepoint Online
- SharePoint Server 2013
- SharePoint  2013
## Topics
- Javascript
- SharePoint 2013
- Client Side Rendering
## Updated
- 03/19/2015
## Description

<h1>Introduction</h1>
<p><span>This JSLink sample allows you to use JQuery Tabs withing your SharePoint List Forms.</span></p>
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
<p><img id="125693" src="125693-client%20side%20rendering%20jquery%20tabs.png" alt="" width="547" height="358" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h2><span>Deployment steps:</span></h2>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>list </li><li>Add <strong>required&nbsp;columns </strong>to the list </li><li>Edit&nbsp;<strong>tabsObj object </strong>baesd on your requirements&nbsp;
<p><img id="125694" src="125694-sharepoint%20list%20form%20tabs.png" alt="SharePoint Form Tabs" width="465" height="91" style="border:1px solid black"></p>
</li><li>Edit the New and Endit <strong>List Forms&nbsp;</strong>page&nbsp; </li><li>Go to List view&nbsp;<strong>web-part properties&nbsp;</strong>and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/HideEmptyColumn.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
 &nbsp;
<p><img id="125695" src="125695-sharepoint%20tabs.png" alt="" width="317" height="475" style="border:1px solid black"></p>
</li><li>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;//&nbsp;List&nbsp;Form&nbsp;-&nbsp;Tabs&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;currentFormUniqueId;&nbsp;
<span class="js__statement">var</span>&nbsp;currentFormWebPartId;&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Use&nbsp;&quot;Multi&nbsp;String&quot;&nbsp;javascript&nbsp;to&nbsp;embed&nbsp;the&nbsp;required&nbsp;css</span>&nbsp;
<span class="js__statement">var</span>&nbsp;MultiString&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(f)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;f.toString().split(<span class="js__string">'\n'</span>).slice(<span class="js__num">1</span>,&nbsp;-<span class="js__num">1</span>).join(<span class="js__string">'\n'</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__statement">var</span>&nbsp;tabsStyle&nbsp;=&nbsp;MultiString(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span><span class="js__ml_comment">/**&nbsp;
.tabs&nbsp;{&nbsp;
border-bottom:&nbsp;1px&nbsp;solid&nbsp;#ddd;&nbsp;
content:&nbsp;&quot;&nbsp;&quot;;&nbsp;
display:&nbsp;table;&nbsp;
margin-bottom:&nbsp;0;&nbsp;
padding-left:&nbsp;0;&nbsp;
list-style:&nbsp;none;&nbsp;
width:&nbsp;100%;&nbsp;
}&nbsp;
&nbsp;
.tabs&nbsp;&gt;&nbsp;li&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;float:&nbsp;left;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;margin-bottom:&nbsp;-1px;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;position:&nbsp;relative;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;display:&nbsp;block;&nbsp;
}&nbsp;
&nbsp;
.tabs&nbsp;&gt;&nbsp;li&nbsp;&gt;&nbsp;a&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;margin-right:&nbsp;2px;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;line-height:&nbsp;1.42857143;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;border:&nbsp;1px&nbsp;solid&nbsp;transparent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;position:&nbsp;relative;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;display:&nbsp;block;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;padding:&nbsp;10px&nbsp;15px;&nbsp;
}&nbsp;
&nbsp;
.tabs&nbsp;a&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;color:&nbsp;#428bca;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;text-decoration:&nbsp;none;&nbsp;
}&nbsp;
&nbsp;
.tabs&nbsp;&gt;&nbsp;li.active&nbsp;&gt;&nbsp;a,&nbsp;.tabs&nbsp;&gt;&nbsp;li.active&nbsp;&gt;&nbsp;a:hover,&nbsp;.tabs&nbsp;&gt;&nbsp;li.active&nbsp;&gt;&nbsp;a:focus&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;color:&nbsp;#555;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;background-color:&nbsp;#fff;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;border:&nbsp;1px&nbsp;solid&nbsp;#ddd;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;border-bottom-color:&nbsp;transparent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cursor:&nbsp;default;&nbsp;
}&nbsp;
&nbsp;
**/</span>&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;tabsObj&nbsp;=&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="js__string">&quot;General&quot;</span>,&nbsp;[<span class="js__string">&quot;Title&quot;</span>,&nbsp;<span class="js__string">&quot;Age&quot;</span>,&nbsp;<span class="js__string">&quot;Married&quot;</span>,&nbsp;<span class="js__string">&quot;Mobile&quot;</span>,&nbsp;<span class="js__string">&quot;SSN&quot;</span>]],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="js__string">&quot;Work&quot;</span>,&nbsp;[<span class="js__string">&quot;Manager&quot;</span>,&nbsp;<span class="js__string">&quot;Salary&quot;</span>,&nbsp;<span class="js__string">&quot;Phone&quot;</span>,&nbsp;<span class="js__string">&quot;Email&quot;</span>]],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="js__string">&quot;Other&quot;</span>,&nbsp;[<span class="js__string">&quot;Comments&quot;</span>]]&nbsp;
];&nbsp;
&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;jQuery&nbsp;library&nbsp;is&nbsp;required&nbsp;in&nbsp;this&nbsp;sample</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Fallback&nbsp;to&nbsp;loading&nbsp;jQuery&nbsp;from&nbsp;a&nbsp;CDN&nbsp;path&nbsp;if&nbsp;the&nbsp;local&nbsp;is&nbsp;unavailable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(window.jQuery&nbsp;||&nbsp;document.write(<span class="js__string">'&lt;script&nbsp;src=&quot;//ajax.aspnetcdn.com/ajax/jquery/jquery-1.10.0.min.js&quot;&gt;&lt;\/script&gt;'</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tabsContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;tabsContext.OnPreRender&nbsp;=&nbsp;TabsOnPreRender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;tabsContext.OnPostRender&nbsp;=&nbsp;TabsOnPostRender;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;accordionContext.OnPostRender&nbsp;=&nbsp;accordionOnPostRender;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;tabsContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(tabsContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;TabsOnPreRender(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!currentFormUniqueId)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentFormUniqueId&nbsp;=&nbsp;ctx.FormUniqueId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentFormWebPartId&nbsp;=&nbsp;<span class="js__string">&quot;WebPart&quot;</span>&nbsp;&#43;&nbsp;ctx.FormUniqueId;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tabHTMLTemplate&nbsp;=&nbsp;<span class="js__string">&quot;&lt;li&nbsp;class='{class}'&gt;&lt;a&nbsp;href='#{Index}'&gt;{Title}&lt;/a&gt;&lt;/li&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tabClass;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tabsHTML&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;tabsObj.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabClass&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(i&nbsp;==&nbsp;<span class="js__num">0</span>)<span class="js__brace">{</span>&nbsp;tabClass&nbsp;=&nbsp;<span class="js__string">&quot;active&quot;</span>;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabsHTML&nbsp;&#43;=&nbsp;tabHTMLTemplate.replace(<span class="js__reg_exp">/{Index}/g</span>,&nbsp;i).replace(<span class="js__reg_exp">/{Title}/g</span>,&nbsp;tabsObj[i][<span class="js__num">0</span>]).replace(<span class="js__reg_exp">/{class}/g</span>,&nbsp;tabClass)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">&quot;#&quot;</span>&nbsp;&#43;&nbsp;currentFormWebPartId).prepend(<span class="js__string">&quot;&lt;ul&nbsp;class='tabs'&gt;&quot;</span>&nbsp;&#43;&nbsp;tabsHTML&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/ul&gt;&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">'.tabs&nbsp;li&nbsp;a'</span>).on(<span class="js__string">'click'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;currentIndex&nbsp;=&nbsp;jQuery(<span class="js__operator">this</span>).attr(<span class="js__string">'href'</span>).replace(<span class="js__string">&quot;#&quot;</span>,<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;showTabControls(currentIndex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__operator">this</span>).parent(<span class="js__string">'li'</span>).addClass(<span class="js__string">'active'</span>).siblings().removeClass(<span class="js__string">'active'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.preventDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;showTabControls(<span class="js__num">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">&quot;#&quot;</span>&nbsp;&#43;&nbsp;currentFormWebPartId).prepend(<span class="js__string">&quot;<style><!--mce:1--></style>&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;TabsOnPostRender(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;controlId&nbsp;=&nbsp;ctx.ListSchema.Field[<span class="js__num">0</span>].Name&nbsp;&#43;&nbsp;<span class="js__string">&quot;_&quot;</span>&nbsp;&#43;&nbsp;ctx.ListSchema.Field[<span class="js__num">0</span>].Id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">&quot;[id^='&quot;</span>&nbsp;&#43;&nbsp;controlId&nbsp;&#43;&nbsp;<span class="js__string">&quot;']&quot;</span>).closest(<span class="js__string">&quot;tr&quot;</span>).attr(<span class="js__string">'id'</span>,&nbsp;<span class="js__string">'tr_'</span>&nbsp;&#43;&nbsp;ctx.ListSchema.Field[<span class="js__num">0</span>].Name).hide();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;showTabControls(index)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">&quot;#&quot;</span>&nbsp;&#43;&nbsp;currentFormWebPartId&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;[id^='tr_']&quot;</span>).hide();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;tabsObj[index][<span class="js__num">1</span>].length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery(<span class="js__string">&quot;[id^='tr_&quot;</span>&nbsp;&#43;&nbsp;tabsObj[index][<span class="js__num">1</span>][i]&nbsp;&#43;&nbsp;<span class="js__string">&quot;']&quot;</span>).show();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2><strong>What you should learn if you browse this code sample (Tabs.js)?</strong></h2>
<p>This is an advance sample, it will help you to learn how to create the<strong> embed css inside your CSR files.</strong></p>
