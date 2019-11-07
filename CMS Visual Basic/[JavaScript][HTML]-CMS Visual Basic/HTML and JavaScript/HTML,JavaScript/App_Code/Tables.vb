'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Namespace WebApplication
	Public Module Tables
		Public Countries As Collections.Generic.List(Of Country) = LoadCountries()
		Public Cities As Collections.Generic.Dictionary(Of String, Collections.Generic.List(Of City)) = LoadCities()
		Public Regions As Collections.Generic.Dictionary(Of Integer, Region) = LoadRegions()
		Class City
			Public CountryID As Integer
			Public RegionID As Integer
			Public City As String
			Public Latitude As Single
			Public Longitude As Single
		End Class
		Class Country
			Public CountryId As Integer
			Public Country As String
			Public Iso2 As String
		End Class
		Class Region
			Public RegionId As Integer
			Public Region As String
		End Class

		Private Function LoadCities() As Collections.Generic.Dictionary(Of String, Collections.Generic.List(Of City))
			Dim Cities As New Collections.Generic.Dictionary(Of String, Collections.Generic.List(Of City))
			Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")

			'Dim Cities As New Collections.Generic.List(Of City)
			Dim Records() As String = ReadAllRows(MapPath(ReadWriteDirectory & "\Cities.txt"))
			Dim First As Boolean = True
			For Each Record As String In Records
				If First Then
					'Skip first record (description)
					First = False
				Else
					Dim Fields() As String = Split(Record, ",")
					Dim City As New City
					City.CountryID = Fields(1)
					City.RegionID = Fields(2)
					City.City = StringValue(Fields(3))
					City.Latitude = Val(StringValue(Fields(4)))
					City.Longitude = Val(StringValue(Fields(5)))
					Dim Key As String = LCase(WordsWithSingleSpaceDelimiter(City.City))
					If Cities.ContainsKey(Key) Then
						Cities(Key).Add(City)
					Else
						Dim Node As New Collections.Generic.List(Of City)
						Node.Add(City)
						Cities.Add(Key, Node)
					End If
				End If
			Next
			Return Cities
		End Function

		Private Function LoadCountries() As Collections.Generic.List(Of Country)
			Dim Countries As New Collections.Generic.List(Of Country)
			Dim Records() As String = ReadAllRows(MapPath(ReadWriteDirectory & "\Countries.txt"))
			Dim First As Boolean = True
			For Each Record As String In Records
				If First Then
					'Skip first record (description)
					First = False
				Else
					Dim Fields() As String = Split(Record, ",")
					Dim Country As New Country
					Country.CountryId = Fields(0)
					Country.Country = StringValue(Fields(1))
					Country.Iso2 = StringValue(Fields(3))
					Countries.Add(Country)
				End If
			Next
			Return Countries
		End Function

		Private Function LoadRegions() As Collections.Generic.Dictionary(Of Integer, Region)
			Dim Regions As New Collections.Generic.Dictionary(Of Integer, Region)
			Dim Records() As String = ReadAllRows(MapPath(ReadWriteDirectory & "\Regions.txt"))
			Dim First As Boolean = True
			For Each Record As String In Records
				If First Then
					'Skip first record (description)
					First = False
				Else
					Dim Fields() As String = Split(Record, ",")
					Dim Region As New Region
					Region.RegionId = Fields(0)
					Region.Region = StringValue(Fields(2))
					Regions.Add(Region.RegionId, Region)
				End If
			Next
			Return Regions
		End Function

		Private Function StringValue(ByVal Field As String) As String
			Return Mid(Field, 2, Field.Length - 2)
		End Function

		Function FindCityQuick(ByVal CityName As String) As Collections.Generic.List(Of City)
			'NOTE Use function WordsWithSingleSpaceDelimiter to obtain city name without not letters: Ex: "St. Petersburg" > "St Petersburg"
			Dim Key As String = LCase(CityName)
			If Cities.ContainsKey(Key) Then
				Return Cities(Key)
			End If
      Return Nothing
    End Function
		Function FindCity(ByVal CityNameOnlyLetters As String) As Collections.Generic.List(Of City)
			Dim Key As String = LCase(WordsWithSingleSpaceDelimiter(CityNameOnlyLetters))
			If Cities.ContainsKey(Key) Then
				Return Cities(Key)
			End If
      Return Nothing
    End Function
		Function CountryName(ByVal City As City) As String
			Return Countries(City.CountryID - 1).Country
		End Function
		Function RegionName(ByVal City As City) As String
			Return Regions(City.RegionID).Region
		End Function
	End Module
End Namespace