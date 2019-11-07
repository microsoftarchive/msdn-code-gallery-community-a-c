using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Bing.Maps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LandmarkEventsSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void map_LandmarkTapped_1(object sender, Bing.Maps.LandmarkTappedEventArgs e)
        {
            landmarkDetailsPanel.Children.Clear();

            LandmarkCollection landmarks = e.Landmarks;
            foreach (Landmark landmark in landmarks)
            {
                TextBlock landmarkName = new TextBlock();
                landmarkName.Text = "Name: " + landmark.Name;

                landmarkDetailsPanel.Children.Add(landmarkName);

                TextBlock landmarkType = new TextBlock();
                landmarkType.Text = "Type: " + landmark.Type;

                landmarkDetailsPanel.Children.Add(landmarkType);

                TextBlock landmarkLocationLatitude = new TextBlock();
                landmarkLocationLatitude.Text = "Latitude: " + landmark.Location.Latitude;

                landmarkDetailsPanel.Children.Add(landmarkLocationLatitude);

                TextBlock landmarkLocationLongitude = new TextBlock();
                landmarkLocationLongitude.Text = "Longitude: " + landmark.Location.Longitude;
                landmarkLocationLongitude.Margin = new Thickness(0, 0, 0, 10);

                landmarkDetailsPanel.Children.Add(landmarkLocationLongitude);
            }
        }
    }
}
