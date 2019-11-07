using Bing.Maps;
using System;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GPXRouteViewerSample
{
    /// <summary>
    /// The GPXRouteViewerSample allows the user to select .gpx files from their 
    /// computer and display them on a map. The user can also see an animated 
    /// playback of their route.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string PlayRouteText = "Play Route";
        private const string StopPlaybackText = "Stop Playback";

        private MapShapeLayer mRouteLayer;
        private MapLayer mMapLayer;
        private DispatcherTimer mRoutePlaybackTimer;
        private Pushpin mMarkerPin;
        private int mRouteLocationIndex;

        public MainPage()
        {
            this.InitializeComponent();

            mRoutePlaybackTimer = new DispatcherTimer();
            mRoutePlaybackTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            mRoutePlaybackTimer.Tick += mRoutePlaybackTimer_Tick;

            mRouteLayer = new MapShapeLayer();
            map.ShapeLayers.Add(mRouteLayer);

            mMapLayer = new MapLayer();
            map.Children.Add(mMapLayer);

            mMarkerPin = new Pushpin();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// Displays a FilePicker to the user and after they select the file
        /// it is loaded and displayed on the map.
        /// </summary>
        private async void LoadGPXFile()
        {
            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".gpx");
            StorageFile gpxFile = await fileOpenPicker.PickSingleFileAsync();

            if (gpxFile != null)
            {
                XmlDocument gpxDoc = await XmlDocument.LoadFromFileAsync(gpxFile);
                XmlNodeList pointNodes = gpxDoc.GetElementsByTagName("trkpt");

                LocationCollection gpxRoutePoints = new LocationCollection();

                foreach (IXmlNode node in pointNodes)
                {
                    XmlNamedNodeMap attributes = node.Attributes;

                    try
                    {
                        IXmlNode latitudeAttribute = attributes.GetNamedItem("lat");
                        double latitude = double.Parse(latitudeAttribute.InnerText);

                        IXmlNode longitudeAttribute = attributes.GetNamedItem("lon");
                        double longitude = double.Parse(longitudeAttribute.InnerText);

                        gpxRoutePoints.Add(new Location(latitude, longitude));
                    }
                    catch
                    {
                        // Most likely if these values don't exist in the file it is
                        // formatted incorrectly or corrupt.  In a real app we would
                        // display some kind of error message to the user.
                    }
                }

                MapPolyline route = new MapPolyline();
                route.Color = Windows.UI.Colors.Blue;
                route.Width = 5;
                route.Locations = gpxRoutePoints;
                mRouteLayer.Shapes.Add(route);

                Pushpin startPin = new Pushpin();
                startPin.Text = "S";
                mMapLayer.Children.Add(startPin);
                MapLayer.SetPosition(startPin, gpxRoutePoints[0]);

                Pushpin endPin = new Pushpin();
                endPin.Text = "E";
                mMapLayer.Children.Add(endPin);
                MapLayer.SetPosition(endPin, gpxRoutePoints[gpxRoutePoints.Count - 1]);

                LocationRect bestRouteView = new LocationRect(gpxRoutePoints);
                map.SetView(bestRouteView);

                mMarkerPin.Visibility = Visibility.Collapsed;
                mMapLayer.Children.Add(mMarkerPin);
            }
        }

        private void playRouteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (mRoutePlaybackTimer.IsEnabled)
            {
                playRouteBtn.Content = PlayRouteText;
                mRoutePlaybackTimer.Stop();
            }
            else
            {
                mRouteLocationIndex = 0;
                mMarkerPin.Visibility = Visibility.Visible;
                playRouteBtn.Content = StopPlaybackText;
                mRoutePlaybackTimer.Start();
            }
        }

        private void mRoutePlaybackTimer_Tick(object sender, object e)
        {
            MapPolyline routePolyline = mRouteLayer.Shapes[0] as MapPolyline;

            if (mRouteLocationIndex < routePolyline.Locations.Count)
            {
                Location location = routePolyline.Locations[mRouteLocationIndex];

                // Center the map on the current location.
                map.Center = location;

                // Set the position of the route marker that indicates the current
                // spot on the route.
                MapLayer.SetPosition(mMarkerPin, location);

                // There are usually LOTS of locations in the polyline. Skipping
                // ahead by 5 still gives smooth-looking animation while only
                // taking 1/5th the time.
                mRouteLocationIndex += 5;
            }
            else
            {
                playRouteBtn.Content = PlayRouteText;
                mRoutePlaybackTimer.Stop();
            }
        }

        private void loadRouteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            // Every time the load route button is clicked we want to clear the previous
            // route.
            mMapLayer.Children.Clear();
            mRouteLayer.Shapes.Clear();
            playRouteBtn.Content = PlayRouteText;
            mRoutePlaybackTimer.Stop();
            LoadGPXFile();
        }
    }
}
