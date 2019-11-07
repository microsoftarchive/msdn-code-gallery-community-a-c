Imports System.Data.Entity

Public Class ProductContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("WingtipToys")
    End Sub

    Public Property Categories() As DbSet(Of Category)
        
    Public Property Products() As DbSet(Of Product)
        
    Public Property ShoppingCartItems() As DbSet(Of CartItem)
        
    Public Property Orders() As DbSet(Of Order)
        
    Public Property OrderDetails() As DbSet(Of OrderDetail)
        
End Class