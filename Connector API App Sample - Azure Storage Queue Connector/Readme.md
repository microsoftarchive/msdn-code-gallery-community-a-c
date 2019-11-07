# Connector API App Sample - Azure Storage Queue Connector
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Microsoft Azure
- BizTalk
- API App
## Topics
- Development
## Updated
- 04/14/2015
## Description

<h1>
<div class="endscriptcode">
<div class="endscriptcode">Introduction</div>
</div>
</h1>
<p>This Connector API App sample provides connectivity to Azure Storage Queue.&nbsp; It provides the following functionalities:</p>
<ol>
<li>Get Message </li><li>Delete Message </li><li>Send Message </li><li>Trigger on Message Available </li></ol>
<p>This Connector sample illustrates the following:</p>
<ol>
<li>Developing a basic API App </li><li>Adding summary and other annotations from XML Comments </li><li>Dynamically generate swagger based on configuration </li><li>Implementing a basic polling based Trigger </li></ol>
<p>NOTE: This is a sample Connector API App.&nbsp; The purpose of the API App is to illustrate how a Connector can be developed.&nbsp; The codebase, therefore, has bee kept really simple and does not include error handling, validation logic, diagnostic logging,
 optimizations, etc.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<h2>Pre-Requisites:</h2>
<p>You will need the following to use the sample:</p>
<ol>
<li>An Azure Storage account with a couple of Queues </li><li>Visual Studio 2013 </li><li>Azure SDK 2.5.1 or above </li></ol>
<h2>Instructions:</h2>
<ol>
<li>Open web.config and add the necessary Storage Connection string in the following sections:<br>
<br>
&lt;appSettings&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;add key=&quot;StorageConnectionString&quot; value=&quot;{add your Storage Connection String here}&quot;/&gt;<br>
&lt;/appSettings&gt;<br>
<br>
</li><li>Open the project in Visual Studio and Build it. </li></ol>
<h3>Local Testing</h3>
<ol>
<li>Run the project (F5 - Start Debugging) </li><li>Navigate to <a href="http://localhost:24128/swagger">http://localhost:24128/swagger</a>
</li><li>Use the Swagger UI to test the operations </li></ol>
<h3>Publishing to Azure</h3>
<p>Follow the steps in the following tutorial: http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-deploy-api-app/</p>
<p>Testing with Logic Apps</p>
<ol>
<li>Create a Logic App in the same Resource Group where you have published this Connector API App.
</li><li>Follow the steps here: <a href="http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/">
http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/</a>
</li></ol>
<p>HINT: You can configure the Logic App to run manually.&nbsp; Click 'Run Now' to run the Logic App.<em><br>
</em></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span><span style="font-size:20px; font-weight:bold"><br>
</span></p>
<p>The Connector API methods are implemented in the MessagesController class (in the MessagesController.cs file).</p>
<p>It provides the following 3 actions:</p>
<ul>
<li>GetMessage: Reads a message from a Queue. The message is not deleted. </li><li>DeleteMessage: Deletes a message that is previously read from a Queue. </li><li>SendMessage: Sends a message to a Queue. </li></ul>
<p>In addition, it implements a trigger:</p>
<ul>
<li>NewMessageTrigger: Returns a message from a Queue. Previous message is deleted.
</li></ul>
<p>SwaggerConfig class in (SwaggerConfig.cs) defines how the swagger is geenrated.&nbsp; The project is configred to generate XML Comments, and Swagger configuration is configured to use that.&nbsp; It also adds 3 operation filters:</p>
<ul>
<li>AddDefaultResponseFilter: Adds a &quot;default&quot; response object </li><li>DiscoverQueueFilter: adds dynamically an enum that lists all the queues in the configured storage account
</li><li>TriggerStateFilter: adds extra vendor extension fields for the triggerState parameter
</li></ul>
<p>&nbsp;</p>
<p><span>&nbsp;</span></p>
<ul>
</ul>
