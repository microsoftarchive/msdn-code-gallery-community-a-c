# Bing Map Control in WPF
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- Bing Maps
- Bing Maps 3D Control
## Topics
- Bing Maps Control for WPF
- Bing Map Control
## Updated
- 02/21/2014
## Description

<h1>Introduction</h1>
<p><em>This article describes how to display bing map in Control in WPF. It is very easy and simple to integrate in your application. It requires only two things. 1) Bing Map Control library 2) BING_MAP_KEY.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>It require <span style="background-color:#ffffff; color:#800080">Microsoft.Maps.MapControl.WPF.dll</span> to display Bing Map Control in WPF. You can download this library from bingmapsportal.com.</p>
<p><a title="Download Here" href="http://www.microsoft.com/en-us/download/confirmation.aspx?id=27165">Download Here</a></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>After downloading you need to install it. You will find that library in program files just copy it and paste into bin folder of your project and add a reference to your project.
</em></p>
<p><em>If your the control is not available in your toolbox add items from WPF Control.<br>
</em></p>
<p><em>It require the namespace</em></p>
<p><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>XAML</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">xaml</span>
<pre class="hidden"> xmlns:m=&quot;clr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF&quot;</pre>
<div class="preview">
<pre class="xaml">&nbsp;xmlns:m=&quot;clr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF&quot;</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;For this purpose you need to create BING_MAP_KEY from this website.<br>
</em></div>
<div class="endscriptcode"><em><br>
</em></div>
<div class="endscriptcode"><em><a href="https://www.bingmapsportal.com/application">https://www.bingmapsportal.com/application</a></em></div>
<div class="endscriptcode"><em><br>
</em></div>
<div class="endscriptcode"><em>There are two types of keys are available. Trial and Basic. The Trial Key expires after 90 days and cannot be converted into basic.<br>
</em></div>
<div class="endscriptcode"><em>Create your key and Add it into your XAML Code.<br>
</em></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>XAML</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">xaml</span>
<pre class="hidden"> &lt;m:Map CredentialsProvider=&quot;YOUR_BING_MAP_KEY&quot; x:Name=&quot;myMap&quot; /&gt;</pre>
<div class="preview">
<pre class="xaml">&nbsp;<span class="xaml__tag_start">&lt;m</span>:Map&nbsp;<span class="xaml__attr_name">CredentialsProvider</span>=<span class="xaml__attr_value">&quot;YOUR_BING_MAP_KEY&quot;</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;myMap&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span></pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>This control contains Mode property which is used to display the map in a different mode.</em></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">    &lt;m:Map Mode=&quot;Road&quot;  CredentialsProvider=&quot;BING_MAP_KEY&quot;  Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; /&gt;
        &lt;m:Map Mode=&quot;Aerial&quot;  CredentialsProvider=&quot;BING_MAP_KEY&quot; Grid.Column=&quot;1&quot; Grid.Row=&quot;0&quot; /&gt;
        &lt;m:Map Mode=&quot;AerialWithLabels&quot;  CredentialsProvider=&quot;BING_MAP_KEY&quot; Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot; /&gt;</pre>
<div class="preview">
<pre class="xaml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;m</span>:Map&nbsp;<span class="xaml__attr_name">Mode</span>=<span class="xaml__attr_value">&quot;Road&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">CredentialsProvider</span>=<span class="xaml__attr_value">&quot;BING_MAP_KEY&quot;</span>&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;m</span>:Map&nbsp;<span class="xaml__attr_name">Mode</span>=<span class="xaml__attr_value">&quot;Aerial&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">CredentialsProvider</span>=<span class="xaml__attr_value">&quot;BING_MAP_KEY&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;m</span>:Map&nbsp;<span class="xaml__attr_name">Mode</span>=<span class="xaml__attr_value">&quot;AerialWithLabels&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">CredentialsProvider</span>=<span class="xaml__attr_value">&quot;BING_MAP_KEY&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</em></div>
<div class="endscriptcode"><em><img id="109199" src="109199-bing%20map.jpg" alt="" width="525" height="352"></em></div>
<p>Use this namespace which is mentioned below.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.Maps.MapControl.WPF;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Microsoft.Maps.MapControl.WPF;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><em>Add the given code when application is initialise.</em></p>
<p><em></em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">      myMap.Focus();
            //Set map to Aerial mode with labels
            myMap.Mode = new AerialMode(true);</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMap.Focus();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;map&nbsp;to&nbsp;Aerial&nbsp;mode&nbsp;with&nbsp;labels</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMap.Mode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AerialMode(<span class="cs__keyword">true</span>);</pre>
</div>
</div>
</em></div>
<p><em></em></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
