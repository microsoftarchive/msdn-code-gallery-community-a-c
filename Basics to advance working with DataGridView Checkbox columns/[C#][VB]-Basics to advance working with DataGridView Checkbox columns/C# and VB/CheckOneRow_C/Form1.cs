using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckOneRow_C
{
    public partial class frmMainForm : Form
    {

        private BindingSource bsRooms = new BindingSource();

        public frmMainForm() { InitializeComponent(); }
        private DataTable GetMockedData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Identifier", typeof(int));
            dt.Columns.Add("Room", typeof(string));
            dt.Columns.Add("RoomType", typeof(string));
            dt.Columns.Add("Rate", typeof(decimal));
            dt.Columns.Add("Available", typeof(bool));

            dt.Rows.Add(10, "201A", "Suite", 98.99, false);
            dt.Rows.Add(20, "101A", "Suite", 120.99, false);
            dt.Rows.Add(30, "201B", "Suite", 99.99, false);

            dt.AcceptChanges();

            return dt;

        }
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            DataGridView1.AutoGenerateColumns = false;
            bsRooms.DataSource = GetMockedData();
            DataGridView1.DataSource = bsRooms;

            DataTable dt = (DataTable)bsRooms.DataSource;
            dt.ColumnChanged += dt_ColumnChanged;
            DataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            DataGridView1.KeyUp += DataGridView1_KeyUp;
        }

        private void DataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                if (DataGridView1.Columns["AvailableColumn"].Index == DataGridView1.CurrentCell.ColumnIndex)
                {
                    Int32 CurrentIdentifier = ((DataRowView)bsRooms.Current).Row.Field<Int32>("Identifier");
                    bool Checked = !(((DataRowView)bsRooms.Current).Row.Field<bool>("Available"));

                    DataGridView1.CurrentRow.Cells["AvailableColumn"].Value = Checked;

                    if (Checked)
                    {
                        DataTable dt = (DataTable)bsRooms.DataSource;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (!(row.Field<Int32>("Identifier") == CurrentIdentifier))
                            {
                                row.SetField<bool>("Available", false);
                            }
                        }

                    }

                    e.Handled = true;

                }
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name == "AvailableColumn")
                {
                    DataGridView1.EndEdit();
                    bool Checked = Convert.ToBoolean(DataGridView1.CurrentCell.Value);
                }
            }
        }

        private void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "Available")
            {
                Int32 CurrentRow = DataGridView1.CurrentCell.RowIndex;
                Int32 CurrentCol = DataGridView1.CurrentCell.ColumnIndex;

                bool Checker = false;

                if (bool.TryParse(e.ProposedValue.ToString(), out Checker))
                {

                    if (Checker)
                    {

                        string ID = bsRooms.CurrentRow("Identifier");
                        DataTable dt = (DataTable)bsRooms.DataSource;

                        foreach (DataRow row in dt.Rows)
                        {
                            string ThisId = row["Identifier"].ToString();
                            if (!(row["Identifier"].ToString() == ID))
                            {
                                row.SetField<bool>("Available", false);
                            }
                        }

                        dt.AcceptChanges();

                    }

                    bsRooms.ResetCurrentItem();
                    DataGridView1.CurrentCell = DataGridView1[CurrentCol, CurrentRow];
                }
            }
        }
    }
}
