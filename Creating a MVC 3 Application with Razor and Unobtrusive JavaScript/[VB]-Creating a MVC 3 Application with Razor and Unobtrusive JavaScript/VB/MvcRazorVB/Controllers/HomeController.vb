Public Class HomeController
    Inherits System.Web.Mvc.Controller

    ' The __usrs class is replacement for a real data access strategy.
    Private Shared _usrs As New Users()

    Function Index() As ActionResult
    	Return View(_usrs._usrList)
    End Function

    Public Function Details(ByVal id As String) As ViewResult
        Return View(_usrs.GetUser(id))
    End Function

    Public Function Edit(ByVal id As String) As ViewResult
        Return View(_usrs.GetUser(id))
    End Function

    <HttpPost()>
    Public Function Edit(ByVal um As UserModel) As ViewResult

        If Not TryUpdateModel(um) Then
            ViewBag.updateError = "Update Failure"
            Return View(um)
        End If

        ' ToDo: add persistent to DB.
        _usrs.Update(um)
        Return View("Details", um)
    End Function

    Public Function About() As ActionResult
        Return View()
    End Function

    Public Function Create() As ViewResult
        Return View(New UserModel())
    End Function

    <HttpPost()>
    Public Function Create(ByVal um As UserModel) As ViewResult

        If Not TryUpdateModel(um) Then
            ViewBag.updateError = "Create Failure"
            Return View(um)
        End If

        ' ToDo: add persistent to DB.
        _usrs.Create(um)
        Return View("Details", um)
    End Function

    Public Function Delete(ByVal id As String) As ViewResult
        Return View(_usrs.GetUser(id))
    End Function

    <HttpPost()>
    Public Function Delete(ByVal id As String, ByVal collection As FormCollection) As RedirectToRouteResult
        _usrs.Remove(id)
        Return RedirectToAction("Index")
    End Function

End Class
