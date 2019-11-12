using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QRCODE_SCANNER.UserControls
{
    /// <summary>
    /// User control to display the camera feed inside a CaptureElement
    /// </summary>
    public sealed partial class CameraCaptureControl : UserControl
    {
        #region Private Fields
        private static Timer timer;
        private Result res;
        private ZXing.BarcodeReader br;
        private WriteableBitmap wrb;
        private MediaCapture captureMgr = null;
        private bool isCameraFound = false;
        private string qrCodeContent;

        #endregion

        #region Public Properties and Events
        /// <summary>
        /// Event to let the consumer of the User control know that the email
        /// has been decoded from the QR code that is scanned
        /// </summary>
        public event EventHandler<CameraClickedEventArgs> EmailDecoded = delegate { };

        /// <summary>
        /// Property to get/set the email address field 
        /// </summary>
        public string QrCodeContent
        {
            get { return qrCodeContent; }
            set { qrCodeContent = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the user control
        /// </summary>
        public CameraCaptureControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to handle the Loaded event of the user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded( object sender, RoutedEventArgs e )
        {
            InitializeMediaCapture();
            ScanQRCode();
        }

        private async void ScanQRCode()
        {
            TimerCallback callBack = new TimerCallback(CaptureQRCodeFromCamera);
            timer = new Timer(callBack, null, 4000, Timeout.Infinite);
        }

        /// <summary>
        /// Method to Initialize the Camera present in the device 
        /// </summary>
        private async void InitializeMediaCapture()
        {
            try
            {
                DeviceInformationCollection devices = null;
                captureMgr = new MediaCapture();
                devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);


                // Use the front camera if found one
                if (devices == null || devices.Count == 0)
                {
                    isCameraFound = false;
                    return;
                }

                DeviceInformation info = null;
                info = devices[0];

                MediaCaptureInitializationSettings settings;
                settings = new MediaCaptureInitializationSettings { VideoDeviceId = info.Id }; // 0 => front, 1 => back


                await captureMgr.InitializeAsync(settings);
                VideoEncodingProperties resolutionMax = null;
                int max = 0;
                var resolutions = captureMgr.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.Photo);

                for (var i = 0 ; i < resolutions.Count ; i++)
                {
                    VideoEncodingProperties res = (VideoEncodingProperties)resolutions[i];
                    if (res.Width * res.Height > max)
                    {
                        max = (int)(res.Width * res.Height);
                        resolutionMax = res;
                    }
                }

                await captureMgr.VideoDeviceController.SetMediaStreamPropertiesAsync(MediaStreamType.Photo, resolutionMax);
                capturePreview.Source = captureMgr;
                isCameraFound = true;
                await captureMgr.StartPreviewAsync();
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Error while initializing media capture device: " + ex.Message);
                dialog.ShowAsync();
                GC.Collect();
            }
        }

        /// <summary>
        /// Method to handle the Click event of the Capture Code button
        /// </summary>
        /// <param name="sender">Sender of the Event</param>
        /// <param name="e">Arguments of the event</param>
        private async void CaptureQRCodeFromCamera(object data)
        {
            MessageDialog dialog = new MessageDialog(string.Empty);
            try
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {
                    if (!isCameraFound)
                    {
                        return;
                    }

                    ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
                    // create storage file in local app storage
                    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "temp.jpg",
                    CreationCollisionOption.GenerateUniqueName);
                    // take photo
                    await captureMgr.CapturePhotoToStorageFileAsync(imgFormat, file);
                    // Get photo as a BitmapImage
                    BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
                    bmpImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                    {
                        wrb = await Windows.UI.Xaml.Media.Imaging.BitmapFactory.New(1, 1).FromStream(fileStream);
                    }
                    br = new BarcodeReader { PossibleFormats = new BarcodeFormat[] { BarcodeFormat.QR_CODE } };
                    res = br.Decode(wrb);
                    CameraClickedEventArgs cameraArgs = null;
                    if (res != null)
                    {
                        QrCodeContent = res.Text;
                        cameraArgs = new CameraClickedEventArgs { EncodedData = this.QrCodeContent };
                        if (this.EmailDecoded != null)
                        {
                            EmailDecoded(this, cameraArgs);
                        }
                    }

                    timer.Change(4000, Timeout.Infinite);
                });
            }

            catch (Exception ex)
            {
                dialog = new MessageDialog("Error: " + ex.Message);
                dialog.ShowAsync();
            }
        }

        /// <summary>
        /// Method to handle the unload event of the User Control. Here, all the MediaCapture resources
        /// are cleaned up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Unloaded( object sender, RoutedEventArgs e )
        {
            captureMgr = null;
            wrb = null;
            res = null;
            br = null;
            if (timer != null)
                timer.Dispose();

            GC.Collect();
        }

        #endregion
    }

    /// <summary>
    /// Class to pass the Event data from the Control to the consumer
    /// </summary>
    public class CameraClickedEventArgs : EventArgs
    {
        private string encodedData;

        /// <summary>
        /// Property to get/set the e-mail address scanned from the QR code
        /// </summary>
        public string EncodedData
        {
            get { return encodedData; }
            set { encodedData = value; }
        }
    }
}
