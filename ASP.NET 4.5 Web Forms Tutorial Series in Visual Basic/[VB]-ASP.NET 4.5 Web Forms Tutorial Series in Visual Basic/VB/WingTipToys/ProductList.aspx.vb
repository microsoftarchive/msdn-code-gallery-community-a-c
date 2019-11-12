Imports System.Web.ModelBinding

Public Class ProductList
    Inherits Page

    Protected Sub Page_Load() Handles Me.Load

    End Sub

    Public Function GetProducts(<QueryString("id")> categoryId As Nullable(Of Integer), <RouteData> categoryName As String) As IQueryable(Of Product)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Product) = db.Products

        If categoryId.HasValue AndAlso categoryId > 0 Then
            query = query.Where(CType(Function(p) p.CategoryID = categoryId, Func(Of Product, Boolean)))
        End If

        If Not String.IsNullOrEmpty(categoryName) Then
            query = query.Where(Function(p) String.Compare(p.Category.CategoryName, categoryName) = 0)
        End If

        Return query
    End Function

End Class