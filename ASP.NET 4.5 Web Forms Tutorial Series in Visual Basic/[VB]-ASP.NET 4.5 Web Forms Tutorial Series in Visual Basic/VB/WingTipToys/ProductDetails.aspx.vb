Imports System.Web.ModelBinding

Public Class ProductDetails
    Inherits Page

    Protected Sub Page_Load() Handles Me.Load

    End Sub

    Public Function GetProduct(<QueryString("ProductID")> productId As Nullable(Of Integer), <RouteData> productName As String) As IQueryable(Of Product)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Product) = db.Products
        If productId.HasValue AndAlso productId > 0 Then
            query = query.Where(CType(Function(p) p.ProductID = productId, Func(Of Product, Boolean)))
        ElseIf Not String.IsNullOrEmpty(productName) Then
            query = query.Where(Function(p) String.Compare(p.ProductName, productName) = 0)
        Else
            query = Nothing
        End If
        Return query
    End Function

End Class