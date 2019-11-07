# Custom Colored ProgressBar (ProgressBarEx)
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Controls
- Graphics
- C#
- Class Library
- custom controls
- Visual Basic .NET
- VB.Net
- Inheritance
- Classes
- Graphics Functions
- vb2008
- Visual C#
- System.Drawing.Drawing2D
- Class Inheritance
## Topics
- Controls
- Graphics
- C#
- Class Library
- custom controls
- Visual Basic .NET
- VB.Net
- Inheritance
- Drawing
- Classes
- Graphics Functions
- Visual C#
- System.Drawing.Drawing2D
- Class Inheritance
## Updated
- 04/18/2015
## Description

<h1>Introduction</h1>
<p><span style="font-size:small"><em>&nbsp; Have you ever wanted to change the colors of a ProgressBar to match your applications colors only to find that the only way is to turn off visual styles which makes all of your controls look bad. If so then try adding
 a ProgressBarEx to your app or to your Toolbox. Here is an image of the demo project form that shows some of the looks you can make using the ProgressBarEx control.</em></span></p>
<p><span style="font-size:small"><em><img id="136605" src="136605-progressbarex%20demo%20form.png" alt="" width="460" height="301"></em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em><img id="136606" src="136606-progressbarex%20example.gif" alt="" width="208" height="35"></em></span></p>
<h1><strong>Update<em>&nbsp;</em></strong></h1>
<p><strong><span style="font-size:small">Updated on 4/18/15</span><em>&nbsp;</em></strong></p>
<p><span style="font-size:small">Added 3 new properties (</span><span style="font-size:small">RoundedCorners, ProgressDirection, and GradientColor) to allow you to have squared or rounded corners, show progress horizontally or vertically, and to change the
 gradiant highlight color.</span><strong><em><br>
</em></strong></p>
<h1><span>Building the Sample</span></h1>
<p><em><span style="font-size:small">Built with VS2008 targeting .Net 3.5 Framework</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><br>
&nbsp;<span style="font-size:small">With the ProgressBarEx control i started by inheriting &quot;Control&quot; as the base class and added the properties that a standard ProgressBar has plus the properties i wanted for other aspects of it such as:</span></p>
<p><span style="font-size:small">&nbsp;The color of the progress bar, the background color, the border and its color, the text and its color, for adding an image, and for controling the position of the gradiant shine.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small">&nbsp; As with all of my custom controls i have included a pre-built Class Library project in a folder named ProgressBarEx that is located inside the ProgressBarEx Demo folder. You can use the dll file in the Release folder
 so that you can just add the ProgressBarEx.dll to your Toolbox. That way you can add one or more to any Form project that you want by simply dragging one or more onto the form. However, you can build the Class Library yourself or just add a class to your project
 and copy the code below.</span></p>
<p><span style="font-size:small">&nbsp;If you build a Class Library project yourself and just copy the code below then you will need to add 2 references to the project. I explain at the top of the code how and which references you need to add.<br>
</span></p>
<p><span style="font-size:small">You can follow these steps to add the control to your toolbox.</span><br>
<em>&nbsp;&nbsp;</em></p>
<ol>
<li><span style="font-size:small">Open Visual Studio</span> </li><li><span style="font-size:small">On the menu click (Tools) and select (Choose Toolbox Items)</span>
</li><li><span style="font-size:small">When the dialog window opens click (Browse)</span>
</li><li><span style="font-size:small">&nbsp;Browse to the ProgressBarEx.dll file in the Release folder in the ProgressBarEx folder or if you built the library yourself then browse to the dll file you built.</span>
</li><li><span style="font-size:small">Double click on it or select it and press (Ok).</span>
</li></ol>
<p><span style="font-size:small">Now you will find the ProgressBarEx control in your Toolbox.</span></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports System.ComponentModel
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

    ''' &lt;summary&gt;Enum of positions used for the ProgressBar`s GradiantPosition property.&lt;/summary&gt;
    Public Enum GradiantArea As Integer
        None = 0
        Top = 1
        Center = 2
        Bottom = 3
    End Enum

    ''' &lt;summary&gt;Enum of ImageLayout types used for the ProgressBar`s ImageLayout property.&lt;/summary&gt;
    Public Enum ImageLayoutType As Integer
        None = 0
        Center = 1
        Stretch = 2
    End Enum

    ''' &lt;summary&gt;Enum of Progress Direction types used for the ProgressDirection property.&lt;/summary&gt;
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

    &lt;Category(&quot;Appearance&quot;), Description(&quot;The foreground color of the ProgressBars text.&quot;)&gt; _
    &lt;Browsable(True)&gt; _
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

    &lt;Category(&quot;Appearance&quot;), Description(&quot;The background color of the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(Color), &quot;DarkGray&quot;)&gt; _
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

    &lt;Category(&quot;Appearance&quot;), Description(&quot;The progress color of the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(Color), &quot;Lime&quot;)&gt; _
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

    &lt;Category(&quot;Appearance&quot;), Description(&quot;The gradiant highlight color of the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(Color), &quot;White&quot;)&gt; _
    Public Property GradiantColor() As Color
        Get
            Return _GradiantColor
        End Get
        Set(ByVal value As Color)
            _GradiantColor = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Behavior&quot;), Description(&quot;The minimum value of the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(0)&gt; _
    Public Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value &gt; _Maximum Then value = _Maximum - 1
            _Minimum = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Behavior&quot;), Description(&quot;The maximum value of the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(100)&gt; _
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value &lt;= _Minimum Then value = _Minimum &#43; 1
            _Maximum = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Behavior&quot;), Description(&quot;The current value of the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(0)&gt; _
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value &lt; _Minimum Then value = _Minimum
            If value &gt; _Maximum Then value = _Maximum
            _Value = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;Draw a border around the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(True)&gt; _
    Public Property Border() As Boolean
        Get
            Return _Border
        End Get
        Set(ByVal value As Boolean)
            _Border = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;The color of the border around the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(Color), &quot;Black&quot;)&gt; _
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

    &lt;Category(&quot;Appearance&quot;), Description(&quot;Shows the progress percentge as text in the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(False)&gt; _
    Public Property ShowPercentage() As Boolean
        Get
            Return _ShowPercentage
        End Get
        Set(ByVal value As Boolean)
            _ShowPercentage = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;Shows the text of the Text property in the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(False)&gt; _
    Public Property ShowText() As Boolean
        Get
            Return _ShowText
        End Get
        Set(ByVal value As Boolean)
            _ShowText = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;Determins the position of the gradiant shine in the ProgressBar.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(GradiantArea), &quot;Top&quot;)&gt; _
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

    &lt;Category(&quot;Appearance&quot;), Description(&quot;An image to display on the ProgressBarEx.&quot;)&gt; _
    &lt;Browsable(True)&gt; _
    Public Property Image() As Bitmap
        Get
            Return _Image
        End Get
        Set(ByVal value As Bitmap)
            _Image = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;Determins how the image is displayed in the ProgressBarEx.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(ImageLayoutType), &quot;None&quot;)&gt; _
    Public Property ImageLayout() As ImageLayoutType
        Get
            Return _ImageLayout
        End Get
        Set(ByVal value As ImageLayoutType)
            _ImageLayout = value
            If _Image IsNot Nothing Then Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;True to draw corners rounded. False to draw square corners.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(True)&gt; _
    Public Property RoundedCorners() As Boolean
        Get
            Return _RoundedCorners
        End Get
        Set(ByVal value As Boolean)
            _RoundedCorners = value
            Me.Refresh()
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;), Description(&quot;Determins the direction of progress displayed in the ProgressBarEx.&quot;)&gt; _
    &lt;Browsable(True)&gt; &lt;DefaultValue(GetType(ProgressDir), &quot;Horizontal&quot;)&gt; _
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
            If rec.Width &lt; rec.Height Then rad = CInt(rec.Width / 2.5)

            Using _BackColorBrush As New LinearGradientBrush(StartPoint, EndPoint, _BackColor, _GradiantColor)
                _BackColorBrush.Blend = bBlend
                If _RoundedCorners Then
                    MakePath(gp, rec, rad)
                    e.Graphics.FillPath(_BackColorBrush, gp)
                Else
                    e.Graphics.FillRectangle(_BackColorBrush, rec)
                End If
            End Using

            If _Value &gt; _Minimum Then
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
                Dim perc As String = &quot;&quot;
                If _ShowText Then perc = Me.Text
                If _ShowPercentage Then perc &amp;= CInt((100 / (_Maximum - _Minimum)) * _Value).ToString &amp; &quot;%&quot;
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

    &lt;Browsable(False), EditorBrowsable(EditorBrowsableState.Never)&gt; _
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = Color.Transparent
        End Set
    End Property

    &lt;Browsable(False)&gt; &lt;EditorBrowsable(EditorBrowsableState.Never)&gt; _
    &lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt; _
    &lt;System.Obsolete(&quot;BackgroundImageLayout is not implemented.&quot;, True)&gt; _
    Public Shadows Property BackgroundImageLayout() As ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(ByVal value As ImageLayout)
            Throw New NotImplementedException(&quot;BackgroundImageLayout is not implemented.&quot;)
        End Set
    End Property

    &lt;Browsable(False)&gt; &lt;EditorBrowsable(EditorBrowsableState.Never)&gt; _
    &lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt; _
    &lt;System.Obsolete(&quot;BackgroundImage is not implemented.&quot;, True)&gt; _
    Public Shadows Property BackgroundImage() As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
            Throw New NotImplementedException(&quot;BackgroundImage is not implemented.&quot;)
        End Set
    End Property

    &lt;Browsable(False)&gt; &lt;EditorBrowsable(EditorBrowsableState.Never)&gt; _
    &lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt; _
    &lt;System.Obsolete(&quot;TabStop is not implemented.&quot;, True)&gt; _
    Public Shadows Property TabStop() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            Throw New NotImplementedException(&quot;TabStop is not implemented.&quot;)
        End Set
    End Property

    &lt;Browsable(False)&gt; &lt;EditorBrowsable(EditorBrowsableState.Never)&gt; _
    &lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt; _
    &lt;System.Obsolete(&quot;TabIndex is not implemented.&quot;, True)&gt; _
    Public Shadows Property TabIndex() As Integer
        Get
            Return MyBase.TabIndex
        End Get
        Set(ByVal value As Integer)
            Throw New NotImplementedException(&quot;TabIndex is not implemented.&quot;)
        End Set
    End Property
End Class
</pre>
<pre class="hidden">using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
//If you are using this code to build a Class Library Project instead of just adding it to a Form Project then you
//will need to add a reference to System.Drawing and System.Windows.Forms for the next three Imports. You can do
//that after you create the new Class Library by going to the VB menu and clicking (Project) and then selecting (Add Reference...).
//Then on the (.Net) tab you can find and select (System.Drawing) and (System.Windows.Forms) to add the references.
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProgressBarEx
{
    public class ProgressBarEx : Control
    {
        private Blend bBlend = new Blend();
        private int _Minimum = 0;
        private int _Maximum = 100;
        private int _Value = 0;
        private bool _Border = true;
        private Pen _BorderPen;
        private Color _BorderColor = Color.Black;
        private GradiantArea _GradiantPosition;
        private Color _GradiantColor = Color.White;
        private Color _BackColor = Color.DarkGray;
        private Color _ProgressColor = Color.Lime;
        private SolidBrush _ForeColorBrush;
        private bool _ShowPercentage = false;
        private bool _ShowText = false;
        private ImageLayoutType _ImageLayout = ImageLayoutType.None;
        private Bitmap _Image = null;
        private bool _RoundedCorners = true;
        private ProgressDir _ProgressDirection = ProgressDir.Horizontal;

        /// &lt;summary&gt;Enum of positions used for the ProgressBar`s GradiantPosition property.&lt;/summary&gt;
        public enum GradiantArea : int
        {
            None = 0,
            Top = 1,
            Center = 2,
            Bottom = 3
        }

        /// &lt;summary&gt;Enum of ImageLayout types used for the ProgressBar`s ImageLayout property.&lt;/summary&gt;
        public enum ImageLayoutType : int
        {
            None = 0,
            Center = 1,
            Stretch = 2
        }

        /// &lt;summary&gt;Enum of Progress Direction types used for the ProgressDirection property.&lt;/summary&gt;
        public enum ProgressDir : int
        {
            Horizontal = 0,
            Vertical = 1
        }

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            base.TabStop = false;
            this.Size = new Size(200, 23);
            bBlend.Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
            this.GradiantPosition = GradiantArea.Top;
            base.BackColor = Color.Transparent;
            _ForeColorBrush = new SolidBrush(base.ForeColor);
            _BorderPen = new Pen(Color.Black);
        }

        [Category(&quot;Appearance&quot;), Description(&quot;The foreground color of the ProgressBars text.&quot;)]
        [Browsable(true)]
        public override System.Drawing.Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ForeColorBrush.Color;
                }
                base.ForeColor = value;
                _ForeColorBrush.Color = value;
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;The background color of the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(Color), &quot;DarkGray&quot;)]
        public Color BackgroundColor
        {
            get { return _BackColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BackColor;
                }
                _BackColor = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;The progress color of the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(Color), &quot;Lime&quot;)]
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ProgressColor;
                }
                _ProgressColor = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;The gradiant highlight color of the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(Color), &quot;White&quot;)]
        public Color GradiantColor
        {
            get { return _GradiantColor; }
            set
            {
                _GradiantColor = value;
                this.Refresh();
            }
        }

        [Category(&quot;Behavior&quot;), Description(&quot;The minimum value of the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value &gt; _Maximum)
                    value = _Maximum - 1;
                _Minimum = value;
                this.Refresh();
            }
        }

        [Category(&quot;Behavior&quot;), Description(&quot;The maximum value of the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value &lt;= _Minimum)
                    value = _Minimum &#43; 1;
                _Maximum = value;
                this.Refresh();
            }
        }

        [Category(&quot;Behavior&quot;), Description(&quot;The current value of the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(0)]
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value &lt; _Minimum)
                    value = _Minimum;
                if (value &gt; _Maximum)
                    value = _Maximum;
                _Value = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;Draw a border around the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool Border
        {
            get { return _Border; }
            set
            {
                _Border = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;The color of the border around the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(Color), &quot;Black&quot;)]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BorderColor;
                }
                _BorderColor = value;
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;Shows the progress percentge as text in the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;Shows the text of the Text property in the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowText
        {
            get { return _ShowText; }
            set
            {
                _ShowText = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;Determins the position of the gradiant shine in the ProgressBar.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(GradiantArea), &quot;Top&quot;)]
        public GradiantArea GradiantPosition
        {
            get { return _GradiantPosition; }
            set
            {
                _GradiantPosition = value;
                if (value == GradiantArea.None)
                {
                    bBlend.Factors = new float[] { 0f, 0f, 0f, 0f, 0f, 0f }; //Shine None
                }
                else if (value == GradiantArea.Top)
                {
                    bBlend.Factors = new float[] { 0.8f, 0.7f, 0.6f, 0.4f, 0f, 0f }; //Shine Top
                }
                else if (value == GradiantArea.Center)
                {
                    bBlend.Factors = new float[] { 0f, 0.4f, 0.6f, 0.6f, 0.4f, 0f }; //Shine Center
                }
                else
                {
                    bBlend.Factors = new float[] { 0f, 0f, 0.4f, 0.6f, 0.7f, 0.8f }; //Shine Bottom
                }
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;An image to display on the ProgressBarEx.&quot;)]
        [Browsable(true)]
        public Bitmap Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;Determins how the image is displayed in the ProgressBarEx.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(ImageLayoutType), &quot;None&quot;)]
        public ImageLayoutType ImageLayout
        {
            get { return _ImageLayout; }
            set
            {
                _ImageLayout = value;
                if (_Image != null)
                    this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;True to draw corners rounded. False to draw square corners.&quot;)]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool RoundedCorners
        {
            get { return _RoundedCorners; }
            set
            {
                _RoundedCorners = value;
                this.Refresh();
            }
        }

        [Category(&quot;Appearance&quot;), Description(&quot;Determins the direction of progress displayed in the ProgressBarEx.&quot;)]
        [Browsable(true)]
        [DefaultValue(typeof(ProgressDir), &quot;Horizontal&quot;)]
        public ProgressDir ProgressDirection
        {
            get { return _ProgressDirection; }
            set
            {
                _ProgressDirection = value;
                this.Refresh();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point StartPoint = new Point(0, 0);
            Point EndPoint = new Point(0, this.Height);

            if (_ProgressDirection == ProgressDir.Vertical)
            {
                EndPoint = new Point(this.Width, 0);
            }

            using (GraphicsPath gp = new GraphicsPath())
            {
                Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
                int rad = Convert.ToInt32(rec.Height / 2.5);
                if (rec.Width &lt; rec.Height)
                    rad = Convert.ToInt32(rec.Width / 2.5);

                using (LinearGradientBrush _BackColorBrush = new LinearGradientBrush(StartPoint, EndPoint, _BackColor, _GradiantColor))
                {
                    _BackColorBrush.Blend = bBlend;
                    if (_RoundedCorners)
                    {
                        gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                        gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                        gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                        gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                        gp.CloseFigure();
                        e.Graphics.FillPath(_BackColorBrush, gp);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(_BackColorBrush, rec);
                    }
                }

                if (_Value &gt; _Minimum)
                {
                    int lngth = Convert.ToInt32((double)(this.Width / (double)(_Maximum - _Minimum)) * _Value);
                    if (_ProgressDirection == ProgressDir.Vertical)
                    {
                        lngth = Convert.ToInt32((double)(this.Height / (double)(_Maximum - _Minimum)) * _Value);
                        rec.Y = rec.Height - lngth;
                        rec.Height = lngth;
                    }
                    else
                    {
                        rec.Width = lngth;
                    }

                    using (LinearGradientBrush _ProgressBrush = new LinearGradientBrush(StartPoint, EndPoint, _ProgressColor, _GradiantColor))
                    {
                        _ProgressBrush.Blend = bBlend;
                        if (_RoundedCorners)
                        {
                            if (_ProgressDirection == ProgressDir.Horizontal)
                            {
                                rec.Height -= 1;
                            }
                            else
                            {
                                rec.Width -= 1;
                            }

                            using (GraphicsPath gp2 = new GraphicsPath())
                            {
                                gp2.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                                gp2.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                                gp2.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                                gp2.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                                gp2.CloseFigure();
                                using (GraphicsPath gp3 = new GraphicsPath())
                                {
                                    using (Region rgn = new Region(gp))
                                    {
                                        rgn.Intersect(gp2);
                                        gp3.AddRectangles(rgn.GetRegionScans(new Matrix()));
                                    }
                                    e.Graphics.FillPath(_ProgressBrush, gp3);
                                }
                            }
                        }
                        else
                        {
                            e.Graphics.FillRectangle(_ProgressBrush, rec);
                        }
                    }
                }

                if (_Image != null)
                {
                    if (_ImageLayout == ImageLayoutType.Stretch)
                    {
                        e.Graphics.DrawImage(_Image, 0, 0, this.Width, this.Height);
                    }
                    else if (_ImageLayout == ImageLayoutType.None)
                    {
                        e.Graphics.DrawImage(_Image, 0, 0);
                    }
                    else
                    {
                        int xx = Convert.ToInt32((this.Width / 2) - (_Image.Width / 2));
                        int yy = Convert.ToInt32((this.Height / 2) - (_Image.Height / 2));
                        e.Graphics.DrawImage(_Image, xx, yy);
                    }
                }

                if (_ShowPercentage | _ShowText)
                {
                    string perc = &quot;&quot;;
                    if (_ShowText)
                        perc = this.Text;
                    if (_ShowPercentage)
                        perc &#43;= Convert.ToString(Convert.ToInt32(((double)100 / (double)(_Maximum - _Minimum)) * _Value)) &#43; &quot;%&quot;;
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(perc, this.Font, _ForeColorBrush, new Rectangle(0, 0, this.Width, this.Height), sf);
                    }
                }

                if (_Border)
                {
                    rec = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                    if (_RoundedCorners)
                    {
                        gp.Reset();
                        gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                        gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                        gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                        gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                        gp.CloseFigure();
                        e.Graphics.DrawPath(_BorderPen, gp);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(_BorderPen, rec);
                    }
                }
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            this.Refresh();
            base.OnTextChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            _ForeColorBrush.Dispose();
            _BorderPen.Dispose();
            base.Dispose(disposing);
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override System.Drawing.Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = Color.Transparent; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete(&quot;BackgroundImageLayout is not implemented.&quot;, true)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set
            {
                throw new NotImplementedException(&quot;BackgroundImageLayout is not implemented.&quot;);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete(&quot;BackgroundImage is not implemented.&quot;, true)]
        public new Image BackgroundImage
        {
            get { return null; }
            set
            {
                throw new NotImplementedException(&quot;BackgroundImage is not implemented.&quot;);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete(&quot;TabStop is not implemented.&quot;, true)]
        public new bool TabStop
        {
            get { return false; }
            set
            {
                throw new NotImplementedException(&quot;TabStop is not implemented.&quot;);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete(&quot;TabIndex is not implemented.&quot;, true)]
        public new int TabIndex
        {
            get { return base.TabIndex; }
            set
            {
                throw new NotImplementedException(&quot;TabIndex is not implemented.&quot;);
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.ComponentModel&nbsp;
<span class="visualBasic__com">'If&nbsp;you&nbsp;are&nbsp;using&nbsp;this&nbsp;code&nbsp;to&nbsp;build&nbsp;a&nbsp;Class&nbsp;Library&nbsp;Project&nbsp;instead&nbsp;of&nbsp;just&nbsp;adding&nbsp;it&nbsp;to&nbsp;a&nbsp;Form&nbsp;Project&nbsp;then&nbsp;you</span>&nbsp;
<span class="visualBasic__com">'will&nbsp;need&nbsp;to&nbsp;add&nbsp;a&nbsp;reference&nbsp;to&nbsp;System.Drawing&nbsp;and&nbsp;System.Windows.Forms&nbsp;for&nbsp;the&nbsp;next&nbsp;three&nbsp;Imports.&nbsp;You&nbsp;can&nbsp;do</span>&nbsp;
<span class="visualBasic__com">'that&nbsp;after&nbsp;you&nbsp;create&nbsp;the&nbsp;new&nbsp;Class&nbsp;Library&nbsp;by&nbsp;going&nbsp;to&nbsp;the&nbsp;VB&nbsp;menu&nbsp;and&nbsp;clicking&nbsp;(Project)&nbsp;and&nbsp;then&nbsp;selecting&nbsp;(Add&nbsp;Reference...).</span>&nbsp;
<span class="visualBasic__com">'Then&nbsp;on&nbsp;the&nbsp;(.Net)&nbsp;tab&nbsp;you&nbsp;can&nbsp;find&nbsp;and&nbsp;select&nbsp;(System.Drawing)&nbsp;and&nbsp;(System.Windows.Forms)&nbsp;to&nbsp;add&nbsp;the&nbsp;references.</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing.Drawing2D&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows.Forms&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;ProgressBarEx&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Control&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;bBlend&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Blend&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_Minimum&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_Maximum&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">100</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_Value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_Border&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BorderPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BorderColor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;=&nbsp;Color.Black&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_GradiantPosition&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GradiantArea&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_GradiantColor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;=&nbsp;Color.White&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BackColor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;=&nbsp;Color.DarkGray&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ProgressColor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;=&nbsp;Color.Lime&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ForeColorBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidBrush&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShowPercentage&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShowText&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ImageLayout&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ImageLayoutType&nbsp;=&nbsp;ImageLayoutType.None&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_Image&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_RoundedCorners&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ProgressDirection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ProgressDir&nbsp;=&nbsp;ProgressDir.Horizontal&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;positions&nbsp;used&nbsp;for&nbsp;the&nbsp;ProgressBar`s&nbsp;GradiantPosition&nbsp;property.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;GradiantArea&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;None&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Top&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Center&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bottom&nbsp;=&nbsp;<span class="visualBasic__number">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;ImageLayout&nbsp;types&nbsp;used&nbsp;for&nbsp;the&nbsp;ProgressBar`s&nbsp;ImageLayout&nbsp;property.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;ImageLayoutType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;None&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Center&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stretch&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;Progress&nbsp;Direction&nbsp;types&nbsp;used&nbsp;for&nbsp;the&nbsp;ProgressDirection&nbsp;property.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;ProgressDir&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Horizontal&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vertical&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.OptimizedDoubleBuffer&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;ControlStyles.SupportsTransparentBackColor,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.TabStop&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">200</span>,&nbsp;<span class="visualBasic__number">23</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bBlend.Positions&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Single</span>()&nbsp;{<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.2F,&nbsp;<span class="visualBasic__number">0</span>.4F,&nbsp;<span class="visualBasic__number">0</span>.6F,&nbsp;<span class="visualBasic__number">0</span>.8F,&nbsp;<span class="visualBasic__number">1</span>.0F}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.GradiantPosition&nbsp;=&nbsp;GradiantArea.Top&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;=&nbsp;Color.Transparent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ForeColorBrush&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(<span class="visualBasic__keyword">MyBase</span>.ForeColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;foreground&nbsp;color&nbsp;of&nbsp;the&nbsp;ProgressBars&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ForeColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Drawing.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.ForeColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Drawing.Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_ForeColorBrush.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.ForeColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ForeColorBrush.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;background&nbsp;color&nbsp;of&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;DarkGray&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackgroundColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_BackColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_BackColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BackColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;progress&nbsp;color&nbsp;of&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;Lime&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ProgressColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ProgressColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_ProgressColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ProgressColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;gradiant&nbsp;highlight&nbsp;color&nbsp;of&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;White&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;GradiantColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_GradiantColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_GradiantColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Behavior&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;minimum&nbsp;value&nbsp;of&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__number">0</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Minimum()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_Minimum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&gt;&nbsp;_Maximum&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;_Maximum&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Minimum&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Behavior&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;maximum&nbsp;value&nbsp;of&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__number">100</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Maximum()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_Maximum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&lt;=&nbsp;_Minimum&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;_Minimum&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Maximum&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Behavior&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;current&nbsp;value&nbsp;of&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__number">0</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Value()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&lt;&nbsp;_Minimum&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;_Minimum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&gt;&nbsp;_Maximum&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;_Maximum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Value&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Draw&nbsp;a&nbsp;border&nbsp;around&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Border()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_Border&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Border&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;color&nbsp;of&nbsp;the&nbsp;border&nbsp;around&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;Black&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BorderColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_BorderColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_BorderColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Shows&nbsp;the&nbsp;progress&nbsp;percentge&nbsp;as&nbsp;text&nbsp;in&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowPercentage()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShowPercentage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShowPercentage&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Shows&nbsp;the&nbsp;text&nbsp;of&nbsp;the&nbsp;Text&nbsp;property&nbsp;in&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowText()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShowText&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShowText&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Determins&nbsp;the&nbsp;position&nbsp;of&nbsp;the&nbsp;gradiant&nbsp;shine&nbsp;in&nbsp;the&nbsp;ProgressBar.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(GradiantArea),&nbsp;<span class="visualBasic__string">&quot;Top&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;GradiantPosition()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GradiantArea&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_GradiantPosition&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GradiantArea)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_GradiantPosition&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;GradiantArea.None&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bBlend.Factors&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Single</span>()&nbsp;{<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F}&nbsp;<span class="visualBasic__com">'Shine&nbsp;None</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;value&nbsp;=&nbsp;GradiantArea.Top&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bBlend.Factors&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Single</span>()&nbsp;{<span class="visualBasic__number">0</span>.8F,&nbsp;<span class="visualBasic__number">0</span>.7F,&nbsp;<span class="visualBasic__number">0</span>.6F,&nbsp;<span class="visualBasic__number">0</span>.4F,&nbsp;<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F}&nbsp;<span class="visualBasic__com">'Shine&nbsp;Top</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;value&nbsp;=&nbsp;GradiantArea.Center&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bBlend.Factors&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Single</span>()&nbsp;{<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.4F,&nbsp;<span class="visualBasic__number">0</span>.6F,&nbsp;<span class="visualBasic__number">0</span>.6F,&nbsp;<span class="visualBasic__number">0</span>.4F,&nbsp;<span class="visualBasic__number">0</span>.0F}&nbsp;<span class="visualBasic__com">'Shine&nbsp;Center</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bBlend.Factors&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Single</span>()&nbsp;{<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.0F,&nbsp;<span class="visualBasic__number">0</span>.4F,&nbsp;<span class="visualBasic__number">0</span>.6F,&nbsp;<span class="visualBasic__number">0</span>.7F,&nbsp;<span class="visualBasic__number">0</span>.8F}&nbsp;<span class="visualBasic__com">'Shine&nbsp;Bottom</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;An&nbsp;image&nbsp;to&nbsp;display&nbsp;on&nbsp;the&nbsp;ProgressBarEx.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Image()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Image&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Determins&nbsp;how&nbsp;the&nbsp;image&nbsp;is&nbsp;displayed&nbsp;in&nbsp;the&nbsp;ProgressBarEx.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(ImageLayoutType),&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ImageLayout()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ImageLayoutType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ImageLayout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ImageLayoutType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ImageLayout&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_Image&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;True&nbsp;to&nbsp;draw&nbsp;corners&nbsp;rounded.&nbsp;False&nbsp;to&nbsp;draw&nbsp;square&nbsp;corners.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;RoundedCorners()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_RoundedCorners&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_RoundedCorners&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Determins&nbsp;the&nbsp;direction&nbsp;of&nbsp;progress&nbsp;displayed&nbsp;in&nbsp;the&nbsp;ProgressBarEx.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;&lt;DefaultValue(<span class="visualBasic__keyword">GetType</span>(ProgressDir),&nbsp;<span class="visualBasic__string">&quot;Horizontal&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ProgressDirection()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ProgressDir&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ProgressDirection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ProgressDir)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ProgressDirection&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnPaint(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.Forms.PaintEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.SmoothingMode&nbsp;=&nbsp;SmoothingMode.AntiAlias&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;StartPoint&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;EndPoint&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Height)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ProgressDirection&nbsp;=&nbsp;ProgressDir.Vertical&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndPoint&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;gp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GraphicsPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rec&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rad&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(rec.Height&nbsp;/&nbsp;<span class="visualBasic__number">2.5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;rec.Width&nbsp;&lt;&nbsp;rec.Height&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;rad&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(rec.Width&nbsp;/&nbsp;<span class="visualBasic__number">2.5</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;_BackColorBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;LinearGradientBrush(StartPoint,&nbsp;EndPoint,&nbsp;_BackColor,&nbsp;_GradiantColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BackColorBrush.Blend&nbsp;=&nbsp;bBlend&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_RoundedCorners&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MakePath(gp,&nbsp;rec,&nbsp;rad)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillPath(_BackColorBrush,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillRectangle(_BackColorBrush,&nbsp;rec)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_Value&nbsp;&gt;&nbsp;_Minimum&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;lngth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;(_Maximum&nbsp;-&nbsp;_Minimum))&nbsp;*&nbsp;_Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ProgressDirection&nbsp;=&nbsp;ProgressDir.Vertical&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lngth&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Height&nbsp;/&nbsp;(_Maximum&nbsp;-&nbsp;_Minimum))&nbsp;*&nbsp;_Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rec.Y&nbsp;=&nbsp;rec.Height&nbsp;-&nbsp;lngth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rec.Height&nbsp;=&nbsp;lngth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rec.Width&nbsp;=&nbsp;lngth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;_ProgressBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;LinearGradientBrush(StartPoint,&nbsp;EndPoint,&nbsp;_ProgressColor,&nbsp;_GradiantColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ProgressBrush.Blend&nbsp;=&nbsp;bBlend&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_RoundedCorners&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ProgressDirection&nbsp;=&nbsp;ProgressDir.Horizontal&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rec.Height&nbsp;-=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rec.Width&nbsp;-=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;gp2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GraphicsPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MakePath(gp2,&nbsp;rec,&nbsp;rad)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;gp3&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GraphicsPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;rgn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Region(gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgn.Intersect(gp2)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp3.AddRectangles(rgn.GetRegionScans(<span class="visualBasic__keyword">New</span>&nbsp;Matrix))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillPath(_ProgressBrush,&nbsp;gp3)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillRectangle(_ProgressBrush,&nbsp;rec)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_Image&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ImageLayout&nbsp;=&nbsp;ImageLayoutType.Stretch&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(_Image,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ImageLayout&nbsp;=&nbsp;ImageLayoutType.None&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(_Image,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xx&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(_Image.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;yy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(_Image.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(_Image,&nbsp;xx,&nbsp;yy)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShowPercentage&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;_ShowText&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;perc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShowText&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;perc&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShowPercentage&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;perc&nbsp;&amp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__number">100</span>&nbsp;/&nbsp;(_Maximum&nbsp;-&nbsp;_Minimum))&nbsp;*&nbsp;_Value).ToString&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;%&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;sf&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringFormat&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.Alignment&nbsp;=&nbsp;StringAlignment.Center,&nbsp;.LineAlignment&nbsp;=&nbsp;StringAlignment.Center}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(perc,&nbsp;<span class="visualBasic__keyword">Me</span>.Font,&nbsp;_ForeColorBrush,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height),&nbsp;sf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_Border&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rec&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;-&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_RoundedCorners&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MakePath(gp,&nbsp;rec,&nbsp;rad)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawPath(_BorderPen,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawRectangle(_BorderPen,&nbsp;rec)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;MakePath(<span class="visualBasic__keyword">ByRef</span>&nbsp;pth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GraphicsPath,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;rc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Rectangle,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;rad&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.Reset()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.AddArc(rc.X,&nbsp;rc.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">180</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.AddArc(rc.Right&nbsp;-&nbsp;(rad),&nbsp;rc.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">270</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.AddArc(rc.Right&nbsp;-&nbsp;(rad),&nbsp;rc.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.AddArc(rc.X,&nbsp;rc.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">90</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.CloseFigure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnTextChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnTextChanged(e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Dispose(<span class="visualBasic__keyword">ByVal</span>&nbsp;disposing&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ForeColorBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Dispose(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>),&nbsp;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Drawing.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Drawing.Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;=&nbsp;Color.Transparent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;&lt;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Obsolete(<span class="visualBasic__string">&quot;BackgroundImageLayout&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shadows</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackgroundImageLayout()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ImageLayout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackgroundImageLayout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ImageLayout)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException(<span class="visualBasic__string">&quot;BackgroundImageLayout&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;&lt;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Obsolete(<span class="visualBasic__string">&quot;BackgroundImage&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shadows</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackgroundImage()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException(<span class="visualBasic__string">&quot;BackgroundImage&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;&lt;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Obsolete(<span class="visualBasic__string">&quot;TabStop&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shadows</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TabStop()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException(<span class="visualBasic__string">&quot;TabStop&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;&lt;EditorBrowsable(EditorBrowsableState.Never)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.Obsolete(<span class="visualBasic__string">&quot;TabIndex&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shadows</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TabIndex()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.TabIndex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException(<span class="visualBasic__string">&quot;TabIndex&nbsp;is&nbsp;not&nbsp;implemented.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
</ul>
