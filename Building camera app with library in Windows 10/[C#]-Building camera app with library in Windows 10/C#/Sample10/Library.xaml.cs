using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sample10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Library : Page
    {
        private static List<Data> videosList { get; set; }
        private static List<Data> photosList { get; set; }

        public Library()
        {
            this.InitializeComponent();

            videosList = new List<Data>();
            photosList = new List<Data>();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            getResources();

            // Set the resources
            photos.ItemsSource = photosList;
            videos.ItemsSource = videosList;
        }

        private void getResources()
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                var photos = await (await ApplicationData.Current.LocalFolder.GetFolderAsync("Photos")).GetFilesAsync();
                var videos = await (await ApplicationData.Current.LocalFolder.GetFolderAsync("Videos")).GetFilesAsync();
                
                // Filter files
                foreach (var photo in photos)
                {
                    photosList.Add(
                        new Data { Name = photo.Name, Path = new Uri(photo.Path) }
                    );
                }

                foreach (var video in videos)
                {
                    videosList.Add(
                        new Data { Name = video.Name, Path = new Uri(video.Path) }
                    );
                }
            }).Wait();
        }

        private void showVideos_Click(object sender, RoutedEventArgs e)
        {
            if((sender as AppBarToggleButton).IsChecked == true)
            {
                // Show the videos
                videos.Visibility = Visibility.Visible;
                photos.Visibility = Visibility.Collapsed;
            } else
            {
                // Show the photos
                photos.Visibility = Visibility.Visible;
                videos.Visibility = Visibility.Collapsed;
            }
        }
    }

    public class Data
    {
        public string Name { get; set; }
        public Uri Path { get; set; }
    }
}
