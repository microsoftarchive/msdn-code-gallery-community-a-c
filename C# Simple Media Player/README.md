# C# Simple Media Player
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- COM
- DirectShow
## Topics
- video
- Media
- Audio
- COM Interop
## Updated
- 01/22/2012
## Description

<h1>Introduction</h1>
<p><em>This sample shows easy way to implement Media Player in .NET Using Quartz Libraries (DirectShow). This sample is built using DirectShow COM Interops. Currently it shows playing a video file selected from the open dialog. By default WPF Comes with Media
 Element but in older version of Winforms this is the easiest way to play audio or vidoe files. But those file require the Media Codecs installed on the system.</em></p>
<p><em>The sample is verified in VS2008 / Vista 64bit.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Just build sample in 32bit Mode in any .NET Version.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Sample Media Library Usage in .NET and DirectShow COM API. It uses few FileGraph interfaces along with Window Interface to show output window in a container. Similary IMediaPosition and other interfaces can be used to implement postions and other media
 scenarios.</em></p>
<p><em>Sample code to play a video file</em></p>
<p><em>&nbsp;</em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">MediaPly&nbsp;_mp&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(openFileDialog1.ShowDialog(<span class="cs__keyword">this</span>)&nbsp;==&nbsp;DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MediaPly();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mp.LoadFile(openFileDialog1.FileName,&nbsp;<span class="cs__keyword">this</span>.panel1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<p><em></p>
<div class="endscriptcode">&nbsp;Just provide the file name and the panle in which the content should be played. I havent used any advanced options available in this API this is a very simple example to show case about legacy technolgy which is still good
 to use in .NET Applications.</div>
</em>
<p></p>
<p>&nbsp;</p>
<p><em>&nbsp;</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;MediaPly&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;
&nbsp;&nbsp;WS_CHILD&nbsp;=&nbsp;0x40000000,&nbsp;
&nbsp;&nbsp;WS_VISIBLE&nbsp;=&nbsp;0x10000000,&nbsp;
&nbsp;&nbsp;LBS_NOTIFY&nbsp;=&nbsp;0x00000001,&nbsp;
&nbsp;&nbsp;HOST_ID&nbsp;=&nbsp;0x00000002,&nbsp;
&nbsp;&nbsp;LISTBOX_ID&nbsp;=&nbsp;0x00000001,&nbsp;
&nbsp;&nbsp;WS_VSCROLL&nbsp;=&nbsp;0x00200000,&nbsp;
&nbsp;&nbsp;WS_BORDER&nbsp;=&nbsp;0x00800000;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;FilgraphManagerClass&nbsp;graphManager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QuartzTypeLib.FilgraphManagerClass();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;IMediaControl&nbsp;mControl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;IMediaPosition&nbsp;mPosition;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;IVideoWindow&nbsp;mWindow;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MediaPly()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;LoadFile(<span class="cs__keyword">string</span>&nbsp;sfile,&nbsp;Panel&nbsp;parentHandler)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graphManager.RenderFile(sfile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mControl&nbsp;=&nbsp;graphManager;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mPosition&nbsp;=&nbsp;graphManager;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mWindow&nbsp;=&nbsp;graphManager;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mWindow.Owner&nbsp;=&nbsp;parentHandler.Handle.ToInt32();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mWindow.WindowStyle&nbsp;=&nbsp;WS_CHILD;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mWindow.SetWindowPosition(parentHandler.ClientRectangle.Left,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parentHandler.ClientRectangle.Top,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parentHandler.ClientRectangle.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parentHandler.ClientRectangle.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graphManager.Run();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Above is the class used to play the Media File. For Audio file you will get mWindow as null so you need to handle the code for Audio Files.</div>
<br>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em><a href="http://msdn.microsoft.com/en-us/library/aa645736(v=vs.71).aspx">http://msdn.microsoft.com/en-us/library/aa645736(v=vs.71).aspx</a></em></p>
<p><em>For more information you can go to MSDN DirectShow.</em></p>
