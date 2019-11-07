'ShowcaseHomePage plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class ShowcaseHomePage
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Private Shared SharedConfiguration As ShowcaseHomePageSharedConfiguration = Plugin.LoadSharedConfiguration
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(ShowcaseHomePageConfiguration), GetType(ShowcaseHomePageSharedConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			If Language = LanguageManager.Language.Italian Then
        Return IfStr(ShortDescription, "Vetrina Pagina Principale", "Parziale esposizione nella home page degli ultimi articoli pubblicati")
			Else
        Return IfStr(ShortDescription, "Showcase Home Page", "Partial exposure in the home page of the latest articles published")
			End If
		End Function

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			'Verify if is homepage
			If HttpContext.Current.Request.Path.ToLower.EndsWith("/default.aspx") Then
        For Each QueryName As String In HttpContext.Current.Request.QueryString.AllKeys
          If StrComp(QueryName, "ss", CompareMethod.Text) <> 0 Then
            Exit Sub
          End If
        Next
				Dim Configuration As ShowcaseHomePageConfiguration
				If SharedConfiguration.Enabled Then
					Configuration = SharedConfiguration.ShowcaseHomePageConfiguration
				Else
					Configuration = Plugin.LoadConfiguration()
				End If

				If Not IsCrawler(MasterPage.Request) OrElse Configuration.ShowToCrawler Then
					If Not HttpContext.Current.Request.Browser.IsMobileDevice OrElse Configuration.ShowToMobileDevice Then
						If MasterPage.Setting.Archive IsNot Nothing Then
							For Each Archive As Integer In MasterPage.Setting.Archive
								Dim Menu As Menu = Menu.Load(Archive, MasterPage.Setting.Language)
								If Menu IsNot Nothing Then
									Dim Pages(Menu.ItemsMenu.Count - 1) As Integer
									Dim N As Integer = 0
									For Each Item As ItemMenu In Menu.ItemsMenu
										If Item.Off = False AndAlso Item.JoinPrevious = False Then
											Pages(N) = Item.IdPage
											N += 1
										End If
									Next
									If N Then
										Array.Sort(Pages)
										Dim Counter As Integer
										Dim ReturnMetaTags As New Collections.Generic.List(Of MetaTags)
										For N = UBound(Pages) To LBound(Pages) Step -1
											If Pages(N) Then
												If Counter < Configuration.NumberOfItems Then
													Dim Level, Category As Integer
                          Dim MetaTags As MetaTags = Nothing
													Menu.LevelAndCategoryItem(Pages(N), Level, Category)
                          Components.AddPageArchived(MasterPage.ContentPlaceHolder, MasterPage, Menu.Archive, Pages(N), HttpContext.Current, CurrentDomainConfiguration, MasterPage.Setting, MetaTags, True, , Configuration.AddCommentsButton, Level, Category, Configuration.CaractersLimit, Configuration.AddPdfButton)
													If Configuration.JoinKeyWords AndAlso MetaTags IsNot Nothing AndAlso MetaTags.KeyWords <> "" Then
														MasterPage.KeyWords &= "," & MetaTags.KeyWords
													End If
													Counter += 1
												Else
													Exit For
												End If
											End If
										Next
									End If
									ReDim Pages(-1)
								End If
							Next
						End If
					End If
				End If
			End If
		End Sub

		Class ShowcaseHomePageConfiguration
			Public NumberOfItems As Integer = 7
			Public CaractersLimit As Integer = 500
			Public ShowToCrawler As Boolean = True
			Public ShowToMobileDevice As Boolean = True
			Public JoinKeyWords As Boolean = True
			Public AddCommentsButton As Boolean
			Public AddPdfButton As Boolean
		End Class

		Class ShowcaseHomePageSharedConfiguration
			Public Enabled As Boolean
			Public ShowcaseHomePageConfiguration As New ShowcaseHomePageConfiguration
		End Class

	End Class

End Namespace