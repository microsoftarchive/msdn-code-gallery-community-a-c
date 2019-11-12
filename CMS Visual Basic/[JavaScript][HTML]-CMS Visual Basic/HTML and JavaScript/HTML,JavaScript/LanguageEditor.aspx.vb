'Note by Andrea Bruno (the King developer)

Imports WebApplication
Partial Class LanguageEditor

	Inherits System.Web.UI.Page
	Private Setting As SubSite
	Private CurrentUser As User

	'REMOVE REM OF NEXT LINES AND REPLACE IN NEXT STANTMENT "blank.aspx" WITH A NEW aspx FILE NAME
	Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
	Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, Authentication.User.RoleType.WebMaster, True, , PluginManager.Plugin.Characteristics.CorePlugin)
		Return Plugin
	End Function
	Shared Sub New()
		Initialize()
	End Sub

	Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
		If ShortDescription Then
			'Return the short description of plugin
      Return Phrase(Language, 52, 79) 'Replace 0 with appropriate phrase ID
		Else
			'Return the long description of plugin
      Return Phrase(Language, 149, 52, 79)    'Replace 0 with appropriate phrase ID
		End If
	End Function

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Setting = CurrentSetting()
		CurrentUser = Authentication.CurrentUser
    Dim MasterPage As MasterPage = SetMasterPage(Me, , False, False)

		MasterPage.TitleDocument = Description(Setting.Language, True)
    MasterPage.Description = Description(Setting.Language, False)
		'MasterPage.KeyWords = "KeyWords1,KeyWords2,KeyWords3"

		Dim Table As New HtmlTable

		Dim FirstRow As New HtmlTableRow
		Table.Rows.Add(FirstRow)
		Dim IdCell As New HtmlTableCell("th")
		IdCell.Controls.Add(TextControl(Phrase(Setting.Language, 408)))
		FirstRow.Controls.Add(IdCell)

		Dim Base As New HtmlTableCell("th")
		Dim LCode As Integer
		Dim Source As Language
		If Setting.Language <> Language.English Then
			Source = Language.English
			LCode = 80 'English
		Else
			Source = Language.Italian
			LCode = 81 'Italian
		End If
		Base.Controls.Add(TextControl(Phrase(Setting.Language, LCode)))
		FirstRow.Controls.Add(Base)

		Dim Current As New HtmlTableCell("th")
		Current.Controls.Add(TextControl(LanguageDefinition(Setting.Language, Setting.Language)))
		FirstRow.Controls.Add(Current)

		Dim SourceDictionary As Collections.Generic.Dictionary(Of Integer, String) = PhraseBooks(Source)
		Dim Dictionary As Collections.Generic.Dictionary(Of Integer, String) = PhraseBooks(Setting.Language)

		'Sort the Dictionary in Alphabethic order of destination language
		Dim Keys(Dictionary.Keys.Count - 1) As Integer
		Dictionary.Keys.CopyTo(Keys, 0)
		Dim SortCriterion As IComparer = New SortAlphapetic(Setting.Language)
		System.Array.Sort(Keys, SortCriterion)

		'Populate items
		For Each Id As Integer In Keys
			Select Case Id
				Case 500 To 1002, 1300 To 1316
					'Exclude this phrases
				Case Else
					Dim Row As New HtmlTableRow
					Table.Rows.Add(Row)

					Dim Cell1 As New HtmlTableCell
					Row.Cells.Add(Cell1)
					Cell1.InnerText = Id

					Dim Cell2 As New HtmlTableCell
					Row.Cells.Add(Cell2)
					Cell2.Controls.Add(TextControl(Phrase(Source, Id)))

					Dim Cell3 As New HtmlTableCell
					Row.Cells.Add(Cell3)
					Dim TextBox As New TextBox
					TextBox.TextMode = TextBoxMode.MultiLine
					If IsPostBack Then
						Dictionary(Id) = Request.Form("Phrase" & Id)
					End If
					TextBox.Text = Phrase(Setting.Language, Id)
					TextBox.ID = "Phrase" & Id
					TextBox.Rows = 3
					TextBox.Columns = 70
					Cell3.Controls.Add(TextBox)
			End Select
		Next

		'Add a table into Master Page 
    MasterPage.ContentPlaceHolder.Controls.Add(New LiteralControl(ControlToText(Table)))

    'Add submit button
    Dim Button As New Button
    Button.Text = Phrase(Setting.Language, 57)
    MasterPage.ContentPlaceHolder.Controls.Add(Button)

		If IsPostBack Then
			'Save the PhraseBooks (dictionaries)
			XmlPhraseBooks(XmlPhraseBooksNameFile) = PhraseBooks
      MasterPage.AddMessage(Setting, 418)
    End If


  End Sub

	Class SortAlphapetic
		Implements IComparer
		Public Function Compare(ByVal Id1 As Object, ByVal Id2 As Object) As Integer Implements IComparer.Compare
			Return StrComp(Phrase(Language, Id1), Phrase(Language, Id2), CompareMethod.Text)
		End Function 'Compare
		Sub New(ByVal Language As LanguageManager.Language)
			Me.Language = Language
		End Sub
		Private Language As LanguageManager.Language
	End Class


End Class
