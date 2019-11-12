# Creating a Reactjs multi language app
## License
- MIT
## Technologies
- ReactJS
## Topics
- Multiple Language Support Application
## Updated
- 07/28/2017
## Description

<p><a rel="noopener" href="https://facebook.github.io/react/" target="_blank">Reactjs</a> is one of the most popular front-end framework, it's also adopted by Facebook, Microsoft, Samsung and other several big companies.
<br>
Often happens to develop Web App with the support to different languages, so I decided to share my experience with Reactjs, in detail as you can see below I developed a simple react solution where is possible to change the language instantly:</p>
<p><img class="alignnone size-full x_wp-image-433" src="-preview.gif" alt="Giuliano De Luca | Blog | react multi language app" width="700px"></p>
<p>The solution is absolutely simple, I stored the translations in a .ts file (json format), because I used
<a rel="noopener" href="https://www.typescriptlang.org/" target="_blank">Typescript</a>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">const</span>&nbsp;language&nbsp;=&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;English</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'welcome'</span>:&nbsp;<span class="js__string">'Welcome'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'description'</span>:&nbsp;<span class="js__string">'This&nbsp;app&nbsp;demonstrates&nbsp;how&nbsp;to&nbsp;easily&nbsp;use&nbsp;a&nbsp;multilanguage&nbsp;mechanism&nbsp;with&nbsp;Office&nbsp;UI&nbsp;Fabric'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Deutsch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'welcome'</span>:&nbsp;<span class="js__string">'Willkommen'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'description'</span>:&nbsp;<span class="js__string">'Diese&nbsp;App&nbsp;demonstriert,&nbsp;wie&nbsp;man&nbsp;leicht&nbsp;einen&nbsp;mehrsprachigen&nbsp;Mechanismus&nbsp;mit&nbsp;Office&nbsp;UI&nbsp;Fabric&nbsp;verwendet'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Italian</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'welcome'</span>:&nbsp;<span class="js__string">'Benvenuto'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'description'</span>:&nbsp;<span class="js__string">'Questa&nbsp;app&nbsp;dimostra&nbsp;come&nbsp;utilizzare&nbsp;facilmente&nbsp;un&nbsp;meccanismo&nbsp;multilingue&nbsp;con&nbsp;Office&nbsp;UI&nbsp;Fabric'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Spanish</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'welcome'</span>:&nbsp;<span class="js__string">'Bienvenido'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'description'</span>:&nbsp;<span class="js__string">'Esta&nbsp;aplicaci&oacute;n&nbsp;demuestra&nbsp;c&oacute;mo&nbsp;utilizar&nbsp;f&aacute;cilmente&nbsp;un&nbsp;mecanismo&nbsp;multilenguaje&nbsp;con&nbsp;Office&nbsp;UI&nbsp;Fabric'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
]&nbsp;
export&nbsp;<span class="js__statement">default</span>&nbsp;language;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Here the component:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;*&nbsp;as&nbsp;React&nbsp;from&nbsp;<span class="js__string">&quot;react&quot;</span>;&nbsp;
import&nbsp;t&nbsp;from&nbsp;<span class="js__string">'./language'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;MultilanguageState&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./MultilanguageState'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;Label&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'office-ui-fabric-react/lib/Label'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;Icon&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'office-ui-fabric-react/lib/Icon'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;PivotItem,&nbsp;
&nbsp;&nbsp;IPivotItemProps,&nbsp;
&nbsp;&nbsp;Pivot&nbsp;
<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'office-ui-fabric-react/lib/Pivot'</span>;&nbsp;
&nbsp;
export&nbsp;interface&nbsp;MultilanguageProps&nbsp;<span class="js__brace">{</span>&nbsp;compiler:&nbsp;string;&nbsp;framework:&nbsp;string;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;'MultilanguageProps'&nbsp;describes&nbsp;the&nbsp;shape&nbsp;of&nbsp;props.</span>&nbsp;
<span class="js__sl_comment">//&nbsp;State&nbsp;is&nbsp;never&nbsp;set&nbsp;so&nbsp;we&nbsp;use&nbsp;the&nbsp;'undefined'&nbsp;type.</span>&nbsp;
export&nbsp;class&nbsp;Multilanguage&nbsp;extends&nbsp;React.Component&lt;MultilanguageProps,&nbsp;MultilanguageState&gt;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;constructor(props:&nbsp;MultilanguageProps,&nbsp;state:&nbsp;MultilanguageState)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;super(props);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.state&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;status:&nbsp;<span class="js__string">''</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentLanguage:&nbsp;<span class="js__num">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//this._getErrorMessage&nbsp;=&nbsp;this._getErrorMessage.bind(this);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;componentWillMount()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">&quot;componentWillMount!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;favorite&nbsp;language</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;favoriteLanguage&nbsp;=&nbsp;<span class="js__string">'en'</span>;&nbsp;<span class="js__sl_comment">//this.getUrlQueryString('SPLanguage');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(favoriteLanguage.search(<span class="js__reg_exp">/en/i</span>)&nbsp;&gt;&nbsp;-<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.setState(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentLanguage:&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.setState(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentLanguage:&nbsp;<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;render()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Pivot&nbsp;onLinkClick=<span class="js__brace">{</span>&nbsp;<span class="js__operator">this</span>.onLinkClick.bind(<span class="js__operator">this</span>)&nbsp;<span class="js__brace">}</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PivotItem&nbsp;linkText=<span class="js__string">'English'</span>&nbsp;itemIcon=<span class="js__string">'TextBox'</span>&nbsp;itemKey=<span class="js__string">'en'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/PivotItem&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PivotItem&nbsp;linkText=<span class="js__string">'German'</span>&nbsp;itemIcon=<span class="js__string">'TextBox'</span>&nbsp;itemKey=<span class="js__string">'de'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/PivotItem&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PivotItem&nbsp;linkText=<span class="js__string">'Italian'</span>&nbsp;itemIcon=<span class="js__string">'TextBox'</span>&nbsp;itemKey=<span class="js__string">'it'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/PivotItem&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PivotItem&nbsp;linkText=<span class="js__string">'Spanish'</span>&nbsp;itemIcon=<span class="js__string">'TextBox'</span>&nbsp;itemKey=<span class="js__string">'es'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/PivotItem&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Pivot&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;<span class="js__brace">{</span>t[<span class="js__operator">this</span>.state.currentLanguage].welcome<span class="js__brace">}</span>&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.props.compiler<span class="js__brace">}</span>&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.props.framework<span class="js__brace">}</span>&nbsp;App!&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;<span class="js__brace">{</span>t[<span class="js__operator">this</span>.state.currentLanguage].description<span class="js__brace">}</span>&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;onLinkClick(item:&nbsp;PivotItem):&nbsp;<span class="js__operator">void</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(item.props.linkText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;languageSelected&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">switch</span>&nbsp;(item.props.itemKey)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;de&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;languageSelected&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;it&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;languageSelected&nbsp;=&nbsp;<span class="js__num">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;es&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;languageSelected&nbsp;=&nbsp;<span class="js__num">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.setState(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentLanguage:&nbsp;languageSelected&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The mechanism works in combination with the react state where is saved a current language used, every time that the user changes the language basically the current language state receive a new value.&nbsp;</div>
</div>
<p>In order to display the string welcome for example is important to use the following notation:</p>
<pre class="lang:js x_decode:true">{t[this.state.currentLanguage].welcome}<br></pre>
<p>This could be a potential scenario of a SharePoint Add-In for example.</p>
<p>In my solution I used <a rel="noopener" href="https://dev.office.com/fabric" target="_blank">
Office UI Fabric</a>, check the source code on Github: <br>
<a rel="noopener" href="https://github.com/giuleon/react-multilanguage-app" target="_blank">https://github.com/giuleon/react-multilanguage-app</a></p>
<p>Check the video: <br>
<a href="https://youtu.be/QPzoPuaf8Y8" target="_blank">https://youtu.be/QPzoPuaf8Y8</a></p>
<p>Read my article:</p>
<p><a href="http://www.delucagiuliano.com/creating-a-reactjs-multi-language-app/" target="_blank">http://www.delucagiuliano.com/creating-a-reactjs-multi-language-app/</a></p>
