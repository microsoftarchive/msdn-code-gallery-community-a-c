Imports WebApplication
Partial Class _Default
	Inherits System.Web.UI.Page
	Private Setting As Config.SubSite
	Private Show As DefaultPageShowType
	Private ArchiveNumber As Integer
	Private NoArchiveSetting As Boolean
	Private PageNumber As Integer
	Private CurrentUser As User
  Private MasterPage As Components.MasterPage

  Protected Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit

      'Response.RedirectPermanent(AbsUrl, True)
    'Response.RedirectPermanent("http://pietroburgo.it", True)
 

      '++++++++ Compatibility old query string Key. Implemented 25/12/2012
    Dim AbsUrl As String = AbsoluteUri(Request)
    If Request.QueryString("p") IsNot Nothing Then AbsUrl = ReplaceBin(AbsUrl, "p=", QueryKey.ArticleNumber & "=")
    If Request.QueryString("a") IsNot Nothing Then AbsUrl = ReplaceBin(AbsUrl, "a=", QueryKey.ArchiveNumber & "=")
    If Request.QueryString("s") IsNot Nothing Then AbsUrl = ReplaceBin(AbsUrl, "&s=", "&" & QueryKey.Show & "=") : AbsUrl = ReplaceBin(AbsUrl, "?s=", "?" & QueryKey.Show & "=")
    If Request.QueryString("u") IsNot Nothing Then AbsUrl = ReplaceBin(AbsUrl, "u=", QueryKey.Url & "=")
    If Request.QueryString("url") IsNot Nothing Then AbsUrl = ReplaceBin(AbsUrl, "url=", QueryKey.Url & "=")
    If Request.QueryString("c") IsNot Nothing Then AbsUrl = ReplaceBin(AbsUrl, "c=", QueryKey.CryptedUrl & "=")
    Dim TPos As Integer = AbsUrl.IndexOf("&t=")
    If TPos <> -1 Then
      AbsUrl = AbsUrl.Substring(0, TPos)
    End If
    If String.Compare(AbsoluteUri(Request), AbsUrl, False) <> 0 Then
      AbsUrl = ReplaceText(AbsUrl, "/default.aspx", "/")
      Response.RedirectPermanent(AbsUrl, True)
    End If
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    Try
      CurrentUser = Authentication.CurrentUser
      Setting = CurrentSetting()
      If Request.QueryString(QueryKey.ArchiveNumber) IsNot Nothing Then
        ArchiveNumber = Request.QueryString(QueryKey.ArchiveNumber)
      Else
        NoArchiveSetting = True
      End If
      If Request.QueryString(QueryKey.ArticleNumber) IsNot Nothing Then PageNumber = Request.QueryString(QueryKey.ArticleNumber)
      If Request.QueryString(QueryKey.Show) IsNot Nothing Then Show = Request.QueryString(QueryKey.Show)
      If Show = DefaultPageShowType.Ip Then
        Response.ContentType = "text/plain"
        Response.Write(Request.UserHostAddress)
        Response.End()
      End If
    Catch ex As Exception
      'Log("ERROR QueryString in Default page", 100, AbsoluteUri(Request))
      RedirectToHomePage(Setting)
    End Try

    'File not found case
    If HttpContext.Current.Request.Url.Query.StartsWith("?404;") Then
      Dim AbsolutePath As String = HttpContext.Current.Request.Url.Query.Substring(5)

      If AbsolutePath.EndsWith("/sitemap.xml") Then
        Show = DefaultPageShowType.Sitemap
      ElseIf AbsolutePath.EndsWith("/sitemap-images.xml") Then
        Show = DefaultPageShowType.SitemapImages
      Else
        PageNotFound(AbsolutePath)
        RedirectToHomePage()
      End If
    End If

    Select Case Show
      Case DefaultPageShowType.Sitemap
        SiteMapGenerator(TypeOfSitemap.Generic)
      Case DefaultPageShowType.SitemapImages
        SiteMapGenerator(TypeOfSitemap.Images)
      Case DefaultPageShowType.Standard
        If NoArchiveSetting Then
          If Setting.PluginInHomePage <> "" Then
            Dim Plugin As PluginManager.Plugin = PluginManager.GetPlugin(Setting.PluginInHomePage)
            If Plugin IsNot Nothing Then
              If Plugin.SelectableAsHomePage And Plugin.IsEnabledAndAccessible(CurrentUser, Setting) Then
                Server.Transfer(Href(Setting.Name, False, Plugin.AspxFileName))
              End If
            End If
          End If
        End If
      Case DefaultPageShowType.RedirectToSearchEngine
        'Dim Redirect As String
        Dim BackToUrl As String = Session("BackToUrl")
        If BackToUrl = "" Then
          'Te session is reseted (restart of server)
          RedirectToHomePage()
        End If
        Dim Redirect1 As String = AbjustForJavascriptString(BackToUrl)
        Dim Redirect2 As String = AbjustForJavascriptString(Session("OutOfNetworkReferrer"))

        Dim Meta As String = Nothing
        Dim ScriptText As String = Nothing
        Dim Body As String = Nothing
        Dim Style As String = Nothing
        Dim Link As New HyperLink
        Link.NavigateUrl = "http://www.google.com/support/customsearch/bin/answer.py?hl=en&answer=70330"
        If Request.UrlReferrer IsNot Nothing Then

          Meta = "<meta http-equiv=""refresh"" content=""1;url=" & Redirect1 & """/>"
          Style = " style=""display:none"""
          ScriptText = "onload=function (){"
          ScriptText &= "var e=document.getElementById('frombackbutton'); if(e.value=='no'){"
          ScriptText &= "e.value='yes';"
          ScriptText &= "location=""" & Redirect1 & """;"
          ScriptText &= "}else{"
          If AutoAdSenseForSearch Then
            ScriptText &= "document.forms(0).submit();"
          Else
            'http://superuser.com/questions/322915/how-to-auto-redirect-browser-url-to-another-page
            ScriptText &= "window.location.assign(""" & Redirect2 & """);"
          End If
          ScriptText &= "}}"

        Else
          Link.Text = HttpUtility.HtmlEncode(Link.NavigateUrl)
        End If
        Meta &= "<meta name=""robots"" content=""noindex"" />"
        Body = ControlToText(Link)
        Body &= "<input type='hidden' id='frombackbutton' value='no'>"

        If AutoAdSenseForSearch Then
          Body &= "<form method=""get"" action=""http://www.google.com/custom""" & Style & "><input type=""hidden"" name=""sitesearch"" value=""" & CurrentDomain() & """></input><input type=""text"" name=""q"" size=""31"" maxlength=""255"" value=""" & Session("QuerySearch") & """></input><input type=""submit"" name=""sa"" value=""" & Phrase(Setting.Language, 3041) & """></input><input type=""hidden"" name=""client"" value=""" & Config.Setup.Affiliations.Google_Client & """></input><input type=""hidden"" name=""forid"" value=""1""></input><input type=""hidden"" name=""ie"" value=""ISO-8859-1""></input><input type=""hidden"" name=""oe"" value=""ISO-8859-1""></input><input type=""hidden"" name=""hl"" value=""it""></input></form>"
        End If

        If ScriptText <> "" Then
          ScriptText = ControlToText(Script(ScriptText, ScriptLanguage.javascript))
        End If

        Dim Head As String = "<head><title>" & HttpUtility.HtmlEncode(Redirect2) & "</title>" & Meta & "</head>"
        Body = "<body>" & Body & ScriptText & "</body>"


        Response.Clear()
        Response.Cache.SetExpires(Now.AddDays(-1))
        Response.ContentType = "text/html"
        Response.Write("<html>" & Head & Body & "</html>")
        Response.End()
    End Select

  End Sub

  Protected Sub Default_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Show <> DefaultPageShowType.RedirectToSearchEngine Then
      MasterPage = Page.Master

      Dim Canonical As New WebControl(HtmlTextWriterTag.Link)
      Canonical.Attributes.Add("rel", "canonical")
      Canonical.Attributes.Add("href", ReplaceText(AbsoluteUri(Request), "/default.aspx", "/"))
      MasterPage.Page.Header.Controls.Add(Canonical)


      Dim Content As Control = MasterPage.ContentPlaceHolder   ' Page.FindControl("Form1")
      Dim Url As String = Nothing

      If Request.QueryString(QueryKey.Url) IsNot Nothing Then
        Url = Request.QueryString(QueryKey.Url)
      ElseIf Request.QueryString(QueryKey.CryptedUrl) IsNot Nothing Then
        Url = DecryptUrl(Request.QueryString(QueryKey.CryptedUrl))
        If Show = DefaultPageShowType.Standard Then
          Show = DefaultPageShowType.News
        End If
      End If
      If Url IsNot Nothing Then
        Url = Url.Replace(vbCr, "")
        Url = Url.Replace(vbLf, "")

        If NotContentsFromDomains IsNot Nothing Then
          If IsCrawler(Request) = False Then
            Dim DomainUrl As String = ExtrapolateDomainName(Url)
            For Each Domain As String In NotContentsFromDomains
              If StrComp(Domain, DomainUrl, CompareMethod.Text) = 0 Or DomainUrl.EndsWith("." & Domain) Then
                Response.Redirect(Href(Setting.Name, False, "default.aspx"), True)
              End If
            Next
          End If
        End If

        'Anti iframe: Redirect to homepage if show this page under a proxy or page language translator
        Page.Header.Controls.Add(Script("if(top.location.href.indexOf(""" & HomePage() & """)!==0){top.location=""" & HomePage() & """}", ScriptLanguage.javascript))

        If Url IsNot Nothing AndAlso Not Url.StartsWith("http://") Then
          Url = "http://" & Url
        End If

        If Not Uri.IsWellFormedUriString(Url, UriKind.Absolute) Then
          RedirectToHomePage(Setting)
        End If

        If Not Setup.SEO.ShowContentAggregatorInThisHost Then
          If Not IsCrawler(Request) Then
            Response.Redirect(Url, True)
          End If
        End If
      End If

      Dim IsHomePage As Boolean = PageNumber = 0

      Select Case Show
        Case DefaultPageShowType.FeedRSS, DefaultPageShowType.OnlineUsers, DefaultPageShowType.Sitemap
        Case Else
          'Add meta for RSS source
          Dim Meta As New HtmlLink
          Meta.Attributes.Add("rel", "alternate")
          Meta.Attributes.Add("type", "application/rss+xml")
          Meta.Attributes.Add("title", "Feed RSS")
          Meta.Href = Href(Setting.Name, False, "default.aspx", QueryKey.Show, Common.DefaultPageShowType.FeedRSS)
          Page.Header.Controls.Add(Meta)
      End Select

      Select Case Show
        Case DefaultPageShowType.News
          If Url IsNot Nothing Then
            MasterPage.MetaRevisitAfterDays = 365
          End If
        Case DefaultPageShowType.ExternalPage
          MasterPage.MetaRevisitAfterDays = 365
        Case DefaultPageShowType.FeedRSS
          Dim rssFeed As New FeedRSSManager.rss
          rssFeed.channel.title = Setting.Title
          rssFeed.channel.description = Setting.Description
          rssFeed.channel.link = Href(Setting.Name, True, "default.aspx") 'Page.AbsoluteUri(Request)
          rssFeed.channel.language = LanguageManager.Acronym(Setting.Language)

          'Add forum
          If Setting.Forums IsNot Nothing Then
            For Each Forum As Integer In Setting.Forums
              FeedRssForum(rssFeed, Setting, EnableShowHidden, Forum)
            Next
          End If

          'Add link to external blog
          If Setting.EnableRelatedBlogAggregator AndAlso Setting.Blog IsNot Nothing AndAlso Setting.Blog.Count > 0 Then
            For Each Blog As Notice In Setting.Blog
              Dim rssItem As New rssChannelItem
              If Not UrlPointToThisNetwork(Blog.Link) Then
                rssItem.link = Common.Href(CurrentSetting.Name, True, "default.aspx", QueryKey.Show, DefaultPageShowType.ExternalPage, QueryKey.Url, Blog.Link.Substring(Blog.Link.IndexOf("/"c) + 2))
              End If
              rssItem.title = InnerText(Blog.Title)
              rssItem.description = InnerText(Blog.Description)
              rssItem.pubDate = Format(Blog.pubDate.ToUniversalTime, "R")

              If Blog.Image IsNot Nothing Then
                Dim Image As New Enclosure
                Image.url = Blog.ImageSrc(True)
                Dim Extension As String = Blog.Image.ToLower.Substring(Blog.Image.LastIndexOf("."c) + 1)
                Image.type = "image/" & Extension
                rssItem.enclosure = Image
              End If
              rssFeed.channel.item.Add(rssItem)
            Next
          End If

          'Add link to news
          Dim Notices As Collections.Generic.List(Of Notice) = NewsManager.News(Setting.News)
          If Notices IsNot Nothing AndAlso Notices.Count > 0 Then

            For Each ThisNews As Notice In Notices
              Dim CryptedUrl As String = CryptUrl(ThisNews.Link.Substring(ThisNews.Link.IndexOf("/"c) + 2))
              If CryptedUrl IsNot Nothing Then
                Dim rssItem As New rssChannelItem
                rssItem.link = Common.Href(CurrentSetting.Name, True, "default.aspx", QueryKey.CryptedUrl, CryptedUrl)
                rssItem.title = InnerText(ThisNews.Title)
                rssItem.description = InnerText(ThisNews.Description)
                rssItem.pubDate = Format(ThisNews.pubDate, "R")
                If ThisNews.Image <> "" Then
                  Dim Image As New Enclosure
                  Image.url = ThisNews.ImageSrc(True)
                  Dim Extension As String = ThisNews.Image.ToLower.Substring(ThisNews.Image.LastIndexOf("."c) + 1)
                  Image.type = "image/" & Extension
                  rssItem.enclosure = Image
                End If
                rssFeed.channel.item.Add(rssItem)
              End If
            Next
          End If

          'Add Menu
          If Setting.Archive IsNot Nothing Then
            For Each Archive As Integer In Setting.Archive
              Dim Menu As Menu = Menu.Load(Archive, Setting.Language)
              If Menu IsNot Nothing Then
                For Each Item As ItemMenu In Menu.ItemsMenu
                  If Item.IdPage <> 0 AndAlso Item.Off = False Then
                    Dim Html As String = ReadAll(MenuManager.PageNameFile(Menu.Archive, Item.IdPage, Setting.Language))
                    Dim MetaTags As New MetaTags(Html)
                    Dim PubDate As Date = TextToDate(MetaTags.MetaTag("date"))

                    If DateDiff(DateInterval.Day, PubDate, Now.ToUniversalTime) < 90 Then
                      Dim rssItem As New rssChannelItem
                      rssItem.link = Item.Href(CurrentDomainConfiguration, Setting, True)
                      rssItem.title = Item.Description.Label
                      rssItem.description = IfStr(Item.Description.Title <> "", Item.Description.Title, Item.Description.Label)
                      rssItem.pubDate = Format(PubDate, "R")

                      Dim TagPhoto As String = MetaTags.MetaTag("Photo")
                      Dim Photo As Photo
                      If TagPhoto <> "" Then
                        Photo = Photo.Load(TagPhoto)
                        If Photo IsNot Nothing Then
                          Dim Image As New Enclosure
                          Image.url = PathCurrentUrl() & Photo.SrcThumbnail(Setting, SizeImagePreview)
                          Image.type = Photo.MimeType
                          rssItem.enclosure = Image
                        End If
                      End If
                      rssFeed.channel.item.Add(rssItem)
                    End If

                  End If
                Next
              End If
            Next
          End If

          Response.ContentType = "text/xml;charset=utf-8"
          FeedRSSManager.RssFeedGenerator(Response.OutputStream, rssFeed)
          Response.End()
      End Select

      Dim ContentPlaceHolder As ContentPlaceHolder
      Select Case Show
        Case DefaultPageShowType.Standard
          'If Setting.SEO.Add5StarRatingIntoPagesOfContent Then
          '	MasterPage.Rating = 5
          'End If
          If IsHomePage Then
            'First startup
            Select Case IsFirstRunning(Setting)
              Case TypeOfFirstRunning.Application
                Response.Redirect(Href(Setting.Name, False, "log.aspx", QueryKey.ActionLog, 2))
              Case TypeOfFirstRunning.Site
                If OEM.DefaultSiteConfiguration <> "" Then
                  Session("ReturnUrl") = "setup.aspx"
                  Response.Redirect(Href(Setting.Name, False, "log.aspx"))
                End If
            End Select
            ContentPlaceHolder = SetPageDefault(Me, Content, Setting, , True, True, True, True)
            MasterPage.MetaRevisitAfterDays = 1
            'MasterPage.UseGoogleOff = False
          Else
            ContentPlaceHolder = SetPageDefault(Me, Content, Setting, , False, False, True, False)
            If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
              'Add Button Edit current page
              MasterPage.AddButton(Phrase(Setting.Language, 3012), Href(Setting.Name, False, "edit.aspx", "archive", ArchiveNumber, "lang", Setting.Language, "page", PageNumber), , IconType.Pen, , True, , Setting.Aspect.SuggestTheBestChoiceByTheBlink)
            End If
          End If
        Case Else
          ContentPlaceHolder = Content
          SetMasterPage(Me)
      End Select

      If Show = DefaultPageShowType.Standard AndAlso PageNumber = 0 AndAlso Setting.Aspect.FirstDocumentInHomePage Then
        'Find ID of first page
        PageNumber = FirstDocument(Setting, ArchiveNumber)
      End If

      If PageNumber Then
        'Find Current menu
        Dim CurrentMenu As MenuManager.Menu = FindMenu(Setting, ArchiveNumber)

        'load page
        If ArchiveNumber = 0 Then
          If Setup.SEO.NoindexForDocumentsInArchive0 Then
            MasterPage.AddMetaTag("robots", "noindex")
          End If
          Components.AddPageArchived(ContentPlaceHolder, Master, ArchiveNumber, PageNumber, HttpContext.Current, CurrentDomainConfiguration, Setting, , IsHomePage)
          Select Case PageNumber
            Case 6
              'Add "About us" in title page and description
              MasterPage.TitleDocument = Phrase(Setting.Language, 2006)
              MasterPage.Description = Phrase(Setting.Language, 2006)
              MasterPage.KeyWords = Phrase(Setting.Language, 2006)
          End Select
        ElseIf CurrentMenu IsNot Nothing Then
          InsertPageContent(ContentPlaceHolder, MasterPage, Setting, CurrentMenu, PageNumber, IsHomePage)

          If IsHomePage AndAlso CurrentDomainConfiguration.AvailableAllSubSite Then
            'Add SubSite Index for this host
            Dim Link As String
            Dim Domains As StringCollection = AllDomainNames()

            'Generation table host/subsite
            Dim SubsiteDomainTable As New Collections.Specialized.StringDictionary
            If Not Domains Is Nothing Then
              For Each DomainName As String In Domains
                Dim Domain As DomainConfiguration
                Domain = DomainConfiguration.Load(DomainName)
                If Domain.SubSitesAvailable.Count <> 0 Then
                  Dim SubsiteDomain As SubSite = SubSite.Load(Domain.SubSitesAvailable(0))
                  If Not SubsiteDomainTable.ContainsKey(SubsiteDomain.Name) Then
                    SubsiteDomainTable.Add(SubsiteDomain.Name, DomainName)
                  End If
                End If
              Next
            End If
            For Each SubSite As SubSite In CurrentDomainConfiguration.SubSites
              'Add flag
              ContentPlaceHolder.Controls.Add(Flag(SubSite.Language))
              'Find host for this Subsite
              If SubsiteDomainTable.ContainsKey(SubSite.Name) Then
                'Add external link
                Link = "http://www." & SubsiteDomainTable(SubSite.Name)
              Else
                'Add internal link
                Link = Href(SubSite.Name, False, Nothing)
              End If
              ContentPlaceHolder.Controls.Add(Components.Link(Link, SubSite.Title, SubSite.Description))
              ContentPlaceHolder.Controls.Add(BR)
            Next
          End If
        Else

          'Redirect to appropriate domain if the archive is not finded for this configuration
          Dim TryDomain As DomainConfiguration
          For Each DomainName As String In AllDomainNames()
            TryDomain = DomainConfiguration.Load(DomainName)
            If TryDomain IsNot Nothing Then
              For Each SubSite As SubSite In TryDomain.SubSites
                If SubSite.Archive IsNot Nothing Then
                  For Each Archive As Integer In SubSite.Archive
                    If Archive = ArchiveNumber Then
                      Dim Menu As Menu = Menu.Load(Archive, SubSite.Language)
                      For Each ItemMenu As MenuManager.ItemMenu In Menu.ItemsMenu
                        If ItemMenu.IdPage = PageNumber Then
                          Dim Redirect As String = ItemMenu.Href(TryDomain, SubSite, True)
                          Extension.Log("redirect", 1000, AbsoluteUri(HttpContext.Current.Request), Redirect, HttpContext.Current.Request.UserHostAddress)
                          Response.RedirectPermanent(Redirect, True)
                        End If
                      Next
                    End If
                  Next
                End If
              Next
            End If
          Next
        End If

        'If IsHomePage Then
        'Not set metatags about document for home page
        'In homepage use only metatags setting with setup
        'MetaTags = Nothing
        'End If
      ElseIf Show = DefaultPageShowType.ListPhotoAlbum Then
        If Setting.Photoalbums IsNot Nothing Then
          Dim Fieldset As New WebControl(HtmlTextWriterTag.Fieldset)
          Dim Box As New HtmlGenericControl("nav")
          Fieldset.Controls.Add(Box)
          Fieldset.BorderStyle = BorderStyle.None
          Box.Attributes.Add("class", "Menu")
          For Each NamePhotoAlbum As String In Setting.Photoalbums
            Dim PhotoAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(NamePhotoAlbum)
            Box.Controls.Add(PhotoAlbum.Control(Setting, 0))
          Next
          ContentPlaceHolder.Controls.Add(Fieldset)
        End If
      ElseIf Show = DefaultPageShowType.OnlineUsers Then
        ContentPlaceHolder.Controls.Add(Components.OnlineUser(Setting, , CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior))
        MasterPage.TitleDocument = Phrase(Setting.Language, 131)
        MasterPage.Description = Phrase(Setting.Language, 131)
        MasterPage.KeyWords = Phrase(Setting.Language, 131)
        MasterPage.AddMetaTag("robots", "noindex")
      ElseIf Show = DefaultPageShowType.News Then
        If Url <> "" Then
          'Show news in frame
          AddContent(Url)
        ElseIf Setting.News IsNot Nothing AndAlso Setting.News.SourcesRSS IsNot Nothing AndAlso Setting.News.SourcesRSS.Count Then
          'Show index of news
          Dim News As Control = Components.NewsPreview(Setting, NewsManager.News(Setting.News))
          MasterPage.TitleDocument &= " " & Phrase(Setting.Language, 2)
          MasterPage.Description = MasterPage.TitleDocument
          MasterPage.KeyWords = MasterPage.TitleDocument
          If News IsNot Nothing Then
            ContentPlaceHolder.Controls.Add(News)
          End If
        End If
      ElseIf Show = DefaultPageShowType.ExternalPage Then
        AddFrame(Url)
      End If
    End If
  End Sub

  Public Sub AddContent(ByVal Url As String)
    Dim Html As String = Nothing
    Dim MetaTags As MetaTags = Nothing
    Dim NotIsHtml As Boolean
    Dim WebSiteSummary As WebSiteSummary = Nothing
    Try
      WebSiteSummary = RielaborationTextFromWeb(Url, Setting.Language, Html, MetaTags)
    Catch ex As System.Net.WebException
      Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
    Catch ex As Exception
      NotIsHtml = True
    End Try

    If WebSiteSummary Is Nothing OrElse Not WebSiteSummary.HaveText Then
      AddFrame(Url, Not NotIsHtml, Html, WebSiteSummary)
    Else
      Dim MasterPage As Components.MasterPage = Page.Master
      'If IsCrawler(Request) Then
      'No archive
      MasterPage.AddMetaTag("robots", "noarchive")
      'Else
      'Add "canonical"
      'Dim Link As New WebControl(HtmlTextWriterTag.Link)
      'Link.Attributes.Add("rel", "canonical")
      'Link.Attributes.Add("href", Url)
      'MasterPage.AddHeader(ControlToText(Link))
      'End If
      If CBool(Setup.SEO.ForContentAcquiredFromExternalSourcesApplyTheTagGooglebotUnavailableAfterSettedToDays) Then
        MasterPage.AddMetaTag("googlebot", "unavailable_after: " & Now.ToUniversalTime.AddDays(Setup.SEO.ForContentAcquiredFromExternalSourcesApplyTheTagGooglebotUnavailableAfterSettedToDays).ToString("dd\-MMM\-yyyy HH\:mm\:ss", Globalization.CultureInfo.InvariantCulture) & " GMT")
      End If
      InsertWebSiteSummary(WebSiteSummary, Page.Master)
    End If

  End Sub

  Public Sub AddFrame(ByVal Url As String, Optional ByRef IsHtml As Boolean = True, Optional ByVal Html As String = Nothing, Optional ByVal WebSiteSummary As WebSiteSummary = Nothing, Optional ByVal MetaTags As MetaTags = Nothing)
    If Url = "" Then
      RedirectToHomePage(Setting)
    End If
    If Setup.Security.DoNotOpenIframeOnSitesContainingMalware AndAlso MalwareDomain(Url) Then
      RedirectToHomePage(Setting, False)
    End If

    Dim Ctrl As New Control
    Dim NoFrame As String = Nothing
    Dim MasterPage As Components.MasterPage = Page.Master
    If WebSiteSummary Is Nothing AndAlso IsHtml Then
      Try
        WebSiteSummary = RielaborationTextFromWeb(Url, Setting.Language, Html, MetaTags)
      Catch ex As System.Net.WebException
        Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
      Catch ex As Exception
        MasterPage.TitleDocument = ex.Message
        IsHtml = False
      End Try
    End If

    If Html <> "" Then
      If Setting.NotIncludeSitesCensoredIntoFrame Then
        If IsCrawler(Request) Then
          'SEO: never include into the iframe censored website
          RedirectToHomePage(Setting, False)
        Else
          'SEO: If the external site contains censored words (porn, sex, ecc..), dont create a directly redirection but use a javascript to ask to user a really intention to visit the website
          If TextContainCensored(Html) Then
            Dim From As String
            If Request.UrlReferrer IsNot Nothing Then
              From = Request.UrlReferrer.AbsoluteUri
            End If
            Dim ScriptCode As Control = Script("if (confirm('" & AbjustForJavascriptString(Phrase(Setting.Language, 146) & " " & Url) & "')){window.location.href='" & AbjustForJavascriptString(Url) & "'}else{window.location.href='" & AbjustForJavascriptString(From) & "'}", ScriptLanguage.javascript)
            Response.Clear()
            Response.ContentType = "text/html"
            Response.Cache.SetExpires(Now.AddYears(1))
            Response.Write("<html><head><meta http-equiv='refresh' content='30;URL='" & AbjustForJavascriptString(From) & "''><meta name='revisit-after' content='12 month'><meta name='robots' content='noindex'>" & ControlToText(ScriptCode) & "</head></html>")
            Response.Flush()
            Response.End()
          End If
        End If
      End If
    End If

    If IsHtml Then
      'If IsCrawler(Request) Then
      'No archive
      MasterPage.AddMetaTag("robots", "noarchive")
      'Else
      'Add "canonical"
      'Dim Link As New WebControl(HtmlTextWriterTag.Link)
      'Link.Attributes.Add("rel", "canonical")
      'Link.Attributes.Add("href", Url)
      'MasterPage.AddHeader(ControlToText(Link))
      'End If
      If CBool(Setup.SEO.ForContentAcquiredFromExternalSourcesApplyTheTagGooglebotUnavailableAfterSettedToDays) Then
        MasterPage.AddMetaTag("googlebot", "unavailable_after: " & Now.ToUniversalTime.AddDays(Setup.SEO.ForContentAcquiredFromExternalSourcesApplyTheTagGooglebotUnavailableAfterSettedToDays).ToString("dd\-MMM\-yyyy HH\:mm\:ss", Globalization.CultureInfo.InvariantCulture) & " GMT")
      End If

 
      Dim Title, Description As String
      If WebSiteSummary IsNot Nothing Then
        MetaTagFromWebSiteSummary(WebSiteSummary, MasterPage)
        Title = WebSiteSummary.Title
        Description = WebSiteSummary.Description
        'Dim H1 As New WebControl(HtmlTextWriterTag.H1)
        'If Setting.SEO.CopyPrevention.FromExternalSources Then
        '  H1.Controls.Add(New LiteralControl(ObfuscateHtml(WebSiteSummary.Title, Setting)))
        '  Ctrl.Controls.Add(H1)
        '  Ctrl.Controls.Add(New LiteralControl(ObfuscateHtml(WebSiteSummary.Description, Setting)))
        'Else
        '  H1.Controls.Add(TextControl(WebSiteSummary.Title))
        '  Ctrl.Controls.Add(H1)
        '  Ctrl.Controls.Add(TextControl(WebSiteSummary.Description))
        'End If
      Else
        If MetaTags Is Nothing Then
          MetaTags = New MetaTags(Html)
        End If
        Title = MetaTags.Title
        Description = MetaTags.Description
        MasterPage.TitleDocument = Title
        MasterPage.Description = Description
        MasterPage.KeyWords = MetaTags.KeyWords
        'Dim H1 As New WebControl(HtmlTextWriterTag.H1)
        'If Setting.SEO.CopyPrevention.FromExternalSources Then
        '  H1.Controls.Add(New LiteralControl(ObfuscateHtml(MetaTags.Title, Setting)))
        '  Ctrl.Controls.Add(H1)
        '  Ctrl.Controls.Add(New LiteralControl(ObfuscateHtml(MetaTags.Description, Setting)))
        'Else
        '  H1.Controls.Add(TextControl(MetaTags.Title))
        '  Ctrl.Controls.Add(H1)
        '  Ctrl.Controls.Add(TextControl(MetaTags.Description))
        'End If
      End If

      ContextualLink.AddContextualLinks(Title, Setting, Setting.MainArchive)
      ContextualLink.AddContextualLinks(Description, Setting, Setting.MainArchive)
      Dim H1 As New WebControl(HtmlTextWriterTag.H1)
      If Setting.SEO.CopyPrevention.FromExternalSources Then
        Title = ObfuscateHtml(Title, Setting)
        Description = ObfuscateHtml(Description, Setting)
      End If
      H1.Controls.Add(New LiteralControl(Title))
      Ctrl.Controls.Add(H1)
      Ctrl.Controls.Add(New LiteralControl(Description))


      If WebSiteSummary IsNot Nothing AndAlso WebSiteSummary.HaveText Then
        NoFrame = ControlToText(WebSiteSummary.Control)
      Else
        If MetaTags Is Nothing Then
          MetaTags = New MetaTags(Html)
        End If

        NoFrame = "<h1>" & HttpUtility.HtmlEncode(MetaTags.Title) & "</h1>"
        If Setup.SEO.ChangeTheContentOfAggregatorsUsingSynonyms Then
          NoFrame &= HttpUtility.HtmlEncode(RielaborationText(InnerText(Html), Setting.Language))
        Else
          NoFrame &= InnerHtml(Html)
        End If
      End If
      If Setting.SEO.CopyPrevention.FromExternalSources Then
        NoFrame = ObfuscateHtml(NoFrame, Setting)
      End If
    End If

    Dim Fieldset As New WebControl(HtmlTextWriterTag.Fieldset)
    Fieldset.Controls.Add(IFrame("100%", Nothing, Url, ContextualLink.AddLinks(NoFrame, Setting, CurrentDomainConfiguration, Setting.MainArchive)))
    MasterPage.AdSenseDisabled = True 'Note: https://www.google.com/adsense/support/bin/answer.py?answer=105956
    Ctrl.Controls.Add(Fieldset)

    MasterPage.ContentPlaceHolder.Controls.Add(Ctrl)
  End Sub

End Class
