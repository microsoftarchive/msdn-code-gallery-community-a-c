# Adding 3D Button Pressed Effect
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- XAML Styles
- WPF Styling
- WPF Animation
- ToggleButton
- 3D effects
- Pressed effect
- Property Triggers
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This sample is in response to a <a href="http://social.msdn.microsoft.com/Forums/en/wpf/thread/04dce23e-37a2-4ff0-bdc6-5c61020d15e8">
request for the best way to encapsulate a &quot;3d pressed&quot; effect</a> for a button on the WPF forums.</p>
<p><img id="65677" src="65677-toggleshadow.png" alt="" width="396" height="199" style="margin-right:auto; margin-left:auto; display:block">&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unzip, open and run!</p>
<p>&nbsp;</p>
<h1><span style="font-size:20px">Description</span></h1>
<p>This example is in response to a <a href="http://social.msdn.microsoft.com/Forums/en/wpf/thread/04dce23e-37a2-4ff0-bdc6-5c61020d15e8">
forum question</a> where the poster wanted to encapsulate the &quot;3D pressed&quot; behaviour into something that was reusable, instead of using the parent page's Visual State Manaager to crerate animations for evrey single button.</p>
<p>In this sample, to create the 3D effect, a shaded effect is added to the template for a ToggleButton.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Microsoft_Windows_Themes:ButtonChrome.Effect&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DropShadowEffect/&gt;&nbsp;
&lt;/Microsoft_Windows_Themes:ButtonChrome.Effect&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>We then add a Property Trigger to the Control Template, which triggers an animation.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsChecked&quot;</span>&nbsp;Value=<span class="js__string">&quot;True&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger.ExitActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StopStoryboard&nbsp;BeginStoryboardName=<span class="js__string">&quot;Storyboard1_BeginStoryboard&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger.ExitActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger.EnterActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;BeginStoryboard&nbsp;x:Name=<span class="js__string">&quot;Storyboard1_BeginStoryboard&quot;</span>&nbsp;Storyboard=<span class="js__string">&quot;{StaticResource&nbsp;Storyboard1}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger.EnterActions&gt;&nbsp;
&lt;/Trigger&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">The animation in this sample simply&nbsp;reduces the depth of the shadow and moves the button slightly, to give the effect of a button being pressed.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;ControlTemplate.Resources&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Storyboard&nbsp;x:Key=<span class="js__string">&quot;Storyboard1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimationUsingKeyFrames&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;(UIElement.Effect).(DropShadowEffect.BlurRadius)&quot;</span>&nbsp;Storyboard.TargetName=<span class="js__string">&quot;Chrome&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EasingDoubleKeyFrame&nbsp;KeyTime=<span class="js__string">&quot;0&quot;</span>&nbsp;Value=<span class="js__string">&quot;3&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DoubleAnimationUsingKeyFrames&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimationUsingKeyFrames&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)&quot;</span>&nbsp;Storyboard.TargetName=<span class="js__string">&quot;Chrome&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EasingDoubleKeyFrame&nbsp;KeyTime=<span class="js__string">&quot;0&quot;</span>&nbsp;Value=<span class="js__string">&quot;4&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DoubleAnimationUsingKeyFrames&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimationUsingKeyFrames&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)&quot;</span>&nbsp;Storyboard.TargetName=<span class="js__string">&quot;Chrome&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EasingDoubleKeyFrame&nbsp;KeyTime=<span class="js__string">&quot;0&quot;</span>&nbsp;Value=<span class="js__string">&quot;2&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DoubleAnimationUsingKeyFrames&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimationUsingKeyFrames&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;(UIElement.Effect).(DropShadowEffect.ShadowDepth)&quot;</span>&nbsp;Storyboard.TargetName=<span class="js__string">&quot;Chrome&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EasingDoubleKeyFrame&nbsp;KeyTime=<span class="js__string">&quot;0&quot;</span>&nbsp;Value=<span class="js__string">&quot;3&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DoubleAnimationUsingKeyFrames&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Storyboard&gt;&nbsp;
&lt;/ControlTemplate.Resources&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">This style, with the animated behaviour can then be used on any button in the application, by assigning the style as follows:</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;ToggleButton&nbsp;Content=<span class="js__string">&quot;Button&nbsp;1&quot;</span>&nbsp;Width=<span class="js__string">&quot;100&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;Style=<span class="js__string">&quot;{DynamicResource&nbsp;ToggleButtonStyle1}&quot;</span>&nbsp;/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">If you wanted to group these ToggleButtons together to act as RadioButtons, please see
<strong><a href="http://code.msdn.microsoft.com/Grouping-ToggleButtons-and-aa4838e7">this other sample project</a></strong>.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Creating animations and triggers and encapsulating them into a style or control template&nbsp;is very simple with Microsoft's Expression Blend.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">You simply place a button on the page, right click the Button, &quot;Edit style&quot; / &quot;Edit a copy&quot; to get the style and control template. then you can add the shadow, and the trigger.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Blend will automatically create the animation and record your changes like shadow depth and TranslateTransform.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
