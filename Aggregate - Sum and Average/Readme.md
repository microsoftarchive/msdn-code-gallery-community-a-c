# Aggregate - Sum and Average
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server Integration Services
- SQL Server Integration Services 2012
## Topics
- SsisAggregateTransform
## Updated
- 04/19/2012
## Description

<h1>Purpose</h1>
<p>This sample demonstrates how to use the Aggregate transform.</p>
<h1>Description</h1>
<p>This sample contains a&nbsp;package that uses an Aggregate transform to calculate the total sales quantity and average unit price for each product in the SalesOrderDetail table in the AdventureWorks database. In both aggregations, the column&nbsp;that defines
 the groupings is the ProductID column.</p>
<h1>Before running the package</h1>
<h2>External dependencies</h2>
<p>This sample assumes that:</p>
<ul>
<li>You have already downloaded and attached to a local, default instance of SQL Server the AdventureWorks sample database from codeplex.com.
</li><li>The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and your user account has access to the AdventureWorks database.
</li><li>You have attached the database with the name, &quot;AdventureWorks&quot;. If the instance of the AdventureWorks sample database you want to use is attached to another instance and/or the name of the database as attached is not &quot;AdventureWorks&quot; edit the AdventureWorks
 connection manager. </li></ul>
<h1>Further reading</h1>
<p>For more information on the Aggregate transform, see the following topic: <a href="http://msdn.microsoft.com/en-us/library/ms138031.aspx">
http://msdn.microsoft.com/en-us/library/ms138031.aspx</a></p>
<p>For a step-by-step guide on how to configure an Aggregate transform of your own, see this guide:
<a href="http://msdn.microsoft.com/en-us/library/ms137839.aspx">http://msdn.microsoft.com/en-us/library/ms137839.aspx</a></p>
