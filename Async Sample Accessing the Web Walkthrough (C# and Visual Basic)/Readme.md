# Async Sample: Accessing the Web Walkthrough (C# and Visual Basic)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Async
## Topics
- Asynchronous Programming
- Async
## Updated
- 07/29/2013
## Description

<h1>Introduction</h1>
<div><span style="font-size:small"><span>&nbsp;</span></span>
<p><span style="font-size:x-small">You can write asynchronous programs more easily and intuitively by using features that are introduced in Visual Studio 2012. You can write asynchronous code that looks like synchronous code and let the compiler handle the
 difficult callback functions and continuations that asynchronous code usually entails.</span></p>
<p><span style="font-size:x-small">The projects in this sample accompany <a href="http://msdn.microsoft.com/en-us/library/hh300224(v=VS.110).aspx">
Walkthrough: Accessing the Web by Using Async and Await</a>. The&nbsp;walkthrough starts with a synchronous Windows Presentation Foundation (WPF) application (project SyncWalkthrough)&nbsp;that sums the number of bytes in a list of web sites. The walkthrough
 then converts the application to an asynchronous solution by using the new features (projects AsyncWalkthrough and AsyncWalkthrough_HttpClient).</span></p>
&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div><span style="font-size:small"><span>&nbsp;</span></span>
<p><span style="font-size:x-small">1. Unzip the downloaded file.</span></p>
<p><span style="font-size:x-small">2. Open Visual Studio 2012.</span></p>
<p><span style="font-size:x-small">3. On the menu bar, choose File, Open, Project/Solution.</span></p>
<p><span style="font-size:x-small">4. Navigate to the directory that holds the unzipped sample.</span></p>
<p><span style="font-size:x-small">5. Open the solution (.sln) file.</span></p>
<p><span style="font-size:x-small">6. In Solution Explorer, open the shortcut menu for the project you want to run and then choose Set as StartUp Project.</span></p>
<p><span style="font-size:x-small">7. Choose F5 or Ctrl&#43;F5 to build and run the sample</span></p>
<span style="font-size:small"><span>&nbsp;</span></span></div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:x-small">The sample contains the following three projects:</span></p>
<ul>
<li><span style="font-size:x-small">SyncWalkthrough, the synchronous version of the program on which the async version is built.</span>
</li><li><span style="font-size:x-small">AsyncWalkthrough, an asynchronous version that builds a method to access the web.</span>
</li><li><span style="font-size:x-small">AsyncWalkthrough_HttpClient, an asynchronous version that uses an HttpClient method to access the web.</span>
</li></ul>
<p>&nbsp;</p>
<h1>More Information</h1>
<div><span style="font-size:x-small">For more information and step-by-step instructions, see
<a href="http://msdn.microsoft.com/en-us/library/hh300224(v=VS.110).aspx">Walkthrough: Accessing the Web by Using Async and Await</a>.</span></div>
