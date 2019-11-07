Imports WebApplication
Partial Class messenger
	Inherits System.Web.UI.Page
	Private Action As MessengerManager.Action
	Private CurrentUser As User
	Private Setting As SubSite
	Private Confirm As Boolean
	Private Value As String
  Private ToUser As User
	Private ForumId As Integer
	Private TopicID As Integer
	Private ReplyId As Integer
	Private Sub messenger_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

		Try
      If Not Request(QueryKey.MsgAction) Is Nothing Then
        Action = Request(QueryKey.MsgAction)
      End If
      If Not Request(QueryKey.MsgUser) Is Nothing Then
        ToUser = Authentication.User.Load(Request(QueryKey.MsgUser))
      End If
      If Not Request(QueryKey.MsgForumId) Is Nothing Then
        ForumId = Request(QueryKey.MsgForumId)
      End If
      If Not Request(QueryKey.MsgTopicId) Is Nothing Then
        TopicID = Request(QueryKey.MsgTopicId)
      End If
      If Not Request(QueryKey.MsgReplyId) Is Nothing Then
        ReplyId = Request(QueryKey.MsgReplyId)
      End If
      If Not Request(QueryKey.MsgValue) Is Nothing Then
        Value = Request(QueryKey.MsgValue)
      End If
		Catch ex As Exception
      RedirectToHomePage(Setting)
		End Try

		CurrentUser = Authentication.CurrentUser
		Setting = CurrentSetting()

		If Request.UrlReferrer Is Nothing OrElse CurrentUser.Role(Setting.Name) <= Authentication.User.RoleType.Visitors Then
      If ToUser IsNot Nothing Then
        Response.RedirectPermanent(ToUser.Href(Setting), True)
      Else
        Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
      End If
		End If
		If Not Page.IsPostBack Then
			Session("BackPage") = Request.UrlReferrer.AbsoluteUri


			Dim MasterPage As MasterPage = SetMasterPage(Me, , False, False, True, False)
      MasterPage.AddMetaTag("robots", "noindex,nofollow")
			'MasterPage.TitleDocument = Phrase(Setting.Language, 0)
			'MasterPage.Description = Phrase(Setting.Language, 0)
			'MasterPage.KeyWords = Phrase(Setting.Language, 0)



			Select Case Action
				Case MessengerManager.Action.RatingUser
					Dim Redirect As String = Request.ServerVariables("HTTP_REFERER")
					If Redirect = "" Then
						Response.Redirect(Href(Setting.Name, False, "default.aspx"))
					Else
            RatingUser(ToUser, Value)
						Response.Redirect(Redirect)
					End If
				Case MessengerManager.Action.AddContact
          CurrentUser.SocialConfiguration.AddUserContact(ToUser.Username)
					CurrentUser.Save()
					ReturnBack()
				Case MessengerManager.Action.RemoveContact
          CurrentUser.SocialConfiguration.RemoveUserContact(ToUser.Username)
					CurrentUser.Save()
					ReturnBack()
				Case MessengerManager.Action.SendMessengerComunication
					Response.ContentType = "text/xml;charset=utf-8"
					Dim xml As New System.Xml.Serialization.XmlSerializer(GetType(ListMessage))
					Dim xmlns As New System.Xml.Serialization.XmlSerializerNamespaces
					xmlns.Add(String.Empty, String.Empty)
					Dim Comunication As MessengerComunication = MessengerComunicarionsToUser(CurrentUser.Username)
					Dim ListMessage As New ListMessage
					If Not Comunication Is Nothing Then
						'Setting = CurrentSetting()
						'message
						ListMessage.Item.Add(Phrase(Setting.Language, 3231) & " """ & Comunication.FromUser & """ " & Phrase(Setting.Language, 3232))
						'url
						ListMessage.Item.Add(HrefPrivateChatRoom(Setting, Comunication.FromUser, , True))
						'target
						ListMessage.Item.Add(ChatTarget(Comunication.FromUser))
					End If
					xml.Serialize(Response.OutputStream, ListMessage, xmlns)
					Response.End()
			End Select

			Page.Title = Phrase(Setting.Language, 3229)	'Messenger

		End If

	End Sub

	Private Sub ConfirmButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConfirmButton.Click
		Confirm = True
	End Sub

	Private Sub messenger_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
		Select Case Action
      Case MessengerManager.Action.None, MessengerManager.Action.AddContact, MessengerManager.Action.RemoveContact, MessengerManager.Action.SendMessengerComunication
      Case Else
        ConfirmPanel.Visible = True
        If Page.IsPostBack Then
          If Confirm Then
            'Message = Components.Message(Setting.Language, 418)
            ConfirmCancelButtons.Visible = False
            Select Case Action
              Case MessengerManager.Action.BlockUser
                LockUser(ToUser)
              Case MessengerManager.Action.DeleteTopics
                ForumManager.RequireDelete(Setting, ForumId, TopicID, ReplyId)
              Case MessengerManager.Action.RequireTopicCensore
                ForumManager.RequireCensore(Setting, ForumId, TopicID, ReplyId)
              Case MessengerManager.Action.RequireAdmonishUser
                ForumManager.RequireAdmonish(Setting, ToUser.Username, ForumId)
              Case MessengerManager.Action.CloseTopic
                ForumManager.RequireSetCloseTopic(Setting, ForumId, TopicID, True)
              Case MessengerManager.Action.OpenTopic
                ForumManager.RequireSetCloseTopic(Setting, ForumId, TopicID, False)
              Case MessengerManager.Action.MarkTopicAsResolved
                ForumManager.RequireSetTopicAsResolved(Setting, ForumId, TopicID, Value)
            End Select
            SetNextMessage(418)
          End If
          ReturnBack()
        Else
          Select Case Action
            Case MessengerManager.Action.BlockUser
              MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 3233) & ": " & ToUser.CodeUser, Setting.Language), Setting))
            Case MessengerManager.Action.DeleteTopics
              Dim Topic As Topic = Topic.Load(ForumId, TopicID)
              Dim Title As String = Nothing
              If Topic IsNot Nothing Then
                Title = Topic.FirstReply.Title
              End If
              MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 51, 62) & ": """ & Title & """", Setting.Language), Setting))
            Case MessengerManager.Action.RequireTopicCensore
              Dim Topic As Topic = Topic.Load(ForumId, TopicID)
              Dim AddTxt As String = Nothing
              If Topic IsNot Nothing Then
                If ReplyId = 1 AndAlso Not ForumForInsideUse(ForumId) Then
                  AddTxt = Topic.FirstReply.Title
                Else
                  Dim Reply As Reply = Reply.Load(ForumId, TopicID, ReplyId)
                  AddTxt = Left(Reply.InnerTextReply, 15) & "..."
                End If
              End If
              MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 3075) & ": """ & AddTxt & """", Setting.Language), Setting))
            Case MessengerManager.Action.RequireAdmonishUser
              MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 3075) & ": " & ToUser.Username, Setting.Language), Setting))
            Case MessengerManager.Action.CloseTopic
              MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 111), Setting.Language), Setting))
            Case MessengerManager.Action.OpenTopic
              MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 2024), Setting.Language), Setting))
            Case MessengerManager.Action.MarkTopicAsResolved
              If Value = "0" Then
                MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 2027), Setting.Language), Setting))
              Else
                MessageInConfirmPanel.Controls.Add(Components.Message(Ask(Phrase(Setting.Language, 2026), Setting.Language), Setting))
              End If
          End Select

        End If
    End Select
	End Sub

	Sub ReturnBack()
		If Session("BackPage") IsNot Nothing Then
			Dim Back As String = Session("BackPage")
			Session("BackPage") = Nothing
			Response.Redirect(Back)
		End If
	End Sub

End Class