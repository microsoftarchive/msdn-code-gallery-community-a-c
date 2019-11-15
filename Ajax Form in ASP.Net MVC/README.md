# Ajax Form in ASP.Net MVC
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- JSON
- ASP.NET MVC
- Javascript
- ASP.NET MVC 5
## Topics
- ASP.NET MVC
- Jquery Ajax
- Post in ASP.NET MVC
## Updated
- 07/24/2016
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This project shows that how to submit a form using Ajax with jQuery and show custom messages accordingly. The callback methods are used to show both success and error messages on same view.</span></p>
<p><span style="font-size:small">The code illustrates the following topics</span></p>
<ul>
<li><span style="font-size:small">Submit form using Ajax with help of jQuery.</span>
</li><li><span style="font-size:small">Show custom error and success messages with help of callback methods.</span>
</li><li><span style="font-size:small">Listing page reload after successful submission form and shows data in listing.</span>
</li><li><span style="font-size:small">Use of Object Oriented JavaScript and UI designed using Bootstrap.</span>
</li><li><span style="font-size:small">Response always returns as a Json data</span> </li></ul>
<h1>Getting Started</h1>
<p><span style="font-size:small">To build and run this sample as-is, you must have Visual Studio 2013 installed. In most cases you can run the application by following these steps:</span></p>
<ol>
<li><span style="font-size:small">Download and extract the .zip file.</span> </li><li><span style="font-size:small">Open the solution file in Visual Studio.</span>
</li><li><span style="font-size:small">Build the solution, which automatically installs the missing NuGet packages.</span>
</li><li><span style="font-size:small">Run the application.</span> </li><li><span style="font-size:small">Click on &ldquo;Add User&rdquo; button and fill up requested data in form and click on submit button which shows on listing page.</span>
</li></ol>
<p><img id="157094" src="https://i1.code.msdn.s-msft.com/ajax-form-in-aspnet-mvc-fddd0818/image/file/157094/1/1.png" alt="" width="594" height="290"></p>
<p><span style="font-size:small">Figure 1:&nbsp;Add User UI Form</span></p>
<p><span style="font-size:small"><img id="157095" src="https://i1.code.msdn.s-msft.com/ajax-form-in-aspnet-mvc-fddd0818/image/file/157095/1/2.png" alt="" width="601" height="212"></span></p>
<p><span style="font-size:small">Figure 2:&nbsp;Landing Page Screen</span></p>
<h1>Source Code Overview</h1>
<p><span style="font-size:small">Most of folders and files are used as per ASP.NET MVC conventions.</span></p>
<p><span style="font-size:small"><em>Serialization:</em> This folder has custom classes for response result&nbsp; from action method.</span><br>
<span style="font-size:small"><em>BaseController.cs:</em> it contains base method to return response in json from post action and custom error message action result.</span></p>
<p><span style="font-size:small"><br>
</span></p>
