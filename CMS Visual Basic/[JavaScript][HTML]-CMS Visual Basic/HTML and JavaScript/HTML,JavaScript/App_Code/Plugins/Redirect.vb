'Plugin By Andrea Bruno

Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class Redirect
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()

		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(RedirectConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			Select Case Language
				Case LanguageManager.Language.Italian
					If ShortDescription Then
						Return "Redirect"
					Else
						Return "Plugin per la configurazione del reindirizzamento di pagina"
					End If
				Case Else
					If ShortDescription Then
						Return "Redirect"
					Else
						Return "Plugin for configuring the redirection page"
					End If
			End Select
    End Function

    Private Shared Sub Plugin_MasterPageInit(MasterPage As Components.MasterPage) Handles Plugin.MasterPageInit
      Dim Configuration As RedirectConfiguration = Plugin.LoadConfiguration()
      For Each Redirect As RedirectConfiguration.RedirectSetting In Configuration.Redirects
        If Redirect.Who = RedirectConfiguration.RedirectSetting.WhoRedirect.All OrElse (Redirect.Who = RedirectConfiguration.RedirectSetting.WhoRedirect.Crawlers AndAlso IsCrawler(MasterPage.Request)) OrElse (Redirect.Who = RedirectConfiguration.RedirectSetting.WhoRedirect.Users AndAlso IsCrawler(MasterPage.Request) = False) Then
          Dim UrlEndWith As String
          If Redirect.UrlEndWith = "" Then
            UrlEndWith = "/default.aspx"
          Else
            UrlEndWith = Redirect.UrlEndWith
          End If
          If AbsoluteUri(MasterPage.Request).EndsWith(UrlEndWith) Then
            Select Case Redirect.Type
              Case RedirectConfiguration.RedirectSetting.RedirectTyte.Permanent
                HttpContext.Current.Response.RedirectPermanent(Redirect.RedirectTo, True)
              Case Else
                MasterPage.Response.Redirect(Redirect.RedirectTo)
                MasterPage.Response.End()
            End Select
            Exit Sub
          End If
        End If
      Next
    End Sub

		Class RedirectConfiguration
			Public Redirects(-1) As RedirectSetting
			Class RedirectSetting
				Public Who As WhoRedirect
				Public UrlEndWith As String
				Public RedirectTo As String
				Public [Type] As RedirectTyte
				Enum RedirectTyte
					Permanent	'301
					Temporary	'302
				End Enum
				Enum WhoRedirect
					All
					Crawlers
					Users
				End Enum
			End Class
		End Class

	End Class

End Namespace