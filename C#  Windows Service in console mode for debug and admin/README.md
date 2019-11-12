# C# : Windows Service in console mode for debug and admin
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Windows Service
## Topics
- Windows Service
## Updated
- 05/03/2015
## Description

<h1>Introduction</h1>
<p>Voici le code source pour l'exemple de l'article Wiki Technet :&nbsp;<a href="http://social.technet.microsoft.com/wiki/contents/articles/30956.c-service-windows-en-mode-console-pour-le-debogage-et-l-administration-fr-fr.aspx">C# : Service Windows en mode
 console pour le d&eacute;bogage et l'administration</a>.</p>
<h1><span>Compiler l'exemple</span></h1>
<p>Pour compiler cet exemple il faut Visual Studio 2013.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>L'article Technet propose une solution pour faciliter le d&eacute;bogage et l'administration de Service Windows cr&eacute;&eacute; en C#/.Net.</p>
<p>L'id&eacute;e est de convertir le Service Windows en application console pour apporter les fonctionnalit&eacute;s suivantes.</p>
<h2>D&eacute;boguer le Service Windows</h2>
<p>Lorsque l'on d&eacute;tecte le mode d&eacute;bogage, nous simmulons l'ex&eacute;cution du service. Ce qui nous permet de d&eacute;boguer le d&eacute;marrage du service, ce qui n'est pas possible lorsque nous attachons le d&eacute;bogueur au service. Pour
 cel&agrave; nous d&eacute;tectons si nous avons un d&eacute;bogueur attach&eacute; et si nous somme en mode interactif:</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;On&nbsp;est&nbsp;en&nbsp;mode&nbsp;int&eacute;ractif&nbsp;et&nbsp;d&eacute;bogage&nbsp;?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Environment.UserInteractive&nbsp;&amp;&amp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/fr-FR/library/System.Diagnostics.Debugger.IsAttached.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Debugger.IsAttached">System.Diagnostics.Debugger.IsAttached</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Simule&nbsp;l'ex&eacute;cution&nbsp;des&nbsp;services</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RunInteractiveServices(ServicesToRun);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Ex&eacute;cute&nbsp;les&nbsp;services&nbsp;normalement</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceBase.Run(ServicesToRun);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&quot;RunInteractiveServices&quot; est une m&eacute;thode qui d&eacute;marre l'ex&eacute;cution du service.</div>
</div>
<h2>Gestion des Services</h2>
<p>Pour aider dans l'administration du service, nous utilisons l'application console pour utiliser des commands dans les arguments pour installer, d&eacute;sinstaller, d&eacute;marrer et arr&ecirc;ter le service. Pour installer et d&eacute;marrer un service
 nous devons normallement ex&eacute;cuter les lignes de commande suivantes:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Bash/shell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">bash</span>

<div class="preview">
<pre class="bash"><span class="bash__string">&quot;%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe&quot;</span>&nbsp;WinServiceTest.exe&nbsp;
net&nbsp;start&nbsp;<span class="bash__string">&quot;My&nbsp;Service&quot;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">et pour arr&ecirc;ter et d&eacute;sinstaller</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Bash/shell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">bash</span>

<div class="preview">
<pre class="bash">net&nbsp;stop&nbsp;<span class="bash__string">&quot;My&nbsp;Service&quot;</span>&nbsp;
<span class="bash__string">&quot;%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe&quot;</span>&nbsp;/u&nbsp;WinServiceTest.exe&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Donc en utilisant des arguments avec notre application console, nous pouvons faire cela de mani&egrave;re plus simple:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Bash/shell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">bash</span>

<div class="preview">
<pre class="js">WinServiceTest.exe&nbsp;install&nbsp;start&nbsp;
WinServiceTest.exe&nbsp;uninstall&nbsp;stop&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Pour faire ca nous utilisons les classes 'ManagedClass' et 'ServiceController'.&nbsp;</div>
&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;On&nbsp;a&nbsp;une&nbsp;commande&nbsp;d'installation&nbsp;?</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(HasCommand(args,&nbsp;<span class="cs__string">&quot;install&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ManagedInstallerClass.InstallHelper(<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__keyword">typeof</span>(Program).Assembly.Location&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hasCommands&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
}&nbsp;
<span class="cs__com">//&nbsp;On&nbsp;a&nbsp;une&nbsp;commande&nbsp;de&nbsp;d&eacute;marrage&nbsp;?</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(HasCommand(args,&nbsp;<span class="cs__string">&quot;start&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;service&nbsp;<span class="cs__keyword">in</span>&nbsp;ServicesToRun)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceController&nbsp;sc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceController(service.ServiceName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.WaitForStatus(ServiceControllerStatus.Running,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">10</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hasCommands&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
}&nbsp;
<span class="cs__com">//&nbsp;On&nbsp;a&nbsp;une&nbsp;commande&nbsp;d'arr&ecirc;t&nbsp;?</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(HasCommand(args,&nbsp;<span class="cs__string">&quot;stop&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;service&nbsp;<span class="cs__keyword">in</span>&nbsp;ServicesToRun)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceController&nbsp;sc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceController(service.ServiceName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.Stop();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.WaitForStatus(ServiceControllerStatus.Stopped,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">10</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hasCommands&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
}&nbsp;
<span class="cs__com">//&nbsp;On&nbsp;a&nbsp;une&nbsp;commande&nbsp;de&nbsp;d&eacute;sintallation&nbsp;?</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(HasCommand(args,&nbsp;<span class="cs__string">&quot;uninstall&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ManagedInstallerClass.InstallHelper(<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__string">&quot;/u&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(Program).Assembly.Location&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hasCommands&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Le dossier &quot;<strong>Article</strong>&quot; : contient la base des articles Wiki Technet fran&ccedil;ais et anglais.
</li><li>Le dossier &quot;<strong>WinServiceTest\WinServiceTest</strong>&quot; est le code source du projet en fran&ccedil;ais.
</li><li>Le dossier &quot;<strong>WinServiceTest\WinServiceTest-en</strong>&quot; est le code source du projet en anglais.
</li><li>La solution &quot;<strong>WinServiceTest\WinServiceTest.sln</strong>&quot; la soution qui contient les deux projets.
</li></ul>
<h1>Plus d'Information</h1>
<p>La description compl&egrave;te du code source se trouve dans l'article Wiki Technet&nbsp;<a href="http://social.technet.microsoft.com/wiki/contents/articles/30956.c-service-windows-en-mode-console-pour-le-debogage-et-l-administration-fr-fr.aspx">C# : Service
 Windows en mode console pour le d&eacute;bogage et l'administration</a>.</p>
