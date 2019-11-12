'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Xml

Namespace WebApplication
	Public Module TrackBack

		Private Sub PageLoad()
			With HttpContext.Current
				'Put user code to initialize the page here
				Try
					.Response.Clear()
					.Response.ContentType = "text/xml"
					'now make sure they are referencing some article id.
					If .Request.Params("id") <> "" Then
            Dim title As String = Nothing
            Dim excerpt As String = Nothing
            Dim url As String = Nothing
						Dim blog_name As String
						If Not .Request.Params("title") Is Nothing Then
							title = .Request.Params("title").ToString
						End If
						If Not .Request.Params("excerpt") Is Nothing Then
							excerpt = .Request.Params("excerpt").ToString
						End If
						If Not .Request.Params("url") Is Nothing Then
							Dim aurl As String()
							'what comes back in the url field is an array with two elements:
							'the first element is the requesting url of the external site,
							'this is what we need in order to verify the link.
							aurl = Split(.Request.Params("url"), ",")
							url = aurl(0)
						End If
						If Not .Request.Params("blog_name") Is Nothing Then
							blog_name = .Request.Params("blog_name").ToString
						End If
						If .Request.HttpMethod = "POST" Then
							Dim id As String = CType(.Request.Params("id"), Integer)
							'since this is a dynamically generated article, we need the id of the page
							'in order to generate a link to check.
							Dim targetPage As String = GenerateLink(id)
              If Len(url) > 0 Then
                'first make sure there is an article for this id. 
                'We'll make a call to another class.
                Dim tmpTitle As String = CheckForURL(url, targetPage, title)
                If tmpTitle <> "0" Then
                  'create the comment
                Else
                  TrackbackResponse(2, "Sorry couldn't find a " & _
                     "relevant link for " & targetPage & " in " & url)
                End If
              End If
						Else
              Dim articleTitle As String = Nothing
              Dim articleURL As String = Nothing
							Dim w As XmlTextWriter = New XmlTextWriter(.Response.Output)
							w.Formatting = Formatting.Indented
							w.WriteStartDocument()
							w.WriteStartElement("response")
							w.WriteElementString("error", "0")
							w.WriteStartElement("rss")
							w.WriteAttributeString("version", "0.91")
							w.WriteStartElement("channel")
							w.WriteElementString("title", articleTitle)
							w.WriteElementString("link", articleURL)
							w.WriteElementString("description", "")
							w.WriteElementString("language", "en-us")
							w.WriteEndElement()
							w.WriteEndElement()
							w.WriteEndElement()
							w.WriteEndDocument()
						End If
					Else
						TrackbackResponse(1, "EntryID is invalid or missing")
					End If
				Catch ex As Exception
					'handle the error.
				End Try
			End With
		End Sub

		Private Sub TrackbackResponse(ByVal errNum As Integer, ByVal errText As String)
			With HttpContext.Current
				Try
					Dim d As New XmlDocument
					Dim root As XmlElement = d.CreateElement("response")
					d.AppendChild(root)
					Dim er As XmlElement = d.CreateElement("error")
					root.AppendChild(er)
					er.AppendChild(d.CreateTextNode(errNum.ToString))
					If errText <> "" Then
						Dim msg As XmlElement = d.CreateElement("message")
						root.AppendChild(msg)
						msg.AppendChild(d.CreateTextNode(errText))
					End If
					d.Save(.Response.Output)
					.Response.End()
        Catch ex As Exception
        End Try
			End With
		End Sub


		Public Function CheckForURL(ByVal sURI As String, _
			ByVal tURI As String, ByVal pageTitle As String) As String
			Try
				Dim page As String = ReadHtmlFromWeb(sURI)
				If (page.Trim = "") Or (page.IndexOf(tURI) < 0) Then
					Return "0"
				Else
					Dim pat As String = "<head.*?>.*<title.*?>(.*)</title.*?>.*</head.*?>"
					Dim reg As Regex = New Regex(pat, RegexOptions.IgnoreCase)
					Dim m As Match = reg.Match(page)
					If m.Success Then
						pageTitle = m.Result("$1")
						Return pageTitle
					End If
				End If
			Catch ex As Exception
				Return "0"
			End Try
			Return pageTitle
		End Function

		Function GenerateLink(ByVal ID As String) As String
			'GenerateLink - accepts an id of the primary key of the article in the database. This method will return a friendly URL of the dynamically generated article on our site. We will not cover this method in this article since systems may use various methods of generating links.
      Return Nothing
    End Function

	End Module
End Namespace

