'Plugin fot Robots.txt customization
'By Andrea Bruno
Namespace WebApplication.Plugin   'Standard namespace obbligatory for all plugins

  Public Class Robots
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, , GetType(RobotsSharedConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub
    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Select Case Language
        Case Language.Italian
          If ShortDescription Then
            Return "Personalizzazione robots.txt"
          Else
            Return "Plugin per la personalizzazione manuale del file robots.txt"
          End If
        Case Else
          If ShortDescription Then
            Return "Robots.txt customize"
          Else
            Return "Plugin for manual customization of the robots.txt file"
          End If
      End Select
    End Function
    Private Shared SharedConfiguration As RobotsSharedConfiguration = Plugin.LoadSharedConfiguration

    Class RobotsSharedConfiguration
      Public Method As MethodSelect
      Enum MethodSelect
        Add
        Replace
      End Enum
      Public Text As String = "User-agent: *" & vbCrLf & "Disallow:"
    End Class

    Private Shared Sub Plugin_RobotsTxtPreRender(ByRef Text As String, DomainConfiguration As DomainConfiguration) Handles Plugin.RobotsTxtPreRender
      If SharedConfiguration.Method = RobotsSharedConfiguration.MethodSelect.Replace Then
        Text = ""
      Else
        Text &= vbCrLf
      End If
      Text &= SharedConfiguration.Text
    End Sub
  End Class

End Namespace