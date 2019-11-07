'Clock plugin code
'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins

	Public Class Clock
		Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
		Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , PluginManager.Plugin.Characteristics.StandardPlugin, GetType(ClockConfiguration))
			Return Plugin
		End Function
		Shared Sub New()
			Initialize()
		End Sub

		Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
			If Language = LanguageManager.Language.Italian Then
				If ShortDescription Then
					Return "Orologio"
				Else
					Return "Plugin per aggiungere l'orologio classico delle stazioni ferroviare svizzere"
				End If
			Else
				If ShortDescription Then
					Return "Clock"
				Else
					Return "Plugin to add the classic clock of Swiss railway stations"
				End If
			End If
		End Function

		Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
			Dim Configuration As ClockConfiguration = Plugin.LoadConfiguration()
			Select Case Configuration.Placing
				Case ClockConfiguration.PageCollocation.TopOfPageAlignedToLeft
					MasterPage.TopToLeft.Controls.AddAt(0, Configuration.Code)
				Case ClockConfiguration.PageCollocation.TopOfPageAlignedToRight
					MasterPage.Top.Controls.AddAt(0, Configuration.Code)
				Case ClockConfiguration.PageCollocation.IntoTheToolsbar
					MasterPage.UserToolsBar.Controls.Add(Configuration.Code)
				Case ClockConfiguration.PageCollocation.LeftSidebar
					MasterPage.Left.Controls.Add(Configuration.Code)
				Case ClockConfiguration.PageCollocation.RightSidebar
					MasterPage.Right.Controls.Add(Configuration.Code)
			End Select
		End Sub

		Class ClockConfiguration
			Public Placing As PageCollocation
			Public Size As Integer = 100
			Public Color As String = "black"
			Public SecondColor As String = "red"
			Public TimeZone As SelectTimeZone
			Public TimeZoneOffset As Single
			Public Label As String
			Function Code() As Control
        Dim TextWriter As String = Nothing
				If Label <> "" Then
					Dim FontSize As Integer = Size / 10
					'Dim LineWidth As Integer = Size / 75 : If LineWidth = 0 Then LineWidth = 1
					TextWriter = ";var ct=c.canvas.getContext('2d');ct.font='bold " & FontSize & "px courier';ct.fillText('" & Label & "', " & -Int(FontSize * Label.Length / 32 * 10) & ", " & Size / 5 & ");"
				End If
				If TimeZone Then
					Return New LiteralControl("<canvas id='c' width='" & Size & "' height='" & Size & "'></canvas><script type='text/javascript'>var c=(e=document.getElementById('c')).getContext('2d'),w=e.width,h=e.height,r=Math.min(w,h)*.4,p=Math.PI,q=p/30,b='" & Color & "',d='" & SecondColor & "';A();function A(){c.clearRect(0,0,w,h);S();c.translate(w/2,h/2);S();T();B(b);c.lineWidth=r*.07;c.arc(0,0,r*1.1,0,2*p,1);c.stroke();R();for(i=0;i<60;i++){S();c.rotate(i*q);(i%5)?P(.013,-1,.013,-.92,b):P(.035,-1,.035,-.75,b);R()}" & TextWriter & "t=new Date();u=t.getTime()+t.getTimezoneOffset()*60000;t=new Date(u+(3600000*" & Me.TimeZoneOffset.ToString(New Globalization.CultureInfo("en-US")) & "));m=t.getMinutes();S();c.rotate(t.getHours()*q*5+m*q/12);T();P(.05,-.6,.05,.26,b);R();S();c.rotate(m*q);T();P(.035,-.93,.05,.25,b);R();S();c.rotate(Math.min((t.getSeconds()+t.getMilliseconds()/1000)*1.02,60)*q);T();P(.018,-.6,.024,.35,d);B(d);c.arc(0,-r*.64,r*.1,0,2*p,1);c.fill();R();R();window.setTimeout('A()',200)}function S(){c.save()}function R(){c.restore()}function T(){c.shadowColor='rgba(0,0,0,.3)';c.shadowOffsetX=c.shadowOffsetY=c.shadowBlur=r*.035}function P(u,v,x,y,z){B(z);c.moveTo(r*u,r*v);L(-u,v);L(-x,y);L(x,y);L(u,v);c.fill()}function L(x,y){c.lineTo(r*x,r*y)}function B(z){c.beginPath();c.strokeStyle=c.fillStyle=z;}</script>")
				Else
					Return New LiteralControl("<canvas id='c' width='" & Size & "' height='" & Size & "'></canvas><script type='text/javascript'>var c=(e=document.getElementById('c')).getContext('2d'),w=e.width,h=e.height,r=Math.min(w,h)*.4,p=Math.PI,q=p/30,b='" & Color & "',d='" & SecondColor & "';A();function A(){c.clearRect(0,0,w,h);S();c.translate(w/2,h/2);S();T();B(b);c.lineWidth=r*.07;c.arc(0,0,r*1.1,0,2*p,1);c.stroke();R();for(i=0;i<60;i++){S();c.rotate(i*q);(i%5)?P(.013,-1,.013,-.92,b):P(.035,-1,.035,-.75,b);R()}" & TextWriter & "t=new Date();m=t.getMinutes();S();c.rotate(t.getHours()*q*5+m*q/12);T();P(.05,-.6,.05,.26,b);R();S();c.rotate(m*q);T();P(.035,-.93,.05,.25,b);R();S();c.rotate(Math.min((t.getSeconds()+t.getMilliseconds()/1000)*1.02,60)*q);T();P(.018,-.6,.024,.35,d);B(d);c.arc(0,-r*.64,r*.1,0,2*p,1);c.fill();R();R();window.setTimeout('A()',200)}function S(){c.save()}function R(){c.restore()}function T(){c.shadowColor='rgba(0,0,0,.3)';c.shadowOffsetX=c.shadowOffsetY=c.shadowBlur=r*.035}function P(u,v,x,y,z){B(z);c.moveTo(r*u,r*v);L(-u,v);L(-x,y);L(x,y);L(u,v);c.fill()}function L(x,y){c.lineTo(r*x,r*y)}function B(z){c.beginPath();c.strokeStyle=c.fillStyle=z;}</script>")
				End If
			End Function
			Enum SelectTimeZone
				ShowTheLocalTime
				UseTimeZone
			End Enum
			Enum PageCollocation
				TopOfPageAlignedToLeft
				TopOfPageAlignedToRight
				IntoTheToolsbar
				LeftSidebar
				RightSidebar
			End Enum
		End Class

	End Class

End Namespace