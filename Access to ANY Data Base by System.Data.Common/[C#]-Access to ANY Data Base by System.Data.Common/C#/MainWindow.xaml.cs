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

using System.Data;
using System.Data.Common;

namespace WpfCommonDataAccess
{
    /// <summary>
    /// You can also read 

    /// 
    /// </summary>
    public partial class MainWindow : Window
    {


       private string strProvider = "";
       private bool blnIsConnectionTrue = false;

        public MainWindow()
        {
            InitializeComponent();

            LoadProviders();
        }

       public void LoadProviders()
        {
            // Retrieve the installed providers and factories.
            DataTable table = DbProviderFactories.GetFactoryClasses();

            comboProviders.DisplayMemberPath = "Name";
            comboProviders.SelectedValuePath = "InvariantName";
            comboProviders.ItemsSource = table.DefaultView;
        
        }

        private void comboProviders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strProvider = comboProviders.SelectedValue.ToString();
            btnTest.Background = new SolidColorBrush(Colors.LightGray);
            blnIsConnectionTrue = false;
            txtStatus.Text = "";

            if (strProvider.IndexOf("OleDb")>=0)
            {
                DataOut newDataOut = new DataOut();
                newDataOut.dsResult = null;
                newDataOut.Show();

                // Need to subscribe ...

                newDataOut.runDBSql();
                listOpenDataOut.Add(newDataOut);
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
           
            string strError = "";

            blnIsConnectionTrue = db.TestConnection(strProvider,txtConnectionString.Text,out strError) ;
            
            if (blnIsConnectionTrue)
            {
              btnTest.Background = new SolidColorBrush(Colors.LightGreen);
              btnTest.Background = new SolidColorBrush(Colors.Green);
              txtStatus.Text = "Connection - OK.";
              txtStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnTest.Background = new SolidColorBrush(Colors.Red);
                txtStatus.Text = strError;
                txtStatus.Foreground = new SolidColorBrush(Colors.Red);
            }       
        }
 
        private void txtConnectionString_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (btnTest != null)
            {
              btnTest.Background = new SolidColorBrush(Colors.LightGray);
            }
            blnIsConnectionTrue = false;
        }

        private List<DataOut> listOpenDataOut = new List<DataOut>();

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if (blnIsConnectionTrue) 
            {
                DataOut newDataOut = new DataOut();
                newDataOut.dsResult = null;
                newDataOut.Show();

                listOpenDataOut.Add(newDataOut);

                // Need to subscribe ...

                newDataOut.runSQL(strProvider, txtConnectionString.Text, new StringBuilder(txtSQL.Text));
                txtStatus.Text = "RUN";
                txtStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                txtStatus.Text = "Please TEST Connection FIRST...";
                txtStatus.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        /// <summary>
        /// Close ALL child ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WPFCommonData_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (DataOut dout in listOpenDataOut)
            {
                try
                {
                  dout.Close();
                }
                catch{}
            }
            
        }

    }
}
