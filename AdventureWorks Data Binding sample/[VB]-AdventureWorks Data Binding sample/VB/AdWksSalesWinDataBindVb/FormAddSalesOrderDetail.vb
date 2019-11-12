Public Class FormAddSalesOrderDetail
    Dim currentOrder As SalesOrderHeader
    Dim parentCxt As AdventureWorksEntities
    Dim newSalesOrderDetail As SalesOrderDetail
    Dim selectedProduct As Product

    Public Sub New(ByVal ctx As AdventureWorksEntities, ByVal order As SalesOrderHeader)
        InitializeComponent()

        parentCxt = ctx
        currentOrder = order
    End Sub

    Private Sub buttonCancelOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonCancelOrder.Click
        Me.Dispose()
    End Sub


    Private Sub FormAddSalesOrderDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If currentOrder Is Nothing Then _
            Throw New ApplicationException("A valid SalesOrderHeader must be supplied")
        Try
            'Get the list of products
            Dim products = parentCxt.Product _
                .Where("it.FinishedGoodsFlag == true AND it.DiscontinuedDate IS NULL")

            'Bind to the query execution.
            productsBindingSource.DataSource = products.Execute(Objects.MergeOption.NoTracking)

            'Create a new Sales Order Detail instance and bind to the data source.
            newSalesOrderDetail = SalesOrderDetail.CreateSalesOrderDetail(currentOrder.SalesOrderID, 9999, 1, 0, 1, 0, 0, 0, Guid.NewGuid, Now)
            salesOrderDetailBindingSource.DataSource = newSalesOrderDetail

            buttonAddNewDetail.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub buttonAddNewDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonAddNewDetail.Click
        Try

            'Add the detail to the details for the current order.
            currentOrder.SalesOrderDetail.Add(newSalesOrderDetail)

            'update the order totals.
            currentOrder.UpdateOrderTotal()
        Catch ex As Exception
            MsgBox("Msg: " & ex.Message.ToString & ControlChars.CrLf & _
                            "Inner Exception: " & ex.InnerException.ToString)
        End Try

    End Sub

    Private Sub dataGridViewProducts_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridViewProducts.CellClick
        buttonAddNewDetail.Enabled = True

        'Get the selected product from the grid.
        selectedProduct = DirectCast(productsBindingSource.Current, Product)

        'Ensure that the product isn't already in the order.
        For Each item In currentOrder.SalesOrderDetail
            If selectedProduct.ProductID = item.ProductID Then
                MsgBox(String.Format("The order already contains the item {0}.{1}" & _
                                              "Please update the quantity of the existing item.", _
                                              selectedProduct.Name, ControlChars.CrLf))
                Exit Sub
            End If
        Next

        'Set the properties on the new detail.
        newSalesOrderDetail.ProductID = selectedProduct.ProductID
        newSalesOrderDetail.UnitPrice = selectedProduct.StandardCost
    End Sub
End Class