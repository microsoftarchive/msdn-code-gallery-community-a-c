Public Class frmCheckListBoxFormDemo
    Private BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = IO.Path.Combine(Application.StartupPath, "Database1.accdb")
        }
    Private Sub LoadMe(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        clbCheckedListBox.SuspendLayout()

        Dim dt As New DataTable

        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText =
                    <SQL>
                        SELECT 
                            Identifier, 
                            ItemIndex, 
                            Item, 
                            CheckedStatus 
                        FROM 
                            Items
                    </SQL>.Value
                }

                cn.Open()
                dt.Load(cmd.ExecuteReader)

            End Using
        End Using

        Dim LastIndex As Integer = 0

        Try
            For Each row As DataRow In dt.Rows

                clbCheckedListBox.Items.Add(row.Field(Of String)("Item"))
                LastIndex = clbCheckedListBox.Items.Count - 1

                If row.Field(Of Boolean)("CheckedStatus") Then
                    clbCheckedListBox.SetItemChecked(LastIndex, True)
                End If

            Next

            ActiveControl = clbCheckedListBox
            clbCheckedListBox.SelectedIndex = 0
        Finally
            clbCheckedListBox.ResumeLayout()
        End Try

    End Sub
    Private Sub CheckListBoxFormDemo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not chkSaveOnFormClose.Checked Then
            Exit Sub
        End If

        Dim Affected As Int32 = 0
        Dim ErrorCount As Int32 = 0

        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText =
                    <SQL>
                        UPDATE Items 
                        SET ItemIndex = @ItemIndex, 
                            CheckedStatus = @CheckedStatus 
                        WHERE ItemIndex=@ItemIndexValue
                    </SQL>.Value
                }

                cmd.Parameters.Add(New OleDb.OleDbParameter With
                    {
                        .ParameterName = "@ItemIndex",
                        .DbType = DbType.Int32
                    }
                )
                cmd.Parameters.Add(New OleDb.OleDbParameter With
                    {
                        .ParameterName = "@CheckedStatus ",
                        .DbType = DbType.Boolean
                    }
                )
                cmd.Parameters.Add(New OleDb.OleDbParameter With
                    {
                        .ParameterName = "@ItemIndexValue",
                        .DbType = DbType.Int32
                    }
                )

                cn.Open()

                For Index As Int32 = 0 To (clbCheckedListBox.Items.Count - 1)

                    cmd.Parameters(0).Value = Index

                    If clbCheckedListBox.GetItemChecked(Index) Then
                        cmd.Parameters(1).Value = True
                    Else
                        cmd.Parameters(1).Value = False
                    End If

                    cmd.Parameters(2).Value = Index

                    Try
                        '
                        ' Good form to check if the query actually worked
                        '
                        Affected = cmd.ExecuteNonQuery

                        If Affected <> 1 Then
                            ErrorCount += 1
                        End If

                    Catch ex As Exception
                        ErrorCount += 1
                    End Try
                Next
            End Using
        End Using

        If ErrorCount > 0 Then
            MessageBox.Show("Failed to update items in database.")
        End If

    End Sub

    'Private Sub clbCheckedListBox_MouseClick(sender As Object, e As MouseEventArgs) Handles clbCheckedListBox.MouseClick
    '    If (e.Button = MouseButtons.Left) And (e.X > 13) Then
    '        clbCheckedListBox.SetItemChecked(clbCheckedListBox.SelectedIndex,
    '                                         (Not clbCheckedListBox.GetItemChecked(clbCheckedListBox.SelectedIndex)))
    '    End If
    'End Sub

    'Private Sub clbCheckedListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles clbCheckedListBox.MouseDoubleClick
    '    If (e.Button = MouseButtons.Left) And (e.X > 13) Then
    '        clbCheckedListBox.SetItemChecked(clbCheckedListBox.SelectedIndex,
    '                                         (Not clbCheckedListBox.GetItemChecked(clbCheckedListBox.SelectedIndex)))
    '    End If
    'End Sub

    Private Sub clbCheckedListBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbCheckedListBox.SelectedValueChanged
        If clbCheckedListBox.GetItemChecked(clbCheckedListBox.SelectedIndex) Then
            lblCurrentCheckedState.Text = "Current item is checked"
        Else
            lblCurrentCheckedState.Text = "Current item is not checked"
        End If
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub

End Class