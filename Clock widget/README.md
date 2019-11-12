# Clock widget
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Windows Forms
- clock
- Visual Studio 2015
## Topics
- Windows Forms
- clock
- Widgets
- Gadget
- circular progress bar
## Updated
- 07/22/2017
## Description

<p><span style="font-family:Calibri; font-size:small">This sample demonstrates how to build a desktop clock gadget/ widget using windows form application and it also demonstrates use of
<strong>circular progress bar</strong>.</span></p>
<p><span style="font-family:Calibri; font-size:small"><img id="175898" src="175898-clock.png" alt="" width="344" height="287"><br>
</span></p>
<p><span style="font-family:Calibri; font-size:small">Create a new windows form application project
</span></p>
<p><span>I</span><span style="font-family:Calibri; font-size:small">n <strong>solution explorer</strong> tab
<em>right click</em> on <em>project Solution</em> and click <strong>manage nuget packages</strong> .</span></p>
<p><span style="font-family:Calibri; font-size:small">Search for &ldquo;<span style="text-decoration:underline">circular progress bar</span>&rdquo; and install it.
</span></p>
<p><span style="font-size:small"><span style="font-family:Times New Roman">&nbsp;</span><span style="font-family:Calibri">&nbsp;<img id="175893" src="175893-nugetpackagemanager.png" alt=""></span></span></p>
<p><span style="font-family:Calibri; font-size:small">After that it installed go to
<strong>ToolBox</strong>. in ToolBox <em>right click</em> and select <strong>Choose Items</strong></span></p>
<p><span style="font-family:Calibri; font-size:small">in <em>.NET framework component</em> tab click
<strong>browse</strong> and browse to the current project folder and then browse to<strong><span>
</span></strong></span><span style="font-family:Calibri; font-size:small"><strong>packages &gt;&gt; WinFormAnimation &gt;&gt; lib &gt;&gt; net35-client</strong> folder</span></p>
<p><span style="font-family:Calibri; font-size:small">then <em><span style="text-decoration:underline">copy</span></em>
<strong>WinFormAnimation.dll</strong> file and go back to <em>packages</em> folder then select
<strong>CircularProgressBar</strong> folder then browse to <strong>lib&gt;&gt; net35-client</strong> folder and
<em><strong><span style="text-decoration:underline">paste</span></strong></em> that file here.</span></p>
<p>&nbsp;<img id="175894" src="175894-selectcircular%201.png" alt=""></p>
<p><span style="font-family:Calibri; font-size:small">then select <strong>CircularProgressBar.dll</strong> and click
<strong>open</strong> now in <em>Choose Toolbox Items</em> window and click <strong>
OK </strong></span></p>
<p>&nbsp;</p>
<p><span style="font-family:Calibri; font-size:small">Now select the circular progress bar and add it to your form application.
</span></p>
<p><span style="font-family:Calibri; font-size:small">to make it more like a widget make select form and make windows form size small and set the
<strong>FormBorderStyle</strong> to <strong>None</strong>.</span></p>
<p><span style="font-family:Calibri; font-size:small">now select the <em>CircularProgressBar</em> and adjust following properties from a properties tab</span></p>
<p><span style="font-family:Calibri"><span style="font-size:small">change <strong>
BackColor</strong> to <span style="text-decoration:underline">Transparent</span></span></span></p>
<p><span style="font-family:Calibri"><span style="font-size:small"><strong>ForeColor</strong>
<span style="text-decoration:underline">White</span></span></span></p>
<p><span style="font-family:Calibri; font-size:small">change the <strong>InnerColor</strong>,
<strong>OuterColor</strong> and <strong>ProgressColor</strong> as desired</span></p>
<p><span style="font-family:Calibri; font-size:small">change <strong>SubscriptText</strong> to
<span style="text-decoration:underline">00</span> and make&nbsp; <strong>SuperScriptText</strong> &nbsp;empty</span></p>
<p><span style="font-family:Calibri"><span style="font-size:small">change the <strong>
Text</strong> to <span style="text-decoration:underline">00:00:00.</span></span></span></p>
<p><span style="font-family:Calibri; font-size:small">set <strong>Style </strong>
to <span style="text-decoration:underline">Marquee</span>.</span></p>
<p><span style="font-family:Calibri; font-size:small">adjust <strong>Step</strong> to
<span style="text-decoration:underline">10</span> and also adjust size of text according to size of clock.</span></p>
<p><span style="font-family:Calibri; font-size:small">&nbsp;</span></p>
<p><span style="font-family:Calibri; font-size:small">this application will check for time after every 1s &nbsp;(1000 milliseconds) interval.</span></p>
<p><span style="font-family:Calibri; font-size:small">in the Form_Load function we had used<strong><span style="color:#0000ff"> <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Timers.aspx" target="_blank" title="Auto generated link to System.Timers">System.Timers</a></span></strong> class</span></p>
<p><span style="font-family:Calibri; font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;x&nbsp;=&nbsp;desktopArea.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;y&nbsp;=&nbsp;desktopArea.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.TransparencyKey&nbsp;=&nbsp;(BackColor);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Timers.Timer&nbsp;timer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Timers.Timer.aspx" target="_blank" title="Auto generated link to System.Timers.Timer">System.Timers.Timer</a>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Interval&nbsp;=&nbsp;<span class="cs__number">1000</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Elapsed&nbsp;&#43;=&nbsp;Timer_Elapsed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.SetDesktopLocation(x&nbsp;-&nbsp;<span class="cs__number">300</span>,&nbsp;<span class="cs__number">100</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">&nbsp;this above line of code will launch method Timer_Elapsed after every 1s.&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp</span>

<div class="preview">
<pre class="js"><span style="font-size:small">&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Timer_Elapsed(object&nbsp;sender,&nbsp;System.Timers.ElapsedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;circularProgressBar1.Invoke((MethodInvoker)delegate&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;circularProgressBar1.Text&nbsp;=&nbsp;DateTime.Now.ToString(<span class="js__string">&quot;hh:mm:ss&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;circularProgressBar1.SubscriptText&nbsp;=&nbsp;DateTime.Now.ToString(<span class="js__string">&quot;tt&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:small">this method will check for time.&nbsp;</span></p>
<p><span style="font-size:small">to move the clock arround the screen add following functions and linked them in event tab of circularProgressBar</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;circularProgressBar1_MouseDown(object&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseDn&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;circularProgressBar1_MouseMove(object&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(mouseDn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseX&nbsp;=&nbsp;MousePosition.X&nbsp;-<span class="js__num">130</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseY&nbsp;=&nbsp;MousePosition.Y&nbsp;-<span class="js__num">50</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.SetDesktopLocation(mouseX,&nbsp;mouseY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;circularProgressBar1_MouseUp(object&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseDn&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>if any suggestions and feedback email me at:</p>
<p><em>umairnadeem20@hotmail.com</em><span style="font-size:small">&nbsp;<br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-family:Calibri; font-size:small">&nbsp;</span></p>
<p><span style="font-family:Calibri; font-size:small">&nbsp;</span></p>
<p><span style="font-family:Calibri; font-size:small">&nbsp;</span></p>
<p><strong>&nbsp;</strong><em>&nbsp;</em></p>
