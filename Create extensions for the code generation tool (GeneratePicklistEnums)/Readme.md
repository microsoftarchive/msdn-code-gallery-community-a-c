# Create extensions for the code generation tool (GeneratePicklistEnums)
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- Microsoft Dynamics CRM SDK
## Updated
- 12/01/2017
## Description

<h1>Create extensions for the code generation tool&nbsp;(GeneratePicklistEnums)</h1>
<p>You can extend the functionality of the code generation tool by specifying additional command-line parameters and parameter values. To specify a parameter, add the following to the command line: /<em>parametername</em><em>class name</em><em>assembly name</em>.
 Note that assembly name does not include the .dll extension. As an alternative, you can add the equivalent value to the config file in the format add key=<em>parametername</em> value=<em>class name</em><em>assembly name</em>/.</p>
<table border="1">
<tbody>
<tr>
<th scope="col">
<p>Parameter name</p>
</th>
<th scope="col">
<p>Interface Name</p>
</th>
<th scope="col">
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p>/codecustomization</p>
</td>
<td>
<p>ICustomizeCodeDomService</p>
</td>
<td>
<p>Called after the CodeDOM generation has been completed, assuming the default instance of
<strong>ICodeGenerationService</strong>. It is useful for generating additional classes, such as the constants in picklists.</p>
</td>
</tr>
<tr>
<td>
<p>/codewriterfilter</p>
</td>
<td>
<p>ICodeWriterFilterService</p>
</td>
<td>
<p>Called during the process of CodeDOM generation, assuming the default instance of
<strong>ICodeGenerationService</strong>, to determine whether a specific object or property should be generated.</p>
</td>
</tr>
<tr>
<td>
<p>/codewritermessagefilter</p>
</td>
<td>
<p>ICodeWriterMessageFilterService</p>
</td>
<td>
<p>Called during the process of CodeDOM generation, assuming the default instance of
<strong>ICodeGenerationService</strong>, to determine whether a specific message should be generated. This should not be used for requests/responses as these are already generated in Microsoft.Crm.Sdk.Proxy.dll and Microsoft.Xrm.Sdk.dll.</p>
</td>
</tr>
<tr>
<td>
<p>/metadataproviderservice</p>
</td>
<td>
<p>IMetadataProviderService</p>
</td>
<td>
<p>Called to retrieve the metadata from the server. This may be called multiple times during the generation process, so the data should be cached.</p>
</td>
</tr>
<tr>
<td>
<p>/codegenerationservice</p>
</td>
<td>
<p>ICodeGenerationService</p>
</td>
<td>
<p>Core implementation of the CodeDOM generation. If this is changed, the other extensions may not behave in the manner described.</p>
</td>
</tr>
<tr>
<td>
<p>/namingservice</p>
</td>
<td>
<p>INamingService</p>
</td>
<td>
<p>Called during the CodeDOM generation to determine the name for objects, assuming the default implementation.</p>
</td>
</tr>
</tbody>
</table>
<p>The implementation of these interfaces must have one of the following constructors:</p>
<p><strong>MyNamingService</strong>()<br>
<strong>MyNamingService</strong>(<strong>INamingService</strong>&nbsp;<em>defaultService</em>)
<br>
<strong>MyNamingService</strong>(<strong>IDictionary</strong>&lt;<strong>string</strong>,
<strong>string</strong>&gt; <em>parameters</em>) <br>
<strong>MyNamingService</strong>(<strong>INamingService</strong>&nbsp;<em>defaultService</em>,
<strong>IDictionary</strong>&lt;<strong>string</strong>, <strong>string</strong>&gt;<em>parameters</em>)</p>
<p>The <strong>Microsoft.Crm.Services.Utility</strong> namespace is defined in CrmSvcUtil.exe. Add a reference to CrmSvcUtil.exe in your Microsoft Visual Studio code generation tool extension projects.</p>
<p>Click too see&nbsp;<a href="https://code.msdn.microsoft.com/Create-extensions-for-the-3dd56a27/sourcecode?fileId=182954&pathId=390602080">CodeCustomizationService.cs</a><strong></strong><em></em>,
<a href="https://code.msdn.microsoft.com/Create-extensions-for-the-3dd56a27/sourcecode?fileId=182954&pathId=503546707">
NamingService.cs</a>, and <a href="https://code.msdn.microsoft.com/Create-extensions-for-the-3dd56a27/sourcecode?fileId=182954&pathId=2125504668">
FilteringService.cs</a> sample files.</p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/extend-code-generation-tool">
Create extensions for the code generation tool</a>.<strong></strong><em></em></p>
<p>The following sample code demonstrates how to write an extension.<strong></strong><em></em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;

using Microsoft.Xrm.Sdk.Metadata;
public interface ICodeWriterFilterService
{
    bool GenerateAttribute(AttributeMetadata attributeMetadata, IServiceProvider services);
    bool GenerateEntity(EntityMetadata entityMetadata, IServiceProvider services);
    bool GenerateOption(OptionMetadata optionMetadata, IServiceProvider services);
    bool GenerateOptionSet(OptionSetMetadataBase optionSetMetadata, IServiceProvider services);
    bool GenerateRelationship(RelationshipMetadataBase relationshipMetadata, EntityMetadata otherEntityMetadata,
    IServiceProvider services);
    bool GenerateServiceContext(IServiceProvider services);

}
/// &lt;summary&gt;
/// Sample extension for the CrmSvcUtil.exe tool that generates early-bound
/// classes for custom entities.
/// &lt;/summary&gt;
public sealed class BasicFilteringService : ICodeWriterFilterService
{
    public BasicFilteringService(ICodeWriterFilterService defaultService)
    {
        this.DefaultService = defaultService;
    }

    private ICodeWriterFilterService DefaultService { get; set; }

    bool ICodeWriterFilterService.GenerateAttribute(AttributeMetadata attributeMetadata, IServiceProvider services)
    {
        return this.DefaultService.GenerateAttribute(attributeMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateEntity(EntityMetadata entityMetadata, IServiceProvider services)
    {
        if (!entityMetadata.IsCustomEntity.GetValueOrDefault()) { return false; }
        return this.DefaultService.GenerateEntity(entityMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateOption(OptionMetadata optionMetadata, IServiceProvider services)
    {
        return this.DefaultService.GenerateOption(optionMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateOptionSet(OptionSetMetadataBase optionSetMetadata, IServiceProvider services)
    {
        return this.DefaultService.GenerateOptionSet(optionSetMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateRelationship(RelationshipMetadataBase relationshipMetadata, EntityMetadata otherEntityMetadata,
    IServiceProvider services)
    {
        return this.DefaultService.GenerateRelationship(relationshipMetadata, otherEntityMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateServiceContext(IServiceProvider services)
    {
        return this.DefaultService.GenerateServiceContext(services);
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Xrm.Sdk.Metadata;&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;ICodeWriterFilterService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;GenerateAttribute(AttributeMetadata&nbsp;attributeMetadata,&nbsp;IServiceProvider&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;GenerateEntity(EntityMetadata&nbsp;entityMetadata,&nbsp;IServiceProvider&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;GenerateOption(OptionMetadata&nbsp;optionMetadata,&nbsp;IServiceProvider&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;GenerateOptionSet(OptionSetMetadataBase&nbsp;optionSetMetadata,&nbsp;IServiceProvider&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;GenerateRelationship(RelationshipMetadataBase&nbsp;relationshipMetadata,&nbsp;EntityMetadata&nbsp;otherEntityMetadata,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IServiceProvider&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;GenerateServiceContext(IServiceProvider&nbsp;services);&nbsp;
&nbsp;
}&nbsp;
<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Sample&nbsp;extension&nbsp;for&nbsp;the&nbsp;CrmSvcUtil.exe&nbsp;tool&nbsp;that&nbsp;generates&nbsp;early-bound</span>&nbsp;
<span class="cs__com">///&nbsp;classes&nbsp;for&nbsp;custom&nbsp;entities.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BasicFilteringService&nbsp;:&nbsp;ICodeWriterFilterService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;BasicFilteringService(ICodeWriterFilterService&nbsp;defaultService)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.DefaultService&nbsp;=&nbsp;defaultService;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ICodeWriterFilterService&nbsp;DefaultService&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ICodeWriterFilterService.GenerateAttribute(AttributeMetadata&nbsp;attributeMetadata,&nbsp;IServiceProvider&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.DefaultService.GenerateAttribute(attributeMetadata,&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ICodeWriterFilterService.GenerateEntity(EntityMetadata&nbsp;entityMetadata,&nbsp;IServiceProvider&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!entityMetadata.IsCustomEntity.GetValueOrDefault())&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.DefaultService.GenerateEntity(entityMetadata,&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ICodeWriterFilterService.GenerateOption(OptionMetadata&nbsp;optionMetadata,&nbsp;IServiceProvider&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.DefaultService.GenerateOption(optionMetadata,&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ICodeWriterFilterService.GenerateOptionSet(OptionSetMetadataBase&nbsp;optionSetMetadata,&nbsp;IServiceProvider&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.DefaultService.GenerateOptionSet(optionSetMetadata,&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ICodeWriterFilterService.GenerateRelationship(RelationshipMetadataBase&nbsp;relationshipMetadata,&nbsp;EntityMetadata&nbsp;otherEntityMetadata,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IServiceProvider&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.DefaultService.GenerateRelationship(relationshipMetadata,&nbsp;otherEntityMetadata,&nbsp;services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ICodeWriterFilterService.GenerateServiceContext(IServiceProvider&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.DefaultService.GenerateServiceContext(services);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
<strong></strong><em></em></pre>
</div>
</div>
</div>
