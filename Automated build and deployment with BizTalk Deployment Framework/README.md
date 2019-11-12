# Automated build and deployment with BizTalk Deployment Framework
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Powershell
- BizTalk Server
- BizTalk Deployment Framework
## Topics
- Automation
- Deployment
## Updated
- 02/14/2016
## Description

<h1>Introduction</h1>
<p><em><a href="https://biztalkdeployment.codeplex.com/" target="_blank">BizTalk Deployment Framework</a> is one of those pearls for BizTalk developers, allowing complex BizTalk solutions to be deployed easily, having all our artifacts and dependencies together
 in one MSI. To make life even better for us, we can also automate the process of building and deploying these BTDF MSI's by using PowerShell. This especially comes in handy once we start having large projects with many BizTalk applications, where we would
 have to spend a lot of time manually running all these MSI's.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Using PowerShell we will make scripts which will handle all steps of the build and deployment process for us. This will make sure our applications are always deployed in the correct order, using the right versions, and with minimal effort. We have some general
 helper functions, which will help us clear log files, wait for user input, iterate through directories, etc. We assume you have are using some of the BTDF best practices for these scripts, where it comes to naming conventions and folder structure. Of course,
 in case anything differs in your environment, you can easily adjust the scripts to meet your requirements.</p>
<h1>Build</h1>
<p>We will first create the PowerShell scripts which will help us build our applications. To be able to share these scripts along your different developers, where there might be some differences in the environments in how directories are set up, we will make
 use of a small csv file to hold our build environment settings.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">Name;Value&nbsp;
projectsBaseDirectory;F:\tfs&nbsp;
installersOutputDirectory;F:\Deployment&nbsp;
visualStudioDirectory;F:\Program&nbsp;Files&nbsp;(x86)\Microsoft&nbsp;Visual&nbsp;Studio&nbsp;<span class="js__num">11.0</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>We will load these settings in our script and assign them to specific parameters.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">$settings&nbsp;=&nbsp;Import-Csv&nbsp;Settings_BuildEnvironment.csv&nbsp;
foreach($setting&nbsp;<span class="js__operator">in</span>&nbsp;$settings)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;The&nbsp;directory&nbsp;where&nbsp;the&nbsp;BizTalk&nbsp;projects&nbsp;are&nbsp;stored&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;projectsBaseDirectory&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$projectsBaseDirectory&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;The&nbsp;directory&nbsp;where&nbsp;the&nbsp;MSI's&nbsp;should&nbsp;be&nbsp;saved&nbsp;to&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;installersOutputDirectory&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$installersOutputDirectory&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Directory&nbsp;where&nbsp;Visual&nbsp;Studio&nbsp;resides&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;visualStudioDirectory&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$visualStudioDirectory&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Now that we have our environment specific parameters set, we can create a function which will build our BizTalk application. We will assume you have several projects, which are in folders under a common directory ($projectsBaseDirectory), which is probably
 your source control root directory. Your application's directories should be under these project's directories. We will building the application by calling Visual Studio, and using the log to check if the build was successful.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;BuildBizTalkApplication([string]$application,&nbsp;[string]$project)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Set&nbsp;directory&nbsp;where&nbsp;the&nbsp;BizTalk&nbsp;projects&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;current&nbsp;project&nbsp;are&nbsp;stored&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$projectsDirectory&nbsp;=&nbsp;<span class="js__string">&quot;$projectsBaseDirectory\$project&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Clear&nbsp;log&nbsp;files&nbsp;and&nbsp;old&nbsp;installers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ClearLogFiles&nbsp;$application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Build&nbsp;application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;Building&nbsp;$application&quot;</span>&nbsp;-ForegroundColor&nbsp;Cyan&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$exitCode&nbsp;=&nbsp;(Start-Process&nbsp;-FilePath&nbsp;<span class="js__string">&quot;$visualStudioDirectory\Common7\IDE\devenv.exe&quot;</span>&nbsp;-ArgumentList&nbsp;<span class="js__string">&quot;&quot;</span><span class="js__string">&quot;$projectsDirectory\$application\$application.sln&quot;</span><span class="js__string">&quot;&nbsp;/Build&nbsp;Release&nbsp;/Out&nbsp;$application.log&quot;</span>&nbsp;-PassThru&nbsp;-Wait).ExitCode&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Check&nbsp;result&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($exitCode&nbsp;-eq&nbsp;<span class="js__num">0</span>&nbsp;-and&nbsp;(Select-<span class="js__object">String</span>&nbsp;-Path&nbsp;<span class="js__string">&quot;$application.log&quot;</span>&nbsp;-Pattern&nbsp;<span class="js__string">&quot;0&nbsp;failed&quot;</span>&nbsp;-Quiet)&nbsp;-eq&nbsp;<span class="js__string">&quot;true&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;built&nbsp;succesfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Green&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;not&nbsp;built&nbsp;succesfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WaitForKeyPress&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Once the applications are built, we will also need to create MSI's for them, which is where the BTDF comes in. This can be done by calling MSBuild, and passing in the .btdfproj file. Finally we copy the MSI to a folder, so all our
 MSI's are together in one location and from there can be copied to the BizTalk server.</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;BuildBizTalkMsi([string]$application,&nbsp;[string]$project)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Set&nbsp;directory&nbsp;where&nbsp;the&nbsp;BizTalk&nbsp;projects&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;current&nbsp;project&nbsp;are&nbsp;stored&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$projectsDirectory&nbsp;=&nbsp;<span class="js__string">&quot;$projectsBaseDirectory\$project&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Build&nbsp;installer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$exitCode&nbsp;=&nbsp;(Start-Process&nbsp;-FilePath&nbsp;<span class="js__string">&quot;&quot;</span><span class="js__string">&quot;$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe&quot;</span><span class="js__string">&quot;&quot;</span>&nbsp;-ArgumentList&nbsp;<span class="js__string">&quot;/t:Installer&nbsp;/p:Configuration=Release&nbsp;&quot;</span><span class="js__string">&quot;$projectsDirectory\$application\Deployment\Deployment.btdfproj&quot;</span><span class="js__string">&quot;&nbsp;/l:FileLogger,Microsoft.Build.Engine;logfile=$application.msi.log&quot;</span>&nbsp;-PassThru&nbsp;-Wait).ExitCode&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Check&nbsp;result&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($exitCode&nbsp;-eq&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;MSI&nbsp;for&nbsp;$application&nbsp;built&nbsp;succesfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Green&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;MSI&nbsp;for&nbsp;$application&nbsp;not&nbsp;built&nbsp;succesfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WaitForKeyPress&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Copy&nbsp;installer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;copy&nbsp;<span class="js__string">&quot;$projectsDirectory\$application\Deployment\bin\Release\*.msi&quot;</span>&nbsp;<span class="js__string">&quot;$installersOutputDirectory&quot;</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1>Deployment</h1>
<p>Once the MSI's have been created we can copy them to our BizTalk server, and start the deployment process. This process consists of 4 steps, starting with undeploying the old applications, uninstalling the old MSI's, installing the new MSI's and deploying
 the new applications. If your applications have dependencies on other applications, it's also important to undeploy and deploy them in the correct order. We will want to use one set of scripts for all our OTAP environments, so we will be using another csv
 file here to keep track of the environment specific settings, like directories and config files to use.</p>
<h2>Undeploy</h2>
<p>We will start by loading the environment specific parameters.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">$settings&nbsp;=&nbsp;Import-Csv&nbsp;Settings_DeploymentEnvironment.csv&nbsp;
foreach($setting&nbsp;<span class="js__operator">in</span>&nbsp;$settings)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Program&nbsp;Files&nbsp;directory&nbsp;where&nbsp;application&nbsp;should&nbsp;be&nbsp;installed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;programFilesDirectory&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$programFilesDirectory&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Suffix&nbsp;as&nbsp;set&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">in</span>&nbsp;the&nbsp;ProductName&nbsp;section&nbsp;of&nbsp;the&nbsp;BTDF&nbsp;project&nbsp;file.&nbsp;By&nbsp;<span class="js__statement">default</span>&nbsp;<span class="js__operator">this</span>&nbsp;is&nbsp;<span class="js__string">&quot;&nbsp;for&nbsp;BizTalk&quot;</span>.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;productNameSuffix&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$productNameSuffix&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].TrimEnd()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Indicator&nbsp;<span class="js__statement">if</span>&nbsp;we&nbsp;should&nbsp;deploy&nbsp;to&nbsp;the&nbsp;BizTalkMgmtDB&nbsp;database&nbsp;from&nbsp;<span class="js__operator">this</span>&nbsp;server.&nbsp;In&nbsp;multi-server&nbsp;environments&nbsp;<span class="js__operator">this</span>&nbsp;should&nbsp;be&nbsp;true&nbsp;on&nbsp;<span class="js__num">1</span>&nbsp;server,&nbsp;and&nbsp;false&nbsp;on&nbsp;the&nbsp;others&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;deployBizTalkMgmtDB&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$deployBizTalkMgmtDB&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Now we can write our function for undeploying. We will also be using MSBuild in conjuntion with BTDF here, by passing in the .btdfproj file location with the Undeploy switch. To do so, we will call the following function for each application to be undeployed.
 Remember to do the undeployment in the correct order.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;UndeployBizTalkApplication([string]$application,&nbsp;[string]$version)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Execute&nbsp;undeployment&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$exitCode&nbsp;=&nbsp;(Start-Process&nbsp;-FilePath&nbsp;<span class="js__string">&quot;$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe&quot;</span>&nbsp;-ArgumentList&nbsp;<span class="js__string">&quot;&quot;</span><span class="js__string">&quot;$programFilesDirectory\$application$productNameSuffix\$version\Deployment\Deployment.btdfproj&quot;</span><span class="js__string">&quot;&nbsp;/t:Undeploy&nbsp;/p:DeployBizTalkMgmtDB=$deployBizTalkMgmtDB&nbsp;/p:Configuration=Server&quot;</span>&nbsp;-Wait&nbsp;-Passthru).ExitCode&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($exitCode&nbsp;-eq&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;undeployed&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Green&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;not&nbsp;undeployed&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>Uninstall</h2>
<p>Once all the applications for our project have been undeployed, we will uninstall the old MSI's. To do this, we will iterate through the MSI's in the specified directory, where we will pass in the directory with the last used installers.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;UninstallBizTalkApplications($msiDirectory)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Get&nbsp;MSI's&nbsp;to&nbsp;be&nbsp;installed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$files&nbsp;=&nbsp;GetMsiFiles&nbsp;$msiDirectory&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Loop&nbsp;through&nbsp;MSI&nbsp;files&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach($file&nbsp;<span class="js__operator">in</span>&nbsp;$files)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UninstallBizTalkApplication&nbsp;$file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>This will call the uninstall command. We will assume our MSI's are named according to BTDF defaults, which is applicationname-version, so for example MyApplication-1.0.0.msi.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;UninstallBizTalkApplication([<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.FileInfo.aspx" target="_blank" title="Auto generated link to System.IO.FileInfo">System.IO.FileInfo</a>]$fileInfo)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Get&nbsp;application&nbsp;name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$applicationName&nbsp;=&nbsp;$fileInfo.BaseName.Split(<span class="js__string">&quot;-&quot;</span>)[<span class="js__num">0</span>]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Set&nbsp;installer&nbsp;path&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$msiPath&nbsp;=&nbsp;$fileInfo.FullName&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Uninstall&nbsp;application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$exitCode&nbsp;=&nbsp;(Start-Process&nbsp;-FilePath&nbsp;<span class="js__string">&quot;msiexec.exe&quot;</span>&nbsp;-ArgumentList&nbsp;<span class="js__string">&quot;/x&nbsp;&quot;</span><span class="js__string">&quot;$msiPath&quot;</span><span class="js__string">&quot;&nbsp;/qn&quot;</span>&nbsp;-Wait&nbsp;-Passthru).ExitCode&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Check&nbsp;<span class="js__statement">if</span>&nbsp;uninstalling&nbsp;was&nbsp;successful&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($exitCode&nbsp;-eq&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$applicationName&nbsp;uninstalled&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Green&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$applicationName&nbsp;not&nbsp;uninstalled&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>Install</h2>
<p>The next step will be to install all the new MSI's we have just built. Here we will once again iterate through the specified directory, where we will now pass in the directory with the new installers.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;InstallBizTalkApplications([string]$msiDirectory)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Clear&nbsp;log&nbsp;files&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ClearLogFiles&nbsp;$msiDirectory&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Get&nbsp;MSI's&nbsp;to&nbsp;be&nbsp;installed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$files&nbsp;=&nbsp;GetMsiFiles&nbsp;$msiDirectory&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Loop&nbsp;through&nbsp;MSI&nbsp;files&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach($file&nbsp;<span class="js__operator">in</span>&nbsp;$files)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Install&nbsp;application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InstallBizTalkApplication&nbsp;$file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;We will also have to load the environment specific parameters here.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">$settings&nbsp;=&nbsp;Import-Csv&nbsp;Settings_DeploymentEnvironment.csv&nbsp;
foreach($setting&nbsp;<span class="js__operator">in</span>&nbsp;$settings)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Program&nbsp;Files&nbsp;directory&nbsp;where&nbsp;application&nbsp;should&nbsp;be&nbsp;installed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;programFilesDirectory&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$programFilesDirectory&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Suffix&nbsp;as&nbsp;set&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">in</span>&nbsp;the&nbsp;ProductName&nbsp;section&nbsp;of&nbsp;the&nbsp;BTDF&nbsp;project&nbsp;file.&nbsp;By&nbsp;<span class="js__statement">default</span>&nbsp;<span class="js__operator">this</span>&nbsp;is&nbsp;<span class="js__string">&quot;&nbsp;for&nbsp;BizTalk&quot;</span>.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;productNameSuffix&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$productNameSuffix&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].TrimEnd()&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">And now we can install the MSI. As mentioned before, we will assume our MSI's are named according to BTDF defaults (applicationname-version.msi).</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;InstallBizTalkApplication([<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.FileInfo.aspx" target="_blank" title="Auto generated link to System.IO.FileInfo">System.IO.FileInfo</a>]$fileInfo)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Get&nbsp;application&nbsp;name&nbsp;and&nbsp;version&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;We&nbsp;assume&nbsp;msi&nbsp;file&nbsp;name&nbsp;is&nbsp;<span class="js__operator">in</span>&nbsp;the&nbsp;format&nbsp;ApplicationName-Version&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$application&nbsp;=&nbsp;$fileInfo.BaseName.Split(<span class="js__string">&quot;-&quot;</span>)[<span class="js__num">0</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$version&nbsp;=&nbsp;$fileInfo.BaseName.Split(<span class="js__string">&quot;-&quot;</span>)[<span class="js__num">1</span>]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Directory&nbsp;where&nbsp;MSI&nbsp;resides&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$msiDirectory&nbsp;=&nbsp;$fileInfo.Directory&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Set&nbsp;log&nbsp;name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$logFileName&nbsp;=&nbsp;<span class="js__string">&quot;$msiDirectory\$application.log&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Set&nbsp;installer&nbsp;path&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$msiPath&nbsp;=&nbsp;$fileInfo.FullName&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Install&nbsp;application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Start-Process&nbsp;-FilePath&nbsp;<span class="js__string">&quot;msiexec.exe&quot;</span>&nbsp;-ArgumentList&nbsp;<span class="js__string">&quot;/i&nbsp;&quot;</span><span class="js__string">&quot;$msiPath&quot;</span><span class="js__string">&quot;&nbsp;/passive&nbsp;/log&nbsp;&quot;</span><span class="js__string">&quot;$logFileName&quot;</span><span class="js__string">&quot;&nbsp;INSTALLDIR=&quot;</span><span class="js__string">&quot;$programFilesDirectory\$application$productNameSuffix\$version&quot;</span><span class="js__string">&quot;&quot;</span>&nbsp;-Wait&nbsp;-Passthru&nbsp;|&nbsp;Out-Null&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Check&nbsp;<span class="js__statement">if</span>&nbsp;installation&nbsp;was&nbsp;successful&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>((Select-<span class="js__object">String</span>&nbsp;-Path&nbsp;$logFileName&nbsp;-Pattern&nbsp;<span class="js__string">&quot;success&nbsp;or&nbsp;error&nbsp;status:&nbsp;0&quot;</span>&nbsp;-Quiet)&nbsp;-eq&nbsp;<span class="js__string">&quot;true&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;installed&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Green&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;not&nbsp;installed&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Deploy</h2>
<div class="endscriptcode"><br>
The last step is to deploy the applications we just installed. First we again have to load the environment specific parameters.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">$settings&nbsp;=&nbsp;Import-Csv&nbsp;Settings_DeploymentEnvironment.csv&nbsp;
foreach($setting&nbsp;<span class="js__operator">in</span>&nbsp;$settings)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Program&nbsp;Files&nbsp;directory&nbsp;where&nbsp;application&nbsp;should&nbsp;be&nbsp;installed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;programFilesDirectory&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$programFilesDirectory&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Suffix&nbsp;as&nbsp;set&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">in</span>&nbsp;the&nbsp;ProductName&nbsp;section&nbsp;of&nbsp;the&nbsp;BTDF&nbsp;project&nbsp;file.&nbsp;By&nbsp;<span class="js__statement">default</span>&nbsp;<span class="js__operator">this</span>&nbsp;is&nbsp;<span class="js__string">&quot;&nbsp;for&nbsp;BizTalk&quot;</span>.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;productNameSuffix&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$productNameSuffix&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].TrimEnd()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Indicator&nbsp;<span class="js__statement">if</span>&nbsp;we&nbsp;should&nbsp;deploy&nbsp;to&nbsp;the&nbsp;BizTalkMgmtDB&nbsp;database&nbsp;from&nbsp;<span class="js__operator">this</span>&nbsp;server.&nbsp;In&nbsp;multi-server&nbsp;environments&nbsp;<span class="js__operator">this</span>&nbsp;should&nbsp;be&nbsp;true&nbsp;on&nbsp;<span class="js__num">1</span>&nbsp;server,&nbsp;and&nbsp;false&nbsp;on&nbsp;the&nbsp;others&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;deployBizTalkMgmtDB&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$deployBizTalkMgmtDB&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Name&nbsp;of&nbsp;the&nbsp;BTDF&nbsp;environment&nbsp;settings&nbsp;file&nbsp;<span class="js__statement">for</span>&nbsp;<span class="js__operator">this</span>&nbsp;environment.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">0</span>].Trim()&nbsp;-eq&nbsp;<span class="js__string">&quot;environmentSettingsFileName&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;$environmentSettingsFileName&nbsp;=&nbsp;$setting.<span class="js__string">'Name;Value'</span>.Split(<span class="js__string">&quot;;&quot;</span>)[<span class="js__num">1</span>].Trim()&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">Deploying is also done by using MSBuild with BTDF, by specifying the Deploy flag. For this we will be calling the following function for each application to be deployed, which of course should be done in the correct order.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;DeployBizTalkApplication([string]$application,&nbsp;[string]$version)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Set&nbsp;log&nbsp;file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$logFileName&nbsp;=&nbsp;<span class="js__string">&quot;$programFilesDirectory\$application$productNameSuffix\$version\DeployResults\DeployResults.txt&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Execute&nbsp;deployment&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$exitCode&nbsp;=&nbsp;(Start-Process&nbsp;-FilePath&nbsp;<span class="js__string">&quot;$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe&quot;</span>&nbsp;-ArgumentList&nbsp;<span class="js__string">&quot;/p:DeployBizTalkMgmtDB=$deployBizTalkMgmtDB;Configuration=Server;SkipUndeploy=true&nbsp;/target:Deploy&nbsp;/l:FileLogger,Microsoft.Build.Engine;logfile=&quot;</span><span class="js__string">&quot;$programFilesDirectory\$application$productNameSuffix\$version\DeployResults\DeployResults.txt&quot;</span><span class="js__string">&quot;&nbsp;&quot;</span><span class="js__string">&quot;$programFilesDirectory\$application$productNameSuffix\$version\Deployment\Deployment.btdfproj&quot;</span><span class="js__string">&quot;&nbsp;/p:ENV_SETTINGS=&quot;</span><span class="js__string">&quot;$programFilesDirectory\$application$productNameSuffix\$version\Deployment\EnvironmentSettings\$environmentSettingsFileName.xml&quot;</span><span class="js__string">&quot;&quot;</span>&nbsp;-Wait&nbsp;-Passthru).ExitCode&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Check&nbsp;<span class="js__statement">if</span>&nbsp;deployment&nbsp;was&nbsp;successful&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($exitCode&nbsp;-eq&nbsp;<span class="js__num">0</span>&nbsp;-and&nbsp;(Select-<span class="js__object">String</span>&nbsp;-Path&nbsp;$logFileName&nbsp;-Pattern&nbsp;<span class="js__string">&quot;0&nbsp;Error(s)&quot;</span>&nbsp;-Quiet)&nbsp;-eq&nbsp;<span class="js__string">&quot;true&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;deployed&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Green&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write-Host&nbsp;<span class="js__string">&quot;$application&nbsp;not&nbsp;deployed&nbsp;successfully&quot;</span>&nbsp;-ForegroundColor&nbsp;Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
</div>
<p>From the same location where we call this function, we will also do some additional checks. Sometimes you will want to import some registry files or execute a SQL script, which you might not want to include in your BTDF MSI for any reason. Also, once everything
 has been deployed, you might want to restart your host instances and IIS, which can also be handled here.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;DeployBizTalkApplications([string[]]$applicationsInOrderOfDeployment,&nbsp;[string[]]$versions,&nbsp;[string]$scriptsDirectory)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Check&nbsp;which&nbsp;restarts&nbsp;should&nbsp;be&nbsp;done&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$resetIIS&nbsp;=&nbsp;CheckIfIISShouldBeReset&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$restartHostInstances&nbsp;=&nbsp;CheckIfHostinstancesShouldBeRestarted&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Loop&nbsp;through&nbsp;applications&nbsp;to&nbsp;be&nbsp;deployed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>($index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;$index&nbsp;-lt&nbsp;$applicationsInOrderOfDeployment.Length;&nbsp;$index&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Deploy&nbsp;application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeployBizTalkApplication&nbsp;$applicationsInOrderOfDeployment[$index]&nbsp;$versions[$index]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Get&nbsp;SQL&nbsp;files&nbsp;to&nbsp;be&nbsp;executed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$sqlFiles&nbsp;=&nbsp;GetSQLFiles&nbsp;$scriptsDirectory&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Loop&nbsp;through&nbsp;SQL&nbsp;files&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach($sqlFile&nbsp;<span class="js__operator">in</span>&nbsp;$sqlFiles)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Execute&nbsp;SQL&nbsp;file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExecuteSqlFile&nbsp;$sqlFile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Get&nbsp;registry&nbsp;files&nbsp;to&nbsp;be&nbsp;imported&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$registryFiles&nbsp;=&nbsp;GetRegistryFiles&nbsp;$scriptsDirectory&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Loop&nbsp;through&nbsp;registry&nbsp;files&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach($registryFile&nbsp;<span class="js__operator">in</span>&nbsp;$registryFiles)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Import&nbsp;registry&nbsp;file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImportRegistryFile&nbsp;$registryFile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;Do&nbsp;restarts&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($resetIIS)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoIISReset&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($restartHostInstances)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoHostInstancesRestart&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1>Bringing it all together</h1>
<p>Finally, we have to stitch it all together. When you have downloaded the complete set of functions from this article, you can specify your build scripts as following, where you will only have to change the project name and applications to be built.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">#&nbsp;Project&nbsp;specific&nbsp;settings&nbsp;
$projectName&nbsp;=&nbsp;<span class="js__string">&quot;OrderSystem&quot;</span>&nbsp;
$applications&nbsp;=&nbsp;@(<span class="js__string">&quot;Contoso.OrderSystem.Orders&quot;</span>,&nbsp;<span class="js__string">&quot;Contoso.OrderSystem.Invoices&quot;</span>,&nbsp;<span class="js__string">&quot;Contoso.OrderSystem.Payments&quot;</span>)&nbsp;
&nbsp;
#&nbsp;Import&nbsp;custom&nbsp;functions&nbsp;
.&nbsp;.\Functions_Build.ps1&nbsp;
&nbsp;
#&nbsp;Build&nbsp;the&nbsp;applications&nbsp;
BuildAndCreateBizTalkInstallers&nbsp;$applications&nbsp;$projectName&nbsp;
&nbsp;
#&nbsp;Wait&nbsp;<span class="js__statement">for</span>&nbsp;user&nbsp;to&nbsp;exit&nbsp;
WaitForKeyPress</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>As for deployment, all those steps can also be called from one single script as following. Once again, the only thing to change is the project specific settings.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">#&nbsp;Project&nbsp;specific&nbsp;settings&nbsp;
$oldInstallersDirectory&nbsp;=&nbsp;<span class="js__string">&quot;F:\tmp\R9&quot;</span>&nbsp;
$newInstallersDirectory&nbsp;=&nbsp;<span class="js__string">&quot;F:\tmp\R10&quot;</span>&nbsp;
$newApplications&nbsp;=&nbsp;@(<span class="js__string">&quot;Contoso.OrderSystem.Orders&quot;</span>,&nbsp;<span class="js__string">&quot;Contoso.OrderSystem.Invoices&quot;</span>,&nbsp;<span class="js__string">&quot;Contoso.OrderSystem.Payments&quot;</span>)&nbsp;
$oldApplications&nbsp;=&nbsp;@(<span class="js__string">&quot;Contoso.OrderSystem.Payments&quot;</span>,&nbsp;<span class="js__string">&quot;Contoso.OrderSystem.Invoices&quot;</span>,&nbsp;<span class="js__string">&quot;Contoso.OrderSystem.Orders&quot;</span>)&nbsp;
$oldVersions&nbsp;=&nbsp;@(<span class="js__string">&quot;1.0.0&quot;</span>,&nbsp;<span class="js__string">&quot;1.0.0&quot;</span>,&nbsp;<span class="js__string">&quot;1.0.0&quot;</span>)&nbsp;
$newVersions&nbsp;=&nbsp;@(<span class="js__string">&quot;1.0.0&quot;</span>,&nbsp;<span class="js__string">&quot;1.0.1&quot;</span>,&nbsp;<span class="js__string">&quot;1.0.0&quot;</span>)&nbsp;
&nbsp;
#&nbsp;Import&nbsp;custom&nbsp;functions&nbsp;
.&nbsp;.\Functions_Deploy.ps1&nbsp;
.&nbsp;.\Functions_Undeploy.ps1&nbsp;
.&nbsp;.\Functions_Install.ps1&nbsp;
.&nbsp;.\Functions_Uninstall.ps1&nbsp;
&nbsp;
#&nbsp;Undeploy&nbsp;the&nbsp;applications&nbsp;
UndeployBizTalkApplications&nbsp;$oldApplications&nbsp;$oldVersions&nbsp;
&nbsp;
#&nbsp;Wait&nbsp;<span class="js__statement">for</span>&nbsp;user&nbsp;to&nbsp;<span class="js__statement">continue</span>&nbsp;
WaitForKeyPress&nbsp;
&nbsp;
#&nbsp;Uninstall&nbsp;the&nbsp;applications&nbsp;
UninstallBizTalkApplications&nbsp;$oldInstallersDirectory&nbsp;
&nbsp;
#&nbsp;Wait&nbsp;<span class="js__statement">for</span>&nbsp;user&nbsp;to&nbsp;<span class="js__statement">continue</span>&nbsp;
WaitForKeyPress&nbsp;
&nbsp;
#&nbsp;Install&nbsp;the&nbsp;applications&nbsp;
InstallBizTalkApplications&nbsp;$newInstallersDirectory&nbsp;
&nbsp;
#&nbsp;Wait&nbsp;<span class="js__statement">for</span>&nbsp;user&nbsp;to&nbsp;<span class="js__statement">continue</span>&nbsp;
WaitForKeyPress&nbsp;
&nbsp;
#&nbsp;Deploy&nbsp;the&nbsp;applications&nbsp;
DeployBizTalkApplications&nbsp;$newApplications&nbsp;$newVersions&nbsp;$newInstallersDirectory&nbsp;
&nbsp;
#&nbsp;Wait&nbsp;<span class="js__statement">for</span>&nbsp;user&nbsp;to&nbsp;exit&nbsp;
WaitForKeyPress</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>As you can see, using these PowerShell scripts you can setup scripts for your build and deployment processes very quickly. And by automating all these steps, we will have to spend much less time on builds and deployments, as we will only have to start our
 scripts, and the rest just goes automatically.</p>
