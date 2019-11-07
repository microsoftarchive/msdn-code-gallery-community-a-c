Imports WebApplication
Partial Class domainevaluation
  Inherits System.Web.UI.Page
  Private Setting As SubSite
  Private CallFromHomePage As Boolean
  Private Action As ActionType
  Private DomainName As String

  Enum ActionType
    None
    Certificate
  End Enum

	Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
	Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , True, True)
		Return Plugin
	End Function
	Shared Sub New()
		Initialize()
	End Sub

  Protected Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
    If MasterPage.ShowTopBar Then
      Dim Setting As SubSite = MasterPage.Setting
      'Add link accommodation
      If Plugin.IsEnabledAndAccessible(MasterPage.User, Setting) Then
        'Button Domain Evaluation
        MasterPage.AddButton(Phrase(Setting.Language, 5002), Common.Href(Setting.Name, False, "domainevaluation.aspx"), , Components.IconType.Globe)
      End If
    End If
  End Sub



	Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
		If ShortDescription Then
      Return Phrase(Language, 5002)
		Else
      Return Phrase(Language, 5001)
		End If
	End Function


	Protected Sub domainevaluation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Setting = CurrentSetting()

		Action = Val(Request.QueryString("a"))
		DomainName = Request.QueryString("d")
		If Action = ActionType.Certificate Then
			ResponseCertificate()
		End If
	End Sub

	Sub ResponseCertificate()
		' create New image and bitmap objects. Load the image file and put into a resized bitmap.
		Dim Image As System.Drawing.Image
		Image = System.Drawing.Image.FromFile(MapPath(DocumentsSubDirectory & "/certificate.jpg"))
		'Add Copyright
		Dim FontSize As Integer = 18
		Dim FontName As String = "Arial Bold"
		'Dim HOffset As Integer = Image.Height / 7

		Dim g As Drawing.Graphics = Drawing.Graphics.FromImage(Image)	 ' create a New graphic object from the above bmp
		Dim Font As New Drawing.Font(FontName, FontSize, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Pixel)
		Dim FontSizeDomine As Integer = 34 / DomainName.Length * 15
		If FontSizeDomine > 34 Then
			FontSizeDomine = 34
		End If
		Dim Font2 As New Drawing.Font(FontName, FontSizeDomine, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Pixel)
		Dim Font3 As New Drawing.Font(FontName, FontSize / 1.5, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Pixel)

		Dim Brush As New Drawing.SolidBrush(Drawing.Color.Black)
		Brush.Color = Drawing.Color.FromArgb(255, Drawing.Color.Black)

		Dim Brush2 As New Drawing.SolidBrush(Drawing.Color.Red)
		Brush2.Color = Drawing.Color.FromArgb(255, Drawing.Color.Red)

		Dim Format As New System.Drawing.StringFormat
		Format.Alignment = Drawing.StringAlignment.Center

		Dim Position As New Drawing.PointF(Image.Width / 2, 46)
		g.DrawString("Certificate of attributed value", Font, Brush, Position, Format)

		Position = New Drawing.PointF(Image.Width / 2, 82)
		g.DrawString(DomainName, Font2, Brush2, Position, Format)

		Position = New Drawing.PointF(Image.Width / 2, 123)
		g.DrawString("This web domain has been estimated:", Font, Brush, Position, Format)

		Position = New Drawing.PointF(Image.Width / 2, 123 + FontSize + 4)
		Dim Evaluation As Long = EvaluationDomain(DomainName)
		If Evaluation < 0 Then
			'service not available
			Response.End()
			Exit Sub 'Threading.Thread.CurrentThread.Abort()
		End If
		g.DrawString(FormatResultEvaluation(Evaluation), Font, Brush2, Position, Format)

		Position = New Drawing.PointF(70, 202)
		Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
		g.DrawString("Authority:" & vbCrLf & CurrentDomainConfiguration.Name & " ©" & vbCrLf & "Date of issue: " & Today.ToString("dd/MMM/yyyy", Culture) & vbCrLf & "Date of expiry: " & Today.AddDays(30).ToString("dd/MMM/yyyy", Culture), Font3, Brush, Position)

		Position = New Drawing.PointF(194, 175)
		g.DrawString("Check ID:" & Chr(164) & CheckId(DomainName) & Chr(164), Font3, Brush, Position)
		g.Dispose()
		' Set the contenttype

		' send image to the viewer

		Response.ContentType = "image/jpeg"
		Dim ImageFormat As Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
		Image.Save(Response.OutputStream, ImageFormat)		' output to the user
		Image.Dispose()
		Response.End()
		Exit Sub 'Threading.Thread.CurrentThread.Abort()
	End Sub

	Function CheckId(ByVal DomainName As String) As String
		Dim Domain As Char() = DomainName.ToCharArray
		Dim Result As Long = &H8AF75280A
		For N As Integer = 0 To Domain.GetUpperBound(0) - 6
			Dim Value As Long = Val("&H" & Hex2(Domain(N)) & Hex2(Domain(N + 1)) & Hex2(Domain(N + 2)) & Hex2(Domain(N + 3)) & Hex2(Domain(N + 4)) & Hex2(Domain(N + 5)))
			Result = Result Xor Value
		Next
		Return Hex(Result)
	End Function

	Function CheckDomainName(ByRef Domain As String) As Boolean
    Dim NewDomain As String = Nothing
		For Each C As Char In Domain.ToCharArray
			If Char.IsLetterOrDigit(C) OrElse C = "." OrElse C = "-" Then
				NewDomain &= C
			End If
		Next
		Domain = LCase(NewDomain)
		If Domain IsNot Nothing Then
      If Domain.StartsWith("http://") Then
        Domain = Mid(Domain, 8)
      End If
			If Domain.StartsWith("www.") Then
				Domain = Mid(Domain, 5)
			End If
			Dim Position As Integer = InStr(Domain, "/")
			If Position Then
				Domain = Left(Domain, Position - 1)
			End If
			Dim Point1 As Integer = InStrRev(Domain, ".")
			If Point1 > 0 Then
				'Filter domain not of second level
				Dim Point2 As Integer = InStrRev(Domain, ".", Point1 - 1)
				If Point2 > 0 Then
					Domain = Mid(Domain, Point2 + 1)
				End If
			End If

			If Domain.IndexOf("/"c) <> -1 OrElse Domain.IndexOf("."c) = -1 OrElse Len(Domain) < 5 Then
				Return False
			Else
				Return True
			End If
		End If
    Return False
  End Function

	Private Function Hex2(ByVal C As Char) As String
		Return Right("00" & Hex(Asc(C)), 2)
	End Function

	Protected Sub domainevaluation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not LCase(Request.Url.LocalPath).EndsWith("/domainevaluation.aspx") Then
			CallFromHomePage = True
		End If

		Dim MasterPage As MasterPage = SetMasterPage(Me, , True, True)
		'Add CSS
		MasterPage.AddHeader(CssBigInput)
		If CallFromHomePage Then
			If Not Page.IsPostBack Then
        If Setting.Aspect.FirstDocumentInHomePage Then
          'Find ID of first page
          Dim ArchiveNumber As Integer
          Dim PageNumber As Integer = FirstDocument(Setting, ArchiveNumber)
          If PageNumber Then
            'Find Current menu
            Dim CurrentMenu As MenuManager.Menu = FindMenu(Setting, ArchiveNumber)
            'load page
            If CurrentMenu IsNot Nothing Then
              InsertPageContent(Content, MasterPage, Setting, CurrentMenu, PageNumber, True)
            End If
          End If
        End If
			End If
		Else
			MasterPage.TitleDocument = Phrase(Setting.Language, 5001)
			MasterPage.Description = Phrase(Setting.Language, 5001)
			MasterPage.KeyWords = Phrase(Setting.Language, 5001)
		End If


	End Sub

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
		If DateDiff(DateInterval.Second, Session("TimePageLoaded"), Now) < 4 Then
			'Block auto robot sublit
			Panel1.Controls.Add(Components.Message(Phrase(Setting.Language, 422, 3245), Setting, , , MessageType.ErrorAlert))
			Panel1.Visible = True
		Else
			If CheckDomainName(Domain.Text) Then
				Dim Evaluation As Long = Me.EvaluationDomain(Domain.Text)
				If Evaluation >= 0 Then
					Certificate.Visible = True
					Certificate.ImageUrl = Common.Href(Setting.Name, False, "domainevaluation.aspx", "a", ActionType.Certificate, "d", Domain.Text)
					Certificate.AlternateText = HttpUtility.HtmlEncode(Domain.Text)
				Else
					'Application error
					Panel1.Controls.Add(Components.Message(Setting, 124, , , MessageType.ErrorAlert))
					Panel1.Visible = True
				End If
			Else
				'Value not valid (domain name not valid)
				Panel1.Controls.Add(Components.Message(Setting, 400, , , MessageType.ErrorAlert))
				Panel1.Visible = True
			End If
		End If
	End Sub

  Private Shared EvaluationsEvaluation As New Collection
  Function EvaluationDomain(ByVal Domain As String) As Long
    If CheckDomainName(Domain) Then
      If EvaluationsEvaluation.Contains(Domain) Then
        Return EvaluationsEvaluation(Domain)
      Else
        Try
          Dim EvaluationSiteOld, EvaluationTrafficRanks, EvaluationDomainName As Long
          Dim Days As Integer
          EvaluationTrafficRanks = Me.EvaluationTrafficRanks(Domain, EvaluationSiteOld, Days)
          EvaluationDomainName = Me.EvaluationDomainName(Domain)
          If EvaluationDomainName > 1000 And Days < 365 Then
            EvaluationDomainName = 50
          End If
          Dim Evaluation As Long = EvaluationSiteOld + EvaluationTrafficRanks + EvaluationDomainName
          If Not EvaluationsEvaluation.Contains(Domain) Then
            EvaluationsEvaluation.Add(Evaluation, Domain)
            Extension.Log("domain_evaluation", 1000, Domain, Evaluation)
            If EvaluationsEvaluation.Count > 1000 Then
              EvaluationsEvaluation.Remove(1)
            End If
          End If
          DomainevaluationError = 0 'Reset error status
          Return Evaluation
        Catch ex As Exception
          'Application error          
					Extension.Log("SpecificError", 1000, "Domainevaluation", ex.Message, ex.Source, ex.StackTrace)
          DomainevaluationError += 1
          Return -1
        End Try
      End If
    Else
      Return -2
    End If
  End Function

  Function FormatResultEvaluation(ByVal Evaluation As Long) As String
    If Evaluation = 0 Then
      Return "ZERO EURO"
    Else
      Dim Result As String = Evaluation.ToString("#,###") & " EURO"
      Result = ReplaceBin(Result, ".", " ")
      Return ReplaceBin(Result, ",", " ")
    End If
  End Function

  Function EvaluationSiteOld(ByVal Days As Integer) As Long
    Return (Days / 130) ^ 2
  End Function

  Function DaysSiteOldFromWhois(ByVal Domain As String, Optional ByRef WhoisResult As String = Nothing) As Integer
    WhoisResult = ReadHtmlFromWeb("http://www.who.is/whois/" & Domain, System.Text.Encoding.GetEncoding("windows-1251"))
    WhoisResult = HttpUtility.HtmlDecode(WhoisResult)
    WhoisResult = WhoisResult.Replace(Chr(160), " "c)
		WhoisResult = RemoveMultipleSpace(WhoisResult)
    Dim Finds() As String = {"Created:", "Creation Date:", "Record created on"}
    Dim N, LenDate As Integer
    For Each Find As String In Finds
      Select Case N
        Case 0, 1
          LenDate = 10
        Case 2
          LenDate = 11
      End Select

      Dim Position As Integer = InStr(WhoisResult, Find, CompareMethod.Text)
      If Position Then
        Dim DateText As String = Mid(WhoisResult, Position + Len(Find) + 1, LenDate)
        Dim Created As Date
        Select Case N
          Case 0, 1
            Created = System.DateTime.ParseExact(DateText, "yyyy-MM-dd", Nothing)
          Case 2
            Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
            Created = System.DateTime.ParseExact(DateText, "dd-MMM-yyyy", Culture)
        End Select
        Return DateDiff(DateInterval.Day, Created, Today)
      End If
      N += 1
    Next
    Return 0
  End Function

  Function EvaluationDomainName(ByVal Domain As String) As Long
    Dim Extension As String = Mid(Domain, InStr(Domain, ".") + 1)
    Dim DomainName As String = Left(Domain, InStr(Domain, ".") - 1)
    Dim Meta As String = Nothing
    If Len(Extension) = 2 Then
      Meta = "&meta=lr%3Dlang_" & Extension
    End If
    Dim Url As String = "http://www.google.com/search?hl=en&safe=off&q=" & "%22" & DomainName & "%22" & Meta
		Dim Html As String = ReadHtmlFromWeb(Url, System.Text.Encoding.GetEncoding("windows-1251"), 5000)
    Dim DidYouMean As String = ">Did you mean: </font><a href="""
    Dim DidYouMeanPosition As Integer = InStr(Html, DidYouMean)
    If DidYouMeanPosition Then
      DidYouMeanPosition = InStr(DidYouMeanPosition, Html, ";q=") + 3
      Dim Text As String = Mid(Html, DidYouMeanPosition, InStr(DidYouMeanPosition + 1, Html, "&") - DidYouMeanPosition)
      Url = "http://www.google.com/search?hl=en&safe=off&q=" & Text & Meta
      Html = ReadHtmlFromWeb(Url, System.Text.Encoding.GetEncoding("windows-1251"))
    End If
    Dim OfAbout As String = "</b> of about <b>"
    Dim PositionPage As Integer = InStr(Html, OfAbout)
    If PositionPage Then
      PositionPage += Len(OfAbout)
      Dim Pages As String = Mid(Html, PositionPage, InStr(PositionPage, Html, "<") - PositionPage)
      Dim NPage As Long = ReplaceBin(Pages, ",", "")
      Dim Evaluation As Integer = NPage / 250
      Select Case Extension
        Case "aero", "arpa", "biz", "cat", "coop", "edu", "info", "int", "jobs", "mobi", "museum", "name", "net", "org", "pro", "travel"
          Evaluation = Evaluation / 4
      End Select
      Return Evaluation
    End If
    Return 0&
  End Function

  Function EvaluationTrafficRanks(ByVal Domain As String, Optional ByRef EvaluationSiteOld As Long = 0, Optional ByRef Days As Long = 0) As Long
    Dim Html As String = Nothing, TraficRank As Long
    TraficRank = AlexaTrafficRank(Domain, Html)
    Days = SiteOld(Html, Domain)
    If Days Then
      EvaluationSiteOld = Me.EvaluationSiteOld(Days)
    End If

    If TraficRank <> 0 Then
      Dim Value As Long = (500000000000 / (TraficRank + 4) ^ 1.3) - 300
      If Value < 0 Then Value = 0
      Return Value
    End If
    Return 0&
  End Function

  Function OldAlexaTrafficRank(ByVal Html As String, ByVal Url As String, ByVal Timeout As Integer) As String
    Dim HtmlBlock1 As String = HtmlBlock(Html)
    Dim Parts1 As Collections.Specialized.StringCollection = ExtrapolatePartsTrafficRank(HtmlBlock1)
    Dim String1, String2 As String
    If Parts1 IsNot Nothing Then
      Dim NTry As Integer
      Do
        Dim Html2 As String = ReadHtmlFromWeb(Url, System.Text.Encoding.GetEncoding("windows-1251"), Timeout)
        Dim HtmlBlock2 As String = HtmlBlock(Html2)
        Dim Parts2 As Collections.Specialized.StringCollection = ExtrapolatePartsTrafficRank(HtmlBlock2)

        'Depurate string collecrion of not valid values
        String2 = JoinCollection(Parts2)
        DepurateCollection(Parts1, String2)

        String1 = JoinCollection(Parts1)
        DepurateCollection(Parts2, String1)

        String2 = JoinCollection(Parts2)
        DepurateCollection(Parts1, String2)

        String1 = JoinCollection(Parts1)
        DepurateCollection(Parts2, String1)

        String2 = JoinCollection(Parts2)
        DepurateCollection(Parts1, String2)

        String1 = JoinCollection(Parts1)

        If String1 = String2 Then
          Exit Do
        ElseIf Len(String2) < Len(String1) Then
          String1 = String2
          Parts1 = Parts2
        End If
			Loop Until NTry = 10
      Return String1
    End If
    Return Nothing
  End Function

  Function SiteOld(ByVal Html As String, ByVal Domain As String) As Integer
    'Find online since date
    Dim Position As Integer = InStr(Html, "Online Since")
    If Position Then
      Position = InStr(Position - 70, Html, """data"">") + 7
      Dim Since As String = Mid(Html, Position, 11)
      Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
      Dim Created As Date
      Try
        If Since.EndsWith("</") Then
          Since = Left(Since, Since.Length - 2)
          Created = System.DateTime.ParseExact(Since, "dd-MMM-yy", Culture)
        Else
          Created = System.DateTime.ParseExact(Since, "dd-MMM-yyyy", Culture)
        End If
        Return DateDiff(DateInterval.Day, Created, Today)
      Catch ex As Exception
        Return DaysSiteOldFromWhois(domain)
      End Try
    End If
    Return 0
  End Function

  Function MinTerm(ByVal TextA As String, ByVal PartsB As Collections.Specialized.StringCollection) As String
    Dim TextB As String = JoinCollection(PartsB)
    Dim Result As String = Nothing
    For Each C As Char In TextA.ToCharArray
      If InStr(TextB, C) Then
        Result &= C
      End If
    Next
    Return Result
  End Function

  Private Sub DepurateCollection(ByRef Parts As Collections.Specialized.StringCollection, ByVal Text As String)
    'Verify if the not in correct horder
    Text = MinTerm(Text, Parts)
    For N As Integer = Parts.Count - 1 To 0 Step -1
      Dim Part As String = Parts(N)
      If Not Compatible(Text, Part) Then
        Parts.RemoveAt(N)
      End If
    Next
  End Sub

  Private Function Compatible(ByVal Text As String, ByVal Part As String) As Boolean
    Dim Position As Integer = 1
    For Each Chr As Char In Part.ToCharArray
      Position = InStr(Position, Text, Chr)
      If Position = 0 Then
        Return False
      Else
        Position += 1
      End If
    Next
    Return True
  End Function

  Private Function JoinCollection(ByVal Collection As Collections.Specialized.StringCollection) As String
    Dim Strings(Collection.Count - 1) As String
    Collection.CopyTo(Strings, 0)
    Return Join(Strings, Nothing)
  End Function

  Private Function HtmlBlock(ByVal Html As String) As String
    Dim Start As Integer = InStr(Html, "<!--Did you know?")
    If Start Then
      Dim EndPosition As Integer = InStr(Start, Html, "<!-- google_ad_section_end")
      Return Mid(Html, Start, EndPosition - Start)
    End If
    Return Nothing
  End Function

  Private Function ExtrapolatePartsTrafficRank(ByVal Html As String) As Collections.Specialized.StringCollection
    ExtrapolatePartsTrafficRank = Nothing
    Dim Tag As Boolean
    Dim L As Integer
    If Not Html Is Nothing Then
      Dim Chr As Char
      Dim Part As String = Nothing
      ExtrapolatePartsTrafficRank = New Collections.Specialized.StringCollection
      For N As Integer = 0 To Html.Length - 1
        Chr = Html.Chars(N)
        Select Case Chr
          Case "<"c
            If Part <> "" Then
              ExtrapolatePartsTrafficRank.Add(Part)
            End If
            Tag = True
          Case ">"c
            Part = ""
            Tag = False
          Case Else
            If Not Tag Then
              Part &= Chr
              L += 1
            End If
        End Select
      Next
    End If
    Return ExtrapolatePartsTrafficRank
  End Function

  Protected Sub domainevaluation_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
    Session("TimePageLoaded") = Now
  End Sub

  Protected Sub Domain_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Domain.TextChanged
    Button1_Click(sender, e)
  End Sub

End Class


