Public Class Form1

    WithEvents bsJobs As New BindingSource

    Private Sub Form1_Load() Handles MyBase.Load

        Dim dt As New DataTable With {.TableName = "Jobs"}


        With dt.Columns
            .AddRange(New DataColumn() _
               { _
                  New DataColumn("Assign", System.Type.GetType("System.Boolean")),
                  New DataColumn("DateAssigned", System.Type.GetType("System.DateTime"))
               } _
            )
        End With

        dt.Rows.Add(New Object() {Nothing, Nothing})

        For Row As Integer = 0 To 8
            If Row.IsEven Then
                dt.Rows.Add(New Object() {True, Now})
            Else
                dt.Rows.Add(New Object() {False, Nothing})
            End If
        Next


        bsJobs.DataSource = dt

        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bsJobs

        AddHandler cmdClose.Click,
        Sub(sender As System.Object, e As System.EventArgs)
            Close()
        End Sub

    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        DataGridView1.Invalidate()
    End Sub
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged

        If DataGridView1.JobAssigned Then
            DataGridView1.JobAssignedDate()
        Else
            DataGridView1.JobAssignedDateToNothing()
        End If

        DataGridView1.CommitJob()

    End Sub
    Private Sub cmdShowTheValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowValues.Click
        'Dim Row As Integer = 0

        'bsJobs.DataTable.AsEnumerable.ToList.ForEach(
        '    Sub(Item)
        '        Console.WriteLine("{0,2} [{1}] [{2}]", Row, Item.Item(0), Item.Item(1))
        '        Row += 1
        '    End Sub)

        Dim MyDataTable = bsJobs.DataTable
        MyDataTable.AsEnumerable.ToList.ForEach(Sub(Item) Console.WriteLine("[{0}] [{1}]", Item("Assign"), Item("DateAssigned")))
    End Sub
End Class
