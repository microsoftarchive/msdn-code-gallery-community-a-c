# Automated Office365 Licensing
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Powershell
- Graph API
## Topics
- Licensing
- Graph API
## Updated
- 09/25/2015
## Description

<h1>Introduction</h1>
<p>Licensing for enterprises and large companies that have enabled Office365 workloads is needed to be handled as a service rather than a user by user task. New users are added to their directories daily and roles change just as often, so the need for licenses
 to be added for these users needs to happen just as often to enable their productivity. With this solution we have attempted to come up with a design that allows ITPros to license new/unlicensed (never had any licenses) users or users based on their role.
 For the role based licensing we will license these users based upon their presence within an Azure Active Directory (AAD) security group.</p>
<p><span style="color:#57a64a; font-family:Consolas; font-size:x-small"><span style="color:#57a64a; font-family:Consolas; font-size:x-small"><span style="color:#57a64a; font-family:Consolas; font-size:x-small">&nbsp;</span></span></span></p>
<h1><span>Building the Sample</span></h1>
<p><em>No special requirements for building the sample.</em></p>
<h1>Prerequisites</h1>
<p><strong>Permissions:</strong></p>
<p>An account that has User Account Administrator permissions in Azure Active Directory (<a href="https://support.office.com/en-us/article/Assigning-admin-roles-in-Office-365-EAC4D046-1AFD-4F1A-85FC-8219C79E1504" target="_blank">https://support.office.com/en-us/article/Assigning-admin-roles-in-Office-365-EAC4D046-1AFD-4F1A-85FC-8219C79E1504</a>).</p>
<p>An application object in Azure Active Directory that has read / write permissions to the directory (<a href="https://azure.microsoft.com/en-us/documentation/articles/active-directory-integrating-applications/" target="_blank">https://azure.microsoft.com/en-us/documentation/articles/active-directory-integrating-applications/</a>).</p>
<p><strong>Machine Needs:</strong></p>
<p>A machine that is running on x64 bit architecture.</p>
<p>Microsoft Online Services SignIn Assistant - <a href="http://go.microsoft.com/fwlink/?LinkID=286152" target="_blank">
http://go.microsoft.com/fwlink/?LinkID=286152</a></p>
<p>Azure Active Directory Module for Windows Powershell - <a href="http://go.microsoft.com/fwlink/p/?linkid=236297" target="_blank">
http://go.microsoft.com/fwlink/p/?linkid=236297</a></p>
<p><strong>Knowledge:</strong></p>
<p>Need to be aware of how to retrieve SKU ID information and Service Plan ID information from Azure Active Directory for your Office365 Tenant.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To license users in an automated fashion we take a dual approach to locating users.&nbsp;</p>
<ol>
<li>Users that are brand new to the company and have been newly created in Azure Active Directory (AAD).&nbsp; These users will have the isLicensed flag on their account set to FALSE.&nbsp;
</li><li>Users will be provided to us in an AAD security group.&nbsp; Since security group management is a basic tool for all enterprises we can make the assumption that&nbsp;assigning licenses via SG is an accepted approach.
</li></ol>
<div>First of all we need to build our config.xml file with the information that will run in our script.&nbsp; The config.xml file contains the company information that will be unique to your&nbsp;Office365 tenant.&nbsp; Below is a list of the attributes that
 need entries in the config xml file:</div>
<div></div>
<div><strong>tenantname [single value]:</strong> Name of your Office365 Tenant (NAME.onmicrosoft.com).</div>
<div><strong>tenantid [single value]<em>&nbsp;</em>: </strong>Name or GUID representation of your tenant (NAME.onmicrosoft.com or tenant GUID).</div>
<div><strong>clientid [single value]<em>&nbsp;</em>: </strong>This is the AppPrincipalID of the applicaiton in AAD that has read / write permissions to your directory.</div>
<div><strong>clientsecret [single value]<em>&nbsp;</em>: </strong>This is the client secret passcode that AAD produces for you when you create your application in AAD.</div>
<div><strong>adminupn [single value]<em>&nbsp;</em>: </strong>This is the UserPrincipalName of the account that has admin permissions to your AAD.</div>
<div><strong>adminpassword [single value]<em>&nbsp;</em>:&nbsp; </strong>This is the password for the above admin account.</div>
<div><strong>groupbased [single value]<em>&nbsp;</em>: </strong>This determines whether or not to license all unlicensed users or users in a specific group (False = All unlicensed users, True = Security Group based).</div>
<div><strong>aadgroupobjectid [single value]<em>&nbsp;</em>: </strong>The security group object ID from AAD for the group of user you want to license.&nbsp; Only used if groupbased is set to true.</div>
<div><strong>skuid [single value]<em>&nbsp;</em>: </strong>The SKU ID for the license you want to apply to the selected users.</div>
<div><strong>enabledplanid [multi value]<em>&nbsp;</em>: </strong>This is the service plan id (GUID) for the service plan you want to be sure is enabled for the selected users.&nbsp; You are able to denote multiple plans with this attribute.</div>
<div><strong>removeskuid [multi value]<em>&nbsp;</em>: </strong>This is the SkuId for any Licenses that you want to ensure are removed from these users when the new Skus are enalbed.&nbsp; This is used when moving users from one Sku to another and those skus
 have conflicting plans.</div>
<p><em>To get any of the SkuIds or plan Ids you can retrieve them from powershell using the Azure Active Directory module for Powershell.
</em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="powershell">Connect<span class="powerShell__operator">-</span>MsolService;&nbsp;
(Get<span class="powerShell__operator">-</span>MsolAccountSku&nbsp;<span class="powerShell__operator">|</span>&nbsp;?&nbsp;{<span class="powerShell__variable">$_</span>.accountskuid&nbsp;<span class="powerShell__operator">-</span>eq&nbsp;<span class="powerShell__string">&quot;LICENSENAME&quot;</span>}).skuid;</pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode"><em>&nbsp;To get Service Plan information.</em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode"><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="powershell">(Get<span class="powerShell__operator">-</span>MsolAccountSku&nbsp;<span class="powerShell__operator">|</span>&nbsp;?&nbsp;{<span class="powerShell__variable">$_</span>.accountskuid&nbsp;<span class="powerShell__operator">-</span>eq&nbsp;<span class="powerShell__string">&quot;LicenseName&quot;</span>}).servicestatus.serviceplan&nbsp;<span class="powerShell__operator">|</span>&nbsp;<span class="powerShell__alias">select</span>&nbsp;servicename,&nbsp;serviceplanid</pre>
</div>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em></p>
<div class="endscriptcode"></div>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>To get the objectID for an AAD group:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">(Get-MsolGroup&nbsp;-SearchString&nbsp;<span class="js__string">&quot;GroupName&quot;</span>).ObjectID</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Using this information the application will load the data from the XML file and make a connection via an Active Directory Client to AAD via the Graph API.&nbsp; Using the connected Active Directory Client we will get the tenant information for the tenant
 provided.&nbsp; The usage location provided in the tenant details call is used to ensure that all the objects we're going to license is in the right usage location.&nbsp; If it is not then the call to license users will fail.&nbsp; We then get the users that
 we're going to license based on the &lt;groupbased&gt; value in the XML file.&nbsp;</p>
<p>Users returned are then searched for in the Graph API and we check to see if the license and plans they currently have assigned match the license and plans that you want to ensure are assigned.&nbsp; If the license / plan combinations match then we dont
 make another call to license the user.&nbsp; If the license sku and plans dont match then we license the user.&nbsp; We take the plans that are to be enabled and check them against all the plans available in that sku and find which plans are to be disabled.&nbsp;
 When licensing you have to provide the plans that are to be disabled so we have to determine those since we provide the plans that are to be enabled in the XML file.</p>
<p>When the disabled plans are determined we ensure the user is licensed and if they have any skus to be removed they are removed.&nbsp; The user is then licensed and we&nbsp;move on to the next user.</p>
<div class="endscriptcode"></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>AuthenticationHelper.cs: This helper class designed by the <a href="https://github.com/Azure-Samples/active-directory-dotnet-graphapi-console" target="_blank">
Azure team</a>&nbsp;to help with the authentication to AAD.</em> </li><li><em><em>Constants.cs: Class to hold constants for the Graph API and other static resources.</em></em>
</li><li>Config.xml: XML file that holds the tenant and configuration information that controls how the application runs and licenses users.
</li></ul>
<h1>More Information</h1>
<p><em>Tons of thanks to the <a href="https://github.com/Azure-Samples/active-directory-dotnet-graphapi-console" target="_blank">
Azure team </a>for their samples and assistance with authentication and authorization to AAD.</em></p>
