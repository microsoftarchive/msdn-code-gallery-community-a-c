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
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdWksSalesWinDataBind
{
    public partial class FormAddSalesOrderDetail : Form
    {
        SalesOrderHeader currentOrder;
        AdventureWorksEntities parentCxt;
        SalesOrderDetail newSalesOrderDetail;
        Product selectedProduct;
                
        public FormAddSalesOrderDetail(AdventureWorksEntities ctx, SalesOrderHeader order)
        {
            InitializeComponent();

            parentCxt = ctx;
            currentOrder = order;
        }

        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formAddSalesOrderDetail_Load(object sender, EventArgs e)
        {
            if (currentOrder == null)
            {
                throw new ApplicationException("A valid SalesOrderHeader must be supplied");  
            }

            try
            {
                // Get the list of Products.
                ObjectQuery<Product> products = parentCxt.Product
                    .Where("it.FinishedGoodsFlag == true AND it.DiscontinuedDate IS NULL");
            
                // Bind to the query execution.
                productsBindingSource.DataSource = products.Execute(MergeOption.NoTracking);

                // Create a new SalesOrderDetail instance and bind to the data source.
                newSalesOrderDetail = SalesOrderDetail.CreateSalesOrderDetail(
                        currentOrder.SalesOrderID, 9999, 1, 0, 1,
                        0, 0, 0, Guid.NewGuid(), DateTime.Now);
                salesOrderDetailBindingSource.DataSource = newSalesOrderDetail;

                buttonAddNewDetail.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonAcceptNewOrder_Click(object sender, EventArgs e)
        {
            try
            { 
                // Add the detail to the details for the current order.
                currentOrder.SalesOrderDetail.Add(newSalesOrderDetail);

                // Update the order totals.
                currentOrder.UpdateOrderTotal();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Msg: " + exception.Message + "\r\nInner Exception: " +
                    exception.InnerException);
            }
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonAddNewDetail.Enabled = true;
            
            // Get the selected product from the grid.
            selectedProduct = (Product)productsBindingSource.Current;

            // Ensure that the product isn't already in the order.
            foreach (SalesOrderDetail item in currentOrder.SalesOrderDetail)
            {
                if (selectedProduct.ProductID == item.ProductID)
                {
                    MessageBox.Show(string.Format("The order already contains the item {0}."
                        + "\nPlease update the quantity of the existing item.", 
                        selectedProduct.Name));

                    return;
                }
            }

            // Set the properties on the new detail.
            newSalesOrderDetail.ProductID = selectedProduct.ProductID;
            newSalesOrderDetail.UnitPrice = selectedProduct.StandardCost;
        }
    }
}

