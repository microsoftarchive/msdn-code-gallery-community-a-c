# C# Console Double Buffer
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Win32
## Topics
- Interop
- Win32 Interop
- buffer
- double buffer
- flickering
## Updated
- 02/16/2013
## Description

<h1>Introduction</h1>
<p><em>(2/16/2013) I am currently working on an update to this project. There is no ETA when it will be finihsed, as I have other projects that take priority.</em></p>
<address>v 1.2.0</address>
<address>- Added clearRow(int row)</address>
<address>- Added clearColumn(int col)</address>
<address>- Added getCharAt(int x, int y)</address>
<address>- Functions now throw exceptions for out of bound indexes and null</address>
<address>- Code cleanup</address>
<address>v 1.1.0</address>
<address>-Added SetDrawCord(short x, short y) method</address>
<address><em>v 1.0.0</em></address>
<address>-Initial Release</address>
<p><em>Let me know if you want me to conintue updating this by rating it! </em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Simply save the code as a class, and create a new instance of the object to get started. If you are having trouble figureing it out, simply ask a question.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This code creates a new buffer, filling it with empty characters. Below is the buffer.Draw() class. This is the function you will probably use the most. To use it, simply input the string you wish to write to the buffer, followed by the starting width
 and height of the text, and finally a number for the attribute. Numbers 1-15 are all of the colors console supports with a black background. Numbers 16-30 have the same sequence of foreground colors, but a blue background color. This pattern continues for
 all colors.</em></p>
<p>Whenever you want to draw the buffer, call buffer.draw. One important thing to remember is that the buffer is not cleared when drawn, so when you want to make changes, simply input the changes into the buffer, and redraw!</p>
<p><strong>Update v 1.2.0</strong></p>
<p>There are three new functions added to this release. clearRow will clear the specified row, setting all characters to empty spaces, and all attributes to 1. clearColumn does the same thing, but clears the specified column instead. getCharAt(int x, int y)
 will get the character at the specified location and return both the character (as a byte) and the attribute using KeyValuePair.</p>
<p>I have added exceptions to the code so you can no longer input non-existant values. In addition, I have doen a little clean up to make the code look better.</p>
<p><strong>Update v 1.1.0</strong></p>
<p>I have now included the buffer.SetDrawCord() function. This allows you to draw a buffer anywehre on the screen. Simply input the X and Y cordnants that represent the upper left corner of the buffer you wish to draw.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
        /// This method draws any text to the buffer with given color.
        /// To chance the color, pass in a value above 0. (0 being black text, 15 being white text).
        /// Put in the starting width and height you want the input string to be.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;str&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;Width&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;Height&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;attribute&quot;&gt;&lt;/param&gt;
        public void Draw(String str, int Width, int Height,short attribute) //Draws the image to the buffer
        {
            if (Width &gt; windowWidth - 1 || Height &gt; windowHeight - 1)
            {
                throw new System.ArgumentOutOfRangeException();
            }
            if (str != null)
            {
                Char[] temp = str.ToCharArray();
                int tc = 0;
                foreach (Char le in temp)
                {
                    buf[(Width &#43; tc) &#43; (Height*width)].Char.AsciiChar = (byte)(int)le; //Height * width is to get to the correct spot (since this array is not two dimensions).
                    if(attribute != 0)
                        buf[(Width &#43; tc) &#43; (Height * width)].Attributes = attribute;
                    tc&#43;&#43;;
                }
            }
                
           
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;This&nbsp;method&nbsp;draws&nbsp;any&nbsp;text&nbsp;to&nbsp;the&nbsp;buffer&nbsp;with&nbsp;given&nbsp;color.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;To&nbsp;chance&nbsp;the&nbsp;color,&nbsp;pass&nbsp;in&nbsp;a&nbsp;value&nbsp;above&nbsp;0.&nbsp;(0&nbsp;being&nbsp;black&nbsp;text,&nbsp;15&nbsp;being&nbsp;white&nbsp;text).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Put&nbsp;in&nbsp;the&nbsp;starting&nbsp;width&nbsp;and&nbsp;height&nbsp;you&nbsp;want&nbsp;the&nbsp;input&nbsp;string&nbsp;to&nbsp;be.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;str&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;Width&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;Height&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;attribute&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Draw(String&nbsp;str,&nbsp;<span class="cs__keyword">int</span>&nbsp;Width,&nbsp;<span class="cs__keyword">int</span>&nbsp;Height,<span class="cs__keyword">short</span>&nbsp;attribute)&nbsp;<span class="cs__com">//Draws&nbsp;the&nbsp;image&nbsp;to&nbsp;the&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Width&nbsp;&gt;&nbsp;windowWidth&nbsp;-&nbsp;<span class="cs__number">1</span>&nbsp;||&nbsp;Height&nbsp;&gt;&nbsp;windowHeight&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;System.ArgumentOutOfRangeException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(str&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Char[]&nbsp;temp&nbsp;=&nbsp;str.ToCharArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;tc&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Char&nbsp;le&nbsp;<span class="cs__keyword">in</span>&nbsp;temp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buf[(Width&nbsp;&#43;&nbsp;tc)&nbsp;&#43;&nbsp;(Height*width)].Char.AsciiChar&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(<span class="cs__keyword">int</span>)le;&nbsp;<span class="cs__com">//Height&nbsp;*&nbsp;width&nbsp;is&nbsp;to&nbsp;get&nbsp;to&nbsp;the&nbsp;correct&nbsp;spot&nbsp;(since&nbsp;this&nbsp;array&nbsp;is&nbsp;not&nbsp;two&nbsp;dimensions).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(attribute&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buf[(Width&nbsp;&#43;&nbsp;tc)&nbsp;&#43;&nbsp;(Height&nbsp;*&nbsp;width)].Attributes&nbsp;=&nbsp;attribute;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tc&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Double Buffer - Containes the object itself, and an example static void main class to show the use of the buffer.</em>
</li></ul>
