# Custom GroupBox Class (GroupBoxEx)
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Controls
- Graphics
- C#
- Class Library
- custom controls
- VB.Net
- Inheritance
- Graphics Functions
- vb2008
- System.Drawing.Drawing2D
- Class Inheritance
## Topics
- Graphics
- C#
- Class Library
- custom controls
- VB.Net
- Inheritance
- Drawing
- Properties
- Classes
- Graphics Functions
- Class Inheritance
## Updated
- 06/09/2014
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">If you have ever used a GroupBox and wanted to change the border color, or wanted an image or backcolor but, didn`t like the way it extended past the edges of the groupbox borders then adding the GroupBoxEx to your project
 or toolbox may be just what your looking for. Here is an image of a few to give an idea of the look of the GroupBoxEx.<br>
</span></em></p>
<p><em><span style="font-size:small"><img id="116468" src="116468-frame_0.png" alt="" width="403" height="263"><br>
</span></em></p>
<h1><span>Building the Sample</span></h1>
<p><em><span style="font-size:small">Built using VS2008 targeting the .Net 3.5 Framework</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">&nbsp; The GroupBoxEx class was created by inheriting a GroupBox since it had the basic properties that where needed. Then i added all the properties that i needed to control the drawing of the GroupBoxEx control. However, i
 did have to hide the BackgroundImage property and replace it with a BackgroundPanelImage property to get the transparency around the top of the control to work correctly. I also had to hide the BackColor property and replace it with a GroupPanelColor so the
 BackColor could be set to Color.Transparent permanently</span>.</p>
<p>&nbsp;<span style="font-size:small">With this control you can change the border color around the text or the group panel, the color behind the text, and the group panel itself. You can also use an image in the group panel. There are a few other properties
 that can be used to change the looks also.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;As with all of my custom controls i have included a Class Library project in the GroupBoxEx folder located in the GroupBoxEx Demo folder. I do this so you can use the GroupBoxEx.dll file to add the control to your ToolBox
 or you can add the GroupBoxEx.vb or GroupBoxEx.cs class file directly to your project using the VB or C# menu (Project / Add Existing Item).</span></p>
<p>&nbsp;</p>
<p>&nbsp;<span style="font-size:small">To add one to your ToolBox so that the GroupBoxEx control is available in the ToolBox and can be dragged onto any form no mater what project you are working on, you will need to ether use the class code and create your
 own Class Library project and build the dll file yourself or you will need the GroupBoxEx.dll file from the GroupBoxEx Demo download. Then follow these steps to add it to your ToolBox.</span></p>
<ol>
<li><span style="font-size:small">Open Visual Studio</span> </li><li><span style="font-size:small">On the menu click (Tools) and then select (Choose Toolbox Items)</span>
</li><li><span style="font-size:small">when the dialog opens click (Browse)</span> </li><li><span style="font-size:small">Browse to the dll file you created or the GroupBoxEx.dll file from the Demo</span>
</li><li><span style="font-size:small">Double click on the dll file or select it and press (Ok)</span>
</li></ol>
<p><span style="font-size:small">Now the GroupBoxEx control is added to your ToolBox so you can drag one onto the form of any project like any other control.<br>
</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.ComponentModel&nbsp;
<span class="visualBasic__com">'If&nbsp;you&nbsp;are&nbsp;building&nbsp;a&nbsp;Class&nbsp;Library&nbsp;project&nbsp;then&nbsp;you&nbsp;will&nbsp;need&nbsp;to&nbsp;add&nbsp;reference&nbsp;to&nbsp;System.Windows.Forms&nbsp;and</span>&nbsp;
<span class="visualBasic__com">'System.Drawing.&nbsp;You&nbsp;can&nbsp;do&nbsp;that&nbsp;after&nbsp;you&nbsp;create&nbsp;the&nbsp;new&nbsp;Class&nbsp;Library&nbsp;by&nbsp;going&nbsp;to&nbsp;the&nbsp;VB&nbsp;menu&nbsp;and&nbsp;clicking</span>&nbsp;
<span class="visualBasic__com">'(Project)&nbsp;and&nbsp;then&nbsp;selecting&nbsp;(Add&nbsp;Reference...).&nbsp;Then&nbsp;on&nbsp;the&nbsp;(.Net)&nbsp;tab&nbsp;you&nbsp;can&nbsp;find&nbsp;and&nbsp;select&nbsp;(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>)</span>&nbsp;
<span class="visualBasic__com">'and&nbsp;(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>)&nbsp;to&nbsp;add&nbsp;the&nbsp;references.</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing.Drawing2D&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows.Forms&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;GroupBoxEx&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Inherit&nbsp;the&nbsp;Properties,&nbsp;Methods,&nbsp;and&nbsp;Events&nbsp;from&nbsp;the&nbsp;GroupBox&nbsp;class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;GroupBox&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;the&nbsp;property&nbsp;backing&nbsp;fields</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BackColorBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_PanelBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_PanelShape&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PanelType&nbsp;=&nbsp;PanelType.Rounded&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BorderPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_DrawBorder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_TextBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_TextBackBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_TextBorderPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BackgroundImageBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TextureBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BackgroundPanelImage&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;an&nbsp;Enum&nbsp;used&nbsp;for&nbsp;the&nbsp;PanelShape&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;PanelType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Squared&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rounded&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Set&nbsp;the&nbsp;Styles,&nbsp;pens,&nbsp;brushes,&nbsp;and&nbsp;properties&nbsp;used&nbsp;for&nbsp;the&nbsp;defaults&nbsp;when&nbsp;a&nbsp;new&nbsp;instance&nbsp;is&nbsp;created</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.SupportsTransparentBackColor,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.UserPaint,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.OptimizedDoubleBuffer,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">180</span>,&nbsp;<span class="visualBasic__number">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BackColorBrush&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(Color.Transparent)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_PanelBrush&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(<span class="visualBasic__keyword">MyBase</span>.BackColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBrush&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(<span class="visualBasic__keyword">MyBase</span>.ForeColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBackBrush&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(Color.White)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBorderPen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;=&nbsp;Color.Transparent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;the&nbsp;properties&nbsp;for&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;Background&nbsp;image.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackgroundPanelImage()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_BackgroundPanelImage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BackgroundPanelImage&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;color&nbsp;of&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ForeColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Drawing.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.ForeColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.Color.aspx" target="_blank" title="Auto generated link to System.Drawing.Color">System.Drawing.Color</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.ForeColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBrush.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;Background&nbsp;color.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;GroupPanelColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_PanelBrush.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_PanelBrush.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;shape&nbsp;of&nbsp;the&nbsp;control.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;GroupPanelShape()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PanelType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_PanelShape&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PanelType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_PanelShape&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;if&nbsp;a&nbsp;border&nbsp;is&nbsp;drawn&nbsp;around&nbsp;the&nbsp;control.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;DrawGroupBorder()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_DrawBorder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_DrawBorder&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;color&nbsp;of&nbsp;the&nbsp;border.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;GroupBorderColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_BorderPen.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;Background&nbsp;color&nbsp;of&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TextBackColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_TextBackBrush.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_TextBackBrush.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Exception(<span class="visualBasic__string">&quot;Color&nbsp;Transparent&nbsp;is&nbsp;not&nbsp;supported&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBackBrush.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;color&nbsp;of&nbsp;the&nbsp;border&nbsp;around&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TextBorderColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_TextBorderPen.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_TextBorderPen.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Exception(<span class="visualBasic__string">&quot;Color&nbsp;Transparent&nbsp;is&nbsp;not&nbsp;supported&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBorderPen.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Used&nbsp;to&nbsp;paint&nbsp;the&nbsp;control&nbsp;according&nbsp;to&nbsp;how&nbsp;the&nbsp;properties&nbsp;are&nbsp;set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnPaint(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.PaintEventArgs.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.PaintEventArgs">System.Windows.Forms.PaintEventArgs</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;e.Graphics&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillRectangle(_BackColorBrush,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SmoothingMode&nbsp;=&nbsp;SmoothingMode.AntiAlias&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tw&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(.MeasureString(<span class="visualBasic__keyword">Me</span>.Text,&nbsp;<span class="visualBasic__keyword">Me</span>.Font).Width)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;th&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(.MeasureString(<span class="visualBasic__keyword">Me</span>.Text,&nbsp;<span class="visualBasic__keyword">Me</span>.Font).Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rec&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">CInt</span>(th&nbsp;/&nbsp;<span class="visualBasic__number">2</span>),&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;-&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(th&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;gp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GraphicsPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.GroupPanelShape&nbsp;=&nbsp;PanelType.Rounded&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rad&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">14</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.Right&nbsp;-&nbsp;(rad),&nbsp;rec.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">270</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.Right&nbsp;-&nbsp;(rad),&nbsp;rec.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.X,&nbsp;rec.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">90</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.X,&nbsp;rec.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">180</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.CloseFigure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddRectangle(rec)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillPath(_PanelBrush,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawBackImage(e.Graphics,&nbsp;gp,&nbsp;<span class="visualBasic__keyword">CInt</span>(th&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.DrawGroupBorder&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;.DrawPath(_BorderPen,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;tw&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;th&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;trec&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">7</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;-&nbsp;<span class="visualBasic__number">15</span>,&nbsp;th&nbsp;&#43;&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;gp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GraphicsPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rad&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">6</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(trec.Right&nbsp;-&nbsp;(rad),&nbsp;trec.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">270</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(trec.Right&nbsp;-&nbsp;(rad),&nbsp;trec.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(trec.X,&nbsp;trec.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">90</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(trec.X,&nbsp;trec.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">180</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.CloseFigure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillPath(_TextBackBrush,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DrawPath(_TextBorderPen,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;sf&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringFormat&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.Alignment&nbsp;=&nbsp;StringAlignment.Center,&nbsp;.LineAlignment&nbsp;=&nbsp;StringAlignment.Center,&nbsp;.Trimming&nbsp;=&nbsp;StringTrimming.EllipsisCharacter,&nbsp;.FormatFlags&nbsp;=&nbsp;StringFormatFlags.NoWrap}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DrawString(<span class="visualBasic__keyword">Me</span>.Text,&nbsp;<span class="visualBasic__keyword">Me</span>.Font,&nbsp;_TextBrush,&nbsp;trec,&nbsp;sf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'A&nbsp;private&nbsp;sub&nbsp;used&nbsp;to&nbsp;position,&nbsp;resize,&nbsp;and&nbsp;draw&nbsp;the&nbsp;BackgroundImage&nbsp;according&nbsp;to&nbsp;the&nbsp;BackgroundImageLayout</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DrawBackImage(<span class="visualBasic__keyword">ByVal</span>&nbsp;g&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Graphics,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;grxpath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GraphicsPath,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;topoffset&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;bm&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bitmap(<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;grx&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Graphics&nbsp;=&nbsp;Graphics.FromImage(bm)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.None&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grx.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Tile&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Math.Ceiling(bm.Width&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Math.Ceiling(bm.Height&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;tr&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;tc&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grx.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage,&nbsp;(x&nbsp;*&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width),&nbsp;(y&nbsp;*&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height),&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Center&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xx&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;yy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(((<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grx.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage,&nbsp;xx,&nbsp;yy,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Stretch&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grx.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Zoom&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;meratio&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;(<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;imgratio&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Width&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage.Height&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;imgrect&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;imgratio&nbsp;&gt;&nbsp;meratio&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Width&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Height&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;imgratio)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;imgratio&nbsp;&lt;&nbsp;meratio&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Height&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Width&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;*&nbsp;imgratio)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.X&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(imgrect.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Y&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(((<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;topoffset)&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(imgrect.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grx.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundPanelImage,&nbsp;imgrect)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;tb&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TextureBrush(bm)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;&lt;&gt;&nbsp;ImageLayout.Tile&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;tb.WrapMode&nbsp;=&nbsp;WrapMode.Clamp&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.TranslateTransform(<span class="visualBasic__number">0</span>,&nbsp;topoffset)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillPath(tb,&nbsp;grxpath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Used&nbsp;to&nbsp;force&nbsp;the&nbsp;control&nbsp;to&nbsp;repaint&nbsp;itself&nbsp;when&nbsp;the&nbsp;text&nbsp;is&nbsp;changed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnTextChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnTextChanged(e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Override&nbsp;the&nbsp;BackColor&nbsp;property&nbsp;and&nbsp;hide&nbsp;it&nbsp;from&nbsp;the&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;&lt;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Obsolete(<span class="visualBasic__string">&quot;The&nbsp;BackColor&nbsp;property&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shadows</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Drawing.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.Color.aspx" target="_blank" title="Auto generated link to System.Drawing.Color">System.Drawing.Color</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Exception(<span class="visualBasic__string">&quot;The&nbsp;BackColor&nbsp;property&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Override&nbsp;the&nbsp;BackgroundImage&nbsp;property&nbsp;and&nbsp;hide&nbsp;it&nbsp;from&nbsp;the&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;&lt;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Obsolete(<span class="visualBasic__string">&quot;The&nbsp;BackgroundImage&nbsp;property&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shadows</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackgroundImage()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackgroundImage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Exception(<span class="visualBasic__string">&quot;The&nbsp;BackgroundImage&nbsp;property&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Dispose&nbsp;of&nbsp;all&nbsp;brushes&nbsp;and&nbsp;pens&nbsp;used&nbsp;for&nbsp;the&nbsp;property&nbsp;backing&nbsp;fields</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Dispose(<span class="visualBasic__keyword">ByVal</span>&nbsp;disposing&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BackColorBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_PanelBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBackBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextBorderPen.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Dispose(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</ul>
