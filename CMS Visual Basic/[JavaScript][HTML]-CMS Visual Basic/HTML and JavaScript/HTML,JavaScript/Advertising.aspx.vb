'This is a plugin for selling text links from your siteThis is a plugin for selling text links from your site
'By Andrea Bruno
Imports WebApplication
Partial Class Advertising
	Inherits System.Web.UI.Page
	Private Setting As SubSite
  Private MasterPage As MasterPage
  Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
	Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , False, False, Plugin.Characteristics.StandardPlugin)
		Return Plugin
	End Function

	Shared Sub New()
		Initialize()
	End Sub

	Shared Startup As Boolean = AdvertisingStartup()

	Protected Shared Sub Plugin_Ipn(ByVal IdOrder As String, ByVal Request As System.Web.HttpRequest) Handles Plugin.Ipn
		ActivationTextualLink(IdOrder)
	End Sub

  Protected Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
    'Advertising
    If MasterPage.ShowRightBar Then
      If EnableSellTextLinks(MasterPage.Setting) Then
        Dim AdvertisingAdd As New HyperLink
        AdvertisingAdd.Text = Phrase(MasterPage.Setting.Language, 2013)
        AdvertisingAdd.NavigateUrl = Common.Href(MasterPage.Setting.Name, False, "advertising.aspx")
        AdvertisingAdd.Style.Add("font-weight", "bold")
        MasterPage.Right.Controls.Add(AdvertisingAdd)
        MasterPage.Right.Controls.Add(BR)
      End If
      Dim Links As Control = LinksControl()
      If Links.Controls.Count Then
        MasterPage.Right.Controls.Add(Links)
        MasterPage.Right.Controls.Add(BR)
      End If
    End If
  End Sub

	Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
		If ShortDescription Then
      Return Phrase(Language, 2013)
		Else
      Return Phrase(Language, 2013)
		End If
  End Function

  Protected Sub Advertising_Init(sender As Object, e As EventArgs) Handles Me.Init
    Setting = CurrentSetting()
    MasterPage = SetMasterPage(Me, , False, False)
    MasterPage.TitleDocument = Phrase(Setting.Language, 2010)
    MasterPage.Description = Phrase(Setting.Language, 2013)
    MasterPage.KeyWords = Phrase(Setting.Language, 2013)
  End Sub

  Sub Confirmation()
    Dim Total As Double
    Dim NDays As Integer = Val(Days.Text)
    Dim Domains As New ArrayList
    Dim TextDomains As String = Nothing
    For Each DomainName As String In AllDomainNames()
      Dim Domain As DomainConfiguration = DomainConfiguration.Load(DomainName)

      If Domain.Redirect = "" Then
        If LCase(Page.Request.Form(DomainName)) = "on" Then
          Dim PricePartial As Double = DailyLinkValue(DomainName) * NDays
          Total += PricePartial
          Domains.Add(DomainName)
          If TextDomains <> "" Then
            TextDomains &= " "
          End If
          TextDomains &= DomainName
        End If
      End If
    Next
    If TotalPrice.Value = Total Then
      'goto pay
      Dim TextualLink As New TextualLink
      TextualLink.CustomerLanguage = Setting.Language
      TextualLink.OrderFrom = PathCurrentUrl()
      TextualLink.Days = Days.Text
      TextualLink.FirstName = FirstName.Text
      TextualLink.LastName = LastName.Text
      TextualLink.Email = Email.Text
      TextualLink.Text = Text.Text
      TextualLink.Link = Link.Text
      TextualLink.Cost = Total
      TextualLink.Domains = Domains
      TextualLink.Save()
      TextualLink.ID = SaveObject(TextualLink, , True)

      Dim Subject As String = Phrase(Setting.Language, 2013) & " " & TextDomains
      Dim PayUrl As String = PayManager.PayPalRequirePaymentUrl("EUR", Total, Phrase(Setting.Language, 2010), Subject, Setting.Language, PathCurrentUrl, Plugin.Name, TextualLink.ID.ToString)

      'Send Email for payment as activation
      Dim ActivationLink As New HyperLink
      ActivationLink.Text = Phrase(Setting.Language, 2017)
      ActivationLink.NavigateUrl = PayUrl
      SendEmail(Subject, ControlToText(ActivationLink), Email.Text, , True)
      Response.Redirect(PayUrl)
    Else
      MasterPage.AddMessage(Setting, 422, , Common.Href(MasterPage.Setting.Name, False, "contact.aspx"), MessageType.ErrorAlert)
    End If
  End Sub

	Sub OrderDetail()
		If TotalPrice.Value <> "" Then
			Confirmation()
    End If

    FirstName.Attributes.Add("readonly", "readonly")
    LastName.Attributes.Add("readonly", "readonly")
    Email.Attributes.Add("readonly", "readonly")
    Text.Attributes.Add("readonly", "readonly")
    Days.Attributes.Add("readonly", "readonly")
    Link.Attributes.Add("readonly", "readonly")

		Dim Table As New HtmlTable
		Dim TitleRow As HtmlTableRow = Components.HeaderRow(2, HorizontalAlign.Center)
		Table.Controls.Add(TitleRow)

		AddLabel(TitleRow.Cells(0), Days.Text & " " & Phrase(Setting.Language, 2014))	'X Dais
		AddLabel(TitleRow.Cells(1), Phrase(Setting.Language, 125)) 'Domain name '

		Dim NDays As Integer = Val(Days.Text)
		Dim Total As Double
		For Each DomainName As String In AllDomainNames()
			Dim Domain As DomainConfiguration = DomainConfiguration.Load(DomainName)
			If Domain.Redirect = "" Then
				If LCase(Page.Request.Form(DomainName)) = "on" Then
					Dim Row As HtmlTableRow = Components.Row(2, HorizontalAlign.Left)

					Table.Controls.Add(Row)

					Dim Hide As New WebControls.HiddenField
					Hide.ID = DomainName
					Hide.Value = "on"
					Dim CheckLiteral As New Literal
					CheckLiteral.Text = ControlToText(Hide)
					Row.Cells(0).Controls.Add(CheckLiteral)

					Dim Price As New Label
					Dim PricePartial As Double = DailyLinkValue(DomainName) * NDays
					Total += PricePartial
					Price.Text = PricePartial.ToString(Setting.Culture) & " €"
					Row.Cells(0).Controls.Add(Price)

					Dim Name As New HyperLink
					Name.Text = DomainName
					Name.NavigateUrl = "http://" & DomainName
					Name.Target = "_blank"
					Row.Cells(1).Controls.Add(Name)
				End If
			End If
		Next
    Dim LastRow As HtmlTableRow = Components.Row(2, HorizontalAlign.Left)
		Dim Tot As New Label
		Tot.Text = Phrase(Setting.Language, 2021) & " " & Total.ToString(Setting.Culture) & " €"
		Tot.Style.Add("font-weight", "bold")
    LastRow.Cells(0).Controls.Add(Tot)
		Table.Controls.Add(LastRow)

		PlaceHolder1.Controls.Add(Table)
		TotalPrice.Value = Total
	End Sub

	Sub InputOrder()

		If Not Page.IsPostBack Then
			Dim Div As New WebControls.WebControl(HtmlTextWriterTag.Div)
			Div.Style.Add("text-align", "left")
      Components.AddPageArchived(Div, Master, 0, 7, HttpContext.Current, CurrentDomainConfiguration, Setting)
      MasterPage.ContentPlaceHolder.Controls.AddAt(0, Div)
      MasterPage.ContentPlaceHolder.Controls.AddAt(0, BR)
    End If

		Dim SelectTable As New HtmlTable
		Dim TitleRow As HtmlTableRow = Components.HeaderRow(5, HorizontalAlign.Center)
		SelectTable.Controls.Add(TitleRow)
		AddLabel(TitleRow.Controls(0), Phrase(Setting.Language, 56))	'Add
		AddLabel(TitleRow.Controls(1), Phrase(Setting.Language, 2011))	'DailiRate
		AddLabel(TitleRow.Controls(2), "PageRank")
		AddLabel(TitleRow.Controls(3), Phrase(Setting.Language, 125))	'Domain name '
		AddLabel(TitleRow.Controls(4), Phrase(Setting.Language, 3026))	'Web site
		For Each DomainName As String In AllDomainNames()
			Dim Domain As DomainConfiguration = DomainConfiguration.Load(DomainName)
			Dim Enabled As Boolean
			Enabled = False
			For Each Setting As String In Domain.SubSitesAvailable
				If Plugin.IsEnabled(Config.SubSite.Load(Setting)) Then
					Enabled = True
					Exit For
				End If
			Next
			If Domain.Redirect = "" AndAlso Enabled Then
				Dim DailyValue As Double = DailyLinkValue(DomainName)
				If DailyValue <> 0 Then
					Dim Row As HtmlTableRow = Components.Row(5, HorizontalAlign.Left)
					SelectTable.Controls.Add(Row)

					Dim Check As New WebControls.CheckBox
					Check.ID = DomainName
					If DomainName = CurrentDomainConfiguration.Name Then
						Check.Checked = True
					End If
					If LCase(Page.Request.Form(DomainName)) = "on" Then
						Check.Checked = True
					End If

					Dim CheckLiteral As New Literal
					CheckLiteral.Text = ControlToText(Check)
					Row.Cells(0).Controls.Add(CheckLiteral)

					Dim DailiPrice As New Label
					DailiPrice.Text = DailyValue.ToString(Setting.Culture) & " €"
					Row.Cells(1).Controls.Add(DailiPrice)

					Dim PageRank As New Label
					PageRank.Text = "<a href=""http://linkdr.net/pagerank"" target=""linkdr""><img src=""http://linkdr.net/cgi-bin/pr.cgi?url=" & DomainName & "&style="" alt=""PageRank Checker"" border=""0""></a>"
					Row.Cells(2).Controls.Add(PageRank)

					Dim Name As New HyperLink
					Name.Text = DomainName
					Name.NavigateUrl = "http://" & DomainName
					Name.Target = "_blank"
					Row.Cells(3).Controls.Add(Name)
					For Each SubSite As SubSite In Domain.SubSites
            Dim Flag As HtmlImage = Components.Flag(SubSite.Language)
						Flag.Style.Add("padding-right", "20px")
						Row.Cells(4).Controls.Add(Flag)
						Dim Title As New Label
						Title.Text = SubSite.Title
						Row.Cells(4).Controls.Add(Title)
					Next
				End If
			End If
		Next
		PlaceHolder1.Controls.Add(SelectTable)

	End Sub

	Function IsSelected() As Boolean
		For Each DomainName As String In AllDomainNames()
			Dim Domain As DomainConfiguration = DomainConfiguration.Load(DomainName)
			If Domain.Redirect = "" Then
				If LCase(Page.Request.Form(DomainName)) = "on" Then
					Return True
				End If
			End If
		Next
    Return False
  End Function

	Function LinkVerify(ByVal Url As String) As Boolean
    Return Not SiteIsCensored(Url, Setting, MasterPage)
  End Function


	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    If Page.IsPostBack Then
      Dim IsErr As Boolean
      If Not LinkVerify(Link.Text) Then
        IsErr = True
      End If
      If Not IsSelected() Then
        MasterPage.AddMessage(Setting, 3001, , , MessageType.ErrorAlert)
        IsErr = True
      End If
      If Not IsValid Then
        MasterPage.AddMessage(Setting, 404, , , MessageType.ErrorAlert)
        IsErr = True
      End If
      If IsErr Then
        InputOrder()
      Else
        OrderDetail()
      End If
    Else
      If CurrentUser.GeneralRole <> Authentication.User.RoleType.Visitors Then
        FirstName.Text = CurrentUser.FirstName
        LastName.Text = CurrentUser.LastName
        Email.Text = CurrentUser.Email
      End If
      Link.Text = "http://"
      Days.Text = RangeValidator1.MaximumValue
      MaxDays.Text = " (<" & RangeValidator1.MaximumValue & ")"
      InputOrder()
    End If
  End Sub

	Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
		'Do not remove this empty Sub
	End Sub
End Class

Module AdvertisingManager
	Function EnableSellTextLinks(ByVal Setting As SubSite) As Boolean
    If PluginManager.IsEnabled(Setting, "advertising.aspx") AndAlso PayPalAccountIsSetting() AndAlso Setup.PaymentGateway.EnabledOnlinePayment Then
      Return True
    End If
    Return False
  End Function
	Class TextualLink
		Public ID As Integer
		Public Created As Date = Now.ToUniversalTime
		Public Activation As Date
		Public Days As Integer
		Public Domains As ArrayList
		Function Domain(ByVal DomainName As String) As Boolean
			Return Domains.Contains(DomainName)
		End Function
		Function IsActivated() As Boolean
			Return Activation <> Date.MinValue
		End Function
		Function IsExpired() As Boolean
			Return Now.ToUniversalTime > Activation.AddDays(Days)
		End Function
		Public Text As String
		Public Link As String
		Public FirstName As String
		Public LastName As String
		Public CustomerLanguage As LanguageManager.Language
		Public OrderFrom As String
		Public Email As String
		Public Cost As Double
		Shared Function Load(ByVal ID As Integer) As TextualLink
      Return CType(LoadObject(GetType(TextualLink), ID), TextualLink)
    End Function
    Sub Save()
      SaveObject(Me, Me.ID, True)
    End Sub
  End Class

  Sub ActivationTextualLink(ByVal ID As Integer)
    Dim Order As TextualLink
    Order = TextualLink.Load(ID)
    If Order IsNot Nothing AndAlso Not Order.IsActivated Then
      Order.Activation = Now.ToUniversalTime
      Order.Save()
      TextualLinkActive.Add(Order)
    End If
  End Sub

  Private TextualLinkActive As New Collections.Generic.List(Of TextualLink)

  Function AdvertisingStartup() As Boolean
    LoadTaxtualLinkSaved()
    For Each DomainName As String In AllDomainNames()
      Dim Domain As DomainConfiguration = DomainConfiguration.Load(DomainName)
      If Domain.Redirect = "" Then
        DailyLinkValue(DomainName)
      End If
    Next
    Return True
  End Function
  Function DailyLinkValue(ByVal DomainName As String) As Double
    Try
      If HttpContext.Current.Request.IsLocal Then
        Return 0.05
      End If
    Catch ex As Exception
    End Try
    Static SyncLockObj As New Object
    Static Collection As New Collections.Specialized.StringDictionary

    SyncLock SyncLockObj
      Dim TraficRank As Long, ValueLink As Double
      If Collection(DomainName) <> Nothing Then
        Return Collection(DomainName)
      Else
        Try
          TraficRank = AlexaTrafficRank(DomainName)
          If TraficRank <> 0 Then
            '      ValueLink = (500000000 / (TraficRank + 4) ^ 1.3)
            ValueLink = (1000000 / (TraficRank + 4))
          End If
          ValueLink = ValueLink + 0.05
          ValueLink = Math.Round(ValueLink, 2)
          Collection.Add(DomainName, ValueLink)
          Return ValueLink
        Catch ex As Exception

        End Try
      End If
    End SyncLock
    Return 0.0
  End Function

  Private Sub LoadTaxtualLinkSaved()
    Dim Keys As String() = AllKeyObject(GetType(TextualLink))
    If Keys IsNot Nothing Then
      For n As Integer = 0 To Keys.Length - 1
        Dim TextualLink As TextualLink = LoadObject(GetType(TextualLink), Keys(n))
        If TextualLink Is Nothing Then
          DeleteObject(GetType(TextualLink), Keys(n))
        Else
          'Add recent and delete old order from archive
          If TextualLink.IsActivated Then
            If TextualLink.IsExpired Then
              'Send Email of renew and delete old order
              SendEmailRenew(TextualLink)
              DeleteObject(GetType(TextualLink), Keys(n))
            Else
              'Fix redirect
              For Id As Integer = 0 To TextualLink.Domains.Count - 1
                Dim Domain As String = TextualLink.Domains(Id)
                Dim Configuration As DomainConfiguration = DomainConfiguration.Load(Domain)
                If Configuration.Redirect <> "" Then
                  TextualLink.Domains(n) = Configuration.Redirect
                End If
              Next

              TextualLinkActive.Add(TextualLink)
            End If
          Else
            'Delete old order never actived
            If TextualLink.Created < Now.ToUniversalTime.AddDays(-15) Then
              'Send Email
              SendEmailRenew(TextualLink)
              'Delete old
              DeleteObject(GetType(TextualLink), Keys(n))
            End If
          End If
        End If
      Next
    End If
  End Sub

	Sub SendEmailRenew(ByVal Order As TextualLink)
		If PayPalAccountIsSetting() AndAlso Setup.PaymentGateway.EnabledOnlinePayment Then
			Dim Body As New Control
			Body.Controls.Add(Components.Literal(System.Web.HttpUtility.HtmlEncode(Phrase(Order.CustomerLanguage, 3257) & " " & Order.FirstName & " " & Order.LastName)))
			Body.Controls.Add(BR)
			Body.Controls.Add(Components.Literal(System.Web.HttpUtility.HtmlEncode(Phrase(Order.CustomerLanguage, 141) & ".")))
			Body.Controls.Add(BR)
			Dim Link As New HyperLink
			Link.Text = Phrase(Order.CustomerLanguage, 2020)
			Link.NavigateUrl = Order.OrderFrom & "advertising.aspx"
			Body.Controls.Add(Link)
			Dim Subject As String = Phrase(Order.CustomerLanguage, 2013)
			For Each Domain As String In Order.Domains
				Subject &= " " & Domain
			Next
      SendEmail(Subject, ControlToText(Body), Order.Email, , True)
		End If
	End Sub

	Function LinksControl() As Control
		Static ObSync As New Object
		SyncLock ObSync
			Dim CurrentDomain As String = Common.CurrentDomain
			Dim Links As New Control
			Dim RemoveExpired As Boolean
			For Each TextualLink As TextualLink In TextualLinkActive
				If TextualLink.IsExpired Then
					RemoveExpired = True
				Else
					For Each Domain As String In TextualLink.Domains
						If Domain = CurrentDomain Then
							Dim Link As New HyperLink
							Link.Text = HttpUtility.HtmlEncode(TextualLink.Text)
							Link.NavigateUrl = TextualLink.Link
							Link.Target = "_blank"
							Links.Controls.Add(Link)
							Links.Controls.Add(BR)
							Exit For
						End If
					Next
				End If
			Next
			If RemoveExpired Then
				AdvertisingManager.RemoveExpired()
			End If
			Return Links
		End SyncLock
	End Function


	Private Sub RemoveExpired()
		For Each TextualLink As TextualLink In TextualLinkActive
			If TextualLink.IsExpired Then
				TextualLinkActive.Remove(TextualLink)
				SendEmailRenew(TextualLink)
				DeleteObject(GetType(TextualLink), TextualLink.ID)
				Exit For
			End If
		Next
	End Sub
End Module