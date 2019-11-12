Imports System.Drawing
Imports System.Windows.Forms

Public Class AnimatedButton
    Inherits Button

    Private Class Frame
        Public Sub New(ByVal FrameCount As Integer, ByVal CurrentFrame As Integer, ByVal FrameSize As Size, ByVal ImageStrip As Image)

            Me.FrameCount = FrameCount
            Me.CurrentFrame = CurrentFrame
            Me.FrameSize = FrameSize
            Me.ImageStrip = ImageStrip

        End Sub

        Public ImageStrip As Image
        Public FrameCount As Integer
        Public CurrentFrame As Integer
        Public FrameSize As Size

    End Class

    Private _IsMouseOver As Boolean = False

    Private MouseOverFrame As Frame

    Private Property IsMouseOver As Boolean

        Get

            Return _IsMouseOver

        End Get

        Set(value As Boolean)

            _IsMouseOver = value

            Refresh()

        End Set

    End Property

    Protected Overrides Sub OnMouseEnter(e As EventArgs)

        MyBase.OnMouseEnter(e)

        IsMouseOver = True

    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)

        MyBase.OnMouseLeave(e)

        IsMouseOver = False

    End Sub

    Private _IsMouseDown As Boolean = False

    Private Property IsMouseDown As Boolean

        Get

            Return _IsMouseDown

        End Get

        Set(value As Boolean)

            _IsMouseDown = value

            Refresh()

        End Set

    End Property

    Private MouseClickFrame As Frame

    Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)

        MyBase.OnMouseDown(mevent)

        IsMouseDown = True

    End Sub
    
    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)

        MyBase.OnMouseUp(mevent)

        IsMouseDown = False

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        DoubleBuffered = True

        MouseOverFrame = New Frame(25, 0, New Size(100, 30), My.Resources.ButtonMouseOver)
        MouseClickFrame = New Frame(25, 0, New Size(100, 30), My.Resources.ButtonMouseDown)

        Me.Size = MouseOverFrame.FrameSize

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here

        e.Graphics.Clear(BackColor)

        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

        If (Not IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseOverFrame.CurrentFrame = 0))) Then

            e.Graphics.DrawImage(MouseOverFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

        ElseIf (IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseOverFrame.CurrentFrame <> MouseOverFrame.FrameCount))) Then

            e.Graphics.DrawImage(MouseOverFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 New Rectangle(0, MouseOverFrame.CurrentFrame * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

            MouseOverFrame.CurrentFrame += 1

        ElseIf (IsMouseOver AndAlso (Not IsMouseDown AndAlso ((MouseOverFrame.CurrentFrame = MouseOverFrame.FrameCount) AndAlso (MouseClickFrame.CurrentFrame = 0)))) Then

            e.Graphics.DrawImage(MouseOverFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 New Rectangle(0, ((MouseOverFrame.CurrentFrame - 1) * MouseOverFrame.FrameSize.Height), MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

        ElseIf (IsMouseOver AndAlso (IsMouseDown AndAlso (MouseClickFrame.CurrentFrame <> MouseClickFrame.FrameCount))) Then

            e.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 New Rectangle(0, MouseClickFrame.CurrentFrame * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

            MouseClickFrame.CurrentFrame += 1

        ElseIf (IsMouseOver AndAlso (IsMouseDown AndAlso (MouseClickFrame.CurrentFrame = MouseClickFrame.FrameCount))) Then

            e.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 New Rectangle(0, ((MouseClickFrame.CurrentFrame - 1) * MouseClickFrame.FrameSize.Height), MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

        ElseIf (IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseClickFrame.CurrentFrame <> 0))) Then

            MouseClickFrame.CurrentFrame -= 1

            e.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 New Rectangle(0, MouseClickFrame.CurrentFrame * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)



        ElseIf (Not IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseOverFrame.CurrentFrame <> 0))) Then

            MouseOverFrame.CurrentFrame -= 1

            e.Graphics.DrawImage(MouseOverFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 New Rectangle(0, MouseOverFrame.CurrentFrame * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

        End If

        Using sf As New StringFormat

            sf.LineAlignment = StringAlignment.Center
            sf.Alignment = StringAlignment.Center

            e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), e.ClipRectangle, sf)

        End Using

    End Sub

    Private Sub _FPS_Tick(sender As Object, e As EventArgs) Handles _FPS.Tick

        Refresh()

    End Sub
End Class
