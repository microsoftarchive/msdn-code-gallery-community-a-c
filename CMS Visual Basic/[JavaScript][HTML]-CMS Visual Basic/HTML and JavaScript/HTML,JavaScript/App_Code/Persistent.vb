'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Namespace WebApplication
	Public Module Persistent

		Property PersistentString(ByVal Name As String, Optional ByVal Plugin As String = "General") As String
			Get
        Return LoadObject(GetType(String), Plugin & "_" & Name)
			End Get
			Set(ByVal value As String)
				SaveObject(value, Plugin & "_" & Name)
			End Set
		End Property

		Property PersistentInteger(ByVal Name As String, Optional ByVal Plugin As String = "General") As Integer
			Get
        Return LoadObject(GetType(Integer), Plugin & "_" & Name)
			End Get
			Set(ByVal value As Integer)
				SaveObject(value, Plugin & "_" & Name)
			End Set
		End Property

		Property PersistentSingle(ByVal Name As String, Optional ByVal Plugin As String = "General") As Single
			Get
        Return LoadObject(GetType(Integer), Plugin & "_" & Name)
			End Get
			Set(ByVal value As Single)
				SaveObject(value, Plugin & "_" & Name)
			End Set
		End Property


		Property PersistentDate(ByVal Name As String, Optional ByVal Plugin As String = "General") As Date
			Get
        Return LoadObject(GetType(Date), Plugin & "_" & Name)
			End Get
			Set(ByVal value As Date)
				SaveObject(value, Plugin & "_" & Name)
			End Set
		End Property

		Private Function KeyToNameFile(ByVal Text As String, Optional ByVal HexMark As String = "%") As String
      KeyToNameFile = Nothing
      If Text <> "" Then
        For Each Chr As Char In Text.ToCharArray
          Select Case Chr
            Case ":"c, "*"c, "?"c, "/"c, "\"c, "|"c, "<"c, ">"c, """"c
              KeyToNameFile &= HexMark & Right("00" & Hex(Asc(Chr)), 2)
            Case Else
              KeyToNameFile &= Chr
          End Select
        Next
      End If
		End Function

		Public Function SaveObject(ByVal Obj As Object, Optional ByRef Key As String = Nothing, Optional ByVal SetID As Boolean = False) As String
			Key = KeyToNameFile(Key)
      Dim Extension As String = Nothing
			Select Case Config.SerializationMode
				Case SerializationModeType.XML
					Extension = ".xml"
				Case SerializationModeType.Binary
					Extension = ".obj"
			End Select
			Dim SubDir As String = Obj.GetType.FullName
			If InStr(SubDir, "Version=") Then
				SubDir = Obj.GetType.Namespace & "+" & Obj.GetType.Name
			End If
			Dim Path As String = MapPath(ObjectSubDirectory & "/" & SubDir & "/")
			Dim Dir As New System.IO.DirectoryInfo(Path)
			If Dir.Exists = False Then
				Dir.Create()
			End If
			If Key Is Nothing Then
				Dim NewKey As Integer = 1
				For Each File As System.IO.FileInfo In Dir.GetFiles("*" & Extension)
					Dim Name As String = Left(File.Name, File.Name.Length - 4)
					If IsNumeric(Name) Then
						If Name >= NewKey Then
							NewKey = CInt(Name) + 1
						End If
					End If
				Next
				Key = NewKey
			End If
			If SetID Then
				Try
					Obj.id = Key
				Catch ex As Exception
					'Is not possible set ID at this object
				End Try
			End If
			'WriteAll(Serialize(Obj), Path & Key & ".obj")

			If Key.Length > 255 Then
				Err.Raise(65535, , "File name too long")
			Else
				Serialize(Obj, Path & Key & Extension)
			End If

			Return Key
		End Function

    Public Function LoadObject(Type As Type, Key As String) As Object
      'NOTE: Use GetType command to set Type value; Ex,: LoadObject(x,GetType(Note),key)
      Dim Obj As Object = Nothing
      Key = KeyToNameFile(Key)
      Dim Extension As String = Nothing
      Select Case Config.SerializationMode
        Case SerializationModeType.XML
          Extension = ".xml"
        Case SerializationModeType.Binary
          Extension = ".obj"
      End Select

      Dim SubDir As String = Type.FullName
      If InStr(SubDir, "Version=") Then
        SubDir = Type.Namespace & "+" & Type.Name
      End If
      Try
        Dim Path As String = MapPath(ObjectSubDirectory & "/" & SubDir & "/")
        Obj = Deserialize(Path & Key & Extension, Type)
      Catch ex As Exception
      End Try
      Return Obj
    End Function

    Public Function SaveCollection(ByVal Collection As Collections.Specialized.StringDictionary, Optional ByRef Key As String = Nothing, Optional ByVal SetID As Boolean = False) As String
      If Collection IsNot Nothing Then
        Dim Array As New ArrayList
        For Each KeyElement As String In Collection.Keys
          Array.Add(KeyElement) 'Add KEY
          Array.Add(Collection(KeyElement)) 'Add VALUE
        Next
        Return SaveObject(Array, Key, SetID)
      End If
      Return Nothing
    End Function

    Public Sub LoadCollection(ByRef Collection As Collections.Specialized.StringDictionary, ByRef Key As String)
      Dim Array As ArrayList = LoadObject(GetType(ArrayList), Key)
      If Array IsNot Nothing Then
        Collection = New Collections.Specialized.StringDictionary
        For ID As Integer = 0 To Array.Count - 1 Step 2
          Dim KeyElement As String = Array(ID)
          Dim Value As String = Array(ID + 1)
          Collection.Add(KeyElement, Value)
        Next
      End If
    End Sub

		Public Function DeleteObject(ByVal Type As Type, ByVal Key As String) As Boolean
			'NOTE: Use GetType command to set Type value; Ex,: DeleteObject(GetType(Note),key)
			Key = KeyToNameFile(Key)
			Dim SubDir As String = Type.FullName
			Dim Path As String = MapPath(ObjectSubDirectory & "/" & SubDir & "/")
      Dim Extension As String = Nothing
			Select Case Config.SerializationMode
				Case SerializationModeType.XML
					Extension = ".xml"
				Case SerializationModeType.Binary
					Extension = ".obj"
			End Select
			Return Delete(Path & Key & Extension)
		End Function
		Public Function AllKeyObject(ByVal Type As Type) As String()
			'NOTE: Use GetType command to set Type value; Ex,: AllKeyObject(GetType(Note))
			Dim Dir As System.IO.DirectoryInfo = ObjectDirectoryLocation(Type)
			Dim Keys As String()
			Try
        Dim Extension As String = Nothing
				Select Case Config.SerializationMode
					Case SerializationModeType.XML
						Extension = ".xml"
					Case SerializationModeType.Binary
						Extension = ".obj"
				End Select

				Dim Files As System.IO.FileInfo() = Dir.GetFiles("*" & Extension)
				ReDim Keys(Files.Length - 1)
				For n As Integer = 0 To Files.Length - 1
					Dim File As String = Files(n).Name
					Dim Name As String = Left(File, File.Length - 4)
					Keys(n) = Name
				Next
				Return Keys
			Catch ex As Exception
			End Try
      Return Nothing
    End Function

		Function ObjectDirectoryLocation(ByVal Type As Type) As System.IO.DirectoryInfo
			Dim SubDir As String = Type.FullName
			Dim Path As String = MapPath(ObjectSubDirectory & "/" & SubDir & "/")
			Return New System.IO.DirectoryInfo(Path)
		End Function
	End Module

End Namespace