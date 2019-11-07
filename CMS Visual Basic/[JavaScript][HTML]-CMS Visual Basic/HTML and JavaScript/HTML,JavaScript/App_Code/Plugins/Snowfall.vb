'By Andrea Bruno
Namespace WebApplication.Plugin		'Standard namespace obbligatory for all plugins
  Public Class Snowfall
    Public Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
    Shared Function Initialize() As PluginManager.Plugin
      If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, , , , , GetType(SnowfallConfiguration))
      Return Plugin
    End Function
    Shared Sub New()
      Initialize()
    End Sub

    Private Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
      Select Case Language
        Case LanguageManager.Language.Italian
          If ShortDescription Then
            Return "Nevicata"
          Else
            Return "Aggiungo la neve al sito web"
          End If
        Case Else
          If ShortDescription Then
            Return "Snowfall"
          Else
            Return "Add the snow on the website"
          End If
      End Select
    End Function

    Private Shared Sub Plugin_MasterPagePreRender(ByVal MasterPage As Components.MasterPage) Handles Plugin.MasterPagePreRender
      Dim Configuration As SnowfallConfiguration = Plugin.LoadConfiguration()
      If HttpContext.Current.Request.Browser.EcmaScriptVersion.Major >= 1 Then 'Verify is browser support javascript
        Dim ShadowColor As String
        If Configuration.BetterForDarkBackground Then
          ShadowColor = "fff"
        Else
          ShadowColor = "888"
        End If
        'This JavaScript is under copyright by Andrea Bruno. Don't use this in another web application! OK?
        MasterPage.MainContainer.Parent.Parent.Controls.Add(Script("/* © " & CopyrightLink & " */function Snow(){doc_width=window.innerWidth;doc_height=window.innerHeight;for(i=0;i<no;++i){yp[i]+=sty[i];if(yp[i]>doc_height-70){xp[i]=Math.random()*(doc_width-am[i]-30);yp[i]=0;stx[i]=.02+Math.random()/10}dx[i]+=stx[i];snw[i].style.pixelTop=window.pageYOffset+yp[i];snw[i].style.pixelLeft=xp[i]+am[i]*Math.sin(dx[i])}setTimeout(""Snow()"",20)}var dx,xp,yp;var am,stx,sty;var i;dx=new Array;xp=new Array;yp=new Array;am=new Array;stx=new Array;sty=new Array;snw=new Array;var doc_width=window.innerWidth;var doc_height=window.innerHeight;var no=window.innerHeight/50;var Speed=" & Configuration.Speed & ";var Speed2=Speed*2.5;for(i=0;i<no;++i){dx[i]=0;xp[i]=Math.random()*(doc_width-170);yp[i]=Math.random()*doc_height;am[i]=Math.random()*20;stx[i]=.02+Math.random()/10;var Sizesnow;if(Math.random()<.7){sty[i]=Speed+Math.random()*Speed;Sizesnow=""200%""}else{sty[i]=Speed2+Math.random()*Speed2;Sizesnow=""300%""}document.write('<div id=""dot'+i+'"" style=""text-shadow: 0px 0px 20px #" & ShadowColor & ";color:#eee; font-size:'+Sizesnow+';position: absolute; z-index: 101; visibility: visible; top: 15px; left: 15px;"">❄</div>');snw[i]=document.getElementById(""dot""+i)}Snow()", ScriptLanguage.javascript))
      End If
    End Sub

    Class SnowfallConfiguration
      Public Speed As SnowfallSpeed = SnowfallSpeed.Normal
      Public BetterForDarkBackground As Boolean = False
      Enum SnowfallSpeed
        Slow = 1
        Normal = 2
        Fast = 3
      End Enum
    End Class
  End Class

End Namespace