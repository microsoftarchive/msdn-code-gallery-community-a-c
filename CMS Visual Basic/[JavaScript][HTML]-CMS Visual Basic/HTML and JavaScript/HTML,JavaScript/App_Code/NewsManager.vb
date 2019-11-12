'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic
Namespace WebApplication
	Public Module NewsManager
		'List of good rss source:
		'"http://rss.news.yahoo.com/rss/russia"
		'  
		'Public AllNews As Notice() = AllNewsArchived(True)
		Public AllNews As Collections.Generic.List(Of Notice)

		Private Function AllNewsArchived(Optional ByVal Sort As Boolean = False) As Collections.Generic.List(Of Notice)
      Dim AllNews As Collections.Generic.List(Of Notice) = LoadObject(GetType(Collections.Generic.List(Of Notice)), "News")
			If AllNews IsNot Nothing Then
				For N As Integer = AllNews.Count - 1 To 0 Step -1
					Dim News As Notice = AllNews(N)
          If Not Recent(Now.ToUniversalTime, News.pubDate, New TimeSpan(Setup.SEO.MaintainsContentsInTheNewsListForDays, 0, 0, 0)) Then
            AllNews.Remove(News)
          End If
				Next
				Return AllNews
			Else
				Return New Collections.Generic.List(Of Notice)
			End If
		End Function

    'Function News(ByVal Find As FilterNews) As Collections.Generic.List(Of Notice)
    '  If AllNews IsNot Nothing Then
    '    Dim Result As New Collections.Generic.List(Of Notice)
    '    Try
    '      For Each NewsArchived As Notice In AllNews.ToArray
    '        If ValidForCriteria(NewsArchived, Find) Then
    '          Result.Add(NewsArchived)
    '        End If
    '      Next
    '    Catch ex As Exception
    '    End Try
    '    Return Result
    '  End If
    '  Return Nothing
    'End Function

		Function News(ByVal Find As FilterNews) As Collections.Generic.List(Of Notice)
      If AllNews IsNot Nothing Then
        Dim Result As New Collections.Generic.List(Of Notice)
        Try
          For Each NewsArchived As Notice In AllNews.ToArray
            If ValidForCriteria(NewsArchived, Find) Then
              Result.Add(NewsArchived)
            End If
          Next
        Catch ex As Exception
        End Try
        Return Result
      End If
      Return Nothing
    End Function

		Sub SortNews(ByRef News As Collections.Generic.List(Of Notice))
			If News IsNot Nothing AndAlso News.Count <> 0 Then
				Dim SortCriterion As New DateNewsComparer
				News.Sort(SortCriterion)
				'System.Array.Sort(News, SortCriterion)
			End If
		End Sub

		Public Class DateNewsComparer
			Implements System.Collections.Generic.IComparer(Of Notice)
			Public Function Compare(ByVal info1 As Notice, ByVal info2 As Notice) As Integer Implements System.Collections.Generic.IComparer(Of Notice).Compare
				Dim RSS1 As Notice = info1
				Dim RSS2 As Notice = info2

				Dim x1 As Date
				If RSS1 Is Nothing Then
					Return -1
				Else
					x1 = RSS1.pubDate
				End If

				Dim x2 As Date
				If RSS2 Is Nothing Then
					Return -1
				Else
					x2 = RSS2.pubDate
				End If

				If x1 < x2 Then
					Return 1
				End If
				If x1 > x2 Then
					Return -1
				End If
				Return 0
			End Function 'Compare
		End Class	'SizeComparer

		Class FilterNews
			Public KeyWords As String()
			Public NotKeywords As String()
			Public SourcesRSS As String()
			Public Language As LanguageManager.Language = Language.NotDefinite
			Public After As Date = #1/1/1990#
		End Class

		Function ValidForCriteria(ByVal RSS As Notice, ByVal KeyWords As String(), ByVal NotKeyWords As String()) As Boolean
			Dim Find As New FilterNews
			Find.KeyWords = KeyWords
			Find.NotKeywords = NotKeyWords
			Return ValidForCriteria(RSS, Find)
		End Function

		Function ValidForCriteria(ByVal News As Notice, ByVal Find As FilterNews) As Boolean
			'Filter of news: Check if the news is valid
			If Find.Language <> LanguageManager.Language.NotDefinite Then
				If (News.Language <> Find.Language) And Not News.Language = LanguageManager.Language.NotDefinite Then
          Return False
				End If
			End If
      If Not Find.SourcesRSS Is Nothing Then
        Dim Finded As Boolean
        For Each SourceRSS As String In Find.SourcesRSS
          If News.XmlHref.ToLower.StartsWith(SourceRSS.ToLower) Then
            Finded = True
            Exit For
          End If
        Next
        If Not Finded Then
          Return False
        End If
      End If
			If Not Find.KeyWords Is Nothing Then
				Dim Finded As Boolean = False
				For Each Word As String In Find.KeyWords
					If FindWord(News.Title, Word) Then
						Finded = True
						Exit For
					ElseIf FindWord(News.Description, Word) Then
						Finded = True
						Exit For
					End If
				Next
				If Not Finded Then
          Return False
				End If
			End If
			If Not Find.NotKeywords Is Nothing Then
				For Each Word As String In Find.NotKeywords
					If FindWord(News.Title, Word) Then
						Return False
					ElseIf FindWord(News.Description, Word) Then
						Return False
					End If
				Next
			End If
			If Find.After <> #1/1/1990# Then
				If News.pubDate < Find.After Then
          Return False
				End If
			End If
			Return True
		End Function

		Public Sub AddNews(ByRef Notices As Collections.Generic.List(Of Notice), ByVal NewsRequire As NewsRequire)
			ReadFeed(Notices, NewsRequire, , True)
		End Sub

		Class NewsRequire
			Public XmlHref As String
			Public KeyWords As String()
			Public NotKeyWords As String()
			Public AddAllRecords As Boolean
			Public UpdateEvery As New TimeSpan(12, 0, 0)
			Public LastUpdate As Date
		End Class

		Function PubDateToDate(ByVal PubDate As String) As Date
			'Convert PubDate value in RSS Feed to Dete
			Try
				Return System.DateTime.ParseExact(PubDate, "r", Nothing) 'In google news the value is in Universal Time
				'Return System.DateTime.ParseExact(PubDate, "r", Nothing).ToUniversalTime 
			Catch ex As Exception
				Try
					'Google news format
					Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
          Return System.DateTime.ParseExact(ReplaceBin(PubDate, "GMT+00:00", "GMT"), "ddd, dd MMM yyyy HH:mm:ss 'GMT'", Culture)
				Catch ex2 As Exception
					Try
						'Skype date format
						Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
						Return System.DateTime.ParseExact(PubDate, "ddd, dd MMM yyyy HH:mm:ss zzz", Culture)
						'Return System.DateTime.ParseExact(PubDate.Substring(5, 20), "dd MMM yyyy HH:mm:ss", Culture)
					Catch ex3 As Exception
						Try
							Return DateSerial(Mid(PubDate, 13, 4), Month(Mid(PubDate, 9, 3)), Mid(PubDate, 6, 2)).ToUniversalTime
						Catch ex4 As Exception
							Return Now.ToUniversalTime
						End Try
					End Try
				End Try
			End Try
		End Function

		Private Function Month(ByVal Text As String) As Integer
			'Convert Month to enum value
			Select Case Text.ToLower
				Case "jan"
					Return 1
				Case "feb"
					Return 2
				Case "mar"
					Return 3
				Case "apr"
					Return 4
				Case "may"
					Return 5
				Case "jun"
					Return 6
				Case "jul"
					Return 7
				Case "aug"
					Return 8
				Case "sep"
					Return 9
				Case "oct"
					Return 10
				Case "nov"
					Return 11
				Case "dec"
					Return 12
			End Select
      Return 0
    End Function

		<Serializable()> Public Class Notice
			'Serializable object used to save the news
			Public ID As Integer
			Public Title As String
			Public Description As String
			Public Link As String
			Public Language As LanguageManager.Language
			Private m_Guid As String
			Property Guid() As String
				Get
					If m_Guid Is Nothing Then
						Return Link
					Else
						Return m_Guid
					End If

				End Get
				Set(ByVal Value As String)
					m_Guid = Value
				End Set
			End Property
			Public pubDate As Date
			Public Image As String
			Public ReadOnly Property ImageSrc(Optional ByVal AbsoluteAddress As Boolean = False) As String
				Get
          Return Href(CurrentDomainConfiguration, Nothing, True, "viewthumb.aspx", QueryKey.ThumbSize, SizeThumbnail, QueryKey.ThumbSource, Me.Image)
				End Get
			End Property
			Public XmlHref As String
			Public Function Control(ByVal Setting As SubSite) As Control
        Dim CryptedUrl As String = CryptUrl(Me.Link.Substring(Me.Link.IndexOf("/"c) + 2))
        If CryptedUrl IsNot Nothing Then
          Dim Ctrl As New HtmlGenericControl("article") 'html5
          Ctrl.Attributes.Add("itemscope", "itemscope")
          Ctrl.Attributes.Add("itemtype", "http://schema.org/NewsArticle")

          If Me.Image <> "" Then
            Dim Img As New WebControl(HtmlTextWriterTag.Img)
            Img.Attributes.Add("itemprop", "image")
            Img.Attributes.Add("src", Me.ImageSrc)
            Ctrl.Controls.Add(Img)
            Img.Attributes.Add("alt", Me.Title)
            Img.Attributes.Add("title", Me.Title)
            Img.Style.Add("float", "right")
            Img.CssClass = "thumb"
          End If

          Ctrl.Controls.Add(DateControl(pubDate, Setting))
          Ctrl.Controls.Add(TextControl(" "))
          Dim NavigateUrl As String = Href(Setting.Name, False, "default.aspx", QueryKey.CryptedUrl, CryptedUrl)
          Ctrl.Controls.Add(Components.Link(NavigateUrl, InnerText(Title), , True, , , "name"))
          Ctrl.Controls.Add(BR)
          Dim Label As New Label
          Label.Attributes.Add("itemprop", "articleBody")
          Label.Text = InnerText(Description)
          Label.CssClass = "Preview"
          Ctrl.Controls.Add(Label)
          'Ctrl.Controls.Add(TextControl(InnerText(Description)))
          Ctrl.Controls.Add(BR)
          If Setting.SEO.CopyPrevention.FromExternalSources Then
            Return New LiteralControl(ObfuscateHtml(ControlToText(Ctrl), Setting))
          Else
            Return Ctrl
          End If
        End If
      End Function
			Public Function Viewer() As Control
				Dim Ctrl As New Control
				Dim H1 As New WebControl(HtmlTextWriterTag.H1)
				H1.Controls.Add(TextControl(Title))
				Ctrl.Controls.Add(TextControl(Description))
				'Dim Box As New WebControl(HtmlTextWriterTag.Fieldset)
				'Box.Controls.Add(IFrame("100%", "1400", Me.Link))
				'Box.Width = Web.UI.WebControls.Unit.Percentage(100)
				'Ctrl.Controls.Add(Box)
				Dim Html As String = ReadHtmlFromWeb(Me.Link, , 10000)
				Dim NoFrame As String = InnerText(Html)
				Ctrl.Controls.Add(IFrame("80%", Nothing, Me.Link, NoFrame))
				Return Ctrl
			End Function
		End Class

		Public WithEvents Updater As New Timers.Timer(1000 * 60 * 60 * 8)	'Update every 8 hour
		Private Sub Updater_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Updater.Elapsed
			Updater.Enabled = False
			UpdateNews()
			UpdateBlogAggregator()
			UpdateIndexedPagesOnGoogle()
			Updater.Start()
		End Sub
		Sub UpdateNews()
			'Read news from archive
			Dim NewsArchived As Collections.Generic.List(Of Notice) = AllNewsArchived(True)

			'Remove all old news
			If NewsArchived IsNot Nothing Then
				For Each News As Notice In NewsArchived
          If Not Recent(Now.ToUniversalTime, News.pubDate, New TimeSpan(Setup.SEO.MaintainsContentsInTheNewsListForDays, 0, 0, 0)) Then
            NewsArchived.Remove(News)
          End If
				Next
			End If

			AllNews = NewsArchived
			Dim LastUpdateNews As Date = PersistentDate("LastUpdateNews")

			If DateDiff(DateInterval.Minute, LastUpdateNews, Now) > 60 Then
				PersistentDate("LastUpdateNews") = Now
				'Update news from the source RSS
				Dim Sources() As NewsRequire = SourceNews()
				If Not Sources Is Nothing Then
					For Each Source As NewsRequire In Sources
						If Not Recent(Source.LastUpdate, Now, Source.UpdateEvery) Then
							Source.LastUpdate = Now
							AddNews(NewsArchived, Source)
						End If
					Next
				End If
				'Save a new notice to disk
				Persistent.SaveObject(NewsArchived, "News")
			End If
		End Sub


		Function SourceNews() As NewsRequire()
      Dim Sources() As NewsRequire = Nothing
			For Each SubSite As SubSite In AllSubSite()
				If Not SubSite.News Is Nothing Then
					Dim Filter As NewsManager.FilterNews = SubSite.News
					If Filter.SourcesRSS IsNot Nothing Then
						For Each Source As String In Filter.SourcesRSS
							AddSourceNews(Sources, Source, Filter.KeyWords)
						Next
					End If
				End If
			Next
			Return Sources
		End Function

		Private Sub AddSourceNews(ByRef Sources() As NewsRequire, ByVal XmlHref As String, ByVal KeyWords() As String)
			Dim Added As Boolean
			If Not Sources Is Nothing Then
				For Each Source As NewsRequire In Sources
					If String.Compare(Source.XmlHref, XmlHref, True) = 0 Then
						Added = True
						If Not Source.KeyWords Is Nothing Then
							If KeyWords Is Nothing Then
								'Nothing value is equivalent at ADD ALL NEWS from xml source
								Source.KeyWords = Nothing
							Else
								'Add keywords not inclused
								For Each KeyWord As String In KeyWords
									Dim IsPresent As Boolean = False
									For Each Word As String In Source.KeyWords
										If System.String.Compare(Word, KeyWord, True) = 0 Then
											IsPresent = True
											Exit For
										End If
									Next
									If Not IsPresent Then
										ReDim Preserve Source.KeyWords(UBound(Source.KeyWords) + 1)
										Source.KeyWords(UBound(Source.KeyWords)) = KeyWord
									End If
								Next
							End If
						End If
						Exit For
					End If
				Next
			End If
			If Not Added Then
				If Sources Is Nothing Then
					ReDim Sources(0)
				Else
					ReDim Preserve Sources(UBound(Sources) + 1)
				End If
				Sources(UBound(Sources)) = New NewsRequire
				Sources(UBound(Sources)).XmlHref = XmlHref
				Sources(UBound(Sources)).KeyWords = KeyWords
			End If
		End Sub
	End Module
End Namespace
