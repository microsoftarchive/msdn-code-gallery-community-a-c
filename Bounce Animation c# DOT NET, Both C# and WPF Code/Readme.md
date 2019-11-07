# Bounce Animation c# DOT NET, Both C# and WPF Code
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- Silverlight and XAML
- WPF Basics
- XAML and HTML conversions
- WPF Silverlight Webbrowser and Webclient
- WPF Data Binding
- WPF Commanding
- Bing Maps Control for WPF
- WPF CustomControl
- XAML Control Templates
- WPF Path XAML ResourceDictionary Cogweel
- XAML / Control Conversion
- XAML Data Triggers
- XAML Styles
- XAML MultiBinding
- WPF Styling
- WPF Control Templating
- XAML Resources
- WPF Binding
- XAML Markup
- Xaml Parse
## Updated
- 09/02/2012
## Description

<p><strong><a href="http://webeasyforall.blogspot.com/" target="_blank">Bounce Class in c#</a></strong></p>
<p>The Bounce class defines three easing functions to implement bounce motion with Flex effect classes.</p>
<p><a href="http://webeasyforall.blogspot.com/" target="_blank"><strong>easeIn</strong></a>(t:Number, b:Number, c:Number, d:Number):Number</p>
<p>[static] The&nbsp;easeIn()&nbsp;method starts the bounce motion slowly, and then accelerates motion as it executes.</p>
<p><a href="http://webeasyforall.blogspot.com/" target="_blank"><strong>easeInOut</strong></a>(t:Number, b:Number, c:Number, d:Number):Number</p>
<p>[static] The&nbsp;easeInOut()&nbsp;method combines the motion of the&nbsp;easeIn()&nbsp;and&nbsp;easeOut()&nbsp;methods to start the bounce motion slowly, accelerate motion, then decelerate.</p>
<p><a href="http://webeasyforall.blogspot.com/" target="_blank"><strong>easeOut</strong></a>(t:Number, b:Number, c:Number, d:Number):Number</p>
<p>[static] The&nbsp;easeOut()&nbsp;method starts the bounce motion fast, and then decelerates motion as it executes.</p>
<p><strong>Video:</strong></p>
<p>&nbsp;</p>
<p><a title="Collapse" href="http://webeasyforall.blogspot.com/" target="_blank"><strong>Properties</strong></a></p>
<p>&nbsp;</p>
<table border="1" cellspacing="0" cellpadding="0" width="1293">
<tbody>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">Bounces</a></p>
</td>
<td valign="top">
<p>Gets or sets the number of bounces.</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">Bounciness</a></p>
</td>
<td valign="top">
<p>Gets or sets a value that specifies how bouncy the bounce animation is.</p>
<p>Low values of this property result in bounces with little lose of height</p>
<p>between bounces (more bouncy) while high values result in dampened bounces (less bouncy).</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">CanFreeze</a></p>
</td>
<td valign="top">
<p>Gets a value that indicates whether the object can be made unmodifiable.&nbsp;</p>
<p>(Inherited from&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">Freezable</a>.)</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">DependencyObjectType</a></p>
</td>
<td valign="top">
<p>Gets the&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">DependencyObjectType</a>&nbsp;that wraps the CLR type of this instance.&nbsp;&nbsp;</p>
<p>(Inherited from&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">DependencyObject</a>.)</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">Dispatcher</a></p>
</td>
<td valign="top">
<p>Gets the&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">Dispatcher</a>&nbsp;this&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">DispatcherObject</a>&nbsp;is associated with.&nbsp;</p>
<p>(Inherited from&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">DispatcherObject</a>.)</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">EasingMode</a></p>
</td>
<td valign="top">
<p>Gets or sets a value that specifies how the animation interpolates.</p>
<p>&nbsp;(Inherited from&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">EasingFunctionBase</a>.)</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">IsFrozen</a></p>
</td>
<td valign="top">
<p>Gets a value that indicates whether the object is currently modifiable.</p>
<p>&nbsp;(Inherited from&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">Freezable</a>.)</p>
</td>
</tr>
<tr>
<td valign="top">
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">IsSealed</a></p>
</td>
<td valign="top">
<p>Gets a value that indicates whether this instance is currently sealed (read-only).&nbsp;</p>
<p>(Inherited from&nbsp;<a href="http://csharplanguageontips.blogspot.com/" target="_blank">DependencyObject</a>.)</p>
</td>
</tr>
</tbody>
</table>
<p><a href="http://msdn.microsoft.com/en-us/library/system.windows.media.animation.bounceease.aspx#mainBody"><br>
</a><strong>Animation</strong></p>
<p>Windows Presentation Foundation (WPF) provides a powerful set of graphics and layout features that enable you to create attractive user interfaces and appealing documents. Animation can make an attractive user interface even more spectacular and usable.
 By just animating a background color or applying an animated&nbsp;<a href="http://webeasyforall.blogspot.com/" target="_blank">Transform</a>, you can create dramatic screen transitions or provide helpful visual cues.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">xaml</span>
<pre class="hidden">   private void rectangle1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation bounceAnimation = new ThicknessAnimation();
            BounceEase BounceOrientation = new BounceEase();
            BounceOrientation.Bounces = 4;
            BounceOrientation.Bounciness = 2;
            bounceAnimation.To = new Thickness(143,200,0,0);
            bounceAnimation.From = new Thickness(143,0,0,0);
            bounceAnimation.EasingFunction = BounceOrientation;
            rectangle1.BeginAnimation(MarginProperty, bounceAnimation);
        }</pre>
<pre class="hidden">&lt;Window x:Class=&quot;BouncingAnimation.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;
    &lt;Grid&gt;
        &lt;Rectangle Height=&quot;100&quot; MouseDown=&quot;rectangle1_MouseDown&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;143,0,0,0&quot; Name=&quot;rectangle1&quot; Stroke=&quot;Black&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;200&quot;&gt;
            &lt;Rectangle.Fill&gt;
                &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
                    &lt;GradientStop Color=&quot;#FFD42626&quot; Offset=&quot;0&quot; /&gt;
                    &lt;GradientStop Color=&quot;#FF550505&quot; Offset=&quot;1&quot; /&gt;
                &lt;/LinearGradientBrush&gt;
            &lt;/Rectangle.Fill&gt;
        &lt;/Rectangle&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;rectangle1_MouseDown(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseButtonEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ThicknessAnimation&nbsp;bounceAnimation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ThicknessAnimation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BounceEase&nbsp;BounceOrientation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BounceEase();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BounceOrientation.Bounces&nbsp;=&nbsp;<span class="cs__number">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BounceOrientation.Bounciness&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bounceAnimation.To&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness(<span class="cs__number">143</span>,<span class="cs__number">200</span>,<span class="cs__number">0</span>,<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bounceAnimation.From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness(<span class="cs__number">143</span>,<span class="cs__number">0</span>,<span class="cs__number">0</span>,<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bounceAnimation.EasingFunction&nbsp;=&nbsp;BounceOrientation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rectangle1.BeginAnimation(MarginProperty,&nbsp;bounceAnimation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Only WPF XAML Code:</strong></div>
<div class="endscriptcode"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;WpfApplication1.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;
    &lt;Grid&gt;
        &lt;Rectangle Name=&quot;myRectangle&quot; Width=&quot;200&quot; Height=&quot;30&quot; Fill=&quot;Blue&quot;&gt;
            &lt;Rectangle.Triggers&gt;
                &lt;EventTrigger RoutedEvent=&quot;Rectangle.MouseDown&quot;&gt;
                    &lt;BeginStoryboard&gt;
                        &lt;Storyboard&gt;
                            &lt;Storyboard x:Name=&quot;myStoryboard&quot;&gt;
                                &lt;DoubleAnimation From=&quot;30&quot; To=&quot;200&quot; Duration=&quot;00:00:3&quot; 
                     Storyboard.TargetName=&quot;myRectangle&quot; 
                     Storyboard.TargetProperty=&quot;Height&quot;&gt;
                                    &lt;DoubleAnimation.EasingFunction&gt;
                                        &lt;BounceEase Bounces=&quot;2&quot; EasingMode=&quot;EaseOut&quot; 
                             Bounciness=&quot;3&quot; /&gt;
                                    &lt;/DoubleAnimation.EasingFunction&gt;
                                &lt;/DoubleAnimation&gt;
                            &lt;/Storyboard&gt;

                        &lt;/Storyboard&gt;
                    &lt;/BeginStoryboard&gt;
                &lt;/EventTrigger&gt;
            &lt;/Rectangle.Triggers&gt;

        &lt;/Rectangle&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WpfApplication1.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;MainWindow&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;350&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;525&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Rectangle</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;myRectangle&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;30&quot;</span>&nbsp;<span class="xaml__attr_name">Fill</span>=<span class="xaml__attr_value">&quot;Blue&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Rectangle</span>.Triggers<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;EventTrigger</span>&nbsp;<span class="xaml__attr_name">RoutedEvent</span>=<span class="xaml__attr_value">&quot;Rectangle.MouseDown&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;BeginStoryboard</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Storyboard</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Storyboard</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;myStoryboard&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DoubleAnimation</span>&nbsp;<span class="xaml__attr_name">From</span>=<span class="xaml__attr_value">&quot;30&quot;</span>&nbsp;<span class="xaml__attr_name">To</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">Duration</span>=<span class="xaml__attr_value">&quot;00:00:3&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetName</span>=<span class="xaml__attr_value">&quot;myRectangle&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetProperty</span>=<span class="xaml__attr_value">&quot;Height&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DoubleAnimation</span>.EasingFunction<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;BounceEase</span>&nbsp;<span class="xaml__attr_name">Bounces</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">EasingMode</span>=<span class="xaml__attr_value">&quot;EaseOut&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Bounciness</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DoubleAnimation.EasingFunction&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DoubleAnimation&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Storyboard&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Storyboard&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/BeginStoryboard&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/EventTrigger&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.Triggers&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Rectangle&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</strong></div>
