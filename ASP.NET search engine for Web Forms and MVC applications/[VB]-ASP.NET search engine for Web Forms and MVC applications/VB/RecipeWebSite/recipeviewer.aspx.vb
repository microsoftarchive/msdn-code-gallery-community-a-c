Public Partial Class receipeviewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        XmlDataSource1.XPath = "Recipes/Recipe[@id='" & Request.Params("id") & "']"
    End Sub

End Class