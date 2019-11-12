Imports System.Xml.Linq
Public Class frmDisplayColumns
    WithEvents bsColumns As New BindingSource
    Private Table As New DataTable
    Private GridView As DataGridView

    ''' <summary>
    ''' Pass in the DataGridView to work on column visible property
    ''' </summary>
    ''' <param name="sender">DataGridView to allow changing visible property of each column</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef sender As DataGridView)
        InitializeComponent()

        GridView = sender

        Table.Columns.AddRange(New DataColumn() _
            { _
                New DataColumn("Action", GetType(System.Boolean)), _
                New DataColumn("ColumnName", GetType(System.String)) _
            } _
        )
    End Sub
    Private Sub DisplayColumns_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        For Each Col As DataGridViewColumn In GridView.Columns
            Table.Rows.Add(New Object() {Col.Visible, Col.Name})
        Next

        bsColumns.DataSource = Table
        DataGridView1.DataSource = bsColumns
        DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        ' Apply settings to the DataGridView 
        For Each row As DataRow In Table.Rows
            GridView.Columns(row(1).ToString).Visible = CBool(row(0))
        Next

        '---------------------------------------------------------------------------------------
        ' The remaining code is demoing how to save column visibility to a XML file then read it
        ' back for restoring which columns are visible. To implement this is your job in regards
        ' to restoring columns, not a difficult task.
        '---------------------------------------------------------------------------------------

        ' Prep for remembering column visibility to file
        Dim Contents = _
        <Columns>
            <%= From Row In Table.Rows.Cast(Of DataRow)() Select _
                <Column>
                    <ColumnName><%= Row.Item("ColumnName") %></ColumnName>
                    <Visible><%= Row.Item("Action") %></Visible>
                </Column> %>
        </Columns>

        ' Write column information to file
        IO.File.WriteAllText("Columns.xml", Contents.ToString)
        Application.DoEvents()

        ' Get column information
        Dim Document As New XDocument
        Dim ColumnsInfo = _
        ( _
            From C In XDocument.Load("Columns.xml")...<Column> _
            Select ColumnName = C.<ColumnName>.Value, Visible = Convert.ToBoolean(C.<Visible>.Value) _
        ).ToList

        ' Show it
        For Each Col In ColumnsInfo
            Console.WriteLine("{0}.visible = {1}", Col.ColumnName, Col.Visible)
            If GridView.Columns.Contains(Col.ColumnName) Then
                GridView.Columns(Col.ColumnName).Visible = Col.Visible
            End If
        Next

    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class