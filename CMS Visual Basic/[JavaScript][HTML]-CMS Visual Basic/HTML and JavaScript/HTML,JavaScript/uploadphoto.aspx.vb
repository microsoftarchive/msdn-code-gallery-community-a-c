Imports WebApplication
Partial Class uploadphoto
  Inherits System.Web.UI.Page
	Private Setting As Config.SubSite

  Protected Sub uploadphoto_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    RegisterAnonimus()
    Setting = CurrentSetting()
  End Sub

  Protected Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
		Dim Photo As New PhotoManager.Photo
		Photo.Album = Request.QueryString("album")
    Try
      Dim MaintainOriginalSize As Boolean = EnabledToMaintainOriginalImageSize(CurrentUser, Setting) AndAlso CheckBox1.Checked
      If InputFile.PostedFile.ContentLength <> 0 Then
        Photo.FromStream(InputFile.PostedFile.InputStream, MaintainOriginalSize)
      ElseIf SourceUrl.Text <> "" Then
        Photo.FromUrl(SourceUrl.Text, MaintainOriginalSize)
      End If
      If Description.Value <> "" Then
        Photo.Description(Setting.Language) = Description.Value
      End If
      If Title.Value <> "" Then
        Photo.Title(Setting.Language) = Title.Value
      End If
      Photo.Save(CurrentUser)
      Photo.Dispose()
      InputFile.Dispose()
      Response.Redirect(Href(Setting.Name, False, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, Photo.Album, QueryKey.ShowPhotoId, Photo.Name), True)
    Catch ex As Exception
      'MESSAGE ERROR: Format not valid!
      Dim MasterPage As MasterPage = Page.Master
      MasterPage.AddMessage(Setting, 428)
    End Try
  End Sub

  Protected Sub uploadphoto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		InputFile.Attributes.Add("size", "50") 'html5
    Dim Album As String
    If Request.QueryString("album") <> "" Then
      Album = Request.QueryString("album")
    Else
      Album = "default"
    End If
    HyperLink1.NavigateUrl = Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, Album)
		HyperLink1.Text = Phrase(Setting.Language, 53) & " " & Phrase(Setting.Language, 103)
		div1.InnerText = Phrase(Setting.Language, 101)
		div2.InnerText = Phrase(Setting.Language, 102)
		Div3.InnerText = Phrase(Setting.Language, 3239)

		If Not Page.IsPostBack Then
			If Config.Setup.RenderingEngine.UploadMaintainOriginalImage = True OrElse EnabledToMaintainOriginalImageSize(CurrentUser, Setting) Then
				Panel1.Visible = True
				If Config.Setup.RenderingEngine.UploadMaintainOriginalImage = True Then
					CheckBox1.Checked = True
				End If
			End If
		End If
		Dim MasterPage As MasterPage = SetMasterPage(Me, , False, True)
    MasterPage.Page.Form.Target = "_blank"
    If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
      MasterPage.Blink(Submit1)
    End If
	End Sub
End Class
