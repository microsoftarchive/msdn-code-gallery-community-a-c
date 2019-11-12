# Add Window Authentication Functionality to a C# Desktop Application
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
## Topics
- Window Authentication in Desktop Application
## Updated
- 01/30/2013
## Description

<p>This application is sample to implement <strong>Window Authentication Functionality to a C# Desktop Application.</strong></p>
<p>To achieve this there are two steps accomplish with below steps.<strong><br>
</strong></p>
<p><strong>Step 1:</strong></p>
<p>1)&nbsp; Get currently logged in user details:</p>
<p>This is pretty straight forward. we can achieve this by using the WindowsIdentity class of <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Security.Principal.aspx" target="_blank" title="Auto generated link to System.Security.Principal">System.Security.Principal</a> namespace. This class provides a static method, getCurrent(), which return a object of WindowsIdentity.<br>
Bellow is the code you can use to get the current logged in user details</p>
<p><strong>Step 2:</strong></p>
<p>2) Validate windows credentials provided by user:</p>
<p>Need to ask domain name, user name, password from user to pass these values to interop service.</p>
<p>This is little complex compared to above as we need to call a windows API using IntropServices. To accomplish this we need to add a extern function declaration, and then call the function. Following code will help you to understand this better.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">bool</span>&nbsp;issuccess&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;username&nbsp;=&nbsp;GetloggedinUserName();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(username.ToLowerInvariant().Contains(txtUserName.Text.Trim().ToLowerInvariant())&nbsp;&amp;&amp;&nbsp;username.ToLowerInvariant().Contains(txtDomain.Text.Trim().ToLowerInvariant()))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;issuccess&nbsp;=&nbsp;IsValidateCredentials(txtUserName.Text.Trim(),&nbsp;txtPwd.Text.Trim(),&nbsp;txtDomain.Text.Trim());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(issuccess)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Successfuly&nbsp;Login&nbsp;!!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;User&nbsp;Name&nbsp;/&nbsp;Password&nbsp;/&nbsp;Domain&nbsp;is&nbsp;invalid&nbsp;!!!&quot;</span>);</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>You can find more information on MSDN website regrading </em><span style="color:#2b91af; font-size:10pt">WindowsIdentity
</span><span style="font-size:9pt">class of&nbsp;</span><span style="font-size:10pt"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Security.Principal.aspx" target="_blank" title="Auto generated link to System.Security.Principal">System.Security.Principal</a> namespace.</span></p>
<p><span style="font-size:10pt">And also about </span><span style="font-size:9pt">extern function declaration</span></p>
