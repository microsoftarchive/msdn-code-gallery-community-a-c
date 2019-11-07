Public Class ShoppingCartActions

    Public Property ShoppingCartId() As String

    Private ReadOnly _db As New ProductContext()

    Public Const CART_SESSION_KEY As String = "CartId"

    Public Sub AddToCart(ByVal id As Integer)
        ' Retrieve the product from the database.           
        ShoppingCartId = GetCartId()

        Dim cartItem = _db.ShoppingCartItems.SingleOrDefault(Function(c) c.CartId = ShoppingCartId AndAlso c.ProductId = id)
        If cartItem Is Nothing Then
            ' Create a new cart item if no cart item exists.                 
            cartItem = New CartItem() With { _
                .ItemId = Guid.NewGuid().ToString(), _
                .ProductId = id, _
                .CartId = ShoppingCartId, _
                .Product = _db.Products.SingleOrDefault(Function(p) p.ProductID = id), _
                .Quantity = 1, _
                .DateCreated = DateTime.Now _
            }

            _db.ShoppingCartItems.Add(cartItem)
        Else
            ' If the item does exist in the cart,                  
            ' then add one to the quantity.                 
            cartItem.Quantity += 1
        End If
        _db.SaveChanges()
    End Sub

    Public Function GetCartId() As String
        If HttpContext.Current.Session(CART_SESSION_KEY) Is Nothing Then
            If Not String.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name) Then
                HttpContext.Current.Session(CART_SESSION_KEY) = HttpContext.Current.User.Identity.Name
            Else
                ' Generate a new random GUID using System.Guid class.     
                Dim tempCartId As Guid = Guid.NewGuid()
                HttpContext.Current.Session(CART_SESSION_KEY) = tempCartId.ToString()
            End If
        End If
        Return HttpContext.Current.Session(CART_SESSION_KEY).ToString()
    End Function

    Public Function GetCartItems() As List(Of CartItem)
        ShoppingCartId = GetCartId()

        Return _db.ShoppingCartItems.Where(Function(c) c.CartId = ShoppingCartId).ToList()
    End Function

    Public Function GetTotal() As Decimal
        ShoppingCartId = GetCartId()
        ' Multiply product price by quantity of that product to get        
        ' the current price for each of those products in the cart.  
        ' Sum all product price totals to get the cart total.   
        Dim total As Nullable(Of Decimal)
        total = CType((From cartItems In _db.ShoppingCartItems Where cartItems.CartId = ShoppingCartId Select CType(cartItems.Quantity, Nullable(Of Integer)) * cartItems.Product.UnitPrice).Sum(), Nullable(Of Decimal))
        Return If(total, Decimal.Zero)
    End Function

    Public Function GetCart(ByVal context As HttpContext) As ShoppingCartActions
        Dim cart = New ShoppingCartActions()
        cart.ShoppingCartId = cart.GetCartId()
        Return cart
    End Function

    Public Sub UpdateShoppingCartDatabase(ByVal cartId As String, ByVal cartItemUpdates As ShoppingCartUpdates())
        Try
            Dim cartItemCount As Integer = cartItemUpdates.Count()
            Dim myCart As List(Of CartItem) = GetCartItems()
            For Each cItem As CartItem In myCart
                ' Iterate through all rows within shopping cart list
                For i As Integer = 0 To cartItemCount - 1
                    If cItem.Product.ProductID = cartItemUpdates(i).ProductId Then
                        If cartItemUpdates(i).PurchaseQuantity < 1 OrElse cartItemUpdates(i).RemoveItem = True Then
                            RemoveItem(cartId, cItem.ProductId)
                        Else
                            UpdateItem(cartId, cItem.ProductId, cartItemUpdates(i).PurchaseQuantity)
                        End If
                    End If
                Next
            Next
        Catch exp As Exception
            Throw New Exception("ERROR: Unable to Update Cart Database - " & exp.Message.ToString(), exp)
        End Try
    End Sub

    Public Sub RemoveItem(ByVal removeCartID As String, ByVal removeProductID As Integer)
        Dim db As New ProductContext()
        Try
            Dim myItem = (From c In db.ShoppingCartItems Where c.CartId = removeCartID AndAlso c.Product.ProductID = removeProductID Select c).FirstOrDefault()
            If myItem IsNot Nothing Then
                db.ShoppingCartItems.Remove(myItem)
                db.SaveChanges()
            End If
        Catch exp As Exception
            Throw New Exception("ERROR: Unable to Remove Cart Item - " & exp.Message.ToString(), exp)
        End Try
    End Sub

    Public Sub UpdateItem(ByVal updateCartID As String, ByVal updateProductID As Integer, ByVal quantity As Integer)
        Dim db As New ProductContext()
        Try
            Dim myItem = (From c In db.ShoppingCartItems Where c.CartId = updateCartID AndAlso c.Product.ProductID = updateProductID Select c).FirstOrDefault()
            If myItem IsNot Nothing Then
                myItem.Quantity = quantity
                db.SaveChanges()
            End If
        Catch exp As Exception
            Throw New Exception("ERROR: Unable to Update Cart Item - " & exp.Message.ToString(), exp)
        End Try
    End Sub

    Public Sub EmptyCart()
        ShoppingCartId = GetCartId()
        Dim cartItems = _db.ShoppingCartItems.Where(Function(c) c.CartId = ShoppingCartId)
        For Each cartItem In cartItems
            _db.ShoppingCartItems.Remove(cartItem)
        Next
        ' Save changes.             
        _db.SaveChanges()
    End Sub

    Public Function GetCount() As Integer
        ShoppingCartId = GetCartId()
        ' Get the count of each item in the cart and sum them up          
        Dim count As Nullable(Of Integer) = (From cartItems In _db.ShoppingCartItems Where cartItems.CartId = ShoppingCartId Select CType(cartItems.Quantity, Nullable(Of Integer))).Sum()
        ' Return 0 if all entries are null         
        Return If(count, 0)
    End Function

    Public Structure ShoppingCartUpdates
        Public ProductId As Integer
        Public PurchaseQuantity As Integer
        Public RemoveItem As Boolean
    End Structure

    Public Sub MigrateCart(ByVal cartId As String, ByVal userName As String)
        Dim shoppingCart = _db.ShoppingCartItems.Where(Function(c) c.CartId = cartId)
        For Each item As CartItem In shoppingCart
            item.CartId = userName
        Next
        HttpContext.Current.Session(CART_SESSION_KEY) = userName
        _db.SaveChanges()
    End Sub

End Class