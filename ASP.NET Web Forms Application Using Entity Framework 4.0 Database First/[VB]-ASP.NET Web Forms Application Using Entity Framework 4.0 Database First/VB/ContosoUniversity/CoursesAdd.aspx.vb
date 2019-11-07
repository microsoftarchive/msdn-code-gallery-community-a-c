Public Class CoursesAdd
    Inherits System.Web.UI.Page

    Private departmentDropDownList As DropDownList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DepartmentsDropDownList_Init(ByVal sender As Object, ByVal e As EventArgs)
        departmentDropDownList = CType(sender, DropDownList)
    End Sub

    Protected Sub CoursesDetailsView_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs) Handles CoursesDetailsView.ItemInserting
        Dim departmentID = Convert.ToInt32(departmentDropDownList.SelectedValue)
        e.Values("DepartmentID") = departmentID
    End Sub

End Class