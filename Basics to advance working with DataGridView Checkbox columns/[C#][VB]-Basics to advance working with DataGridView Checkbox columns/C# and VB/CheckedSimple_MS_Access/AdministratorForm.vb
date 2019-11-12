Public Class frmAdministrator
    WithEvents bsData As New BindingSource

    Private Sub AdministratorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
            {
                .Provider = "Microsoft.ACE.OLEDB.12.0",
                .DataSource = IO.Path.Combine(Application.StartupPath, "Demo.accdb")
            }

        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText =
                    <SQL>
                        SELECT UserName, UserPassword, IsAdmin
                        FROM Users
                    </SQL>.Value
                }

                cn.Open()
                dt.Load(cmd.ExecuteReader)
            End Using
        End Using

        bsData.DataSource = dt
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bsData

    End Sub
End Class