using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AsynchronousDownloader.Commands;
using AsynchronousDownloader.Model;

namespace AsynchronousDownloader.ViewModel
{
    public class DownloadFileViewModel : INotifyPropertyChanged
    {
        private static DownloadFileViewModel _viewModel;

        private List<DownloadFile> downloadFiles;
        public List<DownloadFile> DownloadFiles
        {
            get { return downloadFiles; }
            set
            {
                downloadFiles = value;
                OnPropertyChanged("DownloadFiles");
            }
        }

        public RelayCommand DownloadCommand { get; set; }
        public RelayCommand OpenFileCommand { get; set; }

        public static DownloadFileViewModel SharedViewModel()
        {
            return _viewModel ?? (_viewModel = new DownloadFileViewModel());
        }

        private DownloadFileViewModel()
        {
            DownloadCommand = new RelayCommand(Download, CanDownload);
            OpenFileCommand = new RelayCommand(OpenFile, CanOpenFile);
            DownloadFiles = new List<DownloadFile>();
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_1080p_hp_4.1_40mbps_birds.mkv" });
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_1080p_hp_4.1_10mbps_dts_unstyled_subs_monsters.mkv" });
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_720p_hp_5.1_6mbps_ac3_unstyled_subs_planet.mkv" });
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_720p_hp_3.1_600kbps_aac_mp3_dual_audio_harry_potter.mkv" });
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_720p_hp_5.1_6mbps_ac3_unstyled_subs_planet.mkv" });
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_720p_mp_3.1_3mbps_aac_shrinkage.mp4" });
            DownloadFiles.Add(new DownloadFile { Uri = "http://www.auby.no/files/video_tests/h264_720p_hp_5.1_6mbps_ac3_planet.mp4" });
        }

        private void OpenFile(object obj)
        {
            var file = obj as DownloadFile;
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", file.DownloadLocation));
        }

        private bool CanOpenFile(object obj)
        {
            return true;
        }

        public static bool CanDownload(object obj)
        {
            var file = obj as DownloadFile;
            return (obj != null && file.DownloadStatus == DownloadStatus.NotDownloaded);
        }

        private void Download(object obj)
        {
            var file = obj as DownloadFile;
            file.DownloadStatus = DownloadStatus.Downloading;

            var webClient = new CustomWebClient();
            webClient.Data = file;
            webClient.Clock = new Stopwatch();
            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
            webClient.Clock.Start();
            webClient.DownloadFileAsync(new Uri(file.Uri), file.DownloadLocation = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), file.Filename));
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var customWebClient = sender as CustomWebClient;
            var downloadFile = (customWebClient.Data as DownloadFile);

            downloadFile.DownloadPercentageString = string.Format("{0} %", int.Parse(Math.Truncate(((double.Parse(e.BytesReceived.ToString()) / double.Parse(e.TotalBytesToReceive.ToString())) * 100)).ToString()));
            downloadFile.DownloadPercentage = int.Parse(Math.Truncate(((double.Parse(e.BytesReceived.ToString()) / double.Parse(e.TotalBytesToReceive.ToString())) * 100)).ToString());
            downloadFile.DownloadTime = string.Format("{0} s", int.Parse(Math.Truncate(customWebClient.Clock.Elapsed.TotalSeconds).ToString()));
            downloadFile.DownloadSpeed = string.Format("{0} kb/s", (e.BytesReceived / 1024d / customWebClient.Clock.Elapsed.TotalSeconds).ToString("0.00"));
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var customWebClient = sender as CustomWebClient;
            (customWebClient.Data as DownloadFile).DownloadStatus = DownloadStatus.Downloaded;
            customWebClient.DownloadFileCompleted -= webClient_DownloadFileCompleted;
            customWebClient.DownloadProgressChanged -= webClient_DownloadProgressChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
