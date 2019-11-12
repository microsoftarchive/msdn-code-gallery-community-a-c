'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
  Public Class AllNetworkPluginEnabler
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, User.RoleType.Supervisor, , , PluginManager.Plugin.Characteristics.AlwaysEnabled, , GetType(SharedConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub

    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Select Case Language
        Case LanguageManager.Language.Italian
          If ShortDescription Then
            Return "Attiva/disattiva plugin"
          Else
            Return "Questo plugin ti permette di attivare o disattivare ogni plugin in tutti i siti web"
          End If
        Case Else
          If ShortDescription Then
            Return "Enable/disable plugin"
          Else
            Return "This plugin allows you to enable or disable each plugin in all websites"
          End If
      End Select
    End Function

    Class SharedConfiguration
      Inherits DynamicObjectSerializabled
      Sub New()
        SetDefaultValues()
      End Sub
      Sub SetDefaultValues()
        ResetMembers()
        Dim SkinSetup As SkinSetup = SkinSetup.Load(CurrentSetting.Skin.Setups, True)
        For Each Plugin As PluginManager.Plugin In AllPlugins()
          If Plugin.Characteristic <> PluginManager.Plugin.Characteristics.AlwaysEnabled AndAlso Plugin.Characteristic <> PluginManager.Plugin.Characteristics.CorePlugin Then
            Me(Plugin.Name) = Action.NoAction
          End If
        Next
      End Sub
    End Class

    Enum Action
      NoAction
      EnableThisPluginInAllWebsites
      DisableThisPluginInAllWebsites
    End Enum

    Private Shared Sub Plugin_BeforeEditPluginSharedConfiguration(Configuration As Object, ByRef SetTablePropertyPhraseCorrispondence As StringDictionary) Handles Plugin.BeforeEditPluginSharedConfiguration
      Dim Language As Language = CurrentSetting.Language
      SetTablePropertyPhraseCorrispondence = New StringDictionary
      Dim Conf As SharedConfiguration = Configuration
      For Each Member In Conf.MembersArray
        Dim Plugin = PluginManager.GetPlugin(Member.Name)
        If Plugin IsNot Nothing Then
          SetTablePropertyPhraseCorrispondence.Add(Plugin.Name, Plugin.Description(Language))
        End If
      Next
    End Sub
 
    Private Shared Sub Plugin_BeforeSavePluginSharedConfiguration(Configuration As Object, ByRef InvokeConfigurationPageRefresh As Boolean) Handles Plugin.BeforeSavePluginSharedConfiguration
      Dim Conf As SharedConfiguration = Configuration
      Dim Settings = AllSubSite()
      For Each Member In Conf.MembersArray
        Dim Plugin = PluginManager.GetPlugin(Member.Name)
        If Plugin IsNot Nothing AndAlso Plugin.Characteristic <> PluginManager.Plugin.Characteristics.AlwaysEnabled AndAlso Plugin.Characteristic <> PluginManager.Plugin.Characteristics.CorePlugin Then
          Dim ActionToExecuting As Action = Member.Value
          For Each Site In Settings
            Select Case ActionToExecuting
              Case Action.DisableThisPluginInAllWebsites
                Plugin.IsEnabled(Site) = False
                Plugin.SaveAttribute(Site)
              Case Action.EnableThisPluginInAllWebsites
                Plugin.IsEnabled(Site) = True
                Plugin.SaveAttribute(Site)
            End Select
            Member.Value = Action.NoAction
          Next
        End If
      Next
      Configuration = Nothing
    End Sub
  End Class

End Namespace