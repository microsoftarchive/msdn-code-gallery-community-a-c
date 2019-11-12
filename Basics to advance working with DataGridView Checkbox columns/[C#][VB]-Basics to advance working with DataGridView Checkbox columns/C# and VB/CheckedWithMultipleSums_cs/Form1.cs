using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CheckedWithMultipleSums
{
    /// <summary>
    /// Shows how to get a list of DataRows from our DataGridView which
    /// has a DataSource of DataTable where column 0 is a DataGridViewCheckBoxColumn
    /// that is checked. When checked we will sum the values of two int columns.
    /// 
    /// Button one uses a language extension method (as does button2) to get checked rows
    /// then two variables to return sums.
    /// 
    /// Button two used a linq with a group to get the sums, no extra variables as in Button1
    /// </summary>
    public partial class Form1 : Form
    {
        private string checkBoxColumnName = "Process";
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Mimic load from database table where the database
        /// table has no column to use for allowing the user to
        /// check rows for processing. In the case we want to
        /// have a DataGridViewCheckBoxColumn in column 0 of our
        /// DataGridView. I add a DataColumn in form load for this
        /// where the DataColumn is moved to the first column and
        /// each rows values are set to false.
        /// </summary>
        /// <returns></returns>
        private DataTable GetMockedData()
        {
            DataTable dtMockedData = new DataTable();

            dtMockedData.Columns.Add("Identifier", typeof(int));
            dtMockedData.Columns.Add("LastName", typeof(string));
            dtMockedData.Columns.Add("Value1", typeof(int));
            dtMockedData.Columns.Add("Value2", typeof(int));

            dtMockedData.Rows.Add(10, "Smith", 10, 12);
            dtMockedData.Rows.Add(20, "Jones", 20, 22);
            dtMockedData.Rows.Add(30, "Payne", 1, 1);
            dtMockedData.Rows.Add(40, "Gallagher", 4, 5);
            dtMockedData.Rows.Add(50, "Clime", 20, 56);

            return dtMockedData;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = GetMockedData();

            /*
             * Created a new data column for use as a checkbox
             * and move it to the first column followed by setting
             * value to false rather than null.
             */
            dt.Columns.Add(checkBoxColumnName, typeof(bool));
            dt.Columns[checkBoxColumnName].SetOrdinal(0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i].SetField<bool>("Process", false);
            }

            DataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataRow> checkedRows = DataGridView1.GetRowsChecked(checkBoxColumnName);
            if (checkedRows.Count > 0)
            {
                int Value1Sum = checkedRows.Select((row) => 
                    row.Field<int>("Value1")).Sum();
                int Value2Sum = checkedRows.Select((row) => 
                    row.Field<int>("Value2")).Sum();

                Console.WriteLine("Value1: {0} Value2: {1}", Value1Sum, Value2Sum);
            }
            else
            {
                Console.WriteLine("Nothing checked");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var results = (
                from dataRow in DataGridView1
                    .GetRowsChecked(checkBoxColumnName)
                    .GroupBy((item) => 3 > 0)
                    .Select(
                            groupRow => new Item
                            {
                                Value1Sum = groupRow.Sum((row) => 
                                    row.Field<int>("Value1")),
                                Value2Sum = groupRow.Sum((row) => 
                                    row.Field<int>("Value2"))
                            }
                    )
                select dataRow)
            .FirstOrDefault();

            if (results != null)
            {
                Console.WriteLine("Value1: {0} Value2: {1}", results.Value1Sum, results.Value2Sum);
            }
            else
            {
                Console.WriteLine("Nothing checked");
            }   
        }
    }
}