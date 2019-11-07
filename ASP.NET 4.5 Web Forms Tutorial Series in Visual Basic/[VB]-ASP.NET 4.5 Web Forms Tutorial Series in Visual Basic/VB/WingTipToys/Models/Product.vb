Imports System.ComponentModel.DataAnnotations

Public Class Product

    <ScaffoldColumn(False)> _
    Public Property ProductID() As Integer

    <Required, StringLength(100), Display(Name:="Name")> _
    Public Property ProductName() As String

    <Required, StringLength(10000), Display(Name:="Product Description"), DataType(DataType.MultilineText)> _
    Public Property Description() As String

    Public Property ImagePath() As String

    <Display(Name:="Price")> _
    Public Property UnitPrice() As Nullable(Of Double)

    Public Property CategoryID() As Nullable(Of Integer)

    Public Overridable Property Category() As Category

End Class