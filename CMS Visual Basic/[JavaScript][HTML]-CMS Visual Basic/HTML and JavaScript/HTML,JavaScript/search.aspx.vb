Imports WebApplication
Partial Class search
  Inherits System.Web.UI.Page
  Private CallFromHomePage As Boolean
  Private Setting As SubSite
  Private Action As ActionType
  Private URL As String
  Private Q As String
  Private NotQ As String
	Private SearchLanguage As LanguageManager.Language
	Private NPage As Integer
	Private Blank As Boolean
	Private Preview As Boolean
	Private SearchWeb As Boolean
	Private SearchSale As Boolean
	Private SearchVideo As Boolean
	Private SearchQuestion As Boolean
	Private FindType As CriterionSearchType
	Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
	Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , True, True)
		Return Plugin
	End Function
	Shared Sub New()
		Initialize()
	End Sub

	Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
		If ShortDescription Then
      Return Phrase(Language, 4003)
		Else
      Return Phrase(Language, 4003)
		End If
	End Function

	Protected Sub StartSearch_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartSearch.Init
		Action = Val(Request.QueryString("a"))
		URL = Request.QueryString("URL")
		Q = Trim(System.Web.HttpUtility.UrlDecode(Request.QueryString("q")))
		NotQ = Trim(System.Web.HttpUtility.UrlDecode(Request.QueryString("not")))
		NPage = Val(Request.QueryString("np"))
		FindType = Val(Request.QueryString("cr"))

		Dim NotFound As Boolean
		Dim LoadError As Boolean
    Dim newImage As System.Drawing.Bitmap = Nothing

		Select Case Action
			Case search.ActionType.Thumbnail
        Dim Image As System.Drawing.Image = Nothing

				Dim Rwr As New Navigator.RemoteWebReader
				Dim Tr As Integer
				Do
					If Tr Then
						System.Threading.Thread.Sleep(3000)
					End If
					Tr += 1
					If Rwr.Image("http://images.websnapr.com/?url=" & URL & "&size=s", Image) Then
						LoadError = False

						Dim X As Integer = Image.Width
						Dim Y As Integer = Image.Height - 20
						newImage = New System.Drawing.Bitmap(X, Y)
						Dim graph = System.Drawing.Graphics.FromImage(newImage)
						'graph.Clear(System.Drawing.Color.White)
						Dim subtractPixels As Integer = Image.Height - Y

						'Crop
						Dim rect = New System.Drawing.Rectangle(0, 0, X, Y)
						graph.DrawImage(Image, New System.Drawing.Rectangle(0, 0, X, Y), rect, System.Drawing.GraphicsUnit.Pixel)
						graph.Dispose()
						'Check not found image
						Dim C1 As System.Drawing.Color = newImage.GetPixel(10, 10)
						Dim C2 As System.Drawing.Color = newImage.GetPixel(20, 20)
						Dim C3 As System.Drawing.Color = newImage.GetPixel(30, 30)
						If C1.ToArgb = -5434345 And C2.ToArgb = -1 And C3.ToArgb = -328966 Then
							NotFound = True
						Else
							NotFound = False
						End If

					Else
						LoadError = True
					End If

					'Dim g As Drawing.Graphics = Drawing.Graphics.FromImage(Image)


				Loop Until (NotFound = False And LoadError = False) Or Tr = 5


				If LoadError Or NotFound Then
					Call ResponseImageError()
				Else
					Response.ContentType = "image/jpeg"
					' send the resized image to the viewer
					newImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)		 ' output to the user
				End If
				newImage.Dispose()
		End Select
	End Sub

	Protected Sub StartSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartSearch.Load
		Setting = CurrentSetting()
		SearchLanguage = Setting.Language

		If Not LCase(Request.Url.LocalPath).EndsWith("/search.aspx") Then
			CallFromHomePage = True
		End If

		Dim MasterPage As MasterPage = SetMasterPage(Me, , True, True)
		'Add CSS
		MasterPage.AddHeader(CssBigInput)
		If Not CallFromHomePage Then
			MasterPage.TitleDocument = Phrase(Setting.Language, 4003)
			MasterPage.Description = Phrase(Setting.Language, 4003)
			MasterPage.KeyWords = Phrase(Setting.Language, 4003)
		End If

		Dim PhraseID As Integer = 3042
		For N As ActionType = CriterionSearchType.AllWords To CriterionSearchType.OneWords
			Dim Item As New WebControls.ListItem(Phrase(Setting.Language, PhraseID), N)
			If N = FindType Then
				Item.Selected = True
			End If
			PhraseID += 1
			FindCriterion.Items.Add(Item)
		Next

	End Sub

	Enum CriterionSearchType
		AllWords
		Phrase
		OneWords
	End Enum

	Protected Sub StartSearch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartSearch.PreRender
		LoadSearchSetting()

		If Q <> "" Then
			Query.Text = Q
			Query2.Text = Q
			Dim Master As MasterPage = Page.Master
			Master.TitleDocument &= ": " & Q
			Master.Description = Q
			Master.KeyWords = Q
		End If

		Select Case Action
			Case search.ActionType.Search
				If Q <> "" Then
					SearchExecutor(Q, NotQ, NPage)
				End If
		End Select

	End Sub


	Function RequestUrl(ByVal Action As ActionType, Optional ByVal URL As String = Nothing, Optional ByVal Q As String = Nothing, Optional ByVal NPage As Integer = 0, Optional ByVal Criterion As CriterionSearchType = CriterionSearchType.AllWords, Optional ByVal NotQ As String = Nothing) As String
		'RequestUrl = AppRelativeVirtualPath & "?a=" & Action
		'If URL IsNot Nothing Then RequestUrl &= "&url=" & System.Web.HttpUtility.UrlEncode(URL)
		'If Q IsNot Nothing Then RequestUrl &= "&q=" & System.Web.HttpUtility.UrlEncode(Q)
		If URL IsNot Nothing Then
			Return Href(Setting.Name, False, AppRelativeVirtualPath, "a", Action, "url", System.Web.HttpUtility.UrlEncode(URL))
		ElseIf Q IsNot Nothing Then
			Return Href(Setting.Name, False, AppRelativeVirtualPath, "a", Action, "q", System.Web.HttpUtility.UrlEncode(Q), "np", NPage, "cr", Criterion, "not", NotQ)
		End If
    Return Nothing
  End Function

	Private Function Boolean2N(ByVal Value As Boolean) As Integer
		If Value = False Then
			Return 0
		Else
			Return 1
		End If
	End Function

	Sub SearchExecutor(ByVal Q As String, ByVal NotQ As String, ByVal NPage As Integer)
		Dim PageLoaded As Date = Session("TimePageLoaded")
		If DateDiff(DateInterval.Second, PageLoaded, Now) < 5 Then
			Results.Controls.Add(Components.Message(Phrase(Setting.Language, 422) & ": " & Phrase(Setting.Language, 3245), Setting))
		Else
			If SearchWeb Then
				SearchExecutor(Q, SearchType.Web, NPage, NotQ)
			End If
			If SearchVideo Then
				SearchExecutor(Q, SearchType.Video, NPage)
			End If
			If SearchSale Then
				SearchExecutor(Q, SearchType.Sale)
			End If
			If SearchQuestion Then
				SearchExecutor(Q, SearchType.Question)
			End If
		End If
	End Sub

	Sub SearchExecutor(ByVal Q As String, ByVal Type As SearchType, Optional ByVal NPage As Integer = 0, Optional ByVal NotQ As String = Nothing)
		Dim Feeds As New System.Collections.Generic.List(Of NewsManager.Notice)
		Dim Request As New NewsManager.NewsRequire
		Request.AddAllRecords = True
    Dim TitleTable As String = Nothing
		Dim NRow As Integer = 1
		Select Case Type
			Case SearchType.Web
				If Preview Then
					NRow += 1
				End If
        Dim Query As String = Nothing
				Select Case FindType
					Case CriterionSearchType.AllWords
						Query = Q
					Case CriterionSearchType.OneWords
						Query = Join(Extension.ExtrapolateWords(Q), " OR ")
					Case CriterionSearchType.Phrase
						Query = """" & Q & """"
				End Select
				If NotQ <> "" Then
					Query &= " -(" & NotQ & ")"
				End If
				Request.XmlHref = "http://search.live.com/results.aspx?q=" & Query & "&format=rss&first=" & NPage * 10 + 1
				TitleTable = Phrase(CurrentSetting.Language, 4005)
			Case SearchType.Sale
				Request.XmlHref = "http://rss.api.ebay.com/ws/rssapi?FeedName=SearchResults&siteId=101&language=" & Acronym(Setting.Language) & "&satitle=" & Q
				TitleTable = Phrase(CurrentSetting.Language, 4006)
			Case SearchType.Video
				Request.XmlHref = "http://video.google.com/videofeed?type=search&so=3&num=20&output=rss&q=""" & Q & """" & "&hl=" & Acronym(Setting.Language) & "&start=" & NPage * 20
				TitleTable = Phrase(CurrentSetting.Language, 3258)
			Case SearchType.Question
        Dim Area As String = Nothing
				If Setting.Language <> LanguageManager.Language.English Then
					Area = Acronym(Setting.Language) & "."
				End If
				Request.XmlHref = "http://" & Area & "answers.yahoo.com/rss/searchq?p=""" & Q & """" & "&pn=" & NotQ
				TitleTable = Phrase(CurrentSetting.Language, 4007)
			Case SearchType.Images
				'http://search.live.com/images/results.aspx?q=frutta&format=xml
		End Select
		TitleTable = Phrase(CurrentSetting.Language, 4001) & " """ & TitleTable & """"
		ReadFeed(Feeds, Request)
		Dim Table As New HtmlTable
		Dim Target As String

		If Blank Then
			Target = "_blank"
		Else
			Target = "_self"
		End If

		'add row Title
		Dim TitleRow As HtmlTableRow = Components.HeaderRow(NRow, HorizontalAlign.Center, True)
		Table.Rows.Add(TitleRow)

		TitleRow.Cells(0).InnerText = TitleTable

		'Feed Filter
		Select Case Type
			Case SearchType.Web
				If NRow >= 2 Then
					TitleRow.Controls(1).Controls.Add(New LiteralControl(Phrase(CurrentSetting.Language, 4000)))
				End If
			Case SearchType.Video
				Dim NewGroupFeed As New System.Collections.Generic.List(Of NewsManager.Notice)
				For Each Feed As NewsManager.Notice In Feeds
					Dim VideoId As String = ExtrapolateVideoIdFromGoogleRss(Feed)
					If VideoId <> "" Then
						Feed.Link = VideoId
						AbjustFeedGoogleVideo(Feed)
						NewGroupFeed.Add(Feed)
					End If
				Next
				Feeds = NewGroupFeed
		End Select

		Dim Found As Boolean
		For Each Feed As NewsManager.Notice In Feeds
			Found = True

			Select Case Type
				Case SearchType.Question
					If Not Feed.Link.StartsWith("http:") Then
						Feed.Link = Mid(Feed.Link, 2, Len(Feed.Link) - 2)
					End If
			End Select

			Dim Row As New HtmlTableRow
			Row.Height = 132
			'Dim Row As WebControls.TableRow = Components.Row(c.GetUpperBound(0) + 1, , True)

			Table.Rows.Add(Row)

			Dim Cell As New HtmlTableCell
			Cell.Attributes.Add("vertical-align", "top")
			Row.Cells.Add(Cell)

			'Words to evidence in text
			Dim Words() As String = ExtrapolateWords(Q)
			SortStringByLength(Words)

			'Add Title
			Dim Title As New WebControls.HyperLink
			Title.CssClass = "SearchTitle"
			Title.Text = HttpUtility.HtmlEncode(EvidenceWords(Feed.Title, Words))
			Select Case Type
				Case SearchType.Sale, SearchType.Web, SearchType.Question
					Title.NavigateUrl = Feed.Link
			End Select
			Title.Target = Target
			'HCtrl.Controls.Add(Title)
			Cell.Controls.Add(Title)

			Cell.Controls.Add(BR)

			'Add video object
			Select Case Type
				Case SearchType.Video
					Cell.Controls.Add(VideoObject(Feed.Link, Setting, HttpContext.Current))
					Cell.Controls.Add(BR)
			End Select

			'Ad Description
			Dim Description As New WebControls.HyperLink
			Select Case Type
				Case SearchType.Web, SearchType.Video, SearchType.Question
					Description.Text = HttpUtility.HtmlEncode(EvidenceWords(Feed.Description, Words))
				Case SearchType.Sale
					Description.Text = HttpUtility.HtmlEncode(Feed.Description)
			End Select
			Select Case Type
				Case SearchType.Web, SearchType.Sale, SearchType.Question
					Description.Target = Target
					Description.NavigateUrl = Feed.Link
			End Select
			Cell.Controls.Add(Description)

			'Add link to URL
			Select Case Type
				Case SearchType.Web, SearchType.Question
					Cell.Controls.Add(BR)
					Cell.Controls.Add(BR)
					Dim LinkUrl As New WebControls.HyperLink
					LinkUrl.Text = HttpUtility.HtmlEncode(Feed.Link)
					LinkUrl.NavigateUrl = Feed.Link
					LinkUrl.Target = Target
					Cell.Controls.Add(LinkUrl)
			End Select

			'Add preview
			If NRow >= 2 Then
				Select Case Type
					Case SearchType.Web
						Dim CellThumb As New HtmlTableCell
						Row.Cells.Add(CellThumb)

						Dim Thumb As New WebControls.Image
						CellThumb.Controls.Add(Thumb)
						'Dim Domain As String = Mid(Feed.Link, 8)
						'Dim Pslesh As Integer = InStr(Domain, "/")
						'If Pslesh Then
						'Domain = Left(Domain, Pslesh - 1)
						'End If
						Thumb.ImageUrl = RequestUrl(ActionType.Thumbnail, Feed.Link)
				End Select
			End If

		Next
		If Found Then
			Results.Controls.Add(BR)
			Results.Controls.Add(Table)
			Search2.Visible = True
		Else
			Results.Controls.Add(Components.Message(TitleTable & ": " & Phrase(Setting.Language, 3440), Setting, , , MessageType.ErrorAlert))
		End If

		Select Case Type
			Case SearchType.Web, SearchType.Video
				'Add paginating tool
				Results.Controls.Add(BR)
				Results.Controls.Add(Paginate(Q, NotQ, NPage, Not Found))
		End Select

	End Sub

  Enum SearchType
    Web
    Sale
    Video
    Question
    Images
  End Enum


	Function Paginate(ByVal Q As String, ByVal NotQ As String, ByVal Npage As Integer, ByVal NotFound As Boolean) As Control
		Dim MaxPage As Integer
		If NotFound Then
			MaxPage = Npage
		Else
			MaxPage = 9
		End If
		Dim Panel As New HtmlGenericControl("nav")
		If Not (Npage = 0 And NotFound = True) Then
			If Npage Then
				Dim Prev As New WebControls.HyperLink
				Prev.NavigateUrl = PaginateNavigateUrl(Q, NotQ, Npage - 1)
				Prev.Text = Phrase(Setting.Language, 3251)
				Prev.CssClass = "SearchTitle"
				Panel.Controls.Add(Prev)
				AddSpace(Panel)
			End If
			For N As Integer = 0 To MaxPage
				Dim NLink As New WebControls.HyperLink
				If N <> Npage Then
					NLink.NavigateUrl = PaginateNavigateUrl(Q, NotQ, N)
					Dim Rel As Rel
					If N = Npage - 1 Then
						Rel = Components.Rel.Prev
					ElseIf N = Npage + 1 Then
						Rel = Components.Rel.Next
					Else
						Rel = Components.Rel.None
					End If
					If Rel <> Components.Rel.None Then
						NLink.Attributes("rel") = Rel.ToString.ToLower
					End If
				Else
					NLink.Style.Add("font-weight", "bold")
				End If
				NLink.Text = N + 1
				Panel.Controls.Add(NLink)
				AddSpace(Panel)
			Next
			If Npage <> MaxPage Then
				Dim Nex As New WebControls.HyperLink
				Nex.NavigateUrl = PaginateNavigateUrl(Q, NotQ, Npage + 1)
				Nex.Text = Phrase(Setting.Language, 3250)
				Nex.CssClass = "SearchTitle"
				Panel.Controls.Add(Nex)
				AddSpace(Panel)
			End If
		End If
		Return Panel

	End Function
  Private Function PaginateNavigateUrl(ByVal Q As String, ByVal NotQ As String, ByVal Npg As Integer) As String
    Return RequestUrl(ActionType.Search, , Q, Npg, FindType, NotQ)
  End Function

  Private Sub AddSpace(ByVal Ctrl As Control)
    Dim Space As New WebControls.Label
    Space.Text = " "
    Ctrl.Controls.Add(Space)
  End Sub




  Enum ActionType
    Search
    Thumbnail
  End Enum

  Sub SaveSearchSetting()
    If CurrentUser.GeneralRole > Authentication.User.RoleType.Visitors Then
			CurrentUser.Attribute("src_tb") = TargetBlank.Checked
			CurrentUser.Attribute("src_pr") = ShowPreview.Checked
			CurrentUser.Attribute("src_pr") = ShowPreview.Checked
			CurrentUser.Attribute("src_ws") = WebSearch.Checked
			CurrentUser.Attribute("src_ss") = SaleSearch.Checked
			CurrentUser.Attribute("src_vs") = VideoSearch.Checked
			CurrentUser.Attribute("src_qu") = QuestionSearch.Checked
    End If
    Cookie("src_tb") = TargetBlank.Checked
    Cookie("src_pr") = ShowPreview.Checked
    Cookie("src_ws") = WebSearch.Checked
    Cookie("src_ss") = SaleSearch.Checked
    Cookie("src_vs") = VideoSearch.Checked
    Cookie("src_qu") = QuestionSearch.Checked
  End Sub

  Sub LoadSearchSetting()
    Dim SetFromUser As Boolean
    If CurrentUser.GeneralRole > Authentication.User.RoleType.Visitors Then
			If CurrentUser.Attribute("src_tb") IsNot Nothing Then
				Blank = CurrentUser.Attribute("src_tb")
				SetFromUser = True
			End If
			If CurrentUser.Attribute("src_pr") IsNot Nothing Then
				Preview = CurrentUser.Attribute("src_pr")
			End If
			If CurrentUser.Attribute("src_ws") IsNot Nothing Then
				SearchWeb = CurrentUser.Attribute("src_ws")
			End If
			If CurrentUser.Attribute("src_ss") IsNot Nothing Then
				SearchSale = CurrentUser.Attribute("src_ss")
			End If
			If CurrentUser.Attribute("src_vs") IsNot Nothing Then
				SearchVideo = CurrentUser.Attribute("src_vs")
			End If
			If CurrentUser.Attribute("src_qu") IsNot Nothing Then
				SearchQuestion = CurrentUser.Attribute("src_qu")
			End If
    End If
    If Not SetFromUser Then
      Try
        Blank = Cookie("src_tb")
      Catch ex As Exception
        Blank = False
      End Try
      Try
        Preview = Cookie("src_pr")
      Catch ex As Exception
        Preview = False
      End Try
      Try
        SearchWeb = Cookie("src_ws")
      Catch ex As Exception
        SearchWeb = True
      End Try
      Try
        SearchSale = Cookie("src_ss")
      Catch ex As Exception
        SearchSale = False
      End Try
      Try
        SearchVideo = Cookie("src_vs")
      Catch ex As Exception
        SearchVideo = True
      End Try
      Try
        SearchQuestion = Cookie("src_qu")
      Catch ex As Exception
        SearchQuestion = False
      End Try
    End If

    TargetBlank.Checked = Blank
    ShowPreview.Checked = Preview
    WebSearch.Checked = SearchWeb
    SaleSearch.Checked = SearchSale
    VideoSearch.Checked = SearchVideo
    QuestionSearch.Checked = SearchQuestion
  End Sub

  Protected Sub search_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
    Session("TimePageLoaded") = Now
    If Query.Text = "" Then
      'Page.Controls.Add(Script("document.all(""" & Query.ClientID & """).focus();", ScriptLanguage.javascript))
      ScriptFocus.Controls.Add(Script("document.all." & Query.ClientID & ".focus();", ScriptLanguage.javascript))
      Dim SearchTxt As String = Phrase(Setting.Language, 3041)
      Query.Attributes.Add("onblur", "if (!this.value) this.value='" & SearchTxt & "'")
      Query.Attributes.Add("onclick", "if (this.value=='" & SearchTxt & "') this.value=''")
      'Query.Attributes.Add("value", SearchTxt)
    End If
  End Sub

  'Protected Sub Query2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Query2.TextChanged
  '  StartSearch2_Click(sender, e)
  'End Sub

  Protected Sub StartSearch2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartSearch2.Click
    'Query.Text = Query2.Text
    StartSearch_Click(sender, e)
  End Sub

  'Protected Sub Query_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Query.TextChanged
  '  StartSearch_Click(sender, e)
  'End Sub

  Protected Sub StartSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartSearch.Click
    If Query2.Text <> Q Then
      Query.Text = Query2.Text
    End If
    If Setup.Visible Then
      SaveSearchSetting()
    End If
    Response.Redirect(RequestUrl(ActionType.Search, , Query.Text, , Page.Request.Form(FindCriterion.UniqueID), NotTerms.Text))
  End Sub
End Class
