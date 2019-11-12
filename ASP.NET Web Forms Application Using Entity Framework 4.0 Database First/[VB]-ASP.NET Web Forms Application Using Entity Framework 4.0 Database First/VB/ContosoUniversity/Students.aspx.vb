Public Class Students
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        StudentsGridView.EnableDynamicData(GetType(Student))
        SearchGridView.EnableDynamicData(GetType(Student))
    End Sub

End Class