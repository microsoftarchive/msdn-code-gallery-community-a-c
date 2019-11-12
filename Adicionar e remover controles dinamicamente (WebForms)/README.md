# Adicionar e remover controles dinamicamente (WebForms)
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Visual Studio 2010
- .NET Framework
## Topics
- Controls
- ASP.NET
- User Interface
- Repeater
## Updated
- 07/23/2013
## Description

<h1>Introduction</h1>
<p><em>This example shows how to add and remove controls dynamically form on one page Asp.Net WebForms, preserving the state of these controls and according to the will and needs of the end user.</em></p>
<p><em>Presentation code the following topics:</em></p>
<ul>
<li><em>Using the Repeater control</em> </li><li><em>Use the ItemCommand event</em> </li><li><em>Generation controls variable amount</em> </li><li><em>Demonstration of the behavior and life cycle of Asp.Net WebForms pages (Page_Load PostBack, among others)</em>
</li><li><em>Get value of existing controls inside a Repeater control</em> </li></ul>
<h1><span>Building the Sample</span></h1>
<p><em>To develop this example were used, and the below the following steps:</em></p>
<ul>
<li><em>Creating a form called Default.aspx</em> </li><li><em>Using a Repeater control on the page Template which possesses a text field and a button for removing items, along with the caption of left field.</em>
</li><li><em>Configuration associated with Repeater ItemCommand event</em> </li><li><em>Creating a button to add new descriptions</em> </li><li><em>Creation of the button's OnClick method to add new items.</em> </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>To test the example, after downloading the project files and run it, the only constant in our project, add new fields on the form with the green button and remove items with the red button.</em></p>
<p><img id="92779" src="92779-print.jpg" alt="" width="840" height="232"></p>
<p>I believe that this is one of the existing forms to allow the user to add and remove values ​​in multiple controls, without a pre-defined amount.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Default.aspx - form with the html, css and server controls.</em> </li><li><em><em>Default.cs - C # file that contains the class associated with the page, with its properties and events.</em></em>
</li><li><em><em>Images folder - contains the images of the project</em></em> </li><li><em><em>Web.config - contains the project settings.</em></em> </li></ul>
<h1>More Information</h1>
<p><em>Well folks, this is a simple example, but hopefully it will help more people than ever need to do something similar, especially those who are starting their journey in web development<br>
&nbsp;<br>
Regards to all.</em></p>
