Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Function Index(persona As Persona) As ViewResult
            Return View(persona)
        End Function

        Function Resource(persona As PersonaResource) As ViewResult
            Return View("Index", persona)
        End Function

        Function BBDD(persona As PersonaBBDD) As ViewResult
            Return View("Index", persona)
        End Function

        Function CustomAttr(persona As PersonaCustomAttr) As ViewResult
            Return View("Index", persona)
        End Function

    End Class
End Namespace