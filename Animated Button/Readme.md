# Animated Button
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Studio 2010 SDK
- vb
- Visual Studio 2008
- .NET
- Class Library
- User Interface
- Windows Forms
- Visual Studio 2010
- Windows 7
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- custom controls
- .NET Framework
- Windows
- Visual Basic .NET
- Visual Basic.NET
- VB.Net
- .NET Framework 4.0
- Image manipulation
- Windows UI
- C# Language
- VB.NET Language Features
- WinForms
- .NET Framework 4.5
- Windows 8
- .NET Framwork
- C# 3.0
- Graphics Functions
- vb2008
- Microsoft .NET Framework 3.5 SP1
- VB2010
- Visual C Sharp .NET
- Image process
- Visual Studio 2012
- Visual Studio 2013
- .NET 4.5
- .NET 2.0
- DLL file to use in VB
- .NET Development
- Windows Desktop App Development
- Image Transformation
- Windows 8.1
- .NET Framework 4.5.1
- VB2013
- C# 2013
## Topics
- Controls
- Graphics
- C#
- User Interface
- Windows Forms
- Graphics and 3D
- Images
- .NET Framework
- Visual Basic .NET
- Visual basic
- VB.Net
- Image manipulation
- Image
- Optional &amp; Named Parameters in C#
- .NET 4
- Drawing
- Generic C# resuable code
- C# Language Features
- Visual C Sharp .NET
- .Net Programming
- User Experience
## Updated
- 01/03/2014
## Description

<h1>Introduction</h1>
<p><em>This is a basic animated button made in c# and vb. It has a hover animation and a click animation.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>VS 2013 is required for this sample. There will be a 2012 and 2010 verison coming soon.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This is a custom drawn button that uses animation on user interaction.
<span style="color:#ffffff">aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</span></span></p>
<p><span style="font-size:small"><span style="color:#ffffff">aaaaaaaaaaaaaaaaaaaaaaa</span></span></p>
<p><span style="color:#ffffff">aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</span></p>
<p><span style="font-size:small"><span style="color:#ffffff">aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</span></span></p>
<p><span style="font-size:small"><span style="color:#ffffff">aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</span></span></p>
<p><span style="font-size:small">First create a Class Library Project.</span></p>
<p><span style="font-size:small">Add a Custom Control. (Ctrl &#43; Shift &#43; A) &gt; Windows Forms &gt; Custom Control.</span></p>
<p><span style="font-size:small">Replace all code with following.</span></p>
<p><span style="font-size:small">In the designer, add a timer and name it &quot;_FPS&quot;. Enable the timer, interval set to 1.</span></p>
<p><span style="font-size:small">Add these images to your resources.</span></p>
<p><span style="font-size:small"><img id="106472" src="106472-buttonmousedown.png" alt="" width="100" height="750"><img id="106473" src="106473-buttonmouseover.png" alt="" width="100" height="750"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports System.Drawing
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

        ElseIf (IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseOverFrame.CurrentFrame &lt;&gt; MouseOverFrame.FrameCount))) Then

            e.Graphics.DrawImage(MouseOverFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 New Rectangle(0, MouseOverFrame.CurrentFrame * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

            MouseOverFrame.CurrentFrame &#43;= 1

        ElseIf (IsMouseOver AndAlso (Not IsMouseDown AndAlso ((MouseOverFrame.CurrentFrame = MouseOverFrame.FrameCount) AndAlso (MouseClickFrame.CurrentFrame = 0)))) Then

            e.Graphics.DrawImage(MouseOverFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 New Rectangle(0, ((MouseOverFrame.CurrentFrame - 1) * MouseOverFrame.FrameSize.Height), MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

        ElseIf (IsMouseOver AndAlso (IsMouseDown AndAlso (MouseClickFrame.CurrentFrame &lt;&gt; MouseClickFrame.FrameCount))) Then

            e.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 New Rectangle(0, MouseClickFrame.CurrentFrame * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

            MouseClickFrame.CurrentFrame &#43;= 1

        ElseIf (IsMouseOver AndAlso (IsMouseDown AndAlso (MouseClickFrame.CurrentFrame = MouseClickFrame.FrameCount))) Then

            e.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 New Rectangle(0, ((MouseClickFrame.CurrentFrame - 1) * MouseClickFrame.FrameSize.Height), MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)

        ElseIf (IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseClickFrame.CurrentFrame &lt;&gt; 0))) Then

            MouseClickFrame.CurrentFrame -= 1

            e.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                                 New Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 New Rectangle(0, MouseClickFrame.CurrentFrame * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height),
                                 GraphicsUnit.Pixel)



        ElseIf (Not IsMouseOver AndAlso (Not IsMouseDown AndAlso (MouseOverFrame.CurrentFrame &lt;&gt; 0))) Then

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
</pre>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animate
{
    public partial class AnimatedButton : Button
    {
        #region Frame

        private class Frame
        {
            public Frame(int FrameCount, int CurrentFrame, Size FrameSize, Image ImageStrip)
            {
                this.FrameCount = FrameCount;
                this.CurrentFrame = CurrentFrame;
                this.FrameSize = FrameSize;
                this.ImageStrip = ImageStrip;
            }

            public Image ImageStrip
            {
                get;
                set;
            }
            public int FrameCount
            {
                get;
                set;
            }
            public int CurrentFrame
            {
                get;
                set;
            }
            public Size FrameSize
            {
                get;
                set;
            }
        }

        #endregion

        #region MouseOver

        private bool _IsMouseOver = false;
        private Frame MouseOverFrame
        {
            get;
            set;
        }
        private bool IsMouseOver
        {
            get
            {
                return _IsMouseOver;
            }
            set
            {
                _IsMouseOver = value;

                Refresh();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            IsMouseOver = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            IsMouseOver = false;
        }

        #endregion

        #region MouseClick

        private bool _IsMouseDown = false;
        private bool IsMouseDown
        {
            get
            {
                return _IsMouseDown;
            }
            set
            {
                _IsMouseDown = value;

                Refresh();
            }
        }
        private Frame MouseClickFrame
        {
            get;
            set;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            IsMouseDown = true;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            IsMouseDown = false;
        }

        #endregion

        public AnimatedButton()
        {
            InitializeComponent();

            DoubleBuffered = true;

            MouseOverFrame = new Frame(25, 0, new Size(100, 30), Properties.Resources.ButtonMouseOver);
            MouseClickFrame = new Frame(25, 0, new Size(100, 30), Properties.Resources.ButtonMouseDown);

            this.Size = MouseOverFrame.FrameSize;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.Clear(BackColor); 

            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pe.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            if (!IsMouseOver &amp;&amp; !IsMouseDown &amp;&amp; MouseOverFrame.CurrentFrame == 0)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver &amp;&amp; !IsMouseDown &amp;&amp; MouseOverFrame.CurrentFrame != MouseOverFrame.FrameCount)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, MouseOverFrame.CurrentFrame&#43;&#43; * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver &amp;&amp; !IsMouseDown &amp;&amp; MouseOverFrame.CurrentFrame == MouseOverFrame.FrameCount &amp;&amp; MouseClickFrame.CurrentFrame == 0)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, (MouseOverFrame.CurrentFrame - 1) * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver &amp;&amp; IsMouseDown &amp;&amp; MouseClickFrame.CurrentFrame != MouseClickFrame.FrameCount)
            {
                pe.Graphics.DrawImage(MouseClickFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    new Rectangle(0, MouseClickFrame.CurrentFrame&#43;&#43; * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver &amp;&amp; IsMouseDown &amp;&amp; MouseClickFrame.CurrentFrame == MouseClickFrame.FrameCount)
            {
                pe.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                    new Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    new Rectangle(0, (MouseClickFrame.CurrentFrame - 1) * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver &amp;&amp; !IsMouseDown &amp;&amp; MouseClickFrame.CurrentFrame != 0)
            {
                pe.Graphics.DrawImage(MouseClickFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    new Rectangle(0, --MouseClickFrame.CurrentFrame * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (!IsMouseOver &amp;&amp; !IsMouseDown &amp;&amp; MouseOverFrame.CurrentFrame != 0)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, --MouseOverFrame.CurrentFrame * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), pe.ClipRectangle, sf);
            }
        }

        private void _FPS_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows.Forms&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;AnimatedButton&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Button&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Frame&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;FrameCount&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;CurrentFrame&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;FrameSize&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Size,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;ImageStrip&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.FrameCount&nbsp;=&nbsp;FrameCount&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.CurrentFrame&nbsp;=&nbsp;CurrentFrame&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.FrameSize&nbsp;=&nbsp;FrameSize&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.ImageStrip&nbsp;=&nbsp;ImageStrip&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;ImageStrip&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;FrameCount&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;CurrentFrame&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;FrameSize&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Size&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_IsMouseOver&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;MouseOverFrame&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Frame&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;IsMouseOver&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_IsMouseOver&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_IsMouseOver&nbsp;=&nbsp;value&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnMouseEnter(e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnMouseEnter(e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsMouseOver&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnMouseLeave(e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnMouseLeave(e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsMouseOver&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_IsMouseDown&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;IsMouseDown&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_IsMouseDown&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_IsMouseDown&nbsp;=&nbsp;value&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;MouseClickFrame&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Frame&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnMouseDown(mevent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;MouseEventArgs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnMouseDown(mevent)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsMouseDown&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnMouseUp(mevent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;MouseEventArgs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnMouseUp(mevent)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsMouseDown&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;This&nbsp;call&nbsp;is&nbsp;required&nbsp;by&nbsp;the&nbsp;designer.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Add&nbsp;any&nbsp;initialization&nbsp;after&nbsp;the&nbsp;InitializeComponent()&nbsp;call.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleBuffered&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MouseOverFrame&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Frame(<span class="visualBasic__number">25</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">30</span>),&nbsp;My.Resources.ButtonMouseOver)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MouseClickFrame&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Frame(<span class="visualBasic__number">25</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">30</span>),&nbsp;My.Resources.ButtonMouseDown)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Size&nbsp;=&nbsp;MouseOverFrame.FrameSize&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnPaint(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.Forms.PaintEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnPaint(e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Add&nbsp;your&nbsp;custom&nbsp;paint&nbsp;code&nbsp;here</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.Clear(BackColor)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.InterpolationMode&nbsp;=&nbsp;System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.SmoothingMode&nbsp;=&nbsp;System.Drawing.Drawing2D.SmoothingMode.HighQuality&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.CompositingQuality&nbsp;=&nbsp;System.Drawing.Drawing2D.CompositingQuality.HighQuality&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseOverFrame.CurrentFrame&nbsp;=&nbsp;<span class="visualBasic__number">0</span>)))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseOverFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseOverFrame.CurrentFrame&nbsp;&lt;&gt;&nbsp;MouseOverFrame.FrameCount)))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseOverFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.CurrentFrame&nbsp;*&nbsp;MouseOverFrame.FrameSize.Height,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MouseOverFrame.CurrentFrame&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;((MouseOverFrame.CurrentFrame&nbsp;=&nbsp;MouseOverFrame.FrameCount)&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseClickFrame.CurrentFrame&nbsp;=&nbsp;<span class="visualBasic__number">0</span>))))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseOverFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;((MouseOverFrame.CurrentFrame&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;*&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseClickFrame.CurrentFrame&nbsp;&lt;&gt;&nbsp;MouseClickFrame.FrameCount)))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseClickFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseClickFrame.FrameSize.Width,&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;MouseClickFrame.CurrentFrame&nbsp;*&nbsp;MouseClickFrame.FrameSize.Height,&nbsp;MouseClickFrame.FrameSize.Width,&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MouseClickFrame.CurrentFrame&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseClickFrame.CurrentFrame&nbsp;=&nbsp;MouseClickFrame.FrameCount)))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseClickFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseClickFrame.FrameSize.Width,&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;((MouseClickFrame.CurrentFrame&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;*&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;MouseClickFrame.FrameSize.Width,&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseClickFrame.CurrentFrame&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>)))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MouseClickFrame.CurrentFrame&nbsp;-=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseClickFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseClickFrame.FrameSize.Width,&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;MouseClickFrame.CurrentFrame&nbsp;*&nbsp;MouseClickFrame.FrameSize.Height,&nbsp;MouseClickFrame.FrameSize.Width,&nbsp;MouseClickFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseOver&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;IsMouseDown&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(MouseOverFrame.CurrentFrame&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>)))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MouseOverFrame.CurrentFrame&nbsp;-=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(MouseOverFrame.ImageStrip,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;MouseOverFrame.CurrentFrame&nbsp;*&nbsp;MouseOverFrame.FrameSize.Height,&nbsp;MouseOverFrame.FrameSize.Width,&nbsp;MouseOverFrame.FrameSize.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;sf&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringFormat&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.LineAlignment&nbsp;=&nbsp;StringAlignment.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.Alignment&nbsp;=&nbsp;StringAlignment.Center&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Text,&nbsp;Font,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(ForeColor),&nbsp;e.ClipRectangle,&nbsp;sf)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;_FPS_Tick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;_FPS.Tick&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
