# Connecting to Remote system programatically
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- WPF
## Topics
- Windows Forms
- Windows
- Generic C# resuable code
## Updated
- 07/26/2011
## Description

<h1>Introduction</h1>
<p><em>Somebody might facing the issues like connecting to remote systems programatically using C#.Here is the solution to get rid of those kind of problems.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Unzip the attached code, build and run&nbsp;in VS2010.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>&nbsp;&nbsp;</em><em>Somebody might facing the issues like connecting to remote systems programatically using C#.Here is the solution to get rid of those kind of problems.</em></p>
<p><em>NetworkConnection class which uses 'WNetAddconnection' to connect to remote system by passing domain name,password and username.
</em></p>
<p><em>Before running the application, make sure to pass all the mandatory values</em></p>
<p><em>1. domain name </em></p>
<p><em>2. username</em></p>
<p><em>3.password </em></p>
<p><em>in the 'Getnetworkcredential' method. </em></p>
<p><em>and pass the localname and remotename in the button_click.</em></p>
<p>Technology : C#, .net 3.5</p>
<p>Namespace: <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.NET.aspx" target="_blank" title="Auto generated link to System.NET">System.NET</a></p>
<p>localname can be empty. this same code can be useful for mapping drive also.&nbsp; if we pass localname as some drive (say Z:), it will create a 'Z:' drive of remote system path by using network credentials.</p>
<p>remote name can be in the following forms,</p>
<p>1. '\\IPAddress\drivename$\Foldername'</p>
<p>2. 'http://localhost/foldername/'</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NetworkCredential&nbsp;objnetCred&nbsp;=&nbsp;GetNetorkCredential();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;localName=<span class="cs__keyword">string</span>.Empty;&nbsp;<span class="cs__com">//specify&nbsp;local&nbsp;name&nbsp;of&nbsp;the&nbsp;drive</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;networkName=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;<span class="cs__com">//Specify&nbsp;remote&nbsp;network&nbsp;name,&nbsp;eg:\\190.x.x.x\Test</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(NetworkConnection&nbsp;nc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NetworkConnection(localName,&nbsp;networkName,&nbsp;objnetCred))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exMsg)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(exMsg.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;NetworkCredential&nbsp;GetNetorkCredential()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
<span class="cs__com">//Pass&nbsp;the&nbsp;domain&nbsp;name,username&nbsp;and&nbsp;password&nbsp;in&nbsp;below&nbsp;lines</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NetworkCredential&nbsp;objNetworkCred&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NetworkCredential(@<span class="cs__string">&quot;domainname\username&quot;</span>,&nbsp;<span class="cs__string">&quot;password&quot;</span>,&nbsp;<span class="cs__string">&quot;domainname&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;objNetworkCred;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
