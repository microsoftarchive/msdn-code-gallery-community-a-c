'Campaign Donation
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins

	Public Class Donation
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(DonationConfiguration), GetType(DonationSharedConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub
		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			Select Case Language
				Case Language.Italian
					Return "Campagna donazioni"
				Case Else
					Return "Campaign Donation"
			End Select
		End Function
		Private Shared SharedConfiguration As DonationSharedConfiguration = Plugin.LoadSharedConfiguration

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      Dim Configuration As DonationConfiguration = Nothing
			If SharedConfiguration.Enabled Then
				For Each Config As DonationConfiguration In SharedConfiguration.Configurations
					If Config.Campaign.Language = MasterPage.Setting.Language OrElse Config.Campaign.Language = Language.NotDefinite Then
						Configuration = Config
						Exit For
					End If
				Next
			End If
			If Configuration Is Nothing Then
				Configuration = Plugin.LoadConfiguration()
			End If

			'Hide to crawler if setting
			If Not IsCrawler() OrElse Configuration.ShowToCrawler Then
				If Not HttpContext.Current.Request.Browser.IsMobileDevice OrElse Configuration.ShowToMobileDevice Then
					Dim MetaTag As HtmlMeta = MasterPage.MetaTag("robots")
					If (MetaTag Is Nothing OrElse MetaTag.Content <> "noindex") AndAlso MasterPage.ShowRightBar = True Then	'Only page indexabled 
						Dim DonationControl As New Control
						With Configuration.Campaign
							Dim Target As Integer = .Target	'EURO
							If Now > .StartDay AndAlso Now < (.StartDay.AddDays(.Days)) Then
								Dim TotHours As Integer = .Days * 24
								Dim Hours As Integer = DateDiff(DateInterval.Hour, .StartDay, Now)
								If Hours > TotHours Then Hours = TotHours
								Dim Round As Integer = 3
								Dim NowMoney As Integer = Int((Target / TotHours * Hours) / Round) * Round
								Dim NowPercentage As Integer = Hours / TotHours * 100

								Dim Div As New WebControl(HtmlTextWriterTag.Div)
								Div.Attributes.Add("style", "font-family:Arial Black")
								Div.Attributes.Add("align", "center")

								Dim Link1 As New HyperLink
								Link1.NavigateUrl = .DonatePageUrl

								Link1.Text = HttpUtility.HtmlEncode(.InvokeMessage & " " & CurrentDomain())
								Div.Controls.Add(Link1)

								Dim Table As New WebControl(HtmlTextWriterTag.Table)
								Table.Style.Add(HtmlTextWriterStyle.BorderWidth, "2")
								Div.Controls.Add(Table)
								Table.Style.Add(HtmlTextWriterStyle.Padding, "0")
								Table.Style.Add(HtmlTextWriterStyle.Width, "80%")

								Dim Tr As New WebControl(HtmlTextWriterTag.Tr)
								Table.Controls.Add(Tr)

								Dim Td1 As New WebControl(HtmlTextWriterTag.Td)
								Td1.Style.Add(HtmlTextWriterStyle.VerticalAlign, "right")
								Td1.Attributes.Add(HtmlTextWriterStyle.WhiteSpace, "nowrap")
								Td1.Style.Add(HtmlTextWriterStyle.Height, "20")
								Td1.Style.Add(HtmlTextWriterStyle.Width, NowPercentage & "%")
								Td1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FF0000")
								Dim Tx1 As New Literal
								'Tx1.Mode = LiteralMode.Encode
								Tx1.Text = NowMoney & .TargetCurrency
								Td1.Controls.Add(Tx1)
								Tr.Controls.Add(Td1)

								Dim Td2 As New WebControl(HtmlTextWriterTag.Td)
								Td2.Attributes.Add(HtmlTextWriterStyle.VerticalAlign, "right")
								Td2.Attributes.Add(HtmlTextWriterStyle.WhiteSpace, "nowrap")
								Td2.Attributes.Add(HtmlTextWriterStyle.Height, "20")
								Td2.Attributes.Add(HtmlTextWriterStyle.Width, 100 - NowPercentage & "%")
								Td2.Attributes.Add(HtmlTextWriterStyle.BackgroundColor, "#00FF00")
								Dim Tx2 As New Literal
								Tx2.Text = Target & " " & .TargetCurrency
								Td2.Controls.Add(Tx2)
								Tr.Controls.Add(Td2)

								Dim Link2 As New HyperLink
								Link2.NavigateUrl = .DonatePageUrl
								Link2.Text = HttpUtility.HtmlEncode(NowMoney & " " & .TargetCurrency & " " & .InciteMessage)
								Div.Controls.Add(Link2)
								MasterPage.Top.Parent.Controls.AddAt(0, Div)
							End If
						End With
					End If
				End If
			End If
		End Sub

		Class DonationConfiguration
			Public ShowToCrawler As Boolean
			Public ShowToMobileDevice As Boolean
			Public Campaign As New Campaign
		End Class

		Class DonationSharedConfiguration
			Public Enabled As Boolean
			Public Configurations(-1) As DonationConfiguration
		End Class

		Class Campaign
      Public Language As Language = GetCurrentLanguage()
      Public InvokeMessage As String = IfStr(Language = LanguageManager.Language.Italian, "Per favore legga l'appello personale da parte del fondatore di", "Please read the personal appeal of the founder of")
      Public InciteMessage As String = IfStr(Language = LanguageManager.Language.Italian, "non bastano, aiutaci a fare di più!", "not enough, help us do more!")
			Public DonatePageUrl As String = "./"
			Public StartDay As Date = Today
			Public Days As Integer = 30
			Public Target As Integer = 5000
			Public TargetCurrency As String = "€"
      Private Function GetCurrentLanguage() As Language
        Try
          Dim Setting As SubSite = CurrentSetting()
          Return CurrentSetting.Language
        Catch ex As Exception
          Return Language.NotDefinite
        End Try
      End Function
    End Class

	End Class

End Namespace