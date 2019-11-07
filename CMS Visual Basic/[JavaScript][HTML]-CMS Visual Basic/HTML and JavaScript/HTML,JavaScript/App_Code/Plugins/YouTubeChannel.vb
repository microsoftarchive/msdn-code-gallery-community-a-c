'Plugin: Unplug = Remove this file
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
	Public Class YouTubeChannel
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing AndAlso Not CurrentPluginRunning() Then
          Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(YouTubeChannelConfiguration))

        '*********** elminare (this plugin is a beta)
        Log("youtubestart", 0, "start plugin", Threading.Thread.GetDomain.FriendlyName)
        '**************


        If Not IsLocal() AndAlso (Servers.Count = 0 OrElse My.Computer.Name = Servers(0)) Then

          Timer = New Timers.Timer(60000 * 20) 'The first check is at 20 minutes
          Timer.Enabled = True
          Timer.Start()

        End If
        '**********  REMOVE:
        'Timer_Elapsed(Nothing, Nothing)

        'Else
        'Timer.Enabled = False
      End If
      Return Plugin
    End Function
		Shared Sub New()
			'In multi-server configuration, enable the timer only for one server
			'Timer_Elapsed(Nothing, Nothing)	'Test
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			Select Case Language
				Case LanguageManager.Language.Italian
					If ShortDescription Then
						Return "Canale YouTube"
					Else
						Return "Plugin per l'importazione dei canali YouTube dentro il forum"
					End If
				Case Else
					If ShortDescription Then
						Return "YouTube Channel"
					Else
						Return "Plugins for importing YouTube channels into a forum"
					End If
			End Select
		End Function

		Public Shared WithEvents Timer As Timers.Timer

		Class YouTubeChannelConfiguration
			Public YouTubeChannels(-1) As YouTubeChannel
		End Class

		Class YouTubeChannel
			Public UrlOfChannel As String = "http://www.youtube.com/user/russologia"
			Public AddVideoPlayerOfChannelInHomePage As VideoPlayerPosition
			Enum VideoPlayerPosition
				None
				InTopOfContentBox
				InBottomOfContentBox
				InBottomOfPage
			End Enum
		End Class

		Class YouTubeDataPlugin
			Public Channels(-1) As DataChannel
		End Class

		Class DataChannel
			Public Id As String
			Public ForumId As Integer
			Public PlayListId As String
			Public SubCategory As Integer
			Public Videos(-1) As Video
		End Class

		Class Video
			Public VideoId As String
			Public TopicId As Integer
		End Class

		Private Shared Sub Timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer.Elapsed
			For Each SubSite As SubSite In AllSubSite()
				LoadSource(SubSite)
			Next
			Timer.Interval = 60000 * 20	'Next update after 60 min 
		End Sub

		Private Shared Sub Plugin_AfterSavePluginConfiguration(Configuration As Object, ByRef InvokeConfigurationPageRefresh As Boolean) Handles Plugin.AfterSavePluginConfiguration
      RunLoadSource(CurrentSetting)
    End Sub

    Shared Sub RunLoadSource(Setting As SubSite)
      Dim NewThread As System.Threading.Thread = New System.Threading.Thread(AddressOf LoadSource)
      NewThread.IsBackground = True
      NewThread.Start(Setting)
    End Sub

    Shared Sub LoadSource(SubSite As SubSite)
      Static Running As Boolean
      If Not Running Then
        Running = True
        Try
          If Plugin.IsEnabled(SubSite) Then
            SyncLock Plugin
              Dim Config As YouTubeChannelConfiguration
              Config = Plugin.LoadObject(GetType(YouTubeChannelConfiguration), SubSite.Name)
              If Config.YouTubeChannels.Count <> 0 Then
                Dim Data As YouTubeDataPlugin = Plugin.LoadObject(GetType(YouTubeDataPlugin), SubSite.Name)
                Dim SaveObject As Boolean = False

                For Each Channel As YouTubeChannel In Config.YouTubeChannels
                  ImportFromChannel(Channel, SubSite, SaveObject, Data)
                Next

                If SaveObject Then
                  Plugin.SaveObject(Data, SubSite.Name)
                End If
              End If
            End SyncLock
          End If
        Catch ex As Exception
          Log("YouTubeChannel", 100, "ERROR!", ex.Message, ex.Source, ex.StackTrace)
        End Try
        Running = False
      End If
    End Sub

    Shared Sub ImportFromChannel(Channel As YouTubeChannel, SubSite As SubSite, ByRef SaveObject As Boolean, Data As YouTubeDataPlugin)
      If Channel.UrlOfChannel.ToLower.StartsWith("http://www.youtube.com/user/") Then
        Dim ChannelId As String = Trim(Mid(Channel.UrlOfChannel, 29))
        If ChannelId = "" Then
          Exit Sub
        End If
        ChannelId = Split(ChannelId, "?")(0)

        'Find or create a DataChannels for save a data of this YouTube channel
        Dim DataChannel As DataChannel = Nothing
        Dim ChannelFinded As Boolean = False
        For Each DataChannel In Data.Channels
          If DataChannel.Id = ChannelId Then
            ChannelFinded = True
            Exit For
          End If
        Next
        If Not ChannelFinded Then
          DataChannel = Nothing
        End If





        '*********** elminare
        If DataChannel Is Nothing Then
          Log("youtube", 0, "nothing")
        Else
          Log("youtube", 0, "SubSite", SubSite.Name)
          Log("youtube", 0, "ForumId", DataChannel.ForumId)
          Log("youtube", 0, "SubCategory", DataChannel.SubCategory)
        End If
        '**************






        If DataChannel Is Nothing Then
          DataChannel = New DataChannel
          DataChannel.Id = ChannelId
          ReDim Preserve Data.Channels(Data.Channels.Count)
          Data.Channels(UBound(Data.Channels)) = DataChannel
          SaveObject = True
        End If
        'Find all videos in the channel
        Dim PageChannel As Integer = 0
        Dim Ids As New Collections.Specialized.StringCollection
        Ids.Clear()
        Dim Html As String = ""
        Dim IsNewChannel = DataChannel.Videos.Count = 0
        Do
          PageChannel += 1
          Dim ChannelUrl As String = "http://m.youtube.com/user/" & ChannelId & "/videos?page=" & PageChannel.ToString
          Html = ReadHtmlFromWeb(ChannelUrl, , 30000)
          'Threading.Thread.Sleep(15000)
          If Html <> "" Then
            Dim P As Integer = 0
            Dim Added As Integer = 0
            Do
              P = InStr(P + 1, Html, "&amp;v=", CompareMethod.Binary)
              If P <> 0 Then
                Dim Id As String = Mid(Html, P + 7, 11)
                For Each Video As Video In DataChannel.Videos
                  If Video.VideoId = Id Then
                    Exit Do
                  End If
                Next
                Ids.Add(Id)
                Added += 1
              End If
            Loop Until P = 0
            If Added = 0 Then
              Exit Do
            End If
          End If
        Loop
        If Ids.Count = 0 Then
          If Not IsNewChannel Then
            Exit Sub
          End If
        Else
          If SubSite.Forums IsNot Nothing AndAlso SubSite.Forums.Count <> 0 Then
            If DataChannel.ForumId <> SubSite.Forums(0) Then
              SaveObject = True
              DataChannel.ForumId = SubSite.Forums(0)
              'Add subcategory to forum
              Dim Forum As Forum = Forum.Load(DataChannel.ForumId)
              If Forum.ForumStructure IsNot Nothing AndAlso Forum.ForumStructure.Categories.Count > 0 Then
                Dim TitleCategory As String = Description(SubSite.Language, True)
                Dim Category As ForumStructure.Category = Nothing
                For Each ForumCategory As ForumStructure.Category In Forum.ForumStructure.Categories
                  If ForumCategory.Title = TitleCategory Then
                    Category = ForumCategory
                    Exit For
                  End If
                Next
                If Category Is Nothing Then
                  Category = Forum.ForumStructure.AddCategory(TitleCategory)
                End If
                Dim Title As String = New MetaTags(Html).Title
                If Title.StartsWith("YouTube - ") Then
                  Title = Mid(Title, 11)
                End If
                DataChannel.SubCategory = Forum.ForumStructure.LastId + 1
                Category.AddSubcategory(Title, Description(SubSite.Language, True) & " " & Title, DataChannel.SubCategory)
                Forum.ForumStructure.Save()
              End If
            End If
            'Add all videos
            For Idx As Integer = Ids.Count - 1 To 0 Step -1
              Dim VideoId As String = Ids.Item(Idx)
              'Verify if video is added
              Dim Added As Boolean = False
              For Each Video As Video In DataChannel.Videos
                If Video.VideoId = VideoId Then
                  Added = True
                  Exit For
                End If
              Next
              If Not Added Then
                'Add a new wideo
                Dim TopicId As Integer = 0
                'Threading.Thread.Sleep(15000)
                WebApplication.Global.SecureTaskStart()
                TopicId = AddVideo(VideoId, DataChannel.ForumId, DataChannel.SubCategory, DataChannel.Id)
                Select Case TopicId
                  Case Is > 0
                    'SaveObject = True
                    ReDim Preserve DataChannel.Videos(DataChannel.Videos.Count)
                    Dim Video As New Plugin.YouTubeChannel.Video
                    DataChannel.Videos(UBound(DataChannel.Videos)) = Video
                    Video.VideoId = VideoId
                    Video.TopicId = TopicId
                    Plugin.SaveObject(Data, SubSite.Name) 'Save now to prevent unsave caused from restart of applitation 
                    SaveObject = False
                  Case -1
                    WebApplication.Global.SecureTaskEnd()
                    Plugin.SaveObject(Data, SubSite.Name)
                    'The access to channel is temporarily blocked
                    Exit Sub
                End Select
                WebApplication.Global.SecureTaskEnd()
              End If
            Next
          End If
        End If
      End If
    End Sub

    Shared Function RetrivePlayListId(VideoChannel As String) As String
      Dim Html As String = ReadHtmlFromWeb("http://www.youtube.com/user/" & VideoChannel, , 30000)
      Return ExtrapolateTextBetween(Html, ";list=", "&")
    End Function

    Shared Function AddVideo(Id As String, ForumId As Integer, CategoryId As Integer, Author As String) As Integer
      Dim Html As String
      Try
        Html = ReadHtmlFromWeb("http://www.youtube.com/watch?v=" & Id & "&hl=en", , 30000)
      Catch ex As Exception
        Return 0
        'Time out error
      End Try
      If Html <> "" Then
        Dim Text As String = ExtrapolateTextBetween(Html, "<p id=""eow-description"" >", "</p>")
        'Text = InnerText(Text)
        If InStr(Text, "No description available.") Then
          Text = ""
        End If
        Dim VideoDate As String = ExtrapolateTextBetween(Html, "class=""watch-video-date"" >", "</span>")
        Dim Created As Date
        If VideoDate <> "" Then
          Try
            Created = Date.Parse(VideoDate, New Globalization.CultureInfo("en-US"))
          Catch ex As Exception
            'Stop
          End Try
          Created = Created.AddHours(Now.ToUniversalTime.Hour)
          Created = Created.AddMinutes(Now.ToUniversalTime.Minute)
          Created = Created.AddSeconds(Now.ToUniversalTime.Second)
        End If

        Dim Tag As New MetaTags(Html)
        Dim Title As String = Trim(Tag.Title)
        Title = ReplaceBin(Title, vbLf, "")
        If Title.EndsWith("- YouTube") Then
          Title = Left(Title, Title.Length - 9)
        End If
        Title = Trim(Title)
        If InStr(Html, "YouTube - Broadcast Yourself") Then
          Return -1 'FeedBack server is not available in this moment
        End If
        If Text = "" Then
          Text = Title
        End If

        '*********** elminare
        Log("youtubeTopic", 0, Created, ForumId, CategoryId, Id, FirstUpper(Author), Threading.Thread.CurrentThread.GetHashCode)
        '**************

        Try  '*********** elminare


          Dim Topic As Topic = New ForumManager.Topic(ForumId, CategoryId, FirstUpper(Author), Title, Tag.KeyWords, Text, , Id, True, , "YouTube", , False, Created)
          'Topic.Save()
          Return Topic.ID


        Catch ex As Exception  '*********** elminare
          Log("youtubeErrorNewTopic", 0, Created, ForumId, CategoryId, Id, FirstUpper(Author), Threading.Thread.CurrentThread.GetHashCode, Title, Tag.KeyWords.Count, "text len=" & Len(Text), Created)
        End Try  '*********** elminare


 
      End If
      Return 0
    End Function

    Private Shared Sub Plugin_MasterPagePreRender(MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      'Verify if is homepage
      If HttpContext.Current.Request.Path.ToLower.EndsWith("/default.aspx") Then
        For Each QueryName As String In HttpContext.Current.Request.QueryString.AllKeys
          If StrComp(QueryName, "ss", CompareMethod.Text) <> 0 Then
            Exit Sub
          End If
        Next
        Static ChannelsPlayListId As New Collections.Generic.Dictionary(Of String, String)
        Dim Configuration As YouTubeChannelConfiguration
        Configuration = Plugin.LoadConfiguration()
        For Each Channel As YouTubeChannel In Configuration.YouTubeChannels
          If Channel.AddVideoPlayerOfChannelInHomePage <> YouTubeChannel.VideoPlayerPosition.None Then
            If Channel.UrlOfChannel.ToLower.StartsWith("http://www.youtube.com/user/") Then
              Dim ChannelId As String = Trim(Mid(Channel.UrlOfChannel, 29))
              If ChannelId <> "" Then
                ChannelId = Split(ChannelId, "?")(0)
                Dim PlayListId As String
                PlayListId = Nothing
                If Not ChannelsPlayListId.ContainsKey(ChannelId) Then
                  SyncLock ChannelsPlayListId
                    If Not ChannelsPlayListId.ContainsKey(ChannelId) Then
                      Dim Data As YouTubeDataPlugin = Plugin.LoadObject(GetType(YouTubeDataPlugin), MasterPage.Setting.Name)
                      For Each DataChannel As DataChannel In Data.Channels
                        If DataChannel.Id = ChannelId Then
                          PlayListId = DataChannel.PlayListId
                          Exit For
                        End If
                      Next

                      If PlayListId = "" Then
                        PlayListId = RetrivePlayListId(ChannelId)
                        For Each DataChannel As DataChannel In Data.Channels
                          If DataChannel.Id = ChannelId Then
                            DataChannel.PlayListId = PlayListId
                            Plugin.SaveObject(Data, MasterPage.Setting.Name)
                            Exit For
                          End If
                        Next
                      End If
                      ChannelsPlayListId.Add(ChannelId, PlayListId)
                    End If
                  End SyncLock
                End If
                PlayListId = ChannelsPlayListId(ChannelId)
                If PlayListId <> "" Then
                  Dim Embed As String
                  'Liquid iframe
                  Embed = "<fieldset style=""border:none""><iframe onload=""this.height=this.clientWidth/16*9"" style=""width:100%;border:none"" src=""http://www.youtube.com/embed/videoseries?list=" & PlayListId & "&amp;hl=it_IT"" ></iframe></fieldset>"
                  Select Case Channel.AddVideoPlayerOfChannelInHomePage
                    Case YouTubeChannel.VideoPlayerPosition.InTopOfContentBox
                      MasterPage.ContentPlaceHolder.Controls.AddAt(0, Literal(Embed))
                    Case YouTubeChannel.VideoPlayerPosition.InBottomOfContentBox
                      MasterPage.ContentPlaceHolder.Controls.Add(Literal(Embed))
                    Case YouTubeChannel.VideoPlayerPosition.InBottomOfPage
                      MasterPage.Bottom.Controls.AddAt(0, Literal(Embed))
                  End Select
                End If
              End If
            End If
          End If
        Next
      End If
    End Sub

    Private Shared Sub Plugin_OnEnabledStatusChanged(SubSite As SubSite, Enabled As Boolean) Handles Plugin.OnEnabledStatusChanged
      If Enabled Then
        RunLoadSource(SubSite)
      End If
    End Sub
  End Class

End Namespace