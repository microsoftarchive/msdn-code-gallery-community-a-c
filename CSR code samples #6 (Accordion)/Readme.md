# CSR code samples #6 (Accordion)
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
<p>This JSLink sample will show you how to change rendering logic for the whole&nbsp;List View. This sample will read the Title and Description fields&rsquo; values and render the fields in an accordion style view.</p>
<p><strong>Note:</strong>&nbsp;This sample is part from <a href="http://code.msdn.microsoft.com/office/Client-side-rendering-JS-2ed3538a">
series of samples to learn you how to work with CSR templates</a>.</p>
<p><br>
<br>
</p>
<h2>How to deploy the JSLink templates</h2>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;&nbsp;<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this&nbsp;<a class="title" title="SharePoint 2013 Client Side Rendering: List Views" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">article&nbsp;</a>by
 Tobias Zimmergren.&nbsp;<br>
<br>
Before proceeding&nbsp;with the samples,&nbsp;<strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong>&nbsp;I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<h2>Screenshot</h2>
<p><img id="109726" src="109726-js%20link%20accordion.png" alt="CSR Accordion" width="717" height="225" style="border:1px solid black"></p>
<p><a href="https://mushannak-public.sharepoint.com/Pages/CSR%20Accordion.aspx"><span style="font-size:medium">Demo</span></a></p>
<p>&nbsp;</p>
<h2>Deployment steps:</h2>
<ol>
<li>Create a&nbsp;<strong>Custom&nbsp;</strong>List </li><li>Add a new column to the list:&nbsp;
<ul>
<li>Name: Description </li><li>Type: Multiple lines of text </li></ul>
</li><li>Edit the&nbsp;<strong>Default New Form</strong> </li><li>Go to List view<strong>&nbsp;web-part properties</strong>&nbsp;and add the JSLink file (~sitecollection/Style Library/JSLink-Samples/Accordion.js) to&nbsp;<strong>JS link property</strong>&nbsp;under the&nbsp;<strong>Miscellaneous&nbsp;</strong>Tab.
</li><li><strong>&nbsp;</strong>Click&nbsp;<strong>Apply&nbsp;</strong>button then&nbsp;<strong>Stop&nbsp;</strong>page editing
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// List View &ndash; Accordion Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // jQuery library is required in this sample
    // Fallback to loading jQuery from a CDN path if the local is unavailable
    (window.jQuery || document.write('&lt;script src=&quot;//ajax.aspnetcdn.com/ajax/jquery/jquery-1.10.0.min.js&quot;&gt;&lt;\/script&gt;'));

    // Create object that have the context information about the field that we want to change it's output render 
    var accordionContext = {};
    accordionContext.Templates = {};

    // Be careful when add the header for the template, because it's will break the default list view render
    accordionContext.Templates.Header = &quot;&lt;div class='accordion'&gt;&quot;;
    accordionContext.Templates.Footer = &quot;&lt;/div&gt;&quot;;

    // Add OnPostRender event handler to add accordion click events and style
    accordionContext.OnPostRender = accordionOnPostRender;

    // This line of code tell TemplateManager that we want to change all HTML for item row render
    accordionContext.Templates.Item = accordionTemplate;

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(accordionContext);

})();

// This function provides the rendering logic
function accordionTemplate(ctx) {
    var title = ctx.CurrentItem[&quot;Title&quot;];
    var description = ctx.CurrentItem[&quot;Description&quot;];

    // Return whole item html
    return &quot;&lt;h2&gt;&quot; &#43; title &#43; &quot;&lt;/h2&gt;&lt;p&gt;&quot; &#43; description &#43; &quot;&lt;/p&gt;&lt;br/&gt;&quot;;
}

function accordionOnPostRender() {

    // Register event to collapse and uncollapse when click on accordion header
    $('.accordion h2').click(function () {
        $(this).next().slideToggle();
    }).next().hide();

    $('.accordion h2').css('cursor', 'pointer');
}</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;List&nbsp;View&nbsp;&ndash;&nbsp;Accordion&nbsp;Sample</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Muawiyah&nbsp;Shannak&nbsp;,&nbsp;@MuShannak</span>&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;jQuery&nbsp;library&nbsp;is&nbsp;required&nbsp;in&nbsp;this&nbsp;sample</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Fallback&nbsp;to&nbsp;loading&nbsp;jQuery&nbsp;from&nbsp;a&nbsp;CDN&nbsp;path&nbsp;if&nbsp;the&nbsp;local&nbsp;is&nbsp;unavailable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(window.jQuery&nbsp;||&nbsp;document.write(<span class="js__string">'&lt;script&nbsp;src=&quot;//ajax.aspnetcdn.com/ajax/jquery/jquery-1.10.0.min.js&quot;&gt;&lt;\/script&gt;'</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;object&nbsp;that&nbsp;have&nbsp;the&nbsp;context&nbsp;information&nbsp;about&nbsp;the&nbsp;field&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;it's&nbsp;output&nbsp;render&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;accordionContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;accordionContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Be&nbsp;careful&nbsp;when&nbsp;add&nbsp;the&nbsp;header&nbsp;for&nbsp;the&nbsp;template,&nbsp;because&nbsp;it's&nbsp;will&nbsp;break&nbsp;the&nbsp;default&nbsp;list&nbsp;view&nbsp;render</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;accordionContext.Templates.Header&nbsp;=&nbsp;<span class="js__string">&quot;&lt;div&nbsp;class='accordion'&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;accordionContext.Templates.Footer&nbsp;=&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;OnPostRender&nbsp;event&nbsp;handler&nbsp;to&nbsp;add&nbsp;accordion&nbsp;click&nbsp;events&nbsp;and&nbsp;style</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;accordionContext.OnPostRender&nbsp;=&nbsp;accordionOnPostRender;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;line&nbsp;of&nbsp;code&nbsp;tell&nbsp;TemplateManager&nbsp;that&nbsp;we&nbsp;want&nbsp;to&nbsp;change&nbsp;all&nbsp;HTML&nbsp;for&nbsp;item&nbsp;row&nbsp;render</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;accordionContext.Templates.Item&nbsp;=&nbsp;accordionTemplate;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(accordionContext);&nbsp;
&nbsp;
<span class="js__brace">}</span>)();&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;provides&nbsp;the&nbsp;rendering&nbsp;logic</span>&nbsp;
<span class="js__operator">function</span>&nbsp;accordionTemplate(ctx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;title&nbsp;=&nbsp;ctx.CurrentItem[<span class="js__string">&quot;Title&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;description&nbsp;=&nbsp;ctx.CurrentItem[<span class="js__string">&quot;Description&quot;</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Return&nbsp;whole&nbsp;item&nbsp;html</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">&quot;&lt;h2&gt;&quot;</span>&nbsp;&#43;&nbsp;title&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/h2&gt;&lt;p&gt;&quot;</span>&nbsp;&#43;&nbsp;description&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/p&gt;&lt;br/&gt;&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;accordionOnPostRender()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Register&nbsp;event&nbsp;to&nbsp;collapse&nbsp;and&nbsp;uncollapse&nbsp;when&nbsp;click&nbsp;on&nbsp;accordion&nbsp;header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.accordion&nbsp;h2'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).next().slideToggle();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).next().hide();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.accordion&nbsp;h2'</span>).css(<span class="js__string">'cursor'</span>,&nbsp;<span class="js__string">'pointer'</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2>What you should learn if you browse this code sample (Accordion.js)?</h2>
<p>In this code sample you will learn how to use the JSLink templates to change rendering logic for the whole&nbsp;List View.</p>
<p><span><br>
</span></p>
