Imports Bing.Maps
Imports System.Threading.Tasks
Imports Windows.UI
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media.Animation

Public NotInheritable Class MainPage
    Inherits Page

#Region "Private Properties"

    Private shapeLayer As MapShapeLayer

    'Italy
    'London
    'New York
    'Seattle
    Private path As New LocationCollection() From { _
        New Location(42.8, 12.49), _
        New Location(51.5, 0), _
        New Location(40.8, -73.8), _
        New Location(47.6, -122.3) _
    }

    Private currentAnimation As AnimatedMaps.Animations.PathAnimation

#End Region

#Region "Constructor"

    Public Sub New()
        Me.InitializeComponent()

        shapeLayer = New MapShapeLayer()
        MyMap.ShapeLayers.Add(shapeLayer)
    End Sub

#End Region

#Region "Button Handlers"

    Private Sub ClearMapBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ClearMap()
    End Sub

    Private Sub ScalingPinBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ClearMap()

        Dim pin = New Pushpin()
        MapLayer.SetPosition(pin, MyMap.Center)

        pin.RenderTransformOrigin = New Windows.Foundation.Point(0.5, 0.5)
        pin.RenderTransform = New ScaleTransform()

        Dim story = DirectCast(App.Current.Resources("expandStoryboard"), Storyboard)

        AddHandler pin.PointerEntered, Sub(s, a)
                                           story.Stop()
                                           Storyboard.SetTarget(story, pin)
                                           story.Begin()
                                       End Sub

        AddHandler pin.PointerExited, Sub(s, a)
                                          story.Stop()
                                      End Sub

            MyMap.Children.Add(pin)
    End Sub

    Private Sub DropPinBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ClearMap()

        Dim pin = New Pushpin()
        MapLayer.SetPosition(pin, MyMap.Center)

        MyMap.Children.Add(pin)

        AnimatedMaps.Animations.PushpinAnimations.Drop(pin, Nothing, Nothing)
    End Sub

    Private Sub BouncePinBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ClearMap()

        Dim pin = New Pushpin()
        MapLayer.SetPosition(pin, MyMap.Center)

        MyMap.Children.Add(pin)

        AnimatedMaps.Animations.PushpinAnimations.Bounce(pin, Nothing, Nothing)
    End Sub

    Private Async Sub Bounce4PinsBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ClearMap()

        For i As Integer = 0 To path.Count - 1
            Dim pin = New Pushpin()
            MapLayer.SetPosition(pin, path(i))

            MyMap.Children.Add(pin)

            AnimatedMaps.Animations.PushpinAnimations.Bounce(pin, Nothing, Nothing)

            Await Task.Delay(500)
        Next
    End Sub

    Private Sub MovePinOnPathBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        MovePinOnPath(False)
    End Sub

    Private Sub MovePinOnGeodesicPathBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        MovePinOnPath(True)
    End Sub

    Private Sub MoveMapOnPathBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        MoveMapOnPath(False)
    End Sub

    Private Sub MoveMapOnGeodesicPathBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        MoveMapOnPath(True)
    End Sub

    Private Sub DrawPathBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        DrawPath(False)
    End Sub

    Private Sub DrawGeodesicPathBtn_Tapped(sender As Object, e As TappedRoutedEventArgs)
        DrawPath(True)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub ClearMap()
        MyMap.Children.Clear()
        shapeLayer.Shapes.Clear()

        If currentAnimation IsNot Nothing Then
            currentAnimation.Stop()
            currentAnimation = Nothing
        End If
    End Sub

    Private Sub MovePinOnPath(isGeodesic As Boolean)
        ClearMap()

        Dim pin = New Pushpin()
        MapLayer.SetPosition(pin, path(0))

        MyMap.Children.Add(pin)

        currentAnimation = New AnimatedMaps.Animations.PathAnimation(path, Sub(coord, pathIdx, frameIdx)
                                                                               MapLayer.SetPosition(pin, coord)
                                                                           End Sub, isGeodesic, 10000)

        currentAnimation.Play()
    End Sub

    Private Sub MoveMapOnPath(isGeodesic As Boolean)
        ClearMap()

        'Change zooms levels as map reaches points along path.
        Dim zooms As Integer() = New Integer(3) {5, 4, 6, 5}

        MyMap.SetView(path(0), zooms(0))

        currentAnimation = New AnimatedMaps.Animations.PathAnimation(path, Sub(coord, pathIdx, frameIdx)
                                                                               MyMap.SetView(coord, zooms(pathIdx))
                                                                           End Sub, isGeodesic, 10000)

        currentAnimation.Play()
    End Sub

    Private Sub DrawPath(isGeodesic As Boolean)
        ClearMap()

        Dim line As New MapPolyline()
        line.Color = Colors.Red
        line.Width = 4

        currentAnimation = New AnimatedMaps.Animations.PathAnimation(path, Sub(coord, pathIdx, frameIdx)
                                                                               If frameIdx = 1 Then
                                                                                   'Create the line the line after the first frame so that we have two points to work with.	                
                                                                                   line.Locations = New LocationCollection() From { _
                                                                                   path(0), _
                                                                                   coord _
                                                                               }
                                                                                   shapeLayer.Shapes.Add(line)
                                                                               ElseIf frameIdx > 1 Then
                                                                                   line.Locations.Add(coord)
                                                                               End If
                                                                           End Sub, isGeodesic, 10000)

        currentAnimation.Play()
    End Sub

#End Region
End Class