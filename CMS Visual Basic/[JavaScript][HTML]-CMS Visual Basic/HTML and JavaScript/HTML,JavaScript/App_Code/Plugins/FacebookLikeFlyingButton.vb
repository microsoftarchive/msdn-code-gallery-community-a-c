'Facebook Like Flying Button plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class FacebookLikeFlyingButton
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(FacebookLikeFlyingButtonConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared FlyingScript As String = "<script type=""text/javascript"">var id,timer;var xpos,ypos,xstep,ystep,xsize,ysize;xpos=0;ypos=0;xstep=speed;ystep=speed;xsize=90;ysize=35;gamex=screen.width;gamey=screen.height;if(document.documentElement&&document.documentElement.scrollHeight){gamex=document.documentElement.scrollWidth;gamey=document.documentElement.scrollHeight}else if(document.body){gamex=document.body.scrollWidth;gamey=document.body.scrollHeight}NewStep();function NewStep(){xpos+=xstep;ypos+=ystep;if(xpos>(gamex-xsize)||xpos<0){xstep=-xstep;xpos=xpos+xstep+xstep}if(ypos>(gamey-ysize)||ypos<0){ystep=-ystep;ypos=ypos+ystep+ystep}id=""palla"";if(window.pageYOffset!=null){document.getElementById(id).style.top=window.pageYOffset+ypos+""px"";document.getElementById(id).style.left=xpos+""px""};timer=setTimeout(""NewStep()"",100)}</script>"
		Private Shared HtmlHeaderCode As String = "<div id=""fb-root""></div><script>(function(d, s, id) {var js, fjs = d.getElementsByTagName(s)[0];if (d.getElementById(id)) return;js = d.createElement(s); js.id = id;js.src = ""//connect.facebook.net/it_IT/all.js#xfbml=1"";fjs.parentNode.insertBefore(js, fjs);}(document, 'script', 'facebook-jssdk'));</script>"
		Private Shared HtmlCodeInUsersToolsBar As String = "<div id=""palla""style=""position:absolute; z-index:10"" class=""fb-like"" data-href=""[PageUrl]"" data-send=""false"" data-layout=""button_count"" data-width=""90"" data-show-faces=""false""></div>"
		Private Shared CanonicalUrlNameVariable As String = "[PageUrl]"

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			Select Case Language
				Case LanguageManager.Language.Italian
					If ShortDescription Then
						Return "Bottone volante Facebook"
					Else
						Return "Aggiungi il bottone volante ""mi piace"" alle pagine del tuo sito"
					End If
				Case Else
					If ShortDescription Then
						Return "Facebook flying button"
					Else
						Return "Add a flying button ""Like"" to your site pages"
					End If
			End Select
		End Function

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			Dim Configuration As FacebookLikeFlyingButtonConfiguration = Plugin.LoadConfiguration()
      If HttpContext.Current.Request.Browser.EcmaScriptVersion.Major >= 1 Then 'Verify if browser support javascript
        If Not IsCrawler() OrElse Configuration.ShowToCrawler Then
          If CurrentUser.GeneralRole = User.RoleType.Visitors OrElse Configuration.HideToLoggedUser = False Then
            Dim MetaTag As HtmlMeta = MasterPage.MetaTag("robots")
            If (MetaTag Is Nothing OrElse MetaTag.Content <> "noindex") AndAlso MasterPage.ShowRightBar = True Then 'Share only page indexabled 
              MasterPage.Page.Header.Controls.Add(Script("document.write('" & AbjustForJavascriptString(HtmlHeaderCode) & "')", ScriptLanguage.javascript))
              Dim Code As String = ReplaceBin(HtmlCodeInUsersToolsBar, CanonicalUrlNameVariable, HttpUtility.HtmlEncode(AbsoluteUri(HttpContext.Current.Request))) & ReplaceBin(FlyingScript, "speed", Configuration.Speed)
              MasterPage.UserToolsBar.Controls.AddAt(0, Script("document.write('" & AbjustForJavascriptString(Code) & "')", ScriptLanguage.javascript))
            End If
          End If
        End If
      End If
		End Sub

		Class FacebookLikeFlyingButtonConfiguration
			Public ShowToCrawler As Boolean
			Public HideToLoggedUser As Boolean
			Public Speed As FlySpeed = FlySpeed.Normal
			Enum FlySpeed
				Slow = 1
				Normal = 2
				Fast = 3
				VeryFast = 4
			End Enum
		End Class
	End Class

End Namespace