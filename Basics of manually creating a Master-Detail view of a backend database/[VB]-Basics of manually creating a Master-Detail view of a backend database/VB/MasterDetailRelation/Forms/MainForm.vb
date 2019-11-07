Imports KSG_ExtensionMethods
Imports DataAccess.ProjectGlobals
Public Class frmMainForm
    WithEvents bsMaster As New BindingSource()
    WithEvents bsDetails As New BindingSource()

    Private Sub frmMainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFromDatabase()
    End Sub

    Public Sub LoadFromDatabase()
        Dim ErrorMessage As String = ""
        Dim DataAccess As New DataAccess.CustomerOrdersSetup

        If DataAccess.Load(ErrorMessage) Then
            bsMaster = DataAccess.Master
            bsDetails = DataAccess.Details

            MasterGrid.DataSource = bsMaster
            ChildGrid.DataSource = bsDetails

            MasterGrid.Columns("Freight").DefaultCellStyle.Format = "C2"
            MasterGrid.Columns("Freight").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            MasterGrid.Columns("Freight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            MasterGrid.Columns("Freight").DefaultCellStyle.NullValue = "0"
            MasterGrid.Columns("PostalCode").HeaderText = "Postal"

            BindingNavigator1.BindingSource = bsMaster

            MasterGrid.Columns.Item(CustomerIdentifier).Visible = False
            MasterGrid.Columns("CompanyName").HeaderText = "Company Name"

            ChildGrid.AutoGenerateColumns = False

            MasterGrid.AutoResizeColumns()

            Dim HideColums() As String = {"Column1", "ShipName", "ShipRegion", "ShipPostalCode"}

            For Each col In HideColums
                ChildGrid.Columns(col).Visible = False
            Next

            ChildGrid.AutoResizeColumns()

            AddHandler ChildGrid.CellFormatting, AddressOf ChildGridEvents.ChildGrid_CellFormatting
            AddHandler ChildGrid.CellEnter, AddressOf DGV_CellEnter
        Else
            MessageBox.Show(ErrorMessage)
        End If

    End Sub

    ''' <summary>
    ''' Simple example of creating a DataView of Orders for the currently
    ''' selected customer and show in a child form for demoing.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ToolStripButton1.Click, cmdShowChildDetails.Click

        Dim custView As DataView = New DataView(DirectCast(bsMaster.DataSource, DataSet).Tables("Orders").Copy,
                                                <T>
                                                    <%= CustomerIdentifier() %> = 
                                                    '<%= bsMaster.CurrentCustomerIdentifier %>'
                                                </T>.Value, _
                                                CustomerIdentifier,
                                                DataViewRowState.CurrentRows
        )

        Dim sb As New System.Text.StringBuilder

        sb.AppendLine(String.Format("Order count [{1}] for [{0}]", bsMaster.CurrentRow("CompanyName"), custView.Count))

        sb.AppendLine()
        sb.AppendLine(String.Format("Ship date                 Freight"))

        sb.AppendLine(String.Format("----------------------    -------"))

        For Row As Integer = 0 To custView.Count - 1
            If IsDBNull(custView(Row)("ShippedDate")) Then
                sb.AppendLine(String.Format("{0,-25} [{1}]", "Not shipped", custView(Row)("Freight")))
            Else
                sb.AppendLine(String.Format("{0,-25} [{1}]", custView(Row)("ShippedDate"), custView(Row)("Freight")))
            End If
        Next

        Dim f As New frmShowDetails

        Try
            f.Text = String.Concat("Company: ", bsMaster.CurrentRow("CompanyName"))
            f.TextBox1.Text = sb.ToString
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try

    End Sub
    Private Sub cmdShowDataGridViewColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowDataGridViewColumns.Click
        Dim f As New frmDisplayColumns(MasterGrid)
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
    <System.Diagnostics.DebuggerStepThrough()>
    Public Sub DGV_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If ChildGrid(e.ColumnIndex, e.RowIndex).EditType IsNot Nothing Then
            If ChildGrid.IsCalendarCell(e) Then
                SendKeys.Send("{F2}")
            End If
        End If
    End Sub
    Private Sub MasterGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles MasterGrid.CellFormatting
        If MasterGrid.CurrentRow IsNot Nothing Then
            If MasterGrid.CurrentRow.IsNewRow Then
                Exit Sub
            End If

            If e.ColumnIndex = MasterGrid.Columns("Freight").Index Then
                If Not IsDBNull(e.Value) Then
                    If CDbl(e.Value) < 100.0 Then
                        e.CellStyle.ForeColor = Color.CadetBlue
                    End If
                Else
                    e.CellStyle.BackColor = Color.LightSteelBlue
                End If

            End If
        End If
    End Sub
    ''' <summary>
    ''' Demo showing how to gain access to child rows of the current parent customer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcess.Click
        Dim TheList =
            (
                From T In DirectCast(bsMaster.DataSource, DataSet).Tables("Orders").AsEnumerable
                Where T.Field(Of Boolean)("Process") = True
            ).ToList

        If TheList.Count > 0 Then
            My.Dialogs.InformationDialog("You marked " & TheList.Count.ToString & " items")
        Else
            My.Dialogs.InformationDialog("Nothing marked to process.")
        End If

    End Sub
End Class
