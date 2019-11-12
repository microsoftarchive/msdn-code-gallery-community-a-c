'AddCustomButtons plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin    'Standard namespace obbligatory for all plugins

  Public Class AddCustomButtons
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(AddCustomButtonsConfiguration), GetType(AddCustomButtonsConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub

    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      If Language = LanguageManager.Language.Italian Then
        If ShortDescription Then
          Return "Aggiungi bottoni personalizzati"
        Else
          Return "Plugin per aggiungere bottoni personalizzati nella toolsbar"
        End If
      Else
        If ShortDescription Then
          Return "Add Custom Buttons"
        Else
          Return "Plugin to add custom buttons in toolsbar"
        End If
      End If
    End Function

    Private Shared SharedConfiguration As AddCustomButtonsConfiguration = Plugin.LoadSharedConfiguration

    Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      Dim Configuration As AddCustomButtonsConfiguration
      For Conf As Integer = 0 To 1
        If Conf Then
          Configuration = SharedConfiguration
        Else
          Configuration = Plugin.LoadConfiguration()
        End If
        If Configuration.Buttons.Count Then
          For Each Button As Button In Configuration.Buttons
            If Button.Enabled Then
              MasterPage.AddButton(Button.Text, Button.Href, Button.ToolTip, Button.Icon, Button.Target, Button.Nofollow, Button.OnClick, Button.Blink)
            End If
          Next
        End If
      Next
    End Sub

    Class AddCustomButtonsConfiguration
      Public Buttons(-1) As Button
    End Class

    Class Button
      Public Enabled As Boolean = True
      Public Text As String = "Text"
      Public Href As String = "./default.aspx"
      Public ToolTip As String
      Public Icon As IconType = IconType.Globe
      Public Target As MasterPage.TargetForButton = MasterPage.TargetForButton.Self
      Public Nofollow As Boolean = False
      Public OnClick As String
      Public Blink As Boolean
    End Class

  End Class

End Namespace