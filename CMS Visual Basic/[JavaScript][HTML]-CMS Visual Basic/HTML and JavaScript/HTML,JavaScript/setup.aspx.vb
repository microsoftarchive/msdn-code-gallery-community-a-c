'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Imports WebApplication


Partial Class SubSiteEditor
	Inherits System.Web.UI.Page
	Const Webmaster As User.RoleType = Authentication.User.RoleType.WebMaster
	Private Setting As Config.SubSite									 'Current setting
	Private Config As Config.SubSite									 'Setting to intend edit
	Private Added As Object
	Private AddAction As AddActionType
	Private CurrentUser As User
	Private MasterPage As MasterPage
	Enum AddActionType
		None
		Menu
		Forum
		Album
	End Enum

	Protected WithEvents Table9 As System.Web.UI.HtmlControls.HtmlTable
	Private Const PreClientId As String = "ctl00$ContentPlaceHolder1$"

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		CurrentUser = Authentication.CurrentUser
		Setting = CurrentSetting()

		If CurrentUser.Role(Setting.Name) < Authentication.User.RoleType.Administrator Then
			Response.Redirect(Href(Setting.Name, False, "default.aspx"), True)
		End If

		MasterPage = SetMasterPage(Me, , False, False)
		If Not Request("config") Is Nothing Then
			Config = SubSite.Load(Request("config"))
		Else
			Config = Setting
		End If
	End Sub
	Private PluginIdCorrespondence As New Collections.Specialized.StringDictionary
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("MessageSetupSave") IsNot Nothing Then
      MasterPage.AddMessage(Setting, Session("MessageSetupSave"))
			Session("MessageSetupSave") = Nothing
		End If

		'Find Name of Plugin in HomePage
    Dim PluginInHomePage As String = Nothing
		If IsPostBack Then
			For Each Key As String In Request.Form.Keys
				Dim Value As String = Request.Form(Key)
				If Value.StartsWith("PluginInHomePage_") Then
					PluginInHomePage = Value.Substring(17)
					Exit For
				End If
			Next
		End If

		Dim Webmaster As Boolean
		If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster Then
			Webmaster = True
			Dim C4 As New HtmlControls.HtmlTableCell
			Dim Label As New Label
			Label.Text = Phrase(Setting.Language, 155)
			Label.Style.Add("font-weight", "bold")
			C4.Controls.Add(Label)
			Me.TablePlugins.Rows(1).Cells.Add(C4)
		End If

		Dim Plugins As Collections.Generic.List(Of PluginManager.Plugin) = AllPlugins()
		Plugins.Sort(AddressOf PluginComparer)

		PluginLabel.Text = "(" & Phrase(Setting.Language, 420) & "/" & Phrase(Setting.Language, 421) & ") " & Phrase(Setting.Language, 149)
		For Each Plugin As PluginManager.Plugin In Plugins
			If Plugin.Characteristic <> Plugin.Characteristics.CorePlugin Then
				If Plugin.IsAccessible(CurrentUser, Config) Then
					Dim Row As HtmlControls.HtmlTableRow
          Dim C1 As HtmlControls.HtmlTableCell = Nothing, C2 As HtmlControls.HtmlTableCell = Nothing, C3 As HtmlControls.HtmlTableCell = Nothing, C4 As HtmlControls.HtmlTableCell = Nothing
					Row = New HtmlControls.HtmlTableRow
					Me.TablePlugins.Controls.Add(Row)
					C1 = New HtmlControls.HtmlTableCell
					C2 = New HtmlControls.HtmlTableCell
					C3 = New HtmlControls.HtmlTableCell
					Row.Controls.Add(C1)
					Row.Controls.Add(C2)
					Row.Controls.Add(C3)
					If Webmaster Then
						'Add shared configuration
						C4 = New HtmlControls.HtmlTableCell
						Row.Controls.Add(C4)
					End If

          Dim ShortDescription As String = Plugin.Description(Setting.Language)
          Dim LongDescription As String = Plugin.Description(Setting.Language, False)
          If Plugin.Characteristic = PluginManager.Plugin.Characteristics.AlwaysEnabled Then
            Dim Label As Label
            Label = New Label
            Label.Text = HttpUtility.HtmlEncode(ShortDescription)
            Label.ToolTip = HttpUtility.HtmlEncode(ShortDescription)
            C1.Controls.Add(Label)
          Else
            Dim Cb As CheckBox
            Cb = New CheckBox
            Cb.Text = HttpUtility.HtmlEncode(ShortDescription)
            Cb.ToolTip = EncodingAttribute(LongDescription)
            Dim Name As String = "plugin_" & Plugin.Name
            Cb.ID = Name
            C1.Controls.Add(Cb)
            PluginIdCorrespondence.Add(Plugin.Name, Cb.UniqueID)
            If IsPostBack AndAlso Request(Cb.UniqueID) IsNot Nothing Then
              Select Case Request(Cb.UniqueID)
                Case "on"
                  Cb.Checked = True
                Case Else
                  Cb.Checked = False
              End Select
            Else
              Cb.Checked = Plugin.IsEnabled(Config)
            End If
          End If

          If LongDescription <> "" AndAlso LongDescription <> ShortDescription Then
            Dim Label As Label = New Label
            Label.Style.Add("font-size", "smaller")
            Label.Text = HttpUtility.HtmlEncode(LongDescription)
            UrlToLink(Label.Text, Nothing, Nothing, True)
            C1.Controls.Add(BR)
            C1.Controls.Add(Label)
          End If


          Dim Op As RadioButton
          Op = New RadioButton
          Op.GroupName = "HomePage"
          Op.ID = "PluginInHomePage_" & Plugin.Name
          If Not Plugin.SelectableAsHomePage Then
            Op.Enabled = False
          End If
          C2.Controls.Add(Op)
          If IsPostBack Then
            If Plugin.Name = PluginInHomePage Then
              Op.Checked = True
            Else
              Op.Checked = False
            End If
          Else
            Op.Checked = Config.PluginInHomePage = Plugin.Name
          End If
          If Plugin.IsAccessible(CurrentUser, Setting) Then
            If Plugin.EditObjectParametersForInheritSubSite IsNot Nothing Then
              'Add config button for the plugin
              Dim ConfigButton As Control = Button(Setting, Phrase(Setting.Language, 3025), Href(Setting.Name, False, "configeditor.aspx", "plugin", Plugin.Name), , IconType.ControlPanel, "_blank")
              C3.Controls.Add(ConfigButton)
            End If
            If Webmaster AndAlso Plugin.EditObjectParametersForSharedConfiguration IsNot Nothing Then
              Dim ConfigButton As Control = Button(Setting, Phrase(Setting.Language, 155), Href(Setting.Name, False, "configeditor.aspx", "plugin", Plugin.Name, "shared", True), , IconType.ControlPanel, "_blank")
              C4.Controls.Add(ConfigButton)
            End If
          End If
        End If
      End If
    Next
	End Sub

	Function PluginComparer(x As PluginManager.Plugin, y As PluginManager.Plugin) As Integer
		Return StrComp(x.Description(Setting.Language), y.Description(Setting.Language), CompareMethod.Text)
	End Function


	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    If StrComp(Config.Name, "default", CompareMethod.Binary) = 0 Then
      PanelSetup.Visible = False
      If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
        MasterPage.Blink(NewSetup)
        MasterPage.Blink(NameNewSetup)
      End If
    Else
      If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
        MasterPage.Blink(Save)
      End If
      LoadSetup(Config)
    End If

    If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster Then
      LoadDomain()
    Else
      HostSetting.Visible = False
    End If
  End Sub

  Private Sub SaveSetup(ByRef Setup As SubSite)

    If Page.IsValid Then
      Dim UpdateDefaultLinks As Boolean
      If Join(Setup.CorrelatedWords.Words, ",") <> CorrelatedWords.Text Then
        UpdateDefaultLinks = True
      End If
      Setup.Title = TitleField.Text
      Setup.Description = Description.Text
      Setup.KeyWords = KeyWords.Text
      Setup.CorrelatedWords.Words = Split(CorrelatedWords.Text, ",")
      Dim Status As SubSite.CerrelatedStructure.CorrelatedStatus
      If CW_Enabled.Checked Then
        Status = SubSite.CerrelatedStructure.CorrelatedStatus.Enabled
      ElseIf CW_SameDomain.Checked Then
        Status = SubSite.CerrelatedStructure.CorrelatedStatus.Context
      ElseIf CW_NotEnabled.Checked Then
        Status = SubSite.CerrelatedStructure.CorrelatedStatus.NotEnabled
      End If
      If Setup.CorrelatedWords.Status <> Status Then
        Setup.CorrelatedWords.Status = Status
        UpdateDefaultLinks = True
      End If
      'Setup.Email = Email.Text
      Setup.Currency = Currency.Text
      'Setup.Language = Language.SelectedValue	 'Work correctly only if EnableViewStateMac="false"
      Setup.Language = Request.Form(Language.UniqueID)
      'Setup.IdSkin = Skin.SelectedItem.Text
      Setup.IdSkin = Request.Form(Skin.UniqueID)
      Setup.Contacts = EnableContacts.Checked
      Setup.AboutUs = AboutUs.Checked
      Setup.UsersOnline = UsersOnline.Checked
      Setup.EnableRelatedBlogAggregator = EnableRelatedBlogAggregator.Checked

      Setup.PluginInHomePage = Nothing
      'Find Name of Plugin in HomePage
      For Each Key As String In Request.Form.Keys
        Dim Value As String = Request.Form(Key)
        If Value.StartsWith("PluginInHomePage_") Then
          Setup.PluginInHomePage = Value.Substring(17)
          Exit For
        End If
      Next

      'Save plugin
      For Each Plugin As PluginManager.Plugin In AllPlugins()
        If Plugin.Characteristic <> Plugin.Characteristics.CorePlugin AndAlso Plugin.Characteristic <> Plugin.Characteristics.AlwaysEnabled Then
          If Plugin.IsAccessible(CurrentUser, Config) Then
            Select Case Request(PluginIdCorrespondence(Plugin.Name))
              Case "on"
                Plugin.IsEnabled(Setting) = True
              Case Else
                Plugin.IsEnabled(Setting) = False
            End Select
          End If
        End If
      Next

      Setup.Aspect.FirstDocumentInHomePage = FirstDocumentInHomePage.Checked

      'Setting news
      NewsRSS.Text = Trim(NewsRSS.Text)
      NewsWords.Text = Trim(NewsWords.Text)
      NewsNotWords.Text = Trim(NewsNotWords.Text)
      If NewsRSS.Text <> "" Or NewsWords.Text <> "" Or NewsNotWords.Text <> "" Then
        Dim News As New FilterNews
        If NewsRSS.Text <> "" Then
          Dim Feeds As String = ReplaceBin(NewsRSS.Text, ",http", vbCr & "http")
          News.SourcesRSS = Split(Feeds, vbCr)
        End If
        If NewsWords.Text <> "" Then
          News.KeyWords = Split(NewsWords.Text, ",")
        End If
        If NewsNotWords.Text <> "" Then
          News.NotKeywords = Split(NewsNotWords.Text, ",")
        End If
        Setup.News = News
      Else
        Setup.News = Nothing
      End If

      Dim Elements As Integer

      'Menus
      Elements = Request.Form(NMenu.UniqueID)
      Dim Archives() As Integer = Nothing
      If Elements Then
        For N As Integer = 1 To Elements
          Dim Archive As Integer = Request.Form(PreClientId & "ListArchive" & N)
          If Archive > 0 Then 'Archive 0 is reserved for inside use
            If Archives Is Nothing Then
              ReDim Archives(0)
            Else
              ReDim Preserve Archives(Archives.GetUpperBound(0) + 1)
            End If
            Archives(Archives.GetUpperBound(0)) = Archive
          End If
        Next
      End If
      Setup.Archive = Archives

      'Forums
      Elements = Request.Form(NForum.UniqueID)
      Dim Forums() As Integer = Nothing
      If Elements Then
        For N As Integer = 1 To Elements
          Dim ForumId As Integer = Request.Form(PreClientId & "ListForum" & N)
          If Forums Is Nothing Then
            ReDim Forums(0)
          Else
            ReDim Preserve Forums(Forums.GetUpperBound(0) + 1)
          End If
          Forums(Forums.GetUpperBound(0)) = ForumId

          If Setup.Forums Is Nothing OrElse Setup.Forums IsNot Nothing AndAlso (Setup.Forums.Count < Forums.Count OrElse Setup.Forums(N - 1) = Forums(N - 1)) Then
            Dim Forum As Forum = ForumManager.Forum.Load(ForumId)
            Dim Name As String = Request.Form(PreClientId & "NameForum" & N)
            Dim Descriprion As String = Request.Form(PreClientId & "DescriptionForum" & N)
            If Name <> "" OrElse Descriprion <> "" Then
              If Forum.Name <> Name OrElse Forum.Description <> Descriprion Then
                Forum.Name = Name
                Forum.Description = Descriprion
                Forum.Save()
              End If
            End If
          End If
        Next
      End If
      Setup.Forums = Forums

      'Weathers
      Elements = Request.Form(NWeather.UniqueID)
      Dim Weathers() As WeatherLocality = Nothing
      If Elements Then
        For N As Integer = 1 To Elements
          Dim Weather As New WeatherLocality(Request.Form(PreClientId & "WeatherCode" & N), Request.Form(PreClientId & "WeatherLocality" & N))
          If Weathers Is Nothing Then
            ReDim Weathers(0)
          Else
            ReDim Preserve Weathers(Weathers.GetUpperBound(0) + 1)
          End If
          Weathers(Weathers.GetUpperBound(0)) = Weather
        Next
      End If
      Setup.Weathers = Weathers

      'Album
      Elements = Request.Form(NAlbum.UniqueID)
      Dim Albums As New StringCollection
      If Elements Then
        For N As Integer = 1 To Elements
          Dim Album As String = Request.Form(PreClientId & "ListAlbum" & N)
          Albums.Add(Album)
        Next
      End If
      Setup.PhotoAlbums = Albums

      Setup.Save()

      'Replece current setting used for the User
      If Setting.Name = Setup.Name Then
        Setting = Setup
      End If
      'Session is notting if cookie is disable
      If Not Session Is Nothing Then
        'Replace current hold configuration
        If Not Session("SubSite") Is Nothing Then
          If Session("SubSite").name = Setup.Name Then
            Session("SubSite") = Setup
          End If
        End If
      End If

      If UpdateDefaultLinks Then
        Polling.UpdateDefaultLinks.Start()
      End If

      'Message.Controls.Add(Components.Message(Setting.Language, 1332))
      Session("MessageSetupSave") = 1332
    Else
      'Message.Controls.Add(Components.Message(Setting.Language, 404))
      Session("MessageSetupSave") = 404
    End If
  End Sub

  Private Sub LoadSetup(ByVal Setup As SubSite)
    If CurrentUser.Role(Config.Name) < Webmaster Then
      AddMenu.Visible = False
      AddForum.Visible = False
      AddAlbum.Visible = False
    End If

    'Language select
    For Each LN As LanguageManager.Language In LanguagesUsed
      Dim ListItem As New WebControls.ListItem
      ListItem.Text = LanguageDefinition(LN, Setting.Language)
      ListItem.Value = LN
      'If LN = Setup.Language Then
      'ListItem.Selected = True
      'End If
      Language.Items.Add(ListItem)
    Next

    'Skin select
    For Each Skin As String In AllSkinID()
      Dim ListItem As New WebControls.ListItem
      ListItem.Text = FirstUpper(Skin)
      'If String.Compare(Skin, Setup.Skin.Id, True) = 0 Then
      'ListItem.Selected = True
      'End If
      Me.Skin.Items.Add(ListItem)
    Next


    If IsPostBack Then
      Me.Language.SelectedValue = Request.Form(Language.UniqueID)
      Me.Skin.SelectedValue = Request.Form(Skin.UniqueID)
    Else
      Me.Language.SelectedValue = Setup.Language
      Me.Skin.SelectedValue = Setup.Skin.Id


      Name.Text = Setup.Name
      TitleField.Text = Setup.Title
      Description.Text = Setup.Description
      KeyWords.Text = Setup.KeyWords
      If Not Setup.CorrelatedWords.Words Is Nothing Then
        CorrelatedWords.Text = Join(Setup.CorrelatedWords.Words, ",")
      End If
      Select Case Setup.CorrelatedWords.Status
        Case SubSite.CerrelatedStructure.CorrelatedStatus.Enabled
          CW_Enabled.Checked = True
        Case SubSite.CerrelatedStructure.CorrelatedStatus.Context
          CW_SameDomain.Checked = True
        Case SubSite.CerrelatedStructure.CorrelatedStatus.NotEnabled
          CW_NotEnabled.Checked = True
      End Select
      'Email.Text = Setup.Email
      Currency.Text = Setup.Currency
      EnableContacts.Checked = Setup.Contacts
      AboutUs.Checked = Setup.AboutUs
      UsersOnline.Checked = Setup.UsersOnline
      EnableRelatedBlogAggregator.Checked = Setup.EnableRelatedBlogAggregator
      FirstDocumentInHomePage.Checked = Setup.Aspect.FirstDocumentInHomePage

      If Not Setup.News Is Nothing Then
        NewsRSS.Text = Join(Setup.News.SourcesRSS, ",")
        NewsWords.Text = Join(Setup.News.KeyWords, ",")
        NewsNotWords.Text = Join(Setup.News.NotKeywords, ",")
      End If

    End If

    AddSetupMenus(Setup)
    AddSetupForums(Setup)
    AddSetupWeathers(Setup)
    AddSetupAlbum(Setup)
  End Sub
  Private Sub AddSetupMenus(ByVal Setup As SubSite)
    'Request n. menues
    Dim NMenu As Integer
    If IsPostBack Then
      NMenu = Request.Form(Me.NMenu.UniqueID)
      If AddAction = AddActionType.Menu Then
        NMenu += 1
      End If
    Else
      If Setup.Archive Is Nothing Then
        NMenu = 0
      Else
        NMenu = Setup.Archive.Length
      End If
    End If
    AddElements(Me.NMenu, 20, NMenu)

    Dim Table As HtmlTable = Nothing
    If NMenu Then
      Table = Components.Table(NMenu + 1, 1, , , True)
      Table.Rows(0).Cells(0).InnerHtml = Phrase(Setting.Language, 3015)
      Menus.Controls.Add(Table)
      'Else
      'QUI IL VIDEO NON VA MESSO! Poi la pagina da errore se quando si preme conferma 
      '	'Add video tutorial with instructions about first startup
      '	Dim MasterPage As MasterPage = Page.Master
      '	MasterPage.ContentPlaceHolder.Parent.Controls.AddAt(0, VideoObject("r3qKK5Wq1ko", Setting, HttpContext.Current))
    End If
    Dim Archives As Archive() = AllArchives()

    For N As Integer = 1 To NMenu
      Dim ListArchive As New WebControls.DropDownList
      ListArchive.ID = "ListArchive" & N
      Table.Rows(N).Cells(0).Controls.Add(ListArchive)

      Dim IDArchive As Integer
      Try
        If IsPostBack Then
          If AddAction = AddActionType.Menu And N = NMenu Then
            IDArchive = Added
          Else
            IDArchive = Request.Form(ListArchive.UniqueID)
          End If
          If IDArchive = 0 Then
            IDArchive = 1
          End If

        Else
          IDArchive = Setup.Archive(N - 1)
        End If
      Catch ex As Exception
      End Try

      Dim None As New WebControls.ListItem
      None.Text = Phrase(Setting.Language, 3066)
      None.Value = -1
      ListArchive.Items.Add(None)

      For Each Archive As Archive In Archives
        Dim ListItemArchive As New WebControls.ListItem
        If Archive.ID = IDArchive Then
          ListItemArchive.Selected = True
        End If
        ListItemArchive.Text = Archive.Name(Setup.Language, True)
        ListItemArchive.Value = Archive.ID
        ListArchive.Items.Add(ListItemArchive)
      Next
    Next

    If Setup.Archive IsNot Nothing Then
      For Each Item As Integer In Setup.Archive
        If Item Then
          Dim Button = Components.Button(Setting, Phrase(Setting.Language, 3018), Href(Setting.Name, False, "pagesmanager.aspx"), , Components.IconType.ControlPanel, "_balnk")
          Menus.Controls.Add(Button)
          Exit For
        End If
      Next
    End If

  End Sub
  Private Sub AddSetupForums(ByVal Setup As SubSite)
    Dim Nforum As Integer
    If IsPostBack Then
      Nforum = Request.Form(Me.NForum.UniqueID)
      If AddAction = AddActionType.Forum Then
        Nforum += 1
      End If
    Else
      If Setup.Forums Is Nothing Then
        Nforum = 0
      Else
        Nforum = Setup.Forums.Length
      End If
    End If
    'Request n. mforums
    AddElements(Me.NForum, 20, Nforum)

    'Dim nm As Integer = Setup.Menus.GetUpperBound(0)
    Dim Table As HtmlTable = Nothing
    If Nforum Then
      Table = Components.Table(Nforum + 1, 3, , , True)
      Table.Rows(0).Cells(0).InnerHtml = Phrase(Setting.Language, 61)
      Table.Rows(0).Cells(1).InnerHtml = Phrase(Setting.Language, 101)
      Table.Rows(0).Cells(2).InnerHtml = Phrase(Setting.Language, 102)
      Me.Forums.Controls.Add(Table)
    End If
    Dim Forums As ForumManager.Forum() = AllForums()
    For n As Integer = 1 To Nforum
      'Add list forum
      Dim ListForum As New WebControls.DropDownList
      ListForum.ID = "ListForum" & n
      Table.Rows(n).Cells(0).Controls.Add(ListForum)

      Dim Name As New WebControls.TextBox
      Name.ID = "NameForum" & n
      Table.Rows(n).Cells(1).Controls.Add(Name)

      Dim Description As New WebControls.TextBox
      Description.ID = "DescriptionForum" & n
      Table.Rows(n).Cells(2).Controls.Add(Description)

      Dim IDForum As Integer
      Dim NameForum As String = Nothing
      Dim DescriptionForum As String = Nothing
      Try
        If IsPostBack Then
          If AddAction = AddActionType.Forum And n = Nforum Then
            Dim Forum As Forum = Forum.Load(Added)
            IDForum = Forum.ID
            NameForum = Forum.Name
            DescriptionForum = Forum.Description
          Else
            IDForum = Request.Form(ListForum.UniqueID)
            NameForum = Request.Form(Name.UniqueID)
            DescriptionForum = Request.Form(Description.UniqueID)
          End If
        Else
          Dim Forum As Forum = Forum.Load(Setup.Forums(n - 1))
          IDForum = Forum.ID
          NameForum = Forum.Name
          DescriptionForum = Forum.Description
        End If
      Catch ex As Exception
      End Try
      If Forums IsNot Nothing Then
        For Each Forum As ForumManager.Forum In Forums
          Dim ListItemForum As New WebControls.ListItem
          If Forum.Id = IDForum Then
            ListItemForum.Selected = True
          End If
          ListItemForum.Text = Forum.Id
          If Not Forum.Name Is Nothing Then
            ListItemForum.Text &= " - " & Forum.Name
          End If
          ListItemForum.Value = Forum.Id
          ListForum.Items.Add(ListItemForum)
        Next
      End If
      Name.Attributes.Add("size", 15)
      Name.Text = NameForum
      Description.Attributes.Add("size", 15)
      Description.Text = DescriptionForum
    Next
  End Sub

  Private Sub AddSetupWeathers(ByVal Setup As SubSite)

    Dim NWeather As Integer
    If IsPostBack Then
      NWeather = Request.Form(Me.NWeather.UniqueID)
    Else
      If Setup.Weathers Is Nothing Then
        NWeather = 0
      Else
        NWeather = Setup.Weathers.GetUpperBound(0) + 1
      End If
    End If
    'Request n. elements
    AddElements(Me.NWeather, 20, NWeather)


    'Dim nm As Integer = Setup.Weathers.GetUpperBound(0)
    Dim Table As HtmlTable = Nothing
    If NWeather Then
      Table = Components.Table(NWeather + 1, 2, , , True)
      Table.Rows(0).Cells(0).InnerHtml = "WOEID"
      Table.Rows(0).Cells(1).InnerHtml = Phrase(Setting.Language, 3031)
      Me.Weathers.Controls.Add(Table)
    End If

    For n As Integer = 1 To NWeather

      Dim WeatherCode As New WebControls.TextBox
      WeatherCode.ID = "WeatherCode" & n
      Table.Rows(n).Cells(0).Controls.Add(WeatherCode)

      Dim WeatherLocality As New WebControls.TextBox
      WeatherLocality.ID = "WeatherLocality" & n
      Table.Rows(n).Cells(1).Controls.Add(WeatherLocality)

      Dim WeatherCodeMeteo As String = Nothing
      Dim LocalityMeteo As String = Nothing
      Try
        If IsPostBack Then
          WeatherCodeMeteo = Request.Form(WeatherCode.UniqueID)
          LocalityMeteo = Request.Form(WeatherLocality.UniqueID)
        Else
          WeatherCodeMeteo = Setup.Weathers(n - 1).WeatherCode
          LocalityMeteo = Setup.Weathers(n - 1).LocalityName
        End If
      Catch ex As Exception
      End Try

      'Add field WeatherCode 
      WeatherCode.Attributes.Add("size", 9)
      WeatherCode.MaxLength = 8
      WeatherCode.Text = WeatherCodeMeteo
 
      'Add field Locality
      WeatherLocality.Attributes.Add("size", 15)
      WeatherLocality.Text = LocalityMeteo
 
    Next
  End Sub

  Private Sub AddSetupAlbum(ByVal Setup As SubSite)
    If CurrentUser.Role(Config.Name) >= Webmaster Then
      AlbumSetup.Text = Phrase(Setting.Language, 52, 103)
      AlbumSetup.NavigateUrl = Common.Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, "default")
    Else
      AlbumSetup.Visible = False
    End If
    'Find all Localitys in Database

    Dim Albums As Collections.Generic.List(Of PhotoAlbum)
    Albums = New PhotoAlbum().PhotoAlbums

    Dim NAlbum As String
    If IsPostBack Then
      NAlbum = Request.Form(Me.NAlbum.UniqueID)
      If AddAction = AddActionType.Album Then
        NAlbum += 1
      End If
    Else
      If Setup.PhotoAlbums Is Nothing Then
        NAlbum = 0
      Else
        NAlbum = Setup.PhotoAlbums.Count
      End If
    End If
    'Request n. elements
    AddElements(Me.NAlbum, 5, NAlbum)


    Dim Table As HtmlTable = Nothing
    If NAlbum Then
      Table = Components.Table(NAlbum + 1, 1, , , True)
      Table.Rows(0).Cells(0).InnerHtml = Phrase(Setting.Language, 103)
      Me.Albums.Controls.Add(Table)
    End If
    For n As Integer = 1 To NAlbum
      'Add list Album
      Dim List As New WebControls.DropDownList
      List.ID = "ListAlbum" & n
      Table.Rows(n).Cells(0).Controls.Add(List)

      Dim NameAlbum As String = Nothing
      Try
        If IsPostBack Then
          If AddAction = AddActionType.Album And n = NAlbum Then
            NameAlbum = Added
          Else
            NameAlbum = Request(List.UniqueID)
          End If
        Else
          NameAlbum = Setup.PhotoAlbums(n - 1)
        End If
        NameAlbum = ReplaceBin(NameAlbum, "\", "/") 'Retrocompatibility name album format
      Catch ex As Exception
      End Try

      For Each Album As PhotoAlbum In Albums
        Dim ListItem As New WebControls.ListItem
        If Album.Name = NameAlbum Then
          ListItem.Selected = True
        End If
        ListItem.Text = "(" & Album.Name & ")"
        If Album.Title(Setup.Language) <> "" Then
          ListItem.Text = Album.Title(Setup.Language) & " - " & ListItem.Text
        End If

        ListItem.Value = Album.Name
        List.Items.Add(ListItem)
      Next
    Next
  End Sub

  Sub AddElements(ByVal List As WebControls.DropDownList, ByVal Elements As Integer, ByVal Selected As Integer)
    For n As Integer = 0 To Elements
      Dim ListItem As New WebControls.ListItem
      ListItem.Text = n
      ListItem.Value = n
      If n = Selected Then
        ListItem.Selected = True
      End If
      List.Items.Add(ListItem)
    Next
  End Sub

  Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
    SaveSetup(Config)
    Response.Redirect(AbsoluteUri(Request), True)
  End Sub

  Sub LoadDomain()
    Label30.Text = Phrase(Setting.Language, 3025) & " " & DomainName(Request)
    'Dim FirstItem As New System.Web.UI.WebControls.ListItem
    'FirstItem.Text = Phrase(Setting.Language, 3066)
    'FirstItem.Value = ""
    'ListSetups.Items.Add(FirstItem)

    ListSetups.Items.Clear()
    Dim Domain As DomainConfiguration = CurrentDomainConfiguration()
    Dim [Default] As String = SubSite.DefaultSiteConfiguration
    For Each SubSiteName As String In AllSubSiteNames()
      If StrComp(SubSiteName, [Default], CompareMethod.Text) <> 0 Then
        Dim Item As New System.Web.UI.WebControls.ListItem
        Item.Text = SubSiteName
        If Domain.SubSitesAvailable.Contains(SubSiteName) Then
          Item.Attributes.Add("style", "font-weight: bold")
          Item.Attributes.Add("class", "Evidence")
        Else
          Item.Attributes.Add("style", "text-decoration: line-through")
        End If
        Item.Value = SubSiteName
        If SubSiteName = Config.Name Then
          Item.Selected = True
        End If
        ListSetups.Items.Add(Item)
      End If
    Next
    If ListSetups.Items.Count = 0 Then
      TableDomain.Rows(1).Visible = False
      'ListSetups.Enabled = False
      'SelectSetup.Enabled = False
      'RemoveSetup.Enabled = False
      'DeleteSetup.Enabled = False
    End If
  End Sub

  Private Sub SelectSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectSetup.Click
    If CurrentUser.Role(Setting.Name) >= Webmaster Then
      AddSutupForDomain(Request.Form(ListSetups.UniqueID))
      Response.Redirect(Href(Request.Form(ListSetups.UniqueID), False, "setup.aspx"), True)
    End If
  End Sub

  Private Sub AddSutupForDomain(ByVal Setup As String)
    CurrentDomainConfiguration.AddSubSite(Setup)
  End Sub

  Protected Sub RemoveSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveSetup.Click
    If CurrentUser.Role(Setting.Name) >= Webmaster Then
      RemoveSutupForDomain(Request.Form(ListSetups.UniqueID))
    End If
  End Sub

  Protected Sub DeleteSetup_Click(sender As Object, e As System.EventArgs) Handles DeleteSetup.Click
    If CurrentUser.Role(Setting.Name) >= Webmaster Then
      Dim NameSetup As String = Request.Form(ListSetups.UniqueID)
      If NameSetup <> SubSite.DefaultSiteConfiguration Then
        Dim CurrentDomainName As String = CurrentDomain()
        'Don't delete if is used into other domain 
        Dim IsUsed As Boolean
        For Each DomainName As String In AllDomainNames()
          If DomainName <> CurrentDomainName Then
            Dim DomainConfiguration As DomainConfiguration = DomainConfiguration.Load(DomainName)
            If DomainConfiguration.SubSitesAvailable.Contains(NameSetup) Then
              IsUsed = True
              Exit For
            End If
          End If
        Next
        If Not IsUsed Then
          SubSite.Delete(NameSetup)
        End If
        RemoveSutupForDomain(NameSetup)
      End If
    End If
  End Sub

  Private Sub RemoveSutupForDomain(ByVal Setup As String)
    Dim Domain As DomainConfiguration = CurrentDomainConfiguration()
    Domain.RemoveSubSite(Setup)

    Dim SetupRedirect As String
    If Domain.SubSitesAvailable.Contains(Me.Setting.Name) Then
      SetupRedirect = Me.Setting.Name
    Else
      If Domain.SubSitesAvailable.Count Then
        SetupRedirect = Domain.SubSitesAvailable(0)
      Else
        SetupRedirect = SubSite.DefaultSiteConfiguration
      End If
    End If

    Response.Redirect(Href(SetupRedirect, False, "setup.aspx"), True)
  End Sub

  Private Sub NewSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSetup.Click
    If CurrentUser.Role(Setting.Name) >= Webmaster Then
      Dim NameSetup As String = NameNewSetup.Text.ToLower
      If NameSetup = SubSite.DefaultSiteConfiguration Then
        MasterPage.AddMessage(Setting, 400, , , Components.MessageType.ErrorAlert)
      ElseIf Not IsAlphaNumeric(NameSetup) Then
        MasterPage.AddMessage(Setting, 425, , , Components.MessageType.ErrorAlert)
      ElseIf NameSetup.Length > NameNewSetup.MaxLength Then
        MasterPage.AddMessage(Setting, 426, , , Components.MessageType.ErrorAlert)
      ElseIf AllSubSiteNames.Contains(NameSetup) Then
        MasterPage.AddMessage(Setting, 427, , , Components.MessageType.ErrorAlert)
      Else
        Dim NewSetting As SubSite = SubSite.Load(NameSetup)
        If NewSetting.NotExist Then
          'Make a new subsite configuration
          NewSetting.Name = NameSetup
          NewSetting.Save()
          SubSite.Load(NameSetup) = NewSetting
          AllSubSiteNames.Add(NameSetup)
          AddSutupForDomain(NewSetting.Name)

          If AllDomainNames.Count = 1 Then
            If AllArchives.Count = 0 Then 'Archeve 1 is the default global archive
              'Create the first archive if don't exists
              Dim Archive As Archive = NewArchive()
            End If
            'Assigne the first archive to new setting
            Dim Archives As Archive() = AllArchives()
            If Archives.Count = 1 Then
              ReDim NewSetting.Archive(0)
              NewSetting.Archive(0) = Archives(0).ID
              NewSetting.Photoalbums.Add(AddNewAlbum(Phrase(Setting.Language, 103)))
              NewSetting.Save()
            End If
          End If

          Response.Redirect(Href(NewSetting.Name, False, "setup.aspx"), True)
        Else
          'Name exists
          MasterPage.AddMessage(Setting, 427, , , Components.MessageType.ErrorAlert)
        End If
      End If
    End If
  End Sub

  Private Sub NewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMenu.Click
    If CurrentUser.Role(Config.Name) >= Webmaster Then
      AddAction = AddActionType.Menu
      'Dim Name As String = IIf(NewMenuName.Text <> "", NewMenuName.Text, Config.Name)
      Dim Archive As Archive = NewArchive()
      Dim Menu As Menu = MenuManager.Menu.Load(Archive.ID, Config.Language)
      Menu.Create()
      'Me.NMenu.SelectedValue = Request.Form(Me.NMenu.UniqueID) + 1
      Added = Archive.ID
      AddMessage()
    End If
  End Sub

  Private Sub AddMessage()
    MasterPage.AddMessage(Setting, 418)
    MasterPage.AddMessage(Setting, 152, , "#save")
  End Sub

  Private Sub NewForum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewForum.Click
    If CurrentUser.Role(Config.Name) >= Webmaster Then
      AddAction = AddActionType.Forum
      Dim Name As String = IfStr(NewForumName.Text <> "", NewForumName.Text, Config.Name)
      Dim Forum As ForumManager.Forum = ForumManager.Forum.NewForum(Name, NewForumDescription.Text)
      'Me.NForum.SelectedValue = Request.Form(Me.NForum.UniqueID) + 1
      Added = Forum.Id
      AddMessage()
    End If
  End Sub

  Private Sub NewAlbum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewAlbum.Click
    If CurrentUser.Role(Config.Name) >= Webmaster Then
      AddAction = AddActionType.Album
      Added = AddNewAlbum(NewAlbumTitle.Text, NewAlbumDescription.Text)
      AddMessage()
    End If
  End Sub

  Function AddNewAlbum(Optional Title As String = Nothing, Optional Description As String = Nothing) As String
    Title = IfStr(Title <> "", Title, Config.Name)
    Dim Album As New PhotoAlbum

    Dim SubPhotoAlbum As PhotoManager.PhotoAlbum = Album.CreateSubFotoAlbum(CurrentUser, Config)
    SubPhotoAlbum.Title(Config.Language) = Title
    SubPhotoAlbum.Description(Config.Language) = Description
    'Property
    SubPhotoAlbum.SubPhotoAlbumsNotCreatable = False
    SubPhotoAlbum.AddPermitted = PhotoManager.Permission.Author
    SubPhotoAlbum.Deletable = PhotoManager.Permission.None
    SubPhotoAlbum.Editable = PhotoManager.EditablePermission.OnlyIfEmpty
    SubPhotoAlbum.IsRoot = True
    SubPhotoAlbum.Save()
    Return SubPhotoAlbum.Name
  End Function

  Protected Sub ExtraSetting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtraSetting.Click
    'Dim Save As SaveObjectMethod = Sub()
    '															 SaveConfiguration("config.xml")
    '															 End Sub
    Dim FilterExclude() As String = {"IdSkin", "AttributeArray", "Name", "Language", "FirstDocumentInHomePage", "Archive", "Forums", "Description", "Title", "AdSense", "Theme", "KeyWords", "CorrelatedWords", "News", "EnableRelatedBlogAggregator", "Currency", "Photoalbums", "AboutUs", "UsersOnline", "PluginInHomePage", "Weathers", "Contacts"}
    If CurrentUser.Role(Setting.Name) <= Authentication.User.RoleType.WebMaster Then
      ReDim Preserve FilterExclude(FilterExclude.Count)
      FilterExclude(UBound(FilterExclude)) = "ShareCorrelatedWords"
    End If
    EditObject(Config, AddressOf Config.Save, Phrase(Setting.Language, 151), , , , , , FilterExclude)
  End Sub

	Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
    AddMessage()
	End Sub

	Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
    AddMessage()
	End Sub

	Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
    AddMessage()
	End Sub

	Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
    AddMessage()
	End Sub
End Class
