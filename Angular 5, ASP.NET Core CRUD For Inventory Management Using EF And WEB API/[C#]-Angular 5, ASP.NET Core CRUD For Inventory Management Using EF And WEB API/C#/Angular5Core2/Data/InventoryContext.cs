using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5Core2.Data
{
    public class InventoryContext : DbContext
	{
		public InventoryContext(DbContextOptions<InventoryContext> options)  
            :base(options) { }
		public InventoryContext() { }
		public DbSet<InventoryMaster> InventoryMaster { get; set; }
	}
}
