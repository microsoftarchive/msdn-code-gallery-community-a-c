'Share button plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class ShareButton
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(ShareButtonConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Return Phrase(Language, 150)
		End Function

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			Dim Configuration As ShareButtonConfiguration = Plugin.LoadConfiguration()
			If Not IsCrawler(MasterPage.Request) OrElse Configuration.ShowToCrawler Then
				Dim MetaTag As HtmlMeta = MasterPage.MetaTag("robots")
				If (MetaTag Is Nothing OrElse MetaTag.Content <> "noindex") AndAlso MasterPage.ShowRightBar = True Then	'Share only page indexabled 
          MasterPage.AddHeader(ReplaceBin(Configuration.HtmlHeaderCode, Configuration.CanonicalUrlNameVariable, HttpUtility.HtmlEncode(HttpContext.Current.Request.RawUrl)))
          MasterPage.UserToolsBar.Controls.AddAt(0, New LiteralControl(ReplaceBin(Configuration.HtmlCodeInUsersToolsBar, Configuration.CanonicalUrlNameVariable, HttpUtility.HtmlEncode(HttpContext.Current.Request.RawUrl))))
					For Each BottomContent As BottomContent In MasterPage.BottomContentCollection
            BottomContent.Bar.Controls.Add(New LiteralControl(ReplaceBin(Configuration.HtmlBottomContentCode, Configuration.CanonicalUrlNameVariable, HttpUtility.HtmlEncode(BottomContent.Canonical))))
					Next
				End If
			End If
		End Sub

		Class ShareButtonConfiguration
			Public ShowToCrawler As Boolean
			Public HtmlHeaderCode As String
			Public HtmlCodeInUsersToolsBar As String = "<span class=""addthis_toolbox addthis_default_style addthis_32x32_style""><a class=""addthis_button_preferred_1""></a><a class=""addthis_button_preferred_2""></a><a class=""addthis_button_preferred_3""></a><a class=""addthis_button_preferred_4""></a><a class=""addthis_button_compact""></a><a class=""addthis_counter addthis_bubble_style""></a></span><script type=""text/javascript"" src=""http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e6beb7136caedd8""></script>"
			Public HtmlBottomContentCode As String = "<span class=""addthis_toolbox addthis_default_style""><a addthis:url=""[PageUrl]"" class=""addthis_button_facebook_like"" fb:like:layout=""button_count""></a><a addthis:url=""[PageUrl]"" class=""addthis_button_tweet""></a><a addthis:url=""[PageUrl]"" class=""addthis_button_google_plusone"" g:plusone:size=""medium""></a><a addthis:url=""[PageUrl]"" class=""addthis_counter addthis_pill_style""></a></span><script type=""text/javascript"" src=""http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e6bec2a7b8ab800""></script>"
			Public CanonicalUrlNameVariable As String = "[PageUrl]"
		End Class


	End Class

End Namespace