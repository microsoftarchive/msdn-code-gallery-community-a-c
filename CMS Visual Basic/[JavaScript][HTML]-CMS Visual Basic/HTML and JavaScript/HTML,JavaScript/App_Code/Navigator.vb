'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports System.Net
Imports System.IO
Namespace WebApplication
	Public Module Navigator
		Function AcquiringMainTextFromWeb(ByVal Url As String, Optional ByRef BackHtml As String = Nothing, Optional ByRef BackMetaTags As MetaTags = Nothing) As WebSiteSummary
			Dim CacheDays As TimeSpan
			If Setup.Performance.DaysToKeepInCacheTheExternalPagesAcquired Then
				CacheDays = New TimeSpan(Setup.Performance.DaysToKeepInCacheTheExternalPagesAcquired, 0, 0, 0)
			End If
			BackHtml = ReadHtmlFromWeb(Url, , 10000, , CacheDays)
			Return AcquiringMainText(BackHtml, BackMetaTags)
		End Function

		Function AcquiringMainText(ByVal html As String, Optional ByRef BackMetasTags As MetaTags = Nothing) As WebSiteSummary
			Dim BackMetaTags As New MetaTags(html)
			Dim Result As New WebSiteSummary
			Result.Title = BackMetaTags.Title
			Result.Description = BackMetaTags.Description
			Result.KeyWords = BackMetaTags.KeyWords
      Dim Tag As Boolean, EndTagName As Boolean
      Dim NoInner As String = Nothing
      If Not html Is Nothing Then
        html = html.Replace(vbCrLf, " ")
        html = html.Replace(vbLf, " ")
        Dim StringBuilder As New System.Text.StringBuilder(html.Length)
        Dim Chr As Char
        Dim TagName As String = Nothing
        Dim Level As Integer
        Dim ActionLevel As AcquiringTag = AcquiringTag.Open
        Dim FlagTitle As Boolean
        Dim LevelBase As Integer
        Dim LenText As Integer
        Dim InsideBody As Boolean
        Const AspectedLen As Integer = 150

        For N As Integer = 0 To html.Length - 1
          Chr = html.Chars(N)
          'Temp &= Chr

          Select Case Chr
            Case "<"c
              Tag = True
              EndTagName = False
              TagName = ""
            Case ">"c
              Tag = False

              If TagName.StartsWith("!") Then
                ActionLevel = AcquiringTag.Neutral
              End If
              Select Case TagName
                Case "script", "style", "nav", "footer", "aside", "figcaption"
                  Select Case ActionLevel
                    Case AcquiringTag.Open
                      If NoInner Is Nothing Then
                        NoInner = TagName
                      End If
                    Case AcquiringTag.Close
                      If StrComp(NoInner, TagName) = 0 Then
                        NoInner = Nothing
                      End If
                  End Select
                Case "header", "hgroup"
                  ActionLevel = AcquiringTag.Neutral
              End Select
              Select Case ActionLevel
                Case AcquiringTag.Open
                  Level += 1
                  If StrComp(TagName, "body") = 0 Then
                    InsideBody = True
                  End If
                Case AcquiringTag.Close
                  Level -= 1
              End Select

              If InsideBody AndAlso NoInner Is Nothing Then
                If FlagTitle AndAlso Level < LevelBase AndAlso LenText >= AspectedLen Then
                  Exit For
                End If
                If TagName.StartsWith("!") Then
                  'No action for this tags (join to mother)
                Else
                  Select Case TagName
                    'No action for this tags (join to mother)
                    Case "b", "strong", "i", "u", "em", "a", "br"
                      If StrComp(TagName, "br") = 0 Then
                        StringBuilder.Append(vbLf)
                      End If
                    Case Else
                      'If Not FlagTitle OrElse (FlagTitle = True AndAlso (ActionLevel <> AcquiringTag.Open OrElse (ActionLevel = AcquiringTag.Open AndAlso Level <= LevelBase))) Then
                      'If Not FlagTitle OrElse (ActionLevel = AcquiringTag.Close OrElse Level < LevelBase) OrElse (ActionLevel <> AcquiringTag.Close OrElse Level < LevelBase) Then
                      If Not FlagTitle Then
                        If ActionLevel = AcquiringTag.Close Then
                          Dim Title As String = CleanText(HttpUtility.HtmlDecode(StringBuilder.ToString))
                          If Title.Length AndAlso Char.IsLetterOrDigit(Title(0)) Then
                            If SimilarText(ReplaceBin(Title, vbLf, ""), BackMetaTags.Title) OrElse (TagName.StartsWith("h") AndAlso Len(Title) > 40) Then
                              If TagName.StartsWith("h") = True OrElse (TagName.StartsWith("h") = False AndAlso InStr(N + Title.Length, html, Title, CompareMethod.Text) = 0) Then
                                'Select Case TagName
                                ' Case "h1", "h2"
                                FlagTitle = True
                                LevelBase = Level
                                If Len(BackMetaTags.Title) < Len(Title) Then
                                  Result.Title = BackMetaTags.Title
                                Else
                                  Result.Title = Title
                                End If
                                'End Select
                              End If
                            End If
                          End If
                        End If
                      Else
                        Dim Text As String = CleanText(HttpUtility.HtmlDecode(StringBuilder.ToString))
                        If Level <= LevelBase + 1 OrElse (Len(Text) > AspectedLen AndAlso LenText < AspectedLen) Then
                          If Len(Text) > 3 Then
                            If TagName.StartsWith("h") Then
                              Dim Spaces As Integer
                              Spaces = 0
                              For Each CheckChr As Char In Text.ToCharArray
                                If CheckChr = " "c Then
                                  Spaces += 1
                                End If
                              Next
                              If LenText > 0 OrElse Spaces > 1 Then
                                Dim Title As New WebElement(TypeWebElement.Title)
                                Title.Text = Text
                                Result.Body.Add(Title)
                                LevelBase = Level
                              End If
                            Else
                              Dim Ok As Boolean
                              Ok = False

                              If LenText >= AspectedLen Then
                                Ok = True
                              Else
                                If Len(Text) >= AspectedLen Then
                                  Ok = True
                                Else
                                  Select Case TagName
                                    Case "div", "p"
                                      Ok = True
                                  End Select
                                End If
                              End If
                              If Ok = True Then
                                If Len(Text) < AspectedLen Then
                                  'remove all uppercase text
                                  If StrComp(Text, UCase(Text)) = 0 Then
                                    Ok = False
                                    'remove copyright
                                  ElseIf InStr(Text, "©", CompareMethod.Binary) <> 0 Then
                                    Ok = False
                                    'remove buttons
                                  ElseIf TagName = "a" And Level = LevelBase Then
                                    Ok = False
                                    'remove no end with "."
                                  ElseIf Not Text.EndsWith(".") Then
                                    Ok = False
                                  End If
                                End If
                              End If

                              If Ok Then
                                Dim PrevText As String
                                Dim NoAddNewLine As Boolean = False
                                If Result.Body.Count > 0 AndAlso Result.Body(Result.Body.Count - 1).Type = TypeWebElement.Text Then
                                  PrevText = Result.Body(Result.Body.Count - 1).Text
                                  If Not PrevText.EndsWith(".") AndAlso Char.IsLetter(Text(0)) AndAlso Char.IsLower(Text(0)) Then
                                    NoAddNewLine = True
                                  End If
                                End If

                                If Not NoAddNewLine Then
                                  Dim NewText As New WebElement(TypeWebElement.Text)
                                  Result.Body.Add(NewText)
                                  Select Case ActionLevel
                                    Case AcquiringTag.Open
                                      LevelBase = Level - 2
                                    Case Else
                                      LevelBase = Level - 1
                                  End Select
                                End If

                                LenText += Len(Text)
                                Result.Body(Result.Body.Count - 1).Text &= Text
                              End If
                            End If
                          End If
                        End If
                      End If
                      StringBuilder.Remove(0, StringBuilder.Length) 'Reset string builder
                      'End If
                  End Select
                End If
              Else
                StringBuilder.Remove(0, StringBuilder.Length) 'Reset string builder
              End If
              ActionLevel = AcquiringTag.Open
            Case Else
              If Tag Then
                If EndTagName = False Then
                  If Char.IsLetterOrDigit(Chr) OrElse Chr = "!"c Then
                    TagName &= Char.ToLower(Chr)
                  ElseIf Chr <> "/" Then
                    EndTagName = True
                  End If
                End If
                If Chr = "/"c Then
                  If TagName = "" Then
                    ActionLevel = AcquiringTag.Close
                  ElseIf html.Chars(N + 1) = ">" Then
                    ActionLevel = AcquiringTag.Neutral
                  End If
                End If
              ElseIf NoInner Is Nothing Then
                StringBuilder.Append(Chr)
              End If
          End Select
        Next

        'set tag description
        If Result.Body.Count Then
          Result.Description = ShortDescriptionFromText(Result.Body(0).Text)
        End If

        'Remove last title in the end of body
        For N As Integer = Result.Body.Count - 1 To 0 Step -1
          If Result.Body(N).Type = TypeWebElement.Title Then
            Result.Body.RemoveAt(N)
          Else
            Exit For
          End If
        Next
      End If
			Return Result
		End Function

		Private Enum AcquiringTag
			Open
			Close
			Neutral
		End Enum

		Public Class RemotePageReader
			Public HTML As String
			Public Function Failure() As Boolean
				Failure = Not _Successful
			End Function
			Public Function Successful() As Boolean
				Successful = _Successful
			End Function
			Private _Successful As Boolean = False
			Function Read(ByRef Url As String) As Boolean
				Dim wc As New System.Net.WebClient
				Try
					Dim utf As New System.Text.UTF7Encoding
					HTML = utf.GetString(wc.DownloadData(Url))
					'Dim b() As Byte = utf.GetBytes("hello world") 'CONVERTE UNA STRINGA IN ARRAY DI BYTES
					_Successful = True
				Catch ex As Exception
					HTML = ""
					_Successful = False
				End Try
				Read = _Successful
			End Function
			Public Sub New(ByRef Url As String)
				Read(Url)
			End Sub
			Public Sub New()
			End Sub
		End Class

		Function ResolveUrlRedirect(ByVal Url As String, Optional ByVal Timeout As Integer = 3000, Optional ByVal UserAgent As String = "Mozilla/5.0") As String
			Dim WebRequest As System.Net.HttpWebRequest
			WebRequest = System.Net.HttpWebRequest.Create(Url)
			WebRequest.Timeout = Timeout
			WebRequest.UserAgent = UserAgent
      Dim WebResponse As System.Net.WebResponse
			WebResponse = WebRequest.GetResponse
			Return WebResponse.ResponseUri.AbsoluteUri
		End Function

		Function ReadXmlFromWeb(ByVal Url As String, Optional ByVal Timeout As Integer = 3000, Optional ByVal Headers As System.Net.WebHeaderCollection = Nothing) As System.Xml.XmlDocument
			'Read XML data source from Web
			Dim WebRequest As System.Net.WebRequest
			WebRequest = System.Net.WebRequest.Create(Url)
			WebRequest.Timeout = Timeout
			If Headers IsNot Nothing Then
				WebRequest.Headers = Headers
			End If
			Dim WebResponse As System.Net.WebResponse = WebRequest.GetResponse
      Try
        Dim Xml As New System.Xml.XmlDocument
        Xml.Load(WebResponse.GetResponseStream)
        Return Xml
      Catch ex As Exception
        'No html source! 
        Dim Bytes(WebResponse.ContentLength - 1) As Byte
        WebResponse.GetResponseStream.Read(Bytes, 0, WebResponse.ContentLength)
        Dim Txt As String = ByteArrayToString(Bytes, True)
        Err.Raise(0)
      End Try
      Return Nothing
    End Function


    Function ReadHtmlFromWeb(ByVal Url As String, Optional ByRef Encoding As System.Text.Encoding = Nothing, Optional ByVal Timeout As Integer = 10000, Optional ByVal Proxy As System.Net.WebProxy = Nothing, Optional ByVal CacheTimeSpan As TimeSpan = Nothing, Optional ByVal WebResponse As System.Net.WebResponse = Nothing, Optional ByVal UserAgent As String = "Wap") As String
      Dim Expire As Date = Now.AddMilliseconds(Timeout)
      'Dim Expire As Date = Now.AddMinutes(60) 'Good for debuggin
      If CacheTimeSpan <> TimeSpan.Zero Then
        Dim Cache As CacheReadFromWeb = LoadObject(GetType(CacheReadFromWeb), Url)
        If Cache IsNot Nothing Then
          If Recent(Cache.SaveDate, Now, CacheTimeSpan) Then
            Return Cache.Html
          End If
        End If
      End If

      Dim WebRequest As System.Net.HttpWebRequest
      WebRequest = System.Net.HttpWebRequest.Create(Url)
      'WebRequest.Headers.Add(System.Net.HttpRequestHeader.UserAgent, "GoogleBot")
      WebRequest.Timeout = Timeout
      'WebRequest.UserAgent = "Mozilla/4.0+"
      WebRequest.UserAgent = UserAgent

      If Proxy IsNot Nothing Then
        WebRequest.Proxy = Proxy
      End If
      WebResponse = WebRequest.GetResponse

      If WebResponse.ContentType <> "" Then

        If Not WebResponse.ContentType.StartsWith("text/") Then
          'is not html Data
          Err.Raise(vbObjectError, , WebResponse.ContentType)
        Else
          Dim Parts As String() = Split(WebResponse.ContentType, "=")
          If UBound(Parts) = 1 Then
            Try
              Encoding = Encoding.GetEncoding(Parts(1))
              Dim Parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(WebResponse.GetResponseStream, Encoding, True)
              Dim Text As String = Parser.ReadToEnd
              If CacheTimeSpan <> TimeSpan.Zero Then
                Try
                  SaveCacheReadFromWeb(Text, Url)
                Catch ex As Exception
                  'File name too long
                End Try
              End If
              Return Text
            Catch ex As Exception
            End Try
          End If
        End If
      End If

      Dim Result As String = Nothing

      Try
        If Encoding Is Nothing AndAlso Result Is Nothing Then
          Result = ReadHtmlFromWebAlternative(Url, WebResponse, Expire, CacheTimeSpan)
        End If
      Catch ex As Exception
      End Try

      If Result Is Nothing Then
        Encoding = System.Text.Encoding.UTF8
        Dim StreamReader As System.IO.StreamReader
        StreamReader = New System.IO.StreamReader(WebResponse.GetResponseStream(), Encoding)
        Result = StreamReader.ReadToEnd
      End If
      If CacheTimeSpan <> TimeSpan.Zero Then
        Try
          SaveCacheReadFromWeb(Result, Url)
        Catch ex As Exception
          'File name too long
        End Try
      End If
      Return Result
    End Function

    Private Function ReadHtmlFromWebAlternative(Url As String, WebResponse As System.Net.WebResponse, Expire As Date, CacheTimeSpan As TimeSpan) As String
      'This function try to read a webpage without encode indication in preambole of http request
      'This function detect encoding by meta charset info in head of html page
      Dim Encoding As System.Text.Encoding = Nothing
      Dim EncodeStr As String = Nothing
      Dim BinaryStreamReader As New System.IO.BinaryReader(WebResponse.GetResponseStream)
      Dim Bytes As Byte()
      If WebResponse.ContentLength = -1 Then
        ReDim Bytes(1024 * 1024 * 10) '10 mega
        Dim Lenght As Integer
        Dim IsTimeOut As Boolean
        Try
          Do
            Bytes(Lenght) = BinaryStreamReader.ReadByte
            Lenght += 1
            If Now >= Expire Then
              IsTimeOut = True
              Exit Do
            End If
          Loop
        Catch ex As Exception
          ReDim Preserve Bytes(Lenght)
        End Try
        BinaryStreamReader.Close()
        BinaryStreamReader.Dispose()
        If IsTimeOut Then
          Err.Raise(vbObjectError, , "Time Out")
        End If
      Else
        Bytes = BinaryStreamReader.ReadBytes(WebResponse.ContentLength)
        BinaryStreamReader.Close()
        BinaryStreamReader.Dispose()
      End If

      Dim Row As String = System.Text.Encoding.Default.GetString(Bytes)

      Dim P1 As Integer = InStr(Row, "charset=", CompareMethod.Text)
      If P1 Then
        If Row(P1 + 7) = """" Then
          P1 += 9
        Else
          P1 += 8
        End If
        Dim P2 As Integer = InStr(P1, Row, """", CompareMethod.Text)
        If P2 Then
          Try
            EncodeStr = Mid(Row, P1, P2 - P1)
            Encoding = Encoding.GetEncoding(EncodeStr) 'http://msdn.microsoft.com/library/vstudio/system.text.encoding(v=vs.100).aspx
          Catch ex As Exception
          End Try
          If Encoding IsNot Nothing Then
            Return Encoding.GetString(Bytes)
          End If
        End If
      End If

      Dim Pcod As Integer
      Dim Ncod As Integer

      'Verify if is windows-1252
      'Questo tipo di codifica può contenere anche le sequenze del "UTF-8" - quindi il detect va prima di quello dell UTF-8
      For Each Chr As Char In Row
        If Asc(Chr) >= 128 Then
          Ncod += 1
          If Ncod = 2 Then
            'Is windows-1252
            Log("ReadHtmlFromWeb", 1000, AbsoluteUri(HttpContext.Current.Request))
            Return Encoding.GetEncoding("windows-1252").GetString(Bytes)
          End If
        End If
      Next

      'Verify if is UTF-8
      Pcod = 0
      Ncod = 0
      Dim Utf8String As String = Encoding.GetEncoding("UTF-8").GetString(Bytes)
      'Verify if is UTF-8
      If Encoding Is Nothing AndAlso InStr(Row, "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML ", CompareMethod.Text) Then
        'Is UTF-8
        Log("ReadHtmlFromWeb", 1000, AbsoluteUri(HttpContext.Current.Request))
        Return Utf8String
      End If

      For Each Chr As Char In Utf8String
        If Asc(Chr) = 63 AndAlso Char.IsLetterOrDigit(Chr) Then
          Ncod += 1
          If Ncod = 2 Then
            'Is UTF-8
            Log("ReadHtmlFromWeb", 1000, AbsoluteUri(HttpContext.Current.Request))
            Return Utf8String
          End If
        End If
      Next

      'Verify if is ISO-8859-1
      Pcod = 0
      Ncod = 0
      Do
        Dim L As Integer
        Pcod = InStr(Pcod + 1, Row, "&")
        L = InStr(Pcod + 1, Row, ";") - Pcod
        If L < 7 AndAlso L > 0 Then
          Ncod += 1
          If Ncod = 2 Then
            'Is ISO-8859-1
            Log("ReadHtmlFromWeb", 1000, AbsoluteUri(HttpContext.Current.Request))
            Return Encoding.GetEncoding("ISO-8859-1").GetString(Bytes)
          End If
        End If
      Loop Until Pcod = 0
      Return Nothing
    End Function


    Public Sub CleanCacheReadFromWeb()
      Dim Dir As System.IO.DirectoryInfo = ObjectDirectoryLocation(GetType(CacheReadFromWeb))
      If Dir.Exists Then
        For Each Info As System.IO.FileInfo In Dir.GetFileSystemInfos
          If Not Recent(Info.LastAccessTimeUtc, Now.ToUniversalTime, New TimeSpan(30, 0, 0, 0)) Then
            Delete(Info.FullName)
          End If
        Next
      End If
    End Sub

		Private Sub SaveCacheReadFromWeb(ByVal Html As String, ByVal Url As String)
			Dim Cache As New CacheReadFromWeb
			Cache.Html = RemoveControlChar(Html)
			Cache.SaveDate = Now.ToUniversalTime
			SaveObject(Cache, Url)
		End Sub

		Public Class CacheReadFromWeb
			Public SaveDate As Date
			Public Html As String
		End Class

		'Function ReadFromWebProxy(ByVal Url As String, ByVal Proxy As System.Net.WebProxy) As String
		'Dim wc As New System.Net.WebClient
		'Dim Encoding As New System.Text.UTF7Encoding
		'Return Encoding.GetString(wc.DownloadData(Url))
		'End Function


		Public Class RemoteWebReader
			Sub New(Optional ByVal TimeOut As Integer = 1500)
				Me.TimeOut = TimeOut
			End Sub

			'Dim WebClient As New System.Net.WebClient
			Private WebRequest As System.Net.WebRequest
      Public TimeOut As Integer

			Function Page(ByRef Url As String, ByRef HTML As String, Optional ByVal Encoding As System.Text.Encoding = Nothing) As Boolean
				'Optional ByVal Encoding As System.Text.Encoding = System.Text.Encoding.UTF7
				Try
					WebRequest = System.Net.WebRequest.Create(Url)
					WebRequest.Timeout = TimeOut
					Dim WebResponse As System.Net.WebResponse = WebRequest.GetResponse
					If Encoding Is Nothing Then Encoding = System.Text.Encoding.UTF7

					Dim StreamReader As New System.IO.StreamReader(WebResponse.GetResponseStream, Encoding)
					HTML = StreamReader.ReadToEnd

					'Dim utf As New System.Text.UTF7Encoding
					'HTML = utf.GetString(WebClient.DownloadData(Url))

					Page = True
				Catch ex As Exception
					HTML = ""
					Page = False
				End Try
			End Function
			Function Image(ByRef Url As String, ByRef ImageObject As System.Drawing.Image) As Boolean
				Try
					'ImageObject = ImageObject.FromStream(WebClient.OpenRead(Url))
					'Image = True

					WebRequest = System.Net.WebRequest.Create(Url)
					WebRequest.Timeout = TimeOut
					Dim WebResponse As System.Net.WebResponse = WebRequest.GetResponse
					ImageObject = System.Drawing.Image.FromStream(WebResponse.GetResponseStream)
					Image = True
				Catch ex As Exception
					Image = False
				End Try
			End Function
		End Class


		Class Browser
      Public UserAgent As String = "Wap"
      Public Timeout As Integer = 10000
			Public Cookies As New System.Net.CookieContainer
			Public Referer As String

			Function Post(ByVal Url As String, ByVal FieldValueCollection As Collections.Specialized.StringDictionary) As String

				If Cookies Is Nothing Then Cookies = New CookieContainer
				Dim Encoding As New UTF8Encoding
				Dim ByteData As Byte() = Encoding.GetBytes(PostData(FieldValueCollection))

				Dim PostReq As HttpWebRequest = DirectCast(WebRequest.Create(Url), HttpWebRequest)
				PostReq.Timeout = Me.Timeout
				PostReq.Method = "POST"
				PostReq.KeepAlive = True
				PostReq.CookieContainer = Cookies
				PostReq.ContentType = "application/x-www-form-urlencoded"
				PostReq.UserAgent = UserAgent
				PostReq.Referer = Referer
				PostReq.ContentLength = ByteData.Length

				Dim PostReqStream As Stream = PostReq.GetRequestStream()
				PostReqStream.Write(ByteData, 0, ByteData.Length)
        PostReqStream.Close()
        PostReqStream.Dispose()
				Dim Response As HttpWebResponse
				Response = DirectCast(PostReq.GetResponse(), HttpWebResponse)
				Cookies.Add(Response.Cookies)
				Dim PostreqReader As New StreamReader(Response.GetResponseStream())
				Referer = Response.ResponseUri.AbsoluteUri
				Return PostreqReader.ReadToEnd
			End Function



			Function [Get](ByVal Url As String) As String
				Dim req As System.Net.HttpWebRequest
				' Then grab the content of the desired page
				req = DirectCast(System.Net.HttpWebRequest.Create(Url), System.Net.HttpWebRequest)
				req.Timeout = Me.Timeout
				req.CookieContainer = Cookies
				req.Method = "GET"
				req.ContentType = "application/x-www-form-urlencoded"
				req.UserAgent = Me.UserAgent
				req.Referer = Referer
				Dim Response As System.Net.HttpWebResponse = DirectCast(req.GetResponse(), System.Net.HttpWebResponse)
				Cookies.Add(Response.Cookies)
				Dim sr As New IO.StreamReader(Response.GetResponseStream())
				Referer = Response.ResponseUri.AbsoluteUri
				Cookies.Add(Response.Cookies)
				Return sr.ReadToEnd()
			End Function

			Private Function PostData(ByVal FieldValueCollection As Collections.Specialized.StringDictionary) As String
				Dim Result As String = ""
				If FieldValueCollection IsNot Nothing Then
					For Each Key As String In FieldValueCollection.Keys
						If Result <> "" Then
							Result &= "&"
						End If
						Result &= System.Web.HttpUtility.HtmlEncode(Key) & "=" & System.Web.HttpUtility.HtmlEncode(FieldValueCollection(Key))
					Next
				End If
				Return Result
			End Function

		End Class



	End Module
End Namespace