Imports System.ComponentModel.DataAnnotations

Public Class CustomRequiredAttribute
    Inherits RequiredAttribute

    Public Overrides Function FormatErrorMessage(name As String) As String
        Dim errorMessage As String = Nothing
        If (Not String.IsNullOrEmpty(MyBase.ErrorMessageResourceName)) Then
            errorMessage = TextosBBDD.Recuperar(MyBase.ErrorMessageResourceName)
        End If
        Return If(errorMessage, MyBase.FormatErrorMessage(name))
    End Function

End Class
