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
using System.Windows.Shapes;

namespace AutocompleteWpfSample
{
    /// <summary>
    /// Interaction logic for AutocompleteWithoutStackPanel.xaml
    /// </summary>
    public partial class AutocompleteWithoutStackPanel : Window
    {
        public AutocompleteWithoutStackPanel()
        {
            InitializeComponent();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Set the variables
            var data = Model.GetData();
            string query = (sender as TextBox).Text;

            if (query.Length > 0)
            {
                // Just sort to get the first possible search query
                data.Sort();

                // Now loop and find the first one
                foreach (var obj in data)
                {
                    if (obj.StartsWith(query))
                    {
                        // Yes, matches! Do stuff
                        TextBox target = sender as TextBox;
                        target.Text = obj;

                        // Do the selection-type thing
                        target.CaretIndex = query.Length;
                        target.SelectionStart = query.Length;
                        target.SelectionLength = obj.Length - query.Length;

                        // Break the loop
                        return;
                    }
                }
            }
        }
    }
}
