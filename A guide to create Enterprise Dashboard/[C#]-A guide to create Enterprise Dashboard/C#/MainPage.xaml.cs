using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Visifire.Commons;
using System.Windows.Browser;

namespace ProductAndSales
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Logo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.visifire.com"));
        }

        private void Logo_MouseEnter(object sender, MouseEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            fe.Opacity = 0.6;
        }

        private void Logo_MouseLeave(object sender, MouseEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            fe.Opacity = 1;
        }
    }
}