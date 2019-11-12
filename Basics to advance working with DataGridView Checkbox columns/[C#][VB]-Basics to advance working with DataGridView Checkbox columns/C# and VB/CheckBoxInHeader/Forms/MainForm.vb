''' <summary>
'''
''' </summary>
''' <remarks>
''' 
''' The code for check/uncheck all is from a C Sharp project on
''' Code Project http://www.codeproject.com/KB/grid/SelectAll.aspx
''' while all other code is from Kevin S Gallagher
''' </remarks>
Public Class frmMainForm

   WithEvents mCustomersBindingSource As New BindingSource

   Private mCustomersDocument As XDocument
   Private mCheckedRows() As DataGridViewRow

   Private TotalCheckBoxes As Integer = 0
   Private TotalCheckedCheckBoxes As Integer = 0
   Private HeaderCheckBox As CheckBox = Nothing
   Private IsHeaderCheckBoxClicked As Boolean = False
   Private xmlCheckedRowIdentifiers As XDocument
   Private mCompanyFile As String = "Sessions.xml"
   Private mIdentifier As String = ""

   Private Const CheckBoxColName As String = "Process"

#Region " Non-Data code "
   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      LoadData()
   End Sub
   Private Sub cmdCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseForm.Click
      Close()
   End Sub
#End Region
#Region " Code to save Checked items on form close "
   Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      If Not IsNothing(DataGridView2.DataSource) Then

         Dim Rows = _
         ( _
             From Row In DataGridView2.Rows.Cast(Of DataGridViewRow)() _
             Select Company = Row.Cells("Company").Value, ID = Row.Cells("ID").Value).ToList

         xmlCheckedRowIdentifiers = <?xml version="1.0" encoding="utf-8"?><Companies></Companies>

         For Each Row In Rows
            xmlCheckedRowIdentifiers.<Companies>(0) _
            .Add(<Company><CustomerID><%= Row.ID %></CustomerID></Company>)
         Next

         xmlCheckedRowIdentifiers.Save(mCompanyFile)

      Else

         If IO.File.Exists(mCompanyFile) Then
            IO.File.Delete(mCompanyFile)
         End If

      End If
   End Sub
#End Region
#Region " Load data and populate both DataGridview "
   Private Sub LoadData()

      ' begin code for checkbox in header
      AddHeaderCheckBox()
      ' end code for checkbox in header

      cmdClearBottomDataGridView.Enabled = False

      mCustomersDocument = XDocument.Load("Customers.xml")

      Dim Customers = _
         ( _
            From customer In mCustomersDocument...<Customer> _
            Select Identifier = customer.<CustomerID>.Value, _
                   CompanyName = customer.<CompanyName>.Value _
         ).ToDataTable.AsDataView

      DataGridView1.AutoGenerateColumns = False

      DataGridView1.Columns.AddRange( _
         New DataGridViewColumn() _
            {New DataGridViewCheckBoxColumn _
               With {.HeaderText = "", .Name = CheckBoxColName}, _
             New DataGridViewTextBoxColumn _
               With {.DataPropertyName = "CompanyName", _
                     .HeaderText = "Company", .Name = "CompanyName"}, _
             New DataGridViewTextBoxColumn _
               With {.DataPropertyName = "Identifier", .Name = "Identifier"} _
         })

      mCustomersBindingSource.DataSource = Customers

      DataGridView1.DataSource = mCustomersBindingSource
      DataGridView1.Columns("Identifier").Visible = False

      '
      ' Get all identifers that were checked in the top DataGridView
      ' and Check then for this session.
      '
      If IO.File.Exists(mCompanyFile) Then
         Dim Row As Integer = 0

         Dim Identifiers = (From Company In XDocument.Load(mCompanyFile)...<Company> _
                            Select Company.<CustomerID>.Value).ToList

         For Each Item In Identifiers
            Row = mCustomersBindingSource.Find("Identifier", Item)
            DataGridView1(0, Row).Value = True
         Next

         PopulateBottomDataGridView()

      End If

      DataGridView1.AutoResizeColumns()


      ' begin code for checkbox in header
      TotalCheckBoxes = DataGridView1.RowCount
      TotalCheckedCheckBoxes = 0

      AddHandler HeaderCheckBox.KeyUp, AddressOf HeaderCheckBox_KeyUp
      AddHandler HeaderCheckBox.MouseClick, AddressOf HeaderCheckBox_MouseClick
      AddHandler DataGridView1.CellValueChanged, AddressOf dgvSelectAll_CellValueChanged
      AddHandler DataGridView1.CurrentCellDirtyStateChanged, AddressOf dgvSelectAll_CurrentCellDirtyStateChanged
      AddHandler DataGridView1.CellPainting, AddressOf dgvSelectAll_CellPainting
      '
      ' This logic is optional as the checkbox in the header being checked if not
      ' a system action but a user action. So it depends if the checkbox is checked
      ' from the system or not, in this case the system is toggling the checkbox.
      '
      If DataGridView1.CheckBoxCount(0, True) = DataGridView1.RowCount Then
         HeaderCheckBox.Checked = True
      End If
      ' end code for checkbox in header

   End Sub
#End Region
   Private Sub mCustomersBindingSource_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mCustomersBindingSource.PositionChanged
      mIdentifier = DirectCast(mCustomersBindingSource.Current, DataRowView).Item("Identifier").ToString()
   End Sub
   Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
      mCustomersBindingSource.Position = mCustomersBindingSource.Find("Identifier", mIdentifier)
   End Sub

   Private Sub cmdCheckedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckedRows.Click
      If DataGridView1.CheckBoxCount(CheckBoxColName, True) > 0 Then
         Dim Rows = DataGridView1.GetCheckedRows1(CheckBoxColName)
         For Each Row In Rows
            Console.WriteLine(Row.Cells.Item(1).Value)
         Next
      End If
   End Sub
End Class
