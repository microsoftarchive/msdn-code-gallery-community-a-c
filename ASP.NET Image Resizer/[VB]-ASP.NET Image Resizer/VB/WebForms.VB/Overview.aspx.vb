Imports GleamTech.ImageUltimate

Public Class OverviewPage
    Inherits System.Web.UI.Page

	Protected ImagePath As String
	Protected ImageData As New Dictionary(Of String, Object)()
	Protected ImageExifMetadata As New Dictionary(Of String, Tuple(Of String, String))()
	Protected ImageIptcMetadata As New Dictionary(Of String, Tuple(Of String, String))()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		ImagePath = exampleFileSelector.SelectedFile

		Using imageInfo = New ImageInfo(ImagePath)
			ImageData.Add("Format", imageInfo.Format)
			ImageData.Add("Width", imageInfo.Width)
			ImageData.Add("Height", imageInfo.Height)
			ImageData.Add("DpiX", imageInfo.DpiX)
			ImageData.Add("DpiY", imageInfo.DpiY)
		    ImageData.Add("ColorSpace", imageInfo.ColorSpace)
		    ImageData.Add("ColorType", imageInfo.ColorType)
		    ImageData.Add("BitDepth", imageInfo.BitDepth)
		    ImageData.Add("HasAlpha", imageInfo.HasAlpha)
		    ImageData.Add("ChannelCount", imageInfo.ChannelCount)

			For Each entry In imageInfo.ExifDictionary
			    ImageExifMetadata.Add(entry.Tag.ToString(), Tuple.Create(entry.Value, entry.Description))
			Next

			If ImageExifMetadata.Count = 0 Then
				ImageExifMetadata.Add("", Tuple.Create("", ""))
			End If

			For Each entry In imageInfo.IptcDictionary
			    ImageIptcMetadata.Add(entry.Tag.ToString(), Tuple.Create(entry.Value, entry.Description))
			Next

			If ImageIptcMetadata.Count = 0 Then
				ImageIptcMetadata.Add("", Tuple.Create("", ""))
			End If
		End Using
    End Sub

End Class