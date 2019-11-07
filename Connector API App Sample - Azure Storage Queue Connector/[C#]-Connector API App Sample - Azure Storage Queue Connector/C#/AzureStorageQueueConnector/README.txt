
Azure Storage Queue Connector (Sample)

NOTE:
This is a sample Connector API App.  The purpose of this API App sample is to illustrate how a
Connector can be developed.  The codebase, therefore, has been kept very simple and does not
include error handling, validation logic, diagnostic logs, optimizations, etc.

INTRODUCTION:
This Connector API App provides connectivity to Azure Storage Queues.  It provides the following
functionalities:
    (1) Get Message
	(2) Delete Message
	(3) Send Message
	(4) Trigger on Message Available

This Connector API App illustrates the following:
    (1) Developing a basic API App
	(2) Adding summary and other annotations from XML Comments
	(3) Dynamically generate swagger based on configuration
	(4) Implementing a basic polling based Trigger

PRE-REQUISITES:
You will need the following to use this sample.
(1) An Azure Storage Account with a couple of Queues created.
(2) Visual Studio 2013
(3) Azure SDK 2.5.1 or above

INSTRUCTIONS:
(1) Open Web.config and add the necessary Storage Connection String

  <appSettings>
    <add key="StorageConnectionString" value="{add your Storage Connection String here}"/>
  </appSettings>

(2) Open the project in VS 2013 and build the project.

LOCAL TESTING:
(1) Run the project (F5 - Start Debugging).
(2) Navigate to http://localhost:24128/swagger
(3) Use the swagger UI to test the operations

PUBLISHING TO AZURE:
Follow the steps in the following tutorial:
http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-deploy-api-app/

TESING WITH LOGIC APPS:
(1) Create a Logic App in the same Resource Group where you have published this Connector API App.
(2) Follow the steps here: http://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/
Hint: You can configure the Logic App to run manually. Click 'Run Now' to run the Logic App.


DESCRIPTIONS:
(1) Create an empty Web API Project.
(2) Install the "Windows Azure Storage" client library through Nuget.
(3) Add a Controller Class: MessagesController.cs
(4) Add an entry in web.config to store the Connection String.
  <appSettings>
    <add key="StorageConnectionString" value="{storage-key-connector}">
  </appSettings>
(5) MessagesController contains 3 actions:
	GetMessage      - Reads a message from a Queue. The message is not deleted.
	DeleteMessage   - Deletes a message that is previously read from a Queue.
	SendMessage     - Sends a message to a Queue.
(6) MessageController contains 1 trigger:
	NewMessageTrigger  - Returns a message from a Queue. Previous message is deleted automatically.
(7) SwaggerConfig.cs defines how the Swagger is generated.
(8) Swagger configuration is also configured to include XML comments.
	(8a) Configure the project Build properties to generate XML Comments.
	(8b) Uncomment the following lines:
	                        c.IncludeXmlComments(GetXmlCommentsPath());
	(8c) Implement GetXmlCommentsPath() to return the file path of the XML documentation file.
(9) Swagger configuration also adds 3 Operation Filters:
	AddDefaultResponseFilter adds a "default" response object.
	DiscoverQueueFilter adds dynamically an enum that lists all the queues in the configured storage account.
	TriggerStateFilter adds extra vendor extension fields for the "triggerState" parameter



Date Published:
4/12/2015

AUTHOR:
Sameer Chabungbam
Microsoft Corporation

