Imports System.IO
Imports System.Text

Public Class CyrillicToRomanFallback : Inherits EncoderFallback

   Private table As Dictionary(Of Char, String)

   Public Sub New()
      table = New Dictionary(Of Char, String)
      ' Define mappings.
      ' Uppercase modern Cyrillic characters.
      table.Add(ChrW(&H410), "A")
      table.Add(ChrW(&H411), "B")
      table.Add(ChrW(&H412), "V")
      table.Add(ChrW(&H413), "G")
      table.Add(ChrW(&H414), "D")
      table.Add(ChrW(&H415), "E")
      table.Add(ChrW(&H416), "Zh")
      table.Add(ChrW(&H417), "Z")
      table.Add(ChrW(&H418), "I")
      table.Add(ChrW(&H419), "I")
      table.Add(ChrW(&H41A), "K")
      table.Add(ChrW(&H41B), "L")
      table.Add(ChrW(&H41C), "M")
      table.Add(ChrW(&H41D), "N")
      table.Add(ChrW(&H41E), "O")
      table.Add(ChrW(&H41F), "P")
      table.Add(ChrW(&H420), "R")
      table.Add(ChrW(&H421), "S")
      table.Add(ChrW(&H422), "T")
      table.Add(ChrW(&H423), "U")
      table.Add(ChrW(&H424), "F")
      table.Add(ChrW(&H425), "Kh")
      table.Add(ChrW(&H426), "Ts")
      table.Add(ChrW(&H427), "Ch")
      table.Add(ChrW(&H428), "Sh")
      table.Add(ChrW(&H429), "Shch")
      table.Add(ChrW(&H42A), "'")    ' Hard sign              
      table.Add(ChrW(&H42B), "Ye")
      table.Add(ChrW(&H42C), "'")    ' Soft sign
      table.Add(ChrW(&H42D), "E")
      table.Add(ChrW(&H42E), "Iu")
      table.Add(ChrW(&H42F), "Ia")
      ' Lowercase modern Cyrillic characters.
      table.Add(ChrW(&H430), "a")
      table.Add(ChrW(&H431), "b")
      table.Add(ChrW(&H432), "v")
      table.Add(ChrW(&H433), "g")
      table.Add(ChrW(&H434), "d")
      table.Add(ChrW(&H435), "e")
      table.Add(ChrW(&H436), "zh")
      table.Add(ChrW(&H437), "z")
      table.Add(ChrW(&H438), "i")
      table.Add(ChrW(&H439), "i")
      table.Add(ChrW(&H43A), "k")
      table.Add(ChrW(&H43B), "l")
      table.Add(ChrW(&H43C), "m")
      table.Add(ChrW(&H43D), "n")
      table.Add(ChrW(&H43E), "o")
      table.Add(ChrW(&H43F), "p")
      table.Add(ChrW(&H440), "r")
      table.Add(ChrW(&H441), "s")
      table.Add(ChrW(&H442), "t")
      table.Add(ChrW(&H443), "u")
      table.Add(ChrW(&H444), "f")
      table.Add(ChrW(&H445), "kh")
      table.Add(ChrW(&H446), "ts")
      table.Add(ChrW(&H447), "ch")
      table.Add(ChrW(&H448), "sh")
      table.Add(ChrW(&H449), "shch")
      table.Add(ChrW(&H44A), "'")   ' Hard sign
      table.Add(ChrW(&H44B), "yi")
      table.Add(ChrW(&H44C), "'")   ' Soft sign
      table.Add(ChrW(&H44D), "e")
      table.Add(ChrW(&H44E), "iu")
      table.Add(ChrW(&H44F), "ia")
   End Sub

   Public Overrides Function CreateFallbackBuffer() As System.Text.EncoderFallbackBuffer
      Return New CyrillicToRomanFallbackBuffer(table)
   End Function

   Public Overrides ReadOnly Property MaxCharCount As Integer
      Get
         Return 4                  ' Maximum is "Shch" and "shch"
      End Get
   End Property
End Class

Public Class CyrillicToRomanFallbackBuffer : Inherits EncoderFallbackBuffer
   Private table As Dictionary(Of Char, String)
   Private bufferIndex As Integer
   Private buffer As String
   Private leftToReturn As Integer

   Friend Sub New(ByVal table As Dictionary(Of Char, String))
      Me.table = table
      Me.bufferIndex = -1
      Me.leftToReturn = -1
   End Sub

   Public Overloads Overrides Function Fallback(ByVal charUnknownHigh As Char, ByVal charUnknownLow As Char, ByVal index As Integer) As Boolean
      ' There's no need to handle surrogates.
      Return False
   End Function

   Public Overloads Overrides Function Fallback(ByVal charUnknown As Char, ByVal index As Integer) As Boolean
      If charUnknown >= ChrW(&H410) And charUnknown <= ChrW(&H44F) Then
         buffer = table.Item(charUnknown)
         leftToReturn = buffer.Length - 1
         bufferIndex = -1
         Return True
      End If
      Return False
   End Function

   Public Overrides Function GetNextChar() As Char
      Dim charToReturn As Char
      If leftToReturn >= 0 Then
         leftToReturn -= 1
         bufferIndex += 1
         charToReturn = buffer(bufferIndex)
      Else
         charToReturn = ChrW(0)
      End If
      Return charToReturn
   End Function

   Public Overrides Function MovePrevious() As Boolean
      If bufferIndex > 0 Then
         bufferIndex -= 1
         leftToReturn += 1
         Return True
      Else
         Return False
      End If
   End Function

   Public Overrides ReadOnly Property Remaining As Integer
      Get
         Return leftToReturn
      End Get
   End Property
End Class