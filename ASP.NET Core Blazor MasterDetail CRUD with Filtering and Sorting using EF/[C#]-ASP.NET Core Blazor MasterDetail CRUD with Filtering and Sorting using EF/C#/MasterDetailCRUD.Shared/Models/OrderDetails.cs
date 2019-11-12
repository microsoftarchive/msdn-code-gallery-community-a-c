using System;
using System.Collections.Generic;

namespace MasterDetailCRUD.Shared.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailNo { get; set; }
        public int OrderNo { get; set; }
        public string ItemName { get; set; }
        public string Notes { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}
