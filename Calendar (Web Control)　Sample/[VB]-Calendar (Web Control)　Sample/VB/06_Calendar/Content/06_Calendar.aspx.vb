Public Class _06_Calendar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged

        Label1.Text = ""

        Dim day As DateTime

        For Each day In Calendar1.SelectedDates
            Label1.Text &= day.Date.ToShortDateString() & "<br />"
        Next

    End Sub
End Class