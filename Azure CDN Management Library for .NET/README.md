# Azure CDN Management Library for .NET
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Microsoft Azure
## Topics
- Azure CDN
## Updated
- 06/22/2016
## Description

<h1>Introduction</h1>
<p><em>The Azure CDN Management Library for .NET enables programmatic management of all CDN functionality exposed through the Azure Portal. &nbsp;This is the sample project to accompany the
<a href="https://azure.microsoft.com/documentation/articles/cdn-app-dev-net">Azure CDN documentation</a>.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Open the solution in Visual Studio 2015. &nbsp;Update the constants at the top of
<strong>Program.cs</strong>&nbsp;to reflect your Azure Active Directory tenant. &nbsp;You should then be able to build and run the solution. &nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample demonstrates authentication, listing CDN profiles and endpoints, creating a CDN profile, creating a CDN endpoint, purging a CDN endpoint, deleting a CDN endpoint, and deleting a CDN profile.</em></p>
<p><strong>Creating a CDN Profile</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Creates&nbsp;a&nbsp;CDN&nbsp;profile.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;cdn&quot;&gt;An&nbsp;authenticated&nbsp;CdnManagementClient&lt;/param&gt;</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateCdnProfile(CdnManagementClient&nbsp;cdn)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(profileAlreadyExists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Profile&nbsp;{0}&nbsp;already&nbsp;exists.&quot;</span>,&nbsp;profileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Creating&nbsp;profile&nbsp;{0}.&quot;</span>,&nbsp;profileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProfileCreateParameters&nbsp;profileParms&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ProfileCreateParameters()&nbsp;{&nbsp;Location&nbsp;=&nbsp;resourceLocation,&nbsp;Sku&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Sku(SkuName.StandardVerizon)&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cdn.Profiles.Create(profileName,&nbsp;profileParms,&nbsp;resourceGroupName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Creating a CDN Endpoint</strong></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Creates&nbsp;the&nbsp;CDN&nbsp;endpoint.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;cdn&quot;&gt;An&nbsp;authenticated&nbsp;CdnManagementClient&lt;/param&gt;</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateCdnEndpoint(CdnManagementClient&nbsp;cdn)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(endpointAlreadyExists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Profile&nbsp;{0}&nbsp;already&nbsp;exists.&quot;</span>,&nbsp;profileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Creating&nbsp;endpoint&nbsp;{0}&nbsp;on&nbsp;profile&nbsp;{1}.&quot;</span>,&nbsp;endpointName,&nbsp;profileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndpointCreateParameters&nbsp;endpointParms&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;EndpointCreateParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Origins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;DeepCreatedOrigin&gt;()&nbsp;{&nbsp;<span class="cs__keyword">new</span>&nbsp;DeepCreatedOrigin(<span class="cs__string">&quot;Contoso&quot;</span>,&nbsp;<span class="cs__string">&quot;www.contoso.com&quot;</span>)&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsHttpAllowed&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsHttpsAllowed&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location&nbsp;=&nbsp;resourceLocation&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cdn.Endpoints.Create(endpointName,&nbsp;endpointParms,&nbsp;profileName,&nbsp;resourceGroupName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><strong>Purging a CDN Endpoint</strong><strong>&nbsp;</strong><strong> </strong>
</p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Purges&nbsp;the&nbsp;CDN&nbsp;endpoint.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;cdn&quot;&gt;An&nbsp;authenticated&nbsp;CdnManagementClient&lt;/param&gt;</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PromptPurgeCdnEndpoint(CdnManagementClient&nbsp;cdn)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(PromptUser(String.Format(<span class="cs__string">&quot;Purge&nbsp;CDN&nbsp;endpoint&nbsp;{0}?&quot;</span>,&nbsp;endpointName)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Purging&nbsp;endpoint.&nbsp;Please&nbsp;wait...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cdn.Endpoints.PurgeContent(endpointName,&nbsp;profileName,&nbsp;resourceGroupName,&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;()&nbsp;{&nbsp;<span class="cs__string">&quot;/*&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Done.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</strong>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Program.cs - Console application</em> </li></ul>
<h1>More Information</h1>
<p><em>Be sure to visit the <em><a href="https://azure.microsoft.com/documentation/articles/cdn-app-dev-net">Azure CDN documentation</a>&nbsp;for the complete walkthrough of this sample. &nbsp;</em>For more information, see the
<a href="https://msdn.microsoft.com/library/mt657769.aspx">Azure CDN Library for .NET reference</a>&nbsp;on MSDN.</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:54px; width:1px; height:1px; overflow:hidden">
<h1>Introduction</h1>
<p><em>The Azure CDN Management Library for .NET enables programmatic management of all CDN functionality exposed through the Azure Portal. &nbsp;This is the sample project to accompany the&nbsp;<a href="https://azure.microsoft.com/documentation/articles/cdn-app-dev-net">Azure
 CDN documentation</a>.</em></p>
<h1>Building the Sample</h1>
<p><em>Open the solution in Visual Studio 2015. &nbsp;Update the constants at the top of&nbsp;<strong>Program.cs</strong>&nbsp;to reflect your Azure Active Directory tenant. &nbsp;You should then be able to build and run the solution. &nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample demostrates authentication, listing CDN profiles and endpoints, creating a CDN profile, creating a CDN endpoint, purging a CDN endpoint, deleting a CDN endpoint, and deleting a CDN profile.</em></p>
<p>&nbsp;</p>
<div class="scriptcode" style="line-height:15px">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder" style="margin-left:299.5px"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Creates&nbsp;the&nbsp;CDN&nbsp;endpoint.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;cdn&quot;&gt;An&nbsp;authenticated&nbsp;CdnManagementClient&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateCdnEndpoint(CdnManagementClient&nbsp;cdn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(endpointAlreadyExists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Profile&nbsp;{0}&nbsp;already&nbsp;exists.&quot;</span>,&nbsp;profileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Creating&nbsp;endpoint&nbsp;{0}&nbsp;on&nbsp;profile&nbsp;{1}.&quot;</span>,&nbsp;endpointName,&nbsp;profileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndpointCreateParameters&nbsp;endpointParms&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;EndpointCreateParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Origins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;DeepCreatedOrigin&gt;()&nbsp;{&nbsp;<span class="cs__keyword">new</span>&nbsp;DeepCreatedOrigin(<span class="cs__string">&quot;Contoso&quot;</span>,&nbsp;<span class="cs__string">&quot;www.contoso.com&quot;</span>)&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsHttpAllowed&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsHttpsAllowed&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location&nbsp;=&nbsp;resourceLocation&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cdn.Endpoints.Create(endpointName,&nbsp;endpointParms,&nbsp;profileName,&nbsp;resourceGroupName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>Source Code Files</h1>
<ul>
<li><em>Program.cs - Console application</em> </li></ul>
<h1>More Information</h1>
<p><em>Be sure to visit the&nbsp;<em><a href="https://azure.microsoft.com/documentation/articles/cdn-app-dev-net">Azure CDN documentation</a>&nbsp;for the complete walkthrough of this sample. &nbsp;</em>For more information, see the&nbsp;<a href="https://msdn.microsoft.com/library/mt657769.aspx">Azure
 CDN Library for .NET reference</a>&nbsp;on MSDN.</em></p>
</div>
