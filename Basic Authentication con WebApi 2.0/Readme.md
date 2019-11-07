# Basic Authentication con WebApi 2.0
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- WebAPI
- Basic-Authentication
## Topics
- seguridad
## Updated
- 05/25/2015
## Description

<h1>Introducci&oacute;n</h1>
<p class="p1">Hola a todos.</p>
<p class="p1">En ocasiones pasadas estuvimos estudiando el manejo de los servicios HTTP por medio de WebApi, en los ejemplo que hemos realizado no se han involucrado conceptos de seguridad que permitan de alguna forma proteger la informaci&oacute;n o los
 m&eacute;todos que son expuestos por medio nuestra API.</p>
<p class="p1">Muy bien en este post y algunos adicionales voy a mostrar como se pueden implementar diferentes metodolog&iacute;as de autenticaci&oacute;n, seguridad y protecci&oacute;n de acceso a nuestras APIs, algunos de estos m&eacute;todos ser&aacute;n
 m&aacute;s sofisticado o elaborados que otros, por lo tanto, deben ser evaluados cuidadosamente al momento de elegir nuestro protocolo de seguridad para el desarrollo de servicios HTTP.</p>
<p class="p1">La primera t&eacute;cnica que evaluaremos en este art&iacute;culo es la autenticaci&oacute;n b&aacute;sica (Basic Authentication), este m&eacute;todo permite que nuestras APIs solamente sean accedidas por usuarios que cuenten con credenciales
 v&aacute;lidas, las cuales son suministradas en el momento de realizar las peticiones. Al tratarse de autenticaci&oacute;n b&aacute;sica debemos tener en cuenta que se tiene que implementar una l&oacute;gica dentro de nuestra API, que valide que las credenciales
 presentadas en la solicitud son v&aacute;lidas, con lo cual se otorga el acceso a la API.</p>
<p>&nbsp;</p>
<h1><span>Descripci&oacute;n</span></h1>
<p class="p1">Para empezar crearemos un nuevo proyecto Web el cual trabajaremos solamente con la plantilla de WebApi:</p>
<p class="p2"><img id="138177" src="138177-2015-05-25_1626.png" alt="" width="751" height="564"></p>
<p class="p2">&nbsp;</p>
<p class="p1">Lo siguiente es crear un controlador simple que nos devuelva cualquier resultado, lo importante es poder validar posteriormente que lo podamos acceder al autenticarnos:</p>
<p class="p2">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiAuthentication.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(&quot;Hola &quot;);
        }

    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Http;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebApiAuthentication.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ValuesController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IHttpActionResult&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Ok(<span class="cs__string">&quot;Hola&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p class="p1">Hasta este punto tenemos un controlador de WebApi que nos devuelve el texto &ldquo;Hola &rdquo; al consultarlo por el m&eacute;todo GET en la direcci&oacute;n /Api/Values</p>
<p class="p3"><img id="138178" src="138178-2015-05-25_1636.png" alt="" width="1132" height="417"></p>
<p class="p8"><strong>&nbsp;</strong></p>
<p class="p1">Lo que haremos a continuaci&oacute;n es incluir la l&oacute;gica para la autenticaci&oacute;n, para esto debemos agregar una clase m&oacute;dulo en la cual definiremos el comportamiento de la interface IHttpModule, con la cual interceptaremos
 las solicitudes y realizaremos la correspondiente validaci&oacute;n de credenciales.</p>
<p class="p2">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace WebApiAuthentication.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = &quot;WebAPI Authentication&quot;;

        public void Init(HttpApplication context)
        {
            // Se registran los manejadores de los eventos
            context.AuthenticateRequest &#43;= OnApplicationAuthenticateRequest;
            context.EndRequest &#43;= OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding(&quot;iso-8859-1&quot;);
            credentials = encoding.GetString(Convert.FromBase64String(credentials));

            var credentialsArray = credentials.Split(':');
            var username = credentialsArray[0];
            var password = credentialsArray[1];

            /* Aqu&iacute; se validan las credenciales o el token enviado en el encabezado de la solicitud */
            if (!(username == &quot;test&quot; &amp;&amp; password == &quot;test&quot;))
            {
                return false;
            }

            var identity = new GenericIdentity(username);
            SetPrincipal(new GenericPrincipal(identity, null));

            return true;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers[&quot;Authorization&quot;];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // Se valida si el esquema de autenticaci&oacute;n es b&aacute;sico (Basic Authentication)
                if (authHeaderVal.Scheme.Equals(&quot;basic&quot;, StringComparison.OrdinalIgnoreCase) &amp;&amp; authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // Si la solicitud no fue aprobada, se agrega el encabezado WWW-Authenticate a la respuesta
        
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add(&quot;WWW-Authenticate&quot;, string.Format(&quot;Basic realm=\&quot;{0}\&quot;&quot;, Realm));
            }
        }

        public void Dispose()
        {
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.Http.Headers;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Security.Principal;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebApiAuthentication.Modules&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BasicAuthHttpModule&nbsp;:&nbsp;IHttpModule&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Realm&nbsp;=&nbsp;<span class="cs__string">&quot;WebAPI&nbsp;Authentication&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Init(HttpApplication&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Se&nbsp;registran&nbsp;los&nbsp;manejadores&nbsp;de&nbsp;los&nbsp;eventos</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.AuthenticateRequest&nbsp;&#43;=&nbsp;OnApplicationAuthenticateRequest;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.EndRequest&nbsp;&#43;=&nbsp;OnApplicationEndRequest;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetPrincipal(IPrincipal&nbsp;principal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.CurrentPrincipal&nbsp;=&nbsp;principal;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HttpContext.Current&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.User&nbsp;=&nbsp;principal;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;AuthenticateUser(<span class="cs__keyword">string</span>&nbsp;credentials)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;encoding&nbsp;=&nbsp;Encoding.GetEncoding(<span class="cs__string">&quot;iso-8859-1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;credentials&nbsp;=&nbsp;encoding.GetString(Convert.FromBase64String(credentials));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;credentialsArray&nbsp;=&nbsp;credentials.Split(<span class="cs__string">':'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;username&nbsp;=&nbsp;credentialsArray[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;password&nbsp;=&nbsp;credentialsArray[<span class="cs__number">1</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;Aqu&iacute;&nbsp;se&nbsp;validan&nbsp;las&nbsp;credenciales&nbsp;o&nbsp;el&nbsp;token&nbsp;enviado&nbsp;en&nbsp;el&nbsp;encabezado&nbsp;de&nbsp;la&nbsp;solicitud&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!(username&nbsp;==&nbsp;<span class="cs__string">&quot;test&quot;</span>&nbsp;&amp;&amp;&nbsp;password&nbsp;==&nbsp;<span class="cs__string">&quot;test&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;identity&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;GenericIdentity(username);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetPrincipal(<span class="cs__keyword">new</span>&nbsp;GenericPrincipal(identity,&nbsp;<span class="cs__keyword">null</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnApplicationAuthenticateRequest(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;request&nbsp;=&nbsp;HttpContext.Current.Request;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;authHeader&nbsp;=&nbsp;request.Headers[<span class="cs__string">&quot;Authorization&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(authHeader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;authHeaderVal&nbsp;=&nbsp;AuthenticationHeaderValue.Parse(authHeader);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Se&nbsp;valida&nbsp;si&nbsp;el&nbsp;esquema&nbsp;de&nbsp;autenticaci&oacute;n&nbsp;es&nbsp;b&aacute;sico&nbsp;(Basic&nbsp;Authentication)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(authHeaderVal.Scheme.Equals(<span class="cs__string">&quot;basic&quot;</span>,&nbsp;StringComparison.OrdinalIgnoreCase)&nbsp;&amp;&amp;&nbsp;authHeaderVal.Parameter&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AuthenticateUser(authHeaderVal.Parameter);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Si&nbsp;la&nbsp;solicitud&nbsp;no&nbsp;fue&nbsp;aprobada,&nbsp;se&nbsp;agrega&nbsp;el&nbsp;encabezado&nbsp;WWW-Authenticate&nbsp;a&nbsp;la&nbsp;respuesta</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnApplicationEndRequest(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;HttpContext.Current.Response;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(response.StatusCode&nbsp;==&nbsp;<span class="cs__number">401</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Add(<span class="cs__string">&quot;WWW-Authenticate&quot;</span>,&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Basic&nbsp;realm=\&quot;{0}\&quot;&quot;</span>,&nbsp;Realm));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Para este caso en particular estamos usando una autenticaci&oacute;n &ldquo;Hard Coded&rdquo;, ya que estamos comparando tanto el usuario como la contrase&ntilde;a contra la palabra &ldquo;test&rdquo;, en un escenario real esta
 secci&oacute;n de c&oacute;digo debe ser reemplazada por una l&oacute;gica que permita validar directamente contra un sistema de autenticaci&oacute;n o de usuario (ejemplo tabla de usuarios autorizados en una base de datos vinculada al sistema)</div>
<p class="p1">Esta clase debemos agregarla al flujo de nuestro archivo de configuraci&oacute;n Web.Config en la secci&oacute;n &ldquo;modules&rdquo; el cual se ubica en la etiqueta &ldquo;&lt;system.webServer&gt;&rdquo;, tener especial cuidado con el NameSpace
 que se utilice en la propiedad &ldquo;Type&rdquo;:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;system.webServer&gt;
    &lt;modules&gt;
      &lt;add name=&quot;BasicAuthHttpModule&quot; type=&quot;WebApiAuthentication.Modules.BasicAuthHttpModule&quot; /&gt;
    &lt;/modules&gt;
&lt;/system.webServer&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;system</span>.webServer<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;modules</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;BasicAuthHttpModule&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;WebApiAuthentication.Modules.BasicAuthHttpModule&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/modules&gt;</span>&nbsp;
&lt;/system.webServer&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Por &uacute;ltimo debemos indicar cuales de nuestros m&eacute;todos o en su defecto si todo un controlador WebApi debe aplicar nuestra l&oacute;gica de autenticaci&oacute;n b&aacute;sica, este &uacute;ltimo punto es tan simple como
 agregar el adorno &ldquo;<span class="s6">[</span><span class="s7">Authorize</span><span class="s6">]&rdquo;
</span>a nuestros m&eacute;todos o controladores:</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiAuthentication.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(&quot;Hola &quot;);
        }

    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Http;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebApiAuthentication.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Authorize]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ValuesController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IHttpActionResult&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Ok(<span class="cs__string">&quot;Hola&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>Muy bien tenemos nuestro ejemplo listo, al iniciar el proyecto e intentar consumir nuestra API, el navegador solicitar&aacute; credenciales autenticaci&oacute;n:</p>
<p class="p2"><img id="138179" src="138179-2015-05-25_1652.png" alt="" width="376" height="301"></p>
<p class="p1">En este punto podemos dar las credenciales de acceso, sin embargo, si deseamos que siempre se acceda a la API sin digitar las credenciales, debemos agregar en el encabezado de la solicitud la propiedad &ldquo;Authorization&rdquo;, en el cual
 construiremos la cadena con el usuario y clave correspondientes:</p>
<p class="p2"><img id="138180" src="138180-2015-05-25_1655.png" alt="" width="809" height="330"></p>
<p class="p3">&nbsp;</p>
<p class="p2">Al realizar nuevamente la solicitud, veremos que nuestra API devuelve sin inconvenientes los resultados del m&eacute;todo:</p>
<p class="p2"><img id="138181" src="138181-2015-05-25_1656.png" alt="" width="367" height="421"></p>
<p>&nbsp;</p>
<div class="scriptcode"><span style="font-size:2em">Archivos de c&oacute;digo fuente</span></div>
<ul>
<li><em>ValuesController.cs - Controlador WebApi con el adorno de autenticaci&oacute;n.</em>
</li><li><em><em>BasicAuthHttpModule.cs - M&oacute;dulo encargado de interceptar las solicitudes y validar el acceso a los m&eacute;todos de la API.</em></em>
</li></ul>
<h1>M&aacute;s Informaci&oacute;n</h1>
<p><em>Para m&aacute;s informaci&oacute;n pueden contactarme por medio de la plataforma, mis redes sociales o mi blog
<a href="http://www.yovento.com" target="_blank">http://www.yovento.com</a></em></p>
