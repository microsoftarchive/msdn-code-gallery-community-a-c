# A simple VU Meter Control in WPF [Updated]
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- VU Meter Control
- VU Meter
- User Cotnrol
## Updated
- 09/11/2011
## Description

<h1>Introduction</h1>
<p><em>Design one VU meter control in WPF to show the sound VU value dynamically.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>.Net Framework 3.5 above, and should build it with Visual Studio 2010. Bu tyou could copy the code to VS 2008 project.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Use a WPF UserControl which bind itsself collection to generate the VU Meter cells. By DataTemplate and with trigger to generate the different color for these cells.</em></p>
<p><em>&nbsp;</em></p>
<p><img src="http://i1.code.msdn.s-msft.com/a-simple-vu-meter-control-f2bd097c/image/file/42242/1/untitled.png" alt="" width="184" height="427"></p>
<p><em>Declare one Value DP in this control, and in its callback method to change the cell visiblity property.</em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;readonly&nbsp;DependencyProperty&nbsp;ValueProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="js__string">&quot;Value&quot;</span>,&nbsp;<span class="js__operator">typeof</span>(int),&nbsp;<span class="js__operator">typeof</span>(VUMeterControl),&nbsp;<span class="js__operator">new</span>&nbsp;UIPropertyMetadata(<span class="js__num">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(sender,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VUMeterControl&nbsp;control&nbsp;=&nbsp;(VUMeterControl)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;value&nbsp;=&nbsp;(int)e.NewValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;TOTAL_COUNT&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;i&nbsp;&gt;=&nbsp;<span class="js__num">0</span>;&nbsp;i--)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FrameworkElement&nbsp;element&nbsp;=&nbsp;(FrameworkElement)control.PART_ItemsPresenter.ItemContainerGenerator.ContainerFromIndex(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(TOTAL_COUNT&nbsp;-&nbsp;i&nbsp;&gt;&nbsp;value&nbsp;/&nbsp;(control.MaxValue&nbsp;/&nbsp;TOTAL_COUNT))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;element.Visibility&nbsp;=&nbsp;Visibility.Hidden;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;element.Visibility&nbsp;=&nbsp;Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);</pre>
</div>
</div>
</div>
</em></div>
<p>&nbsp;</p>
<p><em>&nbsp;</em><em><em>Then we could use this control by control its Value property.</em></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Window&nbsp;x:Class=<span class="js__string">&quot;DEMO.Window1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:control=<span class="js__string">&quot;clr-namespace:VUMeterControlLibrary;assembly=VUMeterControlLibrary&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="js__string">&quot;Window1&quot;</span>&nbsp;Height=<span class="js__string">&quot;554&quot;</span>&nbsp;Width=<span class="js__string">&quot;296&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:l=<span class="js__string">&quot;clr-namespace:DEMO&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;StackPanel&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;control:VUMeterControl&nbsp;x:Name=<span class="js__string">&quot;vuMeterControl&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Slider&nbsp;Value=<span class="js__string">&quot;{Binding&nbsp;ElementName=vuMeterControl,&nbsp;Path=Value}&quot;</span>&nbsp;Maximum=<span class="js__string">&quot;100&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&lt;/StackPanel&gt;&nbsp;
&lt;/Window&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1 class="endscriptcode"><span>Source Code Files</span></h1>
<ul>
<li><em>VUMeterControl\VUMeterControlLibrary\VUMeterControl.xaml - VU Meter Control view XAML code, including the DataTemplate for the VU Meter Cell.</em>
</li><li><em><em>VUMeterControl\VUMeterControlLibrary\VUMeterControl.xaml.cs - Behind code of this UserControl.</em></em>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:large"><strong>More Information</strong></span></p>
<p><em>References: </em></p>
<ul>
<li><em><a href="http://www.codeproject.com/KB/cpp/LED_vu_Meter_User_Control.aspx">http://www.codeproject.com/KB/cpp/LED_vu_Meter_User_Control.aspx</a></em>
</li><li>How to Create a WPF User Control &amp; Use It in a WPF Application ( C# ): <a href="http://www.codeproject.com/KB/WPF/UserControl.aspx">
http://www.codeproject.com/KB/WPF/UserControl.aspx</a> </li><li>Try it: Create a WPF user control: <a href="http://msdn.microsoft.com/en-us/library/cc294992.aspx">
http://msdn.microsoft.com/en-us/library/cc294992.aspx</a> </li><li>How to: Create a WPF UserControl Library Project: <a href="http://msdn.microsoft.com/en-us/library/bb514641.aspx">
http://msdn.microsoft.com/en-us/library/bb514641.aspx</a> </li></ul>
<p><em>&nbsp;</em>&nbsp;</p>
<p>----------------------</p>
<p>[2011.9.8: Update the control]&nbsp; 1. Replaced hardwired block count with a BlockCount dependancy property. 2. Correctly calculate the block height based on control height and block count.</p>
