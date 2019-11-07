Imports System.Web.Mvc
Imports System.Web.Routing

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Function Index() As String
            Dim result As String = "Action: Index<br/>"
            result += "<b>RouteData</b><br/>"
            For Each key As String In RouteData.Values.Keys
                result += String.Format("{0}: {1}<br/>", key, RouteData.Values(key))
            Next
            result += "<b>QueryString</b><br/>"
            For Each key As String In Request.QueryString.AllKeys
                result += String.Format("{0}: {1}<br/>", key, Request.QueryString(key))
            Next
            Return result
        End Function

        Function Redirect() As RedirectToRouteResult
            Dim routeData As RouteValueDictionary = New RouteValueDictionary()
            For Each key As String In Request.QueryString.AllKeys
                routeData.Add(key, Request.QueryString(key))
            Next
            Return RedirectToAction("Index", routeData)
        End Function

        <PropagarQueryString>
        Function RedirectQueryString() As RedirectToRouteResult
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace