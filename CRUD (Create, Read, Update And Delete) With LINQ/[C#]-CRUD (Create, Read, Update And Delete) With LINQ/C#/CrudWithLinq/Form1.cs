using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrudWithLinq
{
    public partial class Form1 : Form
    {
        string S_ID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txt_Name.Text = "";
            txt_LastName.Text = "";
            txt_NationalCode.Text = "";
        }

        private void txt_Name_Enter(object sender, EventArgs e)
        {
            txt_Name.ForeColor = Color.Blue;
            txt_Name.BackColor = SystemColors.Info;
        }

        private void txt_LastName_Enter(object sender, EventArgs e)
        {
            if (txt_Name.Text.Replace(" ", "") != "")
            {
                txt_LastName.ForeColor = Color.Blue;
                txt_LastName.BackColor = SystemColors.Info;
            }
            else { MessageBox.Show("Please enter Student Name", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information); txt_Name.Focus(); }
        }

        private void txt_NationalCode_Enter(object sender, EventArgs e)
        {
            if (txt_Name.Text.Replace(" ", "") != "" || txt_LastName.Text.Replace(" ", "") != "")
            {
                txt_NationalCode.ForeColor = Color.Blue;
                txt_NationalCode.BackColor = SystemColors.Info;
            }
            else
            {
                if (txt_Name.Text.Replace(" ", "") != "")
                {
                    MessageBox.Show("Please enter Student Name", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Name.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter Student Lastname", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_LastName.Focus();
                }
            }
        }

        private void txt_Name_Leave(object sender, EventArgs e)
        {
            txt_Name.ForeColor = SystemColors.WindowText;
            txt_Name.BackColor = SystemColors.Window;
        }

        private void txt_LastName_Leave(object sender, EventArgs e)
        {
            txt_LastName.ForeColor = SystemColors.WindowText;
            txt_LastName.BackColor = SystemColors.Window;
        }

        private void txt_NationalCode_Leave(object sender, EventArgs e)
        {
            txt_NationalCode.ForeColor = SystemColors.WindowText;
            txt_NationalCode.BackColor = SystemColors.Window;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Want To Exit ?", "CRUD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_Name.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    txt_LastName.Focus();
            }
        }

        private void txt_LastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_LastName.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    txt_NationalCode.Focus();
            }
        }

        private void txt_NationalCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_NationalCode.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    btn_Add_Click(null, null);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Replace(" ", "") != "" || txt_LastName.Text.Replace(" ", "") != "")
            {
                DialogResult dr = MessageBox.Show("Do you Want To Add ?", "CRUD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DbDataContext dbdc = new DbDataContext();
                    tbl_Student tbls = new tbl_Student()
                    {
                        S_Name = txt_Name.Text,
                        S_LastName = txt_LastName.Text,
                        S_NationalCode = txt_NationalCode.Text
                    };
                    dbdc.tbl_Students.InsertOnSubmit(tbls);
                    dbdc.SubmitChanges();
                    dgv_Data.DataSource = dbdc.tbl_Students;
                    S_ID = "";
                    Clear();
                }
            }
            else
            {
                if (txt_Name.Text.Replace(" ", "") != "")
                {
                    MessageBox.Show("Please enter Student Name", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Name.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter Student Lastname", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_LastName.Focus();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbl_StudentTableAdapter.Fill(studentsDataSet.tbl_Student);
        }

        private void dgv_Data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_Data.Rows[dgv_Data.CurrentRow.Index].Cells[0].Value.ToString() != null)
            {
                S_ID = dgv_Data.Rows[dgv_Data.CurrentRow.Index].Cells[0].Value.ToString();
                txt_Name.Text = dgv_Data.Rows[dgv_Data.CurrentRow.Index].Cells[1].Value.ToString();
                txt_LastName.Text = dgv_Data.Rows[dgv_Data.CurrentRow.Index].Cells[2].Value.ToString();
                txt_NationalCode.Text = dgv_Data.Rows[dgv_Data.CurrentRow.Index].Cells[3].Value.ToString();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Replace(" ", "") != "" || txt_LastName.Text.Replace(" ", "") != "")
            {
                DialogResult dr = MessageBox.Show("Do you Want To Edit ?", "CRUD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DbDataContext dbdc = new DbDataContext();
                    var Edit = dbdc.tbl_Students.Where(tbl_Students => tbl_Students.S_ID == int.Parse(S_ID)).Single();
                    Edit.S_Name = txt_Name.Text;
                    Edit.S_LastName = txt_LastName.Text;
                    Edit.S_NationalCode = txt_NationalCode.Text;
                    dbdc.SubmitChanges();
                    dgv_Data.DataSource = dbdc.tbl_Students;
                    S_ID = "";
                    Clear();
                }
            }
            else
            {
                if (txt_Name.Text.Replace(" ", "") != "")
                {
                    MessageBox.Show("Please enter Student Name", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Name.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter Student Lastname", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_LastName.Focus();
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Replace(" ", "") != "" || txt_LastName.Text.Replace(" ", "") != "")
            {
                DialogResult dr = MessageBox.Show("Do you Want To Delete This Row ?", "CRUD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DbDataContext dbdc = new DbDataContext();
                    var Delete = dbdc.tbl_Students.Where(tbl_Students => tbl_Students.S_ID == int.Parse(S_ID)).Single();
                    dbdc.tbl_Students.DeleteOnSubmit(Delete);
                    dbdc.SubmitChanges();
                    dgv_Data.DataSource = dbdc.tbl_Students;
                    S_ID = "";
                    Clear();
                }
            }
            else
            {
                if (txt_Name.Text.Replace(" ", "") != "")
                {
                    MessageBox.Show("Please enter Student Name", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Name.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter Student Lastname", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_LastName.Focus();
                }
            }
        }
    }
}