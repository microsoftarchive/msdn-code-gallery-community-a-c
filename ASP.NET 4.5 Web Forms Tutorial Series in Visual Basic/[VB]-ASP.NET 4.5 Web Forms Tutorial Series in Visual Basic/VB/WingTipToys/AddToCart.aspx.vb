Public Class AddToCart
    Inherits Page

    Private Sub AddToCart_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rawId As String = Request.QueryString("ProductID")
        Dim productId As Integer

        If Not String.IsNullOrEmpty(rawId) AndAlso Integer.TryParse(rawId, productId) Then
            Dim usersShoppingCart As New ShoppingCartActions()
            usersShoppingCart.AddToCart(Convert.ToInt16(rawId))
        Else
            Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.")
            Throw New Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.")
        End If

        Response.Redirect("ShoppingCart.aspx")
    End Sub

End Class