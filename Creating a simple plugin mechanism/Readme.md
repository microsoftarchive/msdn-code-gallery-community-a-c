# Creating a simple plugin mechanism
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- Visual Basic .NET
- VB.Net
- Generics
- Plugin
- System.Reflection Namespace
## Topics
- Reflection
- Generics
- Plugin
## Updated
- 01/30/2019
## Description

<h1>Introduction</h1>
<p>This sample shows how to create your own simple plugin mechanism.</p>
<p>There are situations where you want to extend your application without changing existing code. So you need only to deliver new assemblies. Also other developers could extend your application. There are several mechanisms to solve this problem.</p>
<h1><span>Building the Sample</span></h1>
<p>Build first the Plugin projects</p>
<ul>
<li>FirstPlugin </li><li>SecondPlugin </li></ul>
<p>to ensure that the Plugins folder contains the plugin DLLs.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To solve this problem, a simple plugin mechanism is implemented that search and loads plugins from a predefined location. The created plugins are projects in form of built assemblies (DLLs).</p>
<p>First we need to define an Interface that all plugins must implement. This Interface is often included in an own project, so other developers only need the assembly of this project to write their own plugins.</p>
<p>The members of the Interface depend on what your application is intended to do. In this sample we have one property that is returning a name and one method that is doing something.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">namespace PluginContracts
{
	public interface IPlugin
	{
		string Name { get; }
		void Do();
	}
}
</pre>
<pre class="hidden">Public Interface IPlugin
    ReadOnly Property Name() As String
    Sub DoSomething()
End Interface</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;PluginContracts&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IPlugin&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Do();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>To provide a plugin, you have to create a new project and add a reference to PluginContracts. Then you have to implement IPlugin</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using PluginContracts;

namespace FirstPlugin
{
	public class FirstPlugin : IPlugin
	{
		#region IPlugin Members

		public string Name
		{
			get
			{
				return &quot;First Plugin&quot;;
			}
		}

		public void Do()
		{
			System.Windows.MessageBox.Show(&quot;Do Something in First Plugin&quot;);
		}

		#endregion
	}
}
</pre>
<pre class="hidden">Imports PluginContracts

Public Class FirstPlugin
    Implements IPlugin


    Public Sub DoSomething() Implements IPlugin.DoSomething
        System.Windows.MessageBox.Show(&quot;Do Something in First Plugin&quot;)
    End Sub

    Public ReadOnly Property Name As String Implements IPlugin.Name
        Get
            Name = &quot;First Plugin&quot;
        End Get
    End Property
End Class</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;PluginContracts;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;FirstPlugin&nbsp;
{&nbsp;
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.MessageBox.Show(<span class="cs__string">&quot;Do&nbsp;Something&nbsp;in&nbsp;First&nbsp;Plugin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This is all you have to do, to provide a plugin. But so that this works, we need to implement the framework in our main application that knows how to find and how to handle the plugins.</div>
<p>First of all we have to know where to search for plugins. Usually we will specify a folder in that all plugins are put in. In this folder we search for all assemblies.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">string[] dllFileNames = null;
if(Directory.Exists(path))
{
  dllFileNames = Directory.GetFiles(path, &quot;*.dll&quot;);
}</pre>
<pre class="hidden">        Dim dllFileNames As String()

        If Directory.Exists(path) Then
            dllFileNames = Directory.GetFiles(path, &quot;*.dll&quot;)
        End If</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>[]&nbsp;dllFileNames&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
<span class="cs__keyword">if</span>(Directory.Exists(path))&nbsp;
{&nbsp;
&nbsp;&nbsp;dllFileNames&nbsp;=&nbsp;Directory.GetFiles(path,&nbsp;<span class="cs__string">&quot;*.dll&quot;</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">&nbsp;Next we have to load the assemblies. Therefore we are using Reflections (System.Reflection).</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">ICollection&lt;Assembly&gt; assemblies = new List&lt;Assembly&gt;(dllFileNames.Length);
foreach(string dllFile in dllFileNames)
{
  AssemblyName an = GetAssemblyName(dllFile);
  Assembly assembly = Assembly.Load(an);
  assemblies.Add(assembly);
}</pre>
<pre class="hidden">            Dim assemblies As ICollection(Of Assembly) = New List(Of Assembly)(dllFileNames.Length)
            For Each dllFile As String In dllFileNames
                Dim an As AssemblyName = AssemblyName.GetAssemblyName(dllFile)
                Dim assembly As Assembly = assembly.Load(an)
                assemblies.Add(assembly)
            Next</pre>
<div class="preview">
<pre class="csharp">ICollection&lt;Assembly&gt;&nbsp;assemblies&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Assembly&gt;(dllFileNames.Length);&nbsp;
<span class="cs__keyword">foreach</span>(<span class="cs__keyword">string</span>&nbsp;dllFile&nbsp;<span class="cs__keyword">in</span>&nbsp;dllFileNames)&nbsp;
{&nbsp;
&nbsp;&nbsp;AssemblyName&nbsp;an&nbsp;=&nbsp;GetAssemblyName(dllFile);&nbsp;
&nbsp;&nbsp;Assembly&nbsp;assembly&nbsp;=&nbsp;Assembly.Load(an);&nbsp;
&nbsp;&nbsp;assemblies.Add(assembly);&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">&nbsp;Now we have loaded all assemblies from our predefined location, we can search for all types that implement our Interface IPlugin.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">Type pluginType = typeof(IPlugin);
ICollection&lt;Type&gt; pluginTypes = new List&lt;Type&gt;();
foreach(Assembly assembly in assemblies)
{
  if(assembly != null)
  {
    Type[] types = assembly.GetTypes();
    foreach(Type type in types)
    {
      if(type.IsInterface || type.IsAbstract)
      {
        continue;
      }
      else
      {
        if(type.GetInterface(pluginType.FullName) != null)
        {
          pluginTypes.Add(type);
        }
      }
    }
  }
}</pre>
<pre class="hidden">            Dim pluginType As Type = GetType(IPlugin)
            Dim pluginTypes As ICollection(Of Type) = New List(Of Type)
            For Each assembly As Assembly In assemblies
                If assembly &lt;&gt; Nothing Then
                    Dim types As Type() = assembly.GetTypes()

                    For Each type As Type In types
                        If type.IsInterface Or type.IsAbstract Then
                            Continue For
                        Else
                            If type.GetInterface(pluginType.FullName) &lt;&gt; Nothing Then
                                pluginTypes.Add(type)
                            End If
                        End If
                    Next
                End If
            Next</pre>
<div class="preview">
<pre class="csharp">Type&nbsp;pluginType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(IPlugin);&nbsp;
ICollection&lt;Type&gt;&nbsp;pluginTypes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Type&gt;();&nbsp;
<span class="cs__keyword">foreach</span>(Assembly&nbsp;assembly&nbsp;<span class="cs__keyword">in</span>&nbsp;assemblies)&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">if</span>(assembly&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Type[]&nbsp;types&nbsp;=&nbsp;assembly.GetTypes();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>(Type&nbsp;type&nbsp;<span class="cs__keyword">in</span>&nbsp;types)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(type.IsInterface&nbsp;||&nbsp;type.IsAbstract)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(type.GetInterface(pluginType.FullName)&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pluginTypes.Add(type);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Last we create instances from our found types using Reflections.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">ICollection&lt;IPlugin&gt; plugins = new List&lt;IPlugin&gt;(pluginTypes.Count);
foreach(Type type in pluginTypes)
{
  IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
  plugins.Add(plugin);
}</pre>
<pre class="hidden">            Dim plugins As ICollection(Of IPlugin) = New List(Of IPlugin)(pluginTypes.Count)
            For Each type As Type In pluginTypes
                Dim plugin As IPlugin = Activator.CreateInstance(type)
                plugins.Add(plugin)
            Next</pre>
<div class="preview">
<pre class="csharp">ICollection&lt;IPlugin&gt;&nbsp;plugins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;IPlugin&gt;(pluginTypes.Count);&nbsp;
<span class="cs__keyword">foreach</span>(Type&nbsp;type&nbsp;<span class="cs__keyword">in</span>&nbsp;pluginTypes)&nbsp;
{&nbsp;
&nbsp;&nbsp;IPlugin&nbsp;plugin&nbsp;=&nbsp;(IPlugin)Activator.CreateInstance(type);&nbsp;
&nbsp;&nbsp;plugins.Add(plugin);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;So far we have searched and initialized our plugins, so we can use the implemented properties and methods of our plugins. To demonstrate that, we create a button for each loaded plugin and connect the content and the click
 event of the button to the property and the method of the plugin.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">_Plugins = new Dictionary&lt;string, IPlugin&gt;();
ICollection&lt;IPlugin&gt; plugins = PluginLoader.LoadPlugins(&quot;Plugins&quot;);
foreach(var item in plugins)
{
  _Plugins.Add(item.Name, item);
  Button b = new Button();
  b.Content = item.Name;
  b.Click &#43;= b_Click;
  PluginGrid.Children.Add(b);
}</pre>
<pre class="hidden">        _Plugins = New Dictionary(Of String, IPlugin)
        Dim plugins As ICollection(Of IPlugin) = PluginLoader.LoadPlugins(&quot;Plugins&quot;)

        If plugins Is Nothing Then
            Close()
            System.Windows.MessageBox.Show(&quot;No plugins loaded. Application Closed.&quot;)
            Return
        End If

        For Each item In plugins
            _Plugins.Add(item.Name, item)

            Dim b = New Button With {
                .Content = item.Name}
            AddHandler b.Click, AddressOf b_Click
            PluginGrid.Children.Add(b)
        Next</pre>
<div class="preview">
<pre class="csharp">_Plugins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;IPlugin&gt;();&nbsp;
ICollection&lt;IPlugin&gt;&nbsp;plugins&nbsp;=&nbsp;PluginLoader.LoadPlugins(<span class="cs__string">&quot;Plugins&quot;</span>);&nbsp;
<span class="cs__keyword">foreach</span>(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;plugins)&nbsp;
{&nbsp;
&nbsp;&nbsp;_Plugins.Add(item.Name,&nbsp;item);&nbsp;
&nbsp;&nbsp;Button&nbsp;b&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Button();&nbsp;
&nbsp;&nbsp;b.Content&nbsp;=&nbsp;item.Name;&nbsp;
&nbsp;&nbsp;b.Click&nbsp;&#43;=&nbsp;b_Click;&nbsp;
&nbsp;&nbsp;PluginGrid.Children.Add(b);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">We are using a Dictionary with the name of the plugin as key to memorize, which button content belongs to which plugin. So we can execute the correct plugin method on certain button click.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private void b_Click(object sender, RoutedEventArgs e)
{
  Button b = sender as Button;
  if(b != null)
  {
    string key = b.Content.ToString();
    if(_Plugins.ContainsKey(key))
    {
      IPlugin plugin = _Plugins[key];
      plugin.Do();
    }
  }
}</pre>
<pre class="hidden">    Private Sub b_Click(sender As Object, e As RoutedEventArgs)
        Dim b As Button = sender
        If b IsNot Nothing Then
            Dim key As String = b.Content.ToString()
            If _Plugins.ContainsKey(key) Then
                Dim plugin As IPlugin = _Plugins(key)
                plugin.DoSomething()
            End If
        End If
    End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;b_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;Button&nbsp;b&nbsp;=&nbsp;sender&nbsp;<span class="cs__keyword">as</span>&nbsp;Button;&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">if</span>(b&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;key&nbsp;=&nbsp;b.Content.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(_Plugins.ContainsKey(key))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPlugin&nbsp;plugin&nbsp;=&nbsp;_Plugins[key];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;plugin.Do();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h2>Improvement</h2>
<p>So that we do not need to implement for each new solution its own plugin loader, we use Generics. This allows us to remove the dependence from a certain plugin interface (here IPlugin).</p>
<p>With that we could also use the same plugin loader to resolove several types of plugins in the same project. So we could have an ICalculationPlugin, IExporterPlugin, ISomethingElsePlugin. All these plugin interfaces can have their own properties and methods.
 They can be accessed from different places in different cases.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name PluginLoader.cs - searches and loads plugins..</em>
</li><li><em><em>source code file name GenericPluginLoader.cs - generic version of PluginLoader.</em></em>
</li><li><em><em>source code file name MainWindow.xaml.cs - making plugins in gui available.</em></em>
</li><li><em><em>source code file name IPlugin.cs - interface for plugin implementation.</em></em>
</li><li><em><em>source code file name FirstPlugin.cs - first plugin implementation.</em></em>
</li><li><em><em>source code file name SecondPlugin.cs - second plugin implementation.</em></em>
</li></ul>
<h1>More Information</h1>
<p><strong>For further code samples visit <em><a href="http://chrigas.blogspot.de/2013/12/sorting-evolution-1.html"></a><a href="http://chrigas.blogspot.com/">http://chrigas.blogspot.com/</a></em></strong></p>
<p>For more information on the second part (Creating a simple plugin mechanism (2)), see
<a href="https://code.msdn.microsoft.com/windowsdesktop/Creating-a-simple-plugin-b45f1d4e">
https://code.msdn.microsoft.com/windowsdesktop/Creating-a-simple-plugin-b45f1d4e</a></p>
<p>For more information on the extended part (Creating a simple plugin mechanism (extended)), see
<a href="https://code.msdn.microsoft.com/Creating-a-simple-plugin-5fc67c9a">https://code.msdn.microsoft.com/Creating-a-simple-plugin-5fc67c9a</a></p>
<p>For more information on Reflection, see <a href="http://msdn.microsoft.com/en-us/library/f7ykdhsy.aspx">
http://msdn.microsoft.com/en-us/library/f7ykdhsy.aspx</a> and <a href="http://msdn.microsoft.com/en-us/library/system.reflection.aspx">
http://msdn.microsoft.com/en-us/library/system.reflection.aspx</a></p>
<p>For more information on Generics, see <a href="http://msdn.microsoft.com/en-us/library/512aeb7t.aspx">
http://msdn.microsoft.com/en-us/library/512aeb7t.aspx</a>, <a href="http://msdn.microsoft.com/en-us/library/ms172192.aspx">
http://msdn.microsoft.com/en-us/library/ms172192.aspx</a>, and <a href="http://msdn.microsoft.com/en-us/library/system.collections.generic.aspx ">
http://msdn.microsoft.com/en-us/library/system.collections.generic.aspx </a></p>
