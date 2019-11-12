'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports System.Drawing
Imports System.Drawing.Imaging
Imports WebApplication

Partial Class viewimg
  Inherits System.Web.UI.Page
  Private Size As Integer
  Private FullSize As Boolean
  Private Setting As SubSite
  Private Name As String
  Private Album As String
#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub


  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Parametri di Request.QueryString
    'SRC = nome del file sorgente da visualizzare
    'REMOTE = (0=il file e' in locare) (1=il file e' nell'archivio remoto)
    'REMOTE = ("xxx.it"=il file e' in remoto al' url http://xxx.it

    Response.Cache.SetExpires(Now.AddYears(1))

    Dim Photo As Photo
    Dim Title As String = Nothing
    Dim Description As String = Nothing
    Dim Subject As String = Nothing
    Dim Src As String
    Setting = CurrentSetting()
    If Request.QueryString(QueryKey.ImageName) <> "" Then
      Try
        Name = Request.QueryString(QueryKey.ImageName)
      Catch ex As Exception
        RedirectToHomePage(Setting)
      End Try
      Album = Request.QueryString(QueryKey.AlbumName)
      Photo = PhotoManager.Photo.Load(Name, Album)
      If Photo Is Nothing Then
        RedirectToHomePage(Setting)
      End If
      Src = Photo.NameFileImage
      Title = Photo.Title(Request.QueryString(QueryKey.LanguageImage))
      Description = Photo.Description(Request.QueryString(QueryKey.LanguageImage))
      Dim PhotoAlbum As PhotoAlbum = PhotoAlbum.Load(Photo.Album)

      Dim AlbumLower As String = Photo.Album.ToLower
      If AlbumLower.StartsWith("users") Then
        Dim Author As Authentication.User = Authentication.User.Load(PhotoAlbum.Author)
        RedirectToAppropriateSubSite(Author, Setting)
      Else
        RedirectToSubSiteWithAppropriateForum(AlbumLower, Setting)
        RedirectToSubSiteWithAppropriatePhotoAlbum(AlbumLower, Setting)
      End If
      Subject = PhotoAlbum.Load(Photo.Album).Title(Request.QueryString(QueryKey.LanguageImage))
    Else
      Src = Server.MapPath(Request.QueryString(QueryKey.ImageSource))
    End If

    Dim RemoteServerUrl As String = Nothing
    Try
      Size = Request.QueryString(QueryKey.Size)
    Catch ex As Exception
      RedirectToHomePage(Setting)
    End Try
    FullSize = Request.QueryString(QueryKey.Fullsize) <> ""
    
    If System.IO.File.Exists(Src) Then
      SendFile(Src, Title, Description, Subject)
    End If
  End Sub

  Sub SendFile(ByRef File As String, ByVal Title As String, ByVal Description As String, ByVal Subject As String)
    ' create New image and bitmap objects. Load the image file and put into a resized bitmap.
    Dim Image As System.Drawing.Image
    Image = System.Drawing.Image.FromFile(File)

    If Album Is Nothing OrElse Not Album.StartsWith("users/") OrElse Setting.Aspect.ImageRendering.DoNotApplyTheImagesToneToUsers = False Then
      Dim ColorTone As ColorTone
      Dim Tone As String = Request.QueryString(QueryKey.ImageColorTone)
      If Tone IsNot Nothing Then
        ColorTone = Tone
      End If
      Image = ApplyColorTone(Image, ColorTone, Setting)
    End If

    Dim Obfuscation As Boolean
    If Album IsNot Nothing Then
      Dim PhotoOfUser As Boolean = Album.StartsWith("users/") OrElse Album.StartsWith("forum/")
      If (Setting.SEO.PhotoObfuscation.PhotoOfUsers = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser) OrElse (Setting.SEO.PhotoObfuscation.PhotoOfWebsite = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser = False) Then
        Obfuscation = True
      End If
    End If

    If Not FullSize OrElse Obfuscation Then
      'Resize Image
      If Obfuscation Then
        'New size after resize to scale
        Dim Width, Height As Integer
        If Size = 0 Then
          Size = ShowDefaultImageSize
        ElseIf Size < 100 Then
          Size = 100
        End If
        If Image.Width > Image.Height Then
          Width = Size
        Else
          Width = Size * Image.Width / Image.Height
        End If
        If Image.Height > Image.Width Then
          Height = Size
        Else
          Height = Size * Image.Height / Image.Width
        End If
        Dim Radians As Double = Math.PI / 180 * 10 '10° Angle rotation
        'New size after rotation
        Dim NewWidth, NewHeight As Double
        NewHeight = 1.02 * Height * Math.Cos(Radians) + Width * Math.Sin(Radians)
        NewWidth = 1.02 * Height * Math.Sin(Radians) + Width * Math.Cos(Radians)
        ImageResize(Image, CInt(NewWidth), CInt(NewHeight), False)
      Else
        Dim MaxSize As Integer = System.Math.Max(Image.Width, Image.Height)
        If Size > MaxSize Then
          Size = MaxSize
        ElseIf Size = 0 Then
          Size = ShowDefaultImageSize
        ElseIf Size < 100 Then
          Size = 100
        End If
        If Size <> MaxSize Then
          ImageResize(Image, Size, True)
        End If
      End If
    End If

    Try
      If Setup.RenderingEngine.ImageCopyright And Size >= 150 Then
        'Add Copyright
        Dim FontSize As Integer
        If Request.Browser.IsMobileDevice Then
          FontSize = 10
        Else
          FontSize = 20
        End If
        Dim OffSet As Integer = 2
        Dim MarginBottom As Integer = IfInt(Obfuscation, 20, 5)
        Dim MarginLeft As Integer = IfInt(Obfuscation, 10, 5)

        Dim Alpha As Integer = 200
        Dim FontName As String = "Arial Bold"
        Try
          If Setup.RenderingEngine.FontCopyright IsNot Nothing Then
            FontName = Setup.RenderingEngine.FontCopyright.Name
            If Not Request.Browser.IsMobileDevice Then
              FontSize = Setup.RenderingEngine.FontCopyright.Size
            End If
            Alpha = Setup.RenderingEngine.FontCopyright.TransparencyPercentage * 2.55!
          End If
        Catch ex As Exception

        End Try
        Dim g As Drawing.Graphics = Drawing.Graphics.FromImage(Image)  ' create a New graphic object from the above bmp
        Dim Position As New Drawing.PointF((OffSet + MarginLeft), Image.Height - (MarginBottom + FontSize))
        Dim Font As New Drawing.Font(FontName, FontSize, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Pixel)

        Dim Brush As New Drawing.SolidBrush(Drawing.Color.Black)
        Brush.Color = Drawing.Color.FromArgb(Alpha, Drawing.Color.Black)
        Dim Copyryght As String = "© " & DomainName(Request, True)
        g.DrawString(Copyryght, Font, Brush, Position)
        Position = New Drawing.PointF((MarginLeft), Image.Height - (OffSet + MarginBottom + FontSize))
        Brush.Color = Drawing.Color.FromArgb(Alpha, Drawing.Color.White)
        g.DrawString(Copyryght, Font, Brush, Position)

        g.Dispose()
        Font.Dispose()
        Brush.Dispose()
      End If
    Catch ex As Exception
      'This image is a bitmap indexed (for ex.: format ".GIF")
    End Try

    If Obfuscation Then
      Image = ImageManager.ImageRotate(Image, 10)
    End If

    ' Set the contenttype
    ' send image to the viewer
    Dim ImageFormat As Drawing.Imaging.ImageFormat
    Dim Parameters As Imaging.EncoderParameters
    Dim Codec As ImageCodecInfo
    If Image.Flags = 2 OrElse Image.Palette.Entries.Length = 0 Then
      'Add exif information
      SetPropertyItem(Image, Title, Description, Subject)
      If Setup.RenderingEngine.InterlaceJpegImages = True Then
        Codec = GetEncoderInfo(ImageFormat.Jpeg)
        Parameters = New EncoderParameters(2)
        'Parameters.Param(0) = New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100)
        Parameters.Param(0) = New EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, EncoderValue.ScanMethodInterlaced)
        Parameters.Param(1) = New EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, EncoderValue.RenderProgressive)
      Else
        ImageFormat = Drawing.Imaging.ImageFormat.Jpeg
      End If
      Response.ContentType = "image/jpeg"
    Else
      ImageFormat = Drawing.Imaging.ImageFormat.Gif
      Response.ContentType = "image/gif"
      'ImageFormat = Image.RawFormat
    End If
    If ImageFormat Is Nothing Then
      Image.Save(Response.OutputStream, Codec, Parameters)   ' output to the user
    Else
      Image.Save(Response.OutputStream, ImageFormat)   ' output to the user
    End If
    Image.Dispose()
  End Sub

  Private Shared Function GetEncoderInfo(ByVal Format As ImageFormat) As ImageCodecInfo
    Dim j As Integer
    Dim encoders() As ImageCodecInfo
    encoders = ImageCodecInfo.GetImageEncoders()
    j = 0
    While j < encoders.Length
      If encoders(j).FormatID = format.Guid Then
        Return encoders(j)
      End If
      j += 1
    End While
    Return Nothing
  End Function

  Sub SetPropertyItem(ByRef Image As System.Drawing.Image, ByVal Title As String, ByVal Description As String, ByVal Subject As String)
    If Setup.SEO.AddDescriptiveExifInfoToImages Then

      Try
        For Each id As Integer In Image.PropertyIdList
          Image.RemovePropertyItem(id)
        Next
      Catch ex As Exception

      End Try

      'Dim Stream As New System.IO.MemoryStream

      'Dim ImageFormat As Drawing.Imaging.ImageFormat
      'ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
      'Image.Save(Stream, ImageFormat)
      'Image.Dispose()
      'Image = Nothing

      'Image = System.Drawing.Image.FromStream(Stream)


      'Set Copyright information
      SetProperty(Image, &H8298, "http://" & CurrentDomain() & "/", True) 'ok

      'Set Author information
      SetProperty(Image, &H13B, "http://" & CurrentDomain() & "/", True)  'ok

      'Set Author information
      SetProperty(Image, &H9C9D, "http://" & CurrentDomain() & "/")  'ok

      If Title <> "" Then
        'Set Title information
        SetProperty(Image, &H10E, Title, True)  'ok
        SetProperty(Image, &H9C9B, Title) 'ok
      End If

      'Set Subject
      If Subject <> "" Then
        SetProperty(Image, &H9C9F, Subject) 'ok
      Else
        SetProperty(Image, &H9C9F, Title) 'ok
      End If

      If Description <> "" Then
        'Set Comment
        SetProperty(Image, &H9C9C, Description) 'ok
      ElseIf Title <> "" Then
        'Sec Comment eith Title string
        SetProperty(Image, &H9C9C, Title) 'ok
      End If

      If Title <> "" OrElse Description <> "" Then
        'Sec Keywords
        Dim Key As String = Title
        If Title <> "" AndAlso Description <> "" Then
          Key &= ","
        End If
        Key &= Description
        SetProperty(Image, &H9C9E, Key)  'ok
      End If
    End If
  End Sub

  Shared Lock As New Object
  Shared PropertyItem As System.Drawing.Imaging.PropertyItem
  Private Sub SetProperty(ByVal Image As System.Drawing.Image, ByVal Id As Integer, ByVal Text As String, Optional ByVal Ascii As Boolean = False)
    'Set EXIF Property
    SyncLock Lock
      If PropertyItem Is Nothing Then
        Dim NewImage As System.Drawing.Image
        NewImage = System.Drawing.Image.FromFile(MapPath(Config.ImgagesResources & "/no remove this file.jpg"))
        PropertyItem = NewImage.PropertyItems(0)
        NewImage.Dispose()
        NewImage = Nothing
      End If

      Dim Bytes() As Byte
      If Text = "" Then
        ReDim Bytes(0)
      Else
        Bytes = StringToByteArray(Text, Ascii)
        ReDim Preserve Bytes(UBound(Bytes) + 1)
      End If
      Bytes(UBound(Bytes)) = &H0
      PropertyItem.Id = Id
      PropertyItem.Value = Bytes

      If Ascii Then
        PropertyItem.Type = 2
        PropertyItem.Len = UBound(Bytes) + 1
      Else
        PropertyItem.Type = 1
        PropertyItem.Len = UBound(Bytes)
      End If
      Image.SetPropertyItem(PropertyItem)
    End SyncLock
  End Sub
End Class
