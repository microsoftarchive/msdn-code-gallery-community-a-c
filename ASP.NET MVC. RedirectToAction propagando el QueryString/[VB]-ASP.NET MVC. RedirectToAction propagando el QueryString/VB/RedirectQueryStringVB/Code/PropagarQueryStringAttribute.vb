Imports System.Web.Mvc

Public Class PropagarQueryStringAttribute
    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuted(filterContext As ActionExecutedContext)
        Dim redirectResult As RedirectToRouteResult = filterContext.Result
        If (redirectResult IsNot Nothing) Then
            Dim query As NameValueCollection = filterContext.HttpContext.Request.QueryString
            For Each key As String In query.Keys
                If (Not redirectResult.RouteValues.ContainsKey(key)) Then
                    redirectResult.RouteValues.Add(key, query(key))
                End If
            Next
        End If
        MyBase.OnActionExecuted(filterContext)
    End Sub

End Class
