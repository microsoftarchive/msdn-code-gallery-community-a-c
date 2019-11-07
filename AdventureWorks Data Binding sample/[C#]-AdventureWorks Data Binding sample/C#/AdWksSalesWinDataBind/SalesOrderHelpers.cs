///////////////////////////////////////////////////////////////
//
// This code is part of the AdventureWorks Data Binding sample.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
///////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using AdWksSalesWinDataBind.Properties;

namespace AdWksSalesWinDataBind
{
    public partial class SalesOrderHeader
    {
        // Update the order total.
        public void UpdateOrderTotal()
        {
            decimal newSubTotal = 0;

            // In a real world application this information should be included in the EDM.
            decimal taxRate = Settings.Default.currentSalesTaxRate;
            decimal freight = Settings.Default.currentFreight;

            // If the items for this order are loaded or if the order is 
            // newly added, then recalculate the subtotal as it may have changed.
            if (SalesOrderDetail.IsLoaded ||
                EntityState == EntityState.Added)
            {
                foreach (SalesOrderDetail item in this.SalesOrderDetail)
                {
                    // Calculate line totals for loaded items.
                    newSubTotal += item.LineTotal;
                }

                this.SubTotal = newSubTotal;
            }

            // Calculate the new tax amount.
            this.TaxAmt = this.SubTotal * taxRate;

            // Calculate the new freight amount.
            this.Freight = this.SubTotal * freight;

            // Calculate the new total.
            this.TotalDue = this.SubTotal + this.TaxAmt + this.Freight;
        }
    }
    public partial class SalesOrderDetail
    {
        // Update the line total.
        public void UpdateLineTotal()
        {
            this.LineTotal = this.OrderQty *
                (this.UnitPrice * (1 - this.UnitPriceDiscount));

            if (this.SalesOrderHeader != null)
            {
                // Ensure that we update the totals in the related order.
                this.SalesOrderHeader.UpdateOrderTotal();
            }
        }
        partial void OnOrderQtyChanging(short value)
        {
            // Validate the supplied value.
            if (value < 1)
            {
                throw new ApplicationException("An order must be 1 or more items.");
            }
        }
        partial void OnOrderQtyChanged()
        {
            // Update the line total to reflect the new quantity;
            this.UpdateLineTotal();
        }
        partial void OnUnitPriceDiscountChanging(decimal value)
        {
            // Validate the supplied value.
            if (value < 0 || value > 1)
            {
                throw new ApplicationException("Discount rate is between 0 and 1.");
            }
        }
        partial void OnUnitPriceDiscountChanged()
        {
            // Update the line total to reflect the new discount;
            this.UpdateLineTotal();
        }
    }
}
