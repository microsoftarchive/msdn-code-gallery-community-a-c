
Partial Public Class SalesOrderHeader
    Public Sub UpdateOrderTotal()
        Dim newSubTotal As Decimal

        'In a real world application this information should be included in the EDM.
        Dim taxRate As Decimal = My.Settings.currentSalesTaxRate
        Dim freight As Decimal = My.Settings.currentFreight

        'If the items for this order are loaded or if the order is
        'newly added, then recalculate the subtotal as it may have changed.
        If SalesOrderDetail.IsLoaded OrElse EntityState = Data.EntityState.Added Then
            For Each item In SalesOrderDetail
                'Calculate line totals for loaded items
                newSubTotal += item.LineTotal
            Next
            SubTotal = newSubTotal
        End If

        'Calculate the new tax amount
        TaxAmt = SubTotal * taxRate

        'calculate the new total
        TotalDue = SubTotal + TaxAmt + freight
    End Sub
End Class

Partial Public Class SalesOrderDetail
    Public Sub UpdateLineTotal()
        LineTotal = OrderQty * (UnitPrice * (1 - UnitPriceDiscount))

        If SalesOrderHeader IsNot Nothing Then
            'Ensure that we update the totals in the related order.
            SalesOrderHeader.UpdateOrderTotal()
        End If
    End Sub

    Private Sub OnOrderQtyChanging(ByVal value As Short)
        'validate the supplied value
        If value < 1 Then
            Throw New ApplicationException("An order must be 1 or more items.")
        End If
    End Sub

    Private Sub OnOrderQtyChanged()
        'Update the line total to reflect the new quantity
        UpdateLineTotal()
    End Sub

    Private Sub OnUnitPriceDiscountChanging(ByVal value As Decimal)
        'Validate the supplied value
        If value < 0 OrElse value > 1 Then
            Throw New ApplicationException("Discount rate is between 0 and 1.")
        End If
    End Sub

    Private Sub OnUnitPriceDiscountChanged()
        'Update the line total to reflect the new discount
        UpdateLineTotal()
    End Sub
End Class
