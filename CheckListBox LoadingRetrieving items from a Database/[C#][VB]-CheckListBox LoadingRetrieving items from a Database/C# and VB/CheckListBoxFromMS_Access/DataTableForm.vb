Public Class frmDataTable
    Private BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = IO.Path.Combine(Application.StartupPath, "Database1.accdb")
        }
    WithEvents dt As New DataTable With {.TableName = "MyTable"}

    Private Sub frmDataTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckedListBox1.Items.AddRange(New String() {"John", "Paul", "George", "Ringo"})

        CheckedListBox1.SetItemChecked(1, True)
        CheckedListBox1.SetItemChecked(3, True)

        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier",
                                            .DataType = GetType(Int32),
                                            .AutoIncrement = True,
                                            .AutoIncrementStep = 100,
                                            .AutoIncrementSeed = 100})

        dt.Columns.Add(New DataColumn With {.ColumnName = "ItemName",
                                            .DataType = GetType(String)})

        dt.Columns.Add(New DataColumn With {.ColumnName = "ExtraData",
                                            .DataType = GetType(String)})


        dt.Rows.Add(New Object() {Nothing, "One", "Extra 1"})
        dt.Rows.Add(New Object() {Nothing, "Two", "Extra 2"})
        dt.Rows.Add(New Object() {Nothing, "Three", "Extra 3"})
        dt.Rows.Add(New Object() {Nothing, "Four", "Extra 4"})
        dt.Rows.Add(New Object() {Nothing, "Five", "Extra 5"})

        clbCheckedListBox.DataSource = dt
        clbCheckedListBox.DisplayMember = "ItemName"

    End Sub
    Private Sub cmdGetChecked_Click(sender As Object, e As EventArgs) Handles cmdGetChecked.Click
        If clbCheckedListBox.CheckedItems.Count > 0 Then
            Dim Successfull As Integer = 0
            Dim Failed As Integer = 0

            Using cn As New OleDb.OleDbConnection With {.ConnectionString = BuilderAccdb.ConnectionString}
                Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                    cmd.CommandText = "INSERT INTO Table1 (Identifier,ItemName,ExtraData) VALUES (@Identifier,@ItemName,@ExtraData)"
                    cmd.Parameters.Add(New OleDb.OleDbParameter With {.ParameterName = "@Identifier", .DbType = DbType.Int32})
                    cmd.Parameters.Add(New OleDb.OleDbParameter With {.ParameterName = "@ItemName", .DbType = DbType.String})
                    cmd.Parameters.Add(New OleDb.OleDbParameter With {.ParameterName = "@ExtraData", .DbType = DbType.String})
                    cn.Open()

                    Dim Affected As Int32

                    For Each drv As DataRowView In clbCheckedListBox.CheckedItems
                        cmd.Parameters("@Identifier").Value = drv.Row.Field(Of Int32)("Identifier")
                        cmd.Parameters("@ItemName").Value = drv.Row.Field(Of String)("ItemName")
                        cmd.Parameters("@ExtraData").Value = drv.Row.Field(Of String)("ExtraData")
                        Affected = cmd.ExecuteNonQuery
                        If Affected <> 1 Then
                            Failed += 1
                        Else
                            Successfull += 1
                        End If
                    Next
                End Using
            End Using
            MessageBox.Show(String.Format("Success: {0} Failed: {1}", Successfull, Failed))
        End If
    End Sub

    ''' <summary>
    ''' The following was to answer a question on Microsoft forumns
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Exit Sub
        Console.WriteLine(String.Join(",", CType(clbCheckedListBox.SelectedItem, DataRowView).Row.ItemArray))
        Console.WriteLine(clbCheckedListBox.GetItemChecked(clbCheckedListBox.SelectedIndex))
        CType(clbCheckedListBox.SelectedItem, DataRowView).Row.SetField(Of String)("ItemName", "New value")
        CType(clbCheckedListBox.DataSource, DataTable).Rows.Remove(CType(clbCheckedListBox.SelectedItem, DataRowView).Row)
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim Result =
            (
                From T In dt.AsEnumerable _
                .Select(Function(item, index) _
                            New With
                            {
                                .Item = item,
                                .Index = index
                            }
                        )
                Where T.Item.Field(Of String)("ItemName").ToLower = TextBox1.Text.ToLower
            ).FirstOrDefault

        If Result IsNot Nothing Then
            Dim Current As Boolean = Not clbCheckedListBox.GetItemChecked(Result.Index)
            clbCheckedListBox.SetItemChecked(Result.Index, Current)
        Else
            MessageBox.Show("Item not located")
        End If



    End Sub
    ''' <summary>
    ''' This code shows a language extension method.
    ''' Step 1, write the code here
    ''' Step 2, copy code to a sub or function and comment it out here
    ''' Step 3, tweak code in above and create extension method
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDemo_Click(sender As Object, e As EventArgs) Handles cmdDemo.Click
        'Dim Test = (From this In CheckedListBox1.Items.Cast(Of String)().Select(Function(item, index) New With {.Item = item, .Index = index}) Where this.Item.ToLower = TextBox1.Text.ToLower).FirstOrDefault
        'If Test IsNot Nothing Then
        '    Dim Current As Boolean = Not CheckedListBox1.GetItemChecked(Test.Index)
        '    CheckedListBox1.SetItemChecked(Test.Index, Current)
        'End If

        CheckedListBox1.FindItemAndSetChecked(txtDemoExt.Text, chkState.Checked)
    End Sub


End Class