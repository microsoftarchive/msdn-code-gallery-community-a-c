# CRUD - ASP.Net MVC, Web Api-2, Windows Form
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- Windows Forms
## Topics
- CRUD
## Updated
- 10/20/2016
## Description

<h1>Introduction</h1>
<p>In this article we will learn basic CRUD operation using Web Api-2, and Stored Procedure with a sample Desktop Application.</p>
<h2><strong><span style="text-decoration:underline">Sample Database:</span></strong></h2>
<p>Let&rsquo;s Create a Sample database named &lsquo;SampleDB&rsquo; with SQL Management Studio. Using the &lsquo;SampleDB&rsquo; now create a Table name &lsquo;tblCustomer&rsquo;.</p>
<p><strong>Script:</strong></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE TABLE [dbo].[tblCustomer](
	[CustID] [bigint] NOT NULL,
	[CustName] [nvarchar](50) NULL,
	[CustEmail] [nvarchar](50) NOT NULL,
	[CustAddress] [nvarchar](256) NULL,
	[CustContact] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC,
	[CustEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustID</span>]&nbsp;[<span class="sql__keyword">bigint</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustName</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustEmail</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustAddress</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">256</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustContact</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;<span class="sql__keyword">CONSTRAINT</span>&nbsp;[<span class="sql__id">PK_tblCustomer</span>]&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;<span class="sql__id">CLUSTERED</span>&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustID</span>]&nbsp;<span class="sql__keyword">ASC</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustEmail</span>]&nbsp;<span class="sql__keyword">ASC</span>&nbsp;
)<span class="sql__keyword">WITH</span>&nbsp;(<span class="sql__id">PAD_INDEX</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">STATISTICS_NORECOMPUTE</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">IGNORE_DUP_KEY</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">ALLOW_ROW_LOCKS</span>&nbsp;=&nbsp;<span class="sql__keyword">ON</span>,&nbsp;<span class="sql__id">ALLOW_PAGE_LOCKS</span>&nbsp;=&nbsp;<span class="sql__keyword">ON</span>)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
&nbsp;
<span class="sql__id">GO</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><strong>Stored Procedure:</strong></p>
<p>Now the step we will go through to perform CRUD operations with stored procedure:</p>
<ol>
<li>First we will create a stored procedure (SP) to RETRIVE record from Customer table
</li><li>Now we will create a stored procedure( SP) to INSERT record into Customer table
</li><li>Now we will create another procedure (SP) to UPDATE existing data in our Customer table.
</li><li>&nbsp;The last step we will create a stored procedure to DELETE existing record from customer table.
</li></ol>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong><span style="text-decoration:underline">Stored Procedure to RETRIVE Record:</span></strong></p>
<p>&nbsp; </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">-- =============================================
-- Author:		&lt;Shashangka,,Shekhar&gt;
-- Create date: &lt;05/10/2015,,&gt;
-- Description:	&lt;With this SP we will Retrive Customer Record from Customer Table,,&gt;
-- =============================================
ALTER PROCEDURE [dbo].[READ_CUSTOMER]
	-- Add the parameters for the stored procedure here
	 @PageNo INT
	,@RowCountPerPage INT
	,@IsPaging INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
    -- Select statements for procedure here

	IF(@IsPaging = 0)
	BEGIN
		SELECT top(@RowCountPerPage)* FROM [dbo].[tblCustomer]
		ORDER BY CustID DESC
	END

	IF(@IsPaging = 1)
	BEGIN
		DECLARE @SkipRow INT
		SET @SkipRow = (@PageNo - 1) * @RowCountPerPage

		SELECT * FROM [dbo].[tblCustomer]
		ORDER BY CustID DESC
	
		OFFSET @SkipRow ROWS FETCH NEXT @RowCountPerPage ROWS ONLY
	END
END
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__com">--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Shashangka,,Shekhar&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Create&nbsp;date:&nbsp;&lt;05/10/2015,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;With&nbsp;this&nbsp;SP&nbsp;we&nbsp;will&nbsp;Retrive&nbsp;Customer&nbsp;Record&nbsp;from&nbsp;Customer&nbsp;Table,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">PROCEDURE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">READ_CUSTOMER</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;for&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">PageNo</span>&nbsp;<span class="sql__keyword">INT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">RowCountPerPage</span>&nbsp;<span class="sql__keyword">INT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">IsPaging</span>&nbsp;<span class="sql__keyword">INT</span>&nbsp;
<span class="sql__keyword">AS</span>&nbsp;
<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">NOCOUNT</span>&nbsp;<span class="sql__keyword">ON</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Select&nbsp;statements&nbsp;for&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">IF</span>(<span class="sql__keyword">@</span><span class="sql__variable">IsPaging</span>&nbsp;=&nbsp;<span class="sql__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__id">top</span>(<span class="sql__keyword">@</span><span class="sql__variable">RowCountPerPage</span>)*&nbsp;<span class="sql__keyword">FROM</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ORDER</span>&nbsp;<span class="sql__keyword">BY</span>&nbsp;<span class="sql__id">CustID</span>&nbsp;<span class="sql__keyword">DESC</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">IF</span>(<span class="sql__keyword">@</span><span class="sql__variable">IsPaging</span>&nbsp;=&nbsp;<span class="sql__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">DECLARE</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">SkipRow</span>&nbsp;<span class="sql__keyword">INT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">SkipRow</span>&nbsp;=&nbsp;(<span class="sql__keyword">@</span><span class="sql__variable">PageNo</span>&nbsp;-&nbsp;<span class="sql__number">1</span>)&nbsp;*&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">RowCountPerPage</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;*&nbsp;<span class="sql__keyword">FROM</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ORDER</span>&nbsp;<span class="sql__keyword">BY</span>&nbsp;<span class="sql__id">CustID</span>&nbsp;<span class="sql__keyword">DESC</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">OFFSET</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">SkipRow</span>&nbsp;<span class="sql__keyword">ROWS</span>&nbsp;<span class="sql__keyword">FETCH</span>&nbsp;<span class="sql__keyword">NEXT</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">RowCountPerPage</span>&nbsp;<span class="sql__keyword">ROWS</span>&nbsp;<span class="sql__id">ONLY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;
<span class="sql__keyword">END</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><strong><span style="text-decoration:underline">Stored Procedure to INSERT Record:</span></strong></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">-- =============================================
-- Author:		&lt;Shashangka,,Shekhar&gt;
-- Create date: &lt;05/10/2015,,&gt;
-- Description:	&lt;With this SP we will Insert Customer Record to Customer Table,,&gt;
-- =============================================
ALTER PROCEDURE [dbo].[CREATE_CUSTOMER]
	-- Add the parameters for the stored procedure here
(
	 @CustName NVarchar(50)
	,@CustEmail NVarchar(50)
	,@CustAddress NVarchar(256)
	,@CustContact  NVarchar(50)
)
AS
BEGIN
	---- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	---- Try Catch--
	BEGIN TRY
		BEGIN TRANSACTION

		DECLARE @CustID Bigint
			SET @CustID = isnull(((SELECT max(CustID) FROM [dbo].[tblCustomer])&#43;1),'1')

		-- Insert statements for procedure here
		INSERT INTO [dbo].[tblCustomer] ([CustID],[CustName],[CustEmail],[CustAddress],[CustContact])
		VALUES(@CustID,@CustName,@CustEmail,@CustAddress,@CustContact)
		SELECT 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;
			SELECT @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY(),@ErrorState = ERROR_STATE();
			RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);
		ROLLBACK TRANSACTION
	END CATCH

END
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__com">--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Shashangka,,Shekhar&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Create&nbsp;date:&nbsp;&lt;05/10/2015,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;With&nbsp;this&nbsp;SP&nbsp;we&nbsp;will&nbsp;Insert&nbsp;Customer&nbsp;Record&nbsp;to&nbsp;Customer&nbsp;Table,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">PROCEDURE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">CREATE_CUSTOMER</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;for&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here</span>&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustName</span>&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">50</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustEmail</span>&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">50</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustAddress</span>&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">256</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustContact</span>&nbsp;&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">50</span>)&nbsp;
)&nbsp;
<span class="sql__keyword">AS</span>&nbsp;
<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__com">--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">NOCOUNT</span>&nbsp;<span class="sql__keyword">ON</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__com">--&nbsp;Try&nbsp;Catch--</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__id">TRY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">DECLARE</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>&nbsp;<span class="sql__keyword">Bigint</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>&nbsp;=&nbsp;<span class="sql__function">isnull</span>(((<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__function">max</span>(<span class="sql__id">CustID</span>)&nbsp;<span class="sql__keyword">FROM</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>])&#43;<span class="sql__number">1</span>),<span class="sql__string">'1'</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Insert&nbsp;statements&nbsp;for&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>]&nbsp;([<span class="sql__id">CustID</span>],[<span class="sql__id">CustName</span>],[<span class="sql__id">CustEmail</span>],[<span class="sql__id">CustAddress</span>],[<span class="sql__id">CustContact</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>(<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>,<span class="sql__keyword">@</span><span class="sql__variable">CustName</span>,<span class="sql__keyword">@</span><span class="sql__variable">CustEmail</span>,<span class="sql__keyword">@</span><span class="sql__variable">CustAddress</span>,<span class="sql__keyword">@</span><span class="sql__variable">CustContact</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">COMMIT</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;<span class="sql__id">TRY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__id">CATCH</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">DECLARE</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__number">4000</span>),<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>&nbsp;<span class="sql__keyword">INT</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>&nbsp;<span class="sql__keyword">INT</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_MESSAGE</span>(),<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_SEVERITY</span>(),<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_STATE</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">RAISERROR</span>&nbsp;(<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ROLLBACK</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;<span class="sql__id">CATCH</span>&nbsp;
&nbsp;
<span class="sql__keyword">END</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><strong><span style="text-decoration:underline">Stored Procedure to UPDATE Record:</span></strong></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">-- =============================================
-- Author:		&lt;Shashangka,,Shekhar&gt;
-- Create date: &lt;05/10/2015,,&gt;
-- Description:	&lt;With this SP we will Update Customer Record to Customer Table,,&gt;
-- =============================================
ALTER PROCEDURE [dbo].[UPDATE_CUSTOMER]
	-- Add the parameters for the stored procedure here
	 @CustID BIGINT
	,@CustName NVarchar(50)
	,@CustEmail NVarchar(50)
	,@CustAddress NVarchar(256)
	,@CustContact  NVarchar(50)
AS
BEGIN
	---- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	---- Try Catch--
	BEGIN TRY
		BEGIN TRANSACTION

		-- Update statements for procedure here
		UPDATE [dbo].[tblCustomer]
		SET [CustName] = @CustName,
			[CustAddress] = @CustAddress,
			[CustContact] = @CustContact
		WHERE [CustID] = @CustID AND [CustEmail] = @CustEmail
		SELECT 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;
			SELECT @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY(),@ErrorState = ERROR_STATE();
			RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);
		ROLLBACK TRANSACTION
	END CATCH

END
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__com">--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Shashangka,,Shekhar&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Create&nbsp;date:&nbsp;&lt;05/10/2015,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;With&nbsp;this&nbsp;SP&nbsp;we&nbsp;will&nbsp;Update&nbsp;Customer&nbsp;Record&nbsp;to&nbsp;Customer&nbsp;Table,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">PROCEDURE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">UPDATE_CUSTOMER</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;for&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>&nbsp;<span class="sql__keyword">BIGINT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustName</span>&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">50</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustEmail</span>&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">50</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustAddress</span>&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">256</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__keyword">@</span><span class="sql__variable">CustContact</span>&nbsp;&nbsp;<span class="sql__keyword">NVarchar</span>(<span class="sql__number">50</span>)&nbsp;
<span class="sql__keyword">AS</span>&nbsp;
<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__com">--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">NOCOUNT</span>&nbsp;<span class="sql__keyword">ON</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__com">--&nbsp;Try&nbsp;Catch--</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__id">TRY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Update&nbsp;statements&nbsp;for&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">UPDATE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;[<span class="sql__id">CustName</span>]&nbsp;=&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustName</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustAddress</span>]&nbsp;=&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustAddress</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CustContact</span>]&nbsp;=&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustContact</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__id">CustID</span>]&nbsp;=&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>&nbsp;<span class="sql__keyword">AND</span>&nbsp;[<span class="sql__id">CustEmail</span>]&nbsp;=&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustEmail</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">COMMIT</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;<span class="sql__id">TRY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__id">CATCH</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">DECLARE</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__number">4000</span>),<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>&nbsp;<span class="sql__keyword">INT</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>&nbsp;<span class="sql__keyword">INT</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_MESSAGE</span>(),<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_SEVERITY</span>(),<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_STATE</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">RAISERROR</span>&nbsp;(<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ROLLBACK</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;<span class="sql__id">CATCH</span>&nbsp;
&nbsp;
<span class="sql__keyword">END</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><strong><span style="text-decoration:underline">Stored Procedure to DELETE Record:</span></strong></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">-- =============================================
-- Author:		&lt;Shashangka,,Shekhar&gt;
-- Create date: &lt;05/10/2015,,&gt;
-- Description:	&lt;With this SP we will Delete Customer Record from Customer Table,,&gt;
-- =============================================
ALTER PROCEDURE [dbo].[DELETE_CUSTOMER]
	-- Add the parameters for the stored procedure here
	  @CustID BIGINT
AS
BEGIN
	---- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	---- Try Catch--
	BEGIN TRY
		BEGIN TRANSACTION

		-- Delete statements for procedure here
		DELETE [dbo].[tblCustomer]
		WHERE [CustID] = @CustID 
		SELECT 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;
			SELECT @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY(),@ErrorState = ERROR_STATE();
			RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);
		ROLLBACK TRANSACTION
	END CATCH

END
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__com">--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Shashangka,,Shekhar&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Create&nbsp;date:&nbsp;&lt;05/10/2015,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;With&nbsp;this&nbsp;SP&nbsp;we&nbsp;will&nbsp;Delete&nbsp;Customer&nbsp;Record&nbsp;from&nbsp;Customer&nbsp;Table,,&gt;</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================</span>&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">PROCEDURE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">DELETE_CUSTOMER</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;for&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>&nbsp;<span class="sql__keyword">BIGINT</span>&nbsp;
<span class="sql__keyword">AS</span>&nbsp;
<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__com">--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">NOCOUNT</span>&nbsp;<span class="sql__keyword">ON</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__com">--&nbsp;Try&nbsp;Catch--</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__id">TRY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__com">--&nbsp;Delete&nbsp;statements&nbsp;for&nbsp;procedure&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">DELETE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">tblCustomer</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__id">CustID</span>]&nbsp;=&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">CustID</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">COMMIT</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;<span class="sql__id">TRY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;<span class="sql__id">CATCH</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">DECLARE</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__number">4000</span>),<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>&nbsp;<span class="sql__keyword">INT</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>&nbsp;<span class="sql__keyword">INT</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_MESSAGE</span>(),<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_SEVERITY</span>(),<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>&nbsp;=&nbsp;<span class="sql__id">ERROR_STATE</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">RAISERROR</span>&nbsp;(<span class="sql__keyword">@</span><span class="sql__variable">ErrorMessage</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorSeverity</span>,<span class="sql__keyword">@</span><span class="sql__variable">ErrorState</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ROLLBACK</span>&nbsp;<span class="sql__keyword">TRANSACTION</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">END</span>&nbsp;<span class="sql__id">CATCH</span>&nbsp;
&nbsp;
<span class="sql__keyword">END</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><strong><span style="text-decoration:underline">Stored Procedure to VIEW Single Record Details:</span></strong></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">-- =============================================
-- Author:		&lt;Shashangka,,Shekhar&gt;
-- Create date: &lt;05/10/2015,,&gt;
-- Description:	&lt;With this SP we will Retrive Single Customer Record from Customer Table,,&gt;
-- =============================================
ALTER PROCEDURE [dbo].[VIEW_CUSTOMER]
	-- Add the parameters for the stored procedure here
	@CustID BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
    -- Select statements for procedure here

	SELECT * FROM [dbo].[tblCustomer]
	WHERE [CustID] = @CustID 
END

</pre>
<div class="preview">
<pre class="js">--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Shashangka,,Shekhar&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;<span class="js__num">05</span><span class="js__reg_exp">/10/</span><span class="js__num">2015</span>,,&gt;&nbsp;
--&nbsp;Description:&nbsp;&nbsp;&nbsp;&nbsp;&lt;With&nbsp;<span class="js__operator">this</span>&nbsp;SP&nbsp;we&nbsp;will&nbsp;Retrive&nbsp;Single&nbsp;Customer&nbsp;Record&nbsp;from&nbsp;Customer&nbsp;Table,,&gt;&nbsp;
--&nbsp;=============================================&nbsp;
ALTER&nbsp;PROCEDURE&nbsp;[dbo].[VIEW_CUSTOMER]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Add&nbsp;the&nbsp;parameters&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;stored&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@CustID&nbsp;BIGINT&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Select&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;*&nbsp;FROM&nbsp;[dbo].[tblCustomer]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WHERE&nbsp;[CustID]&nbsp;=&nbsp;@CustID&nbsp;&nbsp;
END&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><strong><span style="text-decoration:underline">Let&rsquo;s Start:</span></strong></p>
<p>Open Visual Studio 2015, Click File&gt; New &gt; Project. In this window give a name the project and solution.&nbsp;</p>
<p>Click ok and another window will appear with project template, choose Web API:</p>
<p>Click ok and the visual studio will create and load a new ASP.NET application template.</p>
<p>In this app we are going to apply CRUD operation on a single table named <em>Customer</em>. To do first we need to create apiController for the operations. To add a new Controller file we need to click right mouse an option menu will appear Click Add &gt;
 Controller.</p>
<p>Let&rsquo;s name it CustomerController. In the controller we will create action methods to perform CRUD operations.</p>
<p><strong><span style="text-decoration:underline">Let&rsquo;s Create Windows Form Application:</span></strong></p>
<p>Open Visual Studio 2015, Click File&gt; New &gt; Project. In this window give a name the project and solution. This time we will create a Windows Form Application.</p>
<p>In our new application let&rsquo;s create a new Form, name it CRUDForm.cs</p>
<p>In CRUD form we have a data grid which will load all data from database through api controller.&nbsp;</p>
