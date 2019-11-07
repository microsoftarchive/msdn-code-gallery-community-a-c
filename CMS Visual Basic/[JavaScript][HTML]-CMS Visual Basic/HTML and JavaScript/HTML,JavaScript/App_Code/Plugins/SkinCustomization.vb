'SkinCustomization plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins

	Public Class SkinCustomization
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(SkinCustomizationConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			If Language = LanguageManager.Language.Italian Then
				If ShortDescription Then
					Return "Personalizzazione della Skin"
				Else
          Return "Plugin per il ritocco della skin in uso. Resettare la cache del browser ad ogni cambiamento! Per una maggiore personalizzazione si veda qui: " & CopyrightLink & "?p=32&a=26&t=realizzazionetemplate"
				End If
			Else
				If ShortDescription Then
					Return "Skin customization"
				Else
          Return "Plugin for the retouching of skin in use. Reset the browser cache after every change! For greater customization, see here: " & CopyrightLink & "?p=32&a=26&t=realizzazionetemplate"
				End If
			End If
		End Function

		Private Shared Sub Plugin_GetSkinSetup(ByRef SetSkinSetup As Config.SkinSetup, Setting As Config.SubSite) Handles Plugin.GetSkinSetup
			'Customize SkinSetup
			Dim Configuration As SkinCustomizationConfiguration = Plugin.LoadConfiguration()
			SetSkinSetup = SkinSetup.Load(CurrentSetting.Skin.Setups)
			For Each Key As String In SetSkinSetup.Variables.AllKeys
				SetSkinSetup.Variables(Key) = Configuration.SetupSkinParameters(Key)
			Next
		End Sub

		Private Shared Sub Plugin_AfterSavePluginConfiguration(Configuration As Object, ByRef InvokeConfigurationPageRefresh As Boolean) Handles Plugin.AfterSavePluginConfiguration
			'Reset to default values
			Dim Conf As SkinCustomizationConfiguration = Configuration 'Unboxing
			If Conf.ResetConfigurationToDefaultValues Then
				Conf.ResetConfigurationToDefaultValues = False
				Conf.SetupSkinParameters.SetDefaultValues()
				Plugin.SaveObject(Conf)
				InvokeConfigurationPageRefresh = True
			End If
		End Sub

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			Dim Configuration As SkinCustomizationConfiguration = Plugin.LoadConfiguration()
			If Configuration.EnableAdditionalCss Then
				MasterPage.Page.Header.Controls.Add(New LiteralControl("<style type=""text/css"">" & Configuration.AdditionalCss & "</style>"))
			End If
		End Sub

		Class SkinCustomizationConfiguration
			Public AdditionalCss As String = "/* hide CMS credits */" & vbCrLf & ".cms{display: none}"
			Public EnableAdditionalCss As Boolean
			Public SetupSkinParameters As CssSetup = New CssSetup
			Public ResetConfigurationToDefaultValues As Boolean
			Public Class CssSetup
				Inherits DynamicObjectSerializabled
				Sub New()
					SetDefaultValues()
				End Sub
				Sub SetDefaultValues()
					ResetMembers()
					Dim SkinSetup As SkinSetup = SkinSetup.Load(CurrentSetting.Skin.Setups, True)
					For Each Key As String In SkinSetup.Variables.Keys
						Me(Key) = SkinSetup.Variables(Key)
					Next
				End Sub
			End Class
		End Class

	End Class







End Namespace