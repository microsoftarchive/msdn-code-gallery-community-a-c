Imports Bing.Maps
Imports Windows.Foundation
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Media.Animation

Namespace AnimatedMaps.Animations
    Public NotInheritable Class PushpinAnimations

        ''' <summary>Animates a pushpin using a translate transform along the Y axis.</summary>
        ''' <param name="pin">The pushpin to perform the animation on.</param>
        ''' <param name="fromY">Intial translate position.</param>
        ''' <param name="toY">Final translate position.</param>
        ''' <param name="duration">Length of time in ms that the animation should run for.</param>
        ''' <param name="easingFunction">An easing function that specificies how the animation should progress over time.</param>
        Public Shared Sub AnimateY(pin As UIElement, fromY As Double, toY As Double, duration As Integer, easingFunction As EasingFunctionBase)
            pin.RenderTransform = New TranslateTransform()

            Dim sb = New Storyboard()
            Dim Animation = New DoubleAnimation()
            Animation.From = fromY
            Animation.To = toY
            Animation.Duration = New System.TimeSpan(0, 0, 0, 0, duration)
            Animation.EasingFunction = easingFunction

            Storyboard.SetTargetProperty(Animation, "(UIElement.RenderTransform).(TranslateTransform.Y)")
            Storyboard.SetTarget(Animation, pin)

            sb.Children.Add(Animation)
            sb.Begin()
        End Sub

        ''' <summary>A simple animation that drops a pin from a height above it's destinated location onto the map.</summary>
        ''' <param name="pin">The pushpin to perform the animation on.</param>
        ''' <param name="height">The height above the destinated location to drop the pushpin from. Default is 150 pixels.</param>
        ''' <param name="duration">Length of time in ms that the animation should run for. Default is 150 ms.</param>
        Public Shared Sub Drop(pin As UIElement, height As System.Nullable(Of Double), duration As System.Nullable(Of Integer))
            height = If((height.HasValue AndAlso height.Value > 0), height, 150)
            duration = If((duration.HasValue AndAlso duration.Value > 0), duration, 150)

            Dim anchor = MapLayer.GetPositionAnchor(pin)
            Dim from = anchor.Y + height.Value

            Dim easing = New QuadraticEase()
            easing.EasingMode = EasingMode.EaseIn

            AnimateY(pin, -from, -anchor.Y, duration, easing)
        End Sub

        ''' <summary>A simple animation that drops a pin from a height above it's destinated location onto the map and bounce's it to rest.</summary>
        ''' <param name="pin">The pushpin to perform the animation on.</param>
        ''' <param name="height">The height above the destinated location to drop the pushpin from. Default is 150 pixels.</param>
        ''' <param name="duration">Length of time in ms that the animation should run for. Default is 1000 ms.</param>
        Public Shared Sub Bounce(pin As UIElement, height As System.Nullable(Of Double), duration As System.Nullable(Of Integer))
            height = If((height.HasValue AndAlso height.Value > 0), height, 150)
            duration = If((duration.HasValue AndAlso duration.Value > 0), duration, 1000)

            Dim anchor = MapLayer.GetPositionAnchor(pin)
            Dim from = anchor.Y + height.Value
            
            Dim easing = New BounceEase()
            easing.Bounces = 2
            easing.EasingMode = EasingMode.EaseOut
            easing.Bounciness = 2

            AnimateY(pin, -from, -anchor.Y, duration, easing)
        End Sub
    End Class
End Namespace
