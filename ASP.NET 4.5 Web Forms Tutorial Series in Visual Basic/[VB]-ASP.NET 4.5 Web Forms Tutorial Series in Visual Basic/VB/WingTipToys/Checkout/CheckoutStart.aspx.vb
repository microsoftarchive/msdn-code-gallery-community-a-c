Public Class CheckoutStart
    Inherits Page

    Protected Sub Page_Load()
        Dim payPalCaller As New NVPAPICaller()
        Dim retMsg As String = ""
        Dim token As String = ""

        If Session("payment_amt") IsNot Nothing Then
            Dim amt As String = Session("payment_amt").ToString()

            Dim ret As Boolean = payPalCaller.ShortcutExpressCheckout(amt, token, retMsg)
            If ret Then
                Session("token") = token
                Response.Redirect(retMsg)
            Else
                Response.Redirect("CheckoutError.aspx?" & retMsg)
            End If
        Else
            Response.Redirect("CheckoutError.aspx?ErrorCode=AmtMissing")
        End If
    End Sub

End Class