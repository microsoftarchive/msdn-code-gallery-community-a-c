# Azure Cloud Service Multi-Tier Application with Tables, Queues, and Blobs
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- Windows Azure Storage
- Windows Azure Tables
- Windows Azure Storage Queues
- Windows Azure Storage Blobs
## Topics
- ASP.NET
- Send Email
- Microsoft Azure
- Data Access
- ASP.NET MVC
- Web Services
- Deployment
- Windows Azure Storage
- SendGrid
## Updated
- 10/27/2014
## Description

<h1>Introduction</h1>
<p>A Visual Studio project that shows how to use Windows Azure Storage tables, queues, and blobs in a multi-tier application that has an ASP.NET MVC web role on the front-end and worker roles on the back-end.</p>
<p><strong>NOTE:</strong></p>
<p>The sample&nbsp;works with&nbsp;Visual Studio 2013, MVC 5, and&nbsp;Azure .NET SDK 2.3. The accompanying tutorial does not provide instructions for making the project work with other versions of the Azure .NET SDK.</p>
<p>If you want the old Visual Studio 2012 version because you're using a version of the tutorial designed for VS 2012, you can still get that -- it's included in a .zip file in the&nbsp;solution folder.</p>
<h1><span>Building the Sample</span></h1>
<p>To run the project, download it and follow the directions in the tutorial. The tutorial is provided in PDF and Word files in the solution folder. (The tutorial was on the azure.microsoft.com site but is being retired until we can update it for the latest
 Azure SDK.) If you follow the build-from-scratch instructions in the tutorial and install the most current SendGrid NuGet package, you might find breaking changes in the SendGrid API.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The sample and the accompanying tutorial demonstrate how to use features of Windows Azure and tools you can use with Windows Azure:</p>
<ul>
<li>How to&nbsp;work with&nbsp;a Visual Studio cloud project&nbsp;that has&nbsp;an MVC 4 web role and two worker roles. The tutorial also&nbsp;explains how to run the web front-end in a Windows Azure Web Site instead of including it in the Cloud Service.
</li><li>How to publish&nbsp;a cloud project to a Windows Azure Cloud Service. </li><li>How to use the Windows Azure Queue storage service for communication between tiers or between worker roles.
</li><li>How to use the Windows Azure Table storage service as a highly scalable data store for structured non-relational data.
</li><li>How to use the Windows Azure Blob service to store files in the cloud. </li><li>How to work with Windows Azure tables, blobs, and queues in MVC 4 controllers and views.
</li><li>How to view and edit Windows Azure tables, queues, and blobs by using Visual Studio or Azure Storage Explorer.
</li><li>How to use SendGrid to send emails. </li><li>How to configure tracing and view trace data. </li><li>How to handle planned shut-downs by overriding the OnStop method. </li><li>How to scale an application by increasing the number of worker role instances.&nbsp;
</li></ul>
<p>The sample is a mailing list application. The front-end includes web pages that administrators of the service use to manage email lists.</p>
<p><img id="68589" src="68589-mtas-mailing-list-index-page.png" alt="" width="599" height="580"></p>
<p>&nbsp;<img id="68590" src="68590-mtas-subscribers-index-page.png" alt="" width="568" height="532"></p>
<p><img id="68591" src="68591-mtas-message-index-page.png" alt="" width="597" height="560"></p>
<p>The front-end also enables users to subscribe to lists and unsubscribe from lists by using web pages and a Web API service method.&nbsp; The back-end&nbsp;has two worker roles, one to schedule emails and one to send them.</p>
<p><img id="72768" src="http://i1.code.msdn.s-msft.com/windows-azure-multi-tier-eadceb36/image/file/72768/1/mtas-worker-roles-a-and-b.png" alt="" width="590" height="543">&nbsp;</p>
<p>The application uses Windows Azure Storage tables to store email lists, subscribers, and messages to be sent to email lists.&nbsp; It uses queues to coordinate work between the two worker roles and between the web role and the worker role that sends emails.&nbsp;
 It enables administrators to upload the body of a message in HTML and plain text files, and it stores these files in blob storage.&nbsp;</p>
<h1>More Information</h1>
<p>For more information, see the tutorial that accompanies the sample, which is included in the download as described in
<strong>Building the Sample</strong>.</p>
