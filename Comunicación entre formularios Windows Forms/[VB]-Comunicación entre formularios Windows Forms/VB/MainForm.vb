Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGridView1.Rows.Add("Darth", "Vader", True)
        dataGridView1.Rows.Add("Luke", "Skywalker", False)
        dataGridView1.Rows.Add("Leia", "Organa", True)
        dataGridView1.Rows.Add("Han", "Solo", False)
        dataGridView1.Rows.Add("Obi-Wan", "Kenobi", True)
        dataGridView1.Rows.Add("Wilhuff", "Tarkin", False)
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        Dim grid = CType(sender, DataGridView)
        If grid.Columns(e.ColumnIndex).Name <> "EditColumn" Then
            Return
        End If

        Dim rowToEdit = grid.Rows(e.RowIndex)
        Dim dialog = New DialogForm() With
        {
            .CurrentPerson = New Person() With
            {
                .Name = rowToEdit.Cells("NameColumn").Value,
                .Surname = rowToEdit.Cells("SurnameColumn").Value,
                .Active = rowToEdit.Cells("ActiveColumn").Value
            } 
        }

        If dialog.ShowDialog() = DialogResult.OK Then
            rowToEdit.Cells("NameColumn").Value = dialog.CurrentPerson.Name
            rowToEdit.Cells("SurnameColumn").Value = dialog.CurrentPerson.Surname
            rowToEdit.Cells("ActiveColumn").Value = dialog.CurrentPerson.Active
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dialog = New DialogForm()
        If dialog.ShowDialog() = DialogResult.OK Then
            dataGridView1.Rows.Add(
                dialog.CurrentPerson.Name,
                dialog.CurrentPerson.Surname,
                dialog.CurrentPerson.Active
            )
        End If
    End Sub

End Class
