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
using System.Windows.Forms;

namespace AdWksSalesWinDataBind
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSalesOrders());
        }
    }
}
