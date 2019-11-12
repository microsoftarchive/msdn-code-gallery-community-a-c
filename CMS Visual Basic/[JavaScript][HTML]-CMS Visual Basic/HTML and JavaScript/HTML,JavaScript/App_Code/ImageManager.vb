'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Imaging
Namespace WebApplication

	Public Module ImageManager

		Public Sub Thumbnail(ByRef Image As System.Drawing.Image, Optional ByRef Size As Integer = 100)
			ImageResize(Image, Size)
		End Sub

		Public Sub ImageResize(ByRef Image As System.Drawing.Image, ByRef MexSize As Integer, Optional ByVal NotIncrease As Boolean = False)
			Dim Width, Height As Integer
			' Get width
			If Image.Width > Image.Height Then
				Width = MexSize
			Else
				Width = MexSize * Image.Width / Image.Height
			End If

			' Get height
			If Image.Height > Image.Width Then
				Height = MexSize
			Else
				Height = MexSize * Image.Height / Image.Width
			End If

			Dim NewImage As Drawing.Image
			If NotIncrease And (Width > Image.Width OrElse Height > Image.Height) Then
				'Return = Image
			Else
				NewImage = New Drawing.Bitmap(Image, CInt(Width), CInt(Height))
				Image.Dispose()
				Image = NewImage
			End If
		End Sub

		Public Sub ImageResize(ByRef Image As System.Drawing.Image, Width As Integer, Height As Integer, Optional ByVal NotIncrease As Boolean = False)
			Dim NewImage As Drawing.Image
			If NotIncrease And (Width > Image.Width OrElse Height > Image.Height) Then
				'Return = Image
			Else
				NewImage = New Drawing.Bitmap(Image, CInt(Width), CInt(Height))
				Image.Dispose()
				Image = NewImage
			End If
		End Sub

		Public Function ImageRotate(ByRef Image As Bitmap, ByRef Angle As Double, Optional Resize As Boolean = True) As Bitmap
			If Resize Then
				Dim BoxCorners As Point() = {New Point(0, 0), New Point(Image.Width, 0), New Point(Image.Width, Image.Height), New Point(0, Image.Height)}
				Dim M As New Drawing2D.Matrix

				M.RotateAt(Angle, New PointF(Image.Width / 2.0!, Image.Height / 2.0!))
				M.TransformPoints(BoxCorners)

				Dim Left, Right, Top, Bottom As Integer
				For i = 0 To UBound(BoxCorners)
					If BoxCorners(i).X < Left Then
						Left = BoxCorners(i).X
					ElseIf BoxCorners(i).X > Right Then
						Right = BoxCorners(i).X
					End If

					If BoxCorners(i).Y < Top Then
						Top = BoxCorners(i).Y
					ElseIf BoxCorners(i).Y > Bottom Then
						Bottom = BoxCorners(i).Y
					End If
				Next

				Dim RotatedBitmap = New Bitmap(Right - Left, Bottom - Top)
				Dim x As Integer = CInt(Math.Abs(RotatedBitmap.Width - Image.Width) / 2.0!)
				Dim y As Integer = CInt(Math.Abs(RotatedBitmap.Height - Image.Height) / 2.0!)
				Dim g As Graphics = Graphics.FromImage(RotatedBitmap)

				M.Reset()
				M.RotateAt(Angle, New PointF(RotatedBitmap.Width / 2.0!, RotatedBitmap.Height / 2.0!))
				g.Transform = M
				g.DrawImage(Image, New Rectangle(x, y, Image.Width, Image.Height))

				M.Dispose()
				g.Dispose()
				Image.Dispose()
				Return RotatedBitmap

			Else
				Dim Result As New Bitmap(Image.Width, Image.Height)
				Result.SetResolution(Result.HorizontalResolution, Result.VerticalResolution)
				Dim Graphics As Graphics = Graphics.FromImage(Result)
				Graphics.TranslateTransform(Image.Width / 2.0!, Image.Height / 2.0!)
				Graphics.RotateTransform(Angle)
				Graphics.TranslateTransform(-Image.Width / 2.0!, -Image.Height / 2.0!)
				Graphics.DrawImage(Image, New Point(0, 0))
				Graphics.Dispose()
				Image.Dispose()
				Return Result

			End If

    End Function

    Public Function ConvertAlCaponeTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {0.393F, 0.349F, 0.272F, 0.0F, 0.0F}, _
      New Single() {0.769F, 0.686F, 0.534F, 0.0F, 0.0F}, _
      New Single() {0.159F, 0.158F, 0.171F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

		Public Function ConvertBlackAndWhite(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {0.3F, 0.3F, 0.3F, 0.0F, 0.0F}, _
      New Single() {0.59F, 0.59F, 0.59F, 0.0F, 0.0F}, _
      New Single() {0.11F, 0.11F, 0.11F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
			Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
			Return ApplyColorMatrix(Image, ColorMatrix)
		End Function

    Public Function ConvertCoolTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {0.393F, 0.349F, 0.272F, 0.0F, 0.0F}, _
      New Single() {0.39F, 0.7F, 0, 0.0F, 0.0F}, _
      New Single() {0.3F, 0.3F, 0.3F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

    Public Function ConvertOzonoTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {1.0F, 9.0F, 9.0F, 0.0F, 0.0F}, _
      New Single() {0.59F, 0.5F, 0.5F, 0.0F, 0.0F}, _
      New Single() {0.41F, 0.41F, 0.5F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

    Public Function ConvertPolaroidTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {0.82F, 0.4F, 0.4F, 0.0F, 0.0F}, _
      New Single() {0.4F, 0.82F, 0.4F, 0.0F, 0.0F}, _
      New Single() {0.4F, 0.4F, 0.53F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

		Public Function ConvertSepiaTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {0.393F, 0.349F, 0.272F, 0.0F, 0.0F}, _
      New Single() {0.769F, 0.686F, 0.534F, 0.0F, 0.0F}, _
      New Single() {0.189F, 0.168F, 0.131F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
			Return ApplyColorMatrix(Image, ColorMatrix)
		End Function

    Public Function ConvertRayBanTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {1.0F, 0.2F, 0.2F, 0.0F, 0.0F}, _
      New Single() {0.0F, 1.0F, 0, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.1F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {-0.1F, -0.1F, -0.1F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

    Public Function ConvertTrendyTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {1.0F, 0.0F, 0.0F, 0.0F, 0.0F}, _
      New Single() {0.59F, 0.59F, 0.59F, 0.0F, 0.0F}, _
      New Single() {0.11F, 0.11F, 0.11F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.0F, 0.5F, 0.5F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

    Public Function ConvertVintageTone(Image As Drawing.Bitmap) As Drawing.Bitmap
      Dim ColorMatrixElements As Single()() = { _
      New Single() {0.8F, 0.2F, 0.3F, 0.0F, 0.0F}, _
      New Single() {0.3F, 1.0F, 0.2F, 0.0F, 0.0F}, _
      New Single() {0.1F, 0.0F, 0.7F, 0.0F, 0.0F}, _
      New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F}, _
      New Single() {0.1, 0.0F, 0.0F, 0.0F, 1.0F}}
      Dim ColorMatrix As New Drawing.Imaging.ColorMatrix(ColorMatrixElements)
      Return ApplyColorMatrix(Image, ColorMatrix)
    End Function

		Public Function ApplyColorMatrix(OriginalImage As Bitmap, ColorMatrix As Drawing.Imaging.ColorMatrix) As Bitmap
			Dim NewBitmap As New Bitmap(OriginalImage.Width, OriginalImage.Height)
			Using NewGraphics As Graphics = Graphics.FromImage(NewBitmap)
				Using Attributes As New ImageAttributes()
					Attributes.SetColorMatrix(ColorMatrix)
					NewGraphics.DrawImage(OriginalImage, New System.Drawing.Rectangle(0, 0, OriginalImage.Width, OriginalImage.Height), 0, 0, OriginalImage.Width, OriginalImage.Height, _
					 GraphicsUnit.Pixel, Attributes)
					NewGraphics.Dispose()
					Attributes.Dispose()
				End Using
			End Using
			OriginalImage.Dispose()
			Return NewBitmap
		End Function

    Public Function ApplyColorTone(Image As Image, ColorTone As ColorTone, Setting As SubSite) As Image
      If ColorTone <> ColorTone.None Then
        If ColorTone = ColorTone.Default Then
          ColorTone = Setting.Aspect.ImageRendering.ImageTone
        End If
        Select Case ColorTone
          Case ColorTone.AlCapone
            Image = ConvertAlCaponeTone(Image)
          Case ColorTone.Cool
            Image = ConvertCoolTone(Image)
          Case ColorTone.BlackAndWhite
            Image = ConvertBlackAndWhite(Image)
          Case ColorTone.Ozono
            Image = ConvertOzonoTone(Image)
          Case ColorTone.Polaroid
            Image = ConvertPolaroidTone(Image)
          Case ColorTone.RayBan
            Image = ConvertRayBanTone(Image)
          Case ColorTone.Sepia
            Image = ConvertSepiaTone(Image)
          Case ColorTone.Trendy
            Image = ConvertTrendyTone(Image)
          Case ColorTone.Vintage
            Image = ConvertVintageTone(Image)
        End Select
      End If
      Return Image
    End Function

    Public Function ApplyColorTone(Image As Image, Setting As SubSite) As Image
      Dim ColorTone As ColorTone = Setting.Aspect.ImageRendering.ImageTone
      Return ApplyColorTone(Image, ColorTone, Setting)
    End Function

    Enum ColorTone
      [Default]
      None
      AlCapone
      Cool
      BlackAndWhite
      Ozono
      Polaroid
      RayBan
      Sepia
      Trendy
      Vintage
    End Enum

	End Module
End Namespace


