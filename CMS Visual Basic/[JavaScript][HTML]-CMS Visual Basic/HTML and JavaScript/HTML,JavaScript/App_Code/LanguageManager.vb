Imports System.Threading.Tasks

'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Namespace WebApplication

  Public Module LanguageManager
    Public Acronyms() As String = {"--", "EN", "IT", "RU", "DE", "ES", "FR", "ZH", "JP", "AR", "KO", "PT", "GR", "TR", "LV", "NL"}
    Public Enum Language As Integer
      NotDefinite
      English
      Italian
      Russian
      Dutch
      Spanish
      French
      Chinese
      Japanese
      Arab
      Korean
      Portuguese
      Greek
      Turkish
      Latvian
      Nederland
    End Enum
    Public LanguagesUsed As Language() = {Language.English, Language.Italian, Language.Russian, Language.Spanish, Language.French, Language.Dutch, Language.Chinese, Language.Portuguese, Language.Turkish, Language.Latvian, Language.Nederland}
    Function Acronym2Enum(ByVal Acronym As String) As Language
      Dim n As Language
      For Each Acr As String In Acronyms
        If String.Compare(Acronym, Acr, True) = 0 Then
          Return n
        End If
        n += 1
      Next
      Return Language.NotDefinite
    End Function
    Function Acronym(ByVal Language As Language) As String
      Return Acronyms(Language)
    End Function
    Function AcronymDefinition(ByVal Acronym As String, ByVal Language As Language) As String
      Dim n As Integer
      For Each Acr As String In Acronyms
        If String.Compare(Acronym, Acr, True) = 0 Then
          Return Phrase(Language, 79 + n)
        End If
        n += 1
      Next
      Return Nothing
    End Function
    Function LanguageDefinition(ByVal Language As Language, ByVal Output As Language) As String
      Return Phrase(Output, 79 + Language)
    End Function
    Function Culture(Language As Language) As Globalization.CultureInfo
      Dim Name As String
      If Language = LanguageManager.Language.English Then
        Name = "en-US"
      ElseIf Language = LanguageManager.Language.Chinese Then
        Name = "zh-CN"
      Else
        Name = LCase(LanguageManager.Acronym(Language) & "-" & LanguageManager.Acronym(Language))
      End If
      Return New Globalization.CultureInfo(Name)
    End Function
    Public Sub SetLocalization(ByRef Control As Control, ByRef Language As Language)
      Dim Text As String
      Dim Type As System.Type

      For Each Ctrl In Control.Controls
        'If ctrl.Visible Then
        Type = Nothing
        Type = Ctrl.GetType()

        If Type.GetProperty("ToolTip") IsNot Nothing Then
          Text = Localize(Ctrl.ToolTip, Language)
          If Text IsNot Nothing Then
            Ctrl.ToolTip = Text
          End If
        End If

        If Type.GetProperty("Text") IsNot Nothing Then
          If Type.IsVisible Then 'Without this verify get error in page "log.aspx" and "showphoto.aspx" wen app run un trust mode "Medium" under IIS 
            Text = Localize(Ctrl.Text, Language)
            If Text IsNot Nothing Then
              Ctrl.Text = Text
            End If
          End If
        End If

        If Type.GetProperty("ErrorMessage") IsNot Nothing Then
          Text = Localize(Ctrl.ErrorMessage, Language)
          If Text IsNot Nothing Then
            Ctrl.ErrorMessage = Text
          End If
        End If

        If Type.GetProperty("Value") IsNot Nothing Then
          If Not TypeOf Ctrl Is System.Web.UI.HtmlControls.HtmlInputFile Then 'Is Read only
            Text = Localize(Ctrl.Value, Language)
            If Text IsNot Nothing Then
              Ctrl.Value = Text
            End If
          End If
        End If
        If Ctrl.HasControls Then
          SetLocalization(Ctrl, Language)
        End If
        'End If
      Next
    End Sub

    Function Localize(ByRef Variable As String, ByRef Language As Language) As String
      If Variable.Length Then
        If Variable.Chars(0) = "#"c Then
          If Char.IsNumber(Variable.Chars(1)) Then
            If Variable.IndexOf("#"c, 1) = -1 Then
              Dim n As Integer = Mid(Variable, 2)
              Return Phrase(Language, n)
            Else
              Dim IndexString As String() = Split(Variable, "#")
              Dim Index As Integer() = Nothing
              For Each Data As String In IndexString
                If Data <> "" Then
                  If Index Is Nothing Then
                    ReDim Index(0)
                  Else
                    ReDim Preserve Index(Index.GetUpperBound(0) + 1)
                  End If
                  Index(Index.GetUpperBound(0)) = CInt(Data)
                End If
              Next
              Return Phrase(Language, Index)
            End If
          End If
        End If
      End If
      Return Nothing
    End Function

    Public PhraseBooks As Collections.Generic.Dictionary(Of Language, Collections.Generic.Dictionary(Of Integer, String))

    'Dictionaries is a collection of PhraseBooks added from Plugin
    Public Dictionaries As New Collections.Generic.Dictionary(Of String, Collections.Generic.Dictionary(Of Language, Collections.Generic.Dictionary(Of Integer, String)))

    Private Const EndFileName As String = ".PhraseBooks.xml"

    Function XmlPhraseBooksNameFile(Optional ByVal NamePhraseBooks As String = "General") As String
      Return Extension.MapPath(ReadWriteDirectory & "/" & NamePhraseBooks & EndFileName)
    End Function

    Function AllXmlPhraseBooksNameFiles() As String()
      Return System.IO.Directory.GetFiles(Extension.MapPath(ReadWriteDirectory), "*" & EndFileName)
    End Function


    Property XmlPhraseBooks(ByVal NameFile As String) As Collections.Generic.Dictionary(Of Language, Collections.Generic.Dictionary(Of Integer, String))
      'Load Phrase Books from XML file
      Get
        Dim Lemmas As Collections.Generic.List(Of Lemma) = Deserialize(NameFile, GetType(Collections.Generic.List(Of Lemma)))
        Dim NewPhraseBooks As New Collections.Generic.Dictionary(Of Language, Collections.Generic.Dictionary(Of Integer, String))
        For Each Language As Language In LanguagesUsed
          Dim Book As New Collections.Generic.Dictionary(Of Integer, String)
          NewPhraseBooks.Add(Language, Book)
        Next
        For Each Lemma As Lemma In Lemmas
          NewPhraseBooks(Lemma.Language)(Lemma.Id) = Lemma.Text
        Next
        Return NewPhraseBooks
      End Get
      Set(ByVal Dictionary As Collections.Generic.Dictionary(Of Language, Collections.Generic.Dictionary(Of Integer, String)))
        'Save Phrase Books to XML file
        Dim Lemmas As New Collections.Generic.List(Of Lemma)
        For Each Language As Language In Dictionary.Keys
          For Each Id As Integer In Dictionary(Language).Keys
            Dim Lemma As New Lemma
            Lemma.Language = Language
            Lemma.Id = Id
            Lemma.Text = Dictionary(Language)(Id)
            Lemmas.Add(Lemma)
          Next
        Next
        Serialize(Lemmas, NameFile)
      End Set
    End Property

    Class Lemma
      Public Language As Language
      Public Id As Integer
      Public Text As String
    End Class

    Sub LoadPhrasesBooks()
      Dim XmlFile As String = XmlPhraseBooksNameFile()
      If System.IO.File.Exists(XmlFile) Then
        PhraseBooks = XmlPhraseBooks(XmlFile)
      Else
        'Conversion of Phrases Books from .MDB to XML need the "Full trust level" 
        Dim PhraseBooks As New Collections.Generic.Dictionary(Of Language, Collections.Generic.Dictionary(Of Integer, String))
        For Each Language As Language In LanguagesUsed
          Dim Book As New Collections.Generic.Dictionary(Of Integer, String)
          PhraseBooks.Add(Language, Book)
        Next
        Dim ObjDataReader As Data.OleDb.OleDbDataReader = DataManager.Table(LocalizationDataFile, "phrases")
        Dim ID As Integer, TXT As String, Array(0) As String
        While ObjDataReader.Read()
          ID = ObjDataReader("id")
          For Each Language As Language In LanguagesUsed
            Try
              TXT = ObjDataReader(Acronym(Language))
            Catch ex As Exception
              TXT = ""
              If Language <> Language.English Then
                TXT = Phrase(Language.English, ID)
                If TXT = "" AndAlso Language <> Language.Italian Then
                  TXT = Phrase(Language.Italian, ID)
                End If
              End If
            End Try
            PhraseBooks(Language).Add(ID, TXT)
          Next
        End While
        CloseConnection(ObjDataReader)
        LanguageManager.PhraseBooks = PhraseBooks
        If Not System.IO.File.Exists(XmlFile) Then
          XmlPhraseBooks(XmlFile) = PhraseBooks
        End If
      End If

      If PhraseBooks IsNot Nothing Then
        Dictionaries.Add("General", PhraseBooks)
      End If

      'Add all supplementary PhrasesBooks
      For Each File In AllXmlPhraseBooksNameFiles()
        If File <> XmlFile Then
          Dim NamePhraseBooks As String = Left(File, File.Length - Len(EndFileName))
          Dictionaries.Add(NamePhraseBooks, XmlPhraseBooks(File))
        End If
      Next
    End Sub

    Function Phrase(ByVal Language As Language, ByVal ParamArray ID() As Integer) As String
      Dim Text As String = Nothing
      For Each Idx As Integer In ID
        If Text <> "" Then Text &= " "
        Text &= Phrase(Language, Idx)
      Next
      Return Text
    End Function

    Public Function Phrase(ByVal Language As Language, ByRef ID As Integer) As String
      Try
        Return PhraseBooks(Language)(ID)
      Catch ex As Exception
        Try
          Return PhraseBooks(LanguageManager.Language.English)(ID)
        Catch ex2 As Exception
        End Try
      End Try
      Return Nothing
    End Function

    Function Phrase(ByVal NamePhraseBooks As String, ByVal Language As Language, ByVal ParamArray ID() As Integer) As String
      Dim Text As String = Nothing
      For Each Idx As Integer In ID
        If Text <> "" Then Text &= " "
        Text &= Phrase(NamePhraseBooks, Language, Idx)
      Next
      Return Text
    End Function

    Public Function Phrase(ByVal NamePhraseBooks As String, ByVal Language As Language, ByRef ID As Integer) As String
      If NamePhraseBooks Is Nothing Then
        Return Phrase(Language, ID)
      Else
        Try
          Return Dictionaries(NamePhraseBooks)(Language)(ID)
        Catch ex As Exception
          Try
            Return Dictionaries(NamePhraseBooks)(LanguageManager.Language.English)(ID)
          Catch ex2 As Exception
          End Try
        End Try
      End If
      Return Nothing
    End Function

    Public Function Ask(ByVal Text As String, ByVal Language As Language) As String
      If Language = Language.Spanish Then
        Ask = "¿" & Text & "?"
      ElseIf Language = Language.Chinese Then
        Ask = Text & "？"
      Else
        Ask = Text & "?"
      End If
    End Function
  End Module

End Namespace
