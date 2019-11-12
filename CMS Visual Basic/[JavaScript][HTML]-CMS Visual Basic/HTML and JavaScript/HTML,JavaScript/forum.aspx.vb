'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
'Imports WebApplication
Imports System.Xml.Serialization
Imports WebApplication

Partial Class PageForum
  Inherits System.Web.UI.Page

  Private MasterPage As MasterPage
  Private Setting As Config.SubSite
  Private CurrentUserPreferences As UserPreferences
  Private Action As ActionType
  Private Forum As ForumManager.Forum
  Private ForumId As Integer
  Private TopicID As Integer
  Private ReplyID As Integer
  Private SubCategory As Integer = -1 ' -1=All categories; 0=All topics not classifieds; N=All topics of this category number 
  Private PageNumber As Integer
  Private FindText As String
  Private UserIsBlockeed As Date
  Private Reference As String
  Private PrivateTopicOfUser As User
  Private CommentsPhoto As Photo
  Private CurrentUser As User

  Protected Sub forum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    CurrentUser = Authentication.CurrentUser
    CurrentUserPreferences = New UserPreferences(CurrentUser)
    MasterPage = Page.Master
    Setting = CurrentSetting()

    Try
      If Request.QueryString(QueryKey.ActionForum) IsNot Nothing Then Action = Request.QueryString(QueryKey.ActionForum)
      If Request.QueryString(QueryKey.ForumId) IsNot Nothing Then ForumId = Request.QueryString(QueryKey.ForumId)
      If Request.QueryString(QueryKey.ReplyId) IsNot Nothing Then ReplyID = Request.QueryString(QueryKey.ReplyId)
      If Request.QueryString(QueryKey.SubCategory) IsNot Nothing Then SubCategory = Request.QueryString(QueryKey.SubCategory)
      If Request.QueryString(QueryKey.PageNumber) IsNot Nothing Then PageNumber = Request.QueryString(QueryKey.PageNumber)
      If Request.QueryString(QueryKey.FindText) IsNot Nothing Then FindText = Request.QueryString(QueryKey.FindText)
    Catch ex As Exception
      RedirectToHomePage(Setting)
    End Try

    If Request.QueryString("SwitchHideSettingPanel") IsNot Nothing Then
      CurrentUserPreferences.HideSettingPanel = Not CurrentUserPreferences.HideSettingPanel
      CurrentUserPreferences.Save(CurrentUser)
      Response.Redirect(Request.ServerVariables("HTTP_REFERER"), True)
      Exit Sub
    End If

    If Request.QueryString("TopicTitle") IsNot Nothing Then
      TopicTitle.Text = Request.QueryString("TopicTitle")
    End If

    If Request.QueryString(QueryKey.Reference) IsNot Nothing Then
      If Request.QueryString(QueryKey.Reference) IsNot Nothing Then
        Reference = Web.HttpUtility.UrlDecode(Request.QueryString(QueryKey.Reference))
      End If
      'End If
      Select Case ForumId
        Case ReservedForums.ArchiveComment
          Dim APL() As String = Split(Reference)
          Dim Html As String = ReadAll(MenuManager.PageNameFile(APL(0), APL(1), APL(2)))
          Dim MetaTags As New MetaTags(Html)
          If MetaTags.MetaTag("IdComments") <> "" Then
            TopicID = MetaTags.MetaTag("IdComments")
          End If
          PrivateTopicOfUser = Authentication.User.Load(MetaTags.Author)
        Case ReservedForums.PhotoComment
          CommentsPhoto = Photo.Load(Reference)
          If CommentsPhoto IsNot Nothing Then
            TopicID = CommentsPhoto.IdComments
            PrivateTopicOfUser = Authentication.User.Load(CommentsPhoto.Author)
          End If
        Case ReservedForums.PrivateMessage
          PrivateTopicOfUser = Authentication.User.Load(Reference)
          If PrivateTopicOfUser IsNot Nothing Then
            TopicID = PrivateTopicOfUser.MessageBoard
          End If
      End Select
    Else
      Try
        If Not Request.QueryString(QueryKey.TopicId) Is Nothing Then TopicID = Request.QueryString(QueryKey.TopicId)
      Catch ex As Exception
        RedirectToHomePage(Setting)
      End Try
    End If
    If ForumForInsideUse(ForumId) AndAlso TopicID = 0 AndAlso Action <> ActionType.NewTopic Then
      Dim RedirectUrl As String = ForumManager.Link(ActionType.NewTopic, Setting.Name, , Edit.ClientID, ForumId, , , , , , , Reference, SubCategory)
      Response.Redirect(RedirectUrl)
    End If

    TryBlock(Setting)
    If ForumId = 0 Then
      If Setting.Forums IsNot Nothing Then
        If Setting.Forums.Length = 1 Then
          ForumId = Setting.Forums(0)
        End If
      End If
    End If
    If ForumId Then
      Forum = ForumManager.Forum.Load(ForumId)
      If Forum Is Nothing Then
        RedirectToHomePage(Setting)
      End If
    End If
    Select Case Action
      Case ActionType.SetSubcategory
        If Request.UrlReferrer IsNot Nothing Then
          Dim Topic As Topic = Topic.Load(ForumId, TopicID)

          If Topic.SubCategory <> 0 Then
            Dim [Sub] As ForumStructure.Category.Subcategory = Forum.SubCategory(Topic.SubCategory)
            If [Sub] IsNot Nothing Then
              [Sub].TotalTopics -= 1
            End If
          End If
          If SubCategory > 0 Then
            Dim [Sub] As ForumStructure.Category.Subcategory = Forum.SubCategory(SubCategory)
            [Sub].TotalTopics += 1
          End If

          Topic.SubCategory = SubCategory
          Topic.Save()
          Forum.ForumStructure.Save()

          Response.Redirect(Request.UrlReferrer.AbsoluteUri)
        Else
          Response.End()
        End If
      Case ActionType.ShowRSS
        Dim rssFeed As New FeedRSSManager.rss
        rssFeed.channel.title = Phrase(Setting.Language, 61) & " " & Setting.Title
        rssFeed.channel.description = "© " & Year(Now.ToUniversalTime) & " " & Phrase(Setting.Language, 61) & " " & PathCurrentUrl()
        rssFeed.channel.link = ForumManager.Link(ActionType.Show, Setting.Name, True, , ForumId, TopicID)  'Page.AbsoluteUri(Request)
        rssFeed.channel.language = Acronym(Setting.Language)
        FeedRssForum(rssFeed, Setting, EnableShowHidden, ForumId, TopicID, SubCategory)
        Response.ContentType = "text/xml;charset=utf-8"
        FeedRSSManager.RssFeedGenerator(Response.OutputStream, rssFeed)
        Response.End()
      Case ActionType.ShowXML
        Dim Replies() As XmlReply = Nothing
        Dim Topic As Topic = Topic.Load(ForumId, TopicID)
        If Topic IsNot Nothing Then
          For Each Reply As Reply In Topic.Replies(False)
            If Replies Is Nothing Then
              ReDim Replies(0)
            Else
              ReDim Preserve Replies(UBound(Replies) + 1)
            End If
            Replies(UBound(Replies)) = Reply.XmlReply
          Next
        End If

        Response.ContentType = "text/xml;charset=utf-8"

        Dim xml As New XmlSerializer(GetType(XmlReply()))
        Dim xmlns As New XmlSerializerNamespaces
        xmlns.Add(String.Empty, String.Empty)
        xml.Serialize(Response.OutputStream, Replies, xmlns)
        Response.End()
      Case ActionType.ChatModeRefresh
        Dim LastRefresh As Date = TextToDate(Request.QueryString("now"))
        Dim Refresh As Boolean
        If DateLastPost(ForumId, TopicID) > LastRefresh Then
          Refresh = True
        End If
        Response.ContentType = "text/xml;charset=utf-8"
        Dim xml As New XmlSerializer(GetType(Boolean))
        Dim xmlns As New XmlSerializerNamespaces
        xmlns.Add(String.Empty, String.Empty)
        xml.Serialize(Response.OutputStream, Refresh, xmlns)
        Response.End()
      Case ActionType.Reply, ActionType.NewTopic, ActionType.Modify
        RegisterAnonimus()
        UserIsBlockeed = IsBlockedUntil(CurrentUser)
    End Select

    SetMasterPage(Me, , False, True)
    'Template = Common.LoadTemplate(Me, Setting, True, , False, False)
    'Setting language


    If ForumId Then
      'Verify if this ForumId exists in this configuration
      Dim Exists As Boolean
      If Setting.Forums IsNot Nothing Then
        For Each Forum As Integer In Setting.Forums
          If ForumId = Forum Then
            Exists = True
          End If
        Next
      End If
      If Exists = True OrElse ForumForInsideUse(ForumId) Then
        ForumInitialize(Forum, Setting.Language)
        If Not ForumForInsideUse(ForumId) Then
          'Add Button FotoAlbum
          Dim Button As Control = MasterPage.AddButton(Phrase(Setting.Language, 103, 61), HrefPhotoAlbum(Forum.PhotoAlbum, Setting), , Components.IconType.FolderPics)
          AddFotoAlbumSlideShow(Setting, Button, Forum.PhotoAlbum)
        End If
      Else
        'Redirect to appropriate domain if the forum is not associated to this configuration
        Dim TryDomain As DomainConfiguration
        For Each DomainName As String In AllDomainNames()
          TryDomain = DomainConfiguration.Load(DomainName)
          If TryDomain IsNot Nothing Then
            For Each SubSite As SubSite In TryDomain.SubSites
              If SubSite.Forums IsNot Nothing Then
                For Each Forum As Integer In SubSite.Forums
                  If Forum = ForumId Then
                    'redirect
                    Dim Redirect As String '= HttpContext.Current.Request.Url.Scheme & "://" & TryDomain.Name & HttpContext.Current.Request.Url.PathAndQuery

                    Dim Uri As New Uri(AbsoluteUri(HttpContext.Current.Request))
                    Dim NameValues As NameValueCollection = HttpUtility.ParseQueryString(Uri.Query)
                    Dim KeyValue(-1) As String
                    For Each Key In NameValues.AllKeys
                      If Key <> "ss" Then
                        ReDim Preserve KeyValue(UBound(KeyValue) + 2)
                        KeyValue(UBound(KeyValue)) = NameValues(Key)
                        KeyValue(UBound(KeyValue) - 1) = Key
                      End If
                    Next
                    Redirect = Href(Config.DomainConfiguration.Load(DomainName), SubSite.Name, True, "forum.aspx", KeyValue)

                    'Dim P As Integer
                    'Dim Value As String = NameValue.Get("v")


                    'HttpContext.Current.Response.Redirect(Redirect)
                    Response.RedirectPermanent(Redirect, True)
                  End If
                Next
              End If
            Next
          End If
        Next
        Response.Redirect(Href(Setting.Name, False, "default.aspx"))
      End If
    End If

  End Sub

  Private s As Date
  Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    SetVisualization()
  End Sub

  Public Sub SetVisualization()
    If UserIsBlockeed <> Nothing Then
      Edit.Visible = False
      Dim MasterPage As MasterPage = Page.Master : MasterPage.AddMessage(Phrase(Setting.Language, 3196) & " " & UserIsBlockeed.AddSeconds(CurrentUser.TimeOffsetSeconds).ToString(Setting.DateTimeFormat, Setting.Culture), Setting)
    Else
      Select Case Action
        Case ActionType.RequireCensore, ActionType.RequireDelete, ActionType.RequireAdmonish
        Case ActionType.NewTopic, ActionType.Reply, ActionType.Modify
          If Forum.Type = ForumManager.Forum.TypeOfForum.TicketSystem Then
            SelectPhoto.Visible = False
            UploadPhoto.Visible = False
            SetVideo.Visible = False
          End If
          If ForumForInsideUse(ForumId) Then
            If CurrentUser.NamePhotoAlbum = "" Then
              UploadPhoto.Visible = False
            End If
          End If
          If UploadPhoto.Visible Then
            ImgInputFile.Attributes.Add("onchange", "SetImgTitle()")
            MasterPage.Page.Header.Controls.Add(Script("function SetImgTitle(){if (document.getElementById('ImgDescription').value==''){var Description=prompt('" & AbjustForJavascriptString(Phrase(Setting.Language, 104).ToUpper & ": " & Phrase(Setting.Language, 56, 102)) & "','');if (Description!=null){document.getElementById('ImgDescription').value=Description}}}", ScriptLanguage.javascript))
          End If
          Select Case Action
            Case ActionType.NewTopic
              RedirectBannedUser(Setting)
              'Show keywords fielsd
              If Not ForumForInsideUse(ForumId) Then
                ShowKeywordsFielsd()
              End If
              'Hide quote
              SetPhotoList(CurrentUser, Request.Form(PhotoList.UniqueID))
              QuoteRow.Visible = False
              'Edit.Rows(1).Visible = False
              If ForumForInsideUse(ForumId) Then
                Display.Controls.Add(TitleTopicCtrl(ForumId, TopicID, Setting, Master, Reference))
                'Edit.Rows(0).Visible = False 'Title
                TitleRow.Visible = False
              End If
            Case ActionType.Reply, ActionType.Modify
              RedirectBannedUser(Setting)
              If TopicID = 0 Then
                'Edit forum
                If CurrentUser.Role(Setting.Name) >= ForumManager.Forum.ToolsAccess Then
                  Dim Save As SaveObjectMethod = Sub()
                                                   Forum.Save(True)
                                                 End Sub
                  EditObject(Forum, Save, Phrase(Setting.Language, 74, 61), , , , , False, {"TotalTopics", "RelatedArchive"})
                End If
              ElseIf TopicID <> 0 And ForumId <> 0 Then
                If Action = ActionType.Reply Then
                  Display.Controls.Add(ForumManager.ShowTopic(Setting, ForumId, TopicID, PageNumber, CurrentUserPreferences.ShowCensored, CurrentUserPreferences.ShowAvatars, False, Page, Action, Edit.ClientID, True, LinksCorrelated, True, True))
                End If
                Label2.Text = Phrase(Setting.Language, 73)
                If Action = ActionType.Reply Then
                  SetPhotoList(CurrentUser, Request.Form(PhotoList.UniqueID))
                  TitleRow.Visible = False
                  If ReplyID Then
                    Dim Reply As Reply = Reply.Load(ForumId, TopicID, ReplyID)
                    If Reply.AuthorAccount IsNot Nothing Then
                      QuoteAuthor.Controls.Add(QuickInfoUserExternalAccount(Reply.Author, Reply.AuthorAccount))
                    Else
                      QuoteAuthor.Controls.Add(QuickInfoUser(Setting, Authentication.User.Load(Reply.Author), Forum))
                    End If
                    'Set quote
                    If Request.Form(Quote.ID) <> "" Then
                      Quote.Text = Request.Form(Quote.ID)
                    Else
                      Quote.Text = Common.InnerText(HttpUtility.HtmlDecode(Reply.TextReply))
                    End If
                  Else
                    'Hide quote
                    QuoteRow.Visible = False
                  End If
                Else 'Modify
                  Dim Source As Reply = Reply.Load(ForumId, TopicID, ReplyID)
                  If ReplyID = 1 Then
                    If Not ForumForInsideUse(ForumId) Then
                      ShowKeywordsFielsd()
                      Keywords.Text = Source.Keywords
                    End If
                  End If
                  If Source.AuthorAccount Is Nothing Then
                    SetPhotoList(Authentication.User.Load(Source.Author), Source.Photo)
                  End If
                  If AbleToModifyReply(Setting, Source.Author, Source.Created, Source.AuthorAccount) Then
                    If ReplyID = 1 AndAlso Not ForumForInsideUse(ForumId) Then
                      'Edit.Rows(0).Visible = True 'Title
                      TitleRow.Visible = True
                      If Not IsPostBack Then
                        TopicTitle.Text = Source.Title
                      End If
                    Else
                      'Edit.Rows(0).Visible = False 'Title
                      TitleRow.Visible = False
                    End If
                    If Source.TextQuote <> "" Then
                      Dim Control As Control
                      Dim Reply As Reply = Reply.Load(ForumId, TopicID, Source.QuoteID)
                      If Reply.AuthorAccount Is Nothing Then
                        Control = QuickInfoUser(Setting, Authentication.User.Load(Reply.Author), Forum)
                      Else
                        Control = QuickInfoUserExternalAccount(Reply.Author, Reply.AuthorAccount)
                      End If
                      QuoteAuthor.Controls.Add(Control)
                      QuoteRow.Visible = True
                      'Edit.Rows(1).Visible = True 'Quote
                      If Not IsPostBack Then
                        Quote.Text = HttpUtility.HtmlDecode(Common.InnerText(Source.TextQuote))
                      End If
                    Else
                      QuoteRow.Visible = False
                      'Edit.Rows(1).Visible = False 'Quote
                    End If
                    'Edit.Rows(2).Visible = True 'Topic Text

                    If Not IsPostBack Then
                      TopicText.Text = HttpUtility.HtmlDecode(Common.InnerText(Source.TextReply))
                      VideoID.Text = Source.Video
                    End If
                  Else
                    'Block not abled users
                    Response.Clear()
                    Response.End()
                  End If
                End If
                Page.Form.Controls.Add(Components.Script("document.getElementById(""" & TopicText.ClientID & """).focus", ScriptLanguage.vbscript))
              End If
          End Select
        Case Else 'SHOW AND EQUIVALENTS
          'Add chat preview
          If PluginManager.IsEnabled(Setting, "Chat") Then
            ChatPreview.Controls.Add(ChatManager.ChatPreview(DefaultChatRoom, Setting))
          End If
          Edit.Visible = False
          If TopicID Then
            If PageNumber = 0 AndAlso Not ForumForInsideUse(ForumId) Then
              Dim Topic As Topic = Topic.Load(ForumId, TopicID)
              If Topic IsNot Nothing Then
                Dim Redirect As String = ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId, TopicID, , Topic.TotalPages(CurrentUserPreferences.ShowCensored))
                Response.RedirectPermanent(Redirect, True)
              End If
            End If

            Display.Controls.Add(ForumManager.ShowTopic(Setting, ForumId, TopicID, PageNumber, CurrentUserPreferences.ShowCensored, CurrentUserPreferences.ShowAvatars, , Page, Action, Edit.ClientID, True, LinksCorrelated, True, True))

          Else
            If ForumId = 0 Then
              'show forums list
              Display.Controls.Add(ForumList(Setting))
            Else
              If Page.IsPostBack Then
                'Intercept find request
                FindText = Find.Text
                If LTrim(FindText) = "" Then
                  Action = ActionType.Show
                  Response.Redirect(ForumManager.Link(Action, Setting.Name, , , ForumId, , , , , , , , SubCategory), True)
                Else
                  'Log("search", 1000, CurrentUserPreferences.UseInternalSearchEngine, Request.UserAgent, FindText)
                  Action = Request.Form(FindCriterion.UniqueID)
                  If CurrentUserPreferences.UseInternalSearchEngine Then
                    Response.Redirect(ForumManager.Link(Action, Setting.Name, , , ForumId, , , , , FindText, , , SubCategory), True)
                  Else
                    Dim Criterion As Common.GoogleSearch.GoogleSearchCriterion
                    Select Case Action
                      Case ActionType.FindAllWords
                        Criterion = GoogleSearch.GoogleSearchCriterion.All
                      Case ActionType.FindOneWords
                        Criterion = GoogleSearch.GoogleSearchCriterion.Once
                      Case ActionType.FindPhrase
                        Criterion = GoogleSearch.GoogleSearchCriterion.Phrase
                    End Select
                    Response.Redirect(Common.GoogleSearch.SearchUrl(FindText, Criterion), True)
                  End If
                End If
              Else
                Find.Text = Request.QueryString("s")
              End If

              'Set RSS link
              'Message.Controls.Add(RssButton(Link(ActionType.ShowRSS, Setting.Name, , ForumId)))
              'Show search instrument
              'If CurrentUserPreferences.UseInternalSearchEngine Then
              FindPanel.Visible = True
              'Else
              'SearchEngine.Visible = True
              ''Use Google search engine
              '  SearchEngine.Controls.Add(IFrame(500, 90, Common.Href(Setting.Name, False, "forum.aspx", "a", ActionType.CodeSearchEngine)))
              'End If
              'show list of topics
              Dim PhraseID As Integer = 3042
              Dim Selected As Integer
              If Request.Form(FindCriterion.UniqueID) <> "" Then
                Selected = Request.Form(FindCriterion.UniqueID)
              End If
              For N As ActionType = ActionType.FindAllWords To ActionType.FindOneWords
                Dim Item As New WebControls.ListItem(Phrase(Setting.Language, PhraseID), N)
                PhraseID += 1
                If N = Selected Then
                  Item.Selected = True
                End If
                FindCriterion.Items.Add(Item)
              Next

              If CurrentUser.Role(Setting.Name) >= ForumManager.Forum.ToolsAccess Then
                'Add tools button to edit this forum
                Forum.AddButtons(Setting, MasterPage)
              End If

              'If Forum.Name <> "" Then
              '	Dim h1 As New WebControl(HtmlTextWriterTag.H1)
              '	H1.Controls.Add(New LiteralControl(Forum.Name))
              '	Display.Controls.Add(H1)
              'End If

              'If Forum.Description <> "" Then
              '	Dim H2 As New WebControl(HtmlTextWriterTag.H2)
              '	H2.Controls.Add(New LiteralControl(Forum.Description))
              '	Display.Controls.Add(H2)
              'End If

              If Forum.ForumStructure.Categories.Count = 0 OrElse Request.QueryString("c") <> "" Then
                'Display.Controls.Add(Forum.TitleControl(Setting))
                Display.Controls.Add(ShowTopicsList(CurrentUser, Setting, ForumId, CurrentUserPreferences.ShowCensored, PageNumber, , SubCategory, Action, FindText, Page, True))
              Else
                Display.Controls.Add(Forum.Summary(Setting))
                Display.Controls.Add(ShowTopicsByCategory(CurrentUser, Setting, ForumId, CurrentUserPreferences.ShowCensored, Page))
              End If
            End If
          End If
          Select Case Action
            Case ActionType.Show
              If CurrentUserPreferences.ChatMode = True And PageNumber = 0 Then
                If Request.Browser.VBScript Then
                  Dim Control As New Control
                  Dim Src As String = ForumManager.Link(ActionType.ChatModeRefresh, , , , ForumId, TopicID) & "&now=" & HttpUtility.UrlEncode((DateToText(Now.ToUniversalTime)))

                  Dim XmlRefresh As New LiteralControl
                  XmlRefresh.Text = "<xml id=UPD src=""""></xml>"
                  Control.Controls.Add(XmlRefresh)

                  'vbscript"
                  Dim ScriptCheck As String = _
                  "if lcase(document.all.UPD.recordset(0))=""true"" then document.location.reload"
                  Control.Controls.Add(Components.Script(ScriptCheck, Components.ScriptLanguage.vbscript, "UPD", "ondatasetcomplete"))
                  Dim Script As String = _
                  "IDTimer = window.setInterval (""UPD()"",30000)" & vbCrLf & _
                  "Sub UPD()" & vbCrLf & _
                  "  document.all.UPD.src=""" & Src & """ & ""&nowclient="" & now " & vbCrLf & _
                  "End Sub" & vbCrLf
                  Control.Controls.Add(Components.Script(Script, Components.ScriptLanguage.vbscript))

                  'javascript:
                  'Dim ScriptCheck As String = _
                  '"if(document.all.UPD.recordset(0).toLowerCase==""true""){ document.location.reload }"
                  'Control.Controls.AddAt(0, Components.Script(ScriptCheck, Components.ScriptLanguage.javascript, "UPD", "ondatasetcomplete"))
                  'Dim Script As String = _
                  '"IDTimer = window.setInterval (""UPD()"",30000);" & vbCrLf & _
                  '"function UPD(){" & vbCrLf & _
                  '   "document.all.UPD.src=""" & Src & """;" & vbCrLf & _
                  '"}" & vbCrLf
                  'Control.Controls.Add(Components.Script(Script, Components.ScriptLanguage.javascript))

                  MasterPage.ContentPlaceHolder.Controls.Add(Control)
                End If
              End If
            Case ActionType.Subscribe, ActionType.Unsubscribe
              Dim Subscription As New Subscription(ForumId, TopicID)
              Dim Author As String = Request.QueryString(QueryKey.User)
              If Author = "" Then
                Author = CurrentUser.Username
              End If
              Select Case Action
                Case ActionType.Subscribe
                  Subscription.IsSubscript(Author, DomainName(Request), Setting.Name) = Subscription.TypeSubscription.IsTrue
                  Dim MasterPage As MasterPage = Page.Master : MasterPage.AddMessage(Phrase(Setting.Language, 3058), Setting)
                Case ActionType.Unsubscribe
                  Subscription.IsSubscript(Author, DomainName(Request), Setting.Name) = Subscription.TypeSubscription.IsFalse
                  Dim MasterPage As MasterPage = Page.Master : MasterPage.AddMessage(Phrase(Setting.Language, 3057), Setting)
              End Select
          End Select
          If CurrentUserPreferences.HideSettingPanel = False Then
            Preferences.Visible = True
            AutoSubsctiption.Checked = CurrentUser.AutoForumSubscription
            HideSettingPanel.Checked = CurrentUserPreferences.HideSettingPanel
            ShowCensored.Checked = CurrentUserPreferences.ShowCensored
            If CurrentUser.GeneralRole < Authentication.User.RoleType.Senior Then
              ShowCensored.Enabled = False
            End If
            ChatMode.Checked = CurrentUserPreferences.ChatMode
            UseInternalSearchEngine.Checked = CurrentUserPreferences.UseInternalSearchEngine
            ShowAvatars.Checked = CurrentUserPreferences.ShowAvatars
          Else
            Preferences.Visible = False
            If CurrentUser.GeneralRole > Authentication.User.RoleType.Visitors Then
              'AddButton Setting
              Dim Text As String
              Dim Href As String
              Text = Phrase(Setting.Language, 3067)
              Href = ForumManager.Link(Action, Setting.Name, , Preferences.ClientID, ForumId, , , , , , True)
              MasterPage.AddButton(Text, Href, Phrase(Setting.Language, 61) & ": " & Text, Components.IconType.ControlPanel)
            End If
          End If
      End Select
      If Edit.Visible = True Then
        If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
          MasterPage.Blink(Button1)
        End If
        MasterPage.ShowRightBar = False
        AddEmoticonsTool(Emotions, TopicText)
        Requiredfieldvalidator1.Visible = True
        Requiredfieldvalidator2.Visible = True
      End If
    End If
  End Sub

  Sub ShowKeywordsFielsd()
    KeywordsRow.Visible = True
  End Sub

  Private Function ExtrapolateWords(ByVal Title As String) As String()
    If Title <> "" Then
      Dim TitleTransform As New StringBuilder(Title.Length)
      For Each Chr As Char In Title.ToCharArray
        If Char.IsLetterOrDigit(Chr) Then
          TitleTransform.Append(Chr)
        Else
          TitleTransform.Append(" ")
        End If
      Next
      Dim Words() As String = Split(TitleTransform.ToString)
      Dim NewWords() As String = Nothing
      For Each Word As String In Words
        If Len(Word) > 4 Then
          If NewWords Is Nothing Then
            ReDim NewWords(0)
          Else
            ReDim Preserve NewWords(UBound(NewWords) + 1)
          End If
          NewWords(UBound(NewWords)) = LCase(Word)
        End If
      Next
      Return NewWords
    End If
    Return Nothing
  End Function

  Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
    args.IsValid = args.Value.Length <= Setup.Forum.MaxLengthReply
  End Sub

  Private Sub CustomValidator2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
    args.IsValid = Not EmailPresent(args.Value)
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.Visitors Then
      If Not CurrentUser.ProxyUse OrElse Setup.Security.EnableProxyUsersToInteract = True Then
        Dim IsValid As Boolean
        If ForumForInsideUse(ForumId) Then
          Requiredfieldvalidator1.Enabled = False
        End If

        Select Case Action
          Case ActionType.NewTopic
            IsValid = Page.IsValid
          Case ActionType.Reply
            IsValid = Requiredfieldvalidator2.IsValid And CustomValidator1.IsValid And CustomValidator2.IsValid
          Case ActionType.Modify
            Select Case ReplyID
              Case 1
                IsValid = Page.IsValid
              Case Else
                IsValid = Requiredfieldvalidator2.IsValid And CustomValidator1.IsValid And CustomValidator2.IsValid
            End Select
        End Select
        If IsValid Then
          'verify if text contain a Censore word
          If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.AdministratorJunior Then
            If ContainCensoredWord(TopicText.Text) Then
              BlockUser()
            End If
          End If
          'Abjust Test, Title and Quote
          Dim Text As String = Normalize(TopicText.Text)
          Text = HttpUtility.HtmlEncode(Text)
          Text = ReplaceBin(Text, vbCr, "<br />")
          If Setting.SEO.AutomaticallyDelimitsBlocksOfCodeInTheText Then
            AddTagSamp(Text)
          End If
          Dim QuoteText As String = HttpUtility.HtmlEncode(Normalize(Quote.Text))
          QuoteText = ReplaceBin(QuoteText, vbCr, "<br />")
          Dim Title As String
          Dim Keywords As String = Trim(Me.Keywords.Text)
          If ForumForInsideUse(ForumId) Then
            Title = Reference
          Else
            Title = Normalize(TopicTitle.Text)
          End If
          Dim PhotoID As String = Request.Form(PhotoList.UniqueID)
          Dim Video As String = ExtrapolateVideoID(VideoID.Text)

          'Upload photo
          Try
            If ImgInputFile.PostedFile.ContentLength <> 0 Then
              Dim Photo As New PhotoManager.Photo
              If ForumForInsideUse(ForumId) Then
                Photo.Album = CurrentUser.NamePhotoAlbum
              Else
                Photo.Album = Forum.PhotoAlbum
              End If
              If Photo.Album <> "" Then
                Photo.FromStream(ImgInputFile.PostedFile.InputStream)
                If ImgDescription.Value <> "" Then
                  Photo.Description(Setting.Language) = ImgDescription.Value
                End If
                If ImgTitle.Value <> "" Then
                  Photo.Title(Setting.Language) = ImgTitle.Value
                ElseIf ForumForInsideUse(ForumId) AndAlso Title <> "" Then
                  Photo.Title(Setting.Language) = Title
                End If
                Photo.Save(CurrentUser)
                Photo.Dispose()
                ImgInputFile.Dispose()
                PhotoID = Photo.NameCode
              End If
            End If
          Catch ex As Exception
            'MESSAGE ERROR: Format not valid!
            MasterPage.AddMessage(Setting, 428)
          End Try

          Select Case Action
            Case ActionType.NewTopic, ActionType.Reply
              'No resend identical message!
              If MySession("ForumLastText") <> Text Then
                MySession("ForumLastText") = Text
                Dim Topic As Topic = Nothing
                Dim NewReply As Reply = Nothing
                Select Case Action
                  Case ActionType.NewTopic
                    Topic = New Topic(ForumId, SubCategory, CurrentUser.Username, Title, Keywords, Text, PhotoID, Video, , Reference)
                    TopicID = Topic.ID
                    'If PrivateTopicOfUser IsNot Nothing Then
                    Select Case ForumId
                      Case ReservedForums.PrivateMessage
                        'Topic.Reference = PrivateTopicOfUser.Username
                        'Topic.Reference = Reference
                        PrivateTopicOfUser.MessageBoard = TopicID
                        PrivateTopicOfUser.Save()
                      Case ReservedForums.ArchiveComment
                        'Topic.Reference = Reference
                        Dim APL() As String = Split(Reference)
                        Dim File As String = MenuManager.PageNameFile(APL(0), APL(1), APL(2))
                        Dim HtmlDocument As New HtmlDocument(File)
                        HtmlDocument.MetaTags.AddMetaTag("IdComments", TopicID)
                        HtmlDocument.Save(File)
                      Case ReservedForums.PhotoComment
                        'Topic.Reference = Reference
                        CommentsPhoto.IdComments = TopicID
                        CommentsPhoto.Save()
                      Case Else
                        'Send notification
                        If Forum.Type = ForumManager.Forum.TypeOfForum.TicketSystem Then
                          SendEmailNotification(Setting, Topic)
                        End If
                    End Select
                    'End If
                    NewReply = Topic.FirstReply
                  Case ActionType.Reply
                    Topic = Topic.Load(ForumId, TopicID)
                    If Topic.Closed Then
                      SetNextMessage(2025)
                      Response.Redirect(Request.UrlReferrer.AbsoluteUri, True)
                    End If
                    If Topic.AsResolved Then
                      Topic.AsResolved = False
                      Topic.Save()
                    End If
                    SubCategory = Topic.SubCategory
                    'If reply as Censored message, this reply must be Censored
                    Dim Censored As Boolean
                    If ReplyID Then
                      Dim Quote As Reply = Reply.Load(ForumId, TopicID, ReplyID)
                      If Quote IsNot Nothing Then
                        Censored = Quote.Censored
                      End If
                    End If
                    NewReply = New Reply(ForumId, TopicID, CurrentUser.Username, "", Keywords, Text, QuoteText, ReplyID, PhotoID, Video, Censored)
                End Select

                'set date last reply (used for "chat mode")
                DateLastPost(ForumId, TopicID) = Now.ToUniversalTime
                DateLastPost(ForumId) = Now.ToUniversalTime

                'Auto subscription
                Dim Subscription As New Subscription(ForumId, TopicID)
                Dim Author As String = CurrentUser.Username
                If Subscription.IsSubscript(Author) = Subscription.TypeSubscription.NotDefinited Then
                  If CurrentUser.AutoForumSubscription Then
                    Subscription.IsSubscript(Author, DomainName(Request), Setting.Name) = Subscription.TypeSubscription.IsTrue
                  Else
                    Subscription.IsSubscript(Author, DomainName(Request), Setting.Name) = Subscription.TypeSubscription.IsFalse
                  End If
                End If

                'Subscribe user of this message board
                If Action = ActionType.NewTopic AndAlso ForumForInsideUse(ForumId) = True Then
                  If PrivateTopicOfUser IsNot Nothing AndAlso PrivateTopicOfUser.Username <> "" Then
                    Author = PrivateTopicOfUser.Username
                    If Subscription.IsSubscript(Author) = Subscription.TypeSubscription.NotDefinited Then
                      If CurrentUser.AutoForumSubscription Then
                        Subscription.IsSubscript(Author, PrivateTopicOfUser.DomainName, PrivateTopicOfUser.SubSite) = Subscription.TypeSubscription.IsTrue
                      Else
                        Subscription.IsSubscript(Author, PrivateTopicOfUser.DomainName, PrivateTopicOfUser.SubSite) = Subscription.TypeSubscription.IsFalse
                      End If
                    End If
                  End If
                End If

                'Send all subscriptions
                Dim Authors As New Collections.Specialized.StringCollection
                Authors.Add(Author)

                Dim TitleNotification As String = Nothing
                If ForumForInsideUse(ForumId) Then
                  Select Case ForumId
                    Case ReservedForums.PrivateMessage
                      TitleNotification = Phrase(Setting.Language, 121, 413) & " " & Topic.FirstReply.Title
                    Case ReservedForums.ArchiveComment
                      Dim APL() = Split(Topic.Reference)
                      Dim Html As String = ReadAll(MenuManager.PageNameFile(CInt(APL(0)), CInt(APL(1)), CInt(APL(2))))
                      Dim MetaTags As New MetaTags(Html)
                      TitleNotification = Phrase(Setting.Language, 128) & " """ & MetaTags.Title & """"
                    Case ReservedForums.PhotoComment
                      'Dim Photos As New Photo(Title)
                      TitleNotification = Phrase(Setting.Language, 128, 104) & " """ & CommentsPhoto.Title(Setting.Language) & """"
                  End Select
                Else
                  TitleNotification = Topic.FirstReply.Title
                End If
                If Action = ActionType.Reply Then
                  If Not ReplyMomentarilyHidden(NewReply, False, Topic) Then 'not send notification if Author is a new user and this reply is now momentanly hidden
                    For Each Reply As Reply In Topic.AllReplies(ForumId, TopicID, True, True)
                      If Reply.Author <> "" AndAlso Reply.AuthorAccount Is Nothing Then
                        Author = Reply.Author
                        If Not Authors.Contains(Author) Then
                          Authors.Add(Author)
                          'Send subscription
                          If Subscription.IsSubscript(Author) = Subscription.TypeSubscription.IsTrue Then
                            Subscription.SendNotification(Authentication.User.Load(Author), TitleNotification)
                          End If
                        End If
                      End If
                    Next
                  End If
                End If
                Dim PostType As ForumPostType
                If Action = ActionType.NewTopic Then
                  PostType = ForumPostType.NewTopic
                Else
                  PostType = ForumPostType.NewReply
                End If
                RaiseForumReplyPostedEvent(Forum, NewReply, PostType, Setting)

              End If

              If ForumForInsideUse(ForumId) OrElse CurrentUserPreferences.ChatMode Then
                Select Case ForumId
                  Case ReservedForums.PhotoComment
                    Dim Param As String() = Split(Reference, ".")
                    Response.Redirect(HrefPhoto(Param(0), Param(1), Setting))
                  Case Else
                    Response.Redirect(ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId, TopicID), True)
                End Select
              Else
                Response.Redirect(ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId, , , , , , , , SubCategory), True)
              End If
            Case ActionType.Modify
              Dim Topic As Topic = Topic.Load(ForumId, TopicID)
              If Topic.Closed Then
                SetNextMessage(2025)
                Response.Redirect(Request.UrlReferrer.AbsoluteUri, True)
              End If
              Dim Reply As Reply = Reply.Load(ForumId, TopicID, ReplyID)
              Reply.Title = Title
              Reply.Keywords = Keywords
              Reply.TextQuote = QuoteText
              Reply.TextReply = Text
              Reply.Modified = Now.ToUniversalTime
              Reply.Photo = PhotoID
              Reply.Video = Video
              Reply.Save()
              RaiseForumReplyPostedEvent(Forum, Reply, ForumPostType.Modify, Setting)
              Response.Redirect(ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId, TopicID), True)
          End Select
        Else
          Dim MasterPage As MasterPage = Page.Master : MasterPage.AddMessage(Phrase(Setting.Language, 27), Setting)
        End If
      End If
    End If
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    CurrentUser.AutoForumSubscription = AutoSubsctiption.Checked
    CurrentUserPreferences = New UserPreferences(HideSettingPanel.Checked, ChatMode.Checked, ShowCensored.Checked, UseInternalSearchEngine.Checked, ShowAvatars.Checked)
    CurrentUserPreferences.Save(CurrentUser)
  End Sub

  Sub SetPhotoList(ByVal Author As Authentication.User, Optional ByVal SelectPhoto As String = Nothing)
    If Me.SelectPhoto.Visible Then
      PhotoManager.SetPhotoList(PhotoList, imgpreview, Setting, SelectPhoto, 0, JavascriptPhotosList(Setting, Forum.PhotoAlbum, Nothing, Author.NamePhotoAlbum), JavascriptPhotosList(Setting, Forum.PhotoAlbum, Author.Username, Author.NamePhotoAlbum))
      Radio1.Attributes.Add("onclick", "javascript:" & "LoadSource(0)")
      Radio2.Attributes.Add("onclick", "javascript:" & "LoadSource(1)")
      Radio1.Checked = True
      Dim Code As String = "LoadSource(0);"
      PhotoList.Parent.Controls.Add(Script(Code, ScriptLanguage.javascript))
    End If
  End Sub
End Class
