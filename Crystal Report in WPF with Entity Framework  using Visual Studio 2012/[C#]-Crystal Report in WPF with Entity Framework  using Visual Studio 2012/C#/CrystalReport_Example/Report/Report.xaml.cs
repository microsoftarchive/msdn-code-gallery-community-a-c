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
using CrystalReport_Example.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace CrystalReport_Example.Report
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        private void CrystalReportViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ReportDocument rd = new ReportDocument();
                rd.Load("C:/Users/MUSAKKHIR/Documents/visual studio 2012/Projects/CrystalReport_Example/CrystalReport_Example/Report/MyReport.rpt");
                using (MyDBEntities context = new MyDBEntities())
                {
                    var q = (from c in context.CUSTOMERs
                             join p in context.Cities
                             on c.City_ID equals p.City_ID
                             select new
                             {
                                 c.Cust_Id,
                                 c.Cust_Name,
                                 c.Address,
                                 p.City_Name,
                                 c.Gender
                             }).ToList();
                    rd.SetDataSource(q);
                    CrystalReportViewer1.ViewerCore.ReportSource = rd;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
