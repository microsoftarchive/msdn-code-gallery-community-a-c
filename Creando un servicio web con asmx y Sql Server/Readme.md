# Creando un servicio web con asmx y Sql Server
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- IIS
- XML
- ASMX web services
- C# Language
- ASP.NET 4.5
- Visual Studio 2012
## Topics
- Consuming Web Services
## Updated
- 10/31/2014
## Description

<h1>Introducci&oacute;n</h1>
<p>Esta vez vamos a mostrar informaci&oacute;n de la base de datos de Sql Server en un Web References.</p>
<p><span><span style="white-space:pre">&nbsp;</span><em>&quot;Desde la versi&oacute;n .NET Framework 1.1 hasta la versi&oacute;n 2.x, para crear aplicaciones SOA, Microsoft ofrece el f<span style="white-space:pre">
</span>ramework ASMX. Este framework simplifica la creaci&oacute;n tanto de los servicios web como de sus clientes. Los
<span style="white-space:pre">&nbsp;</span>servicios web creados a trav&eacute;s de esta tecnolog&iacute;a son invocados exclusivamente a trav&eacute;s del protocolo HTTP. Es
<span style="white-space:pre">&nbsp;</span>por eso que son conocidos como&nbsp;</em></span><em>Web References.</em></p>
<p><em><span style="white-space:pre">&nbsp;</span>Al crear un cliente de servicio web utilizando Web Reference, estamos utilizando por debajo la
<span style="white-space:pre">&nbsp;</span>herramienta&nbsp;Wsdl.exe&nbsp;proporcionada por Microsoft.&quot;</em></p>
<p><span style="white-space:pre">&nbsp;</span>by&nbsp;<a title="Generando clientes de servicios web JAX-WS desde .NET" href="https://eduvitoriatecnicomio.wordpress.com/2013/02/08/generando-clientes-de-servicios-web-jax-ws-desde-net/" target="_blank">eduvitoriatecnicomio</a></p>
<p><em><span><br>
</span></em></p>
<h1><span>Construyendo el ejemplo</span></h1>
<p>Para empezar, como queremos publicar en nuestro IIS local la aplicaci&oacute;n, necesitamos abrir visual studio como administrador.</p>
<p><img id="127943" src="127943-1.png" alt="" width="380" height="259"></p>
<p>&nbsp;</p>
<p><span>Abrimos una aplicaci&oacute;n vac&iacute;a de&nbsp;</span><span class="skimlinks-unlinked">ASP.NET</span></p>
<p><span class="skimlinks-unlinked"><img id="127944" src="127944-2.png" alt="" width="700" height="503"></span></p>
<p>&nbsp;</p>
<p><span class="skimlinks-unlinked"><span>Damos click derecho al proyecto y agregamos un nuevo elemento de tipo Servicio Web</span></span></p>
<p><span class="skimlinks-unlinked"><span><img id="127945" src="127945-3.png" alt="" width="664" height="574"></span></span></p>
<p>&nbsp;</p>
<p><span class="skimlinks-unlinked"><span><span>Y nos va a aparecer el m&eacute;todo hola mundo de prueba el cual, si nosotros queremos, podemos probar.</span></span></span></p>
<p><span class="skimlinks-unlinked"><span><span>&nbsp;</span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// &lt;summary&gt;
    /// Descripci&oacute;n breve de WebServiceEmployees
    /// &lt;/summary&gt;
    [WebService(Namespace = &quot;http://tempuri.org/&quot;)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la l&iacute;nea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEmployees : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return &quot;Hola a todos&quot;;
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Services;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebApplication1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Descripci&oacute;n&nbsp;breve&nbsp;de&nbsp;WebServiceEmployees</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebService(Namespace&nbsp;=&nbsp;<span class="cs__string">&quot;http://tempuri.org/&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebServiceBinding(ConformsTo&nbsp;=&nbsp;WsiProfiles.BasicProfile1_1)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[System.ComponentModel.ToolboxItem(<span class="cs__keyword">false</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Para&nbsp;permitir&nbsp;que&nbsp;se&nbsp;llame&nbsp;a&nbsp;este&nbsp;servicio&nbsp;web&nbsp;desde&nbsp;un&nbsp;script,&nbsp;usando&nbsp;ASP.NET&nbsp;AJAX,&nbsp;quite&nbsp;la&nbsp;marca&nbsp;de&nbsp;comentario&nbsp;de&nbsp;la&nbsp;l&iacute;nea&nbsp;siguiente.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;[System.Web.Script.Services.ScriptService]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WebServiceEmployees&nbsp;:&nbsp;System.Web.Services.WebService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[WebMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;HelloWorld()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Hola&nbsp;a&nbsp;todos&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span>Como nos conectaremos a una base de datos, vamos a crear una clase que nos servir&aacute; de modelo para obtener los datos en cuesti&oacute;n.</span></p>
<p><span><img id="127946" src="127946-4.png" alt="" width="656" height="579"></span></p>
<p>&nbsp;</p>
<p><span><span>Ahora lo que tenemos que hacer es agregar nuestra cadena de conexi&oacute;n de nuestro archivo de configuraci&oacute;n.</span></span></p>
<p><span><span><img id="127947" src="127947-5.png" alt="" width="263" height="163"></span></span></p>
<p>&nbsp;</p>
<p><span><span><span>Y agregamos la linea correspondiente para nuestra conexi&oacute;n. Si tenemos duda de como hacerlo aqu&iacute; les dejo un&nbsp;</span><a title="connectionstrings" href="http://www.connectionstrings.com/store-connection-string-in-webconfig/" target="_blank">link</a><span>.</span></span></span></p>
<p><span><span><span>&nbsp;</span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">  &lt;connectionStrings&gt;
    &lt;add name=&quot;connectionLocal&quot; 
         connectionString=&quot;server=ISRAEL-PC\SQLEXPRESS;database=Northwind;uid=sa;password=Pa$$w0rd;&quot; /&gt;
  &lt;/connectionStrings&gt;</pre>
<div class="preview">
<pre class="xml">&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;connectionLocal&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;server=ISRAEL-PC\SQLEXPRESS;database=Northwind;uid=sa;password=Pa$$w0rd;&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span>Y el archivo completo nos quedar&iacute;a as&iacute;</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;configuration&gt;
    &lt;system.web&gt;
      &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.5&quot; /&gt;
      &lt;httpRuntime targetFramework=&quot;4.5&quot; /&gt;
    &lt;/system.web&gt;
  
  &lt;connectionStrings&gt;
    &lt;add name=&quot;connectionLocal&quot; 
         connectionString=&quot;server=ISRAEL-PC\SQLEXPRESS;database=Northwind;uid=sa;password=Pa$$w0rd;&quot; /&gt;
  &lt;/connectionStrings&gt;
  
&lt;/configuration&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;configuration</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;system</span>.web<span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;compilation</span><span class="xml__attr_name">debug</span>=<span class="xml__attr_value">&quot;true&quot;</span><span class="xml__attr_name">targetFramework</span>=<span class="xml__attr_value">&quot;4.5&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;httpRuntime</span><span class="xml__attr_name">targetFramework</span>=<span class="xml__attr_value">&quot;4.5&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/system.web&gt;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;add</span><span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;connectionLocal&quot;</span><span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;server=ISRAEL-PC\SQLEXPRESS;database=Northwind;uid=sa;password=Pa$$w0rd;&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/connectionStrings&gt;</span><span class="xml__tag_end">&lt;/configuration&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Ahora es necesario que nuestra clase que nos servir&aacute; como modelo exponga un m&eacute;todo que nos devuelva la consulta en cuesti&oacute;n, que en nuestro caso queremos traer todos los empleados de la tabla de ejemplo de&nbsp;Northwind.</p>
<p><span>Nota:&nbsp;</span>La clase debe ser publica.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public DataSet getEmployees()
        {
            //EL DataSet REPRESENTA UNA MEMORIA CACH&Eacute; DE DATOS EN MEMORIA
            DataSet dataTable = new DataSet();

            //A TRAVEZ DE LA CADENA DE CONEXION DEL WEBCONFIG Y LA OBTENEMOS 
            //CON EL CONFIGURATIONMANAGER
            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings[&quot;connectionLocal&quot;]
                .ConnectionString))
            {
                //SE ABRE LA CONEXION
                con.Open();

                //SE UTILIZA PARA LLENAR UN DATASET CON LOS ELEMENTOS NECESARIOS 
                //COMO UNA CONEXION DE BASE DE DATOS
                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(
                    &quot;SELECT * FROM Employees&quot;, con))
                {
                    //SE LLENA EL DATASET CON LOS DATOS OBTENIDOS EN EL SQLADAPTER
                    sqlAdapter.Fill(dataTable);
                }
            }
            //REGRESAMOS LOS DATOS COMO DATOS EN MEMORIA
            return dataTable;
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;DataSet&nbsp;getEmployees()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//EL&nbsp;DataSet&nbsp;REPRESENTA&nbsp;UNA&nbsp;MEMORIA&nbsp;CACH&Eacute;&nbsp;DE&nbsp;DATOS&nbsp;EN&nbsp;MEMORIA</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;dataTable&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataSet();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//A&nbsp;TRAVEZ&nbsp;DE&nbsp;LA&nbsp;CADENA&nbsp;DE&nbsp;CONEXION&nbsp;DEL&nbsp;WEBCONFIG&nbsp;Y&nbsp;LA&nbsp;OBTENEMOS&nbsp;</span><span class="cs__com">//CON&nbsp;EL&nbsp;CONFIGURATIONMANAGER</span><span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;connectionLocal&quot;</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ConnectionString))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//SE&nbsp;ABRE&nbsp;LA&nbsp;CONEXION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;con.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//SE&nbsp;UTILIZA&nbsp;PARA&nbsp;LLENAR&nbsp;UN&nbsp;DATASET&nbsp;CON&nbsp;LOS&nbsp;ELEMENTOS&nbsp;NECESARIOS&nbsp;</span><span class="cs__com">//COMO&nbsp;UNA&nbsp;CONEXION&nbsp;DE&nbsp;BASE&nbsp;DE&nbsp;DATOS</span><span class="cs__keyword">using</span>&nbsp;(SqlDataAdapter&nbsp;sqlAdapter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlDataAdapter(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Employees&quot;</span>,&nbsp;con))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//SE&nbsp;LLENA&nbsp;EL&nbsp;DATASET&nbsp;CON&nbsp;LOS&nbsp;DATOS&nbsp;OBTENIDOS&nbsp;EN&nbsp;EL&nbsp;SQLADAPTER</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlAdapter.Fill(dataTable);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//REGRESAMOS&nbsp;LOS&nbsp;DATOS&nbsp;COMO&nbsp;DATOS&nbsp;EN&nbsp;MEMORIA</span><span class="cs__keyword">return</span>&nbsp;dataTable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>Y los usings a agregar ser&iacute;an los siguientes</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Configuration;
using System.Data;
using System.Data.SqlClient;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Configuration;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.SqlClient;</pre>
</div>
</div>
</div>
<br>
</span></div>
<p>&nbsp;</p>
<p>Una vez creada la clase correctamente, nos vamos al&nbsp;<em>cs</em>&nbsp;del servicio web. y quitamos el m&eacute;todo de &ldquo;Hola mundo&rdquo; y lo remplazamos por lo siguiente. Si hace falta una referencia la agregamos.</p>
<p>Creamos un nuevo objeto de nuestra clase anterior.&nbsp;<span>Y nos quedar&iacute;a de la siguiente manera, llamando al m&eacute;todo que nos devuelve el&nbsp;</span><em>dataset&nbsp;</em><span>con los datos llenos.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">DataEmployeesModel dataEmployess = new DataEmployeesModel();
        [WebMethod]
        public DataSet getEmployees()
        {
            return dataEmployess.getEmployees();
        }</pre>
<div class="preview">
<pre class="csharp">DataEmployeesModel&nbsp;dataEmployess&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataEmployeesModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[WebMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataSet&nbsp;getEmployees()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;dataEmployess.getEmployees();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>Cabe mencionar que para que el&nbsp;</span><em>dataset</em><span>&nbsp;se pueda interpretar como datos en xml necesitamos agregar la referencia de&nbsp;</span><em>Serialization</em><span>.</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Xml.Serialization;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Xml.Serialization;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<p><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></p>
<p><span>Ejecutamos.</span></p>
<p><span><img id="127948" src="127948-6.png" alt="" width="206" height="31"></span></p>
<p>&nbsp;</p>
<p><span><span>Y nos debe salir de la siguiente forma</span></span></p>
<p><span><span><img id="127949" src="127949-7.png" alt="" width="700" height="157"></span></span></p>
<p>&nbsp;</p>
<p><span><span><span>Abrimos el m&eacute;todo</span></span></span></p>
<p><span><span><span><img id="127950" src="127950-8.png" alt=""></span></span></span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span><span><span><span>Y le damos en &ldquo;Invoke&rdquo; y nos debe aparecer esto</span></span></span></span></p>
<p><span><span><span><span><img id="127951" src="127951-9.png" alt=""></span></span></span></span></p>
<p>&nbsp;</p>
<p><span><span><span><span><span>Y para esto ya quedo formado nuestro servicio en asmx.</span></span></span></span></span></p>
