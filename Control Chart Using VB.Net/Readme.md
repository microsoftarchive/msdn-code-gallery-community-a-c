# Control Chart Using VB.Net
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- VB.Net
## Topics
- VB.Net
## Updated
- 02/11/2016
## Description

<h1>Introduction</h1>
<p><img id="148203" src="148203-1.gif" alt="" width="560" height="364"></p>
<p><span>Nowadays automobile industry&nbsp;is interested in automated measuring machines to ensure quality and to compete in the global industry.&nbsp;</span><span>Control Chart takes a major role&nbsp;in ensuring quality by measuring automobile components.
 The purpose is to make a simple Control Bar Chart for Measuring Systems like Camshaft, Crankshaft, and Master Setting ,so on. A digital sensor is used for measuring Camshaft and Crankshaft. Then the measured data&nbsp;is analyzed using the Control Chart .</span></p>
<p><strong>Control Chart</strong><span>(<a href="http://asq.org/learn-about-quality/data-collection-analysis-tools/overview/control-chart.html" target="_blank">ref</a>)</span></p>
<p><span>The Control Charts are graphs which is used to check the quality of control of a process. In Control charts UCL/LCL or USL/LSL will be used to check with the resultant data.If Measurement data within the range of limits then the process is&nbsp;<strong>OK(GOOD)</strong>&nbsp;.If
 the Measurement data is above or below the Limits the process is&nbsp;<strong>NG(NOT GOOD).</strong></span></p>
<p><span><strong>1) OK (GOOD) -&gt; USL &lt;= Measurement Data &gt;= LSL&nbsp;</strong></span></p>
<p><span><strong>2) NG (NOT GOOD) -&gt; Upper Rang</strong></span><strong>e &nbsp;-&gt; Measurement Data &gt; USL</strong></p>
<p><span><strong>3) NG&nbsp;</strong></span><strong>(NOT GOOD) -&gt; Lower Range -&gt;&nbsp;</strong><span><strong>&nbsp;</strong></span><strong>Measurement Data &lt; LSL</strong></p>
<p><img id="148204" src="148204-shanucontrol_chart_1.jpg" alt="" width="570" height="222"></p>
<p><span>In our simple Control Chart&nbsp;<strong>USL /LSL</strong>&nbsp;are used for verifying the data.USL -&gt; Upper Specification Limit and LSL -&gt; Lower Specification Limit. Note in this sample i have used USL/LSL .</span></p>
<p><span>Difference between USL/LSL and UCL/LCL.</span></p>
<p><span>(</span><span>The UCL or upper control limit and LCL or lower control limit are limits set by your process based on the actual amount of variation of your process.&nbsp;</span></p>
<p>The USL or upper specification limit and LSL or lower specification limit are limits set by your customer's requirements. This is the variation that they will accept from your process.&nbsp;<a href="http://lecturehub.wordpress.com/2013/10/24/the-difference-between-usllsl-and-ucllcl/" target="_blank">Ref</a>)</p>
<p><span>&nbsp;The main purpose of this article is to share what we have developed to other members.&nbsp;</span></p>
<p>We have created a Control Chart as a User Control so that it can be used easily in all projects.</p>
<p>In this article we have attached zip file named as&nbsp;SHANUControlChart_SRC.zip. Which contains .</p>
<p>1) &quot;SHANUControlChart_CNT&quot; Folder (This folder contains the Control Chart User control Source code.</p>
<p>2) &quot;SHANUControlChart_DEMO&quot; Folder (This folder conains the Demo program which includes the Control Chart user control with Random Measurement sample using Timer control).</p>
<h1><span>Building the Sample</span></h1>
<p><strong>Prerequisites</strong></p>
<p>Visual Studio 2010&nbsp; or higer versions</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h2><strong><em>Control Chart user Control:</em></strong></h2>
<p>1) First we will start with the User Control .To Create a user control .</p>
<ol type="1">
<li>Create a new Windows Control Library project. </li><li>Set the Name of Project and Click Ok(here my user control name is SHANUControlChart_CNT).
</li><li>Add all the controls which is needed. </li><li>In code behind declare all the public variables and Public property variables.Here USL/LSL/Nominal and Measurement Data Public property has been declared.Which will be used to pass the data from the windows application.
</li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">'Public Property Declaration
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
   End Property</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'Public&nbsp;Property&nbsp;Declaration</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;MasterData()&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Return</span>&nbsp;lblMasterData.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.Text&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Set</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Property</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;USLData()&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Return</span>&nbsp;lblUslData.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblUslData.Text&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Set</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Property</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;LSLData()&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Return</span>&nbsp;lblLslData.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblLslData.Text&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Set</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Property</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;NominalData()&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Return</span>&nbsp;lblNominalData.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Get</span><span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblNominalData.Text&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Set</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Property</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>&nbsp;&nbsp;5.In our User control we have used Timer control to always check for the Measurment data and produce the Bar Chart.In user control Load we have Enabled and Start the Timer.In Timer Tick Event called the Function
 &quot;LoadcontrolChart()&quot; .In this fucntion we set all USL/LSL and measurement data and draw the Chart control.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Sub LoadcontrolChart()
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
    End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span>&nbsp;LoadcontrolChart()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span><span class="visualBasic__com">'For&nbsp;Barand&nbsp;GageLoad</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;upperLimitChk&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lowerLimitchk&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;errLimtchk&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span><span class="visualBasic__keyword">Dim</span>&nbsp;pointVal&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Integer</span><span class="visualBasic__keyword">Dim</span>&nbsp;calcvalues&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;calcvalues1&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__com">'&nbsp;&nbsp;Dim&nbsp;upperValue&nbsp;As&nbsp;Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;hasread&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Integer</span><span class="visualBasic__keyword">Dim</span>&nbsp;UpperRange&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;err&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pointVal&nbsp;=&nbsp;<span class="visualBasic__number">3</span><span class="visualBasic__keyword">Dim</span>&nbsp;ival&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sensordata&nbsp;=&nbsp;Convert.ToDouble(lblMasterData.Text.Trim())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringPictuerBox.Refresh()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;upperValue&nbsp;=&nbsp;System.Convert.ToDouble(lblUslData.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lovervalue&nbsp;=&nbsp;System.Convert.ToDouble(lblLslData.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;upperValue&nbsp;=&nbsp;lovervalue&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lovervalue&nbsp;=&nbsp;lovervalue&nbsp;-&nbsp;<span class="visualBasic__number">1</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;inputValue&nbsp;=&nbsp;System.Convert.ToDouble(lblMasterData.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'here&nbsp;we&nbsp;call&nbsp;the&nbsp;draw&nbsp;ractangle&nbsp;fucntion&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawRectanles(barheight,&nbsp;barwidth,&nbsp;upperValue,&nbsp;lovervalue,&nbsp;loverInitialvalue,&nbsp;upperInititalvalue,&nbsp;xval,&nbsp;yval)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Try</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>In &nbsp;this Method we check the Measurement data with USL and LSL Limit Value .If Measurement data within the range of USL and LSL then the resultant output will be Ok .We have used the if condition to check the resultant
 values. as below .</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">'This method is to draw the control chart
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
           upperrange = uppervalue &#43; differentpercentage
           'Lover range value
           underrange = lovervalue - differentpercentage
           totalheight = upperrange - underrange
           'For Upper Limit
           ''limitsline = barheight * 0.2 - 10
           limitsline = lovervalue - underrange
           limitsline = limitsline / totalheight
           limitsline = barheight * limitsline &#43; 10
           'For Lower Limit
           lowerlimitline = uppervalue - underrange
           lowerlimitline = lowerlimitline / totalheight
           lowerlimitline = barheight * lowerlimitline &#43; 10
           'lowerlimitline = barheight - limitsline &#43; 10
           'for finding the rangedata
           inputvalueCal = inputValue - underrange
           finaldisplayvalue = inputvalueCal / totalheight
           finaldisplayvalue = barheight * finaldisplayvalue
           Dim g As Graphics = frmMasteringPictuerBox.CreateGraphics
           Dim f5 As Font
           f5 = New Font(&quot;arial&quot;, 22, FontStyle.Bold, GraphicsUnit.Pixel)
           ''If condition to check for the result and display the chart accordingly depend on limit values.
           If inputValue = &quot;0.000&quot; Then
               If zeroDisplay = 0 Then
                   backColors1 = Color.Red
                   backColors2 = Color.DarkRed
                   Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 90, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                   g.DrawString(&quot;NG -&gt; UnderRange&quot;, f5, a5, System.Convert.ToInt32(xval) - 40, barheight &#43; 24)
                   lblMasterData.ForeColor = Color.Red

                   frmMasteringlblmsg.Text = &quot;NG -&gt; UnderRange&quot;
               Else
                   backColors1 = Color.GreenYellow
                   backColors2 = Color.DarkGreen
                   Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 90, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
                   g.DrawString(&quot;OK -&gt; Good&quot;, f5, a5, System.Convert.ToInt32(xval) - 40, barheight &#43; 24)
                   lblMasterData.ForeColor = Color.GreenYellow

                   frmMasteringlblmsg.Text = &quot;OK -&gt; Good&quot;
               End If
           ElseIf inputValue &gt;= lovervalue And inputValue &lt;= uppervalue Then
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
               g.DrawString(&quot;OK -&gt; Good&quot;, f5, a5, System.Convert.ToInt32(xval) - 40, barheight &#43; 24)

               frmMasteringlblmsg.Text = &quot;OK -&gt; Good&quot;
               'frmMasteringlblOrignalData.ForeColor = Color.GreenYellow
           ElseIf inputValue &lt; lovervalue Then
               backColors1 = Color.Red
               backColors2 = Color.DarkRed
               Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
               g.DrawString(&quot;NG -&gt; UnderRange&quot;, f5, a5, System.Convert.ToInt32(xval) - 40, barheight &#43; 24)
               lblMasterData.ForeColor = Color.Red
               'frmMasteringlblOrignalData.ForeColor = Color.Red

               frmMasteringlblmsg.Text = &quot;NG -&gt; UnderRange&quot;
           ElseIf inputValue &gt; uppervalue Then
               backColors1 = Color.Red
               backColors2 = Color.DarkRed
               Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
               g.DrawString(&quot;NG -&gt; UpperRange&quot;, f5, a5, System.Convert.ToInt32(xval) - 40, barheight &#43; 24)
               lblMasterData.ForeColor = Color.Red
               'frmMasteringlblOrignalData.ForeColor = Color.Red

               frmMasteringlblmsg.Text = &quot;NG -&gt; UpperRange&quot;
           Else
               backColors1 = Color.Red
               backColors2 = Color.DarkRed
               Dim a5 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Horizontal)
               g.DrawString(&quot;Not Good&quot;, f5, a5, System.Convert.ToInt32(xval) - 40, barheight &#43; 24)
               lblMasterData.ForeColor = Color.Red

               frmMasteringlblmsg.Text = &quot;Not Good&quot;
           End If

           Dim apen As New Pen(Color.Black, 2)
           g.DrawRectangle(Pens.Black, System.Convert.ToInt32(xval) - 2, System.Convert.ToInt32(yval) - 2, System.Convert.ToInt32(barwidth) &#43; 3, System.Convert.ToInt32(barheight) &#43; 3)

           g.DrawLine(apen, System.Convert.ToInt32(xval) - 15, System.Convert.ToInt32(limitsline), System.Convert.ToInt32(xval), System.Convert.ToInt32(limitsline))
           g.DrawLine(apen, System.Convert.ToInt32(xval) - 15, System.Convert.ToInt32(lowerlimitline), System.Convert.ToInt32(xval), System.Convert.ToInt32(lowerlimitline))
           Dim a1 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), Color.Blue, Color.Orange, Drawing.Drawing2D.LinearGradientMode.Horizontal)
           Dim f As Font
           f = New Font(&quot;arial&quot;, 10, FontStyle.Bold, GraphicsUnit.Pixel)
           g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(uppervalue.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, System.Convert.ToInt32(limitsline) &#43; 1)
           g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(lovervalue.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, System.Convert.ToInt32(lowerlimitline) &#43; 1)
           g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(upperrange.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, 9)
           g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(underrange.ToString))), f, a1, System.Convert.ToInt32(xval) - 40, barheight &#43; 10)
           Dim a As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(xval, barheight &#43; 10, barwidth, finaldisplayvalue &#43; 1), backColors1, backColors2, Drawing.Drawing2D.LinearGradientMode.Vertical)

           Dim a2 As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), Color.Black, Color.Black, Drawing.Drawing2D.LinearGradientMode.Horizontal)
           Dim f2 As Font
           f2 = New Font(&quot;arial&quot;, 12, FontStyle.Bold, GraphicsUnit.Pixel)
           If inputValue &gt;= upperrange Then
               g.FillRectangle(a, New RectangleF(xval, 10, barwidth, barheight))
               g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(inputValue.ToString))), f2, a2, System.Convert.ToInt32(xval) &#43; 40, yval - 8)
           ElseIf inputValue &lt;= underrange Then
               g.FillRectangle(a, New RectangleF(xval, barheight &#43; 10, barwidth, 4))
               g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(inputValue.ToString))), f2, a2, System.Convert.ToInt32(xval) &#43; 40, barheight &#43; 10)
           Else
               g.FillRectangle(a, New RectangleF(xval, barheight - finaldisplayvalue &#43; 10, barwidth, finaldisplayvalue))
               g.DrawString((String.Format(&quot;{0:N3}&quot;, CDbl(inputValue.ToString))), f2, a2, System.Convert.ToInt32(xval) &#43; 40, barheight - System.Convert.ToInt32(finaldisplayvalue))
           End If
           ' End If
           g.Dispose()
       Catch ex As Exception
       End Try
   End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'This&nbsp;method&nbsp;is&nbsp;to&nbsp;draw&nbsp;the&nbsp;control&nbsp;chart</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span>&nbsp;drawRectanles(<span class="visualBasic__keyword">ByVal</span>&nbsp;barheight&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;barwidth&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;uppervalue&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lovervalue&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;loverinitialvalue&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;upperinitialvalue&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;xval&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;yval&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span><span class="visualBasic__keyword">Dim</span>&nbsp;limitsline&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;lowerlimitline&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;underrange&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;upperrange&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;differentpercentage&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;totalheight&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;inputvalueCal&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;finaldisplayvalue&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Double</span><span class="visualBasic__keyword">Dim</span>&nbsp;backColors1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;backColors2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'this&nbsp;is&nbsp;for&nbsp;the&nbsp;range&nbsp;persentage&nbsp;Calculation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;differentpercentage&nbsp;=&nbsp;uppervalue&nbsp;-&nbsp;lovervalue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;differentpercentage&nbsp;=&nbsp;differentpercentage&nbsp;*&nbsp;<span class="visualBasic__number">0.2</span><span class="visualBasic__com">'Upper&nbsp;range&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;upperrange&nbsp;=&nbsp;uppervalue&nbsp;&#43;&nbsp;differentpercentage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Lover&nbsp;range&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;underrange&nbsp;=&nbsp;lovervalue&nbsp;-&nbsp;differentpercentage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalheight&nbsp;=&nbsp;upperrange&nbsp;-&nbsp;underrange&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'For&nbsp;Upper&nbsp;Limit</span><span class="visualBasic__com">''limitsline&nbsp;=&nbsp;barheight&nbsp;*&nbsp;0.2&nbsp;-&nbsp;10</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;limitsline&nbsp;=&nbsp;lovervalue&nbsp;-&nbsp;underrange&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;limitsline&nbsp;=&nbsp;limitsline&nbsp;/&nbsp;totalheight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;limitsline&nbsp;=&nbsp;barheight&nbsp;*&nbsp;limitsline&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span><span class="visualBasic__com">'For&nbsp;Lower&nbsp;Limit</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lowerlimitline&nbsp;=&nbsp;uppervalue&nbsp;-&nbsp;underrange&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lowerlimitline&nbsp;=&nbsp;lowerlimitline&nbsp;/&nbsp;totalheight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lowerlimitline&nbsp;=&nbsp;barheight&nbsp;*&nbsp;lowerlimitline&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span><span class="visualBasic__com">'lowerlimitline&nbsp;=&nbsp;barheight&nbsp;-&nbsp;limitsline&nbsp;&#43;&nbsp;10</span><span class="visualBasic__com">'for&nbsp;finding&nbsp;the&nbsp;rangedata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;inputvalueCal&nbsp;=&nbsp;inputValue&nbsp;-&nbsp;underrange&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;finaldisplayvalue&nbsp;=&nbsp;inputvalueCal&nbsp;/&nbsp;totalheight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;finaldisplayvalue&nbsp;=&nbsp;barheight&nbsp;*&nbsp;finaldisplayvalue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;g&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Graphics&nbsp;=&nbsp;frmMasteringPictuerBox.CreateGraphics&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;f5&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Font&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f5&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;arial&quot;</span>,&nbsp;<span class="visualBasic__number">22</span>,&nbsp;FontStyle.Bold,&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''If&nbsp;condition&nbsp;to&nbsp;check&nbsp;for&nbsp;the&nbsp;result&nbsp;and&nbsp;display&nbsp;the&nbsp;chart&nbsp;accordingly&nbsp;depend&nbsp;on&nbsp;limit&nbsp;values.</span><span class="visualBasic__keyword">If</span>&nbsp;inputValue&nbsp;=&nbsp;<span class="visualBasic__string">&quot;0.000&quot;</span><span class="visualBasic__keyword">Then</span><span class="visualBasic__keyword">If</span>&nbsp;zeroDisplay&nbsp;=&nbsp;<span class="visualBasic__number">0</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkRed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a5&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">90</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(<span class="visualBasic__string">&quot;NG&nbsp;-&gt;&nbsp;UnderRange&quot;</span>,&nbsp;f5,&nbsp;a5,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">24</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringlblmsg.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;NG&nbsp;-&gt;&nbsp;UnderRange&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.GreenYellow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkGreen&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a5&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">90</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(<span class="visualBasic__string">&quot;OK&nbsp;-&gt;&nbsp;Good&quot;</span>,&nbsp;f5,&nbsp;a5,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">24</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.GreenYellow&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringlblmsg.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;OK&nbsp;-&gt;&nbsp;Good&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">ElseIf</span>&nbsp;inputValue&nbsp;&gt;=&nbsp;lovervalue&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;inputValue&nbsp;&lt;=&nbsp;uppervalue&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.GreenYellow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkGreen&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;upperLimitChk&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.GreenYellow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkGreen&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.GreenYellow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkRed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">Dim</span>&nbsp;a5&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(<span class="visualBasic__string">&quot;OK&nbsp;-&gt;&nbsp;Good&quot;</span>,&nbsp;f5,&nbsp;a5,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">24</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringlblmsg.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;OK&nbsp;-&gt;&nbsp;Good&quot;</span><span class="visualBasic__com">'frmMasteringlblOrignalData.ForeColor&nbsp;=&nbsp;Color.GreenYellow</span><span class="visualBasic__keyword">ElseIf</span>&nbsp;inputValue&nbsp;&lt;&nbsp;lovervalue&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkRed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a5&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(<span class="visualBasic__string">&quot;NG&nbsp;-&gt;&nbsp;UnderRange&quot;</span>,&nbsp;f5,&nbsp;a5,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">24</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'frmMasteringlblOrignalData.ForeColor&nbsp;=&nbsp;Color.Red</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringlblmsg.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;NG&nbsp;-&gt;&nbsp;UnderRange&quot;</span><span class="visualBasic__keyword">ElseIf</span>&nbsp;inputValue&nbsp;&gt;&nbsp;uppervalue&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkRed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a5&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(<span class="visualBasic__string">&quot;NG&nbsp;-&gt;&nbsp;UpperRange&quot;</span>,&nbsp;f5,&nbsp;a5,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">24</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'frmMasteringlblOrignalData.ForeColor&nbsp;=&nbsp;Color.Red</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringlblmsg.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;NG&nbsp;-&gt;&nbsp;UpperRange&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors1&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backColors2&nbsp;=&nbsp;Color.DarkRed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a5&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(<span class="visualBasic__string">&quot;Not&nbsp;Good&quot;</span>,&nbsp;f5,&nbsp;a5,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">24</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblMasterData.ForeColor&nbsp;=&nbsp;Color.Red&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frmMasteringlblmsg.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Not&nbsp;Good&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">Dim</span>&nbsp;apen&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black,&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawRectangle(Pens.Black,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">2</span>,&nbsp;System.Convert.ToInt32(yval)&nbsp;-&nbsp;<span class="visualBasic__number">2</span>,&nbsp;System.Convert.ToInt32(barwidth)&nbsp;&#43;&nbsp;<span class="visualBasic__number">3</span>,&nbsp;System.Convert.ToInt32(barheight)&nbsp;&#43;&nbsp;<span class="visualBasic__number">3</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawLine(apen,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">15</span>,&nbsp;System.Convert.ToInt32(limitsline),&nbsp;System.Convert.ToInt32(xval),&nbsp;System.Convert.ToInt32(limitsline))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawLine(apen,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">15</span>,&nbsp;System.Convert.ToInt32(lowerlimitline),&nbsp;System.Convert.ToInt32(xval),&nbsp;System.Convert.ToInt32(lowerlimitline))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a1&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;Color.Blue,&nbsp;Color.Orange,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;f&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Font&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;arial&quot;</span>,&nbsp;<span class="visualBasic__number">10</span>,&nbsp;FontStyle.Bold,&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(uppervalue.ToString))),&nbsp;f,&nbsp;a1,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;System.Convert.ToInt32(limitsline)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(lovervalue.ToString))),&nbsp;f,&nbsp;a1,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;System.Convert.ToInt32(lowerlimitline)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(upperrange.ToString))),&nbsp;f,&nbsp;a1,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;<span class="visualBasic__number">9</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(underrange.ToString))),&nbsp;f,&nbsp;a1,&nbsp;System.Convert.ToInt32(xval)&nbsp;-&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(xval,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span>,&nbsp;barwidth,&nbsp;finaldisplayvalue&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>),&nbsp;backColors1,&nbsp;backColors2,&nbsp;Drawing.Drawing2D.LinearGradientMode.Vertical)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;a2&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">New</span>&nbsp;System.Drawing.Drawing2D.LinearGradientBrush(<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">19</span>),&nbsp;Color.Black,&nbsp;Color.Black,&nbsp;Drawing.Drawing2D.LinearGradientMode.Horizontal)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;f2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Font&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f2&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;arial&quot;</span>,&nbsp;<span class="visualBasic__number">12</span>,&nbsp;FontStyle.Bold,&nbsp;GraphicsUnit.Pixel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;inputValue&nbsp;&gt;=&nbsp;upperrange&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillRectangle(a,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(xval,&nbsp;<span class="visualBasic__number">10</span>,&nbsp;barwidth,&nbsp;barheight))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(inputValue.ToString))),&nbsp;f2,&nbsp;a2,&nbsp;System.Convert.ToInt32(xval)&nbsp;&#43;&nbsp;<span class="visualBasic__number">40</span>,&nbsp;yval&nbsp;-&nbsp;<span class="visualBasic__number">8</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;inputValue&nbsp;&lt;=&nbsp;underrange&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillRectangle(a,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(xval,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span>,&nbsp;barwidth,&nbsp;<span class="visualBasic__number">4</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(inputValue.ToString))),&nbsp;f2,&nbsp;a2,&nbsp;System.Convert.ToInt32(xval)&nbsp;&#43;&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillRectangle(a,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;RectangleF(xval,&nbsp;barheight&nbsp;-&nbsp;finaldisplayvalue&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span>,&nbsp;barwidth,&nbsp;finaldisplayvalue))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString((<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0:N3}&quot;</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(inputValue.ToString))),&nbsp;f2,&nbsp;a2,&nbsp;System.Convert.ToInt32(xval)&nbsp;&#43;&nbsp;<span class="visualBasic__number">40</span>,&nbsp;barheight&nbsp;-&nbsp;System.Convert.ToInt32(finaldisplayvalue))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__com">'&nbsp;End&nbsp;If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Try</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>&nbsp;6.After completion save,Build and run the project.</span></div>
</div>
<h2 class="endscriptcode"><strong>Adding Control Chart User Control</strong></h2>
<p>&nbsp;</p>
<p>2) Now we create a Windows application and add and test our &quot;SHANUControlChart_CNT&quot; User Control.</p>
<ol type="1">
<li>Create a new Windows project. </li><li>Open your form and then from<strong>&nbsp;Toolbox &gt; right click &gt; choose items &gt;&nbsp;</strong>browse select your user control dll and add.
</li><li><strong>&nbsp;</strong>Drag the User Control to your windows form. </li><li>Place all the USL/LSL and Measurement Textbox for input from the user.In Manual check button click pass&nbsp;all the data to user control using the public property as below.
</li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">private void btnDisplay_Click(object sender, EventArgs e)
       {
           shanuControlChart.USLData = txtusl.Text;
           shanuControlChart.LSLData = txtLSL.Text;
           shanuControlChart.NominalData = txtNominal.Text;
           shanuControlChart.MasterData = txtData.Text;
       }</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btnDisplay_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.USLData&nbsp;=&nbsp;txtusl.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.LSLData&nbsp;=&nbsp;txtLSL.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.NominalData&nbsp;=&nbsp;txtNominal.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.MasterData&nbsp;=&nbsp;txtData.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;5.In our demo program we have used the Timer for the random sample Measurement data result checking.I have used the &quot;btnRealTime&quot; as Toggle button.When first time clicked Enabled and Start the Timer and same button clicked
 again Stop the Timer.When timer is Start we have generated a random number and pass the different data to user control and check for the chart result.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">private void btnRealTime_Click(object sender, EventArgs e)
        {
            if (btnRealTime.Text == &quot;Real Time Data ON&quot;)
            {
                 btnRealTime.Text = &quot;Real Time Data OFF&quot;;
                 btnRealTime.ForeColor = Color.Red;
                 timer1.Enabled = true;
                 timer1.Start();
            }
            else
            {
                btnRealTime.Text = &quot;Real Time Data ON&quot;;
                btnRealTime.ForeColor = Color.DarkGreen;
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

' Timer Tick Event to check for the different random sample Measurement test data.

        private void timer1_Tick(object sender, EventArgs e)
        {
           Random rnd =new Random();

        Double rndval = rnd.Next(1, 20);

        txtData.Text = rndval.ToString(&quot;0.000&quot;);//FormatNumber(rndval.ToString(), 3, , 0)

        shanuControlChart.USLData = txtusl.Text;
        shanuControlChart.LSLData = txtLSL.Text;
        shanuControlChart.NominalData = txtNominal.Text;
        shanuControlChart.MasterData = txtData.Text;
        }</pre>
<div class="preview">
<pre class="vb">private&nbsp;void&nbsp;btnRealTime_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(btnRealTime.Text&nbsp;==&nbsp;<span class="visualBasic__string">&quot;Real&nbsp;Time&nbsp;Data&nbsp;ON&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnRealTime.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Real&nbsp;Time&nbsp;Data&nbsp;OFF&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnRealTime.ForeColor&nbsp;=&nbsp;Color.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1.Enabled&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnRealTime.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Real&nbsp;Time&nbsp;Data&nbsp;ON&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnRealTime.ForeColor&nbsp;=&nbsp;Color.DarkGreen;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1.Enabled&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1.<span class="visualBasic__keyword">Stop</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;Timer&nbsp;Tick&nbsp;Event&nbsp;to&nbsp;check&nbsp;for&nbsp;the&nbsp;different&nbsp;random&nbsp;sample&nbsp;Measurement&nbsp;test&nbsp;data.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;void&nbsp;timer1_Tick(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;rnd&nbsp;=new&nbsp;Random();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;rndval&nbsp;=&nbsp;rnd.<span class="visualBasic__keyword">Next</span>(<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__number">20</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtData.Text&nbsp;=&nbsp;rndval.ToString(<span class="visualBasic__string">&quot;0.000&quot;</span>);//FormatNumber(rndval.ToString(),&nbsp;<span class="visualBasic__number">3</span>,&nbsp;,&nbsp;<span class="visualBasic__number">0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.USLData&nbsp;=&nbsp;txtusl.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.LSLData&nbsp;=&nbsp;txtLSL.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.NominalData&nbsp;=&nbsp;txtNominal.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuControlChart.MasterData&nbsp;=&nbsp;txtData.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:2em">Source Code Files</span></div>
</div>
<p>&nbsp;</p>
<ul>
<li><span>SHANUControlChart_DEMO.zip</span> </li></ul>
<h1>More Information</h1>
<p><em><span>The main aim of this article is to create a simple and standard Control Bar Chart user control for the automobile industry.</span></em></p>