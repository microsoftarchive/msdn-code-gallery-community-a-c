Imports System.ComponentModel.DataAnnotations

Public Class CartItem

    <Key> _
    Public Property ItemId() As String
        
    Public Property CartId() As String

    Public Property Quantity() As Integer

    Public Property DateCreated() As DateTime

    Public Property ProductId() As Integer
        
    Public Overridable Property Product() As Product

End Class