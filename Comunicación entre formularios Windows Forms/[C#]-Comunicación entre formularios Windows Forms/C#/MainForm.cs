using System;
using System.Windows.Forms;

namespace DialogForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Darth", "Vader", true);
            dataGridView1.Rows.Add("Luke", "Skywalker", false);
            dataGridView1.Rows.Add("Leia", "Organa", true);
            dataGridView1.Rows.Add("Han", "Solo", false);
            dataGridView1.Rows.Add("Obi-Wan", "Kenobi", true);
            dataGridView1.Rows.Add("Wilhuff", "Tarkin", false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView) sender;
            if (grid.Columns[e.ColumnIndex].Name != "EditColumn") return;

            var rowToEdit = grid.Rows[e.RowIndex];
            var dialog = new DialogForm
            {
                CurentPerson = new Person()
                {
                    Name = (string) rowToEdit.Cells["NameColumn"].Value,
                    Surname = (string) rowToEdit.Cells["SurnameColumn"].Value,
                    Active = (bool) rowToEdit.Cells["ActiveColumn"].Value
                }
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                rowToEdit.Cells["NameColumn"].Value = dialog.CurentPerson.Name;
                rowToEdit.Cells["SurnameColumn"].Value = dialog.CurentPerson.Surname;
                rowToEdit.Cells["ActiveColumn"].Value = dialog.CurentPerson.Active;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(
                    dialog.CurentPerson.Name,
                    dialog.CurentPerson.Surname,
                    dialog.CurentPerson.Active
                    );
            }
        }
    }
}
