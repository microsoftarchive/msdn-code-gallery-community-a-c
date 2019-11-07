# ASP.NET Chart Control Sample Web Application
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET Code Sample Downloads
## Topics
- ASP.NET
- ASP.NET Code Sample Downloads
- ASPNET
- Chart Control
## Updated
- 08/17/2012
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">This &nbsp;Article shows how to make a 3D Pie chart from a datatable&nbsp;In Business Application reporting functionality is important.&nbsp;</span></em></p>
<p><span style="font-size:small"><em>1)Download My Sample.</em></span></p>
<p><span style="font-size:small"><em>2)Inside that folder Student.sql file will be there execute it in your database<em>.<em><em>&nbsp;<em><em>&nbsp;</em></em></em></em></em></em></span><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>SQL</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">mysql</span>
<pre class="hidden">USE [master]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 08/17/2012 18:31:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Student](
	[pk_id] [int] IDENTITY(1,1) NOT NULL,
	[StudName] [varchar](50) NULL,
	[StudTotal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
</pre>
<div class="preview">
<pre class="js">USE&nbsp;[master]&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Student]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">08</span>/<span class="js__num">17</span><span class="js__reg_exp">/2012&nbsp;18:31:11&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;ANSI_PADDING&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[Student](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[pk_id]&nbsp;[int]&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[StudName]&nbsp;[varchar](<span class="js__num">50</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[StudTotal]&nbsp;[int]&nbsp;NULL,&nbsp;
PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[pk_id]&nbsp;ASC&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;ANSI_PADDING&nbsp;OFF&nbsp;
GO&nbsp;
</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;<em><em>
<div class="endscriptcode"><span style="font-size:small">&nbsp;<em>3)Change the connetion string in web.config file.</em></span><em><span style="font-size:small">&nbsp;</span></em><em><span style="font-size:small">&nbsp;</span></em></div>
</em></em></em></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>
<pre class="hidden">	&lt;add name=&quot;MyConnection&quot; connectionString=&quot;Data Source=MONISH-PC\MONISH;Initial Catalog=master;Persist Security Info=True;User ID=saty;Password=1234&quot; providerName=&quot;System.Data.SqlClient&quot;/&gt;
	&lt;/connectionStrings&gt;
</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;add&nbsp;name=<span class="js__string">&quot;MyConnection&quot;</span>&nbsp;connectionString=<span class="js__string">&quot;Data&nbsp;Source=MONISH-PC\MONISH;Initial&nbsp;Catalog=master;Persist&nbsp;Security&nbsp;Info=True;User&nbsp;ID=saty;Password=1234&quot;</span>&nbsp;providerName=<span class="js__string">&quot;System.Data.SqlClient&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/connectionStrings&gt;&nbsp;
</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><span style="font-size:small"><em>&nbsp;4.Build the Application it will work fine..Read on to learn more!</em></span></div>
</div>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<ul>
<li><em><span style="font-size:small">Add New Project Choose Web Forms Application.</span></em>
</li><li><em><span style="font-size:small">Create a Student table in sql server by executing this sql file student.sql</span></em>
</li><li><em><span style="font-size:small">Adding ASP.NET Chart Control to web forms.</span></em>
</li><li><em><span style="font-size:small">drag the&nbsp;</span></em><em><span style="font-size:small">Chart Control and gridview control.</span></em>
</li><li><em><span style="font-size:small">Using Same Model layer with ASP.NET GridView with Enabling &nbsp;Edit / Delete support of records in SQL server database.</span></em>
</li><li><em><span style="font-size:small">Reflecting the changes in Chart Controls after editing records from GridView.</span></em>
</li><li><em><span style="font-size:small">Dynamically changing ASP.NET 4.0 Chart Control Type.</span></em>
</li></ul>
<p><img id="64836" src="64836-1.jpg" alt="" width="728" height="669"></p>
<p>&nbsp;</p>
<p><img id="64837" src="64837-2.jpg" alt="" width="872" height="669"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="64838" src="64838-3.jpg" alt="" width="712" height="669"></p>
<p>&nbsp;</p>
<p><img id="64839" src="64839-4.jpg" alt="" width="728" height="669"></p>
<p>&nbsp;</p>
<p><img id="64841" src="64841-5.jpg" alt="" width="580" height="421"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">A chart consists of one or more series, which are lists of data points. Typically, each data point is a pair of numbers that provide both the X value and Y value to be plotted.&nbsp;In this sample i coded X value for Student
 Name and Y Value for Total Marks for particular student.</span></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:small"><em>student.sql</em></span> </li></ul>
<h1>More Information</h1>
<p><span style="font-size:small"><em>The Microsoft Chart controls make it easy to take data from a database or some other data store and present it as a chart.you can bind an ADO.NET Dataset directly to the Chart</em></span></p>
