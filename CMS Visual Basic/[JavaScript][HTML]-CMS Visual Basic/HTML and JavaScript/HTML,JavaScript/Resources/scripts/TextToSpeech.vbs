' vbscript File
'Value replaced from web application:
'$character : Valid values is: "genie","merlin","peedy","robby"
'$LanguageID : ' Laguage specification, see here http://www.microsoft.com/msagent/dev/docs/autodownload.asp

Dim AgentCharacter
Dim LoadRequestUNC
Dim LoadRequestURL
Dim GetShowAnimation
Dim Character
Character = "$character"

Sub Window_OnLoad
  LoadCharacter
End Sub

Sub Agent_RequestComplete(ByVal Request)
  If Request = LoadRequestURL Then
    If Request.Status = 1 Then
  	ElseIf Request.Status = 0 Then
      Set AgentCharacter = Agent.Characters(Character)
      Set GetShowAnimation = AgentCharacter.Get ("state", "showing, speaking")
      AgentCharacter.Get "animation", "Blink, Confused, Greet, Pleased, Explain, Think, GestureRight, GestureLeft, GestureUp, Idle1_1, Idle2_2, Announce, Process, Uncertain", False
    End If
  End If
End Sub

Sub LoadCharacter
 On Error Resume Next
  Set LoadRequestUNC = Agent.Characters.Load (Character, Character + ".acs")
  If LoadRequestUNC.Status <> 0 Then
    Set LoadRequestURL = Agent.Characters.Load (Character, "http://www.microsoft.com/msagent/chars/" + Character + "/" + Character + ".acf") 
  Else 
    Set AgentCharacter = Agent.Characters(Character)
  End If
End Sub

'Use SpeechText commend to speek a text
Dim Fl
Function SpeechText(Text)
    SpeechTextReset
    SpeechTextNoReset(Text)
    SpeekEnd
end Function

Function SpeechTextReset
  AgentCharacter.Commands.RemoveAll
  AgentCharacter.Commands.Add "ACO", "Advanced Character Options"
  AgentCharacter.LanguageID = $LanguageID  
  AgentCharacter.MoveTo window.screenLeft+450, window.screenTop+225
  SpeekAnnounce
End Function

Function SpeechTextNoReset(Text)
    If Text<>"" Then
        Fl=False
        AgentCharacter.Show
	    Text=Replace(Text,"/"," ")
	    Texts = split(Text,".")
	    For N=0 to Ubound(texts)
		    SpeekPharagraph
		    Paragraph=Texts(n)
		    Phrases=split(Paragraph,vbcr)
		    For N2=0 to Ubound(Phrases)
			    SpeekPhrase
			    Phrase=Phrases(N2)
			    SubPhrases=split(Phrase,",")
			    For N3=0 to Ubound(SubPhrases)
				    SubPhrase=SubPhrases(N3)
				    If Trim(SubPhrase)<>"" Then
                        Fl=True
					    AgentCharacter.Speak("\spd=160\"&SubPhrase)
				    End If
			    Next
		    Next
    	Next	
    End If
End Function

Sub SpeekAnnounce
    AgentCharacter.play "Announce"
End sub

Sub SpeekPhrase
    If Fl Then
        Fl=False
	    AgentCharacter.play "Blink"
    End If
End sub

Sub SpeekPharagraph
    If Fl Then
        Fl=False
	    Min=0:Max=4
	    Rn=Int((Max - Min + 1) *  Rnd + Min)
	    Select Case Rm
		    Case 1
			    AgentCharacter.play "Pleased"	
		    Case 2
			    AgentCharacter.play "Read"
		    Case Else
			    AgentCharacter.play "Explain"
    	End Select
    End if
End sub

Sub SpeekEnd
	AgentCharacter.play "Greet"
End Sub

Function XmlSrc(Src)
    document.all.XmlSpeech.src=Src
End Function

Sub SpeechXml
    Set RecordSet = document.all.XmlSpeech.RecordSet
    SpeechTextReset
    Do until RecordSet.Eof
        AgentCharacter.play "Read"
        'For N1=0 To recordset.fields.Count-1
        '    SpeechTextNoReset(recordset.fields(N1).value)
        'Next
        SpeechTextNoReset(recordset.fields(recordset.fields.Count-1).value)
        RecordSet.MoveNext
    loop
    SpeekEnd
End Sub