Imports WebApplication

Partial Class translator
  Inherits System.Web.UI.Page
  Dim Setting As SubSite

	Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
	Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , True)
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
        MasterPage.AddButton(Phrase(Setting.Language, 3222), Common.Href(Setting.Name, False, "translator.aspx"), , Components.IconType.Globe)
      End If
    End If
  End Sub

	Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
		If ShortDescription Then
      Return Phrase(Language, 3217)
		Else
      Return Phrase(Language, 3219)
		End If
	End Function


	Protected Sub translator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Setting = CurrentSetting()
		Dim MasterPage As MasterPage = SetMasterPage(Me)
		MasterPage.TitleDocument = Phrase(Setting.Language, 3217)
		MasterPage.Description = Phrase(Setting.Language, 3218)
		MasterPage.KeyWords = Phrase(Setting.Language, 3219)

		'Put user code to initialize the page here
		Dim SelectedSource As LanguageManager.Language
		Dim SelectedTarget As LanguageManager.Language
		If Page.IsPostBack Then
			SelectedSource = Request.Form(SourceLanguage.UniqueID)
			SelectedTarget = Request.Form(TargetLanguage.UniqueID)
		Else
			Dim Value As String = Cookie("LastTranslation")
			If Value <> "" Then
				Dim Values As String() = Split(Value)
				SelectedSource = Values(0)
				SelectedTarget = Values(1)
			Else
				SelectedSource = Setting.Language
				SelectedTarget = LanguageManager.Language.English
			End If
		End If

		PupulateLanguageList(SourceLanguage, SelectedSource)
		PupulateLanguageList(TargetLanguage, SelectedTarget)
		For Each Item1 As WebControls.ListItem In SourceLanguage.Items
			For Each Item2 As WebControls.ListItem In TargetLanguage.Items
				If Item1.Text <> Item2.Text Then
					MasterPage.KeyWords &= "," & Item1.Text & "," & Item2.Text
				End If
			Next
		Next
	End Sub

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
		Dim PageLoaded As Date = Session("TimePageLoaded")
		If DateDiff(DateInterval.Second, PageLoaded, Now) < 5 Then
      Dim MasterPage As MasterPage = Page.Master : MasterPage.AddMessage(Phrase(Setting.Language, 422, 3245), Setting)
		Else
			Dim Source As LanguageManager.Language = Request(SourceLanguage.UniqueID)
			Dim Target As LanguageManager.Language = Request(TargetLanguage.UniqueID)
			Cookie("LastTranslation") = Source & " " & Target
			If Source = Target Then
				TargetText.Text = SourceText.Text
			Else
				Try
					TargetText.Text = Translate(SourceText.Text, Source, Target)
				Catch ex As Exception
          Dim MasterPage As MasterPage = Page.Master : MasterPage.AddMessage(Setting, 3226, Nothing, Nothing, MessageType.ErrorAlert)
				End Try
			End If
			TargetText.Visible = True
		End If
	End Sub

	Sub PupulateLanguageList(ByVal List As WebControls.DropDownList, ByVal Selected As LanguageManager.Language)
		Dim Item As New WebControls.ListItem
		'Item.Value = LanguageManager.Language.NotDefinite
		'Item.Text = Phrase(Setting.Language, 415) & ":"
		'List.Items.Add(Item)
		For Each Language As LanguageManager.Language In [Enum].GetValues(GetType(LanguageManager.Language))
			Select Case Language
				Case Language.Chinese, Language.Dutch, Language.English, Language.French, Language.Italian, Language.Japanese, Language.Russian, Language.Spanish
					Item = New WebControls.ListItem
					Item.Value = Language
					Item.Text = LanguageDefinition(Language, Setting.Language)
					If Language = Selected Then
						Item.Selected = True
					End If
					List.Items.Add(Item)
			End Select
		Next
	End Sub

  Protected Sub translator_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
    Session("TimePageLoaded") = Now
  End Sub

End Class
