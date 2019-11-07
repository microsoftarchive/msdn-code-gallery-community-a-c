// Houssem Dellai
// houssem.dellai@ieee.org
// +216 95 325 964
// Studying Software Engineering
// in the National Engineering School of Sfax (ENIS)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebBrowserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void downloadButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.Navigate(webSiteAdr.Text);
        }

        private void refreshButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void forwardButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void helpButtonClick(object sender, RoutedEventArgs e)
        {
            //open my personal page on msdn.microsoft
            webBrowser1.Navigate("http://code.msdn.microsoft.com/Building-a-web-browser-in-C-8f992c88/view/Discussions#content");
        }

        private void mouseEnterEvent(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Width == 75)
            {
                b.Margin = new Thickness(b.Margin.Left - 4, b.Margin.Top - 1, b.Margin.Right, b.Margin.Bottom);
                b.Height += 3;
                b.Width += 8;
                b.FontSize += 2;
            }
        }

        private void mouseLeaveEvent(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Width == 83)
            {
                b.Margin = new Thickness(b.Margin.Left + 4, b.Margin.Top + 1, b.Margin.Right, b.Margin.Bottom);
                b.Height -= 3;
                b.Width -= 8;
                b.FontSize -= 2;
            }
        }
    }
}
