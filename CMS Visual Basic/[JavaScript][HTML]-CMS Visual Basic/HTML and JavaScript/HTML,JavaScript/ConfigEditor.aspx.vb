Imports WebApplication
Imports System.Reflection
Partial Class ConfigEditor
	Inherits System.Web.UI.Page
	Private Setting As SubSite
	Private CurrentUser As User
  Shared Plugin As New PluginManager.Plugin(, , , , Plugin.Characteristics.CorePlugin)
	Shared Progressive As Integer
	Private EditObjectParameters As EditObjectParameters

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Setting = CurrentSetting()
		CurrentUser = Authentication.CurrentUser
		If Request.QueryString("plugin") IsNot Nothing Then
			Dim Plugin As PluginManager.Plugin = PluginManager.GetPlugin(Request.QueryString("plugin"))
			If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster AndAlso Plugin.IsAccessible(CurrentUser, Setting) Then
				If Request.QueryString("shared") IsNot Nothing Then
					If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster Then
						EditObjectParameters = Plugin.EditObjectParametersForSharedConfiguration.Invoke
					Else
						EndResponse()
					End If
				Else
					EditObjectParameters = Plugin.EditObjectParametersForInheritSubSite.Invoke
				End If
			Else
				EndResponse()
			End If
		ElseIf Request.QueryString("edit") IsNot Nothing Then
			If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster Then
				Dim EditObjectParameters As New EditObjectParameters
				Select Case Request.QueryString("edit")
					Case "setup"
						Dim Save As SaveObjectMethod = Sub()
																						 SaveConfiguration("config.xml")
																					 End Sub
						EditObjectParameters.ObjectToEdit = Setup
						EditObjectParameters.SaveObjectMethod = Save
						EditObjectParameters.TitleInPageEditor = Phrase(Setting.Language, 144, 145)
				End Select
				If Request.UrlReferrer IsNot Nothing Then
					EditObjectParameters.BackPage = Request.UrlReferrer.AbsoluteUri
				End If
				Me.EditObjectParameters = EditObjectParameters
			End If
		ElseIf Not IsPostBack Then
			EditObjectParameters = RetriveObjectFromOtherPage()
			Progressive += 1
			KeyObject.Value = "KeepAlive" & Progressive
			Session(KeyObject.Value) = EditObjectParameters
		Else
			EditObjectParameters = Session(Request.Form(KeyObject.UniqueID))
		End If
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim MasterPage As MasterPage = SetMasterPage(Me, , False, False)

		If EditObjectParameters IsNot Nothing Then
			Dim Obj As Object = EditObjectParameters.ObjectToEdit
			Dim SaveObjectMethod As SaveObjectMethod = EditObjectParameters.SaveObjectMethod
			Dim TextTitle As String = EditObjectParameters.TitleInPageEditor
			Dim TextDescription As String = EditObjectParameters.DescriptionInPageEditor
      Dim TablePropertyPhraseCorrispondence As StringDictionary = EditObjectParameters.TablePropertyPhraseCorrispondence
      Dim TablePropertyIdPhraseCorrispondence As Collections.Generic.Dictionary(Of String, Integer) = EditObjectParameters.TablePropertyIdPhraseCorrispondence
			Dim NamePhraseBooks As String = EditObjectParameters.NamePhraseBooks
			Dim BackTo As String = EditObjectParameters.BackPage

			MasterPage.TitleDocument = TextTitle
			MasterPage.Description = TextDescription
			MasterPage.KeyWords = TextTitle

			Dim ControlTitle As New WebControl(HtmlTextWriterTag.H1)
			ControlTitle.Controls.Add(TextControl(TextTitle))
			PlaceHolder1.Controls.Add(ControlTitle)

			Dim ControlDescription As New WebControl(HtmlTextWriterTag.H2)
			ControlDescription.Controls.Add(TextControl(TextTitle))
			PlaceHolder1.Controls.Add(ControlDescription)
			If IsPostBack Then
				'Retrive Obj modification from a page, and set Obj, eventually write a error message in page
				Dim RetriveSetError As Boolean
        PlaceHolder1.Controls.Add(ObjectToControl(Setting, Obj, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, Request, RetriveSetError, EditObjectParameters.FilterExcludeProperties, EditObjectParameters.FilterIncludeProperties, EditObjectParameters.FilterArray))
				If RetriveSetError Then
          MasterPage.AddMessage(Setting, 27)
				ElseIf Request.Form("NoSaveNow") IsNot Nothing Then
					'No action!
				Else
					Try
						SaveObjectMethod.Invoke()
						If BackTo IsNot Nothing AndAlso Session("NoBackTo") Is Nothing Then
							'Return to calling page
							Session("NoBackTo") = Nothing
							Response.Clear()
              SetNextMessage(418)
              Response.Redirect(BackTo, True)
							Exit Sub
						Else
							'Save object successful!!
              MasterPage.AddMessage(Setting, 418)
						End If
					Catch ex As Exception
						'Error in save operation
            MasterPage.AddMessage(ex.Message, Setting, ex.StackTrace, ex.HelpLink, MessageType.ErrorAlert)
					End Try
				End If
				Session("NoBackTo") = Nothing
			Else
				'Set a page with a caracteristics of Obj
        PlaceHolder1.Controls.Add(ObjectToControl(Setting, Obj, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, , , EditObjectParameters.FilterExcludeProperties, EditObjectParameters.FilterIncludeProperties, EditObjectParameters.FilterArray))
			End If
		Else
			'Session is expired! OR Is a request to this page directly
			SaveButton.Visible = False
		End If
		If SaveButton.Visible Then
      If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
        MasterPage.Blink(SaveButton)
      End If
		End If
	End Sub

End Class
