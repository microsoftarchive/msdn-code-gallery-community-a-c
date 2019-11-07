Imports System.Data.OleDb

Module OleDbDemos

    Private ConnectionNoHeader As String = "provider= Microsoft.ACE.OLEDB.12.0; data source='{0}';Extended Properties=""Excel 12.0; HDR=No;"""

    Public Sub OpenSheetInDataGridView(ByVal FileName As String, ByVal SheetName As String)
        Dim f As New frmViewSheetData

        Try
            Dim dt As New DataTable

            Using cn As New OleDbConnection With {.ConnectionString = String.Format(ConnectionNoHeader, FileName)}
                cn.Open()

                Dim cmd As OleDbCommand = New OleDbCommand(
                                          <Text>
                                              SELECT F1 As TheMonth, F2 as Spent FROM [<%= SheetName %>$A2:B5]
                                          </Text>.Value,
                                        cn
                )

                dt.Load(cmd.ExecuteReader)
            End Using

            f.Text = "Sheet name: " & SheetName

            f.DataGridView1.DataSource = dt
            f.DataGridView1.Columns("TheMonth").HeaderText = "Month"

            f.ShowDialog()
        Finally
            f.Dispose()
        End Try

    End Sub
End Module
