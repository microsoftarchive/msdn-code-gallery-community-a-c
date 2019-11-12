'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports System.Xml.Serialization

Namespace WebApplication
	Public Module FeedRSSManager

		Sub RssFeedGenerator(ByVal Stream As System.IO.Stream, ByVal rssFeed As rss)
			' Serialize RSS object to file
			Dim xml As New XmlSerializer(GetType(rss))
			Dim xmlns As New XmlSerializerNamespaces
			xmlns.Add(String.Empty, String.Empty)
			xml.Serialize(Stream, rssFeed, xmlns)
		End Sub

		Public Sub ReadFeed(ByRef Records As Collections.Generic.List(Of Notice), ByVal NewsRequire As NewsRequire, Optional ByVal UserAgent As String = "Mozilla/5.0", Optional ByVal ResolveRedirect As Boolean = False)
      Try
        Dim WebRequest As System.Net.HttpWebRequest
        WebRequest = System.Net.HttpWebRequest.Create(NewsRequire.XmlHref)
        WebRequest.Timeout = 10000
        WebRequest.UserAgent = UserAgent
        'WebResponse = WebRequest.GetResponse
        'Dim WC As New System.Net.WebClient
        'WC.Headers.Add("User-Agent", UserAgent)

        Dim myXmlDocument As New System.Xml.XmlDocument
        'myXmlDocument.Load(WC.OpenRead(NewsRequire.XmlHref))
        myXmlDocument.Load(WebRequest.GetResponse.GetResponseStream)
        Dim Node, Node2, Node3, Node4 As System.Xml.XmlNode
        For N As Integer = 0 To myXmlDocument.ChildNodes.Count - 1
          Node = myXmlDocument.ChildNodes(N)
          For N2 As Integer = 0 To Node.ChildNodes.Count - 1
            Node2 = Node.ChildNodes(N2)
            For N3 As Integer = 0 To Node2.ChildNodes.Count - 1
              Node3 = Node2.ChildNodes(N3)
              If Node3.ChildNodes.Count >= 3 Then
                'Check if is a RSS node
                Dim Fl As Integer = 0
                For N4 As Integer = 0 To Node3.ChildNodes.Count - 1
                  Select Case Node3.ChildNodes(N4).Name.ToLower
                    Case "title"
                      Fl = Fl Or 1
                    Case "description"
                      Fl = Fl Or 2
                    Case "link"
                      Fl = Fl Or 4
                  End Select
                Next
                If Fl = 7 Then
                  Dim Notice As New Notice
                  Notice.pubDate = Today
                  For N4 As Integer = 0 To Node3.ChildNodes.Count - 1
                    Node4 = Node3.ChildNodes(N4)
                    Select Case Node4.Name.ToLower
                      Case "title"
                        Notice.Title = Node4.InnerText
                      Case "link"
                        Notice.Link = Node4.InnerText
                        If ResolveRedirect Then
                          Try
                            Notice.Link = Navigator.ResolveUrlRedirect(Notice.Link)
                          Catch ex As Exception
                          End Try
                        End If
                      Case "guid" 'key
                        Notice.Guid = Node4.InnerText
                      Case "pubdate"
                        Notice.pubDate = PubDateToDate(Node4.InnerText)
                      Case "description"
                        Notice.Description = Node4.InnerText
                      Case "language"
                        If Node4.InnerText.ToLower = "en-US" Then
                          Notice.Language = LanguageManager.Language.English
                        Else
                          Notice.Language = Acronym2Enum(Node4.InnerText)
                        End If
                      Case "enclosure"
                        Node4.InnerText = Node4.InnerText
                        Try
                          If Node4.Attributes("type").Value.ToLower.StartsWith("image/") Then
                            Notice.Image = Node4.Attributes("url").Value
                          End If
                        Catch ex As Exception
                        End Try
                    End Select
                  Next
                  Notice.XmlHref = NewsRequire.XmlHref

                  'Verify if notice is required
                  If NewsRequire.AddAllRecords = True OrElse ValidForCriteria(Notice, NewsRequire.KeyWords, NewsRequire.NotKeyWords) Then
                    'Verifi if notice is a duplicate
                    Dim Duplicate As Boolean = False
                    If Records IsNot Nothing Then
                      'No save a duplicate!
                      For Each ArchivedRSS As Notice In Records
                        If ArchivedRSS.Title = Notice.Title OrElse ArchivedRSS.Description = Notice.Description OrElse ArchivedRSS.Link = Notice.Link Then
                          Duplicate = True
                          Exit For
                        End If
                      Next
                    End If
                    If Duplicate = False Then
                      'Add RSS in Notices
                      If Records Is Nothing Then
                        SyncLock Records
                          Records = New Collections.Generic.List(Of Notice)
                        End SyncLock
                      End If
                      Records.Add(Notice)
                    End If
                  End If
                End If
              End If
            Next
          Next
        Next
        SortNews(Records)
      Catch ex As Exception
        Log("ERROR RSS source", 100, NewsRequire.XmlHref, ex.Message)
        'SendEmail("ERROR: FeedRSSManager.ReadFeed", NewsRequire.XmlHref & vbCrLf & ex.ToString, Config.EmailSupervisor, True, Mail.MailFormat.Text)
      End Try
      'WC.Dispose()
    End Sub

		Public Class rss
			<XmlElementAttribute("channel")> Public channel As New rssChannel
			<XmlAttributeAttribute("version")> Public version As String = "2.0"
		End Class

		Public Class rssChannel
			Public title As String
			Public link As String
			Public description As String
			Public language As String = "en-US"
			<XmlElementAttribute("item")> Public item As New rssChannelItems
		End Class

		Public Class rssChannelItems
			Inherits CollectionBase

			Public Sub Add(ByVal Item As rssChannelItem)
				Dim I As Integer = List.Add(Item)
			End Sub

			Default Public ReadOnly Property Item(ByVal Index As Integer) As rssChannelItem
				Get
					Return CType(List.Item(Index), rssChannelItem)
				End Get
			End Property
		End Class

		Public Class rssChannelItem
			Public title As String
			Public description As String
			Public linkx As String
			Public Property link() As String
				Get
					Return guid
				End Get
				Set(ByVal value As String)
					guid = value
				End Set
			End Property
			Public guid As String
			Public pubDate As String
			'Public enclosure As enclosure
			Public enclosure As Enclosure
		End Class

		<XmlRoot("enclosure")> _
		Public Class Enclosure
			<XmlAttribute("url")> _
			Public url As String

			<XmlAttribute("length")> _
			Public length As String

			<XmlAttribute("type")> _
			Public type As String
		End Class

		Function RssButton(ByVal Href As String) As Control
			Dim RSS As New WebControls.HyperLink
			RSS.CssClass = "RSS"
			RSS.Text = "RSS"
			RSS.ToolTip = "Feed RSS"
			RSS.NavigateUrl = Href
			Return RSS
		End Function
	End Module

End Namespace
