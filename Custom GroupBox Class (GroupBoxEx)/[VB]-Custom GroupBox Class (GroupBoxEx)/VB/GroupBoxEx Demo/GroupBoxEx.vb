Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms

Public Class GroupBoxEx
    'Inherit the Properties, Methods, and Events from the GroupBox class
    Inherits GroupBox

    'Create the property backing fields
    Private _BackColorBrush As SolidBrush
    Private _PanelBrush As SolidBrush
    Private _PanelShape As PanelType = PanelType.Rounded
    Private _BorderPen As Pen
    Private _DrawBorder As Boolean = True
    Private _TextBrush As SolidBrush
    Private _TextBackBrush As SolidBrush
    Private _TextBorderPen As Pen
    Private _BackgroundImageBrush As TextureBrush
    Private _BackgroundPanelImage As Image

    'Create an Enum used for the PanelShape property
    Public Enum PanelType As Integer
        Squared = 0
        Rounded = 1
    End Enum

    'Set the Styles, pens, brushes, and properties used for the defaults when a new instance is created
    Public Sub New()
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.Size = New Size(180, 100)
        _BackColorBrush = New SolidBrush(Color.Transparent)
        _BorderPen = New Pen(Color.Black)
        _PanelBrush = New SolidBrush(MyBase.BackColor)
        _TextBrush = New SolidBrush(MyBase.ForeColor)
        _TextBackBrush = New SolidBrush(Color.White)
        _TextBorderPen = New Pen(Color.Black)
        MyBase.BackColor = Color.Transparent
    End Sub

    'Create the properties for the control

    <Category("Appearance"), Description("Gets or sets the Background image.")> _
    <Browsable(True)> _
    Public Property BackgroundPanelImage() As Image
        Get
            Return _BackgroundPanelImage
        End Get
        Set(ByVal value As Image)
            _BackgroundPanelImage = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets the color of the text.")> _
    <Browsable(True)> _
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.ForeColor = value
            _TextBrush.Color = value
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets the Background color.")> _
    <Browsable(True)> _
    Public Property GroupPanelColor() As Color
        Get
            Return _PanelBrush.Color
        End Get
        Set(ByVal value As Color)
            _PanelBrush.Color = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets the shape of the control.")> _
    <Browsable(True)> _
    Public Property GroupPanelShape() As PanelType
        Get
            Return _PanelShape
        End Get
        Set(ByVal value As PanelType)
            _PanelShape = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets if a border is drawn around the control.")> _
    <Browsable(True)> _
    Public Property DrawGroupBorder() As Boolean
        Get
            Return _DrawBorder
        End Get
        Set(ByVal value As Boolean)
            _DrawBorder = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets the color of the border.")> _
    <Browsable(True)> _
    Public Property GroupBorderColor() As Color
        Get
            Return _BorderPen.Color
        End Get
        Set(ByVal value As Color)
            _BorderPen.Color = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets the Background color of the text.")> _
    <Browsable(True)> _
    Public Property TextBackColor() As Color
        Get
            Return _TextBackBrush.Color
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _TextBackBrush.Color
                Throw New Exception("Color Transparent is not supported")
            End If
            _TextBackBrush.Color = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Gets or sets the color of the border around the text.")> _
    <Browsable(True)> _
    Public Property TextBorderColor() As Color
        Get
            Return _TextBorderPen.Color
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _TextBorderPen.Color
                Throw New Exception("Color Transparent is not supported")
            End If
            _TextBorderPen.Color = value
            Me.Refresh()
        End Set
    End Property

    'Used to paint the control according to how the properties are set
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        With e.Graphics
            .FillRectangle(_BackColorBrush, 0, 0, Me.Width, Me.Height)
            .SmoothingMode = SmoothingMode.AntiAlias
            Dim tw As Integer = CInt(.MeasureString(Me.Text, Me.Font).Width)
            Dim th As Integer = CInt(.MeasureString(Me.Text, Me.Font).Height)
            Dim rec As New Rectangle(0, CInt(th / 2), Me.Width - 1, Me.Height - 1 - CInt(th / 2))
            Using gp As New GraphicsPath
                If Me.GroupPanelShape = PanelType.Rounded Then
                    Dim rad As Integer = 14
                    gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90)
                    gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90)
                    gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90)
                    gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90)
                    gp.CloseFigure()
                Else
                    gp.AddRectangle(rec)
                End If

                .FillPath(_PanelBrush, gp)
                If Me.BackgroundPanelImage IsNot Nothing Then
                    DrawBackImage(e.Graphics, gp, CInt(th / 2))
                End If
                If Me.DrawGroupBorder Then .DrawPath(_BorderPen, gp)
            End Using
            If tw > 0 And th > 0 Then
                Dim trec As New Rectangle(7, 0, Me.Width - 15, th + 2)
                Using gp As New GraphicsPath
                    Dim rad As Integer = 6
                    gp.AddArc(trec.Right - (rad), trec.Y, rad, rad, 270, 90)
                    gp.AddArc(trec.Right - (rad), trec.Bottom - (rad), rad, rad, 0, 90)
                    gp.AddArc(trec.X, trec.Bottom - (rad), rad, rad, 90, 90)
                    gp.AddArc(trec.X, trec.Y, rad, rad, 180, 90)
                    gp.CloseFigure()
                    .FillPath(_TextBackBrush, gp)
                    .DrawPath(_TextBorderPen, gp)
                End Using
                Using sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisCharacter, .FormatFlags = StringFormatFlags.NoWrap}
                    .DrawString(Me.Text, Me.Font, _TextBrush, trec, sf)
                End Using
            End If
        End With
    End Sub

    'A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout
    Private Sub DrawBackImage(ByVal g As Graphics, ByVal grxpath As GraphicsPath, ByVal topoffset As Integer)
        Using bm As New Bitmap(Me.Width, Me.Height - topoffset)
            Using grx As Graphics = Graphics.FromImage(bm)
                If Me.BackgroundImageLayout = ImageLayout.None Then
                    grx.DrawImage(Me.BackgroundPanelImage, 0, 0, Me.BackgroundPanelImage.Width, Me.BackgroundPanelImage.Height)
                ElseIf Me.BackgroundImageLayout = ImageLayout.Tile Then
                    Dim tc As Integer = CInt(Math.Ceiling(bm.Width / Me.BackgroundPanelImage.Width))
                    Dim tr As Integer = CInt(Math.Ceiling(bm.Height / Me.BackgroundPanelImage.Height))
                    For y As Integer = 0 To tr - 1
                        For x As Integer = 0 To tc - 1
                            grx.DrawImage(Me.BackgroundPanelImage, (x * Me.BackgroundPanelImage.Width), (y * Me.BackgroundPanelImage.Height), Me.BackgroundPanelImage.Width, Me.BackgroundPanelImage.Height)
                        Next
                    Next
                ElseIf Me.BackgroundImageLayout = ImageLayout.Center Then
                    Dim xx As Integer = CInt((Me.Width / 2) - (Me.BackgroundPanelImage.Width / 2))
                    Dim yy As Integer = CInt(((Me.Height - topoffset) / 2) - (Me.BackgroundPanelImage.Height / 2))
                    grx.DrawImage(Me.BackgroundPanelImage, xx, yy, Me.BackgroundPanelImage.Width, Me.BackgroundPanelImage.Height)
                ElseIf Me.BackgroundImageLayout = ImageLayout.Stretch Then
                    grx.DrawImage(Me.BackgroundPanelImage, 0, 0, Me.Width, Me.Height - topoffset)
                ElseIf Me.BackgroundImageLayout = ImageLayout.Zoom Then
                    Dim meratio As Double = Me.Width / (Me.Height - topoffset)
                    Dim imgratio As Double = Me.BackgroundPanelImage.Width / Me.BackgroundPanelImage.Height
                    Dim imgrect As New Rectangle(0, 0, Me.Width, Me.Height - topoffset)
                    If imgratio > meratio Then
                        imgrect.Width = Me.Width
                        imgrect.Height = CInt(Me.Width / imgratio)
                    ElseIf imgratio < meratio Then
                        imgrect.Height = Me.Height - topoffset
                        imgrect.Width = CInt((Me.Height - topoffset) * imgratio)
                    End If
                    imgrect.X = CInt((Me.Width / 2) - (imgrect.Width / 2))
                    imgrect.Y = CInt(((Me.Height - topoffset) / 2) - (imgrect.Height / 2))
                    grx.DrawImage(Me.BackgroundPanelImage, imgrect)
                End If
            End Using
            Using tb As New TextureBrush(bm)
                If Me.BackgroundImageLayout <> ImageLayout.Tile Then tb.WrapMode = WrapMode.Clamp
                tb.TranslateTransform(0, topoffset)
                g.FillPath(tb, grxpath)
            End Using
        End Using
    End Sub

    'Used to force the control to repaint itself when the text is changed
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Me.Refresh()
    End Sub

    'Override the BackColor property and hide it from the user
    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <System.Obsolete("The BackColor property is not implemented.", True)> _
    Public Shadows Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            Throw New Exception("The BackColor property is not implemented.")
        End Set
    End Property

    'Override the BackgroundImage property and hide it from the user
    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <System.Obsolete("The BackgroundImage property is not implemented.", True)> _
    Public Shadows Property BackgroundImage() As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(ByVal value As Image)
            Throw New Exception("The BackgroundImage property is not implemented.")
        End Set
    End Property

    'Dispose of all brushes and pens used for the property backing fields
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        _BackColorBrush.Dispose()
        _BorderPen.Dispose()
        _PanelBrush.Dispose()
        _TextBrush.Dispose()
        _TextBackBrush.Dispose()
        _TextBorderPen.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
