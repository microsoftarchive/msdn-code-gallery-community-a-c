# C# Console - Linear Sequential Search Algorithm
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Console
- Visual C#
## Topics
- C#
- Console Window
- Visual C#
## Updated
- 08/14/2017
## Description

<p><span style="color:#0000ff"><strong>Console Version</strong></span></p>
<p>The algorithm is a very important basic subject for computer science. In short, the algorithm is to use the computer to learn mathematics (ancient people with arithmetic, modern computer operator), can be said to be math subjects.<br>
To solve all kinds of problems in real life, computer scientists put real problems corresponding to mathematical problems, and then design formulas, the formula written procedures, so that the computer program to calculate the answer - these formulas are called
 algorithms.<br>
Although the word &quot;formula&quot; is used to describe the algorithm, it is not the mathematical formula in the impression. As the computer can perform complex calculations, so the formula can be designed into dozens of rows, hundreds of lines, and even use a lot
 of mathematical theory.<br>
So, even if the study of the algorithm of the people, but also do not know how to design algorithms; because mathematics, program things are too complicated. Want to correspond to the real problem of mathematics, it is more complicated.</p>
<p><span style="font-size:10px">The algorithm is in the computer project inside, I would like to have someone who wrote the program, should have at least heard the noun.</span></p>
<p>Introduce a common search algorithm - Linear / Sequential Search <span>algorithm</span>, named thought, is the way to find the matching information,</p>
<p>The concept is very simple, but also commonly used, that is, directly with the loop to compare, find the return when the results.</p>
<p>In the following example, in the window of the Console through a long list of incomplete numbers, find the number you want to search:</p>
<p>&nbsp;<img id="176956" src="176956-1.jpg" alt="" width="676" height="443"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">int value = -1;
for (int i = 0; i &lt; list.Length; i&#43;&#43;)
{
	if (list[i] == item)
	{
		value = i;
		break;
	}
}
return value;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">int</span>&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;list.Length;&nbsp;i&#43;&#43;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(list[i]&nbsp;==&nbsp;item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">value</span>;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><span style="font-size:10px">The same use in the WPF, but also can operate the same way to design:</span></p>
<p>&nbsp;<img id="176957" src="176957-2.jpg" alt="" width="525" height="350"></p>
<p>&nbsp;</p>
<p>You can see the results of the algorithm：</p>
<p><img id="176958" src="176958-3.jpg" alt="" width="400" height="400"></p>
<p>&nbsp;</p>
<p>This method is not the same way, it will be the result of the latter is not dealt with, to reduce the effectiveness of the system, which for a large number of data search, a great help.</p>
<p>Of course, it can be used with a string processing.</p>
<p>There is a complete program and interface design structure, I will not explain in detail how to design interface.</p>
