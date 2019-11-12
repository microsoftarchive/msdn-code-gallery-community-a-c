using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CountChecked
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = GetMockedData();
            dataGridView1.Columns["Rate"].DefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleRight;
        }

        private DataTable GetMockedData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Identifier", typeof(int));
            dt.Columns.Add("Room", typeof(string));
            dt.Columns.Add("RoomType", typeof(string));
            dt.Columns.Add("Rate", typeof(decimal));

            // data mock up coming from a database table
            dt.Rows.Add(10, "201A", "Suite", 98.99);
            dt.Rows.Add(20, "101A", "Suite", 120.99);
            dt.Rows.Add(30, "201B", "Suite", 99.99);

            // append a bool column to the data table
            dt.Columns.Add("Available", typeof(bool));
            // change position so it's the first column in the DataGridView
            dt.Columns["Available"].SetOrdinal(0);
            // hide it, we don't normally need to see a primary key
            dt.Columns["Identifier"].ColumnMapping = MappingType.Hidden;

            // give default value else later we will get a invalid cast.
            foreach (DataRow row in dt.Rows)
            {
                row.SetField<bool>("Available", false);
            }

            return dt;
        }
        private void checkCountButton_Click(object sender, EventArgs e)
        {
            int checkRowCount = dataGridView1.DataTable().CheckedRowCount("Available");
            if (checkRowCount > 0)
            {
                MessageBox.Show("Rooms checked count: " + checkRowCount.ToString());
            }
            else
            {
                MessageBox.Show("No rooms checked");
            }
        }

        private void checkListButton_Click(object sender, EventArgs e)
        {
            List<DataRow> listChecked = dataGridView1.DataTable().CheckedRows("Available");
            if (listChecked.Count() >0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (DataRow row in listChecked)
                {
                    sb.AppendLine(row.Field<string>("Room"));
                }
                MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show("No rooms checked");
            }
        }
    }
}