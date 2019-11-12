Imports WebApplication

Partial Class viewthumb
  Inherits System.Web.UI.Page

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
    '++++++++ Compatibility old query string Key. Implemented 25/12/2012
    If Request.QueryString("size") IsNot Nothing Then Response.RedirectPermanent(ReplaceBin(AbsoluteUri(Request), "size=", QueryKey.ThumbSize & "="), True)
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    Dim Setting As SubSite = CurrentSetting()

    Dim Size As Integer = SizeThumbnail
    If Not IsNothing(Request.QueryString(QueryKey.ThumbSize)) Then
      Size = Val(Request.QueryString(QueryKey.ThumbSize))
    End If

    Dim Originalimg As System.Drawing.Image = Nothing
    If Request.QueryString("id") <> "" Then
      Dim Album As String = Request.QueryString("album")
      Dim Id As Integer = Val(Request.QueryString("id"))
      Dim Photo As Photo = PhotoManager.Photo.Load(Id, Album)
      Using Photo
        Originalimg = Photo.Image(Setting)
        If Originalimg IsNot Nothing Then
          SendImage(Originalimg, Size)
        Else
          Originalimg = ImageNotFound()
          SendImage(Originalimg, Size)
          Originalimg.Dispose()
        End If
      End Using
    Else
      If Request.QueryString(QueryKey.ThumbSource) <> "" Then
        Dim Url As String = Request.QueryString(QueryKey.ThumbSource)
        Dim RemoteWebReader As New RemoteWebReader
        RemoteWebReader.Image(Url, Originalimg)
        If Originalimg IsNot Nothing Then
          ApplyColorTone(Originalimg, Setting)
        End If
      End If
      If Originalimg Is Nothing Then
        Originalimg = ImageNotFound()
      End If
      SendImage(Originalimg, Size)
      Originalimg.Dispose()
    End If
  End Sub

  Sub SendImage(Image As Drawing.Image, Size As Integer)
    ' Sending Response JPEG type to the browser. 
    Response.ContentType = "image/jpeg"
    ImageManager.Thumbnail(Image, Size)
    Image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
  End Sub
End Class