# Control TextBox con botón
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Controls
- Windows Forms
- custom controls
- Control
- extended controls
## Topics
- custom controls
- Windows Form Controls
## Updated
- 04/04/2015
## Description

<div>Un interfaz que nos encontramos con mucha frecuencia es el cuadro de texto con un bot&oacute;n asociado. Se utiliza principalmente en pantallas de b&uacute;squedas, pero tambi&eacute;n nos lo podemos encontrar para cubrir otras necesidades: acceso a interfaces
 de entrada de datos (calendario, calculadora, ...), a informaci&oacute;n de ayuda, etc.</div>
<div>Por desgracia el framework de .NET no incluye un control con esta funcionalidad. Podemos suplir esta carencia cre&aacute;ndonos un control de usuario con un TextBox y un Button, pero vamos a ver c&oacute;mo podemos modificar el TextBox para a&ntilde;adirle
 esta funcionalidad, creando un nuevo control que herede del control TextBox.</div>
<div>&nbsp;</div>
<div>Vamos a crear un nuevo control TextBoxButton que se visualizar&aacute; como un control TextBox normal con un bot&oacute;n situado en la parte derecha del control.</div>
<div>El nuevo control tendr&aacute; todas las propiedades, m&eacute;todos y eventos del control TextBox est&aacute;ndar y adem&aacute;s:</div>
<ul>
<li>Una propiedad ButtonImage que permita indicar la imagen a mostrar en el bot&oacute;n.
</li><li>Un evento ButtonClick que se producir&aacute; cuando se realice click sobre el bot&oacute;n.
</li></ul>
<div>Para crear el control voy a crear un nuevo proyecto TextBoxButtonControl en Visual Studio utilizando la plantilla para bibliotecas de clases.</div>
<div style="">Eliminamos la clase<span class="Apple-converted-space">&nbsp;</span><em>Class1<span class="Apple-converted-space">&nbsp;</span></em>que genera el Visual Studio por defecto y creamos una nueva clase<span class="Apple-converted-space">&nbsp;</span><em>TextBoxButton</em>.</div>
<div style="">&nbsp;</div>
<div style="">Para que nuestro control tenga toda la funcionalidad de un<span class="Apple-converted-space">&nbsp;</span><em>TextBox<span class="Apple-converted-space">&nbsp;</span></em>cl&aacute;sico vamos a hacer que nuestra clase herede de la clase<span class="Apple-converted-space">&nbsp;</span><em>TextBox<span class="Apple-converted-space">&nbsp;</span></em>de<span class="Apple-converted-space">&nbsp;</span><em><a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a></em>.
 Para ello necesitamos agregar la referencia a esta librer&iacute;a. En el men&uacute;<span class="Apple-converted-space">&nbsp;</span><em>Proyecto<span class="Apple-converted-space">&nbsp;</span></em>vamos a la opci&oacute;n<span class="Apple-converted-space">&nbsp;</span><em>Agregar
 referencia</em>, desplegamos<span class="Apple-converted-space">&nbsp;</span><em>Ensamblados<span class="Apple-converted-space">&nbsp;</span></em>y vamos a la opci&oacute;n<span class="Apple-converted-space">&nbsp;</span><em>Framework</em>. En la lista
 de ensamblados seleccionamos<span class="Apple-converted-space">&nbsp;</span><em><a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a></em><span class="Apple-converted-space">&nbsp;</span>y pulsamos<span class="Apple-converted-space">&nbsp;</span><em>Aceptar</em>.</div>
<div style="">&nbsp;</div>
<div style="">Hacemos que nuestra clase TextBoxButton herede de <a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Windows.Forms.TextBox.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.TextBox">System.Windows.Forms.TextBox</a>, y con esto ya tendr&iacute;amos la base de nuestro propio control con toda la funcionalidad del TextBox cl&aacute;sico.</div>
<div style="">&nbsp;</div>
<div style="">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;TextBoxButtonControl&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;TextBoxButton:&nbsp;TextBox&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Para poder probar nuestro control vamos a agregar un nuevo proyecto PruebaControl a la soluci&oacute;n utilizando la plantilla Aplicaci&oacute;n de Windows Forms.</div>
</div>
<div>Para poder utilizar el nuevo control desde el proyecto de pruebas tendremos que a&ntilde;adir una referencia al proyecto TextBoxButtonControl. En el men&uacute; Proyecto vamos a la opci&oacute;n Agregar referencia, desplegamos Soluci&oacute;n y vamos a
 la opci&oacute;n Proyectos. Seleccionamos el proyecto TextBoxButtonControl y pulsamos Aceptar.</div>
<div>Si abrimos en modo dise&ntilde;o el formulario Form1 que Visual Studio ha creado autom&aacute;ticamente al crear el proyecto PruebaControl, veremos que en la ventana Cuadro de herramientas aparece nuestro nuevo control TextBoxButton.</div>
<div>&nbsp;</div>
<div>Si no puedes ver el control, compila la Soluci&oacute;n (Men&uacute; Compilar &gt; Compilar Soluci&oacute;n) para que aparezca.</div>
<div>A continuaci&oacute;n arrastramos el control al &aacute;rea de dise&ntilde;o del formulario y veremos que, como esper&aacute;bamos, la apariencia es la misma que la de un control TextBox y, mirando la ventana Propiedades, que ha heredado todas las propiedades
 y eventos de &eacute;ste.</div>
<div>Establecemos el proyecto PruebaControl como proyecto de inicio (Men&uacute; Proyecto &gt;&nbsp; Establecer como proyecto de inicio) y arrancamos la aplicaci&oacute;n para comprobar que el funcionamiento de nuestro TextBoxButton es id&eacute;ntico al de
 cualquier otro TextBox.</div>
<div>Para a&ntilde;adir el bot&oacute;n voy a crear un control Button en el constructor de la clase TextBoxButton y lo a&ntilde;adir&eacute; a la colecci&oacute;n Controls de &eacute;ste.</div>
<div>Tambi&eacute;n voy crear&eacute; un m&eacute;todo PosicionarBoton que se encargar&aacute; de establecer el ancho y alto del bot&oacute;n al valor de la altura del TextBoxButton y de alinearlo a la derecha del TextBox. Llamar&eacute; a este m&eacute;todo
 en la creaci&oacute;n del control y cada vez que se genere el evento Resize indicando que el control ha cambiado de tama&ntilde;o.</div>
<div>Para poder utilizar las clases Size y Point deberemos a&ntilde;adir una referencia al ensamblado <a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a> de la misma forma que lo hicimos con System.Windows.Forms.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;TextBoxButtonControl&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;TextBoxButton:&nbsp;TextBox&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">readonly</span>&nbsp;Button&nbsp;_button;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;TextBoxButton()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Button&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cursor&nbsp;=&nbsp;Cursors.Default,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TabStop&nbsp;=&nbsp;<span class="cs__keyword">false</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Controls.Add(_button);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PosicionarBoton();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">override</span><span class="cs__keyword">void</span>&nbsp;OnResize(EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnResize(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PosicionarBoton();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;PosicionarBoton()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button.Size&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(<span class="cs__keyword">this</span>.ClientSize.Height,&nbsp;<span class="cs__keyword">this</span>.ClientSize.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__keyword">this</span>.ClientSize.Width&nbsp;-&nbsp;_button.Width,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</div>
<div>Si compilamos el proyecto y vamos a nuestro formulario de prueba veremos que ya aparece el bot&oacute;n a la derecha de nuestro control. Si modificamos el tama&ntilde;o del control comprobaremos que el bot&oacute;n se redimensiona para ajustarse al tama&ntilde;o
 del contenedor y, si arrancamos el proyecto PruebaControl veremos c&oacute;mo se muestra correctamente en el formulario.</div>
<div>Sin embargo, si introducimos texto en el control, veremos que cuando el texto llega a la altura del bot&oacute;n el texto se sigue escribiendo debajo de &eacute;ste.</div>
<div>Por desgracia el Framework de .NET no nos proporciona herramientas para evitar este problema as&iacute; que tendremos que recurrir a la API de Windows. Para establecer los margenes de un control de edici&oacute;n deberemos enviar el mensaje EM_SETMARGINS.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;PosicionarBoton()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button.Size&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(<span class="cs__keyword">this</span>.ClientSize.Height,&nbsp;<span class="cs__keyword">this</span>.ClientSize.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__keyword">this</span>.ClientSize.Width&nbsp;-&nbsp;_button.Width,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(<span class="cs__keyword">this</span>.Handle,&nbsp;0xd3,&nbsp;(IntPtr)<span class="cs__number">2</span>,&nbsp;(IntPtr)(_button.Width&nbsp;&lt;&lt;&nbsp;<span class="cs__number">16</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[System.Runtime.InteropServices.DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">static</span><span class="cs__keyword">extern</span>&nbsp;IntPtr&nbsp;SendMessage(IntPtr&nbsp;hWnd,&nbsp;<span class="cs__keyword">int</span>&nbsp;msg,&nbsp;IntPtr&nbsp;wp,&nbsp;IntPtr&nbsp;lp);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Si arrancamos de nuevo nuestro formulario de prueba e introducimos texto en el control comprobaremos que el espacio de edici&oacute;n finaliza justo antes de llegar al bot&oacute;n.</div>
</div>
<div>Ya tenemos nuestro control de texto con bot&oacute;n incrustado, pero no tenemos forma de a&ntilde;adirle funcionalidad al bot&oacute;n ya que no podemos controlar cuando es pulsado por el usuario.</div>
<div>Para solucionarlo vamos a propagar el evento Click del bot&oacute;n a trav&eacute;s de un evento ButtonClick en el nuevo control. Para ello creamos el evento ButtonClick y lo configuramos de forma que, cuando se a&ntilde;ada un controlador al evento, se
 lo a&ntilde;adimos al evento Click del bot&oacute;n. Y cuando se elimine un controlador, lo eliminamos igualmente del evento Click del bot&oacute;n.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Category(<span class="cs__string">&quot;Action&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;EventHandler&nbsp;ButtonClick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;add&nbsp;{&nbsp;&nbsp;_button.Click&nbsp;&#43;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;remove&nbsp;{&nbsp;_button.Click&nbsp;-=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">He a&ntilde;adido un atributo Category al evento para que se muestre en la ventana de Propiedades del Visual Studio junto con el resto de eventos de la categor&iacute;a Acci&oacute;n.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">Si en el formulario de prueba a&ntilde;adimos un controlador para el evento podremos probar la nueva funcionalidad.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;textBoxButton1_ButtonClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Ha&nbsp;pulsado&nbsp;el&nbsp;bot&oacute;n&nbsp;del&nbsp;control&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p>Ya tenemos el control con la funcionalidad deseada. &Uacute;nicamente nos faltar&iacute;a mejorar la presentaci&oacute;n. Para ello a&ntilde;adir&eacute; una propiedad que permita al desarrollador especificar una imagen a mostrar en el bot&oacute;n e incluir&eacute;
 una imagen en el proyecto que se mostrar&aacute; por defecto en caso de que el desarrollador no indique ninguna.</p>
<p>Primero voy a a&ntilde;adir la imagen que mostrar&eacute; por defecto en el proyecto. Para ello abrimos las propiedades del proyecto (Men&uacute; Proyecto &gt; Propiedades de TextBoxButtonControl...) y seleccionamos la opci&oacute;n Recursos. Si nos aparece
 un mensaje indicando que no existe ning&uacute;n archivo de recursos para el proyecto, hacemos click en el enlace para generar uno. Seleccionamos Im&aacute;genes como tipo de recurso y Agregar archivo existente... en Agregar recurso.</p>
</div>
<span style="background-color:#ffffcc"><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1">La imagen&nbsp;ha sido creada originalmente
 por<span class="Apple-converted-space">&nbsp;</span></span><a title="Google" href="http://www.google.com/" style="">Google</a><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1"><span class="Apple-converted-space">&nbsp;</span>y
 descargada de<span class="Apple-converted-space">&nbsp;</span></span><a title="Flaticon" href="http://www.flaticon.com/" style="">www.flaticon.com</a><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1">.
 La imagen se encuentra bajo licencia<span class="Apple-converted-space">&nbsp;</span></span><a title="Creative Commons BY 3.0" href="http://creativecommons.org/licenses/by/3.0/" style="">CC BY 3.0</a><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1">.</span>&nbsp;</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Una vez a&ntilde;adida la imagen establecemos el nombre del recurso como &quot;ellipsis&quot;.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">A continuaci&oacute;n voy a modificar la inicializaci&oacute;n del bot&oacute;n para establecer la imagen por defecto.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Button&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cursor&nbsp;=&nbsp;Cursors.Default,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TabStop&nbsp;=&nbsp;<span class="cs__keyword">false</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundImage&nbsp;=&nbsp;Properties.Resources.ellipsis,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Zoom&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Si arrancamos la aplicaci&oacute;n podremos ver el efecto del cambio.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Ya s&oacute;lo falta darle al desarrollador la posibilidad de cambiar la imagen del bot&oacute;n. As&iacute; que voy a a&ntilde;adir al control una propiedad ButtonImage.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Image&nbsp;_buttonImage;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Category(<span class="cs__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="cs__string">&quot;Imagen&nbsp;del&nbsp;bot&oacute;n&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Image&nbsp;ButtonImage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_buttonImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_buttonImage&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_buttonImage&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button.BackgroundImage&nbsp;=&nbsp;Properties.Resources.ellipsis;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_button.BackgroundImage&nbsp;=&nbsp;_buttonImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">He creado una variable privada _buttonImage para almacenar la imagen elegida por el desarrollador. Si el desarrollador no establece ninguna imagen se utiliza la imagen por defecto.
<p>Si compilo y vuelvo al formulario de prueba podemos ver la nueva propiedad del control.</p>
</div>
</div>
</div>
<div class="endscriptcode">Para probar la nueva propiedad voy a asignarle a la propiedad ButtonImage una imagen con una lupa.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="background-color:#ffffcc"><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1">Imagen creada
 por&nbsp;</span><a title="SimpleIcon" href="http://www.simpleicon.com/" style="">SimpleIcon</a><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1"><span class="Apple-converted-space">&nbsp;</span>y
 descargada de&nbsp;</span><a title="Flaticon" href="http://www.flaticon.com/" style="">www.flaticon.com</a><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1"><span class="Apple-converted-space">&nbsp;</span>bajo
 licencia&nbsp;</span><a title="Creative Commons BY 3.0" href="http://creativecommons.org/licenses/by/3.0/" style="">CC BY 3.0</a><span style="color:#000000; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1">.</span></span></div>
</div>
<p><br>
Al arrancar la aplicaci&oacute;n podemos ver el efecto del cambio.</p>
<p>&nbsp;</p>
<p><img id="135819" src="135819-pruebabotonlupa.png" alt="" width="300" height="299"></p>
