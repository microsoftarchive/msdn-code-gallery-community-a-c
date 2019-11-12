# Async Sample: Control Flow in Async Programs (C# and Visual Basic)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Async
## Topics
- Asynchronous Programming
## Updated
- 02/26/2013
## Description

<h1>Introduction</h1>
<p><span style="font-size:x-small">You can write and maintain asynchronous programs more easily by using the
<span class="input">Async</span> and <span class="input">Await</span> keywords. However, the results might surprise you if you don't understand how your program operates. This sample contains the code that is used in
<a href="http://msdn.microsoft.com/en-us/library/hh873191">Control Flow in Async Programs</a>. The topic traces the flow of control through a simple async program to show you when control moves from one method to another and what information is transferred
 each time.</span></p>
<h1><span>Building the Sample</span></h1>
<ol>
<li><span style="font-size:x-small">Unzip the downloaded file. </span></li><li><span style="font-size:x-small">Open Visual Studio 2012 or Visual Studio Express 2012 for Windows Desktop.
</span></li><li><span style="font-size:x-small">On the menu bar, choose File, Open, Project/Solution.
</span></li><li><span style="font-size:x-small">Navigate to the directory that holds the unzipped sample.
</span></li><li><span style="font-size:x-small">Open the solution (.sln) file. </span></li><li><span style="font-size:x-small">Choose F5 or Ctrl&#43;F5 to build and run the sample.<em>&nbsp;</em>
</span></li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:x-small">This sample uses async methods to download the contents of a specified website as a string and to display the length of the string. The example contains the following two methods.</span></p>
<ul>
<li>
<p><span style="font-size:x-small"><span class="code">startButton_Click</span>, which calls
<span class="code">AccessTheWebAsync</span> and displays the result.</span></p>
</li><li>
<p><span style="font-size:x-small"><span class="code">AccessTheWebAsync</span>, which downloads the contents of a website as a string and returns the length of the string.
<span class="code">AccessTheWebAsync</span> uses an asynchronous <a href="http://msdn.microsoft.com/en-us/library/system.net.http.httpclient(v=vs.110)">
HttpClient</a> method, <a href="http://msdn.microsoft.com/en-us/library/hh551746(v=vs.110)">
GetStringAsync</a>, to download the contents.</span></p>
</li></ul>
<p><span style="font-size:x-small">Numbered display lines appear at strategic points throughout the program to help you understand how the program runs and to explain what happens at each point that is marked. The display lines are labeled &quot;ONE&quot; through &quot;SIX.&quot;
 The labels represent the order in which the program reaches these lines of code.</span></p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><span style="font-size:x-small">For more information, see <a href="http://msdn.microsoft.com/en-us/library/hh873191">
Control Flow in Async Programs</a>&nbsp;or <a href="http://msdn.microsoft.com/en-us/library/hh191443">
Asynchronous Programming with Async and Await (C# and Visual Basic)</a>.</span></p>
