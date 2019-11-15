# CPU Load Generator
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- .NET
- threading
- .NET Framework 4
- .NET Framework
- Performance Counters
- .NET Framework 4.0
- C# Language
- .NET 4.5
- .NET Development
## Topics
- C#
- threading
- Performance
- Performance Counters
- .NET 4
- Generic C# resuable code
- Performance testing
- Background tasks
- Performance &amp; Scalability
## Updated
- 11/20/2015
## Description

<h1><strong>Introduction</strong></h1>
<p><strong><br>
</strong></p>
<p><span style="font-size:medium"><em>Ever wonder how you can test your application under heavy CPU load. Your current test environment might not be having that much CPU load.&nbsp;</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium"><em>Here is a simple&nbsp;tool </em></span><span style="font-size:medium"><em>to generate the load across different CPUs on a system. It can be easily deployable on a machine.&nbsp;&nbsp;Just run this tool, tune the CPU load
 according to your requirement &amp; start testing your application.</em></span></p>
<p>&nbsp;</p>
<p><strong>Building the Sample</strong></p>
<p><em>It requires .Net framework 4.0 or above to build and run the application</em></p>
<h1><strong>Description&nbsp;</strong></h1>
<p><span style="font-size:small"><em>Consider a scenario, you have application which just works fine on dev machine but when you deploy it on test or production machine
<strong>having high CPU load, </strong>your application perform badly<strong>.&nbsp;</strong>You want to simulate this behavior in dev environment. How would you make sure that your application works fine even machine has very limited CPU bandwidth available?
 To simulate this behavior you need to have a machine which is which CPU consumption is very high.</em></span></p>
<p><span style="font-size:small"><em>To solve this problem you can use <strong>CPU load Generator.
</strong>Just run the application on your dev or test box (or any other box) &amp; adjust the load as per your requirement. It would create that much load on CPU. Now you can test/run your own application to see how it is going to behave under heavy CPU load.</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em>Following are the screenshots. When you open the application, it shows groupbox (having option to select the load) for each CPU on the machine. Click on the radio button to select the load which you want for the given CPU.</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em><img id="115067" src="http://i1.code.msdn.s-msft.com/cpu-load-generator-f2677be1/image/file/115067/1/cpu%20load%20generator.png" alt="" width="476" height="393"></em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em>As soon as you change the option in UI, CPU load would be adjusted accordingly. You can open the task manager to see the CPU load.</em></span></p>
<p><span style="font-size:small"><em><br>
</em></span></p>
<p><img id="115069" src="http://i1.code.msdn.s-msft.com/cpu-load-generator-f2677be1/image/file/115069/1/task%20manager.png" alt="" width="437" height="486"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:medium">Internally it uses Background worker threads to monitor and generate the load on CPU. For thread synchronization it used ManualReset event.</span></p>
<p><span style="font-size:medium">One thread is for continuously monitor the CPU current load &amp; rest are for generating the load on CPU. It used IDiposible pattern to clean up all the resources.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em><br>
</em></span></p>
