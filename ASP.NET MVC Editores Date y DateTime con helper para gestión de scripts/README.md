# ASP.NET MVC Editores Date y DateTime con helper para gestión de scripts
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET
- Razor
- MVC
- MVC Examples
- ASP.NET MVC 5
- MVC5
## Topics
- UI Layout
## Updated
- 04/29/2015
## Description

<p>Este ejemplo muestra c&oacute;mo podemos gestionar los scripts de plantillas y vistas parciales sin cargar c&oacute;digo de m&aacute;s en p&aacute;ginas que no lo necesitan ni repetir c&oacute;digo en p&aacute;ginas que muestran varias veces una misma plantilla.</p>
<p>Para solucionar el problema voy a crear tres m&eacute;todos de extensi&oacute;n de la clase HtmlHelper.</p>
<p>La idea es sencilla: ir incluyendo todos los scripts en una colecci&oacute;n que controle que no se incluyan scripts repetidos y renderizarlos al final de la p&aacute;gina. Para ello, voy a crear una nueva clase ScriptHelper, en una nueva carpeta Infrastructure
 en la que definir&eacute; tres m&eacute;todos de extensi&oacute;n, uno para a&ntilde;adir referencias a archivos javascript (AddScriptFile), otro para a&ntilde;adir c&oacute;digo javascript (AddScript)&nbsp; y un &uacute;ltimo m&eacute;todo que se encargar&aacute;
 de escribir los bloques script en la p&aacute;gina (RenderScripts).</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCDateTimePicker.Infrastructure&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">class</span>&nbsp;ScriptHelper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">const</span><span class="cs__keyword">string</span>&nbsp;scriptItemsKey&nbsp;=&nbsp;<span class="cs__string">&quot;ScriptBlocks&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">enum</span>&nbsp;ScriptType&nbsp;{&nbsp;Code,&nbsp;File&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">class</span>&nbsp;ScriptBlock&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ScriptType&nbsp;ScriptType&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Script&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">static</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;ScriptBlock&gt;&nbsp;ScriptCollection(HtmlHelper&nbsp;html)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContextBase&nbsp;_httpContext&nbsp;=&nbsp;html.ViewContext.HttpContext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!_httpContext.Items.Contains(scriptItemsKey))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_httpContext.Items[scriptItemsKey]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;ScriptBlock&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;ScriptBlock&gt;)_httpContext.Items[scriptItemsKey];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;MvcHtmlString&nbsp;AddScript(<span class="cs__keyword">this</span>&nbsp;HtmlHelper&nbsp;html,&nbsp;<span class="cs__keyword">string</span>&nbsp;key,&nbsp;<span class="cs__keyword">string</span>&nbsp;scriptCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;ScriptBlock&gt;&nbsp;scripts&nbsp;=&nbsp;ScriptCollection(html);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!scripts.ContainsKey(key))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scripts.Add(key&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="cs__keyword">new</span>&nbsp;ScriptBlock&nbsp;{&nbsp;ScriptType&nbsp;=&nbsp;ScriptType.Code,&nbsp;Script&nbsp;=&nbsp;scriptCode&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;MvcHtmlString.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;MvcHtmlString&nbsp;AddScriptFile(<span class="cs__keyword">this</span>&nbsp;HtmlHelper&nbsp;html,&nbsp;<span class="cs__keyword">string</span>&nbsp;key,&nbsp;<span class="cs__keyword">string</span>&nbsp;scriptFile)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;ScriptBlock&gt;&nbsp;scripts&nbsp;=&nbsp;ScriptCollection(html);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!scripts.ContainsKey(key))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scripts.Add(key&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="cs__keyword">new</span>&nbsp;ScriptBlock&nbsp;{&nbsp;ScriptType&nbsp;=&nbsp;ScriptType.File,&nbsp;Script&nbsp;=&nbsp;scriptFile&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;MvcHtmlString.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;MvcHtmlString&nbsp;RenderScripts(<span class="cs__keyword">this</span>&nbsp;HtmlHelper&nbsp;html)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;ScriptBlock&gt;&nbsp;scripts&nbsp;=&nbsp;ScriptCollection(html);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(ScriptBlock&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;scripts.Values)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TagBuilder&nbsp;scriptTag&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TagBuilder(<span class="cs__string">&quot;script&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scriptTag.MergeAttribute(<span class="cs__string">&quot;type&quot;</span>,&nbsp;<span class="cs__string">&quot;text/javascript&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item.ScriptType&nbsp;==&nbsp;ScriptType.File)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scriptTag.MergeAttribute(<span class="cs__string">&quot;src&quot;</span>,&nbsp;UrlHelper.GenerateContentUrl(item.Script,&nbsp;html.ViewContext.HttpContext));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scriptTag.InnerHtml&nbsp;=&nbsp;Environment.NewLine&nbsp;&#43;&nbsp;item.Script&nbsp;&#43;&nbsp;Environment.NewLine;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;&#43;=&nbsp;scriptTag.ToString(TagRenderMode.Normal)&nbsp;&#43;&nbsp;Environment.NewLine;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;html.ViewContext.HttpContext.Items.Remove(scriptItemsKey);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;MvcHtmlString.Create(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Los m&eacute;todos AddScript y AddScriptFile crean un objecto ScriptBlock, cada uno de un tipo diferente, y lo incluyen en una colecci&oacute;n Dictionary. A cada objecto ScriptBlock le asignamos una key que nos permite evitar incluir en la colecci&oacute;n
 objetos repetidos.</p>
<p>Esta colecci&oacute;n Dictionary se almacena en la colecci&oacute;n Items del objecto HttpContext al que tenemos acceso a trav&eacute;s de la propiedad ViewContext del HtmlHelper.</p>
<p>Finalmente el m&eacute;todo RenderScripts genera el c&oacute;digo html a enviar a la p&aacute;gina para cada uno de los elementos ScriptBlock de la colecci&oacute;n.</p>
<p>Para probarlo he incluido una llamada al m&eacute;todo RenderScripts al final de la p&aacute;gina principal de dise&ntilde;o (_Layout.cshtml/_Layout.vbhtml) que se encargar&aacute; de generar el c&oacute;digo de todos los scripts que se hayan ido a&ntilde;adiendo
 a lo largo del procesamiento de la vista.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">@<span class="cs__keyword">using</span>&nbsp;MVCDateTimePicker.Infrastructure&nbsp;
&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;name=<span class="cs__string">&quot;viewport&quot;</span>&nbsp;content=<span class="cs__string">&quot;width=device-width&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;@ViewBag.Title&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="cs__string">&quot;~/Content/jquery.datetimepicker.css&quot;</span>&nbsp;rel=<span class="cs__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;~/Scripts/jquery-2.1.3.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@RenderBody()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
@Html.RenderScripts()&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Y he creado dos plantillas de editores, en la carpeta Shared/EditorTemplates, para los tipos de datos Date y DateTime basados en el plugin jquery datetimepicker.</p>
<p>Date.cshtml/Date.vbhtml</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">@<span class="cs__keyword">using</span>&nbsp;MVCDateTimePicker.Infrastructure&nbsp;
@model&nbsp;DateTime&nbsp;
&nbsp;
@Html.AddScriptFile(<span class="cs__string">&quot;datetimepicker_plugin&quot;</span>,&nbsp;<span class="cs__string">&quot;~/Scripts/jquery.datetimepicker.js&quot;</span>)&nbsp;
@Html.AddScript(<span class="cs__string">&quot;init_Date_Editor&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;@&quot;&nbsp;&nbsp;&nbsp;&nbsp;$(function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'.datepicker'</span>).datetimepicker({&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lang:&nbsp;<span class="cs__string">'es'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;format:&nbsp;<span class="cs__string">'d/m/Y'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;formatDate:&nbsp;<span class="cs__string">'d/m/Y'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dayOfWeekStart:&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mask:&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timepicker:&nbsp;<span class="cs__keyword">false</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&quot;)&nbsp;
&nbsp;
@Html.TextBox(<span class="cs__string">&quot;&quot;</span>,&nbsp;(Model&nbsp;==&nbsp;DateTime.MinValue&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;Model.ToString(<span class="cs__string">&quot;dd/MM/yyyy&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;datepicker&quot;</span>&nbsp;})&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;DateTime.cshtml/DateTime.vbhtml</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">@<span class="cs__keyword">using</span>&nbsp;MVCDateTimePicker.Infrastructure&nbsp;
@model&nbsp;DateTime&nbsp;
&nbsp;
@Html.AddScriptFile(<span class="cs__string">&quot;datetimepicker_plugin&quot;</span>,&nbsp;<span class="cs__string">&quot;~/Scripts/jquery.datetimepicker.js&quot;</span>)&nbsp;
@Html.AddScript(<span class="cs__string">&quot;init_DateTime_Editor&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;@&quot;&nbsp;&nbsp;&nbsp;&nbsp;$(function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'.datetimepicker'</span>).datetimepicker({&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lang:&nbsp;<span class="cs__string">'es'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;format:&nbsp;<span class="cs__string">'d/m/Y&nbsp;H:i'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;formatDate:&nbsp;<span class="cs__string">'d/m/Y'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dayOfWeekStart:&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mask:&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});&quot;)&nbsp;
&nbsp;
@Html.TextBox(<span class="cs__string">&quot;&quot;</span>,&nbsp;(Model&nbsp;==&nbsp;DateTime.MinValue&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;Model.ToString(<span class="cs__string">&quot;dd/MM/yyyy&nbsp;hh:mm&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;@<span class="cs__keyword">class</span>&nbsp;=&nbsp;<span class="cs__string">&quot;datetimepicker&quot;</span>&nbsp;})</pre>
</div>
</div>
</div>
&nbsp;M&aacute;s Informaci&oacute;n</h1>
<div class="endscriptcode">Se puede encontrar informaci&oacute;n m&aacute;s detallada del ejemplo en los siguientes art&iacute;culos:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><a href="http://pildorasdotnet.blogspot.com.es/2015/04/aspnet-mvc-platilla-de-editor-para.html" target="_blank">ASP.NET MVC. Platilla de editor para fecha y hora</a></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><a href="http://pildorasdotnet.blogspot.com/2015/04/aspnet-mvc-gestion-de-scripts-en.html" target="_blank">ASP.NET MVC. Gesti&oacute;n de Scripts en Plantillas y Vistas Parciales</a></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
