'AdSense plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class AdSense
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Private Shared SharedConfiguration As AdsenseSharedConfiguration = Plugin.LoadSharedConfiguration
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(, , , , PluginManager.Plugin.Characteristics.EnabledByDefault, GetType(AdsenseLocalConfiguration), GetType(AdsenseSharedConfiguration), AddressOf AddExtraUserAttributes)
			Return Plugin
		End Function

		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function AddExtraUserAttributes() As Collections.Generic.List(Of PluginManager.Plugin.ExtraUserAttribute)
      AddExtraUserAttributes = Nothing
      Dim Configuration As AdsenseConfiguration = LoadConfiguration()
			If Configuration.AdvertisingRotation <> AdvertisingRotationType.None Then
				Dim ExtraUserAttribute As New PluginManager.Plugin.ExtraUserAttribute(PluginManager.Plugin.ExtraUserAttribute.TypeOfAttribute.Text, "GoogleClient", AddressOf UserAttributeTextForGoogleClient, 20)
				AddExtraUserAttributes = New Collections.Generic.List(Of PluginManager.Plugin.ExtraUserAttribute)
				AddExtraUserAttributes.Add(ExtraUserAttribute)
      End If
      Return AddExtraUserAttributes
    End Function

		Private Shared Function UserAttributeTextForGoogleClient(ByVal Language As LanguageManager.Language) As String
			Return Phrase(Language, 408) & " " & "Addsense Google Client"
		End Function

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			If Not MasterPage.AdSenseDisabled Then
				'Hide to local host
        If Not Extension.IsLocal Then
          'Affiliate program is visible only for users visitors, junior and senior
          If MasterPage.User.Role(MasterPage.Setting.Name) <= Authentication.User.RoleType.Senior OrElse MasterPage.User.Role(MasterPage.Setting.Name) = Authentication.User.RoleType.Supervisor Then
            If HttpContext.Current.Request.Browser.EcmaScriptVersion.Major >= 1 Then
              Dim Configuration As AdsenseConfiguration = LoadConfiguration()
              'Hide to crawler if setting
              If Not IsCrawler() OrElse Configuration.ShowToCrawler Then
                Dim GoogleClient As String = Nothing
                Select Case Configuration.AdvertisingRotation
                  Case AdvertisingRotationType.None
                    GoogleClient = Configuration.GoogleClient
                  Case Else
                    Dim GoogleClients As New Collections.Specialized.StringCollection
                    If Configuration.AdvertisingRotation = AdvertisingRotationType.OwnerAndAuthors Then
                      If IsValidGoogleClient(Configuration.GoogleClient) Then
                        GoogleClients.Add(Configuration.GoogleClient)
                      End If
                    End If
                    For Each Author As User In MasterPage.Authors
                      GoogleClient = Author.Attribute("GoogleClient")
                      If IsValidGoogleClient(Author.Attribute("GoogleClient")) Then
                        GoogleClients.Add(GoogleClient)
                      End If
                    Next
                    If GoogleClients.Count Then
                      GoogleClient = GoogleClients.Item(RandomIntNumber(GoogleClients.Count - 1))
                    End If
                End Select
                If IsValidGoogleClient(GoogleClient) Then
                  If HttpContext.Current.Request.Browser.IsMobileDevice Then
                    If Configuration.ShowToMobileDevice <> AdvertisingType.Off Then
                      MasterPage.Top.Controls.Add(AdSenseControl(120, 600, GoogleClient, Configuration.ShowToMobileDevice, Configuration.CustomizeCodeForMobileDevice))
                    End If
                  Else
                    If Configuration.AddToTop <> AdvertisingType.Off AndAlso MasterPage.ShowTopBar Then
                      MasterPage.Top.Controls.Add(AdSenseControl(728, 90, GoogleClient, Configuration.AddToTop, Configuration.CustomizeCodeForTop))
                    End If
                    If Configuration.AddToLeft <> AdvertisingType.Off AndAlso MasterPage.ShowLeftBar Then
                      MasterPage.Left.Controls.AddAt(0, AdSenseControl(250, 250, GoogleClient, Configuration.AddToLeft, Configuration.CustomizeCodeForLeft))
                    End If
                    If Configuration.AddToRight <> AdvertisingType.Off AndAlso MasterPage.ShowRightBar Then
                      MasterPage.Right.Controls.AddAt(0, AdSenseControl(120, 600, GoogleClient, Configuration.AddToRight, Configuration.CustomizeCodeForRight))
                    End If
                  End If
                End If
              End If
            End If
          End If
        End If
				End If
		End Sub

    Shared Function IsValidGoogleClient(GoogleClient As String) As Boolean
      If GoogleClient IsNot Nothing AndAlso GoogleClient.StartsWith("pub-") AndAlso Len(GoogleClient) = 20 Then
        Return True
      End If
      Return False
    End Function

		Shared Function LoadConfiguration() As AdsenseConfiguration
			If SharedConfiguration.ForceSharedConfigurationAtAllSites Then
				LoadConfiguration = SharedConfiguration.AdsenseConfiguration
			Else
				Dim Local As AdsenseLocalConfiguration = Plugin.LoadConfiguration
				If Local.ConfigurationInUse = AdsenseLocalConfiguration.SelectConfiguration.SharedConfiguration Then
					LoadConfiguration = SharedConfiguration.AdsenseConfiguration
				Else
					LoadConfiguration = Local.AdsenseConfiguration
				End If
			End If
      If LoadConfiguration.GoogleClient = "" AndAlso Setup.Affiliations.Google_Client <> "" Then
        LoadConfiguration.GoogleClient = Setup.Affiliations.Google_Client
      End If
    End Function

		Class AdsenseConfiguration
			Public GoogleClient As String = Setup.Affiliations.Google_Client
			Public AdvertisingRotation As AdvertisingRotationType
			Public ShowToCrawler As Boolean = False
			Public ShowToMobileDevice As AdvertisingType = AdvertisingType.TextAndImage
			Public CustomizeCodeForMobileDevice As String
			Public AddToTop As AdvertisingType = AdvertisingType.TextAndImage
			Public CustomizeCodeForTop As String
			Public AddToLeft As AdvertisingType = AdvertisingType.TextAndImage
			Public CustomizeCodeForLeft As String
			Public AddToRight As AdvertisingType = AdvertisingType.TextAndImage
			Public CustomizeCodeForRight As String
		End Class

		Class AdsenseLocalConfiguration
			Public ConfigurationInUse As SelectConfiguration
			Public AdsenseConfiguration As New AdsenseConfiguration
			Enum SelectConfiguration
				LocalConfiguration
				SharedConfiguration
			End Enum
		End Class

		Enum AdvertisingRotationType
			None
			OwnerAndAuthors
			OnlyAuthors
		End Enum

		Enum AdvertisingType
			TextAndImage
			Text
			Image
			Off
		End Enum

		Class AdsenseSharedConfiguration
			Public ForceSharedConfigurationAtAllSites As Boolean
			Public AdsenseConfiguration As New AdsenseConfiguration
		End Class

		Shared Function AdSenseControl(ByVal Width As Integer, ByVal Height As Integer, ByVal GoogleClient As String, Optional ByVal AdvertisingType As AdvertisingType = AdvertisingType.TextAndImage, Optional ByVal CustomCode As String = Nothing) As Control
			Static Code As String
			If Code Is Nothing Then
        Code = ReadAll(Extension.MapPath(CodesSubDirectory & "\adsense.html"))
			End If

			'Add AdSense code
			Dim AdSenseCode As String
			If CustomCode <> "" Then
				AdSenseCode = CustomCode
			Else
				AdSenseCode = Code
			End If
      AdSenseCode = ReplaceBin(AdSenseCode, "#CLIENT", GoogleClient)
      AdSenseCode = ReplaceBin(AdSenseCode, "#WIDTH", Width)
      AdSenseCode = ReplaceBin(AdSenseCode, "#HEIGHT", Height)

			Select Case AdvertisingType
				Case AdvertisingType.Text
          AdSenseCode = ReplaceBin(AdSenseCode, "text_image", "text")
				Case AdvertisingType.Image
          AdSenseCode = ReplaceBin(AdSenseCode, "text_image", "image")
			End Select

			Dim AdSense As New Label
      Dim OnHandheld400Px As String = Nothing
      If Width > 400 Then
        OnHandheld400Px = " class=""OnHandheld400Px"""
      End If

      AdSense.Text = "<p" & OnHandheld400Px & ">" & AdSenseCode & "</p>"
      Return AdSense
    End Function

  End Class

End Namespace