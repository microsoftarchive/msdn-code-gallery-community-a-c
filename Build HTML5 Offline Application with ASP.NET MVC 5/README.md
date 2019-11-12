# Build HTML5 Offline Application with ASP.NET MVC 5
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C# Language
- HTML5
- ASP.NET MVC 5
## Topics
- C#
- ASP.NET MVC
- HTML5
- MVC Samples
- Jquery Ajax
- HTML5/JavaScript
- ASP.NET MVC 5
## Updated
- 09/28/2018
## Description

<p><span title="HTML5 ASP.Net MVC5 Offline application

"></span></p>
<h1>HTML5 ASP.Net MVC5 Desconectado aplicaci&oacute;n</h1>
<p><br>
<br>
<span title="HTML5 MVC5 Offline application which Synchronize offline data to server database when internet connection is live and stores data on client side when internet is offline.

">HTML5 MVC5 Desconectado aplicaci&oacute;n que Sincronizar sin conexi&oacute;n
 de datos a la base de datos del servidor cuando la conexi&oacute;n a Internet es datos en tiempo real y almacena en el lado cliente cuando Internet no est&aacute; en l&iacute;nea.<br>
<br>
</span><span title="Building the Sample

">Generar el ejemplo<br>
<br>
</span><span title="Use Visual Studio 2013, MVC5 to build the application

">Utilice Visual Studio 2013, MVC5 para construir la aplicaci&oacute;n<br>
<br>
</span><span title="Description

">&nbsp;</span></p>
<h1>Descripci&oacute;n</h1>
<p><br>
<br>
<span title="This Build HTML5 MVC5 Offline Application with Application Cache, Web Storage and ASP.NET MVC

">Este Construir aplicaci&oacute;n HTML5 MVC5 Desconectado con memoria cach&eacute; de aplicaciones, almacenamiento Web y ASP.NET MVC<br>
<br>
</span><span title="This give developers capacity to develops MVC5 applications which can function offline as well online in HTML5.

">Esta capacidad de dar a los desarrolladores desarrolla aplicaciones MVC5 que pueden funcionar fuera de l&iacute;nea tambi&eacute;n
 en l&iacute;nea en HTML5.<br>
<br>
</span><span title="Sample uses ASP.Net MVC 5 and C# as coding language with Entity Framework and Javsacript,Jquery code to do client side saving and HTML5 web storage.

">Muestra utiliza ASP.Net MVC 5 y C # como lenguaje de codificaci&oacute;n con Entity Framework
 y Javsacript, c&oacute;digo jQuery para hacer cliente de ahorro lado y almacenamiento web HTML5.<br>
<br>
</span><span title="Sample give developers a starting point for HTML5 offline applications for different platforms.

">Muestra de dar a los desarrolladores un punto de partida para aplicaciones fuera de l&iacute;nea HTML5 para diferentes plataformas.<br>
<br>
</span><span title="This is a HTML5 MVC5 Offline application which Synchronize offline data to server database when internet connection is live and stores data on client side when internet is offline.

&nbsp;&nbsp;

">Esta es una aplicaci&oacute;n HTML5 MVC5 Desconectado
 que sincronizar datos sin conexi&oacute;n a la base de datos del servidor cuando la conexi&oacute;n a Internet es datos en tiempo real y almacena en el lado cliente cuando Internet no est&aacute; en l&iacute;nea.<br>
<br>
&nbsp;&nbsp;<br>
<br>
</span><span title="Sample uses SQL server 2012 express as database.">Muestra utiliza SQL Server 2012 Express como base de datos.
</span><span title="AlwaysNote.sql is attached which can be used to generate database.

">AlwaysNote.sql est&aacute; unido que puede ser utilizado para generar la base de datos.<br>
<br>
</span><span title="Please setup connectionstring inside web.config file to connect to database.



">Por favor configuraci&oacute;n connectionstring interior archivo web.config para conectarse a la base de datos.<br>
<br>
<br>
<br>
</span><span title="C#

">C#<br>
<br>
</span><span title="Edit|Remove

">Editar | Eliminar<br>
<br>
</span><span title="namespace AlwaysNote.Controllers
">AlwaysNote.Controllers de espacio de nombres<br>
</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public class CustomerInputModel
&nbsp;&nbsp;&nbsp;&nbsp;">public class CustomerInputModel<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public string Name { get;">public string Nombre {get;
</span><span title="set;">conjunto; </span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public string Note { get;">public string Nota {get;
</span><span title="set;">conjunto; </span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public int ID { get;">int Id p&uacute;blica {get;
</span><span title="set;">conjunto; </span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public string Key { get;">Key public string {get;
</span><span title="set;">conjunto; </span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public class CustomerViewModel
&nbsp;&nbsp;&nbsp;&nbsp;">public class CustomerViewModel<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public string ID { get;">ID de cadena p&uacute;blica {get;
</span><span title="set;">conjunto; </span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public string Key { get;">Key public string {get;
</span><span title="set;">conjunto; </span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public class CustomerController : Controller
&nbsp;&nbsp;&nbsp;&nbsp;">CustomerController clase p&uacute;blica: Controlador<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public ActionResult Index()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">&Iacute;ndice ActionResult p&uacute;blica ()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="return View();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">Regresar ver ();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="public ActionResult Save(CustomerInputModel model)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">p&uacute;blica ActionResult Guardar (modelo CustomerInputModel)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="CustomerRepository repository =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">Repositorio CustomerRepository =<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="new CustomerRepository();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">nueva CustomerRepository ();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="int id = 0;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">int id = 0;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="if (model.ID &gt; 0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">si (model.ID&gt; 0)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="id = model.ID;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">id = model.ID;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="repository.Update(id, model.Name, model.Note);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">repository.Update (id, model.Name, model.Note);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">m&aacute;s<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="id = repository.Add(model.Name, model.Note);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">id = repository.Add (model.Name, model.Note);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="CustomerViewModel vm = new CustomerViewModel();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">CustomerViewModel vm = new CustomerViewModel ();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="vm.ID = id.ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">vm.ID id.ToString = ();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="vm.Key = model.Key;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">vm.Key = model.Key;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="return Json(vm);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">volver JSON (vm);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;">}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;</span><span title="}
">}<br>
</span><span title="}

&nbsp;




">}<br>
<br>
&nbsp;<br>
<br>
<br>
<br>
<br>
</span><span title="Source Code Files
">C&oacute;digo Fuente Archivos<br>
</span><span title="•source code file name #1 - VS 2013 Solution files with MVC5 source code file name
">&bull; Fuente de nombre de archivo de c&oacute;digo # 1 - VS 2013 archivos de soluci&oacute;n con fuente MVC5 nombre de archivo de c&oacute;digo<br>
</span><span title="•#2 - Database script to create database
">&bull; # 2 - gui&oacute;n de base de datos para crear la base de datos<br>
</span><span title="•For more information : http://blog.nucleon.in/build-html5-offline-application-with-asp-net-mvc-5/">&bull; Para m&aacute;s informaci&oacute;n: http://blog.nucleon.in/build-html5-offline-application-with-asp-net-mvc-5/</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
