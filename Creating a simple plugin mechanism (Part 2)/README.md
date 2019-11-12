# Creating a simple plugin mechanism (Part 2)
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- Visual Basic .NET
- MEF
- Managed Extensibility Framework
- VB.Net
- Generics
- Plugin
## Topics
- MEF
- Managed Extensibility Framework
- Generics
- Plugin
## Updated
- 01/30/2019
## Description

<h1>Introduction</h1>
<p>This sample shows how to create your own simple plugin mechanism with MEF (Managed Extensibility Framework).</p>
<p>There are situations where you want to extend your application without changing existing code. So you need only to deliver new assemblies. Also other developers could extend your application. There are several mechanisms to solve this problem.</p>
<h1><span>Building the Sample</span></h1>
<p>Build first the Plugin projects</p>
<ul>
<li>FirstPlugin </li><li>SecondPlugin </li></ul>
<p>to ensure that the Plugins folder contains the plugin DLLs.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To solve this problem, we build up on the first part of creating a simple plugin mechanism
<a href="http://code.msdn.microsoft.com/Creating-a-simple-plugin-b6174b62">http://code.msdn.microsoft.com/Creating-a-simple-plugin-b6174b62</a>. As in the first part plugins are searched and loaded from a predefined location. The created plugins are projects
 in form of built assemblies (DLLs).</p>
<p>We are using the same Interface that all plugins must implement as in the first part.<em>
<br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;PluginContracts&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IPlugin&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Do();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>In the source of the plugins that we want to provide, we have to make our first changes. We have to add the reference to <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.Composition.aspx" target="_blank" title="Auto generated link to System.ComponentModel.Composition">System.ComponentModel.Composition</a> and using System.ComponentModel.Composition. Now we can mark the class with the Export attribute. So
 the MEF will later find and process this class. Furthermore the type is explicit stated. Hence we want to use the interface rather than the concrete class in the main project.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.Composition.aspx" target="_blank" title="Auto generated link to System.ComponentModel.Composition">System.ComponentModel.Composition</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;PluginContracts;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;FirstPlugin&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Export(<span class="cs__keyword">typeof</span>(IPlugin))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;FirstPlugin&nbsp;:&nbsp;IPlugin&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;IPlugin&nbsp;Members</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;First&nbsp;Plugin&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Do()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.MessageBox.Show.aspx" target="_blank" title="Auto generated link to System.Windows.MessageBox.Show">System.Windows.MessageBox.Show</a>(<span class="cs__string">&quot;Do&nbsp;Something&nbsp;in&nbsp;First&nbsp;Plugin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">This is all we have to do, to provide a plugin in MEF. But so that this works, we need to implement the mechanism in our main application that knows how to find and how to handle the plugins. For that we are using methods provided
 by MEF.</div>
<p class="endscriptcode">So that we can use the Export marked parts, we have to mark properties with the Import attribute. In our case we want to use several exported parts, so we are using the ImportMany attribute.</p>
<p class="endscriptcode">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">[ImportMany]&nbsp;
<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;IPlugin&gt;&nbsp;Plugins&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Last we need to search for the exported and imported parts and compose them. As in the first part we specify a folder in that all plugins are put in.</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;MEFPluginLoader(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;
{&nbsp;
&nbsp;&nbsp;DirectoryCatalog&nbsp;directoryCatalog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryCatalog(path);&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__com">//An&nbsp;aggregate&nbsp;catalog&nbsp;that&nbsp;combines&nbsp;multiple&nbsp;catalogs</span>&nbsp;
&nbsp;&nbsp;var&nbsp;catalog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AggregateCatalog(directoryCatalog);&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;CompositionContainer&nbsp;with&nbsp;all&nbsp;parts&nbsp;in&nbsp;the&nbsp;catalog&nbsp;(links&nbsp;Exports&nbsp;and&nbsp;Imports)</span>&nbsp;
&nbsp;&nbsp;_Container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CompositionContainer(catalog);&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__com">//Fill&nbsp;the&nbsp;imports&nbsp;of&nbsp;this&nbsp;object</span>&nbsp;
&nbsp;&nbsp;_Container.ComposeParts(<span class="cs__keyword">this</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">So far we have searched and initialized our plugins, so we can use the implemented properties and methods of our plugins as in the first part. To access our plugins we use the implemented MEFPluginLoader.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">MEFPluginLoader&nbsp;loader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MEFPluginLoader(<span class="cs__string">&quot;Plugins&quot;</span>);&nbsp;
IEnumerable&lt;IPlugin&gt;&nbsp;plugins&nbsp;=&nbsp;loader.Plugins;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;All other things can be borrowed from the first part.</div>
<h2>Improvement</h2>
<p>So that we do not need to implement for each new solution its own plugin loader, we use as in the first part Generics. This allows us to remove the dependence from a certain plugin interface (here IPlugin).</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name MEFPluginLoader.cs - searches and loads plugins..</em>
</li><li><em><em>source code file name MEFGenericPluginLoader.cs - generic version of PluginLoader.</em></em>
</li><li><em><em>source code file name MainWindow.xaml.cs - making plugins in gui available.</em></em>
</li><li><em><em>source code file name IPlugin.cs - interface for plugin implementation.</em></em>
</li><li><em><em>source code file name FirstPlugin.cs - first plugin implementation.</em></em>
</li><li><em><em>source code file name SecondPlugin.cs - second plugin implementation.</em></em>
</li></ul>
<h1>More Information</h1>
<p><strong>For further code samples visit <em><a href="http://chrigas.blogspot.com/">http://chrigas.blogspot.com/</a></em></strong></p>
<p>For more information on the first part (Creating a simple plugin mechanism), see
<a href="http://code.msdn.microsoft.com/Creating-a-simple-plugin-b6174b62">http://code.msdn.microsoft.com/Creating-a-simple-plugin-b6174b62</a></p>
<p>For more information on the extended part (Creating a simple plugin mechanism (extended)), see
<a href="https://code.msdn.microsoft.com/Creating-a-simple-plugin-5fc67c9a">https://code.msdn.microsoft.com/Creating-a-simple-plugin-5fc67c9a</a></p>
<p>For more information on MEF, see <a href="http://msdn.microsoft.com/en-us/library/vstudio/dd460648.aspx">
http://msdn.microsoft.com/en-us/library/vstudio/dd460648.aspx</a>, <a href="http://mef.codeplex.com/">
http://mef.codeplex.com/</a>, and <a href="http://msdn.microsoft.com/en-us/library/vstudio/system.componentmodel.composition.aspx">
http://msdn.microsoft.com/en-us/library/vstudio/system.componentmodel.composition.aspx</a></p>
<a href="http://msdn.microsoft.com/en-us/library/vstudio/system.componentmodel.composition.aspx"></a>For more information on Generics, see
<a href="http://msdn.microsoft.com/en-us/library/512aeb7t.aspx">http://msdn.microsoft.com/en-us/library/512aeb7t.aspx</a>,
<a href="http://msdn.microsoft.com/en-us/library/ms172192.aspx">http://msdn.microsoft.com/en-us/library/ms172192.aspx</a>, and
<a href="http://msdn.microsoft.com/en-us/library/system.collections.generic.aspx ">
http://msdn.microsoft.com/en-us/library/system.collections.generic.aspx </a></div>
<div class="endscriptcode"></div>
