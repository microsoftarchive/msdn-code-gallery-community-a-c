using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5Core2.Data
{
    public class InventoryMaster
    {
		[Key]
		public int InventoryID { get; set; }

		[Required]
		[Display(Name = "ItemName")]
		public string ItemName { get; set; }

		[Required]
		[Display(Name = "StockQty")]
		public int StockQty { get; set; }

		[Required]
		[Display(Name = "ReorderQty")]
		public int ReorderQty { get; set; }

		public int PriorityStatus { get; set; }
	}
}
