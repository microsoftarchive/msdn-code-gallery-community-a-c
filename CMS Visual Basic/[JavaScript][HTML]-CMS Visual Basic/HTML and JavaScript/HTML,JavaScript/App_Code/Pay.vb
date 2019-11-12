'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic

Namespace WebApplication
	Public Module PayManager
		Enum TypeOfPaymentSystem
			PayPal
			Moneybookers
		End Enum

		Function RequirePayment(ByVal PaymentSystem As TypeOfPaymentSystem, ByVal Text As String, ByVal PayToAccount As String, ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language) As WebControls.HyperLink
			Select Case PaymentSystem
				Case TypeOfPaymentSystem.PayPal
					Return PayPalRequirePayment(Text, PayToAccount, Currency, Amount, DetailDescription, DetailText, Language)
				Case TypeOfPaymentSystem.Moneybookers
					Return MoneybookersRequirePayment(Text, PayToAccount, Currency, Amount, DetailDescription, DetailText, Language)
			End Select
      Return Nothing
    End Function

		Function RequirePayment(ByVal PaymentSystem As TypeOfPaymentSystem, ByVal Text As String, ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language) As WebControls.HyperLink
			Select Case PaymentSystem
				Case TypeOfPaymentSystem.PayPal
					Return PayPalRequirePayment(Text, AppropriatePayPalAccount(Amount), Currency, Amount, DetailDescription, DetailText, Language)
				Case TypeOfPaymentSystem.Moneybookers
					Return MoneybookersRequirePayment(Text, Setup.PaymentGateway.MoneybookersAccount, Currency, Amount, DetailDescription, DetailText, Language)
			End Select
      Return Nothing
    End Function

		Private Function MoneybookersRequirePayment(ByVal Text As String, ByVal PayToEmail As String, ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language) As WebControls.HyperLink
			Dim Link As New HyperLink
			Link.Text = HttpUtility.HtmlEncode(Text)
			Link.NavigateUrl = MoneybookersRequirePaymentUrl(PayToEmail, Currency, Amount, DetailDescription, DetailText, Language)
			Return Link
		End Function

		Function MoneybookersRequirePaymentUrl(ByVal PayToEmail As String, ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language) As String
			Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
      Return "https://www.moneybookers.com/app/payment.pl?pay_to_Email=" & HttpUtility.UrlEncode(PayToEmail) & "&currency=" & Currency & "&amount=" & HttpUtility.UrlEncode(Amount.ToString(Culture)) & "&detail1_description=" & HttpUtility.UrlEncode(DetailDescription) & "&detail1_text=" & HttpUtility.UrlEncode(DetailText) & "&language=" & LanguageManager.Acronym(Language)
		End Function

		Private Function PayPalRequirePayment(ByVal Text As String, ByVal PayToAccount As String, ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language, Optional ByVal ReturnUrl As String = Nothing) As WebControls.HyperLink
			Dim Link As New HyperLink
			Link.Text = HttpUtility.HtmlEncode(Text)
			Link.NavigateUrl = PayPalRequirePaymentUrl(Currency, Amount, DetailDescription, DetailText, Language, ReturnUrl)
			Return Link
		End Function
		Function PayPalRequirePaymentUrl(ByVal PayToAccount As String, ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language, Optional ByVal ReturnUrl As String = Nothing, Optional ByVal ServiceToPay As String = "nothing", Optional ByVal ID As String = Nothing) As String
      Dim NotifyUrl As String = Nothing
      Dim ItemNumber As String = Nothing
			If ServiceToPay <> "" Then
				ItemNumber = "&item_number=" & HttpUtility.UrlEncode(ServiceToPay & "|" & ID)
				NotifyUrl = PayManager.NotifyUrl(ServiceToPay, ID)
			End If
			Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
			If ReturnUrl <> "" Then
				ReturnUrl = "&return=" & HttpUtility.UrlEncode(ReturnUrl)
			End If
			If NotifyUrl <> "" Then	'For IPN notification
				NotifyUrl = "&notify_url=" & HttpUtility.UrlEncode(NotifyUrl)
			End If
      Dim Lc As String = LanguageManager.Acronym(Language)
      Return "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" & HttpUtility.UrlEncode(PayToAccount) & "&currency_code=" & Currency & "&amount=" & HttpUtility.UrlEncode(Amount.ToString(Culture)) & "&item_name=" & HttpUtility.UrlEncode(DetailDescription) & IfStr(DetailText <> "", ": ", "") & HttpUtility.UrlEncode(DetailText) & "&lc=" & Lc & ReturnUrl & NotifyUrl & ItemNumber & "&button_subtype=services&no_note=1&no_shipping=1&bn=PP%2dBuyNowBF%3abtn_buynowCC_LG%2egif%3aNonHosted&charset=utf-8"
		End Function

		Function PayPalRequirePaymentUrl(ByVal Currency As String, ByVal Amount As Double, ByVal DetailDescription As String, ByVal DetailText As String, ByVal Language As LanguageManager.Language, Optional ByVal ReturnUrl As String = Nothing, Optional ByVal ServiceToPay As String = Nothing, Optional ByVal ID As String = Nothing) As String
			Return PayPalRequirePaymentUrl(AppropriatePayPalAccount(Amount), Currency, Amount, DetailDescription, DetailText, Language, ReturnUrl, ServiceToPay, ID)
		End Function

		Function AppropriatePayPalAccount(ByVal Amount As Double) As String
			If Amount <= 10 AndAlso Setup.PaymentGateway.PayPalAccountMicropayments <> "" Then
				Return Setup.PaymentGateway.PayPalAccountMicropayments
			Else
				Return Setup.PaymentGateway.PayPalAccount
			End If
		End Function

		Function NotifyUrl(ByVal Plugin As String, ByVal ID As String) As String
			'Return PathCurrentUrl() & "pay.aspx?ss=" & CurrentSetting.Name & "&service=" & Service & "&id=" & HttpUtility.UrlEncode(ID)
			Return PathCurrentUrl() & "ipn.aspx?service=" & Plugin & "&id=" & HttpUtility.UrlEncode(ID)
		End Function

		Function PayPalVerify() As Boolean
			'Post back to either sandbox or live
			Dim PayPalWebScr As String = "https://www.paypal.com/cgi-bin/webscr"
			Dim req As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(PayPalWebScr), System.Net.HttpWebRequest)

			'Set values for the request back
			req.Method = "POST"
			req.ContentType = "application/x-www-form-urlencoded"
			Dim Param() As Byte = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.ContentLength)
			Dim strRequest As String = Encoding.ASCII.GetString(Param)
			strRequest = strRequest + "&cmd=_notify-validate"
			req.ContentLength = strRequest.Length

			'for proxy
			'Dim proxy As New WebProxy(New System.Uri("http://url:port#"))
			'req.Proxy = proxy

			'Send the request to PayPal and get the response
			Dim streamOut As System.IO.StreamWriter = New System.IO.StreamWriter(req.GetRequestStream(), Encoding.ASCII)
			streamOut.Write(strRequest)
			streamOut.Close()
			Dim streamIn As System.IO.StreamReader = New System.IO.StreamReader(req.GetResponse().GetResponseStream())
			Dim strResponse As String = streamIn.ReadToEnd()
			streamIn.Close()

			If strResponse = "VERIFIED" Then
				'check the payment_status is Completed
				'check that txn_id has not been previously processed
				'check that receiver_Email is your Primary PayPal Email
				'check that payment_amount/payment_currency are correct
				'process payment
				Return True
			ElseIf strResponse = "INVALID" Then
				'log for manual investigation
			Else
				'Response wasn't VERIFIED or INVALID, log for manual investigation
			End If
      Return False
    End Function

		Public Function Delivery(ByVal Plugin As String, ByVal IdOrder As String, Optional ByVal DateOfPayment As String = Nothing, Optional ByVal ModalityOfPayment As String = Nothing) As Boolean

      Extension.Log("DeliveryPayment", 1000, IdOrder, Plugin, DateOfPayment, ModalityOfPayment)
      Dim Request As System.Web.HttpRequest = HttpContext.Current.Request
      Dim EmailToVerify As String = Request("Email") 'Filtre not autorized user to confirm payment
      If Plugin <> "" Then
        Dim PluginObject As PluginManager.Plugin = GetPlugin(Plugin)
        If PluginObject IsNot Nothing Then
          PluginObject.RaiseDelivery(IdOrder, EmailToVerify, Delivery)
          Return Delivery
        End If
      Else
        Try
          If PayPalVerify() Then
            If StrComp(Request.Form("payment_status"), "Completed", CompareMethod.Text) = 0 Then
              If LCase(Request.Form("receiver_Email")) = LCase(Setup.PaymentGateway.PayPalAccount) OrElse LCase(Request.Form("receiver_Email")) = LCase(Setup.PaymentGateway.PayPalAccountMicropayments) OrElse Request.Form("receiver_id") = Setup.PaymentGateway.PayPalAccount OrElse Request.Form("receiver_id") = Setup.PaymentGateway.PayPalAccountMicropayments Then
                Select Case Plugin
                  Case "newuserauthentication"
                    Dim User As User = User.Load(IdOrder)
                    If User.GeneralRole = Authentication.User.RoleType.User Then
                      User.GeneralRole = Authentication.User.RoleType.Senior
                      User.Attribute("FirstName") = Request.Form("first_name")
                      User.Attribute("LastName") = Request.Form("last_name")
                      User.Save()
                      Extension.Log("AuthenticationUser", 1000, User.Username, Request.Form("first_name"), Request.Form("last_name"), Request.Form("payer_Email"), Request.Form("address_zip"), Request.Form("residence_country"))
                      Return True
                    Else
                      Extension.Log("PaymentError", 1000, Plugin, IdOrder, User.GeneralRole.ToString & " RoleType<>1")
                    End If
                  Case Else
                    PluginManager.RaiseIpnEvent(Plugin, IdOrder, Request)
                End Select
              Else
                Extension.Log("PaymentError", 1000, Plugin, IdOrder, "PayPalVerify Spoof detect")
              End If
            Else
              Extension.Log("PaymentError", 1000, Plugin, IdOrder, "payment_status=" & Request.Form("payment_status"))
            End If
          Else
            Extension.Log("PaymentError", 1000, Plugin, IdOrder, "PayPalVerify")
          End If
        Catch ex As Exception
          Extension.Log("PaymentError", 1000, Plugin, IdOrder, ex.Message, ex.Source, ex.StackTrace)
        End Try
      End If
      Return False
    End Function

	End Module
End Namespace