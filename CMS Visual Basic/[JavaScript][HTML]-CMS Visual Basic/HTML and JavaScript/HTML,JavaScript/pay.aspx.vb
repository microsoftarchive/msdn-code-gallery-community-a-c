Imports WebApplication
'Namespace WebApplication
Partial Class pay
	Inherits System.Web.UI.Page
	Private ServicePaid As String
	Private IdOrder As String
  Private MasterPage As MasterPage
	Private Setting As Config.SubSite

	Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
		Setting = CurrentSetting()
		If Request.Form("item_number") <> "" Then
			Dim Value As String() = Split(Request.Form("item_number"), "|")
			ServicePaid = Value(0)
			IdOrder = Value(1)
		Else
			ServicePaid = Request("service")
			IdOrder = Request("id")
		End If
	End Sub


	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    MasterPage = SetMasterPage(Me, , , False)
    MasterPage.AddMetaTag("robots", "noindex")

    If ServicePaid <> "" Then
      Select Case ServicePaid
        Case "newuserauthentication", "advertising.aspx"
          PayManager.Delivery(ServicePaid, IdOrder)
          Response.End()
          Exit Sub 'Threading.Thread.CurrentThread.Abort()
      End Select
      Confirm.Visible = True
    Else
      DescriptionModalityOfPayment.Controls.Add(New LiteralControl("</form>"))
      Components.AddPageArchived(DescriptionModalityOfPayment, Master, 0, 1, HttpContext.Current, CurrentDomainConfiguration, Setting, , , , False)
      DescriptionModalityOfPayment.Controls.Add(New LiteralControl("<form>"))
    End If
	End Sub

	Protected Sub ConfirmPayment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConfirmPayment.Click
		Dim DatePay As Date
		Try
			DatePay = StringToDate(DateOfPayment.Text)
		Catch ex As Exception
			'error: format not valid
      MasterPage.AddMessage(Setting, 428)
			Exit Sub
		End Try

		If ModalityOfPayment.Text = "" Then
      MasterPage.AddMessage(Setting, 3206)
			Exit Sub
		End If

		Dim FlagKey As String = "Payment" & ServicePaid.ToString & Request("id")
		If Not Session(FlagKey) Is Nothing And IsLocal() = False Then
			'Not double confirmation
      MasterPage.AddMessage(Setting, 418)
			TableDate.Visible = False
		Else
			If PayManager.Delivery(ServicePaid, IdOrder, DateOfPayment.Text, ModalityOfPayment.Text) Then
				'successful
        MasterPage.AddMessage(Setting, 418)
				TableDate.Visible = False
				Session(FlagKey) = True
			Else
				'error
        MasterPage.AddMessage(Setting, 422)
			End If
		End If

	End Sub

End Class
