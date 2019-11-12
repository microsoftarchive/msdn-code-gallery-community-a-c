using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Add a using directive and a reference for System.Net.Http.
using System.Net.Http;

// Add the following using directive for System.Threading.
using System.Threading;

namespace StarterCode
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();

            try
            {
                int contentLength = await AccessTheWebAsync();
                resultsTextBox.Text +=
                    String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
            }
            catch (Exception)
            {
                resultsTextBox.Text += "\r\nDownload failed.\r\n";
            }
        }


        async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();

            resultsTextBox.Text +=
                String.Format("\r\nReady to download.\r\n");

            // You might need to slow things down to have a chance to cancel.
            await Task.Delay(250);

            // GetAsync returns a Task<HttpResponseMessage>. 
            // ***The ct argument carries the message if the Cancel button is chosen.
            HttpResponseMessage response = await client.GetAsync("http://msdn.microsoft.com/en-us/library/dd470362.aspx");

            // Retrieve the website contents from the HttpResponseMessage.
            byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

            // The result of the method is the length of the downloaded web site.
            return urlContents.Length;
        }
    }

    // Output:

    // Ready to download.

    // Length of the downloaded string: 158125.
}
