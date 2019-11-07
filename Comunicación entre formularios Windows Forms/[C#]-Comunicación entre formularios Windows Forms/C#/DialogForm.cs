using System;
using System.Windows.Forms;

namespace DialogForm
{
    public partial class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        internal Person CurentPerson
        {
            get
            {
                return new Person()
                {
                    Name= txtName.Text,
                    Surname = txtSurname.Text,
                    Active = chkActive.Checked
                };
            }
            set
            {
                txtName.Text = value == null ? string.Empty : value.Name;
                txtSurname.Text = value == null ? string.Empty : value.Surname;
                chkActive.Checked = value != null && value.Active;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
