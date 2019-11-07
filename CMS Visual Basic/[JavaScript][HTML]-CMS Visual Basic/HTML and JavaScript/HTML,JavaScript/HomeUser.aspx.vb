Imports WebApplication
Partial Class HomeUser

	Inherits System.Web.UI.Page

	Private Setting As SubSite
	Private UserProfile As User
	Private CurrentUser As User
	Private Type As ProfileType

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Request("u") <> "" Then
			UserProfile = Authentication.User.Load(Request("u"))
		End If
		If UserProfile Is Nothing OrElse UserProfile.Username = "" Then
			EndResponse()
		End If

		Setting = CurrentSetting()
		CurrentUser = Authentication.CurrentUser

		'Redirect Userprofile if concernent another subsite
		If CurrentUser.Username <> UserProfile.Username Then
			RedirectToAppropriateSubSite(UserProfile, Setting)
		End If

		Dim Action As Actions = Request.QueryString("a")
		Dim SetValue = Request.QueryString("s")

		If Action Then
			If Request.UrlReferrer Is Nothing AndAlso Session("HomeUserReferer") = "" Then
        RedirectToHomePage(Setting)
			End If
			Select Case Action
				Case Actions.ChngeRole
					Dim MyRole As Authentication.User.RoleType = CurrentUser.Role(Setting.Name)
					Dim RoleProfile As Authentication.User.RoleType = UserProfile.Role(Setting.Name)
					Dim SetRole As Authentication.User.RoleType = CInt(SetValue)
					If MyRole >= Authentication.User.RoleType.AdministratorJunior AndAlso SetRole <= MyRole Then
						If SetRole = Authentication.User.RoleType.Supervisor Then
							UserProfile.GeneralRole = SetRole
						Else
							UserProfile.Role(Setting.Name) = SetRole
						End If
						UserProfile.Save()
					End If
			End Select
			If Request.UrlReferrer IsNot Nothing Then
				Response.Redirect(Request.UrlReferrer.AbsoluteUri)
			Else
				Response.Redirect(Session("HomeUserReferer"))
			End If
		Else
			Session("HomeUserReferer") = Request.RawUrl
		End If
	End Sub



	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim MyRole As Authentication.User.RoleType = CurrentUser.Role(Setting.Name)
		Dim RoleProfile As Authentication.User.RoleType = UserProfile.Role(Setting.Name)
		If CurrentUser.Username <> UserProfile.Username Then
			If MyRole >= Authentication.User.RoleType.AdministratorJunior Then
				If RoleProfile < MyRole Then
					For Role As Authentication.User.RoleType = Authentication.User.RoleType.Excluded To MyRole
						If Role <> Authentication.User.RoleType.Visitors Then
							Dim Item As ListItem
							Item = New ListItem
							Item.Text = Role.ToString
							Item.Value = Role
							If Role = RoleProfile Then
								Item.Selected = True
							End If
							RoleList.Items.Add(Item)
						End If
					Next
					RoleList.Visible = True
					RoleList.Attributes.Add("onChange", "window.location.assign(location + '&a=" & Actions.ChngeRole & "&s=' + this.options[this.selectedIndex].value);")
				End If
			End If
		End If

    If Request("ty") <> "" Then
      Type = Request("ty")
    End If

		Select Case Type
			Case ProfileType.Card

				SetPanel()
			Case ProfileType.Full

		End Select

		Dim MasterPage As MasterPage = SetMasterPage(Me, , False, True)

		'Set page Title, Description and KeyWords: Replece 0 with the appropriate phrase ID
		MasterPage.TitleDocument = UserProfile.Username
		MasterPage.Description = UserProfile.Username
		MasterPage.KeyWords = UserProfile.Username

	End Sub

	Enum Actions
		None
		ChngeRole
	End Enum

	Sub SetPanel()
		UserName.Controls.Add(TextControl(UserProfile.Username))
		If StrComp(CurrentUser.Username, UserProfile.Username, CompareMethod.Text) <> 0 Then
			'Is not current user
			If CurrentUser.GeneralRole >= Authentication.User.RoleType.User Then
				If CurrentUser.SocialConfiguration.ContainContact(UserProfile.Username) Then
					'Add button [Remove from Contacts]
					Operations.Controls.Add(Components.Button(Setting, Phrase(Setting.Language, 3228), Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(UserProfile.Username, Action.RemoveContact)), , IconType.Favourites))
				Else
					If UserProfile.Role(Setting.Name) >= Authentication.User.RoleType.User Then
						'Add button [Add this contact to favorites]
						Operations.Controls.Add(Components.Button(Setting, Phrase(Setting.Language, 3227), Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(UserProfile.Username, Action.AddContact)), , IconType.Favourites))
					End If
				End If
			End If
		Else
			'Is current user
			'Add Button Log Off
      Operations.Controls.Add(Components.Button(Setting, Phrase(Setting.Language, 22), Href(Setting.Name, False, "log.aspx", QueryKey.ActionLog, LogActionType.LogOff), , IconType.Globe))
		End If

		If StrComp(CurrentUser.Username, UserProfile.Username, CompareMethod.Text) = 0 Then
			'Add button Modify Profile
      Operations.Controls.Add(Components.Button(Setting, Phrase(Setting.Language, 320), Href(Setting.Name, False, "log.aspx", QueryKey.ActionLog, LogActionType.EditUser), , IconType.ControlPanel))
		End If

		If CurrentUser.Role(Setting.Name) > Authentication.User.RoleType.WebMaster Then
			'Add button User Setting
			Operations.Controls.Add(Components.Button(Setting, Phrase(Setting.Language, 151), Href(Setting.Name, False, "profilemanager.aspx", "u", UserProfile.Username), , IconType.ControlPanel))
		End If

		'Add button link to message board of this user
    Dim HrefMessageBoard As String = Href(Setting.Name, False, "forum.aspx", QueryKey.Reference, UserProfile.Username, QueryKey.ForumId, ReservedForums.PrivateMessage)
		Dim BtnMessageBoard As WebControl = Components.Button(Setting, Phrase(Setting.Language, 121), HrefMessageBoard, , IconType.Contacts)
		Operations.Controls.Add(BtnMessageBoard)

		'Add personal information
		PopulateInfoPanel()

		'Add some photos
		PopulatePhotosPanel()

		'Add all User Contacts
		PopulateFriendsPanel()


	End Sub

	Sub PopulateInfoPanel()
		If UserProfile.FirstAccess <> Date.MinValue Then
			AddInfo(Phrase(Setting.Language, 112), UserProfile.FirstAccess.ToString(Setting.DateFormat, Setting.Culture), , , "name")
		End If
		If UserProfile.URL <> "" Then
			Dim PageAuthor As String = UserProfile.URL
			If PageAuthor.Contains("://plus.google.com/") Then
				If Not PageAuthor.Contains("?rel=author") Then
					PageAuthor = PageAuthor.TrimEnd("/"c) & "?rel=author"	 'https://spreadsheets.google.com/spreadsheet/viewform?formkey=dHdCLVRwcTlvOWFKQXhNbEgtbE10QVE6MQ&ndplr=1
				End If
			End If
			AddInfo(Phrase(Setting.Language, 18), UserProfile.URL, , PageAuthor, "url", "author")
		End If
		AddInfo(Phrase(Setting.Language, 113), UserProfile.LastAccess.ToString(Setting.DateFormat, Setting.Culture))
		If IsCrawler(Request) OrElse CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.User OrElse CurrentUser.Username = UserProfile.Username Then

			AddInfo(Phrase(Setting.Language, 24), UserProfile.FirstName, , , "givenName")
			AddInfo(Phrase(Setting.Language, 25), UserProfile.LastName, , , "familyName")
			If UserProfile.Gender <> Authentication.User.GenderType.NotDefinite Then
        Dim Gender As String
        If UserProfile.Gender = Authentication.User.GenderType.Male Then
          Gender = Phrase(Setting.Language, 3133)
        Else
          Gender = Phrase(Setting.Language, 3134)
        End If
        AddInfo(Phrase(Setting.Language, 19), Gender, , , "gender")
			End If
			If UserProfile.Phone <> "" Then
        AddInfo(Phrase(Setting.Language, 15), UserProfile.Phone, , "callto://" & UserProfile.Phone, "telephone", "nofollow")
			End If

			'Add tool rating user
			Dim RatingControl As New WebControl(HtmlTextWriterTag.Span)
			RatingControl.Attributes.Add("itemscope", "itemscope")
			RatingControl.Attributes.Add("itemtype", "http://schema.org/Rating")
			Dim RatingFromUser As Integer
			If CurrentUser.Username <> "" Then
				RatingFromUser = UserProfile.UserRating(CurrentUser.Username)
			End If
			Dim ratingValue As New WebControl(HtmlTextWriterTag.Meta)
			ratingValue.Attributes.Add("itemprop", "ratingValue")
			ratingValue.Attributes.Add("content", CInt(UserProfile.Rating))
			RatingControl.Controls.Add(ratingValue)
			Dim bestRating As New WebControl(HtmlTextWriterTag.Meta)
			ratingValue.Attributes.Add("itemprop", "bestRating")
			ratingValue.Attributes.Add("content", 5)
			RatingControl.Controls.Add(bestRating)

			If CurrentUser.Username <> "" Then
				For N As Integer = 1 To 5
          Dim LinkUrl As String = Nothing
          If CurrentUser.Username <> UserProfile.Username Then
            LinkUrl = Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(UserProfile.Username, Action.RatingUser, , N))
          End If

          Dim Star As WebControl = IconUnicode(IconName.BlackStar, True, Phrase(Setting.Language, 433) & " " & N, LinkUrl)
          RatingControl.Controls.Add(Star)
          Star.ID = "star" & N
					If N > RatingFromUser Then
						Star.Style.Add("opacity", "0.3")
						Star.Style.Add("filter", "alpha(opacity=30)")
            Star.Attributes("onmouseover") = "this.style.opacity=1;this.filters.alpha.opacity=100"
						Star.Attributes("onmouseout") = "this.style.opacity=0.3;this.filters.alpha.opacity=30"
					End If

        Next
			End If
			AddInfo(Phrase(Setting.Language, 433), , RatingControl)
		End If

		'Add specials information visibled only to Administrators:
		If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
			Dim LockUser As Control

			If UserProfile.GeneralRole <= Authentication.User.RoleType.Excluded Then
				'This code user is blocked
        LockUser = IconUnicode(IconName.Block, , Phrase(Setting.Language, 3193))
				Lock.Controls.Add(LockUser)
			ElseIf CurrentUser.GeneralRole > UserProfile.GeneralRole Then
				'Add tool to block this code user
				Dim NavigateUrl As String = Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(UserProfile.Username, Action.BlockUser))
        LockUser = IconUnicode(IconName.ScissorBlack, , Phrase(Setting.Language, 3233), NavigateUrl)
				Lock.Controls.Add(LockUser)
			End If
      Dim LockIp As Control = Nothing
			If IPIsBlocked(UserProfile.IP) Then
				'This code user is blocked
        LockIp = IconUnicode(IconName.Block, , Phrase(Setting.Language, 3193), Nothing)
			End If
			If UserProfile.Rating <> 0 Then
				Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
				AddInfo("Rating", Math.Round(UserProfile.Rating, 2).ToString(Culture))
			End If
			AddInfo("IP", UserProfile.IP, LockIp, NavigateUrlIpLookup & UserProfile.IP)
			If UserProfile.ProxyUse Then
				AddInfo("Proxy", Phrase(Setting.Language, 126))
			End If
			If UserProfile.Forwarded <> "" Then
				AddInfo("Forwarded", UserProfile.Forwarded)
			End If
			If UserProfile.Identity <> "" Then
				AddInfo("Identity", UserProfile.Identity)
			End If
			AddInfo(Phrase(Setting.Language, 12), UserProfile.Email, , "mailto:" & UserProfile.Email, "email") 'E-Mail
			If UserProfile.Generate <> "" Then
				Dim InfoUser As Control = QuickInfoUser(Setting, Authentication.User.Load(UserProfile.Generate))
				AddInfo(Phrase(Setting.Language, 119), Nothing, InfoUser)
			End If

			AddInfo("Time offset (sec.)", UserProfile.TimeOffsetSeconds)

			If UserProfile.CodeUser <> "" Then
        Dim LockCode As Control = Nothing
				Dim CodesBanned As Collections.Specialized.StringCollection = BannedCodeUsers()
				If CodesBanned IsNot Nothing AndAlso CodesBanned.Contains(UserProfile.CodeUser) Then
					'This code user is blocked
          LockCode = IconUnicode(IconName.Block, , Phrase(Setting.Language, 3193), Nothing)
				End If
				AddInfo(Phrase(Setting.Language, 3234), UserProfile.CodeUser, LockCode)
			End If
		End If

		If InfoPanel.Controls.Count Then
			InfoPanel.Visible = True
		End If

	End Sub

	Sub PopulatePhotosPanel()
    Dim PhotoAlbum As PhotoAlbum = UserProfile.PhotoAlbum
    If Not PhotoAlbum Is Nothing Then
      'Add button photo album
      Dim Button As Control = Components.Button(Setting, Phrase(Setting.Language, 3224), Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, PhotoAlbum.Name), , IconType.FolderPics1)
      Operations.Controls.Add(Button)
      AddFotoalbumSlideShow(Setting, Button, PhotoAlbum.Name)
      Dim AllPhotosName As Array = PhotoManager.AllPhotosName(PhotoAlbum.Name)
      If Not AllPhotosName Is Nothing AndAlso AllPhotosName.Length > 0 Then
        PhotosPlaceHolder.Visible = True

        Dim FirsPhoto As Photo = PhotoManager.Photo.Load(AllPhotosName(0), PhotoAlbum.Name)
        If IsCrawler(Request) Then
          AddInfo(Phrase(Setting.Language, 104), FirsPhoto.Src(Setting), , FirsPhoto.Src(Setting), "image")
        End If

        PhotosPanel.Controls.Add(FirsPhoto.ControlPhoto(Setting))
        Dim Count As Integer
        Dim MiniPhotos As New Control
        For Each PhotoName As String In AllPhotosName
          If PhotoName <> FirsPhoto.Name Then
            Count += 1
            Dim Photo As Photo = PhotoManager.Photo.Load(PhotoName, PhotoAlbum.Name)
            MiniPhotos.Controls.Add(Photo.ControlThumbnail(Setting, True, , ThumbnailBoxMode.Gallery))
          End If
          If Count = 5 Then Exit For
        Next
        If MiniPhotos.Controls.Count Then
          PhotosPanel.Controls.Add(MiniPhotos)
        End If
      End If
    End If

	End Sub


	Sub PopulateFriendsPanel()
		If Not UserProfile.SocialConfiguration.UserContacts Is Nothing Then
			Dim Count As Integer
			For Each Contact As String In UserProfile.SocialConfiguration.UserContacts
				Dim FriendUser As User = Authentication.User.Load(Contact)
				If FriendUser IsNot Nothing Then
					If FriendUser.GeneralRole >= Authentication.User.RoleType.User Then
						Count += 1
						Dim Box As New WebControl(HtmlTextWriterTag.P)
						Box.Controls.Add(QuickInfoUser(Setting, FriendUser))
						Friends.Controls.Add(Box)
					End If
				End If
			Next
			If Count Then
				FriendsPlaceHolder.Visible = True
			End If
		End If
	End Sub

	Private Sub AddInfo(ByVal Name As String, Optional ByVal Value As String = Nothing, Optional ByVal AdditionalControls As Control = Nothing, Optional ByVal NavigateUrl As String = Nothing, Optional Itemprop As String = Nothing, Optional Rel As String = Nothing)
		Dim Label As New HyperLink
		If Itemprop IsNot Nothing Then
			Label.Attributes.Add("itemprop", Itemprop)
		End If
		If Rel IsNot Nothing Then
			Label.Attributes.Add("rel", Rel)
		End If
		If NavigateUrl IsNot Nothing Then
			Label.NavigateUrl = NavigateUrl
			Label.Target = "_blank"
		End If
		Label.Text = HttpUtility.HtmlEncode(Value)
		Dim LabelName As New LiteralControl(HttpUtility.HtmlEncode(Name & " = "))
		InfoPanel.Controls.Add(LabelName)
		InfoPanel.Controls.Add(Label)
		If AdditionalControls IsNot Nothing Then
			InfoPanel.Controls.Add(AdditionalControls)
		End If
		InfoPanel.Controls.Add(BR)
	End Sub



End Class
