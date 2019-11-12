# ComboBox Databinding
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- ADO.NET
## Topics
- Data Binding
## Updated
- 05/27/2011
## Description

<h1>Introduction</h1>
<p><span id="ctl00_ctl00_Content_TabContentPanel_Content_wikiSourceLabel">Shows how to bind data to ComboBox and DataGridView controls.</span></p>
<h1 class="heading"><span>Requirements</span></h1>
<div class="section" id="requirementsTitleSection">
<p>This sample requires the Northwind database. For more information, see <a href="http://msdn.microsoft.com/en-us/library/5ey0sd99%28v=VS.100%29.aspx" target="_blank">
How to: Install and Troubleshoot Database Components for Samples</a>.</p>
</div>
<h1 class="procedureSubHeading">To run this sample</h1>
<div class="subSection">
<ul>
<li>
<p>Press F5.</p>
</li></ul>
</div>
<h1>Description</h1>
<p>The code demonstrates how to bind six different types of data sources to a ComboBox control. Data is bound from:</p>
<ul>
<li>
<p>an array</p>
</li><li>
<p>an ArrayList of strings</p>
</li><li>
<p>an ArrayList of class objects</p>
</li><li>
<p>a DataTable</p>
</li><li>
<p>a DataView</p>
</li><li>
<p>a BindingSource object</p>
</li></ul>
<p>When the main form loads, the <span class="code">Products</span> table from the Northwind database is retrieved into a DataSet using a simple SQL Select statement. A DataView that provides a sorted view of the
<span class="code">ProductName</span> column is also created at this time. The <span class="code">
Products</span> table is loaded into another DataSet using a TableAdapter and BindingSource.</p>
<p>The user can then populate the combo box control by binding to another array of colors, an array list of shapes, an advanced array list containing sales divisions defined with a structure, the products table residing in either dataset, or the sorted data
 view. If the user binds to the dataset, data view or the advanced array list of sales divisions, when an entry is selected from the combo box, an associated value for that entry is also displayed. If the user binds to the data connector, the combo box and
 datagridview are in sync. Changing the value of the combo box moves the datagridview to the same record. Scrolling through the dataset in the grid or using the navigation toolbar updates the combo box.</p>
<p>The main form contains the combo box controls, button controls to load data, and two label controls and a grid to display the data source and the selected value. The ArrayList, DataSet, and DataView allow you to associate a value with each item displayed
 in the combo box control. For example, if the user selects the product entry <span class="code">
Chai</span> from the products table bound to the combo box, Chai is displayed as the selected entry, but its associated
<span class="code">ProductId</span> is also available through the SelectedValue property. The ValueMember property allows you to select the item that contains the associated value. The DisplayMember property allows you to select the item that is displayed
 in the combo box control.</p>
<h1 class="heading"><span>Creating this Sample</span></h1>
<div class="section" id="sectionSection0">
<p>Most of this form was created by dragging components onto the form, then using smart tags and settings in the
<span class="ui">Properties</span> window. The following is a quick summary of how you could create the DataGridView portion of the form from scratch:</p>
<ol>
<li>
<p>Create a new Windows Application project.</p>
</li><li>
<p>With <span class="code">Form1</span> open, select the <span class="ui">Data Source</span> window. It can also be activated by means of the
<span class="ui">Data</span> menu.</p>
</li><li>
<p>In the <span class="ui">Data Sources</span> window, click <span class="ui">
Add New Data Source</span>.</p>
</li><li>
<p>In the <span class="ui">Data Source Configuration Wizard</span>, choose Database as the data source type.</p>
</li><li>
<p>For the data connection, choose a server that has Northwind on it.</p>
</li><li>
<p>The following step allows you to save the connection string in a strongly typed application settings file.</p>
<ol>
<li>
<p>In the Choose Your Database Objects, select the <span class="code">Products</span> table.</p>
</li><li>
<p>Click <span class="ui">Finish</span> to create your typed dataset for the Northwind database. You can see the results in the
<span class="ui">Data Sources</span> window.</p>
</li></ol>
</li><li>
<p>From the <span class="ui">Data Sources</span> window, drag the <span class="code">
Products</span> table to <span class="code">Form1</span>.</p>
</li><li>
<p>As a result, you will see a data-bound DataGridView and BindingNavigator controls added to the form designer surface. You will also see the
<span class="code">NorthwindDataSet</span>, <span class="code">ProductsTableAdapter</span>, and
<span class="code">ProductsBindingSource</span> added to the component tray.</p>
</li></ol>
</div>
<h1 class="heading"><span>Loading Data Within the Form</span></h1>
<div class="section" id="sectionSection1">
<p>In this example, you load the form with data without any parameters provided by the user. Using the
<span class="ui">DataSet Designer</span> you can to leverage reusable DataAdapters to fill
<span class="code">dsProducts2</span>.</p>
<p>When you drag the <span class="ui">Employees</span> table from the <span class="ui">
Data Sources</span> window, Visual Studio automatically places code to call the default query on the TableAdapter in the
<span class="code">Form.Load</span> event. In this sample this code was moved to the
<span class="code">btnDC</span> Click method:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">'&nbsp;Fill&nbsp;the&nbsp;Lookup&nbsp;Tables&nbsp;
Me.ProductsTableAdapter.Fill(Me.NorthwindDataSet.Products)</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:20px; font-weight:bold">Sample Code</span></div>
<p>&nbsp;</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Bind&nbsp;to&nbsp;a&nbsp;simple&nbsp;arraylist&nbsp;that&nbsp;has&nbsp;entries&nbsp;for&nbsp;different&nbsp;shapes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnArrayList_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnArrayList.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myShapes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ArrayList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;myShapes&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="visualBasic__string">&quot;Circle&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="visualBasic__string">&quot;Octagon&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="visualBasic__string">&quot;Rectangle&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="visualBasic__string">&quot;Squre&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="visualBasic__string">&quot;Trapezoid&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="visualBasic__string">&quot;Triange&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComboBox1.DataSource&nbsp;=&nbsp;myShapes&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComboBox1.SelectedIndex&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblDataSource.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ArrayList&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=2025715432">app.config</a>
</li><li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=1811932399">Divisions.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=1327427881">MainForm.Designer.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=2030557487">MainForm.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=263140602">NorthwindDataSet.Designer.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=1683634888">Status.Designer.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/ComboBox-Databinding-ab61d9d5/sourcecode?fileId=22490&pathId=1786342958">Status.vb</a>
</li></ul>
<h1>More Information</h1>
<p>For more information on Databinding: <a href="http://social.msdn.microsoft.com/Search/en-US?query=databinding" target="_blank">
http://social.msdn.microsoft.com/Search/en-US?query=databinding</a></p>
