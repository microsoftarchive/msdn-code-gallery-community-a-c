'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic

Namespace WebApplication
	Public Module MenuManager
		Class Menu
			Private Shared Cache As New Extension.Cache(AddressOf Load, 100, GetType(Menu))
			Public Archive As Integer
			Public Language As LanguageManager.Language
      Function Name(Optional ShortFormat As Boolean = False) As String
        Dim Text As String = Archive & ": "
        If CBool(ShortFormat) Then
          If CBool(ItemsMenu.Count) Then
            Dim Title As String = ItemsMenu(0).Description.Title
            Dim Label As String = ItemsMenu(0).Description.Label
            If Label <> "" Then
              Text &= Label
            End If
            If Title <> "" Then
              If Label <> "" Then
                Text &= " (" & Title & ")"
              Else
                Text &= Title
              End If
            End If
            Text = TruncateText(Text, 60)
          End If
        Else
          For Each ItemMenu As ItemMenu In ItemsMenu
            If ItemMenu.Level = 0 Then
              Text &= "\" & ItemMenu.Description.Label
            End If
          Next
        End If
        Return Text
      End Function
      Function Exists() As Boolean
        Return System.IO.File.Exists(File)
      End Function
			Sub Create()
				WriteAll("", Me.File)
			End Sub
			Shared Function File(ByVal Archive As Integer, ByVal Language As LanguageManager.Language) As String
				Return MapPath(ArchiveSubDirectory & "/" & Archive & "/" & 1 & ".menu." & Acronym(Language) & ".txt")
			End Function
			Function File() As String
				Return File(Me.Archive, Me.Language)
			End Function
			Sub New(ByVal Archive As Integer, ByVal Language As LanguageManager.Language)
				Me.Archive = Archive
				Me.Language = Language
			End Sub
			Public Sub UpdateItemsMenu()
				'Add new page to ItemsMenu and remove not exists pages
				Dim Dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(DirectoryName(Archive))
				If Dir.Exists Then

					Dim ItemsMenu As New ItemMenuCollection

					Dim Records As Array = Split(ReadAll(File(Archive, Language)), vbCrLf)
					'Add items of menu and removed record of not exists pages
					For Each Record As String In Records
						If Record <> "" Then
							Dim Item As ItemMenu = ItemMenu.Load(Record, Archive, Language)
							If Item IsNot Nothing Then
								'The page of item exists
								ItemsMenu.Add(Item)
							End If
						End If
					Next
					'Find new page added and add new page to menu
					Dim Find As String = "*." & Acronym(Me.Language) & ".htm"
					Dim Files As System.IO.FileInfo() = Dir.GetFiles(Find)
					If Not Files Is Nothing Then
						For Each File As System.IO.FileInfo In Files
							'aggiungi le voci che mancano
							Dim Page As Integer = Left(File.Name, InStr(File.Name, ".") - 1)
							Dim Item As ItemMenu
							Item = ItemsMenu.Page(Page)
							If Item Is Nothing Then
								Dim Code As String = FileManager.ReadAll(File.FullName)
								Dim MetaTags As New MetaTags(Code)
								If Item Is Nothing Then
									Item = New ItemMenu
									Item.IdPage = Page
									Item.Off = True
									Item.Level = 2
									Item.Language = Language
								End If
								Item.Description = New DescriptionType(MetaTags.Title, MetaTags.Description)
								ItemsMenu.Add(Item)
							End If
						Next
					End If

					Me.ItemsMenu = ItemsMenu
					Pipeline.NotifyChangement(GetType(Menu), Archive & " " & Language)

				End If
			End Sub

			Sub LevelAndCategoryItem(ByVal Page As Integer, ByRef Level As Integer, ByRef Category As Integer)
				For Each Item As ItemMenu In ItemsMenu
					If Item.Level <= 2 Then
						Category += 1
					End If
					If Item.IdPage = Page Then
						If Item.Level >= 3 Then
							Level = 1
						Else
							Level = 0
						End If
						Exit For
					End If
				Next
			End Sub

			Public ItemsMenu As New ItemMenuCollection

			Class ItemMenuCollection
				Inherits Collections.Generic.List(Of ItemMenu)
				Function Page(ByVal IdPage As Integer) As ItemMenu
					For Each Item As ItemMenu In Me
						If Item.IdPage = IdPage Then
							Return Item
						End If
					Next
          Return Nothing
        End Function
			End Class

			Private Shared Function Load(ByVal Key As String) As Menu
				Dim Params As String() = Split(Key)
				Dim Menu As Menu
				Menu = New Menu(Params(0), Params(1))
				Menu.UpdateItemsMenu()
				Return Menu
			End Function

			Shared Function Load(ByVal Archive As Integer, ByVal Language As LanguageManager.Language) As Menu
				Dim Key As String = Archive & " " & Language
				Return Cache(Key)
			End Function

			Function Trace(ByVal IdPage As Integer, ByVal DomainConfiguration As DomainConfiguration, ByRef SubSite As Config.SubSite, Optional ByRef ReturnMetaTags As MetaTags = Nothing, Optional ByRef ReturnSubject As String = Nothing) As Control()
				'Dim CtrlCollection As New Collections.Generic.List(Of Control)
				Dim Id As Integer = IndexItem(IdPage)
				Dim Level As Integer = ItemsMenu(Id).Level
				Dim ObjectTrace As New Trace
				For N As Integer = Id To 0 Step -1
					If N > 0 Then
						If ItemsMenu(N - 1).Level < Level Then
							Level = ItemsMenu(N - 1).Level
							If ItemsMenu(N - 1).Level < ItemsMenu(N).Level Then
								Dim ItemMenu As ItemMenu = ItemsMenu(N - 1)
								ObjectTrace.AddElement(ItemMenu.Description.Label, ItemMenu.Description.Title, ItemMenu.Href(DomainConfiguration, SubSite))
								If ReturnMetaTags IsNot Nothing Then
									Dim Title, Description As String
									Title = ItemMenu.Description.Label
									Description = ItemMenu.Description.Title
									If Title <> "" Then
										If ReturnSubject <> "" Then
											ReturnSubject &= ","
										End If
										ReturnSubject &= Title
									End If

									If Description <> "" Then
										If ReturnSubject <> "" Then
											ReturnSubject &= ","
										End If
										ReturnSubject &= Description
									End If

									If Description = "" Then
										Description = Title
									End If
                  ReturnMetaTags.Title = Title & IfStr(ReturnMetaTags.Title <> "", ":", "") & ReturnMetaTags.Title
                  ReturnMetaTags.Description = Description & IfStr(ReturnMetaTags.Description <> "", ":", "") & ReturnMetaTags.Description

									If ReturnMetaTags.KeyWords <> "" Then
										ReturnMetaTags.KeyWords &= ","
									End If
									ReturnMetaTags.KeyWords &= ItemMenu.Description.Label
									If ItemMenu.Description.Title <> "" Then
										ReturnMetaTags.KeyWords &= "," & ReturnMetaTags.Title
									End If
								End If
							End If
						End If
					End If
				Next

				Return ObjectTrace.Controls(True)
			End Function

			Function Control(ByVal DomainConfiguration As DomainConfiguration, ByRef SubSite As Config.SubSite, Optional ByVal RestrictToIdPage As Integer = 0) As Control
				'If Not Menu Is Nothing Then
				Dim CtrlMenu As New Control

				Dim Language As LanguageManager.Language = SubSite.Language
				If Not Me.ItemsMenu.Count = 0 Then
					Dim FirstIdItem As Integer = IndexItemParent(RestrictToIdPage)
					Dim FirstLevel As Integer = Me.ItemsMenu(FirstIdItem).Level
					'Dim PrevLevel As Integer = 0
					'Levels.Add(PrevLevel, CtrlMenu) 'root

          Dim MainBox As UI.ControlCollection = Nothing
					For IdItem As Integer = FirstIdItem To Me.ItemsMenu.Count - 1
						'For Each Item As ItemMenu In Me.ItemsMenu
						Dim Item As ItemMenu = Me.ItemsMenu(IdItem)
						If Item.Off = False And Item.JoinPrevious = False Then
							If RestrictToIdPage <> 0 AndAlso IdItem <> FirstIdItem AndAlso Item.Level <= FirstLevel Then
								Exit For
							End If
							If MainBox Is Nothing OrElse Item.Level = 0 Then
								Dim TopLevel As New HtmlGenericControl("nav") 'html5
								CtrlMenu.Controls.Add(TopLevel)
								TopLevel.Attributes.Add("class", "Menu")
								MainBox = TopLevel.Controls
								MainBox.Add(Item.Control(DomainConfiguration, SubSite))
							Else
								MainBox.Add(Item.Control(DomainConfiguration, SubSite))
							End If
						End If
					Next
				End If
				'AbjustUlOlLevel(CtrlMenu)
				Return CtrlMenu
				'End If
			End Function

			Private Sub AssignCtrlLevel(ByVal Levels As Collections.Generic.Dictionary(Of Integer, Control), ByVal Level As Control, ByVal Key As Integer)
				If Levels.ContainsKey(Key) Then
					Levels.Remove(Key)
				End If
				Levels.Add(Key, Level)
			End Sub

			Private Sub AbjustUlOlLevel(ByRef Control As Control)
				Dim Removed As Boolean
				Do
					Removed = False
					If Control IsNot Nothing Then
						For Each Ctrl As HtmlGenericControl In Control.Controls
							If (StrComp(Ctrl.TagName, "ul") = 0 OrElse StrComp(Ctrl.TagName, "ol") = 0) AndAlso LiFinded(Ctrl) = False Then
								'Remove This Ul-Ol control
								If Ctrl.Parent IsNot Nothing Then
									For Each InsideControl As Control In Ctrl.Controls
										Ctrl.Parent.Controls.Add(InsideControl)
									Next
									Ctrl.Parent.Controls.Remove(Ctrl)
									Ctrl.Dispose()
									Removed = True
									Exit For
								End If
							Else
								If StrComp(Ctrl.TagName, "li") <> 0 AndAlso StrComp(Ctrl.TagName, "legend") <> 0 Then
									AbjustUlOlLevel(Ctrl)
								End If
							End If
						Next
					End If
				Loop Until Not Removed
			End Sub
			Private Function LiFinded(ByRef Control As HtmlGenericControl) As Boolean
				For Each Ctrl As HtmlGenericControl In Control.Controls
					If StrComp(Ctrl.TagName, "li") = 0 Then
						Return True
					End If
				Next
				Return False
			End Function

			Private Function IndexItem(ByVal IdPage As Integer) As Integer
				Dim Id As Integer
				For Each Item As ItemMenu In Me.ItemsMenu
					If Item.IdPage = IdPage Then
						Return Id
					End If
					Id += 1
        Next
        Return 0
			End Function

			Private Function IndexItemParent(ByVal IdPage As Integer) As Integer
				If IdPage Then
					Dim Level As Integer
					For Each Item As ItemMenu In Me.ItemsMenu
						If Item.IdPage = IdPage Then
							Level = Item.Level
							Exit For
						End If
					Next
					Dim Id, ReturnId As Integer
					For Each Item As ItemMenu In Me.ItemsMenu
						If Item.IdPage = IdPage Then
							If Level = 0 Then
								Return Id
							Else
								Return ReturnId
							End If
						End If
						If Item.Off = False AndAlso Item.Level < Level Then
							ReturnId = Id
						End If
						Id += 1
					Next
				End If
        Return 0
      End Function

			Function LevelPage(ByVal IdPage As Integer) As Integer
				For Each Item As ItemMenu In Me.ItemsMenu
					If Item.IdPage = IdPage Then
						Return Item.Level
					End If
				Next
        Return 0
      End Function

		End Class
		Public Function MenuControls(ByVal DomainConfiguration As DomainConfiguration, ByRef SubSite As Config.SubSite) As System.Web.UI.Control
			Dim Control As New Control
			If SubSite.Archive IsNot Nothing Then
				For Each Archive As Integer In SubSite.Archive
					Dim Menu As Menu = Menu.Load(Archive, SubSite.Language)
					If Menu IsNot Nothing Then
						Control.Controls.Add(Menu.Control(DomainConfiguration, SubSite))
					End If
				Next
			End If
			Return Control
		End Function
		Class DescriptionType
			Public Label As String
			Public Title As String
			Public Link As String
			Public Sub New()
			End Sub
			Public Sub New(ByVal Label As String, ByVal Title As String, Optional ByVal Link As String = Nothing)
				Me.Label = Label
				Me.Title = Title
				Me.Link = Link
			End Sub
		End Class
		'Private Sub AddItemToItemList(ByRef Items As ItemMenu(), ByVal Item As ItemMenu)
		'	If Items Is Nothing Then
		'		ReDim Items(0)
		'	Else
		'		ReDim Preserve Items(Items.GetUpperBound(0) + 1)
		'	End If
		'	Items(Items.GetUpperBound(0)) = Item
		'End Sub
		Public Class ItemMenu
			Public Archive As Integer
			Public IdPage As Integer
			Public Level As LevelMenuItem
			Public Description As New DescriptionType
			Public Off As Boolean	 'Disabled
			Public JoinPrevious As Boolean
			Public Language As LanguageManager.Language
			Shared Function Href(ByVal SubSite As Config.SubSite, ByVal Page As Integer, ByVal Archive As Integer, ByVal Title As String, Optional ByVal Absolute As Boolean = False, Optional ByVal DomainConfiguration As DomainConfiguration = Nothing) As String
        'If Title <> "" Then
        '	Dim StringBuilder As New System.Text.StringBuilder(Len(Title))
        '	For Each C As Char In Title.ToCharArray
        '		If System.Char.IsLetterOrDigit(C) Then
        '			StringBuilder.Append(Char.ToLowerInvariant(C))
        '		End If
        '	Next
        '	If StringBuilder.Length Then
        '		Title = StringBuilder.ToString
        '	End If
        'End If
        Return Common.Href(DomainConfiguration, SubSite.Name, Absolute, "default.aspx", QueryKey.ArticleNumber, Page, QueryKey.ArchiveNumber, Archive)
			End Function
			Function Href(ByVal DomainConfiguration As DomainConfiguration, ByVal SubSite As Config.SubSite, Optional ByVal Absolute As Boolean = False) As String
				If IDPage Then
          Dim Title As String = Nothing
					If Description IsNot Nothing Then
						Title = Description.Label
					End If
					Return Href(SubSite, IDPage, Archive, Title, Absolute, DomainConfiguration)
				Else
					Return Description.Link
				End If
			End Function

			Function Control(ByVal DomainConfiguration As DomainConfiguration, ByVal SubSite As Config.SubSite) As Control
				If Not Me.Off Then
          Dim ToolTip As String = Nothing, Text As String = Nothing
					If Not Me.Description Is Nothing Then
						ToolTip = Me.Description.Title
						Text = Me.Description.Label
					End If
					Return ControlItem(Me.Href(DomainConfiguration, SubSite), Text, ToolTip, Me.Level)
				End If
				Return Nothing
			End Function

			Function Record() As String
        Dim Level As String = Nothing, ID As String = Nothing, Label As String = Nothing, Title As String = Nothing, Link As String = Nothing
        Dim Parameters As String = Nothing
				Level = StrDup(Me.Level, ".")
				If Me.IDPage Then
					ID = "[#" & Me.IDPage & "]"
				Else
					ID = "[]"
					Label = "[" & Me.Description.Label & "]"
					Title = "[" & Me.Description.Title & "]"
					If Me.Description.Link <> "" Then
						Link = "[" & Me.Description.Link & "]"
					End If
				End If
				If Me.Off Then
					Parameters &= "{off}"
				End If
				If Me.JoinPrevious Then
					Parameters &= "{join}"
				End If
				Return Level & ID & Label & Title & Link & Parameters
			End Function
			Public Sub New()
			End Sub
			Shared Function Load(ByVal Record As String, ByVal Archive As Integer, ByVal Language As LanguageManager.Language) As ItemMenu
				Dim MewItem As New ItemMenu
				MewItem.Language = Language
				MewItem.Archive = Archive

				Dim p1, p2 As Integer
				If Record <> "" Then
					For n As Integer = 1 To Len(Record)
						If Mid(Record, n, 1) = "." Then
							MewItem.Level += 1
						Else
							Exit For
						End If
					Next
					p1 = InStr(1, Record, "[", vbTextCompare)
					If p1 Then
						p2 = InStr(p1 + 1, Record, "]", vbTextCompare)
						Dim Field As String = Mid(Record, p1 + 1, p2 - p1 - 1)
						If Left(Field, 1) = "#" Then
							MewItem.IdPage = Mid(Field, 2)
						End If
						If MewItem.IdPage Then
							MewItem.Description = LoadDescription(Archive, MewItem.IdPage, Language)
							If MewItem.Description Is Nothing Then
								'The corrispondent page is deleted
								Return Nothing
							End If
						Else
							p1 = InStr(p2, Record, "[", vbTextCompare)
							If p1 Then
								MewItem.Description = New DescriptionType
								p2 = InStr(p1 + 1, Record, "]", vbTextCompare)
								MewItem.Description.Label = Mid(Record, p1 + 1, p2 - p1 - 1)
								p1 = InStr(p2, Record, "[", vbTextCompare)
								If p1 Then
									p2 = InStr(p1 + 1, Record, "]", vbTextCompare)
									MewItem.Description.Title = Mid(Record, p1 + 1, p2 - p1 - 1)
									p1 = InStr(p2, Record, "[", vbTextCompare)
									If p1 Then
										p2 = InStr(p1 + 1, Record, "]", vbTextCompare)
										MewItem.Description.Link = Mid(Record, p1 + 1, p2 - p1 - 1)
									End If
								End If
							End If
						End If
					End If
					MewItem.Off = InStr(p2, Record, "{off}", vbTextCompare) <> 0
					MewItem.JoinPrevious = InStr(p2, Record, "{join}", vbTextCompare) <> 0
				End If
				Return MewItem
			End Function
		End Class
		Private Function LoadDescription(ByVal Archive As Integer, ByVal IDPage As Integer, ByVal Language As LanguageManager.Language) As DescriptionType
			Dim Key As String = Archive & "," & IDPage & "," & Language
			SyncLock PagesDescriptions
				Dim FileInfo As New System.IO.FileInfo(MenuManager.PageNameFile(Archive, IDPage, Language))
				If Recent(FileInfo.LastWriteTimeUtc, Now.ToUniversalTime, New TimeSpan(0, 0, 30)) OrElse Not PagesDescriptions.ContainsKey(Key) Then
					Return SetDescription(Archive, IDPage, Language)
				Else
					Return PagesDescriptions(Key)
				End If
			End SyncLock
		End Function
		Function SetDescription(ByVal Archive As Integer, ByVal IDPage As Integer, ByVal Language As LanguageManager.Language, Optional ByVal Description As DescriptionType = Nothing) As DescriptionType
			If Description Is Nothing Then
				Dim Html As String = ReadAll(MenuManager.PageNameFile(Archive, IDPage, Language))
				If Html = Nothing Then
					Return Nothing
				End If
				Dim MetaTags As New MetaTags(Html)
				Description = New DescriptionType(MetaTags.Title, MetaTags.Description)
			End If
			Dim Key As String = Archive & "," & IDPage & "," & Language
			SyncLock PagesDescriptions
				If PagesDescriptions.ContainsKey(Key) Then
					PagesDescriptions.Remove(Key)
				End If
				PagesDescriptions.Add(Key, Description)
			End SyncLock
			Return Description
		End Function
		Function UnSetDescription(ByVal Archive As Integer, ByVal IDPage As Integer, ByVal Language As LanguageManager.Language) As Boolean
			Dim Key As String = Archive & "," & IDPage & "," & Language
			SyncLock PagesDescriptions
				If PagesDescriptions.ContainsKey(Key) Then
					PagesDescriptions.Remove(Key)
					Return True
				Else
					Return False
				End If
			End SyncLock
		End Function
		Private PagesDescriptions As New Collections.Generic.Dictionary(Of String, DescriptionType)
		Public Function PageNameFile(ByVal Archive As Integer, ByVal IDPage As Integer, ByVal Language As LanguageManager.Language) As String
			Return MapPath(ArchiveSubDirectory & "/" & Archive & "/" & IDPage & "." & Acronym(Language) & ".htm")
		End Function
		Public Function DirectoryName(ByVal Archive As Integer) As String
			Return MapPath(ArchiveSubDirectory & "/" & Archive)
		End Function
		Public Function AllArchives(Optional ByVal WithoutForSystemUse As Boolean = True) As Archive()
			Dim Root As String = Extension.MapPath(ArchiveSubDirectory)
			Dim dir As New System.IO.DirectoryInfo(Root)
			Dim Folders As System.IO.FileSystemInfo() = dir.GetFileSystemInfos()
			Dim Archives(UBound(Folders)) As Archive
			Dim N As Integer
			For Each Folder As System.IO.FileSystemInfo In Folders
				Try
					If WithoutForSystemUse = False OrElse Folder.Name <> "0" Then
						Dim Archive As New Archive(Folder.Name)
						Archives(N) = Archive
						N += 1
					End If
				Catch ex As Exception
					'directoty is not an Archive!
				End Try
			Next
			ReDim Preserve Archives(N - 1)
			Return Archives
		End Function
    Function NewArchive(Optional ByVal ID As Integer = 0) As Archive
      If ID = 0 Then ID = NewSubDirectoryId(Extension.MapPath(ArchiveSubDirectory))
      Dim Archive As New Archive(ID)
      Return Archive
    End Function
		Class Archive
			Public ID As Integer
      Public Function Name(Language As Language, Optional ShortFormat As Boolean = False) As String
        Dim Menu As Menu = Menu.Load(ID, Language)
        Return Menu.Name(ShortFormat)
      End Function

			Sub Load(ByVal ID As Integer)
				Me.ID = ID
			End Sub

			Shared Sub Create(ByVal ID As Integer)
				Dim Dir As New System.IO.DirectoryInfo(MenuManager.DirectoryName(ID))
				Try
					Dir.Create()
				Catch ex As Exception
				End Try
			End Sub

			Shared Function Exist(ByVal ID As Integer) As Boolean
				Dim Dir As New System.IO.DirectoryInfo(MenuManager.DirectoryName(ID))
				Return Dir.Exists
			End Function


			Public Sub New(ByVal ID As Integer)
				Load(ID)
			End Sub

			Private Function DirectoryName() As String
				Return MenuManager.DirectoryName(ID)
			End Function
		End Class

		Public Function FirstDocument(ByVal Setting As SubSite, ByRef ArchiveNumber As Integer) As Integer
			If Setting.Archive IsNot Nothing Then
				For Each Archive As Integer In Setting.Archive
					Dim Menu As Menu = Menu.Load(Archive, Setting.Language)
					If Not Menu Is Nothing Then
						ArchiveNumber = Archive
						If Menu.ItemsMenu IsNot Nothing Then
							For Each ItemMenu As MenuManager.ItemMenu In Menu.ItemsMenu
								If ItemMenu.IDPage Then
									Return ItemMenu.IDPage
								End If
							Next
						End If
					End If
				Next
      End If
      Return 0
		End Function

		Public Function FindMenu(ByVal Setting As SubSite, ByVal ArchiveNumber As Integer) As Menu
			If Setting.Archive IsNot Nothing Then
				For Each Archive As Integer In Setting.Archive
					If Archive = ArchiveNumber Then
						Return Menu.Load(Archive, Setting.Language)
					End If
				Next
			End If
      Return Nothing
		End Function

		Public Sub InsertPageContent(ByRef Content As Control, ByRef MasterPage As MasterPage, ByVal Setting As SubSite, ByVal Menu As Menu, ByVal PageNumber As Integer, Optional ByVal IsHomePage As Boolean = True)
      'Dim Threads As New System.Collections.Generic.List(Of Threading.Thread)

			Dim ReturnMetaTags As New Collections.Generic.List(Of MetaTags)
			If Not IsHomePage AndAlso Menu.Archive <> 0 Then
        Dim Subject As String = Nothing
				MasterPage.SetTrace(Menu.Trace(PageNumber, CurrentDomainConfiguration, Setting, Nothing, Subject))

				'ReturnMetaTags.Title = "" 'Remove full track in title [REM this line for full title]

				If Subject <> "" Then
					MasterPage.AddMetaTag("Subject", Subject)
				End If
			End If

			Dim MetaTags As New MetaTags
			ReturnMetaTags.Add(MetaTags)

			'Find Level and Category
			Dim Category As Integer
			Dim Level As Integer
			If Menu.ItemsMenu IsNot Nothing Then
				Menu.LevelAndCategoryItem(PageNumber, Level, Category)
			End If

      ''Add page
      '   If Setup.Performance.MultyThread Then
      '     'Multy Thread 
      '     Threads.Add(New AddPageArchived(Content, Menu.Archive, PageNumber, MasterPage, HttpContext.Current, CurrentDomainConfiguration, Setting, MetaTags, IsHomePage, Level, Category).Thread)
      '   Else
      'Single Thread 
      Components.AddPageArchived(Content, MasterPage, Menu.Archive, PageNumber, HttpContext.Current, CurrentDomainConfiguration, Setting, MetaTags, IsHomePage, , , Level, Category)
      'End If

      'Add Pages is next pages is join to the previous
      Dim FlgFinded As Boolean

      For Each ItemMenu As MenuManager.ItemMenu In Menu.ItemsMenu
        If ItemMenu.IdPage = PageNumber Then
          FlgFinded = True
        ElseIf FlgFinded Then
          If ItemMenu.JoinPrevious Then
            If ItemMenu.Off = False Then
              Dim Hr As New WebControl(HtmlTextWriterTag.Hr)
              Content.Controls.Add(Hr)
              MetaTags = New MetaTags
              ReturnMetaTags.Add(MetaTags)
              'If Setup.Performance.MultyThread Then
              '  'Multy Thread 
              '  Threads.Add(New AddPageArchived(Content, Menu.Archive, ItemMenu.IdPage, MasterPage, HttpContext.Current, CurrentDomainConfiguration, Setting, MetaTags, IsHomePage, Level, Category).Thread)
              'Else
              'Single Thread
              Components.AddPageArchived(Content, MasterPage, Menu.Archive, ItemMenu.IdPage, HttpContext.Current, CurrentDomainConfiguration, Setting, MetaTags, IsHomePage, , , Level, Category)
              'End If
            End If
          Else
            FlgFinded = False
            Exit For
          End If
        End If
      Next

      'For Each Thread As Threading.Thread In Threads
      '  Thread.Join()
      'Next

      If Not IsHomePage Then
        'Set meta tag for a specific page
        If Menu.Archive > 1 Then
          'Joun all metatags
          Dim MetaTag As MetaTags = Nothing
          Dim Title As String = Nothing
          For Each EahcMetaTag As MetaTags In ReturnMetaTags
            If MetaTag Is Nothing Then
              MetaTag = EahcMetaTag
              Title = MetaTag.Title
            Else
              MetaTag.Join(EahcMetaTag)
            End If
          Next
          MasterPage.TitleDocument = Title ' MetaTag.Title
          If MetaTag IsNot Nothing Then
            MasterPage.Description = MetaTag.Description
            MasterPage.KeyWords = MetaTag.KeyWords
          End If
          'Add menu restrict of the context
          Dim Fieldset As Control = Components.Fieldset(Phrase(Setting.Language, 3240), Menu.Control(CurrentDomainConfiguration, Setting, PageNumber))
          Content.Controls.Add(Fieldset)
        End If
      End If
		End Sub
  End Module
End Namespace