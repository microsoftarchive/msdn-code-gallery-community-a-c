using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using YoutubeExtractor;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace YoutubeDownloader.Resources
{
    [Activity(Label = "VideoActivity")]
    public class VideoActivity : Activity
    {

        VideoView video_view;


        MediaController media_controller;

        Button download;

        ProgressDialog dialog;

        string video_url;

        string video_title;

        string video_extension;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.VideoLayout);
            video_view = FindViewById<VideoView>(Resource.Id.videoView);
            
            //media_controller = FindViewById<MediaController>(Resource.Id.mediaController);

            download = FindViewById<Button>(Resource.Id.downloadVideo);



            download.Click += Download_Click;





            string videoId = Intent.GetStringExtra("id");

            if (!string.IsNullOrEmpty(videoId))

            {

                YoutubeVideo(videoId);

            }


        }

        public void YoutubeVideo(string id)

        {

            string link = "https://www.youtube.com/watch?v=" + id;



            IEnumerable<VideoInfo> videosInfors = DownloadUrlResolver.GetDownloadUrls(link);





            VideoInfo video = videosInfors.First(infor => infor.VideoType == VideoType.Mp4);



            video_url = video.DownloadUrl;

            video_title = video.Title;

            video_extension = video.VideoExtension;



            video_view.SetVideoURI(Android.Net.Uri.Parse(video.DownloadUrl));





            media_controller = new Android.Widget.MediaController(this);

            media_controller.SetMediaPlayer(video_view);

            video_view.SetMediaController(media_controller);

            video_view.RequestFocus();

            video_view.Start();

        }



        async void Download_Click(object sender, EventArgs e)

        {

            var webClient = new WebClient();

            if (!string.IsNullOrEmpty(video_url))

            {

                byte[] bytes = null;



                webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;

                dialog = new ProgressDialog(this);

                dialog.SetProgressStyle(ProgressDialogStyle.Horizontal);

                dialog.SetTitle("Downloading...");

                dialog.SetCancelable(false);

                dialog.SetCanceledOnTouchOutside(false);

                dialog.Show();



                try

                {

                    bytes = await webClient.DownloadDataTaskAsync(video_url);

                }

                catch (TaskCanceledException)

                {

                    Toast.MakeText(this, "Task Canceled", ToastLength.Long).Show();

                    return;

                }

                catch (Exception a)

                {

                    Toast.MakeText(this, a.InnerException.Message, ToastLength.Long).Show();

                    dialog.Progress = 0;

                    return;

                }



                var documentsPath = Android.OS.Environment.ExternalStorageDirectory + "/Download";

                string localFilename = video_title

                    .Replace('.', 'a')

                    .Replace('-', 'a')

                    .Replace('(', 'a')

                    .Replace(')', 'a')

                    .Replace('"', 'a')

                    .Replace(',', 'a')

                    + video_extension;





                string localPath = System.IO.Path.Combine(documentsPath, localFilename);



                dialog.SetTitle("Download Complete");



                //Save file by using writeAsync

                FileStream fs = new FileStream(localPath, FileMode.OpenOrCreate);

                await fs.WriteAsync(bytes, 0, bytes.Length);

                fs.Close();



                dialog.Progress = 0;

            }



        }



        void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)

        {

            dialog.Progress = e.ProgressPercentage;

            if (e.ProgressPercentage == 100)

            {

                dialog.Hide();

            }

        }
    }
}