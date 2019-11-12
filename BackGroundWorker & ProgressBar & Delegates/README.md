# BackGroundWorker & ProgressBar & Delegates
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- Visual Basic .NET
- VB.Net
## Topics
- threading
- Background thread
## Updated
- 06/02/2011
## Description

<h1>Introduction</h1>
<p><em>En este ejemplo abordo uno de los principales problemas que nos podemos encontrar al tratar de copiar un archivo pesado, enviar un correo con documentos adjuntos, carga de datos de una consulta sql compleja, entre otras, y es la congelaci&oacute;n de
 la aplicaci&oacute;n mientras se realiza un proceso, dando una mala imagen de la aplicaci&oacute;n cuando realmente es eficiente pero realmente a qui&eacute;n no le gusta que se le muestre un porcentaje del proceso, el tiempo es oro.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>No hay requerimientos especiales para trabajar con el proyecto<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>El proyecto resuelve el problema de la inevitable congelaci&oacute;n de las aplicaci&oacute;nes a la hora de realizar un proceso que requiera de un tiempo en ejecutarse, copiar un archivo, enviar un correo con Attachments, una carga de datos compleja
 entre otras funciones, gracias al control <a href="http://msdn.microsoft.com/es-es/library/c8dcext2%28v=VS.80%29.aspx" target="_blank">
BackGroundWorker</a>.</em></p>
<p><em>Este control permite que el formulario o control ejecute operaciones de forma as&iacute;ncrona (en segundo plano).<br>
</em></p>
<p><em>Ya que el control BackGroundWorker est&aacute; basados en Threads, no podremos acceder a controles que pertenezcan a la UI, puesto que puede provocar una excepci&oacute;n al tratar de acceder a controles que no fueron instanciados en el propio Thread.</em></p>
<p><em>Para poder paliar este problema en el ejemplo muestro una manera, y es mediante Delegates.</em></p>
<p><em>Los Delegates se utilizan para implementar m&eacute;todos de devoluci&oacute;n de llamada (callbacks), esenciales para programar procesamiento as&iacute;ncrono o insertar c&oacute;digo de cliente.</em></p>
<p>&nbsp;</p>
<p style="text-align:center"><img src="-backgroundworker01.jpg" alt=""></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;frmPrincipal&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;cuenta&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">100</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnIniciar_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnIniciar.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.btnIniciar.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cuenta&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.NumericUpDown1.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundWorker1.RunWorkerAsync()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Excepci&oacute;n&nbsp;controlada:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;<span class="visualBasic__string">&quot;Error&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.<span class="visualBasic__keyword">Error</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Delegate</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;AddNumeroDelegate(<span class="visualBasic__keyword">ByVal</span>&nbsp;number&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;AddNumero(<span class="visualBasic__keyword">ByVal</span>&nbsp;number&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;txtProgreso.InvokeRequired&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtProgreso.Invoke(<span class="visualBasic__keyword">New</span>&nbsp;AddNumeroDelegate(<span class="visualBasic__keyword">AddressOf</span>&nbsp;AddNumero),&nbsp;number)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtProgreso.AppendText(<span class="visualBasic__string">&quot;Elemento&nbsp;&quot;</span>&nbsp;&amp;&nbsp;(number&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>).ToString()&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;procesandose..&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BackgroundWorker1_DoWork(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.ComponentModel.DoWorkEventArgs.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DoWorkEventArgs">System.ComponentModel.DoWorkEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;BackgroundWorker1.DoWork&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;i&nbsp;&lt;&nbsp;cuenta&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundWorker1.ReportProgress(<span class="visualBasic__number">100</span>&nbsp;*&nbsp;i&nbsp;/&nbsp;cuenta,&nbsp;<span class="visualBasic__string">&quot;Procesando&nbsp;(&quot;</span>&nbsp;&amp;&nbsp;i&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;/&quot;</span>&nbsp;&amp;&nbsp;cuenta&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;)&nbsp;elementos...&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddNumero(i)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Threading.Thread.Sleep(<span class="visualBasic__number">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundWorker1.ReportProgress(<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__string">&quot;Completado!&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Result&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Result&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BackgroundWorker1_RunWorkerCompleted(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.ComponentModel.RunWorkerCompletedEventArgs.aspx" target="_blank" title="Auto generated link to System.ComponentModel.RunWorkerCompletedEventArgs">System.ComponentModel.RunWorkerCompletedEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;BackgroundWorker1.RunWorkerCompleted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.btnIniciar.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.btnIniciar.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Excepci&oacute;n&nbsp;controlada:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;<span class="visualBasic__string">&quot;Error&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.<span class="visualBasic__keyword">Error</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BackgroundWorker1_ProgressChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.ComponentModel.ProgressChangedEventArgs.aspx" target="_blank" title="Auto generated link to System.ComponentModel.ProgressChangedEventArgs">System.ComponentModel.ProgressChangedEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;BackgroundWorker1.ProgressChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgressBar1.Value&nbsp;=&nbsp;e.ProgressPercentage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblEstado.Text&nbsp;=&nbsp;e.UserState&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Excepci&oacute;n&nbsp;controlada:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;<span class="visualBasic__string">&quot;Error&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.<span class="visualBasic__keyword">Error</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Form1.vb </li></ul>
<h1>More Information</h1>
<p><em>No hay informaci&oacute;n adicional.<br>
</em></p>
