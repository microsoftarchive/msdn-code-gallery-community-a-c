Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Alumni
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub AlumniGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles AlumniGridView.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim alumnus = TryCast(e.Row.DataItem, Alumnus)
            Dim donationsGridView = CType(e.Row.FindControl("DonationsGridView"), GridView)
            donationsGridView.DataSource = alumnus.Donations.ToList()
            donationsGridView.DataBind()
        End If
    End Sub
End Class
