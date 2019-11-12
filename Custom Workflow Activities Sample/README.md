# Custom Workflow Activities Sample
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- library assembly
- Microsoft Dynamics CRM SDK
## Updated
- 11/14/2017
## Description

<h1>Custom Workflow Activities Sample</h1>
<p>Microsoft Dynamics 365 (online &amp; on-premises) supports the registration and execution of custom workflow activities in addition to the out-of-box activities provided by Windows Workflow Foundation. Windows Workflow Foundation includes an activity library
 that provides activities for control flow, sending and receiving messages, doing work in parallel, and more. However, to build applications that satisfy your business needs, you may need activities that perform tasks specific to that application. To make this
 possible, Windows Workflow Foundation supports the creation of custom workflow activities.</p>
<p>You can write custom workflow activities in Microsoft Visual C# or Microsoft Visual Basic .NET code by creating an assembly that contains one or more classes derived from the Windows Workflow FoundationCodeActivity class. This assembly is annotated with
 .NET attributes to provide the metadata that Microsoft Dynamics 365 uses at runtime to link your code to the workflow engine.</p>
<p>After you have created an assembly that contains one or more custom workflow activities, you register this assembly with Microsoft Dynamics 365. This process is similar to registering a plug-in. The custom workflow activity can then be incorporated into
 a workflow or dialog in the Process form in Microsoft Dynamics 365.</p>
<p>For more information, see <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/custom-workflow-activities-workflow-assemblies" target="_blank">
Custom Workflow Activities(workflow assemblies)</a></p>
<h2>Requirements</h2>
<p>For more information about the requirements for running the sample code provided in this SDK, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/custom-workflow-activities-workflow-assemblies" target="_blank">
Use the sample and helper code</a></p>
<h2>Sample: Create a custom workflow activity</h2>
<p>This sample shows how to write a custom workflow activity that can create an account and a task for the account. This sample uses early binding.</p>
<p><a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/workflow/sample-create-custom-workflow-activity" target="_blank">Sample: Create a custom workflow activity</a></p>
<h2>Sample: Update next birthday using a custom workflow activity</h2>
<p>The following sample workflow activity returns the next birthday. Use this in a workflow that sends a birthday greeting to a customer.</p>
<p><a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/workflow/sample-update-next-birthday-using-custom-workflow-activity" target="_blank">Sample: Update next birthday using a custom workflow activity</a></p>
<h2>Sample: Calculate a credit score with a custom workflow activity</h2>
<p>The following sample workflow activity calculates the credit score based on the Social Security Number (SSN) and name.</p>
<p><a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/workflow/sample-calculate-credit-score-custom-workflow-activity">Sample: Calculate a credit score with a custom workflow activity</a></p>
<h2>Sample: Post data in a URL</h2>
<p>&nbsp;</p>
<h2>Sample: Calculate the shortest distance between two points based on their zipcodes</h2>
<p>&nbsp;</p>
<h2>Sample: Check if the &quot;Est. Close Date&quot; is greater than 10 days</h2>
<p>&nbsp;</p>
<h2>Sample: Create a task with a subject equal to the ID of the input entity</h2>
<p>&nbsp;</p>
<h2>Sample: Assign the lead to the user with the fewest lead records assigned</h2>
<p>&nbsp;</p>
<h2>Sample: Perform addition of two summands</h2>
