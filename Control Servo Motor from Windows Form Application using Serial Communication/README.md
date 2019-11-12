# Control Servo Motor from Windows Form Application using Serial Communication
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Forms
- Visual Studio
- arduino
## Topics
- C#
- Visual Studio
- arduino
- serial communication
- arduino interfacing
## Updated
- 09/30/2017
## Description

<p><span style="font-size:small">This code sample demonstrates how to use to control servo motor attached to arduino in Windows Form Application c# using serial communication.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Download the code file:</span></p>
<p><span style="font-size:small">Extract it</span></p>
<p><span style="font-size:small">Open &quot;Pos&quot;&nbsp;folder<strong>&nbsp;</strong><em>&nbsp;</em> and open file &quot;<strong>pos.ino</strong>&quot; in arduino IDE. Here's the arduino code:</span></p>
<p>&nbsp;</p>
<div class="endscriptcode">&nbsp;
<div></div>
<div><span style="color:#008000; font-size:small">#include&lt;Servo.h&gt;</span><br>
<span style="color:#008000; font-size:small">Servo base;</span></div>
<div><span style="color:#008000; font-size:small">void setup() </span><br>
<span style="color:#008000; font-size:small">{</span><br>
<span style="color:#008000; font-size:small">&nbsp; base.attach(8);</span></div>
<div><span style="color:#008000; font-size:small">&nbsp; Serial.begin(9600);&nbsp;
</span><br>
<span style="color:#008000; font-size:small">}</span></div>
<div><span style="color:#008000; font-size:small">void loop()</span><br>
<span style="color:#008000; font-size:small">{</span><br>
<span style="color:#008000; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; int val=Serial.parseInt();</span><br>
<span style="color:#008000; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if(val!=0)</span><br>
<span style="color:#008000; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="color:#008000; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.write(val);</span><br>
<span style="color:#008000; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="color:#008000; font-size:small">}</span></div>
<div></div>
<div><span style="color:#008000; font-size:small"><br>
</span></div>
<div><span style="font-size:small">I have attached Servo Motor to pin number 8. You can change pin number in your code. Upload this code to arduino board. I am using arduino UNO, and my port number is COM29 and baud rate is 9600. Notice your port number and
 baudRate becasue we will use this in our C# code.</span></div>
<div><span style="font-size:small"><br>
</span></div>
</div>
<div></div>
<div></div>
<div><span style="font-size:small">After you successfully uploaded your code, open
<strong>ServoControl.sln</strong> file in visual studio. </span></div>
<div><span style="font-size:small">In Solution Explorer open <strong>Form1.cs[Design]</strong> file you will notice that I there is a
<strong>T</strong><strong>rackBar</strong> control on Form.</span></div>
<div><img id="180137" width="570" height="235" src="180137-trackbar.png" alt=""></div>
<div><span style="font-size:small">In properties Minimum value was set to 1 and Maxmimun value was set to 180.&nbsp;</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div></div>
<div><span style="font-size:small">In code file, for serial communication i have used libraray</span></div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>

<div class="preview">
<pre class="csharp"><span style="font-size:small"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.Ports.aspx" target="_blank" title="Auto generated link to System.IO.Ports">System.IO.Ports</a>;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>

<div class="preview">
<pre class="js"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SerialPort&nbsp;port&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SerialPort();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;init();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;init()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;port.PortName&nbsp;=&nbsp;<span class="js__string">&quot;COM29&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;port.BaudRate&nbsp;=&nbsp;<span class="js__num">9600</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;port.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;In file <span style="color:#0000ff">
port.PortName=&quot;COM29&quot;</span> write your port name on which arduino is connected. And also baudrate which was set to 9600 in arduino code.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Following lines of code will send value from trackbar control to arduino board</span></div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>

<div class="preview">
<pre class="js"><span style="font-size:small">&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;trackBar1_Scroll(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(port.IsOpen)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;port.WriteLine(trackBar1.Value.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Execute the code and control your servo angles with trackBar. If you have any queries you can ask in Q/A section</span></div>
</div>
<p>&nbsp;</p>
