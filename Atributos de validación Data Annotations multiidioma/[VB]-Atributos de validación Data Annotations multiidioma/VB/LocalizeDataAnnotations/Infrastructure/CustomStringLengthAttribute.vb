Imports System.ComponentModel.DataAnnotations

Public Class CustomStringLengthAttribute
    Inherits StringLengthAttribute

    Public Sub New(maximumLength As Integer)
        MyBase.New(maximumLength)
    End Sub

    Public Overrides Function FormatErrorMessage(name As String) As String
        Dim errorMessage As String = Nothing
        If (Not String.IsNullOrEmpty(MyBase.ErrorMessageResourceName)) Then
            errorMessage = TextosBBDD.Recuperar(MyBase.ErrorMessageResourceName)
        End If
        Return If(errorMessage, MyBase.FormatErrorMessage(name))
    End Function

End Class
