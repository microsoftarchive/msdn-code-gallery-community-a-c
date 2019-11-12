'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Imports Microsoft.VisualBasic
Namespace WebApplication
	Public Module WeatherManager
		Private Function Report(ByVal WeatherCode As String) As System.Xml.XmlDocument
			If CacheReport.ContainsKey(WeatherCode) Then
				Dim RecentReport As ArchiveReport = CacheReport(WeatherCode)
        Return RecentReport.Report
      End If
      Return Nothing
    End Function
		Private CacheReport As New System.Collections.Generic.SortedDictionary(Of String, ArchiveReport)
		Private Class ArchiveReport
			Public Update As Date
			Public Report As System.Xml.XmlDocument
		End Class
		Class Weather
			Public Exist As Boolean
			Public Condition As ConditionCodes = 3200
			Public Temperature As Single
			Public Pressure As Single
			Public RelativeHumidity As Single
			Public Visibility As Integer
			Public Wind As Integer
			Public WindDegrees As Integer
			Public HrefIcon As String
			Public Latitude As Single
			Public Longitude As Single
			Public Sub New(ByVal WeatherCode As String)
				Dim WeatherReport As System.Xml.XmlDocument
				'If Release() Then
				WeatherReport = Report(WeatherCode)
				'End If
				If WeatherReport Is Nothing Then
					Exist = False
				Else
					Exist = True
					Try
						Dim Channel As System.Xml.XmlNode = WeatherReport.SelectSingleNode("//channel")
						Dim Image As System.Xml.XmlNode = WeatherReport.SelectSingleNode("//image")
						Dim Item As System.Xml.XmlNode = WeatherReport.SelectSingleNode("//item")

						For Each Node As System.Xml.XmlNode In Channel
							Select Case Node.Name
								Case "yweather:atmosphere"
									Pressure = Node.Attributes("pressure").InnerText
									RelativeHumidity = Node.Attributes("humidity").InnerText
									Visibility = Node.Attributes("visibility").InnerText
								Case "yweather:wind"
									Wind = Node.Attributes("speed").InnerText
									WindDegrees = Node.Attributes("direction").InnerText
							End Select
						Next

						For Each Node As System.Xml.XmlNode In Item
							Select Case Node.Name
								Case "geo:lat"
									Latitude = Val(Node.InnerText)
								Case "geo:long"
									Longitude = Val(Node.InnerText)
								Case "yweather:condition"
									Temperature = Node.Attributes("temp").InnerText
									Condition = Node.Attributes("code").InnerText
							End Select
						Next

						Dim GTM As Integer = Latitude / 15
						Dim TimeInLocality As Date = Now.ToUniversalTime.AddHours(GTM)

						Dim Night As Boolean
						Select Case TimeInLocality.Hour
							Case 20, 21, 22, 23, 0, 1, 2, 3, 4, 5, 6, 7
								Night = True
							Case Else
								Night = False
						End Select
						If Condition <> ConditionCodes.not_available Then
							HrefIcon = ImgagesResources & "/weather/" & Condition & ".gif"
						End If
					Catch ex As Exception
						'Error 
					End Try
				End If
			End Sub
			Enum ConditionCodes
				tornado = 0
				tropical_storm = 1
				hurricane = 2
				severe_thunderstorms = 3
				thunderstorms = 4
				mixed_rain_and_snow = 5
				mixed_rain_and_sleet = 6
				mixed_snow_and_sleet = 7
				freezing_drizzle = 8
				drizzle = 9
				freezing_rain = 10
				showers = 11
				showers2 = 12
				snow_flurries = 13
				light_snow_showers = 14
				blowing_snow = 15
				snow = 16
				hail = 17
				sleet = 18
				dust = 19
				foggy = 20
				haze = 21
				smoky = 22
				blustery = 23
				windy = 24
				cold = 25
				cloudy = 26
				mostly_cloudy_night = 27
				mostly_cloudy_day = 28
				partly_cloudy_night = 29
				partly_cloudy_day = 30
				clear_night = 31
				sunny = 32
				fair_night = 33
				fair_day = 34
				mixed_rain_and_hail = 35
				hot = 36
				isolated_thunderstorms = 37
				scattered_thunderstorms = 38
				scattered_thunderstorms2 = 39
				scattered_showers = 40
				heavy_snow = 41
				scattered_snow_showers = 42
				heavy_snow2 = 43
				partly_cloudy = 44
				thundershowers = 45
				snow_showers = 46
				isolated_thundershowers = 47
				not_available = 3200
			End Enum
		End Class
		Class WeatherLocality
			Public WeatherCode As String
			Public LocalityName As String
			Public Sub New(ByVal WeatherCode As String, ByVal LocalityName As String)
				Me.WeatherCode = WeatherCode
				Me.LocalityName = LocalityName
			End Sub
			Public Sub New()
			End Sub
		End Class
		Public WithEvents Updater As New Timers.Timer(1000 * 60 * 60 * 1)	'Update every 1 hour

		Private Sub Updater_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Updater.Elapsed
			UpdateWeather()
		End Sub
		Sub UpdateWeather()
			For Each WeatherCode As String In AllWeatherCodesUsedInSubSites()
				'Dim WeatherCode As String = "ITXX0090"
				Try
					Dim WC As New System.Net.WebClient
					Dim NewReport As New System.Xml.XmlDocument
					Dim Parameter As String
					If Val(WeatherCode).ToString = WeatherCode Then
						Parameter = "w="
					Else
						Parameter = "p="
					End If
					NewReport.Load(WC.OpenRead("http://xml.weather.yahoo.com/forecastrss?u=c&" & Parameter & WeatherCode))
					Dim Archive As New ArchiveReport
					Archive.Update = Now
					Archive.Report = NewReport
					If CacheReport.ContainsKey(WeatherCode) Then
						CacheReport.Remove(WeatherCode)
					End If
					CacheReport.Add(WeatherCode, Archive)
				Catch ex As Exception
					'Web Service offline
					Exit Sub
				End Try
			Next
		End Sub
		Function AllWeatherCodesUsedInSubSites() As System.Collections.Specialized.StringCollection
			'Find all WeatherCode used in subsites configuration
			Dim WeatherCodes As New System.Collections.Specialized.StringCollection
			For Each Config As SubSite In AllSubSite()
				If Not Config.Weathers Is Nothing Then
					For Each WeatherLocality As WeatherLocality In Config.Weathers
						Dim WeatherCode As String = WeatherLocality.WeatherCode
						If Not WeatherCodes.Contains(WeatherCode) Then
							WeatherCodes.Add(WeatherCode)
						End If
					Next
				End If
			Next
			Return WeatherCodes
		End Function
	End Module
End Namespace
