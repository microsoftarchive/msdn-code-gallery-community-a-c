# Client-side rendering (JS Link) code samples
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Sharepoint Online
- SharePoint Server 2013
- SharePoint Foundation 2013
- SharePoint 2013
## Topics
- SharePoint
- SharePoint List
- Sharepoint Web Parts
- SharePoint client object model (CSOM)
## Updated
- 03/19/2015
## Description

<p>&nbsp;</p>
<p>Those samples help you learn how to customize a field type by using the <strong>
Client-Side Rendering </strong>(also called <em>CSR</em>, <em>JS Link</em>) technology in SharePoint 2013.</p>
<p>&nbsp;</p>
<p><img id="96784" src="http://i1.code.msdn.s-msft.com/client-side-rendering-js-2ed3538a/image/file/96784/1/spfield.jslink%20templates.png" alt="SPField.JSLink templates " width="662" height="187" style="border:1px solid black"></p>
<p>&nbsp;</p>
<h1>Overview</h1>
<p>Client-side rendering is a new concept in SharePoint 2013. It&rsquo;s provides you with a mechanism that allow you to use your own output render for a set of controls that are hosted in a SharePoint page (<em>list views, display, add and Edit forms</em>).
 This mechanism enables you to use well-known technologies, such as HTML and JavaScript, to define the rendering logic of custom and predefined field types.</p>
<p><br>
JSLink files have the ability to quickly and easily change how a list views and forms are rendered. More specifically how the fields in that list should be displayed.</p>
<p><br>
<strong>Note:</strong> I wrote those code samples to be easy to understand and to achieve learning purposes, because of that I avoided using complex code and controls. In the same time I tried to&nbsp;present real world examples as much as possible.</p>
<p>&nbsp;</p>
<h1>How to deploy the JSLink templates</h1>
<p>You can deploy those JSLink files in many ways, you can use OOTB, LIST schema PowerShell or code.&nbsp;
<br>
I describe in the samples&nbsp;below how to deploy JSLink files using OOTB techniques, but if you want to know more about JSLink deployment methods, I recommend this
<a class="title" title="SharePoint 2013 Client Side Rendering: List Views" href="http://www.codeproject.com/Articles/620110/SharePoint-Client-Side-Rendering-List-Views" target="_blank">
article </a>by Andrei Markeev. <br>
<br>
Before proceeding&nbsp;with the samples, <strong>You have to upload the JavaScript code files on your SharePoint 2013 site</strong>. You can upload to any SharePoint storage document library, _layouts folder or IIS virtual folder, But in the below deployment
 steps<strong> I&rsquo;m supposing you will upload the JSLink-Samples folder to the site collection Style Library</strong>.</p>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 1 (Priority color)</strong></span></p>
<p>Let&rsquo;s start with a simple example, This JSLink sample allows you to change the priority field&nbsp;text color based on the&nbsp;task priority level (<span style="color:#ff0000">High</span>,
<span style="color:#ff6600">Normal </span>and <span style="color:#ffcc00">Low</span>).</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-0a786cdd">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 2 (Substring long text)</strong></span></p>
<p>Our next&nbsp;sample, Will show you how to make the announcements body text shorter and display the whole announcements body text as a tooltip.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-93e7077d">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 3 (Confidential Documents)</strong></span></p>
<p>This JSLink sample will show how to add an icon beside confidential documents name. This icon is added to the document name based on the Confidential field&nbsp;(Yes/No) value.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-97e27fa1">Read More ...</a></h3>
<p>&nbsp;</p>
<p><strong style="color:#3366ff; font-size:medium">Sample 4 (HTML5 number input )</strong></p>
<p>This JSLink sample will demonstrate&nbsp;how to use HTML5 input control Instead of the old HTML in SharePoint New and Edit forms.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-94145281">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 5 (Percent Complete)</strong></span></p>
<p>This JSLink sample will show how to add rendering logic for the Task list Percent Complete field, this code will change the file render to be displayed as a progress bar in
<strong>View </strong>and <strong>Display </strong>forms, and as a scroll input in the
<strong>New </strong>and <strong>Edit </strong>forms.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-f1068b4b">Read More ...</a></h3>
<p>&nbsp;</p>
<p><strong style="color:#3366ff; font-size:medium">Sample 6 (Accordion)</strong></p>
<p>This JSLink sample will show how to <strong>change rendering logic for the whole&nbsp;List View</strong>. This sample will read the Title and Description fields&rsquo; values and render the fields in an accordion style view.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-ccdb2a0e">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 7 (Email Regex Validator)</strong></span></p>
<p>This JSLink sample will show how to add <strong>Regex validation</strong> to input fields&nbsp;inside New and Edit forms.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-80cc9b05">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 8 (Read- Only SP Controls)</strong></span></p>
<p>This JSLink sample will show how to use and <strong>utilize ready sharepoint javascript libraries</strong> to make form fileds uneditable.&nbsp;</p>
<h3><a href="http://code.msdn.microsoft.com/office/Sample-8-List-add-and-edit-d228b751">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 9 (Hidden Field)</strong></span></p>
<p>If you browse this code sample, you will learn how to use <strong>OnPostRender
</strong>template functionality.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-a52cf8a7">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 10 (Hide Empty Column)</strong></span></p>
<p>If you look at this code sample, you will see how to create the CSR Context object, and how to access all reternd list data, then you can use the JQuery to change the view html.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-2625e5e3">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 11 (Form Tabs)</strong></span></p>
<p>This is an advance sample, it will help you to learn how to create the embed css inside your CSR files.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-b2eedf92">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 12 (Repeater)</strong></span></p>
<p>This is an advance sample, it will help you to learn how to utilize your javascript skills to build advanced SharePoint list forms.</p>
<h3><a href="http://code.msdn.microsoft.com/office/Client-side-rendering-code-56649801">Read More ...</a></h3>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#3366ff"><strong>Sample 13 (Fully customized forms with CSRListForm)</strong></span></p>
<p>This Client side rendering code sample will help you to work with CSRListForm and build your sharepoint list forms form scratch and use any form layout and design that you want. .</p>
<h3><a href="https://code.msdn.microsoft.com/office/CSR-code-samples-11-Fully-54ebcaa6">Read More ...</a></h3>
