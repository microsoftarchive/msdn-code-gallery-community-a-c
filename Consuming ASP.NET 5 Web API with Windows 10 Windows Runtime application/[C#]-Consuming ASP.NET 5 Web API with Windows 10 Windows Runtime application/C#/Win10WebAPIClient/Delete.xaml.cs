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
using System.Net.Http;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win10WebAPIClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Delete : Page
    {
        public Delete()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            message.Text = string.Format("Are you sure you want to delete {0}?", App.ActiveUser.Name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString())
            {
                case "Yes":
                    // Send a request to delete the user
                    using (var client = new HttpClient())
                    {
                        Task task = Task.Run(async () =>
                        {
                            await client.DeleteAsync(App.BaseUri + "/" + App.ActiveUser.ID.ToString());
                        });
                        task.Wait();
                    }
                    App.RootFrame.Navigate(typeof(MainPage));
                    break;
                case "Cancel":
                    App.RootFrame.Navigate(typeof(MainPage));
                    break;
                default:
                    break;
            }
        }
    }
}
