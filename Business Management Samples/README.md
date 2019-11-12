# Business Management Samples
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- library assembly
- Microsoft Dynamics CRM SDK
## Updated
- 12/18/2017
## Description

<h1>Introduction</h1>
<p>These samples show how to create a simple queue instance, how to share a queue to the team, how to assign queue item work to some user, how to delete inactive items in a queue and how to configure a queue's email properties.</p>
<h1>Requirements</h1>
<p>For more information about the requirements for running the sample code provided in this SDK, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code">
Use the sample and helper code</a></p>
<h1>Sample: Create a queue(Early bound)</h1>
<p>This sample shows how to create a simple queue and set required attributes.</p>
<p>Click here to see the <a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=355060376">
CreateQueue.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-create-queue-early-bound">Sample: Create a Queue (Early Bound)</a>.</p>
<h1>Sample: Configure email for a queue(Early bound)</h1>
<p>This sample shows how to give a team limited access to a queue. A queue is shared, and a team is given full access to the queue items, such as create, delete, retrieve, and update. However, they can only retrieve a queue.</p>
<p>Click here to see the <a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=922671312">
ConfigureQueueEmail.cs</a> sample file.</p>
<h1>Sample: Assign a Queue to a Team(Early bound)</h1>
<p>This sample shows how to assign a queue to a team.</p>
<p>Click here to see the <a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=1388133322">
AssignQueueItemWorker.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-assign-record-team" target="_blank">Sample: Assign a Queue to a Team(Early Bound)</a>.</p>
<h1>Sample: Delete a Queue(Early bound)</h1>
<p>This sample shows how to delete a queue.</p>
<p>Click here to see the <a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=1255139563">
DeleteQueue.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-delete-queue-early-bound">Sample: Delete a Queue</a>.</p>
<h1>Sample: Add a Record to a Queue(Early Bound)</h1>
<p>This sample shows how to add a record to a queue. It creates source and destination queues. It adds a letter activity to the source queue and then moves it to the destination queue.</p>
<p>Click here to see the <a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=232862611">
AddToQueue.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-add-record-queue-early-bound">Sample: Add a Record to a Queue(Early Bound)</a>.</p>
<h1>Sample: Clean up History for a Queue(Early Bound)</h1>
<p>This sample shows how to clean up the history for the queue by deleting inactive items. It finds completed phone calls in the queue and deletes the associated queue items. Note that the completed phone calls are not deleted by this action.</p>
<p>Click here to see the <a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=929809832">
CleanUpQueueItems.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-clean-up-history-queue-early-bound">Sample: Clean up History for a Queue(Early Bound)</a>.</p>
<h1>Sample: Release a Queue Item to the Queue Using (Early Bound)</h1>
<p>This sample shows how to dissociate a user from a queue item that he or she worked on and release a queue item back to the queue.</p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=1335288897">RemoveQueueItemWorker.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-release-queue-item-queue-early-bound">Sample: Release a Queue Item to the Queue (Early Bound)</a>.</p>
<h1 class="title">Sample: Query connections by a record (early bound)</h1>
<p><span>This sample shows how to query connections for a particular record. It creates connections between a contact and two accounts, and then searches for the contact&rsquo;s connections.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=2065427711">QueryConnections.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-query-connections-record-early-bound">
Sample: Query connections by a record(early bound)</a>.</p>
<h1 class="title">Sample: Query Connection Roles by Entity Type Code (Early Bound)</h1>
<p><span>This sample shows how to use a query to find a connection role for an account entity by specifying an entity type code.</span></p>
<p><span>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=1103619339">QueryConnectionRolesByEntityTypeCode.cs</a>&nbsp;sample file.</span></p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-query-connection-roles-entity-type-code-early-bound">
Sample: Query connection roles by Entity Type Code(Early bound)</a>.</p>
<h1 class="title">Sample: Query connections by reciprocal roles (early bound)</h1>
<p><span>This sample shows how to create matching roles and then find a matching role for a particular role.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=2064620162">QueryConnectionRolesByReciprocalRole.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-query-connections-reciprocal-roles-early-bound">
Sample: Query connections by reciprocal roles(early bound)</a>.</p>
<h1 class="title">Sample: Update a connection role (early bound)</h1>
<p><span>This sample shows how to modify the properties of the connection role, such as a role name, description, and category.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=1641115563">UpdateConnectionRole.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-update-connection-role-early-bound">
Sample: Update a connection role(early bound)</a>.</p>
<h1 class="title">Sample: Process quotes, sales orders and invoices</h1>
<p><span>This sample shows how to convert an opportunity that is won to a quote, then convert a quote to a sales order, and then convert a sales order to an invoice. It also shows how to lock and unlock the sales order and the invoice prices.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=862099874">ProcessingQuotesAndSalesOrders.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-process-quotes-sales-orders-invoices">
Sample: Process quotes, sales orders and invoices</a>.</p>
<h1 class="title">Sample: Retrieve time zone information</h1>
<p><span>This sample shows how to retrieve time zone information.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=1705105128">WorkingWithTimeZones.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-retrieve-time-zone-information">
Sample: Retrieve time zone information</a>.</p>
<h1 class="title">Sample: Serialize and deserialize an entity Instance</h1>
<p><span>This sample shows how to serialize early-bound and late-bound entity instances into an XML format, and how to de-serialize from an XML format to an early-bound entity instance.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=801838078">SerializeAndDeserialize.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-serialize-deserialize-entity-instance">
Sample: Serialize and deserialize and entity Instance</a>.</p>
<h1 id="sample-validate-record-state-and-set-the-state-of-the-record">Sample: Validate record state and set the state of the record</h1>
<p><span>This sample shows how to validate a change of state of an entity and set a state of an entity.</span></p>
<p>Click here to see the&nbsp;<a href="https://code.msdn.microsoft.com/Business-Management-Samples-6a482e62/sourcecode?fileId=182728&pathId=784312487">ValidateAndSetState.cs</a>&nbsp;sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-validate-record-state-set-state-record">
Sample: Validate record state and set the state of the record</a>.</p>
