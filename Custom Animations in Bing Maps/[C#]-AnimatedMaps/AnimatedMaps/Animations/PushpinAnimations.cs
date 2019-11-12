using Bing.Maps;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace AnimatedMaps.Animations
{
    public static class PushpinAnimations
    {
        /// <summary>
        /// Animates a pushpin using a translate transform along the Y axis. 
        /// </summary>
        /// <param name="pin">The pushpin to perform the animation on.</param>
        /// <param name="from">Intial translate position.</param>
        /// <param name="to">Final translate position.</param>
        /// <param name="duration">Length of time in ms that the animation should run for.</param>
        /// <param name="easingFunction">An easing function that specificies how the animation should progress over time.</param>
        public static void AnimateY(UIElement pin, double fromY, double toY, int duration, EasingFunctionBase easingFunction)
        {
            pin.RenderTransform = new TranslateTransform();

            var sb = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = fromY,
                To = toY,
                Duration = new TimeSpan(0, 0, 0, 0, duration),
                EasingFunction = easingFunction
            };

            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            Storyboard.SetTarget(animation, pin);

            sb.Children.Add(animation);
            sb.Begin();
        }

        /// <summary>A simple animation that drops a pin from a height above it's destinated location onto the map.</summary>
        /// <param name="pin">The pushpin to perform the animation on.</param>
        /// <param name="height">The height above the destinated location to drop the pushpin from. Default is 150 pixels.</param>
        /// <param name="duration">Length of time in ms that the animation should run for. Default is 150 ms.</param>
        public static void Drop(UIElement pin, double? height, int? duration)
        {           
            height = (height.HasValue && height.Value > 0) ? height : 150;
            duration = (duration.HasValue && duration.Value > 0) ? duration : 150;

            var anchor = MapLayer.GetPositionAnchor(pin);
            var from = anchor.Y + height.Value;

            AnimateY(pin, -from, -anchor.Y, duration.Value, new QuadraticEase()
            {
                EasingMode = Windows.UI.Xaml.Media.Animation.EasingMode.EaseIn
            });
        }

        /// <summary>A simple animation that drops a pin from a height above it's destinated location onto the map and bounce's it to rest.</summary>
        /// <param name="pin">The pushpin to perform the animation on.</param>
        /// <param name="height">The height above the destinated location to drop the pushpin from. Default is 150 pixels.</param>
        /// <param name="duration">Length of time in ms that the animation should run for. Default is 1000 ms.</param>
        public static void Bounce(UIElement pin, double? height, int? duration)
        {
            height = (height.HasValue && height.Value > 0) ? height : 150;
            duration = (duration.HasValue && duration.Value > 0) ? duration : 1000;

            var anchor = MapLayer.GetPositionAnchor(pin);
            var from = anchor.Y + height.Value;

            AnimateY(pin, -from, -anchor.Y, duration.Value, new BounceEase()
                {
                    Bounces = 2,
                    EasingMode = Windows.UI.Xaml.Media.Animation.EasingMode.EaseOut,
                    Bounciness = 2
                });
        }
    }
}
