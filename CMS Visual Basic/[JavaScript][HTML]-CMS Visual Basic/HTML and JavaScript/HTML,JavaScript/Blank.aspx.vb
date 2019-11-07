'Note by Andrea Bruno (the King developer)
'Use this blank page to create a new plugin: Modify Blank.aspx & Blank.aspx.vb add extra functions in your web abblication!
Imports WebApplication
Partial Class Blank
	'REPLACE THE NAME OF THIS CLASS AND Inherits ATTRIBUTE IN <%@ Page...%> WITH A PLUGIN NAME
	'RENAME A PAGE Blank.aspx
	'EXEMP.: IF THE PAGE NAME IS PluginOne.aspx, THE CLASS NAME MUST BE pluginOne AND SET ATTRIBUTE IN  <%@ Page Inherits="PluginOne" %>  

	Inherits System.Web.UI.Page
	Private Setting As SubSite
	Private CurrentUser As User

	'REMOVE REM OF NEXT LINES AND REPLACE IN NEXT STANTMENT "blank.aspx" WITH A NEW aspx FILE NAME
	'Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
	'Shared Function Initialize() As PluginManager.Plugin
	'	If Plugin Is Nothing Then Plugin = New PluginManager.Plugin("blank.aspx", AddressOf Description)
	'	Return Plugin
	'End Function
	'Shared Sub New()
	'	Initialize()
	'End Sub

	Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
		If ShortDescription Then
			'Return the short description of plugin
			Select Case Language
				Case Else
					Return "Plugun name"
          'Return Phrase(Language, 0)	'Replace 0 with appropriate phrase ID
			End Select
		Else
			'Return the long description of plugin
			Select Case Language
				Case Else
					Return "Description of plugin"
          'Return Phrase(Language, 0)	'Replace 0 with appropriate phrase ID
			End Select
		End If
	End Function

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Setting = CurrentSetting()
		CurrentUser = Authentication.CurrentUser
		Dim MasterPage As MasterPage = SetMasterPage(Me, , False, )

		MasterPage.TitleDocument = Description(Setting.Language, True)
    MasterPage.Description = Description(Setting.Language, False)
		'MasterPage.KeyWords = "KeyWords1,KeyWords2,KeyWords3"

	End Sub

End Class
