using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using CRUD_Model;

namespace CRUD_WF
{
    public partial class CRUDForm : Form
    {
        private int pageNumber = 1;
        private int pageSize = 0;
        private string baseUrl = string.Empty;
        private string url = string.Empty;

        public CRUDForm()
        {
            InitializeComponent();
            baseUrl = txtUrl.Text.ToString().Trim();
            pageSize = 5;
            url = baseUrl + "api/Customer?pageSize=" + pageSize;
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {
            GetCustomer_(url);
        }

        private async void GetCustomer_(string url)
        {
            try
            {
                using (var objClient = new HttpClient())
                {
                    using (var response = await objClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var productJsonString = await response.Content.ReadAsStringAsync();
                            dgList.DataSource = JsonConvert.DeserializeObject<tblCustomer[]>(productJsonString).ToList();
                        }
                    }
                }
            }
            catch
            {
                pageSize = 5; pageNumber = 1;
                MessageBox.Show("Invalid URL!!");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                CreateCustomer();
            }
            else
            {
                if (lblCustID.Text == "")
                {
                    MessageBox.Show("Please Select a Customer to Edit");
                }
                else
                {
                    EditCustomer();
                }
            }
        }

        private async void CreateCustomer()
        {
            try
            {
                string InsertUrl = baseUrl + "api/Customer/Create";
                tblCustomer objCust = new tblCustomer();
                objCust.CustName = txtCustName.Text.ToString();
                objCust.CustEmail = txtCustEmail.Text.ToString();
                objCust.CustAddress = txtCustAddress.Text.ToString();
                objCust.CustContact = txtCustContact.Text.ToString();

                if ((objCust != null) && (objCust.CustEmail != ""))
                {
                    using (var objClient = new HttpClient())
                    {
                        string contentType = "application/json";
                        var serializedCustomer = JsonConvert.SerializeObject(objCust);
                        var content = new StringContent(serializedCustomer, Encoding.UTF8, contentType);
                        var result = await objClient.PostAsync(InsertUrl, content);
                        GetCustomer_(url);
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Email Id is Must!");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Customer!!");
            }
        }

        private async void EditCustomer()
        {
            try
            {
                string EditUrl = baseUrl + "api/Customer/Edit";
                tblCustomer objCust = new tblCustomer();

                objCust.CustID = Convert.ToInt32(lblCustID.Text);
                objCust.CustName = txtCustName.Text.ToString();
                objCust.CustEmail = txtCustEmail.Text.ToString();
                objCust.CustAddress = txtCustAddress.Text.ToString();
                objCust.CustContact = txtCustContact.Text.ToString();

                if ((objCust != null) && (objCust.CustEmail != ""))
                {
                    using (var objClient = new HttpClient())
                    {
                        string contentType = "application/json";
                        var serializedCustomer = JsonConvert.SerializeObject(objCust);
                        var content = new StringContent(serializedCustomer, Encoding.UTF8, contentType);
                        var result = await objClient.PostAsync(EditUrl, content);
                        GetCustomer_(url);
                    }
                }
                else
                {
                    MessageBox.Show("Email Id is Must!");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Customer!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCustID.Text == "")
                {
                    MessageBox.Show("Please Select a Customer to Delete");
                }
                else
                {
                    DialogResult result = MessageBox.Show("You are about to delete " + txtCustName.Text + " permanently. Are you sure you want to delete this record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        long CustID = Convert.ToInt64(lblCustID.Text);
                        DeleteCustomer(CustID);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid Customer!!");
            }
        }

        private async void DeleteCustomer(long? id)
        {
            try
            {
                string DeleteUrl = baseUrl + "api/Customer/Delete";
                using (var objClient = new HttpClient())
                {
                    var result = await objClient.DeleteAsync(String.Format("{0}/{1}", DeleteUrl, id));
                }

                GetCustomer_(url);
            }
            catch
            {
                MessageBox.Show("Invalid Customer!!");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lblCustID.Text = "";
            txtCustName.Text = "";
            txtCustEmail.Text = "";
            txtCustAddress.Text = "";
            txtCustContact.Text = "";
            btnSubmit.Text = "Submit";
            txtCustEmail.ReadOnly = false;
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baseUrl = txtUrl.Text.ToString().Trim();
            }
            catch
            {
                MessageBox.Show("Invalid Approach!!");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (pageNumber == 0)
                    pageNumber = 1;

                pageSize = 5; pageNumber++;

                string url = baseUrl + "api/Customer?pageNumber=" + pageNumber + "&pageSize=" + pageSize;
                GetCustomer_(url);
                btnReload.Text = "Page View: " + pageNumber.ToString() + "/Reload..";
            }
            catch
            {
                MessageBox.Show("Invalid Approach!!");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                pageSize = 5; pageNumber--;
                if (pageNumber == 0)
                    pageNumber = pageNumber + 1;

                string url = baseUrl + "api/Customer?pageNumber=" + pageNumber + "&pageSize=" + pageSize;
                GetCustomer_(url);
                btnReload.Text = "Page View: " + pageNumber.ToString() + "/Reload..";
            }
            catch
            {
                MessageBox.Show("Invalid Approach!!");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            pageSize = 5;
            pageNumber = 1;
            GetCustomer_(url);
            btnReload.Text = "Reload..";
        }

        private void dgList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgList.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgList.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgList.Rows[selectedrowindex];

                    lblCustID.Text = Convert.ToString(selectedRow.Cells[0].Value);
                    txtCustName.Text = Convert.ToString(selectedRow.Cells[1].Value);
                    txtCustEmail.Text = Convert.ToString(selectedRow.Cells[2].Value);
                    txtCustAddress.Text = Convert.ToString(selectedRow.Cells[3].Value);
                    txtCustContact.Text = Convert.ToString(selectedRow.Cells[4].Value);
                    btnSubmit.Text = "Update";
                    txtCustEmail.ReadOnly = true;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Customer!!");
            }

        }
    }
}
