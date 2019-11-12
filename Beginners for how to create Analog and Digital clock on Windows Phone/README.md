# Beginners for how to create Analog and Digital clock on Windows Phone
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Windows Phone 7.1
## Topics
- Silverlight
- User Interface
## Updated
- 03/10/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Do you want to create Analog clock and Digital clock on Windows Phone? With XAML, it's so easy to create Analog clock on windows phone without&nbsp;<span>coordinate calculation. And, Digital clock too. Youi can create the clock
 with&nbsp;<span>DispatchTimer class.</span></span></span></p>
<p><img src="53994-myclock_window.png" alt="" width="316" height="528"></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">Before running this sample, make sure that the following software is installed:</span></p>
<ul>
<li class="unordered"><span style="font-size:small">Visual Studio 2010</span> </li><li class="unordered"><span style="font-size:small">Windows Phone Developer Tools</span>
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong><span style="font-size:medium">Analog Clock</span></strong></p>
<p><span style="font-size:medium">1. Enable the <strong style="font-size:small">Document Outline</strong> tool window</span></p>
<p><span style="font-size:small">What's the Document Outline?&nbsp;The&nbsp;<strong style="font-size:small">Document Outline</strong>&nbsp;tool window in Visual Studio 2010 is similar to the&nbsp;<strong style="font-size:small">Objects and Timeline</strong>&nbsp;window
 in Expression Blend.&nbsp; It is very useful when you have multiple visual states with different sections of the UI set to visible, collapsed, etc.&nbsp; An example scenario is that you want to set properties or event handlers on an object like a<strong style="font-size:small">Button</strong>&nbsp;or&nbsp;<strong style="font-size:small">MediaElement</strong>&nbsp;but
 it is hidden by other controls.&nbsp; You can easily find the desired object using the Document Outline tool window.</span></p>
<p><span style="font-size:small">The&nbsp;<strong>Document Outline</strong>&nbsp;tool window is a very handy window for Windows Phone 7 developers in Visual Studio 2010 but it is hard to find if you try to find it by looking in the typical places such as the
 View | Other Windows menu item.</span></p>
<p><span style="font-size:small">To open the&nbsp;<strong>Document Outline</strong>&nbsp;tool window right-click on the Windows Phone 7 designer and select&nbsp;<strong>Document Outline</strong>:</span></p>
<p><img src="53995-document_outline.png" alt="" width="260" height="413"></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Once opened&nbsp; you can select&nbsp; an object such as a hidden&nbsp;<strong>MediaElement</strong>&nbsp;in the outline and configure properties as needed as shown here:</span></p>
<p><img src="53996-window.png" alt="" width="800" height="450"></p>
<p>&nbsp;</p>
<p><span style="font-size:medium">2. Create Second hand, Long hand and Hour hand.</span></p>
<p><span style="font-size:small">XAML sour is as below.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;phone</span>:PhoneApplicationPage&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;Analog_Clock.MainPage&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">phone</span>=<span class="xaml__attr_value">&quot;clr-namespace:<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Phone.Controls.aspx" target="_blank" title="Auto generated link to Microsoft.Phone.Controls">Microsoft.Phone.Controls</a>;assembly=Microsoft.Phone&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">shell</span>=<span class="xaml__attr_value">&quot;clr-namespace:<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Phone.Shell.aspx" target="_blank" title="Auto generated link to Microsoft.Phone.Shell">Microsoft.Phone.Shell</a>;assembly=Microsoft.Phone&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">d</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/blend/2008&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">mc</span>=<span class="xaml__attr_value">&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mc:<span class="xaml__attr_name">Ignorable</span>=<span class="xaml__attr_value">&quot;d&quot;</span>&nbsp;d:<span class="xaml__attr_name">DesignWidth</span>=<span class="xaml__attr_value">&quot;480&quot;</span>&nbsp;d:<span class="xaml__attr_name">DesignHeight</span>=<span class="xaml__attr_value">&quot;768&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">FontFamily</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;PhoneFontFamilyNormal}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;PhoneFontSizeNormal}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;PhoneForegroundBrush}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SupportedOrientations</span>=<span class="xaml__attr_value">&quot;Portrait&quot;</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Portrait&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;shell:SystemTray.<span class="xaml__attr_name">IsVisible</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Loaded</span>=<span class="xaml__attr_value">&quot;PhoneApplicationPage_Loaded&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;phone</span>:PhoneApplicationPage.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Storyboard</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">SecondHand</span>&quot;</span>&nbsp;<span class="xaml__attr_name">RepeatBehavior</span>=<span class="xaml__attr_value">&quot;Forever&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DoubleAnimation</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:#ff0000"><span class="xaml__attr_name">Duration</span>=<span class="xaml__attr_value">&quot;0:1:0&quot;</span></span>&nbsp;<span class="xaml__attr_name">From</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">To</span>=<span class="xaml__attr_value">&quot;360&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetName</span>=<span class="xaml__attr_value">&quot;Sec&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetProperty</span>=<span class="xaml__attr_value">&quot;(Image.RenderTransform).(RotateTransform.Angle)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d:<span class="xaml__attr_name">IsOptimized</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Storyboard&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Storyboard</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">LongHand</span>&quot;</span>&nbsp;<span class="xaml__attr_name">RepeatBehavior</span>=<span class="xaml__attr_value">&quot;Forever&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DoubleAnimation</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:#ff0000"><span class="xaml__attr_name">Duration</span>=<span class="xaml__attr_value">&quot;1:0:0&quot;</span>&nbsp;</span><span class="xaml__attr_name">From</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">To</span>=<span class="xaml__attr_value">&quot;360&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetName</span>=<span class="xaml__attr_value">&quot;Min&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetProperty</span>=<span class="xaml__attr_value">&quot;(Image.RenderTransform).(RotateTransform.Angle)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d:<span class="xaml__attr_name">IsOptimized</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Storyboard&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Storyboard</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">HourHand</span>&quot;</span>&nbsp;<span class="xaml__attr_name">RepeatBehavior</span>=<span class="xaml__attr_value">&quot;Forever&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DoubleAnimation</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:#ff0000"><span class="xaml__attr_name">Duration</span>=<span class="xaml__attr_value">&quot;12:0:0&quot;</span></span>&nbsp;<span class="xaml__attr_name">From</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">To</span>=<span class="xaml__attr_value">&quot;360&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetName</span>=<span class="xaml__attr_value">&quot;Hour&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.<span class="xaml__attr_name">TargetProperty</span>=<span class="xaml__attr_value">&quot;(Image.RenderTransform).(RotateTransform.Angle)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d:<span class="xaml__attr_name">IsOptimized</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Storyboard&gt;</span>&nbsp;</strong>
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/phone:PhoneApplicationPage.Resources&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--LayoutRoot&nbsp;is&nbsp;the&nbsp;root&nbsp;grid&nbsp;where&nbsp;all&nbsp;page&nbsp;content&nbsp;is&nbsp;placed--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--TitlePanel&nbsp;contains&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;application&nbsp;and&nbsp;page&nbsp;title--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TitlePanel&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;12,17,0,28&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ApplicationTitle&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Clock&nbsp;Application&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;PhoneTextNormalStyle}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;PageTitle&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;My&nbsp;Clock&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;9,-7,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;PhoneTextTitle1Style}&quot;</span>&nbsp;<span class="xaml__attr_name">TextAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--ContentPanel&nbsp;-&nbsp;place&nbsp;additional&nbsp;content&nbsp;here--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ContentPanel&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;480&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;image1&quot;</span>&nbsp;<span class="xaml__attr_name">Stretch</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;480&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;/MyClock;component/Images/clock01.png&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;240&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;229,40,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Sec&quot;</span>&nbsp;<span class="xaml__attr_name">Stretch</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;22&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;/MyClock;component/Images/clock01_sec.png&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>.RenderTransform<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RotateTransform</span>&nbsp;<span class="xaml__attr_name">CenterX</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">11</span>&quot;</span>&nbsp;<span class="xaml__attr_name">CenterY</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">200</span>&quot;</span>&nbsp;<span class="xaml__attr_name">Angle</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/RotateTransform&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Image.RenderTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Image&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;180&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;206,70,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Hour&quot;</span>&nbsp;<span class="xaml__attr_name">Stretch</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;68&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;/MyClock;component/Images/clock01_hour.png&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>.RenderTransform<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RotateTransform</span>&nbsp;<span class="xaml__attr_name">CenterX</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">34</span>&quot;</span>&nbsp;<span class="xaml__attr_name">CenterY</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">170</span>&quot;</span>&nbsp;<span class="xaml__attr_name">Angle</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/RotateTransform&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Image.RenderTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Image&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;234&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;190,16,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Min&quot;</span>&nbsp;<span class="xaml__attr_name">Stretch</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;100&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;/MyClock;component/Images/clock01_min.png&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>.RenderTransform<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RotateTransform</span>&nbsp;<span class="xaml__attr_name">CenterX</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">50</span>&quot;</span>&nbsp;<span class="xaml__attr_name">CenterY</span>=<span class="xaml__attr_value">&quot;<span style="color:#ff0000">224</span>&quot;</span>&nbsp;<span class="xaml__attr_name">Angle</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/RotateTransform&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Image.RenderTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Image&gt;</span>&nbsp;</strong>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;88&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,513,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtDigitalClock&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;TextBlock&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;480&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;64&quot;</span>&nbsp;<span class="xaml__attr_name">TextAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/phone:PhoneApplicationPage&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><span style="font-size:small">The following code will get currnet time when the applicaiton started.</span></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PhoneApplicationPage_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecondHand.Begin();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LongHand.Begin();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HourHand.Begin();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;second&nbsp;=&nbsp;DateTime.Now.Second;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecondHand.Seek(<span class="cs__keyword">new</span>&nbsp;TimeSpan(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;second));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;minutes&nbsp;=&nbsp;DateTime.Now.Minute;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LongHand.Seek(<span class="cs__keyword">new</span>&nbsp;TimeSpan(<span class="cs__number">0</span>,&nbsp;minutes,&nbsp;second));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;hour&nbsp;=&nbsp;DateTime.Now.Hour;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HourHand.Seek(<span class="cs__keyword">new</span>&nbsp;TimeSpan(hour,&nbsp;minutes,&nbsp;second));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span style="font-size:medium"><strong>Digital Clock</strong></span></p>
<p><span style="font-size:medium">1. Put the <strong>TextBlock </strong>from tool window</span></p>
<p><img src="53998-textblock.png" alt="" width="399" height="181"></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><span>You should change the&nbsp;</span><strong>FontSize&nbsp;</strong><span>to 72 or 64 and you can change the</span><strong>Foreground</strong><span>&nbsp;for the font color.</span><br>
</span></p>
<p><span style="font-size:small">2. Add <strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Threading.aspx" target="_blank" title="Auto generated link to System.Windows.Threading">System.Windows.Threading</a></strong> namespace to use the
<strong>DispatchTimer</strong> class</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.aspx" target="_blank" title="Auto generated link to System.Windows">System.Windows</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Phone.Controls.aspx" target="_blank" title="Auto generated link to Microsoft.Phone.Controls">Microsoft.Phone.Controls</a>;&nbsp;
<strong>using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Threading.aspx" target="_blank" title="Auto generated link to System.Windows.Threading">System.Windows.Threading</a>;&nbsp;</strong>
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Phone.Shell.aspx" target="_blank" title="Auto generated link to Microsoft.Phone.Shell">Microsoft.Phone.Shell</a>;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">3. Add the following codes in the Constractor method</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Constructor</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PhoneApplicationService&nbsp;phoneAppService&nbsp;=&nbsp;PhoneApplicationService.Current;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phoneAppService.UserIdleDetectionMode&nbsp;=&nbsp;IdleDetectionMode.Disabled;&nbsp;
&nbsp;
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DispatcherTimer&nbsp;timer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DispatcherTimer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Tick&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler(timer_Tick);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Start();&nbsp;</strong>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span style="font-size:small">4. timer_tick Event Hnadler will be created and you need delete the &quot;<span>throw new NotImplementedException(); &quot; line. And, you need to add the following code to display current time to the TextBlock.</span></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;timer_Tick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;dt&nbsp;=&nbsp;DateTime.Now;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtDigitalClock.Text&nbsp;=&nbsp;dt.ToString(<span class="cs__string">&quot;MM/dd&nbsp;HH:mm:ss&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<h1>Building the sample</h1>
<p><span style="font-size:small"><strong>To run the sample on a Windows Phone 7 emulator</strong></span></p>
<ol>
<li><span style="font-size:small">Unzip the sample files on the local computer.</span>
</li><li><span style="font-size:small">In Visual Studio, open the MediaPlayerSample.sln solution file in the directory of the sample.</span>
</li><li><span style="font-size:small">With the project loaded in Visual Studio, press F5.</span>
</li></ol>
</div>
</div>
