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
using Windows.Web.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win10WebAPIClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateOrUpdate : Page
    {
        bool? create { get; set; }
        public CreateOrUpdate()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Must be a request to update
            // Because if the "create" is null or true, 
            // it is to denote that the request is to create a new object
            if(e.Parameter as bool? == false)
            {
                create = e.Parameter as bool?;
                var user = App.ActiveUser;

                userId.Text = user.ID.ToString();
                name.Text = user.Name;
                gender.IsChecked = user.Gender; // True for male, false for female.
                interests.Text = string.Join(", ", user.Interests);

                actionButton.Content = "Update";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Content.ToString() == "Cancel")
            {
                // Go to default page 
                App.RootFrame.Navigate(typeof(MainPage));
                return; // and cancel the event.
            }

            // Otherwise
            var user = new User
            {
                ID = Convert.ToInt32(userId.Text),
                Name = name.Text,
                Gender = (gender.IsChecked == true) ? true : false,
                Interests = interests.Text.Split(',')
            };
            
            using(var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(user);

                if (create == null || create == true)
                {
                    // Send a POST
                    Task task = Task.Run(async () =>
                    {
                        var data = new HttpFormUrlEncodedContent(
                            new Dictionary<string, string>
                            {
                                ["value"] = content
                            }
                        );
                        await client.PostAsync(App.BaseUri, data);
                    });
                    task.Wait();
                }
                else
                {
                    // Send a PUT
                    Task task = Task.Run(async () =>
                    {
                        var data = new HttpFormUrlEncodedContent(
                            new Dictionary<string, string>
                            {
                                ["value"] = content,
                                ["id"] = App.ActiveUser.ID.ToString()
                            }
                        );
                        await client.PutAsync(App.BaseUri, data);
                    });
                    task.Wait();
                }
            }

            App.RootFrame.Navigate(typeof(MainPage));
        }
    }
}
