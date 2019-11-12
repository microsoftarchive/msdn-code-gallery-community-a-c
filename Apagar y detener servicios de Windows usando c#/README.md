# Apagar y detener servicios de Windows usando c#
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Console Window
## Updated
- 07/07/2011
## Description

<p><strong><em>Apagar y detener servicios de Windows usando c#</em></strong></p>
<p>El siguiente ejemplo est&aacute; en Visual Studio 2008, pero puede ser reutilizado en versiones superiores e inferiores de VS. El siguiente ejemplo pretende iniciar y apagar servicios. En este ejemplo se trabaja con el servicio alerter, pero en el c&oacute;digo
 f&aacute;cilmente se puede modificar a cualquier otro servicio de Windows.</p>
<p><strong>Casos de uso.</strong></p>
<p>Por ejemplo, si mi aplicaci&oacute;n requiere reiniciar el servicio del SQL Server para que la configuraci&oacute;n se guarde, voy a necesitar que mi c&oacute;digo pueda realizar dicha operaci&oacute;n.</p>
<p>&nbsp;</p>
<p>Para bajarse el ejemplo, haga click ac&aacute;:</p>
<p>EJEMPLO VS DOWNLOAD</p>
<p>Lo que va a hacer este ejemplo es apagar e iniciar el servicio alerter de Windows.</p>
<p>Requerimientos:</p>
<p>Agregar la referencia System.ServiceProcess.</p>
<p>Agregar el namespace ServiceProcess.</p>
<p>using <a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.ServiceProcess.aspx" target="_blank" title="Auto generated link to System.ServiceProcess">System.ServiceProcess</a>;</p>
<p>&nbsp;</p>
<p>El resto es puro c&oacute;digo:</p>
<p>private void btnIniciar_Click(object sender, EventArgs e)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string nombreServicio = &quot;Alerter&quot;;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ServiceController service = new ServiceController(nombreServicio);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; int timeoutMilisegundos = 5000;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilisegundos);</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.Start();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.WaitForStatus(ServiceControllerStatus.Running, timeout);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void btnDetener_Click(object sender, EventArgs e)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string serviceName = &quot;Alerter&quot;;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ServiceController service = new ServiceController(serviceName);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; int timeoutMilliseconds = 5000;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.Stop();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.WaitForStatus(ServiceControllerStatus.Running, timeout);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>El c&oacute;digo es simple. Al presionar el bot&oacute;n Iniciar Servicio, el servicio se prende. Si se presiona el bot&oacute;n detener servicio, se detiene.</p>
<p>Analicemos l&iacute;nea por l&iacute;nea:</p>
<p>&nbsp;</p>
<p>En este caso, el servicio se llama Alerter, pero se puede cambiar por cualquier otro nombre.</p>
<p><strong>L&iacute;nea por l&iacute;nea.</strong></p>
<p>using <a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.ServiceProcess.aspx" target="_blank" title="Auto generated link to System.ServiceProcess">System.ServiceProcess</a>;</p>
<p>Esta l&iacute;nea permite utilizar las funciones de manejo de procesos.</p>
<p>string serviceName = &quot;Alerter&quot;;</p>
<p>Esta l&iacute;nea define el nombre del servicio a ser detenido.</p>
<p>ServiceController service = new ServiceController(serviceName);</p>
<p>En esta l&iacute;nea se indica que la variable serviceName (que contiene el nombre de alerter) ser&aacute; el servicio controlado por el sistema.</p>
<p>int timeoutMilliseconds = 5000;</p>
<p>Esta l&iacute;nea contiene el tiempo en milisegundos en que intentar&aacute; detener el servicio. Si toma m&aacute;s tiempo, el sistema dejar&aacute; de intentar (5 segundos de espera).</p>
<p>TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);</p>
