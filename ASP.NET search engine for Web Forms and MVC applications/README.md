# ASP.NET search engine for Web Forms and MVC applications
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET MVC
- ASP.NET Web Forms
## Topics
- Search
- Enterprise Search
## Updated
- 11/30/2016
## Description

<h1><span style="font-size:medium">SearchUnit Community Edition</span></h1>
<p><span style="font-size:small">SearchUnit is a powerful, index based search engine component library, for MVC &amp; Web Form applications.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong>Features of the free Community edition include;</strong><br>
</span></p>
<ul>
<li><span style="font-size:small">High-speed index based searching </span></li><li><span style="font-size:small">Phrase matching </span></li><li><span style="font-size:small">Smart result summary &amp; keyword highlighting
</span></li><li><span style="font-size:small">Stemming/Lemmas </span></li><li><span style="font-size:small">Complex expression support </span></li><li><span style="font-size:small">Spider </span></li><li><span style="font-size:small">Templated control </span></li><li><span style="font-size:small">Open, pure .NET API </span></li><li><span style="font-size:small">.NET 1.1 through 4.x compatible</span> </li></ul>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">Features of the Lite &amp; Pro editions include;</span></strong></p>
<ul>
<li><span style="font-size:small">Multiple document format indexing </span></li><li><span style="font-size:small">'Did you mean?' spelling suggestions </span></li><li><span style="font-size:small">Content &amp; Location categorization </span></li><li><span style="font-size:small">Windows Service based recrawling/reindexing </span>
</li><li><span style="font-size:small">Reusable administration web application </span>
</li><li><span style="font-size:small">Unlimited index size (URLs) </span></li><li><span style="font-size:small">No 'powered-by' link </span></li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small">To download SearchUnit and add a search engine to your web application, please visit
<a href="https://keyoti.com/products/search/dotNetWeb/index.html">https://keyoti.com/products/search/dotNetWeb/index.html</a></span></p>
<p><span style="font-size:small">For a complete list of features and pricing please visit
<a href="https://keyoti.com/products/search/dotNetWeb/licensing.html">https://keyoti.com/products/search/dotNetWeb/licensing.html</a></span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;sew_searchBoxControl&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;<span class="html__tag_start">&lt;small</span><span class="html__tag_start">&gt;</span>Try&nbsp;keywords&nbsp;like:&nbsp;soup,&nbsp;cheese,&nbsp;chicken,&nbsp;salt<span class="html__tag_end">&lt;/small&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;max-width:800px;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;sew_searchResultControl&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;keyotiSearch.useWCFService=true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;keyotiSearch.indexDirectory&nbsp;=&nbsp;<span class="js__string">&quot;~/CategorizedWebSite/IndexDirectory&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;keyotiSearch.onCategoryControlsCreated&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!data.CategoriesEnabled)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Sorry&nbsp;this&nbsp;feature&nbsp;is&nbsp;only&nbsp;present&nbsp;in&nbsp;the&nbsp;Pro&nbsp;edition,&nbsp;but&nbsp;you&nbsp;have&nbsp;installed&nbsp;either&nbsp;the&nbsp;Lite&nbsp;or&nbsp;Community&nbsp;edition.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<h2>ASP.NET Quick Start Guide</h2>
<span>Please follow these simple steps to quickly setup SearchUnit in an ASP.NET web application. If you are using MVC, please follow the&nbsp;</span><a href="https://keyoti.com/products/search/dotNetWeb/tutorials/setup-MVC-search-engine/">MVC quick start guide</a><span>&nbsp;instead.</span>
<div class="quickStart-Cont">
<div class="QS-step">
<h3 class="quickStart-Step">Load/Create a project and add a page or webform.</h3>
<img src=":-create-app.png" alt="Create your MVC web project"></div>
<div class="QS-step">
<h3 class="quickStart-Step">Create a new folder to store the index files;</h3>
<p>Open the project folder in File Explorer</p>
<p>Create a new folder called 'Keyoti_Search_Index'</p>
<img src=":-open-file-explorer.png" alt="Open in File Explorer">&nbsp;<br>
<img src=":-add-search-index-folder.png" alt="Create a new folder for the index"></div>
<div class="QS-step">
<h3>Open the Index Manager Tool from the Start Menu and enter the path to your index directory.</h3>
<p>The Index Manager Tool can be found under the Start Menu;</p>
<div class="QS-code">Start Menu -&gt; All Programs -&gt; SearchUnit -&gt; Index Manager Tool</div>
<img src=":-open-index-manager-tool.png" alt="Open the index manager tool"></div>
<div class="QS-step">
<h3>Select 'Import New Source', enter the start URL &amp; click 'Import'.</h3>
<img src=":-import-sources.png" alt="Select Import New Source"><img src=":-import-website-source.png" alt="Import a Website Source">
<p>If an error reports the page cannot be read, please check the URL or consult the user guide for help.</p>
<p>Once the import is complete close the Import window, select 'Optimize' and click 'Start Optimize'.</p>
</div>
<div class="QS-step">
<h3>Copy the SearchUnit scripts folder to your project;</h3>
<p>Open the SearchUnit install folder (via Start Menu or File Explorer).</p>
<p>Copy the&nbsp;<strong>Keyoti_SearchEngine_Web_Common</strong>&nbsp;folder.</p>
<p>Paste to your application's Solution Explorer.</p>
<img src=":-copy-searchunit-scripts.png" alt="Copy scripts folder to your project."></div>
<div class="QS-step">
<h3>Add the SearchUnit JS and CSS tags to the head of your page.</h3>
<p>To automatically add the tags, drag SearchUnit.js and SearchUnit.css from the Solution Explorer on to the page source. Alternatively copy and paste the tags as below to the head of your page.</p>
<div class="QS-code"><span>&lt;</span><span>script</span><span>&nbsp;</span><span>src</span><span>=&quot;Keyoti_SearchEngine_Web_Common/SearchUnit.js&quot;&gt;&lt;/</span><span>script</span><span>&gt;</span>&nbsp;<br>
<span>&lt;</span><span>link</span><span>&nbsp;</span><span>href</span><span>=&quot;Keyoti_SearchEngine_Web_Common/SearchUnit.css&quot;</span><span>&nbsp;</span><span>rel</span><span>=&quot;stylesheet&quot;</span><span>&nbsp;</span><span>/&gt;</span></div>
<p>.NET 2 users must also add the following to all pages using SearchUnit (or set the variable from a common JS file).</p>
<div class="QS-code"><span>&lt;</span><span>script</span><span>&nbsp;</span><span>type</span><span>=&quot;text/javascript&quot;&gt;</span><span>keyotiSearch.useWCFService=false;</span><span>&lt;/</span><span>script</span><span>&gt;</span>&nbsp;</div>
</div>
<div class="QS-step">
<h3>Add the SearchUnit divs to your page.</h3>
<div class="QS-code">&lt;div id=&quot;sew_searchBoxControl&quot;&gt;&lt;/div&gt;<br>
&lt;div id=&quot;sew_searchResultControl&quot;&gt;&lt;/div&gt;</div>
<p><strong>sew_searchBoxControl</strong>&nbsp;is the search text box and button.</p>
<p><strong>sew_searchResultControl</strong>&nbsp;is the search result control.</p>
</div>
<div class="QS-step">
<h3>Run the web application (hit F5) and try a search!</h3>
<p>Here a search was done for 'themselves'.</p>
<img src=":-search-results.png" alt="Search results page">
<h4>Go further!</h4>
<p>Now you're ready to explore more features in SearchUnit, please take a look at the 'Features' page in the help for more information on all that SearchUnit can do.</p>
</div>
</div>
</div>
</div>
