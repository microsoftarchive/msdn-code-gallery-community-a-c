'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Namespace WebApplication
	Public Module VideoManager
		Function ExtrapolateVideoID(ByVal Url As String) As String
			Url = Trim(Url)
			If InStr(Url, "//") AndAlso InStr(Url, "|") Then
				Return Url
			End If

			If Url.StartsWith("http://www.ustream.tv/recorded/") Then
				Return Url
			End If

			Try
				Dim Mime As String = MimeType(Url)
				If Mime <> "" AndAlso Mime.StartsWith("video") Then
					Return Url & "|" & Mime
				End If
			Catch ex As Exception
			End Try

			If IsMediaPlayerSource(Url) Then
				'Windows media player
				Return Url
			End If

			If Url.StartsWith("http://") OrElse Url.StartsWith("https://") Then
				Try
					Dim Uri As New Uri(Url)
					Dim NameValue As NameValueCollection = HttpUtility.ParseQueryString(Uri.Query)
					Dim P As Integer
					Dim Value As String = NameValue.Get("v")
					If Value <> "" Then
						'YouTube video
						Url = Value
					Else
						Value = NameValue.Get("docid")
						If Value <> "" Then
							'Google video
							Url = Value
						Else
							Value = NameValue.Get("id")
							If Value <> "" Then
								'Libero video
								Url = Value
							Else
								P = InStr(Url, "/video/", CompareMethod.Text)
								If P Then
									'Dailymotion
									Url = Mid(Url, P + 7, 6)
								Else
									P = InStr(Url, "/vimeo.com/", CompareMethod.Text)
									If P Then
										'Vimeo
										Url = Mid(Url, P + 11)
										'Else
									End If
								End If
							End If
						End If
					End If
				Catch ex As Exception
				End Try
			End If

			Select Case Len(Url)
				Case 18, 19, 20
					'Google video
					If DepureDocid(Url) = Url Then
						Return Url
					End If
				Case 11
					'YouTube video
					Return Url
				Case 32
					'Libero video
					Return Url
				Case 6
					'Dailymotion
					Return Url
				Case 8
					'Vimeo
					Return Url
				Case Else
					Return Url
			End Select
      Return Nothing
    End Function

		Private Function IsMediaPlayerSource(ByVal Url As String) As Boolean
			Select Case FileManager.Extension(Url)
				Case "asf", "wma", "avi", "mp2", "mp3", "mpa", "mid", "midi", "rmi", "aif", "aifc", "aiff", "au", "snd", "wav", "cda", "wmv", "wm", "dvr-ms", "mpe", "mpeg", "mpg", "m1v", "vob", "mp4"
					Return True
				Case Else
					If LCase(Url).StartsWith("mms:") Then
						Return True
					End If
			End Select
      Return False
    End Function

		Function MimeType(ByVal Url As String) As String
			Dim WebRequest As System.Net.HttpWebRequest
			WebRequest = System.Net.HttpWebRequest.Create(Url)
			WebRequest.UserAgent = "Wap"
      Dim WebResponse As System.Net.WebResponse = WebRequest.GetResponse
			Return WebResponse.ContentType
		End Function

		Private Function DepureDocid(ByVal Docid As String) As String
			If Docid <> "" Then
        Dim Result As String = Nothing
				For Each C As Char In Docid.ToCharArray
					If Char.IsNumber(C) OrElse C = "-"c Then
						Result &= C
					Else
						Exit For
					End If
				Next
				Return Result
			End If
      Return Nothing
    End Function
		Function VideoObject(ByVal VideoId As String, Setting As SubSite, ByVal HttpContext As HttpContext) As Control
			'Dim Setting As SubSite = CurrentSetting()
			Dim Literal As New WebControls.Literal
			Dim Width, Height As Integer
			Width = SizeImagePreview(HttpContext)
			'Width = 600
			Height = Width / 16 * 10
			If InStr(VideoId, "//") Then

				If VideoId.StartsWith("http://www.ustream.tv/recorded/") Then
					'ustream.tv
					VideoId = Right(VideoId, 32)
					Height = Width / 16 * 9	'16/9 resolution
					'This code need a cerrection!!
					'Literal.Text = "<object type=""application/x-shockwave-flash"" style=""width: " & Width & "px; height: " & Height & "px""><param name=""allowfullscreen"" value=""true""/><param name=""allowscriptaccess"" value=""always""/><param name=""src"" value=""http://www.ustream.tv/flash/viewer.swf?vid=" & VideoId & "&amp;autoplay=false""/></object>"
				Else
					Dim UseVideoPlayer As VideoPlayer
					Dim Parts() As String = VideoId.Split("|"c)
					If UBound(Parts) > 0 Then
						VideoId = Parts(0)
						'Parts(1) is mime type
						Select Case Parts(1)
							Case "video/x-flv", "video/flash"
								UseVideoPlayer = VideoPlayer.FlashPlayer
							Case "video/mp4", "video/mpg", "video/mpeg"	', "video/x-msvideo", "video/x-ms-asf", "video/x-ms-wmv"
								UseVideoPlayer = VideoPlayer.Silverlight
							Case Else
								If Parts(1).StartsWith("video/x-ms") Then
									UseVideoPlayer = VideoPlayer.WindowsMediaPlayer
								ElseIf Parts(1).StartsWith("video/") Then
									UseVideoPlayer = VideoPlayer.Silverlight
								Else
									UseVideoPlayer = VideoPlayer.FlashPlayer
								End If
						End Select
					Else
						Select Case VideoId.ToLower.Substring(VideoId.LastIndexOf("."c) + 1)
							Case "mp4", "avi", "wmv", "mpg"
								UseVideoPlayer = VideoPlayer.Silverlight
							Case "flv", "swf"
								UseVideoPlayer = VideoPlayer.FlashPlayer
							Case Else
								If IsMediaPlayerSource(VideoId) Then
									UseVideoPlayer = VideoPlayer.WindowsMediaPlayer
								Else
									UseVideoPlayer = VideoPlayer.FlashPlayer
								End If
						End Select
					End If


					If UseVideoPlayer = VideoPlayer.Silverlight AndAlso HttpContext.Current.Request.Browser.Browser = "IE" AndAlso Val(HttpContext.Current.Items("SilverlightVideo")) > 0 Then
						'Insert no more of one silverlight video
						UseVideoPlayer = VideoPlayer.WindowsMediaPlayer
					End If

					If UseVideoPlayer = VideoPlayer.Dynsrc Then
						'Using dynsrc parameter in IE
						Literal.Text = "<img border=""0"" dynsrc=""" & VideoId & """ start=""fileopen"" loop=""infinite"" " & VideoSize(Setting, Width, Height) & """>" & _
					 "<br />" & _
					 "<embed src=""" & VideoId & """ controls=""smallconsole"" " & VideoSize(Setting, Width, Height) & """ loop=""false"" autostart=""false"">"
					ElseIf UseVideoPlayer = VideoPlayer.WindowsMediaPlayer Then
						'Using a windows media player
						Height += 102	'Perfekt value!
						Literal.Text = "<object id=""MediaPlayer"" classid=""CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6"" type=""application/x-oleobject"" " & VideoSize(Setting, Width, Height) & """>" & _
					 "<param name=""url"" value=""" & VideoId & """>" & _
					 "<param name=""AutoStart"" value=""false"">" & _
					 "<param name=""ShowControls"" value=""1"">" & _
					 "<param name=""uiMode"" value=""full"">" & _
					 "<embed type=""application/x-ms-wmp"" " & VideoSize(Setting, Width, Height) & """ src=""" & VideoId & """ filename=""" & VideoId & """ autostart=""False"" showcontrols=""True"" showstatusbar=""True"">" & _
					 "</embed> " & _
					 "</object>"
					ElseIf UseVideoPlayer = VideoPlayer.Silverlight Then
						'Using Silverlight Video Player
						HttpContext.Current.Items("SilverlightVideo") = Val(HttpContext.Current.Items("SilverlightVideo")) + 1
						Height += 51 'Perfekt value!
						Literal.Text = "<object data=""data:application/x-silverlight-2,"" type=""application/x-silverlight-2"" " & VideoSize(Setting, Width, Height) & """>" & _
				 "<param name=""source"" value=""ClientBin/VideoPlayer.xap""/>" & _
				 "<param name=""background"" value=""white"" />" & _
				 "<param name=""initParams"" value=""m=" & VideoId & """ />" & _
				 "<param name=""minruntimeversion"" value=""2.0.31005.0"" />" & _
				 "<a href=""http://go.microsoft.com/fwlink/?LinkId=124807"" style=""text-decoration: none;"">" & _
				 "<img src=""http://go.microsoft.com/fwlink/?LinkId=108181"" alt=""Get Microsoft Silverlight"" style=""border-style: none""/>" & _
				 "</a>" & _
				 "</object>"
					ElseIf UseVideoPlayer = VideoPlayer.FlashPlayer Then
						'Using flash player
						Height += 40
						'Old code

						'W3C valid html code
						Literal.Text = "<object type=""application/x-shockwave-flash""  " & VideoSize(Setting, Width, Height) & "><param name=""movie"" value=""resources/flash/FVP10.swf?video=" & HttpUtility.HtmlEncode(VideoId) & "&amp;action=stop&amp;color=ADBBC9&amp;buffer=3&amp;fsbtn=yes&amp;textcolor=000000"" /><param name=""allowFullScreen"" value=""true"" /></object>"
					End If
				End If
			Else
				Select Case Len(VideoId)
					Case 8
						'Vimeo.com
						Height = Width / 16 * 9	'16/9 resolution

						'W3C valid html code
						Literal.Text = "<object type=""application/x-shockwave-flash"" " & VideoSize(Setting, Width, Height) & "><param name=""movie"" value=""http://vimeo.com/moogaloop.swf?clip_id=" & VideoId & "&amp;server=vimeo.com&amp;color=00adef&amp;fullscreen=1"" /><param name=""allowFullScreen"" value=""true"" /></object>"
					Case 6
						'Dailymotion.com
						Height += 52

						'W3C valid html code
						Literal.Text = "<object type=""application/x-shockwave-flash"" " & VideoSize(Setting, Width, Height) & " data=""http://www.dailymotion.com/swf/video/" & VideoId & """><param name=""movie"" value=""http://www.dailymotion.com/swf/video/" & VideoId & """></param><param name=""allowFullScreen"" value=""true""></param></object>"
					Case 11
						'YouTube video 
						Height += 84

						'W3C valid html code
						Literal.Text = "<object type=""application/x-shockwave-flash"" " & VideoSize(Setting, Width, Height) & " data=""" & HttpUtility.HtmlEncode("http://www.youtube.com/v/" & VideoId & "&fs=1&rel=0") & """><param name=""allowFullScreen"" value=""true"" /><param name=""showsearch"" value=""0"" /><param name=""movie"" value=""" & HttpUtility.HtmlEncode("http://www.youtube.com/v/" & VideoId & "&fs=1&rel=0") & """ /><param name=""wmode"" value=""transparent"" /></object>"

						'http://schema.org/VideoObject
            Dim AddSourge As String = Nothing
						If IsCrawler() Then
							'https://developers.google.com/webmasters/videosearch/schema
							Dim ContentUrl As String = YouTubeVideoSource(VideoId)
							If ContentUrl IsNot Nothing Then
								AddSourge = "<meta itemprop=""contentURL"" content =""" & HttpUtility.UrlEncode(ContentUrl) & """ />"
							End If
						End If
						Literal.Text = "<span itemscope=""itemscope"" itemtype=""http://schema.org/VideoObject""><meta itemprop=""thumbnailUrl"" content =""http://img.youtube.com/vi/" & VideoId & "/2.jpg"" />" & AddSourge & Literal.Text & "</span>"
					Case 18, 19, 20
						'Google video  
						Height += 76

						'W3C valid html code
						Dim Hl As String
						If Setting.Language = LanguageManager.Language.Chinese Then
							Hl = "zh-CN"
						Else
							Hl = Acronym(Setting.Language)
						End If
						Literal.Text = "<object type=""application/x-shockwave-flash"" " & VideoSize(Setting, Width, Height) & " data=""http://video.google.com/googleplayer.swf?docId=" & VideoId & "&amp;hl=" & Hl & """><param name=""movie"" value=""http://video.google.com/googleplayer.swf?docId=" & VideoId & "&amp;hl=" & Hl & """ /></object>"
					Case 32
						'Libero video
						Height += 83

						'W3C valid html code
						Literal.Text = "<object type=""application/x-shockwave-flash"" " & VideoSize(Setting, Width, Height) & " data=""http://video.libero.it/static/swf/eltvplayer.swf?id=" & VideoId & ".flv&ap=0""><param name=""movie"" value=""http://video.libero.it/static/swf/eltvplayer.swf?id=" & VideoId & ".flv&amp;ap=0"" /></object>"
				End Select
			End If
			Dim Box As WebControl
      Select Case Setting.Aspect.SizeOfVideoEmbedded
        Case SubSite.AspectConfiguration.VideoSize.Fluid
          Box = New WebControl(HtmlTextWriterTag.Fieldset)
          Box.Style.Add("border", "none")
        Case Else
          Box = New WebControl(HtmlTextWriterTag.Span)
      End Select
      Box.Controls.Add(Literal)
      Return Box
    End Function

    Private Function VideoSize(Setting As SubSite, Width As Integer, Height As Integer) As String
      Select Case Setting.Aspect.SizeOfVideoEmbedded
        Case SubSite.AspectConfiguration.VideoSize.Fluid
          'Return "onload=""this.height=this.clientWidth/16*9"" onmouseup=""this.onload()"" style=""width:100%;border:none"""
          Return "onload=""this.height=this.clientWidth/16*9"" onmouseup=""this.onload()"" width=""800"" height=""450"" style=""width:100%;border:none"""
        Case Else
          Return "style=""width: " & Width & "px; height: " & Height & "px"""
      End Select
    End Function

		Function YouTubeVideoSource(VideoId As String) As String
			Dim Source As String = VideoId
      Dim Html As String = Nothing
			Try
				Html = ReadHtmlFromWeb("http://m.youtube.com/watch?gl=US&hl=it&client=mv-google&v=" & Source)
			Catch ex As Exception
			End Try
			If Html <> "" Then
				Dim P As Integer = Html.IndexOf("rtsp://")
				If P <> -1 Then
					Dim p2 As Integer = Html.IndexOf("""", P)
					If p2 <> -1 Then
						Return Html.Substring(P, p2 - P)
					End If
				End If
      End If
      Return Nothing
		End Function

		Private Enum VideoPlayer
			Dynsrc
			WindowsMediaPlayer
			Silverlight
			FlashPlayer
		End Enum

		Function ExtrapolateVideoIdFromGoogleRss(ByVal Feed As NewsManager.Notice) As String
			Dim Text As String = Feed.Description
			Dim Start As Integer = InStr(Text, "http://img.youtube.com/vi/")
			If Start Then
				Start += 26
				Return Mid(Text, Start, InStr(Start, Text, "/") - Start)
			End If
			Start = InStr(Text, "/googleplayer.swf?docId=")
			If Start Then
				Start += 24
				Return Mid(Text, Start, InStr(Start, Text, "&") - Start)
			End If
      Return Nothing
    End Function

		Sub AbjustFeedGoogleVideo(ByRef Feed As NewsManager.Notice)
			Dim Start As Integer = InStr(Feed.Description, "<br />") + 5
      Feed.Description = ReplaceBin(Feed.Description, "<font color=""green"">", "<font color=""#454545"">")
			Feed.Description = Mid(Feed.Description, Start)
		End Sub

	End Module

End Namespace
