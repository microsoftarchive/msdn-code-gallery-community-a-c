'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Namespace WebApplication
	Public Module ChatManager
		Public Const DefaultChatRoom As String = "_"
		Public Const MaxMessage As Integer = 100
		'Public Messages(MaxMessage) As Message

		Function QueryStringParameters(Optional ByVal Room As String = Nothing, Optional ByVal TypeOfRequest As TypeOfRequest = TypeOfRequest.Show, Optional ByVal JoinToUser As String = Nothing, Optional ByVal ForceRefresh As Boolean = False) As String()
      Dim Result() As String = Nothing
			If Room IsNot Nothing Then
        AddElement(Result, QueryKey.ChatRoom)
				AddElement(Result, Room)
			End If
			If JoinToUser IsNot Nothing Then
        AddElement(Result, QueryKey.ChatJoinUser)
				AddElement(Result, JoinToUser)
			End If
			If TypeOfRequest <> ChatManager.TypeOfRequest.Show Then
        AddElement(Result, QueryKey.ChatAction)
				AddElement(Result, TypeOfRequest)
			End If
			If ForceRefresh Then
        AddElement(Result, QueryKey.ChatForceRefresh)
				AddElement(Result, 1)
			End If
			Return Result
		End Function

		Private MessagesCollection As New Collections.Specialized.HybridDictionary
		Property Messages(ByVal ChatRoom As String) As Message()
			Get
				If MessagesCollection.Contains(ChatRoom) Then
					Return MessagesCollection(ChatRoom)
				Else
					Dim EmptyMessages(MaxMessage - 1) As Message
					MessagesCollection.Add(ChatRoom, EmptyMessages)
					Return EmptyMessages
				End If
			End Get
			Set(ByVal value As Message())
				If MessagesCollection.Contains(ChatRoom) Then
					MessagesCollection.Remove(ChatRoom)
				End If
				MessagesCollection.Add(ChatRoom, value)
			End Set
		End Property

		Private LastMessageIDNoCensored As Integer
		Private LastMessageIDCensored As Integer
		Property LastMessageID(ByVal KeyChat As String, ByVal Censored As Boolean) As Integer
			Get
				If Censored Then
					Return LastMessageIDCensored
				Else
					Return LastMessageIDNoCensored
				End If
			End Get
			Set(ByVal value As Integer)
				If Censored Then
					LastMessageIDCensored = value
				Else
					LastMessageIDNoCensored = value
				End If
			End Set
		End Property


		Enum TypeOfRequest
			Show
			IsUpdated
			SendContent
			SendContentPreview
		End Enum
		Class Message
			Public Time As Date
			Public Text As String
			Public Author As String
      Public AuthorIsVisitors As Boolean
      Public Censored As Boolean
    End Class
    Function ControlMessages(ByVal ChatRoom As String, ByVal User As User, ByVal Setting As SubSite, Optional ByVal Preview As Boolean = False) As Control
      Dim Controls As New Control
      Dim Counter As Integer
      Dim ShowCensored As Boolean = User.Role(Setting.Name) > Authentication.User.RoleType.AdministratorJunior
      Dim AllMessages As Message() = Messages(ChatRoom)
      'If Not AllMessages Is Nothing Then
      For Each Message As Message In AllMessages
        Counter += 1
        If Not Message Is Nothing Then
          If Message.Censored = False OrElse IsBlockedInChat(Setting) OrElse ShowCensored Then
            If Preview Then
              Dim Author As New Control
              Author = InfoUser(Message, Setting, Preview)
              Dim Text As New Label
              Text.Style.Add("font-size", "smaller")
              Text.Text = ">" & AddEmoticons(Message.Text) & " "
              Controls.Controls.Add(Author)
              Controls.Controls.Add(Text)
              If Counter = 15 Then
                Exit For
              End If
            Else
              Dim Time As New HtmlGenericControl("time")
              Time.Attributes.Add("datetime", Message.Time.ToString("s"))
              Time.InnerText = Message.Time.ToLocalTime.AddSeconds(User.TimeOffsetSeconds).ToString(Setting.TimeFormat, Setting.Culture) & " "

              Dim Text As New Label
              Dim Phrase As String = Message.Text
              UrlToLink(Phrase, Setting, CurrentDomainConfiguration, True)

              Text.Text = " " & AddEmoticons(Phrase)
              'Text.ForeColor = ColorMessage(Message.Author)
              If ShowCensored And Message.Censored Then
                'Evidence Censored messages for administrator
                Text.BorderStyle = BorderStyle.Ridge
              End If
              Dim Span As New WebControl(HtmlTextWriterTag.Span)
              Span.Style.Add("color", ColorMessageString(Message.Author))
              Span.Controls.Add(Time)
              Span.Controls.Add(InfoUser(Message, Setting, Preview))
              Span.Controls.Add(Text)
              Span.Controls.Add(BR)
              Controls.Controls.Add(Span)
            End If
          End If
        End If
      Next
      'End If
      Return Controls
    End Function
    Function ColorMessage(ByVal Author As String) As System.Drawing.Color
      Dim Seme As Double
      For N As Integer = 0 To Len(Author) - 1
        Seme += Asc(Author.Chars(N))
      Next
      Rnd(-1)
      Randomize(Seme)
      Dim Red, Green, Blue As Integer
      Do
        Red = Rnd() * 255
        Green = Rnd() * 255
        Blue = Rnd() * 255
      Loop Until (Red + Green + Blue) < 260
      Return Drawing.Color.FromArgb(Red, Green, Blue)
    End Function
    Function ColorMessageString(ByVal Author As String) As String
      Dim Seme As Double
      For N As Integer = 0 To Len(Author) - 1
        Seme += Asc(Author.Chars(N))
      Next
      Rnd(-1)
      Randomize(Seme)
      Dim Red, Green, Blue As Integer
      Do
        Red = Rnd() * 255
        Green = Rnd() * 255
        Blue = Rnd() * 255
      Loop Until (Red + Green + Blue) < 260
      Return "#" & Right("0" & Hex(Red), 2) & Right("0" & Hex(Green), 2) & Right("0" & Hex(Blue), 2)
    End Function

    Function InfoUser(ByVal Message As Message, ByVal Setting As SubSite, ByVal Preview As Boolean) As Control
      Dim Author As User
      Dim ForceOnline As Boolean
      If Message.AuthorIsVisitors Then
        Author = New User
        Author.Username = Message.Author
        ForceOnline = True
        Author.GeneralRole = User.RoleType.Visitors
        If InStr(".", Message.Author) Then
          Author.IP = Message.Author
        End If
      Else
        Author = User.Load(Message.Author)
      End If
      Return QuickInfoUser(Setting, Author, , Preview)
    End Function

    Public Class ListMessage
      <System.Xml.Serialization.XmlElementAttribute("item")> _
      Public Item As New Item
    End Class
    Public Class Item
      Inherits CollectionBase
      Public Sub Add(ByVal Item As String)
        Dim I As Integer = List.Add(Item)
      End Sub
      Default Public ReadOnly Property Item(ByVal Index As Integer) As String
        Get
          Return CType(List.Item(Index), String)
        End Get
      End Property
    End Class
    Public Function ChatPreview(ByVal ChatRoom As String, ByVal Setting As SubSite) As Control
      If HttpContext.Current.Request.Browser.EcmaScriptVersion.Major >= 1 Then
        Dim Link As New HyperLink
        Link.NavigateUrl = Common.Href(Setting.Name, False, "chat.aspx")
        Dim Window As Control = ChatWindow(Setting, ChatRoom, 60, 100, True)
        Link.Controls.Add(Window)
        'ChatManager.ControlMessages(ChatRoom, CurrentUser, Setting, True)
        Link.Style.Add("display", "block")
        Dim Field As Control = Fieldset(Phrase(Setting.Language, 2002), Link)
        Field.Controls.Add(Link)
        Dim Controls As New Control
        Controls.Controls.Add(New LiteralControl("<!--googleoff: index-->"))
        Controls.Controls.Add(Field)
        Controls.Controls.Add(New LiteralControl("<!--googleon: index-->"))
        Return Controls
      Else
        Return New Control
      End If
    End Function
    Public Sub SaveMessages(ByVal ChatRoom As String)
      Dim Data As String = Nothing
      If Not Messages(ChatRoom) Is Nothing Then
        For Each Message As Message In Messages(ChatRoom)
          If Message Is Nothing Then
            Exit For
          Else
            Data &= DateToText(Message.Time) & vbTab & Message.Author & vbTab & Message.AuthorIsVisitors & vbTab & Message.Censored & vbTab & Message.Text & vbCr
          End If
        Next
      End If
      WriteAll(Data, Extension.MapPath(ChatSubDirectory & "\" & ChatRoom & ".txt"))
    End Sub
    Public Sub LoadMessages(ByVal ChatRoom As String)
      Dim Data As String
      Try
        Data = ReadAll(Extension.MapPath(ChatSubDirectory & "\" & ChatRoom & ".txt"), True)
      Catch ex As Exception
        'file not exists
        Exit Sub
      End Try
      Dim Records() As String = Split(Data, vbCr)
      Dim N As Integer
      For Each Record As String In Records
        If Record <> "" Then
          If N <= UBound(Messages(ChatRoom)) Then
            Dim Fields() As String = Split(Record, vbTab)
            Dim Message As New Message
            Message.Time = TextToDate(Fields(0))
            Message.Author = Fields(1)
            Message.AuthorIsVisitors = Fields(2)
            Message.Censored = Fields(3)
            Message.Text = Fields(4)
            Messages(ChatRoom)(N) = Message
            N += 1
          Else
            Exit For
          End If
        End If
      Next
    End Sub

    Function ChatWindow(ByVal Setting As Config.SubSite, ByVal ChatRoom As String, Optional ByVal EverySeconds As Integer = 10, Optional ByVal Height As Integer = 300, Optional ByVal Preview As Boolean = False) As Control
      Dim Place As New Control

      Dim Window As New LiteralControl
      If Preview Then
        Dim Marquee As String = "<marquee id=""displaymsg"" scrolldelay=""1"" scrollamount=""1"" direction=""down""></marquee>"
        Marquee = "<script type=""text/javascript"">document.write('" & AbjustForJavascriptString(Marquee) & "');</script>"
        Window.Text = "<div style=""height:" & Height & "px; overflow:auto"">" & Marquee & "</div>"
      Else
        Window.Text = "<div id=""displaymsg"" style=""height:" & Height & "px; overflow:auto""></div>"
      End If
      Place.Controls.Add(Window)

      Dim Request As TypeOfRequest
      If Preview Then
        Request = TypeOfRequest.SendContentPreview
      Else
        Request = TypeOfRequest.SendContent
      End If
      '==============================================
      'New algoritm using polling javascript
      '==============================================


      Dim ScriptSourceMessages As New WebControl(HtmlTextWriterTag.Script)
      ScriptSourceMessages.ID = "sourcemessages"
      ScriptSourceMessages.Attributes("language") = ScriptLanguage.javascript.ToString.ToLower
      ScriptSourceMessages.Attributes("type") = ScriptType(ScriptLanguage.javascript)
      ScriptSourceMessages.Attributes.Add("src", Common.Href(Setting.Name, True, "chat.aspx", QueryStringParameters(ChatRoom, Request, , True)))
      Place.Controls.Add(Literal(ControlToText(ScriptSourceMessages)))
      Dim Script As String

      Script = _
      "SrcMsg=""" & Common.Href(Setting.Name, True, "chat.aspx", QueryStringParameters(ChatRoom, Request)) & """;" & vbCrLf & _
      "function UPDCHAT(){" & vbCrLf & _
       "xhead=document.getElementsByTagName('head')[0];" & vbCrLf & _
       "xscript=document.createElement('script');" & vbCrLf & _
       "xscript.language='javascript';" & vbCrLf & _
       "xscript.type= 'text/javascript';" & vbCrLf & _
       "xscript.src=SrcMsg+""&now="" + new Date();" & vbCrLf & _
       "xhead.appendChild(xscript);" & vbCrLf & _
      "}" & vbCrLf & _
      "xupd=setInterval(""UPDCHAT()""," & EverySeconds * 1000 & ")" & vbCrLf

      Place.Controls.Add(Components.Script(Script, Components.ScriptLanguage.javascript))
      Return Place

    End Function


    Sub BlockUserInChat()
      'block the user
      Const HoursToBlock As Integer = 6
      MySession("UserTempBlockInChat") = True
      Cookie("UserTempBlockInChat", Now.AddHours(HoursToBlock)) = "True"
      BlockIPInChat(CurrentUser.IP, New TimeSpan(HoursToBlock, 0, 0))
    End Sub
    Function IsBlockedInChat(ByVal Setting As SubSite) As Boolean
      Return IsBlocked(Setting, "UserTempBlockInChat", IPBlockedsInChat)
    End Function

    Public IPBlockedsInChat As Collections.Specialized.StringDictionary = LoadIPBlockedCollection("IPBlockedsInChat")

    Sub BlockIPInChat(ByVal IP As String, ByVal Time As TimeSpan)
      BlockIP(IP, Time, IPBlockedsInChat)
    End Sub

    Function IPIsBlockedInChat(ByVal IP As String) As Boolean
      Return IPIsBlocked(IP, IPBlockedsInChat)
    End Function

    Class ChatAccessibility
      Private Collection As New Collections.Specialized.StringCollection
      Property IsAbleToAccess(ByVal ChatRoom As String) As Boolean
        Get
          If ChatRoom.StartsWith(DefaultChatRoom) Then
            Return True
          Else
            Return Collection.Contains(ChatRoom)
          End If
        End Get
        Set(ByVal value As Boolean)
          If Not ChatRoom.StartsWith(DefaultChatRoom) Then
            Select Case value
              Case True
                If Not Collection.Contains(ChatRoom) Then
                  Collection.Add(ChatRoom)
                End If
              Case False
                If Collection.Contains(ChatRoom) Then
                  Collection.Add(ChatRoom)
                End If
            End Select
          End If
        End Set
      End Property
      Sub Claer()
        Collection.Clear()
      End Sub
    End Class

    Sub SendMessage(ByVal Message As Message)
      SendMessage(Message.Text, Message.Author, Message.AuthorIsVisitors)
    End Sub
    Sub SendMessage(ByVal Text As String, ByVal Author As String, Optional ByVal AuthorIsVisitors As Boolean = False, Optional ByVal ChatRoom As String = DefaultChatRoom, Optional ByVal Censored As Boolean = False)
      Dim Message As New Message
      Dim DateNotSet As Date = Nothing
      Message.Time = Now.ToUniversalTime
      Message.Author = Author
      Message.Text = HttpUtility.HtmlEncode(Text)
      Message.AuthorIsVisitors = AuthorIsVisitors
      Array.Copy(Messages(ChatRoom), 0, Messages(ChatRoom), 1, MaxMessage - 1)
      Messages(ChatRoom)(0) = Message
      Select Case Message.Censored
        Case True
          LastMessageID(ChatRoom, True) += 1
        Case False
          LastMessageID(ChatRoom, False) += 1
          LastMessageID(ChatRoom, True) += 1
      End Select
      SaveMessages(ChatRoom)
      Dim Setting As SubSite
      If Not IsNothing(My.Response) Then
        Setting = CurrentSetting()
        RaiseChatMessageWritedEvent(ChatRoom, Text, Author, Setting)
      End If
    End Sub


		Private MessageSoppoler As New System.Collections.Generic.List(Of Message)

		Private WithEvents TimerSendMessageGermanyRu As New Timers.Timer

		Private Sub TimerSendMessageGermanyRu_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles TimerSendMessageGermanyRu.Elapsed
			Dim Message As Message
			If MessageSoppoler.Count Then
				Message = MessageSoppoler(0)
				MessageSoppoler.RemoveAt(0)
				SendMessage(Message)
			End If
			TimerSendMessageGermanyRu.Interval = 4000 + Rnd() * 8000
		End Sub

		Public Const StyleCode As String = "position:fixed;left:40px;width:300px;bottom:10px;z-index: 100;text-align:center;padding:5px;border:5px solid black;color:black;background:white;"

		Public Function ChatPopUpStyle() As WebControl
			Dim Style As New WebControl(HtmlTextWriterTag.Style)
			Style.Controls.Add(Literal(".popUp{" & StyleCode & "}"))
			Return Style
		End Function

		Public Function ChatInvite(ByVal FromUserName As String, ByVal Setting As SubSite, Optional ByVal Title As String = Nothing, Optional ByVal ForceNameInput As Boolean = True) As WebControl
			Dim PopUpBox As New WebControl(HtmlTextWriterTag.Div)
			PopUpBox.CssClass = "popUp"
			PopUpBox.ID = "popUpChat"


			Dim Top As New WebControl(HtmlTextWriterTag.Div)
			Dim Content As New WebControl(HtmlTextWriterTag.Div)
			Dim Bottom As New WebControl(HtmlTextWriterTag.Div)

			PopUpBox.Controls.Add(Top)
			PopUpBox.Controls.Add(Content)
			PopUpBox.Controls.Add(Bottom)

			If Title <> "" Then
				Dim TitleLabel As New Label
				TitleLabel.Text = Title
				TitleLabel.Style.Add("font-size", "xx-larger")
				TitleLabel.Style.Add("font-weight", "bold")
				Dim P As New WebControl(HtmlTextWriterTag.P)
				P.Controls.Add(TitleLabel)
				Top.Controls.Add(P)
			End If

			Dim AcceptMessage As New Label
			Dim User As User = User.Load(FromUserName)
			Dim Invitant As String
			If User IsNot Nothing Then
				Invitant = User.FirstName
			Else
				Invitant = FromUserName
			End If
			AcceptMessage.Text = FirstUpper(Invitant) & " " & Phrase(Setting.Language, 3232)	'FirstName invite you to join in private chat. Accept?
			Top.Controls.Add(AcceptMessage)

			Dim PName As New WebControl(HtmlTextWriterTag.P)
			Bottom.Controls.Add(PName)

			Dim NameLabel As New Label
			NameLabel.Text = Phrase(Setting.Language, 24) & ":"
			PName.Controls.Add(NameLabel)

			Dim NameUserChat As New WebControls.TextBox
			NameUserChat.ID = "NameUserChat"
			'NameUserChat.Attributes.Add("name", "NameUserChat")
			NameUserChat.MaxLength = 20
			NameUserChat.Text = CurrentUser.Username
			PName.Controls.Add(NameUserChat)

			Dim Enjoy As New WebControl(HtmlTextWriterTag.Button)
			Dim Script As String
      Script = "window.location.assign('" & Href(Setting.Name, True, "chat.aspx", QueryKey.ChatRoom, "_" & HttpContext.Current.Session.SessionID, QueryKey.ChatUser, "") & "'+document.getElementById('NameUserChat').value);"

			If ForceNameInput Then
				Script = "while (!document.getElementById('NameUserChat').value){document.getElementById('NameUserChat').value=prompt(""" & Ask(Phrase(Setting.Language, 24), Setting.Language) & """)};" & Script
			End If
			Enjoy.Attributes.Add("onclick", Script)
			Enjoy.Controls.Add(Literal(Phrase(Setting.Language, 1309)))
			Bottom.Controls.Add(Enjoy)

			Dim CloseButton As New WebControl(HtmlTextWriterTag.Button)
			CloseButton.Attributes.Add("onclick", "document.getElementById('popUpChat').parentNode.removeChild(document.getElementById('popUpChat'));")
			CloseButton.Controls.Add(Literal(Phrase(Setting.Language, 111)))
			Bottom.Controls.Add(CloseButton)

			'Add content into pop ub box

			If User IsNot Nothing AndAlso User.NamePhotoAlbum <> "" Then


				Dim PhotoAlbum As PhotoAlbum = User.PhotoAlbum

				If PhotoAlbum IsNot Nothing Then
					Dim Photos As Array = AllPhotosName(PhotoAlbum.Name)
					If Photos IsNot Nothing AndAlso Photos.Length > 0 Then
						Dim Photo As Photo = PhotoManager.Photo.Load(Photos(0), PhotoAlbum.Name)
						Dim Thumbnail As HtmlControl = Photo.ControlThumbnail(Setting, , 200)	 ' New WebControl(HtmlTextWriterTag.Span)
						Thumbnail.Attributes.Add("class", "BoxElement")
						Content.Controls.Add(Thumbnail)
					End If
				End If

				'Dim Avatar As Control = User.AvatarControl(Setting)
				'If Avatar IsNot Nothing Then
				'	Dim Box As New WebControl(HtmlTextWriterTag.Center)
				'	Box.Controls.Add(Avatar)
				'	Content.Controls.Add(Box)
				'End If
			End If

			Return PopUpBox
		End Function

		Function JavaScriptPopUp(ByVal Html As String, Optional ByVal AfterSeconds As Integer = 0) As String
			Dim JFunction As String = "function createPopUp(popUpCode){var div = document.createElement('div');div.innerHTML=popUpCode;document.body.appendChild(div.firstChild);}" & vbCrLf
			Dim CallFunction As String
			CallFunction = "function ChatWindowPopUp(){createPopUp('" & AbjustForJavascriptString(Html) & "');}" & vbCrLf
			If AfterSeconds Then
				'Note: The code Abjustment is necessary 2 times (AbjustForJavascriptString)
				CallFunction &= "setTimeout('" & AbjustForJavascriptString("if (!document.getElementById('NameUserChat')){ChatWindowPopUp()}") & "', " & AfterSeconds * 1000 & ")" & vbCrLf
			End If
			Return JFunction + CallFunction
		End Function

	End Module
End Namespace