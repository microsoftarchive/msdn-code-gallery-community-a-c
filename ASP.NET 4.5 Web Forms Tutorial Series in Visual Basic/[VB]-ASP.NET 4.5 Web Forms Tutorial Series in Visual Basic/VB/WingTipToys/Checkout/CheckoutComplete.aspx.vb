Public Class CheckoutComplete
    Inherits Page

    Protected Sub Page_Load()
        If Not IsPostBack Then
            ' Verify user has completed the checkout process.
            If Session("userCheckoutCompleted") <> True Then
                Session("userCheckoutCompleted") = String.Empty
                Response.Redirect("CheckoutError.aspx?" & "Desc=Unvalidated%20Checkout.")
            End If

            Dim payPalCaller As New NVPAPICaller()

            Dim retMsg As String = String.Empty
            Dim decoder As New nvpCodec()

            Dim token As String = Session("token").ToString()
            Dim payerID As String = Session("payerId").ToString()
            Dim finalPaymentAmount As String = Session("payment_amt").ToString()

            Dim ret As Boolean = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, payerID, decoder, retMsg)
            If ret Then
                ' Retrieve PayPal confirmation value.
                Dim paymentConfirmation As String = decoder("PAYMENTINFO_0_TRANSACTIONID").ToString()
                TransactionId.Text = paymentConfirmation

                Dim db As New ProductContext()
                ' Get the current order id.
                Dim currentOrderId As Integer = -1
                If Not String.IsNullOrEmpty(Session("currentOrderId")) Then
                    currentOrderId = Convert.ToInt32(Session("currentOrderID"))
                End If
                Dim myCurrentOrder As Order
                If currentOrderId >= 0 Then
                    ' Get the order based on order id.
                    myCurrentOrder = db.Orders.[Single](Function(o) o.OrderId = currentOrderId)
                    ' Update the order to reflect payment has been completed.
                    myCurrentOrder.PaymentTransactionId = paymentConfirmation
                    ' Save to DB.
                    db.SaveChanges()
                End If

                ' Clear shopping cart.
                Dim usersShoppingCart As New ShoppingCartActions()
                usersShoppingCart.EmptyCart()

                ' Clear order id.
                Session("currentOrderId") = String.Empty
            Else
                Response.Redirect("CheckoutError.aspx?" & retMsg)
            End If
        End If
    End Sub

    Protected Sub Continue_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Default.aspx")
    End Sub

End Class