using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Win10WebAPIClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString())
            {
                case "Create":
                    App.RootFrame.Navigate(typeof(CreateOrUpdate), true);
                    break;
                case "Read":
                    App.RootFrame.Navigate(typeof(View));
                    break;
                case "Update":
                    App.RootFrame.Navigate(typeof(CreateOrUpdate), false);
                    break;
                case "Delete":
                    App.RootFrame.Navigate(typeof(Delete));
                    break;
                default:
                    break;
            }
        }
    }

    // Actual data model
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string[] Interests { get; set; }
    }
}
