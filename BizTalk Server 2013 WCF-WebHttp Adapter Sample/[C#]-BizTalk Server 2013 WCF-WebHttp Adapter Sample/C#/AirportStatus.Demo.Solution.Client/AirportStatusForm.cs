using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AirportStatus.Demo.Solution.Client
{
    using SR_Airport;

    public partial class AirportStatusForm : Form
    {
        public AirportStatusForm()
        {
            InitializeComponent();
            FillComboboxAirports();
        }

        private void FillComboboxAirports()
        {
            //Set source string
            string sourcefile = Environment.CurrentDirectory + @"\Airports.xml";

            //Instantiate XMLDocument
            XmlDocument doc = new XmlDocument();
            //Load airports
            doc.Load(sourcefile);

            //Fill combobox
            XmlNodeList airportName = doc.SelectNodes("Airports/Airport");
            foreach (XmlNode dataSources in airportName)
            {
                comboBoxAirports.Items.Add(dataSources.Attributes["Name"].Value.ToString() + " " + dataSources.Attributes["Code"].Value.ToString());
            }

            //Display the first airport in the list
            comboBoxAirports.SelectedIndex = 0;
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            AirportServiceClient client = new AirportServiceClient();

            Request request = new Request();
            Response response = new Response();

            string airportcode = comboBoxAirports.SelectedItem.ToString().Substring(comboBoxAirports.SelectedItem.ToString().Length-3,3);

            request.AirportCode = airportcode;

            try
            {
                //Call service
                response = client.GetStatus(request);

                //Display result Status
                labelCityText.Text = response.City;
                labelStateText.Text = response.State;
                labelStatusText.Text = response.Status.Reason;

                //Display result Weather
                labelWindText.Text = response.Weather.Wind;
                labelTempratureText.Text = response.Weather.Temp;
                labelVisibilityText.Text = response.Weather.Visibility.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
