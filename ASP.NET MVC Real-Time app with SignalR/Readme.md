# ASP.NET MVC Real-Time app with SignalR
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC 4
- ASP.NET SignalR
## Topics
- ASP.NET SignalR
## Updated
- 10/20/2016
## Description

<h1><strong>ASP.NET MVC Real-Time app with SignalR</strong><strong>&nbsp;</strong></h1>
<p>In topic we will focus on how to display real time updates from database with SignalR on existing ASP.NET MVC CRUD project.</p>
<p>The topic has two step:</p>
<p>1.&nbsp; First step we will create a sample app to perform CRUD operations</p>
<p>2.&nbsp; Second step we will make the app real-time with SignalR</p>
<p>&nbsp;</p>
<p>Who are not familiar yet with SignalR <a href="http://shashangka.com/2016/01/08/signalr-basic/">
Overview of SignalR</a> from my previous post.</p>
<p>&nbsp;</p>
<h2><strong><span style="text-decoration:underline">Step &ndash; 1</span></strong></h2>
<p>At first we need to create a database named <em>CRUD_Sample.</em> In sample db we have to create a table named
<em>Customer.</em></p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE TABLE [dbo].[Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustName] [varchar](100) NULL,
	[CustEmail] [varchar](150) NULL
)

</pre>
<div class="preview">
<pre class="js">CREATE&nbsp;TABLE&nbsp;[dbo].[Customer](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Id]&nbsp;[bigint]&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CustName]&nbsp;[varchar](<span class="js__num">100</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CustEmail]&nbsp;[varchar](<span class="js__num">150</span>)&nbsp;NULL&nbsp;
)&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<h2><span style="text-decoration:underline">Stored Procedures:</span></h2>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">USE [CRUD_Sample]
GO

/****** Object:  StoredProcedure [dbo].[Delete_Customer]    Script Date: 12/27/2015 1:44:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		&lt;Author,,Name&gt;
-- Create date: &lt;Create Date,,&gt;
-- Description:	&lt;Description,,&gt;
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Customer]
	-- Add the parameters for the stored procedure here
	 @Id Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM[dbo].[Customers] WHERE [Id] = @Id
	RETURN 1
END

GO

/****** Object:  StoredProcedure [dbo].[Get_Customer]    Script Date: 12/27/2015 1:44:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		&lt;Author,,Name&gt;
-- Create date: &lt;Create Date,,&gt;
-- Description:	&lt;Description,,&gt;
-- =============================================
CREATE PROCEDURE [dbo].[Get_Customer] 
	-- Add the parameters for the stored procedure here
	@Count INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT top(@Count)* FROM [dbo].[Customers]
END

GO

/****** Object:  StoredProcedure [dbo].[Get_CustomerbyID]    Script Date: 12/27/2015 1:44:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		&lt;Author,,Name&gt;
-- Create date: &lt;Create Date,,&gt;
-- Description:	&lt;Description,,&gt;
-- =============================================
CREATE PROCEDURE [dbo].[Get_CustomerbyID] 
	-- Add the parameters for the stored procedure here
	@Id BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[Customers]
	WHERE Id=@Id
END

GO

/****** Object:  StoredProcedure [dbo].[Set_Customer]    Script Date: 12/27/2015 1:44:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		&lt;Author,,Name&gt;
-- Create date: &lt;Create Date,,&gt;
-- Description:	&lt;Description,,&gt;
-- =============================================
CREATE PROCEDURE [dbo].[Set_Customer]
	-- Add the parameters for the stored procedure here
	 @CustName Nvarchar(100)
	,@CustEmail Nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Customers] ([CustName],[CustEmail])
	VALUES(@CustName,@CustEmail)
	RETURN 1
END

GO

/****** Object:  StoredProcedure [dbo].[Update_Customer]    Script Date: 12/27/2015 1:44:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		&lt;Author,,Name&gt;
-- Create date: &lt;Create Date,,&gt;
-- Description:	&lt;Description,,&gt;
-- =============================================
CREATE PROCEDURE [dbo].[Update_Customer]
	-- Add the parameters for the stored procedure here
	 @Id Bigint
	,@CustName Nvarchar(100)
	,@CustEmail Nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Customers] SET[CustName] = @CustName ,[CustEmail]= @CustEmail
	WHERE [Id] = @Id
	RETURN 1
END

GO
</pre>
<div class="preview">
<pre class="js">USE&nbsp;[CRUD_Sample]&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;StoredProcedure&nbsp;[dbo].[Delete_Customer]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">12</span>/<span class="js__num">27</span><span class="js__reg_exp">/2015&nbsp;1:44:05&nbsp;PM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Author,,Name&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;Create&nbsp;<span class="js__object">Date</span>,,&gt;&nbsp;
--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;Description,,&gt;&nbsp;
--&nbsp;=============================================&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[Delete_Customer]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Id&nbsp;Bigint&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;interfering&nbsp;<span class="js__statement">with</span>&nbsp;SELECT&nbsp;statements.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Insert&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DELETE&nbsp;FROM[dbo].[Customers]&nbsp;WHERE&nbsp;[Id]&nbsp;=&nbsp;@Id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RETURN&nbsp;<span class="js__num">1</span>&nbsp;
END&nbsp;
&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;StoredProcedure&nbsp;[dbo].[Get_Customer]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">12</span>/<span class="js__num">27</span><span class="js__reg_exp">/2015&nbsp;1:44:05&nbsp;PM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Author,,Name&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;Create&nbsp;<span class="js__object">Date</span>,,&gt;&nbsp;
--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;Description,,&gt;&nbsp;
--&nbsp;=============================================&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[Get_Customer]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Count&nbsp;INT&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;interfering&nbsp;<span class="js__statement">with</span>&nbsp;SELECT&nbsp;statements.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Insert&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;top(@Count)*&nbsp;FROM&nbsp;[dbo].[Customers]&nbsp;
END&nbsp;
&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;StoredProcedure&nbsp;[dbo].[Get_CustomerbyID]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">12</span>/<span class="js__num">27</span><span class="js__reg_exp">/2015&nbsp;1:44:05&nbsp;PM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Author,,Name&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;Create&nbsp;<span class="js__object">Date</span>,,&gt;&nbsp;
--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;Description,,&gt;&nbsp;
--&nbsp;=============================================&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[Get_CustomerbyID]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Id&nbsp;BIGINT&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;interfering&nbsp;<span class="js__statement">with</span>&nbsp;SELECT&nbsp;statements.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Insert&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;*&nbsp;FROM&nbsp;[dbo].[Customers]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WHERE&nbsp;Id=@Id&nbsp;
END&nbsp;
&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;StoredProcedure&nbsp;[dbo].[Set_Customer]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">12</span>/<span class="js__num">27</span><span class="js__reg_exp">/2015&nbsp;1:44:05&nbsp;PM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Author,,Name&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;Create&nbsp;<span class="js__object">Date</span>,,&gt;&nbsp;
--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;Description,,&gt;&nbsp;
--&nbsp;=============================================&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[Set_Customer]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@CustName&nbsp;Nvarchar(<span class="js__num">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,@CustEmail&nbsp;Nvarchar(<span class="js__num">150</span>)&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;interfering&nbsp;<span class="js__statement">with</span>&nbsp;SELECT&nbsp;statements.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Insert&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;INSERT&nbsp;INTO&nbsp;[dbo].[Customers]&nbsp;([CustName],[CustEmail])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;VALUES(@CustName,@CustEmail)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RETURN&nbsp;<span class="js__num">1</span>&nbsp;
END&nbsp;
&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;StoredProcedure&nbsp;[dbo].[Update_Customer]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">12</span>/<span class="js__num">27</span><span class="js__reg_exp">/2015&nbsp;1:44:05&nbsp;PM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Author,,Name&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;Create&nbsp;<span class="js__object">Date</span>,,&gt;&nbsp;
--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;Description,,&gt;&nbsp;
--&nbsp;=============================================&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[Update_Customer]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Id&nbsp;Bigint&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,@CustName&nbsp;Nvarchar(<span class="js__num">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,@CustEmail&nbsp;Nvarchar(<span class="js__num">150</span>)&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;interfering&nbsp;<span class="js__statement">with</span>&nbsp;SELECT&nbsp;statements.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Insert&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UPDATE&nbsp;[dbo].[Customers]&nbsp;SET[CustName]&nbsp;=&nbsp;@CustName&nbsp;,[CustEmail]=&nbsp;@CustEmail&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WHERE&nbsp;[Id]&nbsp;=&nbsp;@Id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RETURN&nbsp;<span class="js__num">1</span>&nbsp;
END&nbsp;
&nbsp;
GO&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<h2><span style="text-decoration:underline">Getting Started with MVC Project:</span></h2>
<p>To create the sample applications, we need to have Visual Studio 2012 or later installed and be able to run the server on a platform that supports .NET 4.5.</p>
<p>Click ok and the visual studio will create and load a new ASP.NET application template. In this case we are using ASP.NET MVC 5.&nbsp;</p>
<p>&nbsp;</p>
<h2><span style="text-decoration:underline">Repository Pattern:</span></h2>
<p>The Repository Pattern allows to centralise all data access logic in one place. It is a common construct to avoid duplication of data access logic throughout our application.</p>
<p>The Repository pattern adds a separation layer between the data and business layers of an application.</p>
<p>&nbsp;</p>
<h1><strong><span style="text-decoration:underline">Step &ndash; 2</span></strong></h1>
<h2><span style="text-decoration:underline">Getting Started with SignalR:</span></h2>
<p>The first thing is getting reference from NuGet.</p>
<p><em>Get it on NuGet!</em></p>
<p><em>Install-Package Microsoft.AspNet.SignalR</em></p>
<h2><span style="text-decoration:underline">Register SignalR middleware:</span></h2>
<p>Once you have it installed. Let&rsquo;s create OwinStartup Class.</p>
<p>The following code adds a simple piece of middleware to the OWIN pipeline, implemented as a function that receives a Microsoft.Owin.IOwinContext instance.</p>
<p>&nbsp;</p>
<p>When the server receives an HTTP request, the OWIN pipeline invokes the middleware. The middleware sets the content type for the response and writes the response body.</p>
<p>&nbsp;</p>
<h2><span style="text-decoration:underline">Create &amp; Use Hub classes:</span></h2>
<p>After finishing previous process, let&rsquo;s create a Hub. A SignalR Hub make remote procedure calls (RPCs) from a server to connected clients and from clients to the server.</p>
