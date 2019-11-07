Public Class CheckoutReview
    Inherits Page

    Protected Sub Page_Load()
        If Not IsPostBack Then
            Dim payPalCaller As New NVPAPICaller()

            Dim retMsg As String = ""
            Dim token As String = Session("token").ToString()
            Dim payerID As String = ""
            Dim decoder As New nvpCodec()

            Dim ret As Boolean = payPalCaller.GetCheckoutDetails(token, payerID, decoder, retMsg)
            If ret Then
                Session("payerId") = payerID

                Dim myOrder = New Order()
                myOrder.OrderDate = Convert.ToDateTime(decoder("TIMESTAMP").ToString())
                myOrder.Username = User.Identity.Name
                myOrder.FirstName = decoder("FIRSTNAME").ToString()
                myOrder.LastName = decoder("LASTNAME").ToString()
                myOrder.Address = decoder("SHIPTOSTREET").ToString()
                myOrder.City = decoder("SHIPTOCITY").ToString()
                myOrder.State = decoder("SHIPTOSTATE").ToString()
                myOrder.PostalCode = decoder("SHIPTOZIP").ToString()
                myOrder.Country = decoder("SHIPTOCOUNTRYCODE").ToString()
                myOrder.Email = decoder("EMAIL").ToString()
                myOrder.Total = Convert.ToDecimal(decoder("AMT").ToString())

                ' Verify total payment amount as set on CheckoutStart.aspx.
                Try
                    Dim paymentAmountOnCheckout As Decimal = Convert.ToDecimal(Session("payment_amt").ToString())
                    Dim paymentAmoutFromPayPal As Decimal = Convert.ToDecimal(decoder("AMT").ToString())
                    If paymentAmountOnCheckout <> paymentAmoutFromPayPal Then
                        Response.Redirect("CheckoutError.aspx?" & "Desc=Amount%20total%20mismatch.")
                    End If
                Catch ex As Exception
                    Response.Redirect("CheckoutError.aspx?" & "Desc=Amount%20total%20mismatch.")
                End Try

                ' Get DB context.
                Dim db As New ProductContext()

                ' Add order to DB.
                db.Orders.Add(myOrder)
                db.SaveChanges()

                ' Get the shopping cart items.
                Dim usersShoppingCart As New ShoppingCartActions()
                Dim myOrderList As List(Of CartItem) = usersShoppingCart.GetCartItems()

                ' Add OrderDetail information to the DB for each product purchased.
                For i As Integer = 0 To myOrderList.Count - 1
                    ' Create a new OrderDetail object.
                    Dim myOrderDetail = New OrderDetail()
                    myOrderDetail.OrderId = myOrder.OrderId
                    myOrderDetail.Username = User.Identity.Name
                    myOrderDetail.ProductId = myOrderList(i).ProductId
                    myOrderDetail.Quantity = myOrderList(i).Quantity
                    myOrderDetail.UnitPrice = myOrderList(i).Product.UnitPrice

                    ' Add OrderDetail to DB.
                    db.OrderDetails.Add(myOrderDetail)
                    db.SaveChanges()
                Next

                ' Set OrderId.
                Session("currentOrderId") = myOrder.OrderId

                ' Display Order information.
                Dim orderList As New List(Of Order)()
                orderList.Add(myOrder)
                ShipInfo.DataSource = orderList
                ShipInfo.DataBind()

                ' Display OrderDetails.
                OrderItemList.DataSource = myOrderList
                OrderItemList.DataBind()
            Else
                Response.Redirect("CheckoutError.aspx?" & retMsg)
            End If
        End If
    End Sub

    Protected Sub CheckoutConfirm_Click(sender As Object, e As EventArgs)
        Session("userCheckoutCompleted") = "true"
        Response.Redirect("~/Checkout/CheckoutComplete.aspx")
    End Sub

End Class