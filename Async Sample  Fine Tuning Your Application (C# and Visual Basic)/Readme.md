# Async Sample:  Fine Tuning Your Application (C# and Visual Basic)
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
- 02/26/2013
## Description

<h1>Introduction</h1>
<p>You can add precision and flexibility to your async applications by using the methods and properties that the
<a href="http://msdnstage.redmond.corp.microsoft.com/en-us/library/system.threading.tasks.task(VS.110).aspx">
Task</a> type makes available. The projects in this sample use <a href="http://msdnstage.redmond.corp.microsoft.com/en-us/library/system.threading.cancellationtoken(VS.110).aspx">
CancellationToken</a> and important Task methods such as <a href="http://msdnstage.redmond.corp.microsoft.com/en-us/library/system.threading.tasks.task.whenall(VS.110).aspx">
Task.WhenAll</a> and <a href="http://msdnstage.redmond.corp.microsoft.com/en-us/library/system.threading.tasks.task.whenany(VS.110).aspx">
Task.WhenAny</a>.</p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Unzip the downloaded file. </li><li>Open Visual Studio 2012 or Visual Studio Express 2012 for Windows Desktop. </li><li>On the menu bar, choose File, Open, Project/Solution. </li><li>Navigate to the directory that holds the unzipped sample. </li><li>Open the solution (.sln) file. </li><li>In Solution Explorer, open the shortcut menu for the project you want to run and then choose Set as StartUp Project.
</li><li>Choose F5 or Ctrl&#43;F5 to build and run the sample. </li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The examples in this sample show you how to do the following:</p>
<ul>
<li>Cancel a Task (project CancelATask) </li><li>Cancel a list of Tasks (project CancelAListOfTasks) </li><li>Cancel Tasks after a period of time(project CancelAfterTime) </li><li>Cancel remaining Tasks after one is complete (project CancelAfterOneTask) </li><li>Start multiple tasks and process them as they complete (project ProcessTasksAsTheyFinish)
</li></ul>
<h1>More Information</h1>
<p>For more information about these projects, see <a href="http://msdnstage.redmond.corp.microsoft.com/library/jj155761.aspx">
Fine Tuning&nbsp;Your Async&nbsp;Application</a>. For more information about using async and await, see
<a href="http://msdn.microsoft.com/en-us/library/hh191443(v=VS.110).aspx">Asynchronous Programming with Async and Await</a> and the topics&nbsp;that are described&nbsp;there.</p>
