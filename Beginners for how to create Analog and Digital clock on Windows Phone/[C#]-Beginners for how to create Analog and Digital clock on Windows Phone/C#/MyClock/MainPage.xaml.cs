using System;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Windows.Threading;
using Microsoft.Phone.Shell;

namespace Analog_Clock
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
            phoneAppService.UserIdleDetectionMode = IdleDetectionMode.Disabled;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SecondHand.Begin();
            LongHand.Begin();
            HourHand.Begin();

            int second = DateTime.Now.Second;
            SecondHand.Seek(new TimeSpan(0, 0, second));

            int minutes = DateTime.Now.Minute;
            LongHand.Seek(new TimeSpan(0, minutes, second));

            int hour = DateTime.Now.Hour;
            HourHand.Seek(new TimeSpan(hour, minutes, second));

        }


        void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            txtDigitalClock.Text = dt.ToString("MM/dd HH:mm:ss");
        }

    }
}