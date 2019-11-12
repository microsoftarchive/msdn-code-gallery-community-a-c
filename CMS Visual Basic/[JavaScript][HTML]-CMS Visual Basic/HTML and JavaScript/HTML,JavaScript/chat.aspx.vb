Imports WebApplication
Partial Class Chat
  Inherits System.Web.UI.Page

  Private Setting As SubSite
  Private JoinUser As String
  Private ChatRoom As String
  Shared Plugin As PluginManager.Plugin = Initialize()
  Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , True, , Plugin.Characteristics.EnabledByDefault)
    Return Plugin
  End Function
  Shared Sub New()
    Initialize()
  End Sub

  Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
    If ShortDescription Then
      Return Phrase(Language, 2001)
    Else
      Return Phrase(Language, 2001)
    End If
  End Function

  Protected Sub Chat_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    'Url request parameters:
    'r = chat room

    Setting = CurrentSetting()
    Dim CheffOfChatRoom As User = Nothing
    If Not Request.QueryString(QueryKey.ChatRoom) Is Nothing Then
      ChatRoom = Request.QueryString(QueryKey.ChatRoom)
      CheffOfChatRoom = Authentication.User.Load(ChatRoom)
    Else
      ChatRoom = DefaultChatRoom
    End If

    If Not Request.QueryString(QueryKey.ChatJoinUser) Is Nothing Then
      JoinUser = Request.QueryString(QueryKey.ChatJoinUser)
      'Block not autorized call a join
      Dim UserInvitedToJoin As User = Authentication.User.Load(JoinUser)
      If Not UserInvitedToJoin.SocialConfiguration.ContainContact(CurrentUser) Then
        EndResponse()
      ElseIf StrComp(CurrentUser.Username, ChatRoom, CompareMethod.Text) <> 0 Then
        EndResponse()
      End If
      UserInvitedToJoin.SocialConfiguration.ChatAccessibility.IsAbleToAccess(ChatRoom) = True
      AddComunication(CurrentUser.Username, JoinUser, TypeOfComunication.JoinToChat)
      Response.Redirect(HrefPrivateChatRoom(Setting, CurrentUser.Username))
    End If

    'Block not autorized
    If CheffOfChatRoom IsNot Nothing Then
      If Not ChatRoom.StartsWith("_") AndAlso CurrentUser.Username <> ChatRoom AndAlso Not CurrentUser.SocialConfiguration.ChatAccessibility.IsAbleToAccess(ChatRoom) Then
        EndResponse()
      End If
    End If

    Dim Action As TypeOfRequest = Request(QueryKey.ChatAction)
    Select Case Action
      Case TypeOfRequest.IsUpdated
        Dim LastMessage As Long = Session("ChatLastMessage")
        Dim Refresh As Boolean
        If LastMessageID(ChatRoom, IsBlockedInChat(Setting)) > LastMessage Then
          Refresh = True
        End If
        Response.ContentType = "text/html"
        'Dim Html As New WebControl(HtmlTextWriterTag.Html)
        'Dim Body As New WebControl(HtmlTextWriterTag.Body)
        'Html.Controls.Add(Body)
        'Body.Controls.Add(New LiteralControl(Refresh.ToString))
        'Response.Write(ControlToText(Html))
        Response.Write(Refresh.ToString)

        'Response.ContentType = "text/xml;charset=utf-8"
        'Dim xml As New System.Xml.Serialization.XmlSerializer(GetType(Boolean))
        'Dim xmlns As New System.Xml.Serialization.XmlSerializerNamespaces
        'xmlns.Add(String.Empty, String.Empty)
        'xml.Serialize(Response.OutputStream, Refresh, xmlns)
        Response.End()
      Case TypeOfRequest.SendContent, TypeOfRequest.SendContentPreview

        Dim Preview As Boolean = Action = TypeOfRequest.SendContentPreview
        Dim Messages As Control = ControlMessages(ChatRoom, CurrentUser, Setting, Preview)
        Dim HTML As String = ControlToText(Messages)

        Dim LastMessage As Long = Session("ChatLastMessage")

        If Request.QueryString(QueryKey.ChatForceRefresh) <> "" OrElse LastMessageID(ChatRoom, IsBlockedInChat(Setting)) > LastMessage Then
          Session("ChatLastMessage") = LastMessageID(Nothing, IsBlockedInChat(Setting))
          Response.ContentType = "text/javascript"
          Response.Cache.SetExpires(Now.AddSeconds(10))
          'If the client perform the "unescape", need replace the "%" with "%25"
          Response.Write("document.getElementById(""displaymsg"").innerHTML=unescape(""" & ReplaceBin(AbjustForJavascriptString(HTML), "%", "%25") & """);")
        End If
        Response.End()
    End Select
  End Sub

  Protected Sub Chat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Config.Setup.Security.OnlyLoggedUsersInChat Then
      RegisterAnonimus()
    End If
    TryBlock(Setting)

    Dim MasterPage As MasterPage = SetMasterPage(Me, , False, True)
    '= Common.LoadTemplate(Me, Setting, True, , False, False, , )
    'Dim Template As New Template(Me , Setting, True, , False, False, , , False)
    MasterPage.TitleDocument = Phrase(Setting.Language, 2001)
    MasterPage.Description = Phrase(Setting.Language, 2001)
    MasterPage.KeyWords = Phrase(Setting.Language, 2001)
    MasterPage.AdSenseDisabled = True 'Note: Google ads, search boxes or search results may not be in chat programs http://support.google.com/adsense/bin/answer.py?hl=en&answer=2661562

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    SendMessage()
  End Sub

  Private Sub SendMessage()
    RedirectBannedUser(Setting)
    Dim Text As String = Left(TextMessage.Text, TextMessage.MaxLength)
    Text = Text.Trim
    If Text <> "" Then
      If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.AdministratorJunior Then
        If ContainCensoredWord(Text) Then
          BlockUserInChat()
        End If
      End If
      Text = Normalize(Text)
      'Text = HttpUtility.HtmlEncode(Text)

      'No resend identical message!
      If MySession("ChatLastText") <> Text Then
        MySession("ChatLastText") = Text


        Dim Author As String
        Dim Visitors As Boolean
        If CurrentUser.Username <> "" Then
          Author = CurrentUser.Username
        Else
          Author = FirstUpper(Request.QueryString(QueryKey.ChatJoinUser))
          If Author Is Nothing Then
            Author = HttpContext.Current.Request.UserHostAddress
          End If
          Visitors = True
        End If
        ChatManager.SendMessage(Text, Author, Visitors, ChatRoom, IsBlockedInChat(Setting))
      End If
    End If
    'Reset text if page
    TextMessage.Text = ""
  End Sub

  Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    Discussion.Controls.Add(Fieldset(Phrase(Setting.Language, 2001), ChatWindow(Setting, ChatRoom)))
    AddEmoticonsTool(Emoticons, TextMessage)
    AddLiteral(Compose, "<script type=""text/javascript"">document.getElementById(""" & TextMessage.ClientID & """).focus();</script>")
    Exit Sub
    'Add online users
  End Sub

  Private Sub TextMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMessage.TextChanged
    SendMessage()
  End Sub
End Class
