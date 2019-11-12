using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Media.MediaProperties;
using Windows.Media.FaceAnalysis;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sample10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaCapture capture { get; set; }
        private bool isRecording { get; set; }
        private static DispatcherTimer timer { get; set; }

        // Video capture settings
        private static MediaEncodingProfile encoding { get; set; }
        private static string myEncoding = "";
        private static string myQuality = "";
        private static bool muted = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void init()
        {
            await capture.InitializeAsync();

            captureElement.Source = capture;
            await capture.StartPreviewAsync();

            loading.Visibility = Visibility.Collapsed;

            #region Error handling
            MediaCaptureFailedEventHandler handler = (sender, e) =>
            {
                System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(async () =>
                {
                    await new MessageDialog("There was an error capturing the video from camera.", "Error").ShowAsync();
                });
            };
            
            capture.Failed += handler;
            #endregion

            #region Advanced topic; I will complete this region later
            try
            {
                // FaceTracker tracker = await FaceTracker.CreateAsync();
                // await tracker.ProcessNextFrameAsync(await capture.GetPreviewFrameAsync());
            } catch (Exception e)
            {
                await new MessageDialog(e.InnerException.Message, "Error").ShowAsync();
            }
            #endregion
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as AppBarButton).Name == "cameraIcon")
            {
                // Capture the image
                capturePhoto();
            } else if ((sender as AppBarButton).Name == "videoIcon")
            {
                // Start recording
                alterRecording();
            } else if ((sender as AppBarButton).Name == "rotateCameraIcon")
            {
                invertCamera();
            } else if ((sender as AppBarButton).Name == "muteIcon")
            {
                muteUnmute();
            } else if ((sender as AppBarButton).Name == "libraryIcon")
            {
                App.RootFrame.Navigate(typeof(Library));

                cleanResources();
            }
        }

        private async void cleanResources()
        {
            captureElement.Source = null;
            await capture.StopPreviewAsync();

            if(isRecording)
            {
                await capture.StopRecordAsync();
            }
            capture.Dispose(); // Dispose the resource
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Page has become active, load the resources.
            capture = new MediaCapture();
            loading.Visibility = Visibility.Visible;

            init();
        }

        private async void capturePhoto()
        {
            if(!isRecording)
            {
                    var file = await (await ApplicationData.Current.LocalFolder.CreateFolderAsync("Photos",     
                                      CreationCollisionOption.OpenIfExists)
                                      ).CreateFileAsync("Photo.jpg", CreationCollisionOption.GenerateUniqueName);

                await capture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(), file);
            } else
            {
                await new MessageDialog("Application is currently recording your camera, please stop recording and try again.", "Recording").ShowAsync();
            }
        }

        private async void alterRecording()
        {
            if(isRecording)
            {
                // Stop recording
                await capture.StopRecordAsync();
                videoIcon.Foreground = new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 0, G = 0, B = 0 }); // Black
                isRecording = false; // Not recording any more
            } else
            {
                encoding = getVideoEncoding(); // Get the current encoding selection.

                // Start recording
                var file = await (await ApplicationData.Current.LocalFolder.CreateFolderAsync("Videos", 
                                  CreationCollisionOption.OpenIfExists)).CreateFileAsync(
                                  string.Format("Recording_{0}-{1}.{2}", 
                                  myEncoding, 
                                  myQuality, 
                                  (myEncoding == "MP4") ? "mp4" : "wav"), 
                                  CreationCollisionOption.GenerateUniqueName);

                await capture.StartRecordToStorageFileAsync(encoding, file);

                videoIcon.Foreground = new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 255, G = 0, B = 0 }); // Red
                isRecording = true; // Capturing the video stream.
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            encoding = getVideoEncoding(); // Get the encoding settings for current selection.
        }

        private MediaEncodingProfile getVideoEncoding()
        {
            VideoEncodingQuality quality = VideoEncodingQuality.Auto;
            myQuality = "Auto";

            switch (videoQuality.SelectedIndex)
            {
                case 2:
                    quality = VideoEncodingQuality.HD1080p;
                    myQuality = "1080p";
                    break;
                case 3:
                    quality = VideoEncodingQuality.HD720p;
                    myQuality = "720p";
                    break;
                case 4:
                    quality = VideoEncodingQuality.Vga;
                    myQuality = "VGA";
                    break;
                default:
                    break;
            }

            myEncoding = (videoType == null || videoType.SelectedIndex == 0) ? "MP4" : "WMV";

            return (videoType == null || videoType.SelectedIndex == 0) ?
                MediaEncodingProfile.CreateMp4(quality) :
                MediaEncodingProfile.CreateWmv(quality);
        }

        private void invertCamera()
        {
            captureElement.FlowDirection = FlowDirection.RightToLeft;
        }

        private void muteUnmute()
        {
            if(muted)
            {
                // Unmute
                capture.AudioDeviceController.Muted = false;
                muted = false;
                muteIcon.Foreground = new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 0, G = 0, B = 0 });
            } else
            {
                // Mute
                capture.AudioDeviceController.Muted = true;
                muted = true;
                muteIcon.Foreground = new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 255, G = 0, B = 0 });
            }
        }
    }
}
