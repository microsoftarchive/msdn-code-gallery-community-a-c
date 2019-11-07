using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SplashScreen
{
  
    /// Interaction logic for SplashWindow.xaml
   
    public partial class SplashWindow : Window
    {
        private MainWindow m_mainWindow;

        private DispatcherTimer splashAnimationTimer;

        private const string Loading = "Loading";
        public SplashWindow()
        {
            InitializeComponent();
            InitializeComponent();

            splashAnimationTimer = new DispatcherTimer();
            splashAnimationTimer.Interval = TimeSpan.FromMilliseconds(500);
            splashAnimationTimer.Tick += new EventHandler(splashAnimationTimer_Tick);
            splashAnimationTimer.Start();

            m_mainWindow = new MainWindow();

            m_mainWindow.ReadyToShow += new MainWindow.ReadyToShowDelegate(m_mainWindow_ReadyToShow);

            m_mainWindow.Closed += new EventHandler(m_mainWindow_Closed);
        }

        void splashAnimationTimer_Tick(object sender, EventArgs e)
        {
           

            int dotsCount = lblProgress.Content.ToString().Replace(Loading, string.Empty).Length;

            if (dotsCount < 6)
            {
                dotsCount++;
            }
            else
            {
                dotsCount = 0;
            }

            lblProgress.Content = Loading.PadRight(Loading.Length + dotsCount, '.');
        }

        void m_mainWindow_ReadyToShow(object sender, EventArgs args)
        {
           
            #region Animate the splash screen fading

            Storyboard sb = new Storyboard();
            //
            DoubleAnimation da = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };
            //
            Storyboard.SetTarget(da, this);
            Storyboard.SetTargetProperty(da, new PropertyPath(OpacityProperty));
            sb.Children.Add(da);
            //
            sb.Completed += new EventHandler(sb_Completed);
            //
            sb.Begin();

            #endregion //  splash screen fading With Animation.
        }

        void sb_Completed(object sender, EventArgs e)
        {
            // When the splash screen fades out, we can show the main window.....
            m_mainWindow.Visibility = System.Windows.Visibility.Visible;
        }

        void m_mainWindow_Closed(object sender, EventArgs e)
        {
           

            this.Close();
        }
    }
}

