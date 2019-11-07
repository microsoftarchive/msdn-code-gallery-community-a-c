Namespace WebApplication
  Public Class ContextualLink

    Const Algorithm As Integer = 1 'Switch 0=Classic, 1=Recursive (0 is fast for short vocabolary, 1 is fast for big vocabolary but slow for very short)

    Private Shared Links As Collections.Generic.Dictionary(Of LanguageManager.Language, Link())
    Private Shared LinkFinderStructures As Collections.Generic.Dictionary(Of LanguageManager.Language, LinkFinderStructure)

    Class Link
      Public Text As String
      Public NavigateUrl As String
      Public Archive As Integer
      Public Level As Integer
      Public Category As Integer
      Public ToolTip As String
      Public Language As LanguageManager.Language
      Public Type As SubSite.CerrelatedStructure.CorrelatedStatus
      Public Sub New(ByRef Text As String, ByRef NavigateUrl As String, ByRef Archive As Integer, Optional ByRef ToolTip As String = Nothing, Optional ByRef Language As LanguageManager.Language = LanguageManager.Language.NotDefinite, Optional ByVal Type As SubSite.CerrelatedStructure.CorrelatedStatus = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Context, Optional ByVal Level As Integer = 0, Optional ByVal Category As Integer = 0)
        Me.Text = Text
        Me.NavigateUrl = NavigateUrl
        Me.Archive = Archive
        Me.Level = Level
        Me.Category = Category
        Me.ToolTip = ToolTip
        Me.Language = Language
        Me.Type = Type
      End Sub
    End Class

    Public Shared Function AddLinks(ByRef Html As String, ByVal Setting As SubSite, ByVal DomainConfiguration As DomainConfiguration, ByVal Archive As Integer, Optional AddWWW As AddWWW = AddWWW.Auto) As String
      UrlToLink(Html, Setting, DomainConfiguration)
      AddContextualLinks(Html, Setting, Archive, , , , AddWWW)
      Return Html
    End Function

    Shared Sub AddContextualLinks(ByRef Html As String, ByVal Setting As SubSite, ByVal Archive As Integer, Optional ByVal Level As Integer = 0, Optional ByVal Category As Integer = 0, Optional AbsoluteUrl As Boolean = False, Optional AddWWW As AddWWW = AddWWW.Auto)
      If Links IsNot Nothing AndAlso Links.ContainsKey(Setting.Language) AndAlso Setting.SEO.ApplyCorrelatedWordsFromOtherSites Then
        AddLinksToText(Html, Links(Setting.Language), TextType.Html, , Archive, Level, Category, AbsoluteUrl, AddWWW)
      ElseIf LinkFinderStructures IsNot Nothing AndAlso Setting.SEO.ApplyCorrelatedWordsFromOtherSites Then
        AddLinksToText(Html, LinkFinderStructures(Setting.Language), TextType.Html, , Archive, Level, Category, AbsoluteUrl, AddWWW)
      End If
    End Sub

    'Add a single link to text
    Shared Sub AddLinkToText(ByRef Text As String, ByVal Link As Link, Optional ByVal SourceType As TextType = TextType.Text, Optional ByVal Sort As Boolean = False, Optional ByVal Archive As Integer = 0)
      Dim SingleLink(0) As Link
      SingleLink(0) = Link
      AddLinksToText(Text, SingleLink, SourceType, Sort, Archive)
    End Sub

    Shared Sub AddLinksToText(ByRef Text As String, ByRef Links() As Link, Optional SourceType As TextType = TextType.Text, Optional Sort As Boolean = False, Optional Archive As Integer = 0, Optional Level As Integer = 0, Optional Category As Integer = 0, Optional AbsoluteUrl As Boolean = False, Optional AddWWW As AddWWW = AddWWW.Auto)
      ExecuteAddLinksToText(Text, Nothing, Links, SourceType, Sort, Archive, Level, Category, AbsoluteUrl, AddWWW)
    End Sub

    Shared Sub AddLinksToText(ByRef Text As String, LinkFinderStructure As LinkFinderStructure, Optional SourceType As TextType = TextType.Text, Optional Sort As Boolean = False, Optional Archive As Integer = 0, Optional Level As Integer = 0, Optional Category As Integer = 0, Optional AbsoluteUrl As Boolean = False, Optional AddWWW As AddWWW = AddWWW.Auto)
      ExecuteAddLinksToText(Text, LinkFinderStructure, Nothing, SourceType, Sort, Archive, Level, Category, AbsoluteUrl, AddWWW)
    End Sub

    Private Shared Sub ExecuteAddLinksToText(ByRef Text As String, LinkFinderStructure As LinkFinderStructure, Links() As Link, Optional ByRef SourceType As TextType = TextType.Text, Optional ByRef Sort As Boolean = False, Optional ByRef Archive As Integer = 0, Optional ByRef Level As Integer = 0, Optional ByRef Category As Integer = 0, Optional ByRef AbsoluteUrl As Boolean = False, Optional AddWWW As AddWWW = AddWWW.Auto)
      If Text <> "" Then
        If Links IsNot Nothing OrElse LinkFinderStructure IsNot Nothing Then
          Dim www As String = Nothing
          If AddWWW = ContextualLink.AddWWW.Auto Then
            If HttpContext.Current IsNot Nothing AndAlso HttpContext.Current.Request IsNot Nothing Then
              If DomainName(HttpContext.Current.Request).StartsWith("www.") Then
                www = "www."
              End If
            End If
          ElseIf AddWWW = ContextualLink.AddWWW.Yes Then
            www = "www."
          End If
          Dim MapHtml() As Boolean = Nothing
          If SourceType = TextType.Html Then
            MapHtml = CheckHtml(Text)
          End If
          If Sort Then
            Dim SortCriterion As IComparer = New SortLinkByTextLength(CurrentSetting.Language)
            System.Array.Sort(Links, SortCriterion)
          End If
          Dim Replaces As New Collections.Generic.List(Of ReplaceLink)

          Dim TextLCase As String = LCase(Text) 'To speedUp this function Instr instruction is in Bynary mode (all text parameter is in lcase)
          If Links IsNot Nothing Then
            'perform Algorithm 0
            Dim S As Integer 'S is a base 1 word position inside the text
            For Each Link As Link In Links
              '======= block #1: If you change this block, then modify the block #1 ====================
              If Link.Type = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Enabled OrElse (Link.Type = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Context And Link.Archive = Archive) Then
                If Link.Level = 0 OrElse Link.Category = Category Then
                  '======= end block #1 ================================================================
                  'Dim NavigateUrl As String = Nothing
                  S = 1 'S is base 1
                  Do
                    S = FindWord(S, TextLCase, Link.Text, , MapHtml, CompareMethod.Binary) 'To speedUp this function Instr instruction is in Bynary mode (all text parameter is in lcase)
                    If CBool(S) Then
                      PrepareToReplace(Replaces, Link, Archive, AbsoluteUrl, www, Text, TextLCase, S)
                    Else
                      Exit Do
                    End If
                  Loop
                End If
              End If
            Next
          Else
            'perform Algorithm 1
            Dim PrevChr As Char
            Dim ThisChar As Char
            For Idx As Integer = 0 To TextLCase.Length - 1
              PrevChr = ThisChar
              ThisChar = TextLCase(Idx)
              If MapHtml Is Nothing OrElse Not MapHtml(Idx) Then
                If Char.IsLetterOrDigit(PrevChr) = False Then
                  Dim LinksAtIdx As Collections.Generic.List(Of Link)
                  LinksAtIdx = LinkFinderStructure.ContainWord(TextLCase, Idx)
                  If LinksAtIdx IsNot Nothing Then
                    Dim HtmlCollision As Boolean
                    HtmlCollision = False
                    If MapHtml IsNot Nothing Then
                      For N = Idx To Idx + LinksAtIdx(0).Text.Length - 1
                        If MapHtml(Idx) = True Then
                          HtmlCollision = True
                          Exit For
                        End If
                      Next
                    End If
                    If HtmlCollision = False Then
                      For Each Link As Link In LinksAtIdx
                        '======= block #1: If you change this block, then modify the block #1 ====================
                        If Link.Type = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Enabled OrElse (Link.Type = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Context And Link.Archive = Archive) Then
                          If Link.Level = 0 OrElse Link.Category = Category Then
                            '======= end block #1 ================================================================
                            PrepareToReplace(Replaces, Link, Archive, AbsoluteUrl, www, Text, TextLCase, Idx + 1)
                            Idx += Link.Text.Length
                            Exit For
                          End If
                        End If
                      Next
                    End If
                  End If
                End If
              End If
            Next
          End If
          If CBool(Replaces.Count) Then
            Text = ApplyLinksToText(Text, Replaces)
          End If
        End If
      End If
    End Sub

    Enum AddWWW
      Auto
      Yes
      No
    End Enum

    Shared Sub PrepareAndCollectContextualLinks()
      Dim Links() As Link = Nothing
      Dim Languages As New Collections.Generic.Dictionary(Of Language, Collections.Generic.List(Of Integer))
      For Each Language As Language In LanguagesUsed
        Languages.Add(Language, New Collections.Generic.List(Of Integer))
      Next
      For Each Setup As SubSite In AllSubSite()
        If Not Setup.NotExist Then
          Dim Domain As DomainConfiguration
          If SubSiteToDomain IsNot Nothing Then
            Domain = DomainConfiguration.Load(SubSiteToDomain(Setup.Name))
          Else
            Domain = Nothing
          End If
          If Domain IsNot Nothing Then
            'AddLink at Domain
            If Setup.CorrelatedWords.Status <> Config.SubSite.CerrelatedStructure.CorrelatedStatus.NotEnabled Then
              If Not Setup.CorrelatedWords.Words Is Nothing Then
                Dim Status As Config.SubSite.CerrelatedStructure.CorrelatedStatus
                If Setup.SEO.ShareCorrelatedWords Then
                  Status = Setup.CorrelatedWords.Status
                Else
                  Status = SubSite.CerrelatedStructure.CorrelatedStatus.Context
                End If
                Dim NavigateUrl As String = Mid(Href(Domain, Setup.Name, True, "default.aspx"), 8)
                For Each Word As String In Setup.CorrelatedWords.Words
                  AddLinkToArray(Links, Word, NavigateUrl, 0, Setup.Description, Setup.Language, Status)
                Next
              End If
            End If
            'AddLink at all pages
            If Not Setup.Archive Is Nothing Then
              For Each Archive As Integer In Setup.Archive
                If Not Languages(Setup.Language).Contains(Archive) Then
                  Languages(Setup.Language).Add(Archive)
                  Dim Menu As Menu = Menu.Load(Archive, Setup.Language)
                  If Menu IsNot Nothing Then
                    Dim ItemsMenu As Collections.Generic.List(Of ItemMenu) = Menu.ItemsMenu
                    If Not ItemsMenu Is Nothing Then
                      Dim Category As Integer = 0
                      For Each Item As ItemMenu In ItemsMenu
                        If Item.Level <= 2 Then
                          Category += 1
                        End If
                        Dim Href As String = Item.Href(Domain, Setup)
                        If Href <> "" Then
                          If Not Item.Off Then
                            Dim FileName As String = MenuManager.PageNameFile(Item.Archive, Item.IdPage, Item.Language)
                            If IO.File.Exists(FileName) Then
                              Dim Document As New HtmlDocument(FileName)
                              Dim Words() As String = SplitCorrelateWords(Document.MetaTags.Collection("CorrelatedKeyWords"))
                              If Not Words Is Nothing Then
                                Dim Status As SubSite.CerrelatedStructure.CorrelatedStatus
                                Status = CType(Document.MetaTags.Collection("CorrelatedStatus"), SubSite.CerrelatedStructure.CorrelatedStatus)
                                If Status <> Config.SubSite.CerrelatedStructure.CorrelatedStatus.NotEnabled Then
                                  If Not Setup.SEO.ShareCorrelatedWords Then
                                    Status = SubSite.CerrelatedStructure.CorrelatedStatus.Context
                                  End If
                                  Dim Level As Integer
                                  If Item.Level >= 3 Then
                                    Level = 1
                                  Else
                                    Level = 0
                                  End If
                                  For Each Word As String In Words
                                    AddLinkToArray(Links, Word, Href, Archive, Item.Description.Title, Setup.Language, Status, Level, Category)
                                  Next
                                End If
                              End If
                            End If
                          End If
                        End If
                      Next
                    End If
                  End If
                End If
              Next
            End If
          End If
        End If
      Next

      Dim LinksLanguage As New Collections.Generic.Dictionary(Of LanguageManager.Language, Link())
      Dim LinkFinderStructuresByLanguage As New Collections.Generic.Dictionary(Of LanguageManager.Language, LinkFinderStructure)

      If Not Links Is Nothing Then
        For Each Language As LanguageManager.Language In LanguageManager.LanguagesUsed
          Dim SortCriterion As IComparer = New SortLinkByTextLength(Language)
          Dim LinksSorted() As Link = CType(Links.Clone(), Link())
          System.Array.Sort(LinksSorted, SortCriterion)
          Select Case Algorithm
            Case 0
              LinksLanguage.Add(Language, LinksSorted)
            Case Else
              LinkFinderStructuresByLanguage.Add(Language, New LinkFinderStructure(LinksSorted))
          End Select
        Next
        Select Case Algorithm
          Case 0
            ContextualLink.Links = LinksLanguage
            LinkFinderStructures = Nothing
          Case Else
            ContextualLink.Links = Nothing
            LinkFinderStructures = LinkFinderStructuresByLanguage
        End Select
      End If
    End Sub

    Private Shared Sub AddLinkToArray(ByRef Links() As Link, ByRef Text As String, ByRef NavigateUrl As String, ByRef Archive As Integer, Optional ByRef ToolTip As String = Nothing, Optional ByVal Language As LanguageManager.Language = LanguageManager.Language.NotDefinite, Optional ByVal Type As SubSite.CerrelatedStructure.CorrelatedStatus = Config.SubSite.CerrelatedStructure.CorrelatedStatus.Context, Optional ByVal Level As Integer = 0, Optional ByVal Category As Integer = 0)
      If Text IsNot Nothing Then
        Text = Text.Trim
        If Text <> "" Then
          Text = LCase(Text) 'To speedUp AddLinksToText function, all Instr instruction is in Binary mode (all text parameter must be in lcase)
          If Links Is Nothing Then
            ReDim Links(0)
          Else
            ReDim Preserve Links(Links.Length)
          End If
          Dim Link As New Link(Text, NavigateUrl, Archive, ToolTip, Language, Type, Level, Category)
          Links(UBound(Links)) = Link
        End If
      End If
    End Sub

    Private Shared Function ApplyLinksToText(ByRef Text As String, ByRef Replaces As Collections.Generic.List(Of ReplaceLink)) As String
      Dim SortCriterion As IComparer(Of ReplaceLink) = New SortReplaces
      Replaces.Sort(SortCriterion)
      'System.Array.Sort(Replaces, SortCriterion)
      Dim Result As New StringBuilder(Len(Text) * 2 + 512)
      Dim P As Integer
      Dim S As Integer
      Dim IsFirst As Boolean = True
      For Each Replace As ReplaceLink In Replaces
        P = Replace.StartPosition
        If IsFirst Then
          Result.Append(Left(Text, P - 1))
          IsFirst = False
        Else
          Result.Append(Mid(Text, S, P - S))
        End If
        S = Replace.NextPosition

        Dim Link As New HyperLink
        Link.ToolTip = EncodingAttribute(Replace.Link.ToolTip)
        Link.NavigateUrl = Replace.Link.NavigateUrl
        Link.Text = Replace.Link.Text
        If Setup.SEO.TypeOfContextualLink = Configuration.SearchEngineOptimizationConfiguration.LinkType.NoFollow Then
          Link.Attributes.Add("rel", "nofollow")
        ElseIf Setup.SEO.TypeOfContextualLink = Configuration.SearchEngineOptimizationConfiguration.LinkType.JavaScript Then
          Link.Attributes.Add("rel", "nofollow")
          Link.NavigateUrl = "javascript:window.location.assign('" & Link.NavigateUrl & "')"
        End If
        Result.Append(ControlToText(Link))
      Next
      Result.Append(Mid(Text, S))
      Return Result.ToString
    End Function

    Class SortReplaces
      Implements IComparer(Of ReplaceLink)
      Public Function Compare(ByVal ReplaceLink1 As ReplaceLink, ByVal ReplaceLink2 As ReplaceLink) As Integer Implements IComparer(Of ReplaceLink).Compare
        Select Case ReplaceLink1.StartPosition
          Case Is > ReplaceLink2.StartPosition
            Return 1
          Case Is < ReplaceLink2.StartPosition
            Return -1
          Case Else
            Return 0
        End Select
      End Function
    End Class

    Public Class ReplaceLink
      Public Link As Link
      Public StartPosition As Integer
      Public NextPosition As Integer
      Public Sub New(ByRef Text As String, ByRef NavigateUrl As String, Optional ByRef ToolTip As String = Nothing)
        Dim Link = New Link(Text, NavigateUrl, Nothing, ToolTip)
        Me.Link = Link
      End Sub
    End Class

    Class SortLinkByTextLength
      Implements IComparer
      Public Function Compare(ByVal Link1 As Object, ByVal Link2 As Object) As Integer Implements IComparer.Compare
        Dim L1 As Link = CType(Link1, Link)
        Dim L2 As Link = CType(Link2, Link)
        Dim X1 As Integer = Len(L1.Text)
        Dim X2 As Integer = Len(L2.Text)
        If X1 < X2 Then
          Return 1
        ElseIf X1 > X2 Then
          Return -1
        ElseIf L1.Language = L2.Language Then
          Return 0
        ElseIf L1.Language = Language Then
          Return -1
        ElseIf L2.Language = Language Then
          Return 1
        Else
          Return 0
        End If
      End Function
      Sub New(ByVal Language As LanguageManager.Language)
        Me.Language = Language
      End Sub
      Private Language As LanguageManager.Language
    End Class

    Private Shared Sub PrepareToReplace(Replaces As Collections.Generic.List(Of ReplaceLink), Link As Link, ByRef Archive As Integer, ByRef AbsoluteUrl As Boolean, ByRef www As String, ByRef Text As String, ByRef TextLcase As String, ByRef S As Integer)
      Const Cancel As Char = Chr(24)
      Dim NavigateUrl As String = Nothing

      'Finded word
      If Archive <> 0 AndAlso Link.Archive = Archive Then

        'Is a inside link
        If AbsoluteUrl Then
          Try
            Dim Domain As String = ArchiveToDomain(Link.Archive)
            NavigateUrl = "http://" & www & Domain & "/" & Mid(Link.NavigateUrl, 2)
          Catch ex As Exception
            'SubSiteToDomain collection is Nothing (Use sub UpdateSubSiteToDomain to load this collection)
          End Try
        Else
          NavigateUrl = Link.NavigateUrl
        End If
      Else
        'Is a external link
        If Link.NavigateUrl.First <> "."c Then
          NavigateUrl = "http://" & www & Link.NavigateUrl
        Else
          Dim Domain As String = Nothing
          Try
            Domain = ArchiveToDomain(Link.Archive)
          Catch ex As Exception
            'SubSiteToDomain collection is Nothing (Use sub UpdateSubSiteToDomain to load this collection)
          End Try
          If Domain <> "" Then
            NavigateUrl = "http://" & www & Domain & "/" & Mid(Link.NavigateUrl, 2)
          Else
            NavigateUrl = Link.NavigateUrl
          End If
        End If
      End If

      'Save copy of text
      Dim TextReplaced As String = Mid(Text, S, Link.Text.Length)
      'Set "cancel" caracters
      Mid(TextLcase, S) = StrDup(Link.Text.Length, Cancel)

      'Add a replace object
      Dim Replace As New ReplaceLink(TextReplaced, NavigateUrl, Link.ToolTip)
      Replace.StartPosition = S
      S = S + Link.Text.Length
      Replace.NextPosition = S
      Replaces.Add(Replace)

    End Sub

    Class LinkFinderStructure
      Public Letters As New Collections.Generic.Dictionary(Of Char, CharStructure)
      Class CharStructure
        'Public Letter As Char
        Public Find As New LinkFinderStructure
        Public Links As Collections.Generic.List(Of Link)
      End Class
      Function ContainWord(Text As String, Position As Integer) As Collections.Generic.List(Of Link)
        Dim C As Char
        If Position < Text.Length Then
          C = Text(Position)
        Else
          Return Nothing
        End If
        Dim L As CharStructure
        If Letters.ContainsKey(C) Then
          L = Letters(C)
          If L.Links IsNot Nothing Then
            Dim HexFirstChar As Integer = AscW(L.Links(0).Text(0))
            'True is the first char is in ideogram Alphabet
            Dim Chinese As Boolean = HexFirstChar >= &H2E80 AndAlso HexFirstChar <= &HFA6A
            If Chinese OrElse Position = Text.Length - 1 OrElse Not Char.IsLetterOrDigit(Text(Position + 1)) Then
              'Verify if exists e word/phrase more long
              Dim Result As Collections.Generic.List(Of Link)
              Result = L.Find.ContainWord(Text, Position + 1)
              If Result IsNot Nothing Then
                Return Result 'Exists a word/phrase more long 
              Else
                Return L.Links 'Is the longer word/phrase
              End If
            End If
          Else
            Return L.Find.ContainWord(Text, Position + 1)
          End If
        End If
        Return Nothing
      End Function
      Sub PopulateLink(Link As Link, Level As Integer)
        If Level < Link.Text.Count Then
          Dim C As Char = Link.Text(Level)
          'NewList.Add(Link)
          Dim L As CharStructure
          If Not Me.Letters.ContainsKey(C) Then
            L = New CharStructure
            Me.Letters.Add(C, L)
          Else
            L = Me.Letters(C)
          End If

          If Level = Link.Text.Count - 1 Then
            If L.Links Is Nothing Then
              L.Links = New Collections.Generic.List(Of Link)
            End If
            L.Links.Add(Link)
          Else
            L.Find.PopulateLink(Link, Level + 1)
          End If
        End If
      End Sub

      Sub New(Links() As Link)
        For Each Link As Link In Links
          PopulateLink(Link, 0)
        Next
      End Sub
      Sub New()
      End Sub
    End Class

  End Class

End Namespace
