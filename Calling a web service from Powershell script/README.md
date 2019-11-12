# Calling a web service from Powershell script
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WCF
- Powershell
- Web Services
- BizTalk Server
- Windows PowerShell 3.0
## Topics
- Powershell script to call a web service
## Updated
- 01/16/2014
## Description

<h1>Introduction</h1>
<p><em>Calling a web service from Powershell script</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This script can be used to call a web / wcf service from powershell script.</em></p>
<p><em>Just replace below things</em></p>
<p><em>1) URI1 with the service URL to be called 2) CalculateTax with the method to be called in service</em></p>
<p><em>3) Pass request xml path to Input variable</em></p>
<p><em>4)&nbsp;log file location&nbsp;</em>&nbsp;$Logfile in the code snippet</p>
<p>&nbsp;</p>
<p>Following is the sample logFile which logs the details as below:</p>
<p>-----------------------------------------------------------------------------<br>
Log started on 1/16/2014 3:48:07 AM<br>
Request <br>
------------------<br>
&lt;TaxServiceRequest&gt;... Request will be logged here........................ &lt;/TaxServiceRequest&gt;
<br>
Response <br>
------------------<br>
&lt;TaxServiceResponse&gt;...Response will be logged here.......................&nbsp; &lt;/TaxServiceResponse&gt;<br>
-----------------------------------------------------------------------------<br>
-----------------------------------------------------------------------------</p>
<p>&nbsp;</p>
<p>I have attached the PStoCallWcfService.zip file which consists of</p>
<p>1) PStoCallWcfService.txt change the extension from .txt to .ps1</p>
<p>2) Sample log file attached</p>
<p>3) Request and response xml files</p>
<p>You can customize this script as per your requirement and schedule it in task scheduler to run frequently.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="powershell"><span class="powerShell__com">#&nbsp;Script&nbsp;to&nbsp;call&nbsp;a&nbsp;web&nbsp;service&nbsp;from&nbsp;Powershell</span>&nbsp;
<span class="powerShell__com">#&nbsp;log&nbsp;file&nbsp;name,location&nbsp;to&nbsp;save&nbsp;the&nbsp;log&nbsp;details</span>&nbsp;
<span class="powerShell__variable">$Logfile</span>&nbsp;=&nbsp;<span class="powerShell__string">&quot;E:\LogFile.txt&quot;</span>&nbsp;
<span class="powerShell__keyword">function</span>&nbsp;LogWrite&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">Param</span>&nbsp;([string]<span class="powerShell__variable">$logstring</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Add-content</span>&nbsp;<span class="powerShell__operator">-</span>Path&nbsp;<span class="powerShell__variable">$Logfile</span>&nbsp;<span class="powerShell__operator">-</span>value&nbsp;<span class="powerShell__variable">$logstring</span>&nbsp;
}&nbsp;
<span class="powerShell__variable">$LogStartDT</span>&nbsp;=&nbsp;<span class="powerShell__string">&quot;Log&nbsp;started&nbsp;on&nbsp;{0}&quot;</span>&nbsp;<span class="powerShell__operator">-</span>f&nbsp;(<span class="powerShell__cmdlets">Get-Date</span>)&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;-----------------------------------------------------------------------------&quot;</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;$LogStartDT&quot;</span>&nbsp;
&nbsp;
<span class="powerShell__variable">$Input</span>&nbsp;=&nbsp;<span class="powerShell__cmdlets">Get-Content</span>&nbsp;<span class="powerShell__string">&quot;E:\TaxRequest.xml&quot;</span>&nbsp;
<span class="powerShell__com">#&nbsp;write&nbsp;request&nbsp;into&nbsp;log&nbsp;file</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;Request&nbsp;&quot;</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;------------------&quot;</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;$Input&quot;</span>&nbsp;
<span class="powerShell__variable">$URI1</span>&nbsp;=&nbsp;<span class="powerShell__string">&quot;https://abc.com/TaxCal/TaxService.svc&quot;</span>&nbsp;
&nbsp;
<span class="powerShell__variable">$proxy</span>&nbsp;=&nbsp;New<span class="powerShell__operator">-</span>WebServiceProxy&nbsp;<span class="powerShell__operator">-</span>Uri&nbsp;<span class="powerShell__variable">$URI1</span>&nbsp;
[xml]<span class="powerShell__variable">$resp</span>=&nbsp;<span class="powerShell__variable">$proxy</span>.CalculateTax(<span class="powerShell__variable">$Input</span>)&nbsp;
<span class="powerShell__com">#&nbsp;write&nbsp;response&nbsp;into&nbsp;log&nbsp;file</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;Response&nbsp;&quot;</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;------------------&quot;</span>&nbsp;
LogWrite&nbsp;<span class="powerShell__variable">$resp</span>.OuterXml&nbsp;
LogWrite&nbsp;<span class="powerShell__string">&quot;-----------------------------------------------------------------------------&quot;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
