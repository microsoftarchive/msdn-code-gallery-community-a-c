Imports Bing.Maps
Imports System.Collections.Generic
Imports Windows.UI.Xaml

Namespace AnimatedMaps.Animations
    Public Class PathAnimation
#Region "Private Properties"

        Private Const _delay As Integer = 30
        Private Const EARTH_RADIUS_KM As Double = 6378.1

        Private _timerId As DispatcherTimer

        Private _path As LocationCollection
        Private _isGeodesic As Boolean = False

        Private _intervalLocs As LocationCollection
        Private _intervalIdx As List(Of Integer)

        Private _duration As System.Nullable(Of Integer)
        Private _frameIdx As Integer = 0
        Private _isPaused As Boolean

#End Region

#Region "Constructor"

        ''' <summary>This class extends from the BaseAnimation class and cycles through a set of coordinates over a period of time, calculating mid-point coordinates along the way.</summary>
        ''' <param name="path">An array of locations to cycle through.</param>
        ''' <param name="intervalCallback">A function that is called when a frame is to be rendered. This callback function recieves four values; current cordinate, index on path and frame index.</param>
        ''' <param name="isGeodesic">Indicates if the path should follow the curve of the earth.</param>
        ''' <param name="duration">Length of time in ms that the animation should run for. Default is 1000 ms.</param>
        Public Sub New(path As LocationCollection, intervalCallback As IntervalCallback, isGeodesic As Boolean, duration As System.Nullable(Of Integer))
            _path = path
            _isGeodesic = isGeodesic
            _duration = duration

            PreCalculate()

            _timerId = New DispatcherTimer()
            _timerId.Interval = New TimeSpan(0, 0, 0, 0, _delay)

            AddHandler _timerId.Tick, Sub(s, a)
                                          If Not _isPaused Then
                                              Dim progress As Double = CDbl(_frameIdx * _delay) / CDbl(_duration.Value)

                                              If progress > 1 Then
                                                  progress = 1
                                              End If

                                              intervalCallback(_intervalLocs(_frameIdx), _intervalIdx(_frameIdx), _frameIdx)

                                              If progress = 1 Then
                                                  _timerId.[Stop]()
                                              End If

                                              _frameIdx += 1
                                          End If
                                      End Sub
        End Sub

#End Region

#Region "Public Delgates"

        Public Delegate Sub IntervalCallback(loc As Location, pathIdx As Integer, frameIdx As Integer)

#End Region

#Region "Public Properties"

        Public Property Path() As LocationCollection
            Get
                Return _path
            End Get
            Set(value As LocationCollection)
                _path = value
                PreCalculate()
            End Set
        End Property

        Public Property IsGeodesic() As Boolean
            Get
                Return _isGeodesic
            End Get
            Set(value As Boolean)
                _isGeodesic = value
                PreCalculate()
            End Set
        End Property

        Public Property Duration() As System.Nullable(Of Integer)
            Get
                Return _duration
            End Get
            Set(value As System.Nullable(Of Integer))
                _duration = value
                PreCalculate()
            End Set
        End Property

#End Region

#Region "Public Methods"

        Public Sub Play()
            _frameIdx = 0
            _isPaused = False
            _timerId.Start()
        End Sub

        Public Sub Pause()
            _isPaused = True
        End Sub

        Public Sub [Stop]()
            If _timerId.IsEnabled Then
                _frameIdx = 0
                _isPaused = False
                _timerId.[Stop]()
            End If
        End Sub

#End Region

#Region "Private Methods"

        Private Sub PreCalculate()
            'Stop the timer
            If _timerId IsNot Nothing AndAlso _timerId.IsEnabled Then
                _timerId.[Stop]()
            End If

            _duration = If((_duration.HasValue AndAlso _duration.Value > 0), _duration, 150)

            _intervalLocs = New LocationCollection()
            _intervalIdx = New List(Of Integer)()

            _intervalLocs.Add(_path(0))
            _intervalIdx.Add(0)

            Dim dlat As Double, dlon As Double
            Dim totalDistance As Double = 0

            If _isGeodesic Then
                'Calcualte the total distance along the path in KM's.
                For i As Integer = 0 To _path.Count - 2
                    totalDistance += HaversineDistance(_path(i), _path(i + 1))
                Next
            Else
                'Calcualte the total distance along the path in degrees.
                For i As Integer = 0 To _path.Count - 2
                    dlat = _path(i + 1).Latitude - _path(i).Latitude
                    dlon = _path(i + 1).Longitude - _path(i).Longitude

                    totalDistance += Math.Sqrt(dlat * dlat + dlon * dlon)
                Next
            End If

            Dim frameCount As Integer = CInt(Math.Ceiling(CDbl(_duration.Value) / CDbl(_delay)))
            Dim idx As Integer = 0
            Dim progress As Double

            'Pre-calculate step points for smoother rendering.
            For f As Integer = 0 To frameCount - 1
                progress = CDbl(f * _delay) / CDbl(_duration.Value)

                Dim travel As Double = progress * totalDistance
                Dim alpha As Double = 0
                Dim dist As Double = 0
                Dim dx As Double = travel

                For i As Integer = 0 To _path.Count - 2

                    If _isGeodesic Then
                        dist += HaversineDistance(_path(i), _path(i + 1))
                    Else
                        dlat = _path(i + 1).Latitude - _path(i).Latitude
                        dlon = _path(i + 1).Longitude - _path(i).Longitude
                        alpha = Math.Atan2(dlat * Math.PI / 180, dlon * Math.PI / 180)
                        dist += Math.Sqrt(dlat * dlat + dlon * dlon)
                    End If

                    If dist >= travel Then
                        idx = i
                        Exit For
                    End If

                    dx = travel - dist
                Next

                If dx <> 0 AndAlso idx < _path.Count - 1 Then
                    If _isGeodesic Then
                        Dim bearing = CalculateBearing(_path(idx), _path(idx + 1))
                        _intervalLocs.Add(CalculateCoord(_path(idx), bearing, dx))
                    Else
                        dlat = dx * Math.Sin(alpha)
                        dlon = dx * Math.Cos(alpha)

                        _intervalLocs.Add(New Location(_path(idx).Latitude + dlat, _path(idx).Longitude + dlon))
                    End If

                    _intervalIdx.Add(idx)
                End If
            Next

            'Ensure the last location is the last coordinate in the path.
            _intervalLocs.Add(_path(_path.Count - 1))
            _intervalIdx.Add(_path.Count - 1)
        End Sub

        Private Shared Function DegToRad(x As Double) As Double
            Return x * Math.PI / 180
        End Function

        Private Shared Function RadToDeg(x As Double) As Double
            Return x * 180 / Math.PI
        End Function

        ''' <summary>Calculates the distance between two locations in KM's.</summary>
        ''' <param name="origin" type="Microsoft.Maps.Location">Initial location.</param>
        ''' <param name="dest" type="Microsoft.Maps.Location">Second location.</param>
        ''' <returns>Returns the shortest distance between the two coordinates in KM's.</returns>
        Private Shared Function HaversineDistance(origin As Location, dest As Location) As Double
            Dim lat1 As Double = DegToRad(origin.Latitude), lon1 As Double = DegToRad(origin.Longitude), lat2 As Double = DegToRad(dest.Latitude), lon2 As Double = DegToRad(dest.Longitude)

            Dim dLat As Double = lat2 - lat1, dLon As Double = lon2 - lon1, cordLength As Double = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dLon / 2), 2), centralAngle As Double = 2 * Math.Atan2(Math.Sqrt(cordLength), Math.Sqrt(1 - cordLength))

            Return EARTH_RADIUS_KM * centralAngle
        End Function

        ''' <summary>Calculates the bearing between two loacations.</summary>
        ''' <param name="origin" type="Microsoft.Maps.Location">Initial location.</param>
        ''' <param name="dest" type="Microsoft.Maps.Location">Second location.</param>
        ''' <returns>The bearing angle between two coordinates.</returns>
        Private Shared Function CalculateBearing(origin As Location, dest As Location) As Double
            Dim lat1 = DegToRad(origin.Latitude)
            Dim lon1 = origin.Longitude
            Dim lat2 = DegToRad(dest.Latitude)
            Dim lon2 = dest.Longitude
            Dim dLon = DegToRad(lon2 - lon1)
            Dim y = Math.Sin(dLon) * Math.Cos(lat2)
            Dim x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon)
            Return (RadToDeg(Math.Atan2(y, x)) + 360) Mod 360
        End Function

        ''' <summary>Calculates a destination coordinate given a starting location, bearing, and distance in KM's.</summary>
        ''' <param name="origin" type="Microsoft.Maps.Location">Initial location.</param>
        ''' <param name="brng" type="Number">Bearing pointing towards new location.</param>
        ''' <param name="arcLength" type="Number">A distance in KM's.</param>
        ''' <returns>A destination coordinate based on an origin point, bearing and distance.</returns>
        Private Shared Function CalculateCoord(origin As Location, brng As Double, arcLength As Double) As Location
            Dim lat1 As Double = DegToRad(origin.Latitude), lon1 As Double = DegToRad(origin.Longitude), centralAngle As Double = arcLength / EARTH_RADIUS_KM

            Dim lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(centralAngle) + Math.Cos(lat1) * Math.Sin(centralAngle) * Math.Cos(DegToRad(brng)))
            Dim lon2 = lon1 + Math.Atan2(Math.Sin(DegToRad(brng)) * Math.Sin(centralAngle) * Math.Cos(lat1), Math.Cos(centralAngle) - Math.Sin(lat1) * Math.Sin(lat2))

            Return New Location(RadToDeg(lat2), RadToDeg(lon2))
        End Function

#End Region
    End Class
End Namespace
