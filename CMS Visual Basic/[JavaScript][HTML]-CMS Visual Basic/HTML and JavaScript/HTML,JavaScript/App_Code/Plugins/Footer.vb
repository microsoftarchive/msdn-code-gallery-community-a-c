'Footer plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin   'Standard namespace obbligatory for all plugins

  Public Class Footer
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(FooterConfiguration), GetType(FooterSharedConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub
    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Return Phrase(Language, 56) & " " & "Footer"
    End Function
    Private Shared SharedConfiguration As FooterSharedConfiguration = Plugin.LoadSharedConfiguration

    Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      Dim Configuration As FooterConfiguration
      If SharedConfiguration.Enabled Then
        Configuration = SharedConfiguration.FooterConfiguration
      Else
        Configuration = Plugin.LoadConfiguration()
      End If
      'Hide to crawler if setting
      If Not IsCrawler() OrElse Configuration.ShowToCrawler Then
        If Not HttpContext.Current.Request.Browser.IsMobileDevice OrElse Configuration.ShowToMobileDevice Then
          If Configuration.Columns.Count Then
            Dim FooterControl As New HtmlTable
            FooterControl.Style.Add("white-space", "nowrap")
            Dim Row As New HtmlTableRow
            FooterControl.Controls.Add(Row)
            For Each Column As Column In Configuration.Columns
              Dim Cell As New HtmlTableCell
              Row.Controls.Add(Cell)
              Dim Menu As New WebControl(HtmlTextWriterTag.Div)
              Menu.CssClass = "Menu"
              If Column.Title <> "" Then
                Menu.Controls.Add(ControlItem(Nothing, Column.Title, Nothing, 0))
              End If
              If Column.Text <> "" Then

                Dim Text As New Label
                Text.Text = Column.Text
                Text.Style.Add("white-space", "normal") 'http://code.google.com/p/chromium/issues/detail?id=89573
                Menu.Controls.Add(Text)
              End If
              For Each Link As Link In Column.Items
                Menu.Controls.Add(ControlItem(Link.Url, Link.Text, Link.Tooltip))
              Next
              Cell.Controls.Add(Menu)
            Next
            MasterPage.Bottom.Controls.AddAt(0, FooterControl)
          End If
        End If
      End If
    End Sub

    Class FooterConfiguration
      Public ShowToCrawler As Boolean
      Public ShowToMobileDevice As Boolean
      Public Columns(-1) As Column
    End Class

    Class FooterSharedConfiguration
      Public Enabled As Boolean
      Public FooterConfiguration As New FooterConfiguration
    End Class

    Class Column
      Public Title As String
      Public Text As String
      Public Items(-1) As Link
    End Class

    Class Link
      Public Url As String = "./"
      Public Text As String
      Public Tooltip As String
    End Class

  End Class

End Namespace