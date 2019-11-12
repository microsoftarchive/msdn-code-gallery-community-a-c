'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.IO
Namespace WebApplication
	Public Module Sitemap
		Enum TypeOfSitemap
			Generic
			Images
		End Enum

		Public Sub SiteMapGenerator(ByVal Type As TypeOfSitemap)
			Dim Request As HttpRequest = HttpContext.Current.Request
			Dim Response As HttpResponse = HttpContext.Current.Response
      Dim Pages As StringCollection = Nothing
			Dim Domain As String
			Domain = CurrentDomain()
			'UpdateIndexedPagesOnGoogle(Domain)
			If InStr(Request.UserAgent, "Google", CompareMethod.Text) Then
        If Setup.SEO.AtGooglebotExcludeIndexedPagesInSitemap Then
          Pages = LoadObject(GetType(StringCollection), "googleidx_" & Domain)
        End If
			End If

			Extension.Log("ReadSitemap", 1000, Domain, Pages IsNot Nothing, Request.UserAgent, Request.UserHostAddress)

			Response.Clear()
			Response.Cache.SetNoStore()
			Response.ContentType = "text/xml"
      Sitemap.GenerateSiteMap(Response.OutputStream, Domain, Pages, AbsoluteUri(Request).StartsWith("http://www."), Type)
			Response.End()
    End Sub

		Public Sub GenerateSiteMap(ByVal Stream As Stream, ByVal Domain As String, Optional ByVal Exclude As StringCollection = Nothing, Optional ByVal www As Boolean = False, Optional ByVal Type As TypeOfSitemap = TypeOfSitemap.Generic)
			Dim SiteMap As XmlTextWriter
      Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture
      SiteMap = New XmlTextWriter(Stream, Encoding.UTF8)
			siteMap.WriteStartDocument()
			siteMap.WriteStartElement("urlset")

			siteMap.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
			siteMap.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd")

			siteMap.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9")
			If Type = TypeOfSitemap.Images Then
				siteMap.WriteAttributeString("xmlns:image", "http://www.google.com/schemas/sitemap-image/1.1")
			End If

			Dim DomainConfiguration As DomainConfiguration = DomainConfiguration.Load(Domain)
			For Each Setting As SubSite In DomainConfiguration.SubSites
				PluginManager.RaiseOnSitemapGenerationEvent(Type, Setting, SiteMap, Domain, Exclude, www)
				Select Case Type
					Case TypeOfSitemap.Generic
						'Add home page
            AddPage(www, SiteMap, Domain, Href(DomainConfiguration, Setting.Name, False, "default.aspx"), Exclude, 0.8!, Now.ToUniversalTime, ChangeFrequency.Daily)

						'Add all plugin with aspx file
						For Each Plugin As PluginManager.Plugin In AllPlugins()
							If Plugin.AspxFileName <> "" Then
                If Plugin.IsEnabledAndAccessible(Authentication.User.RoleType.Visitors, Setting) Then
                  If Plugin.AddItemToMenu Then
                    AddPage(www, SiteMap, Domain, Href(Setting.Name, False, Plugin.AspxFileName), Exclude, 0.5!, , ChangeFrequency.Yearly)
                  End If
                End If
							End If
						Next

						'Add link to external blog
						If Setting.EnableRelatedBlogAggregator AndAlso Setting.Blog IsNot Nothing AndAlso Setting.Blog.Count > 0 Then
							For Each Blog As Notice In Setting.Blog
								If Not UrlPointToThisNetwork(Blog.Link) Then
                  AddPage(www, SiteMap, Domain, Common.Href(CurrentSetting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.ExternalPage, QueryKey.Url, Blog.Link.Substring(Blog.Link.IndexOf("/"c) + 2)), Exclude, 0.8!, Blog.pubDate, ChangeFrequency.Never)
								End If
							Next
						End If
				End Select

				'Add link to news
				Dim Notices As Collections.Generic.List(Of Notice) = NewsManager.News(Setting.News)
				If Notices IsNot Nothing Then
					For Each Notice As Notice In Notices
						If Type = TypeOfSitemap.Generic OrElse (Type = TypeOfSitemap.Images AndAlso Notice.Image <> "") Then
							Dim Image As String = Nothing
							If Type = TypeOfSitemap.Images Then
								Image = Notice.Image
							End If
              AddPage(www, SiteMap, Domain, Href(Setting.Name, False, "default.aspx", QueryKey.CryptedUrl, CryptUrl(Notice.Link.Substring(Notice.Link.IndexOf("/"c) + 2))), Exclude, 0.8!, Notice.pubDate, ChangeFrequency.Never, Image)
						End If
					Next
				End If

				'Add Menu
				If Setting.Archive IsNot Nothing Then
					For Each Archive As Integer In Setting.Archive
						Dim Menu As Menu = Menu.Load(Archive, Setting.Language)
						If Not Menu Is Nothing Then
							For Each Item As ItemMenu In Menu.ItemsMenu
								If Item.IdPage <> 0 AndAlso Item.Off = False Then
									Dim Priority As Single
									Select Case Item.Level
										Case 0, 1
                      Priority = 0.600000024!
										Case 2
                      Priority = 0.5!
										Case Else
                      Priority = 0.400000006!
									End Select

									Dim Photo As Photo = Nothing
									If Type = TypeOfSitemap.Images Then
										If Type = TypeOfSitemap.Images Then
											Dim Html As String = ReadAll(MenuManager.PageNameFile(Menu.Archive, Item.IdPage, Setting.Language))
											Dim MetaTags As New MetaTags(Html)
											Dim TagPhoto As String = MetaTags.MetaTag("Photo")
											If TagPhoto <> "" Then
												Photo = Photo.Load(TagPhoto)
											End If
										End If
									End If

									If Type = TypeOfSitemap.Generic OrElse (Type = TypeOfSitemap.Images AndAlso Photo IsNot Nothing) Then
										AddPage(www, SiteMap, Domain, Item.Href(DomainConfiguration, Setting), Setting, Photo, True, Exclude, Priority, , ChangeFrequency.Never)
									End If
								End If
							Next
						End If
					Next
				End If

				'Add link to forum
				If Setting.Forums IsNot Nothing Then
					For Each ForumId As Integer In Setting.Forums
						Dim Forum As Forum = Forum.Load(ForumId)
						If Type = TypeOfSitemap.Generic Then
							For Each Topic As Topic In AllTopics(ForumId, False)
								If Topic.NRepliesNotCensored > 0 Then
									For NPage As Integer = 1 To Topic.TotalPages(False)
										Dim Priority As Single
										Select Case Topic.NRepliesNotCensored
											Case Is > 100
                        Priority = 0.800000012!
											Case Is > 50
                        Priority = 0.699999988!
											Case Is > 10
                        Priority = 0.600000024!
											Case Is > 2
                        Priority = 0.5!
											Case Is > 1
                        Priority = 0.300000012!
											Case Else
                        Priority = 0.100000001!
										End Select
                    Priority = Priority / (1 + (NPage - 1) / 30)
										If NPage <> 1 Then
                      Priority -= 0.100000001!
										End If

										Dim Frequency As ChangeFrequency
										If NPage <> Topic.TotalPages(False) Then
											Frequency = ChangeFrequency.Never
										Else
											Dim Days As Integer = DateDiff(DateInterval.Day, Topic.LastReplyCreate(False), Now.ToUniversalTime)
											Select Case Days
												Case Is < 2
													Frequency = ChangeFrequency.Hourly
												Case Is < 7
													Frequency = ChangeFrequency.Daily
												Case Is < 30
													Frequency = ChangeFrequency.Weekly
												Case Is < 60
													Frequency = ChangeFrequency.Monthly
												Case Else
													Frequency = ChangeFrequency.Never
											End Select
										End If
										Dim LastModified As Date
										If NPage = Topic.TotalPages(False) Then
											LastModified = Topic.LastReplyCreate(False)
										Else
											LastModified = Nothing
										End If
										AddPage(www, SiteMap, Domain, ForumManager.Link(ActionType.Show, Setting.Name, , , ForumId, Topic.ID, , NPage), Exclude, Priority, LastModified, Frequency)
									Next
								End If
							Next
						End If

						'Add photo album of forum
            If Forum.PhotoAlbum <> "" Then
              Dim ForumPhotoAlbums As PhotoAlbum = PhotoAlbum.Load(Forum.PhotoAlbum)
              If ForumPhotoAlbums IsNot Nothing Then
                AddPhotoAlbum(ForumPhotoAlbums, www, SiteMap, DomainConfiguration, Setting, Exclude, Type)
              End If
            End If
          Next
        End If

        'Photos
        Dim PhotoAlbums As StringCollection = Setting.PhotoAlbums
        If PhotoAlbums IsNot Nothing Then
          For Each PhotoAlbumsName As String In PhotoAlbums
            Dim PhotoAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(PhotoAlbumsName)
            If PhotoAlbum IsNot Nothing Then
              AddPhotoAlbum(PhotoAlbum, www, SiteMap, DomainConfiguration, Setting, Exclude, Type)
            End If
          Next
        End If
      Next

      ' .ToString(Globalization.CultureInfo.InvariantCulture)

      SiteMap.WriteEndElement()
      siteMap.WriteEndDocument()
      siteMap.Close()
    End Sub

    Public Sub AddPhotoAlbum(ByVal PhotoAlbum As PhotoAlbum, ByVal www As Boolean, ByVal xWriter As XmlTextWriter, ByVal Domain As DomainConfiguration, ByVal Setting As SubSite, Optional ByVal Exclude As StringCollection = Nothing, Optional ByVal Type As TypeOfSitemap = TypeOfSitemap.Generic)
      For Each Photo As Photo In PhotoAlbum.Photos.Values
        Dim Image As Photo = Nothing
        If Type = TypeOfSitemap.Images Then
          Image = Photo
        End If
        AddPage(www, xWriter, Domain.Name, HrefPhoto(PhotoAlbum.Name, Photo.Name, Setting, Domain), Setting, Image, False, Exclude, , Photo.Created, Sitemap.ChangeFrequency.Never)
      Next
      For Each SubPhotoAlbum As PhotoAlbum In PhotoAlbum.PhotoAlbums(False)
        If SubPhotoAlbum IsNot Nothing Then
          AddPhotoAlbum(SubPhotoAlbum, www, xWriter, Domain, Setting, Exclude, Type)
        End If
      Next
    End Sub

		Private Sub AddPage(ByVal www As Boolean, ByVal xWriter As XmlTextWriter, ByVal Domain As String, ByVal Url As String, ByVal Setting As SubSite, ByVal Image As Photo, Optional ByVal IsThumbnail As Boolean = False, Optional ByVal Exclude As StringCollection = Nothing, Optional ByVal Priority As Single = 0.5, Optional ByVal LastModified As Date = Nothing, Optional ByVal ChangeFrequency As ChangeFrequency = ChangeFrequency.Never)
      Dim ImageLoc As String = Nothing, ImageCaption As String = Nothing, ImageGeoLocation As String = Nothing, ImageTitle As String = Nothing, ImageLicense As String = Nothing
			If Image IsNot Nothing Then
				Select Case IsThumbnail
					Case True
            ImageLoc = "http://" & IfStr(www, "www.", "") & Domain & "/" & Image.SrcThumbnail(Setting, SizeImagePreview)
					Case Else
            ImageLoc = "http://" & IfStr(www, "www.", "") & Domain & "/" & Image.Src(Setting)
				End Select
				ImageCaption = Image.Description(Setting.Language)
				Dim Title As String = Image.Title(Setting.Language)
				If Image.Title(Setting.Language) <> "" Then
					Dim AllCity As Collections.Generic.List(Of City)
          AllCity = Tables.FindCity(Title)
					If AllCity IsNot Nothing AndAlso AllCity.Count > 0 Then
						ImageGeoLocation = AllCity(0).City
					End If
				End If
				ImageTitle = Title
        ImageLicense = "http://" & IfStr(www, "www.", "") & Domain & "/"
			End If
			AddPage(www, xWriter, Domain, Url, Exclude, Priority, LastModified, ChangeFrequency, ImageLoc, ImageCaption, ImageGeoLocation, ImageTitle, ImageLicense)
		End Sub

    Public Sub AddPage(ByVal www As Boolean, ByVal xWriter As XmlTextWriter, ByVal Domain As String, ByVal Url As String, Optional ByVal Exclude As StringCollection = Nothing, Optional ByVal Priority As Single = 0.5!, Optional ByVal LastModified As Date = Nothing, Optional ByVal ChangeFrequency As ChangeFrequency = ChangeFrequency.Never, Optional ByVal ImageLoc As String = Nothing, Optional ByVal ImageCaption As String = Nothing, Optional ByVal ImageGeoLocation As String = Nothing, Optional ByVal ImageTitle As String = Nothing, Optional ByVal ImageLicense As String = Nothing)
      If Priority < 0.0! Then Priority = 0.0!
      If Priority > 1.0! Then Priority = 1.0!
      'If Url IsNot Nothing AndAlso Url.StartsWith("~/") Then
      If Url IsNot Nothing AndAlso Url.StartsWith(".") Then
        Url = Url.Substring(1)
      End If
      'Dim Loc As String = Domain & "/" & System.Web.HttpUtility.HtmlEncode(Url)
      Dim Loc As String = Domain & "/" & Url
      If ExcludeNotContains(Exclude, Loc) Then
        xWriter.WriteStartElement("url")

        xWriter.WriteElementString("loc", "http://" & IfStr(www, "www.", "") & Loc)
        If LastModified <> Date.MinValue Then
          xWriter.WriteElementString("lastmod", LastModified.ToString("yyyy-MM-dd"))
        End If
        xWriter.WriteElementString("changefreq", ChangeFrequency.ToString.ToLower)
        xWriter.WriteElementString("priority", Priority.ToString("0.#"))

        'Add image
        If ImageLoc <> "" Then
          xWriter.WriteStartElement("image:image")
          xWriter.WriteElementString("image:loc", ImageLoc)
          If ImageCaption <> "" Then xWriter.WriteElementString("image:caption", ImageCaption)
          If ImageGeoLocation <> "" Then xWriter.WriteElementString("image:geo_location", ImageGeoLocation)
          If ImageTitle <> "" Then xWriter.WriteElementString("image:title", ImageTitle)
          If ImageLicense <> "" Then xWriter.WriteElementString("image:license", ImageLicense)
          xWriter.WriteEndElement()
        End If
        xWriter.WriteEndElement()
        'Else
        'Log("SiteMapExclude", 1000, Loc)
      End If
    End Sub

		Private Function ExcludeNotContains(ByVal Exclude As StringCollection, ByVal Url As String) As Boolean
			If Exclude IsNot Nothing Then
				For Each Link As String In Exclude
					If StrComp(Link, Url, CompareMethod.Text) = 0 Then
						Return False
					End If
				Next
			End If
			Return True
		End Function

		Enum ChangeFrequency
			Always
			Hourly
			Daily
			Weekly
			Monthly
			Yearly
			Never
		End Enum


	End Module
End Namespace

