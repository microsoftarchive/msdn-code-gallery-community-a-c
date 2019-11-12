using Bing.Maps;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace AnimatedMaps
{
    public sealed partial class MainPage : Page
    {
        #region Private Properties

        private MapShapeLayer shapeLayer;

        private LocationCollection path = new LocationCollection(){
            new Location(42.8, 12.49),   //Italy
            new Location(51.5, 0),       //London
            new Location(40.8, -73.8),   //New York
            new Location(47.6, -122.3)   //Seattle
        };

        private Animations.PathAnimation currentAnimation;

        #endregion

        #region Constructor

        public MainPage()
        {
            this.InitializeComponent();

            shapeLayer = new MapShapeLayer();
            MyMap.ShapeLayers.Add(shapeLayer);
        }

        #endregion

        #region Button Handlers

        private void ClearMapBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearMap();
        }

        private void ScalingPinBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearMap();

            var pin = new Pushpin();
            MapLayer.SetPosition(pin, MyMap.Center);

            pin.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
            pin.RenderTransform = new ScaleTransform();

            var story = (Storyboard)App.Current.Resources["expandStoryboard"];

            pin.PointerEntered += (s, a) =>
            {
                story.Stop();
                Storyboard.SetTarget(story, pin);
                story.Begin();
            };

            pin.PointerExited += (s, a) =>
            {
                story.Stop();
            };

            MyMap.Children.Add(pin);
        }

        private void DropPinBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearMap();
            
            var pin = new Pushpin();
            MapLayer.SetPosition(pin, MyMap.Center);

            MyMap.Children.Add(pin);

            Animations.PushpinAnimations.Drop(pin, null, null);
        }

        private void BouncePinBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearMap();

            var pin = new Pushpin();
            MapLayer.SetPosition(pin, MyMap.Center);

            MyMap.Children.Add(pin);

            Animations.PushpinAnimations.Bounce(pin, null, null);
        }

        private async void Bounce4PinsBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClearMap();

	        for (var i = 0; i < path.Count; i++) {
                var pin = new Pushpin();
                MapLayer.SetPosition(pin, path[i]);

                MyMap.Children.Add(pin);

                Animations.PushpinAnimations.Bounce(pin, null, null);

                await Task.Delay(500);
	        }	   
        }

        private void MovePinOnPathBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MovePinOnPath(false);
        }

        private void MovePinOnGeodesicPathBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MovePinOnPath(true);
        }

        private void MoveMapOnPathBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MoveMapOnPath(false);
        }

        private void MoveMapOnGeodesicPathBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MoveMapOnPath(true);
        }

        private void DrawPathBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DrawPath(false);
        }

        private void DrawGeodesicPathBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DrawPath(true);
        }

        #endregion

        #region Private Methods

        private void ClearMap()
        {
            MyMap.Children.Clear();
            shapeLayer.Shapes.Clear();

            if (currentAnimation != null)
            {
                currentAnimation.Stop();
                currentAnimation = null;
            }
        }

        private void MovePinOnPath(bool isGeodesic)
        {
            ClearMap();
            
            var pin = new Pushpin();
            MapLayer.SetPosition(pin, path[0]);
            
            MyMap.Children.Add(pin);

            currentAnimation = new Animations.PathAnimation(path, (coord, pathIdx, frameIdx) =>
            {
                MapLayer.SetPosition(pin, coord);
            }, isGeodesic, 10000);

            currentAnimation.Play();
        }

        private void MoveMapOnPath(bool isGeodesic)
        {
            ClearMap();

            //Change zooms levels as map reaches points along path.
            int[] zooms = new int[4] { 5, 4, 6, 5 };

            MyMap.SetView(path[0], zooms[0]);

            currentAnimation = new Animations.PathAnimation(path, (coord, pathIdx, frameIdx) =>
            {
                MyMap.SetView(coord, zooms[pathIdx]);
            }, isGeodesic, 10000);

            currentAnimation.Play();
        }

        private void DrawPath(bool isGeodesic)
        {
            ClearMap();

            MapPolyline line = new MapPolyline()
            {
                Color = Colors.Red,
                Width = 4
            };

            currentAnimation = new Animations.PathAnimation(path, (coord, pathIdx, frameIdx) =>
            {
                if (frameIdx == 1)
                {
                    //Create the line after the first frame so that we have two points to work with.	                
                    line.Locations = new LocationCollection() { path[0], coord };
                    shapeLayer.Shapes.Add(line);
                }
                else if (frameIdx > 1)
                {
                    line.Locations.Add(coord);
                }
            }, isGeodesic, 10000);

            currentAnimation.Play();
        }

        #endregion
    }
}
