# Comunicación entre formularios Windows Forms
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Windows Forms
- VB.Net
- DataGridView
## Topics
- Windows Forms
## Updated
- 05/17/2016
## Description

<h1>Introducci&oacute;n</h1>
<p><em>Un escenario muy habitual es el de tener que pasar datos entre diferentes formularios.</em></p>
<p><em>En este ejemplo muestro c&oacute;mo hacerlo implementando una soluci&oacute;n para uno de esos escenarios m&aacute;s habituales: la creaci&oacute;n de un formulario para editar las filas de un DataGridView.</em></p>
<h1><span>Construyendo el ejemplo</span></h1>
<p><em>Para mostrar el funcionamiento he creado un proyecto Windows Forms con tres elementos:</em></p>
<p><em>- Una clase Person para encapsular los datos de cada una de las filas</em></p>
<p><em>- Un formulario principal con el DataGridView a editar y un bot&oacute;n para a&ntilde;adir nuevas filas</em></p>
<p><em>- Un formulario que permitir&aacute; la edici&oacute;n de las filas del DataGridView mediante controles est&aacute;ndar como TextBox o CheckBox.</em></p>
<p><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></p>
<p><em>Para poder establecer y recuperar la informaci&oacute;n del formuario de edici&oacute;n creo una propiedad CurrentPerson de tipo Person: &nbsp;&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;Person&nbsp;CurentPerson&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name=&nbsp;txtName.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Surname&nbsp;=&nbsp;txtSurname.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Active&nbsp;=&nbsp;chkActive.Checked&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtName.Text&nbsp;=&nbsp;<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">string</span>.Empty&nbsp;:&nbsp;<span class="cs__keyword">value</span>.Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtSurname.Text&nbsp;=&nbsp;<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">string</span>.Empty&nbsp;:&nbsp;<span class="cs__keyword">value</span>.Surname;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkActive.Checked&nbsp;=&nbsp;<span class="cs__keyword">value</span>&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;<span class="cs__keyword">value</span>.Active;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>As&iacute;, el formulario principal se encargar&aacute; de crear el formulario de edici&oacute;n y de asignarle a trav&eacute;s de esta propiedad CurrentPerson los valores iniciales de edici&oacute;n.</p>
<p>Al cerrarse &nbsp;el formulario devolviendo un DialogResut.OK el propio formulario principal se encarga de recuperar a trav&eacute;s de esta misma propiedad los valores editados y aplicarlos al DataGridView.</p>
<p>&nbsp;</p>
<h1><span>Archivos</span></h1>
<ul>
<li><em>MainForm.cs/MainForm.vb - formulario principal</em> </li><li><em><em>DialogForm.cs/DialogForm.vb - formulario de edici&oacute;n</em></em> </li><li><em><em>Person.cs/Person.vb - clase Person</em></em> </li></ul>
<h1>M&aacute;s informaci&oacute;n</h1>
<p><em>Para obtener una descripci&oacute;n m&aacute;s detallada puede consutar el art&iacute;culo:</em></p>
<p><em><br>
</em></p>
