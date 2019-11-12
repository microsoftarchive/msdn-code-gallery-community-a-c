using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NtierMvc.BusinessLogic;
using NtierMvc.Common;
using NtierMvc.Model;

namespace NtierMvcUserInterface
{
    public partial class EmployeesForm : Form
    {
        #region Class Declarations

        private LoggingHandler _loggingHandler;

        #endregion
        public EmployeesForm()
        {
            InitializeComponent();
        }

        private void ClearScreen()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtHiringDate.Text = string.Empty;
            txtGrossSalary.Text = string.Empty;
            txtNetSalary.Text = string.Empty;
            lvEmployees.Items.Clear();
        }

        private void InsertRowToListView(ListView lv, List<string> strValues)
        {
            var lvRowItem = new ListViewItem();

            try
            {
                lvRowItem.Text = strValues[0];
                for (int iCounter = 1; iCounter < strValues.Count; iCounter++)
                {
                    lvRowItem.SubItems.Add(strValues[iCounter]);
                }
                lv.Items.Add(lvRowItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UserInterface:EmployeesForm::InsertRowToListView::Error occured." +
                    Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void Insert(int id, string name, int age, DateTime? hiringDate, decimal grossSalary)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    var entity = new EmployeesEntity();
                    entity.Id = id;
                    entity.Name = name;
                    entity.Age = age;
                    entity.HiringDate = hiringDate;
                    entity.GrossSalary = grossSalary;
                    var opSuccessful = employees.InsertEmployee(entity);

                    var resultMessage = opSuccessful ? "Done Successfully" : "Error happened!";

                    MessageBox.Show(resultMessage, "Success", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                MessageBox.Show("UserInterface:EmployeesForm::Insert::Error occured." + 
                    Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void Update(int id, string name, int age, DateTime? hiringDate, decimal grossSalary)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    var entity = new EmployeesEntity();
                    entity.Id = id;
                    entity.Name = name;
                    entity.Age = age;
                    entity.HiringDate = hiringDate;
                    entity.GrossSalary = grossSalary;
                    var opSuccessful = employees.UpdateEmployee(entity);

                    var resultMessage = opSuccessful ? "Done Successfully" : "Error happened or no Employee found to update";

                    MessageBox.Show(resultMessage, "Success", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                MessageBox.Show("UserInterface:EmployeesForm::Update::Error occured." +
                    Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void Delete(int id)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    bool opSuccessful = employees.DeleteEmployeeById(id);

                    var resultMessage = opSuccessful ? "Done Successfully" : "Error happened or no Employee found to delete";

                    MessageBox.Show(resultMessage, "Success", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                MessageBox.Show("UserInterface:EmployeesForm::Delete::Error occured." +
                    Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private EmployeesEntity SelectOne(int id)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    return employees.SelectEmployeeById(id);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                MessageBox.Show("UserInterface:EmployeesForm::SelectOne::Error occured." +
                    Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
            }
            return null;
        }

        private List<EmployeesEntity> SelectAll()
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    return employees.SelectAllEmployees();
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                MessageBox.Show("UserInterface:EmployeesForm::SelectAll::Error occured." +
                    Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
            }
            return null;
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            _loggingHandler = new LoggingHandler();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert(
                int.Parse(txtId.Text),
                txtName.Text,
                int.Parse(txtAge.Text),
                txtHiringDate.Text.Trim().Length == 0 ? (DateTime?) null : DateTime.ParseExact(txtHiringDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None), 
                Math.Round(Decimal.Parse(txtGrossSalary.Text),3));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update(
                int.Parse(txtId.Text),
                txtName.Text,
                int.Parse(txtAge.Text),
                txtHiringDate.Text.Trim().Length == 0 ? (DateTime?)null : DateTime.ParseExact(txtHiringDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Math.Round(Decimal.Parse(txtGrossSalary.Text), 3));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(int.Parse(txtId.Text));
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            var entity = SelectOne(int.Parse(txtId.Text));
            if (entity != null)
            {
                txtName.Text = entity.Name;
                txtAge.Text = entity.Age.ToString();
                txtHiringDate.Text = string.IsNullOrEmpty(entity.HiringDate.ToString())
                    ? string.Empty : Convert.ToDateTime(entity.HiringDate).ToString("dd/MM/yyyy");
                txtGrossSalary.Text = entity.GrossSalary.ToString();
                txtNetSalary.Text = entity.NetSalary.ToString();
            }
            else
            {
                MessageBox.Show("No Employees Found!", "Warning", MessageBoxButtons.OK);
            }
        }
        
        private void btnList_Click(object sender, EventArgs e)
        {
            lvEmployees.Items.Clear();

            var employees = SelectAll();

            if (employees != null)
            {
                foreach (var emp in employees)
                {
                    var strListItems = new List<string>();
                    strListItems.Add(emp.Id.ToString());
                    strListItems.Add(emp.Name.ToString());
                    strListItems.Add(emp.Age.ToString());
                    strListItems.Add(string.IsNullOrEmpty(emp.HiringDate.ToString()) ? string.Empty : Convert.ToDateTime(emp.HiringDate).ToString("dd/MM/yyyy"));
                    strListItems.Add(emp.GrossSalary.ToString());
                    strListItems.Add(emp.NetSalary.ToString());

                    InsertRowToListView(lvEmployees, strListItems);
                }
            }
            else
            {
                MessageBox.Show("No Employees Found!", "Warning", MessageBoxButtons.OK);
            }


        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            //accepts only numbers
            if (e.KeyChar != 8 && e.KeyChar != 127)
            {
                if (e.KeyChar < 48 || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //accepts only numbers
            if (e.KeyChar != 8 && e.KeyChar != 127)
            {
                if (e.KeyChar < 48 || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void lvEmployees_Click(object sender, EventArgs e)
        {
            if (lvEmployees.SelectedItems.Count == 1)
            {
                txtId.Text = this.lvEmployees.SelectedItems[0].SubItems[0].Text;
                txtName.Text = this.lvEmployees.SelectedItems[0].SubItems[1].Text;
                txtAge.Text = this.lvEmployees.SelectedItems[0].SubItems[2].Text;
                txtHiringDate.Text = this.lvEmployees.SelectedItems[0].SubItems[3].Text;
                txtGrossSalary.Text = this.lvEmployees.SelectedItems[0].SubItems[4].Text;
                txtNetSalary.Text = this.lvEmployees.SelectedItems[0].SubItems[5].Text;
            }
        }

    }
}
