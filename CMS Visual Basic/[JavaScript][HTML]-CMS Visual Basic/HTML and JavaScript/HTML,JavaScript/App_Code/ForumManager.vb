'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Option Explicit On
Option Strict On
Imports System
Imports System.Collections.Generic
Imports System.Xml.Serialization

Imports Microsoft.VisualBasic
Namespace WebApplication
	Public Module ForumManager

		Public Const NameAttribute As String = "BytesWriteForum"

		'Stars User for bytes text write in forum
		Public Const Stars1 As Integer = 60000
		Public Const Stars2 As Integer = Stars1 * 2
		Public Const Stars3 As Integer = Stars2 * 2
		Public Const Stars4 As Integer = Stars3 * 2
		Public Const Stars5 As Integer = Stars4 * 2

	
		Class ForumStructure
			Private ForumId As Integer

      Public Sub New()
      End Sub

      Public SortCategory As Boolean
      Public SortSubCategory As Boolean

			Public Sub New(ByVal Id As Integer)
				ForumId = Id
			End Sub

			Function AddCategory(ByVal Title As String) As Category
				Dim Category As New Category
				Category.Title = Title
				Categories.Add(Category)
				Return Category
			End Function

			Public Categories As Collections.Generic.List(Of Category) = New Collections.Generic.List(Of Category)

      Public Function CategoriesSorted() As Collections.Generic.List(Of Category)
        Dim Categories As System.Collections.Generic.List(Of ForumStructure.Category)
        If SortCategory OrElse SortSubCategory Then
          Categories = New System.Collections.Generic.List(Of ForumStructure.Category)
          'Categories.AddRange(Forum.ForumStructure.Categories)
          Dim Index As Integer
          For Each Category As ForumStructure.Category In Me.Categories
            'Clonation
            Dim CategoryClone As ForumStructure.Category = New ForumStructure.Category
            CategoryClone.Title = Category.Title
            CategoryClone.Index = Index
            Index += 1
            Categories.Add(CategoryClone)
            If SortSubCategory Then
              Dim Subcategories As System.Collections.Generic.List(Of ForumStructure.Category.Subcategory)
              Subcategories = New System.Collections.Generic.List(Of ForumStructure.Category.Subcategory)
              Subcategories.AddRange(Category.Subcategories) 'Clonation list of SubCategory
              Subcategories.Sort(New ForumStructure.SortSubCategoryComparer)
              CategoryClone.Subcategories = Subcategories
            End If
          Next
          If SortCategory Then
            Categories.Sort(New ForumStructure.SortCategoryComparer)
          End If
          Return Categories
        Else
          Return Me.Categories
        End If
      End Function

			Class Category
        Friend Index As Integer = -1
        Sub AddSubcategory(ByVal Title As String, ByVal Description As String, ByVal Id As Integer)
          Dim Subcategory As New Subcategory
          Subcategory.Id = Id
          Subcategory.Title = Title
          Subcategory.Description = Description
          Subcategories.Add(Subcategory)
        End Sub

				Public Title As String
				Public Subcategories As Collections.Generic.List(Of Subcategory) = New Collections.Generic.List(Of Subcategory)
				Class Subcategory
					Public Id As Integer
					Public Title As String
					Public Description As String
					Public Icon As IconType = IconType.Contacts
					Public TotalTopics As Integer          
        End Class
			End Class
			Function LastId() As Integer
				'Find last Id used
				For Each Category As Category In Categories
					For Each SubCategory As ForumStructure.Category.Subcategory In Category.Subcategories
						If SubCategory.Id > LastId Then
							LastId = SubCategory.Id
						End If
					Next
        Next
        Return 0
			End Function
			Sub Save()
				'Auto set Id of Sub Categories
				Dim LastId As Integer = Me.LastId
				'Set id to category
        For Each Category As Category In Categories
          For Each SubCategory As ForumStructure.Category.Subcategory In Category.Subcategories
            If SubCategory.Id > LastId Then
              LastId = SubCategory.Id
            End If
          Next
        Next
        For Each Category As Category In Categories
          For Each SubCategory As ForumStructure.Category.Subcategory In Category.Subcategories
            If SubCategory.Id = 0 Then
              LastId += 1
              SubCategory.Id = LastId
            End If
          Next
        Next

				'Save
				Serialize(Me, ForumId)
			End Sub

			Shared Sub Serialize(ByVal ForumStructure As ForumStructure, ByVal ForumId As Integer)
				If ForumStructure IsNot Nothing Then
					ForumStructure.ForumId = ForumId
					FileManager.Serialize(ForumStructure, PathFileName(ForumId))
				End If
			End Sub

			Shared Function Derserialize(ByVal ForumId As Integer) As ForumStructure
        Dim ForumStructure As ForumStructure = CType(FileManager.Deserialize(PathFileName(ForumId), GetType(ForumStructure)), ForumManager.ForumStructure)
				If ForumStructure Is Nothing Then
					ForumStructure = New ForumStructure
				End If
				ForumStructure.ForumId = ForumId
				Return ForumStructure
			End Function

      Shared Function PathFileName(ByVal ForumId As Integer) As String
        Return MapPath(ForumSubDirectory & "/" & ForumId & "/Categories.xml")
      End Function


      Class SortCategoryComparer
        Implements IComparer(Of Category)
        Public Function Compare(ByVal Category1 As Category, ByVal Category2 As Category) As Integer Implements IComparer(Of Category).Compare
          Return StrComp(Category1.Title, Category2.Title, CompareMethod.Binary)
        End Function
      End Class

      Class SortSubCategoryComparer
        Implements IComparer(Of Category.Subcategory)
        Public Function Compare(ByVal SubCategory1 As Category.Subcategory, ByVal SubCategory2 As Category.Subcategory) As Integer Implements IComparer(Of Category.Subcategory).Compare
          Return StrComp(SubCategory1.Title, SubCategory2.Title, CompareMethod.Binary)
        End Function
      End Class

    End Class

		Public Function ForumForInsideUse(ByVal ForumId As Integer) As Boolean
			Return [Enum].IsDefined(GetType(ReservedForums), ForumId)
		End Function

		Public Function AllForums(Optional ByVal WithoutForSystemUse As Boolean = True) As ForumManager.Forum()
			Dim Root As String = Extension.MapPath(ForumSubDirectory)
			Dim dir As New System.IO.DirectoryInfo(Root)
			Dim Folders As System.IO.FileSystemInfo() = dir.GetFileSystemInfos()
      Dim Forums As ForumManager.Forum() = Nothing
			For Each Folder As System.IO.FileSystemInfo In Folders
				Try
          Dim ForumId As Integer = CInt(Folder.Name)
					If WithoutForSystemUse = False Or ForumForInsideUse(ForumId) = False Then
            Dim Forum As Forum = CType(Forum.Load(CStr(ForumId)), ForumManager.Forum)
						If Forum IsNot Nothing Then
							If Forums Is Nothing Then
								ReDim Forums(0)
							Else
								ReDim Preserve Forums(Forums.GetUpperBound(0) + 1)
							End If
							Forums(Forums.GetUpperBound(0)) = Forum
						End If
					End If
				Catch ex As Exception
					'directoty is not a Forum!
				End Try
			Next
			Return Forums
		End Function

		Private ForumArchiveDetected As New Collections.Generic.List(Of Integer)
		Class Forum
			Public Shared Load As New Extension.Cache(AddressOf DelegateLoad, 100, GetType(Forum))
      Private Index As Integer
      Public Type As TypeOfForum = OEM.DefaultTypeOfForum
      Enum TypeOfForum
        Forum
        TicketSystem
      End Enum
      ReadOnly Property Id As Integer
        Get
          Return Index
        End Get
      End Property
			Public Name As String
			Public Description As String

			Public Function TitleControl(Setting As SubSite, Optional SubCategory As ForumStructure.Category.Subcategory = Nothing, Optional IsTopicsNotClassified As Boolean = False, Optional ByRef Title As String = Nothing, Optional ByRef Description As String = Nothing) As Control
				'Dim InLine As New WebControl(HtmlTextWriterTag.Span)
				'InLine.Style.Add("display", "block")
				Dim Control As New Control			 ' New HtmlGenericControl("hgroup")
				'InLine.Controls.Add(Hgroup)
				If Admitted(Id, Setting) Then
					Dim Href As String
					Dim TotalTopics As Integer

					If IsTopicsNotClassified Then
						If Title Is Nothing Then Title = Phrase(Setting.Language, 137)
						If Description Is Nothing Then Description = Phrase(Setting.Language, 138)
						Href = ForumManager.Link(ActionType.Show, Setting.Name, , , Id, , , , , , , , 0)
					ElseIf SubCategory Is Nothing Then
						If Title Is Nothing Then Title = Me.Name
						If Description Is Nothing Then Description = Me.Description
						Href = Me.Href(Setting)
						TotalTopics = Me.TotalTopics
					Else
						Href = ForumManager.Link(ActionType.Show, Setting.Name, , , Id, , , , , , , , SubCategory.Id)
						If Title Is Nothing Then Title = SubCategory.Title
						If Description Is Nothing Then Description = SubCategory.Description
						TotalTopics = SubCategory.TotalTopics
					End If

					Dim User As User = CurrentUser
					Dim Role As User.RoleType = CurrentUser.Role(Setting.Name)

					If Role >= ForumManager.Forum.ToolsAccess Then
						Control.Controls.Add(Me.Tools(Setting))
					End If

					Dim TitleH1 As New WebControl(HtmlTextWriterTag.H1)
					TitleH1.Style.Add("display", "inline")
					Control.Controls.Add(TitleH1)
					Dim Link As New WebControls.HyperLink
					TitleH1.Controls.Add(Link)
					Link.NavigateUrl = Href
					Link.Text = HttpUtility.HtmlEncode(Title)
					Link.ToolTip = EncodingAttribute(Description)

					If TotalTopics > 0 Then
						Dim TextHtml As String = Web.HttpUtility.HtmlEncode(TotalTopics & " " & Phrase(Setting.Language, 65))	 'Topics
						If Config.Setup.SEO.GoogleOffGoogleOnTagsEnabled Then
							TextHtml = GoogleOffTag & TextHtml & GoogleOnTag
						End If
						Control.Controls.Add(New LiteralControl(TextHtml))
					End If

					If Description <> "" Then
						Dim Label As New WebControl(HtmlTextWriterTag.H2)
						Control.Controls.Add(Label)
						Label.Controls.Add(TextControl(Description))
					End If
				End If
				Return Control
			End Function

			Function Summary(ByVal Setting As SubSite) As Control
				Dim Control As New HtmlGenericControl("section")
				If Admitted(Id, Setting) Then
					Control.Controls.Add(Me.TitleControl(Setting))
          If CBool(ForumStructure.Categories.Count) Then
            Dim Table As New HtmlTable
            Control.Controls.Add(Table)
            Dim Categories = Me.ForumStructure.CategoriesSorted
            For Each Category As ForumStructure.Category In Categories
              Dim RowCategory As New HtmlTableRow
              Table.Controls.Add(RowCategory)
              RowCategory.Cells.Add(New HtmlTableCell("th"))

              Dim Link As New HyperLink
              RowCategory.Controls(0).Controls.Add(Link)
              Dim Cell As HtmlControl = RowCategory.Cells(0)
              Cell.Attributes.Add("colspan", "2")
              Link.Text = HttpUtility.HtmlEncode(Category.Title)
              Dim Index As Integer
              If Category.Index <> -1 Then
                Index = Category.Index 'Work with sorted clone
              Else
                Index = ForumStructure.Categories.IndexOf(Category) 'Work with original
              End If
              Link.Attributes.Add("id", "Category" & Index)

              'Dim RowTopics As New WebControls.TableHeaderRow
              'Table.Rows.Add(RowTopics)
              Dim Th As HtmlTableCell = New HtmlTableCell("th")
              Th.InnerText = Phrase(Setting.Language, 65)
              RowCategory.Controls.Add(Th)

              For Each SubCategory As ForumStructure.Category.Subcategory In Category.Subcategories
                Dim Row As New HtmlTableRow
                Table.Rows.Add(Row)
                Row.Cells.Add(New HtmlTableCell)
                Row.Cells.Add(New HtmlTableCell)
                Row.Cells.Add(New HtmlTableCell)
                Row.Cells(0).Controls.Add(EnhancedLinkIcon(Setting.Skin, SubCategory.Icon, , Me.Href(Setting, SubCategory)))
                Row.Cells(1).Controls.Add(Components.Link(Me.Href(Setting, SubCategory), SubCategory.Title))
                Row.Cells(1).Style.Add("width", "100%")
                Row.Cells(1).Controls.Add(BR)
                AddLabel(Row.Cells(1), SubCategory.Description)
                'Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                Row.Cells(2).Style.Add("text-align", "right") 'html5
                If SubCategory.TotalTopics > 0 Then
                  Row.Cells(2).InnerText = CStr(SubCategory.TotalTopics)
                End If
              Next
              'IdCategory += 1
            Next
          End If
				End If
				Return Control
			End Function

			Public RelatedArchive As Integer
			Public Function ArchiveAppropriate(ByVal SubSite As SubSite) As Integer
				If Not ForumForInsideUse(Id) Then
					Dim Archive As Integer = SubSite.MainArchive
          If CBool(Archive) Then
            Return Archive
          Else
            If RelatedArchive = 0 Then
              SyncLock ForumArchiveDetected
                If Not ForumArchiveDetected.Contains(Id) Then
                  ForumArchiveDetected.Add(Id)
                  For Each Setting As SubSite In AllSubSite()
                    Archive = Setting.MainArchive
                    If Archive <> 0 AndAlso Setting.Forums IsNot Nothing AndAlso Setting.Forums.Count = 1 AndAlso Setting.Forums(0) = Id Then
                      RelatedArchive = Archive
                      Save()
                      Exit For
                    End If
                  Next
                End If
              End SyncLock
            End If
            Return RelatedArchive
          End If
				End If
        Return 0
      End Function

			<XmlIgnore()> Public ForumStructure As ForumStructure

			Public Shared ReadOnly ToolsAccess As Authentication.User.RoleType = Authentication.User.RoleType.Administrator
			Private Function HrefEdit(ByVal Setting As SubSite) As String
				Return ForumManager.Link(ActionType.Modify, Setting.Name, , , Id)
			End Function
			Function Tools(ByVal Setting As SubSite) As Control
        Dim Edit As Control = Components.IconUnicode(IconName.Pencil, , Phrase(Setting.Language, 74, 61), HrefEdit(Setting))
        Return Edit
			End Function
			Sub AddButtons(ByVal Setting As SubSite, ByVal MasterPage As MasterPage)
				MasterPage.AddButton(Phrase(Setting.Language, 74, 61), HrefEdit(Setting), , Components.IconType.ControlPanel, MasterPage.TargetForButton.Blank, True)
				'MasterPage.AddButton(Phrase(Setting.Language, 74, 154), HrefEdit(Setting), Phrase(Setting.Language, 74, 154, 61), Components.IconType.ControlPanel, MasterPage.TargetForButton.Blank, True)
			End Sub

      Function PhotoAlbum() As String
        Return "forum/" & Id
      End Function
      Function Exists() As Boolean
        Return System.IO.Directory.Exists(PathForum(Id))
      End Function

      Shared Function NewForum(ByVal Name As String, ByVal Description As String) As Forum
        Dim ID As Integer = NewSubDirectoryId(Extension.MapPath(ForumSubDirectory), 200)
        Dim Forum As New Forum
        Forum.Index = ID
        Forum.ForumStructure = ForumStructure.Derserialize(ID)
        Forum.Name = Name
        Forum.Description = Description
        Forum.Save()
        Forum.Load(CStr(ID)) = Forum
        Return Forum
      End Function

      Shared Function NewForum(ByVal ID As Integer, Type As Forum.TypeOfForum) As Forum
        Dim Forum As New Forum
        Forum.Index = ID
        Forum.Type = Type
        Forum.ForumStructure = ForumStructure.Derserialize(ID)
        Forum.Save()
        Return Forum
      End Function

      Private Shared Function DelegateLoad(ByVal Id As String) As Object
        Return LoadFromFile(CInt(Id))
      End Function

      Function Href(ByVal SubSite As SubSite, Optional SubCategory As ForumStructure.Category.Subcategory = Nothing) As String
        If SubCategory IsNot Nothing Then
          Return Link(ActionType.Show, SubSite.Name, , , Me.Id, , , , , , , , SubCategory.Id)
        Else
          Return Link(ActionType.Show, SubSite.Name, , , Me.Id)
        End If
      End Function

      Private Shared Function LoadFromFile(ByVal Id As Integer) As Forum
        Dim NewForum As Forum
        Dim File As String = FileName(Id)
        If System.IO.File.Exists(File) Then
          NewForum = CType(Deserialize(FileName(Id), GetType(Forum)), Forum)
          NewForum.Index = Id
          NewForum.ForumStructure = ForumStructure.Derserialize(Id)
          NewForum.UpdateTotalTopic()
          Return NewForum
        End If
        Return Nothing
      End Function

      Function SubCategory(Id As Integer) As ForumManager.ForumStructure.Category.Subcategory
        For Each Category As ForumStructure.Category In Me.ForumStructure.Categories
          For Each [Sub] As ForumStructure.Category.Subcategory In Category.Subcategories
            If [Sub].Id = Id Then
              Return [Sub]
            End If
          Next
        Next
        Return Nothing
      End Function

      Sub Save(Optional ByVal SaveStructure As Boolean = False)
        If Not System.IO.Directory.Exists(PathForum(Id)) Then
          System.IO.Directory.CreateDirectory(PathForum(Id))
        End If
        Serialize(Me, FileName(Id))
        If SaveStructure Then
          ForumStructure.Save()
        End If
        RemoveCacheOfTopicListAndTopicListByCategories(Id)
        Pipeline.NotifyChangement(GetType(Forum), CStr(Id))
      End Sub

      Private Shared Function FileName(ByVal Id As Integer) As String
        Return PathForum(Id) & "/info.xml"
      End Function

      Function Trace(ByVal Setting As SubSite, Optional SubCategory As Integer = -1) As Control()
        If Me.ForumStructure IsNot Nothing Then
          Dim SubCategoryObject As ForumStructure.Category.Subcategory = Nothing
          Dim Category As ForumStructure.Category = Nothing
          If SubCategory > 0 Then
            Category = CategoryOfSubCategory(SubCategory, SubCategoryObject)
          End If

          Dim NewTrace As New Components.Trace
          NewTrace.Controls()
          NewTrace.AddElement(Setting.Title, Setting.Description, Common.Href(Setting.Name, False, Nothing))
          NewTrace.AddElement(Me.Name, Me.Description, Link(ActionType.Show, Setting.Name, , , Me.Id))
          If SubCategory = 0 Then
            'NewTrace.AddElement(Phrase(Setting.Language, 61), Me.Description, Link(ActionType.Show, Setting.Name, , , Me.Id))
            NewTrace.AddElement(Phrase(Setting.Language, 137), Phrase(Setting.Language, 138), Link(ActionType.Show, Setting.Name, , , Me.Id, , , , , , , , SubCategory) & "#SubCategory" & SubCategory)
            Return NewTrace.Controls
          Else
            If SubCategory > 0 AndAlso Category IsNot Nothing Then
              Dim IdCategory As Integer = ForumStructure.Categories.IndexOf(Category)
              NewTrace.AddElement(Category.Title, Category.Title, Link(ActionType.Show, Setting.Name, , , Me.Id) & "#Category" & IdCategory)
              NewTrace.AddElement(SubCategoryObject.Title, SubCategoryObject.Description, Link(ActionType.Show, Setting.Name, , , Me.Id, , , , , , , , SubCategory))
            End If
            Return NewTrace.Controls
          End If
        End If
        Return Nothing
      End Function

      Function CategoryOfSubCategory(IdSubCategory As Integer, Optional ByRef BackSubCategory As ForumStructure.Category.Subcategory = Nothing) As ForumStructure.Category
        For Each Category As ForumStructure.Category In Me.ForumStructure.Categories
          For Each BackSubCategory In Category.Subcategories
            If BackSubCategory.Id = IdSubCategory Then
              Return Category
            End If
          Next
        Next
        Return Nothing
      End Function

      Private Sub UpdateTotalTopic()
        Dim Thread As System.Threading.Thread = New System.Threading.Thread(AddressOf ThreadUpdateTotalTopic)
        Thread.Name = "UpdateTotalTopic"
        Thread.Priority = Threading.ThreadPriority.Normal
        Thread.IsBackground = True
        Thread.Start()
      End Sub

      Private Sub ThreadUpdateTotalTopic()
        Dim DirectoryName As String = PathForum(Id)
        If IO.Directory.Exists(DirectoryName) Then
          Dim Topics As Integer = IO.Directory.GetDirectories(DirectoryName).Length
          If Topics <> TotalTopics Then
            TotalTopics = Topics
            Save()
          End If
        End If
      End Sub
      Function GetAllTopicsId() As Integer()
        Dim DirectoryName As String = PathForum(Id)
        If IO.Directory.Exists(DirectoryName) Then
          Dim Directories() As IO.DirectoryInfo = New IO.DirectoryInfo(DirectoryName).GetDirectories()
          Dim Result(Directories.Count - 1) As Integer
          Dim Id As Integer
          For Each Directory As IO.DirectoryInfo In Directories
            Result(Id) = CInt(Val(Directory.Name))
            Id += 1
          Next
          Return Result
        Else
          Dim Result(-1) As Integer
          Return Result
        End If
      End Function
      Public TotalTopics As Integer
    End Class

    Public CacheForumLoaded As Boolean
    Public Sub LoadCachesForum()
      Dim Forums() As ForumManager.Forum = AllForums()
      If Forums IsNot Nothing Then
        For Each Forum As ForumManager.Forum In Forums
          LoadCache(Forum.Id)
        Next
      End If
      CacheForumLoaded = True
    End Sub

    Private Sub LoadCache(ByVal ForumId As Integer)
      Dim Root As String = Extension.MapPath(ForumSubDirectory & "\" & ForumId)
      Dim Dir As New System.IO.DirectoryInfo(Root)
      Dim Folders As System.IO.DirectoryInfo() = Dir.GetDirectories
      Dim Ids(Folders.Length - 1) As Integer
      Dim N As Integer
      For ID As Integer = Folders.Length - 1 To 0 Step -1
        Dim Info As System.IO.DirectoryInfo = Folders(ID)
        Ids(N) = CInt(Info.Name) 'Assign topic ID
        N += 1
      Next

      Dim CacheIsChanged As Boolean

      'Remove from cache deleted topics
      Dim AllTopics As Collections.Generic.Dictionary(Of Integer, Topic) = Topic.Topics(ForumId)

      For Each Topic As Topic In AllTopics.Values
        If Not Ids.Contains(Topic.ID) Then
          Topic.Delete(ForumId, Topic.ID)
        End If
      Next

      'Add to cache not loaded topics
      For Each TopicID As Integer In Ids
        If Not AllTopics.ContainsKey(TopicID) Then
          Topic.Load(ForumId, TopicID)
          CacheIsChanged = True
        End If
      Next

      'Now sort by lastreply to speedup and improve performance of application
      SyncLock Topic.Collection
        Dim Compare As New LastMessageComparer(False, False, Nothing)
        Dim Topics As New System.Collections.Generic.List(Of ForumManager.Topic)
        If CBool(Topics.Count) Then
          Topics.Sort(Compare)
        End If
      End SyncLock

      'Assign canged value to "false". Changed valued is used for monotoring cache changments. If cache change, the save cache at end application. 
      If CacheIsChanged Then
        RemoveCacheOfTopicListAndTopicListByCategories(ForumId)
        ForumManager.Topic.SetCacheIsChanged(ForumId)
      Else
        SyncLock Topic.Changed
          If Topic.Changed.ContainsKey(ForumId) Then
            Topic.Changed.Remove(ForumId)
          End If
          Topic.Changed.Add(ForumId, False)
        End SyncLock
      End If

    End Sub

    Public Function FindLastReply(ByVal Topic As Topic, Optional ByVal FindLastNotCensored As Boolean = False, Optional ByVal FindNoHide As Boolean = False) As Reply
      Dim Dir As New System.IO.DirectoryInfo(PathTopic(Topic.ForumId, Topic.ID))
      'Try
      Dim Files() As System.IO.FileInfo = Dir.GetFiles("*.htm")
      If CBool(Files.Length) Then
        If FindLastNotCensored Or FindNoHide Then
          For N As Integer = Files.GetUpperBound(0) To Files.GetLowerBound(0) Step -1
            Dim ReplyID As Integer = CInt(Val(Files(N).Name))
            Dim Reply As Reply = ForumManager.Reply.Load(Topic.ForumId, Topic.ID, ReplyID)
            If FindLastNotCensored = False OrElse Reply.Censored = False Then
              If FindNoHide = False OrElse ReplyMomentarilyHidden(Reply, False, Topic) = False Then
                Return Reply
              End If
            End If
          Next
        Else
          Dim IdLastReply As Integer = CInt(Val(Files(Files.GetUpperBound(0)).Name))
          Return Reply.Load(Topic.ForumId, Topic.ID, IdLastReply)
        End If
      End If
      Return Nothing
    End Function

    Public Function LastReplyId(ForumId As Integer, TopicId As Integer) As Integer
      Static Obj As New Object
      SyncLock Obj
        Dim Dir As New System.IO.DirectoryInfo(PathTopic(ForumId, TopicId))
        Dim Files() As System.IO.FileInfo = Dir.GetFiles("*.htm")
        If CBool(Files.Length) Then
          Return CInt(Val(Files(Files.GetUpperBound(0)).Name))
        End If
      End SyncLock
      Return 0
    End Function

    Private Function PathForum(ByVal ForumId As Integer) As String
      Return Extension.MapPath(ForumSubDirectory & "\" & ForumId & "\")
    End Function

    Private Function PathTopic(ByVal ForumId As Integer, ByVal TopicID As Integer) As String
      Return PathForum(ForumId) & TopicID & "\"
    End Function

    Public Function Link(ByVal Action As ActionType, Optional ByVal Subsite As String = Nothing, Optional ByVal AbsoluteAddress As Boolean = False, Optional ByVal Jump As String = Nothing, Optional ByVal ForumId As Integer = Nothing, Optional ByVal TopicID As Integer = Nothing, Optional ByVal ReplyID As Integer = Nothing, Optional ByVal PageNumber As Integer = Nothing, Optional ByVal User As String = Nothing, Optional ByVal Find As String = Nothing, Optional ByVal SwitchHideSettingPanel As Boolean = False, Optional ByVal Reference As String = Nothing, Optional SubCategory As Integer = -1) As String
      Dim KeyValue As New ArrayList
      If Action <> 0 Then
        KeyValue.Add(QueryKey.ActionForum)
        KeyValue.Add(Action)
      End If
      If CBool(ForumId) Then
        KeyValue.Add(QueryKey.ForumId)
        KeyValue.Add(ForumId)
      End If
      If CBool(TopicID) Then
        KeyValue.Add(QueryKey.TopicId)
        KeyValue.Add(TopicID)
      End If
      If CBool(ReplyID) Then
        KeyValue.Add(QueryKey.ReplyId)
        KeyValue.Add(ReplyID)
      End If
      If Reference IsNot Nothing Then
        KeyValue.Add(QueryKey.Reference)
        KeyValue.Add(Reference)
      End If
      If CBool(PageNumber) Then
        KeyValue.Add(QueryKey.PageNumber)
        KeyValue.Add(PageNumber)
      End If
      If Not User Is Nothing Then
        KeyValue.Add(QueryKey.User)
        KeyValue.Add(User)
      End If
      If SwitchHideSettingPanel Then
        KeyValue.Add("SwitchHideSettingPanel")
        KeyValue.Add(SwitchHideSettingPanel)
      End If
      If Action <> ActionType.Show Then
        If Not Find Is Nothing Then
          KeyValue.Add(QueryKey.FindText)
          KeyValue.Add(Find)
        End If
      End If
      If SubCategory <> -1 Then
        KeyValue.Add(QueryKey.SubCategory)
        KeyValue.Add(SubCategory)
      End If

      Dim StringArray(KeyValue.Count - 1) As String
      For N As Integer = 0 To KeyValue.Count - 1
        StringArray(N) = CStr(KeyValue(N))
      Next
      Dim Href As String = Common.Href(Subsite, AbsoluteAddress, "forum.aspx", StringArray)
      If Jump IsNot Nothing Then
        Href &= "#" & Jump
      End If
      Return Href
    End Function

    Sub RemoveCacheOfTopicListAndTopicListByCategories(ByVal ForumId As Integer)
      If Common.WebCache IsNot Nothing Then
        SyncLock CacheKeysByForumId
          If CacheKeysByForumId.ContainsKey(ForumId) Then
            Dim KeysCollection As Collections.Specialized.StringCollection = CacheKeysByForumId(ForumId)
            SyncLock KeysCollection
              For Each CacheKey As String In KeysCollection
                Common.WebCache.Remove(CacheKey)
              Next
            End SyncLock
          End If
        End SyncLock
      End If
    End Sub

    Private CacheKeysByForumId As New Collections.Generic.Dictionary(Of Integer, Collections.Specialized.StringCollection)
    Private Sub AddUsedCacheKeyToCollection(ByVal ForumId As Integer, ByVal Key As String)
      SyncLock CacheKeysByForumId
        Dim KeysCollection As Collections.Specialized.StringCollection
        If CacheKeysByForumId.ContainsKey(ForumId) Then
          KeysCollection = CacheKeysByForumId(ForumId)
        Else
          KeysCollection = New Collections.Specialized.StringCollection
          CacheKeysByForumId.Add(ForumId, KeysCollection)
        End If
        SyncLock KeysCollection
          If Not KeysCollection.Contains(Key) Then
            KeysCollection.Add(Key)
          End If
        End SyncLock
      End SyncLock
    End Sub

    Function ShowTopicsByCategory(ByVal User As User, ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal ShowCensored As Boolean, Optional ByVal Page As Page = Nothing) As Control
      If Admitted(ForumId, Setting) Then
        Dim Forum As Forum = CType(Forum.Load(CStr(ForumId)), ForumManager.Forum)

        If Page IsNot Nothing Then

          Dim MasterPage As Components.MasterPage
          MasterPage = CType(Page.Master, Components.MasterPage)
          MasterPage.MetaRevisitAfterDays = 1

          'Add meta-tag in Header for specify the RSS source for the forum
          AddRssReference(Page, Setting, ForumId)

          'Set Meta Tag Revisit after 1 Day
          MasterPage.MetaRevisitAfterDays = 1

          MasterPage.SetTrace(Forum.Trace(Setting))
        End If


        Dim CacheKey As String = Nothing
        If Common.WebCache IsNot Nothing Then
          If User.Username = "" Then
            CacheKey = "STBC" & " " & ForumId & " " & Setting.Language
            AddUsedCacheKeyToCollection(ForumId, CacheKey)
            Dim Result As Control = CType(Common.WebCache(CacheKey), UI.Control)
            If Result IsNot Nothing Then
              Dim Literal As New Literal
              SyncLock Result
                'Spiegazioni del "SyncLock":
                'E' stato loggato un errore "La raccolta è stata modificata dopo la creazione di un'istanza dell'enumeratore."
                'Probabilmente la conversione da Control a Stringa è fatta in simultanea con un altra istanza. 
                'L'aggiunta del SyncLock dovrebbe risolvere il problema, se l'errore si ripetesse occorrerà trovare un'altra soluzione
                Literal.Text = ControlToText(Result)
              End SyncLock
              Return Literal
            End If
          End If
        End If

        If Forum.ForumStructure IsNot Nothing Then
          'Sort Category and SubCategory
          Dim Categories As System.Collections.Generic.List(Of ForumStructure.Category)
          Categories = Forum.ForumStructure.CategoriesSorted


          Dim Groups(0) As System.Collections.Generic.List(Of ForumManager.Topic)
          Dim WithoutSubcategories As New System.Collections.Generic.List(Of ForumManager.Topic)
          Groups(0) = WithoutSubcategories
          For Each Category As ForumStructure.Category In Categories
            For Each Subcategory As ForumStructure.Category.Subcategory In Category.Subcategories
              Dim Subcategories As New System.Collections.Generic.List(Of ForumManager.Topic)
              If Subcategory.Id > UBound(Groups) Then
                ReDim Preserve Groups(Subcategory.Id)
              End If
              Groups(Subcategory.Id) = Subcategories
            Next
          Next

          Dim TopicsCache As System.Collections.Generic.Dictionary(Of Integer, ForumManager.Topic) = ForumManager.Topic.Topics(ForumId)
          Dim ShowHidden As Boolean = EnableShowHidden()

          Dim Topics() As Topic
          SyncLock Topic.Collection
            ReDim Topics(TopicsCache.Count - 1)
            TopicsCache.Values.CopyTo(Topics, 0)
          End SyncLock

          Dim GroupLength As Integer = Groups.Length
          For Each Topic As Topic In Topics
            If TopicMomentarilyHidden(Topic) = False OrElse ShowHidden Then
              If Topic.Censored = False OrElse ShowCensored = True Then
                Dim Id As Integer
                If Topic.SubCategory < 0 OrElse Topic.SubCategory >= GroupLength Then
                  Id = 0
                Else
                  Id = Topic.SubCategory
                End If
                Groups(Id).Add(Topic)
              End If
            End If
          Next

          'Sort
          For Each Group As System.Collections.Generic.List(Of ForumManager.Topic) In Groups
            SortTopic(ShowCensored, ShowHidden, CurrentUser.Username, Group)
          Next

          If CacheKey <> "" Then
            'Update TotalTopics by category
            Dim SaveForum As Boolean
            For Each Category As ForumStructure.Category In Categories
              For Each Subcategory As ForumStructure.Category.Subcategory In Category.Subcategories
                If Subcategory.TotalTopics <> Groups(Subcategory.Id).Count Then
                  SaveForum = True
                  Subcategory.TotalTopics = Groups(Subcategory.Id).Count
                End If
              Next
            Next
            If SaveForum Then
              Forum.ForumStructure.Save()
            End If
          End If

          Dim MainControl As New HtmlGenericControl("section") 'html5

          For Each Category As ForumStructure.Category In Categories
            Dim Panel As New WebControl(HtmlTextWriterTag.Fieldset)
            MainControl.Controls.Add(Panel)
            Panel.CssClass = "Menu"

            Dim Title As New WebControl(HtmlTextWriterTag.H2)
            Title.Controls.Add(TextControl(Category.Title))
            Panel.Controls.Add(Title)

            For Each Subcategory As ForumStructure.Category.Subcategory In Category.Subcategories
              AddSubPanel(Panel, Setting, Forum.Id, Subcategory.Id, Groups(Subcategory.Id))
            Next
          Next

          If CBool(Groups(0).Count) Then
            AddSubPanel(MainControl, Setting, Forum.Id, 0, Groups(0))
          End If

          If CacheKey <> "" Then
            Common.WebCache.Add(CacheKey, MainControl, Nothing, Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
          End If

          Return MainControl
        End If
      End If
      Return Nothing
    End Function

    Function Admitted(ForumId As Integer, Setting As SubSite) As Boolean
      If Setting.Forums IsNot Nothing Then
        Return Setting.Forums.Contains(ForumId)
      End If
      Return False
    End Function

    Private Sub AddSubPanel(ByVal Panel As Control, ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal SubCategory As Integer, ByVal Topics As System.Collections.Generic.List(Of ForumManager.Topic))
      Dim SubPanel As New WebControl(HtmlTextWriterTag.Fieldset)
      SubPanel.CssClass = "Menu"
      Panel.Controls.Add(SubPanel)
      SubPanel.Controls.Add(ForumManager.ShowTopicsList(CurrentUser, Setting, ForumId, New ForumManager.UserPreferences(CurrentUser).ShowCensored, , 3, SubCategory, , , , False, Topics))
    End Sub

    Function ShowTopicsList(ByVal User As User, ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal ShowCensored As Boolean, Optional ByVal CurrentPage As Integer = 0, Optional ByVal TopicsInPreview As Integer = 0, Optional ByVal SubCategory As Integer = -1, Optional ByVal Action As ActionType = ActionType.Show, Optional ByVal FindText As String = Nothing, Optional ByVal Page As Page = Nothing, Optional ByVal SetMetaRevisitAfter As Boolean = False, Optional ByVal Topics As System.Collections.Generic.List(Of ForumManager.Topic) = Nothing) As Control
      Dim Ctrl As New HtmlGenericControl("section") 'html5
      If Admitted(ForumId, Setting) Then
        Dim CurrentForum As Forum = ForumManager.CurrentForum(Setting, ForumId)
        If CurrentForum Is Nothing Then
          Return Nothing
        End If

        'Add title & subtitle
        Dim CurrentSubCategory As ForumStructure.Category.Subcategory = Nothing
        Dim TopicsNotClassified As Boolean
        If SubCategory = 0 Then
          TopicsNotClassified = True
        ElseIf SubCategory > 0 Then
          CurrentSubCategory = CurrentForum.SubCategory(SubCategory)
        End If

        Dim PageTitle As String = Nothing, PageDescription As String = Nothing
        Ctrl.Controls.Add(CurrentForum.TitleControl(Setting, CurrentSubCategory, TopicsNotClassified, PageTitle, PageDescription))

        Dim MasterPage As MasterPage = Nothing
        If Page IsNot Nothing Then
          MasterPage = CType(Page.Master, Components.MasterPage)
          If TopicsInPreview = 0 Then
            MasterPage.TitleDocument = PageTitle
            If PageDescription <> "" Then
              MasterPage.Description = PageDescription
            Else
              MasterPage.Description = PageTitle
            End If

            'Add trace
            If Page IsNot Nothing AndAlso CurrentForum.ForumStructure.Categories.Count <> 0 Then
              MasterPage.SetTrace(CurrentForum.Trace(Setting, SubCategory))
            End If
          End If

        End If

        If CurrentPage = 0 Then
          CurrentPage = 1
        End If

        Dim CacheKey As String = Nothing
        If Common.WebCache IsNot Nothing Then
          If User.Username = "" AndAlso Action = ActionType.Show AndAlso CurrentPage = 1 Then
            CacheKey = "STL" & " " & ForumId & " " & TopicsInPreview & " " & SubCategory & " " & Setting.Language
            If Setting.SEO.CopyPrevention.ForumAndComments Then
              CacheKey &= " " & Setting.Name
            End If
            AddUsedCacheKeyToCollection(ForumId, CacheKey)
            Dim Result As Control = CType(Common.WebCache(CacheKey), UI.Control)
            If Result IsNot Nothing Then
              Dim Literal As New Literal
              SyncLock Result
                Literal.Text = ControlToText(Result)
              End SyncLock
              Return Literal
            End If
          End If
        End If

        Dim TopicsForPage As Integer
        Dim IsPreview As Boolean = TopicsInPreview <> 0
        If CBool(TopicsInPreview) Then
          TopicsForPage = TopicsInPreview
        Else
          TopicsForPage = Config.Setup.Forum.TopicsForPage
        End If
        Dim Language As LanguageManager.Language = Setting.Language
        Dim Role As User.RoleType = User.Role(Setting.Name)

        Dim Table As New HtmlTable
        Dim c() As Integer
        If CBool(TopicsInPreview) Then
          Dim NewC() As Integer = {0, 1, 4}
          c = NewC
        Else
          If Role >= Authentication.User.RoleType.AdministratorJunior Then
            Dim NewC() As Integer = {0, 1, 2, 3, 4, 5}
            c = NewC
          ElseIf Role >= Authentication.User.RoleType.User Then
            Dim NewC() As Integer = {0, 1, 2, 3, 4, 5}
            c = NewC
          Else
            Dim NewC() As Integer = {0, 1, 2, 3, 4}
            c = NewC
          End If
        End If

        'add row Title
        Dim TitleRow As HtmlTableRow = Components.HeaderRow(c.GetUpperBound(0) + 1, HorizontalAlign.Center, True)
        For EachC As Integer = c.GetLowerBound(0) To c.GetUpperBound(0)
          Dim NC As Integer = c(EachC)
          Select Case NC
            Case 0  'Logo
              'Set RSS link
              TitleRow.Controls(EachC).Controls.Add(RssButton(ForumManager.Link(ActionType.ShowRSS, Setting.Name, , , ForumId, , , , , , , , SubCategory)))

              'Add meta-tag in Header for specify the RSS source for the forum
              If Page IsNot Nothing Then
                AddRssReference(Page, Setting, ForumId, SubCategory)
              End If

            Case 1  'Author & Topic
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 69))
              TitleRow.Controls(EachC).Controls.Add(BR)
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 62))
              TitleRow.Cells(EachC).Style.Add("width", "35%")
            Case 2  'Replies
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 70), True)
            Case 3  'Readed
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 71), True)
            Case 4  'Last user & Last message
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 66))
              TitleRow.Controls(EachC).Controls.Add(BR)
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 67))
            Case 5  'Operations
              AddLabel(TitleRow.Cells(EachC), Phrase(Language, 68))
          End Select
        Next

        'add row in table
        Table.Rows.Add(TitleRow)


        If CurrentForum IsNot Nothing Then
          If Topics Is Nothing Then
            Topics = AllTopics(ForumId, ShowCensored, Action, FindText, SubCategory)
          End If
          If Topics IsNot Nothing AndAlso Topics.Count <> 0 Then
            Dim FirstTopic, LastTopic, TotalPage As Integer
            If CBool(TopicsForPage) Then
              TotalPage = Topics.Count \ TopicsForPage + 1
              FirstTopic = (CurrentPage - 1) * TopicsForPage
              LastTopic = FirstTopic + TopicsForPage - 1
              If LastTopic > Topics.Count - 1 Then
                LastTopic = Topics.Count - 1
              End If
            Else
              FirstTopic = 0
              LastTopic = Topics.Count - 1
              TotalPage = 1
            End If

            For NTopic As Integer = FirstTopic To LastTopic
              Dim Topic As Topic = Topics(NTopic) : Dim FirstReply As Reply = Topic.FirstReply
              If FirstReply Is Nothing Then
                Log("FirstReplyIsNothing", 1000, CStr(ForumId), CStr(NTopic))
              Else
                Dim LastReply As Reply
                LastReply = Topic.LastReply(ShowCensored, EnableShowHidden, User.Username)

                'Set Meta Tag Revisit after x Days
                Dim FlagRevisitAfter As Boolean
                If FlagRevisitAfter = False Then
                  FlagRevisitAfter = True
                  If SetMetaRevisitAfter Then
                    SetRevisitAfrer(Page, LastReply)
                  End If
                End If

                Dim Row As HtmlTableRow = Components.Row(c.GetUpperBound(0) + 1, , True)

                For EachC As Integer = c.GetLowerBound(0) To c.GetUpperBound(0)
                  Dim NC As Integer = c(EachC)
                  Select Case NC
                    Case 0  'folder
                      'Row.Cells(EachC).HorizontalAlign = HorizontalAlign.Center
                      Row.Cells(EachC).Style.Add("text-align", "center") 'html5
                      Dim Folder As Components.IconType = IconOfTopic(Topic, User)
                      Row.Cells(EachC).Controls.Add(EnhancedLinkIcon(Setting.Skin, Folder, , Reply.QueryString(Setting, ForumId, Topic.ID, Topic.TotalPages(ShowCensored))))
                      Dim Icon As WebControl
                      If Topic.Closed Then
                        Icon = Components.IconUnicode(IconName.Block, True, Phrase(Setting.Language, 2025))
                        Row.Cells(EachC).Controls.Add(Icon)
                      Else
                        If CurrentForum.Type = Forum.TypeOfForum.TicketSystem Then
                          If CBool(Topic.AsResolved) Then
                            Icon = Components.IconUnicode(IconName.CheckMarkV, True, Phrase(Setting.Language, 2029))
                          Else
                            Icon = Components.IconUnicode(IconName.CheckMarkX, True, Phrase(Setting.Language, 2030))
                          End If
                          Row.Cells(EachC).Controls.Add(Icon)
                        End If
                      End If
                    Case 1  'author & topic
                      'Row.Cells(EachC).HorizontalAlign = HorizontalAlign.Left
                      'Row.Cells(EachC).Style.Add("text-align", "left") 'html5
                      'Row.Cells(EachC).Wrap = True
                      Row.Cells(EachC).Style.Add("white-Space", "normal") 'html5

                      Dim InfoUser As RenderMethod = Sub(Writer As System.Web.UI.HtmlTextWriter, Container As System.Web.UI.Control)
                                                       If FirstReply.AuthorAccount Is Nothing Then
                                                         QuickInfoUser(CurrentSetting, Authentication.User.Load(FirstReply.Author), CurrentForum).RenderControl(Writer)
                                                       Else
                                                         QuickInfoUserExternalAccount(FirstReply.Author, FirstReply.AuthorAccount).RenderControl(Writer)
                                                       End If
                                                     End Sub
                      Dim PlaceHolder As New PlaceHolder
                      PlaceHolder.SetRenderMethodDelegate(InfoUser)
                      Row.Cells(EachC).Controls.Add(PlaceHolder)

                      'Row.Cells(EachC).Controls.Add(QuickInfoUser(Setting, Authentication.User.Load(FirstReply.Author), ForumId))

                      AddDateAndTime(Row.Cells(EachC), FirstReply.Created)
                      Row.Cells(EachC).Controls.Add(BR)
                      Dim Title As String = FirstReply.Title
                      Try
                        If Title = Title.ToUpper Then
                          Title = Title.ToLower
                        End If
                      Catch ex As Exception
                        'title is nothing!
                      End Try
                      Dim Link As New HyperLink
                      Link.NavigateUrl = Reply.QueryString(Setting, ForumId, Topic.ID, 1)
                      Link.Text = HttpUtility.HtmlEncode(Title)
                      Link.Style.Add("font-weight", "bold")
                      Link.Style.Add("display", "block")
                      Row.Cells(EachC).Controls.Add(Link)
                    Case 2  'replies
                      Row.Cells(EachC).Style.Add("text-align", "center") 'html5
                      Row.Cells(EachC).InnerText = CStr(IfInt(ShowCensored, Topic.NReplies, Topic.NRepliesNotCensored) - 1)
                    Case 3  'readed
                      Row.Cells(EachC).Style.Add("text-align", "center") 'html5
                      Row.Cells(EachC).InnerText = CStr(Topic.Readed)
                    Case 4  'Last user & Last message
                      Row.Cells(EachC).Style.Add("width", "100%")
                      Row.Cells(EachC).Style.Add("white-Space", "normal") 'html5
                      If LastReply IsNot Nothing Then 'Prevent error

                        Dim InfoUser As RenderMethod = Sub(Writer As System.Web.UI.HtmlTextWriter, Container As System.Web.UI.Control)
                                                         If FirstReply.AuthorAccount Is Nothing Then
                                                           QuickInfoUser(CurrentSetting, Authentication.User.Load(LastReply.Author), CurrentForum).RenderControl(Writer)
                                                         Else
                                                           QuickInfoUserExternalAccount(LastReply.Author, LastReply.AuthorAccount).RenderControl(Writer)
                                                         End If
                                                       End Sub

                        Dim PlaceHolder As New PlaceHolder
                        PlaceHolder.SetRenderMethodDelegate(InfoUser)
                        Row.Cells(EachC).Controls.Add(PlaceHolder)
                        AddDateAndTime(Row.Cells(EachC), LastReply.Created)
                        AddLiteral(Row.Cells(EachC), "<br />")
                        Row.Cells(EachC).Controls.Add(Preview(LastReply, ShowCensored, Topic.TotalPages(ShowCensored), Setting))
                      End If
                    Case 5  'operations
                      'Row.Cells(EachC).HorizontalAlign = HorizontalAlign.Center
                      Row.Cells(EachC).Style.Add("text-align", "center") 'html5

                      'Add button for add topic to google bookmarks
                      Dim Bookmark As String = ForumManager.Link(ActionType.Show, Setting.Name, True, , ForumId, Topic.ID, , 1)
                      Dim Bookmarks As Control = Components.IconUnicode(IconName.BlackStar, , Phrase(Setting.Language, 134), HrefGoogleAddBookmarks(Setting.Language, Topic.Title, Bookmark, PathCurrentUrl), "_blank")

                      Row.Cells(EachC).Controls.Add(Bookmarks)

                      If (CBool(Stars(CurrentUser)) AndAlso CurrentForum.Type <> Forum.TypeOfForum.TicketSystem) OrElse AbleToCensore(Setting) Then
                        'Censore topic
                        Dim NavigateUrl As String = Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.RequireTopicCensore, , , ForumId, Topic.ID, 1))
                        Dim Censore As Control = Components.IconUnicode(IconName.ScissorBlack, , Phrase(Setting.Language, 3075), NavigateUrl)
                        Row.Cells(EachC).Controls.Add(Censore)
                      End If

                      If AbleToCensore(Setting) Then
                        'Delete topic
                        Dim NavigateUrl As String = Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.DeleteTopics, , , ForumId, Topic.ID, 1))
                        Dim Delete As Control = Components.IconUnicode(IconName.ScissorWhite, , Phrase(Setting.Language, 51), NavigateUrl)
                        Row.Cells(EachC).Controls.Add(Delete)
                      End If
                  End Select
                Next
                'add row in table
                Table.Rows.Add(Row)
              End If
            Next
            Ctrl.Controls.Add(Table)

            'Add Paginate
            If Not IsPreview Then
              If TotalPage > 1 Then
                Ctrl.Controls.Add(Paginate(Setting, TotalPage, CurrentPage, Action, ForumId, , FindText, SubCategory))
              End If
            End If
          Else
            Ctrl.Controls.Add(Components.Message(Phrase(Setting.Language, 3050), Setting))
          End If

          'Add button New Topic
          If Not IsPreview Then
            If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.Visitors Then
              Dim Text As String
              Dim Href As String
              Text = Phrase(Setting.Language, IfInt(CurrentForum.Type = Forum.TypeOfForum.TicketSystem, 2023, 72))
              Href = ForumManager.Link(ActionType.NewTopic, Setting.Name, , , ForumId, , , , , , , , SubCategory)
              Dim NewTopicButton As Control = Button(Setting, Text, Href, , Components.IconType.DocumentBlank, , True)
              If MasterPage IsNot Nothing Then
                MasterPage.AddButton(Text, Href, , Components.IconType.DocumentBlank, , True, , Setting.Aspect.SuggestTheBestChoiceByTheBlink)
                If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
                  MasterPage.Blink(NewTopicButton)
                End If
              End If
              Dim Buttons As New HtmlGenericControl("nav")
              Buttons.Controls.Add(NewTopicButton)
              Ctrl.Controls.Add(Buttons)
            End If
          End If
        End If
        'If Action <> ActionType.Show Then
        '    AddButtonReturnForm(Ctrl, ForumId)
        'End If

        If CacheKey <> "" Then
          'ATTENZIONE: Non trasformare Ctrl in un Litheral altrimenti la funzione ShowTopicsByCategory non restituisce più una cache dinamica (in grado di aggiornare dinamicamente il quick info user) 
          Common.WebCache.Add(CacheKey, Ctrl, Nothing, Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If
      End If
      Return Ctrl
    End Function

    Private Function CurrentForum(ByVal Setting As SubSite, ByVal ForumId As Integer) As Forum
      If Setting.Forums IsNot Nothing Then
        If Setting.Forums.Contains(ForumId) Then
          Return CType(ForumManager.Forum.Load(CStr(ForumId)), Forum)
        End If
      End If
      If ForumForInsideUse(ForumId) Then
        Return CType(ForumManager.Forum.Load(CStr(ForumId)), Forum)
      End If
      Return Nothing
    End Function

    Function IconOfTopic(ByVal Topic As Topic, ByVal User As User) As Components.IconType
      Dim FirsReply As Reply = Topic.FirstReply
      Dim Visitors As Boolean = User.GeneralRole = Authentication.User.RoleType.Visitors
      Dim HasWritedInTopic As Boolean
      If Not Visitors Then
        HasWritedInTopic = UserHasWritedInTopic(User.Username, Topic.ForumId, Topic.ID)
      End If
      If FirsReply IsNot Nothing Then
        If Topic.Censored Then
          Return Components.IconType.Folder2
        ElseIf FirsReply.Video <> "" Then
          If HasWritedInTopic Then
            Return Components.IconType.FolderVideo1
          Else
            Return Components.IconType.FolderVideo
          End If
        ElseIf FirsReply.Photo <> "" Then
          If HasWritedInTopic Then
            Return Components.IconType.FolderPics1
          Else
            Return Components.IconType.FolderPics
          End If
        End If
      End If
      If HasWritedInTopic Then
        Return Components.IconType.Folder1
      Else
        Return Components.IconType.Folder
      End If
    End Function

    Sub AddRssReference(ByVal Page As Page, ByVal Setting As SubSite, ByVal ForumId As Integer, Optional ByVal SubCategory As Integer = -1)
      'Add meta-tag in Header for specify the RSS source for the forum
      Dim Meta As New HtmlLink
      Meta.Attributes.Add("rel", "alternate")
      Meta.Attributes.Add("type", "application/rss+xml")
      Meta.Attributes.Add("title", "Feed RSS")
      Meta.Href = ForumManager.Link(ActionType.ShowRSS, Setting.Name, , , ForumId, , , , , , , , SubCategory)
      Page.Header.Controls.Add(Meta)
    End Sub

    Function IsBlockedUntil(ByVal User As User) As Date
      'Check if user is temporary blocked
      Dim Admonition As String = CStr(User.Attribute("Admonition"))
      Dim LastAmmonition As Date, Value As Integer
      If Admonition <> "" Then
        Dim Data() As String = Split(Admonition, " ")
        LastAmmonition = DateTime.FromOADate(Val(Data(0)))
        Value = CInt(Data(1))
        If Value >= Setup.Security.QuorumToBlockUser Then
          If LastAmmonition.AddDays(Setup.Security.DaysRequiredForReadmissionBlockedUser) > Now.ToUniversalTime Then
            'User is blocked
            Return LastAmmonition.AddDays(Setup.Security.DaysRequiredForReadmissionBlockedUser)
          Else
            'Unblock user
            User.Attribute("Admonition") = ""
            User.Attribute("UserAdmonish") = ""
          End If
        End If
      End If
      Return Nothing
    End Function

    Public Sub RequireAdmonish(ByVal Setting As SubSite, ByVal UserName As String, ByVal ForumId As Integer)
      'Limit at one request of Censore for session 
      Dim NameFlag As String = "RequireAdmonish" & ForumId & "," & UserName
      If HttpContext.Current.Session(NameFlag) Is Nothing Then
        HttpContext.Current.Session(NameFlag) = True
        Dim User As User = User.Load(UserName)
        If Not User Is Nothing Then
          Dim UserAdmonish As String = CStr(User.Attribute("UserAdmonish"))
          Dim ListUser() As String = Split(UserAdmonish, ",")
          If Array.IndexOf(ListUser, CurrentUser.Username) = -1 Then
            If UserAdmonish <> "" Then
              UserAdmonish &= ","
            End If
            UserAdmonish &= CurrentUser.Username
            User.Attribute("UserAdmonish") = UserAdmonish
            If User.Role(Setting.Name) <= Authentication.User.RoleType.Senior Then
              Dim Admonition As String = CStr(User.Attribute("Admonition"))
              Dim LastAmmonition As Date, Value As Integer
              If Admonition <> "" Then
                Dim Data() As String = Split(Admonition, " ")
                LastAmmonition = DateTime.FromOADate(Val(Data(0)))
                If LastAmmonition.AddDays(Setup.Security.DaysToWaitForTheExpirationOfTheAdmonition) > Now.ToUniversalTime Then
                  Value = CInt(Data(1))
                End If
              End If

              Dim AddValue As Integer
              If AbleToAdmonish(Setting) Then
                AddValue += Setup.Security.QuorumToBlockUser
              Else
                AddValue += Stars(CurrentUser)
              End If
              Value += AddValue
              User.Attribute("Admonition") = ReplaceBin(Now.ToUniversalTime.ToOADate.ToString, ",", ".") & " " & Value
              User.Save()

              'Log This operation
              Extension.Log("Admonish", 1000, CurrentUser.Username, CStr(AddValue), UserName)
            End If
          End If
        End If
      End If
    End Sub

    Public Sub RequireCensore(ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal ReplyID As Integer)
      If ReplyID = 0 Then
        ReplyID = 1
      End If
      Dim Reply As Reply
      Reply = Reply.Load(ForumId, TopicID, ReplyID)

      Dim NameFlag As String = "RequireCensore" & ForumId & "," & TopicID & "," & ReplyID
      If HttpContext.Current.Session(NameFlag) Is Nothing Then
        HttpContext.Current.Session(NameFlag) = True
        Reply.RequestCensorship += Stars(CurrentUser)
        'Log This operation
        Extension.Log("Censored", 1000, CurrentUser.Username, CStr(ForumId), CStr(TopicID), CStr(ReplyID))
      End If
    End Sub
    Public Sub RequireDelete(ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal ReplyID As Integer)
      If AbleToCensore(Setting) Then
        If ReplyID = 1 Then
          'delete topic
          Topic.Delete(ForumId, TopicID)
        End If
      End If
    End Sub
    Public Sub RequireSetCloseTopic(ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal TopicID As Integer, Close As Boolean)
      If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
        'close topic
        Dim Topic As Topic = Topic.Load(ForumId, TopicID)
        Topic.Closed = Close
        Topic.Save()
      End If
    End Sub
    Public Sub RequireSetTopicAsResolved(ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal TopicID As Integer, SetAsResolved As Integer)
      Dim Topic As Topic = Topic.Load(ForumId, TopicID)
      If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior OrElse (CurrentUser.Username = Topic.FirstReply.Author AndAlso Topic.FirstReply.AuthorAccount Is Nothing) Then
        If Not Topic.Closed Then
          'close topic
          Topic.AsResolved = SetAsResolved
          Topic.Save()
        End If
      End If
    End Sub
    Public Function AbleToCensore(ByVal Setting As SubSite, Optional ByVal Proprietary As User = Nothing) As Boolean
      If Proprietary IsNot Nothing Then
        If StrComp(CurrentUser.Username, Proprietary.Username, CompareMethod.Text) = 0 Then
          Return True
        End If
      End If
      If Setting Is Nothing Then
        Setting = CurrentSetting()
      End If
      Return CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior
    End Function
    Public Function AbleToAdmonish(ByVal Setting As SubSite) As Boolean
      Return CurrentUser.Role(Setting.Name) > Authentication.User.RoleType.Senior
    End Function

    Enum ActionType
      Show
      NewTopic
      Reply
      Modify
      Unsubscribe
      Subscribe
      ChatModeRefresh
      FindAllWords
      FindPhrase
      FindOneWords
      RequireCensore
      ShowRSS
      RequireAdmonish
      NotUsed 'Rimpiazzare questa la prossima volta che occorre definire una azione 
      ShowXML
      RequireDelete
      SetSubcategory
    End Enum

    Function ForumList(ByVal Setting As SubSite) As Control
      Dim Control As New Control
      If Setting.Forums IsNot Nothing Then
        For Each ForumId As Integer In Setting.Forums
          Dim Forum As Forum = CType(ForumManager.Forum.Load(CStr(ForumId)), ForumManager.Forum)
          Control.Controls.Add(Forum.Summary(Setting))
        Next
      End If
      Return Control
    End Function

    Function Paginate(ByVal Setting As SubSite, ByVal TotalPage As Integer, ByVal CurrentPage As Integer, ByVal Action As ActionType, ByVal ForumId As Integer, Optional ByVal TopicID As Integer = Nothing, Optional ByVal FindText As String = Nothing, Optional ByVal SubCategory As Integer = 0) As HtmlGenericControl
      If TotalPage > 1 Then
        Dim Ctrl As New HtmlGenericControl("nav")
        Dim Href As String
        If CBool(TopicID) Then
          Href = Link(Action, Setting.Name, , , ForumId, TopicID)
        Else
          Href = Link(Action, Setting.Name, , , ForumId, , , , , FindText, , , SubCategory)
        End If
        If TotalPage > Setup.Forum.NPaginating Then
          Dim Icon As New WebControls.HyperLink
          Icon.Text = ChrW(8678) 'Left
          Icon.NavigateUrl = Href & "&" & QueryKey.PageNumber & "=" & 1
          Ctrl.Controls.Add(Icon)
        End If
        Dim First As Integer = CurrentPage + 1 - Setup.Forum.NPaginating \ 2
        If First < 1 Then
          First = 1
        End If
        Dim Last As Integer = CurrentPage + Setup.Forum.NPaginating \ 2
        If Last - First < Setup.Forum.NPaginating Then
          Last = First + Setup.Forum.NPaginating - 1
        End If
        If Last > TotalPage Then
          Last = TotalPage
          First = Last - Setup.Forum.NPaginating + 1
          If First < 1 Then
            First = 1
          End If
        End If
        For NPage As Integer = First To Last
          Ctrl.Controls.Add(New LiteralControl(" "))
          If NPage = CurrentPage Then
            Ctrl.Controls.Add(New LiteralControl("<strong>" & NPage & "</strong>"))
          Else
            Dim Rel As Rel
            If NPage = CurrentPage - 1 Then
              Rel = Components.Rel.Prev
            ElseIf NPage = CurrentPage + 1 Then
              Rel = Components.Rel.Next
            Else
              Rel = Components.Rel.None
            End If
            Ctrl.Controls.Add(Components.Link(Href & "&" & QueryKey.PageNumber & "=" & NPage, CStr(NPage)))
          End If
        Next
        If TotalPage > Setup.Forum.NPaginating Then
          Ctrl.Controls.Add(New LiteralControl(" "))
          Dim Icon As New WebControls.HyperLink
          Icon.Text = ChrW(8680) 'Right
          Icon.NavigateUrl = Href & "&" & QueryKey.PageNumber & "=" & TotalPage
          Ctrl.Controls.Add(Icon)
        End If
        Return Ctrl
      End If
      Return Nothing
    End Function

    Public Function AbleToModifyReply(ByVal Setting As SubSite, ByVal Author As String, ByVal Create As Date, Optional ByVal AuthorAccount As String = Nothing) As Boolean
      Dim C1 As Boolean = CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.Administrator
      Dim C2 As Boolean
      If Author <> "" AndAlso AuthorAccount Is Nothing Then
        C2 = StrComp(Author, CurrentUser.Username, CompareMethod.Text) = 0
      End If
      Dim C3 As Boolean = DateDiff(DateInterval.Day, Create, Now) < 10 Or CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior
      If C1 Or (C2 And C3) Then
        Return True
      Else
        Return False
      End If
    End Function

    Private Function Recent(ByVal DateValue As Date) As Boolean
      If CurrentUser.LastAccess <> Nothing Then
        If DateValue > CurrentUser.LastAccess Then
          Recent = True
        End If
      End If
      Return False
    End Function

    Function UserHasWritedInTopic(ByVal UserName As String, ByVal ForumId As Integer, ByVal TopicID As Integer) As Boolean
      Dim Subscription As New Subscription(ForumId, TopicID)
      If Subscription.IsSubscript(UserName) = Subscription.TypeSubscription.NotDefinited Then
        Return False
      Else
        Return True
      End If
    End Function

    Public Sub AddDateAndTime(ByVal Control As Control, ByVal DateValue As Date)
      Dim PersonalizedDate As RenderMethod = Sub(Writer As System.Web.UI.HtmlTextWriter, Container As System.Web.UI.Control)
                                               Dim DateValueUser As Date = DateValue.ToLocalTime.AddSeconds(CurrentUser.TimeOffsetSeconds)
                                               Dim Setting As SubSite = CurrentSetting()
                                               Dim DateTime As New HtmlGenericControl("time")
                                               DateTime.Attributes.Add("datetime", DateValueUser.ToString("s"))
                                               DateTime.InnerText = " " & DateValueUser.ToString(Setting.DateTimeFormat, Setting.Culture)
                                               If Recent(DateValueUser) Then
                                                 DateTime.Attributes.Add("class", "Evidence")
                                               End If
                                               DateTime.RenderControl(Writer)
                                             End Sub
      Dim PlaceHolder As New PlaceHolder
      PlaceHolder.SetRenderMethodDelegate(PersonalizedDate)
      Control.Controls.Add(PlaceHolder)
    End Sub

    Private Function Preview(ByVal LastReply As Reply, ByVal ShowCensored As Boolean, ByVal TotalPages As Integer, ByVal Setting As SubSite) As Control
      Const Ln As Integer = 256
      Dim text As String = LastReply.InnerTextReply
      text = ReplaceBin(text, "<br />", "|")

      Dim Link As New HyperLink
      Link.NavigateUrl = Reply.QueryString(Setting, LastReply.ForumId, LastReply.TopicID, TotalPages)
      Link.Text = HttpUtility.HtmlEncode(TruncateText(text, Ln))
      If Setting.SEO.CopyPrevention.ForumAndComments Then
        Link.Text = ObfuscateHtml(Link.Text, Setting)
      End If
      Link.CssClass = "Preview"
      'Link.Style.Add("display", "block")
      'Link.Font.Size = FontUnit.Smaller
      Return Link
    End Function

    Function TopicMomentarilyHidden(ByVal Topic As Topic) As Boolean
      If CBool(Setup.Security.HoursEvaluationTimeNewUser) Then
        If DateDiff(DateInterval.Hour, Topic.Created, Now.ToUniversalTime) < Setup.Security.HoursEvaluationTimeNewUser Then
          If Topic.LastReplyNotCensoredId(False, Nothing) = 1 Then
            If Topic.FirstReply.Author IsNot Nothing AndAlso Topic.FirstReply.AuthorAccount Is Nothing Then
              Dim Author As User = Authentication.User.Load(Topic.FirstReply.Author)
              If DateDiff(DateInterval.Hour, Author.FirstMessageInForum, Now.ToUniversalTime) < Setup.Security.HoursEvaluationTimeNewUser Then
                If StrComp(Topic.FirstReply.Author, CurrentUser.Username, CompareMethod.Text) <> 0 Then
                  Return True
                End If
              End If
            End If
          End If
        End If
      End If
      Return False
    End Function
    Function ReplyMomentarilyHidden(ByVal Reply As Reply, Optional ByVal CheckAuthorCurrentUser As Boolean = True, Optional ByVal Topic As Topic = Nothing) As Boolean
      If Reply IsNot Nothing Then
        If Setup.Security.HoursEvaluationTimeNewUser <> 0 Then
          If DateDiff(DateInterval.Hour, Reply.Created, Now.ToUniversalTime) < Setup.Security.HoursEvaluationTimeNewUser Then
            If Reply.AuthorAccount Is Nothing Then
              Dim Author As User = Authentication.User.Load(Reply.Author)
              If Author IsNot Nothing Then
                If DateDiff(DateInterval.Hour, Author.FirstMessageInForum, Now.ToUniversalTime) < Setup.Security.HoursEvaluationTimeNewUser Then
                  If CheckAuthorCurrentUser = False OrElse StrComp(Author.Username, CurrentUser.Username, CompareMethod.Text) <> 0 Then
                    'Enabled show topic of new user if administrator reply in this topic
                    If Topic Is Nothing Then
                      Topic = Topic.Load(Reply.ForumId, Reply.TopicID)
                    End If
                    If Reply.ID <> 1 OrElse TopicMomentarilyHidden(Topic) Then
                      Return True
                    End If
                  End If
                End If
              End If
            End If
          End If
        End If
      End If
      Return False
    End Function

    Function EnableShowHidden() As Boolean
      Return CurrentUser.Role(CurrentSetting.Name) >= User.RoleType.AdministratorJunior
    End Function

    Public Sub FeedRssForum(ByRef RssFeed As FeedRSSManager.rss, ByVal Setting As SubSite, ByVal EnableShowHidden As Boolean, ByVal ForumId As Integer, Optional ByVal TopicId As Integer = Nothing, Optional ByVal SubCategory As Integer = -1)
      If CBool(TopicId) Then
        Dim Topic As Topic = Topic.Load(ForumId, TopicId)
        If Topic IsNot Nothing Then
          Dim FirstReply As Reply = Topic.FirstReply
          If FirstReply IsNot Nothing Then
            RssFeed.channel.title = FirstReply.Title
            For Each Reply As Reply In Topic.Replies(False)
              Dim RssItem As New rssChannelItem
              RssItem.link = ForumManager.Link(ActionType.Reply, Setting.Name, True, , ForumId, FirstReply.TopicID, IfInt(Reply.ID <> Topic.LastReplyId(EnableShowHidden), Reply.ID, 0))
              RssItem.title = FirstReply.Title
              RssItem.description = Reply.Text
              RssItem.pubDate = Format(Reply.Created, "R")
              If Reply.Photo <> "" Then
                Dim MyPhoto As Photo = Photo.Load(Reply.Photo)
                If MyPhoto IsNot Nothing Then
                  Dim Image As New Enclosure
                  Image.url = PathCurrentUrl() & MyPhoto.Src(Setting)
                  Image.type = MyPhoto.MimeType
                  RssItem.enclosure = Image
                End If
              End If
              RssFeed.channel.item.Add(RssItem)
            Next
          End If
        End If
      Else
        Dim Topics As System.Collections.Generic.List(Of ForumManager.Topic) = AllTopics(ForumId, False, , , SubCategory)
        'If Not Topics Is Nothing Then
        If Topics IsNot Nothing And Topics.Count <> 0 Then
          Dim Added As Integer
          Dim CurrentUserPreferences As UserPreferences = New UserPreferences(CurrentUser)
          For Each Topic As Topic In Topics
            Dim FirstReply As Reply = Topic.FirstReply
            If FirstReply IsNot Nothing Then
              Dim rssItem As New rssChannelItem
              rssItem.link = ForumManager.Link(ActionType.Show, Setting.Name, True, , ForumId, Topic.ID, , Topic.TotalPages(CurrentUserPreferences.ShowCensored))
              rssItem.title = FirstReply.Title
              rssItem.description = FirstReply.Text
              rssItem.pubDate = Format(FirstReply.Created, "R")
              If FirstReply.Photo <> "" Then
                Dim MyPhoto As Photo = Photo.Load(FirstReply.Photo)
                If MyPhoto IsNot Nothing Then
                  Dim Image As New Enclosure
                  Image.url = PathCurrentUrl() & MyPhoto.Src(Setting)
                  Image.type = MyPhoto.MimeType
                  rssItem.enclosure = Image
                End If
              End If
              RssFeed.channel.item.Add(rssItem)
              Added += 1
              If Added = Setup.Forum.TopicsForPage Then
                Exit For
              End If
            End If
          Next
        End If
      End If
    End Sub



    Function AllTopics(ByVal ForumId As Integer, ByVal ShowCensored As Boolean, Optional ByVal Action As ActionType = ActionType.Show, Optional ByVal FindText As String = Nothing, Optional ByVal SubCategory As Integer = -1) As System.Collections.Generic.List(Of ForumManager.Topic)
      'Speed up this operation!
 
      Dim TopicsCache As System.Collections.Generic.Dictionary(Of Integer, ForumManager.Topic) = ForumManager.Topic.Topics(ForumId)
      Dim Topics As New System.Collections.Generic.List(Of ForumManager.Topic)
      Dim ShowHidden As Boolean = EnableShowHidden()
      Dim TimeOut As Date = Now.AddMilliseconds(1000)

      If Not TopicsCache Is Nothing Then


        'If TopicsCache.ContainsValue(Nothing) Then
        '  Stop
        'End If

        If Setup.Performance.MultyThread Then
          'Multy thread
          Try
            Threading.Tasks.Parallel.ForEach(TopicsCache.Values, Sub(Topic)
                                                                   If Now > TimeOut Then
                                                                     Exit Sub
                                                                   End If
                                                                   If Topic IsNot Nothing Then
                                                                     If TopicMomentarilyHidden(Topic) = False OrElse ShowHidden Then
                                                                       Dim Add As Boolean
                                                                       Select Case Action
                                                                         Case ActionType.FindAllWords, ActionType.FindOneWords, ActionType.FindPhrase
                                                                           Add = FindInTopic(ForumId, Topic.ID, ShowCensored, Action, FindText, ShowHidden)
                                                                         Case Else
                                                                           Add = True
                                                                       End Select
                                                                       If Add Then
                                                                         If Topic.Censored = False OrElse ShowCensored = True Then
                                                                           'add to list only not Censored topics
                                                                           If SubCategory = -1 OrElse SubCategory = Topic.SubCategory Then
                                                                             'Restrict to determinate subcategoru
                                                                             Topics.Add(Topic)
                                                                           End If
                                                                         End If
                                                                       End If
                                                                     End If                                                                 
                                                                   End If
                                                                 End Sub)
          Catch ex As Exception
            'Error: System.Web.HttpUnhandledException: Generata eccezione di tipo System.Web.HttpUnhandledException. ---> System.InvalidOperationException: L'insieme e stato modificato. L'operazione di enumerazione potrebbe non essere eseguita.
            'Non uso il SyncLock perchè tenerlo bloccato significherebbe fermare gli altri thread che accedono alla risorca. Comunque sia questo è un evento molto raro e la sua eventuale gestione implicheremme un calo di prestazioni.
          End Try
        Else
          'Single thread
          Try
            For Each Topic As Topic In TopicsCache.Values
              If Now > TimeOut Then
                Exit For
              End If
              If Topic IsNot Nothing Then
                If TopicMomentarilyHidden(Topic) = False OrElse ShowHidden Then
                  Dim Add As Boolean
                  Select Case Action
                    Case ActionType.FindAllWords, ActionType.FindOneWords, ActionType.FindPhrase
                      Add = FindInTopic(ForumId, Topic.ID, ShowCensored, Action, FindText, ShowHidden)
                    Case Else
                      Add = True
                  End Select
                  If Add Then
                    If Topic.Censored = False OrElse ShowCensored = True Then
                      'add to list only not Censored topics
                      If SubCategory = -1 OrElse SubCategory = Topic.SubCategory Then
                        'Restrict to determinate subcategoru
                        Topics.Add(Topic)
                      End If
                    End If
                  End If
                End If
              End If
            Next
          Catch ex As Exception
            'Error: System.Web.HttpUnhandledException: Generata eccezione di tipo System.Web.HttpUnhandledException. ---> System.InvalidOperationException: L'insieme e stato modificato. L'operazione di enumerazione potrebbe non essere eseguita.
            'Non uso il SyncLock perchè tenerlo bloccato significherebbe fermare gli altri thread che accedono alla risorca. Comunque sia questo è un evento molto raro e la sua eventuale gestione implicheremme un calo di prestazioni.
          End Try
        End If
      End If

      'If Topics.Contains(Nothing) Then
      '  Stop
      'End If

      SortTopic(ShowCensored, ShowHidden, CurrentUser.Username, Topics)

      Return Topics
    End Function

    Sub SortTopic(ByVal ShowCensored As Boolean, ByVal ShowHidden As Boolean, ByVal Username As String, ByRef Topics As System.Collections.Generic.List(Of ForumManager.Topic))
      Try
        If CBool(Topics.Count) Then
          Dim Compare As New LastMessageComparer(ShowCensored, ShowHidden, Username)
          Topics.Sort(Compare)
        End If
      Catch ex As Exception
      End Try
    End Sub

  
    Private Function FindInTopic(ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal FindInCensoredReply As Boolean, ByVal Action As ActionType, ByVal FindText As String, ByVal ShowHidden As Boolean) As Boolean
      Dim Words() As String = Nothing
      If Action <> ActionType.FindPhrase Then
        Words = Split(FindText)
      End If
      For Each Reply As Reply In Topic.AllReplies(ForumId, TopicID, FindInCensoredReply, ShowHidden)
        Dim Source As String = Reply.Title & " " & Reply.Author & " " & Reply.Text
        Select Case Action
          Case ActionType.Show
            Return True
          Case ActionType.FindAllWords
            Return CBool(FindWord(1, Source, Words))
          Case ActionType.FindPhrase
            Return CBool(FindWord(1, Source, FindText))
          Case ActionType.FindOneWords
            Return CBool(FindWord(1, Source, Words))
        End Select
      Next
      Return False
    End Function

    Class LastMessageComparer
      Implements IComparer(Of ForumManager.Topic)
      Private ShowCensored As Boolean
      Private ShowHiden As Boolean
      Private User As String
      Public Function Compare(ByVal Topic1 As Topic, ByVal Topic2 As Topic) As Integer Implements IComparer(Of ForumManager.Topic).Compare
        Dim x1, x2 As Date
        'Try        
        If ShowCensored Then
          x1 = Topic1.LastReplyCreate(ShowHiden, User)
          x2 = Topic2.LastReplyCreate(ShowHiden, User)
        Else
          x1 = Topic1.LastReplyNotCensoredCreate(ShowHiden, User)
          x2 = Topic2.LastReplyNotCensoredCreate(ShowHiden, User)
        End If

        Select Case x1
          Case Is > x2
            Return -1
          Case Is < x2
            Return 1
        End Select
        Return 0
      End Function 'Compare

      Public Sub New(ByVal ShowCensored As Boolean, ByVal ShowHiden As Boolean, ByVal User As String)
        Me.ShowCensored = ShowCensored
        Me.ShowHiden = ShowHiden
        Me.User = User
      End Sub
    End Class 'SizeComparer

    Class ForumSetting
      Public ID As Integer
      Function Name() As String
        If NameInSubsite <> "" Then
          Return NameInSubsite
        Else
          Return NameInConfiguration
        End If
      End Function
      Function Description() As String
        If DescriptionInSubsite <> "" Then
          Return DescriptionInSubsite
        Else
          Return DescriptionInConfiguration
        End If
      End Function
      Public NameInSubsite As String
      Public NameInConfiguration As String
      Public DescriptionInSubsite As String
      Public DescriptionInConfiguration As String

      Sub Load(ByVal Forum As ForumManager.Forum)
        Me.NameInSubsite = Forum.Name
        Me.DescriptionInSubsite = Forum.Description
        Me.ID = Forum.Id
      End Sub
      Sub Save()

      End Sub

      Public Sub New(ByVal Forum As ForumManager.Forum)
        Load(Forum)
      End Sub

    End Class

    Class Topic
      Public Sub New()
        'Do not remove
      End Sub
      Public ID As Integer
      Public ForumId As Integer
      Public Closed As Boolean
      Public AsResolved As Integer 'Id of best reply or -1 (true) or 0 (false)
      Public Created As Date
      Public SubCategory As Integer
      Public Reference As String
      Public Keywords As String
      Public Readed As Integer
      Public Censored As Boolean

      Public NReplies As Integer
      Private m_LastReplyId As Integer
      Private m_LastReplyCreated As Date
      Private LastReplyAuthor As String
      Private LastReplyAuthorAccount As String

      Public NRepliesNotCensored As Integer
      Private m_LastReplyNotCensoredId As Integer
      Private m_LastReplyNotCensoredCreated As Date
      Private LastReplyNotCensoredAuthor As String
      Private LastReplyNotCensoredAuthorAccount As String

      Private m_LastNoHideReplyId As Integer
      Private m_LastNoHideReplyCreate As Date
      Private m_LastNoHideReplyNotCensoredId As Integer
      Private m_LastNoHideReplyNotCensoredCreate As Date

      Private LastNoHideReplyNotCensoredCheck As CheckNoHide
      Private LastReplyNotCensoredAuthorFirstMessage As Date

      Private LastNoHideReplyCheck As CheckNoHide
      Private LastReplyAuthorFirstMessage As Date

      Public Function Title() As String
        Dim FirstReply As Reply = Me.FirstReply
        If FirstReply IsNot Nothing Then
          Return FirstReply.Title
        End If
        Return Nothing
      End Function

      Shared Function Exists(ByVal ForumId As Integer, ByVal TopicID As Integer) As Boolean
        Dim Root As New IO.DirectoryInfo(PathTopic(ForumId, TopicID))
        If Root.Exists = True And (Root.Attributes And IO.FileAttributes.Hidden) = 0 Then
          Return True
        End If
        Return False
      End Function

      Private m_FirstReplyId As Integer = 1
      Public ReadOnly Property FirstReplyId() As Integer
        Get
          Return m_FirstReplyId
        End Get
      End Property

      'Function NextNewReplyId() As Integer
      '	Return m_LastReplyId + 1
      'End Function

      Enum CheckNoHide
        Unkonw
        Hide
        Visible
      End Enum
      Private Sub CheckNoHideLastReply(ByVal NoCensored As Boolean)
        Dim LastReply As Reply = Nothing
        Dim ReplyCreatedCreated As Date
        If NoCensored Then
          ReplyCreatedCreated = m_LastReplyNotCensoredCreated
        Else
          ReplyCreatedCreated = m_LastReplyCreated
        End If
        If DateDiff(DateInterval.Hour, ReplyCreatedCreated, Now.ToUniversalTime) < Setup.Security.HoursEvaluationTimeNewUser Then
          LastReply = Reply.Load(ForumId, ID, IfInt(NoCensored, m_LastReplyNotCensoredId, m_LastReplyId))
        End If
        If LastReply IsNot Nothing AndAlso ReplyMomentarilyHidden(LastReply, False, Me) Then
          Dim Reply As Reply = FindLastReply(Me, NoCensored, True)
          Dim Author As User = Authentication.User.Load(LastReply.Author)
          If NoCensored Then
            m_LastNoHideReplyNotCensoredId = Reply.ID
            m_LastNoHideReplyNotCensoredCreate = Reply.Created
            LastNoHideReplyNotCensoredCheck = CheckNoHide.Hide
            LastReplyNotCensoredAuthorFirstMessage = Author.FirstMessageInForum
          Else
            m_LastNoHideReplyId = Reply.ID
            m_LastNoHideReplyCreate = Reply.Created
            LastNoHideReplyCheck = CheckNoHide.Hide
            LastReplyAuthorFirstMessage = Author.FirstMessageInForum
          End If
        Else
          Select Case NoCensored
            Case True
              LastNoHideReplyNotCensoredCheck = CheckNoHide.Visible
            Case Else
              LastNoHideReplyCheck = CheckNoHide.Visible
          End Select
        End If
      End Sub
      Private Sub UpdateNoHideLastsMessages()
        CheckNoHideLastReply(False)
        CheckNoHideLastReply(True)
      End Sub

      Public ReadOnly Property LastReplyId(ByVal ShowHiden As Boolean, Optional ByVal User As String = Nothing) As Integer
        Get
          If LastNoHideReplyCheck = CheckNoHide.Visible OrElse ShowHiden OrElse (LastReplyAuthorAccount Is Nothing AndAlso User = LastReplyAuthor) Then
            Return m_LastReplyId
          Else
            Return m_LastNoHideReplyId
          End If
        End Get
      End Property
      Public ReadOnly Property LastReplyNotCensoredId(ByVal ShowHiden As Boolean, Optional ByVal User As String = Nothing) As Integer
        Get
          If LastNoHideReplyNotCensoredCheck = CheckNoHide.Visible OrElse ShowHiden OrElse (LastReplyNotCensoredAuthorAccount Is Nothing AndAlso User = LastReplyNotCensoredAuthor) Then
            Return m_LastReplyNotCensoredId
          Else
            Return m_LastNoHideReplyNotCensoredId
          End If
        End Get
      End Property
      Public ReadOnly Property LastReplyCreate(ByVal ShowHiden As Boolean, Optional ByVal User As String = Nothing) As Date
        Get
          If LastNoHideReplyCheck = CheckNoHide.Visible OrElse ShowHiden OrElse (LastReplyAuthorAccount Is Nothing AndAlso User = LastReplyAuthor) Then
            Return m_LastReplyCreated
          Else
            Return m_LastNoHideReplyCreate
          End If
        End Get
      End Property
      Public ReadOnly Property LastReplyNotCensoredCreate(ByVal ShowHiden As Boolean, Optional ByVal User As String = Nothing) As Date
        Get
          If LastNoHideReplyNotCensoredCheck = CheckNoHide.Visible OrElse ShowHiden OrElse (LastReplyNotCensoredAuthorAccount Is Nothing AndAlso User = LastReplyNotCensoredAuthor) Then
            Return m_LastReplyNotCensoredCreated
          Else
            Return m_LastNoHideReplyNotCensoredCreate
          End If
        End Get
      End Property

      Function FirstReply() As Reply
        Return Reply.Load(ForumId, ID, FirstReplyId)
      End Function

      Function LastReply(ByVal ShowCensored As Boolean, ByVal ShowHiden As Boolean, Optional ByVal User As String = Nothing, Optional ByVal RecursiveCount As Integer = 0) As Reply
        If ShowCensored Then
          If LastNoHideReplyCheck = CheckNoHide.Visible OrElse ShowHiden OrElse (LastReplyAuthorAccount Is Nothing AndAlso User = LastReplyAuthor) Then
            Return Reply.Load(ForumId, ID, m_LastReplyId)
          ElseIf DateDiff(DateInterval.Hour, LastReplyAuthorFirstMessage, Now.ToUniversalTime) >= Setup.Security.HoursEvaluationTimeNewUser Then
            'Hide of last reply is expired
            CheckNoHideLastReply(False)
            If RecursiveCount >= 2 Then

              Log("ErrorRecursive", 1000, "Function LastReply (All)", User, CStr(Me.ForumId), CStr(LastNoHideReplyCheck), CStr(Me.m_LastReplyId), CStr(Me.ID), CStr(m_LastNoHideReplyId), CStr(LastNoHideReplyNotCensoredCheck), CStr(Me.m_LastNoHideReplyNotCensoredId), CStr(Me.m_LastNoHideReplyNotCensoredId), CStr(DateDiff(DateInterval.Hour, m_LastReplyCreated, Now.ToUniversalTime)))
              Return Reply.Load(ForumId, ID, m_LastNoHideReplyId)

            End If
            Return LastReply(ShowCensored, ShowHiden, User, RecursiveCount + 1)
          Else
            Return Reply.Load(ForumId, ID, m_LastNoHideReplyId)
          End If
        Else
          If LastNoHideReplyNotCensoredCheck = CheckNoHide.Visible OrElse ShowHiden OrElse (LastReplyNotCensoredAuthorAccount Is Nothing AndAlso User = LastReplyNotCensoredAuthor) Then
            Return Reply.Load(ForumId, ID, m_LastReplyNotCensoredId)
            'ElseIf Now.ToUniversalTime > m_LastReplyNotCensoredCreated.AddHours(HoursEvaluationTimeNewUser) Then
          ElseIf DateDiff(DateInterval.Hour, LastReplyNotCensoredAuthorFirstMessage, Now.ToUniversalTime) >= Setup.Security.HoursEvaluationTimeNewUser Then
            'Hide of last reply is expired     
            CheckNoHideLastReply(True)
            If RecursiveCount >= 2 Then

              Log("ErrorRecursive", 1000, "Function LastReply (noCensore)", User, CStr(Me.ForumId), CStr(LastNoHideReplyCheck), CStr(Me.m_LastReplyId), CStr(Me.ID), CStr(m_LastNoHideReplyId), CStr(LastNoHideReplyNotCensoredCheck), CStr(Me.m_LastNoHideReplyNotCensoredId), CStr(Me.m_LastNoHideReplyNotCensoredId), CStr(DateDiff(DateInterval.Hour, m_LastReplyNotCensoredCreated, Now.ToUniversalTime)))
              Return Reply.Load(ForumId, ID, m_LastNoHideReplyNotCensoredId)

            End If
            Return LastReply(ShowCensored, ShowHiden, User, RecursiveCount + 1)
          Else
            Return Reply.Load(ForumId, ID, m_LastNoHideReplyNotCensoredId)
          End If
        End If
      End Function
      Function TotalPages(ByVal IncludeConsured As Boolean) As Integer
        If IncludeConsured Then
          Return (NReplies - 1) \ Setup.Forum.RepliesForPages + 1
        Else
          Return (NRepliesNotCensored - 1) \ Setup.Forum.RepliesForPages + 1
        End If
      End Function

      Public Function Replies(ByVal ShowCensored As Boolean) As Collections.Generic.List(Of Reply)
        Dim Root As String = Extension.MapPath(ForumSubDirectory & "\" & ForumId & "\" & ID)
        Dim Dir As New System.IO.DirectoryInfo(Root)
        If Dir.Exists Then
          Dim Collection As New Collections.Generic.List(Of Reply)
          Dim Files As System.IO.FileSystemInfo() = Dir.GetFileSystemInfos("*.htm")
          For Each File As System.IO.FileSystemInfo In Files
            Dim ReplyID As Integer = CInt(Val(File.Name))
            Dim Reply As Reply = Reply.Load(ForumId, ID, ReplyID)
            If ShowCensored Or Reply.Censored = False Then
              Collection.Add(Reply)
            End If
          Next
          Return Collection
        End If
        Return Nothing
      End Function

      Public Sub New(ByVal ForumId As Integer, ByVal SubCategory As Integer, ByVal Author As String, ByVal Title As String, ByVal Keywords As String, ByVal Text As String, Optional ByVal Photo As String = Nothing, Optional ByVal Video As String = Nothing, Optional ByVal SaveNow As Boolean = True, Optional ByVal Reference As String = Nothing, Optional ByVal AuthorAccoun As String = Nothing, Optional ByVal Id As Integer = 0, Optional ByVal PollDetection As Boolean = True, Optional Created As Date = Nothing)
        If SubCategory < 0 Then
          SubCategory = 0
        End If
        If CBool(Id) Then
          Me.ID = Id
          System.IO.Directory.CreateDirectory(Root(ForumId) & "/" & Me.ID)
        Else
          Me.ID = NextID(ForumId)

          'Uptate number of total topics
          Dim Forum As Forum = CType(ForumManager.Forum.Load(CStr(ForumId)), ForumManager.Forum)
          Forum.TotalTopics += 1
          Dim [Sub] As ForumManager.ForumStructure.Category.Subcategory = Forum.SubCategory(SubCategory)
          Dim SaveStructure As Boolean
          If [Sub] IsNot Nothing Then
            SaveStructure = True
            [Sub].TotalTopics += 1
          End If
          Forum.Save(SaveStructure)

        End If
        Me.Keywords = Trim(Keywords)
        Me.ForumId = ForumId
        Me.SubCategory = SubCategory
        Dim AllTopics As Collections.Generic.Dictionary(Of Integer, Topic) = Topic.Topics(ForumId)
        If AllTopics.ContainsKey(Me.ID) Then
          AllTopics.Remove(Me.ID)
        End If
        AllTopics.Add(Me.ID, Me)
        Me.Reference = Reference
        Dim FirstReply As Reply = New Reply(ForumId, Me.ID, Author, Title, Keywords, Text, , , Photo, Video, , AuthorAccoun, PollDetection, Created)

        'Quello che segue viene già settato con SetNewLastReply chiamato da New Reply
        'Me.Created = FirstReply.Created

        'm_FirstReplyId = FirstReply.ID
        'm_LastReplyId = FirstReplyId
        'm_LastReplyNotCensoredId = FirstReplyId
        'm_LastReplyCreated = FirstReply.Created
        'm_LastReplyNotCensoredCreated = FirstReply.Created
        'LastReplyAuthor = FirstReply.Author
        'LastReplyAuthorAccount = FirstReply.AuthorAccount
        'LastReplyNotCensoredAuthor = FirstReply.Author
        'LastReplyNotCensoredAuthorAccount = FirstReply.AuthorAccount

        'UpdateNoHideLastsMessages() 'Viene eseguito già con New Reply

        'Il topic viene salvato comunque con New Reply
        'If SaveNow Then
        'Save()
        'End If

      End Sub

      Public Shared Function AllReplies(ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal ShowCensored As Boolean, ByVal ShowHiden As Boolean) As Reply()
        Dim Root As String = Extension.MapPath(ForumSubDirectory & "\" & ForumId & "\" & TopicID)
        'Dim dir As New System.IO.DirectoryInfo(Root)
        If System.IO.Directory.Exists(Root) Then
          Dim Documents As String() = System.IO.Directory.GetFiles(Root, "*.htm")
          Array.Sort(Documents)
          Dim Replies(Documents.GetUpperBound(0)) As Reply
          Dim N As Integer
          Dim replyID As Integer
          Dim LastReply As Integer
          Dim Topic As Topic = Topic.Load(ForumId, TopicID)
          For Each File As String In Documents
            File = FileManager.FileName(File)
            replyID = CInt(Val(File))
            LastReply = replyID
            Dim Reply As Reply = Reply.Load(ForumId, TopicID, replyID)
            If ReplyMomentarilyHidden(Reply, , Topic) = False OrElse EnableShowHidden() Then
              If ShowCensored OrElse Reply.Censored = False Then
                If ShowHiden OrElse Reply.IsHiden = False Then
                  Replies(N) = Reply
                  N += 1
                End If
              End If
            End If
          Next

          If Topic.LastReplyId(True) <> LastReply Then
            Log("ErrorLastReplyId", 1000, Topic.ForumId, Topic.ID, Topic.LastReplyId(True), LastReply)
            'Remove topic from cache
            Topic.NotifyTopicHasChangedFromAnotherServer(ForumId, TopicID)
            'Load a topic on cache
            Topic = Topic.Load(ForumId, TopicID)
            If Topic IsNot Nothing Then
              If Topic.LastReplyId(True) <> LastReply Then
                'After update of cache the error about last topic persiste!
                Log("ErrorLastReplyId", 1000, Topic.ForumId, Topic.ID, Topic.LastReplyId(True), LastReply, "Persist")
                Topic.m_LastReplyId = LastReply
                Topic.UpdateLastReplyNotCensored(False)
                Topic.Save()
              End If
            End If
            RemoveCacheOfTopicListAndTopicListByCategories(ForumId)
          End If

          ReDim Preserve Replies(N - 1)
          Return Replies
        End If
        Return Nothing
      End Function

      Private Shared Sub NotifyTopicHasChangedFromAnotherServer(ByVal ForumId As Integer, ByVal TopicId As Integer)
        Dim AllTopics As Collections.Generic.Dictionary(Of Integer, Topic) = Topics(ForumId)
        SyncLock Collection
          If AllTopics.ContainsKey(TopicId) Then
            AllTopics.Remove(TopicId)
          End If
          Topic.Load(ForumId, TopicId)
        End SyncLock
      End Sub

      Private Shared Sub NotifyTopicHasChangedFromAnotherServer(ByVal Key As String)
        Dim Parts As String() = Split(Key)
        Dim ForumId As Integer = CInt(Parts(0))
        Dim TopicId As Integer = CInt(Parts(1))
        NotifyTopicHasChangedFromAnotherServer(ForumId, TopicId)
      End Sub


      'This line initialize a pipeline multi-server notification necessary to notify a changement of topic to another server
      Private Shared EnableServerNotification As Boolean = StartupServerNotification()
      Private Shared Function StartupServerNotification() As Boolean
        Pipeline.AddActionForNotification(GetType(Topic), AddressOf NotifyTopicHasChangedFromAnotherServer)
        Return True
      End Function

      Public Shared Function Topics(ByVal ForumId As Integer) As Collections.Generic.Dictionary(Of Integer, Topic)
        SyncLock Collection
          If Collection.ContainsKey(ForumId) Then
            Return Collection(ForumId)
          Else
            Dim NewTopicsCollection As Collections.Generic.Dictionary(Of Integer, Topic) = New Collections.Generic.Dictionary(Of Integer, Topic)
            Collection.Add(ForumId, NewTopicsCollection)
            Return NewTopicsCollection
          End If
        End SyncLock
      End Function

      Shared Sub SaveCache()
        If CacheLoaded Then
          Try
            For Each ForumId As Integer In Collection.Keys
              SaveCache(ForumId)
            Next
          Catch ex As Exception
            Log("SpecificError", 1000, "SaveCache", ex.Source, ex.Message, ex.StackTrace)
          End Try
        End If
      End Sub

      Shared Sub SaveCache(ForumId As Integer)
        Try
          If Changed.ContainsKey(ForumId) Then
            If Changed.Item(ForumId) = True Then
              Dim AllTopics As Collections.Generic.Dictionary(Of Integer, Topic) = Topic.Topics(ForumId)
              Dim Infos(AllTopics.Count - 1) As TopicInfoId
              Dim N As Integer
              For Each Topic As Topic In AllTopics.Values
                Infos(N) = Topic.InfoId
                N += 1
              Next
              SaveObject(Infos, CStr(ForumId))
            End If
          End If
        Catch ex As Exception
          Log("SpecificError", 1000, "SaveCache", ex.Source, ex.Message, ex.StackTrace)
        End Try
      End Sub

      Shared CacheLoaded As Boolean

      Shared Sub LoadCache()
        For Each Forum As ForumManager.Forum In ForumManager.AllForums(False)
          Dim Topics As Collections.Generic.Dictionary(Of Integer, Topic) = Topic.Topics(Forum.Id)
          Dim Infos As TopicInfoId() = CType(LoadObject(GetType(TopicInfoId()), CStr(Forum.Id)), TopicInfoId())
          If Infos IsNot Nothing Then
            Dim Dirs() As Integer = Nothing
            If Infos.Count <> Forum.TotalTopics Then
              Dirs = Forum.GetAllTopicsId
            End If

            For Each InfoId As TopicInfoId In Infos
              If Dirs Is Nothing OrElse Dirs.Contains(InfoId.Id) Then
                Dim Topic As Topic
                Topic = New Topic
                Topic.ForumId = Forum.Id
                Topic.ID = InfoId.Id
                Try
                  Topic.LoadInfo(InfoId.Info)
                  SyncLock Collection
                    Try
                      If Not Topics.ContainsKey(Topic.ID) Then
                        Topics.Add(Topic.ID, Topic)
                      End If
                    Catch ex As Exception
                    End Try
                  End SyncLock
                Catch ex As Exception
                End Try
              End If
            Next
            RemoveCacheOfTopicListAndTopicListByCategories(Forum.Id)
          End If
        Next
        CacheLoaded = True
      End Sub

      Friend Shared Sub SetCacheIsChanged(ByVal ForumId As Integer)
        SyncLock Topic.Changed
          If Topic.Changed.ContainsKey(ForumId) Then
            Topic.Changed.Remove(ForumId)
          End If
          Topic.Changed.Add(ForumId, True)
        End SyncLock
      End Sub

      Friend Shared Changed As New Collections.Generic.Dictionary(Of Integer, Boolean)  'This collection memorizze the changed forum with a flag "true" to save a cache at application end

      Public Shared Collection As New Collections.Generic.Dictionary(Of Integer, Collections.Generic.Dictionary(Of Integer, Topic))
      Public Shared Function Load(ByVal ForumId As Integer, ByVal TopicID As Integer) As Topic
        SyncLock Collection
          Try
            Dim AllTopics As Collections.Generic.Dictionary(Of Integer, Topic) = Topic.Topics(ForumId)
            If AllTopics.ContainsKey(TopicID) Then
              Return AllTopics(TopicID)
            Else
              If Exists(ForumId, TopicID) Then
                Dim Topic As New Topic
                Topic.LoadFromFile(ForumId, TopicID)
                If Topic.FirstReplyId = 0 Then
                  'This topic is empty! Must be deleted!
                  Topic.Delete(ForumId, TopicID)
                Else
                  Try
                    AllTopics.Add(TopicID, Topic)
                    'Topic.UpdateNoHideLastsMessages()	'This instruction before this point cause a recursive loop
                  Catch ex As Exception
                  End Try
                  Return Topic
                End If
              End If
            End If
          Catch ex As Exception
            Log("ErrorLoadTopic", 100, ForumId, TopicID, ex.Message, ex.StackTrace)
          End Try
        End SyncLock
        Return Nothing
      End Function

      Shared Sub Delete(ByVal ForumId As Integer, ByVal TopicID As Integer)
        Dim Path As String = PathTopic(ForumId, TopicID)
        If IO.Directory.Exists(Path) Then

          'Strong control to verify accident delete of important directory!
          DeleteDirectory(Path)

        End If

        Dim AllTopics As Collections.Generic.Dictionary(Of Integer, Topic) = Topics(ForumId)
        If AllTopics IsNot Nothing Then
          If AllTopics.ContainsKey(TopicID) Then
            'Log This operation
            Dim Topic As Topic = AllTopics(TopicID)
            Extension.Log("DeleteTopic", 1000, CurrentUser.Username, ForumId, TopicID, Topic.FirstReply.Title)
            SyncLock Collection
              AllTopics.Remove(TopicID)
            End SyncLock

            'Abjust counter
            Dim Forum As Forum = CType(ForumManager.Forum.Load(CStr(ForumId)), ForumManager.Forum)
            Forum.TotalTopics -= 1
            Dim SubCategory As ForumManager.ForumStructure.Category.Subcategory = Forum.SubCategory(Topic.SubCategory)
            Dim SaveStructure As Boolean
            If SubCategory IsNot Nothing Then
              If Not Topic.Censored Then
                SaveStructure = True
                SubCategory.TotalTopics -= 1
              End If
            End If
            Forum.Save(SaveStructure)
            Topic.Finalize()
            'RemoveCacheOfTopicListAndTopicListByCategories(ForumId)
          End If
        End If
      End Sub

      Private Sub LoadFromFile(ByVal ForumId As Integer, ByVal TopicID As Integer)
        Me.ForumId = ForumId
        Me.ID = TopicID

        'Load Last Reply
        'If FirstReply IsNot Nothing Then
        LoadInfo()

        'UpdateNoHideLastsMessages() This function here cause a recursive loop
      End Sub

      Sub Save()
        SaveInfo()
      End Sub

      Public Sub UpdateLastReplyNotCensored(Optional ByVal Save As Boolean = True)
        Dim NewLastReplyNotCensored As Reply = FindLastReply(Me, True)
        If NewLastReplyNotCensored Is Nothing Then
          m_LastReplyNotCensoredId = 0
          m_LastReplyNotCensoredCreated = Nothing
          If Save Then
            Me.SaveInfo()
          End If
        ElseIf m_LastReplyNotCensoredId <> NewLastReplyNotCensored.ID Then
          m_LastReplyNotCensoredId = NewLastReplyNotCensored.ID
          m_LastReplyNotCensoredCreated = NewLastReplyNotCensored.Created
          If Save Then
            Me.SaveInfo()
          End If
        End If
      End Sub
      Private Sub LoadInfo(Optional ByVal Info As TopicInfo = Nothing)

        If Info Is Nothing Then
          Info = CType(Deserialize(NameFileTopicInfo(ForumId, ID), GetType(TopicInfo)), TopicInfo)
          If Info Is Nothing Then
            Exit Sub
          End If
        End If
        Me.Closed = Info.Closed
        Me.AsResolved = Info.AsResolved
        Me.Created = Info.Created
        Me.SubCategory = Info.SubCategory
        Me.Reference = Info.Reference
        Me.Keywords = Info.Keywords
        Me.Readed = Info.Readed
        Me.Censored = Info.Censored

        Me.NReplies = Info.NReplies
        Me.m_LastReplyId = Info.LastReplyId
        Me.m_LastReplyCreated = Info.LastReplyCreated
        Me.LastReplyAuthor = Info.LastReplyAuthor
        Me.LastReplyAuthorAccount = Info.LastReplyAuthorAccount

        Me.NRepliesNotCensored = Info.NRepliesNotCensored
        Me.m_LastReplyNotCensoredId = Info.LastReplyNotCensoredId
        Me.m_LastReplyNotCensoredCreated = Info.LastReplyNotCensoredCreated
        Me.LastReplyNotCensoredAuthor = Info.LastReplyNotCensoredAuthor
        Me.LastReplyNotCensoredAuthorAccount = Info.LastReplyNotCensoredAuthorAccount


        RepairInfoTopic()

        UpdateNoHideLastsMessages()

        'End If

      End Sub

      'Private Sub LoadInfoDeprecate()
      '  'Retrocompatibility routine
      '  'Delete this after prove period


      '  Dim OldFile As String = MapPath(ForumSubDirectory & "\" & ForumId & "\" & ID & "\topic.info")
      '  If System.IO.File.Exists(OldFile) Then
      '    'New routine XML
      '    'ElseIf System.IO.File.Exists(OldFile) Then

      '    'Old routine (Need to convert)

      '    Dim Code As String = ReadAll(OldFile)
      '    If Code IsNot Nothing Then
      '      Dim Datas() As String = Microsoft.VisualBasic.Strings.Split(Code, vbCrLf)
      '      'Dim Datas() As String = Code.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
      '      Dim UBound As Integer = Datas.GetUpperBound(0)
      '      If Datas.Length <= 1 Then
      '        Datas = Split(Code)
      '        UBound = Datas.GetUpperBound(0)
      '        SaveInfo() 'Convert info in new Format
      '      End If

      '      Try

      '        NReplies = Datas(0)
      '        If UBound >= 1 Then
      '          Readed = Datas(1)
      '        End If
      '        If UBound >= 2 Then
      '          m_LastReplyId = Datas(2)
      '        End If
      '        If UBound >= 3 Then
      '          m_LastReplyNotCensoredId = Datas(3)
      '        End If
      '        If UBound >= 4 Then
      '          Reference = Datas(4)
      '        End If
      '        If UBound >= 5 Then
      '          Keywords = Datas(5)
      '        End If
      '        If UBound >= 6 Then
      '          Censored = Datas(6)
      '        End If
      '        If UBound >= 7 Then
      '          Dim LastReplyCreateFileTime As Long = Datas(7)
      '          If LastReplyCreateFileTime Then
      '            m_LastReplyCreated = Date.FromFileTime(LastReplyCreateFileTime)
      '          End If
      '        End If
      '        If UBound >= 8 Then
      '          Dim LastReplyCreateNotCensoredFileTime As Long = Datas(8)
      '          If LastReplyCreateNotCensoredFileTime Then
      '            m_LastReplyNotCensoredCreated = Date.FromFileTime(LastReplyCreateNotCensoredFileTime)
      '          End If
      '        End If
      '        If UBound >= 9 Then
      '          Dim CreateFileTime As Long = Datas(9)
      '          If CreateFileTime Then
      '            Created = Date.FromFileTime(CreateFileTime)
      '          End If
      '        End If
      '        If UBound >= 10 Then
      '          LastReplyAuthor = Datas(10)
      '        End If
      '        If UBound >= 11 Then
      '          LastReplyNotCensoredAuthor = Datas(11)
      '        End If
      '        If UBound >= 12 Then
      '          NRepliesNotCensored = Datas(12)
      '        End If
      '        If UBound >= 13 Then
      '          SubCategory = Datas(13)
      '        End If

      '      Catch ex As Exception

      '      End Try


      '      RepairInfoTopic()
      '      SaveInfo()
      '      FileManager.Delete(OldFile)
      '      Try
      '        FileManager.Delete(OldFile & ".old")
      '      Catch ex As Exception

      '      End Try
      '    End If
      '  End If
      'End Sub


      Private Sub RepairInfoTopic()
        'Abjust info if is corrupt!
        'Add data if not present
        Dim RepairDescription As String = Nothing

        If m_LastReplyId = 0 Then
          Dim LastReply As Reply = FindLastReply(Me, False)
          If LastReply IsNot Nothing Then
            m_LastReplyId = LastReply.ID
            m_LastReplyCreated = LastReply.Created
            If LastReply.Author IsNot Nothing Then
              LastReplyAuthor = LastReply.Author
            End If
            RepairDescription = "m_LastReplyId = 0"
          End If
        End If

        If m_LastReplyNotCensoredId = 0 Then
          Dim LastReplyNotCensored As Reply = FindLastReply(Me, True)
          If LastReplyNotCensored IsNot Nothing Then
            m_LastReplyNotCensoredId = LastReplyNotCensored.ID
            m_LastReplyNotCensoredCreated = LastReplyNotCensored.Created
            If LastReplyNotCensored.Author IsNot Nothing Then
              LastReplyNotCensoredAuthor = LastReplyNotCensored.Author
            End If
            RepairDescription = "m_LastReplyNotCensoredId = 0"
          End If
        End If

        If m_LastReplyId = 0 AndAlso m_FirstReplyId <> 0 Then
          'This topic is empty
          m_FirstReplyId = 0
          RepairDescription = "m_LastReplyId = 0 AndAlso m_FirstReplyId <> 0"
        ElseIf m_FirstReplyId = 0 Then
          Dim reply As Reply = reply.Load(ForumId, ID, 1)
          If reply IsNot Nothing Then
            m_FirstReplyId = 1
            Me.Created = reply.Created
            RepairDescription = "m_FirstReplyId = 0"
          End If
        End If

        If m_LastReplyNotCensoredId = 0 And Censored = False Then
          Censored = True
          RepairDescription = "m_LastReplyNotCensoredId = 0 And Censored = False"
        End If

        If NReplies = 0 Then
          NReplies = m_LastReplyId
          RepairDescription = "NReplies = 0"
        End If

        'If NRepliesNotCensored = 0 Then
        '  If m_LastReplyNotCensoredId > 0 Then
        '    Dim Replies() As Reply = AllReplies(ForumId, Me.ID, False, True)
        '    If Replies IsNot Nothing Then
        '      NRepliesNotCensored = Replies.Length
        '      Save = True
        '    End If
        '  End If
        'End If

        If Not ForumForInsideUse(ForumId) Then
          If Keywords = "" Then
            Dim FirstReply As Reply = Reply.Load(ForumId, ID, FirstReplyId)
            If FirstReply IsNot Nothing Then
              Me.Censored = FirstReply.Censored
              If Trim(FirstReply.Keywords) <> "" Then
                Keywords = FirstReply.Keywords
              ElseIf FirstReply.Title <> "" Then
                Keywords = FirstReply.Title
              End If
              If Keywords <> "" Then
                RepairDescription = "Keywords = """""
              End If
            End If

          End If
        End If

        If Created = Date.MinValue Then
          Dim FirstReply As Reply = Reply.Load(ForumId, ID, FirstReplyId)
          If FirstReply IsNot Nothing AndAlso Created <> FirstReply.Created Then
            Created = FirstReply.Created
            RepairDescription = "Created = Date.MinValue"
          End If
        End If

        If RepairDescription IsNot Nothing Then
          '=========================remove this bloch
          Log("RepairInfoTopic", 1000, ForumId, ID, RepairDescription)
          '==========================================
          SaveInfo()
        End If
      End Sub

      Private Function Info() As TopicInfo
        'Info = InfoId()
        Info = New TopicInfo
        Info.Closed = Me.Closed
        Info.AsResolved = Me.AsResolved
        Info.Created = Me.Created
        Info.SubCategory = Me.SubCategory
        Info.Reference = Me.Reference
        Info.Keywords = Me.Keywords
        Info.Readed = Me.Readed
        Info.Censored = Me.Censored

        Info.NReplies = Me.NReplies
        Info.LastReplyId = Me.m_LastReplyId
        Info.LastReplyCreated = Me.m_LastReplyCreated
        Info.LastReplyAuthor = Me.LastReplyAuthor
        Info.LastReplyAuthorAccount = Me.LastReplyAuthorAccount

        Info.NRepliesNotCensored = Me.NRepliesNotCensored
        Info.LastReplyNotCensoredId = Me.m_LastReplyNotCensoredId
        Info.LastReplyNotCensoredCreated = Me.m_LastReplyNotCensoredCreated
        Info.LastReplyNotCensoredAuthor = Me.LastReplyNotCensoredAuthor
        Info.LastReplyNotCensoredAuthorAccount = Me.LastReplyNotCensoredAuthorAccount

      End Function

      Private Function InfoId() As TopicInfoId
        InfoId = New TopicInfoId
        InfoId.Id = ID
        InfoId.Info = Info()
      End Function


      Private Sub SaveInfo()
        AddDir()
        Serialize(Info, NameFileTopicInfo(ForumId, ID))
        ForumManager.Topic.SetCacheIsChanged(ForumId)
        NotifyChangement(GetType(Topic), ForumId & " " & ID)
      End Sub

      Class TopicInfo
        Public Closed As Boolean
        Public AsResolved As Integer
        Public Created As Date
        Public SubCategory As Integer
        Public Reference As String
        Public Keywords As String
        Public Readed As Integer
        Public Censored As Boolean

        Public NReplies As Integer 'NReplies
        Public LastReplyId As Integer '= m_LastReplyId
        Public LastReplyCreated As Date 'm_LastReplyCreated
        Public LastReplyAuthor As String
        Public LastReplyAuthorAccount As String

        Public NRepliesNotCensored As Integer
        Public LastReplyNotCensoredId As Integer 'm_LastReplyNotCensoredId
        Public LastReplyNotCensoredCreated As Date 'm_LastReplyNotCensoredCreated
        Public LastReplyNotCensoredAuthor As String
        Public LastReplyNotCensoredAuthorAccount As String

      End Class

      Class TopicInfoId
        Public Info As TopicInfo
        Public Id As Integer
      End Class

      Private Function Root(ByVal ForumId As Integer) As String
        Return Extension.MapPath(ForumSubDirectory & "\" & ForumId)
      End Function

      Private Function NextID(ByVal ForumId As Integer) As Integer
        Return NewSubDirectoryId(Root(ForumId))
      End Function

      Private Sub AddDir()
        Dim Path As String = Root(ForumId) & "\" & ID
        If Not IO.Directory.Exists(Path) Then
          IO.Directory.CreateDirectory(Path)
        End If
      End Sub

      Private Function ExistsTopicInfo(ByVal ForumId As Integer, ByVal TopicID As Integer) As Boolean
        Dim I As New System.IO.FileInfo(NameFileTopicInfo(ForumId, TopicID))
        Return I.Exists
      End Function

      Private Function NameFileTopicInfo(ForumId As Integer, TopicID As Integer) As String
        Return Extension.MapPath(ForumSubDirectory & "\" & ForumId & "\" & ID & "\topic.xml")
      End Function

      Function IncReplies(ByVal NewReply As Reply) As Integer
        SetNewLastReply(NewReply)
        NReplies += 1
        NRepliesNotCensored += 1
        Return NReplies
      End Function

      Private Sub SetNewLastReply(ByVal NewReply As Reply)
        If NewReply.ID = 1 Then
          Me.Created = NewReply.Created
        End If
        Me.m_LastReplyId = NewReply.ID
        Me.m_LastReplyCreated = NewReply.Created
        Me.LastReplyAuthor = NewReply.Author
        Me.LastReplyAuthorAccount = NewReply.AuthorAccount
        If Not NewReply.Censored Then
          m_LastReplyNotCensoredId = NewReply.ID
          m_LastReplyNotCensoredCreated = NewReply.Created
          Me.LastReplyNotCensoredAuthor = NewReply.Author
          Me.LastReplyNotCensoredAuthorAccount = NewReply.AuthorAccount
        End If
        UpdateNoHideLastsMessages()
      End Sub

      Function IncReaded() As Integer
        Readed += 1
        SaveInfo()
        Return Readed
      End Function
    End Class

    Class Reply
      Function IsHiden() As Boolean
        Return ReplyMomentarilyHidden(Me)
      End Function
      Public ForumId As Integer
      Public TopicID As Integer
      Private IsCensored As Boolean
      Public Property Censored() As Boolean
        Get
          Return IsCensored
        End Get
        Set(ByVal value As Boolean)
          If IsCensored <> value Then
            Dim Topic As Topic = Topic.Load(ForumId, TopicID)
            If value = True Then
              Topic.NRepliesNotCensored -= 1
            Else
              Topic.NRepliesNotCensored += 1
            End If
            IsCensored = value
            If ID() = Topic.FirstReplyId Then
              If Topic.Censored <> value Then
                Topic.Censored = value
                Dim Forum As Forum = CType(ForumManager.Forum.Load(CStr(ForumId)), ForumManager.Forum)
                Dim SubCategory As ForumManager.ForumStructure.Category.Subcategory = Forum.SubCategory(Topic.SubCategory)
                If SubCategory IsNot Nothing Then
                  Select Case Topic.Censored
                    Case True
                      SubCategory.TotalTopics -= 1
                    Case False
                      SubCategory.TotalTopics += 1
                  End Select
                  Forum.ForumStructure.Save()
                End If
              End If
            End If
            Topic.Save()
          End If
        End Set
      End Property
      Private NCensoreRequireds As Integer
      Public Property RequestCensorship As Integer
        Get
          Return NCensoreRequireds
        End Get
        Set(ByVal value As Integer)
          NCensoreRequireds = value
          Dim Censored As Boolean
          If Me.Censored = False Then
            Dim Minimum As Integer = CInt(DateDiff(DateInterval.Day, Me.Created, Now.ToUniversalTime) / 10)
            If Minimum < Setup.Security.QuorumToCensored Then
              Minimum = Setup.Security.QuorumToCensored
            End If

            Dim Proprietary As User = Nothing
            If ReservedForums.PrivateMessage = ForumId Then
              Proprietary = User.Load(Reply.Load(ForumId, TopicID, ID).Title)
            End If

            If AbleToCensore(Nothing, Proprietary) OrElse (Me.Author = CurrentUser.Username And Me.AuthorAccount Is Nothing) OrElse Me.NCensoreRequireds > Minimum Then
              Censored = True
              Me.Censored = True
              'Censore reply at Censored message
              For Each ReplyQuote As Reply In Topic.Load(ForumId, TopicID).Replies(False)
                If ReplyQuote.QuoteID = Me.ID Then
                  ReplyQuote.Censored = True
                  ReplyQuote.Save()
                End If
              Next
            End If
          End If
          Me.Save()

          If Censored Then
            'Abjust preview last message in topic if is necessary
            Dim Topic As Topic = Topic.Load(ForumId, TopicID)
            If Topic IsNot Nothing Then
              Topic.UpdateLastReplyNotCensored()
            End If
          End If

        End Set
      End Property
      Public Theme As Integer
      Public Photo As String
      Public Video As String
      Public Poll() As Integer
      Public IsPoll As Boolean
      Private m_id As Integer
      Public ReadOnly Property ID() As Integer
        Get
          Return m_id
        End Get
      End Property
      Public QuoteID As Integer
      Public Created As Date
      Public Modified As Date
      Public Title As String
      Public Keywords As String
      Private m_Text As String
      Property Text() As String
        Get
          Return m_Text
        End Get
        Set(ByVal Value As String)
          m_Text = Value
        End Set
      End Property
      Private m_TextQuote As String
      Property TextQuote() As String
        Get
          Return m_TextQuote
        End Get
        Set(ByVal Value As String)
          m_TextQuote = Value
          UpdateText()
        End Set
      End Property
      Private m_TextReply As String
      Property TextReply() As String
        Get
          If QuoteID = 0 Then
            Return m_Text
          Else
            Return m_TextReply
          End If
        End Get
        Set(ByVal Value As String)
          m_TextReply = Value
          UpdateText()
        End Set
      End Property
      Private Sub ExtrapolateQuote()
        Dim S As Integer = InStr(m_Text, ": </b><br />", CompareMethod.Text)
        If CBool(S) Then
          'Retrocomparibility
          S += 10
          Dim E As Integer
          E = InStr(S + 1, m_Text, "</blockquote>", CompareMethod.Text)
          If CBool(E) Then
            m_TextQuote = (Mid(m_Text, S + 1, E - S - 1))
            m_TextReply = Mid(m_Text, E + 13)
          End If
        Else
          m_TextQuote = Nothing
          m_TextReply = m_Text
        End If
      End Sub
      Function InnerTextReply() As String
        Return Common.InnerText(Me.TextReply)
      End Function
      Public Author As String
      Public AuthorAccount As String
      Shared Function Numeric8Digits(ByVal N As Integer) As String
        Return Format(N, "00000000")
      End Function
      Public Sub New()
      End Sub
      Public Sub New(ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal Author As String, ByVal Title As String, ByVal Keywords As String, ByVal TextReply As String, Optional ByVal TextQuote As String = Nothing, Optional ByVal QuoteID As Integer = Nothing, Optional ByVal Photo As String = Nothing, Optional ByVal Video As String = Nothing, Optional ByVal Censored As Boolean = False, Optional ByVal AuthorAccount As String = Nothing, Optional ByVal PollDetection As Boolean = True, Optional Created As Date = Nothing)
        Me.ForumId = ForumId
        Me.TopicID = TopicID
        Me.Author = Author
        Me.AuthorAccount = AuthorAccount
        Me.Title = Trim(Title)
        Me.Keywords = Trim(Keywords)
        Me.TextReply = TextReply
        Me.QuoteID = QuoteID
        Me.TextQuote = TextQuote
        Me.Photo = Photo
        Me.Video = Video
        Me.IsCensored = Censored
        If Created <> Date.MinValue Then
          Me.Created = Created
        Else
          Me.Created = Now.ToUniversalTime
        End If
        Save(, PollDetection)
      End Sub

      Private Shared Function LoadObject(ByVal Key As String) As Object
        Dim Parameters() As String = Split(Key)
        Return LoadFromFile(CInt(Parameters(0)), CInt(Parameters(1)), CInt(Parameters(2)))
      End Function

      Private Shared Function LoadFromFile(ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal ID As Integer) As Reply
        Dim NewReply As New Reply
        NewReply.ForumId = ForumId
        NewReply.TopicID = TopicID
        NewReply.m_id = ID
        Dim File As String = PathTopic(ForumId, TopicID) & Numeric8Digits(NewReply.m_id) & ".htm"
        Dim Document As HtmlDocument
        Try
          Document = New HtmlDocument(File)
        Catch ex As Exception
          'Reply not exist
          Return Nothing
        End Try
        NewReply.Text = Document.Body
        NewReply.Author = Document.MetaTags.Author
        NewReply.Title = Document.MetaTags.Title
        NewReply.Keywords = Document.MetaTags.KeyWords
        NewReply.Created = TextToDate(Document.MetaTags.MetaTag("create"))
        NewReply.Modified = TextToDate(Document.MetaTags.MetaTag("modified"))
        NewReply.Theme = CInt(Document.MetaTags.MetaTag("theme"))
        NewReply.AuthorAccount = Document.MetaTags.MetaTag("AuthorAccount")
        NewReply.Photo = Document.MetaTags.MetaTag("photo")
        NewReply.Video = Document.MetaTags.MetaTag("video")
        If Document.MetaTags.Collection.ContainsKey("poll") Then
          NewReply.Poll = PollStringToVotes(Document.MetaTags.MetaTag("poll"))
          NewReply.IsPoll = True
        End If

        If Not Document.MetaTags.MetaTag("Censorerequireds") Is Nothing Then
          NewReply.NCensoreRequireds = CInt(Document.MetaTags.MetaTag("Censorerequireds"))
        End If

        If Not Document.MetaTags.MetaTag("Censored") Is Nothing Then
          NewReply.IsCensored = CBool(Document.MetaTags.MetaTag("Censored"))
        End If

        NewReply.QuoteID = CInt(Document.MetaTags.MetaTag("quote"))
        If CBool(NewReply.QuoteID) Then
          NewReply.ExtrapolateQuote()
        End If
        Return NewReply
      End Function

      Private Sub UpdateText()
        If Me.QuoteID <> 0 AndAlso TextQuote <> "" Then
          Dim QuoteAuthor As String = Reply.Load(Me.ForumId, Me.TopicID, QuoteID).Author
          Me.m_Text = "<blockquote><b>" & QuoteAuthor & ": </b><br />" & TextQuote & "</blockquote>"
          Me.m_Text &= Me.m_TextReply
        ElseIf m_TextReply <> "" Then
          Me.m_Text = Me.m_TextReply
        End If
      End Sub

      Sub Save(Optional ByVal ForceID As Integer = 0, Optional ByVal PollDetection As Boolean = True)
        If CBool(TopicID) Then
          Dim MetaTags As New MetaTags(Me.Title, "", Me.Keywords, Me.Author)
          MetaTags.AddMetaTag("create", DateToText(Created))

          If Modified <> New Date Then
            MetaTags.AddMetaTag("modified", DateToText(Modified))
          End If

          If Me.AuthorAccount <> "" Then
            MetaTags.AddMetaTag("AuthorAccount", Me.AuthorAccount)
          End If

          If CBool(Me.Theme) Then
            MetaTags.AddMetaTag("theme", CStr(Me.Theme))
          End If

          If Me.Photo <> "" Then
            MetaTags.AddMetaTag("photo", Me.Photo)
          End If

          If Me.Video <> "" Then
            MetaTags.AddMetaTag("Video", Me.Video)
          End If

          If Me.IsCensored Then
            MetaTags.AddMetaTag("Censored", CStr(Me.IsCensored))
          End If

          If CBool(Me.RequestCensorship) Then
            MetaTags.AddMetaTag("Censorerequireds", CStr(Me.RequestCensorship))
          End If

          Dim Body As String
          If CBool(Me.QuoteID) Then
            MetaTags.AddMetaTag("quote", CStr(Me.QuoteID))
          End If
          Body = Me.Text
          If PollDetection Then
            Me.IsPoll = AddPoll(CurrentDomainConfiguration, CurrentSetting, Body, PollContext.IsPoll, Nothing)
          End If
          If Me.Poll IsNot Nothing OrElse Me.IsPoll Then
            MetaTags.AddMetaTag("poll", VotesToPollString(Me.Poll))
          End If

          Dim Document As New HtmlDocument(MetaTags, Body)

          If CBool(ForceID) Then
            m_id = ForceID
          ElseIf m_id = 0 Then
            'Increment Author Bytes Write in Furum
            If AuthorAccount Is Nothing Then
              Dim Author As User = Authentication.User.Load(Me.Author)
              If Not Me.Text Is Nothing Then
                Dim ByteWrite As Long
                Try
                  ByteWrite = CLng(Author.Attribute(NameAttribute & Me.ForumId))
                Catch ex As Exception
                  ByteWrite = 0
                End Try
                ByteWrite += Me.TextReply.Length
                Author.Attribute(NameAttribute & Me.ForumId) = ByteWrite
                If Author.FirstMessageInForum = Date.MinValue Then
                  Author.FirstMessageInForum = Created
                End If
                Author.Save()
              End If
            End If
          End If

          Dim SaveTopic As Boolean
          'Objust LastReply attribute in Topic
          Dim Topic As Topic = Topic.Load(Me.ForumId, Me.TopicID)

          Dim IsNewPost As Boolean
          If m_id = 0 Then 'Is a new post
            IsNewPost = True
            m_id = NextID()
          End If

          Dim FileName As String = Root() & Numeric8Digits(m_id) & ".htm"
          Document.Save(FileName)

          'Add in cache
          Dim Key As String = KeyCache(ForumId, TopicID, ID)
          Cache(Key) = Me

          If IsNewPost Then
            Topic.IncReplies(Me)
            SaveTopic = True
          End If

          'Save Keywords in topic
          If m_id = Topic.FirstReplyId Then
            Topic.Keywords = Keywords
            SaveTopic = True
          End If

          If SaveTopic Then
            Topic.Save()
            Dim t As Topic = Topic.Load(Me.ForumId, Me.TopicID)
          End If

          'Notyfy Changement to other server
          NotifyChangement(GetType(Reply), KeyCache(ForumId, TopicID, ID))

          'Refresh cache of topic list and topic list by categories
          RemoveCacheOfTopicListAndTopicListByCategories(ForumId)
        End If
      End Sub
      Private Function Root() As String
        Return PathTopic(ForumId, TopicID)
      End Function
      Private Function NextID() As Integer
        Return LastReplyId(ForumId, TopicID) + 1
        'Dim Topic As Topic = Topic.Load(ForumId, TopicID)
        'Return Topic.NextNewReplyId
      End Function
      Shared Function QueryString(ByVal SubSite As SubSite, ByVal ForumId As Integer, ByVal TopicId As Integer, ByVal PageNumber As Integer) As String
        Return Link(ActionType.Show, SubSite.Name, , , ForumId, TopicId, , PageNumber)
      End Function
      Property AuthorSubscription(Optional ByVal Page As Page = Nothing, Optional ByVal Setting As SubSite = Nothing) As Subscription.TypeSubscription
        Get
          Dim Subscription As New Subscription(Me.ForumId, Me.TopicID)
          Return Subscription.IsSubscript(Me.Author)
        End Get
        Set(ByVal Value As Subscription.TypeSubscription)
          Dim Subscription As New Subscription(Me.ForumId, Me.TopicID)
          If Subscription.IsSubscript(Me.Author) = Subscription.TypeSubscription.NotDefinited Then
            Subscription.IsSubscript(Me.Author, DomainName(HttpContext.Current.Request), Setting.Name) = Value
          End If
        End Set
      End Property
      Private Shared ObjSync As Object
      Public Shared Function Load(ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal ID As Integer) As Reply
        Return CType(Cache(KeyCache(ForumId, TopicID, ID)), Reply)
      End Function

      Private Shared Function KeyCache(ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal ID As Integer) As String
        Return ForumId & " " & TopicID & " " & ID
      End Function

      Private Shared Cache As New Extension.Cache(AddressOf LoadObject, 1000, GetType(Reply))

      Function XmlReply() As XmlReply
        Dim Xml As New XmlReply
        Xml.Author = Me.Author
        Xml.AuthorAccount = Me.AuthorAccount
        Xml.Text = Common.InnerText(Me.TextReply)
        Xml.Title = Me.Title
        Xml.Create = Me.Created.ToString("dd MM yyyy")
        Return Xml
      End Function
    End Class

    <Serializable()> Class XmlReply
      Public Author As String
      Public AuthorAccount As String
      Public Create As String
      Public Title As String
      Public Text As String
    End Class


    Function MoreUCase(ByVal Text As String) As Boolean
      If CBool(Text.Length) Then
        Dim Valutate As Integer
        For N As Integer = 0 To Text.Length - 1 Step 3
          Dim C As Char = Text.Chars(N)
          If Char.IsUpper(C) Then
            Valutate += 1
          Else
            Valutate -= 1
          End If
        Next
        If Valutate > 0 Then
          Return True
        Else
          Return False
        End If
      Else
        Return False
      End If
    End Function

    Sub SendEmailNotification(Setting As SubSite, Topic As Topic)
      If Setup.Email.Email.Email <> "" Then
        Dim Body As String = Phrase(Setting.Language, 3054) & ": " & Topic.Title & "<br />"
        Dim Show As New WebControls.HyperLink
        Show.Text = Phrase(Setting.Language, 3055)
        Show.ForeColor = System.Drawing.Color.Green
        Show.NavigateUrl = Link(ActionType.Show, , True, "PageBottom", Topic.ForumId, Topic.ID)
        Body &= ControlToText(Show) & "<br />"
        Dim Subject As String = Nothing
        If Topic.SubCategory > -1 Then
          Subject = "[" & Topic.SubCategory & "] "
        End If
        SendEmail(Subject & Topic.Title, Body, Setup.Email.Email.Email, , , False, Configuration.EmailSender.Administrator)
      End If
    End Sub


    Class Subscription
      Function Subscription(ByVal UserName As String) As UserSubscription
        If Subscriptions.ContainsKey(UserName) Then
          Return Subscriptions(UserName)
        End If
        Return Nothing
      End Function
      Private Const NameFile As String = "subscriptions.info"
      Private Subscriptions As New Collections.Generic.Dictionary(Of String, UserSubscription)
      Private ForumId As Integer
      Private TopicID As Integer
      Private Sub Load(ByVal ForumId As Integer, ByVal TopicID As Integer)
        Me.ForumId = ForumId
        Me.TopicID = TopicID
        Dim File As String = PathTopic(ForumId, TopicID) & NameFile
        If System.IO.File.Exists(File) Then
          Dim Data As String = ReadAll(File)
          Dim Datas() As String = Split(Data, vbCrLf)
          If CBool(Datas.Length) Then
            For Each Record As String In Datas
              If Record <> "" Then
                Dim Field() As String = Split(Record, vbTab)
                Try
                  Dim UserSubscription As New UserSubscription(Field(0), CType(Field(1), TypeSubscription), CBool(Field(2)), Field(3), Field(4))
                  Subscriptions.Add(Field(0), UserSubscription)
                Catch ex As Exception
                End Try
              End If
            Next
          End If
        End If
      End Sub
      Public Sub Save()
        If CBool(Subscriptions.Count) Then
          Dim Data As String = Nothing
          For Each UserSubscription As UserSubscription In Subscriptions.Values
            Data &= UserSubscription.UserName & vbTab & UserSubscription.IsSubscript & vbTab & UserSubscription.Suspend & vbTab & UserSubscription.ServerName & vbTab & UserSubscription.SubSite & vbCrLf
            WriteAll(Data, PathTopic(ForumId, TopicID) & NameFile)
          Next
        End If
      End Sub

      Public Sub New(ByVal ForumId As Integer, ByVal TopicID As Integer)
        Load(ForumId, TopicID)
      End Sub
      Enum TypeSubscription
        IsTrue = -1
        IsFalse = 0
        NotDefinited = 1
      End Enum
      Property IsSubscript(ByVal UserName As String, Optional ByVal ServerName As String = Nothing, Optional ByVal Setting As String = Nothing) As TypeSubscription
        Get
          If UserName IsNot Nothing AndAlso Subscriptions.ContainsKey(UserName) Then
            Return Subscriptions(UserName).IsSubscript
          Else
            Return TypeSubscription.NotDefinited
          End If
        End Get
        Set(ByVal Value As TypeSubscription)
          Dim UserSubscription As UserSubscription
          If Subscriptions.ContainsKey(UserName) Then
            UserSubscription = Subscriptions(UserName)
            UserSubscription.IsSubscript = Value
          Else
            UserSubscription = New UserSubscription(UserName, Value, Nothing, ServerName, Setting)
            Subscriptions.Add(UserName, UserSubscription)
          End If
          Save()
        End Set
      End Property
      Sub SendNotification(ByVal User As User, ByVal Title As String)
        If User IsNot Nothing AndAlso User.Email <> "" Then
          Dim UserSubscription As UserSubscription = Me.Subscription(User.Username)
          If UserSubscription IsNot Nothing AndAlso UserSubscription.IsSubscript = TypeSubscription.IsTrue AndAlso Not UserSubscription.Suspend = True Then
            UserSubscription.Suspend = True
            Me.Save()
            Dim Language As LanguageManager.Language = User.Language
            Dim Subject As String
            If ForumForInsideUse(ForumId) Then
              Subject = Title
            Else
              Subject = Phrase(Language, 3053) & " """ & Title & """"
            End If
            Dim Body As String = Phrase(Language, 3054) & ": " & Title & "<br />"
            Dim Show As New WebControls.HyperLink
            Dim Unsubscribe As New WebControls.HyperLink
            Show.Text = Phrase(Language, 3055)
            Unsubscribe.Text = Phrase(Language, 3056)
            Show.ForeColor = System.Drawing.Color.Green
            Unsubscribe.ForeColor = System.Drawing.Color.Red
            Show.NavigateUrl = Link(ActionType.Show, UserSubscription.SubSite, True, "PageBottom", ForumId, TopicID)
            Unsubscribe.NavigateUrl = Link(ActionType.Unsubscribe, UserSubscription.SubSite, True, , ForumId, TopicID, , , User.Username)
            Body &= ControlToText(Show) & "<br />"
            Body &= ControlToText(Unsubscribe) & "<br />"
            SendEmail(Subject, Body, User.Email, , , False, Configuration.EmailSender.Administrator)
          End If
        End If
      End Sub
      Class UserSubscription
        Public UserName As String
        Public ServerName As String
        Public Suspend As Boolean
        Public SubSite As String
        Public IsSubscript As TypeSubscription
        Public Sub New(ByVal UserName As String, ByVal IsSubscript As TypeSubscription, ByVal Suspend As Boolean, ByVal ServerName As String, ByVal Subsite As String)
          Me.UserName = UserName
          Me.IsSubscript = IsSubscript
          Me.Suspend = Suspend
          Me.ServerName = ServerName
          Me.SubSite = Subsite
        End Sub
      End Class
    End Class


    Class UserPreferences
      Public HideSettingPanel As Boolean
      Public ChatMode As Boolean
      Public ShowCensored As Boolean
      Public UseInternalSearchEngine As Boolean
      Public ShowAvatars As Boolean

      Public Sub New(ByVal User As User)
        Load(User)
      End Sub
      Public Sub New(ByVal HideSettingPanel As Boolean, ByVal ChatMode As Boolean, ByVal ShowCensored As Boolean, ByVal UseInternalSearchEngine As Boolean, ByVal ShowAvatars As Boolean)
        Me.HideSettingPanel = HideSettingPanel
        Me.ChatMode = ChatMode
        Me.ShowCensored = ShowCensored
        Me.UseInternalSearchEngine = UseInternalSearchEngine
        Me.ShowAvatars = ShowAvatars
      End Sub
      Sub Save(ByVal User As User)
        Dim Bol As String = _
        Abs(HideSettingPanel) & _
        Abs(ChatMode) & _
        Abs(ShowCensored) & _
        Abs(UseInternalSearchEngine) & _
        Abs(ShowAvatars)
        User.Attribute("ForumSetting") = Bol
        User.Save()
      End Sub
      Sub Load(ByVal User As User)
        Dim Bl As String = CStr(User.Attribute("ForumSetting"))
        If Bl Is Nothing Then
          HideSettingPanel = True
        Else
          Try
            HideSettingPanel = Bl.Chars(0) = "T"c
            ChatMode = Bl.Chars(1) = "T"c
            If User.GeneralRole <= Authentication.User.RoleType.Excluded Then
              'Force hide Censore message for banned user
              ShowCensored = False
            Else
              ShowCensored = Bl.Chars(2) = "T"c
            End If
            UseInternalSearchEngine = Bl.Chars(3) = "T"c
            ShowAvatars = Bl.Chars(4) = "T"c
          Catch ex As Exception
          End Try
        End If
      End Sub
      Private Function Abs(ByVal Value As Boolean) As String
        If Value Then
          Return "T"
        End If
        Return "F"
      End Function
    End Class

    Private ChacheLastPost As New Collections.Generic.Dictionary(Of String, Date)

    Property DateLastPost(ByVal ForumId As Integer, Optional ByVal TopicID As Integer = 0) As Date
      Get
        Dim Key As String = ForumId & "/" & TopicID
        If ChacheLastPost.ContainsKey(Key) Then
          Return ChacheLastPost(Key)
        End If
        Return Nothing
      End Get
      Set(ByVal Value As Date)
        Dim Key As String = ForumId & "/" & TopicID
        Try
          ChacheLastPost.Remove(Key)
        Catch ex As Exception
        End Try
        ChacheLastPost.Add(Key, Value)
      End Set
    End Property

    Function Normalize(ByVal Text As String) As String
      If MoreUCase(Text) Then
        Text = Text.ToLower
      End If
      'This function minimize caracters repetition; exempl:
      'Helllllo amigosssss > Helllo amigosss
      Dim StringBuilder As New System.Text.StringBuilder(Len(Text))
      Dim C, OC As Char
      Dim Repetition As Integer
      For Each C In Text
        If StrComp(C, OC, CompareMethod.Text) = 0 AndAlso Not Char.IsDigit(C) Then
          Repetition += 1
        Else
          Repetition = 0
        End If
        If Repetition < 3 OrElse C = " "c Then
          StringBuilder.Append(C)
        End If
        OC = C
      Next
      Return TrimCrLf(StringBuilder.ToString)
    End Function

    Sub AddForumPhotoAlbum(ByVal Forum As ForumManager.Forum, ByVal Language As LanguageManager.Language)
      Dim RootPhotoAlbum As PhotoAlbum = CType(PhotoManager.PhotoAlbum.Load("forum"), PhotoManager.PhotoAlbum)
      If RootPhotoAlbum Is Nothing Then
        RootPhotoAlbum = New PhotoAlbum
        RootPhotoAlbum.Name = "forum"
        RootPhotoAlbum.AddPermitted = PhotoManager.Permission.Permitted
        RootPhotoAlbum.Deletable = Permission.None
        RootPhotoAlbum.Save()
      End If
      'Dim Creator As New User
      'Creator.CurrentSubsite = Setting
      'Dim PhotoAlbum As PhotoAlbum = RootPhotoAlbum.CreateSubFotoAlbum(Creator)
      Dim ForumName As String = RootPhotoAlbum.Name & "/" & Forum.Id
      Dim PhotoAlbum As PhotoAlbum = CType(PhotoManager.PhotoAlbum.Load(ForumName), PhotoManager.PhotoAlbum)
      If PhotoAlbum Is Nothing Then
        PhotoAlbum = New PhotoAlbum
        PhotoAlbum.Name = ForumName
        PhotoAlbum.IsRoot = True
        PhotoAlbum.Editable = PhotoManager.EditablePermission.None
        PhotoAlbum.AddPermitted = PhotoManager.Permission.Permitted
        PhotoAlbum.Deletable = PhotoManager.Permission.Author
        PhotoAlbum.SubPhotoAlbumsNotCreatable = True
        PhotoAlbum.Title(Language) = Phrase(Language, 61, 103)
        PhotoAlbum.Save()
        Forum.Save()
      End If
    End Sub

    Sub ForumInitialize(ByVal Forum As ForumManager.Forum, ByVal Language As LanguageManager.Language)
      'This method add a common PhotoAlbum for the forum 
      If Forum IsNot Nothing Then
        Static Initialized As New Collections.Generic.List(Of Integer)
        If Not Initialized.Contains(Forum.Id) Then
          Initialized.Add(Forum.Id)
          AddForumPhotoAlbum(Forum, Language)
        End If
      End If
    End Sub


    Public Function ShowTopic(ByVal Setting As SubSite, ByVal ForumId As Integer, ByVal TopicID As Integer, ByVal CurrentPage As Integer, ByVal ShowCensored As Boolean, ByVal ShowAvatars As Boolean, Optional ByVal OperationsColumn As Boolean = True, Optional ByVal Page As Page = Nothing, Optional ByVal Action As ActionType = ActionType.Show, Optional ByVal Jump As String = Nothing, Optional ByVal AddButtons As Boolean = False, Optional ByVal LinksCorrelated As Control = Nothing, Optional ByVal AddTitle As Boolean = True, Optional ByVal SetMetaRevisitAfter As Boolean = False) As Control
      Dim Threads As New System.Collections.Generic.List(Of Threading.Thread)

      Dim Replies() As Reply = ForumManager.Topic.AllReplies(ForumId, TopicID, ShowCensored, EnableShowHidden)

      Dim Topic As Topic = Topic.Load(ForumId, TopicID)
      Dim FirstReply As Reply = Nothing
      If Topic Is Nothing OrElse Topic.FirstReply Is Nothing Then
        If ForumForInsideUse(ForumId) Then
          HttpContext.Current.Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
        Else
          HttpContext.Current.Response.RedirectPermanent(ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId), True)
        End If
      End If

      Dim CurrentUser As User = Authentication.CurrentUser
      Dim MasterPage As MasterPage = Nothing
      If Page IsNot Nothing Then
        MasterPage = CType(Page.Master, Components.MasterPage)
      End If

      Dim Archive As Integer
      Dim CurrentForum As Forum = ForumManager.CurrentForum(Setting, ForumId)
      If CurrentForum IsNot Nothing Then
        Archive = CurrentForum.ArchiveAppropriate(Setting)
      End If
      If Not ForumForInsideUse(ForumId) Then
        If MasterPage IsNot Nothing Then
          If CurrentForum.ForumStructure.Categories.Count > 0 Then
            MasterPage.SetTrace(CurrentForum.Trace(Setting, Topic.SubCategory))
          End If
        End If
      ElseIf CurrentUser.GeneralRole < Authentication.User.RoleType.AdministratorJunior Then
        'Force no show Censore message in forum for inside use (message board, foto comments, ecc..)
        ShowCensored = False
      End If

      'Reactive subscription if is suspended
      If CurrentUser.GeneralRole > Authentication.User.RoleType.Visitors Then
        Dim Subscription As New Subscription(ForumId, TopicID)
        If Subscription.IsSubscript(CurrentUser.Username) = Subscription.TypeSubscription.IsTrue Then
          If Subscription.Subscription(CurrentUser.Username).Suspend = True Then
            Subscription.Subscription(CurrentUser.Username).Suspend = False
            Subscription.Save()
          End If
        End If
      End If

      Dim Ctrl As New HtmlGenericControl("section") 'html5

      If Topic IsNot Nothing Then
        Topic.IncReaded()
        If Topic.Censored AndAlso Not ShowCensored Then
          'Force a "show Censore reply" if the user view a Censored topic
          If IsCrawler() Then
            ShowCensored = True
          ElseIf Not ForumForInsideUse(ForumId) Then
            HttpContext.Current.Response.Redirect(ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId), True)
          End If
        End If

        Dim PrivateTopicOfUser As User = Nothing
        If AddTitle Then
          'Add Title of topic
          Select Case ForumId
            Case ReservedForums.PrivateMessage
              If PrivateTopicOfUser Is Nothing Then
                If Topic.Reference = "" Then
                  'Convert for compatibility to old version software
                  'Add a reference to topic
                  Topic.Reference = Replies(0).Title
                  Topic.Save()
                End If
                PrivateTopicOfUser = User.Load(Topic.Reference)
              End If
              If PrivateTopicOfUser IsNot Nothing Then
                RedirectToAppropriateSubSite(PrivateTopicOfUser, Setting)
                Ctrl.Controls.Add(TitleTopicCtrl(ForumId, TopicID, Setting, MasterPage, Topic.Reference))
              End If
            Case ReservedForums.PhotoComment, ReservedForums.ArchiveComment
              If Topic.Reference = "" Then
                'Convert for compatibility to old version software
                'Add a reference to topic
                Topic.Reference = Topic.Title
                Topic.Save()
              End If
              Ctrl.Controls.Add(TitleTopicCtrl(ForumId, TopicID, Setting, MasterPage, Topic.Reference))
            Case Else
              Ctrl.Controls.Add(TitleTopicCtrl(ForumId, TopicID, Setting, MasterPage, Topic.Reference, Topic.Title))
          End Select
        End If

        'Set metatag of page
        If MasterPage IsNot Nothing Then
          Select Case ForumId
            Case ReservedForums.PrivateMessage
              If PrivateTopicOfUser IsNot Nothing Then
                MasterPage.TitleDocument = PrivateTopicOfUser.Username
                MasterPage.Description = Phrase(Setting.Language, 121, 413) & " " & PrivateTopicOfUser.Username
                MasterPage.KeyWords = PrivateTopicOfUser.Username
              End If
            Case ReservedForums.PhotoComment
              Dim CommentsPhoto As Photo = Photo.Load(Topic.Reference)
              If CommentsPhoto IsNot Nothing Then
                MasterPage.TitleDocument = CommentsPhoto.Title(Setting.Language)
                MasterPage.Description = CommentsPhoto.Description(Setting.Language)
                MasterPage.KeyWords = MasterPage.TitleDocument & "," & MasterPage.Description
              End If
            Case ReservedForums.ArchiveComment
              Dim APL() As String = Split(Topic.Reference)
              If APL.Count = 3 Then
                Dim Html As String = ReadAll(MenuManager.PageNameFile(CInt(APL(0)), CInt(APL(1)), CType(APL(2), Language)))
                Dim MetaTags As New MetaTags(Html)
                MasterPage.TitleDocument = MetaTags.Title
                MasterPage.Description = MetaTags.Description
                MasterPage.KeyWords = MetaTags.KeyWords
              End If
            Case Else
              MasterPage.TitleDocument = Topic.Title
              MasterPage.Description = MasterPage.TitleDocument
              If Topic.Keywords <> "" Then
                MasterPage.KeyWords = Topic.Keywords & "," & MasterPage.TitleDocument
              Else
                MasterPage.KeyWords = MasterPage.TitleDocument
              End If
          End Select
        End If

        Dim Table As New HtmlTable

        Dim c As Integer()
        If OperationsColumn AndAlso Not Topic.Closed Then
          Dim NewC() As Integer = {0, 1, 2}
          c = NewC
        Else
          Dim NewC() As Integer = {0, 1}
          c = NewC
        End If

        'add row Title
        Dim TitleRow As HtmlTableRow = Components.HeaderRow(c.GetUpperBound(0) + 1, HorizontalAlign.Center, True)
        For EachC As Integer = c.GetLowerBound(0) To c.GetUpperBound(0)
          Dim NC As Integer = c(EachC)
          Select Case NC
            Case 0  'Author
              AddLabel(TitleRow.Cells(EachC), Phrase(Setting.Language, 69))
              TitleRow.Cells(EachC).Controls.Add(BR)
              AddLabel(TitleRow.Cells(EachC), Phrase(Setting.Language, 3027))
            Case 1  'Message
              'Set RSS link
              TitleRow.Cells(EachC).Controls.Add(RssButton(ForumManager.Link(ActionType.ShowRSS, Setting.Name, , , ForumId, TopicID)))
              'Set PDF link
              Dim PdfEnabled As Boolean = Setting.EnablePdfVersion.TopicsOfForum = EnabledStatus.Yes OrElse (Setting.EnablePdfVersion.TopicsOfForum = EnabledStatus.Default AndAlso Setup.RenderingEngine.EnablePdfVersion.TopicsOfForum = True)
              If PdfEnabled AndAlso PdfSupported(Setting.Language) Then
                AddLabel(TitleRow.Cells(EachC), " ")
                TitleRow.Cells(EachC).Controls.Add(PdfButton(HrefPdf(SourceType.Forum, CurrentDomainConfiguration, Setting.Name, ForumId, TopicID, Topic.Title)))
              End If
              If Page IsNot Nothing Then
                'Add meta-tag in Header for specify the RSS source for the forum
                Dim Meta As New HtmlLink
                Meta.Attributes.Add("rel", "alternate")
                Meta.Attributes.Add("type", "application/rss+xml")
                Meta.Attributes.Add("title", EncodingAttribute(Topic.Title))
                Meta.Href = ForumManager.Link(ActionType.ShowRSS, Setting.Name, , , ForumId, TopicID)
                Page.Header.Controls.Add(Meta)
              End If

              'Set Description
              AddLabel(TitleRow.Cells(EachC), " " & Phrase(Setting.Language, 60) & " ")
              TitleRow.Cells(EachC).Style.Add("width", "100%")
              'Add Arrow "go bottom"
              'Dim GoPageBottom As New Logo(Chr(&HEA), Components.DrowFonts.Wingdings, "#PageBottom", Phrase(Setting.Language, 3051))
              'Dim GoPageBottom As New Logo(Setting.Skin, IconToolType.Bottom, "#PageBottom", Phrase(Setting.Language, 3051))
              TitleRow.Cells(EachC).Controls.Add(IconUnicode(IconName.ArrowDown, , Phrase(Setting.Language, 3051), "#PageBottom"))
            Case 2 'Operations (quote, Censore, ecc.)
              AddLabel(TitleRow.Cells(EachC), Phrase(Setting.Language, 68))
          End Select
        Next

        'add row in table
        Table.Rows.Add(TitleRow)

        If CBool(Replies.Length) Then
          Dim FirstMessage, LastMessage, TotalPages As Integer
          TotalPages = Replies.GetUpperBound(0) \ Setup.Forum.RepliesForPages + 1

          'Verifi eventually error of total page and make correction
          If DateDiff(DateInterval.Hour, Topic.LastReplyNotCensoredCreate(True).ToUniversalTime, Now.ToUniversalTime) > Setup.Security.HoursEvaluationTimeNewUser Then
            If ShowCensored Then
              If Topic.NReplies <> Replies.GetUpperBound(0) + 1 Then
                Log("ErrorNRepliesInTopic", 1000, "NReplies", CStr(Topic.ForumId), CStr(Topic.ID), CStr(Topic.NReplies), CStr(Replies.GetUpperBound(0) + 1))
                Topic.NReplies = Replies.GetUpperBound(0) + 1
                Topic.Save()
              End If
            Else
              If Topic.NRepliesNotCensored <> Replies.GetUpperBound(0) + 1 Then
                Log("ErrorNRepliesInTopic", 1000, "NRepliesNotCensored", CStr(Topic.ForumId), CStr(Topic.ID), CStr(Topic.NRepliesNotCensored), CStr(Replies.GetUpperBound(0) + 1))
                Topic.NRepliesNotCensored = Replies.GetUpperBound(0) + 1
                Topic.Save()
              End If
            End If
          End If


          If CurrentPage = 0 Then
            CurrentPage = TotalPages
          End If
          If CurrentPage > TotalPages Then
            CurrentPage = TotalPages
          End If

          FirstMessage = (CurrentPage - 1) * Setup.Forum.RepliesForPages
          LastMessage = FirstMessage + Setup.Forum.RepliesForPages - 1
          If LastMessage > Replies.GetUpperBound(0) Then
            LastMessage = Replies.GetUpperBound(0)
          End If
          For NReply As Integer = FirstMessage To LastMessage
            Dim Reply As Reply = Replies(NReply)
            If NReply = 0 Then
              FirstReply = Reply
            End If
            'Set Meta Tag Revisit after x Days
            Dim FlagRevisitAfter As Boolean
            If FlagRevisitAfter = False Then
              FlagRevisitAfter = True
              If SetMetaRevisitAfter Then
                SetRevisitAfrer(Page, Reply)
              End If
            End If

            Dim Row As HtmlTableRow = Components.Row(c.GetUpperBound(0) + 1, , True)

            Dim Author As User = Nothing
            If Reply.AuthorAccount Is Nothing Then
              Author = Authentication.User.Load(Reply.Author)
              If Author IsNot Nothing AndAlso MasterPage IsNot Nothing Then
                MasterPage.AddAuthors(Author)
              End If
            End If

            Dim Create As Date = Reply.Created

            For EachC As Integer = c.GetLowerBound(0) To c.GetUpperBound(0)
              Dim NC As Integer = c(EachC)

              Select Case NC
                Case 0  'Author
                  Row.Cells(EachC).Style.Add("text-align", "center") 'html5
                  Dim InfoUser As RenderMethod = Sub(Writer As System.Web.UI.HtmlTextWriter, Container As System.Web.UI.Control)
                                                   If Reply.AuthorAccount Is Nothing Then
                                                     QuickInfoUser(CurrentSetting, Author, CurrentForum).RenderControl(Writer)
                                                   Else
                                                     QuickInfoUserExternalAccount(Reply.Author, Reply.AuthorAccount).RenderControl(Writer)
                                                   End If
                                                 End Sub
                  Dim PlaceHolder As New PlaceHolder
                  PlaceHolder.SetRenderMethodDelegate(InfoUser)
                  Row.Cells(EachC).Controls.Add(PlaceHolder)
                  Row.Cells(EachC).Controls.Add(BR)
                  AddDateAndTime(Row.Cells(EachC), Create)

                  If Setting.SEO.LinkToWebsitesOfUsersInTheForums <> SubSite.SeoFunctions.TypeLink.No AndAlso Author IsNot Nothing Then
                    If Author.URL <> "" AndAlso (Author.URL.StartsWith("http://") OrElse Author.URL.StartsWith("https://")) Then
                      Row.Cells(EachC).Controls.Add(BR)
                      Dim Link As New HyperLink
                      Link.CssClass = "url"
                      Link.NavigateUrl = Author.URL
                      Link.ToolTip = Phrase(Setting.Language, 18)
                      Select Case Setting.SEO.LinkToWebsitesOfUsersInTheForums
                        Case SubSite.SeoFunctions.TypeLink.Yes
                          Link.Text = Link.ToolTip
                        Case SubSite.SeoFunctions.TypeLink.YesWithTheIcon
                          Link.Controls.Add(Components.Icon(IconType.Globe, Setting.Skin, Phrase(Setting.Language, 18)))
                        Case SubSite.SeoFunctions.TypeLink.YesWithTheTitle

                          Dim TitleOfWebSite As String = CStr(Author.Attribute("TitleOfWebSite"))
                          If TitleOfWebSite = "" OrElse CStr(Author.Attribute("UrlOfWebSite")) <> Author.URL Then
                            Try
                              Dim MetaTags As New MetaTags(ReadHtmlFromWeb(Author.URL))
                              TitleOfWebSite = MetaTags.Title
                            Catch ex As Exception
                            End Try
                            If TitleOfWebSite = "" Then
                              TitleOfWebSite = Author.URL
                            End If
                            Author.Attribute("TitleOfWebSite") = TitleOfWebSite
                            Author.Attribute("UrlOfWebSite") = Author.URL
                          End If
                          Link.Text = HttpUtility.HtmlEncode(TruncateText(TitleOfWebSite, 200))
                          Link.Style.Add("white-space", "normal")
                      End Select
                      Row.Cells(EachC).Controls.Add(Link)
                    End If
                  End If

                  'Show awatars
                  If ShowAvatars AndAlso Author IsNot Nothing Then
                    Dim Avatar As Control = Author.AvatarControl(Setting)
                    If Avatar IsNot Nothing Then
                      Row.Cells(EachC).Controls.Add(BR)
                      Row.Cells(EachC).Controls.Add(Avatar)
                    End If
                  End If

                Case 1  'Message
                  'Allign
                  'Row.Cells(EachC).HorizontalAlign = HorizontalAlign.Justify
                  Dim Cell As HtmlTableCell = Row.Cells(EachC)
                  Cell.Style.Add("text-align", "justity") 'html5
                  Cell.Style.Add("white-Space", "normal") 'html5

                  'Dim Align As New WebControls.WebControl(HtmlTextWriterTag.Span)
                  'Align.CssClass = "PhotoUnpair"

                  'Add Photo
                  Dim MyPhoto As Photo = Photo.Load(Reply.Photo)
                  If MyPhoto IsNot Nothing Then
                    Dim Box As HtmlControl = CType(MyPhoto.ControlThumbnail(Setting, , SizeImagePreview), HtmlControl)
                    Box.Attributes.Add("class", "BoxElement PhotoUnpair")
                    Cell.Controls.Add(Box)
                  End If

                  'Add video
                  If Reply.Video <> "" Then
                    Dim Box As WebControl = CType(VideoObject(Reply.Video, Setting, HttpContext.Current), WebControl)
                    If Setting.Aspect.SizeOfVideoEmbedded = SubSite.AspectConfiguration.VideoSize.SameAsImagesPreviewConfiguration Then
                      Box.CssClass = "BoxElement PhotoUnpair"
                    End If
                    Cell.Controls.Add(Box)
                  End If

                  'Add Message
                  If Setup.Performance.MultyThread Then
                    'Multy Thread
                    Dim ReplyNumber As Integer = NReply
                    Dim www As ContextualLink.AddWWW
                    If HttpContext.Current.Request IsNot Nothing Then
                      If DomainName(HttpContext.Current.Request).StartsWith("www.") Then
                        www = ContextualLink.AddWWW.Yes
                      Else
                        www = ContextualLink.AddWWW.No
                      End If
                    End If
                    Dim NewThread = New Threading.Thread(Sub()
                                                           GerReplyText(Cell, ForumId, TopicID, Reply, Setting, Archive, ReplyNumber, www)
                                                         End Sub)
                    NewThread.Name = "GerReplyText"
                    NewThread.IsBackground = True
                    NewThread.Start()
                    Threads.Add(NewThread)
                  Else
                    'Mono Thread
                    GerReplyText(Cell, ForumId, TopicID, Reply, Setting, Archive, NReply)
                  End If

                  'Add extra info
                  If Reply.Censored Then
                    Row.Cells(EachC).Controls.Add(BR)
                    Row.Cells(EachC).Controls.Add(Components.Message(Setting, 2009, , , MessageType.Normal))
                  ElseIf ReplyMomentarilyHidden(Reply, , Topic) Then
                    'Message momentarily hidden
                    Row.Cells(EachC).Controls.Add(BR)
                    Row.Cells(EachC).Controls.Add(Components.Message(Setting, 2008, , , MessageType.Normal))
                  End If
                Case 2 'Operations
                  Dim ReplyID As Integer = Reply.ID
                  Row.Cells(EachC).Style.Add("text-align", "center")  'html5

                  'Reply with quote
                  Dim Quote As Control = Components.IconUnicode(IconName.LeftPointingIndex, , Phrase(Setting.Language, 3071), Link(ActionType.Reply, Setting.Name, , Jump, ForumId, TopicID, ReplyID))
                  Row.Cells(EachC).Controls.Add(Quote)

                  If AbleToModifyReply(Setting, Reply.Author, Create, Reply.AuthorAccount) Then
                    'Modify message
                    Dim Edit As Control = Components.IconUnicode(IconName.WritingHand, , Phrase(Setting.Language, 74), Link(ActionType.Modify, Setting.Name, , Jump, ForumId, TopicID, ReplyID))
                    Row.Cells(EachC).Controls.Add(Edit)
                  End If

                  If AbleToCensore(Setting, PrivateTopicOfUser) OrElse (CBool(Stars(CurrentUser)) AndAlso CurrentForum.Type <> Forum.TypeOfForum.TicketSystem) Then
                    'Require Censore
                    Dim NavigateUrl As String = Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.RequireTopicCensore, , , ForumId, TopicID, ReplyID))
                    Dim Censore As Control = Components.IconUnicode(IconName.ScissorBlack, , Phrase(Setting.Language, 3075), NavigateUrl)
                    Row.Cells(EachC).Controls.Add(Censore)
                  End If

              End Select
            Next
            'add row in table
            Table.Rows.Add(Row)
          Next

          Dim Anchor As New Literal
          Anchor.Text = "<a id=""StartTopic""></a>"
          'Dim Anchor As New HyperLink
          'Anchor.ID = "StartTopic"
          Ctrl.Controls.Add(Anchor)
          Ctrl.Controls.Add(Table)

          'Add Paginate
          If TotalPages > 1 Then
            Ctrl.Controls.Add(Paginate(Setting, TotalPages, CurrentPage, Action, ForumId, TopicID))
          End If
        Else
          Ctrl.Controls.Add(Components.Message(Phrase(Setting.Language, 3050), Setting))
        End If
        If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.Visitors Then

          If AddButtons Then
            Dim Buttons As New HtmlGenericControl("nav")
            Ctrl.Controls.Add(Buttons)

            'Add return Forum button
            If Not ForumForInsideUse(ForumId) Then
              If Setting.Forums IsNot Nothing Then
                AddButtonReturnForm(ForumId, Setting, MasterPage, Buttons)
              End If
            End If

            '
            'Add PDF button
            'If Setting.Forums IsNot Nothing Then
            'End If

            'DownloadPdf.NavigateUrl = PathUrl(AbsoluteUri(HttpContext.Current.Request)) & "p." & Setting.Name & "." & Replace(Photo.Album, "/", "-") & "." & Photo.Name & "/" & HttpUtility.UrlEncodeUnicode(Alphanumeric(Photo.Title(Setting.Language))) & ".pdf"
            'PlaceHolderControlOperations.Controls.Add(DownloadPdf)


            'Add button Speech Topic
            If HttpContext.Current.Request.Browser.VBScript = True Then
              'TextToSpeek feature
              Dim IdButton As Integer = CInt(Val(HttpContext.Current.Items("LastIdContent"))) + 1
              HttpContext.Current.Items("LastIdContent") = IdButton
              Dim RssSource As String = ForumManager.Link(ActionType.ShowXML, Setting.Name, True, , ForumId, TopicID)
              MasterPage.AddButton(Phrase(Setting.Language, 3246), "vbscript:XmlSrc(""" & RssSource & """)", Nothing, IconType.MusicPlayer)
              Buttons.Controls.Add(Button(Setting, Phrase(Setting.Language, 3246), "vbscript:XmlSrc(""" & RssSource & """)", Nothing, IconType.MusicPlayer))
            End If

            'Add button for add topic in google bookmarks
            Dim Bookmark As String = ForumManager.Link(ActionType.Show, Setting.Name, True, , ForumId, TopicID, , 1)
            Dim Href As String = HrefGoogleAddBookmarks(Setting.Language, Topic.Title, Bookmark, PathCurrentUrl)
            Buttons.Controls.Add(Button(Setting, Phrase(Setting.Language, 134), Href, , Components.IconType.Favourites, "_blank", True))

            'Add reply button
            If OperationsColumn Then
              If Not Topic.Closed Then
                Dim AddButtonReply As Boolean
                If CurrentForum.Type <> Forum.TypeOfForum.TicketSystem Then
                  AddButtonReply = True
                Else
                  If FirstReply Is Nothing Then FirstReply = Topic.FirstReply
                  If (CurrentUser.Username = FirstReply.Author AndAlso FirstReply.AuthorAccount Is Nothing) OrElse CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
                    AddButtonReply = True
                  End If
                End If
                If AddButtonReply Then
                  Dim Text As String
                  Dim HrefReply As String = ForumManager.Link(ActionType.Reply, Setting.Name, , Jump, ForumId, TopicID)

                  If Not ForumForInsideUse(ForumId) Then
                    Text = Phrase(Setting.Language, 73)
                  Else
                    Select Case ForumId
                      Case ReservedForums.PrivateMessage
                        Text = Phrase(Setting.Language, 122)
                      Case Else
                        Text = Phrase(Setting.Language, 123)
                    End Select
                  End If
                  MasterPage.AddButton(Text, HrefReply, , Components.IconType.Pen, , True, , Setting.Aspect.SuggestTheBestChoiceByTheBlink)
                  Dim ReplyButton As Control = Button(Setting, Text, HrefReply, , Components.IconType.Pen, , True)
                  If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
                    MasterPage.Blink(ReplyButton)
                  End If
                  Buttons.Controls.Add(ReplyButton)
                End If
              End If

              'Add button "Close" / "Open"
              If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
                If Topic.Closed Then
                  Href = Common.Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.OpenTopic, , , ForumId, Topic.ID))
                  Buttons.Controls.Add(Button(Setting, Phrase(Setting.Language, 2024), Href, , Components.IconType.Globe, , True))
                Else
                  Href = Common.Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.CloseTopic, , , ForumId, Topic.ID))
                  Buttons.Controls.Add(Button(Setting, Phrase(Setting.Language, 111), Href, , Components.IconType.Globe, , True))
                End If
              End If

              'Add button "Set topic is resolved" / "Unset topic is resolved"
              If CurrentForum.Type = Forum.TypeOfForum.TicketSystem Then
                If Not Topic.Closed Then
                  If FirstReply Is Nothing Then FirstReply = Topic.FirstReply
                  If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior OrElse (CurrentUser.Username = FirstReply.Author AndAlso FirstReply.AuthorAccount Is Nothing) Then
                    If CBool(Topic.AsResolved) Then
                      Href = Common.Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.MarkTopicAsResolved, , "0", ForumId, Topic.ID))
                      Buttons.Controls.Add(Button(Setting, Phrase(Setting.Language, 2027), Href, , Components.IconType.Globe, , True))
                    Else
                      Href = Common.Href(Setting.Name, False, "messenger.aspx", MessengerManager.QueryStringParameters(, MessengerManager.Action.MarkTopicAsResolved, , "-1", ForumId, Topic.ID))
                      Buttons.Controls.Add(Button(Setting, Phrase(Setting.Language, 2026), Href, , Components.IconType.Globe, , True))
                    End If
                  End If
                End If
              End If

              'Add info "The topic is closed!"
              If Topic.Closed Then
                Buttons.Controls.Add(Components.IconUnicode(IconName.Block, True, Phrase(Setting.Language, 2025)))
              End If

            End If
          End If
        End If

        'Add Anchor in Page Bottom
        Dim AnchorBottom As New Literal
        AnchorBottom.Text = "<a name=""PageBottom""></a>"
        Ctrl.Controls.Add(AnchorBottom)

        'Add quote style
        'Dim QuoteStyle As New LiteralControl
        'QuoteStyle.Text = "<style><!--span.quote { font-style: italic; border-style: dotted; border-width: 1px}--></style>"
        'Ctrl.Controls.Add(QuoteStyle)

        If Not ForumForInsideUse(ForumId) AndAlso LinksCorrelated IsNot Nothing Then

          'Add tools to select appropriate category
          If Topic.SubCategory = 0 OrElse CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
            If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.Senior Then
              If Setting.Forums IsNot Nothing AndAlso Setting.Forums.Contains(ForumId) Then
                Dim Forum As Forum = CType(Forum.Load(CStr(ForumId)), ForumManager.Forum)
                If Forum.ForumStructure IsNot Nothing AndAlso Forum.ForumStructure.Categories.Count > 0 Then
                  Dim Box As New WebControl(HtmlTextWriterTag.Fieldset)
                  Box.CssClass = "Menu"
                  Dim TitleBox As New WebControl(HtmlTextWriterTag.H3)
                  TitleBox.Controls.Add(TextControl(Phrase(Setting.Language, IfInt(Topic.SubCategory = 0, 139, 140))))

                  Box.Controls.Add(TitleBox)
                  Dim Categories = Forum.ForumStructure.CategoriesSorted
                  For Each Category As ForumStructure.Category In Categories
                    For Each Subcategory As ForumStructure.Category.Subcategory In Category.Subcategories
                      Dim HyperLink As New HyperLink
                      HyperLink.Text = HttpUtility.HtmlEncode(Category.Title & ">" & Subcategory.Title)
                      HyperLink.ToolTip = EncodingAttribute(Subcategory.Description)
                      HyperLink.NavigateUrl = Link(ActionType.SetSubcategory, Setting.Name, , , ForumId, TopicID, , , , , , , Subcategory.Id)
                      Box.Controls.Add(BR)
                      Box.Controls.Add(HyperLink)
                    Next
                  Next
                  LinksCorrelated.Controls.Add(BR)
                  LinksCorrelated.Controls.Add(Box)
                End If
              End If
            End If
          End If


          'Add correlated links
          Dim Topics As System.Collections.Generic.List(Of ForumManager.Topic) = AllTopics(ForumId, ShowCensored)
          If Topics IsNot Nothing AndAlso Topics.Count <> 0 Then
            Dim BaseWords() As String = ExtrapolateWords(Topic.Keywords)
            Dim Words As New ArrayList
            If Not BaseWords Is Nothing Then
              For Each Word As String In BaseWords
                If Word.Length >= 4 Then
                  Words.Add(Left(Word, Len(Word) - 1)) 'Cut the last caratter for not M/F case sensitive; Exemp.: "Hotels" > "Hotel"
                End If
              Next
            End If
            If CBool(Words.Count) Then
              Dim CorrelatedLinks As New Control
              For Each CompareTopic As Topic In Topics
                If Topic.ID <> CompareTopic.ID Then
                  Dim Finded As Integer = 0
                  Dim NotFinded As Integer = 0
                  Dim CompareWords() As String = ExtrapolateWords(CompareTopic.Keywords)
                  If Not CompareWords Is Nothing Then
                    For Each Word As String In Words
                      For Each CompareWord As String In CompareWords
                        If CompareWord.Length >= 4 Then
                          CompareWord = Left(CompareWord, Len(CompareWord) - 1) 'Cut the last caratter for not M/F case sensitive; Exemp.: "Hotels" > "Hotel"
                          If Math.Abs(Word.Length - CompareWord.Length) <= 3 Then
                            If CompareWord.StartsWith(Word, StringComparison.InvariantCultureIgnoreCase) OrElse Word.StartsWith(CompareWord, StringComparison.InvariantCultureIgnoreCase) Then
                              Finded += 1
                            Else
                              NotFinded += 1
                            End If
                          End If
                        End If
                      Next
                    Next
                    If CBool(Finded) Then
                      If Finded >= NotFinded Then
                        Dim CompareTopicFirstReply As Reply = CompareTopic.FirstReply
                        If CompareTopicFirstReply IsNot Nothing Then
                          Dim Link As New WebControls.HyperLink
                          Link.Text = HttpUtility.HtmlEncode(CompareTopicFirstReply.Title)
                          Link.NavigateUrl = Reply.QueryString(Setting, ForumId, CompareTopic.ID, 1)
                          CorrelatedLinks.Controls.Add(Link)
                          CorrelatedLinks.Controls.Add(BR)
                        End If
                      End If
                    End If
                  End If
                End If
              Next
              If CBool(CorrelatedLinks.Controls.Count) Then
                LinksCorrelated.Controls.Add(Fieldset(Phrase(Setting.Language, 3212), CorrelatedLinks))
              End If
            End If
          End If
        End If
      End If
      For Each Thread As Threading.Thread In Threads
        Thread.Join()
      Next
      Return Ctrl
    End Function


    Sub GerReplyText(AddToCell As HtmlTableCell, ForumId As Integer, TopicID As Integer, Reply As Reply, Setting As SubSite, Archive As Integer, NReply As Integer, Optional AddWWW As ContextualLink.AddWWW = ContextualLink.AddWWW.Auto)
      Dim Lt As New Literal
      Lt.Text = AddEmoticons(Reply.Text)
      If Reply.IsPoll Then
        PollManager.AddPoll(CurrentDomainConfiguration, Setting, Lt.Text, PollContext.Forum, Reply.Poll, ForumId, TopicID, Reply.ID)
      End If
      TagNameToLower(Lt.Text)

      If AddLinksAccommodationService IsNot Nothing Then
        AddLinksAccommodationService(Lt.Text, Setting.Language, CurrentDomainConfiguration, Setting.Name)
      End If

      ContextualLink.AddLinks(Lt.Text, Setting, CurrentDomainConfiguration, Archive, AddWWW)
      If NReply = 0 Then
        AddCityInformation(Lt.Text, Setting)
      End If
      If Setting.SEO.CopyPrevention.ForumAndComments Then
        Lt.Text = ObfuscateHtml(Lt.Text, Setting)
      End If
      AddToCell.Controls.Add(Lt)
    End Sub



		Private Sub SetRevisitAfrer(ByVal page As Page, ByVal LastReply As Reply)
			'Set Meta Tag Revisit after x Days
			If page IsNot Nothing AndAlso LastReply IsNot Nothing Then
        Dim MasterPage As Components.MasterPage
        MasterPage = CType(page.Master, Components.MasterPage)
				If CacheForumLoaded = False Then
					MasterPage.MetaRevisitAfterDays = 1
				Else
          Dim RevisitAfterDay As Integer = CInt(DateDiff(DateInterval.Day, LastReply.Created, Now.ToUniversalTime))
					If RevisitAfterDay < 1 Then
						RevisitAfterDay = 1
					End If
					MasterPage.MetaRevisitAfterDays = RevisitAfterDay
				End If
			End If
		End Sub

		Function TitleTopicCtrl(ByVal ForumId As Integer, ByVal TopicId As Integer, ByVal Setting As SubSite, ByVal MasterPage As MasterPage, Optional ByVal Reference As String = Nothing, Optional ByVal Text As String = Nothing) As Control
			Select Case ForumId
				Case ReservedForums.PhotoComment
					Dim Ctrl As New Control
					Dim PhotoWithComments As Photo = Photo.Load(Reference)
					If PhotoWithComments IsNot Nothing Then
						Ctrl.Controls.Add(PhotoWithComments.ControlPhoto(Setting))
					End If
					Return Ctrl
				Case ReservedForums.ArchiveComment
					Dim APL() As String = Split(Reference)
					Dim Ctrl As New Control
          Components.AddPageArchived(Ctrl, MasterPage, CInt(APL(0)), CInt(APL(1)), HttpContext.Current, CurrentDomainConfiguration, Setting, , , , False)
					Return Ctrl
				Case Else
					Dim Title As New LiteralControl
					Dim H1 As WebControl = Components.Control(HtmlTextWriterTag.H1)
					H1.Controls.Add(Title)
					Select Case ForumId
						Case ReservedForums.PrivateMessage
							Title.Text = Web.HttpUtility.HtmlEncode(Phrase(Setting.Language, 121, 413) & " " & Reference)
						Case Else
							Title.Text = Web.HttpUtility.HtmlEncode(Text)
							AddCityInformation(Title.Text, Setting)
					End Select
					Return H1
			End Select
		End Function

    Public Sub AddButtonReturnForm(ByVal ForumId As Integer, ByVal Setting As SubSite, ByVal Masterpage As MasterPage, ByVal Buttons As Control)
      Dim Text As String
      Dim Href As String
      Text = Phrase(Setting.Language, 61)
      Href = ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId)
      Masterpage.AddButton(Text, Href, , Icon_Forum)
      Buttons.Controls.Add(Button(Setting, Text, Href, , Icon_Forum))
    End Sub

		Public Delegate Sub AddLinksDelegate(ByRef Text As String, ByVal Language As LanguageManager.Language, ByVal DomainConfiguration As DomainConfiguration, ByVal CurrentSubSiteName As String)

    Public AddLinksAccommodationService As AddLinksDelegate

	End Module


End Namespace