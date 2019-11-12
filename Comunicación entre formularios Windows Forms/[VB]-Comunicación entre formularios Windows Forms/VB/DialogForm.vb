Public Class DialogForm

    Friend Property CurrentPerson As Person
        Get
            Return New Person() With
            {
                .Name=txtName.Text,
                .Surname=txtSurname.Text,
                .Active=chkActive.Checked
            }
        End Get
        Set
            txtName.Text = If(Value Is Nothing, String.Empty, Value.Name)
            txtSurname.Text = If(Value Is Nothing, String.Empty, Value.Surname)
            chkActive.Checked = Value IsNot Nothing AndAlso value.Active
        End Set
    End Property

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

End Class