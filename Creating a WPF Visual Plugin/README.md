# Creating a WPF Visual Plugin
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- Managed Extensibility Framework
- Plugin
## Topics
- Graphics
- MEF
- Managed Extensibility Framework
- Plug-in
- Plugin
## Updated
- 05/27/2014
## Description

<h1>Description</h1>
<p>Make 1 WPF App and 2 Plug-ins first, then create setting pane for each Plug-in.</p>
<p>&nbsp;</p>
<h1><span>Project structure</span></h1>
<h3>VisualPlugin.UI</h3>
<p>This is a Main WPF App. It supports loading Plug-ins, showing infomration of Plug-in and calling settings screen.</p>
<p>&nbsp;</p>
<h3>VisualPlugin.Interfaces</h3>
<p>Interface for Plug-in.</p>
<p>I will show you the simple example of Interface for below members.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IVisualPlugin&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;name&nbsp;of&nbsp;Plug-in.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Do&nbsp;something&nbsp;for&nbsp;Plug-in&nbsp;execution.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Proc();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Method&nbsp;that&nbsp;returns&nbsp;Plug-in&nbsp;setting&nbsp;screen.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;GetSettingsView();&nbsp;
}</pre>
</div>
</div>
</div>
<h3>VisualPlugin.Visuals</h3>
<p>This prohect will define UI theme, like common use of colors or fonts.</p>
<p>The Main of WPF application(VisualPlugin.UI) and each of Plug-in will refer this to create unified view.&nbsp;</p>
<p>If you are developing with some UI libraries, ex &quot;MahApps.Metro&quot;, then you don't need this project.</p>
<p>&nbsp;</p>
<h3>VisualPlugin.Sample1 / Sample2</h3>
<p>Plug-in smaples.</p>
<p>Sample 1, Proc() will show Message box.</p>
<p>Sample 2, Proc() will show new window and the path of picture you set.</p>
<p>&nbsp;</p>
<h1>Explanation</h1>
<p>This section explains show Plug-in retrun view. Please refer the detail of MEF with Microsoft referenece &quot;Managed Extensibility Framework&quot;.</p>
<p>&nbsp;</p>
<h3>Plug-in side</h3>
<p>Setting screeb is defined as User Control with Sample1, Sample2 projects.User Control merges each resources in VisualPlugin.Visuals. This will unify View with the Main of WPF application (VisualPlugin.UI).</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;UserControl</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ResourceDictionary</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ResourceDictionary</span>.MergedDictionaries<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ResourceDictionary</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;pack://application:,,,/VisualPlugin.Visuals;component/Styles/Brushes.xaml&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ResourceDictionary</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;pack://application:,,,/VisualPlugin.Visuals;component/Styles/Buttons.xaml&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ResourceDictionary</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;pack://application:,,,/VisualPlugin.Visuals;component/Styles/Fonts.xaml&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ResourceDictionary.MergedDictionaries&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ResourceDictionary&gt;</span>&nbsp;
&lt;/UserControl.Resources&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">See below for how Plug-in itself configured.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;GetSettingsView()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Settings&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContext&nbsp;=&nbsp;<span class="cs__keyword">this</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Create User Control of Setting screen and return it.Why I programed as this? Because there are advantages with creating User Control by Calling side, means WPF Main Application(VisualPlugin.UI). You'll find this style prevent any
 trouble with thread and others easier. &nbsp;Pass &quot;instance of Plug-in&quot; directly or through ViewModel, to the newly created User Control's DataContext. &nbsp; &nbsp;You can change Plug-in behaivors loaded into WPF Application, VisualPlugin.UI, immediately.</div>
<div class="endscriptcode"></div>
<h3 class="endscriptcode">Main WPF Application side</h3>
<p>First, ViewModel provides Setting Screen as property.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PluginViewModel&nbsp;:&nbsp;ViewModel&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;_settingsView;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IVisualPlugin&nbsp;Plugin&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;SettingsView&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>._settingsView&nbsp;??&nbsp;(<span class="cs__keyword">this</span>._settingsView&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Plugin.GetSettingsView());&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;PluginViewModel(IVisualPlugin&nbsp;plugin)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Plugin&nbsp;=&nbsp;plugin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">SettingsView is the property.</div>
<div class="endscriptcode"></div>
Second, View uses ContentPresenter to display items of SettingsView. &nbsp;
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;ContentPresenter&nbsp;Content=<span class="js__string">&quot;{Binding&nbsp;SettingsView}&quot;</span>&nbsp;/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">ContentPresenter dscides what to display with value of Content property or somthing like ContentTemplate Property. (Refer explanation of MSDN for deital logics.)If Plug-in's GetSettingsView() method can returns User Control (UI
 Element), the User Control itself will be display.</div>
<p>&nbsp;</p>
<h1>Execution Result</h1>
<p>First, output list of Plug-ins that WPF Application had been loaded. &nbsp;</p>
<p><img id="115510" src="115510-ss140525224820kd.png" alt="" width="525" height="350"></p>
<p><br>
Then press [Settings] button to show the Settings screen.</p>
<p>For example, following UserControl will be.....</p>
<p><img id="115511" src="115511-ss140525223859kd.png" alt="" width="919" height="942"></p>
<p>&nbsp;</p>
<p>Display like this:) Style is also used!</p>
<p><img id="115512" src="115512-ss140525224936kd.png" alt="" width="434" height="232"></p>
<p><br>
What you changed in Plug-in Settings screen will be refrected immediately, to the WPF application which loaded this Plug-in.&nbsp;</p>
<p><img id="115513" src="115513-ss140525232132kd.png" alt="" width="614" height="410"></p>
</div>
