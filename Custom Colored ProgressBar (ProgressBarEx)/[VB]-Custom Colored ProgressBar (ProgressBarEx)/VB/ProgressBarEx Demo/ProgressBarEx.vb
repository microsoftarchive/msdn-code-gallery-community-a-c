Imports System.ComponentModel
'If you are using this code to build a Class Library Project instead of just adding it to a Form Project then you
'will need to add a reference to System.Drawing and System.Windows.Forms for the next three Imports. You can do
'that after you create the new Class Library by going to the VB menu and clicking (Project) and then selecting (Add Reference...).
'Then on the (.Net) tab you can find and select (System.Drawing) and (System.Windows.Forms) to add the references.
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ProgressBarEx
    Inherits Control

    Private bBlend As New Blend

    Private _Minimum As Integer = 0
    Private _Maximum As Integer = 100
    Private _Value As Integer = 0
    Private _Border As Boolean = True
    Private _BorderPen As Pen
    Private _BorderColor As Color = Color.Black
    Private _GradiantPosition As GradiantArea
    Private _GradiantColor As Color = Color.White
    Private _BackColor As Color = Color.DarkGray
    Private _ProgressColor As Color = Color.Lime
    Private _ForeColorBrush As SolidBrush
    Private _ShowPercentage As Boolean = False
    Private _ShowText As Boolean = False
    Private _ImageLayout As ImageLayoutType = ImageLayoutType.None
    Private _Image As Bitmap = Nothing
    Private _RoundedCorners As Boolean = True
    Private _ProgressDirection As ProgressDir = ProgressDir.Horizontal

    ''' <summary>Enum of positions used for the ProgressBar`s GradiantPosition property.</summary>
    Public Enum GradiantArea As Integer
        None = 0
        Top = 1
        Center = 2
        Bottom = 3
    End Enum

    ''' <summary>Enum of ImageLayout types used for the ProgressBar`s ImageLayout property.</summary>
    Public Enum ImageLayoutType As Integer
        None = 0
        Center = 1
        Stretch = 2
    End Enum

    ''' <summary>Enum of Progress Direction types used for the ProgressDirection property.</summary>
    Public Enum ProgressDir As Integer
        Horizontal = 0
        Vertical = 1
    End Enum

    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        MyBase.TabStop = False
        Me.Size = New Size(200, 23)
        bBlend.Positions = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
        Me.GradiantPosition = GradiantArea.Top
        MyBase.BackColor = Color.Transparent
        _ForeColorBrush = New SolidBrush(MyBase.ForeColor)
        _BorderPen = New Pen(Color.Black)
    End Sub

    <Category("Appearance"), Description("The foreground color of the ProgressBars text.")> _
    <Browsable(True)> _
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            If value = Color.Transparent Then
                value = _ForeColorBrush.Color
            End If
            MyBase.ForeColor = value
            _ForeColorBrush.Color = value
        End Set
    End Property

    <Category("Appearance"), Description("The background color of the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(GetType(Color), "DarkGray")> _
    Public Property BackgroundColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _BackColor
            End If
            _BackColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The progress color of the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(GetType(Color), "Lime")> _
    Public Property ProgressColor() As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _ProgressColor
            End If
            _ProgressColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The gradiant highlight color of the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(GetType(Color), "White")> _
    Public Property GradiantColor() As Color
        Get
            Return _GradiantColor
        End Get
        Set(ByVal value As Color)
            _GradiantColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Behavior"), Description("The minimum value of the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(0)> _
    Public Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value > _Maximum Then value = _Maximum - 1
            _Minimum = value
            Me.Refresh()
        End Set
    End Property

    <Category("Behavior"), Description("The maximum value of the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(100)> _
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value <= _Minimum Then value = _Minimum + 1
            _Maximum = value
            Me.Refresh()
        End Set
    End Property

    <Category("Behavior"), Description("The current value of the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(0)> _
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value < _Minimum Then value = _Minimum
            If value > _Maximum Then value = _Maximum
            _Value = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Draw a border around the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(True)> _
    Public Property Border() As Boolean
        Get
            Return _Border
        End Get
        Set(ByVal value As Boolean)
            _Border = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The color of the border around the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(GetType(Color), "Black")> _
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _BorderColor
            End If
            _BorderColor = value
            _BorderPen.Color = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Shows the progress percentge as text in the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(False)> _
    Public Property ShowPercentage() As Boolean
        Get
            Return _ShowPercentage
        End Get
        Set(ByVal value As Boolean)
            _ShowPercentage = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Shows the text of the Text property in the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(False)> _
    Public Property ShowText() As Boolean
        Get
            Return _ShowText
        End Get
        Set(ByVal value As Boolean)
            _ShowText = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Determins the position of the gradiant shine in the ProgressBar.")> _
    <Browsable(True)> <DefaultValue(GetType(GradiantArea), "Top")> _
    Public Property GradiantPosition() As GradiantArea
        Get
            Return _GradiantPosition
        End Get
        Set(ByVal value As GradiantArea)
            _GradiantPosition = value
            If value = GradiantArea.None Then
                bBlend.Factors = New Single() {0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F} 'Shine None
            ElseIf value = GradiantArea.Top Then
                bBlend.Factors = New Single() {0.8F, 0.7F, 0.6F, 0.4F, 0.0F, 0.0F} 'Shine Top
            ElseIf value = GradiantArea.Center Then
                bBlend.Factors = New Single() {0.0F, 0.4F, 0.6F, 0.6F, 0.4F, 0.0F} 'Shine Center
            Else
                bBlend.Factors = New Single() {0.0F, 0.0F, 0.4F, 0.6F, 0.7F, 0.8F} 'Shine Bottom
            End If
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("An image to display on the ProgressBarEx.")> _
    <Browsable(True)> _
    Public Property Image() As Bitmap
        Get
            Return _Image
        End Get
        Set(ByVal value As Bitmap)
            _Image = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Determins how the image is displayed in the ProgressBarEx.")> _
    <Browsable(True)> <DefaultValue(GetType(ImageLayoutType), "None")> _
    Public Property ImageLayout() As ImageLayoutType
        Get
            Return _ImageLayout
        End Get
        Set(ByVal value As ImageLayoutType)
            _ImageLayout = value
            If _Image IsNot Nothing Then Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("True to draw corners rounded. False to draw square corners.")> _
    <Browsable(True)> <DefaultValue(True)> _
    Public Property RoundedCorners() As Boolean
        Get
            Return _RoundedCorners
        End Get
        Set(ByVal value As Boolean)
            _RoundedCorners = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Determins the direction of progress displayed in the ProgressBarEx.")> _
    <Browsable(True)> <DefaultValue(GetType(ProgressDir), "Horizontal")> _
    Public Property ProgressDirection() As ProgressDir
        Get
            Return _ProgressDirection
        End Get
        Set(ByVal value As ProgressDir)
            _ProgressDirection = value
            Me.Refresh()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim StartPoint As New Point(0, 0)
        Dim EndPoint As New Point(0, Me.Height)

        If _ProgressDirection = ProgressDir.Vertical Then
            EndPoint = New Point(Me.Width, 0)
        End If

        Using gp As New GraphicsPath
            Dim rec As New Rectangle(0, 0, Me.Width, Me.Height)
            Dim rad As Integer = CInt(rec.Height / 2.5)
            If rec.Width < rec.Height Then rad = CInt(rec.Width / 2.5)

            Using _BackColorBrush As New LinearGradientBrush(StartPoint, EndPoint, _BackColor, _GradiantColor)
                _BackColorBrush.Blend = bBlend
                If _RoundedCorners Then
                    MakePath(gp, rec, rad)
                    e.Graphics.FillPath(_BackColorBrush, gp)
                Else
                    e.Graphics.FillRectangle(_BackColorBrush, rec)
                End If
            End Using

            If _Value > _Minimum Then
                Dim lngth As Integer = CInt((Me.Width / (_Maximum - _Minimum)) * _Value)
                If _ProgressDirection = ProgressDir.Vertical Then
                    lngth = CInt((Me.Height / (_Maximum - _Minimum)) * _Value)
                    rec.Y = rec.Height - lngth
                    rec.Height = lngth
                Else
                    rec.Width = lngth
                End If

                Using _ProgressBrush As New LinearGradientBrush(StartPoint, EndPoint, _ProgressColor, _GradiantColor)
                    _ProgressBrush.Blend = bBlend
                    If _RoundedCorners Then

                        If _ProgressDirection = ProgressDir.Horizontal Then
                            rec.Height -= 1
                        Else
                            rec.Width -= 1
                        End If

                        Using gp2 As New GraphicsPath
                            MakePath(gp2, rec, rad)
                            Using gp3 As New GraphicsPath
                                Using rgn As New Region(gp)
                                    rgn.Intersect(gp2)
                                    gp3.AddRectangles(rgn.GetRegionScans(New Matrix))
                                End Using
                                e.Graphics.FillPath(_ProgressBrush, gp3)
                            End Using
                        End Using
                    Else
                        e.Graphics.FillRectangle(_ProgressBrush, rec)
                    End If
                End Using
            End If

            If _Image IsNot Nothing Then
                If _ImageLayout = ImageLayoutType.Stretch Then
                    e.Graphics.DrawImage(_Image, 0, 0, Me.Width, Me.Height)
                ElseIf _ImageLayout = ImageLayoutType.None Then
                    e.Graphics.DrawImage(_Image, 0, 0)
                Else
                    Dim xx As Integer = CInt((Me.Width / 2) - (_Image.Width / 2))
                    Dim yy As Integer = CInt((Me.Height / 2) - (_Image.Height / 2))
                    e.Graphics.DrawImage(_Image, xx, yy)
                End If
            End If

            If _ShowPercentage Or _ShowText Then
                Dim perc As String = ""
                If _ShowText Then perc = Me.Text
                If _ShowPercentage Then perc &= CInt((100 / (_Maximum - _Minimum)) * _Value).ToString & "%"
                Using sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    e.Graphics.DrawString(perc, Me.Font, _ForeColorBrush, New Rectangle(0, 0, Me.Width, Me.Height), sf)
                End Using
            End If

            If _Border Then
                rec = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
                If _RoundedCorners Then
                    MakePath(gp, rec, rad)
                    e.Graphics.DrawPath(_BorderPen, gp)
                Else
                    e.Graphics.DrawRectangle(_BorderPen, rec)
                End If
            End If
        End Using
    End Sub

    Private Sub MakePath(ByRef pth As GraphicsPath, ByVal rc As Rectangle, ByVal rad As Integer)
        pth.Reset()
        pth.AddArc(rc.X, rc.Y, rad, rad, 180, 90)
        pth.AddArc(rc.Right - (rad), rc.Y, rad, rad, 270, 90)
        pth.AddArc(rc.Right - (rad), rc.Bottom - (rad), rad, rad, 0, 90)
        pth.AddArc(rc.X, rc.Bottom - (rad), rad, rad, 90, 90)
        pth.CloseFigure()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        Me.Refresh()
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        _ForeColorBrush.Dispose()
        _BorderPen.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = Color.Transparent
        End Set
    End Property

    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <System.Obsolete("BackgroundImageLayout is not implemented.", True)> _
    Public Shadows Property BackgroundImageLayout() As ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(ByVal value As ImageLayout)
            Throw New NotImplementedException("BackgroundImageLayout is not implemented.")
        End Set
    End Property

    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <System.Obsolete("BackgroundImage is not implemented.", True)> _
    Public Shadows Property BackgroundImage() As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
            Throw New NotImplementedException("BackgroundImage is not implemented.")
        End Set
    End Property

    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <System.Obsolete("TabStop is not implemented.", True)> _
    Public Shadows Property TabStop() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            Throw New NotImplementedException("TabStop is not implemented.")
        End Set
    End Property

    <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <System.Obsolete("TabIndex is not implemented.", True)> _
    Public Shadows Property TabIndex() As Integer
        Get
            Return MyBase.TabIndex
        End Get
        Set(ByVal value As Integer)
            Throw New NotImplementedException("TabIndex is not implemented.")
        End Set
    End Property
End Class
