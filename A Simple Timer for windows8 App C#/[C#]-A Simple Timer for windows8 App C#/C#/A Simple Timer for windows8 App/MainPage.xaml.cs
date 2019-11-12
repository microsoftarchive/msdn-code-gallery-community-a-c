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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace A_Simple_Timer_for_windows8_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        private int i,j;

        public MainPage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            Init();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TimerTextBlock.Text = "Time Consumed: 0 second(s)";
        }

      
        void timer_Tick(object sender, object e)
        {
            
            TimerTextBlock.Text = "Time Consumed: " + (i) + " second(s)";
            i = i + j;
        }

       

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            StopButton.IsEnabled = false;
            StartButton.IsEnabled = true;
        }

        private void SetTimeButton_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }

        public void Init()
        {
            j=i = Convert.ToInt32(IntervalTextBox.Text);
            timer.Interval = TimeSpan.FromSeconds(i);
        }

       
       
    }
}
