# Async Sample: Make Multiple Web Requests in Parallel (C# and Visual Basic)
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
<div>This sample contains the code for <a href="http://msdn.microsoft.com/en-us/library/hh696703">
How to: Make Multiple Web Requests in Parallel</a>. The sample shows you how to separate creating&nbsp;a task from awaiting the task if your program has other work to accomplish that doesn&rsquo;t depend on the completion of the task.</div>
<div>Step by step instructions can be found in the How-to topic.</div>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Unzip the downloaded file. </li><li>Open Visual Studio 2012 or Visual Studio Express 2012 for Windows Desktop. </li><li>On the menu bar, choose File, Open, Project/Solution. </li><li>Navigate to the directory that holds the unzipped sample. </li><li>Open the solution (.sln) file. </li><li>Choose F5 or Ctrl&#43;F5 to build and run the sample. </li></ol>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div>Async makes it easy to set up asynchronous applications. In most cases, you await an asynchronous call immediately, but you don't have to. If the calling method has other work to do that is independent of the results of the asynchronous call, you can call
 the async method, do the independent work, then await the results of the call.</div>
<div>In the following example, a call is made to an async method, someWebAccessMethodAsync. The method returns a Task or Task&lt;TResult&gt;, which is assigned to myTask. At that point, myTask is active, but the calling method can continue to do other work
 until myTask is awaited.</div>
<div>&nbsp;</div>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// The following line creates and starts the task.
var myTask = someWebAccessMethodAsync(url);

// While the task is running, you can do other work that doesn't depend
// on the results of the task.
// . . . . .

// The application of await suspends the rest of this method until the task is complete.
var result = await myTask;</pre>
<pre class="hidden">' The following line creates and starts the task.
Dim myTask = someWebAccessMethodAsync(url)

' While the task is running, you can do other work that does not depend
' on the results of the task.
' . . . . .

' The application of Await suspends the rest of this method until the task is 
' complete.
Dim result = Await myTask</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;The&nbsp;following&nbsp;line&nbsp;creates&nbsp;and&nbsp;starts&nbsp;the&nbsp;task.</span>&nbsp;
var&nbsp;myTask&nbsp;=&nbsp;someWebAccessMethodAsync(url);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;While&nbsp;the&nbsp;task&nbsp;is&nbsp;running,&nbsp;you&nbsp;can&nbsp;do&nbsp;other&nbsp;work&nbsp;that&nbsp;doesn't&nbsp;depend</span>&nbsp;
<span class="cs__com">//&nbsp;on&nbsp;the&nbsp;results&nbsp;of&nbsp;the&nbsp;task.</span>&nbsp;
<span class="cs__com">//&nbsp;.&nbsp;.&nbsp;.&nbsp;.&nbsp;.</span>&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;The&nbsp;application&nbsp;of&nbsp;await&nbsp;suspends&nbsp;the&nbsp;rest&nbsp;of&nbsp;this&nbsp;method&nbsp;until&nbsp;the&nbsp;task&nbsp;is&nbsp;complete.</span>&nbsp;
var&nbsp;result&nbsp;=&nbsp;await&nbsp;myTask;</pre>
</div>
</div>
</div>
This sample fires off three web downloads without immediately awaiting them. The downloads can run in parallel until the tasks are awaited.</span></div>
<h1>More Information</h1>
<div><em>For more information on async programming, see <a href="http://msdn.microsoft.com/en-us/library/hh191443">
Programming with Async and Await</a>.</em></div>
