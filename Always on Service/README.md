# Always on Service
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Service
## Topics
- Windows Service
## Updated
- 05/13/2016
## Description

<h1>Introduction</h1>
<p>I often develop critical windows services which have the need to be always on, even in case of a crash.My idea is to develop a parallel windows service with a very simple business logic which monitors continuously another windows service:Service A will contain
 the critical business logic, while Service B simply constantly check that Service A status is running. In the case that Service A falls down, Service B will have the task to restart Service A.</p>
<h1><span>Building the Sample</span></h1>
<p><em>No build requiremet are required.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This solution is very simple:</em></p>
<p><em>The core of this solution is a Timer objectSystem.Timers.Timer</em></p>
<p><em>https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.110).aspx</em></p>
<p><em>(Generates an event after a set interval, with an option to generate recurring events.)</em></p>
<p><em>Which, every x milliseconds, generate an event in which will be present the logic to check and possibly restart the monitored service.</em></p>
<p><em>The service name and the timer interval are red from the configuration file.</em></p>
<p><em>Using then a ServiceControllerStatus Class</em></p>
<p><em>https://msdn.microsoft.com/en-us/library/system.serviceprocess.servicecontroller(v=vs.110).aspx</em></p>
<p><em>(Represents a Windows service and allows you to connect to a running or stopped service, manipulate it, or get information about it.)</em></p>
<p><em>I can check the status of the service, reading the Status property</em></p>
<p><em>https://msdn.microsoft.com/en-us/library/system.serviceprocess.servicecontroller.status(v=vs.110).aspx</em></p>
<p><em>(Gets the status of the service that is referenced by this instance.)</em></p>
<p><em>And then, if the service is stopped, restart it using the Start method.</em></p>
<p><em>https://msdn.microsoft.com/en-us/library/yb9w7ytd(v=vs.110).aspx</em></p>
<p><em>(Starts the service, passing no arguments.)</em><em>&nbsp; &nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name,&nbsp;<span class="cs__string">&quot;Checking&nbsp;status&nbsp;for&nbsp;service&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Properties.Settings.Default.ServiceName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceController&nbsp;sc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceController(Properties.Settings.Default.ServiceName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name,&nbsp;<span class="cs__string">&quot;Current&nbsp;status:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;sc.Status.ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(sc.Status&nbsp;==&nbsp;ServiceControllerStatus.Stopped)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name,&nbsp;<span class="cs__string">&quot;Starting&nbsp;service&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Properties.Settings.Default.ServiceName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name,&nbsp;<span class="cs__string">&quot;Started&nbsp;service&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Properties.Settings.Default.ServiceName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoggingHelper.Information(MethodBase.GetCurrentMethod().Name,&nbsp;<span class="cs__string">&quot;Service&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Properties.Settings.Default.ServiceName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;was&nbsp;stopped.&nbsp;Service&nbsp;restarted.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoggingHelper.Exception(MethodBase.GetCurrentMethod().Name,&nbsp;ex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>This solution come with Logger classes, using Enterprise Library Logging and with a Wix setup project.</p>
<p><span style="font-size:x-small; color:#ff0000"><strong>This solution is to be intended for demo purpose.It disclaims all liability of service usage in production environments.</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:x-small; color:#ff0000"><strong><a title="http://zsvipullo.blogspot.it/" href="http://zsvipullo.blogspot.it/">http://zsvipullo.blogspot.it/</a><br>
</strong></span></p>
