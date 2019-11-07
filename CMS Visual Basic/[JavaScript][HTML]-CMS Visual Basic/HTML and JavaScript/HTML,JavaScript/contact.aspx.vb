Imports WebApplication

Partial Class contact
	Inherits System.Web.UI.Page
	Private Setting As SubSite

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Setting = CurrentSetting()
	End Sub

	Protected Sub contact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim MasterPage As MasterPage = SetMasterPage(Me, , False, True)
		AddPhoneContact()
		AddLogo(Setting.Skin)
		If Not Page.IsPostBack Then
			'Add name
			If CurrentUser.GeneralRole <> Authentication.User.RoleType.Visitors Then
				FromName.Text = CurrentUser.FirstName
				If FromName.Text <> "" And CurrentUser.LastName <> "" Then
					FromName.Text &= " "
				End If
				FromName.Text &= CurrentUser.LastName
				FromEmail.Text = CurrentUser.Email
			End If
		End If
	End Sub
	Sub AddPhoneContact()
		Dim Table As New HtmlTable
		Dim Row As New HtmlTableRow
		Table.Controls.Add(Row)
		For Each Service As Configuration.ContactsConfiguration.Service In [Enum].GetValues(GetType(Configuration.ContactsConfiguration.Service))
			If Service <> Configuration.ContactsConfiguration.Service.General Then
				Dim PhoneContact1 As Configuration.ContactsConfiguration.PhoneContact = Setting.PhoneContact(Service)
				If Not PhoneContact1 Is Nothing Then
					Dim Cell As New HtmlTableCell
					Row.Controls.Add(Cell)
					Cell.Controls.Add(PhoneNumber(PhoneContact1, Setting.Language, Setting.Skin))
				End If
			End If
		Next
		If Row.Controls.Count Then
			PhoneContact.Controls.Add(Table)
		End If
	End Sub
  Sub AddLogo(ByVal Skin As Config.Skin)
    If Not Skin Is Nothing Then
      Dim S1 As New WebControls.WebControl(HtmlTextWriterTag.Span)
      Dim S2 As New WebControls.WebControl(HtmlTextWriterTag.Span)
      S1.Controls.Add(Icon(IconType.Help, Skin))
      S2.Controls.Add(Icon(IconType.TechSupport, Skin))

      S1.Attributes.Add("vertical-align", "middle")
      S2.Attributes.Add("vertical-align", "middle")

      L1.Controls.Add(S1)
      L2.Controls.Add(S2)
    End If
  End Sub


	Protected Sub contact_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
		Session("TimePageLoaded") = Now
	End Sub

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim MasterPage As MasterPage = Page.Master
    If Page.IsValid Then
      Dim PageLoaded As Date = Session("TimePageLoaded")
      Dim IsAutoRobot As Boolean = DateDiff(DateInterval.Second, PageLoaded, Now) < 10
      Session("TimePageLoaded") = Now
      If IsAutoRobot Then
        MasterPage.AddMessage(Phrase(Setting.Language, 422, 3245), Setting)
      Else
        'Anti seo spam filter
        If InStr(MailText.Text, "seo", CompareMethod.Text) <> 0 OrElse InStr(MailText.Text, "Search Engine Optimization", CompareMethod.Text) <> 0 OrElse InStr(MailText.Text, "first page of Google", CompareMethod.Text) <> 0 OrElse InStr(MailText.Text, "RANKING", CompareMethod.Text) <> 0 OrElse InStr(MailText.Text, "PAGE GOOGLE", CompareMethod.Text) <> 0 Then
          Response.Redirect("http://www.google.com/search?q=SPAM+SEO")
          'Response.Redirect("http://www.appraisalwebdomain.com/")
        End If
        Table1.Visible = False
        'Send Mail
        Dim Ctrl As New Control
        Dim Table As HtmlTable = Components.Table(7, 2)
        'Email
        Table.Rows(0).Cells(0).Controls.Add(Components.Literal(Phrase(Setting.Language, 12)))
        Table.Rows(0).Cells(1).Controls.Add(Components.Literal(FromEmail.Text))
        'Name
        Table.Rows(1).Cells(0).Controls.Add(Components.Literal(Phrase(Setting.Language, 417)))
        Table.Rows(1).Cells(1).Controls.Add(Components.Literal(FromName.Text))
        'Username
        Table.Rows(2).Cells(0).Controls.Add(Components.Literal(Phrase(Setting.Language, 9)))
        Table.Rows(2).Cells(1).Controls.Add(Components.Literal(CurrentUser.Username))
        'IP
        Table.Rows(3).Cells(0).Controls.Add(Components.Literal(Phrase(Setting.Language, 416)))
        Table.Rows(3).Cells(1).Controls.Add(Components.Literal(Page.Request.UserHostAddress))
        'To
        Table.Rows(4).Cells(0).Controls.Add(Components.Literal(Phrase(Setting.Language, 3181)))
        'Domain Name
        Table.Rows(5).Cells(0).Controls.Add(Components.Literal(Phrase(Setting.Language, 3175)))
        Table.Rows(5).Cells(1).Controls.Add(Components.Literal(Page.Request.UserHostName))
        'Subsite
        Table.Rows(6).Cells(0).Controls.Add(Components.Literal("Subsite"))
        Table.Rows(6).Cells(1).Controls.Add(Components.Literal(Setting.Name))


        Ctrl.Controls.Add(Table)
        Ctrl.Controls.Add(Components.Literal(System.Web.HttpUtility.HtmlEncode(MailText.Text)))
        Dim Destination As String

        If To_Staff.Checked Then
          'Contact operator
          Table.Rows(4).Cells(1).Controls.Add(Components.Literal(Phrase(Setting.Language, 3184)))
          Destination = Setting.Email.Email
        Else
          'Contact technical support
          Table.Rows(4).Cells(1).Controls.Add(Components.Literal(Phrase(Setting.Language, 3185)))
          Destination = Config.Setup.Email.EmailSupervisor.Email
        End If
        SendEmail(MailSubject.Text, ControlToText(Ctrl), Destination, , True, True, , FromEmail.Text)
        MasterPage.AddMessage(Setting, 418)


        '================================================
        'Rimuovere questa linea per la distribuzione
        '================================================
        'If PayPalAccountIsSetting() And Setting.Language = LanguageManager.Language.Italian Then
        'Response.Redirect(PayManager.PayPalRequirePaymentUrl("EUR", "0.9", "Supporto", "Servizio di assistenza via E-mail fornito a " & FromName.Text, LanguageManager.Language.Italian))
        'End If


      End If

    Else
      MasterPage.AddMessage(Setting, 404)
    End If
	End Sub
End Class
