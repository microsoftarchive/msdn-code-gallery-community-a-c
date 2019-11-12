# Autocomplete TextBox in WPF (Using only .NET and WPF libraries)
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- WPF
- .NET Framework
- Windows Desktop App Development
## Topics
- UI Design
- AutoComplete
- Desktop and Web apps development
## Updated
- 05/30/2015
## Description

<h1>Introduction</h1>
<p><em>In this source sample I would show you how to add the autocomplete functionality to your WPF application's (TextBox control) using your own model data, .NET assemblies and WPF assemblies. There is no need to add any third-party NuGet package or any other
 .dll file. You can create your own after reading this post and by using the sample attached.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample was built, ran and used using <strong>Visual Studio 2013</strong> over
<strong>.NET framework 4.5</strong>. You can try it under your own environment and see the results. But the above are
<strong>recommended</strong>.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample gives an overview of how to create the functionality of autocomplete in WPF. Autocomplete function is based on the following,&nbsp;</em></p>
<ol>
<li><em>Query provided by the user<br>
It is the input that user has typed into the control.</em> </li><li><em>List or collection of data that we have at the moment.</em> </li><li><em>A conditional statement to check whether the object or item in our list has the content or not.</em>
</li></ol>
<p><em>Using this, we can create our own autocomplete feature for any textbox.First define the model that we are going to use, you can extract the model from an SQL Server database, from Microsoft Azure data sources or from any other custom file also. I used
 the following,&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;AutocompleteWpfSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Model&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;GetData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Afzaal&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Ahmad&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Zeeshan&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Daniyal&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Rizwan&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;John&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Doe&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Johanna&nbsp;Doe&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Pakistan&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Microsoft&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Programming&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Visual&nbsp;Studio&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Sofiya&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Rihanna&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(<span class="cs__string">&quot;Eminem&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><em>The above code would provide us the data required to complete the functionality. Now, adding the XAML controls would be like this. All we need is,&nbsp;</em></p>
<ol>
<li><em>A TextBox<br>
for user inputer&nbsp;</em> </li><li><em>A StackPanel<br>
for managing the TextBlocks being added</em> </li><li><em>A Border<br>
to separate the stuff from underground controlrs. </em><strong><em>Fancy stuff only</em></strong><em>.&nbsp;</em>
</li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;5,&nbsp;3,&nbsp;5,&nbsp;3&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">KeyUp</span>=<span class="xaml__attr_value">&quot;TextBox_KeyUp&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;textBox&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Border</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;298&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;150&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;1&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ScrollViewer</span>&nbsp;<span class="xaml__attr_name">VerticalScrollBarVisibility</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;resultStack&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ScrollViewer&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Border&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>Great, that completes the UI. You would see that I have also attached an event handler to handle the user input. That is to run when the user inputs a character, I would search for the match in my
<strong>Model</strong>. Have a look at the following C# code for the WPF application's Autocomplete feature.&nbsp;</em></div>
<p class="endscriptcode"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;TextBox_KeyUp(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;KeyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;found&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;border&nbsp;=&nbsp;(resultStack.Parent&nbsp;<span class="cs__keyword">as</span>&nbsp;ScrollViewer).Parent&nbsp;<span class="cs__keyword">as</span>&nbsp;Border;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;data&nbsp;=&nbsp;Model.GetData();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;query&nbsp;=&nbsp;(sender&nbsp;<span class="cs__keyword">as</span>&nbsp;TextBox).Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(query.Length&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Clear</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultStack.Children.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;border.Visibility&nbsp;=&nbsp;System.Windows.Visibility.Collapsed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;border.Visibility&nbsp;=&nbsp;System.Windows.Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Clear&nbsp;the&nbsp;list</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultStack.Children.Clear();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;the&nbsp;result</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;obj&nbsp;<span class="cs__keyword">in</span>&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(obj.ToLower().StartsWith(query.ToLower()))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;word&nbsp;starts&nbsp;with&nbsp;this...&nbsp;Autocomplete&nbsp;must&nbsp;work</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;addItem(obj);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;found&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!found)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultStack.Children.Add(<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;No&nbsp;results&nbsp;found.&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">&nbsp;<em>I also had the function to add the item to the StackPanel, showing that would be injustice. So here it is,&nbsp;</em></p>
<em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;addItem(<span class="cs__keyword">string</span>&nbsp;text)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBlock&nbsp;block&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;the&nbsp;text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;block.Text&nbsp;=&nbsp;text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;A&nbsp;little&nbsp;style...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;block.Margin&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness(<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;block.Cursor&nbsp;=&nbsp;Cursors.Hand;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Mouse&nbsp;events</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;block.MouseLeftButtonUp&nbsp;&#43;=&nbsp;(sender,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox.Text&nbsp;=&nbsp;(sender&nbsp;<span class="cs__keyword">as</span>&nbsp;TextBlock).Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;block.MouseEnter&nbsp;&#43;=&nbsp;(sender,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBlock&nbsp;b&nbsp;=&nbsp;sender&nbsp;<span class="cs__keyword">as</span>&nbsp;TextBlock;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Background&nbsp;=&nbsp;Brushes.PeachPuff;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;block.MouseLeave&nbsp;&#43;=&nbsp;(sender,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBlock&nbsp;b&nbsp;=&nbsp;sender&nbsp;<span class="cs__keyword">as</span>&nbsp;TextBlock;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Background&nbsp;=&nbsp;Brushes.Transparent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;to&nbsp;the&nbsp;panel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultStack.Children.Add(block);&nbsp;
}</pre>
</div>
</div>
</div>
</em>
<p></p>
<p class="endscriptcode"><em>The above code would now be able to add the new items to the list and would let the user chose which item to add to the TextBox.</em></p>
<h3 class="endscriptcode"><em>Note</em></h3>
<p><em>There are a lot of other UI changes that I have made. So, you can surely ignore them. Such as mouse enter and mouse leave event handling to change the background color.</em></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml -- This file contains the UI controls</em> </li><li><em>MainWindow.xaml.cs -- This file contains the background logic for the autocomplete tools.</em>
</li><li><em>Model.cs -- This is the model for our application. It has a static function for providing the list of values required for our project.</em>
</li><li><em>AutocompleteWithoutStackPanel.xaml -- Another page (with a different layout; same purpose and function)<br>
</em></li><li><em>AutocompleteWithoutStackPanel.xaml.cs -- Background logic for the above Window.<br>
</em></li></ul>
<h1>More Information</h1>
<p><em>Read MSDN resources for more on this topic. (Or read the upcoming article of mine on WPF tips soon...)</em></p>
