# ASP.NET MVC. RedirectToAction propagando el QueryString
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET
- MVC
- MVC Examples
- ASP.NET MVC 5
- MVC5
## Topics
- URL Routing
## Updated
- 03/17/2015
## Description

<div>En ocasiones nos podemos encontrar con en una acci&oacute;n de redirecci&oacute;n necesitamos pasar valores recibidos en el QueryString a la acci&oacute;n destino. Si los posibles par&aacute;metros son pocos y claramente definidos podemos hacerlo a trav&eacute;s
 del&nbsp;par&aacute;metro&nbsp;<em>routeValues</em>. &iquest;Pero qu&eacute; pasa si los posibles par&aacute;metros son muchos o, peor a&uacute;n, indefinidos?</div>
<div>&nbsp;</div>
<div>He le&iacute;do alg&uacute;n comentario por parte del equipo de desarrollo de MVC indicando que es una problem&aacute;tica a la que tienen pensado dar soluci&oacute;n en futuras versiones. Pero, &iquest;qu&eacute; se puede hacer mientras tanto?</div>
<div>&nbsp;</div>
<div>Para mostrar tanto el problema como la soluci&oacute;n voy a crear un nuevo proyecto web
<em>RedirectQueryString </em>utilizando la plantilla vac&iacute;a de ASP.NET y marcando el check MVC.</div>
<div>&nbsp;</div>
<div><img id="134968" src="134968-redirectquerystringproject.jpg" alt="" width="644" height="435"></div>
<div><img id="134969" src="134969-redirectquerystringproject2.jpg" alt="" width="646" height="423"></div>
<div>&nbsp;</div>
<div>En la carpeta <em>Controllers </em>creo un controlador <em>HomeController.cs
</em>con dos acciones:</div>
<ul>
<li>La acci&oacute;n <em>Index </em>que ser&aacute; el destino de la redirecci&oacute;n. Esta acci&oacute;n simplemente mostrar&aacute; el nombre de la acci&oacute;n y el contenido de la colecci&oacute;n
<em>RouteData </em>y el <em>QueryString</em>. Para simplificar el ejemplo devuelve los datos en un string directamente al navegador.
</li><li>La acci&oacute;n <em>Redirect </em>que devuelve un resultado <em>RedirectToRouteResult
</em>redirigiendo la petici&oacute;n a la acci&oacute;n <em>Index</em>. </li></ul>
<div>El c&oacute;digo del archivo <em>HomeController.cs</em>:</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;RedirectQueryString.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;result&nbsp;=&nbsp;<span class="cs__string">&quot;Action:&nbsp;Index&lt;br/&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&lt;b&gt;RouteData&lt;/b&gt;&lt;br/&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;key&nbsp;<span class="cs__keyword">in</span>&nbsp;RouteData.Values.Keys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;&#43;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}:&nbsp;{1}&lt;br/&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;key,&nbsp;RouteData.Values[key]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&lt;b&gt;QueryString&lt;/b&gt;&lt;br/&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;key&nbsp;<span class="cs__keyword">in</span>&nbsp;Request.QueryString.AllKeys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;&#43;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}:&nbsp;{1}&lt;br/&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;key,&nbsp;Request.QueryString[key]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RedirectToRouteResult&nbsp;Redirect()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Si arrancamos la aplicaci&oacute;n y accedemos a las urls
<em>http://&lt;rutapublicacion&gt;</em> o <em>http://&lt;rutapublicacion&gt;/Home/Redirect</em> obtenemos el mismo resultado:</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div><img id="134970" src="134970-redirectresult1.jpg" alt="" width="323" height="207"></div>
<div>Pero &iquest;qu&eacute; sucede si intentamos acceder a una url del tipo <em>
http://&lt;rutapublicacion&gt;/Home/Redirect?dato=4</em> ? Obtenemos exactamente el mismo resultado. Entonces, &iquest;c&oacute;mo conseguimos pasar el valor de dato a la acci&oacute;n Index?
<p>La opci&oacute;n m&aacute;s sencilla es utilizar el par&aacute;metro <em>routeValues
</em>del m&eacute;todo <em>RedirectToAction</em>. Para ello reescribimos el c&oacute;digo de la acci&oacute;n
<em>Redirect</em>:</p>
</div>
<div>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RedirectToRouteResult&nbsp;Redirect()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;dato&nbsp;=&nbsp;Request.QueryString[<span class="cs__string">&quot;dato&quot;</span>]&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Ahora al acceder a la url <em>http://&lt;rutapublicacion&gt;/Home/Redirect?dato=14</em>:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><img id="134971" src="134971-redirectresult2.jpg" alt="" width="353" height="225"></div>
<div class="endscriptcode">&nbsp;&iquest;Y si los posibles valores fueran muchos o no los conoci&eacute;ramos de antemano? Entonces utilizar&iacute;amos la sobrecarga del m&eacute;todo
<em>RedirectToAction </em>que acepta una colecci&oacute;n del tipo <em>RouteValueDictionary</em>:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RedirectToRouteResult&nbsp;Redirect()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RouteValueDictionary&nbsp;routeData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RouteValueDictionary();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;key&nbsp;<span class="cs__keyword">in</span>&nbsp;Request.QueryString.AllKeys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routeData.Add(key,&nbsp;Request.QueryString[key]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>,&nbsp;routeData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Para utilizar la clase <em>RouteValueDictionary</em> deberemos a&ntilde;adir una referencia al namespace
<em><a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Web.Routing.aspx" target="_blank" title="Auto generated link to System.Web.Routing">System.Web.Routing</a></em>:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Web.Routing.aspx" target="_blank" title="Auto generated link to System.Web.Routing">System.Web.Routing</a>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Para probarlo accedemos a la url: <em><a href="http://null">http://&lt;rutapublicacion&gt;/Home/Redirect?dato=4&amp;otrodato=8</a></em>:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><img id="134973" src="134973-redirectresult3.jpg" alt="" width="421" height="233"></div>
<div class="endscriptcode">Otro escenario que quer&iacute;a contemplar es cuando utilizamos estos valores del QueryString a lo largo de toda la aplicaci&oacute;n y tenemos muchas acciones de redirecci&oacute;n. Podr&iacute;amos repetir el c&oacute;digo anterior
 en todas las acciones o utilizar un atributo de filtro. He de decir que la soluci&oacute;n anterior tambi&eacute;n me ha dado alg&uacute;n problema cuando la acci&oacute;n destino requiere autenticaci&oacute;n y debe pasar por una pantalla de login, en este
 caso tambi&eacute;n es una alternativa a tener en cuenta.</div>
</div>
</div>
<div class="endscriptcode">
<p>Para mostrar esta soluci&oacute;n vamos a crear una nueva carpeta <em>Code</em> en el proyecto y en esta carpeta una nuevo archivo de clase llamado
<em>PropagarQueryStringAttribute.cs</em>. La clase <em>PropagarQueryStringAttribute</em> heredar&aacute; de la clase
<em>ActionFilterAttribute</em>, esta clase implementa las interfaces <em>IActionFilter</em> e
<em>IResultFilter</em> las cuales definen m&eacute;todos que se ejecutan antes y despu&eacute;s de ejecutar la acci&oacute;n y el resultado de &eacute;sta respectivamente. En este caso sobreescribiremos el m&eacute;todo que se ejecuta despu&eacute;s de ejecutar
 la acci&oacute;n para a&ntilde;adir a la colecci&oacute;n <em>RouteValues</em> del resultado los valores del QueryString:</p>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Specialized.aspx" target="_blank" title="Auto generated link to System.Collections.Specialized">System.Collections.Specialized</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RedirectQueryString.Code&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PropagarQueryStringAttribute:&nbsp;ActionFilterAttribute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuted(ActionExecutedContext&nbsp;filterContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;redirectResult&nbsp;=&nbsp;filterContext.Result&nbsp;<span class="cs__keyword">as</span>&nbsp;RedirectToRouteResult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(redirectResult&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NameValueCollection&nbsp;query&nbsp;=&nbsp;filterContext.HttpContext.Request.QueryString;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;key&nbsp;<span class="cs__keyword">in</span>&nbsp;query.Keys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!redirectResult.RouteValues.ContainsKey(key))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redirectResult.RouteValues.Add(key,&nbsp;query[key]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnActionExecuted(filterContext);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Para probar el nuevo atributo crearemos una nueva acci&oacute;n en el archivo
<em>HomeController.cs</em> y le aplicamos el atributo reci&eacute;n creado:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[PropagarQueryString]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RedirectToRouteResult&nbsp;RedirectQueryString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Para poder utilizar el atributo <em>PropagarQueryString</em> deberemos a&ntilde;adir una referencia al namespace
<em>RedirectQueryString.Code</em>:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;RedirectQueryString.Code;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Para probar el nuevo atributo accedemos a la url
<em>http://&lt;rutapublicacion&gt;/Home/RedirectQueryString?dato=4&amp;otrodato=8</em>:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><img id="134974" src="134974-redirectresult3.jpg" alt="" width="421" height="233"></div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
</div>
