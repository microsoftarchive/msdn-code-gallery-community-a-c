# AdventureWorks Data Binding sample
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
## Topics
- Data Binding
- Windows Forms
- Entity Data Model
- Object Services
- Query builder methods
- Project data sources
- Property validation
- DataSource control
- DataGrid control
## Updated
- 03/04/2011
## Description

<h1 class="heading">Scenario</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionEPBHA">
<p>You can bind an <strong>ObjectQuery</strong> to a <strong>DataGridView</strong> control on a Windows form in a few lines of code. This sample demonstrates how to create the
<strong>ObjectQuery</strong> and assign the <strong>ObjectQuery</strong> to the <strong>
DataSource</strong> property of a <strong>DataGridView</strong> control. For more information about this sample, see the Adventure Works Data Binding sample topics in the
<a href="http://msdn.microsoft.com/en-us/library/065daca8-f82b-49d0-a11e-8cceb907a34b">
Entity Framework documentation</a>.</p>
</div>
<h1 class="heading">Languages</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionENBHA">
<ul>
<li>
<p>Conceptual schema definition language (CSDL)</p>
</li><li>
<p>Store schema definition language (SSDL)</p>
</li><li>
<p>Mapping specification language (MSL)</p>
</li><li>
<p>C#</p>
</li><li>
<p>Entity SQL</p>
</li></ul>
</div>
<h1 class="heading">Features</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionELBHA">
<p>This sample uses the following features of the Entity Framework.</p>
<ul>
<li>
<p>Entity Data Model</p>
</li><li>
<p>Object Services</p>
</li><li>
<p>Query builder methods</p>
</li><li>
<p>Data binding</p>
</li><li>
<p>Project data sources</p>
</li><li>
<p>Property validation</p>
</li><li>
<p>Windows Forms</p>
</li><li>
<p><strong>DataSource</strong> control</p>
</li><li>
<p><strong>DataGrid</strong> control</p>
</li></ul>
</div>
<h1 class="heading">Prerequisites</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionEJBHA">
<p>Before running this sample, make sure the following software is installed:</p>
<ul>
<li>
<p>Visual Studio 2008 SP1 containing the .NET Framework 3.5</p>
</li><li>
<p>SQL Server 2005 or 2008 Database Engine</p>
<ul>
<li>
<p>AdventureWorks sample database</p>
</li><li>
<p>SQL Server Management Studio (optional)</p>
</li></ul>
</li></ul>
</div>
<h1 class="heading">Building the Sample</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionEHBHA">
<p>Use the following procedure to build the sample.</p>
<h3 class="subHeading">To build the AdventureWorks Data Binding sample application</h3>
<div class="subSection">
<ol>
<li>
<p>(Optional) If the AdventureWorks sample database is not already present in your SQL Server instance, download and install it from
<a href="http://go.microsoft.com/fwlink/?LinkId=124770" target="_blank">Sample Databases for Microsoft SQL Server 2005 SP2</a>.</p>
</li><li>
<p>Open the AdWksSalesWinDataBind solution file in Visual Studio.</p>
</li><li>
<p>(Optional) If you created the AdventureWorks database in an instance of SQL Server other than the default instance on the local machine, specify the correct SQL Server instance by modifying the Data Source in the AdventureworksEntities connection string
 in the App.Config file of the AdWksSalesWinDataBind project.</p>
</li><li>
<p>Build the project.</p>
</li></ol>
</div>
</div>
<h1 class="heading">Running the Sample</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionEFBHA">
<p>Use the following procedure to run the sample.</p>
<h3 class="subHeading">To run the AdventureWorks Data Binding application</h3>
<div class="subSection">
<ol>
<li>
<p>Run the application.</p>
</li><li>
<p>Enter a SalesOrderHeaderID value in the <strong>Order Number</strong> text box. Use a number between 43659 and 75123, and click the
<strong>Get Sales Order</strong> button.</p>
</li><li>
<p>In the <strong>Sales Order Details</strong> data grid, modify the number in the
<strong>Quantity</strong> column, and press <strong>Enter</strong>.</p>
<p>Line and order totals are updated by business logic on the client.</p>
</li><li>
<p>Click the <strong>Add Detail to Order</strong> button.</p>
</li><li>
<p>When the <strong>Add SalesOrderDetail</strong> dialog appears, click to select a
<strong>Product</strong> from the data grid.</p>
</li><li>
<p>Enter a quantity and optional discount, which must be a value between 0 and 1.</p>
</li><li>
<p>Click <strong>Create Order</strong>. A new order is created and added to the <strong>
Sales Order Details</strong> data grid.</p>
</li></ol>
</div>
</div>
<h1 class="heading">Removing the Sample</h1>
<div class="seeAlsoNoToggleSection" id="sectionSectionEDBHA">
<p>Use the following procedure to remove the AdventureWorks Data Binding sample.</p>
<h3 class="subHeading">To remove the AdventureWorks Data Binding application</h3>
<div class="subSection">
<ol>
<li>
<p>Delete the project directory and contents.</p>
</li><li>
<p>(Optional) Drop the AdventureWorks database from the instance of SQL Server.</p>
</li></ol>
</div>
</div>
<h1 class="heading"><span id="seeAlsoNoToggle">See Also</span></h1>
<div class="seeAlsoNoToggleSection" id="seeAlsoSection">
<h4 class="subHeading">Other Resources</h4>
<a href="http://msdn.microsoft.com/en-us/library/a437041f-6899-4ae7-96ce-aabf528d7205" target="_blank">ADO.NET Entity Framework</a><br>
<a href="http://msdn.microsoft.com/en-us/library/64a9fba4-9166-4140-be0b-43f15531cdd1" target="_blank">Entity Data Model</a><br>
<a href="http://msdn.microsoft.com/en-us/library/1af01b4c-1046-4b5d-bc50-d6f3b64e92af" target="_blank">Binding Objects to Controls</a></div>
