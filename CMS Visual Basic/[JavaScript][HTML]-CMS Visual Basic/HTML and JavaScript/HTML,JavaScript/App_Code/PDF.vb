'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Option Explicit On
Option Strict On
Namespace WebApplication
	Public Module PdfManager
		'PDF File code generator

		Function PdfSupported(Language As Language) As Boolean
			Select Case Language
				Case LanguageManager.Language.Chinese, LanguageManager.Language.Russian, LanguageManager.Language.Arab
					Return False
				Case Else
					Return True
			End Select
		End Function

    Function HrefPdf(ByVal Source As SourceType, ByVal DomainConfiguration As DomainConfiguration, ByVal SubSite As String, ByVal Base As Object, ByVal Id As Integer, ByVal FileName As String) As String
      Dim NameFilePdf As New StringBuilder
      NameFilePdf.Append(HttpUtility.UrlEncode(CStr(Source)))
      NameFilePdf.Append("_")
      NameFilePdf.Append(HttpUtility.UrlEncode(ReplaceBin(CStr(Base), "/", "-"))) 'Album, ForumId
      NameFilePdf.Append("_")
      NameFilePdf.Append(HttpUtility.UrlEncode(CStr(Id)))
      NameFilePdf.Append("_")
      NameFilePdf.Append(HttpUtility.UrlEncode(Alphanumeric(FileName)))
      NameFilePdf.Append(".pdf")
      Return Href(DomainConfiguration, SubSite, False, NameFilePdf.ToString)
    End Function

    Enum SourceType
      Forum
      Photo
      Archive
    End Enum

    Public Sub BodyToPdf(ByRef clPDF As clsPDFCreator, ByVal Html As String)
      'Convert Html To Text
      Dim Tag As Boolean
      Dim FlagTagName As Boolean = True
      Dim TagName As String = Nothing
      If Not Html Is Nothing Then
        Dim Text As String = Nothing
        Dim TextPrevCtrl As String = Nothing
        Dim Chr As Char

        For N As Integer = 0 To Html.Length - 1
          Chr = Html.Chars(N)
          Select Case Chr
            Case "<"c
              HtmlControlToPdf(clPDF, Text, TagName, TextPrevCtrl)
              Tag = True
              FlagTagName = False
              TagName = ""
            Case ">"c
              Tag = False
            Case Else
              If Not Tag Then
                Text &= Chr
              ElseIf FlagTagName = False Then
                If Char.IsLetterOrDigit(Chr) Then
                  TagName &= Chr
                Else
                  FlagTagName = True
                End If
              End If
          End Select
        Next
        HtmlControlToPdf(clPDF, Text, TagName, TextPrevCtrl, True)

        'Return HttpUtility.HtmlDecode(StringBuilder.ToString)
      End If
    End Sub
    Private Sub HtmlControlToPdf(ByRef clPDF As clsPDFCreator, ByRef Text As String, ByVal TagName As String, ByRef TextBefore As String, Optional ByVal IsLast As Boolean = False)
      Text = HttpUtility.HtmlDecode(Text)
      Dim FontSize As Single
      Dim PrintNow As Boolean = True
      Dim Style As PdfManager.PdfTextType
      Select Case LCase(TagName)
        Case "h1"
          Style = PdfTextType.Bold
          FontSize = 22
        Case "h2"
          Style = PdfTextType.Bold
          FontSize = 20
        Case "h3"
          Style = PdfTextType.Bold
          FontSize = 16
        Case "h4"
          Style = PdfTextType.Bold
          FontSize = 15
        Case "h5"
          Style = PdfTextType.Bold
          FontSize = 14
        Case "h6"
          Style = PdfTextType.Bold
          FontSize = 13
        Case "li"
          FontSize = 12
          Text = " • " & Text
        Case Else
          PrintNow = False
          FontSize = 12
          TextBefore &= Text
      End Select
      If PrintNow OrElse IsLast Then
        If TextBefore IsNot Nothing Then
          AddTextToPdfDoc(clPDF, PdfTextType.DefaultText, TextBefore, 12)
          TextBefore = Nothing
        End If
        If Text IsNot Nothing Then
          AddTextToPdfDoc(clPDF, Style, Text, FontSize)
        End If
      End If
      Text = Nothing
    End Sub
    Public Function PdfDocument(Url As String) As Boolean
      'Dim Url As String = HttpContext.Current.Request.Url.AbsolutePath ' HttpContext.Current.Request.RawUrl
      If Url.EndsWith(".pdf") Then

        Dim FileName As String

        Dim FirstSeparator As Integer = Url.IndexOf("_")
        Dim Slesh As Integer = InStrRev(Url, "/", FirstSeparator) - 1
        FileName = Url.Substring(Slesh + 1)

        '===================== 25/12/2012 == compatibility old version
        If FileName.Contains("/") Then
          Dim RedirectTo = Url.Substring(0, Slesh + 1) & ReplaceBin(FileName, "/", "-")
          HttpContext.Current.Response.RedirectPermanent(RedirectTo, True)
          Return True
        End If

        '==============================================================

        FileName = HttpUtility.UrlDecode(FileName)
        Dim Params() As String = FileName.Split("_"c)
        Dim Type As PdfManager.SourceType
        Dim Base As Object
        Dim Id As Integer
        Try
          Type = CType(Params(0), SourceType)
          Base = ReplaceBin(CStr(Params(1)), "-", "/")
          Id = CInt(Params(2))

          'If UBound(BaseAndSubsite) = 1 Then
          '	SubSiteName = BaseAndSubsite(1)
          'Else
          '	SubSiteName = CurrentSubSiteName()
          'End If
        Catch ex As Exception
          Return False
          'Redirect301(Href(CurrentSetting.Name, False, "default.aspx"))
        End Try

        PdfDocument(Type, Base, Id)
        Return True
      End If
      Return False
    End Function

    Public Sub PdfDocument(ByVal Source As SourceType, ByVal Base As Object, ByVal Id As Integer)
      Dim Setting As SubSite = CurrentSetting()
      'Redirect if PDF content is disabled
      Select Case Source
        Case SourceType.Forum
          If Setting.EnablePdfVersion.TopicsOfForum = EnabledStatus.No OrElse (Setting.EnablePdfVersion.TopicsOfForum = EnabledStatus.Default AndAlso Setup.RenderingEngine.EnablePdfVersion.TopicsOfForum = False) Then
            'Redirect 
            HttpContext.Current.Response.Redirect(Href(Setting.Name, False, "forum.aspx", QueryKey.ForumId, Base, QueryKey.TopicId, Id, QueryKey.PageNumber, "1"), True)
          End If
        Case SourceType.Photo
          If Setting.EnablePdfVersion.Photos = EnabledStatus.No OrElse (Setting.EnablePdfVersion.Photos = EnabledStatus.Default AndAlso Setup.RenderingEngine.EnablePdfVersion.Photos = False) Then
            'Redirect
            HttpContext.Current.Response.Redirect(Href(Setting.Name, False, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, Base, QueryKey.ShowPhotoId, Id), True)
          End If
        Case SourceType.Archive
          If Setting.EnablePdfVersion.Pages = EnabledStatus.No OrElse (Setting.EnablePdfVersion.Pages = EnabledStatus.Default AndAlso Setup.RenderingEngine.EnablePdfVersion.Pages = False) Then
            'Redirect
            Dim Menu As Menu = Menu.Load(CInt(Base), Setting.Language)
            If Menu IsNot Nothing Then
              Dim ItemMenu = Menu.ItemsMenu.Page(Id)
              If ItemMenu IsNot Nothing Then
                HttpContext.Current.Response.Redirect(ItemMenu.Href(CurrentDomainConfiguration, Setting), True)
              End If
            End If
            RedirectToHomePage(Setting)
          End If
      End Select
      Dim Copyright = DomainName(HttpContext.Current.Request, True)
      Dim clPDF As New clsPDFCreator(Copyright, Copyright, Copyright)
      Dim Response As Web.HttpResponse = HttpContext.Current.Response
      Response.ContentType = "application/pdf"
      Dim Stream As New System.IO.MemoryStream(2000000)
      Dim Ed2kNameFile As String
      With clPDF
        Dim Host As String = PathCurrentUrl()
        Select Case Source
          Case SourceType.Forum
            Dim Topic As Topic = Topic.Load(CInt(Base), Id)
            If Topic Is Nothing Then
              HttpContext.Current.Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
            Else
              If CInt(Base) = 100 Then
                RedirectToAppropriateSubSite(User.Load(Topic.Reference), Setting)
              End If
              Ed2kNameFile = Topic.Title & " " & ReplaceBin(Topic.Keywords, ",", " ")
              Inizialize(clPDF, Stream, Topic.Title, Topic.Title, Topic.Keywords, Topic.Created)
              AddFooterToPdfDoc(clPDF, Host & ForumManager.Link(ActionType.Show, Setting.Name, , , CInt(Base), Id, , 1))
              Dim Replies As Reply() = Topic.AllReplies(CInt(Base), Id, New UserPreferences(CurrentUser).ShowCensored, EnableShowHidden)

              'Load all Photos
              For Each Reply As Reply In Replies
                If Reply.Photo <> "" Then
                  Dim Photo As Photo = Photo.Load(Reply.Photo)
                  If Photo IsNot Nothing Then
                    clPDF.LoadImg(Alphanumeric(Photo.Album & "id" & Photo.Name), Photo.Image(Setting))
                    Photo.Dispose()
                  End If
                End If
              Next

              .BeginPage()
              AddTitleToPdfDoc(clPDF, Topic.Title)
              AddSubTitleToPdfDoc(clPDF, "© " & Host & " ", &HFF)
              For Each Reply As Reply In Replies

                clPDF.Y -= 0.5!
                Dim Author As String
                If Reply.Author <> "" Then
                  Author = Reply.Author
                Else
                  Author = "?"
                End If
                AddTextToPdfDoc(clPDF, PdfTextType.Bold, Author & ":")
                If Reply.QuoteID <> 0 AndAlso Reply.TextQuote <> "" Then
                  Dim ReplyQuote As Reply = Reply.Load(CInt(Base), Id, Reply.QuoteID)
                  If ReplyQuote IsNot Nothing Then
                    Author = ReplyQuote.Author
                  Else
                    Author = ""
                  End If
                  If Author = "" Then
                    Author = "?"
                  End If
                  Dim Quote As String
                  Quote = "(" & Phrase(Setting.Language, 3072) & ") " & Author
                  Quote &= ": «"
                  Quote &= TrimCrLf(HttpUtility.HtmlDecode(Common.InnerText(Reply.TextQuote)))
                  Quote &= "»"
                  AddTextToPdfDoc(clPDF, PdfTextType.Grey, Quote)
                End If
                'Add pohoto
                If Reply.Photo <> "" Then
                  Dim Photo As Photo = Photo.Load(Reply.Photo)
                  If Photo IsNot Nothing Then
                    AddPhoto(clPDF, Photo, Setting)
                    Photo.Dispose()
                  End If
                End If
                AddTextToPdfDoc(clPDF, PdfTextType.DefaultText, "«" & TrimCrLf(HttpUtility.HtmlDecode(Common.InnerText(Reply.TextReply))) & "»" & vbLf)
              Next
              .EndPage()
            End If
          Case SourceType.Photo
            Dim Photo As Photo = PhotoManager.Photo.Load(Id, CStr(Base))
            If Photo Is Nothing Then
              HttpContext.Current.Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
            Else
              Dim AlbumLower As String = CStr(Base).ToLower
              Dim ObjAlbum As PhotoAlbum = CType(PhotoManager.PhotoAlbum.Load(CStr(Base)), PhotoAlbum)
              If ObjAlbum Is Nothing Then
                RedirectToHomePage(Setting)
              End If
              If AlbumLower.StartsWith("users") Then
                Dim Author As Authentication.User = Authentication.User.Load(ObjAlbum.Author)
                RedirectToAppropriateSubSite(Author, Setting)
              Else
                RedirectToSubSiteWithAppropriateForum(AlbumLower, Setting)
                RedirectToSubSiteWithAppropriatePhotoAlbum(AlbumLower, Setting)
              End If

              'Ed2kNameFile = Photo.Title(Setting.Language) & " " & Photo.Description(Setting.Language)

              'Dim Image As System.Drawing.Image
              'Image = Photo.Image
              Inizialize(clPDF, Stream, Photo.Title(Setting.Language), Photo.Description(Setting.Language), Photo.Title(Setting.Language), Photo.Created)

              clPDF.LoadImg(Alphanumeric(Photo.Album & "id" & Photo.Name), Photo.Image(Setting))
              AddFooterToPdfDoc(clPDF, DomainName(HttpContext.Current.Request, True))
              .BeginPage()
              AddPhoto(clPDF, Photo, Setting)
              Photo.Dispose()
              AddSubTitleToPdfDoc(clPDF, "© " & Host & " ", &HFF)
              .EndPage()
            End If
          Case SourceType.Archive
            Dim Html As String = Nothing
            Try
              Html = ReadAll(MenuManager.PageNameFile(CInt(Base), Id, Setting.Language), True)
            Catch ex As Exception
              RedirectToHomePage(Setting)
            End Try
            Dim MetaTags As New MetaTags(Html)
            Ed2kNameFile = MetaTags.Title & " " & MetaTags.Description & " " & ReplaceBin(MetaTags.KeyWords, ",", " ")

            Dim Body As String = Common.Body(Html)
            Dim Create As Date
            Try
              Create = TextToDate(MetaTags.MetaTag("date"))
            Catch ex As Exception
            End Try
            Inizialize(clPDF, Stream, MetaTags.Title, MetaTags.Description, MetaTags.KeyWords, Create)
            Dim PhotoName As String = MetaTags.MetaTag("Photo")
            Dim Photo As Photo = Nothing
            If PhotoName <> "" Then
              Photo = Photo.Load(PhotoName)
              If Photo IsNot Nothing Then
                clPDF.LoadImg(Alphanumeric(Photo.Album & "id" & Photo.Name), Photo.Image(Setting))
              End If
            End If

            AddFooterToPdfDoc(clPDF, ItemMenu.Href(Setting, Id, CInt(Base), MetaTags.Title, True))
            .BeginPage()
            AddTitleToPdfDoc(clPDF, MetaTags.Title)
            AddSubTitleToPdfDoc(clPDF, MetaTags.Description)
            AddSubTitleToPdfDoc(clPDF, "© " & Host & " ", &HFF)
            If Photo IsNot Nothing Then
              AddPhoto(clPDF, Photo, Setting)
              Photo.Dispose()
            End If

            clPDF.Y -= 0.5!
            BodyToPdf(clPDF, Body)
            .EndPage()

        End Select
        ' Chiude il documento
        .ClosePDFFile()
      End With
      clPDF = Nothing
      'If Not HttpContext.Current.Request.Browser.Crawler AndAlso StrComp(HttpContext.Current.Request.Browser.Browser, "opera", CompareMethod.Text) = 0 AndAlso Stream.Length < 9000 Then
      '	Ed2kNameFile = WordsWithSingleSpaceDelimiter(Ed2kNameFile) & ".pdf"
      '	Dim Buffer(Stream.Length - 1) As Byte
      '	Stream.Write(Buffer, 0, Stream.Length)
      '	Dim Data As String = ByteArrayToString(Buffer, True)
      '	Dim Md4 As String = hex_md4(Data)
      '	Response.Redirect("ed2k://|file|" & Ed2kNameFile & "|" & Data.Length & "|" & Md4 & "|s=" & CurrentUri() & "|/")
      'Else
      Stream.WriteTo(Response.OutputStream)
      Stream.Close()
      Stream.Dispose()
      Response.End()
    End Sub

    Private Sub AddPhoto(ByVal clPDF As clsPDFCreator, ByVal Photo As Photo, ByVal Setting As SubSite)
      AddTitleToPdfDoc(clPDF, Photo.Title(Setting.Language))
      Dim W As Integer, H As Integer
      W = 21 - (CInt(clPDF.Margin) + 3) * 2
      'Dim Image As System.Drawing.Image = Photo.Image(Setting)
      H = CInt(W * (Photo.Height / Photo.Width))

      If clPDF.Y - 0.5 - H < clPDF.Margin Then
        clPDF.EndPage()
        clPDF.BeginPage()
      Else
        clPDF.Y = clPDF.Y - 0.5!
      End If

      clPDF.DrawImg(Alphanumeric(Photo.Album & "id" & Photo.Name), (21.0! - W) / 2.0!, clPDF.Y, W, H)
      clPDF.Y = clPDF.Y - H

      If Photo.Description(Setting.Language) <> "" Then
        AddTextToPdfDoc(clPDF, PdfTextType.Italic, Photo.Description(Setting.Language))
        clPDF.Y -= 0.5!
      End If

    End Sub

    Private Sub Inizialize(ByVal clPDF As clsPDFCreator, ByVal Stream As System.IO.MemoryStream, ByVal Title As String, ByVal Subject As String, ByVal Keywords As String, ByVal Creation As Date)
      clPDF.Title = Title
      clPDF.Subject = Subject
      clPDF.Keywords = Keywords
      clPDF.Creation = Creation

      clPDF.ScaleMode = clsPDFCreator.pdfScaleMode.pdfCentimeter         ' Unità di misura
      clPDF.PaperSize = clsPDFCreator.pdfPaperSize.pdfA4           ' Formato pagina (21x29.7)
      clPDF.Margin = 1.5                 ' Margine
      clPDF.Orientation = clsPDFCreator.pdfPageOrientation.pdfPortrait         ' Orientamento

      clPDF.InitPDFFile(Stream)          ' inizializza il file
      ' Definisce le risorse relative ai font
      clPDF.LoadFont("Title", "Arial", Drawing.FontStyle.Bold)                ' Tipo TrueType
      clPDF.LoadFont("SubTitle", "Arial", Drawing.FontStyle.Bold Or Drawing.FontStyle.Italic)
      clPDF.LoadFont("Fnt1", "Arial")                ' Tipo TrueType
      clPDF.LoadFont("Bold", "Arial", Drawing.FontStyle.Bold)                ' Tipo TrueType
      clPDF.LoadFont("Italic", "Arial", Drawing.FontStyle.Italic)                ' Tipo TrueType
      clPDF.LoadFontStandard("Fnt2", "Arial", )    ' Tipo Type1
    End Sub

    Private Sub AddTitleToPdfDoc(ByVal clPDF As clsPDFCreator, ByVal Text As String)
      AddTextToPdfDoc(clPDF, PdfTextType.Bold, Text, 22)
    End Sub

    Private Sub AddSubTitleToPdfDoc(ByVal clPDF As clsPDFCreator, ByVal Text As String, Optional ByVal Color As Integer = &H0)
      AddTextToPdfDoc(clPDF, PdfTextType.Bold, Text, 20, Color)
    End Sub

    Private Enum PdfTextType
      DefaultText
      Bold
      Grey
      Italic
    End Enum

    Private Sub AddTextToPdfDoc(ByVal clPDF As clsPDFCreator, ByVal TextType As PdfTextType, ByVal Text As String, Optional ByVal FontSize As Single = 12, Optional ByVal Color As Integer = &H0)
      Dim MaxWidth As Single = 21 - clPDF.Margin * 2
      Text = ReplaceBin(Text, vbCr, "")
      Dim Lines() As String = Split(Text, vbLf)
      Dim Rows As New Collections.Specialized.StringCollection
      Dim Font As String = Nothing
      Select Case TextType
        Case PdfTextType.DefaultText
          Font = "Fnt1"
        Case PdfTextType.Bold
          Font = "Bold"
        Case PdfTextType.Italic
          Font = "Italic"
        Case PdfTextType.Grey
          Font = "Fnt1"
          Color = &H999999
      End Select
      clPDF.SetColorFill(Color)

      For Each Line As String In Lines
        For Each SubLine As String In SplitTextBySize(clPDF, Line, Font, FontSize, MaxWidth)
          If SubLine <> "" Then
            Rows.Add(SubLine)
          End If
        Next
      Next
      Dim Interline As Single = FontSize / 22

      For Each Row As String In Rows
        clPDF.Y -= Interline 'Move to next line
        If clPDF.Y < clPDF.Margin Then
          clPDF.EndPage()
          clPDF.BeginPage()
          clPDF.Y -= Interline
          clPDF.SetColorFill(Color)
        End If
        clPDF.DrawText(clPDF.Margin, clPDF.Y, Row, Font, FontSize, clsPDFCreator.pdfTextAlign.pdfAlignLeft)
      Next
    End Sub

    Function SplitTextBySize(ByVal clPDF As clsPDFCreator, ByVal Text As String, ByVal FontName As String, ByVal FontSize As Single, ByVal MaxWidth As Single) As Collections.Specialized.StringCollection
      Dim Parts As New Collections.Specialized.StringCollection
      Dim Flag As Boolean
      Dim Str As New System.Text.StringBuilder(10000)
      For Each C As Char In Text.ToCharArray
        If Char.IsLetterOrDigit(C) Then
          If Flag = True Then
            Flag = False
            Parts.Add(Str.ToString)
            Str = New System.Text.StringBuilder(10000)
          End If
        Else
          Flag = True
        End If
        Str.Append(C)
      Next
      If CBool(Str.Length) Then
        Parts.Add(Str.ToString)
      End If
      Dim Lines As New Collections.Specialized.StringCollection
      Dim Line As String = Nothing
      For Each Part As String In Parts
        If clPDF.Length(Line & Part, FontName, FontSize) >= MaxWidth Then
          Lines.Add(Line)
          Line = ""
        End If
        Line &= Part
      Next
      If CBool(Len(Line)) Then
        Lines.Add(Line)
      End If
      Return Lines
    End Function

    Private Sub AddFooterToPdfDoc(ByVal clPDF As clsPDFCreator, ByVal Text As String)
      With clPDF
        .StartObject("Footers", clsPDFCreator.pdfObjectType.pdfAllPages)
        clPDF.SetColorFill(&HFF)
        .DrawText(clPDF.Margin, 0.7, Text, "Fnt1", 8, clsPDFCreator.pdfTextAlign.pdfAlignLeft)
        .EndObject()
        .DrawObject("Footers")
      End With
    End Sub
  End Module

  Public Class clsPDFCreator
    Public X As Single, Y As Single
    Private Const PDF_VERSION As String = "%PDF-1.3"
    Private AUTOR As String
    Private CREATOR As String
    Private COPYRIGHT As String

    ' Enum
    Public Enum pdfPathOptions
      Stroked = &H1
      Closed = &H2
      Filled = &H4
      Nil = &H0
    End Enum

    Public Enum pdfColorSpace
      pdfRGB = 0
      pdfGrayScale = 1
    End Enum

    Public Enum pdfTextAlign
      pdfAlignLeft = 0
      pdfAlignRight = 1
      pdfCenter = 2
    End Enum

    Public Enum pdfPaperSize
      pdfA4 = 0
      pdfA3 = 1
      pdf85x11 = 2
      pdf85x12 = 3
      pdfUser = &HFF
    End Enum

    Public Enum pdfScaleMode
      pdf72PxInch = 0
      pdfInch = 1
      pdfMillimeter = 2
      pdfCentimeter = 3
    End Enum

    Public Enum pdfPageOrientation
      pdfPortrait = 0
      pdfLandscape = 1
    End Enum

    Public Enum pdfObjectType
      pdfNull = &H0
      pdfFirstPage = &H1
      pdfEvenPages = &H2
      pdfOddPages = &H4
      pdfNotFirstPage = &H8
      pdfAllPages = pdfEvenPages Or pdfOddPages Or pdfFirstPage
    End Enum


    'Internal Variables
    'Private mvarFileNumber  As Integer
    Private Stream As System.IO.Stream
    Private mvarTitle As String
    Private mvarSubject As String
    Private mvarKeywords As String
    Private mvarCreation As Date
    Private mvarPaperSize As pdfPaperSize
    Private mvarPageWidth As Single
    Private mvarPageHeight As Single
    Private mvarScaleMode As pdfScaleMode
    Private mvarOrientation As pdfPageOrientation
    Private mvarPages As Integer
    Private mvarMargin As Single
    Private mvarFileName As String  'Copia locale.
    Private mvarEncodeASCII85 As Boolean
    Private strPage As String
    Private strFont As String
    Private strFontname As String
    Private strImg As String
    Private strObject As String
    Private strObjectForPage As String
    Private intResource As Integer
    Private intPages As Integer
    Private intObject As Integer
    Private intMaxObject As Integer
    Private intOffsetTemp As Integer
    Private intUsedFont As Integer

    Private mvarCharSpacing As Single
    Private mvarWordSpacing As Single
    Private mvarTextScaling As Single

    Private Class FontDescriptor
      Public BaseFont As String
      Public FirstChar As Byte
      Public LastChar As Byte
      Public Param As String
      Public Widths(255) As Integer
      Public MissingWidth As Integer
    End Class

    Private Class ObjDescriptor
      Public Name As String
      Public Options As pdfObjectType
    End Class

    'Data Arrays
    Private arrXREF() As String
    Private arrOBJECT() As ObjDescriptor
    Private arrFONT() As FontDescriptor

    Public Sub New(Optional ByVal Author As String = Nothing, Optional ByVal Creator As String = Nothing, Optional ByVal Copyright As String = Nothing)
      Me.AUTOR = Author
      Me.CREATOR = Creator
      Me.COPYRIGHT = Copyright
      mvarEncodeASCII85 = False
      Title = "(senza titolo)"
      mvarScaleMode = pdfScaleMode.pdf72PxInch
      PaperSize = pdfPaperSize.pdfA4
      mvarOrientation = pdfPageOrientation.pdfPortrait
      mvarMargin = 0
      mvarPages = 0
      intUsedFont = 0
    End Sub

    Public WriteOnly Property EncodeASCII85() As Boolean
      Set(ByVal vData As Boolean)
        mvarEncodeASCII85 = vData
      End Set
    End Property

    Private MyMargin As Single
    Public Property Margin() As Single
      Set(ByVal Value As Single)
        'mvarMargin = ToSpace(vData)
        MyMargin = Value
        Y = 29.7! - MyMargin '(A4 - Margin)
      End Set
      Get
        Return MyMargin
      End Get
    End Property

    Public WriteOnly Property PaperWidth() As Single
      Set(ByVal vData As Single)
        If mvarPaperSize <> pdfPaperSize.pdfUser Then mvarPaperSize = pdfPaperSize.pdfUser
        mvarPageWidth = ToSpace(vData)
      End Set
    End Property

    Public WriteOnly Property PaperHeight() As Single
      Set(ByVal vData As Single)
        If mvarPaperSize <> pdfPaperSize.pdfUser Then mvarPaperSize = pdfPaperSize.pdfUser
        mvarPageHeight = ToSpace(vData)
      End Set
    End Property

    Public ReadOnly Property Pages() As Integer
      Get
        Pages = mvarPages
      End Get
    End Property

    Public WriteOnly Property ScaleMode() As pdfScaleMode
      Set(ByVal New_ScaleMode As pdfScaleMode)
        mvarScaleMode = New_ScaleMode
      End Set
    End Property

    Public WriteOnly Property PaperSize() As pdfPaperSize
      Set(ByVal New_PaperSize As pdfPaperSize)
        mvarPaperSize = New_PaperSize

        Select Case mvarPaperSize
          Case pdfPaperSize.pdf85x12         'Letter, 8 1/2 x 12 in.
            mvarPageWidth = 612
            mvarPageHeight = 864

          Case pdfPaperSize.pdf85x11         'Letter, 8 1/2 x 11 in.
            mvarPageWidth = 612
            mvarPageHeight = 792

          Case pdfPaperSize.pdfA3        'A3, 297 x 420 mm
            mvarPageWidth = 842
            mvarPageHeight = 1190.5

          Case pdfPaperSize.pdfA4        'A4, 210 x 297 mm
            mvarPageWidth = 595.2
            mvarPageHeight = 842

          Case pdfPaperSize.pdfUser        'User-defined

        End Select
      End Set
    End Property

    Public WriteOnly Property Orientation() As pdfPageOrientation
      Set(ByVal NewOrientation As pdfPageOrientation)
        mvarOrientation = NewOrientation
      End Set
    End Property

    Public WriteOnly Property Title() As String
      Set(ByVal New_Title As String)
        mvarTitle = New_Title
      End Set
    End Property

    Public WriteOnly Property Subject() As String
      Set(ByVal New_Subject As String)
        mvarSubject = New_Subject
      End Set
    End Property

    Public WriteOnly Property Keywords() As String
      Set(ByVal New_Keywords As String)
        mvarKeywords = New_Keywords
      End Set
    End Property

    Public WriteOnly Property Creation() As Date
      Set(ByVal New_Creation As Date)
        mvarCreation = New_Creation
      End Set
    End Property

    Public Sub InitPDFFile(Optional ByVal Stream As System.IO.Stream = Nothing)

      If Me.Stream IsNot Nothing Then Stream.Flush() : Stream.Dispose()
      Me.Stream = Stream

      WriteObj(PDF_VERSION)

      ' inizializza gli oggetti
      intMaxObject = 0

      ' 1 Attribute
      InitObj(1)
      WriteObj("<<" & vbCrLf & _
       "/Title (" & ToPdfStr(mvarTitle) & ")" & vbCrLf & _
       "/Subject (" & ToPdfStr(mvarSubject) & ")" & vbCrLf & _
       "/Keywords (" & ToPdfStr(mvarKeywords) & ")" & vbCrLf & _
       "/Author (" & ToPdfStr(AUTOR) & ")" & vbCrLf & _
       "/Creator  (" & ToPdfStr(CREATOR) & ")" & vbCrLf & _
       "/Producer (" & ToPdfStr(COPYRIGHT) & ")" & vbCrLf & _
       "/CreationDate (D:" & Format(mvarCreation, "yyyymmddhhmmss") & "+01'00')" & vbCrLf & _
       ">>")
      EndObj()

      ' 2 Catalog
      InitObj(2)
      WriteObj("<<" & vbCrLf & _
       "/Type /Catalog" & vbCrLf & _
       "/Pages 3 0 R" & vbCrLf & _
       "/PageLayout /OneColumn" & vbCrLf & _
       "/PageMode /UseNone" & vbCrLf & _
       "/Lang (it) " & vbCrLf & _
       "/ViewerPreferences << /HideToolbar false " & _
       "/DisplayDocTitle true " & _
       "/HideWindowUI false >>" & vbCrLf & _
       ">>")
      EndObj()

      ' Lascia spazio per gli oggetti 3, 4
      intMaxObject = 4

    End Sub

    Public Sub ClosePDFFile()
      Dim i As Integer
      Dim intTemp As Integer

      ' 4 Resource
      intResource = InitObj(4)
      WriteObj("<<" & vbCrLf & _
       IfStr(strFont <> "", "/Font <<" & vbCrLf & strFont & ">>" & vbCrLf, "") & _
       "/ProcSet [/PDF /Text" & IfStr(strImg <> "", " /ImageB /ImageC /ImageI", "") & " ]" & vbCrLf & _
       IfStr((strImg <> "") Or (strObject <> ""), "/XObject <<" & vbCrLf & strImg & vbCrLf & strObject & ">>" & vbCrLf, "") & _
       ">>")
      EndObj()

      ' 3 Page
      intPages = InitObj(3)
      WriteObj("<<" & vbCrLf & _
       "/Type /Pages" & vbCrLf & _
       "/Count " & mvarPages & vbCrLf & _
       "/MediaBox [0 0 " & _
        ToStr(mvarPageWidth) & " " & _
        ToStr(mvarPageHeight) & "]" & vbCrLf & _
       "/CropBox [" & ToStr(mvarMargin) & " " & _
       ToStr(mvarMargin) & " " & _
       ToStr(mvarPageWidth - mvarMargin) & " " & _
       ToStr(mvarPageHeight - mvarMargin) & "]" & vbCrLf & _
       IfStr(mvarOrientation = pdfPageOrientation.pdfLandscape, "/Rotate 90", "") & vbCrLf & _
       "/Kids [" & strPage & " ]" & vbCrLf & _
       "/Resources " & CStr(intResource) & " 0 R" & vbCrLf & _
       ">>")
      EndObj()

      'intTemp = Seek(mvarFileNumber) - 1
      intTemp = CInt(Stream.Position - 1)
      WriteObj("xref")
      WriteObj("0 " & CStr(intMaxObject + 1))
      WriteObj("0000000000 65535 f")
      For i = 1 To intMaxObject
        WriteObj(arrXREF(i))
      Next

      WriteObj("trailer" & vbCrLf & _
       "<<" & vbCrLf & _
       "/Size " & intMaxObject & vbCrLf & _
       "/Info 1 0 R" & vbCrLf & _
       "/Root 2 0 R" & vbCrLf & _
       ">>")

      WriteObj("startxref" & vbCrLf & _
       CStr(intTemp))
      Dim Bytes As Byte() = StringToByteArray("%%EOF" & vbCrLf, True)
      Stream.Write(Bytes, 0, Bytes.GetLength(0))
      'Stream.Close()
      'Print(mvarFileNumber, "%%EOF", vbCrLf)
      'FileClose(mvarFileNumber)
    End Sub

    Private Function InitObj(Optional ByVal intObj As Integer = 0) As Integer

      If intObj = 0 Then intObj = intMaxObject + 1
      If intObj > intMaxObject Then intMaxObject = intObj
      ReDim Preserve arrXREF(intMaxObject)
      arrXREF(intObj) = Right$("0000000000" & (Stream.Position - 1), 10) & " 00000 n"
      'arrXREF(intObj) = Right$("0000000000" & (Seek(mvarFileNumber) - 1), 10) & " 00000 n"
      WriteObj(CStr(intObj) & " 0 obj")
      InitObj = intObj
    End Function

    Private Sub EndObj()
      Dim Bytes As Byte() = Conversion.StringToByteArray("endobj" & vbCrLf, True)
      Stream.Write(Bytes, 0, Bytes.GetLength(0))
      'PrintLine(mvarFileNumber, "endobj")
    End Sub

    Private Sub WriteObj(ByVal strTemp As String)
      Dim Bytes As Byte() = Conversion.StringToByteArray(strTemp & vbCrLf, True)
      Stream.Write(Bytes, 0, Bytes.GetLength(0))

      'PrintLine(mvarFileNumber, strTemp)
    End Sub

    Public Function BeginPage() As Integer
      Y = CSng(29.7 - MyMargin) '(A4 - Margin)
      Dim intPage As Integer

      mvarPages = mvarPages + 1
      intPage = InitObj()
      WriteObj("<<" & vbCrLf & _
       "/Type /Page" & vbCrLf & _
       "/Parent 3 0 R" & vbCrLf & _
       "/Contents " & CStr(intPage + 1) & " 0 R" & vbCrLf & _
       ">>")
      EndObj()

      strPage = strPage & CStr(intPage) & " 0 R "

      InitObj(intPage + 1)
      WriteObj("<< /Length " & CStr(intPage + 2) & " 0 R >>" & vbCrLf & _
       "stream")
      intOffsetTemp = CInt(Stream.Position)

      ' Verifica se ci sono oggetti comuni da inserire sullo sfondo della pagina
      InsertObjectOnPage()

      mvarCharSpacing = 0
      mvarWordSpacing = 0
      mvarTextScaling = 100
      BeginPage = mvarPages
    End Function

    Public Sub EndPage()

      intOffsetTemp = CInt(Stream.Position) - intOffsetTemp
      WriteObj("endstream")
      EndObj()

      ' Scrive la lunghezza
      InitObj()
      WriteObj(CStr(intOffsetTemp))
      EndObj()
    End Sub

    Public Sub SetWordSpacing(ByVal W As Single)
      mvarWordSpacing = W
      WriteObj(ToStr(mvarWordSpacing) & " Tw")
    End Sub

    Public Sub SetCharSpacing(ByVal W As Single)
      mvarCharSpacing = W
      WriteObj(ToStr(mvarCharSpacing) & " Tc")
    End Sub

    Public Sub SetTextHorizontalScaling(ByVal W As Single)
      mvarTextScaling = W
      WriteObj(ToStr(mvarTextScaling) & " Tz")
    End Sub

    Public Sub SetTextRenderingMode(ByVal W As Single)
      If (W >= 0) And (W <= 2) Then WriteObj(ToStr(W) & " Tr")
    End Sub

    Public Sub DrawText(ByVal x As Single, ByVal y As Single, _
    ByVal strTemp As String, _
    ByVal FontName As String, ByVal Fontsize As Single, _
    Optional ByVal Align As pdfTextAlign = pdfTextAlign.pdfAlignLeft, _
    Optional ByVal Rotate As Single = 0)
      Dim PI As Single
      Dim sTeta As Single
      Dim cTeta As Single
      Dim C As Single
      Dim l As Single

      Select Case Align
        Case pdfTextAlign.pdfAlignLeft

        Case pdfTextAlign.pdfAlignRight
          l = Length(strTemp, FontName, Fontsize)
          x = x - l
        Case pdfTextAlign.pdfCenter
          l = Length(strTemp, FontName, Fontsize)
          x = x - l / 2
      End Select

      WriteObj("BT")
      WriteObj("/" & FontName & " " & ToStr(Fontsize) & " Tf")
      If Rotate <> 0 Then
        PI = Math.PI
        C = PI / 180.0F
        sTeta = CSng(Math.Sin(C * Rotate))
        cTeta = CSng(Math.Cos(C * Rotate))
        WriteObj(ToStr(cTeta) & " " & ToStr(sTeta) & " " & _
         ToStr(-sTeta) & " " & ToStr(cTeta) & _
         " " & ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " Tm")
      Else
        WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " Td")
      End If

      WriteObj("(" & ToPdfStr(strTemp) & ") Tj")
      WriteObj("ET")
    End Sub

    Public Sub SetColorStroke(ByVal rgb As Integer)
      Dim R As Integer
      Dim G As Integer
      Dim B As Integer

      If (rgb <= 0) And (rgb >= -255) Then
        WriteObj(ToStr(-rgb / 255.0!) & " G")
      Else
        R = rgb Mod 256
        G = (rgb \ 256) Mod 256
        B = (rgb \ 65536) Mod 256
        WriteObj(ToStr(R / 255.0!) & " " & ToStr(G / 255.0!) & " " & ToStr(B / 255.0!) & " RG")
      End If
    End Sub

    Public Sub SetColorFill(ByVal rgb As Integer)
      Dim R As Integer
      Dim G As Integer
      Dim B As Integer

      If (rgb <= 0) And (rgb >= -255) Then
        WriteObj(ToStr(-rgb / 255.0!) & " g")
      Else
        R = (rgb Mod 256)
        G = ((rgb \ 256) Mod 256)
        B = ((rgb \ 65536) Mod 256)
        WriteObj(ToStr(R / 255.0!) & " " & ToStr(G / 255.0!) & " " & ToStr(B / 255.0!) & " rg")
      End If
    End Sub

    Public Sub SetDash(ByVal dash_on As Single, Optional ByVal dash_off As Single = 0)
      If (dash_on = 0) And (dash_off = 0) Then
        WriteObj("[ ] 0 d")
      Else
        WriteObj("[" & ToStr(ToSpace(dash_on)) & " " & ToStr(ToSpace(dash_off)) & "] 0 d")
      End If
    End Sub

    Public Sub SetLineWidth(ByVal W As Single)
      WriteObj(ToStr(ToSpace(W)) & " w")
    End Sub

    Public Sub SetLineCap(ByVal W As Integer)
      If (W >= 0) And (W <= 2) Then WriteObj(ToStr(W) & " J")
    End Sub

    Public Sub SetLineJoin(ByVal W As Integer)
      If (W >= 0) And (W <= 2) Then WriteObj(ToStr(W) & " j")
    End Sub

    Public Sub SetMiterLimit(ByVal W As Single)
      If (W >= 1) Then WriteObj(ToStr(W) & " M")
    End Sub

    Public Sub MoveTo(ByVal x As Single, ByVal y As Single)
      WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " m")
    End Sub

    Public Sub LineTo(ByVal x As Single, ByVal y As Single, _
    Optional ByVal Options As pdfPathOptions = pdfPathOptions.Stroked)
      WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " l")
      Call Path(Options)
    End Sub

    Private Sub Path(Optional ByVal Options As pdfPathOptions = pdfPathOptions.Nil)

      If (Options And (pdfPathOptions.Filled Or pdfPathOptions.Stroked Or pdfPathOptions.Closed)) = (pdfPathOptions.Filled Or pdfPathOptions.Stroked Or pdfPathOptions.Closed) Then
        WriteObj("b")
      ElseIf (Options And (pdfPathOptions.Filled Or pdfPathOptions.Stroked)) = (pdfPathOptions.Filled Or pdfPathOptions.Stroked) Then
        WriteObj("B")
      ElseIf (Options And pdfPathOptions.Filled) = pdfPathOptions.Filled Then
        WriteObj("f")
      Else
        If (Options And pdfPathOptions.Closed) <> 0 Then WriteObj("h")
        If (Options And pdfPathOptions.Stroked) <> 0 Then WriteObj("S")
      End If

    End Sub

    Public Sub Rectangle(ByVal x As Single, ByVal y As Single, _
    ByVal xdim As Single, ByVal ydim As Single, _
    Optional ByVal Options As pdfPathOptions = pdfPathOptions.Stroked, _
    Optional ByVal Ray As Single = 0)
      Dim sR As Single

      WriteObj("n")
      If Ray > 0 Then
        If Ray > (xdim / 2) Then Ray = xdim / 2
        If Ray > (ydim / 2) Then Ray = ydim / 2
        sR = 0.55! * Ray
        MoveTo(x + Ray, y)
        LineTo(x + xdim - Ray, y, pdfPathOptions.Nil)
        Curve((x + xdim - Ray + sR), y, x + xdim, y + Ray - sR, x + xdim, y + Ray, pdfPathOptions.Nil)
        LineTo(x + xdim, y + ydim - Ray, pdfPathOptions.Nil)
        Curve(x + xdim, y + ydim - Ray + sR, x + xdim - Ray + sR, y + ydim, x + xdim - Ray, y + ydim, pdfPathOptions.Nil)
        LineTo(x + Ray, y + ydim, pdfPathOptions.Nil)
        Curve(x + Ray - sR, y + ydim, x, y + ydim - Ray + sR, x, y + ydim - Ray, pdfPathOptions.Nil)
        LineTo(x, y + Ray, pdfPathOptions.Nil)
        Curve(x, y + Ray - sR, x + Ray - sR, y, x + Ray, y, pdfPathOptions.Nil)
      Else
        WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " " & _
         ToStr(ToSpace(xdim)) & " " & ToStr(ToSpace(ydim)) & " re")
      End If

      Call Path(Options)
    End Sub

    Public Sub Curve(ByVal x1 As Single, ByVal y1 As Single, _
    ByVal X2 As Single, ByVal Y2 As Single, _
    ByVal X3 As Single, ByVal Y3 As Single, _
    Optional ByVal Options As pdfPathOptions = pdfPathOptions.Stroked)

      WriteObj(ToStr(ToSpace(x1)) & " " & ToStr(ToSpace(y1)) & " " & _
       ToStr(ToSpace(X2)) & " " & ToStr(ToSpace(Y2)) & " " & _
       ToStr(ToSpace(X3)) & " " & ToStr(ToSpace(Y3)) & " c")
      Call Path(Options)
    End Sub

    Public Sub DrawCircle(ByVal x As Single, ByVal y As Single, _
    ByVal Ray As Single, _
    Optional ByVal Options As pdfPathOptions = pdfPathOptions.Stroked)

      MoveTo(x, y - Ray)
      Curve(x + 0.55! * Ray, y - Ray, x + Ray, y - 0.55! * Ray, x + Ray, y, pdfPathOptions.Nil)
      Curve(x + Ray, y + 0.55! * Ray, x + 0.55! * Ray, y + Ray, x, y + Ray, pdfPathOptions.Nil)
      Curve(x - 0.55! * Ray, y + Ray, x - Ray, y + 0.55! * Ray, x - Ray, y, pdfPathOptions.Nil)
      Curve(x - Ray, y - 0.55! * Ray, x - 0.55! * Ray, y - Ray, x, y - Ray, pdfPathOptions.Nil)
      Call Path(Options)
    End Sub

    Public Sub Arc(ByVal x As Single, ByVal y As Single, _
    ByVal Ray As Single, _
    Optional ByVal StartAngle As Single = 0, _
    Optional ByVal EndAngle As Single = 360, _
    Optional ByVal Ratio As Single = 1, _
    Optional ByVal Pie As Boolean = False, _
    Optional ByVal Rotate As Single = 0, _
    Optional ByVal Quality As Integer = 1, _
    Optional ByVal Options As pdfPathOptions = pdfPathOptions.Stroked)

      Dim i As Single
      Dim rad As Single
      Dim PI As Single
      Dim sTeta As Single
      Dim cTeta As Single
      Dim C As Single
      Dim x1, X2 As Single
      Dim y1, Y2 As Single

      WriteObj("n")
      MoveTo(x, y)
      If (Options And pdfPathOptions.Filled) <> 0 Then Pie = True
      PI = Math.PI
      C = PI / 180
      sTeta = CSng(Math.Sin(-C * Rotate))
      cTeta = CSng(Math.Cos(-C * Rotate))

      For i = StartAngle To EndAngle Step Quality
        rad = C * i
        X2 = CSng(Ray * Math.Cos(rad))
        Y2 = CSng((Ray * Ratio) * Math.Sin(rad))

        x1 = X2 * cTeta + Y2 * sTeta
        y1 = -X2 * sTeta + Y2 * cTeta
        If (i = StartAngle) And (Not Pie) Then MoveTo(x + x1, y + y1)
        LineTo(x + x1, y + y1, pdfPathOptions.Nil)
      Next

      If Pie Then LineTo(x, y, pdfPathOptions.Nil)
      Call Path(Options)
    End Sub

    Public Function LoadImg(ByVal Name As String, ByVal Image As System.Drawing.Image, Optional ByVal ColorSpace As pdfColorSpace = pdfColorSpace.pdfRGB) As Boolean
      Dim ImgBuf() As Byte = Nothing
      Dim ImgColor() As Byte = Nothing
      Dim blnFlag As Boolean
      Dim ImgWidth As Integer
      Dim ImgHeight As Integer
      Dim ImgBPP As Byte

      blnFlag = ReadBMP(Image, ImgBuf, ImgColor, ImgWidth, ImgHeight, ImgBPP, ColorSpace)

      If blnFlag Then LoadImgFromArray(Name, ImgBuf, ImgColor, ImgWidth, ImgHeight, ImgBPP, ColorSpace)
      LoadImg = blnFlag
    End Function

    Private Function StrConv(ByVal buf() As Byte) As String
      Dim sb As New System.Text.StringBuilder
      Dim len As Integer = buf.Length - 1

      'everything here is 1-based
      For i As Integer = 1 To len
        sb.Append(ChrW(buf(i)))
      Next

      StrConv = sb.ToString()
    End Function

    Public Sub LoadImgFromArray(ByVal Name As String, _
    ByRef ImgBuf() As Byte, _
    ByRef ImgColor() As Byte, _
    ByVal ImgWidth As Integer, _
    ByVal ImgHeight As Integer, _
    ByVal ImgBPP As Byte, _
    Optional ByVal ColorSpace As pdfColorSpace = pdfColorSpace.pdfRGB)

      Dim sPixel As String
      Dim sColor As String
      Dim i As Integer

      Dim strDevice As String
      Dim BPP As Byte

      BPP = CByte(8 / ImgBPP)

      i = InitObj()
      WriteObj("<<" & vbCrLf & _
       "/Type /XObject" & vbCrLf & _
       "/Subtype /Image" & vbCrLf & _
       "/Name /" & Name & vbCrLf & _
       "/Width " & CStr(ImgWidth) & vbCrLf & _
       "/Height " & CStr(ImgHeight) & _
       IfStr(mvarEncodeASCII85, vbCrLf & "/Filter /ASCII85Decode", ""))

      strDevice = IfStr(ColorSpace = pdfColorSpace.pdfRGB, "DeviceRGB", "DeviceGray")

      Select Case ImgBPP
        Case 24
          WriteObj("/BitsPerComponent 8" & vbCrLf & _
           "/ColorSpace /" & strDevice & vbCrLf & _
           "/Length " & CStr(i + 1) & " 0 R")

        Case 8, 4, 1
          WriteObj("/BitsPerComponent " & CStr(ImgBPP) & vbCrLf & _
           "/ColorSpace [/Indexed /" & strDevice & " " & _
           CStr((2 ^ ImgBPP) - 1) & " " & CStr(i + 2) & " 0 R]" & vbCrLf & _
           "/Length " & CStr(i + 1) & " 0 R")

      End Select

      ' Now I use StrConv: thanks to Adriano Belfiore <for_program(at)yahoo(dot)it>
      If mvarEncodeASCII85 Then sPixel = ToASCII85(ImgBuf) _
      Else sPixel = StrConv(ImgBuf)

      WriteObj(">>" & vbCrLf & _
       "stream" & vbCrLf & _
       sPixel & vbCrLf & _
       "endstream")
      EndObj()

      strImg = strImg & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf

      InitObj()
      WriteObj(CStr(Len(sPixel) - IfInt(mvarEncodeASCII85, 2, 0)))
      EndObj()

      If ImgBPP <= 8 Then
        InitObj()

        sColor = IfStr(mvarEncodeASCII85, ToASCII85(ImgColor), StrConv(ImgColor))

        WriteObj("<<" & _
         IfStr(mvarEncodeASCII85, "/Filter /ASCII85Decode" & vbCrLf, "") & _
         "/Length " & CStr(Len(sColor) - IfInt(mvarEncodeASCII85, 2, 0)) & " >>" & vbCrLf & _
         "stream" & vbCrLf & _
         sColor & vbCrLf & _
         "endstream")
        EndObj()
      End If
    End Sub

    Public Sub DrawImg(ByVal Name As String, _
    ByVal DestX As Single, ByVal DestY As Single, _
    ByVal ImgWidth As Single, ByVal ImgHeight As Single)

      WriteObj("q" & vbCrLf & _
       ToStr(ToSpace(ImgWidth)) & " " & " 0 0 -" & ToStr(ToSpace(ImgHeight)) & _
       " " & ToStr(ToSpace(DestX)) & " " & ToStr(ToSpace(DestY)) & " cm" & vbCrLf & _
       "/" & Name & " Do" & vbCrLf & _
       "Q")

    End Sub

    ' Carica 1 dei 14 font base Tipo1
    Public Sub LoadFontStandard(ByVal Name As String, ByVal BaseFont As String, Optional ByVal Options As System.Drawing.FontStyle = Drawing.FontStyle.Regular)
      Dim i As Integer
      Dim sTemp As String

      BaseFont = Replace(BaseFont, " ", "")
      If Options = Drawing.FontStyle.Bold Then
        sTemp = ",Bold"
      ElseIf Options = (Drawing.FontStyle.Bold Or Drawing.FontStyle.Italic) Then
        sTemp = ",BoldItalic"
      ElseIf Options = Drawing.FontStyle.Italic Then
        sTemp = ",Italic"
      Else
        sTemp = ""
      End If

      i = InitObj()
      WriteObj("<< /Type /Font " & _
       "/Subtype /Type1 " & _
       "/Name /" & Name & " " & _
       "/BaseFont /" & BaseFont & sTemp & " " & _
       "/Encoding /WinAnsiEncoding >>")
      EndObj()
      strFont = strFont & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf
    End Sub

    ' Carica un font tipo TrueType
    Public Sub LoadFont(ByVal Name As String, ByVal BaseFont As String, Optional ByVal Options As System.Drawing.FontStyle = Drawing.FontStyle.Regular)
      Dim i As Integer
      Dim j As Integer
      Dim sTemp As String

      intUsedFont = intUsedFont + 1
      ReDim Preserve arrFONT(intUsedFont)

      arrFONT(intUsedFont) = CreateFont(BaseFont, Options)



      With arrFONT(intUsedFont)
        i = InitObj()
        WriteObj("<< /Type /Font " & vbCrLf & _
         "/Subtype /TrueType" & vbCrLf & _
         "/Name /" & Name & vbCrLf & _
         "/BaseFont /" & .BaseFont & vbCrLf & _
         "/FirstChar " & CStr(.FirstChar) & vbCrLf & _
         "/LastChar " & CStr(.LastChar) & vbCrLf & _
         "/FontDescriptor " & CStr(i + 1) & " 0 R" & vbCrLf & _
         "/Encoding /WinAnsiEncoding" & vbCrLf & _
         "/Widths [")

        sTemp = ""
        For j = .FirstChar To .LastChar
          sTemp = sTemp & ToStr(.Widths(j)) & " "
          If (((j - .FirstChar + 1) Mod 16) = 0) Or (j = .LastChar) Then
            WriteObj(sTemp)
            sTemp = ""
          End If
        Next

        WriteObj("] >>")
        EndObj()
        strFont = strFont & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf
        strFontname = strFontname & "<" & Name & ">" & Right("0000" & CStr(intUsedFont), 4) & ";"

        i = InitObj()
        WriteObj("<<" & vbCrLf & _
         "/Type /FontDescriptor" & vbCrLf & _
         "/FontName /" & .BaseFont & vbCrLf & _
         .Param & vbCrLf & _
         ">>")
        EndObj()
      End With
    End Sub


    Public Sub StartObject(ByVal Name As String, Optional ByVal Options As pdfObjectType = pdfObjectType.pdfNull)
      Dim i As Integer

      i = InitObj()
      WriteObj("<<" & vbCrLf & _
       "/Type /XObject" & vbCrLf & _
       "/Subtype /Form" & vbCrLf & _
       "/FormType 1" & vbCrLf & _
       "/Name /" & Name & vbCrLf & _
       "/BBox [" & ToStr(mvarMargin) & " " & _
       ToStr(mvarMargin) & " " & _
       ToStr(mvarPageWidth - mvarMargin) & " " & _
       ToStr(mvarPageHeight - mvarMargin) & "]" & vbCrLf & _
       "/Matrix [1 0 0 1 0 0]" & vbCrLf & _
       "/Length " & CStr(i + 1) & " 0 R >>" & vbCrLf & _
       "stream")
      intOffsetTemp = CInt(Stream.Position)

      strObject = strObject & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf

      intObject = intObject + 1
      ReDim Preserve arrOBJECT(intObject)
      arrOBJECT(intObject) = New ObjDescriptor

      With arrOBJECT(intObject)
        .Name = Name
        .Options = Options
      End With

    End Sub

    Public Sub EndObject()

      intOffsetTemp = CInt(Stream.Position) - intOffsetTemp
      WriteObj("endstream")
      EndObj()

      ' Scrive la lunghezza
      InitObj()
      WriteObj(CStr(intOffsetTemp))
      EndObj()
    End Sub

    Public Sub DrawObject(ByVal Name As String)
      WriteObj("/" & Name & " Do")
    End Sub


    ' UTILITA': Funzioni di utilita'
    Private Function ToSpace(ByVal Valore As Single) As Single

      ' Convert value to 72 pixel per inch
      Select Case mvarScaleMode

        Case pdfScaleMode.pdf72PxInch
          ToSpace = Valore

        Case pdfScaleMode.pdfInch
          ToSpace = Valore * 72

        Case pdfScaleMode.pdfCentimeter
          ToSpace = (Valore * 72) / 2.54!

        Case pdfScaleMode.pdfMillimeter
          ToSpace = (Valore * 72) / 25.4!

      End Select

    End Function

    Private Function ToUser(ByVal Valore As Single) As Single

      ' Convert value to 72 pixel per inch
      Select Case mvarScaleMode

        Case pdfScaleMode.pdf72PxInch
          ToUser = Valore

        Case pdfScaleMode.pdfInch
          ToUser = Valore / 72

        Case pdfScaleMode.pdfCentimeter
          ToUser = 2.54! * (Valore / 72)

        Case pdfScaleMode.pdfMillimeter
          ToUser = 25.4! * (Valore / 72)

      End Select

    End Function

    Private Function ToStr(ByVal Valore As Single, Optional ByVal Dec As Integer = 3) As String
      ToStr = Math.Round(Valore, Dec).ToString(Globalization.CultureInfo.InvariantCulture)
    End Function


    Public Function Length(ByVal Phrase As String, ByVal FontName As String, ByVal Fontsize As Single) As Single

      Dim k As Integer
      Dim i As Integer
      Dim C As Integer
      Dim l As Integer
      Dim j As Single
      Dim UsedFont As Integer

      k = 0
      l = CShort(Len(Phrase))
      j = 0


      k = InStr(1, strFontname, "<" & FontName & ">", vbTextCompare)
      If k > 0 Then
        k = k + Len(FontName) + 2
        UsedFont = CInt(Val(Mid(strFontname, k, 4)))

        With arrFONT(UsedFont)
          For i = 1 To l
            C = Asc(Mid(Phrase, i, 1))
            k = k + IfInt((C >= .FirstChar) And (C <= .LastChar), .Widths(C), .MissingWidth)
            If C = 32 Then j = j + 1 ' conta gli spazi
          Next
        End With
        Length = ToUser(((k * Fontsize / 1000) + (j * mvarWordSpacing) + (l * mvarCharSpacing)) * (mvarTextScaling / 100))
      End If

    End Function


    Private Function ToASCII85(ByRef InBuf() As Byte) As String

      Dim i As Byte

      Dim m As Double
      Dim q As Integer
      Dim l As Integer
      Dim k As Integer
      Dim j As Integer
      Dim lngLen As Integer

      Dim arrASCII() As Byte

      lngLen = UBound(InBuf)

      ReDim arrASCII(CInt(lngLen * 1.3) + 1)

      k = 1
      j = 1
      While k <= lngLen
        l = (lngLen - k) + 1
        m = 0

        For i = 1 To 4
          If i > l Then Exit For
          m = m + InBuf(k + i - 1) * (256 ^ (4 - i))
        Next

        If (m = 0) And (l = 4) Then
          arrASCII(j) = Asc("z")
          j = j + 1
        Else

          For i = 1 To 4
            q = CInt(m / 85 ^ (5 - i))
            m = m - q * (85 ^ (5 - i))
            arrASCII(j + i - 1) = CByte(33 + q)
          Next

          arrASCII(j + 5 - 1) = CByte(33 + m)
          j = j + IfInt(l < 4, l + 1, 5)
        End If

        k = k + 4
      End While

      ReDim Preserve arrASCII(j)

      ToASCII85 = StrConv(arrASCII) & "~>"
    End Function

    Private Function ReadBMP(ByVal Image As System.Drawing.Image, ByRef ImgBuf() As Byte, ByRef ImgColor() As Byte, ByRef ImgWidth As Integer, ByRef ImgHeight As Integer, ByRef ImgBPP As Byte, Optional ByVal ColorSpace As pdfColorSpace = pdfColorSpace.pdfRGB) As Boolean

      Const ToBitplane As Integer = 24 'Convert to 8 or 24 bitplane [change this value to set bitplane convertsion]

      Dim NewImage As System.Drawing.Image = CType(Image.Clone, Drawing.Image)  'Image Rescale
      ImageResize(NewImage, 400, True)
      Dim Bitmap As System.Drawing.Bitmap

      Dim IndexPalette() As Integer
      If ToBitplane <= 8 Then
        Dim fb As New System.IO.MemoryStream(1000000)
        NewImage.Save(fb, System.Drawing.Imaging.ImageFormat.Gif)
        Bitmap = New System.Drawing.Bitmap(fb)
        fb.Dispose()
        Dim Colors() As Drawing.Color = Bitmap.Palette.Entries
        Dim Color As Drawing.Color
        Dim IdColor As Integer = 1
        Dim Id As Integer
        ReDim IndexPalette(UBound(Colors))
        ReDim ImgColor(Colors.Length * 3)
        For Each Color In Colors
          'read palette color
          ImgColor(IdColor) = Color.R >> 1
          ImgColor(IdColor + 1) = Color.G >> 1
          ImgColor(IdColor + 2) = Color.B >> 1
          IdColor += 3
          IndexPalette(Id) = Color.ToArgb
          Id += 1
        Next

      Else
        Bitmap = New Drawing.Bitmap(NewImage)
      End If

      ReDim ImgBuf(CInt((Bitmap.Width * Bitmap.Height) * ToBitplane / 8))
      Dim P As Integer = 1
      Dim Pixel As Drawing.Color
      For y As Integer = Bitmap.Height - 1 To 0 Step -1
        For x As Integer = 0 To Bitmap.Width - 1
          If ToBitplane <= 8 Then
            Dim IdxPalette As Integer = Array.BinarySearch(IndexPalette, Bitmap.GetPixel(x, y).ToArgb)
            ImgBuf(P) = CByte(IdxPalette)
            P += 1
          Else
            Pixel = Bitmap.GetPixel(x, y)
            ImgBuf(P) = Pixel.R >> 1
            ImgBuf(P + 1) = Pixel.G >> 1
            ImgBuf(P + 2) = Pixel.B >> 1
            P += 3
          End If
        Next
      Next
      ImgWidth = Bitmap.Width
      ImgHeight = Bitmap.Height
      ImgBPP = ToBitplane
      NewImage.Dispose()
      NewImage = Nothing
      Bitmap.Dispose()
      Bitmap = Nothing
      Return True
    End Function

    Private Sub FileGet2(ByVal Stream As System.IO.Stream, ByRef Obj As Object, Optional ByVal RecordNumber As Integer = -1)
      'Emulation FileGet in Stream
      If RecordNumber <> -1 Then
        Stream.Seek(RecordNumber - 1, System.IO.SeekOrigin.Begin)
      End If

      Dim Bytes As Byte()
      If TypeOf Obj Is Array Then
        Dim Array As Array = CType(Obj, System.Array) 'unboxing
        ReDim Bytes(UBound(Array))
        Stream.Read(Bytes, 0, Bytes.Length)
        For N As Integer = 0 To UBound(CType(Obj, Array))
          Array.SetValue(Bytes(N), N)
        Next
      ElseIf TypeOf Obj Is Byte Then
        Obj = Stream.ReadByte
      ElseIf TypeOf Obj Is Integer Then
        ReDim Bytes(3)
        Stream.Read(Bytes, 0, 4)
        Obj = BitConverter.ToInt32(Bytes, 0)
      ElseIf TypeOf Obj Is Short Then
        ReDim Bytes(1)
        Stream.Read(Bytes, 0, 2)
        Obj = BitConverter.ToInt16(Bytes, 0)
      End If
    End Sub

    Private Function ToPdfStr(ByVal Temp As String) As String
      If Temp <> "" Then
        Temp = Replace(Replace(Replace(Temp, "\", "\\"), "(", "\("), ")", "\)")
        Dim TextEncode As String
        Dim Encoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Windows-1252")
        For Each C As Char In Temp
          Dim Ascii As UInt16

          'Ascii = Asc(C) 'Ascw don't work correctly with some chars
          Ascii = Encoding.GetBytes(C)(0)

          'Dim Bytes() As Byte = Encoding.GetBytes(C)
          'Select Case Bytes.Length
          'Case 1
          'Ascii = Bytes(0)
          'Case 2
          'Ascii = System.BitConverter.ToUInt16(Bytes, 0)
          'End Select


          'If Ascii >= 1040 And Ascii <= 1103 Then
          'Cyrillic
          If Not (Ascii >= 32 And Ascii <= 127) Then
            'TextEncode &= "\" & Right("000" & Oct(Ascii), IIf(Ascii > 999, 4, 3))
            TextEncode &= "\" & Oct(Ascii)
          Else
            TextEncode &= C
          End If
        Next
        Return TextEncode
      End If
    End Function

    Private Function CreateFont(ByVal FontName As String, ByVal Style As System.Drawing.FontStyle) As FontDescriptor
      Dim Font As New System.Drawing.Font(FontName, 8, Style)
      Dim imgOutput As New Drawing.Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
      Dim gr As Drawing.Graphics = Drawing.Graphics.FromImage(imgOutput)
      imgOutput.Dispose()
      Dim Size As System.Drawing.SizeF
      Dim awTemp(224) As Integer
      Dim fdTemp As New FontDescriptor
      Dim StemH, ItalicAngle As Integer
      Dim Flag As Integer
      Dim MaxWidth, Height, bx3, bx4 As Integer

      For N As Integer = 32 To 255
        Dim Id As Integer = N - 31
        Size = gr.MeasureString(Chr(N), Font, 0)
        awTemp(Id) = CInt(Size.Width - 3.55) * 91
        If awTemp(Id) = 0 Then awTemp(Id) = awTemp(2)
        If CInt((Size.Height - 3.55) * 91) > Height Then
          Height = CInt((Size.Height - 3.55) * 91)
        End If
        If awTemp(Id) > MaxWidth Then
          MaxWidth = awTemp(Id)
        End If
      Next
      gr.Dispose()
      awTemp(1) = awTemp(2) 'Set space lenght
      fdTemp.BaseFont = Replace(FontName, " ", "")
      fdTemp.FirstChar = 32
      fdTemp.LastChar = 255
      fdTemp.MissingWidth = awTemp(2)
      Dim AddToBase As String
      If CBool(Style And Drawing.FontStyle.Bold) Then
        StemH = CInt(MaxWidth / 5.96)
        Flag = Flag Or 262144
        AddToBase &= "Bold"
      Else
        StemH = CInt(MaxWidth / 10.96)
      End If
      If CBool(Style And Drawing.FontStyle.Italic) Then
        ItalicAngle = -11
        Flag = Flag Or 64
        AddToBase &= "Itlic"
      Else
        ItalicAngle = 0
      End If
      If CBool(Style And Drawing.FontStyle.Underline) Then
        AddToBase &= "Underline"
      End If
      If CBool(Style And Drawing.FontStyle.Strikeout) Then
        AddToBase &= "Strikeout"
      End If
      If AddToBase <> "" Then
        fdTemp.BaseFont &= "," & AddToBase
      End If
      If CBool(InStr(FontName, "serif", CompareMethod.Text)) Then
        Flag = Flag Or 2
      End If
      If CBool(InStr(FontName, "symbol", CompareMethod.Text)) Then
        Flag = Flag Or 4
      Else
        Flag = Flag Or 32
      End If
      bx4 = Height
      If awTemp(1) = awTemp(6) Then
        Flag = Flag Or 1
        bx3 = CInt(bx4 * 0.8!)
      Else
        bx3 = CInt(bx4 * 1.2!)
      End If

      fdTemp.Param = "/Flags " & Flag & " /FontBBox [-250 -300 " & bx3 & " " & bx4 & "] " & _
      "/MissingWidth " & fdTemp.MissingWidth & " /StemV 109 " & _
      "/StemH " & StemH & " /ItalicAngle " & ItalicAngle & "  /CapHeight " & Height & " /XHeight " & Int(Height / 2) & " " & _
      "/Ascent " & Height & " /Descent -300 /Leading 133 " & _
      "/MaxWidth " & MaxWidth & " /AvgWidth " & awTemp(3)
      For N As Integer = fdTemp.FirstChar To fdTemp.LastChar
        fdTemp.Widths(N) = awTemp(N - fdTemp.FirstChar + 1)
      Next
      Return fdTemp
    End Function

    ' Verifica se ci sono oggetti comuni da inserire sulla pagina
    Private Sub InsertObjectOnPage()
      Dim i As Integer

      If intObject > 0 Then
        For i = 1 To intObject
          With arrOBJECT(i)
            If (((.Options And pdfObjectType.pdfAllPages) = pdfObjectType.pdfAllPages) Or _
             (((.Options And pdfObjectType.pdfEvenPages) <> 0) And ((mvarPages Mod 2) = 0)) Or _
             (((.Options And pdfObjectType.pdfOddPages) <> 0) And ((mvarPages Mod 2) <> 0)) And (Not _
             (((.Options And pdfObjectType.pdfNotFirstPage) <> 0) And (mvarPages = 1)))) Then
              DrawObject(.Name)
            End If
          End With
        Next
      End If
    End Sub

    Protected Overrides Sub Finalize()
      MyBase.Finalize()
    End Sub
  End Class

End Namespace