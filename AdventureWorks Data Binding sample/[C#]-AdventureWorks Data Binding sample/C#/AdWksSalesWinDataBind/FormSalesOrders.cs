///////////////////////////////////////////////////////////////
//
// This code is part of the AdventureWorks Data Binding sample.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
///////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;

namespace AdWksSalesWinDataBind
{
    public partial class FormSalesOrders : Form
    {
        // Define a long-running object content used by the form.
        // This content must be persisted because controls are bound to
        // data in this ObjectContext instance.
        private AdventureWorksEntities objCtx;

        // Define the SalesOrderHeader object for the selected order.
        private SalesOrderHeader currentOrder;

        public FormSalesOrders()
        {
            InitializeComponent();
            objCtx = new AdventureWorksEntities();
        }

        private void GetOrderBindResults(int orderID)
        {
            // Get the SalesOrderHeader and related SalesOrderDetails object for the order
            // with the specified SalesOrderID value, overwriting local changes with 
            // values from the database.
            ObjectQuery<SalesOrderHeader> orderQuery = 
                objCtx.SalesOrderHeader.Include("SalesOrderDetail")
                .Where("it.SalesOrderID == @p", new ObjectParameter("p", orderID));
            orderQuery.MergeOption = MergeOption.OverwriteChanges;
                           
            // Bind the SalesOrderHeader binding source to execution of the first returned object.
            bindingSourceOrders.DataSource = orderQuery.First();

            // Set the current order to the bound object.
            currentOrder = (SalesOrderHeader)bindingSourceOrders.Current;

            this.Refresh();
        }

        private void buttonGetOrder_Click(object sender, EventArgs e)
        {
            int orderNumber;
            buttonDeleteDetail.Enabled = false;

            try
            {
                // Get the order number.
                orderNumber = Int32.Parse(txtOrderNumber.Text);

                // Call the method that gets the order and items.
                this.GetOrderBindResults(orderNumber);

                buttonAddSalesOrder.Enabled = true; 
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Ensure that the supplied SalesOrderID "
                    + "value {0} is a valid order number.",
                    txtOrderNumber.Text), "Invalid Order Number");

                ResetForm();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(String.Format("No orders were found with the SalesOrderID value {0}",
                    txtOrderNumber.Text), "Order Does Not Exist");

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occured");

                ResetForm();
            }
        }

        private void buttonAddSalesOrder_Click(object sender, EventArgs e)
        {  
            FormAddSalesOrderDetail formAddSODetail = 
                new FormAddSalesOrderDetail(objCtx, currentOrder);
        
            DialogResult dlgResult = formAddSODetail.ShowDialog(this);

            if (dlgResult.Equals(DialogResult.Cancel))
            {
                // Call the method that gets the order and items.
                MessageBox.Show("The item was not added to the order.",
                    "Item Addition Cancelled");
            }
        }

        private void SaveChanges()
        {
            try
            {
                // Save changes to the database.
                objCtx.SaveChanges();

                MessageBox.Show("All pending changes saved to the database.", "Changes Saved");

                // Re-execute the query for the current order and 
                // rebind the controls to the latest results.
                GetOrderBindResults(currentOrder.SalesOrderID);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(String.Format("An error has occured when trying to save changes to the sales order {0} \n"
                + "The changes have been rolled-back. \nRequery for sales order '{2}' and retry the operation.",
                currentOrder.SalesOrderID),"Changes Not Saved");
            }
            catch (OptimisticConcurrencyException)
            {
                MessageBox.Show(String.Format("An error has occured when trying to save changes to the sales order {0} \n"
                + "The changes have been rolled-back. \nRequery for sales order '{2}' and retry the operation.",
                currentOrder.SalesOrderID), "Concurrency Violation");
            }
        }

        private void buttonDeleteDetail_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected detail from the grid.
                SalesOrderDetail selectedDetail =
                    (SalesOrderDetail)bindingSourceOrderDetails.Current;

                // Call the method to delete the specific order detail.
                objCtx.DeleteObject(selectedDetail);

                // Update the order total.
                currentOrder.UpdateOrderTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error has occured: \n\t" + ex.Message, "Error");
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error has occured: \n\t" + ex.Message, "Error");
            }
        }
  
        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Check the state manager to ensure that we don't have any unsaved changes.
            if (objCtx.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Deleted | EntityState.Modified).Count() > 0)
            {
               DialogResult dr = MessageBox.Show("There are unsaved changes. Do you want to " +
                    " save changes before you exit?","Unsaved Changes",MessageBoxButtons.YesNoCancel);

               switch (dr)
               {
                   case DialogResult.Yes:
                       // Call SaveChanges.
                       this.SaveChanges();
                       break;
                   case DialogResult.No:
                       this.Close();
                       break;
                   case DialogResult.Cancel:
                       // Cancel the operation if the user doesn't want to close.
                       return;                       
               }
            }
            this.Close();
        }

        private void Form1_FormClosing(object sender,
            FormClosingEventArgs e)
        {
            // Dispose the long running object context.
            objCtx.Dispose();
        }

        private void ResetForm()
        {
            buttonAddSalesOrder.Enabled = false;
            buttonGetOrder.Enabled = false;
            buttonDeleteDetail.Enabled = false;
            txtOrderNumber.Focus();
            txtOrderNumber.SelectAll();
        }
        
        private void txtOrderNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
                buttonGetOrder_Click(this, System.EventArgs.Empty);
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            this.buttonGetOrder.Enabled = true;
        }

        private void dataGridViewOrderDetails_RowHeaderMouseClick(object sender, 
            DataGridViewCellMouseEventArgs e)
        {
            buttonDeleteDetail.Enabled = true;
        }

        private void dataGridViewOrderDetails_DataError(object sender,
            DataGridViewDataErrorEventArgs error)
        {
            if (error.Exception != null)
            {
                MessageBox.Show(error.Exception.Message, "Validation Error");
                error.Cancel = true;
            }
        }
    }
}
