'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Namespace WebApplication
	Public Module Twitter

		Public Enum TwitterAction
			FriendTimeline
			Publictimeline
			Archive
			Replies
			Direct
			AuthUser
			Update
			Followers
		End Enum

    Private Function HrefXml(ByVal Action As TwitterAction) As String
      Select Case Action
        Case TwitterAction.FriendTimeline
          Return "http://twitter.com/statuses/friends_timeline/{0}.xml"
        Case TwitterAction.Publictimeline
          Return "http://twitter.com/statuses/public_timeline.xml"
        Case TwitterAction.Archive
          Return "http://twitter.com/statuses/user_timeline/{0}.xml"
        Case TwitterAction.Replies
          Return "http://twitter.com/statuses/replies.xml"
        Case TwitterAction.Direct
          Return "http://twitter.com/direct_messages.xml"
        Case TwitterAction.AuthUser
          Return "http://twitter.com/account/verify_credentials.xml"
        Case TwitterAction.Update
          Return "http://@twitter.com/statuses/update.xml"
        Case TwitterAction.Followers
          Return "http://twitter.com/statuses/followers.xml"
      End Select
      Return Nothing
    End Function


		Public Function Push(ByVal Username As String, ByVal Password As String, ByVal Action As TwitterAction, Optional ByVal Mode As Integer = 0) As String
			Dim req As WebRequest
			If Mode = 0 Then
				req = HttpWebRequest.Create(String.Format(HrefXml(Action), Username))
			Else
				req = HttpWebRequest.Create(String.Format(HrefXml(Action)))
			End If

			req.Credentials = New NetworkCredential(Username, Password)
			Try
				'returns raw xml 
				Dim res As WebResponse = req.GetResponse()
				Dim ret As StreamReader = New StreamReader(res.GetResponseStream())
				Dim retData As String = ret.ReadToEnd()
				ret.Close()
				Return retData.ToString
			Catch ex As Exception
				Return "There was an error please try again..."
			End Try
		End Function

		Public Function PostStatus(ByVal Username As String, ByVal Password As String, ByVal Status As String) As String
			Dim ret As String
			Dim req As WebRequest = HttpWebRequest.Create("http://@twitter.com/statuses/update.xml")
			System.Net.ServicePointManager.Expect100Continue = False
			req.Credentials = New NetworkCredential(Username, Password)

			req.ContentType = "application/x-www-form-urlencoded"
			req.Method = "POST"
			Dim encoding As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()
			Dim bt() As Byte = encoding.GetBytes(String.Format("status={0}", Status))

      Dim Stream As Stream
			Try
				req.ContentLength = bt.Length
        Stream = req.GetRequestStream()
        Stream.Write(bt, 0, bt.Length)
			Catch ex As Exception
				Throw ex
			End Try
      Stream.Dispose()
			Try
				'returns raw xml 
				Dim res As WebResponse = req.GetResponse()
				If res Is Nothing Then
					Return Nothing
				End If

				Dim sr As StreamReader = New StreamReader(res.GetResponseStream())
				ret = sr.ReadToEnd().Trim()
				sr.Close()
			Catch ex As Exception
				Throw ex
			End Try

			Return ret
		End Function
	End Module






End Namespace
