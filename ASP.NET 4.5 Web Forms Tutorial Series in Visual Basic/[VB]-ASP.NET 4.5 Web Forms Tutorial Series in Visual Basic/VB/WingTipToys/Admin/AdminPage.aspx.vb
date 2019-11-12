Public Class AdminPage
    Inherits Page

    Protected Sub Page_Load()
        Dim productAction As String = Request.QueryString("ProductAction")
        If productAction = "add" Then
            LabelAddStatus.Text = "Product added!"
        End If

        If productAction = "remove" Then
            LabelRemoveStatus.Text = "Product removed!"
        End If
    End Sub

    Protected Sub AddProductButton_Click()
        Dim fileOk As Boolean = False
        Dim path As String = Server.MapPath("~/Catalog/Images/")
        If ProductImage.HasFile Then
            Dim fileExtension As String = IO.Path.GetExtension(ProductImage.FileName).ToLower()
            Dim allowedExtensions As String() = {".gif", ".png", ".jpeg", ".jpg"}
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileOk = True
                End If
            Next
        End If

        If fileOk Then
            Try
                ' Save to Images folder.
                ProductImage.PostedFile.SaveAs(path + ProductImage.FileName)
                ' Save to Images/Thumbs folder.
                ProductImage.PostedFile.SaveAs((path & "Thumbs/") + ProductImage.FileName)
            Catch ex As Exception
                LabelAddStatus.Text = ex.Message
            End Try

            ' Add product data to DB.
            Dim products As New AddProducts()
            Dim addSuccess As Boolean = products.AddProduct(AddProductName.Text, AddProductDescription.Text, AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName)
            If addSuccess Then
                ' Reload the page.
                Dim pageUrl As String = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count())
                Response.Redirect(pageUrl & "?ProductAction=add")
            Else
                LabelAddStatus.Text = "Unable to add new product to database."
            End If
        Else
            LabelAddStatus.Text = "Unable to accept file type."
        End If
    End Sub

    Public Function GetCategories() As IQueryable(Of Category)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Category) = db.Categories
        Return query
    End Function

    Public Function GetProducts() As IQueryable(Of Product)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Product) = db.Products
        Return query
    End Function

    Protected Sub RemoveProductButton_Click()
        Dim db = New ProductContext()
        Dim productId As Integer = Convert.ToInt16(DropDownRemoveProduct.SelectedValue)
        Dim myItem = (From c In db.Products Where c.ProductID = productId Select c).FirstOrDefault()
        If myItem IsNot Nothing Then
            db.Products.Remove(myItem)
            db.SaveChanges()

            ' Reload the page.
            Dim pageUrl As String = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count())
            Response.Redirect(pageUrl & "?ProductAction=remove")
        Else
            LabelRemoveStatus.Text = "Unable to locate product."
        End If
    End Sub

End Class