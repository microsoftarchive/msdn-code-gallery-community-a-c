'AdSense plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class ChatRobot
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Private Shared SharedConfiguration As ChatRobotSharedConfiguration = Plugin.LoadSharedConfiguration
		Private Shared QuestionsByLanguage As Collections.Generic.Dictionary(Of Language, Collections.Generic.List(Of Question))
		Private Shared UsersInChat As New ClassUsersInChat
		Private Shared MonitoringPageVisited As New List(Of PageMonitor)
		Private Shared MonitoringUrlVisited As New StringCollection
		Shared Function Initialize() As PluginManager.Plugin
			If Plugin Is Nothing Then
				QuestionsByLanguage = New Collections.Generic.Dictionary(Of Language, Collections.Generic.List(Of Question))
        Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(ChatRobotConfiguration), GetType(ChatRobotSharedConfiguration))
				For Each Language As Language In LanguageManager.LanguagesUsed
					Dim Questions As Collections.Generic.List(Of Question) = New Collections.Generic.List(Of Question)
					For Each FileName As String In System.IO.Directory.GetFiles(Plugin.Directory, "*." & Acronym(Language) & ".txt")

						If IO.File.Exists(FileName) Then
							Dim Sibilling As Sibilling
							Dim Question As Question = New Question
							Dim Lines As String() = ReadAllRows(FileName, False)
							Dim LastLineIsEmpty As Boolean = False
							Dim SibillingStart As Boolean = False	'This flag is used for permit a multi-line text
							Dim NLine As Integer = 0
							For Each Line As String In Lines

								NLine += 1
								Try
									Select Case Line
										Case "!"
											Sibilling = Sibilling.Speek
											SibillingStart = True
										Case "?"
											Sibilling = Sibilling.Ask
											SibillingStart = True
											'Case "??"
											'	Sibilling = Sibilling.Splash
											'	SibillingStart = True
										Case Else
											Line = Trim(Line)
											'is not a Rem line
											If Not Line.StartsWith("/") Then
												If Line <> "" Then

													Select Case Line(0)
														Case "+"c, "="c, "-"c
															Dim Ambit As String = ""
															Dim AmbitType As Char = ""
															Dim Skip As Boolean = False
															Dim UBound As Integer = Line.Length - 1
															For N As Integer = 0 To UBound
																Dim Chr As Char = Line(N)
																Select Case Chr
																	Case "+"c
																		FixAmbitToQuestion(Language, Question, AmbitType, Ambit)
																		AmbitType = Chr
																	Case "-"c
																		FixAmbitToQuestion(Language, Question, AmbitType, Ambit)
																		AmbitType = Chr
																	Case "="c
																		If Not Ambit.Contains("?") Then
																			FixAmbitToQuestion(Language, Question, AmbitType, Ambit)
																			AmbitType = Chr
																		Else
                                      Dim Tmp As String = ReplaceBin(Ambit, "?", "&")
																			If InStrRev("=", Tmp) > InStrRev("&", Tmp) Then
																				FixAmbitToQuestion(Language, Question, AmbitType, Ambit)
																				AmbitType = Chr
																			End If
																		End If
																	Case Else
																		Ambit &= Chr
																		If N = UBound Then
																			FixAmbitToQuestion(Language, Question, AmbitType, Ambit)
																		End If
																End Select
															Next
														Case Else
															Select Case Sibilling
																Case Sibilling.Ask
																	Question.Ask.Add(PhraseToStrings(Line))
																Case Sibilling.Speek
																	If SibillingStart Then
																		Question.Answer.Add(Line)
																		If Not Question.SearchUseOnly Then
																			If InStr(Line, "SEARCH") <> 0 OrElse InStr(Line, "INSIDE") <> 0 Then
																				Question.SearchUseOnly = True
																			End If
																		End If
																	Else
																		'Add multy line text
																		Dim MultiLines As String = Question.Answer(Question.Answer.Count - 1)
																		MultiLines &= vbLf & Line
																		Question.Answer(Question.Answer.Count - 1) = MultiLines
																	End If
																	'Case Sibilling.Splash
																	'	If SibillingStart Then
																	'		Question.Splash.Add(Line)
																	'	Else
																	'		'Add multy line text
																	'		Question.Splash(Question.Splash.Count - 1) &= vbLf & Line
																	'	End If
															End Select
													End Select
												Else
													If Not LastLineIsEmpty Then
														Questions.Add(Question)
														Question = New Question
													End If
												End If
												LastLineIsEmpty = Line = ""
												SibillingStart = False
											End If
									End Select
								Catch ex As Exception
									WriteAll("Error at line " & NLine & " at position: " & Line, "error." & FileName, True, False)
								End Try
							Next
							If Lines.Count Then
								If Not Questions.Contains(Question) Then
									Questions.Add(Question)
								End If
							End If
						End If
					Next
					QuestionsByLanguage.Add(Language, Questions)
				Next
				Return Plugin
			End If
      Return Nothing
    End Function

		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			If ShortDescription Then
				Return "Chat robot"
			Else
				If Language = LanguageManager.Language.Italian Then
          Return "Plugin che aggiunge un robot autorisponditore il quale simula un operatore e assiste i visitatori nel sito web. Occorre preventivamente programmare il robot tramite un apposito linguaggio: " & CopyrightLink & "?p=82&a=26&t=instructionschatlanguage"
				Else
          Return "Plugin to the addition of a robot autoresponder that simulates an operator to assist the visitors in the website. It should advance to program the robot using a special language: " & CopyrightLink & "?p=82&a=26&t=instructionschatlanguage"
				End If
			End If
		End Function


		Class ChatRobotConfiguration
			Public CustomizeTitle As String
			Public RobotsUserName() As String = {"Admin"}
			Public HowManyTimesShowInviteForSessionNavigation As Integer = 2
			Public ShowInviteAfterSeconds As Integer = 10
		End Class

		Class ChatRobotSharedConfiguration
			Public UseSharedConfigurationToAllSettings As Boolean
			Public LogTheConversations As Boolean
			Public ChatRobotConfiguration As New ChatRobotConfiguration
		End Class

		Private Class PageMonitor
			Public Page As Integer
			Public Archive As Integer
			Public Language As Language
		End Class

		Private Shared Sub Plugin_ChatMessageWrited(ByVal ChatRoom As String, ByVal Text As String, ByVal Author As String, ByVal Setting As SubSite) Handles Plugin.ChatMessageWrited
			If Setting IsNot Nothing Then
				If QuestionsByLanguage.ContainsKey(Setting.Language) Then
					Dim Questions As Collections.Generic.List(Of Question) = QuestionsByLanguage(Setting.Language)
					Dim User As ClassUsersInChat.ChatUser = UsersInChat.RetriveUser(ChatRoom)

					If User IsNot Nothing Then
						User.CounterMessage += 1
						User.TimeOfLastMessageWritedIntoChatRoom = Now.ToUniversalTime
						User.TimeOfLastMessageWritedIntoChatRoomByUser = User.TimeOfLastMessageWritedIntoChatRoom

						Select Case User.CounterMessage
							Case 5
								If Not User.Entity.Ambit.Contains("RUNNING") Then
									User.Entity.Ambit.Add("RUNNING")
								End If
							Case 4
								SyncLock User.Entity.Ambit
									If User.Entity.Ambit.Contains("INTRODUCTORY") Then
										User.Entity.Ambit.Remove("INTRODUCTORY")
									End If
								End SyncLock
							Case 1
								User.Entity.Ambit.Add("INTRODUCTORY")
								SyncLock User.Entity.Ambit
									If User.Entity.Ambit.Contains("WELCOME") Then
										User.Entity.Ambit.Remove("WELCOME")
									End If
								End SyncLock
						End Select

						'Log conversation
						If SharedConfiguration.LogTheConversations Then
							WriteAll(Now.ToUniversalTime & vbTab & Author & ":" & vbCrLf & Text & vbCrLf, Plugin.Directory & "log\" & ChatRoom & ".txt", True, False)
						End If

						Dim Answer As String = BestAnswer(PhraseToStrings(Text), User, Questions)
						If Answer <> "" Then
							UsersInChat.SendMessage(Answer, ChatRoom, User.InvitedByRobotName)
						End If

						'Delete one time ambit
						SyncLock User.Entity.Ambit
							Dim Remover As New StringCollection
							For Each Ambit As String In User.RemoveAmbitList
								If User.Entity.Ambit.Contains(Ambit) Then
									User.Entity.Ambit.Remove(Ambit)
								End If
								Remover.Add(Ambit)
							Next
							For Each Ambit As String In Remover
								If User.RemoveAmbitList.Contains(Ambit) Then
									User.RemoveAmbitList.Remove(Ambit)
								End If
							Next
							For Each Ambit As String In User.Entity.Ambit
								If Ambit.StartsWith("#") Then
									If Not User.RemoveAmbitList.Contains(Ambit) Then
										User.RemoveAmbitList.Add(Ambit)
									End If
								End If
							Next
						End SyncLock


					End If
				End If
			End If
		End Sub

		Shared Function SetVariables(ByVal Text As String, ByVal User As ClassUsersInChat.ChatUser) As String
			If Text <> "" Then
				Dim Robot As Authentication.User = Authentication.User.Load(User.InvitedByRobotName)
				If Robot IsNot Nothing Then
          Text = ReplaceBin(Text, "ROBOT.NAME", Robot.FirstName)
          Text = ReplaceBin(Text, "ROBOT.LASTNAME", Robot.LastName)
          Text = ReplaceBin(Text, "ROBOT.PHONE", Robot.Phone)
          Text = ReplaceBin(Text, "ROBOT.SKYPE", Robot.Skype)
          Text = ReplaceBin(Text, "ROBOT.CITY", Robot.City)
          Text = ReplaceBin(Text, "ROBOT.WEBPAGE", Robot.URL)
          Text = ReplaceBin(Text, "ROBOT.EMAIL", Robot.Email)
          Text = ReplaceBin(Text, "ROBOT.COUNTRY", Robot.Country)
				Else
          Text = ReplaceBin(Text, "ROBOT.NAME", User.InvitedByRobotName)
				End If

        Text = ReplaceBin(Text, "USER.NAME", User.Entity.Name)
        Text = ReplaceBin(Text, "WEBSITE", "http://" & CurrentDomain())
				Return Text
			End If
      Return Nothing
    End Function

		Private Shared Sub Plugin_Load() Handles Plugin.Load
			If Not IO.Directory.Exists(Plugin.Directory & "log") Then
				'Create a log directory if not exists
				IO.Directory.CreateDirectory(Plugin.Directory & "log")
			End If
		End Sub

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			'Effect only for website with robots programmed for the same language of website
			'Please, add or edit the Instructions Chat Language file into directory \app_data\Plugins\ChatRobot
			If QuestionsByLanguage.ContainsKey(MasterPage.Setting.Language) Then
				Dim Request = HttpContext.Current.Request
				Dim Session = HttpContext.Current.Session

				'Enabled this plugin function only for chat with the same name of id session user
        If Session.SessionID <> Request.QueryString(QueryKey.ChatRoom) Then

          'Monitoring navigation of user and assign him the appropriates ambits
          If Session("AmbitsChatRobot") Is Nothing Then
            Session("AmbitsChatRobot") = New StringCollection
          End If
          Dim AmbitUser As StringCollection = Session("AmbitsChatRobot")
          Dim UserPage As String = UCase(CurrentPage())
          For Each UrlPage As String In MonitoringUrlVisited
            If Not AmbitUser.Contains(UrlPage) Then
              If UserPage.StartsWith(UrlPage) Then
                'The used has visited a determinate page monitoring into ambit conditions
                AmbitUser.Add(UrlPage)
              End If
            End If
          Next

          If Not Request.Path.EndsWith("/chat.aspx") Then
            If Request.Browser.EcmaScriptVersion.Major >= 1 Then
              Dim Configuration As ChatRobotConfiguration = GetConfiguration()
              If Configuration.RobotsUserName.Count > 0 Then
                If Configuration.RobotsUserName.Count Then
                  Dim RobotUserName As String
                  If Session("ChatRobotUserName") IsNot Nothing Then
                    RobotUserName = Session("ChatRobotUserName")
                    Session("ShowChatRobot") += 1
                  Else
                    'Get Random a robot
                    RobotUserName = Configuration.RobotsUserName(RandomIntNumber(Configuration.RobotsUserName.Count - 1))
                    Session("ChatRobotUserName") = RobotUserName
                    Session("ShowChatRobot") = 1
                  End If
                  Dim Title As String
                  If Configuration.CustomizeTitle = "" Then
                    Title = Phrase(MasterPage.Setting.Language, 3199)
                  Else
                    Title = Configuration.CustomizeTitle
                  End If


                  Dim ShowInviteAfterSeconds As Integer
                  'Don't invite into chat the users exit from the chat
                  If Session("UserChatInfo") Is Nothing Then
                    'Limit the request of enjoy in chat room
                    If Session("ShowChatRobot") <= Configuration.HowManyTimesShowInviteForSessionNavigation Then
                      'Permit enjoin in chat only to user never try the chat with robot
                      If MasterPage.User.Attribute("ChatRobot") Is Nothing Then
                        ShowInviteAfterSeconds = Configuration.ShowInviteAfterSeconds
                      End If
                    End If
                  End If
                  Dim ChatInviteCode = ControlToText(ChatManager.ChatInvite(RobotUserName, MasterPage.Setting, Title))
                  'Dim ScriptPopup As Control = Script(ChatManager.JavaScriptPopUp(ChatInviteCode), ScriptLanguage.javascript)
                  Dim ScriptPopup As Control = Script(ChatManager.JavaScriptPopUp(ChatInviteCode, ShowInviteAfterSeconds), ScriptLanguage.javascript)
                  MasterPage.Bottom.Controls.Add(ScriptPopup)
                  MasterPage.Page.Header.Controls.Add(ChatManager.ChatPopUpStyle) 'Add style of popup to header
                  MasterPage.AddButton(Phrase(MasterPage.Setting.Language, 2001, 3199), Nothing, , IconType.Help, , , "if (!document.getElementById('NameUserChat')){ChatWindowPopUp()}")
                End If
              End If
            End If
          ElseIf Session("ChatRobotUserName") Is Nothing Then
            'This user do not have invite in this chat. The session is expired!
            'Redirect to homepage
            HttpContext.Current.Response.Redirect(Href(MasterPage.Setting.Name, True, "default.aspx"))
          Else
            'The user is now in chat
            Dim ChatRoom As String = Request.QueryString(QueryKey.ChatRoom)
            'Verify if the user is in the chat room for robot
            If ChatRoom = "_" & Session.SessionID Then
              Dim UserChatInfo As ClassUsersInChat.ChatUser
              If Session("UserChatInfo") Is Nothing Then
                'Is a new user entered in chat
                UserChatInfo = New ClassUsersInChat.ChatUser
                Session("UserChatInfo") = UserChatInfo
                UserChatInfo.Entity.Name = FirstUpper(Request.QueryString(QueryKey.ChatJoinUser))
                UserChatInfo.Language = MasterPage.Setting.Language
                UserChatInfo.Entity.PrivateChatRoom = Request.QueryString(QueryKey.ChatRoom)
                UserChatInfo.InvitedByRobotName = Session("ChatRobotUserName")
                UserChatInfo.User = MasterPage.User 'Assign Current User
                UserChatInfo.Entity.Ambit = Session("AmbitsChatRobot")
                UserChatInfo.Domine = CurrentDomain()
                UserChatInfo.Entity.Ambit.Add(UserChatInfo.Domine)
                UserChatInfo.Entity.Ambit.Add(MasterPage.Setting.Name)
                If MasterPage.Setting.Forums IsNot Nothing Then
                  For Each IdForum As Integer In MasterPage.Setting.Forums
                    UserChatInfo.Entity.Ambit.Add("F" & IdForum)
                  Next
                End If
                If UserChatInfo.User.GeneralRole > User.RoleType.Visitors Then
                  UserChatInfo.User.Attribute("ChatRobot") = True 'Flag registered used to not repeat more the invitation if the user have try the chat wit robot
                  UserChatInfo.User.Save()
                End If
                If UserChatInfo.User.GeneralRole >= User.RoleType.Visitors Then
                  Select Case UserChatInfo.User.Gender
                    Case User.GenderType.Female
                      UserChatInfo.Entity.Ambit.Add("USER.FEMALE")
                    Case User.GenderType.Male
                      UserChatInfo.Entity.Ambit.Add("USER.MALE")
                  End Select
                End If
                Dim Robot As User = User.Load(UserChatInfo.InvitedByRobotName)
                If Robot IsNot Nothing Then
                  Select Case Robot.Gender
                    Case User.GenderType.Female
                      UserChatInfo.Entity.Ambit.Add("ROBOT.FEMALE")
                    Case User.GenderType.Male
                      UserChatInfo.Entity.Ambit.Add("ROBOT.MALE")
                  End Select
                End If

                SyncLock UsersInChat.Users
                  UsersInChat.Users.Add(UserChatInfo)
                End SyncLock

                'Log conversation
                If SharedConfiguration.LogTheConversations Then
                  Dim NameFile As String = Plugin.Directory & "log\"
                  If Not System.IO.Directory.Exists(NameFile) Then
                    System.IO.Directory.CreateDirectory(NameFile)
                  End If
                  NameFile &= ChatRoom & ".txt"
                  WriteAll("Chat Room: " & ChatRoom & vbCrLf, NameFile, True, False)
                  WriteAll("User Name: " & UserChatInfo.User.Username & vbCrLf, NameFile, True, False)
                  WriteAll("Name used in chat: " & UserChatInfo.Entity.Name & vbCrLf, NameFile, True, False)
                  WriteAll("IP: " & Request.UserHostAddress & vbCrLf, NameFile, True, False)
                  WriteAll("Gender User: " & UserChatInfo.User.Gender.ToString & vbCrLf, NameFile, True, False)
                  WriteAll("Robot: " & UserChatInfo.InvitedByRobotName & vbCrLf, NameFile, True, False)
                  WriteAll("Domine: " & CurrentDomain() & vbCrLf, NameFile, True, False)
                  WriteAll("Setting: " & MasterPage.Setting.Name & vbCrLf, NameFile, True, False)
                  WriteAll("Chat start time: " & Now.ToUniversalTime & vbCrLf, NameFile, True, False)
                End If

                UserChatInfo.Entity.Ambit.Add("WELCOME")


                'Write splash message
                Dim Questions As Collections.Generic.List(Of Question) = QuestionsByLanguage(MasterPage.Setting.Language)
                Dim Answer As String = BestAnswer(Nothing, UserChatInfo, Questions)
                If Answer = "" Then
                  Answer = Phrase(MasterPage.Setting.Language, 34)
                End If
                UsersInChat.SendMessage(Answer, ChatRoom, UserChatInfo.InvitedByRobotName)
              End If
            End If
          End If
        End If
			End If
		End Sub

		Private Shared Function GetConfiguration() As Plugin.ChatRobot.ChatRobotConfiguration
			If SharedConfiguration.UseSharedConfigurationToAllSettings Then
				Return SharedConfiguration.ChatRobotConfiguration
			Else
				Return Plugin.LoadConfiguration()
			End If
		End Function


		Class ClassUsersInChat
			Public WithEvents Refresh As New System.Timers.Timer

			Sub New()
				Refresh.Interval = 15000
				Refresh.Enabled = True
				Refresh.Start()
			End Sub

			Public Users As New Collections.Generic.List(Of ChatUser)

			Public Class ChatUser
				Public User As User
				Public Entity As New Entity
				Public InvitedByRobotName As String
				Public CounterMessage As Integer
				Public QuestionsUsed As New List(Of Question)
				Public Domine As String
				Public Language As Language
				Public RemoveAmbitList As New StringCollection
				Public TimeOfLastMessageWritedIntoChatRoom As Date
				Public TimeOfLastMessageWritedIntoChatRoomByUser As Date
			End Class

			Function RetriveUser(ByVal ChatRoom As String) As ChatUser
				SyncLock Users
					For Each User As ChatUser In Users
						If User.Entity.PrivateChatRoom = ChatRoom Then
							Return User
						End If
					Next
				End SyncLock
        Return Nothing
      End Function
			Sub SendMessage(ByVal Text As String, ByVal ChatRoom As String, ByVal RobotName As String)
				Static FirsMessageFlag As Boolean
        Text = ReplaceBin(Text, vbCr, "")
				Dim Texts As String() = Split(Text, vbLf)
				Dim PlaningTime As Date = Now.ToUniversalTime
				For Each Line As String In Texts
					Dim Message As Message
					If FirsMessageFlag = 0 Then
						'write immediatly the first message in chat by robot
						FirsMessageFlag = 1
					ElseIf Len(Line) < 200 Then
						PlaningTime = PlaningTime.AddSeconds(10)
					Else
						PlaningTime = PlaningTime.AddSeconds(15)
					End If
					If Line <> "" Then
						Message = New Message
						Message.Text = Line
						Message.ChatRoom = ChatRoom
						Message.Robot = RobotName
						Message.PlaningTime = PlaningTime
						SyncLock Spooler
							Spooler.Add(Message)
						End SyncLock
					End If
				Next
			End Sub
			Private Spooler As New Generic.List(Of Message)
			Class Message
				Public Text As String
				Public ChatRoom As String
				Public Robot As String
				Public PlaningTime As Date
			End Class

			Private Sub Refresh_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Refresh.Elapsed
				Const SplashMessageAfterSeconds As Integer = 50

				Try

					SyncLock Users

						'Remove offline user
						If Users.Count Then
							Dim ChatUsers() As ChatUser
							ReDim ChatUsers(Users.Count - 1)
							Users.CopyTo(ChatUsers)
							For Each ChatUser As ChatUser In ChatUsers
								If ChatUser.User.IsOnline = False Then
									Users.Remove(ChatUser)
								End If
							Next
						End If

						'Send splash message to user 
						For Each ChatUser As ChatUser In Users
							If ChatUser.CounterMessage > 1 Then
								If DateDiff(DateInterval.Second, ChatUser.TimeOfLastMessageWritedIntoChatRoom, Now.ToUniversalTime) >= SplashMessageAfterSeconds Then
									If DateDiff(DateInterval.Second, ChatUser.TimeOfLastMessageWritedIntoChatRoomByUser, Now.ToUniversalTime) <= SplashMessageAfterSeconds * 2 Then
										'Write splash message
										Dim Questions As Collections.Generic.List(Of Question) = QuestionsByLanguage(ChatUser.Language)
										Dim Answer As String = BestAnswer(Nothing, ChatUser, Questions)
										If Answer <> "" Then
											UsersInChat.SendMessage(Answer, ChatUser.Entity.PrivateChatRoom, ChatUser.InvitedByRobotName)
										End If
									End If
								End If
							End If
						Next

					End SyncLock
					SyncLock Spooler
						'Send message into spooler and remove it
						Dim Sended As New Generic.List(Of Message)
						For Each Message As Message In Spooler
							If Now.ToUniversalTime >= Message.PlaningTime Then
								Sended.Add(Message)
								Dim ToUser As ChatUser = RetriveUser(Message.ChatRoom)
								If ToUser IsNot Nothing Then 'Dont send if the user is exit
									ChatManager.SendMessage(Message.Text, Message.Robot, User.Load(Message.Robot) Is Nothing, Message.ChatRoom)

									'Set time of last message in chat room
									ToUser.TimeOfLastMessageWritedIntoChatRoom = Now.ToUniversalTime

									'Log conversation
									If SharedConfiguration.LogTheConversations Then
										WriteAll(Now.ToUniversalTime & vbTab & Message.Robot & ":" & vbCrLf & Message.Text & vbCrLf, Plugin.Directory & "log\" & Message.ChatRoom & ".txt", True, False)
									End If
								End If
							End If
						Next
						For Each Message As Message In Sended
							Spooler.Remove(Message)
						Next
					End SyncLock

				Catch ex As Exception
					Log("RobotChatError", 100, ex.Message & vbCrLf & ex.Source & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf)
				End Try

			End Sub
		End Class


		Public Class Question
			Public Ask As New Collections.Generic.List(Of String())
			Public Answer As New StringCollection
			'Public Splash As New StringCollection
			Public Ambit As New StringCollection
			Public NotAmbit As New StringCollection
			Public IfThisAnswerAddAmbitToUser As New StringCollection
      Public SearchUseOnly As Boolean
			Public AdditionalImportance As Integer
		End Class

		Private Shared Function PhraseToStrings(ByVal Phrase As String) As String()
			Phrase = RemoveAccent(LCase(Phrase))
			Phrase = Trim(WordsWithSingleSpaceDelimiter(Phrase))
			PhraseToStrings = Split(Phrase)
		End Function

		Private Enum Sibilling
			Ask
			Speek
		End Enum

		Class Entity
      Public Name As String
			Public Ambit As New StringCollection
			Public PrivateChatRoom As String
		End Class

		Private Entities As New Collections.Generic.List(Of Entity)

		Private Shared Function BestAnswer(ByVal Ask() As String, ByVal UserInChat As ClassUsersInChat.ChatUser, ByVal Questions As Collections.Generic.List(Of Question)) As String
			Dim BestStimation As Integer
      Dim BestQuestion As Question = Nothing
			Dim EntityUser As Entity = UserInChat.Entity

			If Ask Is Nothing Then
				'Splash the welcome message at the first access or at user inactivity
				For Each Question As Question In Questions
					If Not Question.SearchUseOnly Then
						If Not UserInChat.QuestionsUsed.Contains(Question) Then
							If UserInChat.CounterMessage > 0 OrElse (UserInChat.CounterMessage = 0 AndAlso Question.Ambit.Contains("WELCOME")) Then
								If AmbitCompatible(EntityUser.Ambit, Question.Ambit, Question.NotAmbit) Then
									If Question.Ask.Count = 0 AndAlso Question.Answer.Count <> 0 Then
										Return ReturnAnswer(UserInChat, Question)
									End If
								End If
							End If
						End If
					End If
				Next
			Else
				For Each Question As Question In Questions
					If Not UserInChat.QuestionsUsed.Contains(Question) Then
						Dim Stimation As Integer = AnswerStimation(Ask, Question, EntityUser)
						If Stimation > BestStimation Then
							BestStimation = Stimation
							BestQuestion = Question
							If BestStimation >= 100 + Ask.Count Then
								Exit For
							End If
						End If
					End If
				Next

				If BestStimation >= 70 Then
					'Add ambit to user if the best question set the ambit of user
					If BestQuestion.IfThisAnswerAddAmbitToUser.Count Then
						For Each Ambit As String In BestQuestion.IfThisAnswerAddAmbitToUser
							If Not EntityUser.Ambit.Contains(Ambit) Then
								EntityUser.Ambit.Add(Ambit)
							End If
						Next
					End If
					'Return the best question finded!
					Return ReturnAnswer(UserInChat, BestQuestion, Ask)
				Else
					'Answer not found. Use google to find appropriate answer
					If InStr(Join(Ask, ""), "?") Then
						For Each Question As Question In Questions
							If Question.SearchUseOnly Then
								If Not UserInChat.QuestionsUsed.Contains(Question) Then
									If AmbitCompatible(EntityUser.Ambit, Question.Ambit, Question.NotAmbit) Then
										If Question.Ask.Count = 0 AndAlso Question.Answer.Count <> 0 Then
											'For Each Answer In Question.Answer
											'	If InStr(Answer, "SEARCH") <> 0 OrElse InStr(Answer, "INSIDE") <> 0 Then
											Return ReturnAnswer(UserInChat, Question, Ask)
											'	End If
											'Next
										End If
									End If
								End If
							End If
						Next
					End If
				End If
			End If
      Return Nothing
    End Function

		Private Shared Function ReturnAnswer(ByVal UserInChat As ClassUsersInChat.ChatUser, ByVal Question As Question, Optional ByVal Ask() As String = Nothing) As String
			If Question.Answer.Count <= 1 Then
				UserInChat.QuestionsUsed.Add(Question)
			End If

			Dim Phrases As StringCollection
			Phrases = Question.Answer

			Dim Result As String = SetVariables(Phrases(RandomIntNumber(Phrases.Count - 1)), UserInChat)

			If Ask IsNot Nothing Then
				Dim PhreseSearch As String = Join(Ask)
				If InStr(Result, "SEARCH") Then
					Dim ResultsOutsideSearch As New StringCollection
					Search.Find(ResultsOutsideSearch, PhreseSearch)
					If ResultsOutsideSearch.Count Then
						Dim SearchOut As String = "http://" & ResultsOutsideSearch(0)
            Result = ReplaceBin(Result, "SEARCH", SearchOut)
					End If
				End If

				If InStr(Result, "INSIDE") Then
					Dim ResultsInsideSearch As New StringCollection
					Search.Find(ResultsInsideSearch, PhreseSearch, UserInChat.Domine)
					If ResultsInsideSearch.Count Then
						Dim SearchIn As String = "http://" & ResultsInsideSearch(0)
            Result = ReplaceBin(Result, "INSIDE", SearchIn)
					End If
				End If
			End If

			Return Result
		End Function

		Private Shared Function AnswerStimation(ByVal Ask() As String, ByVal Question As Question, ByVal UserInChat As Entity) As Integer
      Dim BestStimation As Integer
      If AmbitCompatible(UserInChat.Ambit, Question.Ambit, Question.NotAmbit) Then
        Dim AskJoin As String = Join(Ask)
        'Dim ShortAsk() = TruncateGender(Ask)
        For Each MindAsk() As String In Question.Ask
          'Dim ShortMindAsk() As String = TruncateGender(MindAsk)
          Dim MindAskJoin As String = Join(MindAsk)
          If MindAskJoin = AskJoin Then
            'The phrase is indentically
            SetBestStimation(BestStimation, 100 + MindAsk.Count + Question.AdditionalImportance)
          End If

          If InStr(AskJoin, MindAskJoin) Then
            'The phrase is present
            SetBestStimation(BestStimation, 90 + MindAsk.Count + Question.AdditionalImportance)
          End If

          If UBound(Ask) >= 0 AndAlso UBound(MindAsk) >= 0 Then
            Dim Equal As Integer = 0


            For Each WordMind As String In MindAsk
              For Each Word As String In Ask
                If IsSimilar(Word, WordMind) Then
                  'BaseRobotWords.Remove(WordMind)
                  Equal += 1
                  Exit For
                End If
              Next
            Next
            If Equal = MindAsk.Count Then
              'Sono presenti tutte le parole
              SetBestStimation(BestStimation, 80 + MindAsk.Count + Question.AdditionalImportance)
            End If
          End If
        Next
      End If
      Return BestStimation
    End Function

		Private Shared Function AmbitCompatible(ByVal AmbitUser As StringCollection, ByVal AmbitQuestion As StringCollection, ByVal NotAmbitQuestion As StringCollection) As Boolean
			If SameAmbit(AmbitUser, AmbitQuestion) Then
				If ForThisUser(AmbitUser, NotAmbitQuestion) Then
					Return True
				End If
			End If
      Return False
    End Function

		Private Shared Function SameAmbit(ByVal AmbitUser As StringCollection, ByVal AmbitNeed As StringCollection) As Boolean
			If AmbitNeed.Count = 0 Then
				Return True
			Else
				If AmbitUser.Count Then
					For Each Ambit As String In AmbitNeed
						If Not AmbitUser.Contains(Ambit) Then
							Return False
						End If
					Next
					Return True
				End If
			End If
      Return False
    End Function

		Private Shared Function ForThisUser(ByVal AmbitUser As StringCollection, ByVal AmbitNotNeed As StringCollection) As Boolean
			For Each Ambit As String In AmbitNotNeed
				If AmbitUser.Contains(Ambit) Then
					Return False
				End If
			Next
			Return True
		End Function


		'Private Shared Function TruncateGender(ByVal Strings() As String) As String()
		'	Dim Texts As New StringCollection
		'	Dim HaveLong As Boolean
		'	For Each Text As String In Strings
		'		If Len(Text) >= 3 Then
		'			Texts.Add(Left(Text, Len(Text) - 1))
		'			If Len(Text) >= 5 Then
		'				HaveLong = True
		'			End If
		'		Else
		'			Texts.Add(Left(Text, Len(Text)))
		'		End If
		'	Next

		'	If HaveLong Then
		'		Dim Remover As New StringCollection
		'		For Each Text As String In Texts
		'			If Len(Text) <= 3 Then
		'				Remover.Add(Text)
		'			End If
		'		Next
		'		For Each Text As String In Remover
		'			Texts.Remove(Text)
		'		Next
		'	End If
		'	Dim Result(Texts.Count - 1) As String
		'	Texts.CopyTo(Result, 0)
		'	Return Result
		'End Function

    Private Shared Sub SetBestStimation(ByRef Best As Integer, ByRef NewStimation As Integer)
      If NewStimation > Best Then
        Best = NewStimation
      End If
    End Sub

		Private Shared Sub FixAmbitToQuestion(ByVal Language As Language, ByVal Question As Question, ByVal AmbitType As Char, ByRef Ambit As String)
			If Ambit <> "" Then
				Select Case AmbitType
					Case "+"c
						Question.IfThisAnswerAddAmbitToUser.Add(Ambit)
					Case "-"c
						Question.NotAmbit.Add(Ambit)
					Case "="c
						Question.Ambit.Add(Ambit)
						If Ambit.StartsWith("#") Then
							Question.AdditionalImportance = 10
						End If
						'Add to monitoring if the ambit is inherent to a page visited
						If Len(Ambit) >= 6 Then
							If Ambit(0) = "P"c AndAlso Char.IsNumber(Ambit(1)) AndAlso Char.IsNumber(Ambit(Ambit.Count - 1)) Then
								Ambit = Mid(Ambit, 2)
								Dim Parameters() As String = Split(Ambit, "A")
								Dim PageMonitor As PageMonitor = New PageMonitor
								PageMonitor.Page = Parameters(0)
								PageMonitor.Archive = Parameters(1)
								PageMonitor.Language = Language
								MonitoringPageVisited.Add(PageMonitor)
							End If
						ElseIf Ambit.Contains(".ASPX") Then
							MonitoringUrlVisited.Add(Ambit)
						End If
				End Select
			End If
			Ambit = ""
		End Sub

		Private Shared Sub Plugin_RenderingPage(ByVal Archive As Integer, ByVal Page As Integer, ByVal Setting As Config.SubSite, ByVal HttpContext As HttpContext, ByVal Where As Control, ByVal MetaTags As Common.MetaTags, ByVal Body As String, ByVal BottomContent As HtmlControl) Handles Plugin.RenderingPage
			If HttpContext IsNot Nothing Then
				'Monitoring navigation of user and assign him the appropriates ambits
				Dim UserPage As String = UCase(CurrentPage())
				For Each PageMonitoring As PageMonitor In MonitoringPageVisited
					If PageMonitoring.Page = Page AndAlso PageMonitoring.Archive = Archive AndAlso PageMonitoring.Language = Setting.Language Then
						Dim AmbitString As String = "P" & Page & "A" & Archive
						If HttpContext.Current.Session("AmbitsChatRobot") Is Nothing Then
							HttpContext.Current.Session("AmbitsChatRobot") = New StringCollection
						End If
						Dim AmbitUser As StringCollection = HttpContext.Current.Session("AmbitsChatRobot")
						If Not AmbitUser.Contains(AmbitString) Then
							'The user has visited a determinate page monitoring into ambit conditions
							AmbitUser.Add(AmbitString)
						End If
					End If
				Next
			End If
		End Sub
	End Class

End Namespace