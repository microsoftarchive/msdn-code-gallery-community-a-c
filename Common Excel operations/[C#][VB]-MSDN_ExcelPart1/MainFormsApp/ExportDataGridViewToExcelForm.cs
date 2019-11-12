using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelOperations;
using UtilityLibrary;

namespace MainApplication
{
    public partial class ExportDataGridViewToExcelForm : Form
    {
        private DataTable _dataTable;
        public DataTable DataTable
        {
            get { return _dataTable; }
        }
        public ExportDataGridViewToExcelForm()
        {
            InitializeComponent();
            Shown += ExportDataGridViewToExcelForm_Shown;
        }

        private void ExportDataGridViewToExcelForm_Shown(object sender, EventArgs e)
        {
            var ops = new DataOperations();
            var peopleList = ops.GetPeople();
            foreach (var person  in peopleList)
            {
                dataGridView1.Rows.Add(new object[] {person.Id,person.FirstName,person.LastName, person.BirthDay, person.Role, person.Gender});
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            _dataTable = dataGridView1.GetDataTable();
        }
    }
}
