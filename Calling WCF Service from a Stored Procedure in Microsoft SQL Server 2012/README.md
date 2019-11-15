# Calling WCF Service from a Stored Procedure in Microsoft SQL Server 2012
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- SQL Server 2012
## Topics
- WCF
- Stored Procedures
## Updated
- 05/19/2014
## Description

<div align="justify">One my friends wanted to call a WCF Service from a Stored Procedure in Microsoft SQL Server 2012. So this is how you can do it.</div>
<div></div>
<div align="justify">Before starting off with coding, there are some things that we all need to know and understand well.</div>
<div></div>
<div align="justify">When wring functionalities such as Stored Procedures, Triggers etc. for a database which sits inside Microsoft SQL Server, there are two things we can use.</div>
<ul>
<li>T-SQL </li><li>SQL CLR (SQL Common Language Runtime) </li></ul>
<div align="justify">You can either write your operation using T-SQL or you can use SQL CLR. Since you all are familiar with T-SQL, let&rsquo;s see what SQL CLR is.</div>
<div align="justify"><br>
<strong>SQL CLR is use of the Microsoft .NET Common Language Runtime within SQL Server. SQL CLR is very useful when you want to accomplish a task which is not possible with T-SQL.</strong> The best example for such task would be the task that I am going to
 do right now.</div>
<div align="justify"><br>
You can&rsquo;t use only T-SQL to consume a WCF Service. But SQL CLR gives the ability to call and consume a WCF Service. So what we can do is write a Stored Procedure with the use of SQL CLR which will call and consume from the WCF Service. Then we can write
 a T-SQL Stored Procedure to call the SQL CLR Stored Procedure.</div>
<div align="justify"><br>
Different SQL Server versions uses different CLR versions. SQL Server 2012 uses version 4.0 of the CLR although previous versions of SQL Server (from SQL Server 2005) uses version 2.0 of the CLR.</div>
<div align="justify"><br>
Keeping that in mind let&rsquo;s jump into the action.</div>
<div></div>
<div align="justify">In my development environment, I have Microsoft Visual Studio 2013 and Microsoft SQL Server 2012 installed.</div>
<div></div>
<div align="justify">First let me start off with with creating a WCF Service which will be consumed by the Stored Procedure. I am creating a WCF Service application,&nbsp; targeting .NET Framework 4.5.1. If you are thinking since my SQL Server version is 2012
 and the CLR version for SQL Server 2012 is 4.0, I should be using&nbsp; .NET framework 4.0 instead of 4.5.1. Don&rsquo;t worry, the .NET Framework 4.0, 4.5, and 4.5.1 include CLR 4.0, the .NET Framework 2.0, 3.0, and 3.5 include CLR 2.0 as there was no version
 3 of the CLR.</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh4.ggpht.com/-_wqAN3zWupc/UwcVEMaonGI/AAAAAAAACLg/7HcoQlnODGU/s1600-h/Picture1%25255B6%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture1" src="http://lh3.ggpht.com/-lI-2mt5ElG4/UwcVFY1iqlI/AAAAAAAACLo/PxKqZKgs6NA/Picture1_thumb%25255B4%25255D.png?imgmax=800" border="0" alt="Picture1" width="590" height="365" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Create WCF Service Application</td>
</tr>
</tbody>
</table>
<div style="text-align:justify">Here I have the following WCF Service with a method &ldquo;<strong>SayHello</strong>&rdquo; which accepts a string. So I will be calling this method from my Stored Procedure.</div>
<div style="text-align:justify">&nbsp;</div>
<p><strong><span style="text-decoration:underline">IService1.cs</span></strong></p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">[ServiceContract]</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">interface</span> IService1</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">{</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    [OperationContract]</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">string</span> SayHello(<span style="color:blue">string</span> name);</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">}</pre>
</div>
</div>
<p><strong><span style="text-decoration:underline">Service.cs</span></strong></p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> Service1 : IService1</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">{</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">string</span> SayHello(<span style="color:blue">string</span> name)</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        <span style="color:blue">return</span> <span style="color:blue">string</span>.Format(<span style="color:#006080">&quot;Hello {0}!&quot;</span>, name);</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">}</pre>
</div>
</div>
<p>Now make sure your WCF Service is up and running.<br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh6.ggpht.com/-Y4-QSZ-M0nw/UwcVGg6kcZI/AAAAAAAACLw/SaEcvV6JQa8/s1600-h/Picture2%25255B4%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture2" src="http://lh4.ggpht.com/-AU8aB3jV8Kw/UwcVHue-3oI/AAAAAAAACL4/13hLSSjWDcA/Picture2_thumb%25255B2%25255D.png?imgmax=800" border="0" alt="Picture2" width="590" height="317" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">WCF Service Up and Running</td>
</tr>
</tbody>
</table>
<div style="text-align:justify">Now I am done with creating the WCF Service Application. Now before moving into next steps let me briefly explain the approach I am going to follow.</div>
<div></div>
<div align="justify">I will need to have a SQL CLR project created using Visual Studio 2013. There I will have a Stored Procedure created. But when you are creating SQL project using Visual Studio 2013 and if you think about calling WCF Service directly from
 SQL project by adding a web reference, you can&rsquo;t do that. From SQL Projects you can&rsquo;t add web references.</div>
<div align="justify"><br>
Because of that I should have an intermediate WCF client. So I will be creating a DLL which will acts as the WCF Client here. There I will be exposing a public static method which in turn call the WCF Service. Then in my SQL CLR project, I will be adding a
 reference to that particular DLL, and then I can call it&rsquo;s public static method which will in turn call the WCF Service. Hope you all got a clear idea on my approach here.</div>
<div align="justify"><br>
Now coming back in to the action, I will now create a Class Library Project.</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh3.ggpht.com/-5GhVapRgbhE/UwcVIO1jBaI/AAAAAAAACL8/1RXcXZI4l2g/s1600-h/Picture3%25255B4%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture3" src="http://lh3.ggpht.com/-fwurAvHwHL8/UwcVJSoO6EI/AAAAAAAACMI/pm5SdiWSSNI/Picture3_thumb%25255B2%25255D.png?imgmax=800" border="0" alt="Picture3" width="590" height="364" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Create Class Library</td>
</tr>
</tbody>
</table>
<p>Now first thing I am going to do is adding a reference to my WCF Service.<br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh4.ggpht.com/-GEws0MPM5j0/UwcVJ71tWVI/AAAAAAAACMM/sEyxbnpth3w/s1600-h/Untitled4%25255B4%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Untitled4" src="http://lh4.ggpht.com/-ChTUzf9D5iE/UwcVKhS6c0I/AAAAAAAACMU/AAcEA_g7qOI/Untitled4_thumb%25255B2%25255D.png?imgmax=800" border="0" alt="Untitled4" width="506" height="363" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Add Service Reference</td>
</tr>
</tbody>
</table>
<div align="justify">From the next window, click on <strong>Advance</strong> (That&rsquo;s because we should add the reference as a Web Reference, and not as a WCF Service Reference. The WCF Client is not supported in SQL CLR, and in SQL 2012 it doesn't work).</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh3.ggpht.com/-FIt8DcZscR4/UwcVLc1mgBI/AAAAAAAACMg/cxI0UWaKCUA/s1600-h/Picture5%25255B5%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture5" src="http://lh5.ggpht.com/-XKHbr_0RGLQ/UwcVMZfsRtI/AAAAAAAACMo/PxuJFqD1Wc4/Picture5_thumb%25255B3%25255D.png?imgmax=800" border="0" alt="Picture5" width="590" height="478" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Advanced</td>
</tr>
</tbody>
</table>
<p>In the following window click on &ldquo;<strong>Add Web Reference</strong>&rdquo;.<br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh4.ggpht.com/-V0-gR6tIdA0/UwcVNUOXYsI/AAAAAAAACMw/l7WUF4EqvE0/s1600-h/Picture6%25255B5%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture6" src="http://lh5.ggpht.com/-z7sjK9AUkEY/UwcVOn5TINI/AAAAAAAACM4/izpdtThWhf8/Picture6_thumb%25255B3%25255D.png?imgmax=800" border="0" alt="Picture6" width="590" height="606" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Add Web Reference</td>
</tr>
</tbody>
</table>
<p>Now enter the WCF Service <strong>URL</strong>, provide a <strong>Web reference name</strong> and click on
<strong>Add Reference</strong>.<br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh6.ggpht.com/-HEGl-n35ab4/UwcVXJoisbI/AAAAAAAACNA/EgJrG23HvAo/s1600-h/Picture7%25255B5%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture7" src="http://lh4.ggpht.com/-UUPafPAApgk/UwcVYOTMfaI/AAAAAAAACNI/91NuKBB5kFg/Picture7_thumb%25255B3%25255D.png?imgmax=800" border="0" alt="Picture7" width="590" height="411" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Add Reference</td>
</tr>
</tbody>
</table>
<p>Now I have the following class &ldquo;MyClass&rdquo; with the following public static method &ldquo;CallWcfService&rdquo;.</p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">using</span> MyClassLibrary.svcService;</pre>
<br>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">namespace</span> MyClassLibrary</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">{</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">class</span> MyClass</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        <span style="color:blue">public</span> <span style="color:blue">static</span> <span style="color:blue">string</span> CallWcfService(<span style="color:blue">string</span> name)</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">            <span style="color:blue">string</span> result = <span style="color:blue">string</span>.Empty;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">            <span style="color:blue">using</span> (Service1 client = <span style="color:blue">new</span> Service1())</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">            {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">                result = client.SayHello(name);</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">            }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">            <span style="color:blue">return</span> result;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">}</pre>
</div>
</div>
<p>Above method accepts a string and will call the &ldquo;SayHello&rdquo; method in my WCF Service and return the result from the &ldquo;SayHello&rdquo; method.<br>
<br>
</p>
<div align="justify">Now I am done with creating the DLL, Next part is creating the SQL Project using CLR. In Visual Studio 2013, under installed templates go to
<strong>Other Languages</strong> section. There inside <strong>SQL Server</strong> category, I can find the
<strong>SQL Server Database Project</strong>.</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh6.ggpht.com/-IfKxJncsfqM/UwcVaSG5oWI/AAAAAAAACNQ/Ap7xXc6VDSM/s1600-h/Picture8%25255B5%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture8" src="http://lh3.ggpht.com/-UudHCpzTYs0/UwcVbmQ5dCI/AAAAAAAACNY/xcoNarkqdCE/Picture8_thumb%25255B3%25255D.png?imgmax=800" border="0" alt="Picture8" width="590" height="365" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Create SQL Server Database Project</td>
</tr>
</tbody>
</table>
<p>Now I am adding a New Item to the project.<br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh6.ggpht.com/-TxaEyykmf4Q/UwcVcTqVtWI/AAAAAAAACNg/kA1nanFeVGI/s1600-h/Untitled1%25255B6%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Untitled1" src="http://lh3.ggpht.com/-X5jBAuEnhIo/UwcVdnpNu7I/AAAAAAAACNo/XCkXwBmG_ck/Untitled1_thumb%25255B4%25255D.png?imgmax=800" border="0" alt="Untitled1" width="590" height="521" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Add New Item</td>
</tr>
</tbody>
</table>
<p>Then In Following window, I am selecting &ldquo;<strong>SQL CLR C# Stored Procedure</strong>&rdquo;.<br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh5.ggpht.com/-gc8KQqIbkI4/UwcVeEOxGlI/AAAAAAAACNw/yrWQvlmR7mY/s1600-h/Picture9%25255B10%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture9" src="http://lh4.ggpht.com/-MeO7loE729Y/UwcVfZfbAqI/AAAAAAAACN4/_vtGijMEjVc/Picture9_thumb%25255B6%25255D.png?imgmax=800" border="0" alt="Picture9" width="590" height="364" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Create SQL CLR C# Stored Procedure</td>
</tr>
</tbody>
</table>
<div style="text-align:justify">Now I am adding a reference to my above created DLL by right clicking on Reference, clicking on Add Reference and browsing for the DLL.</div>
<div style="text-align:justify">&nbsp;</div>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh3.ggpht.com/-XBvHvAK3BDs/UwcVfwLQFaI/AAAAAAAACOA/yAcs7RZmRUI/s1600-h/Picture10%25255B4%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture10" src="http://lh5.ggpht.com/-Guo83UoLvc0/UwcVghoj_-I/AAAAAAAACOI/Ua3koOHBleI/Picture10_thumb%25255B2%25255D.png?imgmax=800" border="0" alt="Picture10" width="311" height="193" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Reference Added</td>
</tr>
</tbody>
</table>
<p>Then I am modifying my created Stored Procedure as follows.</p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">partial</span> <span style="color:blue">class</span> StoredProcedures</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">{</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    [Microsoft.SqlServer.Server.SqlProcedure]</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">static</span> <span style="color:blue">void</span> spCallWcfService(<span style="color:blue">string</span> name)</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        <span style="color:blue">try</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">            SqlPipe sqlPipe = SqlContext.Pipe;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">            <span style="color:blue">string</span> result = MyClassLibrary.MyClass.CallWcfService(name);</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">            SqlContext.Pipe.Send(result);</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        <span style="color:blue">catch</span> (Exception ex)</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        {</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">            SqlContext.Pipe.Send(ex.Message);</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    }</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">}</pre>
</div>
</div>
<p><br>
Now the modified Stored Procedure will accepts a string. Then I am calling the static method inside my DLL and will send the result directly to the client or current output consumer.<br>
<br>
</p>
<div style="text-align:justify">Now I am all done with Visual Studio. Let&rsquo;s move into the SQL Server Management Studio. I have an empty database created there named &ldquo;<strong>MyDemoDB</strong>&rdquo;.</div>
<div style="text-align:justify">&nbsp;</div>
<p>First I am going to register my SQL CLR Project as an object in my instance of SQL Server.</p>
<div align="justify"><br>
For that I am running the following query.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">IF</span> <span style="color:blue">EXISTS</span> (</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    <span style="color:blue">SELECT</span> [name] </pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">FROM</span> sys.assemblies </pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    <span style="color:blue">WHERE</span> [name] = N<span style="color:#006080">'MySQLCLRProject'</span>)</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">&nbsp;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">    <span style="color:blue">BEGIN</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        <span style="color:blue">DROP</span> ASSEMBLY MySQLCLRProject</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        <span style="color:blue">ALTER</span> ASSEMBLY MySQLCLRProject</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        <span style="color:blue">FROM</span> <span style="color:#006080">'D:\...\MySQLCLRProject.dll'</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        <span style="color:blue">WITH</span> PERMISSION_SET = UNSAFE ;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">END</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px"><span style="color:blue">ELSE</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">BEGIN</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        <span style="color:blue">CREATE</span> ASSEMBLY MySQLCLRProject</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">        <span style="color:blue">FROM</span> <span style="color:#006080">'D:\...\MySQLCLRProject.dll'</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">        <span style="color:blue">WITH</span> PERMISSION_SET = UNSAFE;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">    <span style="color:blue">END</span></pre>
</div>
</div>
<p>I am thrown with this error.</p>
<div align="justify"><br>
<span style="color:red">CREATE ASSEMBLY for assembly 'MySQLCLRProject' failed because assembly 'MySQLCLRProject' is not authorized for PERMISSION_SET = UNSAFE.&nbsp; The assembly is authorized when either of the following is true: the database owner (DBO) has
 UNSAFE ASSEMBLY permission and the database has the TRUSTWORTHY database property on; or the assembly is signed with a certificate or an asymmetric key that has a corresponding login with UNSAFE ASSEMBLY permission.</span></div>
<div></div>
<div align="justify">For that I am running the following query.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">alter</span> <span style="color:blue">database</span> [MyDemoDB]</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px"><span style="color:blue">set</span> trustworthy <span style="color:blue">on</span>;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px">go</pre>
</div>
</div>
<p>Command got completed successfully. Then I am running the previous query back again. And this time it got completed successfully.<br>
<br>
</p>
<div align="justify">Now I am creating a T-SQL Stored Procedure inside &ldquo;<strong>MyDemoDB</strong>&rdquo; which calls the CLR Stored Procedure.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">CREATE</span> <span style="color:blue">PROCEDURE</span> [dbo].[spWcfCall]</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">      @parameter1 NVARCHAR(<span style="color:blue">MAX</span>)</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">WITH</span> <span style="color:blue">EXECUTE</span> <span style="color:blue">AS</span> CALLER</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px"><span style="color:blue">AS</span></pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">EXTERNAL</span> NAME MySQLCLRProject.StoredProcedures.spCallWcfService</pre>
</div>
</div>
<div style="text-align:justify">&ldquo;<strong>spWcfCall</strong>&rdquo; will be accepting a string. It will be then passed to to the CLR Stored Procedure. It will be again get passed to public static method in my DLL which in turn call the WCF Service.</div>
<div style="text-align:justify">&nbsp;</div>
<div align="justify">After executing the query I can see my T-SQL Procedure inside Stored Procedures in &ldquo;<strong>MyDemoDB</strong>&rdquo;</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh3.ggpht.com/-PqPyY2-LZPw/UwcVhIlTqZI/AAAAAAAACOQ/NVYVEqJ0RJA/s1600-h/Picture11%25255B17%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture11" src="http://lh4.ggpht.com/-XQE8zkQs65Q/UwcViETISUI/AAAAAAAACOY/6LGv-4Ncdxk/Picture11_thumb%25255B9%25255D.png?imgmax=800" border="0" alt="Picture11" width="294" height="305" style="float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-width:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Stored Procedure Created</td>
</tr>
</tbody>
</table>
<p>Now I am executing the &ldquo;spWcfCall&rdquo; stored procedure with a parameter hoping to see the result returned by the service.</p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">EXEC</span> spWcfCall &quot;Jaliya&quot;</pre>
</div>
</div>
<p>Again an error.</p>
<div align="justify"><br>
<span style="color:red">Execution of user code in the .NET Framework is disabled. Enable &quot;clr enabled&quot; configuration option.</span></div>
<div align="justify"><br>
For that I am running the following query.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; font-family:'Courier New',courier,monospace; width:97.5%; direction:ltr; text-align:left; margin:20px 0px 10px; line-height:12pt; max-height:1000px; background-color:#f4f4f4; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px">
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">USE</span> [MyDemoDB]</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:#f4f4f4; border-style:none; padding:0px"><span style="color:blue">EXEC</span> sp_configure <span style="color:#006080">'clr enabled'</span>, <span style="color:#006080">'1'</span>;</pre>
<pre style="overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; width:100%; color:black; direction:ltr; text-align:left; margin:0em; line-height:12pt; background-color:white; border-style:none; padding:0px"><span style="color:blue">RECONFIGURE</span>;</pre>
</div>
</div>
<div style="text-align:justify">It got completed and again I am executing the &ldquo;spWcfCall&rdquo; stored procedure. And this time no errors. My Stored Procedure has successfully called the WCF Service and resulted string is as follows.</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh5.ggpht.com/-MiDlADgGWsM/UwcVijjfujI/AAAAAAAACOc/lyZthu1bte4/s1600-h/Picture12%25255B5%25255D.png" style="margin-left:auto; margin-right:auto"><img title="Picture12" src="http://lh3.ggpht.com/-hVb8HK_BevQ/UwcVjIA_MHI/AAAAAAAACOk/hgIIKauEeE8/Picture12_thumb%25255B3%25255D.png?imgmax=800" alt="Picture12" width="129" height="25" style="float:none; margin-left:auto; display:block; margin-right:auto"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Result</td>
</tr>
</tbody>
</table>
