# Changing a WPF Button Background
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- Button
- Triggers
- WPF Styling
- WPF Control Templating
- Button Background
- ButtonChrome
## Updated
- 08/16/2012
## Description

<h1>Introduction</h1>
<div>If you want to change the background of a button, you will notice that the standard button loses it's background colour when the button is focussed, or the mouse pointer is over or clicking the button.</div>
<div></div>
<div><img id="64806" src="64806-buttonbackground.png" alt="" width="544" height="369" style="margin-right:auto; margin-left:auto; display:block"></div>
<div></div>
<div>This is a question that keeps coming up on the MSDN forums.</div>
<div>This sample shows the reasons for this, and how to overcome the problem.</div>
<div>&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div>Just download, unblock, unzip, open and run!</div>
<div>&nbsp;</div>
<h1><span style="font-size:20px">Description</span></h1>
<div>In this sample&nbsp;there are four buttons, from raw standard unstyled button, to the final solution.</div>
<div>&nbsp;</div>
<h2>1. Unstyled Button</h2>
<div>First let's have a look at the standard button, with a red background</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Button&nbsp;Click=<span class="js__string">&quot;Button_Click&quot;</span>&nbsp;Background=<span class="js__string">&quot;Red&quot;</span>&nbsp;Content=<span class="js__string">&quot;Button&nbsp;1&quot;</span>&nbsp;Margin=<span class="js__string">&quot;10,0,10,10&quot;</span>&nbsp;Width=<span class="js__string">&quot;100&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">When you hover, and click this button you will see that the red is lost. There must be some Triggers somewhere that are also changing the Background property under various conditions. Also, when it is focussed, it flashes.</div>
</div>
<div>&nbsp;</div>
<h2>2. Default Styled Button</h2>
<div>Using Expression Blend, I am able to extract the default style and template for the standard Button.</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Button&nbsp;Focusable=<span class="js__string">&quot;False&quot;</span>&nbsp;Click=<span class="js__string">&quot;Button_Click_1&quot;</span>&nbsp;Background=<span class="js__string">&quot;Red&quot;</span>&nbsp;Content=<span class="js__string">&quot;Button&nbsp;2&quot;</span>&nbsp;Margin=<span class="js__string">&quot;10,0,10,10&quot;</span>&nbsp;Style=<span class="js__string">&quot;{DynamicResource&nbsp;DefaultStyle}&quot;</span>&nbsp;Width=<span class="js__string">&quot;100&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Often you will find that the thing you need to change is just a tweak to the standard template, style or trigger. However, with the Button, we find that the trigger is not at Template level. What we find instead is the ButtonChrome:</div>
<div class="endscriptcode"></div>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Setter&nbsp;Property=<span class="js__string">&quot;Template&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter.Value&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate&nbsp;TargetType=<span class="js__string">&quot;{x:Type&nbsp;Button}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Microsoft_Windows_Themes:ButtonChrome&nbsp;x:Name=<span class="js__string">&quot;Chrome&quot;</span>&nbsp;BorderBrush=<span class="js__string">&quot;{TemplateBinding&nbsp;BorderBrush}&quot;</span>&nbsp;Background=<span class="js__string">&quot;{TemplateBinding&nbsp;Background}&quot;</span>&nbsp;RenderMouseOver=<span class="js__string">&quot;{TemplateBinding&nbsp;IsMouseOver}&quot;</span>&nbsp;RenderPressed=<span class="js__string">&quot;{TemplateBinding&nbsp;IsPressed}&quot;</span>&nbsp;RenderDefaulted=<span class="js__string">&quot;{TemplateBinding&nbsp;IsDefaulted}&quot;</span>&nbsp;SnapsToDevicePixels=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentPresenter&nbsp;HorizontalAlignment=<span class="js__string">&quot;{TemplateBinding&nbsp;HorizontalContentAlignment}&quot;</span>&nbsp;Margin=<span class="js__string">&quot;{TemplateBinding&nbsp;Padding}&quot;</span>&nbsp;RecognizesAccessKey=<span class="js__string">&quot;True&quot;</span>&nbsp;SnapsToDevicePixels=<span class="js__string">&quot;{TemplateBinding&nbsp;SnapsToDevicePixels}&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;{TemplateBinding&nbsp;VerticalContentAlignment}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Microsoft_Windows_Themes:ButtonChrome&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsKeyboardFocused&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;RenderDefaulted&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Chrome&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;ToggleButton.IsChecked&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;RenderPressed&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Chrome&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsEnabled&quot;</span>&nbsp;Value=<span class="js__string">&quot;false&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Foreground&quot;</span>&nbsp;Value=<span class="js__string">&quot;#ADADAD&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter.Value&gt;&nbsp;
&lt;/Setter&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div>It is the ButtonChrome that is doing the changes. in fact everything is contained inside the ButtonChrome, similar way that the Bullet of a Checkbox is responsible for it's own visual states.</div>
<div></div>
<div>We must therefore get rid of ButtonChrome. One way to do this is to edit this default template, and replace ButtonChrome with your own design for a button.</div>
</div>
<div></div>
<div>One thing I did do with this button is set <strong>Focusable=False</strong>, which stops it flashing, at least.&nbsp;</div>
<div></div>
<h2>3. &quot;Simple Style&quot; Button</h2>
<div>As I have Expression Blend, I am able to search for and use Blend's built in &quot;Simple Styles&quot;. When I click on assets and starttyping &quot;simple&quot;, I get the whole set of Simple styles (styles for all the standard controls) like SimpleButton.</div>
<div></div>
<div>When I select SimpleButton, the &quot;Simple Styles.xaml&quot; ResourceDictionary is added to my project and the new button uses that style:&nbsp;</div>
<div></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="csharp">&lt;Button&nbsp;Click=<span class="cs__string">&quot;Button_Click_2&quot;</span>&nbsp;Content=<span class="cs__string">&quot;Button&nbsp;3&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;10,0,10,10&quot;</span>&nbsp;Style=<span class="cs__string">&quot;{DynamicResource&nbsp;SimpleButton}&quot;</span>&nbsp;Background=<span class="cs__string">&quot;Red&quot;</span>&nbsp;Width=<span class="cs__string">&quot;100&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>/&gt;</pre>
</div>
</div>
</div>
<p>Now we can see all the triggers associated with the mouse events in the &quot;SimpleButton&quot; style, in &quot;Simple Styles.xaml&quot;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Setter&nbsp;Property=<span class="js__string">&quot;Template&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter.Value&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate&nbsp;TargetType=<span class="js__string">&quot;{x:Type&nbsp;Button}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;x:Name=<span class="js__string">&quot;Grid&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Border&nbsp;x:Name=<span class="js__string">&quot;Border&quot;</span>&nbsp;Background=<span class="js__string">&quot;{TemplateBinding&nbsp;Background}&quot;</span>&nbsp;BorderBrush=<span class="js__string">&quot;{TemplateBinding&nbsp;BorderBrush}&quot;</span>&nbsp;BorderThickness=<span class="js__string">&quot;{TemplateBinding&nbsp;BorderThickness}&quot;</span>&nbsp;Padding=<span class="js__string">&quot;{TemplateBinding&nbsp;Padding}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentPresenter&nbsp;HorizontalAlignment=<span class="js__string">&quot;{TemplateBinding&nbsp;HorizontalContentAlignment}&quot;</span>&nbsp;Margin=<span class="js__string">&quot;{TemplateBinding&nbsp;Padding}&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;{TemplateBinding&nbsp;VerticalContentAlignment}&quot;</span>&nbsp;RecognizesAccessKey=<span class="js__string">&quot;True&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsKeyboardFocused&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;BorderBrush&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;DefaultedBorderBrush}&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Border&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsMouseOver&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Background&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;MouseOverBrush}&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Border&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsPressed&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Background&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;PressedBrush}&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Border&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;BorderBrush&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;PressedBorderBrush}&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Border&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsEnabled&quot;</span>&nbsp;Value=<span class="js__string">&quot;true&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsEnabled&quot;</span>&nbsp;Value=<span class="js__string">&quot;false&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Background&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;DisabledBackgroundBrush}&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Border&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;BorderBrush&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;DisabledBorderBrush}&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Border&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Foreground&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;DisabledForegroundBrush}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter.Value&gt;&nbsp;
&lt;/Setter&gt;</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">4. Restyled and working!</h2>
<div class="endscriptcode"></div>
<div class="endscriptcode">So now we can see what is happening, we can fix it. Below I have copied the SimpleButton style and commented out the triggers.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Button&nbsp;Click=<span class="js__string">&quot;Button_Click_3&quot;</span>&nbsp;Content=<span class="js__string">&quot;Button&nbsp;4&quot;</span>&nbsp;Margin=<span class="js__string">&quot;10,0,10,10&quot;</span>&nbsp;Style=<span class="js__string">&quot;{DynamicResource&nbsp;CustomButtonStyle}&quot;</span>&nbsp;Background=<span class="js__string">&quot;Red&quot;</span>&nbsp;Width=<span class="js__string">&quot;100&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Setter</span>&nbsp;<span class="xaml__attr_name">Property</span>=<span class="xaml__attr_value">&quot;Template&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Setter</span>.Value<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ControlTemplate</span>&nbsp;<span class="xaml__attr_name">TargetType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;Button}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Grid&quot;</span>&nbsp;<span class="xaml__attr_name">Cursor</span>=<span class="xaml__attr_value">&quot;Hand&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Border</span>&nbsp;<span class="xaml__attr_name">CornerRadius</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Border&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;Background}&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;BorderBrush}&quot;</span>&nbsp;<span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;BorderThickness}&quot;</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;Padding}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ContentPresenter</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;HorizontalContentAlignment}&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;Padding}&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;VerticalContentAlignment}&quot;</span>&nbsp;<span class="xaml__attr_name">RecognizesAccessKey</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;Triggers&nbsp;removed&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ControlTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter.Value&gt;&nbsp;
<span class="xaml__tag_end">&lt;/Setter&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong>Now the Button stays Red.</strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Now however,&nbsp;you realiase the problem with changing the Button Background. There is no visual feedback to the user that the button is being interacted with.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">So ideally you would want to restore the Triggers, but just subtle changes like increasing button size slightly on MouseOver, reducing slightly on MouseDown, to give the effect of depressing the button.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">In&nbsp;this example, I just&nbsp;added Cursor=Hand, so you can at least see it is clickable. I also rounded the corners slightly to make it look more like the default button.</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml - Startup window</em> </li><li><em>Simple Styles.xaml - the magic resource dictionary, added by Expression Blend</em>
</li></ul>
<h1><em>&nbsp;</em></h1>
