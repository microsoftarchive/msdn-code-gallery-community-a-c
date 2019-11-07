# Adding new records into Microsoft Access tables and display in a DataGridView
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Data Access
- VB.Net
- Microsoft access database 2007
## Topics
- Data Binding
- SQL
- Data Access
## Updated
- 10/28/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">This article demonstrates how to add new rows to a Microsoft Access database table where all operations are done without Visual Studio IDE data wizards.<br>
<br>
08/2014 The following shows how to do this in SQL-Server in both C# and VB.NET<br>
<br>
<a href="http://code.msdn.microsoft.com/Adding-new-records-into-bff5eaaf" target="_blank">Adding new records into SQL-Server table and update a DataGridView in real time</a></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">12/9/2014 added a secondary example in the VB.NET form project that simply shows that we should consider trimming values being sent into a INSERT statement.<br>
<br>
12/8/2015 added C# class library, updated solution to VS2013</span></p>
<p><br>
<span style="font-size:small">A well designed solution will separate database operations from the user interface thus all data operations are done in a class project. These operations could be placed in the same project but this is a better design if you want
 to use the code in other solutions.</span><br>
<br>
<span style="font-size:small">To keep things simple data is added to the database table via mocked data in a list because if I allowed the operator to add data there would be a need for validation which is not within the scope of this demo which is to show
 how to add rows to the backend database table then upon success add rows to the DataGridView.</span><br>
<br>
<span style="font-size:small">At program startup data is loaded into a DataTable which is used to set the DataSource of a BindingSource. Note, the BindingSource is a great component for doing things like find, re-positioning, adding, editing and removal of
 data but in this demonstration only a find is used, again like validation discussed above I am keeping this simple. After the BindingSource DataSource is set to the DataTable we set the BindingSource as the DataSource to the DataGridView which will show several
 records.</span><br>
<br>
<span style="font-size:small">Pressing the Demo button will iterate through a list one by one and insert a new row in the backend database customer table. A second SQL statement is executed immediately to get the new primary key for the record just added. This
 new primary key is then passed back to the UI. The UI will then add a new DataRow to the DataTable which is the DataSource of the BindingSource. Adding the record will then be displayed in the DataGridView. The key here is the secondary SQL statement Select
 @@Identity. Caveat, the same can be done with Microsoft SQL-Server but we can use one SQL statement for the insert and one for the new primary key together in the command object's CommandText but not with OleDb and Microsoft Access.</span><br>
<br>
<span style="font-size:small">Please read all the comments in the code which will assist you to use this logic in your applications. Also, the same logic shown here will work in C# with one change, the SQL statements must be done with the @ symbol preceeding
 the string and without the tags. What I did here for the C# version is use the same class project as the VB.NET Windows forms project.</span></p>
<p><span style="font-size:small"><img id="123674" src="123674-am.png" alt="" width="462" height="259"><br>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function AddNewRow(ByVal sender As Customer, ByRef Identfier As Integer) As Boolean
    Dim Success As Boolean = True

    Try
        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Builder.ConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}

                cmd.CommandText = InsertStatement

                cmd.Parameters.AddWithValue(&quot;@CompanyName&quot;, sender.CompanyName)
                cmd.Parameters.AddWithValue(&quot;@ContactName&quot;, sender.ContactName)
                cmd.Parameters.AddWithValue(&quot;@ContactTitle&quot;, sender.ContactTitle)

                cn.Open()

                cmd.ExecuteNonQuery()

                cmd.CommandText = &quot;Select @@Identity&quot;
                Identfier = CInt(cmd.ExecuteScalar)

            End Using
        End Using

    Catch ex As Exception
        Success = False
    End Try

    Return Success

End Function
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;AddNewRow(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Customer,&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;Identfier&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Success&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDb.OleDbConnection&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.ConnectionString&nbsp;=&nbsp;Builder.ConnectionString}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDb.OleDbCommand&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.Connection&nbsp;=&nbsp;cn}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;InsertStatement&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="visualBasic__string">&quot;@CompanyName&quot;</span>,&nbsp;sender.CompanyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="visualBasic__string">&quot;@ContactName&quot;</span>,&nbsp;sender.ContactName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="visualBasic__string">&quot;@ContactTitle&quot;</span>,&nbsp;sender.ContactTitle)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Select&nbsp;@@Identity&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identfier&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(cmd.ExecuteScalar)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Success&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Success&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small">UI Code</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">''' &lt;summary&gt;
''' Database1.accdb has been setup to be copied to Bin\Debug folder
''' each time you run this demo so we start fresh each time.
''' 
''' Run the oproject, press Demo button.
''' Close the app
''' 
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Public Class Form1

    ''' &lt;summary&gt;
    ''' Access to database operations
    ''' &lt;/summary&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Private DataOpts As New DataAccess.Operations

    ''' &lt;summary&gt;
    ''' Used for the data source for the DataGridView
    ''' &lt;/summary&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    WithEvents bsCustmers As New BindingSource

    ''' &lt;summary&gt;
    ''' Load data from back end database
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bsCustmers.DataSource = DataOpts.LoadCustomers
        DataGridView1.DataSource = bsCustmers
    End Sub
    ''' &lt;summary&gt;
    ''' Add new rows to the cutomer table, we get the new primary key via the method
    ''' AddNewRow.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Private Sub cmdAddRows_Click(sender As Object, e As EventArgs) Handles cmdAddRows.Click
        Dim SeconaryTry As Boolean = False
        Dim Customers As New List(Of Customer) From
            {
                New Customer With {.CompanyName = &quot;BDF Inc.&quot;, .ContactName = &quot;Anne&quot;, .ContactTitle = &quot;Owner&quot;},
                New Customer With {.CompanyName = &quot;Bill's shoes&quot;, .ContactName = &quot;Bill&quot;, .ContactTitle = &quot;Owner&quot;},
                New Customer With {.CompanyName = &quot;Salem Fishing Corp&quot;, .ContactName = &quot;Debbie&quot;, .ContactTitle = &quot;Sales&quot;}
            }

        Dim NewIdentifier As Integer = 0
        Dim dt As DataTable = CType(bsCustmers.DataSource, DataTable)

        For Each Customer In Customers
            '
            ' See if the row already exists
            '
            If bsCustmers.Find(&quot;CompanyName&quot;, Customer.CompanyName) = -1 Then
                If DataOpts.AddNewRow(Customer, NewIdentifier) Then
                    dt.Rows.Add(New Object() {NewIdentifier, Customer.CompanyName, Customer.ContactName, Customer.ContactTitle})
                End If
            Else
                SeconaryTry = True
                Exit For
            End If
        Next

        If SeconaryTry Then
            MessageBox.Show(&quot;This was designed to work once :-)&quot;)
        End If
    End Sub
    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        DataOpts.ViewDatabase()
    End Sub
End Class
</pre>
<pre class="hidden">using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// &lt;summary&gt;
        /// Access to database operations
        /// &lt;/summary&gt;
        /// &lt;remarks&gt;&lt;/remarks&gt;
        private DataAccess.Operations DataOpts = new DataAccess.Operations();

        /// &lt;summary&gt;
        /// Used for the data source for the DataGridView
        /// &lt;/summary&gt;
        /// &lt;remarks&gt;&lt;/remarks&gt;
        private BindingSource bsCustmers = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bsCustmers.DataSource = DataOpts.LoadCustomers();
            DataGridView1.DataSource = bsCustmers;
        }

        private void cmdAddRows_Click(object sender, EventArgs e)
        {
            bool SeconaryTry = false;
            List&lt;Customer&gt; Customers = new List&lt;Customer&gt;() {
			new Customer {CompanyName = &quot;BDF Inc.&quot;, ContactName = &quot;Anne&quot;, ContactTitle = &quot;Owner&quot;},
			new Customer {CompanyName = &quot;Bill's shoes&quot;, ContactName = &quot;Bill&quot;, ContactTitle = &quot;Owner&quot;},
			new Customer {CompanyName = &quot;Salem Fishing Corp&quot;, ContactName = &quot;Debbie&quot;, ContactTitle = &quot;Sales&quot;}
		};

            int NewIdentifier = 0;
            DataTable dt = (DataTable)bsCustmers.DataSource;
            foreach (var Customer in Customers)
            {
                //
                // See if the row already exists
                //
                if (bsCustmers.Find(&quot;CompanyName&quot;, Customer.CompanyName) == -1)
                {
                    if (DataOpts.AddNewRow(Customer, ref NewIdentifier))
                    {
                        dt.Rows.Add(new object[] { NewIdentifier, Customer.CompanyName, Customer.ContactName, Customer.ContactTitle });
                    }
                }
                else
                {
                    SeconaryTry = true;
                    break;
                }
            }

            if (SeconaryTry)
            {
                MessageBox.Show(&quot;This was designed to work once :-)&quot;);
            }
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            DataOpts.ViewDatabase();
        }
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;Database1.accdb&nbsp;has&nbsp;been&nbsp;setup&nbsp;to&nbsp;be&nbsp;copied&nbsp;to&nbsp;Bin\Debug&nbsp;folder</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;each&nbsp;time&nbsp;you&nbsp;run&nbsp;this&nbsp;demo&nbsp;so&nbsp;we&nbsp;start&nbsp;fresh&nbsp;each&nbsp;time.</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;Run&nbsp;the&nbsp;oproject,&nbsp;press&nbsp;Demo&nbsp;button.</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;Close&nbsp;the&nbsp;app</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Access&nbsp;to&nbsp;database&nbsp;operations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;DataOpts&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataAccess.Operations&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Used&nbsp;for&nbsp;the&nbsp;data&nbsp;source&nbsp;for&nbsp;the&nbsp;DataGridView</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;bsCustmers&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;BindingSource&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Load&nbsp;data&nbsp;from&nbsp;back&nbsp;end&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsCustmers.DataSource&nbsp;=&nbsp;DataOpts.LoadCustomers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.DataSource&nbsp;=&nbsp;bsCustmers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Add&nbsp;new&nbsp;rows&nbsp;to&nbsp;the&nbsp;cutomer&nbsp;table,&nbsp;we&nbsp;get&nbsp;the&nbsp;new&nbsp;primary&nbsp;key&nbsp;via&nbsp;the&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;AddNewRow.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;cmdAddRows_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;cmdAddRows.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;SeconaryTry&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Customers&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Customer)&nbsp;From&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Customer&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.CompanyName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;BDF&nbsp;Inc.&quot;</span>,&nbsp;.ContactName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Anne&quot;</span>,&nbsp;.ContactTitle&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Owner&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Customer&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.CompanyName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Bill's&nbsp;shoes&quot;</span>,&nbsp;.ContactName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Bill&quot;</span>,&nbsp;.ContactTitle&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Owner&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Customer&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.CompanyName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Salem&nbsp;Fishing&nbsp;Corp&quot;</span>,&nbsp;.ContactName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Debbie&quot;</span>,&nbsp;.ContactTitle&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Sales&quot;</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;NewIdentifier&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(bsCustmers.DataSource,&nbsp;DataTable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;Customer&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Customers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;See&nbsp;if&nbsp;the&nbsp;row&nbsp;already&nbsp;exists</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;bsCustmers.Find(<span class="visualBasic__string">&quot;CompanyName&quot;</span>,&nbsp;Customer.CompanyName)&nbsp;=&nbsp;-<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataOpts.AddNewRow(Customer,&nbsp;NewIdentifier)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{NewIdentifier,&nbsp;Customer.CompanyName,&nbsp;Customer.ContactName,&nbsp;Customer.ContactTitle})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SeconaryTry&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;SeconaryTry&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;This&nbsp;was&nbsp;designed&nbsp;to&nbsp;work&nbsp;once&nbsp;:-)&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;cmdView_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;cmdView.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataOpts.ViewDatabase()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;The following is for the updated code in the VB.NET project to add a record from a modal form. Will update the C# code shortly to do the same.</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="162815" src="162815-newfigure.jpg" alt="" width="496" height="740"><br>
</span></div>
<div class="endscriptcode"></div>
