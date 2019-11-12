Imports WebApplication
Partial Class pagesmanager
  Inherits System.Web.UI.Page
	Private Setting As Config.SubSite
  Private Archive As Integer
	Private Language As LanguageManager.Language
	Private MasterPage As MasterPage
  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    RegisterAnonimus()
    Setting = CurrentSetting()
    Archive = Val(Request.QueryString("archive"))
		Language = Val(Request.QueryString("lng"))
		If Archive = 0 Then
			If Setting.Archive IsNot Nothing Then
				If Setting.Archive.Length = 1 Then
					Archive = Setting.Archive(0)
					If Language = Language.NotDefinite Then Language = Setting.Language
				End If
			End If
		End If

		If Language = Language.NotDefinite Then
			Language = Setting.Language
		End If
    'block not autorized
    Dim Block As Boolean
    If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.AdministratorJunior Then
      Block = True
    Else
			If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.WebMaster And Archive <> 0 Then
				Block = True
				If Setting.Archive IsNot Nothing Then
					For Each IdArchive As Integer In Setting.Archive
						If IdArchive = Archive Then
							Block = False
						End If
					Next
				End If
			End If
    End If
    If Block Then
      Response.Clear()
      Response.End()
    End If
  End Sub

  Protected Sub pagesmanager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		MasterPage = SetMasterPage(Me, , False, False)
  End Sub

  Function Script() As Control


    Dim CodeMsg As String = _
     "var msg3017=""" & Phrase(Setting.Language, 3017) & """;" & vbCrLf & _
     "var msg3016=""" & Phrase(Setting.Language, 3016) & """;" & vbCrLf & _
     "var msg101=""" & Phrase(Setting.Language, 101) & """;" & vbCrLf & _
     "var msg102=""" & Phrase(Setting.Language, 102) & """;" & vbCrLf

    Dim Code As String = _
    "PageSelect=document.getElementById(""" & PageSelect.ClientID & """);" & vbCrLf & _
    "ObjTitle=document.getElementById(""" & Title.ClientID & """);" & vbCrLf & _
    "ObjLabel=document.getElementById(""" & Label.ClientID & """);" & vbCrLf & _
    "ObjLink=document.getElementById(""" & Link.ClientID & """);" & vbCrLf & _
    "CodeMenu=document.getElementById(""" & CodeMenu.ClientID & """);" & vbCrLf & _
    "MessageAlert=document.getElementById(""" & MessageAlert.ClientID & """);" & vbCrLf & _
    "HidePage=document.getElementById(""" & HidePage.ClientID & """);" & vbCrLf & _
    "ListItems=document.getElementById(""" & ListItems.ClientID & """);" & vbCrLf & _
    "Enter=document.getElementById(""" & Enter.ClientID & """);" & vbCrLf & _
    "AddPage=document.getElementById(""" & AddPage.ClientID & """);" & vbCrLf & _
    "EditPage=document.getElementById(""" & EditPage.ClientID & """);" & vbCrLf & _
    "AddItem=document.getElementById(""" & AddItem.ClientID & """);" & vbCrLf & _
    "RemoveItem=document.getElementById(""" & RemoveItem.ClientID & """);" & vbCrLf & _
    "ListItems=document.getElementById(""" & ListItems.ClientID & """);" & vbCrLf & _
    "JoinPrevious=document.getElementById(""" & JoinPrevious.ClientID & """);" & vbCrLf

    Code &= ReadAll(MapPath(ScriptsResources & "/" & "pagesmanager.js"))

    Code = CodeMsg & Code

    Return Components.Script(Code, ScriptLanguage.javascript)
  End Function

  Sub ReplacePlaceHolder()
    PlaceHolder1.Controls.Add(IconUnicode(IconName.ArrowUp, , Phrase(Setting.Language, 3005), "javascript:moveup()"))
    PlaceHolder2.Controls.Add(IconUnicode(IconName.ArrowDown, , Phrase(Setting.Language, 3006), "javascript:movedown()"))
    PlaceHolder3.Controls.Add(IconUnicode(IconName.ArrowLeft, , Phrase(Setting.Language, 3007), "javascript:declevel()"))
    PlaceHolder4.Controls.Add(IconUnicode(IconName.ArrowRight, , Phrase(Setting.Language, 3008), "javascript:inclevel()"))
  End Sub

  Private Sub SetVisualization()
    'Put user code to initialize the page here
		If Archive = 0 Then
      BlockPanel.Visible = False
			If Setting.Archive IsNot Nothing Then
				Dim Box As New WebControl(HtmlTextWriterTag.Div)
				Box.CssClass = "Menu"

				For Each Archive As Integer In Setting.Archive
					If Archive <> 0 Then
            Dim Menu As Menu = Menu.Load(Archive, Setting.Language)
            Dim Text As String = Phrase(Setting.Language, 3015) & " " & Menu.Name
						Dim Link As String = Href(Setting.Name, False, "pagesmanager.aspx", "archive", Archive, "lng", Setting.Language)
						Box.Controls.Add(Components.Folder(Text, Phrase(Setting.Language, 52), Link, Setting))
					End If
				Next
        Dim Content As Control = MasterPage.ContentPlaceHolder
				Content.Controls.Add(Box)
			End If
		Else
      BlockPanel.Visible = True
      Dim Items As Collections.Generic.List(Of ItemMenu) = MenuManager.Menu.Load(Archive, Language).ItemsMenu
			If Not Items Is Nothing Then
				For Each Item As ItemMenu In Items
					Dim ListItem As New WebControls.ListItem
					ListItem.Text = Space(Item.Level) & Trim(Item.Description.Label)
					ListItem.Value = Item.Record
					ListItems.Items.Add(ListItem)
				Next
			End If
			MessageAlert.Text = Phrase(Setting.Language, 3016)
			ReplacePlaceHolder()
      BlockPanel.Controls.Add(Script)
			MasterPage.Blink(Enter)
		End If
  End Sub

  Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    SetVisualization()
  End Sub

  Private Sub Enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enter.Click
    Submit()
    MasterPage.AddMessage(Setting, 3021)
  End Sub

  Private Sub AddPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPage.Click
    Submit()
    Response.Redirect("edit.aspx?ss=" & Setting.Name & "&archive=" & Archive & "&lng=" & Language)
  End Sub

  Private Sub Submit()
    Dim Code As String = CodeMenu.Value
		Dim File As String = MenuManager.Menu.File(Archive, Language)
    WriteAll(Code, File)
		Dim MenuObj As Menu = MenuManager.Menu.Load(Archive, Language)
		MenuObj.UpdateItemsMenu()
		Polling.UpdateDefaultLinks.start()
  End Sub

  Private Sub EditPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPage.Click
    Submit()
    'Response.Redirect("edit.aspx?ss=" & Setting.Name & "&archive=" & Archive & "&lng=" & Language & "&page=" & PageSelect.Value)
    Response.Redirect(Href(Setting.Name, False, "edit.aspx", "archive", Archive, "lng", Language, "page", PageSelect.Value))
  End Sub
End Class
