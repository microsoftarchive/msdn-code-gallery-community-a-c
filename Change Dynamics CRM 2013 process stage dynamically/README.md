# Change Dynamics CRM 2013 process stage dynamically
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Dynamics CRM 2013
## Topics
- Business Process Flows
## Updated
- 05/01/2015
## Description

<h1>Introduction</h1>
<p><strong>UPDATE</strong>: With CRM2015 - the new client side process API should be used to set the current step. The following approach should be only used for setting the process to the first step.</p>
<p>If you have more than one Dynamics CRM 2013 Business Process Flow for a given entity, users can easily change the current process by using the &lsquo;Switch Process&rsquo; Command Bar button. Once changed, you can identify which process is running by hovering
 over the &lsquo;I&rsquo; on the bottom right of the process flow:</p>
<p>If your users would like to change the Business Process Flow stage dynamically based on a given set of attribute values then it is not immediately obvious how this can be achieved. This post provides one solution using a custom workflow activity in combination
 with the new Synchronous Workflow feature of Dynamics CRM 2013. &nbsp;</p>
<h2>Solution</h2>
<p>The currently selected process and stage are stored in CRM using the following attributes:</p>
<ul>
<li>processid &ndash; GUID of the selected Business Process (workflow) </li><li>stageid &ndash; GUID of the selected Process Stage (processstage) </li></ul>
<p>Initially I thought that these attributes might be able to be updated using a workflow directly, but it turns out you can only update them via code. This sample provides two workflow activities:</p>
<p>Query Process Stage - gets the current stage and process name so that you can make a decision if needs to change</p>
<p>Change Process Stage - changes the stage based on the name provided.</p>
<p>You will need to also refresh the form to get the new proces stage to be rendered when the dependant attribtues are changed on the form using:</p>
<p>Xrm.Page.data.entity.save()</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><em>To build the solution you will need the Developer Tookit for VS2012 found in the SDK/Tools folder.</em></p>
