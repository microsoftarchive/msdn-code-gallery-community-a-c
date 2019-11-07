using Bing.Maps;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace PixelToLocationSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MapLayer mMapLayer;

        public MainPage()
        {
            this.InitializeComponent();

            mMapLayer = new MapLayer();
            map.Children.Add(mMapLayer);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void map_RightTapped_1(object sender, RightTappedRoutedEventArgs e)
        {
            Location location = new Location();
            bool succeeded = map.TryPixelToLocation(e.GetPosition(map), out location);

            if (succeeded)
            {
                Pushpin pin = new Pushpin();
                mMapLayer.Children.Add(pin);
                MapLayer.SetPosition(pin, location);
            }
        }
    }
}
