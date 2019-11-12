Imports WebApplication

Partial Class MasterPageModel
  Inherits Components.MasterPage
  Shared CodeClickToSearch As String
  Public TitlePage As String
  Private m_UseGoogleOff As Boolean = Setup.SEO.GoogleOffGoogleOnTagsEnabled
  Private m_AdSenseDisabled As Boolean
  Private m_Description As String
  Private m_Author As String
  Private m_KeyWords As String
  Private m_Language As String
  Private m_MetaRevisitAfterDays As Integer = Config.MetaRevisitAfterDays
  Private TraceControls() As Control
  Private MetaRobots As New HtmlMeta
  Private AuthorOff As Boolean

  Public Overrides Property Setting() As SubSite
  Public Overrides Property User As User = CurrentUser
  Public Overrides Property Rating As Integer

  Public Overrides Property UseGoogleOff() As Boolean
    Get
      Return m_UseGoogleOff
    End Get
    Set(ByVal value As Boolean)
      m_UseGoogleOff = value
    End Set
  End Property

  'Overrides
  Public Overrides Property AdSenseDisabled() As Boolean
    Get
      Return m_AdSenseDisabled
    End Get
    Set(ByVal value As Boolean)
      m_AdSenseDisabled = value
    End Set
  End Property

  Public Overrides Function AddButton(ByVal Text As String, ByVal Href As String, Optional ByVal ToolTip As String = Nothing, Optional ByVal Icon As IconType = Nothing, Optional ByVal Target As TargetForButton = TargetForButton.Self, Optional ByVal Nofollow As Boolean = False, Optional ByVal OnClick As String = Nothing, Optional Blink As Boolean = False) As WebControl
    Return ToolsBarAddButton(ToolsBar, Text, Href, ToolTip, Icon, Target, Nofollow, OnClick, Blink)
  End Function

  Public Overrides Sub AddButton(ByVal Button As ButtonsStandard, Optional Blink As Boolean = False)
    Select Case Button
      Case ButtonsStandard.NewPage
        Me.AddButton(Phrase(Setting.Language, 3013), Href(Setting.Name, False, "edit.aspx"), , Components.IconType.DocumentBlank, , True, , Blink)
      Case ButtonsStandard.PageManager
        Me.AddButton(Phrase(Setting.Language, 3018), Href(Setting.Name, False, "pagesmanager.aspx"), , Components.IconType.ControlPanel, , True, , Blink)
    End Select
  End Sub

  Public Overrides Sub ShowElement(Optional ByRef LeftBar As Boolean = True, Optional ByRef RightBar As Boolean = True, Optional ByRef TopBar As Boolean = True, Optional ByRef BottomBar As Boolean = True)
    ShowLeftBar = LeftBar
    ShowRightBar = RightBar
    ShowTopBar = TopBar
    ShowBottomBar = BottomBar
  End Sub

  Public Overrides Property ContentPlaceHolder() As WebControls.ContentPlaceHolder
    Get
      Return ContentPlaceHolder1
    End Get
    Set(ByVal Value As WebControls.ContentPlaceHolder)
      ContentPlaceHolder1 = Value
    End Set
  End Property

  Public Overrides ReadOnly Property MainContainer As Control
    Get
      Return Container
    End Get
  End Property

  Public Overrides ReadOnly Property UserToolsBar As Control
    Get
      Return ToolsBar
    End Get
  End Property

  Private CollectionOfBottomContent As New Collections.Generic.List(Of BottomContent)

  Public Overrides ReadOnly Property BottomContentCollection As Collections.Generic.List(Of BottomContent)
    Get
      Return CollectionOfBottomContent
    End Get
  End Property

  Public Overrides Sub AddBottomContent(ByVal Bar As Control, ByVal Canonical As String)
    Dim BottonContent As New BottomContent
    BottonContent.Bar = Bar
    BottonContent.Canonical = Canonical
    CollectionOfBottomContent.Add(BottonContent)
  End Sub

  Public Overrides ReadOnly Property Left As Control
    Get
      Return BarLeft
    End Get
  End Property

  Public Overrides ReadOnly Property Top As Control
    Get
      Return BarTop
    End Get
  End Property

  Public Overrides ReadOnly Property TopToLeft As Control
    Get
      Return Me.TopLeft
    End Get
  End Property

  Public Overrides ReadOnly Property TopToRight As Control
    Get
      Return Me.TopRight
    End Get
  End Property

  Public Overrides ReadOnly Property Right As Control
    Get
      Return BarRight
    End Get
  End Property
  Public Overrides ReadOnly Property Bottom As Control
    Get
      Return BarBottom
    End Get
  End Property


  Public Overrides Property ShowTopBar() As Boolean
    Get
      ShowTopBar = BarTop.Visible
    End Get
    Set(ByVal Value As Boolean)
      BarTop.Visible = Value
    End Set
  End Property

  Public Overrides Property ShowBottomBar() As Boolean
    Get
      ShowBottomBar = BarBottom.Visible
    End Get
    Set(ByVal Value As Boolean)
      BarBottom.Visible = Value
    End Set
  End Property

  Public Overrides Property ShowLeftBar() As Boolean
    Get
      ShowLeftBar = BarLeft.Visible
    End Get
    Set(ByVal Value As Boolean)
      BarLeft.Visible = Value
    End Set
  End Property

  Public Overrides Property ShowRightBar() As Boolean
    Get
      ShowRightBar = BarRight.Visible
    End Get
    Set(ByVal Value As Boolean)
      BarRight.Visible = Value
    End Set
  End Property

  Public Overrides Property ShowMenu() As Boolean
    Get
      ShowMenu = BarLeft.Visible
    End Get
    Set(ByVal Value As Boolean)
      BarLeft.Visible = Value
    End Set
  End Property

  Public Overrides Property ShowMeteo() As Boolean
    Get
      ShowMeteo = BarLeft.Visible
    End Get
    Set(ByVal Value As Boolean)
      BarLeft.Visible = Value
    End Set
  End Property

  Public Overrides Property Author() As String
    Get
      Return m_Author
    End Get
    Set(ByVal value As String)
      m_Author = value
    End Set
  End Property
  Public Overrides Property MetaRevisitAfterDays() As Integer
    Get
      Return m_MetaRevisitAfterDays
    End Get
    Set(ByVal value As Integer)
      m_MetaRevisitAfterDays = value
    End Set
  End Property
  Public Overrides Property Description() As String
    Get
      Return m_Description
    End Get
    Set(ByVal value As String)
      m_Description = value
    End Set
  End Property
  Public Overrides Property KeyWords() As String
    Get
      Return m_KeyWords
    End Get
    Set(ByVal value As String)
      m_KeyWords = value
    End Set
  End Property
  Public Overrides Property Language() As String
    Get
      Return m_Language
    End Get
    Set(ByVal value As String)
      m_Language = value
    End Set
  End Property
  Public Overrides Property ShortcutIcon() As String
    Get
      Return FavIcon.Href
    End Get
    Set(ByVal value As String)
      FavIcon.Href = value
    End Set
  End Property
  Public Overrides Sub AddStyle(Css As String)
    Static Style As WebControl
    If Style Is Nothing Then
      Style = New WebControl(HtmlTextWriterTag.Style)
      Page.Header.Controls.Add(Style)
    End If
    Style.Controls.Add(Literal(Css))
  End Sub
  Public Overrides Property TitleDocument() As String
    Get
      Return HttpUtility.HtmlDecode(Page.Title)
    End Get
    Set(ByVal value As String)
      Page.Title = HttpUtility.HtmlEncode(value)
    End Set
  End Property

  Private Services As New HtmlGenericControl("nav") 'Html5

  Private AuthostInThisPage As New Collections.Generic.List(Of User)
  Public Overrides ReadOnly Property Authors As Collections.Generic.List(Of User)
    Get
      SyncLock AuthostInThisPage
        Return AuthostInThisPage
      End SyncLock
    End Get
  End Property
  Public Overrides Sub AddAuthors(Author As User)
    SyncLock AuthostInThisPage
      If Not AuthostInThisPage.Contains(Author) Then
        AuthostInThisPage.Add(Author)
      End If
    End SyncLock
  End Sub

  Public Overrides Sub AddItemService(ByVal Href As String, ByVal Text As String, ByVal ToolTip As String, Optional ByVal Level As Integer = 2)
    Services.Controls.Add(ControlItem(Href, Text, ToolTip, Level))
  End Sub

  Private Sub SetElements(ByVal Setting As SubSite)

    Dim Skin As Skin = Setting.Skin
    Dim SkinSetup As SkinSetup = Setting.Skin.SkinSetup

    If SkinSetup IsNot Nothing Then
      Dim CounterRequest = Session("CounterRequest")
      If CounterRequest Is Nothing Then
        CounterRequest = 1
        Session("CounterRequest") = 2
      Else
        Session("CounterRequest") += 1
      End If
      Dim BgSound As String = SkinSetup.Variables("bgsound")
      If BgSound <> "" AndAlso ((Not StrComp(SkinSetup.Variables("soundonlyatstartsession"), "true", CompareMethod.Text) = 0) OrElse CounterRequest = 1) Then
        'If Not IsLocal() Then
        If BgSound.EndsWith(".mod") Then
          BarTop.Controls.AddAt(0, ModPLayer)
        ElseIf Request.Browser.BackgroundSounds Then
          Dim SoundCtrl As New WebControls.WebControl(HtmlTextWriterTag.Bgsound)
          SoundCtrl.Attributes.Add("src", BgSound)
          Me.Page.Header.Controls.Add(SoundCtrl)
        Else
          Me.form1.Controls.AddAt(0, AudioObject(SkinSetup.Variables("BgSound")))
        End If
        'End If 
      End If
    End If

    If TraceControls IsNot Nothing Then
      'Add trace menu at top page, ex: Rome > History > Foundation
      Dim LastId As Integer = TraceControls.GetUpperBound(0)
      For N As Integer = 0 To LastId
        NavigationScheme.Controls.Add(TraceControls(N))
        If N <> LastId Then
          Dim Space As New LiteralControl(" > ")
          NavigationScheme.Controls.Add(Space)
        End If
      Next
    End If

    'Add elements at end of page
    If IsCrawler(Request) Then
      AddCodeFromFile(BarBottom, "HideContent")
    End If

    If Config.Setup.RenderingEngine.AddLinksDomains AndAlso BarBottom.Visible = True Then
      AddLinksDomains(Config.Setup.RenderingEngine.HideLinksDomains)    ' Add friend domains to best ranking"
    End If

    If Not IsLocal() Then
      AddCodeCounter()
    End If


    Dim HomePage As String
    Dim DomainConfiguration As DomainConfiguration = CurrentDomainConfiguration()
    HomePage = Common.Href(Setting.Name, False, "default.aspx")

    If BarLeft.Visible Then

      'Add link to services
      For Each Plugin As PluginManager.Plugin In AllPlugins()
        If Plugin.AddItemToMenu Then
          If Plugin.IsEnabledAndAccessible(User, Setting) Then
            AddItemService(Href(Setting.Name, False, Plugin.AspxFileName), Plugin.Description(Setting.Language, True), Plugin.Description(Setting.Language, False))
          End If
        End If
      Next

      If Services.Controls.Count Then
        Services.Controls.AddAt(0, ControlItem(Nothing, Phrase(Setting.Language, 0), Phrase(Setting.Language, 0), 0))
        Services.Attributes("class") = "Menu"
        BarLeft.Controls.Add(Services)
      Else
        Services.Dispose()
      End If

      'Add menu
      BarLeft.Controls.Add(MenuControls(CurrentDomainConfiguration, Setting))

      'Add link to blog
      If Setting.Blog IsNot Nothing AndAlso Setting.Blog.Count > 0 Then
        Dim BlogLinks As New WebControl(HtmlTextWriterTag.Div)
        BlogLinks.CssClass = "Menu"
        BlogLinks.Controls.Add(ControlItem(Nothing, "web", Nothing, 0))

        For Each Blog As Notice In Setting.Blog
          Dim Href As String
          If UrlPointToThisNetwork(Blog.Link) Then
            Href = Blog.Link
          Else
            Href = Common.Href(CurrentSetting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.ExternalPage, QueryKey.Url, Blog.Link.Substring(Blog.Link.IndexOf("/"c) + 2))
          End If
          BlogLinks.Controls.Add(ControlItem(Href, InnerText(Blog.Title), InnerText(Blog.Description)))
        Next
        BarLeft.Controls.Add(BlogLinks)
      End If

      If Not Setting.Weathers Is Nothing Then
        BarLeft.Controls.Add(Weathers(Setting))
      End If

      'Add Currency Exchange Table
      If Setting.CurrencyExchangeWidget Then
        BarLeft.Controls.Add(CurrencyManager.ExchangeTable(Setting.Currency, Setting.Language, Skin))
      End If

      AddCodeFromFile(BarLeft)
    End If

    If BarRight.Visible Then
      'Add random foto preview
      If Setting.Photoalbums IsNot Nothing Then
        Dim Added As Boolean
        Dim Random As Random
        If User.GeneralRole = Authentication.User.RoleType.Visitors Then
          Random = StringToRandom(Setting.Name & Request.Url.PathAndQuery)
        End If
        For Each PhotoAlbum As String In Setting.Photoalbums
          Dim Exclude As Collections.Generic.List(Of Integer) = New Collections.Generic.List(Of Integer)
          Dim Photos As Collections.Generic.List(Of Photo) = GetRandomPhotos(PhotoAlbum, Setting.Aspect.RandomPicturesForPhotoAlbum)
          For Each Photo In Photos
            BarRight.Controls.Add(Photo.ControlThumbnail(Setting))
          Next
          If Photos.Count Then Added = True
        Next
        If Added Then
          BarRight.Controls.Add(BR)
        End If
      End If
      AddCodeFromFile(BarRight)

      'Add search results restrict to this domain
      If Setting.ShowRelatedPagesWithTheSearchCarriedOutByTheVisitor Then
        If Session("QuerySearch") <> "" Then
          If Session("ResultOfSearchControl") Is Nothing Then
            Dim Control As Control = SeacrhResult(Session("QuerySearch"), CurrentDomain)
            If Control Is Nothing Then
              Session("ResultOfSearchControl") = False
            Else
              Session("ResultOfSearchControl") = Control
            End If
          End If
          If Not TypeOf (Session("ResultOfSearchControl")) Is Boolean Then
            ContentPlaceHolder.Controls.Add(Session("ResultOfSearchControl"))
          End If
        End If
      End If
    End If

    If BarTop.Visible Then
      If Not SkinSetup Is Nothing Then
        Dim TitleDescription As String = Trim(Setting.Title & " " & Setting.Description)
        Dim ImageTopLeft As String = SkinSetup.Variables("ImageTopLeft")

        Dim LinkLogo As String
        If User.GeneralRole >= Authentication.User.RoleType.User Then
          LinkLogo = User.Href(Setting)
        Else
          LinkLogo = HomePage
        End If

        If ImageTopLeft <> "" Then
          Dim CtrlTopLeft As Control = ControlSkin(ImageTopLeft, TitleDescription, LinkLogo)
          If CtrlTopLeft IsNot Nothing Then
            Dim WebControl As WebControl = CtrlTopLeft
            WebControl.CssClass = "ImageTopLeft"
            TopLeft.Controls.AddAt(0, WebControl)
          End If
        End If

        Dim Logo As String = SkinSetup.Variables("Logo")
        If Logo <> "" Then
          Dim CtrlLogo As Control = ControlSkin(Logo, TitleDescription, LinkLogo)
          If CtrlLogo IsNot Nothing Then
            Dim WebControl As WebControl = CtrlLogo
            WebControl.CssClass = "Logo"
            TopLeft.Controls.Add(WebControl)
          End If
        End If

        If Setting.Title <> "" Then
          'Add web-site title
          Dim Title As New Label
          Title.CssClass = "WebSiteTitle"
          Dim Size As Integer = 1200 / Setting.Title.Length
          If Size > 50 Then Size = 50
          If Size < 15 Then Size = 15
          Title.Font.Size = New WebControls.FontUnit(Size, UnitType.Pixel)
          Title.Text = HttpUtility.HtmlEncode(Setting.Title)
          TopLeft.Controls.Add(Title)
        End If

        Dim BannerServices As String = SkinSetup.Variables("BannerServices")
        If BannerServices <> "" Then
          If True Then
            'Services mini-banner
            AddTopMiniBanner(BannerServices, Phrase(Setting.Language, 0), Common.Href(Setting.Name, False, "contact.aspx"))
          End If
        End If

        'Add link and flag for multylanguage web site
        If DomainConfiguration.SubSitesAvailable.Count > 1 Then
          If Not DomainConfiguration.AvailableAllSubSite Then
            'Add SubSite Index for this url
            For Each SubSite As SubSite In DomainConfiguration.SubSites
              If SubSite.Name <> Setting.Name Then
                'Add flag
                Dim Flag As HtmlImage = Components.Flag(SubSite.Language)
                Flag.Attributes.Add("class", "Flag")
                'Add link
                Dim Link As New WebControls.HyperLink
                Link.Attributes.Add("title", EncodingAttribute(SubSite.Title))
                Link.Controls.Add(Flag)
                Link.NavigateUrl = Common.Href(SubSite.Name, False, "default.aspx")
                TopRight.Controls.Add(Link)
              End If
            Next
          End If
        End If

        'Button Home Page
        Dim HomePageButtonText As String
        Dim TooltipHomePageButton As String = Phrase(Setting.Language, 4)
        If Setting.SEO.TextOnHomePageButton = SubSite.SeoFunctions.HomeButtonText.WebsiteTitle AndAlso Setting.Title <> "" Then
          HomePageButtonText = Setting.Title
        Else
          HomePageButtonText = TooltipHomePageButton
        End If
        AddButton(HomePageButtonText, HomePage, TooltipHomePageButton, Components.IconType.Home)

        If User.GeneralRole >= User.RoleType.User Then
          'Button HomeUser
          Dim Button As Control = AddButton(Phrase(Setting.Language, 34) & " " & User.Username, User.Href(Setting), , Components.IconType.MyIcons)
          AddFotoAlbumSlideShow(Setting, Button, User.NamePhotoAlbum)
        Else
          'Button New User
          Dim IsDefault As Boolean = Setting.Name = SubSite.DefaultSiteConfiguration
          If Not IsDefault Then
            If Request.AppRelativeCurrentExecutionFilePath <> "~/log.aspx" OrElse Request.QueryString(QueryKey.ActionLog) <> CStr(LogActionType.NewUser) Then
              Dim Href As String = HrefLogin()
              AddButton(Phrase(Setting.Language, 20), Href, , Components.IconType.Favourites, , True, , Setting.Aspect.SuggestTheBestChoiceByTheBlink)
            End If
          End If

          'Button LogIn/Off																																
          If Request.AppRelativeCurrentExecutionFilePath <> "~/log.aspx" OrElse Request.QueryString(QueryKey.ActionLog) <> "" Then
            Dim Href As String = HrefLogin(False)
            Dim Blink As Boolean
            If IsDefault Then
              Blink = Setting.Aspect.SuggestTheBestChoiceByTheBlink
            End If
            AddButton(Phrase(Setting.Language, 21), Href, , Components.IconType.Favourites, , True, , Blink)
          End If
        End If

        'Button Online Users
        If Setting.UsersOnline Then
          AddButton(Phrase(Setting.Language, 131), Common.Href(Setting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.OnlineUsers), , Components.IconType.Users, , True)
        End If

        If Setting.Forums IsNot Nothing Then
          'Add button Forum
          AddButton(Phrase(Setting.Language, 61), Common.Href(Setting.Name, False, "forum.aspx"), , Icon_Forum)
        End If

        If Setting.News IsNot Nothing AndAlso Setting.News.SourcesRSS IsNot Nothing AndAlso Setting.News.SourcesRSS.Count Then
          'Add button News
          AddButton(Phrase(Setting.Language, 2), Common.Href(Setting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.News), , Components.IconType.Globe)
        End If

        'Button show PhotoAlbum
        If HttpContext.Current.Request.Url.LocalPath.EndsWith("/default.aspx", StringComparison.InvariantCultureIgnoreCase) Then
          If Setting.Photoalbums IsNot Nothing AndAlso Setting.Photoalbums.Count <> 0 Then
            Dim Href As String
            If Setting.Photoalbums.Count = 1 Then
              Href = Common.Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, Setting.Photoalbums(0))
            Else
              Href = Common.Href(Setting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.ListPhotoAlbum)
            End If
            Dim Button As Control = AddButton(Phrase(Setting.Language, 103), Href, , Components.IconType.FolderPics)
            AddFotoAlbumSlideShow(Setting, Button, Setting.Photoalbums(0))
          End If
        End If

        'Button Contact
        If Setting.Contacts Then
          AddButton(Phrase(Setting.Language, 3179), Common.Href(Setting.Name, False, "contact.aspx"), , Components.IconType.Help)
        End If

        'Add "About us"
        If Setting.AboutUs = True AndAlso AboutUsExists() Then
          AddButton(Phrase(Setting.Language, 2006), Common.Href(Setting.Name, False, "default.aspx", QueryKey.ArticleNumber, 6, QueryKey.ArchiveNumber, 0), , Components.IconType.Document)
        End If

        'Button Chat
        'If User.Role(Setting.Name) > Authentication.User.RoleType.Visitors Then 'Available chat only for new entry user
        If PluginManager.IsEnabled(Setting, "Chat") Then
          AddButton(Phrase(Setting.Language, 2001), Common.Href(Setting.Name, False, "chat.aspx"), , Components.IconType.Chat)
        End If
        'End If

        If Setting.Name <> "" Then
          If User.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
            If Setting.Archive IsNot Nothing Then
              For Each Item As Integer In Setting.Archive
                If Item Then
                  'Button Page Manager
                  AddButton(Common.ButtonsStandard.PageManager)
                  'Button New Page (Add Page)
                  Dim Blink As Boolean = False
                  If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
                    If Setting.Archive IsNot Nothing AndAlso Setting.Archive.Count = 1 Then
                      If Not HttpContext.Current.Request.Url.LocalPath.EndsWith("/edit.aspx", StringComparison.InvariantCultureIgnoreCase) Then
                        Dim Menu As Menu = Menu.Load(Setting.Archive(0), Setting.Language)
                        If Menu IsNot Nothing AndAlso Menu.ItemsMenu.Count = 0 Then
                          Blink = True
                        End If
                      End If
                    End If
                  End If
                  AddButton(Common.ButtonsStandard.NewPage, Blink)
                  Exit For
                End If
              Next
            End If

            If User.Role(Setting.Name) >= Authentication.User.RoleType.Administrator Then
              'Add Button Tech Support
              Dim TechSupportUrl As String
              If Setting.Language = LanguageManager.Language.Italian Then
                TechSupportUrl = CopyrightLink & "forum.aspx?ss=forum"
              Else
                TechSupportUrl = CopyrightLink & "forum.aspx"
              End If
              AddButton(Phrase(Setting.Language, 3185), TechSupportUrl, , IconType.TechSupport)

              'Add Button SubSite setting
              AddButton(Phrase(Setting.Language, 3025), Common.Href(Setting.Name, False, "setup.aspx", "config", Setting.Name), Phrase(Setting.Language, 3025, 3026), Components.IconType.ControlPanel)
            End If
            If User.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster Then
              'Add Button WebMaster Panel setting
              AddButton(Phrase(Setting.Language, 144, 145), Common.Href(Setting.Name, False, "configeditor.aspx", "edit", "setup"), Phrase(Setting.Language, 144, 145), Components.IconType.ControlPanel)
            End If
          End If
        End If

        AddCodeFromFile(BarTop)
      End If
    End If

    If BarBottom.Visible Then
      Dim Domain As New WebControls.Label
      Domain.Text = "© " & Now.Year & " " & PathCurrentUrl()
      Domain.CssClass = "copyright"
      BarBottom.Controls.Add(Domain)


      '=================================================================
      'Don't remove this routine bellow! This code is part of license! 
      '=================================================================

      Dim LinkCopyright As New HyperLink
      LinkCopyright.NavigateUrl = CopyrightLink
      LinkCopyright.Text = Copyright
      LinkCopyright.CssClass = "cms"
      BarBottom.Controls.Add(LinkCopyright)

      '=================================================================
      ' 
      '=================================================================

      AddCodeFromFile(BarBottom)

      'Add search engine result
      'If Session("OutOfNetworkReferrer") IsNot Nothing Then
      '  Me.BarBottom.Parent.Controls.Add(IFrame("100%", 1200, Session("OutOfNetworkReferrer")))
      'End If

    End If

    If Session("NextMessage") IsNot Nothing Then
      AddMessage(Session("NextMessage"), Setting)
      Session("NextMessage") = Nothing
    End If

    If Messages.Controls.Count Then
      Dim BoxOverlapping As New WebControl(HtmlTextWriterTag.Div)
      ContentPlaceHolder1.Controls.AddAt(0, BoxOverlapping)
      BoxOverlapping.CssClass = "MessageOverlap"
      BoxOverlapping.Controls.Add(Components.TextControl(Message))
      Dim Div As New WebControl(HtmlTextWriterTag.P)
      Div.Controls.Add(Messages)
      ContentPlaceHolder1.Controls.AddAt(0, Div)
    End If

    If Request.Browser.EcmaScriptVersion.Major >= 1 Then

      'Render the menu Contractible and Expandable
      If Setting.Aspect.MenuContractible Then
        If HttpContext.Current.Items.Contains("idm0") Then
          Page.Header.Controls.Add(ScriptByNameFile("ExpandMenu.js"))
          AddStyle(".contracted ~ *{display:none}.contracted:before{content:'▼ '!important}.m0[href^='javascript:']:before{content:'✖ '}")
        End If
      End If

      'Add script to setting focus to article
      If Setup.RenderingEngine.OnPageLoad = Configuration.RenderingEngineConfiguration.OnLoadPageAction.JumpToSectionTagsInPage Then
        Dim AutoFucus As WebControl = Script("if (window.location.href.indexOf('#')==-1){var Section=document.getElementsByTagName('section');if (Section.length>=1){Section[0].id='Focused';window.location.replace('#Focused')}}", ScriptLanguage.javascript)
        AutoFucus.Attributes.Add("visibility", "hidden")
        AutoFucus.Attributes.Add("display", "none")
        Page.Header.Parent.Controls.Add(AutoFucus)
      End If

      'Add Messenger Comunication Script
      '(funzione in conflitto con openwysiwyg)>>> Page.Header.Controls.Add(MessengerManager.ScriptCheckEvents(Setting))

      'Detect Time Zone Offset
      If User.ForceDetectTimeOffset Then
        User.DetectTimeOffsetDisabled()
        Page.Header.Controls.Add(ScriptOutside(SourceScript.DetectTimeZoneOffset))
      End If

      'Dim ScriptText As String = ReadAll(MapPath(ScriptsResources & "/" & "closewindow.js"))
      'Dim ScriptNoCloseBrowser As Control = Script(Replace(ScriptText, "GoToUrl", """" & Session("OutOfNetworkReferrer") & """", , , CompareMethod.Text), ScriptLanguage.javascript, "window", "onbeforeunload")
      'Page.Header.Parent.Controls.Add(ScriptNoCloseBrowser)

      If Session("OutOfNetworkReferrer") <> "" Then
        Dim ScriptText As String = HeaderScript
        If StrComp(Request.Browser.Browser, "IE", CompareMethod.Text) = 0 Then
          ScriptText = ReplaceText(ScriptText, ".pageY", ".clientY")
          ScriptText = ReplaceText(ScriptText, ".pageX", ".clientX")
        End If
        Dim BrowserName As String = Request.Browser.Browser
        ScriptText = ReplaceText(ScriptText, "//[not " & BrowserName & "]", "/* [not " & BrowserName & "]")
        ScriptText = ReplaceText(ScriptText, "//END[not " & BrowserName & "]", "[not " & BrowserName & "] */")
        ScriptText = ReplaceText(ScriptText, "//END[not ", "//END [not ")

        ScriptText = ReplaceText(ScriptText, "//[" & BrowserName & "]", "//")
        ScriptText = ReplaceText(ScriptText, "//END[" & BrowserName & "]", "//")

        ScriptText = ReplaceText(ScriptText, "//[", "/*[")
        ScriptText = ReplaceText(ScriptText, "//END[", "*/ //[")

        Dim Go As String
        If AutoAdSenseForSearch Then
          Go = Href(Setting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.RedirectToSearchEngine)
        Else
          ScriptText = ReplaceText(ScriptText, "//location", "location")
          ScriptText = ReplaceText(ScriptText, "submitForm.", "//submitForm.")
          Go = Session("OutOfNetworkReferrer")
        End If
        ScriptText = ReplaceText(ScriptText, "OutOfNetworkReferrer", """" & AbjustForJavascriptString(Go) & """")

        ScriptText = ReplaceText(ScriptText, "ExitMessage", """" & AbjustForJavascriptString(Phrase(Setting.Language, 136) & " " & CurrentDomain()) & """")
        Dim ScriptNoCloseBrowser As Control = Script(ScriptText, ScriptLanguage.javascript)
        BottomPlaceHolder.Controls.Add(ScriptNoCloseBrowser)
      End If
    End If

    If Rating Then
      'Add tool rating user
      Dim RatingControl As New WebControl(HtmlTextWriterTag.Div)
      RatingControl.Attributes.Add("itemscope", "itemscope")
      RatingControl.Attributes.Add("itemtype", "http://schema.org/Rating")
      Dim RatingValue As New WebControl(HtmlTextWriterTag.Meta)
      RatingValue.Attributes.Add("itemprop", "ratingValue")
      RatingValue.Attributes.Add("content", Rating)
      RatingControl.Controls.Add(RatingValue)
      Dim BestRating As New WebControl(HtmlTextWriterTag.Meta)
      BestRating.Attributes.Add("itemprop", "bestRating")
      BestRating.Attributes.Add("content", 5)
      RatingControl.Controls.Add(BestRating)
      ContentPlaceHolder1.Controls.Add(RatingControl)
    End If

    'If IsCrawler(Request) Then
    'If Rating Then
    '	Dim Box As New WebControl(HtmlTextWriterTag.Div)
    '	Box.CssClass = "hreview"
    '	Box.Attributes.Add("itemprop", "rating")
    '	Box.Attributes.Add("itemscope", "itemscope")
    '	Box.Attributes.Add("itemtype", "http://data-vocabulary.org/Rating")

    '	Dim Fn As New WebControl(HtmlTextWriterTag.Span)
    '	Fn.CssClass = "fn"
    '	Fn.Controls.Add(TextControl(Page.Title))
    '	Box.Controls.Add(Fn)

    '	Dim Reviewer As New WebControl(HtmlTextWriterTag.Span)
    '	Reviewer.CssClass = "reviewer"
    '	Reviewer.Controls.Add(TextControl(PathCurrentUrl))
    '	Box.Controls.Add(Reviewer)

    '	Dim Rating As New WebControl(HtmlTextWriterTag.Span)
    '	Rating.CssClass = "rating"
    '	Rating.Controls.Add(TextControl(Me.Rating))
    '	Box.Controls.Add(Rating)

    '	ContentPlaceHolder1.Controls.Add(Box)
    'End If

    'If Authors.Count = 1 Then
    'Dim Author As User = Authors(0)
    For Each Author As User In Authors

      Select Case 1
        Case 1
          Dim Link As New WebControl(HtmlTextWriterTag.Link)
          Link.Attributes.Add("rel", "author")
          Link.Attributes.Add("href", Author.Href(Setting))
          ContentPlaceHolder1.Controls.AddAt(0, Link)
        Case 2
          Dim Vcard As New WebControl(HtmlTextWriterTag.Span)
          Vcard.CssClass = "vcard"

          Dim PageAuthor As String = Author.URL
          If PageAuthor IsNot Nothing AndAlso PageAuthor.Contains("://plus.google.com/") Then
            If Not PageAuthor.Contains("?rel=author") Then
              PageAuthor &= "?rel=author" 'https://spreadsheets.google.com/spreadsheet/viewform?formkey=dHdCLVRwcTlvOWFKQXhNbEgtbE10QVE6MQ&ndplr=1
            End If
          End If

          Dim AuthorA As New WebControl(HtmlTextWriterTag.A)
          AuthorA.CssClass = "url fn"
          AuthorA.Attributes.Add("rel", "author")
          AuthorA.Attributes.Add("href", PageAuthor)
          AuthorA.Controls.Add(TextControl(Author.FirstName & " " & Author.LastName & "+")) 'https://spreadsheets.google.com/spreadsheet/viewform?formkey=dHdCLVRwcTlvOWFKQXhNbEgtbE10QVE6MQ&ndplr=1
          Vcard.Controls.Add(AuthorA)
          ContentPlaceHolder1.Controls.AddAt(0, Vcard)
      End Select

    Next
    'End If

    'End If

  End Sub

  Shared HeaderScript As String = ReadAll(Extension.MapPath(ScriptsResources & "/" & "HeaderScript.js")) 'Cache this script

  Shared AboutUs As New System.Collections.Generic.Dictionary(Of LanguageManager.Language, Boolean)
  Private Function AboutUsExists() As Boolean
    If AboutUs.ContainsKey(Setting.Language) Then
      Return AboutUs.ContainsKey(Setting.Language)
    Else
      If System.IO.File.Exists(MenuManager.PageNameFile(1, 6, Setting.Language)) Then
        Try
          AboutUs.Add(Setting.Language, True)
        Catch ex As Exception
        End Try
        Return True
      Else
        Try
          AboutUs.Add(Setting.Language, False)
        Catch ex As Exception
        End Try
        Return False
      End If
    End If
  End Function

  Private Function AdSenseReferralCode(ByVal Width As Integer, ByVal Height As Integer, ByVal CpaChoice As String) As String
    Dim ReferralAdSenseCode As String = ReadAll(Extension.MapPath(CodesSubDirectory & "\adsense_referral.html"))
    ReferralAdSenseCode = ReplaceBin(ReferralAdSenseCode, "#CLIENT", Setup.Affiliations.Google_Client)
    ReferralAdSenseCode = ReplaceBin(ReferralAdSenseCode, "#WIDTH", CStr(Width))
    ReferralAdSenseCode = ReplaceBin(ReferralAdSenseCode, "#HEIGHT", CStr(Height))
    ReferralAdSenseCode = ReplaceBin(ReferralAdSenseCode, "#CPACHOICE", CpaChoice)
    Return ReferralAdSenseCode
  End Function

  Private Sub AddTopMiniBanner(ByVal ImageUrl As String, ByVal ToolTip As String, ByVal Href As String)
    Dim HyperLink As New WebControls.HyperLink
    HyperLink.ToolTip = EncodingAttribute(ToolTip)
    HyperLink.NavigateUrl = Href
    Dim Image As New WebControls.Image
    Image.AlternateText = ToolTip
    Image.ImageUrl = ImageUrl
    Dim Width, Height As Integer
    CacheImageSize.LoadWidthHeight(Image.ImageUrl, Width, Height)
    Image.Width = Width
    Image.Height = Height
    HyperLink.Controls.Add(Image)
    TopRight.Controls.Add(HyperLink)
  End Sub

  Private Sub AddCodeCounter()
    Dim Control As New Web.UI.WebControls.Literal
    Control.ID = "CodeCounter"
    Dim Html As String = _
    "<span id=""CodeCounter"">" & _
    Config.CodeCounter & _
    "</span>"
    If Setup.RenderingEngine.HideStatsCode Then
      Html &= _
       "<script type=""text/javascript"">" & _
       "CodeCounter.outerHTML="""";" & _
       "</script>"
    End If
    Control.Text = Html
    BarBottom.Controls.Add(Control)
    'Me.Controls.Add(Control)
  End Sub

  Private Sub AddLinksDomains(ByVal Hide As Boolean)
    'Add link friend host to best ranking
    Dim Ctrl As New WebControl(HtmlTextWriterTag.Span)
    Dim AllDomainNames = Config.AllDomainNames
    If AllDomainNames IsNot Nothing Then
      For Each Domain As String In AllDomainNames
        Dim Link As New HyperLink
        Dim P1 As Integer = InStr(Domain, ".", CompareMethod.Binary)
        Dim P2 As Integer = InStr(P1 + 1, Domain, ".", CompareMethod.Binary)
        If P1 <> 0 And P2 = 0 Then
          Link.NavigateUrl = "http://www." & Domain
        Else
          Link.NavigateUrl = "http://" & Domain
        End If
        Dim DomainConfiguration As DomainConfiguration
        DomainConfiguration = DomainConfiguration.Load(Domain)
        If DomainConfiguration.SubSitesAvailable.Count Then
          Dim SubSite As SubSite
          SubSite = SubSite.Load(DomainConfiguration.SubSitesAvailable(0))

          If SubSite.Title <> "" Then
            Link.Text = HttpUtility.HtmlEncode(SubSite.Title)
          Else
            Link.Text = HttpUtility.HtmlEncode(Link.NavigateUrl)
          End If
          Ctrl.Controls.Add(Flag(SubSite.Language))
          Ctrl.Controls.Add(Link)
          Ctrl.Controls.Add(New LiteralControl("   "))
        End If
      Next
      BarBottom.Controls.Add(Ctrl)
      If Hide Then
        BarBottom.Controls.Add(Script(Ctrl.ClientID & ".style.display='none';", ScriptLanguage.javascript))
      End If
    End If
  End Sub

  Private Function ToolsBarAddButton(ByVal Where As Control, ByVal Text As String, ByVal Href As String, Optional ByVal ToolTip As String = Nothing, Optional ByVal Icon As IconType = Nothing, Optional ByVal Target As TargetForButton = TargetForButton.Self, Optional ByVal Nofollow As Boolean = False, Optional ByVal OnClick As String = Nothing, Optional Blink As Boolean = False) As WebControl
    Dim Button As WebControl
    Dim TargetName As String = Nothing
    Select Case Target
      Case TargetForButton.Messenger
        TargetName = Window.Messenger.ToString
      Case TargetForButton.Blank
        TargetName = "_blank"
    End Select
    Button = Components.Button(Setting, Text, Href, ToolTip, Icon, TargetName, Nofollow)
    If OnClick IsNot Nothing AndAlso OnClick <> "" Then
      Button.Attributes.Add("onclick", OnClick)
    End If
    If Blink Then
      Me.Blink(Button)
    End If
    ToolsBar.Controls.Add(Button)
    Return Button
  End Function

  Overrides Sub Blink(Control As Control)
    AddBlinkCode()
    'Control.Style.Add("text-decoration", "blink!important")	
    If TypeOf Control Is WebControl Then
      Dim Ctrl As WebControl = Control
      If Ctrl.CssClass <> "" Then
        Ctrl.CssClass &= " blink"
      Else
        Ctrl.CssClass = "blink"
      End If
    ElseIf TypeOf Control Is HtmlControl Then
      Dim Ctrl As HtmlControl = Control
      If Ctrl.Attributes("class") <> "" Then
        Ctrl.Attributes("class") &= " blink"
      Else
        Ctrl.Attributes("class") = "blink"
      End If
    End If
  End Sub

  Private Sub AddBlinkCode()
    Static AddedBlinkCode As Boolean
    If Not AddedBlinkCode Then
      AddedBlinkCode = True
      Page.Header.Controls.Add(Script("function blink(){var bt = document.getElementsByClassName('blink');for (i=0; i<bt.length; i++){try{bt[i].style.color=bt[i].currentStyle.color;bt[i].style.backgroundColor=bt[i].currentStyle.backgroundColor}catch(err){bt[i].style.color=window.getComputedStyle(bt[i], null).color;bt[i].style.backgroundColor=window.getComputedStyle(bt[i], null).backgroundColor}t=bt[i].style.color;bt[i].style.color=bt[i].style.backgroundColor;bt[i].style.backgroundColor=t}setTimeout('blink()',500)};setTimeout('blink()',500)", ScriptLanguage.javascript))
    End If
  End Sub

  Protected Sub MasterPage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    Setting = CurrentSetting()

    'Block not autorized plugin for current user
    Dim CurrentPageName As String = Mid(Page.ToString, 5)
    CurrentPageName = CurrentPageName.Substring(0, Len(CurrentPageName) - 5) & ".aspx"
    For Each Plugin As PluginManager.Plugin In AllPlugins()
      If Plugin.AspxFileName = CurrentPageName Then
        If Not Plugin.IsEnabledAndAccessible(User, Setting) Then
          Response.End()
        End If
      End If
    Next
    RaiseMasterPageInitEvent(Me, User, Setting)
    If Setup.SEO.EntrapUsersFromSearchEngines Then
      Dim QuerryReferrer As Boolean
      Try
        If Request IsNot Nothing AndAlso Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.Query <> "" AndAlso DomainName(Request) <> Request.UrlReferrer.Host Then
          QuerryReferrer = True
        End If
      Catch ex As Exception
      End Try
      If QuerryReferrer Then
        If Request.Form("payment_status") <> "" Then
          'Is a paypal IPN notification
          Exit Sub
        End If

        'Is request is from external network domine
        Dim FromHost As String = Request.UrlReferrer.Host.ToLower
        If FromHost.StartsWith("www.") Then
          FromHost = Mid(FromHost, 5)
        End If
        If Not AllDomainNames().Contains(FromHost) Then
          Dim Ref As New System.Web.HttpRequest("", Request.UrlReferrer.AbsoluteUri, Web.HttpUtility.UrlDecode(Request.UrlReferrer.Query.Substring(1)))
          Dim QueryName As String
          If InStr(Request.UrlReferrer.AbsoluteUri, "yahoo.") <> 0 Then
            QueryName = "P"
          Else
            QueryName = "q"
          End If
          Dim Query As String = Ref.QueryString(QueryName)
          If Query <> "" Then
            Dim FromInsideSiteSearch As Boolean = Session("OutOfNetworkReferrer") <> ""
            Dim NewOutOfNetworkReferrer As String = HttpContext.Current.Request.UrlReferrer.AbsoluteUri
            If NewOutOfNetworkReferrer.ToLower.EndsWith("/default.aspx") Then
              NewOutOfNetworkReferrer = NewOutOfNetworkReferrer.Substring(0, NewOutOfNetworkReferrer.Length - 12)
            End If
            If Not FromInsideSiteSearch Then
              Dim IsFromGoogle As Boolean = InStr(Request.UrlReferrer.Host, "google", CompareMethod.Text) <> 0
              Dim MyHost As String = CurrentDomain()
              If IsFromGoogle Then
                If Request.UrlReferrer.LocalPath.EndsWith("/url") Then
                  'is a google counter!  Replace the counter with a google search page
                  NewOutOfNetworkReferrer = Request.UrlReferrer.Scheme & System.Uri.SchemeDelimiter & Request.UrlReferrer.Host & "/search?q=" & HttpUtility.UrlEncode(Query)
                End If
                NewOutOfNetworkReferrer &= "&sitesearch=" & MyHost
                If Setup.Affiliations.Google_Client <> "" Then
                  NewOutOfNetworkReferrer &= "&client=" & Setup.Affiliations.Google_Client
                End If
              Else
                NewOutOfNetworkReferrer = ReplaceText(NewOutOfNetworkReferrer, "?" & QueryName & "=", "?" & QueryName & "=site%3A" & MyHost & "+")
                NewOutOfNetworkReferrer = ReplaceText(NewOutOfNetworkReferrer, "&" & QueryName & "=", "&" & QueryName & "=site%3A" & MyHost & "+")
              End If
              'End If

              'Add search result in the footer if reference is from search engine
              'Session("SearchEngineReference") = NewOutOfNetworkReferrer

              'If back to search engine show only results for this domain!
              'Dim OutOfNetworkReferrer As String = Session("OutOfNetworkReferrer")
              'If Not FromInsideSiteSearch Then
              If Request.Browser.EcmaScriptVersion.Major Then
                If Not IsCrawler(Request) Then
                  'If Request.UrlReferrer.Query <> "" Then
                  Dim MyUrl As String = HttpContext.Current.Request.Url.LocalPath
                  If MyUrl.EndsWith("/default.aspx", StringComparison.InvariantCultureIgnoreCase) Then
                    MyUrl = MyUrl.Substring(0, MyUrl.Length - 13)
                  End If
                  Dim BackToUrl As String
                  If HttpContext.Current.Request.Url.Query.StartsWith("?404;") Then
                    BackToUrl = ReplaceBin(HttpContext.Current.Request.Url.Query.Substring(5), ":80/", "/")
                  Else
                    'BackToUrl = HttpContext.Current.Request.Url.Scheme & System.Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & MyUrl & HttpContext.Current.Request.Url.Query
                    BackToUrl = AbsoluteUri(HttpContext.Current.Request)
                  End If
                  BackToUrl = ReplaceText(BackToUrl, "/default.aspx", "/")
                  Session("BackToUrl") = BackToUrl
                  Session("QuerySearch") = Query
                  Session("OutOfNetworkReferrer") = NewOutOfNetworkReferrer
                  Dim Redirect As String = Href(Me.Setting.Name, True, "default.aspx", QueryKey.Show, DefaultPageShowType.RedirectToSearchEngine)
                  Response.Redirect(Redirect)
                  Exit Sub
                  'End If
                End If
              End If
            End If
          End If
        End If
      End If
    End If

    'Redirect uppercase url
    Dim uri As String = AbsoluteUri(HttpContext.Current.Request)
    'If uri <> uri.ToLower Then
    'Redirect301(uri.ToLower)
    'End If

    'Block user not autorized
    If Setup.Security.BlockIPAddresses <> Configuration.BlockIPMode.Disabled Then
      BlockIPAddress()
    End If
    BlockExcludedUser()

    'Set localization
    LanguageManager.SetLocalization(Page, Setting.Language)
  End Sub


  Protected Sub MasterPage_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    SetElements(Setting)
    SetMetaTags()

    If Request.Browser.Browser = "IE" AndAlso Request.Browser.MajorVersion < 9 Then
      'Preserve html5 compatibility with IE8: http://code.google.com/p/html5shiv/
      Page.Header.Controls.Add(Script(ScriptLanguage.javascript, "//html5shiv.googlecode.com/svn/trunk/html5.js"))
    End If
    Page.Header.Controls.Add(Script("if(screen.width<=800){document.getElementById('ctl00_StyleSheetHandheld').media='screen'}", ScriptLanguage.javascript))

    If Request.Browser.IsMobileDevice Then
      Dim X As Integer = Request.Browser.ScreenPixelsWidth
      Dim TextStyle As New LiteralControl(".Container{width:" & X & "px;}")
      Dim Style As New WebControl(HtmlTextWriterTag.Style)
      Style.Controls.Add(TextStyle)
      Page.Header.Controls.Add(Style)
    End If

    If Request.Browser.VBScript = True Then
      If Setting.IsTrue("MicrosoftAgent") Then
        BarBottom.Controls.Add(TextToSpeekClientCode(Setting.Language, Setting.Int("MicrosoftAgentCharacter")))
      End If
    End If

    If Request.Browser.EcmaScriptVersion.Major >= 1 Then
      'Add script to Break out of ANY iFrame 
      Me.Page.Header.Controls.Add(Script("if(top!=self){top.location.href=self.location.href}", ScriptLanguage.javascript))

      Dim Path As String = Nothing
      If Setting.IsTrue("Enabled", "Search") Then
        Path = Href(CurrentDomainConfiguration, Setting.Name, True, "search.aspx", "q=")
      Else
        Dim Domain As String = DomainConfiguration.DomainForSearchFunction(Setting.Language)
        If Domain IsNot Nothing Then
          Path = Href(DomainConfiguration.Load(Domain), Nothing, True, Nothing, "q=")
        End If
      End If
      If Path IsNot Nothing Then
        If CodeClickToSearch Is Nothing Then
          CodeClickToSearch = ReadAll(MapPath(ScriptsResources & "/" & "Search.js"))
        End If
        Dim CodeSearch As String = ReplaceBin(CodeClickToSearch, "DomainName", Path)
        Me.Page.Header.Controls.Add(Components.Script(CodeSearch, ScriptLanguage.javascript))
        Me.Page.Form.Attributes.Add("ondblclick", "WebSearch()")
      End If

      If False Then 'DISABLE/ENABLE
        'Add script redirect page to seach engine wen exit from network
        Dim FromSite As String = Session("referer")
        If FromSite = "" AndAlso Request IsNot Nothing AndAlso Request.UrlReferrer IsNot Nothing Then
          Dim Domain As String = CurrentDomain()
          For Each DomainInNetwork As String In AllDomainNames()
            If Domain <> DomainInNetwork Then
              Dim Ref As New System.Web.HttpRequest("", Request.UrlReferrer.AbsoluteUri, Web.HttpUtility.UrlDecode(Request.UrlReferrer.Query.Substring(1)))
              If Ref.QueryString("q") <> "" Then
                FromSite = HttpContext.Current.Request.UrlReferrer.AbsoluteUri
                Session("referer") = FromSite
              End If
              Exit For
            End If
          Next
        End If
        If FromSite <> "" Then
          If InStr(FromSite, "sitesearch", CompareMethod.Text) = 0 Then
            FromSite &= "&sitesearch=" & DomainName(Request)
            Dim CodeUnloadPage As String
            CodeUnloadPage = "window.open('http://www.google.com/','_blank');"
            BottomPlaceHolder.Controls.Add(Components.Script(CodeUnloadPage, ScriptLanguage.javascript, "document", "onbeforeunload"))
          End If
        End If
      End If


    End If
    If _OverlappingContent Then
      AddHeader(ReadAll(MapPath(ScriptsResources & "/" & "OverlappingContentLink.js")))
    End If

    If UseGoogleOff Then
      If BarLeft.Visible Then
        BarLeft.Parent.Controls.AddAt(BarLeft.Parent.Controls.IndexOf(BarLeft), New LiteralControl(GoogleOffTag))
        BarLeft.Parent.Controls.AddAt(BarLeft.Parent.Controls.IndexOf(BarLeft) + 1, New LiteralControl(GoogleOnTag))
      End If
      If BarRight.Visible Then
        BarRight.Parent.Controls.AddAt(BarRight.Parent.Controls.IndexOf(BarRight), New LiteralControl(GoogleOffTag))
        BarRight.Parent.Controls.AddAt(BarRight.Parent.Controls.IndexOf(BarRight) + 1, New LiteralControl(GoogleOnTag))
      End If
      If BarTop.Visible Then
        BarTop.Parent.Controls.AddAt(BarTop.Parent.Controls.IndexOf(BarTop), New LiteralControl(GoogleOffTag))
        BarTop.Parent.Controls.AddAt(BarTop.Parent.Controls.IndexOf(BarTop) + 1, New LiteralControl(GoogleOnTag))
      End If
      If BarBottom.Visible Then
        BarBottom.Parent.Controls.AddAt(BarBottom.Parent.Controls.IndexOf(BarBottom), New LiteralControl(GoogleOffTag))
        BarBottom.Parent.Controls.AddAt(BarBottom.Parent.Controls.IndexOf(BarBottom) + 1, New LiteralControl(GoogleOnTag))
      End If
    End If

    RaiseMasterPagePreRenderEvent(Me, User, Setting)

    If form1.Action = "" Then
      'This resolve html5 validation of action attribute
      form1.Action = Request.CurrentExecutionFilePath & Request.Url.Query
    End If

    If BarRight.Controls.Count = 0 Then
      BarRight.Visible = False
    End If

    For Each BottomContent As BottomContent In CollectionOfBottomContent
      If BottomContent.Bar.Controls.Count = 0 Then
        BottomContent.Bar.Visible = False
      End If
    Next

  End Sub

  Private Sub SetMetaTags()

    Dim Charset As String
    If Response.Charset = "utf-8" Then
      Charset = "UTF-8"
    Else
      Charset = Response.Charset
    End If

    'Html5
    Me.Page.Header.Controls.AddAt(1, New LiteralControl("<meta charset=""" & Charset & """>"))

    'Xhtml (Not supported in html5)
    'AddMetaTag("Content-Type", Response.ContentType & ";charset=" & Charset)

    StyleSheet.Href = Href(Setting.Name, False, "css.aspx", "skin", Setting.Skin.Id)
    StyleSheetHandheld.Href = Href(Setting.Name, False, "css.aspx", "skin", Setting.Skin.Id, "media", "handheld")
    StyleSheetPrint.Href = Href(Setting.Name, False, "css.aspx", "skin", Setting.Skin.Id, "media", "print")
    StyleSheetMobile.Href = Href(Setting.Name, False, "css.aspx", "skin", Setting.Skin.Id, "media", "handheld")
    'StyleSheetHandheld.Attributes.Add("onload", "if(screen.width<=800){document." & StyleSheetHandheld.ID & ".media='screen'}")
    'If Request.UserAgent <> "" AndAlso LCase(Request.UserAgent).Contains("webkit") Then
    'Istance on fly this next tag link:
    '<link id="StyleSheetAndroid" rel="stylesheet" href="css.aspx" type="text/css" media="screen and (-webkit-device-pixel-ratio:0.75)"	runat="server" />
    'Dim StyleSheetAndroid As New WebControl(HtmlTextWriterTag.Link)
    'StyleSheetAndroid.Attributes.Add("rel", "stylesheet")
    'StyleSheetAndroid.Attributes.Add("href", Href(Setting.Name, False, "css.aspx", "skin", Setting.Skin.Id, "media", "handheld"))
    'StyleSheetAndroid.Attributes.Add("type", "text/css")
    'StyleSheetAndroid.Attributes.Add("media", "all and (min-device-width: 0in) and (max-device-width: 7in)")
    'Page.Header.Controls.Add(StyleSheetAndroid)
    'End If

    If m_Description <> "" Then
      AddMetaTag("description", m_Description)
      'If AuthorOff = False Then
      '	AddMetaTag("author", m_Description)
      'End If
    End If
    If m_KeyWords <> "" Then AddMetaTag("keywords", m_KeyWords)

    Dim Robots As String = "" 'This is the most powerful of the StringBuilder, do not change!
    If MetaRobots.Content IsNot Nothing Then
      If Setting.SEO.Indexing = SubSite.SeoFunctions.IndexingDirective.Noindex AndAlso Not MetaRobots.Content.Contains("noindex") Then
        Replace(MetaRobots.Content, "index", "noindex")
      End If
      Robots &= MetaRobots.Content
    End If
    If MetaRobots.Content Is Nothing OrElse Not MetaRobots.Content.Contains("index") Then
      If Robots.Length Then
        Robots &= ","
      End If
      If Setting.SEO.Indexing = SubSite.SeoFunctions.IndexingDirective.Noindex Then
        Robots &= "noindex"
      Else
        Robots &= "index"
        AddMetaTag("revisit-after", m_MetaRevisitAfterDays & " Days")
      End If
    End If
      If MetaRobots.Content Is Nothing OrElse Not MetaRobots.Content.Contains("nofollow") Then
        If Robots.Length Then
        Robots &= ","
        End If
      Robots &= "follow"
      End If
      If Setup.SEO.PreventCrawlerArchivingOfContent = True Then
        If MetaRobots.Content Is Nothing OrElse Not MetaRobots.Content.Contains("archive") Then
          If Robots.Length Then
          Robots &= ","
          End If
        Robots &= "noarchive"
        End If
      End If
      MetaRobots.Name = "robots"
    MetaRobots.Content = Robots
      Me.Page.Header.Controls.Add(MetaRobots)

    If Setting.SEO.Indexing <> SubSite.SeoFunctions.IndexingDirective.Index AndAlso Setting.SEO.Indexing <> SubSite.SeoFunctions.IndexingDirective.Noindex Then
      Select Case Setting.SEO.Indexing
        Case SubSite.SeoFunctions.IndexingDirective.GooglebotNoindex
          AddMetaTag("googlebot", "noindex")
        Case SubSite.SeoFunctions.IndexingDirective.MsnbotNoindex
          AddMetaTag("msnbot", "noindex")
        Case SubSite.SeoFunctions.IndexingDirective.SlurpNoindex
          AddMetaTag("slurp", "noindex")
        Case SubSite.SeoFunctions.IndexingDirective.ToemaNoindex
          AddMetaTag("toema", "noindex")
      End Select
    End If


    html.Attributes.Add("lang", m_Language)
    'AddMetaTag(Nothing, m_Language, "content-language")
    'AddMetaTag("Language", m_Language)
    'AddMetaTag("Expires", Now.AddMinutes(2).ToString("r"))
    If User.Username = "" Then
      Response.Cache.SetExpires(Now.AddMinutes(2))
    End If

  End Sub

  Public Overrides Function MetaTag(ByVal Name As String) As HtmlMeta
    For Each Ctrl As Object In Me.Page.Header.Controls
      If TypeOf Ctrl Is HtmlMeta Then
        If Ctrl.Name = Name Then
          Return Ctrl
        End If
      End If
    Next
    Return Nothing
  End Function

  Public Overrides Sub AddMetaTag(ByVal Name As String, ByVal Content As String, Optional ByVal HttpEquiv As String = Nothing)
    Select Case LCase(Name)
      Case "author"
        AuthorOff = True
      Case "robots"
        If MetaRobots.Content IsNot Nothing Then
          MetaRobots.Content &= ","
        End If
        MetaRobots.Content &= Content
        Exit Sub
    End Select
    Dim MetaTag As New HtmlMeta()
    If Not Name Is Nothing Then
      MetaTag.Name = Name
    End If
    MetaTag.Content = Content
    If Not HttpEquiv Is Nothing Then
      MetaTag.HttpEquiv = HttpEquiv
    End If
    Me.Page.Header.Controls.Add(MetaTag)
  End Sub

  Public Overrides Sub SetTrace(ByVal ParamArray Controls() As Control)
    TraceControls = Controls
  End Sub
  Private Messages As New PlaceHolder
  Private Message As String
  Public Overrides Sub AddMessage(ByVal Text As String, Setting As SubSite, Optional ByVal ToolTip As String = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Type As MessageType = MessageType.Normal)
    If Messages.Controls.Count Then
      Messages.Controls.Add(BR)
    End If
    Messages.Controls.Add(Components.Message(Text, Setting, ToolTip, Href, Type))
    If Message <> "" Then
      Message &= vbCrLf
    End If
    Message &= Text
  End Sub

  Public Overrides Sub AddMessage(Setting As SubSite, ByVal IDText As Integer, Optional ByVal IDToolTip As Integer = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Type As MessageType = MessageType.Normal)
    Dim Text As String = Phrase(Setting.Language, IDText)
    AddMessage(Text, Setting, Phrase(Setting.Language, IDToolTip), Href, Type)
  End Sub

  Public Overrides Sub AddMessage(Control As Control)
    If Messages.Controls.Count Then
      Messages.Controls.Add(BR)
    End If
    Messages.Controls.Add(Control)
  End Sub

  Private _OverlappingContent As Boolean
  Public Overrides Property OverlappingContent() As Boolean
    Get
      Return _OverlappingContent
    End Get
    Set(ByVal value As Boolean)
      _OverlappingContent = value
    End Set
  End Property


  Public Sub AddCodeFromFile(ByVal Control As Control, Optional ByVal FileName As String = Nothing)
    If FileName Is Nothing Then
      FileName = Control.ID
    End If
    Dim Domain = CurrentDomain()
    For BySetting As Integer = 0 To 2
      For ByLanguage As Integer = 0 To 1
        Dim Lng As String
        Dim NameSetting As String = Nothing
        Select Case BySetting
          Case 0
            NameSetting = ""
          Case 1
            NameSetting = "." & Setting.Name
          Case 2
            NameSetting = "." & Domain
        End Select
        Select Case ByLanguage
          Case 0
            Lng = ""
          Case Else
            Lng = "." & LanguageManager.Acronym(Setting.Language)
        End Select
        Dim NameFile As String = FileName & NameSetting & Lng & ".html"
        Dim Code As String = HtmlCodesToAddingInPage(NameFile)
        If Code <> "" Then
          Dim CodeObj As New WebControls.Literal
          CodeObj.Text = Code
          Control.Controls.Add(CodeObj)
        End If
      Next
    Next
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Common.WebCache Is Nothing Then
      'Here Only once time operations!
      Common.WebCache = HttpContext.Current.Cache
      SyncLock Common.WebCache
        Dim NewThread As Threading.Thread = New Threading.Thread(AddressOf UpdateCodeFile)
        NewThread.Name = "UpdateCodeFile"
        NewThread.Priority = Threading.ThreadPriority.Lowest
        NewThread.IsBackground = True
        NewThread.Start()
      End SyncLock
    End If

    If UseAlternativeLoadPluginMethod = NeedAlternativeMethodLoad.Need Then
      UseAlternativeLoadPluginMethod = NeedAlternativeMethodLoad.Run
      Dim NewThread As Threading.Thread = New Threading.Thread(AddressOf LoadPluginsByAspxFileWebRequest)
      NewThread.Priority = Threading.ThreadPriority.Lowest
      NewThread.IsBackground = True
      NewThread.Start(PathCurrentUrl)
    End If
  End Sub
End Class




