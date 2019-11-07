Imports System.ComponentModel.DataAnnotations

Public Class Category

    <ScaffoldColumn(False)> _
    Public Property CategoryID() As Integer

    <Required, StringLength(100), Display(Name:="Name")> _
    Public Property CategoryName() As String

    <Display(Name:="Product Description")> _
    Public Property Description() As String

    Public Overridable Property Products() As ICollection(Of Product)

End Class