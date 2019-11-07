using Bing.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MapShapesSample
{
    /// <summary>
    /// The Bing Maps C# Maps Sample shows how to add shapes to the map including polygons 
    /// and polylines. It also indicates the difference between valid and invalid polygons.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MapShapeLayer mShapeLayer;
        MapLayer mPinLayer;
        LocationCollection mPolyShapeLocations;

        public MainPage()
        {
            this.InitializeComponent();

            // Shapes are added to a MapShapeLayer.
            mShapeLayer = new MapShapeLayer();
            map.ShapeLayers.Add(mShapeLayer);

            // Pushpins are added to a MapLayer.
            mPinLayer = new MapLayer();
            map.Children.Add(mPinLayer);

            mPolyShapeLocations = new LocationCollection();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void PopulateValidLocations()
        {
            mPolyShapeLocations.Clear();
            mPolyShapeLocations.Add(new Location(15, -15));
            mPolyShapeLocations.Add(new Location(30, -90));
            mPolyShapeLocations.Add(new Location(-45, -15));
            mPolyShapeLocations.Add(new Location(30, 90));
            mPolyShapeLocations.Add(new Location(60, 60));
        }

        private void AddPolyShape(MapShape mapShape)
        {
            mShapeLayer.Shapes.Clear();
            mPinLayer.Children.Clear();

            mShapeLayer.Shapes.Add(mapShape);

            // Add pushpins to the map to make it easy to see how the order of 
            // the locations in the LocationCollection affects how the poly shape
            // is drawn.
            for (int i = 0; i < mPolyShapeLocations.Count; i++)
            {
                Pushpin pin = new Pushpin();
                pin.Text = i.ToString();
                mPinLayer.Children.Add(pin);
                MapLayer.SetPosition(pin, mPolyShapeLocations[i]);
            }
        }

        private MapPolygon CreatePolygon()
        {
            MapPolygon polygon = new MapPolygon();
            polygon.FillColor = Windows.UI.Colors.Blue;
            polygon.Locations = mPolyShapeLocations;

            return polygon;
        }

        private MapPolyline CreatePolyline()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Color = Windows.UI.Colors.Red;
            polyline.Locations = mPolyShapeLocations;

            return polyline;
        }

        private void Polygon_Button_Click_1(object sender, RoutedEventArgs e)
        {
            PopulateValidLocations();
            AddPolyShape(CreatePolygon());
        }

        private void Invalid_Polygon_Button_Click_1(object sender, RoutedEventArgs e)
        {
            PopulateValidLocations();
            mPolyShapeLocations.Add(new Location(0, 90));
            AddPolyShape(CreatePolygon());
        }

        private void Polyline_Button_Click_2(object sender, RoutedEventArgs e)
        {
            PopulateValidLocations();
            AddPolyShape(CreatePolyline());
        }
    }
}
