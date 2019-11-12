'Plugin By Andrea Bruno


Namespace WebApplication.Plugin    'Standard namespace obbligatory for all plugins
  Public Class BackgroundSlideshow
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(BackgroundSlideshowConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub

    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Select Case Language
        Case LanguageManager.Language.Italian
          If ShortDescription Then
            Return "Background Slideshow"
          Else
            Return "Plugin per mettere a rotazione le foto di un album nello sfondo della pagina"
          End If
        Case Else
          If ShortDescription Then
            Return "Background Slideshow"
          Else
            Return "Plugins to make a photo Slideshow in the background of the page"
          End If
      End Select
    End Function

    Private Shared Sub Plugin_BeforeEditPluginConfiguration(Configuration As Object, ByRef SetTablePropertyPhraseCorrispondence As StringDictionary) Handles Plugin.BeforeEditPluginConfiguration
      Dim Setting As SubSite = CurrentSetting()
      If Setting.Photoalbums IsNot Nothing AndAlso Setting.Photoalbums.Count > 0 Then Configuration.IdPhotoAlbum = Setting.Photoalbums(0)
    End Sub

    Private Shared Sub Plugin_BeforeSavePluginConfiguration(Configuration As Object, ByRef InvokeConfigurationPageRefresh As Boolean) Handles Plugin.BeforeSavePluginConfiguration
      If Configuration.IntervalInSeconds < 10 Then Configuration.IntervalInSeconds = 10 'Don't allow setting a value less of 10 seconds
    End Sub

    Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      Dim Configuration As BackgroundSlideshowConfiguration = Plugin.LoadConfiguration()
      If Configuration.OnlyInHomePage = False OrElse (StrComp(System.IO.Path.GetFileName(HttpContext.Current.Request.Path), "default.aspx", CompareMethod.Text) = 0 AndAlso HttpContext.Current.Request.QueryString(QueryKey.Show) = "" AndAlso HttpContext.Current.Request.QueryString(QueryKey.Url) AndAlso HttpContext.Current.Request.QueryString(QueryKey.CryptedUrl) = "" AndAlso HttpContext.Current.Request.QueryString(QueryKey.ArticleNumber) = "") Then
        If HttpContext.Current.Request.Browser.EcmaScriptVersion.Major >= 1 Then 'Verify if browser support javascript
          If Configuration.IdPhotoAlbum <> "" Then
            Const NSlide As Integer = 5
            Dim AllPhotos = GetRandomPhotos(Configuration.IdPhotoAlbum, NSlide)
            If AllPhotos IsNot Nothing AndAlso AllPhotos.Count > 0 Then
              Dim JavaArray As New StringBuilder(100 * NSlide)
              For Each Photo In AllPhotos
                Dim x As String = Photo.Src(MasterPage.Setting)
                JavaArray.Append("""" & AbjustForJavascriptString(Photo.Src(MasterPage.Setting, 1024, Configuration.ColorTone)) & """")
                JavaArray.Append(",")
              Next
              Dim Effect As String
              If Configuration.PhotoEffect <> BackgroundSlideshowConfiguration.Effect.None Then
                Effect = "url('resources/images/backgrounds/" & Configuration.PhotoEffect.ToString & ".png')"
              Else
                Effect = "none"
              End If
              Dim ScriptCode = "function bgSlideshow(){var photosurls=[" & JavaArray.ToString & "];if (typeof bgSlideshow.photoidx=='undefined'){bgSlideshow.photoidx=0};document.body.style.backgroundImage=""" & Effect & ",url('""+photosurls[bgSlideshow.photoidx]+""')"";bgSlideshow.photoidx++;if(bgSlideshow.photoidx>photosurls.length-1){bgSlideshow.photoidx=0}}"
              ScriptCode &= "document.body.style.backgroundRepeat='repeat,no-repeat';document.body.style.backgroundPosition='top,center';document.body.style.backgroundAttachment='fixed,fixed';document.body.style.backgroundSize='auto,cover'"
              ScriptCode &= ";bgSlideshow();setInterval('bgSlideshow()'," & Configuration.IntervalInSeconds * 1000 & ")"
              Dim ScriptControl As WebControl = Script(ScriptCode, ScriptLanguage.javascript)
              MasterPage.Bottom.Controls.Add(ScriptControl)
            End If
          End If
        End If
      End If
    End Sub

    Class BackgroundSlideshowConfiguration
      Public IdPhotoAlbum As String
      Public IntervalInSeconds As Integer = 60
      Public OnlyInHomePage As Boolean
      Public PhotoEffect As Effect = Effect.InterlacedDark
      Public ColorTone As ColorTone
      Enum Effect
        None
        Cancas
        InterlacedDark
        InterlacedLight
        DragonSkin
        FilterAmber
        FilterAmberInterlacedDark
        FilterAmberInterlacedLight
        FilterAntiqueBrass
        FilterAntiqueBrassInterlacedDark
        FilterAntiqueBrassInterlacedLight
        FilterBlackOlive
        FilterBlackOliveInterlacedDark
        FilterBlackOliveInterlacedLight
        FilterCoconut
        FilterCoconutInterlacedDark
        FilterCoconutInterlacedLight
        FilterTuscany
        FilterTuscanyInterlacedDark
        FilterTuscanyInterlacedLight
        FilterVanilla
        FilterVanillaInterlacedDark
        FilterVanillaInterlacedLight
        PapirBlack
        PapirWhite
        ParchmentBlack
        ParchmentWhite
      End Enum
    End Class

  End Class

End Namespace