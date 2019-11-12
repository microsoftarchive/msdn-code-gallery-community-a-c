'Plugin By Andrea Bruno
'V.1.1

'File dependencies: Remove these files to remove the plugin:
'[ScriptsResources]/3dGallery.js

Namespace WebApplication.Plugin   'Standard namespace obbligatory for all plugins
  Public Class ThreeDimensionsGallery
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(ThreeDimensionsGalleryConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub

    Private Shared JavaScriptCode As String = ReadAll(MapPath(ScriptsResources & "/" & "3dGallery.js"))

    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Select Case Language
        Case LanguageManager.Language.Italian
          If ShortDescription Then
            Return "Galleria 3d"
          Else
            Return "Galleria fotografica tridimensionale."
          End If
        Case Else
          If ShortDescription Then
            Return "3d Gallery"
          Else
            Return "Three dimensions photo gallery."
          End If
      End Select
    End Function

    Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      Dim Configuration As ThreeDimensionsGalleryConfiguration = Plugin.LoadConfiguration()
      If Configuration.OnlyInHomePage = False OrElse (StrComp(System.IO.Path.GetFileName(HttpContext.Current.Request.Path), "default.aspx", CompareMethod.Text) = 0 AndAlso HttpContext.Current.Request.QueryString(QueryKey.Show) = "" AndAlso HttpContext.Current.Request.QueryString(QueryKey.Url) = "" AndAlso HttpContext.Current.Request.QueryString(QueryKey.CryptedUrl) = "" AndAlso HttpContext.Current.Request.QueryString(QueryKey.ArticleNumber) = "") Then
        If HttpContext.Current.Request.Browser.EcmaScriptVersion.Major >= 1 Then 'Verify if browser support javascript
          If Not IsCrawler(MasterPage.Request) OrElse Configuration.ShowToCrawler Then
            If CurrentUser.GeneralRole = User.RoleType.Visitors OrElse Configuration.HideToLoggedUser = False Then
              Dim MetaTag As HtmlMeta = MasterPage.MetaTag("robots")
              If (MetaTag Is Nothing OrElse MetaTag.Content <> "noindex") AndAlso MasterPage.ShowRightBar = True Then 'Only page indexabled 
                'Populate 16 random images
                Dim ImagesCode As String = ""
                Dim Setting As SubSite = CurrentSetting()
                'If Setting.PhotoAlbums IsNot Nothing Then
                'For Each PhotoAlbum As String In Setting.PhotoAlbums
                'If Configuration.IdPhotoAlbum = "" OrElse Configuration.IdPhotoAlbum = PhotoAlbum Then
                Dim DomainConfiguration As DomainConfiguration = CurrentDomainConfiguration()
                Dim Photos = GetRandomPhotos(Configuration.IdPhotoAlbum, 16)
                If Photos.Count Then
                  Dim N As Integer
                  Do
                    For Each Photo In Photos
                      ImagesCode &= "<img alt=""" & Photo.Title(Setting.Language) & """ src=""" & Photo.Src(Setting, 500) & """>"
                      N += 1
                    Next
                  Loop While N = 16
                  If Configuration.IdPhotoAlbum = "" Then Configuration.IdPhotoAlbum = Configuration.IdPhotoAlbum
                  MasterPage.AddHeader("<style type=""text/css"">#screen{width:100%;height:600px}#screen img {position:absolute;cursor:pointer;visibility:hidden;width:0;height:0;-ms-interpolation-mode:nearest-neighbor;}#screen .tvover{border:solid " & Configuration.ColorBorder & ";}#screen .tvout{border:solid " & Configuration.ColorBorderOnMouseOver & ";}#bankImages{display:none;}</style>")
                  MasterPage.AddHeader(JavaScriptCode)
                  Dim Control As New LiteralControl("<div id=""screen""></div><div id=""bankImages"">" & ImagesCode & "</div><script type=""text/javascript"">onresize=tv.resize;tv.init();</script>")
                  MasterPage.MainContainer.Controls.AddAt(0, Control)
                  Exit Sub
                  'End If
                End If
                'Next
                'End If
              End If
            End If
          End If
        End If
      End If
    End Sub

    Class ThreeDimensionsGalleryConfiguration
      Public OnlyInHomePage As Boolean = True
      Public ShowToCrawler As Boolean = True
      Public HideToLoggedUser As Boolean
      Public IdPhotoAlbum As String
      Public ColorBorder As String = "#eee"
      Public ColorBorderOnMouseOver As String = "#555"
    End Class

  End Class

End Namespace