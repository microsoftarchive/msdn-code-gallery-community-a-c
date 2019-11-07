# CRM Online 2011 WebServices - SOAP Only Client
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- CRM Online
- Web Services
## Topics
- Client
## Updated
- 11/01/2012
## Description

<p><em><span style="color:#ff0000">Updated <span style="color:#000000">29th August 2012: The sample has been modified to support both the Microsoft online services environment(Office 365 style) authentication and the Microsoft account (formerly Windows Live
 ID) authentication. Once again many thanks to <a href="http://www.linkedin.com/pub/ryan-lo/0/1bb/9bb" target="_blank">
Ryan Lo from Marketo </a>for providing the updated sample.<br>
</span></span></em></p>
<p>This example retrieves data from CRM Online using pure SOAP calls only and no additional assemblies to illustrate the underlying SOAP interactions.</p>
<p>It is useful if you're planning to interact with CRM Online web services from a non-.NET environment.</p>
<p>The soap messages were based on Fiddler (<a href="http://www.fiddler2.com">http://www.fiddler2.com</a>) traffic capture of sample code from the CRM 2011 SDK (<a href="http://msdn.microsoft.com/en-us/library/gg309408.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/gg309408.aspx</a>).</p>
<p>At a high-level below is what the code does:</p>
<ol>
<li>Pass in the device credentials and get a PUID. The device credentials is a <br>
randomly generated string that satisfies Live ID schema. You can generate one <br>
from this tool: <a href="http://code.msdn.microsoft.com/CRM2011Beta/Release/ProjectReleases.aspx?ReleaseId=4944">
Create CRM 2011 Beta Device</a> <br>
<ol>
<li>POST <a href="https://login.live.com/ppsecure/DeviceAddCredential.srf">https://login.live.com/ppsecure/DeviceAddCredential.srf</a>
</li><li>Get the PUID from response&nbsp;&nbsp; </li></ol>
</li><li>Pass the device credentials
<ol>
<li>POST <a href="https://login.live.com/liveidSTS.srf">https://login.live.com/liveidSTS.srf</a>
</li><li>Get the device CiperData (BinaryDAToken)&nbsp; </li></ol>
</li><li>Pass the WLID username, password and device BinaryDAToken
<ol>
<li>POST <a href="https://login.live.com/liveidSTS.srf">https://login.live.com/liveidSTS.srf</a>
</li><li>Get the security tokens (2 CipherValues) &amp; X509SubjectKeyIdentifier </li></ol>
</li><li>Do CRUD with the web service by passing X509SubjectKeyIdentifier, 2 CipherValues and the SOAP request (with data payload)
<ol>
<li>POST <a href="https://yourorganization.api.crm.dynamics.com/XRMServices/2011/Organization.svc">
https://yourorganization.api.crm.dynamics.com/XRMServices/2011/Organization.svc</a>
</li><li>Get the result from the CRUD response and parse XML to get the data you need </li></ol>
</li></ol>
<p><br>
Thanks,<br>
Girish Raja | Technical Product Manager | Microsoft |Redmond, WA<br>
<a href="http://blogs.msdn.com/girishr" target="_blank">http://blogs.msdn.com/girishr</a> |
<a href="http://twitter.com/girishr" target="_blank">http://twitter.com/girishr</a></p>
<p><br>
<br>
<br>
<br>
</p>
<p>&nbsp;</p>
<p><br>
<br>
</p>
<p>&nbsp;</p>
