Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class UpdateCredits
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub ExecuteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExecuteButton.Click
        Using context As New SchoolEntities()
            RowsAffectedLabel.Text = context.ExecuteStoreCommand("UPDATE Course SET Credits = Credits * {0}", CreditsMultiplierTextBox.Text).ToString()
        End Using
    End Sub
End Class
