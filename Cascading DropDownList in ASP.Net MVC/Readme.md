# Cascading DropDownList in ASP.Net MVC
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC
- jQuery
- ASP.NET MVC 3
- ASP.NET MVC 4
## Topics
- User Interface
- Web Services
## Updated
- 01/09/2012
## Description

<h1>Introduction</h1>
<p>This sample shows&nbsp;how to implement cascading drop down lists in ASP.Net MVC.&nbsp; The user is presented with a list of countries. Once a country is selected, a new drop down list is displayed with the states in the selected country.</p>
<p>&nbsp;</p>
<p><img src="48388-1st.png" alt="" width="591" height="458"></p>
<p>After selecting the Country, the State Drop Down List Box appears, populated with the Sates from the country you selected.</p>
<p><img src="48389-canada.png" alt="" width="595" height="464"></p>
<p>Selecting a State displays the Submit Button.</p>
<p><img src="48390-state.png" alt="" width="603" height="471"></p>
<p>Submitting your selection shows the Country and State you selected.</p>
<p><img src="48391-submit.png" alt="" width="594" height="464"></p>
<p>If JavaScrip is disable, You get a message <strong>This site requires JavaScript</strong>.</p>
<p>That message is delivered with the new <a href="http://dev.w3.org/html5/spec-author-view/the-noscript-element.html">
HTML5&nbsp; <br>
&lt;noscript&gt; element</a> in the <em>Views\Shared\_Layout.cshtml</em> <br>
file.</p>
<pre class="code">    <span style="color:blue">&lt;</span><span style="color:maroon">noscript</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">div</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">h2</span><span style="color:blue">&gt;</span>This site requires JavaScript<span style="color:blue">&lt;/</span><span style="color:maroon">h2</span><span style="color:blue">&gt;
        &lt;/</span><span style="color:maroon">div</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">noscript</span><span style="color:blue">&gt;
</span></pre>
<p>I&rsquo;ve modified the <em>Site.css</em> file and set the main ID to not <br>
display.</p>
<pre class="code"><span style="color:maroon">#main </span>{
    <span style="color:red">display</span>: <span style="color:blue">none</span>;
    <span style="color:red">padding</span>: <span style="color:blue">30px 30px 15px 30px</span>;
 }
Browsers that have JavaScript enabled run <em>Scripts\myReady.js</em>, which shows the DOM element with ID main.</pre>
<pre class="code">$(<span style="color:blue">function </span>() {
    $(<span style="color:maroon">'#main'</span>).show();  
});</pre>
<pre class="code"><p>The <strong>IndexDDL</strong> action method creates a <a href="http://msdn.microsoft.com/en-us/library/system.web.mvc.selectlist.aspx">SelectList</a> <br>of countries, stores it in the <a href="http://rachelappel.com/when-to-use-viewbag-viewdata-or-tempdata-in-asp.net-mvc-3-applications">ViewBag</a> <br>and passes it to the <strong>IndexDDL</strong> view.</p>
<pre class="code"><span style="color:blue">public </span><span style="color:#2b91af">SelectList </span>GetCountrySelectList() {

    <span style="color:blue">var </span>countries = <span style="color:#2b91af">Country</span>.GetCountries();
    <span style="color:blue">return new </span><span style="color:#2b91af">SelectList</span>(countries.ToArray(),
                        <span style="color:#a31515">&quot;Code&quot;</span>,
                        <span style="color:#a31515">&quot;Name&quot;</span>);

}

<span style="color:blue">public </span><span style="color:#2b91af">ActionResult </span>IndexDDL() {

    ViewBag.Country = GetCountrySelectList();
    <span style="color:blue">return </span>View();
}</pre>
<br>
<p>The <strong>IndexDDL</strong> view is shown below.</p>
<br>&lt;!-- .style1 { 	background-color: #ffffff; } .style2 { 	background-color: #ffff00; } --&gt;<br>
<pre class="code"><span class="style1" style="">@{</span><span style="background:yellow"><span class="style1">
</span></span><span class="style1">    ViewBag.Title = </span><span class="style1" style="color:#a31515">&quot;Classic Cascading DDL&quot;</span>;<span class="style1">
</span><span style="background:yellow">}

@</span><span style="color:blue">using </span>(Html.BeginForm(<span style="color:#a31515">&quot;IndexDDL&quot;</span>, <span style="color:#a31515">&quot;Home&quot;</span>, <span style="color:#2b91af">FormMethod</span>.Post, 
    <span style="color:blue">new </span>{ id = <span style="color:#a31515">&quot;CountryStateFormID&quot;</span>, 
          data_stateListAction = @Url.Action(<span style="color:#a31515">&quot;StateList&quot;</span>) })) {
    <span style="color:blue">&lt;</span><span style="color:maroon">fieldset</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">legend</span><span style="color:blue">&gt;</span>Country/State<span style="color:blue">&lt;/</span><span style="color:maroon">legend</span><span style="color:blue">&gt;
        </span><span style="background:yellow">@</span><span class="style2">Html.DropDownList(</span><span class="style2" style="color:#a31515">&quot;Countries&quot;</span><span class="style2">, ViewBag.Country </span><span class="style2" style="color:blue">as </span><span class="style2" style="color:#2b91af">SelectList</span>,<span class="style2">
            </span><span class="style2" style="color:#a31515">&quot;Select a Country&quot;</span><span class="style2">, </span><span class="style2" style="color:blue">new </span><span class="style2">{ id = </span><span style="color:#a31515">&quot;<span class="style2">CountriesID&quot; </span></span><span class="style2">})</span>
        <span style="color:blue">&lt;</span><span style="color:maroon">div </span><span style="color:red">id</span><span style="color:blue">=&quot;StatesDivID&quot; &gt;
            &lt;</span><span style="color:maroon">label </span><span style="color:red">for</span><span style="color:blue">=&quot;States&quot;&gt;</span>States<span style="color:blue">&lt;/</span><span style="color:maroon">label</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">select </span><span style="color:red">id</span><span style="color:blue">=&quot;StatesID&quot;  </span><span style="color:red">name</span><span style="color:blue">=&quot;States&quot;&gt;&lt;/</span><span style="color:maroon">select</span><span style="color:blue">&gt;
        &lt;/</span><span style="color:maroon">div</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">p</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">input </span><span style="color:red">type</span><span style="color:blue">=&quot;submit&quot; </span><span style="color:red">value</span><span style="color:blue">=&quot;Submit&quot; </span><span style="color:red">id</span><span style="color:blue">=&quot;SubmitID&quot; /&gt;
        &lt;/</span><span style="color:maroon">p</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">fieldset</span><span style="color:blue">&gt;
</span>}

<span style="color:blue">&lt;</span><span style="color:maroon">script </span><span style="color:red">src</span><span style="color:blue">=&quot;</span><span style="background:yellow">@</span><span style="color:blue">Url.Content(</span><span style="color:#a31515">&quot;~/Scripts/countryState.js&quot;</span><span style="color:blue">)&quot;&gt;&lt;/</span><span style="color:maroon">script</span><span style="color:blue">&gt;
</span></pre>
<br>
<p>The Countries DropDownList has an ID <strong>CountriesID</strong> (shown in <br>yellow highlight above) which enable the <em>Scripts/countryState.js</em> script  to hook up changes in the country selection (yellow highlight below). The  <em>Scripts/countryState.js</em> file is shown below.</p>
</pre>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$(function () {

    $('#StatesDivID').hide();
    $('#SubmitID').hide();

    $('#CountriesID').change(function () {
        var URL = $('#CountryStateFormID').data('stateListAction');
        $.getJSON(URL &#43; '/' &#43; $('#CountriesID').val(), function (data) {
            var items = '&lt;option&gt;Select a State&lt;/option&gt;';
            $.each(data, function (i, state) {
                items &#43;= &quot;&lt;option value='&quot; &#43; state.Value &#43; &quot;'&gt;&quot; &#43; state.Text &#43; &quot;&lt;/option&gt;&quot;;
                // state.Value cannot contain ' character. We are OK because state.Value = cnt&#43;&#43;;
            });
            $('#StatesID').html(items);
            $('#StatesDivID').show();

        });
    });

    $('#StatesID').change(function () {
        $('#SubmitID').show();
    });
});</pre>
<div class="preview">
<pre class="js">$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#StatesDivID'</span>).hide();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#SubmitID'</span>).hide();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#CountriesID'</span>).change(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;URL&nbsp;=&nbsp;$(<span class="js__string">'#CountryStateFormID'</span>).data(<span class="js__string">'stateListAction'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.getJSON(URL&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;$(<span class="js__string">'#CountriesID'</span>).val(),&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;items&nbsp;=&nbsp;<span class="js__string">'&lt;option&gt;Select&nbsp;a&nbsp;State&lt;/option&gt;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(data,&nbsp;<span class="js__operator">function</span>&nbsp;(i,&nbsp;state)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;option&nbsp;value='&quot;</span>&nbsp;&#43;&nbsp;state.Value&nbsp;&#43;&nbsp;<span class="js__string">&quot;'&gt;&quot;</span>&nbsp;&#43;&nbsp;state.Text&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/option&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;state.Value&nbsp;cannot&nbsp;contain&nbsp;'&nbsp;character.&nbsp;We&nbsp;are&nbsp;OK&nbsp;because&nbsp;state.Value&nbsp;=&nbsp;cnt&#43;&#43;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#StatesID'</span>).html(items);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#StatesDivID'</span>).show();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#StatesID'</span>).change(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#SubmitID'</span>).show();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
