Imports WebApplication
Partial Class EditPage
  Inherits System.Web.UI.Page
	Private Setting As Config.SubSite
	Private Archive As Integer = -1
	Private NPage As Integer
	Private Language As LanguageManager.Language
	Private MasterPage As MasterPage

	Protected Sub EditPage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Setting = CurrentSetting()
		RegisterAnonimus()
		If Request.QueryString("archive") <> "" Then
			Archive = Val(Request.QueryString("archive"))
		Else
			If Setting.Archive IsNot Nothing Then
				If Setting.Archive.Length = 1 Then
					Archive = Setting.Archive(0)
				End If
			End If
		End If
		NPage = Val(Request.QueryString("page"))
		If NPage = 0 And IsNumeric(Request.Form(NewNPage.UniqueID)) Then
			NPage = Request.Form(NewNPage.UniqueID)
		End If
		Language = Val(Request.QueryString("lng"))
		If Language = Language.NotDefinite Then
			Language = Setting.Language
		End If
		Dim Block As Boolean
		If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.AdministratorJunior Then
			Block = True
		Else
			If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.WebMaster And NPage <> 0 Then
				Block = True
				If Setting.Archive IsNot Nothing Then
					For Each Id As Integer In Setting.Archive
						If Id = Archive Then
							Block = False
						End If
					Next
				End If
			End If
		End If
		If Block Then
			Response.Clear()
			Response.End()
		End If
	End Sub

	Protected Sub edit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		MasterPage = SetMasterPage(Me, , False, False)
	End Sub

	Private Function PageNameFile(ByVal Archive As Integer, ByRef NPage As Integer, ByVal Language As LanguageManager.Language) As String
		If NPage Then
			Return MenuManager.PageNameFile(Archive, NPage, Language)
		Else
			Do
				NPage += 1
			Loop Until Not IO.File.Exists(MenuManager.PageNameFile(Archive, NPage, Language))
			Return MenuManager.PageNameFile(Archive, NPage, Language)
		End If
	End Function

	'Private Function AddIcon(ByVal Text As String, Optional ByVal Font As String = "Webdings") As String
	'	Dim Ctrl As New WebControls.Label
	'	Ctrl.Font.Name = Font
	'	Ctrl.Text = Text
	'	Return ControlToText(Ctrl)
	'End Function

	Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
		SetVisualization()
	End Sub
	Private Sub SetVisualization()
    If Setup.Ambient.HtmlEditor = Configuration.AmbientConfiguration.HtmlEditorNames.TinyMCE Then
      Dim Source As String = ReadAll(MapPath(Config.Resources & "\TinyMCE\config.html"))
      'Source = Replace(Source, "'html'", "'" & Html.ClientID & "'", , , CompareMethod.Text)
      Dim Script As New Literal
      Script.Text = Source
      HtmlEditor.Controls.Add(Script)
    Else
      'Free Html Editor .net by Andrea Bruno © http://wysiwygnet.com/
      Dim Tools As New Control
      HtmlEditor.Controls.Add(Tools)
      HtmlEditor.Controls.Add(BR)
      Dim Editor As New WebControl(HtmlTextWriterTag.Div)
      Editor.ID = "editor"
      Editor.Attributes.Add("contenteditable", "true")
      Editor.Style.Add("border-style", "dashed")
      Editor.Style.Add("width", "inherit")
      'Editor.Height = 300
      Editor.Style.Add("padding", "10px")
      'Editor.Attributes.Add("display", "none")
      HtmlEditor.Controls.Add(Editor)
      ScriptClient.Controls.Add(Script("var Editor=document.getElementById('" & Editor.ClientID & "');var TextArea=document.getElementById('" & Html.ClientID & "');TextArea.style.display='none';Editor.innerHTML=TextArea.value;function Save(){TextArea.value=Editor.innerHTML}", ScriptLanguage.javascript))
      Form.Attributes.Add("onsubmit", "Save()")

      Dim Anchor As Integer = IconName.Anchor
      Dim Bold As Integer = IconName.Bold
      Dim Italic As Integer = IconName.Italic
      Dim Neutral As Integer = &H2115
      Dim BulletedList As Integer = IconName.BulletedList
      Dim EnumeratedList As Integer = &H2419
      If Request.Browser.Browser = "Chrome" Then
        'Chrome dont support this unichode chars, then change this!
        Anchor = &H21AC
        Bold = &H24B7
        Italic = &H24BE
      ElseIf Request.UserAgent.Contains("Android") Then
        Anchor = &H21AC
        Bold = &H24B7
        Italic = &H24BE
        Neutral = &H24DD
        BulletedList = &H21F6
        EnumeratedList = &H2116
      End If
      Dim ReqLink As String
      Dim ReqLinkInsideAlgoritm As Boolean
      If Request.Browser.Browser = "IE" Then
        ReqLinkInsideAlgoritm = True
        ReqLink = "null"
      Else
        ReqLink = "prompt('URL:', 'http://')"
      End If
      Tools.Controls.Add(IconUnicode(IconName.Undo, True, "Undo", "javascript:var status=document.execCommand('undo')"))
      Tools.Controls.Add(IconUnicode(IconName.Redo, True, "Redo", "javascript:var status=document.execCommand('redo')"))

      '+++++++++++++++++++++++++
      'BUG: The Anchor botton don't work with Firefox! If a good JS coder fix this issue, please post the resolution here: http://cmsaspnet.com/forum.aspx?f=202&c=4
      Tools.Controls.Add(IconUnicode(Anchor, True, "Link", "javascript:var status=document.execCommand('createlink'," & ReqLinkInsideAlgoritm.ToString.ToLower & "," & ReqLink & ")"))
      '+++++++++++++++++++++++++


      Tools.Controls.Add(IconUnicode(Bold, True, "Bold", "javascript:var status=document.execCommand('bold')"))
      Tools.Controls.Add(IconUnicode(Italic, True, "Italic", "javascript:var status=document.execCommand('italic')"))
      Tools.Controls.Add(IconUnicode(IconName.Underline, True, "Underline", "javascript:var status=document.execCommand('underline')"))
      Tools.Controls.Add(IconUnicode(&H20A6, True, "Strikethrough", "javascript:var status=document.execCommand('strikethrough')"))
      Tools.Controls.Add(IconUnicode(&HAA, True, "Superscript", "javascript:var status=document.execCommand('superscript')"))
      Tools.Controls.Add(IconUnicode(IconName.One, True, "H1", "javascript:var status=document.execCommand('formatBlock',false,'<h1>')"))
      Tools.Controls.Add(IconUnicode(IconName.Two, True, "H2", "javascript:var status=document.execCommand('formatBlock',false,'<h2>')"))
      Tools.Controls.Add(IconUnicode(IconName.Three, True, "H3", "javascript:var status=document.execCommand('formatBlock',false,'<h3>')"))
      Tools.Controls.Add(IconUnicode(&H24D2, True, "Block code", "javascript:var status=document.execCommand('formatBlock',false,'<pre>')"))
      Tools.Controls.Add(IconUnicode(Neutral, True, "Neutral", "javascript:var status=document.execCommand('formatBlock',false,'<div>')"))
      Tools.Controls.Add(IconUnicode(&H21E4, True, "Justify left", "javascript:var status=document.execCommand('justifyleft')"))
      'Tools.Controls.Add(IconUnicode(&H2194, True, "Justify center", "javascript:var status=document.execCommand('justifycenter')"))
      Tools.Controls.Add(IconUnicode(&H21E5, True, "Justify right", "javascript:var status=document.execCommand('justifyright')"))
      Tools.Controls.Add(IconUnicode(BulletedList, True, "List", "javascript:var status=document.execCommand('insertunorderedlist')"))
      Tools.Controls.Add(IconUnicode(EnumeratedList, True, "Enumerated list", "javascript:var status=document.execCommand('insertorderedlist')"))
    End If

    For Each Value As EnabledStatus In [Enum].GetValues(GetType(EnabledStatus))
      Dim ListItem As New WebControls.ListItem
      Dim Word As Integer
      Select Case Value
        Case EnabledStatus.Default
          Word = 3167
        Case EnabledStatus.Yes
          Word = 126
        Case Else
          Word = 127
      End Select
      ListItem.Text = Phrase(Setting.Language, Word)
      ListItem.Value = Value
      ShowDate.Items.Add(ListItem)
    Next

    If Archive = -1 Then
      Panel1.Visible = False
      If Setting.Archive IsNot Nothing Then

        Dim Box As New WebControl(HtmlTextWriterTag.Div)
        Box.CssClass = "Menu"

        For Each Archive As Integer In Setting.Archive
          Dim Text As String = ""
          Dim Menu As Menu = Menu.Load(Archive, Setting.Language)
          For Each ItemMenu As ItemMenu In Menu.ItemsMenu
            If ItemMenu.Level = 0 Then
              Text &= "\" & ItemMenu.Description.Label
            End If
          Next
          If Text = "" Then
            Text = Phrase(Setting.Language, 3015) & " " & Archive
          End If
          Dim Link As String = Href(Setting.Name, False, "edit.aspx", "archive", Archive, "lng", Setting.Language)

          Box.Controls.Add(Components.Folder(Text, Phrase(Setting.Language, 52), Link, Setting))

        Next
        Dim Content As Control = MasterPage.ContentPlaceHolder
        Content.Controls.Add(Box)
      End If
    Else
      Dim CurrentAlbum As String = Nothing
      Dim CurrentPhoto As String = Nothing
      Dim FileName As String = MenuManager.PageNameFile(Archive, NPage, Language)
      If IO.File.Exists(FileName) Then
        'Dim Code As String = Extension.ReadAll(FileName)
        'Dim MetaTags As New MetaTags(Code)
        Dim Document As New HtmlDocument(FileName)
        Select Case Page.IsPostBack
          Case False
            If NPage Then
              TitlePage.Text = Document.MetaTags.Title
              Description.Text = Document.MetaTags.Description
              KeyWords.Text = Document.MetaTags.KeyWords
              CorrelatedWords.Text = Document.MetaTags.Collection("CorrelatedKeyWords")
              Dim Status As SubSite.CerrelatedStructure.CorrelatedStatus
              Status = Document.MetaTags.Collection("CorrelatedStatus")
              Select Case Status
                Case Config.SubSite.CerrelatedStructure.CorrelatedStatus.Enabled
                  CW_Enabled.Checked = True
                Case Config.SubSite.CerrelatedStructure.CorrelatedStatus.Context
                  CW_SameDomain.Checked = True
                Case Config.SubSite.CerrelatedStructure.CorrelatedStatus.NotEnabled
                  CW_NotEnabled.Checked = True
              End Select
              If Document.MetaTags.MetaTag("EnabledComments") <> "" Then
                EnabledComments.Checked = CBool(Document.MetaTags.MetaTag("EnabledComments"))
              End If
              Dim ShowDateValue As EnabledStatus
              If Document.MetaTags.MetaTag("ShowDate") <> "" Then
                ShowDateValue = Document.MetaTags.MetaTag("ShowDate")
              End If

              For Each Item As ListItem In ShowDate.Items
                If Item.Value = ShowDateValue Then
                  Item.Selected = True
                  Exit For
                End If
              Next

              CurrentAlbum = Document.MetaTags.MetaTag("PhotoAlbum")
              If CurrentAlbum <> "" Then
                AddPhotoAlbum.Checked = True
              Else
                CurrentPhoto = Document.MetaTags.MetaTag("Photo")
                If CurrentPhoto <> "" Then
                  CurrentAlbum = Split(CurrentPhoto, ".")(0)
                End If
              End If
              VideoID.Text = Document.MetaTags.Collection("Video")
              Html.Value = Document.Body
            End If
        End Select
        If DeletePermission(Document.MetaTags.Author) Then
          Delete.Visible = True
        End If
      Else
        Delete.Visible = False
      End If

      'add select photo and album
      'Add code preview photo

      AddScriptClientPreviewPhoto(PhotoList, imgpreview)
      Dim Srcs() As String = Nothing, Titles() As String = Nothing
      Dim N, Checked As Integer
      If Not Setting.Photoalbums Is Nothing Then
        For Each Album As String In Setting.Photoalbums
          Dim PhotoAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(Album)
          If PhotoAlbum IsNot Nothing Then
            AddValue(Srcs, JavascriptPhotosList(Setting, PhotoAlbum.Name))
            Dim Title As String = PhotoAlbum.Title(Setting.Language)
            If Title = "" Then
              Title = PhotoAlbum.Name
            End If
            AddValue(Titles, Title)
            If PhotoAlbum.Name = CurrentAlbum Then Checked = N
            N += 1
            For Each SubPhotoAlbum As PhotoAlbum In PhotoAlbum.PhotoAlbums(False)
              AddValue(Srcs, JavascriptPhotosList(Setting, SubPhotoAlbum.Name))
              Dim TitleSubPhotoAlbum As String = SubPhotoAlbum.Title(Setting.Language)
              If TitleSubPhotoAlbum = "" Then
                TitleSubPhotoAlbum = SubPhotoAlbum.Name
              End If
              AddValue(Titles, TitleSubPhotoAlbum)
              If SubPhotoAlbum.Name = CurrentAlbum Then Checked = N
              N += 1
            Next
          End If
        Next
      End If
      If Page.IsPostBack Then
        Checked = Val(Request.Form("ctl00$ContentPlaceHolder1$PhotoSource"))
        CurrentPhoto = Request.Form(PhotoList.UniqueID)
      End If
      AddScriptClientPopulateListPhotos(PhotosSourceSelect, PhotoList, Titles, Checked, CurrentPhoto, 0, Srcs)

    End If
  End Sub

  Private Sub AddValue(ByRef Array() As String, ByRef Value As String)
    If Array Is Nothing Then
      ReDim Array(0)
    Else
      ReDim Preserve Array(UBound(Array) + 1)
    End If
    Array(UBound(Array)) = Value
  End Sub

  Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
    Dim UpdateCorrelatedLinks As Boolean
    Dim MetaTags As New MetaTags
    'Mantain old tags
    If NPage AndAlso IO.File.Exists(PageNameFile(Archive, NPage, Language)) Then
      Dim OldDocument As New HtmlDocument(PageNameFile(Archive, NPage, Language))
      MetaTags = OldDocument.MetaTags
      MetaTags.Title = TitlePage.Text
      MetaTags.Description = Description.Text
      MetaTags.KeyWords = KeyWords.Text
      If MetaTags.Author = "" Then
        MetaTags.Author = CurrentUser.Username
      End If
      If MetaTags.Collection("CorrelatedKeyWords") <> CorrelatedWords.Text Then
        UpdateCorrelatedLinks = True
      End If
    Else
      MetaTags = New MetaTags(TitlePage.Text, Description.Text, KeyWords.Text, CurrentUser.Username)
      MetaTags.AddMetaTag("Date", DateToText(Now.ToUniversalTime))
    End If
    'Dim ShowDateValue As EnabledStatus = ShowDate.SelectedValue 'Work correctly only if EnableViewStateMac="false"
    Dim ShowDateValue As EnabledStatus = Request.Form(ShowDate.UniqueID)
    If ShowDateValue <> EnabledStatus.Default Then
      MetaTags.AddMetaTag("ShowDate", Request.Form(ShowDate.UniqueID))
    End If
    MetaTags.AddMetaTag("EnabledComments", EnabledComments.Checked)
    MetaTags.AddMetaTag("CorrelatedKeyWords", CorrelatedWords.Text)

    Dim Status As SubSite.CerrelatedStructure.CorrelatedStatus
    If CW_Enabled.Checked Then
      Status = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Enabled
    ElseIf CW_SameDomain.Checked Then
      Status = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Context
    ElseIf CW_NotEnabled.Checked Then
      Status = Config.SubSite.CerrelatedStructure.CorrelatedStatus.NotEnabled
    End If

    If NPage Then
      Dim OldStatus As SubSite.CerrelatedStructure.CorrelatedStatus = MetaTags.Collection("CorrelatedStatus")
      If OldStatus <> Status Then
        UpdateCorrelatedLinks = True
      End If
    End If

    MetaTags.AddMetaTag("CorrelatedStatus", Status)

    If AddPhotoAlbum.Checked Then
      If Request.Form("ctl00$ContentPlaceHolder1$PhotoSource") <> "" Then
        Dim NAlbum, N As Integer
        NAlbum = Val(Request.Form("ctl00$ContentPlaceHolder1$PhotoSource"))
        Dim NameAlbum As String = Nothing
        For Each Album As String In Setting.PhotoAlbums
          Dim PhotoAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(Album)
          If PhotoAlbum IsNot Nothing Then
            If NAlbum = N Then
              NameAlbum = PhotoAlbum.Name
            End If
            N = N + 1
            For Each SubPhotoAlbum As PhotoAlbum In PhotoAlbum.PhotoAlbums(False)
              If NAlbum = N Then
                NameAlbum = SubPhotoAlbum.Name
              End If
              N = N + 1
            Next
          End If
        Next
        If NameAlbum <> Nothing Then
          MetaTags.AddMetaTag("PhotoAlbum", NameAlbum)
        End If
      End If
    Else
      MetaTags.RemoveMetaTag("PhotoAlbum")
    End If

    If Request(PhotoList.UniqueID) <> "" Then
      'Add photo
      MetaTags.AddMetaTag("Photo", Request(PhotoList.UniqueID))
    Else
      MetaTags.RemoveMetaTag("Photo")
    End If

    Dim Video As String = ExtrapolateVideoID(VideoID.Text)
    If Video <> "" Then
      'Add video
      MetaTags.AddMetaTag("Video", Video)
    Else
      MetaTags.RemoveMetaTag("Video")
    End If
    If Setting.SEO.AutomaticallyDelimitsBlocksOfCodeInTheText Then
      AddTagSamp(Html.Value)
    End If
    Dim Document As New HtmlDocument(MetaTags, HtmlToXhtml(Html.Value), Language)

    Dim SaveToPage As Integer = NPage
    WriteAll(Document.Html, PageNameFile(Archive, SaveToPage, Language))
    If NPage = 0 Then
      'is a new page
      RedirectToPagesmanager = True
      NewNPage.Value = SaveToPage
      UpdateItemMenu() 'Add a new page to menu
    Else
      UpdateItemMenu()
      'ModifyPageIntoMenu(NPage)
    End If
    MasterPage.AddMessage(Setting, 3020)
    If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
      BlinkPageManegerButton = True
    End If
    If UpdateCorrelatedLinks Then
      Polling.UpdateDefaultLinks.Start()
    End If
  End Sub

  Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
    Dim NameFile As String = MenuManager.PageNameFile(Archive, NPage, Language)
    Dim Code As String = FileManager.ReadAll(NameFile)
    Dim MetaTags As New MetaTags(Code)
    If DeletePermission(MetaTags.Author) Then
      MenuManager.UnSetDescription(Archive, NPage, Language)
      IO.File.Delete(NameFile)
      UpdateItemMenu()
      'Delete comments
      If MetaTags.MetaTag("IdComments") <> 0 Then
        Topic.Delete(ReservedForums.ArchiveComment, MetaTags.MetaTag("IdComments"))
      End If
      MasterPage.AddMessage(Setting, 3019)
    End If
  End Sub

  Private Function DeletePermission(ByVal Author As String) As Boolean
    If CurrentUser.Role(Setting.Name) > Authentication.User.RoleType.AdministratorJunior Or (StrComp(CurrentUser.Username, Author, CompareMethod.Text) = 0 And CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior) Then
      Return True
    End If
    Return False
  End Function

  Sub UpdateItemMenu()
    'Add new page or remove deleted page
    Dim Menu As Menu = Menu.Load(Archive, Language)
    Menu.UpdateItemsMenu()
  End Sub

  Private BlinkPageManegerButton As Boolean
  Public RedirectToPagesmanager As Boolean
  Protected Sub Submit_PreRender(sender As Object, e As System.EventArgs) Handles Submit.PreRender
    'MasterPage.AddButton(Common.ButtonsStandard.PageManager, BlinkPageManegerButton AndAlso IsPostBack)
    Dim GoToUrl As String = Href(Setting.Name, False, "pagesmanager.aspx", "archive", Archive)
    If RedirectToPagesmanager Then
      SetNextMessage(3020)
      Response.Redirect(GoToUrl, True)
    End If
    MasterPage.AddButton(Phrase(Setting.Language, 3018), GoToUrl, , Components.IconType.ControlPanel, , True, , BlinkPageManegerButton AndAlso IsPostBack)
    If Not IsPostBack AndAlso Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
      MasterPage.Blink(Submit)
    End If
  End Sub
End Class
