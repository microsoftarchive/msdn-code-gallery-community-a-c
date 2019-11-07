# Azure Active Directory: Graph API
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Microsoft Azure
- azure active directory
## Topics
- QuickStart
## Updated
- 05/09/2015
## Description

<h1>Azure Active Directory: Graph API</h1>
<div class="subhead">Microsoft Azure QuickStarts</div>
<p>This console application is a .NET sample, using the Graph API Client library (Version 2.0) - it demonstrates common Read calls to the Graph API including Getting Users, Groups, Group Membership, Roles, Tenant information, Service Principals, Applications.
 The second part of the sample app demonstrates common Write/Update/Delete options on Users, Groups, and shows how to execute User License Assignment, updating a User's thumbnailPhoto and links, etc. It also can read the contents from the signed-on user's mailbox.
</p>
<p>The sample incorporates using the Active Directory Authentication Library (ADAL) for authentication. The first part of the console app is Read-only, and uses OAuth Client Credentials to authenticate against the Demo Company. The second part of the app has
 update operations, and requires User credentials (using the OAuth Authorization Code flow). Update operations are not permitted using this shared Demo company - to try these, you will need to update the application configuration to be used with your own Azure
 AD tenant, and will need to configure applications accordingly. When configuring this application to be used with your own tenant, you will need to configure two applications in the Azure Management Portal: one using OAuth Client Credentials, and a second
 one using OAuth Authorization Code flow (each with separate ClientIds (AppIds)) - to execute update operations, you will need to logon with an account that has Administrative permissions. This app also demonstrates how to read the mailbox of the signed on
 user account using the Microsoft common consent framework - applications can be granted access to Azure Active directory, as well as Microsoft Office365 applications including Exchange and SharePoint Online.
</p>
<p>Note: The latest version of this sample is <a href="https://github.com/AzureADSamples/ConsoleApp-GraphAPI-DotNet">
available on GitHub</a> . </p>
<p>If you don't have a Microsoft Azure subscription you can get a FREE trial account
<a href="http://go.microsoft.com/fwlink/?LinkId=330212">here</a>. </p>
<h2>Running this sample</h2>
<p>Step 1: Run the sample in Visual Studio. </p>
<p>The sample app is preconfigured to read data from a Demonstration company (GraphDir1.onMicrosoft.com) in Azure AD. Run the sample application by selecting F5. The second part of the app will require Admin credentials, you can simulate authentication using
 this demo user account: userName = <a href="mailto:demoUser@graphDir1.onMicrosoft.com">
demoUser@graphDir1.onMicrosoft.com</a>, password = graphDem0 However, this is only a user account and does not have administrative permissions to execute updates - therefore, you will see &quot;..unauthorized..&quot; response errors when attempting any requests requiring
 admin permissions. To see how updates work, you will need to configure and use this sample with your own tenant - see the next step.
</p>
<p>Step 2: Running this application with your own Azure Active Directory tenant</p>
<p>Register the Sample app for your own tenant</p>
<ol class="task-list">
<li>
<p>Sign in to the Azure management portal.</p>
</li><li>
<p>Click on <strong>Active Directory</strong> in the left hand nav.</p>
</li><li>
<p>Click the <strong>directory tenant</strong> where you wish to register the sample application.</p>
</li><li>
<p>Click the <strong>Applications</strong> tab.</p>
</li><li>
<p>In the drawer, click <strong>Add</strong>.</p>
</li><li>
<p>Click <strong>&quot;Add an application my organization is developing&quot;</strong>.</p>
</li><li>
<p>Enter a friendly name for the application, for example <strong>&quot;Console App for Azure AD&quot;</strong>, select
<strong>&quot;Web Application and/or Web API&quot;</strong>, and click <strong>next</strong>.
</p>
</li><li>
<p>For the <strong>Sign-on URL</strong>, enter a value (NOTE: this is not used for the console app, so is only needed for this initial configuration): &quot;http://localhost&quot;</p>
</li><li>
<p>For the <strong>App ID URI</strong>, enter &quot;http://localhost&quot;. Click the checkmark to complete the initial configuration.</p>
</li><li>
<p>While still in the Azure portal, click the <strong>Configure</strong> tab of your application.</p>
</li><li>
<p>Find the <strong>Client ID</strong> value and copy it aside, you will need this later when configuring your application.</p>
</li><li>
<p>Under the Keys section, select either a 1-year or 2-year key - the <strong>keyValue</strong> will be displayed after you save the configuration at the end - it will be displayed, and you should save this to a secure location. NOTE: The key value is only
 displayed once, and you will not be able to retrieve it later.</p>
</li><li>
<p>Configure Permissions - under the <strong>&quot;Permissions to other applications&quot;</strong> section, you will configure permissions to access the Graph (Windows Azure Active Directory). For &quot;Windows Azure Active Directory&quot; under the first permission column (Application
 Permission:1&quot;), select &quot;Read directory data&quot;. Notes: this configures the App to use OAuth Client Credentials, and have Read access permissions for the application.
</p>
</li><li>
<p>Select the <strong>Save</strong> button at the bottom of the screen - upon successful configuration, your Key value should now be displayed - please copy and store this value in a secure location.</p>
</li><li>
<p>You will need to update the program.cs of this Application project with the updated values. From Visual Studio, open the project and program.cs file, find and update the string values of &quot;clientId&quot; and &quot;clientSecret&quot; with the Client ID and key values from
 Azure management portal. Update your tenant name for the authString value (e.g. contoso.onMicrosoft.com). Update the tenantId value for the string tenantId, with your tenantId. Note: your tenantId can be discovered by opening the following metadata.xml document:
<a href="https://login.windows.net/GraphDir1.onmicrosoft.com/FederationMetadata/2007-06/FederationMetadata.xml">
https://login.windows.net/GraphDir1.onmicrosoft.com/FederationMetadata/2007-06/FederationMetadata.xml</a> - replace &quot;graphDir1.onMicrosoft.com&quot;, with your tenant's domain value (any domain that is owned by the tenant will work). The tenantId is a guid, that
 is part of the sts URL, returned in the first xml node's sts url (&quot;EntityDescriptor&quot;): e.g. &quot;<a href="https://sts.windows.net/">https://sts.windows.net/</a>&quot;</p>
</li><li>
<p>Now Configure a 2nd application object to run the update portion of this app: return to the Azure Management Portal's Application Page, select &quot;Add&quot; from the bottom, seelect &quot;Add an Application my Organization is Developing&quot;, Supply an Application name,
 and make sure to select &quot;Native Client Application&quot;, supply a redirect Uri (e.g. &quot;https://localhost&quot;). Select &quot;configure&quot; from the top tab - under &quot;permissions to other applications&quot; select the DelegatedPermissions:1 drop down menu for the Graph (Windows Azure
 Active Directory), and select &quot;Access Your organization's directory&quot;. This application will also attempt to read the signed-on user's Mailbox contents from Exchange Online - to enable this, add an additional permission: select &quot;Office365 Exchange Online&quot; and
 from the DeletagePermissions:1 drop down, select &quot;Read users mail (preview)&quot;. Copy the Client ID value - this will be used to configure program.cs next - save the Application configuration.<br>
Select SAVE on the bottom of the screen. </p>
</li><li>
<p>Open the program.cs file, and find the &quot;redirectUri&quot; string value, and replace it with &quot;https://localhost&quot; (or the value your configured for the ReplyURL). Also replace the &quot;clientIdForUserAuthn&quot; with the client ID value from the previous step.</p>
</li><li>
<p>Build and run your application - you will need to authenticate with valid tenant administrator credentials for your company when you run the application (required for the Create/Update/delete operations).</p>
</li></ol>
<h2>More information</h2>
<ul>
<li><a href="http://azure.microsoft.com/en-us/documentation/services/active-directory/">Azure Active Directory documentation</a>
</li><li><a href="https://github.com/AzureADSamples">Microsoft Azure Active Directory Samples and Documentation</a>
</li></ul>
