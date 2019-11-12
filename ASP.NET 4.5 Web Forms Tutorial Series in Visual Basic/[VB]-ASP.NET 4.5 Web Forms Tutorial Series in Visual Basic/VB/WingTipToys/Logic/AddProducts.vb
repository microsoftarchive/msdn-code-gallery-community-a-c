Public Class AddProducts

    Public Function AddProduct(productName As String, productDesc As String, productPrice As String, productCategory As String, productImagePath As String) As Boolean
        Dim myProduct = New Product()
        myProduct.ProductName = productName
        myProduct.Description = productDesc
        myProduct.UnitPrice = Convert.ToDouble(productPrice)
        myProduct.ImagePath = ProductImagePath
        myProduct.CategoryID = Convert.ToInt32(productCategory)

        ' Get DB context.
        Dim db As New ProductContext()

        ' Add product to DB.
        db.Products.Add(myProduct)
        db.SaveChanges()

        ' Success.
        Return True
    End Function

End Class