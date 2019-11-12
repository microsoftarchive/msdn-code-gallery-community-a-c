# A very simple example to access the Global Address List using Directory services
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- Active Directory
- .NET Framework 4.0
## Topics
- Active Directory
## Updated
- 04/02/2012
## Description

<h1>Introduction</h1>
<p>Access the Global Address List of a Microsoft Exchange Server&nbsp;using Directory services.</p>
<h1><span>Building the Sample</span></h1>
<p>There are not&nbsp;special requirements or instructions for building the sample.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample application (WPF &amp; .NET Framework 4.0) uses the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.DirectoryServices.aspx" target="_blank" title="Auto generated link to System.DirectoryServices">System.DirectoryServices</a> API to query the Global Address List of a Microsoft Exchange Server. Every Exchange server stores this address list in the Active Directory Server of your infrastructure.
 Taking advantage of this, you can easily query the Active Directory to retrieve this address list with a lot of properties about every entry.</p>
<p><br>
The class Address is a wrapper class for each search result of the LDAP query. You can add more properties to show in the grid of the main window modifying this class. In the constructor of the class there is a list with the more common properties that Active
 Directory has about each directory entry.</p>
<p>Obviously, you need to have the requested permissions to query the Active Directory to make the sample work. I choose WPF because the simplicity of the DataGrid control, but you can easily change the user interface, for example to Windows Forms, if you need
 because there are not any strong dependencies between the logic of the sample and the user interface.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Address[]&nbsp;GetGlobalAddressList()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;searcher&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectorySearcher())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;entry&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryEntry(searcher.SearchRoot.Path))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searcher.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;(&amp;(mailnickname=*)(objectClass=user))&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searcher.PropertiesToLoad.Add(<span class="cs__string">&quot;cn&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searcher.PropertyNamesOnly&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searcher.SearchScope&nbsp;=&nbsp;SearchScope.Subtree;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searcher.Sort.Direction&nbsp;=&nbsp;SortDirection.Ascending;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searcher.Sort.PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;cn&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;searcher.FindAll().Cast&lt;SearchResult&gt;().Select(result&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;Address(result.GetDirectoryEntry())).ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
