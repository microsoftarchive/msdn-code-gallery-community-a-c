# A super simple MVC that connects VS 2013 to a sample MySQL database
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- HTML5
- MVC
- MySQL
- ASP.NET MVC 5
## Topics
- C#
- Model View Controller (MVC)
- ASP.NET MVC
- ASP.NET MVC Basics
- ASP.NET MVC 4
- MySQL
- Visual C#
- MVC Samples
- MVC Example
- C# programming
## Updated
- 06/23/2015
## Description

<h1>
<div class="endscriptcode">Introduction</div>
</h1>
<p><em>For many, myself included, MySQL and MVC are mysteries.&nbsp; MySQL is a mystery because Microsoft has only recently embraced other technologies, so I never used MySQL.&nbsp; MVC is a mystery because it is hard to do a super simple sample that preforms
 some useful function, at least it is for me.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You will need to install the MySQL using the installer at: <a href="http://bit.ly/mysqlinstaller">
http://bit.ly/mysqlinstaller</a> , on 6/23/2015 it will only install with VS 2013 SKUs, and will not install with VS 2013 Express versions.&nbsp; Once you have the MySQL installed, you should make sure you can make a connection from your Visual Studio using
 instructions at my blog: <a href="http://bit.ly/howtoconnecttomySQL">http://bit.ly/howtoconnecttomySQL</a>, this will insure that you have gotten everything working using a simple console application that is based on the MySQL documentation (that doesn't work
 as written).</em></p>
<p><em>This app was tested on 6/23/2015 using VS 2013 Ultimate 2013 Version 12.0.31101.00 Update 4 and .NET Framework Version 4.5.51641.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>For many people, myself included, may have difficulty getting started with Model, View, Controller type of programming, and to just add a little more interest I included a MySQL database with the sample.&nbsp; If you are looking to implementing MVC and
 need to get up to speed, there are many tutorials, but few that keep it really simple.&nbsp; And as far as I can tell (please tell me if there are others) there are none that do this using MySQL.</em></p>
<p><em>In this sample, which is explained on&nbsp;my blog at: <a href="http://bit.ly/readfrommySQL">
http://bit.ly/readfrommySQL</a>, you will have a full up, but not very useful ASP MVC application.&nbsp; More to come!<br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="html"><span class="html__comment">&lt;!--View&nbsp;Code--&gt;</span>&nbsp;
<span class="html__comment">&lt;!----&gt;</span>&nbsp;
<span class="html__doctype">&lt;!DOCTYPE&nbsp;html&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="html__tag_start">&lt;html</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;viewport&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;width=device-width&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span>Index<span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Name:&nbsp;@Model.first_name<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Last&nbsp;Name:&nbsp;@Model.last_name<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
<span class="html__comment">&lt;!--Stop&nbsp;Copying&nbsp;Code&nbsp;Here--&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>The Source File, MSPASPFirstOne.zip contains all of the files needed to run the application, EXPECT you will need to install the MySQL files.&nbsp;
</em></li></ul>
<h1>More Information</h1>
<p><em>For more information see the blog at <a href="http://bit.ly/readfrommySQL">
http://bit.ly/readfrommySQL</a>.</em></p>
