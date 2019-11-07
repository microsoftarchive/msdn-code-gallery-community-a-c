'This plugin help to add customized code into page 
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class AddHtmlCode
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(AddHtmlCodeConfiguration), GetType(AddHtmlCodeConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			Select Case Language
				Case LanguageManager.Language.Italian
					If ShortDescription Then
						Return "Aggiungi codice html"
					Else
						Return "Aggiungi codice html personalizzato alla pagina master"
					End If
				Case Else
					If ShortDescription Then
						Return "Add html code"
					Else
						Return "Add customized html code into master page"
					End If
			End Select
		End Function

		Private Shared SharedConfiguration As AddHtmlCodeConfiguration = Plugin.LoadSharedConfiguration

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			Dim Configuration As AddHtmlCodeConfiguration
			For N As Integer = 0 To 1
				If N Then
					Configuration = Plugin.LoadConfiguration
				Else
					Configuration = SharedConfiguration
				End If
				If Not IsCrawler(MasterPage.Request) OrElse Configuration.ShowToCrawler Then
					If CurrentUser.GeneralRole = User.RoleType.Visitors OrElse Configuration.HideToLoggedUser = False Then
						AddCode(MasterPage.Page.Header, Configuration.Head)
						If MasterPage.ShowTopBar Then
							AddCode(MasterPage.Top, Configuration.Top)
							AddCode(MasterPage.UserToolsBar, Configuration.UserToolsBar)
						End If
						If MasterPage.ShowLeftBar Then
							AddCode(MasterPage.Left, Configuration.SlidebarLeft)
						End If
						If MasterPage.ShowRightBar Then
							AddCode(MasterPage.Right, Configuration.SlidebarRight)
						End If
						If MasterPage.ShowBottomBar Then
							AddCode(MasterPage.Bottom, Configuration.Footer)
						End If
            AddCode(MasterPage.ContentPlaceHolder, Configuration.Content)
					End If
				End If
			Next
		End Sub

		Shared Sub AddCode(Where As Control, Code As AddHtmlCodeConfiguration.Code)
			If Code.Html <> "" Then
				If Code.AddAtPosition > Where.Controls.Count Then
					Code.AddAtPosition = Where.Controls.Count
				End If
				Where.Controls.AddAt(Code.AddAtPosition, New LiteralControl(Code.Html))
			End If
		End Sub

		Class AddHtmlCodeConfiguration
			Public ShowToCrawler As Boolean = True
			Public HideToLoggedUser As Boolean
			Public Head As New Code
			Public Top As New Code
			Public UserToolsBar As New Code
			Public Content As New Code
			Public SlidebarLeft As New Code
			Public SlidebarRight As New Code
			Public Footer As New Code
			Class Code
				Public Html As String
				Public AddAtPosition As Integer
			End Class
		End Class

	End Class

End Namespace