# Atributos de validación Data Annotations multiidioma
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
- System.ComponentModel.DataAnnotations
## Topics
- Globalization and Localization
## Updated
- 04/29/2015
## Description

<h1>Introducci&oacute;n</h1>
<p>El espacio de nombres <a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> proporciona clases de atributos que se usan para definir los metadatos para ASP.NET MVC y los controles de ASP.NET.</p>
<p>Estos atributos nos permiten especificar las cadenas a utilizar en la interfaz de la aplicaci&oacute;n cuando se hace referencia al campo, se detectan errores de validaci&oacute;n, etc. Esto resulta muy &uacute;til para tener definidas estas cadenas en un
 &uacute;nico lugar de la aplicaci&oacute;n y que los mensajes al usuario sean uniformes a lo largo de toda nuestra aplicaci&oacute;n.</p>
<p>Sin embargo, en este mundo cada vez m&aacute;s globalizado, cada vez son menos las aplicaciones cuyo interfaz se define en un &uacute;nico idioma. Entonces, &iquest;c&oacute;mo utilizamos los atributos del namespace DataAnnotations de forma que nuestros
 textos se adapten al idioma del usuario?</p>
<p>En este ejemplo muestro diferentes alternativas para afrontar este problema.</p>
<h1><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></h1>
<p>En el ejemplo abordo 4 implementaciones diferentes de c&oacute;mo tratar el tema de los textos en los atributos del modelo.</p>
<p>Para cada una de las 4 soluciones se implementa una clase para el modelo y una acci&oacute;n diferente en el &uacute;nico controlador definido en la aplicaci&oacute;n.</p>
<p>&nbsp;</p>
<h2><span>Primera Soluci&oacute;n. Textos sin traducci&oacute;n.</span></h2>
<p>La primera soluci&oacute;n es la de no implementar ninguna soluci&oacute;n. Es decir introducir los textos directamente en los atributos y mostrarlos siempre en el mismo idioma independientemente de la cultura del usuario.</p>
<p>Este ejemplo se implementa a trav&eacute;s de la clase del modelo <em>Persona</em> y la acci&oacute;n
<em>Index</em> del <em>HomeController</em>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Persona:&nbsp;IPersona&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Debe&nbsp;introducir&nbsp;un&nbsp;nombre&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DisplayName(<span class="cs__string">&quot;Nombre&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Nombre&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DisplayName(<span class="cs__string">&quot;Apellido&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Apellido&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DisplayName(<span class="cs__string">&quot;Ciudad&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StringLength(<span class="cs__number">20</span>,&nbsp;MinimumLength=<span class="cs__number">4</span>,&nbsp;ErrorMessage=<span class="cs__string">&quot;El&nbsp;nombre&nbsp;de&nbsp;Ciudad&nbsp;debe&nbsp;tener&nbsp;una&nbsp;longitud&nbsp;entre&nbsp;4&nbsp;y&nbsp;20&nbsp;caracteres&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Ciudad&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DisplayName(<span class="cs__string">&quot;Correo&nbsp;electr&oacute;nico&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>Segunda Soluci&oacute;n. Utilizar archivos de recursos.</h2>
<p>La soluci&oacute;n ya implementada por ASP.NET: utilizar archivos de recursos.</p>
<p>Este ejemplo se implementa a trav&eacute;s de la clase del modelo <em>PersonaResource</em> y la acci&oacute;n
<em>Resource</em> del <em>HomeController</em>.&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PersonaResource:&nbsp;IPersona&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessageResourceName&nbsp;=&nbsp;<span class="cs__string">&quot;NombreObligatorio&quot;</span>,&nbsp;ErrorMessageResourceType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(Textos))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name=<span class="cs__string">&quot;Nombre&quot;</span>,&nbsp;ResourceType=<span class="cs__keyword">typeof</span>(Textos))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Nombre&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Apellido&quot;</span>,&nbsp;ResourceType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(Textos))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Apellido&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Ciudad&quot;</span>,&nbsp;ResourceType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(Textos))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StringLength(<span class="cs__number">20</span>,&nbsp;MinimumLength&nbsp;=&nbsp;<span class="cs__number">4</span>,&nbsp;ErrorMessageResourceName=<span class="cs__string">&quot;CiudadErrorLongitud&quot;</span>,&nbsp;ErrorMessageResourceType=<span class="cs__keyword">typeof</span>(Textos))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Ciudad&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Email&quot;</span>,&nbsp;ResourceType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(Textos))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;Tercera Soluci&oacute;n. Utilizar una plantilla de texto T4</h2>
<p>&nbsp;</p>
<p>En el tercer ejemplo creo una plantilla de texto T4 que genera una clase <em>TextosLoader</em> que reemplaza los archivos de recursos de forma que los textos pueden estar almacenados en cualquier origen de datos (en el ejemplo utilizo un
<em>DataTable</em> serializado en un fichero xml).</p>
<p>Este ejemplo se implementa a trav&eacute;s de la clase del modelo <em>PersonaBBDD</em> y la acci&oacute;n
<em>BBDD </em>del <em>HomeController</em>.</p>
<p>Este es el c&oacute;digo de la plantilla de texto:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&lt;#@&nbsp;template&nbsp;debug=<span class="cs__string">&quot;false&quot;</span>&nbsp;hostspecific=<span class="cs__string">&quot;true&quot;</span>&nbsp;language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;assembly&nbsp;name=<span class="cs__string">&quot;System.Core&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;assembly&nbsp;name=<span class="cs__string">&quot;System.Data&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;assembly&nbsp;name=<span class="cs__string">&quot;System.Xml&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;import&nbsp;<span class="cs__keyword">namespace</span>=<span class="cs__string">&quot;System.Linq&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;import&nbsp;<span class="cs__keyword">namespace</span>=<span class="cs__string">&quot;System.Text&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;import&nbsp;<span class="cs__keyword">namespace</span>=<span class="cs__string">&quot;System.Collections.Generic&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;import&nbsp;<span class="cs__keyword">namespace</span>=<span class="cs__string">&quot;System.Data&quot;</span>&nbsp;#&gt;&nbsp;
&lt;#@&nbsp;output&nbsp;extension=<span class="cs__string">&quot;.cs&quot;</span>&nbsp;#&gt;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;LocalizeDataAnnotations.Infrastructure&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">class</span>&nbsp;TextosLoader&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;#&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;rutaArchivo&nbsp;=&nbsp;Host.ResolveAssemblyReference(<span class="cs__string">&quot;$(ProjectDir)&quot;</span>)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;Content\\Textos.xml&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;tablaTextos&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tablaTextos.ReadXml(rutaArchivo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow[]&nbsp;textos&nbsp;=&nbsp;tablaTextos.Select(<span class="cs__string">&quot;Idioma='es'&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(DataRow&nbsp;row&nbsp;<span class="cs__keyword">in</span>&nbsp;textos)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine(String.Format(<span class="cs__string">&quot;\t\tpublic&nbsp;static&nbsp;string&nbsp;{0}&quot;</span>,&nbsp;row[<span class="cs__string">&quot;Id&quot;</span>]));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine(<span class="cs__string">&quot;\t\t{&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine(String.Format(<span class="cs__string">&quot;\t\t\tget&nbsp;{{&nbsp;return&nbsp;TextosBBDD.Recuperar(\&quot;{0}\&quot;);&nbsp;}}&quot;</span>,&nbsp;row[<span class="cs__string">&quot;Id&quot;</span>]));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine(<span class="cs__string">&quot;\t\t}&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;Cuarta Soluci&oacute;n. Atributos personalizados.</h2>
<div class="endscriptcode">En el &uacute;ltimo ejemplo creo atributos personalizados para evitar crear la clase accesoria de la plantilla de texto T4.</div>
<div class="endscriptcode">En los atributos sobreescribo las propiedades y m&eacute;todos que devuelven los textos para devolverlos a partir de un origen de datos diferentes.</div>
<p>&nbsp;</p>
<p>Este ejemplo se implementa a trav&eacute;s de la clase del modelo <em>PersonaCustomAttr</em> y la acci&oacute;n
<em>CustomAttr </em>del <em>HomeController</em>.</p>
<p>Por ejemplo creo el atributo <em>CustomRequiredAttribute </em>en el que se sobreescribe el m&eacute;todo
<em>FormatErrorMessage</em>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomRequiredAttribute:&nbsp;RequiredAttribute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FormatErrorMessage(<span class="cs__keyword">string</span>&nbsp;name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;errorMessage&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(<span class="cs__keyword">base</span>.ErrorMessageResourceName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;errorMessage&nbsp;=&nbsp;TextosBBDD.Recuperar(<span class="cs__keyword">base</span>.ErrorMessageResourceName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;errorMessage&nbsp;??&nbsp;<span class="cs__keyword">base</span>.FormatErrorMessage(name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<h1>M&aacute;s Informaci&oacute;n</h1>
<p>Se puede encontrar informaci&oacute;n m&aacute;s detallada del ejemplo en los siguientes art&iacute;culos:</p>
<p><a href="http://pildorasdotnet.blogspot.com.es/2015/03/aspnet-localizando-dataannotations-i.html" target="_blank">ASP.NET. Localizando Data Annotations (I) - Archivos de recursos</a></p>
<p><a href="http://pildorasdotnet.blogspot.com.es/2015/03/aspnet-localizando-dataannotations-ii.html" target="_blank">ASP.NET. Localizando Data Annotations (II) - Utilizar una plantilla T4 para conectar a cualquier origen</a></p>
<p><a href="http://pildorasdotnet.blogspot.com/2015/03/aspnet-localizando-data-annotations-y.html" target="_blank">ASP.NET. Localizando Data Annotations (y III) - Personalizar Atributos de Validaci&oacute;n</a></p>
