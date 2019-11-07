# Blob Storage CRUD Operations Using VB, C#
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- Microsoft Azure
- VB.Net
- Microsoft Azure Storage
## Topics
- VB.Net
- Code Sample
- Microsoft Azure Storage
- VB.NET Examples
- CSharp Examples
## Updated
- 03/26/2016
## Description

<h2>Azure Storage: Blobs</h2>
<div class="subhead">Microsoft Azure QuickStarts</div>
<p>Demonstrate how to use the Blob Storage service. Blob storage stores unstructured data such as text, binary data, documents or media files. Blobs can be accessed from anywhere in the world via HTTP or HTTPS.</p>
<p>Note: This sample uses the .NET 4.6 asynchronous programming model to demonstrate how to call the Storage Service using the storage client libraries asynchronous API's. When used in real applications this approach enables you to improve the responsiveness
 of your application. Calls to the storage service are prefixed by the await keyword.</p>
<p>If you don't have a Microsoft Azure subscription you can get a FREE trial account
<a href="http://go.microsoft.com/fwlink/?LinkId=330212">here</a>.</p>
<p>If you don't have azure SDK installed in your machine you can download from <a href="https://azure.microsoft.com/en-in/downloads/">
here.</a></p>
<h2>Running this sample</h2>
<p>This sample can be run using either the Azure Storage Emulator that installs as part of Azure SDK - or by updating the App.Config file with your AccountName and Key.</p>
<p>To run the sample using the Storage Emulator (default option)</p>
<ol>
<li>Start the Azure Storage Emulator (once only) by pressing the&nbsp;Start&nbsp;button or the&nbsp;Windows&nbsp;key and searching for it by typing &quot;Azure Storage Emulator&quot;. Select it from the list of applications to start it.
</li><li>Set breakpoints and run the project using F10. </li></ol>
<p>To run the sample using the Storage Service</p>
<ol>
<li>Open the app.config file and comment out the connection string for the emulator (UseDevelopmentStorage=True) and uncomment the connection string for the storage service (AccountName=[]...)
</li><li>Create a Storage Account through the Azure Portal and provide your [AccountName] and [AccountKey] in the App.Config file.
</li><li>Set breakpoints and run the project using F10.&nbsp; </li></ol>
