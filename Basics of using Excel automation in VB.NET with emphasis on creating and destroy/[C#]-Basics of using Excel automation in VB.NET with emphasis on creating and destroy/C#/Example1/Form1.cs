using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdSimpleOpenToSheet_Click(object sender, EventArgs e)
        {
            Simple1 Demo = new Simple1();
            Demo.OpenExcel(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample1.xlsx"), "Sheet1");
        }

        /// <summary>
        /// Here we get the sheet names for all sheets in the file Sample1.xlsx and as delievered,
        /// I placed the Sheet names out of order so they will show up in the ListBox in the ordinal
        /// position in the workbook. If we used OleDb to get sheet names OleDb will sort them a-z.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetSheets_Click(object sender, EventArgs e)
        {
            lstSheetNames.DataSource = null;
            Simple1 Demo = new Simple1();
            List<string> Names = Demo.GetSheetNames(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample1.xlsx"));
            lstSheetNames.DataSource = Names;
        }

        private void cmdCollectCellData_Click(object sender, EventArgs e)
        {
            Simple2 Demo = new Simple2();
            string Data = Demo.Collect(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CombinedTest.xlsx"), "Sheet1");
            MessageBox.Show(Data);
        }
    }
}