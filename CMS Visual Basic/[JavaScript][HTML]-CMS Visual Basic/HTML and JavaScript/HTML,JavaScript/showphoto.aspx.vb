Imports WebApplication
Partial Class showphoto
	Inherits System.Web.UI.Page
	Private Setting As SubSite
	Private Mode As ShowMode
	Private Album As String
	Private PhotoNumber As Integer

	Protected Sub showphoto_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    '++++++++ Compatibility old query string Key. Implemented 25/12/2012
    If Request.QueryString("n") IsNot Nothing Then Response.RedirectPermanent(ReplaceBin(AbsoluteUri(Request), "n=", QueryKey.ShowPhotoId & "="), True)
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    Setting = CurrentSetting()
    Album = Request.QueryString(QueryKey.ShowPhotoAlbumId)
    PhotoNumber = Val(Request.QueryString(QueryKey.ShowPhotoId))

		If Album = "" OrElse PhotoNumber = 0 Then
      RedirectToHomePage(Setting)
		End If

    Mode = Val(Request.QueryString(QueryKey.ShowPhotoMode))

		Dim ObjAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(Album)
		If ObjAlbum Is Nothing Then
      RedirectToHomePage(Setting)
		End If

		Dim AlbumLower As String = Album.ToLower
		If AlbumLower.StartsWith("users") Then
			Dim Author As Authentication.User = Authentication.User.Load(ObjAlbum.Author)
			RedirectToAppropriateSubSite(Author, Setting)
		Else
			RedirectToSubSiteWithAppropriateForum(AlbumLower, Setting)
			RedirectToSubSiteWithAppropriatePhotoAlbum(AlbumLower, Setting)
		End If

		If Setup.SEO.GoogleOffGoogleOnTagsEnabled Then
			GoogleOff1.Controls.Add(New LiteralControl(GoogleOffTag))
			GoogleOn1.Controls.Add(New LiteralControl(GoogleOnTag))
			GoogleOff2.Controls.Add(New LiteralControl(GoogleOffTag))
			GoogleOn2.Controls.Add(New LiteralControl(GoogleOnTag))
		End If

	End Sub

	Sub AddControlOperations(ByVal Photo As PhotoManager.Photo, ByVal ActualOperation As PhotoManager.Operations)
		PlaceHolderControlOperations.Controls.Add(Photo.ControlOperations(CurrentUser, Setting, ActualOperation))
	End Sub

	Sub AddAlbumNavigator(ByVal Photo As PhotoManager.Photo)
		PlaceHolderControlOperations.Controls.Add(Photo.Navigator(Setting))
	End Sub

	Sub AddComments(ByVal Photo As PhotoManager.Photo)
		Dim TopicID As String = Photo.IdComments
		If TopicID Then
			Dim Fieldset As New WebControls.WebControl(HtmlTextWriterTag.Fieldset)
			Dim h2 As New WebControl(HtmlTextWriterTag.H2)
			Dim Title As LiteralControl = TextControl(Phrase(Setting.Language, 130) & ":")
			h2.Controls.Add(Title)
			Fieldset.Controls.Add(h2)
      Fieldset.Controls.Add(ForumManager.ShowTopic(Setting, ReservedForums.PhotoComment, TopicID, 0, False, False, , , , , False, , False))
			Fieldset.Controls.Add(ButtonWriteComments(Photo))
			Comments.Controls.Add(Fieldset)
		End If
	End Sub

	Private Sub Submit(ByVal ObjPhoto As PhotoManager.Photo)
    Dim Operation As PhotoManager.Operations = Val(Request.QueryString(QueryKey.PhotoOperation))

		Select Case Operation
			Case PhotoManager.Operations.Delete
				ObjPhoto.Delete(CurrentUser, Setting)
        Response.Redirect(Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, ObjPhoto.Album))
			Case PhotoManager.Operations.Edit
				ObjPhoto.Edit(CurrentUser, Setting, PhotoOperations1.TitleValue, PhotoOperations1.DescriptionValue)
        Response.Redirect(Href(Setting.Name, False, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, ObjPhoto.Album, QueryKey.ShowPhotoId, PhotoNumber))
		End Select
	End Sub

	Enum ShowMode
		Normal
		FullScreen
	End Enum

	Protected Sub showphoto_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

		Dim GoNext As New System.Web.UI.WebControls.Image
    GoNext.ImageUrl = Config.ImgagesResources & "/toolicons/right.gif"
		Dim Width, Height As Integer
		CacheImageSize.LoadWidthHeight(GoNext.ImageUrl, Width, Height)
		GoNext.Width = Width
		GoNext.Height = Height

		GoNext.AlternateText = Phrase(Setting.Language, 3250)
		GoToNext.Controls.Add(GoNext)

		Dim GoPrevious As New System.Web.UI.WebControls.Image
    GoPrevious.ImageUrl = Config.ImgagesResources & "/toolicons/left.gif"
		CacheImageSize.LoadWidthHeight(GoPrevious.ImageUrl, Width, Height)
		GoPrevious.Width = Width
		GoPrevious.Height = Height
		GoPrevious.AlternateText = Phrase(Setting.Language, 3251)
		GoToPrevious.Controls.Add(GoPrevious)

		Dim FullScreenImg As New System.Web.UI.WebControls.Image
		FullScreenImg.ImageUrl = Config.ImgagesResources & "/toolicons/fullscreen.gif"
		CacheImageSize.LoadWidthHeight(FullScreenImg.ImageUrl, Width, Height)
		FullScreenImg.Width = Width
		FullScreenImg.Height = Height
		FullScreenImg.AlternateText = Phrase(Setting.Language, 3252)
		FullScreen.Controls.Add(FullScreenImg)

		FullScreen.ToolTip = EncodingAttribute(Phrase(Setting.Language, 3252))
		FullScreen.Controls.Add(FullScreenImg)

		Dim Operation As PhotoManager.Operations = Val(Request.QueryString("operation"))
		Dim ActualOperation As PhotoManager.Operations

    FullScreen.Attributes.Add("onclick", "javascript:" & "window.open('about:blank','FullScreen','fullscreen=yes,status=no,toolbar=no,menubar=no,location=no')")
    FullScreen.NavigateUrl = Href(Setting.Name, False, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, Album, QueryKey.ShowPhotoId, PhotoNumber, QueryKey.ShowPhotoMode, ShowMode.FullScreen)
		FullScreen.Attributes.Add("rel", Rel.Alternate.ToString.ToLower)
		FullScreen.Target = "FullScreen"

		Dim ObjPhoto As PhotoManager.Photo = PhotoManager.Photo.Load(PhotoNumber, Album)

    If ObjPhoto Is Nothing Then
      'If photo not found, redirect at home page
      RedirectToHomePage(Setting)
    End If

    Using ObjPhoto
      Dim MasterPage As MasterPage
      Select Case Mode
        Case ShowMode.FullScreen
          MasterPage = SetMasterPage(Me, , False, False, False, False)
          'Dim Code As String = _
          '"WebBrowser.fullscreen=True"
          'Page.Controls.Add(Script(Code, ScriptLanguage.vbscript))
        Case Else
          MasterPage = SetMasterPage(Me, , False, True)
      End Select

      MasterPage.TitleDocument = ObjPhoto.Title(Setting.Language)
      MasterPage.Description = ObjPhoto.Description(Setting.Language)
      MasterPage.KeyWords = MasterPage.TitleDocument & "," & MasterPage.Description

      If Page.IsPostBack Then
        Submit(ObjPhoto)
        ActualOperation = PhotoManager.Operations.View
      Else
        ActualOperation = Operation
      End If

      If Mode = ShowMode.FullScreen Then
        'PhotoAlbum.Visible = False
        Dim Fieldset As New WebControl(HtmlTextWriterTag.Fieldset)
        Fieldset.BorderStyle = BorderStyle.None
        Fieldset.Controls.Add(Button(Setting, Phrase(Setting.Language, 111), "javascript:window.close();", , IconType.Pics, , True))
        PhotoAlbum.Controls.Add(Fieldset)
      Else
        Dim Fieldset As New WebControl(HtmlTextWriterTag.Fieldset)
        Fieldset.BorderStyle = BorderStyle.None
        PhotoAlbum.Controls.Add(Fieldset)

        'Add PDF button
        Dim PdfEnabled As Boolean = Setting.EnablePdfVersion.Photos = EnabledStatus.Yes OrElse (Setting.EnablePdfVersion.Photos = EnabledStatus.Default AndAlso Setup.RenderingEngine.EnablePdfVersion.Photos = True)
        If PdfEnabled AndAlso PdfSupported(Setting.Language) Then
          Fieldset.Controls.Add(Components.Button(Setting, "PDF", HrefPdf(SourceType.Photo, CurrentDomainConfiguration, Setting.Name, ObjPhoto.Album, ObjPhoto.Name, ObjPhoto.Title(Setting.Language)), , IconType.Document))
        End If

        'Add PhotoAlbum button
        Dim Button As Control = Components.Button(Setting, Phrase(Setting.Language, 53, 103), Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, Album), , IconType.FolderPics, , , , "index")
        Fieldset.Controls.Add(Button)
        AddFotoAlbumSlideShow(Setting, Button, Album)

        'Add write a comments button
        Dim CommentsButton As Control = ButtonWriteComments(ObjPhoto)
        If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
          MasterPage.Blink(CommentsButton)
        End If
        Fieldset.Controls.Add(CommentsButton)
        AddControlOperations(ObjPhoto, ActualOperation)
        AddAlbumNavigator(ObjPhoto)
        AddComments(ObjPhoto)
      End If
      If ActualOperation = PhotoManager.Operations.View Then
        PhotoOperations1.Visible = False
        If Page.IsPostBack = False Then
          FromName.Text = Trim(CurrentUser.FirstName & " " & CurrentUser.LastName)
          FromEmail.Text = CurrentUser.Email
        End If
        If Request.QueryString(QueryKey.VcardSubject) <> "" Then
          Dim Subject As New Label
          Subject.Text = Request.QueryString(QueryKey.VcardSubject)
          Subject.Style.Add("font-size", "x-large")
          Dim Text As New Label
          Text.Text = Request.QueryString(QueryKey.VcardText)
          Dim From As New HyperLink
          From.Text = HttpUtility.HtmlEncode(Request.QueryString(QueryKey.VcardFrom))
          From.NavigateUrl = "mailto:" & Request.QueryString(QueryKey.VcardFromEmail)
          Dim Message As New Control
          Message.Controls.Add(Subject)
          Message.Controls.Add(BR)
          Message.Controls.Add(Text)
          Message.Controls.Add(BR)
          Message.Controls.Add(From)
          Message.Controls.Add(BR)
          MasterPage.AddMessage(Message)
          Ecard.Visible = False
        End If
      Else
        Ecard.Visible = False
        Gradient.Visible = False
        PhotoOperations1.Operation(PhotoManager.TypeObject.Photo, Operation, Setting.Language)
        PhotoOperations1.PhraseTitle = Phrase(Setting.Language, 101)
        PhotoOperations1.PhraseDescription = Phrase(Setting.Language, 102)
        Select Case Operation
          Case PhotoManager.Operations.CreateSubFotoAlbum
          Case PhotoManager.Operations.Delete
            PhotoOperations1.Alert = Ask(Phrase(Setting.Language, 57, 58), Setting.Language)
          Case PhotoManager.Operations.Edit
            PhotoOperations1.TitleValue = ObjPhoto.Title(Setting.Language)
            PhotoOperations1.DescriptionValue = ObjPhoto.Description(Setting.Language)
        End Select
      End If

      ImgPlaceHolder.Controls.Add(ObjPhoto.ControlPhoto(Setting))

      'Add Exif info
      If Setting.Aspect.ImageRendering.ShowExifInfo Then
        Dim ExitInfo As Control = ObjPhoto.ExifInfo(Setting)
        If ExitInfo IsNot Nothing Then
          ImgPlaceHolder.Controls.Add(ExitInfo)
        End If
      End If

      Dim PhotoOfUser As Boolean = Album.StartsWith("users/") OrElse Album.StartsWith("forum/")
      If (Setting.SEO.PhotoObfuscation.PhotoOfUsers = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser) OrElse (Setting.SEO.PhotoObfuscation.PhotoOfWebsite = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser = False) Then
        Max.Visible = False
      Else
        Dim MaxSize As Integer = System.Math.Max(ObjPhoto.Width, ObjPhoto.Height)
        Max.Text = ObjPhoto.Width & "X" & ObjPhoto.Height
        Max.NavigateUrl = ObjPhoto.Src(Setting, -1)
      End If

      Dim PrevPh As Integer = ObjPhoto.PreviousPhoto
      Dim NextPh As Integer = ObjPhoto.NextPhoto
      If PrevPh Then
        GoToPrevious.NavigateUrl = PhotoManager.HrefPhoto(Album, PrevPh, Setting)
        GoToPrevious.Attributes("Rel") = "prev"
        If Mode Then
          GoToPrevious.NavigateUrl &= "&" & QueryKey.ShowPhotoMode & "=" & Mode
        End If
        AddPreView(PreviousPreView, PrevPh, Album, GoToPrevious)
      Else
        GoToPrevious.Visible = False
      End If

      If NextPh Then
        GoToNext.NavigateUrl = PhotoManager.HrefPhoto(Album, NextPh, Setting)
        GoToPrevious.Attributes("Rel") = "prefetch"
        If Mode Then
          GoToNext.NavigateUrl &= "&" & QueryKey.ShowPhotoMode & "=" & Mode
        End If
        AddPreView(NextPreView, NextPh, Album, GoToNext)
      Else
        GoToNext.Visible = False
      End If
    End Using

  End Sub

	Function ButtonWriteComments(ByVal Photo As Photo) As Control
    Dim HrefWriteComment As String = Href(Setting.Name, False, "forum.aspx", QueryKey.Reference, Photo.NameCode, QueryKey.ForumId, ReservedForums.PhotoComment, QueryKey.TopicId, Photo.IdComments, QueryKey.ActionForum, IfInt(Photo.IdComments = 0, ForumManager.ActionType.NewTopic, ForumManager.ActionType.Reply))
		Return Components.Button(Setting, Phrase(Setting.Language, 123), HrefWriteComment, , IconType.Pen, , True)
	End Function

	Sub AddPreView(ByVal AddPreView As Control, ByVal Photo As Integer, ByVal Album As String, ByVal EventCtrl As WebControl)
		If Mode = ShowMode.FullScreen Then
			Exit Sub
		End If
		Dim Image As Photo = PhotoManager.Photo.Load(Photo, Album)
		Dim Thumbnail As Control = Image.ControlThumbnail(Setting)
		Dim Panel As New WebControls.Panel
		Panel.Controls.Add(Thumbnail)
		AddPreView.Controls.Add(Panel)
		'Panel.Attributes("style") = "display:none"
		'EventCtrl.Attributes("onMouseOver") = Panel.ClientID & ".style.display='block'"
		'EventCtrl.Attributes("onMouseOut") = Panel.ClientID & ".style.display='none'"
	End Sub

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim MasterPage As MasterPage = Page.Master
    If Not IsCrawler() Then
      If Page.IsValid Then
        Dim PageLoaded As Date = Session("TimePageLoaded")
        If DateDiff(DateInterval.Second, PageLoaded, Now) < 10 Then
          MasterPage.AddMessage(Phrase(Setting.Language, 422, 3245), Setting)
        Else
          Dim Subject As String = Phrase(Setting.Language, 3255) & " " & FromName.Text & " (" & FromEmail.Text & ") IP:" & Page.Request.UserHostAddress
          Dim Html As New HyperLink
          Html.Text = HttpUtility.HtmlEncode(Phrase(Setting.Language, 3257) & " " & ToName.Text & ". " & Subject & " " & Phrase(Setting.Language, 3256))
          Html.NavigateUrl = Href(Setting.Name, True, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, Album, QueryKey.ShowPhotoId, PhotoNumber, QueryKey.VcardSubject, SubjectEcard.Text, QueryKey.VcardText, TextEcard.Text, QueryKey.VcardFrom, FromName.Text, QueryKey.VcardFromEmail, FromEmail.Text)
          Try
            SendEmail(Subject, ControlToText(Html), ToEmail.Text, True, True, False, Configuration.EmailSender.Administrator, FromEmail.Text)
            MasterPage.AddMessage(Phrase(Setting.Language, 418), Setting, , , MessageType.Normal)
          Catch ex As Exception
            MasterPage.AddMessage(ex.Message, Setting, , , MessageType.ErrorAlert)
          End Try
        End If
      Else
        MasterPage.AddMessage(Phrase(Setting.Language, 404), Setting, , , MessageType.ErrorAlert)
      End If
    End If
  End Sub

	Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
		args.IsValid = IsEmail(args.Value)
	End Sub

	Protected Sub CustomValidator4_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator4.ServerValidate
		args.IsValid = IsEmail(args.Value)
	End Sub

	Protected Sub Button1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.PreRender
		If IsPostBack = False Then
			Session("TimePageLoaded") = Now
		Else
			Session("TimePageLoaded") = Nothing
		End If
	End Sub
End Class
