Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Function Index(persona As Persona) As ActionResult
            Return View(persona)
        End Function
    End Class
End Namespace