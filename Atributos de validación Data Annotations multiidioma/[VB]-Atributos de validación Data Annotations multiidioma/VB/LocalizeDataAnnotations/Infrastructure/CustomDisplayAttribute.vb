Imports System.ComponentModel

Public Class CustomDisplayAttribute
    Inherits DisplayNameAttribute

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(displayName As String)
        MyBase.New(displayName)
    End Sub

    Public Overrides ReadOnly Property DisplayName As String
        Get
            Dim name As String = TextosBBDD.Recuperar(MyBase.DisplayName)
            Return If(name, MyBase.DisplayName)
        End Get
    End Property

End Class
