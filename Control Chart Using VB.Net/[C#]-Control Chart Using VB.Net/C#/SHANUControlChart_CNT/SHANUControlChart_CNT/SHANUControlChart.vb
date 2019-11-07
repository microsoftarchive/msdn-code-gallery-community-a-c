Imports System.Drawing
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Threading
Imports System.Threading.Thread

Imports System.Reflection
Imports System.Drawing.Drawing2D

'Author  : Syed Shanu
'Date    : 2014-07-11
'Description :Contol Limit 
Public Class SHANUControlChart
    ' Global Declaration
    Dim zerovalues As Double
    Dim readvalue As Double = 0.0
    Dim readvalue1 As Double = 0.0
    Dim sensordata As Double
    Dim zerovalue1 As Double = 0.0
    Dim maxClick As Integer = 0
    Dim zeroDisplay As Integer = 0
    Dim upperLimitChk As Boolean = False
    Dim lowerLimitchk As Boolean = False
    Dim errLimtchk As Boolean = False

    'for the BarGraph Variable Declaration
    Dim upperValue As Double
    Dim lovervalue As Double
    Dim loverInitialvalue As Double
    Dim upperInititalvalue As Double
    Dim barheight As Double = 360
    Dim barwidth As Double = 120
    Dim xval As Double = 50
    Dim yval As Double = 10
    Dim inputValue As Double
    'Public Property Declaration
    Public Property MasterData() As String
        Get
            Return lblMasterData.Text
        End Get
        Set(value As String)
            lblMasterData.Text = value
        End Set
    End Property

    Public Property USLData() As String
        Get
            Return lblUslData.Text
        End Get
        Set(value As String)
            lblUslData.Text = value
        End Set
    End Property

    Public Property LSLData() As String
        Get
            Return lblLslData.Text
        End Get
        Set(value As String)
            lblLslData.Text = value
        End Set
    End Property


    Public Property NominalData() As String
        Get
            Return lblNominalData.Text
        End Get
        Set(value As String)
            lblNominalData.Text = value
        End Set
    End Property
    Private Sub SHANUControlChart_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblmsg.Top = picHolder.Height
        Timer1.Enabled = True

        lblS.Top = picHol2.Height
        lblH.Top = picHol2.Height
        lblA.Top = picHol2.Height
        lblN.Top = picHol2.Height
        lblU.Top = picHol2.Height

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick


        LoadcontrolChart()
    End Sub
    Public Sub LoadcontrolChart()
        Try
            'For Barand GageLoad
            upperLimitChk = False
            lowerLimitchk = False
            errLimtchk = False
            Dim pointVal As Integer
            Dim calcvalues As Double
            Dim calcvalues1 As Double
            '  Dim upperValue As Double
            Dim hasread As Integer
            Dim UpperRange As Double
            Dim err As String
            pointVal = 3
            Dim ival As Integer

            '' For the title Scroll.. ------------
            If lblmsg.Top > -lblmsg.Height Then
                lblmsg.Top = lblmsg.Top - 5
            Else
                lblmsg.Top = picHolder.Height
            End If

            ' For S Upwards
            If lblS.Top > -lblS.Height Then
                lblS.Top = lblS.Top - 5
            Else
                lblS.Top = picHol2.Height
            End If

            ' For H Downwards
            If lblH.Top < +lblH.Height Then
                lblH.Top = lblH.Top + 5
            Else
                lblH.Top = picHol2.Height - 30
            End If

            ' For A Upwards
            If lblA.Top > -lblA.Height Then
                lblA.Top = lblA.Top - 5
            Else
                lblA.Top = picHol2.Height
            End If

            ' For H Downwards
            If lblN.Top < +lblN.Height Then
                lblN.Top = lblN.Top + 5
            Else
                lblN.Top = picHol2.Height - 30
            End If

            ' For A Upwards
            If lblU.Top > -lblU.Height Then
                lblU.Top = lblU.Top - 5
            Else
                lblU.Top = picHol2.Height
            End If


            '' end of title text scrolling---------------------

            sensordata = Convert.ToDouble(lblMasterData.Text.Trim())

            frmMasteringPictuerBox.Refresh()

            upperValue = System.Convert.ToDouble(lblUslData.Text)
            lovervalue = System.Convert.ToDouble(lblLslData.Text)
            If upperValue = lovervalue Then
                lovervalue = lovervalue - 1
            End If

            inputValue = System.Convert.ToDouble(lblMasterData.Text)
            'here we call the draw ractangle fucntion 
            drawRectanles(barheight, barwidth, upperValue, lovervalue, loverInitialvalue, upperInititalvalue, xval, yval)
          

        Catch ex As Exception
        End Try
    End Sub
    ''This method is to draw the control chart 
    Public Sub drawRectanles(ByVal barheight As Double, ByVal barwidth As Double, ByVal uppervalue As Double, ByVal lovervalue As Double, ByVal loverinitialvalue As Double, ByVal upperinitialvalue As Double, ByVal xval As Double, ByVal yval As Double)
        Try
            Dim limitsline As Double
            Dim lowerlimitline As Double
            Dim underrange As Double
            Dim upperrange As Double
            Dim differentpercentage As Double
            Dim totalheight As Double
            Dim inputvalueCal As Double
            Dim finaldisplayvalue As Double
            Dim backColors1 As Color
            Dim backColors2 As Color
            'this is for the range persentage Calculation
            differentpercentage = uppervalue - lovervalue
            differentpercentage = differentpercentage * 0.2
            'Upper range value
            upperrange = uppervalue + differentpercentage
            'Lover range value
            underrange = lovervalue - differentpercentage
            totalheight = upperrange - underrange
            'For Upper Limit
            ''limitsline = barheight * 0.2 - 10
            limitsline = lovervalue - underrange
            limitsline = limitsline / totalheight
            limitsline = barheight * limitsline + 10
            'For Lower Limit
            lowerlimitline = uppervalue - underrange
            lowerlimitline = lowerlimitline / totalheight
            lowerlimitline = barheight * lowerlimitline + 10
            'lowerlimitline = barheight - limitsline + 10
            'for finding the rangedata
            inputvalueCal = inputValue - underrange
            finaldisplayvalue = inputvalueCal / totalheight
            finaldisplayvalue = barheight * finaldisplayvalue
            Dim g As Graphics = frmMasteringPictuerBox.CreateGraphics
            Dim f5 As Font
            f5 = New Font("arial", 22, FontStyle.Bold, GraphicsUnit.Pixel)
            ''If condition to check for the result and display the chart accordingly depend on limit values.
            If inputValue = "0.000" Then
                If zeroDisplay = 0 Then
                    backColors1 = Color.Red
                    backColors2 = Color.DarkRed
                    Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 90, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                    g.DrawString("NG -> UnderRange", f5, a5, System.Convert.ToInt32(xval) - 40, barheight + 24)
                    lblMasterData.ForeColor = Color.Red

                    frmMasteringlblmsg.Text = "NG -> UnderRange"
                Else
                    backColors1 = Color.GreenYellow
                    backColors2 = Color.DarkGreen
                    Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 90, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                    g.DrawString("OK -> Good", f5, a5, System.Convert.ToInt32(xval) - 40, barheight + 24)
                    lblMasterData.ForeColor = Color.GreenYellow

                    frmMasteringlblmsg.Text = "OK -> Good"
                End If
            ElseIf inputValue >= lovervalue And inputValue <= uppervalue Then
                backColors1 = Color.GreenYellow
                backColors2 = Color.DarkGreen
                If upperLimitChk = False Then
                    backColors1 = Color.GreenYellow
                    backColors2 = Color.DarkGreen
                    lblMasterData.ForeColor = Color.GreenYellow
                Else
                    backColors1 = Color.Red
                    backColors2 = Color.DarkRed
                    lblMasterData.ForeColor = Color.Red
                End If
                Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                g.DrawString("OK -> Good", f5, a5, System.Convert.ToInt32(xval) - 40, barheight + 24)

                frmMasteringlblmsg.Text = "OK -> Good"
                'frmMasteringlblOrignalData.ForeColor = Color.GreenYellow
            ElseIf inputValue < lovervalue Then
                backColors1 = Color.Red
                backColors2 = Color.DarkRed
                Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                g.DrawString("NG -> UnderRange", f5, a5, System.Convert.ToInt32(xval) - 40, barheight + 24)
                lblMasterData.ForeColor = Color.Red
                'frmMasteringlblOrignalData.ForeColor = Color.Red

                frmMasteringlblmsg.Text = "NG -> UnderRange"
            ElseIf inputValue > uppervalue Then
                backColors1 = Color.Red
                backColors2 = Color.DarkRed
                Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                g.DrawString("NG -> UpperRange", f5, a5, System.Convert.ToInt32(xval) - 40, barheight + 24)
                lblMasterData.ForeColor = Color.Red
                'frmMasteringlblOrignalData.ForeColor = Color.Red

                frmMasteringlblmsg.Text = "NG -> UpperRange"
            Else
                backColors1 = Color.Red
                backColors2 = Color.DarkRed
                Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                g.DrawString("Not Good", f5, a5, System.Convert.ToInt32(xval) - 40, barheight + 24)
                lblMasterData.ForeColor = Color.Red

                frmMasteringlblmsg.Text = "Not Good"
            End If
        
            Dim apen As New Pen(Color.Black, 2)
            g.DrawRectangle(Pens.Black, System.Convert.ToInt32(xval) - 2, System.Convert.ToInt32(yval) - 2, System.Convert.ToInt32(barwidth) + 3, System.Convert.ToInt32(barheight) + 3)

            g.DrawLine(apen, System.Convert.ToInt32(xval) - 15, System.Convert.ToInt32(limitsline), System.Convert.ToInt32(xval), System.Convert.ToInt32(limitsline))
            g.DrawLine(apen, System.Convert.ToInt32(xval) - 15, System.Convert.ToInt32(lowerlimitline), System.Convert.ToInt32(xval), System.Convert.ToInt32(lowerlimitline))
            Dim a1 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), Color.Blue, Color.Orange, Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Dim f As Font
            f = New Font("arial", 10, FontStyle.Bold, GraphicsUnit.Pixel)
            g.DrawString((String.Format("{0:N3}", CDbl(uppervalue.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, System.Convert.ToInt32(limitsline) + 1)
            g.DrawString((String.Format("{0:N3}", CDbl(lovervalue.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, System.Convert.ToInt32(lowerlimitline) + 1)
            g.DrawString((String.Format("{0:N3}", CDbl(upperrange.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, 9)
            g.DrawString((String.Format("{0:N3}", CDbl(underrange.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, barheight + 10)
            Dim a As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(xval, barheight + 10, barwidth, finaldisplayvalue + 1), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Vertical)
          
            Dim a2 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), Color.Black, Color.Black, Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Dim f2 As Font
            f2 = New Font("arial", 12, FontStyle.Bold, GraphicsUnit.Pixel)
            If inputValue >= upperrange Then
                g.FillRectangle(a, New RectangleF(xval, 10, barwidth, barheight))
                g.DrawString((String.Format("{0:N3}", CDbl(inputValue.ToString))), f2, a2, System.Convert.ToInt32(xval) + 40, yval - 8)
            ElseIf inputValue <= underrange Then
                g.FillRectangle(a, New RectangleF(xval, barheight + 10, barwidth, 4))
                g.DrawString((String.Format("{0:N3}", CDbl(inputValue.ToString))), f2, a2, System.Convert.ToInt32(xval) + 40, barheight + 10)
            Else
                g.FillRectangle(a, New RectangleF(xval, barheight - finaldisplayvalue + 10, barwidth, finaldisplayvalue))
                g.DrawString((String.Format("{0:N3}", CDbl(inputValue.ToString))), f2, a2, System.Convert.ToInt32(xval) + 40, barheight - System.Convert.ToInt32(finaldisplayvalue))
            End If
            ' End If
            g.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class
''Class for Gradiant Style Panel
Public Class Panel1
    Inherits Panel
    Dim mStartColor As System.Drawing.Color
    Dim mEndColor As System.Drawing.Color

    'Properties  STARTCOLOR and ENDCOLOR to give the Gradient Effect
    Public Property StartColor() As System.Drawing.Color
        Get
            Return mStartColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mStartColor = Value
            PaintGradient()
        End Set
    End Property
    Public Property EndColor() As System.Drawing.Color
        Get
            Return mEndColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mEndColor = Value
            PaintGradient()
        End Set
    End Property


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
    End Sub


    Private Sub PaintGradient()
        Dim gradBrush As System.Drawing.Drawing2D.LinearGradientBrush
        gradBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0),
        New Point(Me.Width, Me.Height), StartColor, EndColor)
        Dim bmp As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.FillRectangle(gradBrush, New Rectangle(0, 0, Me.Width, Me.Height))
        Me.BackgroundImage = bmp
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

End Class
