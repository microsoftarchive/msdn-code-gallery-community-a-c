# Add log on as a service user rights with windows powershell
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Windows Server
## Topics
- Security and windows powershell
## Updated
- 07/23/2013
## Description

<h1>Introduction</h1>
<p><em>Automating the addition of LogOnAsAService rights to a machine has been challenging and tedious up until now....</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>No, your machine must have powershell v2.0 or newer, and must also have secedit.exe as a native tool in the Path.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>It takes the current users credentials and grants them log on as a service rights in the local security policy, user rights assignments. Script can also be modified to take in the user name as a parameter so that it is more versatile...</em></p>
<p><em>It queries the list of currently added users and appends the new user to the list so you don't have to worry about losing any existing permissions. A group policy update is then performed at the system level to sync up all of the changes.&nbsp;</em></p>
<p>Before executing be sure to have the .inf &quot;template&quot; file in the same directory as that is what will be used to build a new .inf that gets merged back into the security database.</p>
<p>...................................................................................................................................................</p>
<p>...................................................................................................................................................</p>
<p>...................................................................................................................................................</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>
<pre class="hidden">Set-ExecutionPolicy Unrestricted

#Get SID from current user
$objUser = New-Object System.Security.Principal.NTAccount(&quot;$ENV:userdomain\$ENV:username&quot;)
$strSID = $objUser.Translate([System.Security.Principal.SecurityIdentifier])
$MySID = $strSID.Value

#Get list of currently used SIDs
secedit /export /cfg tempexport.inf
$curSIDs = Select-String .\tempexport.inf -Pattern &quot;SeServiceLogonRight&quot;
$Sids = $curSIDs.line
copy .\LogOnAsAService.inf .\LogOnAsAServiceTemplate.inf
add-content .\LogOnAsAServiceTemplate.inf &quot;$Sids,*$MySID&quot;

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
secedit /import /db secedit.sdb /cfg &quot;$scriptPath\LogOnAsAServiceTemplate.inf&quot;
secedit /configure /db secedit.sdb

gpupdate /force

del &quot;$scriptPath\LogOnAsAServiceTemplate.inf&quot; -force
del &quot;$scriptPath\secedit.sdb&quot; -force
del &quot;$scriptPath\tempexport.inf&quot; -force</pre>
<div class="preview">
<pre class="powershell"><span class="powerShell__cmdlets">Set-ExecutionPolicy</span>&nbsp;Unrestricted&nbsp;
&nbsp;
<span class="powerShell__com">#Get&nbsp;SID&nbsp;from&nbsp;current&nbsp;user</span>&nbsp;
<span class="powerShell__variable">$objUser</span>&nbsp;=&nbsp;<span class="powerShell__cmdlets">New-Object</span>&nbsp;System.Security.Principal.NTAccount(<span class="powerShell__string">&quot;$ENV:userdomain\$ENV:username&quot;</span>)&nbsp;
<span class="powerShell__variable">$strSID</span>&nbsp;=&nbsp;<span class="powerShell__variable">$objUser</span>.Translate([System.Security.Principal.SecurityIdentifier])&nbsp;
<span class="powerShell__variable">$MySID</span>&nbsp;=&nbsp;<span class="powerShell__variable">$strSID</span>.Value&nbsp;
&nbsp;
<span class="powerShell__com">#Get&nbsp;list&nbsp;of&nbsp;currently&nbsp;used&nbsp;SIDs</span>&nbsp;
secedit&nbsp;<span class="powerShell__operator">/</span>export&nbsp;<span class="powerShell__operator">/</span>cfg&nbsp;tempexport.inf&nbsp;
<span class="powerShell__variable">$curSIDs</span>&nbsp;=&nbsp;<span class="powerShell__cmdlets">Select-String</span>&nbsp;.\tempexport.inf&nbsp;<span class="powerShell__operator">-</span>Pattern&nbsp;<span class="powerShell__string">&quot;SeServiceLogonRight&quot;</span>&nbsp;
<span class="powerShell__variable">$Sids</span>&nbsp;=&nbsp;<span class="powerShell__variable">$curSIDs</span>.line&nbsp;
copy&nbsp;.\LogOnAsAService.inf&nbsp;.\LogOnAsAServiceTemplate.inf&nbsp;
<span class="powerShell__cmdlets">add-content</span>&nbsp;.\LogOnAsAServiceTemplate.inf&nbsp;<span class="powerShell__string">&quot;$Sids,*$MySID&quot;</span>&nbsp;
&nbsp;
<span class="powerShell__variable">$scriptPath</span>&nbsp;=&nbsp;<span class="powerShell__cmdlets">split-path</span>&nbsp;<span class="powerShell__operator">-</span>parent&nbsp;<span class="powerShell__variable">$MyInvocation</span>.MyCommand.Definition&nbsp;
secedit&nbsp;<span class="powerShell__operator">/</span>import&nbsp;<span class="powerShell__operator">/</span>db&nbsp;secedit.sdb&nbsp;<span class="powerShell__operator">/</span>cfg&nbsp;<span class="powerShell__string">&quot;$scriptPath\LogOnAsAServiceTemplate.inf&quot;</span>&nbsp;
secedit&nbsp;<span class="powerShell__operator">/</span>configure&nbsp;<span class="powerShell__operator">/</span>db&nbsp;secedit.sdb&nbsp;
&nbsp;
gpupdate&nbsp;<span class="powerShell__operator">/</span>force&nbsp;
&nbsp;
<span class="powerShell__alias">del</span>&nbsp;<span class="powerShell__string">&quot;$scriptPath\LogOnAsAServiceTemplate.inf&quot;</span>&nbsp;<span class="powerShell__operator">-</span>force&nbsp;
<span class="powerShell__alias">del</span>&nbsp;<span class="powerShell__string">&quot;$scriptPath\secedit.sdb&quot;</span>&nbsp;<span class="powerShell__operator">-</span>force&nbsp;
<span class="powerShell__alias">del</span>&nbsp;<span class="powerShell__string">&quot;$scriptPath\tempexport.inf&quot;</span>&nbsp;<span class="powerShell__operator">-</span>force</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Must be in the same directory as the .ps1 prior to running:&nbsp;<a id="92750" href="/site/view/file/92750/1/LogOnAsAService.inf">LogOnAsAService.inf</a>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
