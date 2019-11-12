'BlogrollTopForumUser plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class BlogrollTopForumUser
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Private Shared SharedConfiguration As BlogrollTopForumUserSharedConfiguration = Plugin.LoadSharedConfiguration
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(BlogrollTopForumUserConfiguration), GetType(BlogrollTopForumUserSharedConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			Select Case Language
				Case LanguageManager.Language.Italian
          Return IfStr(ShortDescription, "Blogroll utente top forum", "Plugin che crea un blogroll automatico con i siti degli utente top del forum")
				Case Else
          Return IfStr(ShortDescription, "Blogroll top forum user", "Plugin that automatically creates a blogroll of sites with the best user forum")
			End Select
		End Function

		Private Shared BlockSynk As New Object
		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			'Verify if is homepage
			If HttpContext.Current.Request.Path.ToLower.EndsWith("/default.aspx") Then
        For Each QueryName As String In HttpContext.Current.Request.QueryString.AllKeys
          If StrComp(QueryName, "ss", CompareMethod.Text) <> 0 Then
            Exit Sub
          End If
        Next
				Dim Configuration As BlogrollTopForumUserConfiguration
				If SharedConfiguration.ApplySharedConfigurationToAll Then
					Configuration = SharedConfiguration.BlogrollTopForumUserConfiguration
				Else
					Configuration = Plugin.LoadConfiguration()
				End If
				Dim DateLimit As Date = Today.AddDays(-Configuration.DaysToBeConsideredForTheRanking)
				If Not IsCrawler() OrElse Configuration.ShowToCrawler Then
					If Not HttpContext.Current.Request.Browser.IsMobileDevice OrElse Configuration.ShowToMobileDevice Then
						Dim TopUsers As Collections.Generic.Dictionary(Of String, Ranking.Day.ActivityOfUser())
						If Configuration.CriterionForRanking = BlogrollTopForumUserConfiguration.Criterion.PostWrited Then
							TopUsers = TopPostWritedrBySubsite
						Else
							TopUsers = TopTextLengthWritedrBySubsite
						End If

						Dim TopUserForThisSubsite As Ranking.Day.ActivityOfUser()
						SyncLock BlockSynk
							If TopUsers.ContainsKey(MasterPage.Setting.Name) Then
								TopUserForThisSubsite = TopUsers.Item(MasterPage.Setting.Name)
							Else
								TopUserForThisSubsite = MakeTopUserList(Configuration.CriterionForRanking, Configuration.NumberOfItems, DateLimit)
								TopUsers.Add(MasterPage.Setting.Name, TopUserForThisSubsite)
							End If
						End SyncLock

						'Generate on fly the control
						Dim Table As New HtmlTable

						If Configuration.PositionedAtTheTopOfThePage Then
              MasterPage.ContentPlaceHolder.Controls.AddAt(0, Table)
            Else
              MasterPage.ContentPlaceHolder.Controls.Add(Table)
						End If
						Table.Rows.Add(New HtmlTableRow)
						Dim Th0 As HtmlTableCell = New HtmlTableCell("th")
						Table.Rows(0).Controls.Add(Th0)
						If Configuration.TextOnTopOfBlogroll = "" Then
							Th0.InnerText = "Top " & Configuration.NumberOfItems
						Else
							Th0.InnerText = Configuration.TextOnTopOfBlogroll
						End If

						Dim ColSpan As Integer = 1

						Table.Rows.Add(New HtmlTableRow)
						Dim Th1 As HtmlTableCell = New HtmlTableCell("th")
						Table.Rows(1).Controls.Add(Th1)
						Th1.InnerText = Phrase(MasterPage.Setting.Language, 9)

						Dim ColWebsite As Integer
						If Configuration.ShowWebsiteOfUsers <> BlogrollTopForumUserConfiguration.WebsiteShow.Off Then
							ColSpan += 1
							ColWebsite = 1
							Dim Th As HtmlTableCell = New HtmlTableCell("th")
							Table.Rows(1).Controls.Add(Th)
							Th.InnerText = Phrase(MasterPage.Setting.Language, 3026)
						End If

						Dim ColScore As Integer
						If Configuration.ShowScore Then
							ColSpan += 1
							ColScore = ColWebsite + 1
							Dim Th As HtmlTableCell = New HtmlTableCell("th")
							Table.Rows(1).Controls.Add(Th)
							Th.InnerText = Phrase(MasterPage.Setting.Language, 158)
						End If
						Th0.Attributes("colspan") = ColSpan

						Dim Row As Integer = 1
						For Each UserInTop As Ranking.Day.ActivityOfUser In TopUserForThisSubsite
							Dim User As User = User.Load(UserInTop.User)
							If User IsNot Nothing Then
								Row += 1
								Table.Rows.Add(New HtmlTableRow)
								Table.Rows(Row).Cells.Add(New HtmlTableCell)
								Table.Rows(Row).Cells(0).Controls.Add(QuickInfoUser(MasterPage.Setting, User))

								If ColWebsite Then
									Table.Rows(Row).Cells.Add(New HtmlTableCell)
									If User.URL <> "" Then

										Dim Verified As Boolean = True
										If Configuration.ExcludeWebsiteWithCensoredWords Then
											Dim WebsiteValid As String = User.Attribute("WebsiteWithCensoredWords")
											If WebsiteValid = "" OrElse Not WebsiteValid.EndsWith(User.URL) Then
												Dim Check As Boolean
												Try
													Check = TextContainCensored(ReadHtmlFromWeb(User.URL))
												Catch ex As Exception
												End Try
												If Check Then
													WebsiteValid = "-" & User.URL
												Else
													WebsiteValid = "+" & User.URL
												End If
												User.Attribute("WebsiteWithCensoredWords") = WebsiteValid
											End If
											If WebsiteValid.StartsWith("-") Then
												Verified = False
											End If
										End If

										If Verified Then
											Dim Link As New WebControls.HyperLink
											Link.NavigateUrl = User.URL
											Link.CssClass = "url"
											If Configuration.LinkTargetBlank Then
												Link.Target = "_blank"
											End If
											If Configuration.RelNofollowLink Then
												Link.Attributes.Add("rel", "nofollow")
											End If
											Select Case Configuration.ShowWebsiteOfUsers
												Case BlogrollTopForumUserConfiguration.WebsiteShow.Url
													Link.Text = HttpUtility.HtmlEncode(User.URL)
												Case Else
													Dim TitleOfWebSite As String = User.Attribute("TitleOfWebSite")
													If TitleOfWebSite = "" OrElse User.Attribute("UrlOfWebSite") <> User.URL Then
														Try
															Dim MetaTags As New MetaTags(ReadHtmlFromWeb(User.URL))
															TitleOfWebSite = MetaTags.Title
														Catch ex As Exception
														End Try
														If TitleOfWebSite = "" Then
															TitleOfWebSite = User.URL
														End If
														User.Attribute("TitleOfWebSite") = TitleOfWebSite
														User.Attribute("UrlOfWebSite") = User.URL
													End If
													Link.Text = HttpUtility.HtmlEncode(TruncateText(TitleOfWebSite, 200))
													'Link.Text = TitleOfWebSite
											End Select
											Table.Rows(Row).Cells(ColWebsite).Controls.Add(Link)

										End If
									End If
								End If

								If ColScore Then
									Dim Cell As New HtmlTableCell
									Cell.Style.Add("text-align", "right")	'html5
									Table.Rows(Row).Cells.Add(Cell)
									Select Case Configuration.CriterionForRanking
										Case BlogrollTopForumUserConfiguration.Criterion.TextLengthWrited
											Table.Rows(Row).Cells(ColScore).InnerText = UserInTop.TextLengthWrited
										Case Else
											Table.Rows(Row).Cells(ColScore).InnerText = UserInTop.PostWrited
									End Select
								End If

							End If

						Next
					End If
				End If
			End If
		End Sub

		Shared TopPostWritedrBySubsite As New Collections.Generic.Dictionary(Of String, Ranking.Day.ActivityOfUser())
		Shared TopTextLengthWritedrBySubsite As New Collections.Generic.Dictionary(Of String, Ranking.Day.ActivityOfUser())

		Shared Function MakeTopUserList(SortBy As BlogrollTopForumUserConfiguration.Criterion, MaxElements As Integer, DateLimit As Date) As Ranking.Day.ActivityOfUser()
			Dim List = New Collections.Generic.Dictionary(Of String, Ranking.Day.ActivityOfUser)
			Dim UsersForumRanking As Ranking = Plugin.LoadObject(GetType(Ranking))
			For Each Day As Ranking.Day In UsersForumRanking.Days
				If Day.Date >= DateLimit Then
					For Each User As Ranking.Day.ActivityOfUser In Day.ActivityOfUsersCollection.Values
						Dim TotalOfUser As Ranking.Day.ActivityOfUser
						If List.ContainsKey(User.User) Then
							TotalOfUser = List.Item(User.User)
						Else
							TotalOfUser = New Ranking.Day.ActivityOfUser
							TotalOfUser.User = User.User
							List.Add(User.User, TotalOfUser)
						End If
						TotalOfUser.PostWrited += User.PostWrited
						TotalOfUser.TextLengthWrited += User.TextLengthWrited
					Next
				End If
			Next
			Dim Result(List.Count - 1) As Ranking.Day.ActivityOfUser
			List.Values.CopyTo(Result, 0)
			Dim Sort As IComparer
			If SortBy = BlogrollTopForumUserConfiguration.Criterion.TextLengthWrited Then
				Sort = New SortByTextLengthWrited
			Else
				Sort = New SortByPostWrited
			End If
			Array.Sort(Result, Sort)
			If Result.Count > MaxElements Then
				ReDim Preserve Result(MaxElements - 1)
			End If
			Return Result
		End Function

		Private Class SortByPostWrited
			Implements IComparer
			Public Function Compare(ByVal ActivityOfUser1 As Object, ByVal ActivityOfUser2 As Object) As Integer Implements IComparer.Compare
				If ActivityOfUser1.PostWrited < ActivityOfUser2.PostWrited Then
					Return 1
				ElseIf ActivityOfUser1.PostWrited > ActivityOfUser2.PostWrited Then
					Return -1
				End If
				Return 0
			End Function
		End Class

		Private Class SortByTextLengthWrited
			Implements IComparer
			Public Function Compare(ByVal ActivityOfUser1 As Object, ByVal ActivityOfUser2 As Object) As Integer Implements IComparer.Compare
				If ActivityOfUser1.TextLengthWrited < ActivityOfUser2.TextLengthWrited Then
					Return 1
				ElseIf ActivityOfUser1.TextLengthWrited > ActivityOfUser2.TextLengthWrited Then
					Return -1
				End If
				Return 0
			End Function
		End Class


		Private Shared Sub Plugin_ForumReplyPosted(Forum As ForumManager.Forum, Reply As ForumManager.Reply, ForumPostType As PluginManager.ForumPostType, Setting As Config.SubSite) Handles Plugin.ForumReplyPosted
			If ForumPostType <> PluginManager.ForumPostType.Modify Then
				If Reply.AuthorAccount = "" Then

					Dim Configuration As BlogrollTopForumUserConfiguration
					If SharedConfiguration.ApplySharedConfigurationToAll Then
						Configuration = SharedConfiguration.BlogrollTopForumUserConfiguration
					Else
						Configuration = Plugin.LoadConfiguration()
					End If
					Dim DateLimit As Date = Today.AddDays(-Configuration.DaysToBeConsideredForTheRanking)

					Dim UsersForumRanking As Ranking = Plugin.LoadObject(GetType(Ranking), Setting.Name)
					SyncLock Plugin
						Dim TodayRank As Ranking.Day
						If UsersForumRanking.Days.Count = 0 OrElse UsersForumRanking.Days(0).Date <> Today Then
							TodayRank = New Ranking.Day
							TodayRank.Date = Today
							ReDim Preserve UsersForumRanking.Days(UBound(UsersForumRanking.Days) + 1)
							UsersForumRanking.Days(UBound(UsersForumRanking.Days)) = TodayRank
							Dim SortCriterion As IComparer = New SortByDate
							Array.Sort(UsersForumRanking.Days, SortCriterion)
							'Remowe excedents days
							For Id As Integer = 0 To UBound(UsersForumRanking.Days)
								If UsersForumRanking.Days(Id).Date < DateLimit Then
									ReDim Preserve UsersForumRanking.Days(Id - 1)
									Exit For
								End If
							Next
						End If
						TodayRank = UsersForumRanking.Days(0)
						Dim ActivityOfUser As Ranking.Day.ActivityOfUser
						If TodayRank.ActivityOfUsersCollection.ContainsKey(Reply.Author) Then
							ActivityOfUser = TodayRank.ActivityOfUsersCollection(Reply.Author)
						Else
							ActivityOfUser = New Ranking.Day.ActivityOfUser
							TodayRank.ActivityOfUsersCollection.Add(Reply.Author, ActivityOfUser)
						End If
						ActivityOfUser.User = Reply.Author
						ActivityOfUser.PostWrited += 1
						ActivityOfUser.TextLengthWrited += Len(Reply.TextReply)
					End SyncLock
					Plugin.SaveObject(UsersForumRanking)


					'Upaste the top List
					Dim TopUsers As Collections.Generic.Dictionary(Of String, Ranking.Day.ActivityOfUser())
					For Each Criterion As BlogrollTopForumUserConfiguration.Criterion In [Enum].GetValues(GetType(BlogrollTopForumUserConfiguration.Criterion))
						If Criterion = BlogrollTopForumUserConfiguration.Criterion.PostWrited Then
							TopUsers = TopPostWritedrBySubsite
						Else
							TopUsers = TopTextLengthWritedrBySubsite
						End If

						Dim TopUserForThisSubsite As Ranking.Day.ActivityOfUser()
						TopUserForThisSubsite = MakeTopUserList(Criterion, Configuration.NumberOfItems, DateLimit)
						If TopUsers.ContainsKey(Setting.Name) Then
							TopUsers.Remove(Setting.Name)
						End If
						TopUsers.Add(Setting.Name, TopUserForThisSubsite)
					Next

				End If
			End If
		End Sub

		Private Class SortByDate
			Implements IComparer
			Public Function Compare(ByVal Day1 As Object, ByVal Day2 As Object) As Integer Implements IComparer.Compare
				If Day1.Date < Day2.Date Then
					Return 1
				ElseIf Day1.Date > Day2.Date Then
					Return -1
				End If
				Return 0
			End Function 'Compare
		End Class

		Class BlogrollTopForumUserConfiguration
			Public NumberOfItems As Integer = 10
			Public DaysToBeConsideredForTheRanking As Integer = 30
			Public CriterionForRanking As Criterion
			Enum Criterion
				PostWrited
				TextLengthWrited
			End Enum
			Public ShowToCrawler As Boolean = True
			Public ShowToMobileDevice As Boolean = True
			Public PositionedAtTheTopOfThePage As Boolean
			Public TextOnTopOfBlogroll As String = ""
			Public ShowWebsiteOfUsers As WebsiteShow
			Enum WebsiteShow
				Url
				TitleOfWebsite
				Off
			End Enum
			Public RelNofollowLink As Boolean
			Public LinkTargetBlank As Boolean
			Public ExcludeWebsiteWithCensoredWords As Boolean = True
			Public ShowScore As Boolean
		End Class

		Class BlogrollTopForumUserSharedConfiguration
			Public ApplySharedConfigurationToAll As Boolean
			Public BlogrollTopForumUserConfiguration As New BlogrollTopForumUserConfiguration
		End Class

		Class Ranking
			Public Days(-1) As Day
			Class Day
				Public [Date] As Date
				Property ActivityOfUsers As ActivityOfUser()
					Get
						Dim Result(ActivityOfUsersCollection.Count - 1) As Ranking.Day.ActivityOfUser
						ActivityOfUsersCollection.Values.CopyTo(Result, 0)
						Return Result
					End Get
					Set(value As ActivityOfUser())
						ActivityOfUsersCollection.Clear()
						For Each Element As ActivityOfUser In value
							ActivityOfUsersCollection.Add(Element.User, Element)
						Next
					End Set
				End Property
				Friend ActivityOfUsersCollection As New Collections.Generic.Dictionary(Of String, ActivityOfUser)

				'Public ActivityOfUsersCollection As New Collections.Generic.Dictionary(Of String, ActivityOfUser)
				Class ActivityOfUser
					Public User As String
					Public TextLengthWrited As Integer
					Public PostWrited As Integer
				End Class
			End Class
		End Class

	End Class

End Namespace