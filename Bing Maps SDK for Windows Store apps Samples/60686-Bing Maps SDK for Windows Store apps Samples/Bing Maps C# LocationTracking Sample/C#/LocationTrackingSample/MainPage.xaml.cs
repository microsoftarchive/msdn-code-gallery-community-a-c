// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
// PARTICULAR PURPOSE. 
// 
// Copyright (c) Microsoft Corporation. All rights reserved 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bing.Maps;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// To run this app, make sure "Location" capability is enabled in Package.appxmanifest.
// And "Location" permission is enabled in the app settings.

namespace LocationTrackingSample
{
    /// <summary>
    /// The main class
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Geolocator geolocator;
        LocationIcon locationIcon;

        public MainPage()
        {
            this.InitializeComponent();
            geolocator = new Geolocator();
            locationIcon = new LocationIcon();
            // Add the location icon to map layer so that we can position it.
            map.Children.Add(locationIcon);
            geolocator.PositionChanged += new Windows.Foundation.TypedEventHandler<Geolocator, PositionChangedEventArgs>(geolocator_PositionChanged);
        }

        private void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            // Need to set map view on UI thread.
            this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(
                () =>
                {
                    displayPosition(this, args);
                }));
        }

        private void displayPosition(object sender, PositionChangedEventArgs args)
        {
            Location location = new Location(args.Position.Coordinate.Latitude, args.Position.Coordinate.Longitude);
            MapLayer.SetPosition(locationIcon, location);
            map.SetView(location, 15.0f);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
